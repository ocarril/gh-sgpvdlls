namespace CROM.Tools.Comun.helpers
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Reflection;
    using System.Xml;
    using ZXing;
    using ZXing.QrCode;
    using System.IO.Compression;
    using System.Collections.Generic;
    using System.Globalization;

    public static class HelpSUNAT
    {

                      

        public static Bitmap GenerarCodigoQR(string pEmisorRUC,
                                             string Tipocomprobante,
                                             string Numeracion,
                                             string SumatoriaIGV,
                                             string ImporteTotalVenta,
                                             string FechaEmision,
                                             string TipoDocumentoAdquirente,
                                             string NumeroDocumentoAdquirente,
                                             string CodigoHash,
                                             bool pSaveImgQR,
                                             string pPathFileName,
                                             string pUserLogin,
                                             out string pMessajeError)
        {
            pMessajeError = string.Empty;
            Bitmap result = null;
            try
            {

                QrCodeEncodingOptions options = new QrCodeEncodingOptions();
                options = new QrCodeEncodingOptions
                {
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    Width = 250,
                    Height = 250,
                };
                var writer = new BarcodeWriter();
                writer.Format = BarcodeFormat.QR_CODE;
                writer.Options = options;

                if (String.IsNullOrWhiteSpace(pEmisorRUC) || String.IsNullOrEmpty(Tipocomprobante) || String.IsNullOrEmpty(Numeracion) ||
                    String.IsNullOrWhiteSpace(SumatoriaIGV) || String.IsNullOrEmpty(ImporteTotalVenta) || String.IsNullOrEmpty(FechaEmision) ||
                    String.IsNullOrWhiteSpace(ImporteTotalVenta) || String.IsNullOrWhiteSpace(FechaEmision) || String.IsNullOrWhiteSpace(TipoDocumentoAdquirente) ||
                    String.IsNullOrWhiteSpace(NumeroDocumentoAdquirente) || String.IsNullOrWhiteSpace(CodigoHash))
                {
                    pMessajeError = "Debe proporcionar todos los parametros para la generación del QR.";
                }
                else
                {
                    string codigo = string.Concat(pEmisorRUC, "|",
                                                  Tipocomprobante, "|",
                                                  Numeracion, "|",
                                                  SumatoriaIGV, "|",
                                                  ImporteTotalVenta, "|",
                                                  FechaEmision, "|",
                                                  TipoDocumentoAdquirente, "|",
                                                  NumeroDocumentoAdquirente, "|",
                                                  CodigoHash);


                    var qr = new ZXing.BarcodeWriter();
                    qr.Options = options;
                    qr.Format = ZXing.BarcodeFormat.QR_CODE;
                    result = new Bitmap(qr.Write(codigo.Trim())); //Generar QR

                    /*
                     * GRABAR LA IMAGEN QR
                     */
                    if (pSaveImgQR)
                    {
                        try
                        {
                            result.Save(pPathFileName, ImageFormat.Png);
                        }
                        catch (Exception ex)
                        {

                            HelpLogging.Write(TraceLevel.Error, string.Concat(pEmisorRUC + "." + MethodBase.GetCurrentMethod().Name), ex,
                                              pEmisorRUC);
                            pMessajeError = "Error interno.";
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                HelpException.mTraerMensaje(ex, false, string.Concat("HelpSUNAT.", MethodBase.GetCurrentMethod().Name), pUserLogin, pEmisorRUC);
            }
            return result;
        }

        public static string ObtenerDigestValueSunat(XmlDocument oXmlSunat)
        {
            XmlNamespaceManager manager = new XmlNamespaceManager(oXmlSunat.NameTable);
            manager.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            manager.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#");
            string valor = oXmlSunat.SelectSingleNode("//ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature/ds:SignedInfo/ds:Reference/ds:DigestValue", manager).InnerText;
            return valor;
        }

        public static string ObtenerSignatureValueSunat(XmlDocument oXmlSunat)
        {
            XmlNamespaceManager manager = new XmlNamespaceManager(oXmlSunat.NameTable);
            manager.AddNamespace("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            manager.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#");
            string valor = oXmlSunat.SelectSingleNode("//ext:UBLExtensions/ext:UBLExtension/ext:ExtensionContent/ds:Signature/ds:SignatureValue", manager).InnerText;
            return valor;
        }
        
        public static string[] ObtenerRespuestaZIPSunat(string pRutaEnvioSUNAT, string pNumRUC, string nombreFileDOC)
        {
            System.IO.FileInfo arch = new System.IO.FileInfo(pRutaEnvioSUNAT);

            if (arch.Extension == ".zip")
            {
                return LeerRepuestaCDR(pRutaEnvioSUNAT, System.IO.Path.GetFileName(pRutaEnvioSUNAT), pNumRUC, nombreFileDOC);
            }
            else
            {
                return null;
            }
        }

        public static string[] LeerRepuestaCDR(string pRutaEnvioSUNAT, string pNomFileSUNAT, string pNumRUC, string nombreFileDOC)
        {
            string mensajeRpta = "";
            string mensajeRptaNota = "";
            string fileZiped = "";
            string[] datos = new string[6];
            Nullable<DateTime> fechaCreateFile = null;
            Nullable<DateTime> fechaModifiedFile = null;

            try
            {
                //int PosicionFile = pLecturaFileZip; // pLecturaFileZip ? 0 : 1;

                using (ZipArchive zip = ZipFile.Open(pRutaEnvioSUNAT, ZipArchiveMode.Read))
                {
                    for (int PosicionFile = 0; PosicionFile < zip.Entries.Count; PosicionFile++)
                    {
                        if (zip.Entries[PosicionFile].ToString().Contains(nombreFileDOC))
                        {

                            fileZiped = zip.Entries[PosicionFile].ToString();
                            break;

                        }
                    }

                    ZipArchiveEntry zentry = null;
                    zentry = zip.GetEntry(fileZiped);
                    XmlDocument xd = new XmlDocument();
                    xd.Load(zentry.Open());
                    XmlNodeList xnl = xd.GetElementsByTagName("cbc:Description");
                    foreach (XmlElement item in xnl)
                    {
                        mensajeRpta = item.InnerText;
                    }

                    XmlNodeList xnlNota = xd.GetElementsByTagName("cbc:Note");
                    foreach (XmlElement item in xnlNota)
                    {
                        mensajeRptaNota = item.InnerText;
                    }
                }
                fechaCreateFile = File.GetCreationTime(pRutaEnvioSUNAT);
                fechaModifiedFile = File.GetLastWriteTime(pRutaEnvioSUNAT);
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Info, string.Concat("HelpSUNAT.", MethodBase.GetCurrentMethod().Name),
                                string.Concat("pRutaEnvioSUNAT.: ", pRutaEnvioSUNAT, "ex.Message ERROR: ", ex.Message), pNumRUC, pNumRUC);
            }
            datos[0] = mensajeRpta;
            datos[1] = fileZiped;
            datos[2] = pNomFileSUNAT;
            datos[3] = fechaCreateFile.HasValue ? fechaCreateFile.Value.ToString("dd/MM/yyyy HH:mm:ss",
                  CultureInfo.CreateSpecificCulture("es-PE")) : string.Empty;
            datos[4] = fechaModifiedFile.HasValue ? fechaModifiedFile.Value.ToString("dd/MM/yyyy HH:mm:ss",
                  CultureInfo.CreateSpecificCulture("es-PE")) : string.Empty;
            datos[5] = string.IsNullOrEmpty(mensajeRptaNota) ? "-" : mensajeRptaNota;
            return datos;
        }

        public static string[] LeerValidBajaRA(XmlDocument oXmlSunat)
        {
            string mensajeRpta = "";
            string mensajeRptaNota = "";
            string[] datos = new string[6];
            try
            {
                //using (ZipArchive zip = ZipFile.Open(pRutaEnvioSUNAT, ZipArchiveMode.Read))
                //{
                    //ZipArchiveEntry zentry = null;
                    //fileZiped = zip.Entries[1].ToString();
                    //zentry = zip.GetEntry(fileZiped);
                    //XmlDocument xd = new XmlDocument();
                    //xd.Load(zentry.Open());
                    XmlNodeList xnl = oXmlSunat.GetElementsByTagName("cbc:Description");
                    foreach (XmlElement item in xnl)
                    {
                        mensajeRpta = item.InnerText;
                    }

                    XmlNodeList xnlNota = oXmlSunat.GetElementsByTagName("cbc:Note");
                    foreach (XmlElement item in xnlNota)
                    {
                        mensajeRptaNota = item.InnerText;
                    }
                //}
            }
            catch (Exception ex)
            {

            }
            //datos[0] = mensajeRpta;
            //datos[1] = fileZiped;
            //datos[2] = pNomFileSUNAT;
            //datos[3] = fechaCreateFile.HasValue ? fechaCreateFile.Value.ToString("dd/MM/yyyy HH:mm:ss",
            //      CultureInfo.CreateSpecificCulture("es-PE")) : string.Empty;
            //datos[4] = fechaModifiedFile.HasValue ? fechaModifiedFile.Value.ToString("dd/MM/yyyy HH:mm:ss",
            //      CultureInfo.CreateSpecificCulture("es-PE")) : string.Empty;
            //datos[5] = string.IsNullOrEmpty(mensajeRptaNota) ? "-" : mensajeRptaNota;
            return datos;
        }
    }
}

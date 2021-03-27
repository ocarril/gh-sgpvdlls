namespace CROM.SGComercial.Reports
{
    using BusinessEntities.SUNAT.response;
    ////using CROM.BusinessEntities.SUNAT.response;
    using CROM.Tools.Comun;
    using CROM.Tools.Config;

    using Microsoft.Reporting.WebForms;
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Tools.Comun.Web;

    public class CreateReportLogic: BaseLayer
    {

        public byte[] CreateReportSalesInvoice(DTODocumRegFEResponse pFactura, out ReturnValor pReturn)
        {

            pReturn = new ReturnValor();
            byte[] bytes = null;
            try
            {
                string nameReportDocumento = string.Concat("FE_", pFactura.NombreReporte);
                string nombreReportePath = Path.Combine(ConfigCROM.AppConfig(pFactura.codEmpresa,
                                                                              ConfigTool.DEFAULT_Path_Importacion),
                                                         "formats",
                                                         nameReportDocumento
                                                         );

                //Obtener la ruta del reporte
                if (!File.Exists(nombreReportePath))
                {

                    pReturn.Message = string.Format("No existe formato para el reporte : [{0}]", pFactura.NombreReporte);
                    return bytes;
                }

                ReportDataSource reportDataSourceDetalle = new ReportDataSource();
                ReportViewer reportViewer1 = new ReportViewer();

                reportViewer1.ProcessingMode = ProcessingMode.Local; //NEW
                //reportViewer1.DataBinding
                //LocalReport localReport = reportViewer1.LocalReport; //NEW
                //localReport.ReportPath = nombreReportePath;          //NEW

                reportViewer1.LocalReport.ReportEmbeddedResource = "CROM.SGComercial.Reports." + nameReportDocumento;
                //reportViewer1.LocalReport.ReportPath = nombreReportePath;
                //reportViewer1.LocalReport.ReportPath = nameReportDocumento;



                reportDataSourceDetalle.Name = "CROM_BusinessEntities_DTODocumRegFEResponse";
                reportDataSourceDetalle.Value = pFactura.LstDocumRegDetalle;



                //localReport.DataSources.Add(reportDataSourceDetalle);   //NEW


                //reportDataSourceDetalle.DataMember = "CROMBusinessEntitiesSUNATresponse";
                //reportDataSourceDetalle.DataMember = "CROM.BusinessEntities.SUNAT.response.DTODocumRegFEDetalleResponse";
                reportDataSourceDetalle.DataSourceId = "CROMBusinessEntitiesSUNATresponse";

                reportViewer1.LocalReport.DataSources.Add(reportDataSourceDetalle);


                //reportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(new PermissionSet(PermissionState.Unrestricted));

                //CROM.BusinessEntities.SUNAT.response.DTODocumRegFEDetalleResponse
                //permite insertar imagenes externas(Codigo QR)
                reportViewer1.LocalReport.EnableExternalImages = true;
                //reportViewer1.ShowBackButton = false;
                //reportViewer1.ShowDocumentMapButton = false;
                //reportViewer1.ShowRefreshButton = false;


                //, 
                //

                //rs.Name = "CROM.BusinessEntities.SUNAT.response";CROM_BusinessEntities_SUNAT_response_DTODocumRegFEDetalleResponse

                //CROMBusinessEntitiesSUNATresponse
                string strSoloEntero = string.Empty;
                string strSoloDecima = string.Empty;
                decimal decEnteroD = 0;
                Int64 intEntero = 0;
                string strDatoNumero1 = pFactura.DRC_sumTotValVenta.ToString("N2");
                strSoloEntero = strDatoNumero1.Substring(0, strDatoNumero1.IndexOf('.'));
                strSoloDecima = strDatoNumero1.Substring(strDatoNumero1.IndexOf('.') + 1, 2);
                decEnteroD = Convert.ToDecimal(strSoloEntero);
                intEntero = Convert.ToInt64(decEnteroD);

                string strValorTotalPrecioVentaLetras = Helper.Numero_A_Texto(intEntero) + " CON " +
                                                        strSoloDecima + "/100 " + (string.IsNullOrEmpty(pFactura.codRegMonedaNombre) ?
                                                        string.Empty : pFactura.codRegMonedaNombre.Trim().ToUpper());

                //Definicion de parametros
                ReportParameter[] parameters = new ReportParameter[22];

                parameters[00] = new ReportParameter("pCliente", pFactura.DRC_rznSocialUsuario);
                parameters[01] = new ReportParameter("pRUC", pFactura.DRC_numDocUsuario);
                parameters[02] = new ReportParameter("pDireccion", pFactura.cliEntidadDireccion.ToUpper());
                parameters[03] = new ReportParameter("pLocalidad", pFactura.cliEntidadDireccionUbigeo);
                parameters[04] = new ReportParameter("pFecha", pFactura.DRC_fecEmision);
                parameters[05] = new ReportParameter("pTotalDscto", pFactura.DRC_sumDescTotal.ToString("N2"));
                parameters[06] = new ReportParameter("pTotalTotComision", pFactura.DRC_sumOtrosCargos.ToString("N2"));
                parameters[07] = new ReportParameter("pValorVenta", pFactura.DRC_sumTotValVenta.ToString());
                parameters[08] = new ReportParameter("pImpuesto", pFactura.DRC_sumTotTributos.ToString("N2"));
                parameters[09] = new ReportParameter("pISC", pFactura.DRC_sumTotalAnticipos.ToString("N2"));

                parameters[10] = new ReportParameter("pImporteTotal", pFactura.DRC_sumPrecioVenta.ToString("N2"));
                parameters[11] = new ReportParameter("pTotal", pFactura.DRC_sumTotValVenta.ToString());
                parameters[12] = new ReportParameter("pNumero", pFactura.DRC_Doc_Numero);
                parameters[13] = new ReportParameter("pSerie", pFactura.DRC_Doc_Serie);
                parameters[14] = new ReportParameter("pCheque", "-");
                parameters[15] = new ReportParameter("pBanco", "-");
                parameters[16] = new ReportParameter("pOrden", pFactura.numOrdenCompra);
                parameters[17] = new ReportParameter("pGuia", pFactura.numDocumentoOrigen);
                parameters[18] = new ReportParameter("pImpuestoCantidad", string.Concat(pFactura.prcImpuestoGV.ToString("N2"), " %"));
                parameters[19] = new ReportParameter("pTotalLetras", strValorTotalPrecioVentaLetras);

                parameters[20] = new ReportParameter("pFirma", pFactura.codEmpresaRUC);
                parameters[21] = new ReportParameter("pCodBarras", pFactura.DRC_CodBarras);

                //Asignar parametros al reporte
                reportViewer1.LocalReport.SetParameters(parameters);
                reportViewer1.LocalReport.Refresh();

                //Enviar al correo del cliente
                Warning[] warnings; string mimeType;
                string encoding;
                string extension;
                string[] streamids;
                bytes = reportViewer1.LocalReport.Render("PDF", null,
                                                                out extension,
                                                                out encoding,
                                                                out mimeType,
                                                                out streamids,
                                                                out warnings);

                return bytes;
            }
            catch (Exception ex)
            {

                Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pFactura.segUsuarioCrea, pFactura.codEmpresa);
                pReturn.Message = WebConstants.ErroresEjecucion.FirstOrDefault(x => x.Key == 1001).Value;
            }
            return bytes;
        }
    }
}

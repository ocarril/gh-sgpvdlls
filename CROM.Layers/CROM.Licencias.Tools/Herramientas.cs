namespace CROM.Licencias.Tools
{
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Globalization;
    using System.IO;
    using System.Security.Cryptography;
    using System.Xml.Serialization;
    
    public static class Herramientas
    {
        public enum Proceso
        {
            Nuevo,
            Modificar,
            Eliminar
        }
        public enum TipoInstalacion
        {
            Demostracion,
            Instalacion
        }
        private static ReturnValor oReturnValor = new ReturnValor();

        public static LicenciaBE DeserializeLicencia()
        {
            LicenciaBE Item = new LicenciaBE();
            try
            {
                string fileLICENCIA = AppDomain.CurrentDomain.BaseDirectory + "LICENCIA.XML";
                if (File.Exists(fileLICENCIA))
                {
                    FileStream fs = new FileStream(fileLICENCIA, FileMode.Open);

                    XmlSerializer xs = new XmlSerializer(typeof(LicenciaBE));
                    Item = (LicenciaBE)xs.Deserialize(fs);
                    fs.Close();
                    Item.CADENA = HelpCrypto.SimetricoDesEncryptar(Item.CADENA, ComoDato());
                    Item.LENG1 = HelpCrypto.SimetricoDesEncryptar(Item.LENG1, ComoDato());
                    Item.LENG2 = HelpCrypto.SimetricoDesEncryptar(Item.LENG2, ComoDato());
                    Item.LENG3 = HelpCrypto.SimetricoDesEncryptar(Item.LENG3, ComoDato());
                    Item.LENG4 = HelpCrypto.SimetricoDesEncryptar(Item.LENG4, ComoDato());
                    Item.LENG5 = HelpCrypto.SimetricoDesEncryptar(Item.LENG5, ComoDato());
                    Item.LENG6 = HelpCrypto.SimetricoDesEncryptar(Item.LENG6, ComoDato());
                    Item.LENG7 = HelpCrypto.SimetricoDesEncryptar(Item.LENG7, ComoDato());
                    Item.LENG8 = HelpCrypto.SimetricoDesEncryptar(Item.LENG8, ComoDato());
                    Item.ENCRYPC = HelpCrypto.SimetricoDesEncryptar(Item.ENCRYPC, ComoDato());
                }
                else
                    throw new Exception("¡ El sistema no encuentra su respectivo archivo de licencia para esta PC ! ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Item;
        }

        public static void SerializarLicencia(LicenciaBE Item, bool NUEVO)
        {
            try
            {
                // Crear Archivo para Guardar los Datos de La Clase
                FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "LICENCIA.XML", FileMode.Create);
                // Crear un Objeto XmlSerializer to perform the serialization
                Item.CADENA = HelpCrypto.SimetricoEncryptar(Item.CADENA, ComoDato());
                Item.LENG1 = HelpCrypto.SimetricoEncryptar(Item.LENG1, ComoDato());
                if (NUEVO)
                {
                    Item.LENG3 = HelpCrypto.SimetricoEncryptar(DateTime.Now.ToString(), ComoDato());
                    if (Item.LENG2 == TipoInstalacion.Demostracion.ToString().ToUpper())
                    {
                        DateTime dateExpiracion = DateTime.Now.AddDays(Convert.ToDouble(Item.LENG4));
                        Item.LENG7 = HelpCrypto.SimetricoEncryptar(dateExpiracion.ToString(), ComoDato());
                    }
                    else
                        Item.LENG7 = HelpCrypto.SimetricoEncryptar(DateTime.Now.ToString(), ComoDato());
                }
                else
                {
                    Item.LENG7 = HelpCrypto.SimetricoEncryptar(Item.LENG7, ComoDato());
                    Item.LENG3 = HelpCrypto.SimetricoEncryptar(Item.LENG3, ComoDato());
                }
                Item.LENG2 = HelpCrypto.SimetricoEncryptar(Item.LENG2, ComoDato());
                Item.LENG4 = HelpCrypto.SimetricoEncryptar(Item.LENG4, ComoDato());
                Item.LENG5 = HelpCrypto.SimetricoEncryptar(Item.LENG5, ComoDato());
                Item.LENG6 = HelpCrypto.SimetricoEncryptar(Item.LENG6, ComoDato());
                Item.LENG8 = HelpCrypto.SimetricoEncryptar(Item.LENG8, ComoDato());
                Item.ENCRYPC = HelpCrypto.SimetricoEncryptar(ObtenerValorEncrypt(), ComoDato());
                XmlSerializer xs = new XmlSerializer(typeof(LicenciaBE));
                // Use the XmlSerializer object to serialize the data to the file
                xs.Serialize(fs, Item);
                // Close the file
                fs.Close();
                return;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Detecta la Validacion de la Licencia de la RED
        /// </summary>
        ///<returns></returns>
        public static ReturnValor EsValidaLaLICENCIA(ref bool version)
        {
            string concanatedo = string.Empty;
            try
            {
                bool LICENCIAVALIDA = false;
                CultureInfo provider = new CultureInfo("es-PE");
                concanatedo = concanatedo + "*Antes del problema::\n";
                DateTime fecNuevoControlLicencia = DateTime.ParseExact("12/12/2013", "d", provider);
                concanatedo = concanatedo + "*" + fecNuevoControlLicencia.ToString()+"\n";
                LicenciaBE LICENCIA = new LicenciaBE();
                concanatedo = concanatedo + "*Antes de DesSerializar la licencia\n" ;
                LICENCIA = DeserializeLicencia();
                concanatedo = concanatedo + "*Despues de DesSerializar la licencia\n";
                concanatedo = concanatedo + "*LICENCIA.LENG3: " + LICENCIA.LENG3.Substring(0,10) + "\n";
                concanatedo = concanatedo + "*LICENCIA.LENG7: " + LICENCIA.LENG7.Substring(0, 10) + "\n";
                DateTime dateInstalacion = DateTime.ParseExact(LICENCIA.LENG3.Substring(0, 10), "d", provider);
                DateTime dateExpiracion = DateTime.ParseExact(LICENCIA.LENG7.Substring(0, 10), "d", provider);
                concanatedo = concanatedo + "*dateInstalacion: " + dateInstalacion.ToString() + "\n";
                concanatedo = concanatedo + "*dateExpiracion: " + dateExpiracion.ToString() + "\n";
                string strENCRYPC = string.Empty;
                string[] arrENCRYPC = LICENCIA.ENCRYPC.Split('*');
                strENCRYPC = arrENCRYPC[0];
                concanatedo = concanatedo + "*strENCRYPC: " + strENCRYPC.ToString() + "\n";
                if (strENCRYPC != ObtenerValorEncrypt() && IdValidoSerial(LICENCIA))
                {
                    oReturnValor.Message = HelpMessages.CROM_LicMensaje01;
                    return oReturnValor;
                }
                decimal CONTADOR = Convert.ToDecimal(LICENCIA.LENG5) + 1;
                concanatedo = concanatedo + "*CONTADOR: " + CONTADOR.ToString() + "\n";
                
                LICENCIA.LENG5 = CONTADOR.ToString();
                
                if (LICENCIA.LENG2 == TipoInstalacion.Demostracion.ToString().ToUpper())
                {
                    ControlLicenciaDEMO(ref version, ref LICENCIAVALIDA, LICENCIA, dateExpiracion);
                    SerializarLicencia(LICENCIA, false);
                }
                else
                {
                    //if (dateInstalacion < fecNuevoControlLicencia)
                    //{
                    LICENCIAVALIDA = true;
                    version = true;
                    SerializarLicencia(LICENCIA, false);
                    oReturnValor.Exitosa = LICENCIAVALIDA;
                    //}
                    //else
                    //{
                    //    if (arrENCRYPC.Length == 1)
                    //        oReturnValor.Message = HelpMessages.CROM_LicMensaje02;
                    //    else
                    //    {
                    //        if (arrENCRYPC[1] != Herramientas.ComoDato())
                    //            oReturnValor.Message = HelpMessages.CROM_LicMensaje03;
                    //        else
                    //        {
                    //            LICENCIAVALIDA = true;
                    //            version = true;
                    //            oReturnValor.Exitosa = LICENCIAVALIDA;
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                oReturnValor.Message = concanatedo+ "---DE ACQUI VIENE LA EXCELCION Licencia;:" + ex.Message;
                oReturnValor.Exitosa = false;
            }
            return oReturnValor;
        }

        private static void ControlLicenciaDEMO(ref bool version, ref bool LICENCIAVALIDA, LicenciaBE LICENCIA, DateTime dateExpiracion)
        {
            if (DateTime.Now <= dateExpiracion && LICENCIA.LENG8 == "SI") //
            {
                int Dias = (int)HelpTime.CantidadDias(DateTime.Now, dateExpiracion, HelpTime.TotalTiempo.Dias, true);
                oReturnValor.Message = "¡QUEDAN [ " + Dias.ToString().PadLeft(5, '0') + " ] DIAS de la Versión de DEMOSTRACION del Sistema! \n  [ Empresa : " + LICENCIA.LENG6 + " ] Versión de Demostración !"; 
                LICENCIAVALIDA = true;
            }
            else
            {
                LICENCIA.LENG8 = "NO";
                oReturnValor.Message = "¡ SE EXPIRO LA LICENCIA DE PRUEBA PARA EL SISTEMA ! \n Contactarse con Orlando Carril al Cel:01-997405565 Versión de Demostración Agotada...!";
                LICENCIAVALIDA = false;
            }
            version = false;
        }

        private static bool IdValidoSerial(LicenciaBE item)
        {
            bool Existe = false;
            String[] Ids = { "2008-CROM-GCPN-0001-0000", // 001 - CROM SISTEMAS
                             "2008-CROM-GCPN-0002-0001", // 002 - MAGESET SRL
                             "2009-CROM-GCPN-0002-0011", // 003 - SERGRAMAG
                             "2009-CROM-GCPN-0002-0111", // 004 - OXINET
                             "2009-CROM-GCPN-0002-1111", // 005 - CAYETANO EIRL
                             "2010-CROM-GCPN-0002-0001", // 006 - CARLO VILLANUEVA
                             "2011-CROM-GCPN-0001-0001", // 007 - CANATRIAL S.A.C.
                             "2011-CROM-GCPN-0002-0003", // 008 - ANTI & CUCHO
                             "2011-CROM-GCPN-0002-0004", // 009 - BODEGA 911
                             "2011-CROM-GCPN-0002-0005", // 010 - RELEGRAF
                             "2011-CROM-GCPN-0002-0006", // 011 - Nuevo cliente
                             "2011-CROM-GCPN-0002-0007", // 012 - Nuevo cliente
                             "2011-CROM-GCPN-0002-0008", // 013 - Nuevo cliente
                             "2011-CROM-GCPN-0002-0009", // 014 - Nuevo cliente
                             "2011-CROM-GCPN-0002-0010", // 015 - Nuevo cliente
                           };
            foreach (string id in Ids)
            {
                if (id == item.LENG1)
                {
                    Existe = true;
                    break;
                }
            }
            return Existe;
        }

        private static string ObtenerValorEncrypt()
        {
            string idEncrypt = string.Empty;
            System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
            foreach (System.Management.ManagementObject NumeroDeSerie in searcher.Get())
            {
                if (NumeroDeSerie["SerialNumber"] != null)
                {
                    idEncrypt = Convert.ToString(NumeroDeSerie["SerialNumber"]);//.Equals(2);
                    break;
                }
            }
            searcher.Dispose();
            return idEncrypt;
        }

        public static string ComoDato()
        {
            return HelpMessages.CROM_Existe;
        }

        private static byte[] Encriptar(string strEncriptar, string strPK)
        {
            return Encriptarlo(strEncriptar, (new PasswordDeriveBytes(strPK, null)).GetBytes(32));
        }

        private static byte[] Encriptarlo(string strEncriptar, byte[] bytPK)
        {
            Rijndael miRijndael = Rijndael.Create();
            byte[] encrypted = null;
            byte[] returnValue = null;
            try
            {
                miRijndael.Key = bytPK;
                miRijndael.GenerateIV();

                byte[] toEncrypt = System.Text.Encoding.UTF8.GetBytes(strEncriptar);
                encrypted = (miRijndael.CreateEncryptor()).TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);

                returnValue = new byte[miRijndael.IV.Length + encrypted.Length];
                miRijndael.IV.CopyTo(returnValue, 0);
                encrypted.CopyTo(returnValue, miRijndael.IV.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                miRijndael.Clear();
            }
            return returnValue;
        }

        public static String SimetricoEncryptar(String dato_Encriptar, String dato_Lllave)
        {
            String SimetricoEncryptar = null;
            byte[] _bytTemp = null;

            _bytTemp = Encriptar(dato_Encriptar, dato_Lllave); //TransEncripHash.MiRijndael.
            SimetricoEncryptar = Convert.ToBase64String(_bytTemp);

            return (SimetricoEncryptar);
        }
        public static String SimetricoDesEncryptar(String dato_Encriptado, String dato_Lllave)
        {
            String SimetricoDesEncryptar = null;
            byte[] _bytTemp = null;
            if (!string.IsNullOrEmpty(dato_Encriptado))
            {
                _bytTemp = Convert.FromBase64String(dato_Encriptado);
                SimetricoDesEncryptar = Desencriptar(_bytTemp, dato_Lllave); //TransEncripHash.MiRijndael.
            }
            else
                SimetricoDesEncryptar = string.Empty;
            return (SimetricoDesEncryptar);
        }

        private static string Desencriptar(byte[] bytDesEncriptar, string strPK)
        {
            return Desencriptarlo(bytDesEncriptar, (new PasswordDeriveBytes(strPK, null)).GetBytes(32));
        }

        private static string Desencriptarlo(byte[] bytDesEncriptar, byte[] bytPK)
        {
            Rijndael miRijndael = Rijndael.Create();
            byte[] tempArray = new byte[miRijndael.IV.Length];
            byte[] encrypted = new byte[bytDesEncriptar.Length - miRijndael.IV.Length];
            string returnValue = string.Empty;

            try
            {
                miRijndael.Key = bytPK;

                Array.Copy(bytDesEncriptar, tempArray, tempArray.Length);
                Array.Copy(bytDesEncriptar, tempArray.Length, encrypted, 0, encrypted.Length);
                miRijndael.IV = tempArray;

                returnValue = System.Text.Encoding.UTF8.GetString((miRijndael.CreateDecryptor()).TransformFinalBlock(encrypted, 0, encrypted.Length));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                miRijndael.Clear();
            }

            return returnValue;
        }
    }
}

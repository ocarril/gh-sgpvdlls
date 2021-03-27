namespace CROM.Tools.Comun
{
    using CROM.Tools.Comun.security.crypto;
    using CROM.Tools.Comun.Web;
    using System;
    using System.Data.SqlTypes;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Web;


    public static class HelpCrypto
    {
        #region -- ENCRIPTA UN TEXTO CON UNA LLAVE

        private static string KEY = "OMGC$";

        public static String SimetricoEncryptar(String dato_Encriptar, String dato_Lllave)
        {
            String SimetricoEncryptar = null;
            byte[] _bytTemp = null;
            _bytTemp = Encriptarlo(dato_Encriptar, (new PasswordDeriveBytes(dato_Lllave, null)).GetBytes(32));
            SimetricoEncryptar = Convert.ToBase64String(_bytTemp);

            return (SimetricoEncryptar);
        }

        public static String SimetricoEncryptar(String dato_Encriptar)
        {
            String SimetricoEncryptar = null;
            byte[] _bytTemp = null;
            _bytTemp = Encriptarlo(dato_Encriptar, (new PasswordDeriveBytes(KEY, null)).GetBytes(32));
            SimetricoEncryptar = Convert.ToBase64String(_bytTemp);

            return (SimetricoEncryptar);
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

        #endregion

        #region -- DESENCRIPTA UN TEXTO CON UNA LLAVE

        public static String SimetricoDesEncryptar(String dato_Encriptado, String dato_Lllave)
        {
            String SimetricoDesEncryptar = null;
            byte[] _bytTemp = null;
            _bytTemp = Convert.FromBase64String(dato_Encriptado);
            SimetricoDesEncryptar = Desencriptarlo(_bytTemp, (new PasswordDeriveBytes(dato_Lllave, null)).GetBytes(32));
            return (SimetricoDesEncryptar);
        }

        public static String SimetricoDesEncryptar(String dato_Encriptado)
        {
            String SimetricoDesEncryptar = null;
            byte[] _bytTemp = null;
            //_bytTemp = Convert.FromBase64String(dato_Encriptado);
            //SimetricoDesEncryptar = Desencriptarlo(_bytTemp, (new PasswordDeriveBytes(KEY, null)).GetBytes(32));
            //return (SimetricoDesEncryptar);

            _bytTemp = Convert.FromBase64String(dato_Encriptado.Replace(' ', '+'));
            SimetricoDesEncryptar = Desencriptarlo(_bytTemp, (new PasswordDeriveBytes(KEY, null)).GetBytes(32));

            return (SimetricoDesEncryptar);
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

        #endregion

        public static bool SISValidarTextoEncriptado(string pPassword, string pPasswordEncriptado)
        {
            SqlString datoStringSQL = pPassword;
            SqlString datoEncriptado = UserDefinedFunctions.EncryptFunction(datoStringSQL);
            if (datoEncriptado == pPasswordEncriptado)
                return true;
            else
                return false;
        }

        public static string SISEncriptarTexto(string pPassword)
        {
            SqlString datoStringSQL = pPassword;
            SqlString datoEncriptado = UserDefinedFunctions.EncryptFunction(datoStringSQL);
            return Extensors.CheckStr(datoEncriptado);
        }

        public static string QueryString(string DesEncriptado, string id)
        {
            string idValue = string.Empty;
            string[] prmValores = DesEncriptado.Split(new char[] { '&' });
            foreach (string prms in prmValores)
            {
                string[] prmValorQuery = prms.Split(new char[] { '=' });
                if (prmValorQuery[0] == id)
                {
                    idValue = prmValorQuery[1];
                    break;
                }
            }
            return idValue;
        }

        public static string QueryString_Remove(string DesEncriptado, string id)
        {
            string newEncriptado = string.Empty;
            string[] prmValores = DesEncriptado.Split(new char[] { '&' });
            foreach (string prms in prmValores)
            {

                string[] prmValorQuery = prms.Split(new char[] { '=' });
                if (prmValorQuery[0] != id)
                {
                    newEncriptado = newEncriptado + prms;
                }
            }

            return newEncriptado;
        }

        public static string GenerarContrasenia(int pLongitudContrasenia = 6)
        {
            string lsPass = "";
            string lsLetras = "0123456789abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ!#$%&/()=?¡.-!#$%&/()=?¡.-";

            Random ss = new Random();
            for (int i = 0; i < pLongitudContrasenia; i++)
            {
                int intex = ss.Next(90);
                lsPass = lsPass + lsLetras.Substring(intex, 1);
            }
            return lsPass;
        }

        public static string GetAccessToken(HttpRequestMessage request, bool indConPrefijo)
        {
            string accessToken = string.Empty;
            if (!request.Headers.Contains("Authorization")) return accessToken;
            var TOKEN = request.Headers.GetValues("Authorization");
            if (TOKEN != null)
            {

                foreach (string strToken in TOKEN)
                {
                    accessToken = (indConPrefijo ? strToken.Substring(WebConstants.REQUEST_HEADER_AUTHORIZATION_SCHEME.ToLower().Length + 1,
                                                   strToken.Length - (WebConstants.REQUEST_HEADER_AUTHORIZATION_SCHEME.ToLower().Length + 1)) :
                                  strToken);

                }
            }
            return accessToken;
        }

        public static string GetAccessToken(HttpRequestBase request, bool indConPrefijo)
        {

            string accessToken = string.Empty;
            if (request.Headers.GetValues("Authorization") == null)
                return accessToken;

            var TOKEN = request.Headers.GetValues("Authorization");
            if (TOKEN != null)
            {

                foreach (string strToken in TOKEN)
                {
                    accessToken = (indConPrefijo ? strToken.Substring(WebConstants.REQUEST_HEADER_AUTHORIZATION_SCHEME.ToLower().Length + 1,
                                                   strToken.Length - (WebConstants.REQUEST_HEADER_AUTHORIZATION_SCHEME.ToLower().Length + 1)) :
                                  strToken);

                }
            }
            return accessToken;
        }

    }

}

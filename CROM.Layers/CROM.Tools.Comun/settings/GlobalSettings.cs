namespace CROM.Tools.Comun.settings
{
    using System;
    using System.Configuration;

    public static class GlobalSettings
    {
        #region VALORES PARA SEGURIDAD


        public static bool GetDEFAULT_ServicioWEB()
        {
            return ConfigurationManager.AppSettings["DEFAULT_ServicioWEB"] == "S" ? true : false;
        }

        #endregion

        #region VALORES PARA CORREO ELECTRONICO

        public static string GetEMAIL_CredencialPass()
        {
            return ConfigurationManager.AppSettings["EMAIL_CredencialPass"].ToString();
        }

        public static string GetEMAIL_CredencialUser()
        {
            return ConfigurationManager.AppSettings["EMAIL_CredencialUser"].ToString();
        }

        public static string GetEMAIL_Host()
        {
            return ConfigurationManager.AppSettings["EMAIL_Host"].ToString();
        }

        public static int GetEMAIL_SmtpPort()
        {
            return Extensors.CheckInt(ConfigurationManager.AppSettings["EMAIL_SmtpPort"].ToString());
        }

        public static bool GetEMAIL_enabledSSL()
        {
            return Convert.ToBoolean(ConfigurationManager.AppSettings["EMAIL_enabledSSL"]);
        }

        public static string GetEMAIL_Asunto()
        {
            return ConfigurationManager.AppSettings["EMAIL_Asunto"].ToString();
        }

        #endregion

        #region VALORES PARA APLICACION

        public static int GetDEFAULT_IdEmpresa()
        {

            int valorConfig = Extensors.CheckInt(ConfigurationManager.AppSettings["DEFAULT_IdEmpresa"]);

            return valorConfig;
        }

        public static string GetDEFAULT_KEY_SYSTEM()
        {
            return ConfigurationManager.AppSettings["DEFAULT_KEY_SYSTEM"].ToString();

        }

        public static string GetDEFAULT_SistemaInicio()
        {
            return Extensors.CheckStr(ConfigurationManager.AppSettings["DEFAULT_SistemaInicio"].ToString());
        }

        public static string GetDEFAULT_Idioma()
        {
            return ConfigurationManager.AppSettings["DEFAULT_Idioma"].ToString();
        }

        public static string GetBDCadenaConexion(string cnxName)
        {
            return ConfigurationManager.ConnectionStrings[cnxName].ConnectionString;

        }

        public static string GetDEFAULT_NombreEventLog()
        {
            return ConfigurationManager.AppSettings["DEFAULT_NombreEventLog"].ToString();
        }

        public static string GetDEFAULT_TipoException()
        {
            return ConfigurationManager.AppSettings["Default_TipoException"].ToString();
        }

        public static string GetPrefijoclaseIdioma()
        {
            return ConfigurationManager.AppSettings["PrefijoclaseIdioma"].ToString();
        }

        public static string GetPathFilesIdiomasCl()
        {
            return ConfigurationManager.AppSettings["PathFilesIdiomasCl"].ToString();
        }

        public static string GetNombreIdiomaComple()
        {
            return ConfigurationManager.AppSettings["NombreIdiomaComple"].ToString();
        }

        public static string GetDEFAULT_ValorTimeout()
        {

            string valorConfig = Extensors.CheckStr(ConfigurationManager.AppSettings["DEFAULT_ValorTimeout"]);

            return valorConfig;
        }

        public static int GetDEFAULT_HorasFechaActualCloud()
        {

            int valorConfig = Extensors.CheckInt(ConfigurationManager.AppSettings["DEFAULT_HorasFechaActualCloud"]);

            return valorConfig;
        }


        #endregion

        #region VALORES DE RUTAS URLS APLICACIONES Y APIS WEB SERVICES

        public static string GetDEFAULT_URL_WS_API_Alertas()
        {

            string valorConfig = Extensors.CheckStr(ConfigurationManager.AppSettings["DEFAULT_rutaApiWebAlertas"]);

            return valorConfig;
        }

        public static string GetDEFAULT_URL_WEBAPP_Seguridad()
        {

            string valorConfig = Extensors.CheckStr(ConfigurationManager.AppSettings["DEFAULT_URL_WEBAPP_Seguridad"]);

            return valorConfig;
        }

        public static string GetDEFAULT_URL_WS_API_Seguridad()
        {

            string valorConfig = Extensors.CheckStr(ConfigurationManager.AppSettings["DEFAULT_URL_WS_API_Seguridad"]);

            return valorConfig;
        }

        public static string GetDEFAULT_URL_WEBAPP_Comercial()
        {

            string valorConfig = Extensors.CheckStr(ConfigurationManager.AppSettings["DEFAULT_URL_WEBAPP_Comercial"]);

            return valorConfig;
        }

        public static string GetDEFAULT_URL_WS_API_Comercial()
        {

            string valorConfig = Extensors.CheckStr(ConfigurationManager.AppSettings["DEFAULT_URL_WS_API_Comercial"]);

            return valorConfig;
        }

        public static string GetDEFAULT_URL_WEBAPP_Encuesta()
        {

            string valorConfig = Extensors.CheckStr(ConfigurationManager.AppSettings["DEFAULT_rutaAppWebEncuesta"]);

            return valorConfig;
        }

        public static string GetDEFAULT_Path_Application()
        {

            string valorConfig = Extensors.CheckStr(ConfigurationManager.AppSettings["DEFAULT_Path_Application"]);

            return valorConfig;
        }

        public static string GetDEFAULT_LinkCROM()
        {

            string valorConfig = Extensors.CheckStr(ConfigurationManager.AppSettings["DEFAULT_LinkCROM"]);

            return valorConfig;
        }

        #endregion

        public static string GetConfiguracion(string key)
        {
            string result = String.Empty;
            if (String.IsNullOrEmpty(key))
                return result;
            try
            {
                result = ConfigurationManager.AppSettings[key];
            }
            catch (Exception)
            {

                result = string.Empty;
            }

            return result;
        }

        public static bool GetDEFAULT_Time60()
        {
            return ConfigurationManager.AppSettings["DEFAULT_Time60"] == "S" ? true : false;
        }

        public static string GetDEFAULT_DatePattern()
        {
            return ConfigurationManager.AppSettings["DEFAULT_DatePattern"].ToString();
        }

        public static string GetDEFAULT_ShortTimePattern()
        {
            return ConfigurationManager.AppSettings["DEFAULT_ShortTimePattern"].ToString();
        }

        public static string GetDEFAULT_LongTimePattern()
        {
            return ConfigurationManager.AppSettings["DEFAULT_LongTimePattern"].ToString();
        }

        public static string GetDEFAULT_LinkTipoCambio()
        {
            return ConfigurationManager.AppSettings["DEFAULT_LinkTipoCambio"].ToString();
        }

        #region LLAVES DE AZURE-CLOUD

        public static string GetDEFAULT_AccountAzure()
        {
            return ConfigurationManager.AppSettings["DEFAULT_accountAzure"];
        }

        public static string GetDEFAULT_KeyAzure()
        {
            return ConfigurationManager.AppSettings["DEFAULT_keyAzure"];
        }

        #endregion

        #region SISTEMA DE FACTURACION

        public static bool GetDEFAULT_MODO_DEMO_SUNAT()
        {
           
            int valorConfig = Extensors.CheckInt(ConfigurationManager.AppSettings["DEFAULT_MODO_DEMO_SUNAT"]);

            return valorConfig == 1 ? true : false;
        }


        public static int GetDEFAULT_MODO_PROD_XML_RPTA()
        {

            int valorConfig = Extensors.CheckInt(ConfigurationManager.AppSettings["DEFAULT_MODO_PROD_XML_RPTA"]);

            return valorConfig;
        }



        public static bool GetDEFAULT_MODO_ASYNC_WSA()
        {

            bool valorConfig = Extensors.CheckInt(ConfigurationManager.AppSettings["DEFAULT_MODO_ASYNC_WS"]) == 1 ? true : false;

            return valorConfig;
        }

        public static int GetDEFAULT_SAVE_DOCUM_MODE_NEW()
        {

            int valorConfig = Extensors.CheckInt(ConfigurationManager.AppSettings["DEFAULT_SAVE_DOCUM_MODE_NEW"]);

            return valorConfig;
        }



        public static int GetDEFAULT_NumProcesoSISFACT()
        {

            int valorConfig = Extensors.CheckInt(ConfigurationManager.AppSettings["DEFAULT_NumProcesoSISFACT"]);

            return valorConfig;
        }

        #endregion


        public static bool GetDEFAULT_ENVIA_GRE_SFS_SUNAT()
        {

            bool valorConfig = Extensors.CheckInt(ConfigurationManager.AppSettings["DEFAULT_ENVIA_GRE_SFS_SUNAT"]) == 1 ? true : false;

            return valorConfig;
        }



        #region VALORES PARA WEB JOB

        public static string GetDEFAULT_WebJobUserLogin()
        {
            return ConfigurationManager.AppSettings["DEFAULT_WebJobUserLogin"];
        }

        public static string GetDEFAULT_WebJobClave()
        {
            return ConfigurationManager.AppSettings["DEFAULT_WebJobClave"];
        }

        #endregion

    }
}

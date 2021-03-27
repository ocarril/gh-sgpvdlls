namespace CROM.Proyectos.DataAccess
{
    using CROM.Tools.Comun.settings;

    using System;

    public static class Util
    {
        public static string ConexionBD()
        {
            string strCnxDB;
            try
            {
                strCnxDB = GlobalSettings.GetBDCadenaConexion("cnxCROMSystema");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strCnxDB;
        }
    }
}

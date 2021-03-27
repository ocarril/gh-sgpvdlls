using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using CROM.Tools.Comun.settings;

namespace CROM.RecursosHumanos.DataAcces
{
    public static class Util
    {
        public static string ConexionBD()
        {
            string strCnxDB;
            try
            {
                strCnxDB = GlobalSettings.GetBDCadenaConexion("cnxCROMRRHHH");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strCnxDB;
        }
    }
}

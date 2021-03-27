namespace CROM.Tools.Comun
{
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.settings;

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Sql;
    using System.Data.SqlClient;


    public static class HelpDataBases
    {
        public static object InstanciasInstaladas()
        {
            Microsoft.Win32.RegistryKey rk;
            rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server", false);
            object s = rk.GetValue("InstalledInstances");
            return s;
        }

        // Para saber las bases de datos de la instancia indicada
        public static List<String> BasesDeDatos(String Instancia)
        {
            // Las bases de datos de SQL Server
            String[] basesSys = { "master", "model", "msdb", "tempdb" };
            List<String> bases = new List<String>();
            DataTable dt = new DataTable();
            //Usamos la seguridad integrada de Windows
            String sCnn = "Server=" + Instancia + "; " + "database=master;  User ID=sa;	Password=uscrom;";
            // La orden T-SQL para recuperar las bases de master
            String sel = "SELECT name FROM sysdatabases ORDER BY name";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sel, sCnn);
                da.Fill(dt);
                int k = -1;
                for (int i = 0; i <= (dt.Rows.Count - 1); ++i)
                {
                    object s = dt.Rows[i].ItemArray;
                    object[] z = (object[])(s);
                    string x = z[0].ToString();
                    // Solo asignar las bases que no son del sistema
                    if (Array.IndexOf(basesSys, x) == -1)
                    {
                        k += 1;
                        bases.Add(x.ToString());
                    }
                }
                if (k == -1)
                    return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " [Error al recuperar las bases de la instancia indicada");
            }
            return bases;
        }

        public static DataTable ObtenerServerInfo()
        {
            return SqlDataSourceEnumerator.Instance.GetDataSources();
        }

        public static ReturnValor CrearBACKUP(string BaseDato_ORIG, string BaseDato_INSTANCIA, string BaseDato_BACKUP)
        {
            ReturnValor oReturnValor = new ReturnValor();
            string sBackup = "BACKUP DATABASE " + BaseDato_ORIG +
                 " TO DISK = N'" + BaseDato_BACKUP +
                 "' WITH NOFORMAT, NOINIT, NAME =N'" + BaseDato_ORIG +
                 "-Full Database Backup',SKIP, STATS = 10";

            SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();

            csb.DataSource = BaseDato_INSTANCIA;
            csb.InitialCatalog = BaseDato_ORIG;
            csb.IntegratedSecurity = true;

            using (SqlConnection con = new SqlConnection(csb.ConnectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmdBackUp = new SqlCommand(sBackup, con);

                    cmdBackUp.ExecuteNonQuery();
                    con.Close();
                    oReturnValor.Exitosa = true;
                    oReturnValor.Message = "¡ Se ha CREADO un BackUp de La BASE de Datos" + " [ " + BaseDato_ORIG.ToUpper() + " ] Satisfactoriamente !" ;
                }
                catch (Exception EX)
                {
                    oReturnValor.Message = "¡ Error al copiar la BASE de Datos !" + " [ " + BaseDato_ORIG.ToUpper() + " ] " + EX.Message;
                }

            }
            return oReturnValor;

        }

        public static String BDGetCadenaConexion(string cnxName)
        {
            string ConexionString = GlobalSettings.GetBDCadenaConexion(cnxName);
            return ConexionString;
        }

        public static void BDDetectarBaseDeDatoEnCadenaDeCNX(string cadenaDeConexion, out string baseDato, out string server, out string login)
        {
            cadenaDeConexion = cadenaDeConexion.Trim();
            String[] ParteConexion = cadenaDeConexion.Split(new Char[] { ';' });
            String[] BD = ParteConexion[1].Split(new Char[] { '=' });
            String[] SR = ParteConexion[0].Split(new Char[] { '=' });
            
            baseDato = BD[1].Trim();
            server = SR[1].Trim();

            login = ParteConexion[2].Trim() + "; " + ParteConexion[3].Trim();
        }

        public static bool BDExisteBaseDeDato(string CadenadeConexion)
        {
            string baseDato;
            string server;
            string login;
            BDDetectarBaseDeDatoEnCadenaDeCNX(CadenadeConexion, out baseDato, out server, out login);
            return (BDExisteBaseDeDato(baseDato, server, login));
        }

        public static bool BDExisteBaseDeDato(string BaseDeDatoName, string Server, string login)
        {
            bool existeBaseDeDato = false;
            DataTable dt = new DataTable();
            string sCnn = "Data Source=" + Server + "; Initial Catalog=master; " + login + ";";
            string sel = "SELECT name FROM sysdatabases WHERE name = '" + BaseDeDatoName + "'";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sel, sCnn);
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    existeBaseDeDato = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error al recuperar las bases de la instancia indicada");
            }
            finally
            {
                sCnn = null;
                dt.Dispose();
            }
            return existeBaseDeDato;
        }
    }
}
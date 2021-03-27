namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.OleDb;
    using System.Data;

    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.Almacen;


    public class ImportacionData
    {

        private OleDbConnection GetConnectionOLDB(String XLS_Source, int XLS_Version)
        {
            int i = 34;
            char c = (char)i;

            string connectionString = string.Empty;
            if (XLS_Version == 1)
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                            XLS_Source + ";Extended Properties=" + c.ToString() + "Excel 12.0 Xml;HDR=YES;" + c.ToString();
            else
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Excel 8.0;Data Source=" +
                                                         XLS_Source + ";Extended Properties=" + c.ToString() + "Excel 8.0 Xml;HDR=YES;" + c.ToString();
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            return connection;
        }
        private OleDbDataReader GetListImportado(String XLSOrigen, String NameRango, int XLS_Version)
        {
            OleDbDataReader readerOLDB;
            string sql_Query = "SELECT * FROM " + NameRango;
            using (OleDbCommand commandOLDB = new OleDbCommand(sql_Query, GetConnectionOLDB(XLSOrigen, XLS_Version)))
            {
                commandOLDB.CommandType = CommandType.Text;
                readerOLDB = commandOLDB.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection);
            }
            return readerOLDB;
        }

        private OleDbConnection GetConnectionOLDB(String XLS_Source)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Excel 8.0;Data Source=" +
                                          XLS_Source +
                                         ";Extended Properties=HDR=No; IMEX=1;";

            // Provider=Microsoft.Jet.OLEDB.4.0;Excel 8.0; Extended Properties=HDR=No; IMEX=1
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            return connection;
        }
        private OleDbDataReader GetListImportado(String XLSOrigen, String NameRango)
        {
            OleDbDataReader readerOLDB;
            string sql_Query = "SELECT * FROM " + NameRango;
            using (OleDbCommand commandOLDB = new OleDbCommand(sql_Query, GetConnectionOLDB(XLSOrigen)))
            {
                commandOLDB.CommandType = CommandType.Text;
                readerOLDB = commandOLDB.ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.CloseConnection);
            }
            return readerOLDB;
        }

        public List<BEProductoSeriado> ImportarProductoSeriadosDAL(string p_XLSOrigen, int XLS_Version, string p_NameRango, string p_codProducto)
        {
            bool prmFormatoDeFecha = false;
            try
            {
                List<BEProductoSeriado> listaProductoSeriado = new List<BEProductoSeriado>();
                if (p_XLSOrigen != null)
                {
                    using (OleDbDataReader readerOLDB = GetListImportado(p_XLSOrigen, p_NameRango, XLS_Version))
                    {
                        while (readerOLDB.Read())
                        {
                            if (Convert.ToString(readerOLDB[0]) == p_codProducto)
                            {
                                BEProductoSeriado obj = new BEProductoSeriado();
                                obj.codigoProducto = Convert.ToString(readerOLDB[0]);
                                object datFecha = readerOLDB[1];
                                if (datFecha != null)
                                {
                                    if (datFecha.ToString() != string.Empty)
                                    {
                                        prmFormatoDeFecha = true;
                                        obj.FechaVencimiento = Convert.ToDateTime(readerOLDB[1]);
                                    }
                                }
                                obj.NumeroLote = Convert.ToString(readerOLDB[2]);
                                obj.NumeroSerie = Convert.ToString(readerOLDB[3]);
                                obj.Estado = true;
                                listaProductoSeriado.Add(obj);
                            }
                        }
                    }
                }
                return (listaProductoSeriado);
            }
            catch (Exception ex)
            {
                string msge = string.Empty;
                if (prmFormatoDeFecha)
                    msge = "El formato de fecha de la columna FecVencimiento es incorrecto.!";
                throw new Exception(msge + " __ " + ex.Message);
            }
        }

    }
}

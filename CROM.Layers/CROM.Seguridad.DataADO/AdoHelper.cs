namespace CROM.Seguridad.DataADO
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Helpers de ADO.NET puro para las clases de este proyecto: construcción de SqlCommand/SqlParameter
    /// hacia procedimientos almacenados del esquema Seguridad, y lectura nula-segura de SqlDataReader por nombre de columna.
    /// </summary>
    internal static class AdoHelper
    {
        public static SqlCommand CreateStoredProcCommand(this SqlConnection cn, string storedProcName)
        {
            var cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcName;
            return cmd;
        }

        public static SqlParameter AddParam(this SqlCommand cmd, string name, SqlDbType type, object value)
        {
            var p = new SqlParameter(name, type) { Value = value ?? DBNull.Value };
            cmd.Parameters.Add(p);
            return p;
        }

        public static SqlParameter AddParam(this SqlCommand cmd, string name, SqlDbType type, int size, object value)
        {
            var p = new SqlParameter(name, type, size) { Value = value ?? DBNull.Value };
            cmd.Parameters.Add(p);
            return p;
        }

        public static SqlParameter AddInputOutputParam(this SqlCommand cmd, string name, SqlDbType type, object value)
        {
            var p = new SqlParameter(name, type) { Direction = ParameterDirection.InputOutput, Value = value ?? DBNull.Value };
            cmd.Parameters.Add(p);
            return p;
        }

        public static SqlParameter AddInputOutputParam(this SqlCommand cmd, string name, SqlDbType type, int size, object value)
        {
            var p = new SqlParameter(name, type, size) { Direction = ParameterDirection.InputOutput, Value = value ?? DBNull.Value };
            cmd.Parameters.Add(p);
            return p;
        }

        public static SqlParameter AddReturnValueParam(this SqlCommand cmd)
        {
            var p = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue };
            cmd.Parameters.Add(p);
            return p;
        }

        public static string GetStringOrNull(this SqlDataReader reader, string column)
        {
            int i = reader.GetOrdinal(column);
            return reader.IsDBNull(i) ? null : reader.GetString(i);
        }

        public static int? GetIntOrNull(this SqlDataReader reader, string column)
        {
            int i = reader.GetOrdinal(column);
            return reader.IsDBNull(i) ? (int?)null : reader.GetInt32(i);
        }

        public static int GetInt(this SqlDataReader reader, string column, int defaultValue = 0)
        {
            int i = reader.GetOrdinal(column);
            return reader.IsDBNull(i) ? defaultValue : reader.GetInt32(i);
        }

        public static bool? GetBoolOrNull(this SqlDataReader reader, string column)
        {
            int i = reader.GetOrdinal(column);
            return reader.IsDBNull(i) ? (bool?)null : reader.GetBoolean(i);
        }

        public static bool GetBool(this SqlDataReader reader, string column, bool defaultValue = false)
        {
            int i = reader.GetOrdinal(column);
            return reader.IsDBNull(i) ? defaultValue : reader.GetBoolean(i);
        }

        public static DateTime? GetDateTimeOrNull(this SqlDataReader reader, string column)
        {
            int i = reader.GetOrdinal(column);
            return reader.IsDBNull(i) ? (DateTime?)null : reader.GetDateTime(i);
        }

        public static DateTime GetDateTime(this SqlDataReader reader, string column)
        {
            int i = reader.GetOrdinal(column);
            return reader.IsDBNull(i) ? default(DateTime) : reader.GetDateTime(i);
        }

        public static decimal? GetDecimalOrNull(this SqlDataReader reader, string column)
        {
            int i = reader.GetOrdinal(column);
            return reader.IsDBNull(i) ? (decimal?)null : reader.GetDecimal(i);
        }

        public static Guid? GetGuidOrNull(this SqlDataReader reader, string column)
        {
            int i = reader.GetOrdinal(column);
            return reader.IsDBNull(i) ? (Guid?)null : reader.GetGuid(i);
        }

        /// <summary>
        /// Lee una columna de tipo indeterminado (p.ej. codEmpresaKey/codUsuarioKey, que en LINQ-to-SQL
        /// se leían como "item.X.ToString()" sin conocer su tipo exacto en este proyecto) y la convierte a string.
        /// </summary>
        public static string GetAsStringOrNull(this SqlDataReader reader, string column)
        {
            object val = reader[column];
            return val == null || val == DBNull.Value ? null : val.ToString();
        }
    }
}

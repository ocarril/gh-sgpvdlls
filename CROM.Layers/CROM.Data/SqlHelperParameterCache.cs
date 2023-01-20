namespace CROM.Data
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;

    public static class SqlHelperParameterCache
    {
        #region private methods, variables, and constructors
        //Put the params to a static field so that all thread can access it and share it.
        //that mean we have cached all parames. --nice design.
        private static readonly Hashtable ParamCache = Hashtable.Synchronized(new Hashtable());

        private static SqlParameter[] DiscoverSpParameterSet(string connectionString, string spName, bool isIncludeReturnValueParameter)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(spName, cn))
            {
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmd);
                if (isIncludeReturnValueParameter == false)
                {
                    cmd.Parameters.RemoveAt(0);
                }
                SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count];
                cmd.Parameters.CopyTo(discoveredParameters, 0);

                // HACK: Workaround for dealing with .DeriveParameters() parameters bug in SqlClient where Text types don't map correctly. Do Not Change this until it's fixed.
                foreach (SqlParameter param in discoveredParameters)
                {
                    if ((param.SqlDbType == SqlDbType.VarChar) && (param.Size == Int32.MaxValue))
                    {
                        param.SqlDbType = SqlDbType.Text;
                    }
                }
                cn.Close();
                return discoveredParameters;
            }
        }

        private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
        {
            SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];
            for (int i = 0; i < originalParameters.Length; i++)
            {
                clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
            }
            return clonedParameters;
        }
        #endregion private methods, variables, and constructors

        #region public methods
        public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
        {
            return GetSpParameterSet(connectionString, spName, false);
        }

        private static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool isIncludeReturnValueParameter)
        {
            string hashKey = connectionString + ":" + spName + (isIncludeReturnValueParameter ? "isIncludeReturnValueParameter" : "");
            SqlParameter[] cachedParameters = ParamCache[hashKey] as SqlParameter[];
            if (cachedParameters == null)
            {
                cachedParameters = DiscoverSpParameterSet(connectionString, spName, isIncludeReturnValueParameter);
                ParamCache[hashKey] = cachedParameters;
            }
            return CloneParameters(cachedParameters);
        }
        #endregion

    }
}

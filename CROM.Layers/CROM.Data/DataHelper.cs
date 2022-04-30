namespace CROM.Data
{

    using CROM.Data.interfaces;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.attributes;
    using CROM.Tools.Comun.Extensions;

    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;

    public class DataHelper : IDataHelper
    {
        private DbProviderFactory _factory;
        private string _providerName;


        public DbProviderFactory ProviderFactory
        {
            get { return _factory; }
            set
            {
                _factory = value;
                this.ConnectionString = this.ProviderFactory.CreateConnection().ConnectionString;
            }
        }

        public DbTransaction CreateTransaction()
        {
            var con = this.ProviderFactory.CreateConnection();
            con.ConnectionString = ConnectionString;
            con.Open();
            return con.BeginTransaction();
        }

        public string ProviderName
        {
            get { return _providerName; }
            set
            {
                _factory = DbProviderFactories.GetFactory(value);
                _providerName = value;
            }
        }

        public string ConnectionString { get; set; }

        public DataHelper(string nameOrConnectionString)
        {
            this.ProviderName = ConfigurationManager.ConnectionStrings[nameOrConnectionString].ProviderName;
            string strConnection = ConfigurationManager.ConnectionStrings[nameOrConnectionString].ConnectionString;
            //DbConnectionStringBuilder con = new DbConnectionStringBuilder(strConnection);
            DbConnectionStringBuilder con = new DbConnectionStringBuilder();
            con.ConnectionString = strConnection;
            //con.UserID = CryptClass.EncryptDecrypt(con.UserID, true, false);
            //con.Password = CryptClass.EncryptDecrypt(con.Password, true, false);
            //con.UserID = con.UserID;
            //con.Password = con.Password;

            //con.ConnectTimeout = 240;
            ConnectionString = con.ConnectionString;
        }

        #region private utility methods

        private DbParameter[] HelperParameterCache(string connectionString, string storedName)
        {
            DbParameter[] parameter = null;
            if (this.ProviderFactory.GetType() == typeof(System.Data.SqlClient.SqlClientFactory))
            {
                parameter = SqlHelperParameterCache.GetSpParameterSet(connectionString, storedName);
            }
            return parameter;
        }

        private void AttachParameters(DbCommand command, DbParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (DbParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }

        private void AssignParameterValues(DbParameter[] commandParameters, DataRow dataRow)
        {
            if ((commandParameters == null) || (dataRow == null))
            {
                return;
            }

            int i = 0;
            foreach (DbParameter commandParameter in commandParameters)
            {
                if (commandParameter.ParameterName == null ||
                    commandParameter.ParameterName.Length <= 1)
                    throw new Exception(
                        string.Format(
                            "Please provide a valid parameter name on the parameter #{0}, the ParameterName property has the following value: '{1}'.",
                            i, commandParameter.ParameterName));
                if (dataRow.Table.Columns.IndexOf(commandParameter.ParameterName.Substring(1)) != -1)
                    commandParameter.Value = dataRow[commandParameter.ParameterName.Substring(1)];
                i++;
            }
        }

        private void AssignParameterValues(DbParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
            {
                return;
            }

            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("Parameter count does not match Parameter Value count.");
            }

            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                AssingParameter(commandParameters[i], parameterValues[i]);

            }
        }


        private void AssingParameter(DbParameter commandParameter, object parameterValue)
        {

            if (parameterValue is IDataParameter)
            {
                IDataParameter paramInstance = (IDataParameter)parameterValue;
                if (paramInstance.Value == null)
                {
                    commandParameter.Value = DBNull.Value;
                }
                else
                {
                    commandParameter.Value = paramInstance.Value;
                }
            }
            else if (parameterValue == null)
            {
                commandParameter.Value = DBNull.Value;
            }
            else
            {
                if (parameterValue is string)
                {
                    var letterCase = (LetterCaseAttribute)parameterValue.GetType().GetCustomAttributes(typeof(LetterCaseAttribute), false).FirstOrDefault();
                    //var letterCase = (LetterCaseAttribute)Attribute.GetCustomAttribute(property, typeof(LetterCaseAttribute));
                    if (letterCase != null && letterCase.CaseType != LetterCaseAttribute.LetterCaseType.SensitiveCase)
                        parameterValue = parameterValue.ToString().ToUpperInvariant();
                }
                commandParameter.Value = parameterValue;
            }
        }

        private void PrepareCommand(DbCommand command, DbConnection connection, DbTransaction transaction,
            CommandType commandType, string commandText, DbParameter[] commandParameters, out bool mustCloseConnection)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (String.IsNullOrEmpty(commandText)) throw new ArgumentNullException("commandText");

            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            command.Connection = connection;

            command.CommandText = commandType == CommandType.TableDirect ? string.Format("select * from {0}", commandText) : commandText;

            command.CommandType = commandType == CommandType.TableDirect ? CommandType.Text : commandType;

            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }

            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }
        }

        #endregion

        #region help sqldata
        public DbParameter CreateDbParameter(string _paramName, System.Data.DbType paramType,
                Int32? paramSize, System.Data.ParameterDirection paramDirection, object paramValue)
        {
            DbParameter sqlParam = ProviderFactory.CreateParameter(); // new DbParameter();
            sqlParam.ParameterName = _paramName;
            sqlParam.DbType = paramType;
            if (paramSize != null)
                sqlParam.Size = Convert.ToInt32(paramSize);
            sqlParam.Value = paramValue;
            sqlParam.Direction = paramDirection;
            return sqlParam;
        }
        #endregion

        #region ExecuteEntity

        public DbDataReader ExecuteEntity(string StoredName, object entity)
        {
            if (String.IsNullOrEmpty(StoredName)) throw new ArgumentNullException("StoredName");


            DbParameter[] commandParameters = HelperParameterCache(this.ConnectionString, StoredName);

            AssingParameterEntity(commandParameters, entity);

            return ExecuteReader(CommandType.StoredProcedure, StoredName, commandParameters);
        }

        public object ExecuteEntityEscalar(string StoredName, object entity)
        {
            if (String.IsNullOrEmpty(StoredName)) throw new ArgumentNullException("StoredName");


            DbParameter[] commandParameters = HelperParameterCache(this.ConnectionString, StoredName);

            AssingParameterEntity(commandParameters, entity);

            return ExecuteScalar(CommandType.StoredProcedure, StoredName, commandParameters);
        }

        public object ExecuteEntityEscalar(DbTransaction transaction, string StoredName, object entity)
        {
            if (String.IsNullOrEmpty(StoredName)) throw new ArgumentNullException("StoredName");


            DbParameter[] commandParameters = HelperParameterCache(this.ConnectionString, StoredName);

            AssingParameterEntity(commandParameters, entity);

            return ExecuteScalar(transaction, CommandType.StoredProcedure, StoredName, commandParameters);
        }

        public int ExecuteEntityNonQuery(string StoredName, object entity)
        {
            if (String.IsNullOrEmpty(StoredName)) throw new ArgumentNullException("StoredName");


            DbParameter[] commandParameters = HelperParameterCache(this.ConnectionString, StoredName);

            AssingParameterEntity(commandParameters, entity);

            return ExecuteNonQuery(CommandType.StoredProcedure, StoredName, commandParameters);
        }

        public int ExecuteEntityNonQuery(DbTransaction transaction, string StoredName, dynamic entity)
        {
            if (String.IsNullOrEmpty(StoredName)) throw new ArgumentNullException("StoredName");


            DbParameter[] commandParameters = HelperParameterCache(this.ConnectionString, StoredName);

            AssingParameterEntity(commandParameters, entity);

            return ExecuteNonQuery(transaction, CommandType.StoredProcedure, StoredName, commandParameters);
        }

        private void AssingParameterEntity(DbParameter[] commandParameters, object entity)
        {
            foreach (var parameter in commandParameters)
            {
                var parameterName = parameter.ParameterName.Replace("@", "");
                var value = entity.GetPropertyValue(parameterName);

                if (parameter is SqlParameter && parameterName.EndsWith("TableType"))
                {
                    if (value == null)
                    {
                        var parameterTable = parameterName.Replace("TableType", "");
                        value = entity.GetPropertyValue(parameterTable);
                    }
                    ((SqlParameter)parameter).SqlDbType = SqlDbType.Structured;
                    ((SqlParameter)parameter).TypeName = parameterName;
                    if (value == null) value = entity;
                    parameter.Value = value;
                }
                if (value != null)
                {
                    if (value is string)
                    {
                        var property = entity.GetPropertyInfoInternal(parameterName);
                        if (property != null)
                        {
                            var letterCase = (LetterCaseAttribute)Attribute.GetCustomAttribute(property, typeof(LetterCaseAttribute));
                            if (letterCase == null)
                                value = value.ToString().ToUpperInvariant();
                        }
                    }
                    parameter.Value = value;
                }
            }
        }

        #endregion

        private TResult ExecuteCommand<TResult>(Func<TResult> commandFunction, DbConnection connection = null)
        {
            try
            {
                return commandFunction();
            }
            catch (SqlException sqlException)
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
                switch (sqlException.Number)
                {
                    case 50000:
                        throw new CROMException("Excepción Controlada", sqlException);
                    default:
                        throw;
                }
            }
        }

        #region ExecuteNonQuery

        public int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(commandType, commandText, null);
        }

        public int ExecuteNonQuery(CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            using (DbConnection connection = (DbConnection)this.ProviderFactory.CreateConnection())
            {

                connection.ConnectionString = this.ConnectionString;

                connection.Open();
                return ExecuteNonQuery(connection, commandType, commandText, commandParameters);
            }
        }

        public int ExecuteNonQuery(string StoredName, params object[] parameterValues)
        {
            if (String.IsNullOrEmpty(StoredName)) throw new ArgumentNullException("StoredName");

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                DbParameter[] commandParameters = HelperParameterCache(this.ConnectionString, StoredName);

                AssignParameterValues(commandParameters, parameterValues);

                return ExecuteNonQuery(CommandType.StoredProcedure, StoredName, commandParameters);
            }
            else
            {
                return ExecuteNonQuery(CommandType.StoredProcedure, StoredName);
            }
        }

        public int ExecuteNonQuery(DbConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(connection, commandType, commandText, (DbParameter[])null);
        }

        public int ExecuteNonQuery(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            DbCommand cmd = (DbCommand)this.ProviderFactory.CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (DbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);
            int retval = 0;

            retval = ExecuteCommand(() => cmd.ExecuteNonQuery(), connection);

            cmd.Parameters.Clear();

            if (mustCloseConnection)
                connection.Close();
            return retval;
        }

        public int ExecuteNonQuery(ref DbCommand cmd)
        {
            DbConnection connection = (DbConnection)this.ProviderFactory.CreateConnection();
            try
            {
                connection.ConnectionString = this.ConnectionString;
                connection.Open();
                cmd.Connection = connection;
                return cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }


        public int ExecuteNonQuery(DbConnection connection, string StoredName, params object[] parameterValues)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (String.IsNullOrEmpty(StoredName)) throw new ArgumentNullException("StoredName");

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                DbParameter[] commandParameters = HelperParameterCache(connection.ConnectionString, StoredName);

                AssignParameterValues(commandParameters, parameterValues);

                return ExecuteNonQuery(connection, CommandType.StoredProcedure, StoredName, commandParameters);
            }
            else
            {
                return ExecuteNonQuery(connection, CommandType.StoredProcedure, StoredName);
            }
        }

        public int ExecuteNonQuery(DbTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(transaction, commandType, commandText, (DbParameter[])null);
        }

        public int ExecuteNonQuery(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            DbCommand cmd = (DbCommand)this.ProviderFactory.CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            int retval = cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            return retval;
        }

        public int ExecuteNonQuery(DbTransaction transaction, string StoredName, params object[] parameterValues)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            if (String.IsNullOrEmpty(StoredName)) throw new ArgumentNullException("StoredName");

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                DbParameter[] commandParameters = HelperParameterCache(ConnectionString, StoredName);

                AssignParameterValues(commandParameters, parameterValues);

                return ExecuteNonQuery(transaction, CommandType.StoredProcedure, StoredName, commandParameters);
            }
            else
            {
                return ExecuteNonQuery(transaction, CommandType.StoredProcedure, StoredName);
            }
        }

        #endregion ExecuteNonQuery

        #region ExecuteDataset

        public DataSet ExecuteDataset(CommandType commandType, string commandText)
        {
            return ExecuteDataset(commandType, commandText, (DbParameter[])null);
        }

        public DataSet ExecuteDataset(CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            using (DbConnection connection = (DbConnection)this.ProviderFactory.CreateConnection())
            {
                connection.ConnectionString = this.ConnectionString;
                connection.Open();
                return ExecuteDataset(connection, commandType, commandText, commandParameters);
            }
        }

        public DataSet ExecuteDataset(string storedName, params object[] parameterValues)
        {
            if (String.IsNullOrEmpty(storedName)) throw new ArgumentNullException("storedName");

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                DbParameter[] commandParameters = HelperParameterCache(this.ConnectionString, storedName);

                AssignParameterValues(commandParameters, parameterValues);

                return ExecuteDataset(CommandType.StoredProcedure, storedName, commandParameters);
            }
            else
            {
                return ExecuteDataset(CommandType.StoredProcedure, storedName);
            }
        }

        public DataSet ExecuteDataset(DbConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteDataset(connection, commandType, commandText, (DbParameter[])null);
        }

        public DataSet ExecuteDataset(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            DbCommand cmd = (DbCommand)this.ProviderFactory.CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (DbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            try
            {
                using (DbDataAdapter da = (DbDataAdapter)this.ProviderFactory.CreateDataAdapter())
                {
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();

                    da.Fill(ds);

                    cmd.Parameters.Clear();

                    if (mustCloseConnection)
                        connection.Close();

                    return ds;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet ExecuteDataset(DbConnection connection, string storedName, params object[] parameterValues)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (String.IsNullOrEmpty(storedName)) throw new ArgumentNullException("storedName");

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                DbParameter[] commandParameters = HelperParameterCache(connection.ConnectionString, storedName);

                AssignParameterValues(commandParameters, parameterValues);

                return ExecuteDataset(connection, CommandType.StoredProcedure, storedName, commandParameters);
            }
            else
            {
                return ExecuteDataset(connection, CommandType.StoredProcedure, storedName);
            }
        }

        public DataSet ExecuteDataset(DbTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteDataset(transaction, commandType, commandText, (DbParameter[])null);
        }

        public DataSet ExecuteDataset(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null)
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            DbCommand cmd = (DbCommand)this.ProviderFactory.CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            using (DbDataAdapter da = this.ProviderFactory.CreateDataAdapter())
            {
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();

                da.Fill(ds);

                cmd.Parameters.Clear();

                return ds;
            }
        }

        public DataSet ExecuteDataset(DbTransaction transaction, string storedName, params object[] parameterValues)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null)
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            if (String.IsNullOrEmpty(storedName)) throw new ArgumentNullException("spName");

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                DbParameter[] commandParameters = HelperParameterCache(transaction.Connection.ConnectionString, storedName);

                AssignParameterValues(commandParameters, parameterValues);

                return ExecuteDataset(transaction, CommandType.StoredProcedure, storedName, commandParameters);
            }
            else
            {
                return ExecuteDataset(transaction, CommandType.StoredProcedure, storedName);
            }
        }

        #endregion ExecuteDataset

        #region ExecuteReader

        private enum DbConnectionOwnership
        {
            /// <summary>Connection is owned and managed by SqlHelper</summary>
            Internal,
            /// <summary>Connection is owned and managed by the caller</summary>
            External
        }

        private DbDataReader ExecuteReader(DbConnection connection, DbTransaction transaction, CommandType commandType, string commandText, DbParameter[] commandParameters, DbConnectionOwnership connectionOwnership)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            bool mustCloseConnection = false;
            DbCommand cmd = (DbCommand)this.ProviderFactory.CreateCommand();
            cmd.CommandTimeout = 0;
            //try
            //{
            return ExecuteCommand(() =>
            {
                PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

                DbDataReader dataReader;

                if (connectionOwnership == DbConnectionOwnership.External)
                {
                    dataReader = cmd.ExecuteReader();
                }
                else
                {
                    dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }

                bool canClear = true;
                foreach (DbParameter commandParameter in cmd.Parameters)
                {
                    if (commandParameter.Direction != ParameterDirection.Input)
                        canClear = false;
                }

                if (canClear)
                {
                    cmd.Parameters.Clear();
                }

                return dataReader;
            }, connection);
            //}
            //catch
            //{
            //    if (mustCloseConnection)
            //        connection.Close();
            //    //throw;
            //}
        }

        public DbDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            return ExecuteReader(commandType, commandText, (DbParameter[])null);
        }

        public DbDataReader ExecuteReader(CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            DbConnection connection = null;
            try
            {
                connection = (DbConnection)this.ProviderFactory.CreateConnection();
                connection.ConnectionString = this.ConnectionString;
                connection.Open();

                return ExecuteReader(connection, null, commandType, commandText, commandParameters, DbConnectionOwnership.Internal);
            }
            catch
            {
                if (connection != null) connection.Close();
                throw;
            }

        }

        public DbDataReader ExecuteReader(string storedName, params object[] parameterValues)
        {
            if (String.IsNullOrEmpty(storedName)) throw new ArgumentNullException("storedName");

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                DbParameter[] commandParameters = HelperParameterCache(this.ConnectionString, storedName);

                AssignParameterValues(commandParameters, parameterValues);

                return ExecuteReader(CommandType.StoredProcedure, storedName, commandParameters);
            }
            else
            {
                return ExecuteReader(CommandType.StoredProcedure, storedName);
            }
        }

        public DbDataReader ExecuteReader(DbConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteReader(connection, commandType, commandText, (DbParameter[])null);
        }

        public DbDataReader ExecuteReader(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            return ExecuteReader(connection, (DbTransaction)null, commandType, commandText, commandParameters, DbConnectionOwnership.External);
        }

        public DbDataReader ExecuteReader(DbConnection connection, string storedName, params object[] parameterValues)
        {
            if (String.IsNullOrEmpty(storedName)) throw new ArgumentNullException("storedName");

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                DbParameter[] commandParameters = HelperParameterCache(connection.ConnectionString, storedName);

                AssignParameterValues(commandParameters, parameterValues);

                return ExecuteReader(connection, CommandType.StoredProcedure, storedName, commandParameters);
            }
            else
            {
                return ExecuteReader(connection, CommandType.StoredProcedure, storedName);
            }
        }

        public DbDataReader ExecuteReader(DbTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteReader(transaction, commandType, commandText, (DbParameter[])null);
        }

        public DbDataReader ExecuteReader(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null)
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, DbConnectionOwnership.External);
        }

        public DbDataReader ExecuteReader(DbTransaction transaction, string storedName, params object[] parameterValues)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            if (String.IsNullOrEmpty(storedName)) throw new ArgumentNullException("storedName");

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                DbParameter[] commandParameters = HelperParameterCache(transaction.Connection.ConnectionString, storedName);

                AssignParameterValues(commandParameters, parameterValues);

                return ExecuteReader(transaction, CommandType.StoredProcedure, storedName, commandParameters);
            }
            else
            {
                return ExecuteReader(transaction, CommandType.StoredProcedure, storedName);
            }
        }

        #endregion ExecuteReader

        #region ExecuteScalar

        public object ExecuteScalar(CommandType commandType, string commandText)
        {
            return ExecuteScalar(commandType, commandText, (DbParameter[])null);
        }

        public object ExecuteScalar(CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            using (DbConnection connection = (DbConnection)this.ProviderFactory.CreateConnection())
            {
                connection.ConnectionString = this.ConnectionString;
                connection.Open();

                return ExecuteScalar(connection, commandType, commandText, commandParameters);
            }
        }

        public object ExecuteScalar(string storedName, params object[] parameterValues)
        {
            if (String.IsNullOrEmpty(storedName)) throw new ArgumentNullException("storedName");

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                DbParameter[] commandParameters = HelperParameterCache(this.ConnectionString, storedName);

                AssignParameterValues(commandParameters, parameterValues);

                return ExecuteScalar(CommandType.StoredProcedure, storedName, commandParameters);
            }
            else
            {
                return ExecuteScalar(CommandType.StoredProcedure, storedName);
            }
        }

        public object ExecuteScalar(DbConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteScalar(connection, commandType, commandText, (DbParameter[])null);
        }

        public object ExecuteScalar(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            DbCommand cmd = (DbCommand)this.ProviderFactory.CreateCommand();

            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (DbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            object retval = cmd.ExecuteScalar();

            cmd.Parameters.Clear();

            if (mustCloseConnection)
                connection.Close();

            return retval;
        }

        public object ExecuteScalar(DbConnection connection, string storedName, params object[] parameterValues)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (String.IsNullOrEmpty(storedName)) throw new ArgumentNullException("storedName");

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                DbParameter[] commandParameters = HelperParameterCache(connection.ConnectionString, storedName);

                AssignParameterValues(commandParameters, parameterValues);

                return ExecuteScalar(connection, CommandType.StoredProcedure, storedName, commandParameters);
            }
            else
            {
                return ExecuteScalar(connection, CommandType.StoredProcedure, storedName);
            }
        }

        public object ExecuteScalar(DbTransaction transaction, CommandType commandType, string commandText)
        {
            return ExecuteScalar(transaction, commandType, commandText, (DbParameter[])null);
        }

        public object ExecuteScalar(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null)
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            DbCommand cmd = (DbCommand)this.ProviderFactory.CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            object retval = cmd.ExecuteScalar();

            cmd.Parameters.Clear();
            return retval;
        }

        public object ExecuteScalar(DbTransaction transaction, string storedName, params object[] parameterValues)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null)
                throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            if (storedName == null || storedName.Length == 0) throw new ArgumentNullException("storedName");

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                DbParameter[] commandParameters = HelperParameterCache(transaction.Connection.ConnectionString, storedName);

                AssignParameterValues(commandParameters, parameterValues);

                return ExecuteScalar(transaction, CommandType.StoredProcedure, storedName, commandParameters);
            }
            else
            {
                return ExecuteScalar(transaction, CommandType.StoredProcedure, storedName);
            }
        }

        #endregion ExecuteScalar

        #region FillDataset

        public void FillDataset(CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
        {
            if (dataSet == null) throw new ArgumentNullException("dataSet");

            using (DbConnection connection = (DbConnection)this.ProviderFactory.CreateConnection())
            {
                connection.ConnectionString = this.ConnectionString;
                connection.Open();

                FillDataset(connection, commandType, commandText, dataSet, tableNames);
            }
        }

        public void FillDataset(CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params DbParameter[] commandParameters)
        {
            if (dataSet == null) throw new ArgumentNullException("dataSet");
            using (DbConnection connection = (DbConnection)this.ProviderFactory.CreateConnection())
            {
                connection.ConnectionString = this.ConnectionString;
                connection.Open();

                FillDataset(connection, commandType, commandText, dataSet, tableNames, commandParameters);
            }
        }

        public void FillDataset(string storedName,
            DataSet dataSet, string[] tableNames,
            params object[] parameterValues)
        {
            if (dataSet == null) throw new ArgumentNullException("dataSet");
            using (DbConnection connection = (DbConnection)this.ProviderFactory.CreateConnection())
            {
                connection.ConnectionString = this.ConnectionString;
                connection.Open();

                FillDataset(connection, storedName, dataSet, tableNames, parameterValues);
            }
        }

        public void FillDataset(DbConnection connection, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames)
        {
            FillDataset(connection, commandType, commandText, dataSet, tableNames, null);
        }

        public void FillDataset(DbConnection connection, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params DbParameter[] commandParameters)
        {
            FillDataset(connection, null, commandType, commandText, dataSet, tableNames, commandParameters);
        }

        public void FillDataset(DbConnection connection, string storedName,
            DataSet dataSet, string[] tableNames,
            params object[] parameterValues)
        {
            if (dataSet == null) throw new ArgumentNullException("dataSet");
            if (storedName == null || storedName.Length == 0) throw new ArgumentNullException("storedName");

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                DbParameter[] commandParameters = HelperParameterCache(connection.ConnectionString, storedName);

                AssignParameterValues(commandParameters, parameterValues);

                FillDataset(connection, CommandType.StoredProcedure, storedName, dataSet, tableNames, commandParameters);
            }
            else
            {
                // Otherwise we can just call the SP without params
                FillDataset(connection, CommandType.StoredProcedure, storedName, dataSet, tableNames);
            }
        }

        public void FillDataset(DbTransaction transaction, CommandType commandType,
            string commandText,
            DataSet dataSet, string[] tableNames)
        {
            FillDataset(transaction, commandType, commandText, dataSet, tableNames, null);
        }

        public void FillDataset(DbTransaction transaction, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params DbParameter[] commandParameters)
        {
            FillDataset(transaction.Connection, transaction, commandType, commandText, dataSet, tableNames, commandParameters);
        }

        public void FillDataset(DbTransaction transaction, string storedName,
            DataSet dataSet, string[] tableNames,
            params object[] parameterValues)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            if (dataSet == null) throw new ArgumentNullException("dataSet");
            if (String.IsNullOrEmpty(storedName)) throw new ArgumentNullException("storedName");

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                DbParameter[] commandParameters = HelperParameterCache(transaction.Connection.ConnectionString, storedName);

                AssignParameterValues(commandParameters, parameterValues);

                FillDataset(transaction, CommandType.StoredProcedure, storedName, dataSet, tableNames, commandParameters);
            }
            else
            {
                FillDataset(transaction, CommandType.StoredProcedure, storedName, dataSet, tableNames);
            }
        }

        private void FillDataset(DbConnection connection, DbTransaction transaction, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params DbParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (dataSet == null) throw new ArgumentNullException("dataSet");

            DbCommand command = (DbCommand)this.ProviderFactory.CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(command, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            using (DbDataAdapter dataAdapter = (DbDataAdapter)this.ProviderFactory.CreateDataAdapter())
            {
                dataAdapter.SelectCommand = command;

                if (tableNames != null && tableNames.Length > 0)
                {
                    string tableName = "Table";
                    for (int index = 0; index < tableNames.Length; index++)
                    {
                        if (tableNames[index] == null || tableNames[index].Length == 0) throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames");
                        dataAdapter.TableMappings.Add(tableName, tableNames[index]);
                        tableName += (index + 1).ToString();
                    }
                }

                dataAdapter.Fill(dataSet);

                command.Parameters.Clear();
            }

            if (mustCloseConnection)
                connection.Close();
        }
        #endregion

        #region UpdateDataset

        public void UpdateDataset(DbCommand insertCommand, DbCommand deleteCommand, DbCommand updateCommand, DataSet dataSet, string tableName)
        {
            if (insertCommand == null) throw new ArgumentNullException("insertCommand");
            if (deleteCommand == null) throw new ArgumentNullException("deleteCommand");
            if (updateCommand == null) throw new ArgumentNullException("updateCommand");
            if (tableName == null || tableName.Length == 0) throw new ArgumentNullException("tableName");

            using (DbDataAdapter dataAdapter = (DbDataAdapter)this.ProviderFactory.CreateDataAdapter())
            {
                dataAdapter.UpdateCommand = updateCommand;
                dataAdapter.InsertCommand = insertCommand;
                dataAdapter.DeleteCommand = deleteCommand;

                dataAdapter.Update(dataSet, tableName);

                dataSet.AcceptChanges();
            }
        }
        #endregion

        #region CreateCommand

        public DbCommand CreateCommand(DbConnection connection, string storedName, params string[] sourceColumns)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (storedName == null || storedName.Length == 0) throw new ArgumentNullException("storedName");

            DbCommand cmd = (DbCommand)this.ProviderFactory.CreateCommand();
            cmd.Connection = connection;
            cmd.CommandText = storedName;
            cmd.CommandType = CommandType.StoredProcedure;

            if ((sourceColumns != null) && (sourceColumns.Length > 0))
            {
                DbParameter[] commandParameters = HelperParameterCache(connection.ConnectionString, storedName);

                for (int index = 0; index < sourceColumns.Length; index++)
                    commandParameters[index].SourceColumn = sourceColumns[index];

                AttachParameters(cmd, commandParameters);
            }

            return cmd;
        }
        #endregion

        #region CreateParameter
        public DbParameter[] CreateParameter(string[] parameterNames, object[] parameterValues)
        {
            if (parameterNames == null) throw new ArgumentNullException("connection");
            if (parameterValues == null) throw new ArgumentNullException("connection");
            if (parameterNames.Length != parameterValues.Length) throw new Exception("parameter lenght");

            DbParameter[] parameters = new DbParameter[parameterNames.Length];

            for (int i = 0; i < parameterNames.Length; i++)
            {
                parameters[i] = (DbParameter)this.ProviderFactory.CreateParameter();
                parameters[i].ParameterName = parameterNames[i];
                parameters[i].Value = parameterValues[i];
            }
            return parameters;
        }
        #endregion
    }
}

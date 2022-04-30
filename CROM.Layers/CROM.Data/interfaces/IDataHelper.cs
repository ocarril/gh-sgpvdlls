namespace CROM.Data.interfaces
{
    using System;
    using System.Data;
    using System.Data.Common;

    public interface IDataHelper
    {
        DbTransaction CreateTransaction();

        DbProviderFactory ProviderFactory { get; set; }
        string ProviderName { get; set; }
        string ConnectionString { get; set; }

        DbParameter CreateDbParameter(string _paramName, DbType paramType,
            Int32? paramSize, System.Data.ParameterDirection paramDirection, object paramValue);


        DbDataReader ExecuteEntity(string StoredName, object entity);
        object ExecuteEntityEscalar(string StoredName, object entity);
        object ExecuteEntityEscalar(DbTransaction transaction, string StoredName, object entity);
        int ExecuteEntityNonQuery(string StoredName, dynamic entity);
        int ExecuteEntityNonQuery(DbTransaction transaction, string StoredName, dynamic entity);
        int ExecuteNonQuery(CommandType commandType, string commandText);
        int ExecuteNonQuery(CommandType commandType, string commandText, params DbParameter[] commandParameters);
        int ExecuteNonQuery(string StoredName, params object[] parameterValues);
        int ExecuteNonQuery(DbConnection connection, CommandType commandType, string commandText);
        int ExecuteNonQuery(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters);
        int ExecuteNonQuery(ref DbCommand cmd);
        int ExecuteNonQuery(DbConnection connection, string StoredName, params object[] parameterValues);
        int ExecuteNonQuery(DbTransaction transaction, CommandType commandType, string commandText);
        int ExecuteNonQuery(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters);
        int ExecuteNonQuery(DbTransaction transaction, string StoredName, params object[] parameterValues);
        DataSet ExecuteDataset(CommandType commandType, string commandText);
        DataSet ExecuteDataset(CommandType commandType, string commandText, params DbParameter[] commandParameters);
        DataSet ExecuteDataset(string storedName, params object[] parameterValues);
        DataSet ExecuteDataset(DbConnection connection, CommandType commandType, string commandText);
        DataSet ExecuteDataset(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters);
        DataSet ExecuteDataset(DbConnection connection, string storedName, params object[] parameterValues);
        DataSet ExecuteDataset(DbTransaction transaction, CommandType commandType, string commandText);
        DataSet ExecuteDataset(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters);
        DataSet ExecuteDataset(DbTransaction transaction, string storedName, params object[] parameterValues);
        DbDataReader ExecuteReader(CommandType commandType, string commandText);
        DbDataReader ExecuteReader(CommandType commandType, string commandText, params DbParameter[] commandParameters);
        DbDataReader ExecuteReader(string storedName, params object[] parameterValues);
        DbDataReader ExecuteReader(DbConnection connection, CommandType commandType, string commandText);
        DbDataReader ExecuteReader(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters);
        DbDataReader ExecuteReader(DbConnection connection, string storedName, params object[] parameterValues);
        DbDataReader ExecuteReader(DbTransaction transaction, CommandType commandType, string commandText);
        DbDataReader ExecuteReader(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters);
        DbDataReader ExecuteReader(DbTransaction transaction, string storedName, params object[] parameterValues);
        object ExecuteScalar(CommandType commandType, string commandText);
        object ExecuteScalar(CommandType commandType, string commandText, params DbParameter[] commandParameters);
        object ExecuteScalar(string storedName, params object[] parameterValues);
        object ExecuteScalar(DbConnection connection, CommandType commandType, string commandText);
        object ExecuteScalar(DbConnection connection, CommandType commandType, string commandText, params DbParameter[] commandParameters);
        object ExecuteScalar(DbConnection connection, string storedName, params object[] parameterValues);
        object ExecuteScalar(DbTransaction transaction, CommandType commandType, string commandText);
        object ExecuteScalar(DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] commandParameters);
        object ExecuteScalar(DbTransaction transaction, string storedName, params object[] parameterValues);
        void FillDataset(CommandType commandType, string commandText, DataSet dataSet, string[] tableNames);

        void FillDataset(CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params DbParameter[] commandParameters);

        void FillDataset(string storedName,
            DataSet dataSet, string[] tableNames,
            params object[] parameterValues);

        void FillDataset(DbConnection connection, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames);

        void FillDataset(DbConnection connection, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params DbParameter[] commandParameters);

        void FillDataset(DbConnection connection, string storedName,
            DataSet dataSet, string[] tableNames,
            params object[] parameterValues);

        void FillDataset(DbTransaction transaction, CommandType commandType,
            string commandText,
            DataSet dataSet, string[] tableNames);

        void FillDataset(DbTransaction transaction, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params DbParameter[] commandParameters);

        void FillDataset(DbTransaction transaction, string storedName,
            DataSet dataSet, string[] tableNames,
            params object[] parameterValues);

        void UpdateDataset(DbCommand insertCommand, DbCommand deleteCommand, DbCommand updateCommand, DataSet dataSet, string tableName);
        DbCommand CreateCommand(DbConnection connection, string storedName, params string[] sourceColumns);
        DbParameter[] CreateParameter(string[] parameterNames, object[] parameterValues);
        //IEnumerable<dynamic> ExecuteDynamic(string uspDemogrid, params object[] parameters);
        //string ExecuteReaderAsJson(string uspDemogrid, params object[] parameters);
    }
}

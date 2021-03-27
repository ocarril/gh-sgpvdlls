namespace CROM.Tools.Comun.security.crypto
{
    using System;
    using System.Data.SqlTypes;
    using System.Security.Cryptography;
    using System.Text;

    public partial class UserDefinedFunctions
    {
        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlString EncryptFunction(SqlString dataInput)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();
            byte[] hashedDataBytes = md5Hasher.ComputeHash(encoder.GetBytes(dataInput.ToString()));
            return Convert.ToBase64String(hashedDataBytes);
        }
    }
}

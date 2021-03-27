using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace CROM.Tools.Crypto
{
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

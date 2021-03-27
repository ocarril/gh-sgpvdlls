using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace CROM.Tools.Comun.Extensions
{
    public static class StringExtensions
    {
        
        //public static string CipherMd5(this string str)
        //{
        //    MD5 md5Hash = MD5.Create();
        //    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str));
        //    StringBuilder sBuilder = new StringBuilder();
        //    int i;

        //    for (i = 0; i < data.Length; i++)
        //    {
        //        sBuilder.Append(data[i].ToString("x2"));
        //    }
        //    return sBuilder.ToString();
        //}

        public static DateTime StringToDate(this string str)
        {
            var fecha = new DateTime();
            if (DateTime.TryParse(str, new CultureInfo("es-PE"), DateTimeStyles.None, out fecha))
            {
                return fecha;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

    }
}

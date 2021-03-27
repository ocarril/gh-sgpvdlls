#region Imports

using System;

#endregion

namespace CROM.Tools.Comun.Extensions
{
    public static class DateTimeExtensions
    {
        static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        static readonly double MaxUnixSeconds = (DateTime.MaxValue - UnixEpoch).TotalSeconds;

        //public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        //{
        //    return unixTimeStamp > MaxUnixSeconds
        //       ? UnixEpoch.AddMilliseconds(unixTimeStamp)
        //       : UnixEpoch.AddSeconds(unixTimeStamp);
        //}
        public static string DateTimeString(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy HH:mm:ss");
        }

        public static string GetConcatTime(string concat)
        {
            return String.Concat(GetConcatTime(), concat);
        }

        public static string GetConcatTime()
        {
            DateTime time = DateTime.Now;
            string month = time.Month.ToString().PadLeft(2, '0');
            string day = time.Day.ToString().PadLeft(2, '0');
            string hour = time.Hour.ToString().PadLeft(2, '0');
            string minute = time.Minute.ToString().PadLeft(2, '0');
            string second = time.Second.ToString().PadLeft(2, '0');
            return String.Concat(time.Year, month, day, hour, minute, second,time.Millisecond);
        }

        public static ulong DateTimeToUnixTimestamp(this DateTime dateTime)
        {
            return Convert.ToUInt64((dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds);
        }

        public static DateTime UnixTimeStampToDateTime(ulong unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(Convert.ToDouble(unixTimeStamp)).ToLocalTime();
            return dtDateTime;
        }
    }
}
namespace CROM.Tools.Comun
{
    using System;
    using System.Configuration;
    using System.Text.RegularExpressions;

    public static class Extensors
    {
        #region Convertidores

        public static DateTime? ToDateTime(this object Expression)
        {
            DateTime? result = null;
            try
            {
                result = Convert.ToDateTime(Expression);
            }
            catch { }
            return result;
        }

        public static decimal ToDecimal(this object Expression, decimal DefaultValue)
        {
            decimal result = DefaultValue;
            try
            {
                result = Convert.ToDecimal(Expression);
            }
            catch { }
            return result;
        }

        public static double ToDouble(this object Expression)
        {
            return ToDouble(Expression, 0);
        }

        public static double ToDouble(this object Expression, double DefaultValue)
        {
            double result = DefaultValue;
            try
            {
                result = Convert.ToDouble(Expression);
            }
            catch { }
            return result;
        }

        public static decimal ToDecimal(this object Expression)
        {
            return ToDecimal(Expression, 0);
        }

        public static int ToInteger(this object Expression, int DefaultValue)
        {
            int result = DefaultValue;
            try
            {
                result = Convert.ToInt32(Expression);
            }
            catch { }
            return result;
        }

        public static int ToInt16(this object Expression)
        {
            return ToInt16(Expression, 0);
        }

        public static int ToInt16(this object Expression, int DefaultValue)
        {
            int result = DefaultValue;
            try
            {
                result = Convert.ToInt16(Expression);
            }
            catch { }
            return result;
        }

        public static int ToInteger(this object Expression)
        {
            return ToInteger(Expression, 0);
        }
        public static int ToByte(this object Expression, int DefaultValue)
        {
            int result = DefaultValue;
            try
            {
                result = Convert.ToByte(Expression);
            }
            catch { }
            return result;
        }

        public static bool ToBoolean(this object Expression)
        {
            bool result = false;
            try
            {
                switch (Expression.GetType().Name)
                {
                    case "Int32":
                        if ((int)Expression == 1)
                            result = true;
                        else
                            result = false;
                        break;
                    case "Int16":
                        if ((short)Expression == 1)
                            result = true;
                        else
                            result = false;
                        break;
                    case "String":
                        string oString = (string)Expression;
                        if (oString.ToLower().Equals("true"))
                            result = true;
                        else
                            result = false;
                        break;
                    default:
                        result = Convert.ToBoolean(Expression);
                        break;
                }
            }
            catch { }
            return result;
        }

        static public bool IsNumeric(object value)
        {
            bool resultado;
            double numero;
            resultado = Double.TryParse(Convert.ToString(value), 
                                        System.Globalization.NumberStyles.Any, 
                                        System.Globalization.NumberFormatInfo.InvariantInfo, 
                                        out numero);
            return resultado;

        }

        static public bool IsNumeric2(string inputString)
        {
            return Regex.IsMatch(inputString, "^[0-9]+$");
        }

        static public decimal RedondearMontos(double value, int nroDecimales)
        {
            return ToDecimal(Math.Round(value, nroDecimales));
        }
        static public decimal RedondearMontos(decimal value, int nroDecimales)
        {
            return ToDecimal(Math.Round(value, nroDecimales));
        }

        public static double ConvertSolesToCentimos(double vMonto)
        {
            return (vMonto * 100);
        }
    
        public static string FormatoInternacional(string telefono)
        {
            string salida = string.Empty;

            salida = "51" + telefono;
            return salida;
        }
    
        static public string FormatFecha(string vFecha)
        {
            string fecha = string.Empty;
            fecha = vFecha.Replace(@"-", string.Empty);
            if (vFecha != string.Empty)
            {
                fecha = fecha.Substring(8, 2) + "/" + fecha.Substring(4, 2) + "/" + fecha.Substring(0, 4);
            }
            return fecha;
        }


        /// <summary>
        /// funcion adicionada para validar
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static public string ConvertSoles(object value)
        {
            string salida = "0.00";
            if (value == null || value == System.DBNull.Value)
            {
                salida = "0.00";
            }
            else
            {
                if (Convert.ToString(value) == string.Empty)
                    salida = "0.00";
                else
                    salida = string.Format("{0:n}", Convert.ToDouble(value) / 100);
            }
            return salida;
        }

        #endregion

        #region Formateadores

        public static string FormatTo2Decimals(this object Expression)
        {
            string oExpression = string.Empty;
            if (Expression != null)
            {
                switch (Expression.GetType().Name)
                {
                    case "Int16":
                    case "Int32":
                    case "Decimal":
                    case "Single":
                        return string.Format("{0:###########0.00##}", Expression);
                    default:
                        return oExpression;
                }
            }
            else return oExpression;
        }

        public static string FormatDateToDDMMYYYY(this object Expression)
        {
            if (Expression != null)
            {
                if (Expression.GetType().Name == "DateTime")
                {
                    DateTime oExpression = Convert.ToDateTime(Expression);
                    if (oExpression == DateTime.MinValue) return string.Empty;
                    return oExpression.ToString("dd/MM/yyyy");
                }
                else
                {
                    string sExpression = Expression.ToString();
                    try
                    {
                        if (sExpression.Length == 8) // Ejemplo de Formato: 20140418
                        {
                            sExpression = sExpression.Substring(6, 2) + "/" + sExpression.Substring(4, 2) + "/" + sExpression.Substring(0, 4);
                        }
                        else if (sExpression.Contains("1900"))
                        {
                            return string.Empty;
                        }
                        DateTime oExpression = Convert.ToDateTime(Expression);
                        if (oExpression == DateTime.MinValue) sExpression = string.Empty;
                        sExpression = oExpression.ToString("dd/MM/yyyy");
                    }
                    catch { }
                    return sExpression;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public static string FormatDateToDDMMYYYYHHMM(this object Expression)
        {
            return FormatDateToDDMMYYYYHHMM(Expression, false);
        }

        public static string FormatDateToDDMMYYYYHHMM(this object Expression, bool Hour24)
        {
            if (Expression != null)
            {
                if (Expression.GetType().Name == "DateTime")
                {
                    DateTime oExpression = Convert.ToDateTime(Expression);
                    if (oExpression == DateTime.MinValue) return string.Empty;
                    if (Hour24)
                        return oExpression.ToString("dd/MM/yyyy HH:mm:ss");
                    else
                        return oExpression.ToString("dd/MM/yyyy hh:mm tt");
                }
                else
                {
                    string sExpression = Expression.ToString();
                    try
                    {
                        DateTime oExpression = Convert.ToDateTime(Expression);
                        if (oExpression == DateTime.MinValue) sExpression = string.Empty;
                        if (Hour24)
                            return oExpression.ToString("dd/MM/yyyy HH:mm:ss");
                        else
                            return oExpression.ToString("dd/MM/yyyy hh:mm tt");
                    }
                    catch { }
                    return sExpression;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public static string FormatDateToYYYY_MM_DD(this object Expression)
        {

            if (Expression != null)
            {
                if (Expression.GetType().Name == "DateTime")
                {
                    DateTime oExpression = Convert.ToDateTime(Expression);
                    if (oExpression == DateTime.MinValue) return string.Empty;
                    return oExpression.ToString("yyyy-MM-dd");
                }
                else
                {
                    string sExpression = Expression.ToString();
                    try
                    {
                        DateTime oExpression = Convert.ToDateTime(Expression);
                        if (oExpression == DateTime.MinValue) sExpression = string.Empty;
                        sExpression = oExpression.ToString("yyyy-MM-dd");
                    }
                    catch { }
                    return sExpression;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public static string FormatDateToYYYYMMDD(this object Expression)
        {

            if (Expression != null)
            {
                if (Expression.GetType().Name == "DateTime")
                {
                    DateTime oExpression = Convert.ToDateTime(Expression);
                    if (oExpression == DateTime.MinValue) return string.Empty;
                    return oExpression.Year.ToString() + oExpression.Month.ToString().PadLeft(2, '0') + oExpression.Day.ToString().PadLeft(2, '0');
                }
                else
                {
                    string sExpression = Expression.ToString();
                    try
                    {
                        DateTime oExpression = Convert.ToDateTime(Expression);
                        if (oExpression == DateTime.MinValue) sExpression = string.Empty;
                        sExpression = oExpression.Year.ToString() + oExpression.Month.ToString().PadLeft(2, '0') + oExpression.Day.ToString().PadLeft(2, '0');
                    }
                    catch { }
                    return sExpression;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public static string FormatDateToHHMMSS(this object Expression)
        {

            if (Expression != null)
            {

                string sExpression = Expression.ToString();
                try
                {
                    sExpression = sExpression.Substring(0, 2) + ":" + sExpression.Substring(2, 2) + ":" + sExpression.Substring(4, 2);
                }
                catch { }
                return sExpression;

            }
            else
            {
                return string.Empty;
            }
        }
        
        static public string StringCamell(this object Expression)
        {

            if (Expression != null)
            {

                string sExpression = Expression.ToString();
                try
                {
                    string nuevoStringCamell = string.Empty;
                    string[] arrayCadenaString = sExpression.Split(' ');
                    foreach (string cadaPalabra in arrayCadenaString)
                    {
                        nuevoStringCamell = nuevoStringCamell + string.Concat(cadaPalabra.Substring(0, 1).ToUpper(),
                                                                              cadaPalabra.Substring(1, cadaPalabra.Length - 1).ToLower(),
                                                                              " ");
                    }

                    sExpression = nuevoStringCamell.TrimEnd();
                }
                catch { }
                return sExpression;

            }
            else
            {
                return string.Empty;
            }
        }

        #endregion

        static public string CheckStr(object value)
        {
            string salida = string.Empty;
            if (value == null || value == System.DBNull.Value)
                salida = string.Empty;
            else
                salida = value.ToString();
            return salida.Trim();
        }

        static public Int64 CheckInt64(object value)
        {
            Int64 salida = 0;
            if (value == null || value == System.DBNull.Value)
            {
                salida = 0;
            }
            else
            {
                if (Convert.ToString(value) == string.Empty)
                    salida = 0;
                else
                    salida = Convert.ToInt64(value);
            }
            return salida;
        }

        static public float CheckFloat(object value)
        {
            int salida = 0;
            if (value == null || value == System.DBNull.Value)
            {
                salida = 0;
            }
            else
            {
                if (Convert.ToString(value) == string.Empty)
                    salida = 0;
                else
                    salida = Convert.ToInt32(value);
            }
            return salida;
        }

        static public int CheckInt(object value)
        {
            int salida = 0;
            if (value == null || value == System.DBNull.Value)
            {
                salida = 0;
            }
            else
            {
                if (Convert.ToString(value) == string.Empty)
                    salida = 0;
                else
                    salida = Convert.ToInt32(value);
            }
            return salida;
        }

        static public int? CheckIntnull(object value)
        {
            int? salida = 0;
            if (value == null || value == System.DBNull.Value)
            {
                salida = null;
            }
            else
            {
                if (Convert.ToString(value) == string.Empty)
                    salida = 0;
                else
                    salida = Convert.ToInt32(value);
            }
            return salida;
        }

        static public int CheckByte(object value)
        {
            byte salida = 0;
            if (value == null || value == System.DBNull.Value)
            {
                salida = 0;
            }
            else
            {
                if (Convert.ToString(value) == string.Empty)
                    salida = 0;
                else
                    salida = Convert.ToByte(value);
            }
            return salida;
        }
        static public double CheckDbl(object value)
        {
            double salida = 0;
            if (value == null || value == System.DBNull.Value)
            {
                salida = 0;
            }
            else if(string.IsNullOrEmpty( value.ToString()))
            {
                salida = 0;
            }
            else
            {
                if (Convert.ToString(value) == string.Empty)
                    salida = 0;
                else
                    salida = Convert.ToDouble(value);
            }
            return salida;
        }

        static public decimal CheckDecimal(object value)
        {
            decimal salida = 0;
            if (value == null || value == System.DBNull.Value)
            {
                salida = 0;
            }
            else
            {
                if (Convert.ToString(value) == string.Empty)
                    salida = 0;
                else
                    salida = Convert.ToDecimal(value);
            }
            return salida;
        }

        static public object CheckDblDB(object value)
        {
            double salida = 0;
            if (value == null || value == System.DBNull.Value)
            {
                return System.DBNull.Value;
            }
            salida = Convert.ToDouble(value);
            return salida;
        }

        static public double CheckDbl(object value, int nroDecimales)
        {
            double salida = 0;
            if (value == null || value == System.DBNull.Value)
            {
                salida = 0;
            }
            else
            {
                salida = Convert.ToDouble(value);
            }
            return redondearMontos(salida, nroDecimales);
        }

        static public double redondearMontos(double value, int nroDecimales)
        {
            return Math.Round(value, nroDecimales);
        }

        static public Nullable<DateTime> CheckDate(object value)
        {
            Nullable<DateTime> salida;
            if (value == null || value == System.DBNull.Value)
            {
                salida = null;
            }
            else
            {
                salida = Convert.ToDateTime(value);
            }

            return salida;
        }

        static public DateTime CheckDateHoy(object value)
        {
            DateTime salida;
            if (value == null || value == System.DBNull.Value)
            {
                salida = DateTime.Now;
            }
            else
            {
                salida = Convert.ToDateTime(value);
            }

            return salida;
        }
    }
}

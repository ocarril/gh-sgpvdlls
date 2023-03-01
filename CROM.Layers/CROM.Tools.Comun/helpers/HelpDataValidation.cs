using CROM.Tools.Comun.Web;
using System;
using System.Text.RegularExpressions;

namespace CROM.Tools.Comun
{
    public static class HelpDataValidation
    {

        /// <summary>
        /// Valida si una fecha es mayor o igual a la fecha del sistema
        /// </summary>
        /// <param name="value">fecha a validar</param>
        /// <returns>true o false</returns>
        public static bool FechaMayorIgualActual(DateTime value)
        {
            var currentDate = DateTime.Today;
            if (value >= currentDate)
                return true;

            return false;
        }

        /// <summary>
        /// Valida si una fecha es menor o igual a la fecha del sistema
        /// </summary>
        /// <param name="value">fecha a validar</param>
        /// <returns>true o false</returns>
        public static bool FechaMenorIgualActual(DateTime value)
        {
            var currentDate = DateTime.Today;
            if (value <= currentDate)
                return true;

            return false;
        }

        /// <summary>
        /// Valida si el parámetro ingresado contiene solo numeros
        /// </summary>
        /// <param name="value">cadena de texto a validar</param>
        /// <returns>true o false</returns>
        public static bool ExpRegValidateNumber(string value)
        {
            var match = Regex.Match(value, ValidExpresionRegularesConstants.ExpRegValidateNumber);
            if (match.Success)
                return true;
            return false;

        }

        /// <summary>
        /// Valida si el parámetro ingresado contiene solo letras + áÁéÉíÍóÓúÚñÑüÜ
        /// </summary>
        /// <param name="value">cadena de texto a validar</param>
        /// <returns>true o false</returns>
        public static bool ExpRegValidateLetters(string value)
        {

            var match = Regex.Match(value, ValidExpresionRegularesConstants.ExpRegValidateLetters);
            if (match.Success)
                return true;
            return false;

        }


        /// <summary>
        /// Valida si el parámetro ingresado es un email valido
        /// </summary>
        /// <param name="value">cadena de texto a validar</param>
        /// <returns>true o false</returns>
        public static bool ExpRegValidateEmail(string value)
        {
            var expresion = ValidExpresionRegularesConstants.ExpRegValidateEmail;
            if (Regex.IsMatch(value, expresion))
            {
                if (Regex.Replace(value, expresion, String.Empty).Length == 0)
                    return true;
            }
            return false;

        }


        /// <summary>
        /// Valida si el parámetro ingresado contiene letras, numeros, áÁéÉíÍóÓúÚñÑüÜ, letras + numeros + áÁéÉíÍóÓúÚñÑüÜ
        /// </summary>
        /// <param name="value">cadena de texto a validar</param>
        /// <returns>true o false</returns>
        /// 
        public static bool ExpRegValidateAlfaNumeric(string value)
        {

            var match = Regex.Match(value, ValidExpresionRegularesConstants.ExpRegValidateAlfaNumeric);
            if (match.Success)
                return true;

            return false;
        }

        /// <summary>
        /// Valida si el parámetro ingresado contiene letras, numeros, áÁéÉíÍóÓúÚñÑüÜ , letras + numeros + áÁéÉíÍóÓúÚñÑüÜ
        /// </summary>
        /// <param name="value">cadena de texto a validar</param>
        /// <returns>true o false</returns>
        public static bool ExpRegValidateAlfaNumericSpace(string value)
        {
            var match = Regex.Match(value, ValidExpresionRegularesConstants.ExpRegValidateAlfaNumericSpace);
            if (match.Success)
                return true;

            return false;
        }

        /// <summary>
        /// Valida si el parámetro ingresado es una phono con las siguientes caracteristicas 112-121-212
        /// </summary>
        /// <param name="value">cadena de texto a validar</param>
        /// <returns>true o false</returns>
        public static bool ExpRegValidatePhone(string value)
        {
            var match = Regex.Match(value, ValidExpresionRegularesConstants.ExpRegValidatePhone);
            if (match.Success)
                return true;

            return false;
        }

        /// <summary>
        /// Valida si el parámetro ingresado completo se encuentra en el texto
        /// solo letras + áÁéÉíÍóÓúÚñÑüÜ
        /// </summary>
        /// <param name="texto">cadena de texto donde se va a encontrar el palabra</param>
        /// <param name="word">palabra completa que se va a buscar en el texto</param>
        /// <returns>true o false</returns>
        public static bool ExpRegValidateFindWord(string texto, string word)
        {
            var match = Regex.Match(texto, string.Format(@"\b{0}\b", word));

            if (match.Success)
                return true;

            return false;
        }

        /// <summary>
        /// Valida si el parámetro ingresado solo es texto y _
        /// </summary>
        /// <param name="value">cadena de texto a validar</param>
        /// <returns>true o false</returns>
        public static bool ExpRegValidateTextoUnderline(string value)
        {
            var match = Regex.Match(value.ToLower(), ValidExpresionRegularesConstants.ExpRegValidateTextoUnderline);
            if (match.Success)
                return true;

            return false;
        }

    }
}

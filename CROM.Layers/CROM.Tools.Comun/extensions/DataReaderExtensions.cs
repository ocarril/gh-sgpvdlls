using System.Data;

namespace CROM.Tools.Comun.Extensions
{
    public static class DataReaderExtensions
    {
        /// <summary>
        ///  Obtiene el Valor de una Columna de un IDataRecord
        /// </summary>
        /// <typeparam name="T">Tipo de Dato de la Variable</typeparam>
        /// <param name="r">IDataRecord a Procesar</param>
        /// <param name="columnName">Nombre de la Columna a Obtener el Valor</param>
        /// <param name="defaultValue">Valor por Defecto si es NULL o no existe la Columna</param>
        public static T GetValue<T>(this IDataRecord r, string columnName, T defaultValue)
        {
            T value = default(T);

            //if (!HasColumn(r, columnName)) return value;

            int index = r.GetOrdinal(columnName);
            value = GetValue<T>(r, index, defaultValue);
            return value;
        }

        /// <summary>
        ///  Obtiene el Valor de una Columna de un IDataRecord
        /// </summary>
        /// <typeparam name="T">Tipo de Dato de la Variable</typeparam>
        /// <param name="r">IDataRecord a Procesar</param>
        /// <param name="index">Index de la Columna a extraer la informacion</param>
        /// <param name="defaultValue">Valor por Defecto si es NULL o no existe la Columna</param>
        public static T GetValue<T>(this IDataRecord r, int index, T defaultValue)
        {
            T value = defaultValue;
            //if (r.FieldCount <= index) return value;

            if (!r.IsDBNull(index))
            {
                value = (T)r.GetValue(index);
            }
            return value;
        }

    }

}


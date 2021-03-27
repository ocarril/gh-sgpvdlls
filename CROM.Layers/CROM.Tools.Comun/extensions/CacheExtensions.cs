#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

#endregion

namespace CROM.Tools.Comun.Extensions
{
    public static class CacheExtensions
    {
        #region Variables

        private static readonly ObjectCache Cache = MemoryCache.Default;

        #endregion

        #region Metodos

        /// <summary>
        ///     Agrega un nuevo valor a la Cache utilizando un nuevo par Clave/Valor, con una vigencia de 30 Dias.
        /// </summary>
        /// <typeparam name="T">Tipo de item que sera agregado a la Cache</typeparam>
        /// <param name="objectToCache">Item que se agregara a la Cache</param>
        /// <param name="key">Nombre del Item que se agregara a la memoria Cache</param>
        public static void Add<T>(T objectToCache, string key) where T : class
        {
            if (Exists(key))
                Clear(key);
            Cache.Add(key, objectToCache, DateTime.Now.AddDays(30));
        }

        /// <summary>
        ///     Agrega un nuevo valor a la Cache utilizando un nuevo par Clave/Valor, con una vigencia de 30 Dias.
        /// </summary>
        /// <param name="objectToCache">Item que se agregara a la Cache</param>
        /// <param name="key">Nombre del Item que se agregara a la memoria Cache</param>
        public static void Add(object objectToCache, string key)
        {
            if (Exists(key))
                Clear(key);
            Cache.Add(key, objectToCache, DateTime.Now.AddDays(30));
        }

        /// <summary>
        ///     Quita un Item de la Memoria Cache
        /// </summary>
        /// <param name="key">Nombre del Item que se va a eliminar de la cache</param>
        public static void Clear(string key)
        {
            if (Exists(key))
            {
                Cache.Remove(key);
            }
        }

        #endregion

        #region Funciones

        /// <summary>
        ///     Verifica si un Item Existe
        /// </summary>
        /// <param name="key">Nombre del item que se va a buscar</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            return Cache.Get(key) != null;
        }

        /// <summary>
        ///     Recupera todos lso Elementos existentes en la Memoria Cache
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAll()
        {
            return Cache.Select(keyValuePair => keyValuePair.Key).ToList();
        }

        /// <summary>
        ///     Recupera un Item de la Cache
        /// </summary>
        /// <typeparam name="T">Tipo de item que sera recuperado a la Cache </typeparam>
        /// <param name="key">Nombre del Item que se encuentra a la memoria Cache</param>
        public static T Get<T>(string key) where T : class
        {
            try
            {
                return (T) Cache[key];
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}
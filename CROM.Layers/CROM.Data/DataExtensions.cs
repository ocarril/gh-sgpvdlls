namespace CROM.Data
{
    using CROM.Data.interfaces;

    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Dynamic;
    using System.Linq;
    using System.Reflection;


    public static class DataExtensions
    {
        public static IEnumerable<dynamic> ToDynamics(this IDataReader reader, bool close = true)
        {
            return GetDynamicsByReader(reader, close);
        }

        public static dynamic ToDynamic(this IDataReader reader, bool close = true)
        {
            return GetDynamicByReader(reader, close);
        }

        public static IQueryPage<dynamic> ToQueryPage(this IDataReader reader, bool close = true)
        {
            return GetQueryPageDynamicByReader(reader, close); ;
        }

        private static IQueryPage<dynamic> GetQueryPageDynamicByReader(IDataReader dataReader, bool close = true)
        {
            QueryPage<dynamic> queryPage = new QueryPage<dynamic>();
            var propertiesQueryPage = FindClassProperties(typeof(IQueryPage<dynamic>), dataReader);
            var queryRead = true;

            var result = new List<dynamic>();

            var fieldCount = dataReader.FieldCount;
            while (dataReader.Read())
            {
                dynamic onlyRow = new ExpandoObject();
                for (var i = 0; i < fieldCount; i++)
                {
                    ((IDictionary<string, object>)onlyRow).Add(dataReader.GetName(i), dataReader.GetValue(i));
                }
                result.Add(onlyRow);
                if (!queryRead) continue;
                queryPage = GetEntity<QueryPage<dynamic>>(dataReader, propertiesQueryPage);
                queryRead = false;
            }


            if (close) dataReader.Close();
            //if (queryRead) return new QueryPage<dynamic> { Total = 0, Rows = new List<dynamic> };
            queryPage.AddResult(result);
            return queryPage;
        }

        private static IEnumerable<dynamic> GetDynamicsByReader(IDataReader dataReader, bool close = true)
        {
            var fieldCount = dataReader.FieldCount;
            while (dataReader.Read())
            {
                dynamic onlyRow = new ExpandoObject();
                for (var i = 0; i < fieldCount; i++)
                {
                    ((IDictionary<string, object>)onlyRow).Add(dataReader.GetName(i), dataReader.GetValue(i));
                }
                yield return onlyRow;
            }
            if (close) dataReader.Close();
        }

        private static dynamic GetDynamicByReader(IDataReader dataReader, bool close = true)
        {
            var fieldCount = dataReader.FieldCount;
            while (dataReader.Read())
            {
                dynamic onlyRow = new ExpandoObject();
                for (var i = 0; i < fieldCount; i++)
                {
                    ((IDictionary<string, object>)onlyRow).Add(dataReader.GetName(i), dataReader.GetValue(i));
                }
                return onlyRow;
            }
            if (close) dataReader.Close();
            return null;
        }

        public static IQueryPage<T> ToQueryPage<T>(this IDataReader reader, bool close = true)
        {
            return GetQueryPageByReader<T>(reader, close);
        }

        public static IEnumerable<T> ToEntities<T>(this IDataReader reader, bool close = true)
        {
            return GetEntitiesByReader<T>(reader, close);
        }

        public static T ToEntity<T>(this IDataReader reader, bool close = true)
        {
            return GetEntityByReader<T>(reader, close);
        }

        private static T GetEntityByReader<T>(IDataReader dataReader, bool close = true)
        {
            var properties = FindClassProperties(typeof(T), dataReader);
            while (dataReader.Read())
            {
                var x = GetEntity<T>(dataReader, properties);
                return x;
            }
            if (close) dataReader.Close();
            return default(T);
        }

        private static IEnumerable<T> GetEntitiesByReader<T>(IDataReader dataReader, bool close = true)
        {
            var properties = FindClassProperties(typeof(T), dataReader);
            while (dataReader.Read())
            {
                var x = GetEntity<T>(dataReader, properties);
                yield return x;
            }
            if (close) dataReader.Close();
        }

        private static IQueryPage<T> GetQueryPageByReader<T>(IDataReader dataReader, bool close = true)
        {
            QueryPage<T> queryPage = null;
            var propertiesQueryPage = FindClassProperties(typeof(IQueryPage<T>), dataReader);
            var queryRead = true;

            var result = new List<T>();

            var properties = FindClassProperties(typeof(T), dataReader);
            while (dataReader.Read())
            {
                var x = GetEntity<T>(dataReader, properties);
                result.Add(x);
                if (!queryRead) continue;
                queryPage = GetEntity<QueryPage<T>>(dataReader, propertiesQueryPage);
                queryRead = false;
            }

            if (close) dataReader.Close();
            if (queryRead) return null;
            queryPage.AddResult(result);
            return queryPage;
        }



        private static T GetEntity<T>(IDataRecord record, IEnumerable<CustomProperty> properties)
        {
            var x = Activator.CreateInstance<T>();
            foreach (var property in properties)
            {
                SetValueProperty(x, property, record);
            }
            return x;
        }

        private static readonly ConcurrentDictionary<Type, List<CustomProperty>> ReflectionPropertyCache = new ConcurrentDictionary<Type, List<CustomProperty>>();

        private static List<CustomProperty> FindClassProperties(Type objectType, IDataReader record)
        {
            //if (ReflectionPropertyCache.ContainsKey(objectType))
            //    return ReflectionPropertyCache[objectType];

            var properties = objectType.GetProperties();
            var result = (from property in properties
                          let field = Enumerable.Range(0, record.FieldCount)
                                                .Select(i => new { index = i, name = record.GetName(i) })
                                                .SingleOrDefault(x => x.name.Equals(property.Name, StringComparison.OrdinalIgnoreCase))
                          where field != null
                          select new CustomProperty
                          {
                              Name = property.Name,
                              PropertyInfo = property,
                              RecordOrder = field.index
                          }).ToList();

            //ReflectionPropertyCache.TryAdd(objectType, result);

            return result;
        }

        private static void SetValueProperty<T>(T source, CustomProperty property, IDataRecord record)
        {
            var value = record.GetValue(property.RecordOrder);
            if (value.GetType() != typeof(DBNull))
            {
                try
                {
                    property.PropertyInfo.SetValue(source, value, null);
                }
                catch (Exception ex)
                {
                    var error = string.Format(" - Failed  - The field {0} not type {1}.", property.Name,
                        value.GetType());
                    Debug.WriteLine(error);
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        private struct CustomProperty
        {
            public string Name { get; set; }
            public PropertyInfo PropertyInfo { get; set; }
            public int RecordOrder { get; set; }
        }
    }
}
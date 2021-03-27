namespace CROM.Tools.Services.Utilitarios.Excel
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    //using Belcorp.Planit.Domain.Entities.Views;
    using DocumentFormat.OpenXml.Spreadsheet;

    /// <summary>
    /// Objeto que representa una hoja de excel
    /// </summary>
    /// <remarks>
    /// Creacion: 	LOG(EMP) 20120607 <br />
    /// </remarks>
    public class WorkSheet
    {
        public string Id { get; set; }
        public int WorkSheetIndex { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public RowData HeaderRow { get; set; }
        public List<RowData> Rows { get; set; }
        public UInt32 StartRowIndex { get; set; }
        public Columns Columns { get; set; }
        public List<DefinedNameVal> DefinedNameValues { get; set; }

        public WorkSheet()
        { this.StartRowIndex = 1; }

        public void MapperListToRows<T>(List<T> listObject, Dictionary<int, string> mapper)
        {
            MapperListToRows<T>(listObject, mapper, null);
        }

        public void MapperListToRows<T>(List<T> listObject, Dictionary<int, string> mapper, string agrupador)
        {
            if (listObject == null || mapper == null)
            {
                throw new ArgumentException();
            }

            this.Rows = new List<RowData>();
            if (listObject.Count > 0)
            {

                var rowIndex = this.StartRowIndex;

                if (this.Title != null && !this.Title.Equals(""))
                {
                    rowIndex++;
                }
                if (this.HeaderRow != null)
                {
                    this.HeaderRow.RowIndex = rowIndex++;
                }

                foreach (var registro in listObject)
                {
                    int valor = (agrupador != null && GetPropertyValue(typeof(T), agrupador, registro) != null) ? 1 : 0;
                    RowData row = valor == 0 ? new RowData(rowIndex) : new RowData { RowIndex = rowIndex, OutlineLevel = 1 };
                    row.Cells = MapperToCells(mapper, rowIndex, registro);
                    this.Rows.Add(row);
                    rowIndex++;
                }
            }
        }

        public List<CellData> MapperToCells<T>(Dictionary<int, string> mapper, uint rowIndex, T data)
        {
            Type type = typeof(T);
            var cells = new List<CellData>();
            int newIndex = 0;
            foreach (var item in mapper)
            {
                object value = GetPropertyValue(type, item.Value, data);
                Type propertyType = type.GetProperty(item.Value).PropertyType;
                CellData cell;
                if ((propertyType.IsArray || propertyType.Namespace.ToLower().Equals("system.collections.generic")) && value != null)
                {
                    foreach (var objectItem in (value as IEnumerable<object>))
                    {
                        cell = new CellData(item.Key + newIndex++, rowIndex) { Value = objectItem != null ? objectItem.ToString() : null };
                        cells.Add(cell);
                    }
                }
                else
                {
                    cell = new CellData(item.Key + newIndex, rowIndex) { Value = value != null ? value.ToString() : null };
                    cells.Add(cell);
                }
            }
            return cells;
        }

        public object GetPropertyValue(Type type, string propertyName, object item)
        {
            PropertyInfo property = type.GetProperty(propertyName);
            if (property == null)
            {
                throw new ArgumentException("No se encontro la propiedad mapeada, propiedad invalida :" + propertyName);
            }
            object value = property.GetValue(item, null);
            return value;
        }
    }
}

namespace CROM.Tools.Comun.utils.excel
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using DocumentFormat.OpenXml.Spreadsheet;
    using DocumentFormat.OpenXml.Packaging;
    using System.Linq;
    using DocumentFormat.OpenXml.Wordprocessing;

    /// <summary>
    /// Objeto que representa una fila de Excel
    /// </summary>
    /// <remarks>
    /// Creacion: 	LOG(EMP) 20120607 <br />
    /// </remarks>
    public class RowData
    {
        public UInt32 RowIndex { get; set; }
        public byte OutlineLevel { get; set; }
        public List<CellData> Cells { get; set; }
        public string DefaultStyleId { get; set; }

        public RowData() { }

        public RowData(UInt32 index)
        {
            this.RowIndex = index;
            this.OutlineLevel = 0;
        }

        public RowData(UInt32 index, byte outlineLevel)
        {
            this.RowIndex = index;
            this.OutlineLevel = outlineLevel;
        }

        public RowData(Row row, SharedStringTable sharedStringTable)
        {
            this.RowIndex = row.RowIndex;
            this.GetCells(row, sharedStringTable);
        }

        /// <summary>
        /// obtiene las celdas que contiene una fila de excel.
        /// </summary>
        /// <param name="row">objeto Row de OPEN XML -> Fila de donde se obtiene le valor</param>
        /// <param name="sharedStringTable">objeto sharedStringTable de OPEN XML -> contendor de todas los texto del documento</param>
        /// <returns>List : lista de celdas que contiene la fila</returns>
        private void GetCells(Row row, SharedStringTable sharedStringTable)
        {
            this.Cells = new List<CellData>();
            var cells = from cell in row.Descendants<Cell>() where cell.CellValue != null select new CellData(cell, sharedStringTable);
            int index = 1;
            foreach (var cell in cells)
            {
                // se compensa la celda en caso este nula
                if (cell.CellIndex != index)
                {
                    while (index < cell.CellIndex)
                    {
                        CellData newCell = new CellData(index, this.RowIndex);
                        this.Cells.Add(newCell);
                        index++;
                    }
                }
                index++;
                this.Cells.Add(cell);
            }
        }

        public T MapperRowToObject<T>(Type obj, Dictionary<int, string> mapper)
        {
            if (mapper == null)
            {
                throw new ArgumentException();
            }
            CellData cell;
            var newObj = Activator.CreateInstance(obj);
            for (int i = 0; i < this.Cells.Count; i++)
            {
                cell = this.Cells[i];

            }
            return (T)newObj;
        }

        public void SetValues(string[] values)
        {
            this.Cells = new List<CellData>();
            CellData cell;
            for (int i = 1; i <= values.Length; i++)
            {
                cell = new CellData(i, this.RowIndex);
                cell.Value = values[i - 1];
                this.Cells.Add(cell);
            }
        }

    }
}

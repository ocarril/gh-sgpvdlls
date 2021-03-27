namespace CROM.Tools.Comun.utils.excel
{
    using System;
    using DocumentFormat.OpenXml.Spreadsheet;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Objeto que representa una celda de Excel
    /// </summary>
    /// <remarks>
    /// Creacion: 	LOG(EMP) 20120607 <br />
    /// </remarks>
    public class CellData
    {

        public string CellName { get; set; }
        public int CellIndex { get; set; }
        public string CellReference { get; set; }
        public string Value { get; set; }
        public string StyleId { get; set; }
        public CellFormula CellFormula { get; set; }
        public string CellsRange { get; set; }

        public CellData()
        {
        }

        public CellData(int index, UInt32 rowIndex, string formulates)
        {
            this.CellIndex = index;
            this.CellName = this.ConvertIndexToColumnName(index);
            this.CellReference = this.CellName + rowIndex;
            this.CellFormula.Text = formulates;
        }

        public CellData(int index, UInt32 rowIndex)
        {
            this.CellIndex = index;
            this.CellName = this.ConvertIndexToColumnName(index);
            this.CellReference = this.CellName + rowIndex;
        }

        public CellData(string cellName, UInt32 rowIndex)
        {
            this.CellIndex = this.ConvertColumnNameToNumber(cellName);
            this.CellName = cellName;
            this.CellReference = this.CellName + rowIndex;
        }

        public CellData(Cell cell, SharedStringTable sharedStringTable)
        {
            this.CellReference = cell.CellReference;
            this.CellName = this.GetColumnName(this.CellReference);
            this.CellIndex = this.ConvertColumnNameToNumber(this.CellName);
            this.Value = this.GetValue(cell, sharedStringTable);
        }

        public bool CellIsNull()
        {
            return this.Value == null || this.Value.Trim().Equals("");
        }

        /// <summary>
        /// obtiene el valor de una celda leida mediante OPEN XML
        /// </summary>
        /// <param name="cell">objeto Cell de OPEN XML -> celda de donde se obtiene le valor</param>
        /// <param name="sharedStringTable">objeto sharedStringTable de OPEN XML -> contendor de todas los texto del documento</param>
        /// <returns>cadena con el valor de la celda</returns>
        private string GetValue(Cell cell, SharedStringTable sharedStringTable)
        {
            if (cell.CellValue != null)
            {
                if (sharedStringTable != null && cell.DataType != null && cell.DataType.HasValue && cell.DataType == CellValues.SharedString)
                    return sharedStringTable.ChildElements[int.Parse(cell.CellValue.InnerText)].InnerText;
                else
                    return cell.CellValue.InnerText;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene el valor no numerico de la referencia de la celda
        /// </summary>
        /// <param name="cellReference">Referencia de la celda (ej. B2)</param>
        /// <returns>Nombre de la Columna (ej. B)</returns>
        private string GetColumnName(string cellReference)
        {
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellReference);

            return match.Value;
        }

        /// <summary>
        /// obtiene el indice de la columma segun el nombre 1..n
        /// </summary>
        /// <param name="columnName">Nombre de la columna (A...Z)</param>
        /// <returns>retorna un intero obtenido</returns>
        /// <exception cref="ArgumentException">retorna una excepcion si
        /// el nombre de la culmna no tiene caracteres validos</exception>
        public int ConvertColumnNameToNumber(string columnName)
        {
            Regex alpha = new Regex("^[A-Z]+$");
            if (!alpha.IsMatch(columnName)) throw new ArgumentException();

            char[] colLetters = columnName.ToCharArray();
            Array.Reverse(colLetters);

            int convertedValue = 0;
            for (int i = 0; i < colLetters.Length; i++)
            {
                char letter = colLetters[i];
                int current = i == 0 ? letter - ((int)ParamsLetter.IndexLetterASCII + 1) : letter - (int)ParamsLetter.IndexLetterASCII;
                convertedValue += current * (int)Math.Pow((int)ParamsLetter.TotalLetters, i);
            }

            return convertedValue + 1;
        }

        /// <summary>
        /// Obtiene el nombre de la columna segun el indice
        /// </summary>
        /// <param name="index">indice de la columa 1 - n</param>
        /// <returns>cadena con el nombre de la columa</returns>
        public string ConvertIndexToColumnName(int index)
        {
            int indexLetterASCII = (int)ParamsLetter.IndexLetterASCII;
            int totalLetters = (int)ParamsLetter.TotalLetters;
            if (index <= (int)ParamsLetter.TotalLetters)
            {
                char letter = (char)(index + indexLetterASCII);
                return letter.ToString();
            }
            else
            {
                int group = index / totalLetters;
                int letter = index % totalLetters;
                if (letter == 0) { letter = totalLetters; group--; }
                char firstLetter = (char)(group + indexLetterASCII);
                char secondLetter = (char)(letter + indexLetterASCII);
                string columnName = firstLetter.ToString() + secondLetter.ToString();
                return columnName;
            }
        }

        private enum ParamsLetter : int
        {
            IndexLetterASCII = 64,
            TotalLetters = 26
        }
        
    }
}

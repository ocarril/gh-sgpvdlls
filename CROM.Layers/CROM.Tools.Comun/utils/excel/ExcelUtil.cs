namespace CROM.Tools.Comun.utils.excel
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Enums = CROM.Tools.Comun.utils.excel.enumerator;

    /// <summary>
    /// Objeto que permite manipular un archivo excel
    /// </summary>
    /// <remarks>
    /// Creacion: 	LOG(EMP) 20120607 <br />
    /// Referencias: <br/>
    /// Introducing the Office (2007) Open XML File Formats: http://msdn.microsoft.com/en-us/library/aa338205.aspx
    /// Parsing and Reading Large Excel Files with the Open XML SDK: http://blogs.msdn.com/b/brian_jones/archive/2010/05/27/parsing-and-reading-large-excel-files-with-the-open-xml-sdk.aspx
    /// Creating Documents by Using the Open XML Format SDK : http://msdn.microsoft.com/en-us/library/dd440953(v=office.12)
    /// Advanced styling in Excel Open XML: http://polymathprogrammer.com/2009/12/21/advanced-styling-in-excel-open-xml/
    /// Leer tablas de un Excel con Open XML y Linq: http://www.returngis.net/2010/12/leer-tablas-de-un-excel-con-open-xml-y-linq/
    /// Crear un documento Excel con Open XML: http://www.returngis.net/2010/04/crear-un-documento-excel-con-open-xml/
    /// </remarks>
    public class ExcelUtil
    {
        public string Filepath { get; set; }
        public Stream FileStream { get; set; }
        public bool IgnoreHeaderRow { get; set; }
        public List<Style> Styles { get; set; }
        public NumberingFormats numberingFormats { get; set; }

        public ExcelUtil(NumberingFormats numberingFormats = null)
        {
            this.numberingFormats = numberingFormats;
        }

        public ExcelUtil(string filePath, NumberingFormats numberingFormats = null)
        {
            this.Filepath = filePath;
            this.numberingFormats = numberingFormats;
        }

        public ExcelUtil(Stream fileStream, NumberingFormats numberingFormats = null)
        {
            this.FileStream = fileStream;
            this.numberingFormats = numberingFormats;
        }

        public ExcelUtil(string filePath, bool ignoreHeaderRow, NumberingFormats numberingFormats = null)
        {
            this.Filepath = filePath;
            this.IgnoreHeaderRow = ignoreHeaderRow;
            this.numberingFormats = numberingFormats;
        }

        public ExcelUtil(Stream fileStream, bool ignoreHeaderRow, NumberingFormats numberingFormats = null)
        {
            this.FileStream = fileStream;
            this.IgnoreHeaderRow = ignoreHeaderRow;
            this.numberingFormats = numberingFormats;
        }

        /// <summary>
        /// verifica si el documento esta abierto
        /// </summary>
        /// <returns>Bool: devuelve true si esta abierto y false si no lo está</returns>
        public bool LockedDocument()
        {
            try
            {
                FileStream = new FileStream(this.Filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        private SpreadsheetDocument OpenDocument()
        {
            return (this.FileStream == null) ? SpreadsheetDocument.Open(this.Filepath, false) : SpreadsheetDocument.Open(this.FileStream, false);
        }
        /// <summary>
        /// obtiene todas las hojas y su contenido de un documento excel
        /// </summary>
        /// <returns>List : lista de hojas que contiene el documento</returns>
        public List<WorkSheet> ReadDocument()
        {
            List<WorkSheet> excelDocument = new List<WorkSheet>();
            using (var document = OpenDocument())
            {
                var workbook = document.WorkbookPart.Workbook;

                if (document.WorkbookPart.SharedStringTablePart != null)
                {
                    var sharedStringTable = document.WorkbookPart.SharedStringTablePart.SharedStringTable;
                    var workSheets = from work in workbook.Descendants<Sheet>() select new WorkSheet() { Id = work.Id, Name = work.Name };

                    int workSheetIndex = 1;
                    foreach (WorkSheet sheet in workSheets)
                    {
                        var worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(sheet.Id);
                        sheet.DefinedNameValues = this.BuildDefinedNamesTable(document.WorkbookPart, sheet.Name);

                        if (!this.IgnoreHeaderRow)
                        {
                            sheet.HeaderRow = (from row in worksheetPart.Worksheet.Descendants<Row>()
                                               where row.RowIndex == 1
                                               select new RowData(row, sharedStringTable)).First(r => r.Cells != null && r.Cells.Count > 0);
                        }

                        sheet.Rows = GetRows(worksheetPart, sharedStringTable).Where(r => r.Cells != null && r.Cells.Count > 0).ToList();
                        sheet.WorkSheetIndex = workSheetIndex++;
                        excelDocument.Add(sheet);

                    }
                }
            }
            this.FileStream.Close();
            return excelDocument;
        }

        List<DefinedNameVal> BuildDefinedNamesTable(WorkbookPart workbookPart, string sheetNameFind)
        {
            //Build a list
            List<DefinedNameVal> definedNameValues = new List<DefinedNameVal>();

            var tableName = workbookPart.Workbook.GetFirstChild<DefinedNames>();

            if (tableName != null)
            {

                foreach (DefinedName name in workbookPart.Workbook.GetFirstChild<DefinedNames>())
                {
                    //Parse defined name string...
                    string key = name.Name;
                    string reference = name.InnerText;

                    string sheetName = reference.Split('!')[0];
                    sheetName = sheetName.Trim('\'');

                    if (sheetName == sheetNameFind && name.Hidden == null)
                    {
                        //Assumption: None of my defined names are relative defined names (i.e. A1)
                        string range = reference.Split('!')[1];
                        string[] rangeArray = range.Split('$');

                        string startCol = rangeArray[1];
                        int startRow = Convert.ToInt32(rangeArray[2].TrimEnd(':'));

                        string endCol = null;
                        int endRow = 999999;

                        if (rangeArray.Length > 3)
                        {
                            endCol = rangeArray[3];
                            endRow = Convert.ToInt32(rangeArray[4]);
                        }

                        definedNameValues.Add(new DefinedNameVal() { Key = key, SheetName = sheetName, StartColumn = startCol, StartRow = startRow, EndColumn = endCol, EndRow = endRow });
                    }

                }
            }

            return definedNameValues;
        }

        /// <summary>
        /// obtiene todas las hojas y su contenido de un documento excel
        /// </summary>
        /// <param name="workSheetName">nombre de la hoja a obtener</param>
        /// <returns>List : lista de filas que contiene la hoja</returns>
        public IEnumerable<RowData> ReadWorkSheet(string workSheetName)
        {
            using (var document = OpenDocument())
            {
                var workbook = document.WorkbookPart.Workbook;
                var sharedStringTable = document.WorkbookPart.SharedStringTablePart.SharedStringTable;
                string workSheetsId = workbook.Descendants<Sheet>().First(s => s.Name == workSheetName).Id;
                var worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(workSheetsId);
                var resultado = GetRows(worksheetPart, sharedStringTable);
                return resultado;
            }
        }

        /// <summary>
        /// obtiene todas las hojas y su contenido de un documento excel
        /// </summary>
        /// <param name="index">indice de la hoja a obtener 1..n</param>
        /// <returns>List : lista de filas que contiene la hoja</returns>
        public IEnumerable<RowData> ReadWorkSheet(int index)
        {
            using (var document = OpenDocument())
            {
                var workBookPart = document.WorkbookPart;
                var workbook = workBookPart.Workbook;
                var sharedStringTablePart = workBookPart.SharedStringTablePart;
                var sharedStringTable = sharedStringTablePart != null ? sharedStringTablePart.SharedStringTable : null;

                string workSheetId = "";
                if (index == 1)
                {
                    workSheetId = workbook.Descendants<Sheet>().First().Id;
                }
                else
                {
                    var workSheets = from work in workbook.Descendants<Sheet>() select new WorkSheet() { Id = work.Id };
                    int getIndex = 1;
                    foreach (var sheet in workSheets)
                    {
                        if (getIndex == index)
                        {
                            workSheetId = sheet.Id;
                            break;
                        }
                        getIndex++;
                    }
                }
                var worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(workSheetId);
                var resultado = GetRows(worksheetPart, sharedStringTable);
                return resultado;
            }
        }

        private IEnumerable<RowData> GetRows(WorksheetPart worksheetPart, SharedStringTable sharedStringTable)
        {
            int rowIni = this.IgnoreHeaderRow ? 2 : 0;
            var resultado = from row in worksheetPart.Worksheet.Descendants<Row>()
                            where row.RowIndex >= rowIni
                            select new RowData(row, sharedStringTable);
            return resultado;
        }

        /// <summary>
        /// Guarda el documento en una ruta fisica
        /// </summary>
        public void SaveNewDocument(List<WorkSheet> workSheets)
        {
            FileStream fs = File.OpenWrite(this.Filepath);
            byte[] ms = this.CreateNewDocument(workSheets);
            fs.Write(ms, 0, ms.Length);
            fs.Close();
        }

        /// <summary>
        /// Guarda el documento en una ruta fisica
        /// </summary>
        /// <param name="workSheet">hoja que incluira el archivo a guardar</param>
        public void SaveNewDocument(WorkSheet workSheet)
        {
            FileStream fs = File.OpenWrite(this.Filepath);
            byte[] ms = this.CreateNewDocument(workSheet);
            fs.Write(ms, 0, ms.Length);
            fs.Close();
        }

        /// <summary>
        /// Guarda el documento en una ruta fisica
        /// </summary>
        /// <param name="memoryStreamAsByte">bytes del contenido del documento</param>
        public void SaveNewDocument(byte[] memoryStreamAsByte)
        {
            FileStream fs = File.OpenWrite(this.Filepath);
            fs.Write(memoryStreamAsByte, 0, memoryStreamAsByte.Length);
            fs.Close();
        }

        /// <summary>
        /// crea un documento nuevo como bytes para ser retornados como
        /// File a la vista
        /// </summary>
        /// <param name="workSheet">hoja que incluira el archivo</param>
        /// <returns>bytes del documento</returns>
        public byte[] CreateNewDocument(WorkSheet workSheet)
        {
            return CreateNewDocument(new List<WorkSheet> { workSheet });
        }

        /// <summary>
        /// crea un documento nuevo como bytes para ser retornados como
        /// File a la vista
        /// </summary>
        /// <param name="workSheets"> Lista de hojas que incluira el archivo</param>
        /// <returns>bytes del documento</returns>
        public byte[] CreateNewDocument(List<WorkSheet> workSheets)
        {
            var memoryStream = new MemoryStream();
            using (var excel = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook, true))
            {
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                WorkbookPart wbp = excel.AddWorkbookPart();
                Workbook wb = new Workbook();

                if (this.Styles != null && this.Styles.Count > 0)
                {
                    WorkbookStylesPart wbsp = wbp.AddNewPart<WorkbookStylesPart>();
                    wbsp.Stylesheet = CreateStylesheet();
                    wbsp.Stylesheet.Save();
                }

                Sheets sheets = new Sheets();

                UInt32 indexSheet = 1;

                foreach (var workSheet in workSheets)
                {
                    MergeCells mergeCells = new MergeCells();
                    workSheet.Id = "rId" + indexSheet;
                    WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>(workSheet.Id);
                    mergeCells = MergeCells(workSheet);
                    wsp.Worksheet = GenerateWorksheetContent(workSheet);
                    wsp.Worksheet.InsertAfter(mergeCells, wsp.Worksheet.Elements<SheetData>().First());
                    wsp.Worksheet.Save();

                    Sheet sheet = new Sheet();
                    sheet.Name = workSheet.Name == null || workSheet.Name.Equals("") ? "Sheet" + indexSheet : workSheet.Name;
                    sheet.SheetId = indexSheet++;
                    sheet.Id = wbp.GetIdOfPart(wsp);

                    sheets.Append(sheet);

                }

                wb.Append(fv);
                wb.Append(sheets);
                excel.WorkbookPart.Workbook = wb;
                excel.WorkbookPart.Workbook.Save();
                //excel.WorkbookPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;
                excel.Close();
            }

            var result = memoryStream.ToArray();
            memoryStream.Close();
            memoryStream.Dispose();

            return result;
        }

        public byte[] CreateNewDocument(string pathInputFile, List<WorkSheet> listWorkSheet)
        {
            MemoryStream memoryStream = new MemoryStream();

            FileStream fileStream = new FileStream(pathInputFile, FileMode.Open);

            fileStream.CopyTo(memoryStream, 4096);
            fileStream.Close();
            fileStream.Dispose();

            //Open up the copied template workbook
            using (SpreadsheetDocument excel = SpreadsheetDocument.Open(memoryStream, true))
            {
                //Access the main Workbook part, which contains all references
                WorkbookPart workbookPart = excel.WorkbookPart;

                foreach (var workSheet in listWorkSheet)
                {
                    string workSheetId = workbookPart.Workbook.Descendants<Sheet>().First().Id;

                    //Grab the first worksheet
                    WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(workSheetId);

                    //SheetData will contain all the data 
                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                    foreach (var row in workSheet.Rows)
                    {
                        sheetData.AppendChild(CreateBody(row));
                    }

                    worksheetPart.Worksheet.Save();
                }

                //excel.WorkbookPart.Workbook.CalculationProperties.ForceFullCalculation = true;
                excel.WorkbookPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;

                //ThisWorkbook.PivotCaches(yourIndex).Refresh

                excel.Close();
            }

            var result = memoryStream.ToArray();
            memoryStream.Close();
            memoryStream.Dispose();

            return result;

        }

        /// <summary>
        /// crea un documento nuevo en bytes para ser retornados como
        /// File a la vista
        /// </summary>
        /// <param name="listObject"> Lista de objetos que se incluiran como registros al excel</param>
        /// <param name="mapper"> mapeo de columnas con atributos</param>
        /// <returns>bytes del documento</returns>
        public byte[] CreateNewDocument<T>(List<T> listObject, Dictionary<int, string> mapper)
        {
            WorkSheet workSheet = new WorkSheet();
            workSheet.MapperListToRows<T>(listObject, mapper);
            return this.CreateNewDocument(workSheet);
        }

        /// <summary>
        /// crea un documento nuevo en bytes para ser retornados como
        /// File a la vista
        /// </summary>
        /// <param name="listObject"> Lista de objetos que se incluiran como registros al excel</param>
        /// <param name="mapper"> mapeo de columnas con atributos</param>
        /// <param name="header"> Cabecera del detalle</param>
        /// <returns>bytes del documento</returns>
        public byte[] CreateNewDocument<T>(List<T> listObject, Dictionary<int, string> mapper, RowData header)
        {
            WorkSheet workSheet = new WorkSheet();
            workSheet.HeaderRow = header;
            workSheet.MapperListToRows<T>(listObject, mapper);
            return this.CreateNewDocument(workSheet);
        }

        /// <summary>
        /// crea un documento nuevo en bytes para ser retornados como
        /// File a la vista
        /// </summary>
        /// <param name="listObject"> Lista de objetos que se incluiran como registros al excel</param>
        /// <param name="mapper"> mapeo de columnas con atributos</param>
        /// <param name="header"> Cabecera del detalle</param>
        /// <param name="agrupador"> Propiedad que indicará si una columna es agrupada</param>
        /// <returns>bytes del documento</returns>
        public byte[] CreateNewDocument<T>(List<T> listObject, Dictionary<int, string> mapper, RowData header, String agrupador)
        {
            WorkSheet workSheet = new WorkSheet();
            workSheet.HeaderRow = header;
            workSheet.MapperListToRows<T>(listObject, mapper, agrupador);
            return this.CreateNewDocument(workSheet);
        }

        #region PruebaExcel
        public List<RowData> CreateExcelGrid(GridExcel grid, int columnPosition, uint rowPosition, string headerStyle)
        {
            List<RowData> excelRows = new List<RowData>();
            uint count = 0;
            List<RowData> headerRow = new List<RowData>();

            headerRow = CreateExcelGridHeader(grid, columnPosition, rowPosition, headerStyle);//CreateHeaderGrid(rowPosition, columnPosition, grid, headerStyle);
            excelRows.AddRange(headerRow);
            rowPosition = rowPosition + (uint)grid.NivelesCabecera;

            foreach (var fila in grid.Datos)
            {
                RowData assistantRow = new RowData();
                assistantRow = CreateRowGrid(rowPosition, columnPosition, count, fila);
                excelRows.Add(assistantRow);
                count = count + 1;

                if (fila.GridAnidado != null)
                {
                    List<RowData> nestedExcelRows = new List<RowData>();
                    nestedExcelRows = CreateNestedGrid(rowPosition, columnPosition, count, fila, headerStyle);
                    excelRows.AddRange(nestedExcelRows);
                    count = count + (uint)nestedExcelRows.Count;
                }
            }

            return excelRows;
        }

        private List<RowData> CreateNestedGrid(uint rowPosition, int columnPosition, uint count, FilaExcel row, string headerStyle)
        {
            List<RowData> gridRows = new List<RowData>();
            List<RowData> nestedExcelRows = new List<RowData>();

            nestedExcelRows.Add(EmptyRow(rowPosition + count, row.GridAnidado.NivelAgrupacionCabecera));
            count = count + 1;
            gridRows = CreateExcelGrid(row.GridAnidado, columnPosition + 1, rowPosition + count, headerStyle);
            nestedExcelRows.AddRange(gridRows);
            count = count + (uint)gridRows.Count;
            nestedExcelRows.Add(EmptyRow(rowPosition + count, row.GridAnidado.NivelAgrupacionCabecera));

            return nestedExcelRows;
        }

        /// <summary>
        /// crea la fila de un grid excel
        /// </summary>
        /// <param name="rowPosition">posicion de la fila</param>
        /// <param name="columnPosition">posicion de la columna</param>
        /// <param name="count">contador para las filas del grid</param>
        /// <param name="row">fila del grid excel</param>
        /// <returns>retorna la fila excel de un grid</returns>
        private RowData CreateRowGrid(uint rowPosition, int columnPosition, uint count, FilaExcel row)
        {
            RowData gridRow = new RowData();
            gridRow.RowIndex = rowPosition + count;
            gridRow.Cells = CreateCellsRow(row, columnPosition, gridRow.RowIndex);
            gridRow.OutlineLevel = row.NivelAgrupacion;

            return gridRow;
        }

        /// <summary>
        /// crea una fila vacia
        /// </summary>
        /// <param name="rowIndex"> numero de fila</param>
        /// <param name="level">nivel de agrupacion</param>
        /// <returns>retorna una fila vacia</returns>
        public RowData EmptyRow(uint rowIndex, byte level)
        {
            RowData row = new RowData();
            CellData cell;
            List<CellData> cellsList = new List<CellData>();

            row.RowIndex = rowIndex;
            cell = CreateCell("", 1, rowIndex, "", "");
            cellsList.Add(cell);
            row.Cells = cellsList;
            row.OutlineLevel = level;

            return row;
        }

        /// <summary>
        /// crea cabecera excel para el grid
        /// </summary>
        /// <param name="header"> lista de cabeceras</param>
        /// <param name="columnPosition"> posicion de columna</param>
        /// <param name="rowPosition">posicion de fila</param>
        /// <param name="headerStyle">estilo de cabecera</param>
        /// <returns>retorna cabecera excel para el grid</returns>
        private List<RowData> CreateExcelGridHeader(GridExcel grid, int columnPosition, uint rowPosition, string headerStyle)
        {
            List<RowData> rows = new List<RowData>();
            List<CellData> cells = new List<CellData>();
            uint rowIndex = 0;

            for (int i = 0; i < grid.NivelesCabecera; i++)
            {
                RowData row = new RowData();
                cells = new List<CellData>();

                foreach (var head in grid.Cabeceras)
                {
                    if (i == head.PosicionFila)
                    {
                        CellData cell;
                        rowIndex = rowPosition + (uint)head.PosicionFila;

                        if (head.CantidadCeldas != 0)
                        {
                            int horizontalEndPosition = columnPosition + head.PosicionColumna + head.CantidadCeldas;
                            cell = CreateCell(head.Texto, columnPosition + head.PosicionColumna, rowPosition + (uint)head.PosicionFila, horizontalEndPosition, (int)Enums.ParametrosDireccionMergeExcel.DireccionHorizontal, headerStyle);
                        }
                        else
                        {
                            int verticalEndPosition = (int)rowPosition + (grid.NivelesCabecera - 1);
                            cell = CreateCell(head.Texto, columnPosition + head.PosicionColumna, rowPosition + (uint)head.PosicionFila, verticalEndPosition, (int)Enums.ParametrosDireccionMergeExcel.DireccionVertical, headerStyle);
                        }
                        cells.Add(cell);
                    }
                }

                cells = cells.OrderBy(x => x.CellIndex).ToList();

                row.RowIndex = rowIndex;
                row.Cells = cells;
                row.OutlineLevel = grid.NivelAgrupacionCabecera;
                row.DefaultStyleId = headerStyle;

                rows.Add(row);
            }



            return rows;
        }

        /// <summary>
        /// crear fila excel
        /// </summary>
        /// <param name="listaCeldas">lista de celdas</param>
        /// <param name="rowPosition">posicion de fila</param>
        /// <param name="style">estilo para la fila</param>
        /// <returns>retorna una fila excel</returns>
        public RowData CreateRow(List<CellData> cellsList, uint rowPosition, string style)
        {
            RowData assistantRow = new RowData();
            assistantRow.RowIndex = rowPosition;
            assistantRow.Cells = cellsList;
            assistantRow.DefaultStyleId = style;

            return assistantRow;
        }

        /// <summary>
        /// crear fila excel
        /// </summary>
        /// <param name="cellsList">lista de celdas</param>
        /// <param name="rowPosition">posicioon de fila</param>
        /// <returns>retorna una fila excel</returns>
        public RowData CreateRow(List<CellData> cellsList, uint rowPosition)
        {
            RowData assistantRow = new RowData();
            assistantRow.RowIndex = rowPosition;
            assistantRow.Cells = cellsList;

            return assistantRow;
        }

        private List<CellData> CreateCellsRow(FilaExcel row, int columnPosition, uint rowPosition)
        {
            List<CellData> rowCells = new List<CellData>();
            int count = 0;

            foreach (var value in row.Fila)
            {
                CellData cell;
                cell = CreateCell(value != null ? value.Value : "", columnPosition + count, rowPosition, value != null ? value.Style : "");
                count = count + 1;
                rowCells.Add(cell);
            }

            return rowCells;
        }

        /// <summary>
        /// crea celda excel
        /// </summary>
        /// <param name="value">valor de la celda</param>
        /// <param name="columnPosition">posicion columna</param>
        /// <param name="rowPosition">posicion fila</param>
        /// <param name="rangoCeldas">rango de celdas a unir</param>
        /// <param name="style">estilo de la celda</param>
        /// <returns>retorna celda excel</returns>
        public CellData CreateCell(dynamic value, int columnPosition, uint rowPosition, string cellsRange, string style)
        {
            CellData cell;
            cell = new CellData(columnPosition, rowPosition) { Value = value != null ? value.ToString() : null };
            cell.StyleId = style;
            cell.CellsRange = cellsRange;

            return cell;
        }

        public CellData CreateCell(dynamic value, int columnPosition, uint rowPosition, int finalPositionMergeCell, int direction, string style)
        {
            CellData cell;
            string mergeCellName;
            string cellsRange;
            int finalPosition;

            cell = new CellData(columnPosition, rowPosition) { Value = value != null ? value.ToString() : null };
            cell.StyleId = style;

            if ((int)Enums.ParametrosDireccionMergeExcel.DireccionHorizontal == direction)
            {
                finalPosition = (int)rowPosition;
                mergeCellName = cell.ConvertIndexToColumnName(finalPositionMergeCell);
            }
            else
            {
                mergeCellName = cell.CellName;
                finalPosition = finalPositionMergeCell;
            }

            cellsRange = cell.CellReference + ":" + mergeCellName + finalPosition;
            cell.CellsRange = cellsRange;

            return cell;
        }

        public CellData CreateCell(dynamic value, int columnPosition, uint rowPosition, string cellsRange, string style, string formulates)
        {
            CellData cell;
            cell = new CellData(columnPosition, rowPosition) { Value = value != null ? value.ToString() : null };
            cell.StyleId = style;
            cell.CellsRange = cellsRange;
            cell.CellFormula = new CellFormula();
            cell.CellFormula.Text = formulates;

            return cell;
        }

        /// <summary>
        /// crear celda excel
        /// </summary>
        /// <param name="value">valor de la celda</param>
        /// <param name="posicionColumna">posicion columna</param>
        /// <param name="posicionFila">posicion de fila</param>
        /// <returns>retorna celda excel</returns>
        public CellData CreateCell(dynamic value, int columnPosition, uint rowPosition)
        {
            CellData cell;
            cell = new CellData(columnPosition, rowPosition) { Value = value != null ? value.ToString() : null };
            cell.CellsRange = "";

            return cell;
        }

        /// <summary>
        /// crear celda excel
        /// </summary>
        /// <param name="value">valor de la celda</param>
        /// <param name="columnPosition">posicion columna</param>
        /// <param name="rowPosition">posicion fila</param>
        /// <param name="estilo">estilo de celda</param>
        /// <returns>retorna celda excel</returns>
        public CellData CreateCell(dynamic value, int columnPosition, uint rowPosition, string estilo)
        {
            CellData cell;
            cell = new CellData(columnPosition, rowPosition) { Value = value != null ? value.ToString() : null };
            cell.StyleId = estilo;
            cell.CellsRange = "";

            return cell;
        }

        /// <summary>
        /// crear celda excel
        /// </summary>
        /// <param name="value">valor de la celda</param>
        /// <param name="cellName">nombre de la columna</param>
        /// <param name="rowPosition">posicion de la fila</param>
        /// <param name="rangoCeldas">rango de las celdas a unir</param>
        /// <param name="style">estilo de la celda</param>
        /// <returns>retorna celda excel</returns>
        public CellData CreateCell(dynamic value, string cellName, uint rowPosition, string cellsRange, string style)
        {
            CellData cell;
            cell = new CellData(cellName, rowPosition) { Value = value != null ? value.ToString() : null };
            cell.StyleId = style;
            cell.CellsRange = cellsRange;

            return cell;
        }

        /// <summary>
        /// crear celda excel
        /// </summary>
        /// <param name="value">valor de la celda</param>
        /// <param name="cellName">nombre de la columna</param>
        /// <param name="rowPosition">posicion de la fila</param>
        /// <returns>retornar celda excel</returns>
        public CellData CreateCell(dynamic value, string cellName, uint rowPosition)
        {
            CellData cell;
            cell = new CellData(cellName, rowPosition) { Value = value != null ? value.ToString() : null };
            cell.CellsRange = "";

            return cell;
        }

        /// <summary>
        /// crear celda excel
        /// </summary>
        /// <param name="value">valor de la celda</param>
        /// <param name="cellName">nombre de la columna</param>
        /// <param name="rowPosition">posicion de la fila</param>
        /// <param name="style">estilo de celda</param>
        /// <returns>retorna celda excel</returns>
        public CellData CreateCell(dynamic value, string cellName, uint rowPosition, string style)
        {
            CellData cell;
            cell = new CellData(cellName, rowPosition) { Value = value != null ? value.ToString() : null };
            cell.StyleId = style;
            cell.CellsRange = "";

            return cell;
        }

        private MergeCells MergeCells(WorkSheet workSheet)
        {
            MergeCells mergeCells;
            mergeCells = new MergeCells();

            if (CheckUnionOfCells(workSheet))
            {
                if (workSheet.Rows != null)
                {
                    foreach (var row in workSheet.Rows)
                    {
                        foreach (var celda in row.Cells)
                        {
                            if (celda.CellsRange != "")
                            {
                                MergeCell mergeCell = new MergeCell() { Reference = new StringValue(celda.CellsRange) };
                                mergeCells.Append(mergeCell);
                            }
                        }
                    }
                }
            }

            return mergeCells;
        }

        private bool CheckUnionOfCells(WorkSheet workSheet)
        {
            bool option = false;

            if (workSheet.Rows != null)
            {
                foreach (var row in workSheet.Rows)
                {
                    option = SearchUnitedCells(row.Cells);

                    if (option)
                    {
                        break;
                    }
                }
            }

            return option;
        }

        private bool SearchUnitedCells(List<CellData> cells)
        {
            bool option = false;

            foreach (var cell in cells)
            {
                if (cell.CellsRange != "")
                {
                    option = true;
                    break;
                }
            }

            return option;
        }

        public List<WorkSheet> GetDataTemplate(string filePath)
        {
            List<WorkSheet> listTemplate;

            ExcelUtil templateExcel = new ExcelUtil(filePath, true);

            listTemplate = templateExcel.ReadDocument();
            listTemplate = CleanExcel(listTemplate);

            return listTemplate;
        }

        private List<WorkSheet> CleanExcel(List<WorkSheet> WorsheetList)
        {
            foreach (var excelSheet in WorsheetList)
            {
                foreach (var row in excelSheet.Rows)
                {
                    foreach (var cell in row.Cells)
                    {
                        cell.CellsRange = "";
                    }
                }
            }

            return WorsheetList;
        }

        public List<WorkSheet> SortRowsExcel(List<WorkSheet> WorsheetList)
        {
            foreach (var excelSheet in WorsheetList)
            {
                excelSheet.Rows = excelSheet.Rows.OrderBy(x => x.RowIndex).ToList();
            }

            return WorsheetList;
        }
        #endregion

        /// <summary>
        /// implemente el contenido del nuevo documento Excel
        /// </summary>
        /// <param name="workSheet"> hoja de la que se leera el contenido</param>
        /// <returns>Retorna una hoja OPEN XML</returns>
        private Worksheet GenerateWorksheetContent(WorkSheet workSheet)
        {
            Worksheet worksheet = new Worksheet();
            SheetData sheetData = new SheetData();

            UInt32 rowIndex = 1;
            if (workSheet.Title != null && !workSheet.Title.Equals(""))
            {
                sheetData.Append(CreateTitle(workSheet.Title));
                rowIndex++;
            }
            if (workSheet.HeaderRow != null)
            {
                sheetData.Append(CreateHeader(workSheet.HeaderRow, rowIndex));
            }

            if (workSheet.Rows != null)
            {
                foreach (var row in workSheet.Rows)
                {
                    sheetData.Append(CreateBody(row));
                }
            }

            if (workSheet.Columns != null && workSheet.Columns.Count() > 0)
            {
                worksheet.Append(workSheet.Columns);
            }

            worksheet.Append(sheetData);

            return worksheet;
        }

        private Row CreateTitle(string title)
        {
            var titleRow = new Row { RowIndex = 1 };
            Cell newCell = new Cell { CellReference = "A1", CellValue = new CellValue(title), DataType = CellValues.String };
            titleRow.Append(newCell);
            return titleRow;
        }

        private Row CreateHeader(RowData headerRow, UInt32 rowIndex)
        {
            var newRow = new Row { RowIndex = rowIndex };
            foreach (var cell in headerRow.Cells)
            {
                float numValue;
                Cell newCell = new Cell { CellReference = cell.CellReference, CellValue = new CellValue(cell.Value), DataType = float.TryParse(cell.Value, out numValue) ? CellValues.Number : CellValues.String };
                if (this.Styles != null && this.Styles.Count > 0)
                {
                    var styleId = this.Styles.FirstOrDefault(s => s.Id.Equals(cell.StyleId == null ? headerRow.DefaultStyleId : cell.StyleId));
                    if (styleId != null)
                    {
                        newCell.StyleIndex = (uint)styleId.StyleIndex;
                    }
                }
                newRow.Append(newCell);
            }
            return newRow;
        }

        private Row CreateBody(RowData rowData)
        {
            var newRow = new Row { RowIndex = rowData.RowIndex, OutlineLevel = rowData.OutlineLevel };

            foreach (var cell in rowData.Cells)
            {
                float numValue;
                Cell newCell = new Cell { CellFormula = cell.CellFormula, CellReference = cell.CellReference, CellValue = new CellValue(cell.Value), DataType = float.TryParse(cell.Value, out numValue) ? CellValues.Number : CellValues.String };
                if (this.Styles != null && this.Styles.Count > 0)
                {
                    var styleId = this.Styles.FirstOrDefault(s => s.Id.Equals(cell.StyleId ?? rowData.DefaultStyleId));
                    if (styleId != null)
                    {
                        newCell.StyleIndex = (uint)styleId.StyleIndex;
                    }
                }
                newRow.Append(newCell);
            }

            return newRow;
        }

        /// <summary>
        /// crea la lista de estilos que manejara el excel
        /// </summary>
        /// <returns>Stylesheet</returns>
        private Stylesheet CreateStylesheet()
        {
            Stylesheet styleSheet = new Stylesheet();

            Borders borders = CreateBorder();
            CellStyleFormats cellStyleFormat = CreateCellStyleFormats();
            CellStyles cellStyles = CellStyles();

            Fonts fonts = new Fonts();
            Fills fills = new Fills();
            CellFormats cellFormats = new CellFormats();

            GetFont(ref fonts, "Arial", 11, false, "000000");
            GetFill(ref fills, "");
            PatternFill patternFill = new PatternFill { PatternType = PatternValues.Gray125 };
            Fill fill = new Fill { PatternFill = patternFill };
            fills.Append(fill);

            cellFormats.Append(CreateCellFormat());

            int styleIndex = 1;
            foreach (Style style in this.Styles)
            {
                CellFormat cellformat = CreateCellFormat(style, ref fonts, ref fills);

                Alignment alignment = null;
                if (style.HorizontalAlignment != 0)
                {
                    switch ((int)style.HorizontalAlignment)
                    {
                        case 1: alignment = new Alignment { Horizontal = HorizontalAlignmentValues.Left, WrapText = style.WrapText };
                            break;
                        case 2: alignment = new Alignment { Horizontal = HorizontalAlignmentValues.Center, WrapText = style.WrapText };
                            break;
                        case 3: alignment = new Alignment { Horizontal = HorizontalAlignmentValues.Right, WrapText = style.WrapText };
                            break;
                    }
                    cellformat.AppendChild(alignment);
                }
                cellFormats.Append(cellformat);

                style.StyleIndex = styleIndex++;
                style.FontId = cellformat.FontId;
                style.FillId = cellformat.FillId;
            }

            fills.Count = UInt32Value.FromUInt32((uint)fills.ChildElements.Count);
            fonts.Count = UInt32Value.FromUInt32((uint)fonts.ChildElements.Count);
            cellFormats.Count = UInt32Value.FromUInt32((uint)cellFormats.ChildElements.Count);

            styleSheet.Append(fonts);
            styleSheet.Append(fills);
            styleSheet.Append(borders);
            styleSheet.NumberingFormats = numberingFormats;
            styleSheet.Append(cellStyleFormat);
            styleSheet.Append(cellFormats);
            styleSheet.Append(cellStyles);
            styleSheet.Append(new DifferentialFormats { Count = 0 });
            styleSheet.Append(new TableStyles
            {
                Count = 0,
                DefaultTableStyle = StringValue.FromString("TableStyleMedium9"),
                DefaultPivotStyle = StringValue.FromString("PivotStyleLight16")
            });

            return styleSheet;
        }

        /// <summary>
        /// get font id exist else create new
        /// </summary>
        /// <returns>Font Id</returns>
        private uint GetFont(ref Fonts fonts, string name, int size, bool bold, string color)
        {
            var fontStyle = this.Styles.FirstOrDefault(s => s.FontName != null && s.FontName.Equals(name) &&
                                                          s.FontSize == size &&
                                                          s.Color != null && s.Color.Equals(color) &&
                                                          s.FontBold == bold);
            uint fontId;
            if (fontStyle == null || fontStyle.FontId == 0)
            {
                Font font = new Font();
                FontName fontName = new FontName { Val = StringValue.FromString(name == null || name.Equals("") ? "arial" : name) };
                FontSize fontSize = new FontSize { Val = DoubleValue.FromDouble(size == 0 ? 11 : size) };
                Bold fontBold = new Bold { Val = bold };
                Color fontColor = new Color
                {
                    Rgb =
                        HexBinaryValue.FromString(color == null || color.Equals("")
                                                      ? "000000"
                                                      : color)
                };
                font.Bold = fontBold;
                font.Color = fontColor;
                font.FontName = fontName;
                font.FontSize = fontSize;
                fonts.Append(font);
                fontId = (uint)fonts.ChildElements.Count - 1;
            }
            else
            {
                fontId = fontStyle.FontId;
            }
            return fontId;
        }

        /// <summary>
        /// get fill id exist else create new
        /// </summary>
        /// <returns>Font Id</returns>
        private uint GetFill(ref Fills fills, string color)
        {
            var fillStyle = this.Styles.FirstOrDefault(s => s.BackGroundColor.Equals(color));
            if (fillStyle == null || fillStyle.FillId == 0)
            {
                Fill fill = new Fill();
                PatternFill patternFill = new PatternFill();
                if (color == null || color.Equals("") || color.Equals("none"))
                {
                    patternFill.PatternType = PatternValues.None;
                }
                else
                {
                    patternFill.PatternType = PatternValues.Solid;
                    patternFill.ForegroundColor = new ForegroundColor();
                    patternFill.ForegroundColor.Rgb = HexBinaryValue.FromString(color);
                    patternFill.BackgroundColor = new BackgroundColor();
                    patternFill.BackgroundColor.Rgb = patternFill.ForegroundColor.Rgb;
                }
                fill.PatternFill = patternFill;
                fills.Append(fill);
                return (uint)fills.ChildElements.Count - 1;
            }
            return fillStyle.FillId;
        }

        private Borders CreateBorder()
        {
            Borders borders = new Borders();

            Border border = new Border();
            border.LeftBorder = new LeftBorder();
            border.RightBorder = new RightBorder();
            border.TopBorder = new TopBorder();
            border.BottomBorder = new BottomBorder();
            border.DiagonalBorder = new DiagonalBorder();
            borders.Append(border);

            border = new Border();
            border.LeftBorder = new LeftBorder();//new Color() { Auto = true });
            border.LeftBorder.Style = BorderStyleValues.Thin;
            border.RightBorder = new RightBorder();//new Color() { Auto = true });
            border.RightBorder.Style = BorderStyleValues.Thin;
            border.TopBorder = new TopBorder();//new Color() { Auto = true });
            border.TopBorder.Style = BorderStyleValues.Thin;
            border.BottomBorder = new BottomBorder();//new Color() { Auto = true });
            border.BottomBorder.Style = BorderStyleValues.Thin;
            border.DiagonalBorder = new DiagonalBorder();
            borders.Append(border);
            borders.Count = UInt32Value.FromUInt32((uint)borders.ChildElements.Count);
            return borders;
        }

        private CellStyleFormats CreateCellStyleFormats()
        {
            CellStyleFormats cellStyleFormat = new CellStyleFormats();
            cellStyleFormat.Append(CreateCellFormat());
            cellStyleFormat.Count = UInt32Value.FromUInt32((uint)cellStyleFormat.ChildElements.Count);
            return cellStyleFormat;
        }

        private CellStyles CellStyles()
        {
            CellStyles cellStyles = new CellStyles();
            cellStyles.Append(new CellStyle { Name = StringValue.FromString("Normal"), FormatId = 0, BuiltinId = 0 });
            cellStyles.Count = UInt32Value.FromUInt32((uint)cellStyles.ChildElements.Count);
            return cellStyles;
        }

        private CellFormat CreateCellFormat()
        {
            var cellformat = new CellFormat { NumberFormatId = 0, FormatId = 0, BorderId = 0, FontId = 0, FillId = 0 };
            return cellformat;
        }

        private CellFormat CreateCellFormat(Style style, ref Fonts fonts, ref Fills fills)
        {
            var cellformat = new CellFormat
            {
                NumberFormatId = 0,
                FormatId = 0,
                ApplyNumberFormat = BooleanValue.FromBoolean(true),
                BorderId = (uint)(style.Border ? 1 : 0),
                FontId = GetFont(ref fonts, style.FontName, style.FontSize, style.FontBold, style.Color),
                FillId = GetFill(ref fills, style.BackGroundColor),

            };

            if (style.NumericFormat != null)
            {
                cellformat.NumberFormatId = style.NumericFormat;
                cellformat.ApplyNumberFormat = BooleanValue.FromBoolean(true);
            }

            //cellformat.BorderId = 1;
            //cellformat.ApplyBorder = true;

            return cellformat;
        }

        public Column CreateColumnData(UInt32 startColumnIndex, UInt32 endColumnIndex, BooleanValue bestFit, double columnWidth = 8)
        {
            Column column;
            column = new Column();
            column.Min = startColumnIndex;
            column.Max = endColumnIndex;
            column.Width = columnWidth;
            column.CustomWidth = true;
            column.BestFit = bestFit;
            return column;
        }

        public Columns ObtenerAnchoCeldas(List<RowData> filasExcel, int posicionFilaInicial, int posicionLeerFilaAncho)
        {
            ExcelUtil documento = new ExcelUtil();
            Columns columns = new Columns();
            CellData celda = new CellData();
            uint indiceColumna;
            double anchoColumna;

            for (int i = 0; i < filasExcel[posicionFilaInicial].Cells.Count; i++)
            {
                celda = filasExcel[posicionFilaInicial].Cells[i];
                indiceColumna = (uint)celda.ConvertColumnNameToNumber(celda.CellName);
                anchoColumna = ObtenerCeldaMayorAnchoPorColumna(filasExcel, celda.CellName, posicionLeerFilaAncho);
                if (anchoColumna != 0)
                {
                    columns.Append(documento.CreateColumnData(indiceColumna, indiceColumna, false, anchoColumna + 4));
                }
                else
                {
                    columns.Append(documento.CreateColumnData(indiceColumna, indiceColumna, false, anchoColumna + 2));
                }
            }

            return columns;
        }

        private double ObtenerCeldaMayorAnchoPorColumna(List<RowData> filasExcel, string nombreCelda, int posicionFila)
        {
            int maximo = 0;
            int longitudValor = 1;

            for (int i = posicionFila; i < filasExcel.Count; i++)
            {
                foreach (var celda in filasExcel[i].Cells)
                {
                    if (nombreCelda == celda.CellName)
                    {
                        if (ValidarCeldaAEvaluar(celda))
                        {
                            if (celda.Value != null) { longitudValor = Convert.ToString(celda.Value).Length; }

                            if (longitudValor > maximo)
                            {
                                maximo = longitudValor;
                            }
                        }
                    }
                }
            }

            return maximo;
        }

        private bool ValidarCeldaAEvaluar(CellData celda)
        {
            string nombreCeldaInicio = celda.CellName;
            string finRango = "";
            string nombreCeldaFinal = "";
            bool opcion = true;

            if (celda.CellsRange != "")
            {
                finRango = celda.CellsRange.Split(':')[1];

                foreach (var caracter in finRango)
                {
                    if (!char.IsDigit(caracter))
                    {
                        nombreCeldaFinal = nombreCeldaFinal + caracter;
                    }
                }

                if (nombreCeldaInicio != nombreCeldaFinal)
                {
                    opcion = false;
                }

            }

            return opcion;
        }

        #region Funciones y Formatos Excel
        public string IfError(dynamic value, dynamic errorValue)
        {
            return "= IfError(" + value + "," + errorValue + ")";
        }
        #endregion


    }
}

namespace CROM.ComercialAlmacen.Interfaces
{
    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.Comercial.DTO;
    using CROM.GestionComercial.BusinessLogic;
    using CROM.Tools.Comun.utils.excel;
    using CROM.Tools.Comun.utils.excel.enumerator;

    using DocumentFormat.OpenXml.Spreadsheet;
    using System;
    using System.Collections.Generic;
    
    public class ReporteExcelGCLogic
    {
        private List<string> coloresFondo = new List<string>();

        #region CREA LOS REPORTES DEL SISTEMA CON EXPORTACION A EXCEL

        public byte[] GenerarReporteDeInventarioActual(BaseFiltroInventarioActual pFiltro, int posicionColumna, uint posicionFila, Dictionary<int, string> titulosReporte, Dictionary<int, string> titulosCelda)
        {
            NumberFormat formatosNumerico = new NumberFormat();
            ExcelUtil documento = new ExcelUtil(formatosNumerico.numberingFormats);
            List<RowData> filasExcel = new List<RowData>();
            List<CellData> celdasExcel = new List<CellData>();
            List<CellData> celdasExcelFecha = new List<CellData>();
            WorkSheet workSheet = new WorkSheet();
            byte[] ficheroExcel;
            string tituloReporte;

            ConsultasGCLogic consultaLogic = new ConsultasGCLogic();
            List<vwProductoInventario> lstProductoInventario = new List<vwProductoInventario>();
            lstProductoInventario = consultaLogic.ListProductoReporteDeInventarioActual(pFiltro);

            documento.Styles = ObtenerEstilosReporte();
            documento.Styles.AddRange(GenerarEstilosDeFondo(lstProductoInventario));

            CellData celdaTitulo;
            tituloReporte = "Reporte de Inventario actual de Productos";
            celdaTitulo = documento.CreateCell(tituloReporte, posicionColumna, posicionFila, 8, (int)ParametrosDireccionMergeExcel.DireccionHorizontal, Convert.ToString(EstilosReporteGC.TituloReporte));
            celdasExcel.Add(celdaTitulo);
            filasExcel.Add(documento.CreateRow(celdasExcel, posicionFila));

            posicionFila = posicionFila + 1;
            CellData celdaFecha;
            celdaFecha = documento.CreateCell(titulosCelda[2], posicionColumna, posicionFila, 8, (int)ParametrosDireccionMergeExcel.DireccionHorizontal, Convert.ToString(EstilosReporteGC.FondoBase));
            celdasExcelFecha.Add(celdaFecha);
            filasExcel.Add(documento.CreateRow(celdasExcelFecha, posicionFila));

            posicionFila = posicionFila + 1;
            CellData celdaDatoINV;
            celdaDatoINV = documento.CreateCell("Inventario INIcial", posicionColumna, posicionFila, 8, (int)ParametrosDireccionMergeExcel.DireccionHorizontal, Convert.ToString(EstilosReporteGC.TituloReporte));
            celdasExcelFecha.Add(celdaDatoINV);
            filasExcel.Add(documento.CreateRow(celdasExcelFecha, posicionFila));

            posicionFila = posicionFila + 1;
            filasExcel.AddRange(CrearCabeceraInventarioActual(lstProductoInventario, posicionColumna, posicionFila, Convert.ToString(EstilosReporteGC.CabeceraCuadro), titulosReporte));

            posicionFila = posicionFila + 1;
            filasExcel.AddRange(CrearDatosReporteInventario(lstProductoInventario, posicionColumna, posicionFila, titulosCelda));

            posicionFila = posicionFila + 1;

            workSheet.Rows = filasExcel;
            workSheet.Columns = ObtenerAnchoCeldas(filasExcel, 1, 7);

            ficheroExcel = documento.CreateNewDocument(workSheet);

            return ficheroExcel;
        }

        private List<RowData> CrearDatosReporteInventario(List<vwProductoInventario> lstProductoInventario, int posicionColumna, uint posicionFila, Dictionary<int, string> titulosCelda)
        {
            ExcelUtil documento = new ExcelUtil();
            List<RowData> filasExcel = new List<RowData>();
            List<RowData> filasExcelDemanda = new List<RowData>();
            List<RowData> filasExcelVsDemandaProfit = new List<RowData>();
            int contador = 1;
            foreach (var inventario in lstProductoInventario)
            {
                filasExcel.AddRange(CrearFilaExcelPaginaInventario(inventario, posicionColumna, posicionFila, contador));
                ++posicionFila;
                ++contador;
            }

            return filasExcel;
        }
        private double ObtenerCeldaMayorAnchoPorColumna(List<RowData> filasExcel, string nombreCelda, int posicionFila)
        {
            int maximo = 0;

            for (int i = posicionFila; i < filasExcel.Count; i++)
            {
                foreach (var celda in filasExcel[i].Cells)
                {
                    if (nombreCelda == celda.CellName)
                    {
                        if (celda.Value != null)
                            if (Convert.ToString(celda.Value).Length > maximo)
                            {
                                maximo = Convert.ToString(celda.Value).Length;
                            }
                    }
                }
            }

            return maximo;
        }

        private List<RowData> CrearFilaExcelPaginaInventario(vwProductoInventario filaGridInvetario, int posicionColumna, uint posicionFila, int contador)
        {
            ExcelUtil documento = new ExcelUtil();
            List<CellData> celdasExcel = new List<CellData>();
            List<RowData> filasExcel = new List<RowData>();
            CellData celda;

            string fondoEstiloPagina = Convert.ToString(EstilosReporteGC.FondoDefecto);

            //posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(contador.ToString("N2"), posicionColumna, posicionFila, fondoEstiloPagina);
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(filaGridInvetario.codigoProducto, posicionColumna, posicionFila, fondoEstiloPagina);
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(filaGridInvetario.codProductoNombre, posicionColumna, posicionFila, fondoEstiloPagina);
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(filaGridInvetario.indSeriado, posicionColumna, posicionFila, fondoEstiloPagina);
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(filaGridInvetario.cntStockInicial.ToString("N2"), posicionColumna, posicionFila, fondoEstiloPagina);
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(filaGridInvetario.cntStockFisico.ToString("N2"), posicionColumna, posicionFila, fondoEstiloPagina);
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell("'" + filaGridInvetario.audFechaActualizacion.ToString(), posicionColumna, posicionFila, fondoEstiloPagina);
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;

            filasExcel.Add(documento.CreateRow(celdasExcel, posicionFila));

            return filasExcel;
        }

        #endregion

        private List<Style> ObtenerEstilosReporte()
        {
            List<Style> estilos = new List<Style>();

            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteGC.FondoLila), BackGroundColor = "8064A2", Border = true, FontBold = false, FontSize = 10, Color = "ffffff", HorizontalAlignment = Style.HorizontalAlignmentOptions.Left });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteGC.FondoBase), BackGroundColor = "FFFFFF", Border = true, FontBold = false, FontSize = 9, HorizontalAlignment = Style.HorizontalAlignmentOptions.Center });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteGC.FondoNegro), BackGroundColor = "000000", Border = true, FontBold = false, FontSize = 9, Color = "ffffff", HorizontalAlignment = Style.HorizontalAlignmentOptions.Left });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteGC.FondoPost), BackGroundColor = "CCFF33", Border = true, FontBold = false, FontSize = 9, HorizontalAlignment = Style.HorizontalAlignmentOptions.Left });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteGC.FondoPostPais), BackGroundColor = "FFCC00", Border = true, FontBold = false, FontSize = 9, HorizontalAlignment = Style.HorizontalAlignmentOptions.Center });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteGC.FondoVerde), BackGroundColor = "00CC00", Border = true, FontBold = false, FontSize = 9, HorizontalAlignment = Style.HorizontalAlignmentOptions.Center });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteGC.CabeceraCuadro), BackGroundColor = "0099FF", Border = true, FontBold = true, FontSize = 10, Color = "ffffff", HorizontalAlignment = Style.HorizontalAlignmentOptions.Center });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteGC.FondoValorPagina), BackGroundColor = "CCCCCC", Border = true, FontBold = false, FontSize = 9, HorizontalAlignment = Style.HorizontalAlignmentOptions.Center });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteGC.ColorWorkingPage), BackGroundColor = "CCCCCC", Border = true, FontBold = false, FontSize = 9, Color = "0000FF", HorizontalAlignment = Style.HorizontalAlignmentOptions.Center });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteGC.TituloReporte), BackGroundColor = "F2F2F2", Border = false, FontBold = true, FontSize = 16, Color = "000000", HorizontalAlignment = Style.HorizontalAlignmentOptions.Left });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteGC.FondoDefecto), BackGroundColor = "FFFFFF", Border = false, FontBold = false, FontSize = 9 });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteGC.FondoGranate), BackGroundColor = "990066", Border = false, FontBold = true, FontSize = 10, Color = "ffffff", HorizontalAlignment = Style.HorizontalAlignmentOptions.Center });
            return estilos;
        }

        private List<Style> GenerarEstilosDeFondo(List<vwProductoInventario> lstInventario)
        {
            List<Style> listaStyles = new List<Style>();
            foreach (string colorFondo in coloresFondo)
                listaStyles.Add(new Style
                {
                    Id = "Id" + colorFondo,
                    BackGroundColor = colorFondo,
                    Border = false,
                    FontBold = false,
                    FontSize = 9,
                    HorizontalAlignment = Style.HorizontalAlignmentOptions.Left,
                    WrapText = true
                });

            return listaStyles;
        }

        private Columns ObtenerAnchoCeldas(List<RowData> filasExcel, int posicionFilaInicial, int posicionLeerFilaAncho)
        {
            ExcelUtil documento = new ExcelUtil();
            Columns columns = new Columns();
            CellData celda = new CellData();
            uint indiceColumna;
            double anchoColumna;
            double anchoFinal = 0;

            for (int i = 0; i < filasExcel[posicionFilaInicial].Cells.Count; i++)
            {
                celda = filasExcel[posicionFilaInicial].Cells[i];
                indiceColumna = (uint)celda.ConvertColumnNameToNumber(celda.CellName);
                anchoColumna = ObtenerCeldaMayorAnchoPorColumna(filasExcel, celda.CellName, posicionLeerFilaAncho);
                if (anchoColumna != 0)
                {
                    anchoFinal = anchoColumna;
                    columns.Append(documento.CreateColumnData(indiceColumna, indiceColumna, false, anchoColumna + 2));
                }
                else
                {
                    columns.Append(documento.CreateColumnData(indiceColumna, indiceColumna, false, anchoFinal + 2));
                }
            }

            return columns;
        }

        private List<RowData> CrearCabeceraInventarioActual(IList<vwProductoInventario> listaInventario, int posicionColumna, uint posicionFila, string estilo, Dictionary<int, string> titulosReporte)
        {
            ExcelUtil documento = new ExcelUtil();
            List<CellData> celdasExcel = new List<CellData>();
            List<RowData> filasExcel = new List<RowData>();
            CellData celda;

            celda = documento.CreateCell(titulosReporte[1], posicionColumna, posicionFila, estilo);
            celdasExcel.Add(celda);
            posicionColumna = posicionColumna + 1;

            celda = documento.CreateCell(titulosReporte[2], posicionColumna, posicionFila, estilo);
            celdasExcel.Add(celda);
            posicionColumna = posicionColumna + 1;

            celda = documento.CreateCell(titulosReporte[3], posicionColumna, posicionFila, estilo);
            celdasExcel.Add(celda);
            posicionColumna = posicionColumna + 1;

            celda = documento.CreateCell(titulosReporte[4], posicionColumna, posicionFila, estilo);
            celdasExcel.Add(celda);
            posicionColumna = posicionColumna + 1;

            celda = documento.CreateCell(titulosReporte[5], posicionColumna, posicionFila, estilo);
            celdasExcel.Add(celda);
            posicionColumna = posicionColumna + 1;

            celda = documento.CreateCell(titulosReporte[6], posicionColumna, posicionFila, estilo);
            celdasExcel.Add(celda);
            posicionColumna = posicionColumna + 1;

            celda = documento.CreateCell(titulosReporte[8], posicionColumna, posicionFila, estilo);
            celdasExcel.Add(celda);
            posicionColumna = posicionColumna + 1;

            filasExcel.Add(documento.CreateRow(celdasExcel, posicionFila));

            return filasExcel;
        }

    }
}

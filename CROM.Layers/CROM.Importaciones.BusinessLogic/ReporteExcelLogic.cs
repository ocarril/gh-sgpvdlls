namespace CROM.Importaciones.BusinessLogic
{
    using CROM.BusinessEntities.Importaciones;
    using CROM.BusinessEntities.Importaciones.DTO;
    using CROM.Tools.Comun.utils.excel;
    using CROM.Tools.Comun.utils.excel.enumerator;

    using DocumentFormat.OpenXml.Spreadsheet;
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class ReporteExcelLogic
    {
        private List<string> coloresFondo = new List<string>();

        #region CREA LOS REPORTES DEL SISTEMA CON EXPORTACION A EXCEL

        public byte[] GenerarExcelReporteCostoDUA(FiltroExportar filtroExportar, int posicionColumna, uint posicionFila, Dictionary<int, string> titulosReporte, Dictionary<int, string> titulosCelda)
        {
            NumberFormat formatosNumerico = new NumberFormat();
            ExcelUtil documento = new ExcelUtil(formatosNumerico.numberingFormats);
            List<RowData> filasExcel = new List<RowData>();
            List<CellData> celdasExcel = new List<CellData>();
            List<CellData> celdasExcelFecha = new List<CellData>();
            WorkSheet workSheet = new WorkSheet();
            byte[] ficheroExcel;
            string tituloReporte;

            documento.Styles = ObtenerEstilosReporte();
            documento.Styles.AddRange(GenerarEstilosDeFondo(filtroExportar.itemOIDUA));

            CellData celdaTitulo;
            tituloReporte = "Reporte de Costos de la DUA N° :" + filtroExportar.itemOIDUA.numOIDUA;
            celdaTitulo = documento.CreateCell(tituloReporte, posicionColumna, posicionFila, 7, (int)ParametrosDireccionMergeExcel.DireccionHorizontal, Convert.ToString(EstilosReporteDUA.TituloReporte));
            celdasExcel.Add(celdaTitulo);
            filasExcel.Add(documento.CreateRow(celdasExcel, posicionFila));

            posicionFila = posicionFila + 1;
            CellData celdaFecha;
            celdaFecha = documento.CreateCell(titulosCelda[2], posicionColumna, posicionFila, 7, (int)ParametrosDireccionMergeExcel.DireccionHorizontal, Convert.ToString(EstilosReporteDUA.FondoBase));
            celdasExcelFecha.Add(celdaFecha);
            filasExcel.Add(documento.CreateRow(celdasExcelFecha, posicionFila));

            posicionFila = posicionFila + 1;
            CellData celdaDatoDUA;
            celdaDatoDUA = documento.CreateCell("Costos por DUA : ", posicionColumna, posicionFila, 7, (int)ParametrosDireccionMergeExcel.DireccionHorizontal, Convert.ToString(EstilosReporteDUA.TituloReporte));
            celdasExcelFecha.Add(celdaDatoDUA);
            filasExcel.Add(documento.CreateRow(celdasExcelFecha, posicionFila));

            posicionFila = posicionFila + 1;
            filasExcel.AddRange(CrearCabeceraCostoDUA(filtroExportar.itemOIDUA.lstOIDUACosto, posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.CabeceraCuadro), titulosReporte));

            posicionFila = posicionFila + 1;
            filasExcel.AddRange(CrearDatosReporteCostoDUA(filtroExportar.itemOIDUA, posicionColumna, posicionFila, titulosCelda));

            posicionFila = posicionFila + 1;

            workSheet.Rows = filasExcel;
            workSheet.Columns = ObtenerAnchoCeldas(filasExcel, 1, 4);

            ficheroExcel = documento.CreateNewDocument(workSheet);

            return ficheroExcel;
        }

        private List<RowData> CrearTOTALCostoDUA(BEOIDUA itemDUA, int posicionColumna, uint posicionFila, Dictionary<int, string> titulosCelda)
        {
            ExcelUtil documento = new ExcelUtil();
            List<CellData> celdasExcel = new List<CellData>();
            List<RowData> filasExcel = new List<RowData>();
            CellData celda;

            celda = documento.CreateCell("", posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.FondoDefecto));
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell("TOTAL COSTOS DE INTERNAMIENTO:", posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.CabeceraCuadro));
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(itemDUA.lstOIDUACosto.Where(ww => ww.codRegResumenCosto != "IMCST001").Sum(X => X.decMontoCosto).ToString("N2"), posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.FondoValorPagina));
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;

            filasExcel.Add(documento.CreateRow(celdasExcel, posicionFila));

            return filasExcel;
        }

        private List<RowData> CrearFOBCostoDUA(BEOIDUA itemDUA, int posicionColumna, uint posicionFila, Dictionary<int, string> titulosCelda)
        {
            ExcelUtil documento = new ExcelUtil();
            List<CellData> celdasExcel = new List<CellData>();
            List<RowData> filasExcel = new List<RowData>();
            CellData celda;

            celda = documento.CreateCell("", posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.FondoDefecto));
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell("TOTAL FOB:", posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.CabeceraCuadro));
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(itemDUA.lstOIDUACosto.Where(X => X.codRegResumenCosto == "IMCST001").Sum(f => f.decMontoCosto).ToString("N2"), posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.FondoValorPagina));
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;

            filasExcel.Add(documento.CreateRow(celdasExcel, posicionFila));

            return filasExcel;
        }

        private List<RowData> CrearFactorCostoDUA(BEOIDUA itemDUA, int posicionColumna, uint posicionFila, Dictionary<int, string> titulosCelda)
        {
            ExcelUtil documento = new ExcelUtil();
            List<CellData> celdasExcel = new List<CellData>();
            List<RowData> filasExcel = new List<RowData>();
            CellData celda;

            celda = documento.CreateCell("", posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.FondoDefecto));
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell("FACTOR :", posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.CabeceraCuadro));
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(itemDUA.decFactor == null ? "0.000" : itemDUA.decFactor.Value.ToString("N3"), posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.FondoValorPagina));
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;

            filasExcel.Add(documento.CreateRow(celdasExcel, posicionFila));

            return filasExcel;
        }

        private List<RowData> CrearDatosReporteCostoDUA(BEOIDUA itemDUA, int posicionColumna, uint posicionFila, Dictionary<int, string> titulosCelda)
        {
            ExcelUtil documento = new ExcelUtil();
            List<RowData> filasExcel = new List<RowData>();
            List<RowData> filasExcelDemanda = new List<RowData>();
            List<RowData> filasExcelVsDemandaProfit = new List<RowData>();

            foreach (var costo in itemDUA.lstOIDUACosto)
            {
                filasExcel.AddRange(CrearFilaExcelPaginaCostoDUA(costo, posicionColumna, posicionFila));
                ++posicionFila;
                if (costo.lstCostoDetalle.Count > 0)
                {
                    foreach (var costoDetalle in costo.lstCostoDetalle)
                    {
                        filasExcel.AddRange(CrearFilaExcelDetalleCosto(posicionColumna, posicionFila, costoDetalle));
                        ++posicionFila;
                    }
                }
                ++posicionFila;
            }

            filasExcel.AddRange(CrearTOTALCostoDUA(itemDUA, posicionColumna, posicionFila, titulosCelda));
            ++posicionFila;

            filasExcel.AddRange(CrearFOBCostoDUA(itemDUA, posicionColumna, posicionFila, titulosCelda));
            ++posicionFila;

            filasExcel.AddRange(CrearFactorCostoDUA(itemDUA, posicionColumna, posicionFila, titulosCelda));
            ++posicionFila;

            ++posicionFila;
            filasExcel.AddRange(CrearCabeceraCostoProducto(posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.CabeceraCuadro)));
            ++posicionFila;

            int contad = 1;
            foreach (var costoProdu in itemDUA.lstOIDUAProducto)
            {
                costoProdu.codOIDUAProducto = contad;
                filasExcel.AddRange(CrearFilaExcelPaginaCostoProducto(costoProdu, posicionColumna, posicionFila));
                ++contad;
                ++posicionFila;
            }
            return filasExcel;
        }
        private List<RowData> CrearFilaExcelDetalleCosto(int posicionColumna, uint posicionFila, DTOCostoDetalle costoDetalle)
        {

            ExcelUtil documento = new ExcelUtil();
            List<CellData> celdasExcel = new List<CellData>();
            List<RowData> filasExcel = new List<RowData>();
            CellData celda;
            string fondoEstiloDetalle = Convert.ToString(EstilosReporteDUA.FondoDefecto);

            celda = documento.CreateCell(string.Empty, posicionColumna, posicionFila, fondoEstiloDetalle);
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(costoDetalle.codProductoNombre, posicionColumna, posicionFila, fondoEstiloDetalle);
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;

            celda = documento.CreateCell(costoDetalle.monTipoCambioVta.ToString("N3"), posicionColumna, posicionFila, fondoEstiloDetalle);
            celdasExcel.Add(celda);
            posicionColumna = posicionColumna + 1;

            celda = documento.CreateCell(costoDetalle.monUnitPrecioVenta.ToString("N2"), posicionColumna, posicionFila, fondoEstiloDetalle);
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell("US $", posicionColumna, posicionFila, fondoEstiloDetalle);
            celdasExcel.Add(celda);


            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(costoDetalle.monTotalDocumento.ToString("N2"), posicionColumna, posicionFila, fondoEstiloDetalle);
            celdasExcel.Add(celda);

            filasExcel.Add(documento.CreateRow(celdasExcel, posicionFila));
            return filasExcel;
        }
        private List<RowData> CrearFilaExcelPaginaCostoDUA(BEOIDUACosto filaGridCosto, int posicionColumna, uint posicionFila)
        {
            ExcelUtil documento = new ExcelUtil();
            List<CellData> celdasExcel = new List<CellData>();
            List<RowData> filasExcel = new List<RowData>();
            CellData celda;

            string fondoEstiloPagina = Convert.ToString(EstilosReporteDUA.FondoDefecto);

            celda = documento.CreateCell(filaGridCosto.codOIDUACosto, posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.FondoDefecto));
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(filaGridCosto.auxcodRegResumenCosto, posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.FondoValorPagina));
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell("", posicionColumna, posicionFila, fondoEstiloPagina);
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell("", posicionColumna, posicionFila, fondoEstiloPagina);
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(filaGridCosto.auxcodRegMoneda, posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.FondoValorPagina));
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(filaGridCosto.decMontoCosto.ToString("N2"), posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.FondoValorPagina));
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;

            filasExcel.Add(documento.CreateRow(celdasExcel, posicionFila));

            return filasExcel;
        }
        private List<RowData> CrearFilaExcelPaginaCostoProducto(BEOIDUAProducto filaGridProducto, int posicionColumna, uint posicionFila)
        {
            ExcelUtil documento = new ExcelUtil();
            List<CellData> celdasExcel = new List<CellData>();
            List<RowData> filasExcel = new List<RowData>();
            CellData celda;

            string fondoEstiloPagina = Convert.ToString(EstilosReporteDUA.FondoDefecto);

            celda = documento.CreateCell(filaGridProducto.codOIDUAProducto, posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.FondoDefecto));
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(filaGridProducto.auxdesProducto, posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.FondoDefecto));
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(filaGridProducto.decPrecioUniFOB == null ? "0.00" : filaGridProducto.decPrecioUniFOB.Value.ToString("N2"), posicionColumna, posicionFila, fondoEstiloPagina);
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(filaGridProducto.decCantidadFOB == null ? "0.00" : filaGridProducto.decCantidadFOB.Value.ToString("N2"), posicionColumna, posicionFila, fondoEstiloPagina);
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(filaGridProducto.decPrecioUniCosto == null ? "0.00" : filaGridProducto.decPrecioUniCosto.Value.ToString("N2"), posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.FondoValorPagina));
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell(filaGridProducto.decTotalUniCosto == null ? "0.00" : filaGridProducto.decTotalUniCosto.Value.ToString("N2"), posicionColumna, posicionFila, Convert.ToString(EstilosReporteDUA.FondoValorPagina));
            celdasExcel.Add(celda);

            posicionColumna = posicionColumna + 1;

            filasExcel.Add(documento.CreateRow(celdasExcel, posicionFila));

            return filasExcel;
        }

        private List<RowData> CrearCabeceraCostoDUA(IList<BEOIDUACosto> listaOIDUACosto, int posicionColumna, uint posicionFila, string estilo, Dictionary<int, string> titulosReporte)
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

            filasExcel.Add(documento.CreateRow(celdasExcel, posicionFila));

            return filasExcel;
        }
        private List<RowData> CrearCabeceraCostoProducto(int posicionColumna, uint posicionFila, string estilo)
        {
            ExcelUtil documento = new ExcelUtil();
            List<CellData> celdasExcel = new List<CellData>();
            List<RowData> filasExcel = new List<RowData>();
            CellData celda;

            celda = documento.CreateCell("Item", posicionColumna, posicionFila, estilo);
            celdasExcel.Add(celda);
            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell("Nombre del Producto", posicionColumna, posicionFila, estilo);
            celdasExcel.Add(celda);
            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell("Precio Unit. FOB", posicionColumna, posicionFila, estilo);
            celdasExcel.Add(celda);
            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell("Total Unidades", posicionColumna, posicionFila, estilo);
            celdasExcel.Add(celda);
            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell("Total Costo Unit.", posicionColumna, posicionFila, estilo);
            celdasExcel.Add(celda);
            posicionColumna = posicionColumna + 1;
            celda = documento.CreateCell("Total Costo", posicionColumna, posicionFila, estilo);
            celdasExcel.Add(celda);
            posicionColumna = posicionColumna + 1;

            filasExcel.Add(documento.CreateRow(celdasExcel, posicionFila));

            return filasExcel;
        }

        private List<Style> ObtenerEstilosReporte()
        {
            List<Style> estilos = new List<Style>();

            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteDUA.FondoLila), BackGroundColor = "8064A2", Border = true, FontBold = false, FontSize = 10, Color = "ffffff", HorizontalAlignment = Style.HorizontalAlignmentOptions.Left });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteDUA.FondoBase), BackGroundColor = "FFFFFF", Border = true, FontBold = false, FontSize = 9, HorizontalAlignment = Style.HorizontalAlignmentOptions.Center });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteDUA.FondoNegro), BackGroundColor = "000000", Border = true, FontBold = false, FontSize = 9, Color = "ffffff", HorizontalAlignment = Style.HorizontalAlignmentOptions.Left });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteDUA.FondoPost), BackGroundColor = "CCFF33", Border = true, FontBold = false, FontSize = 9, HorizontalAlignment = Style.HorizontalAlignmentOptions.Left });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteDUA.FondoPostPais), BackGroundColor = "FFCC00", Border = true, FontBold = false, FontSize = 9, HorizontalAlignment = Style.HorizontalAlignmentOptions.Center });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteDUA.FondoVerde), BackGroundColor = "00CC00", Border = true, FontBold = false, FontSize = 9, HorizontalAlignment = Style.HorizontalAlignmentOptions.Center });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteDUA.CabeceraCuadro), BackGroundColor = "0099FF", Border = true, FontBold = true, FontSize = 10, Color = "ffffff", HorizontalAlignment = Style.HorizontalAlignmentOptions.Center });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteDUA.FondoValorPagina), BackGroundColor = "CCCCCC", Border = true, FontBold = false, FontSize = 9, HorizontalAlignment = Style.HorizontalAlignmentOptions.Center });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteDUA.ColorWorkingPage), BackGroundColor = "CCCCCC", Border = true, FontBold = false, FontSize = 9, Color = "0000FF", HorizontalAlignment = Style.HorizontalAlignmentOptions.Center });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteDUA.TituloReporte), BackGroundColor = "F2F2F2", Border = false, FontBold = true, FontSize = 16, Color = "000000", HorizontalAlignment = Style.HorizontalAlignmentOptions.Left });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteDUA.FondoDefecto), BackGroundColor = "FFFFFF", Border = false, FontBold = false, FontSize = 9 });
            estilos.Add(new Style { Id = Convert.ToString(EstilosReporteDUA.FondoGranate), BackGroundColor = "990066", Border = false, FontBold = true, FontSize = 10, Color = "ffffff", HorizontalAlignment = Style.HorizontalAlignmentOptions.Center });
            return estilos;
        }
        private List<Style> GenerarEstilosDeFondo(BEOIDUA datoDUA)
        {
            datoDUA.lstOIDUACosto.ToList().ForEach(p =>
            {
                p.lstCostoDetalle.ToList().ForEach(e =>
                {
                    if (e.codOIDUACosto != 0)
                        coloresFondo.Add("#FFFF00");
                });
            });
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

        #endregion
    }
}

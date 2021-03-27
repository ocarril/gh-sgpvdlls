namespace CROM.GestionComercial.BusinessLogic
{
    using CROM.BusinessEntities.Almacen;
    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.Comercial.DTO;
    using CROM.GestionComercial.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.Web;
    using CROM.Tools.Config;

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 30/12/2010-23:38:47 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [GestionComercial.ConsultasGCLogic.cs]
    /// </summary>
    public class ConsultasGCLogic
    {
        private ConsultasGCData oConsultasGCData = null;
        private ReturnValor oReturnValor = null;

        public ConsultasGCLogic()
        {
            oConsultasGCData = new ConsultasGCData();
            oReturnValor = new ReturnValor();
        }

        /// <summary>
        /// Listado de productos vendidos o comprados de cocumentos fiscales
        /// </summary>
        /// <param name="prm_codProducto">Código de producto</param>
        /// <param name="prm_codEmpresa">Código de Empresa</param>
        /// <param name="prm_CodigoPuntoVenta">Código de Punto de venta</param>
        /// <param name="prm_AnioProceso">Año del proceso que se veran la información</param>
        /// <param name="prm_TipoCambio">Tipo de cambio para calculo en dólares</param>
        /// <param name="prm_CodigoArguDestinoComp">Tipo de Destino si fue Venta o compra</param>
        /// <returns></returns>
        public List<ResumenVentasMensuales> ListProductoVentasCompras(int prm_codEmpresa, int? prm_codProducto, 
                                                                      string prm_codDeposito, string prm_CodigoPuntoVenta, 
                                                                      int prm_AnioProceso, int prm_MesIni, 
                                                                      int prm_MesFin, decimal prm_TipoCambio, 
                                                                      string prm_CodigoArguDestinoComp,
                                                                      string puserActual)
        {
            List<ResumenVentasMensuales> lstResumenVentasMensuales = new List<ResumenVentasMensuales>();
            try
            {
                lstResumenVentasMensuales = oConsultasGCData.ListProductoVentasCompras(prm_codEmpresa, prm_codProducto, 
                                                                                       prm_codDeposito, prm_CodigoPuntoVenta, 
                                                                                       prm_AnioProceso, prm_MesIni, 
                                                                                       prm_MesFin, prm_TipoCambio, 
                                                                                       prm_CodigoArguDestinoComp);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              puserActual, prm_codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstResumenVentasMensuales;
        }

        /// <summary>
        /// Listado de productos vendidos o comprados de documentos fiscales por entidades por año
        /// </summary>
        /// <param name="prm_CodigoPersonaEntidad">Código de la Entidad a tomar en cuenta</param>
        /// <param name="prm_CodigoPersonaEmpre">Código de la Empresa</param>
        /// <param name="prm_CodigoPuntoVenta">Código de Punto de venta</param>
        /// <param name="prm_AnioProceso">Año del proceso que se veran la información</param>
        /// <param name="prm_TipoCambio">Tipo de cambio para calculo en dólares</param>
        /// <param name="prm_CodigoArguDestinoComp">Tipo de Destino si fue Venta o compra</param>
        /// <returns></returns>
        public List<ResumenVentasMensuales> ListEntidadesVentasCompras(int prm_codEmpresa, string prm_CodigoPersonaEntidad, 
                                                                       string prm_CodigoPuntoVenta, int prm_AnioProceso, 
                                                                       int prm_MesIni, int prm_MesFin, 
                                                                       decimal prm_TipoCambio, 
                                                                       string prm_CodigoArguDestinoComp,
                                                                       string puserActual)
        {
            List<ResumenVentasMensuales> miLista = new List<ResumenVentasMensuales>();
            try
            {
                miLista = oConsultasGCData.ListEntidadesVentasCompras(prm_codEmpresa, prm_CodigoPersonaEntidad, 
                                                                      prm_CodigoPuntoVenta, prm_AnioProceso, 
                                                                      prm_MesIni, prm_MesFin, prm_TipoCambio, 
                                                                      prm_CodigoArguDestinoComp);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              puserActual, prm_codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return miLista;
        }

        /// <summary>
        /// Listado de productos por entidades por rango de fechas
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEComprobanteEmisionDetalle> ListProductosPorEntidadesVentasCompras(BaseFiltro pFiltro)
        {
            List<BEComprobanteEmisionDetalle> lstComprobanteEmisionDetalle = new List<BEComprobanteEmisionDetalle>();
            try
            {
                pFiltro.fecInicio = HelpTime.ConvertYYYYMMDD(pFiltro.fecInicioDate);
                pFiltro.fecFinal = HelpTime.ConvertYYYYMMDD(pFiltro.fecFinalDate);
                lstComprobanteEmisionDetalle = oConsultasGCData.ListProductosPorEntidadesVentasCompras(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             pFiltro.segUsuarioEdita, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstComprobanteEmisionDetalle;
        }

        /// <summary>
        /// Listado de movimientos fisicos de los productos
        /// </summary>
        /// <param name="prm_FechaProcesoINI">Fecha de inicio</param>
        /// <param name="prm_FechaProcesoFIN">Fecha de Fin/param>
        /// <param name="prm_codEmpresa">Código de la Empresa</param>
        /// <param name="prm_CodigoPuntoVenta">Código de Punto de venta</param>
        /// <param name="prm_CodigoProducto">Código de producto</param>
        /// <param name="prm_CodigoArguDestinoComp">Tipo de Destino si fue Venta o compra</param>
        /// <returns></returns>
        public List<ProductoMovimientos> ListProductoMovimientosVentasCompras(int prm_codEmpresa, 
                                                                              Nullable<DateTime> prm_FechaProcesoINI, 
                                                                              Nullable<DateTime> prm_FechaProcesoFIN, 
                                                                              string prm_CodigoPuntoVenta, 
                                                                              string prm_codDeposito, 
                                                                              int? prm_codProducto, 
                                                                              string prm_CodigoArguDestinoComp,
                                                                              string puserActual)
        {
            List<ProductoMovimientos> lstProductoMovimientos = new List<ProductoMovimientos>();
            try
            {
                lstProductoMovimientos = oConsultasGCData.ListProductoMovimientosVentasCompras(prm_codEmpresa, 
                                                                                               HelpTime.ConvertYYYYMMDD(prm_FechaProcesoINI), 
                                                                                               HelpTime.ConvertYYYYMMDD(prm_FechaProcesoFIN), 
                                                                                               prm_CodigoPuntoVenta, 
                                                                                               prm_codDeposito, prm_codProducto, 
                                                                                               prm_CodigoArguDestinoComp);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              puserActual, prm_codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstProductoMovimientos;
        }

        /// <summary>
        /// Listado de (n) Entidades en Record de Ventas o compras
        /// </summary>
        /// <param name="prm_FechaProcesoINI">Fecha de Inicio</param>
        /// <param name="prm_FechaProcesoFIN">Fecha de Final</param>
        /// <param name="prm_CodigoPersonaEmpre">Código de la empresa</param>
        /// <param name="prm_CodigoPuntoVenta">Código del punto de Venta</param>
        /// <param name="prm_CodigoComprobante">Código de Comprobante</param>
        /// <param name="prm_CodigoPersonaEntidad">Código de la entidad a consultar</param>
        /// <param name="prm_codEmpleado">Código del empleado a consultar</param>
        /// <param name="prm_CodigoArguDestinoComp">Código de destino de las operaciones</param>
        /// <param name="prm_NumeroRegistros">Cantidad de entidades a mostrar</param>
        /// <returns></returns>
        public List<BEComprobanteEmision> ListRecordEntidadesVentasCompras(int prm_codEmpresa, 
                                                                           Nullable<DateTime> prm_FechaProcesoINI, 
                                                                           Nullable<DateTime> prm_FechaProcesoFIN, 
                                                                           string prm_CodigoPuntoVenta, 
                                                                           string prm_CodigoComprobante, 
                                                                           string prm_CodigoPersonaEntidad, 
                                                                           int? prm_codEmpleado, 
                                                                           string prm_CodigoArguDestinoComp, 
                                                                           int prm_NumeroRegistros,
                                                                           string puserActual)
        {
            List<BEComprobanteEmision> lstComprobanteEmision = new List<BEComprobanteEmision>();
            try
            {
                lstComprobanteEmision = oConsultasGCData.ListRecordEntidadesVentasCompras(prm_codEmpresa, 
                                                                                          HelpTime.ConvertYYYYMMDD(prm_FechaProcesoINI),
                                                                                          HelpTime.ConvertYYYYMMDD(prm_FechaProcesoFIN),
                                                                                          prm_CodigoPuntoVenta, 
                                                                                          prm_CodigoComprobante, 
                                                                                          prm_CodigoPersonaEntidad, prm_codEmpleado, 
                                                                                          prm_CodigoArguDestinoComp, 
                                                                                          prm_NumeroRegistros);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              puserActual, prm_codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstComprobanteEmision;
        }

        /// <summary>
        /// Listado del registro de ventas y compras
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEComprobanteEmision> ListRegistroDeVentasCompras(BaseFiltro pFiltro)
        {
            List<BEComprobanteEmision> lstComprobanteEmision = new List<BEComprobanteEmision>();
            try
            {
                pFiltro.fecInicio = HelpTime.ConvertYYYYMMDD(pFiltro.fecInicioDate);
                pFiltro.fecFinal = HelpTime.ConvertYYYYMMDD(pFiltro.fecFinalDate);
                if (pFiltro.indContabilizado)
                    lstComprobanteEmision = oConsultasGCData.ListRegistroDeVentasComprasContab(pFiltro); 
                else
                    lstComprobanteEmision = oConsultasGCData.ListRegistroDeVentasCompras(pFiltro);
                foreach (BEComprobanteEmision x in lstComprobanteEmision)
                {
                    if (x.CodigoArguMoneda == ConfigCROM.AppConfig(pFiltro.codEmpresa, ConfigTool.DEFAULT_MonedaInt))
                        x.ValorTotalDescuento = x.ValorTotalPrecioExtran;
                    else
                        x.ValorTotalDescuento = x.ValorTotalPrecioVenta;
                }
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioEdita, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstComprobanteEmision;
        }

        /// <summary>
        /// Listado del registro de ventas y compras de forma detallada de productos vendidos
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEComprobanteEmisionDetalle> ListRegistroDeVentasComprasDetallado(BaseFiltro pFiltro)
        {
            List<BEComprobanteEmisionDetalle> lstComprobanteEmisionDetalle = new List<BEComprobanteEmisionDetalle>();
            try
            {
                pFiltro.fecInicio = HelpTime.ConvertYYYYMMDD(pFiltro.fecInicioDate);
                pFiltro.fecFinal = HelpTime.ConvertYYYYMMDD(pFiltro.fecFinalDate);
                lstComprobanteEmisionDetalle = oConsultasGCData.ListRegistroDeVentasComprasDetallado(pFiltro);
                foreach (BEComprobanteEmisionDetalle x in lstComprobanteEmisionDetalle)
                {
                    if (x.refCodigoArguMoneda == ConfigCROM.AppConfig(pFiltro.codEmpresa, ConfigTool.DEFAULT_MonedaInt))
                        x.TotItemValorDscto = Math.Round((x.TotItemValorVenta / x.refValorTipoCambio), 4);
                    else
                        x.TotItemValorDscto = x.TotItemValorVenta;
                }
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioEdita, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstComprobanteEmisionDetalle;
        }
        
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="pFiltro"></param>
        ///// <returns></returns>
        //public List<BEComprobanteEmision> ListComprobantesParaPDTMensual(BaseFiltro pFiltro, 
        //                                                                 out List<BEComprobanteEmision> lstComprobanteEmisionCompraPDT)
        //{
        //    List<BEComprobanteEmision> lstComprobanteEmision = new List<BEComprobanteEmision>();
        //    List<BEComprobanteEmision> lstComprobanteEmisionPDT_Ventas = new List<BEComprobanteEmision>();
        //    List<BEComprobanteEmision> lstComprobanteEmisionPDT_Compra = new List<BEComprobanteEmision>();
        //    try
        //    {
        //        lstComprobanteEmision = oConsultasGCData.ListComprobantesParaPDTMensual(pFiltro);
        //        short i = 1;
        //        short t = 1;
        //        foreach (BEComprobanteEmision item in lstComprobanteEmision)
        //        {
        //            if (item.CodigoArguMoneda == ConfigCROM.AppConfig(pFiltro.codEmpresa, ConfigTool.DEFAULT_MonedaInt))
        //                item.ValorTotalHistorico = item.ValorTotalPrecioExtran;
        //            else
        //                item.ValorTotalHistorico = item.ValorTotalPrecioVenta;

        //            string codigoArguDestino = item.CodigoArguDestinoComp;
        //            if (item.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_CLIENTES)
        //            {
        //                BEComprobanteEmision miItemPDT_Ventas = new BEComprobanteEmision();
        //                miItemPDT_Ventas = item;
        //                miItemPDT_Ventas.SegAnio = i;

        //                if (miItemPDT_Ventas.DocEsGravado)
        //                {
        //                    miItemPDT_Ventas.ValorTotalVentaGravada = Convert.ToDecimal(item.ValorTotalVenta);
        //                    miItemPDT_Ventas.ValorTotalImpuestoGravada = Convert.ToDecimal(item.ValorTotalImpuesto);
        //                }
        //                else
        //                {
        //                    miItemPDT_Ventas.ValorTotalVenta = Convert.ToDecimal(item.ValorTotalVenta);
        //                    miItemPDT_Ventas.ValorTotalImpuesto = Convert.ToDecimal(item.ValorTotalImpuesto);
        //                }
        //                lstComprobanteEmisionPDT_Ventas.Add(miItemPDT_Ventas);
        //                ++i;
        //            }
        //            else
        //            {
        //                BEComprobanteEmision miItemPDT_Compra = new BEComprobanteEmision();
        //                miItemPDT_Compra = item;
        //                miItemPDT_Compra.SegAnio = t;
        //                if (miItemPDT_Compra.DocEsGravado)
        //                {
        //                    miItemPDT_Compra.ValorTotalVentaGravada = Convert.ToDecimal(item.ValorTotalVenta);
        //                    miItemPDT_Compra.ValorTotalImpuestoGravada = Convert.ToDecimal(item.ValorTotalImpuesto);
        //                }
        //                else
        //                {
        //                    miItemPDT_Compra.ValorTotalVenta = Convert.ToDecimal(item.ValorTotalVenta);
        //                    miItemPDT_Compra.ValorTotalImpuesto = Convert.ToDecimal(item.ValorTotalImpuesto);
        //                }
        //                lstComprobanteEmisionPDT_Compra.Add(miItemPDT_Compra);
        //                ++t;
        //            }

        //        }

        //        lstComprobanteEmisionCompraPDT = lstComprobanteEmisionPDT_Compra;

        //    }
        //    catch (Exception ex)
        //    {
        //        var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
        //                                                      pFiltro.segUsuarioEdita, pFiltro.codEmpresa.ToString());
        //        throw new Exception(returnValor.Message);
        //    }

        //    return lstComprobanteEmisionPDT_Ventas;

        //}
        
        public List<BEComprobanteEmisionDetalle> ListPorEntidadesProductosVentasCompras(int prm_codEmpresa, 
                                                                                        string prm_CodigoPersonaEntidad, 
                                                                                        string prm_CodigoPuntoVenta, 
                                                                                        Nullable<DateTime> prm_FechaDeEmisionINI, 
                                                                                        Nullable<DateTime> prm_FechaDeEmisionFIN, 
                                                                                        string prm_CodigoArguDestinoComp, 
                                                                                        string prm_CodigoComprobante,
                                                                                        string puserActual)
        {
            List<BEComprobanteEmisionDetalle> miLista = new List<BEComprobanteEmisionDetalle>();
            try
            {
                miLista = oConsultasGCData.ListPorEntidadesProductosVentasCompras(prm_codEmpresa, 
                                                                                  prm_CodigoPersonaEntidad, 
                                                                                  prm_CodigoPuntoVenta,
                                                                                  HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionINI), 
                                                                                  HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionFIN), 
                                                                                  prm_CodigoArguDestinoComp, 
                                                                                  prm_CodigoComprobante);
                if (miLista.Count > 0)
                {
                    decimal nTotCantidad = 0, nTotMonNac = 0, nTotMonInt = 0, nConta = 0;
                    string CodigoExis = Convert.ToString(miLista[0].CodigoProducto);
                    List<BEComprobanteEmisionDetalleResumen> listaCEDResumen = new List<BEComprobanteEmisionDetalleResumen>();

                    foreach (BEComprobanteEmisionDetalle ItemRow in miLista)
                    {
                        if (ItemRow.CodigoProducto == CodigoExis)
                        {
                            nTotCantidad = nTotCantidad + ItemRow.Cantidad;
                            nTotMonNac = nTotMonNac + ItemRow.TotItemValorVenta;
                            nTotMonInt = nTotMonInt + ItemRow.refTotItemValorVentaExtran;
                        }
                        else
                        {
                            BEComprobanteEmisionDetalleResumen xCEDetalleResumen = new BEComprobanteEmisionDetalleResumen();
                            xCEDetalleResumen.CodigoProducto = CodigoExis;
                            xCEDetalleResumen.Cantidad = nTotCantidad;
                            xCEDetalleResumen.TotalMonedaNacional = nTotMonNac;
                            xCEDetalleResumen.TotalMonedaExtranjero = nTotMonInt;
                            listaCEDResumen.Add(xCEDetalleResumen);

                            nTotCantidad = 0; nTotMonNac = 0; nTotMonInt = 0;
                            CodigoExis = ItemRow.CodigoProducto;
                            nTotCantidad = nTotCantidad + ItemRow.Cantidad;
                            nTotMonNac = nTotMonNac + ItemRow.TotItemValorVenta;
                            nTotMonInt = nTotMonInt + ItemRow.refTotItemValorVentaExtran;
                        }
                        ++nConta;
                    }
                    BEComprobanteEmisionDetalleResumen xCEDetalleResumenF = new BEComprobanteEmisionDetalleResumen();
                    xCEDetalleResumenF.CodigoProducto = CodigoExis;
                    xCEDetalleResumenF.Cantidad = nTotCantidad;
                    xCEDetalleResumenF.TotalMonedaNacional = nTotMonNac;
                    xCEDetalleResumenF.TotalMonedaExtranjero = nTotMonInt;
                    listaCEDResumen.Add(xCEDetalleResumenF);
                    miLista[0].listaComprobanteEmisionDetalleResumen = listaCEDResumen;

                }
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              puserActual, prm_codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return miLista;
        }
        
        public List<InventarioAux> ListProductosReporteDeInventario(string prm_codEmpresaRUC, 
                                                                    Nullable<DateTime> prm_FechaDeEmisionINI, 
                                                                    Nullable<DateTime> prm_FechaDeEmisionFIN, 
                                                                    string prm_CodigoPuntoVenta, 
                                                                    string prm_codDeposito, 
                                                                    string prm_Periodo, 
                                                                    string prm_desAgrupacion,
                                                                    string puserActual,
                                                                    int pcodEmpresa)
        {
            List<InventarioAux> listaInventario = new List<InventarioAux>();
            try
            {
                listaInventario = oConsultasGCData.ListProductosReporteDeInventario(prm_codEmpresaRUC, 
                                                                                    HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionINI), 
                                                                                    HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionFIN), 
                                                                                    prm_CodigoPuntoVenta, 
                                                                                    prm_codDeposito, 
                                                                                    prm_Periodo, 
                                                                                    prm_desAgrupacion);
                int contador = 1;
                foreach (InventarioAux item in listaInventario)
                {
                    item.Conteo = contador;
                    ++contador;
                }
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              puserActual, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return listaInventario;
        }
        
        public List<BEProductoSeriado> ListNumerosDeSerie(string prmcodProducto, string prmProvider, 
                                                          string prmDataSourceFile, string prmExtended, 
                                                          string prmNameRange,
                                                          string puserActual,
                                                          int pcodEmpresa)
        {
            List<BEProductoSeriado> lstProductoSeriados = new List<BEProductoSeriado>();
            try
            {
                List<BEProducto> lstProducto = new List<BEProducto>();
                foreach (DataRow xRow in oConsultasGCData.ListNumerosDeSerie(prmProvider, prmDataSourceFile, 
                                                                             prmExtended, prmNameRange).Rows)
                {
                    BEProductoSeriado productoSeriado = new BEProductoSeriado();
                    if (xRow["codProducto"].ToString() == prmcodProducto)
                    {
                        productoSeriado.codigoProducto = xRow["codProducto"].ToString();
                        if (xRow["fecVencimiento"] != null)
                            productoSeriado.FechaVencimiento = Convert.ToDateTime(xRow["fecVencimiento"].ToString());

                        productoSeriado.NumeroLote = xRow["nroLote"].ToString();
                        productoSeriado.NumeroSerie = xRow["nroSerie"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             puserActual, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstProductoSeriados;
        }
        
        public List<vwProductoConsignacion> ListProductoConsignacion(BaseFiltroProductoConsignacion pFiltro)
        {
            List<vwProductoConsignacion> lstProductoConsignacion = new List<vwProductoConsignacion>();
            try
            {
                pFiltro.fecInicio = HelpTime.ConvertYYYYMMDD(pFiltro.fecInicioDate);
                pFiltro.fecFinal = HelpTime.ConvertYYYYMMDD(pFiltro.fecFinalDate);
                lstProductoConsignacion = oConsultasGCData.ListProductoConsignacion(pFiltro);
                int contador = 1;
                foreach (vwProductoConsignacion item in lstProductoConsignacion)
                {
                    item.codItem = contador;
                    ++contador;
                }
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstProductoConsignacion;
        }

        public List<vwProductoInventario> ListProductoReporteDeInventarioActual(BaseFiltroInventarioActual pFiltro)
        {
            List<vwProductoInventario> listaInventarioActual = new List<vwProductoInventario>();
            try
            {
                listaInventarioActual = oConsultasGCData.ListProductoReporteDeInventarioActual(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return listaInventarioActual;
        }

    }
}

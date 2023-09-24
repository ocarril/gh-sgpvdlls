namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;
    using System.Data;
    using System.Data.OleDb;

    using CROM.BusinessEntities.Almacen;
    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.Comercial.DTO;
    using CROM.Tools.Comun;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 30/12/2010-23:10:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.ConsultasGCData.cs]
    /// </summary>
    public class ConsultasGCData
    {
        private string conexion = string.Empty;
        public ConsultasGCData()
        {
            conexion = Util.ConexionBD();
        }

        /// <summary>
        /// Listado de productos vendidos o comprados de documentos fiscales
        /// </summary>
        /// <param name="prm_CodigoProducto">Código de producto</param>
        /// <param name="prm_CodigoPersonaEmpre">Código de Empresa</param>
        /// <param name="prm_CodigoPuntoVenta">Código de Punto de venta</param>
        /// <param name="prm_AnioProceso">Año del proceso que se veran la información</param>
        /// <param name="prm_TipoCambio">Tipo de cambio para calculo en dólares</param>
        /// <param name="prm_CodigoArguDestinoComp">Tipo de Destino si fue Venta o compra</param>
        /// <returns></returns>
        public List<ResumenVentasMensuales> ListProductoVentasCompras(int prm_CodEmpresa,int? prm_codProducto,  
                                                                      string prm_codDeposito, string prm_CodigoPuntoVenta, 
                                                                      int prm_AnioProceso, int prm_MesIni, int prm_MesFin, 
                                                                      decimal prm_TipoCambio, string prm_CodigoArguDestinoComp)
        {
            List<ResumenVentasMensuales> miLista = new List<ResumenVentasMensuales>();
            try
            {
                using (_ConsultasGCDataContext SQLDC = new _ConsultasGCDataContext(conexion))
                {
                    var resul = SQLDC.omgc_R_PorProductoEnAniosVentasCompras(prm_CodEmpresa, 
                                                                             prm_codProducto, 
                                                                             prm_CodigoPuntoVenta, 
                                                                             prm_codDeposito, 
                                                                             prm_AnioProceso, 
                                                                             prm_MesIni, 
                                                                             prm_MesFin, 
                                                                             prm_TipoCambio, 
                                                                             prm_CodigoArguDestinoComp);
                    foreach (var item in resul)
                    {
                        miLista.Add(new ResumenVentasMensuales()
                        {
                            Años = item.Años == null ? 0 : Convert.ToInt32(item.Años),
                            Cantidad = item.Cantidad == null ? 0 : Convert.ToDecimal(item.Cantidad),
                            ItemMes = item.ItemMes == null ? 0 : Convert.ToInt32(item.ItemMes),
                            Meses = item.Meses,
                            MontoExtranje = item.MontoExtranje == null ? 0 : Convert.ToDecimal(item.MontoExtranje),
                            MontoNacional = item.MontoNacional == null ? 0 : Convert.ToDecimal(item.MontoNacional),
                            TipoCambio = item.TipoCambio == null ? 0 : Convert.ToDecimal(item.TipoCambio),
                            CodigoArguTipoDeOperacion = item.CodigoArguTipoDeOperacion,
                            CodigoArguTipoDeOperacionNombre = item.CodigoArguTipoDeOperacionNombre,
                            codProducto = item.codProducto,
                            codigoProducto = item.codigoProducto,
                            Descripcion = item.Descripcion
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
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
        public List<ResumenVentasMensuales> ListEntidadesVentasCompras(int prm_CodEmpresa, string prm_CodigoPersonaEntidad, 
                                                                       string prm_CodigoPuntoVenta, int prm_AnioProceso, 
                                                                       int prm_MesIni, int prm_MesFin, decimal prm_TipoCambio, 
                                                                       string prm_CodigoArguDestinoComp)
        {
            List<ResumenVentasMensuales> miLista = new List<ResumenVentasMensuales>();
            try
            {
                using (_ConsultasGCDataContext SQLDC = new _ConsultasGCDataContext(conexion))
                {
                    var resul = SQLDC.omgc_R_DocumRegEnAniosVentasCompras(prm_CodEmpresa, 
                                                                          prm_CodigoPersonaEntidad, 
                                                                          prm_CodigoPuntoVenta, 
                                                                          prm_AnioProceso, 
                                                                          prm_MesIni, 
                                                                          prm_MesFin, 
                                                                          prm_TipoCambio, 
                                                                          prm_CodigoArguDestinoComp);
                    foreach (var item in resul)
                    {
                        miLista.Add(new ResumenVentasMensuales()
                        {
                            Años = item.Años == null ? 0 : Convert.ToInt32(item.Años),
                            Cantidad = item.Cantidad == null ? 0 : Convert.ToDecimal(item.Cantidad),
                            ItemMes = item.ItemMes == null ? 0 : Convert.ToInt32(item.ItemMes),
                            Meses = item.Meses,
                            MontoExtranje = item.MontoExtranje == null ? 0 : Convert.ToDecimal(item.MontoExtranje),
                            MontoNacional = item.MontoNacional == null ? 0 : Convert.ToDecimal(item.MontoNacional),
                            TipoCambio = item.TipoCambio == null ? 0 : Convert.ToDecimal(item.TipoCambio),
                            CodigoArguTipoDeOperacion = item.CodigoArguTipoDeOperacion,
                            CodigoArguTipoDeOperacionNombre = item.CodigoArguTipoDeOperacionNombre,

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        /// <summary>
        /// Listado de productos por entidades por rango de fechas
        /// </summary>
        /// <param name="prm_FechaDeEmisionINI">Fecha de inicio</param>
        /// <param name="prm_FechaDeEmisionFIN">Fecha de Fin</param>
        /// <param name="prm_CodigoPersonaEmpre">Código de la Empresa</param>
        /// <param name="prm_CodigoPuntoVenta">Código de Punto de venta</param>
        /// <param name="prm_CodigoPersonaEntidad">Código de la Entidad a tomar en cuenta</param>
        /// <param name="prm_CodigoArguDestinoComp">Tipo de Destino si fue Venta o compra</param>
        /// <returns></returns>
        public List<BEComprobanteEmisionDetalle> ListProductosPorEntidadesVentasCompras(BaseFiltro pFiltro) 
        {
            List<BEComprobanteEmisionDetalle> lstComprobanteEmisionDetalle = new List<BEComprobanteEmisionDetalle>();
            try
            {
                using (_ConsultasGCDataContext SQLDC = new _ConsultasGCDataContext(conexion))
                {
                    var resul = SQLDC.omgc_R_ProductosPorEntidadesVentasCompras(pFiltro.codEmpresa,
                                                                                pFiltro.fecInicio, 
                                                                                pFiltro.fecFinal, 
                                                                                pFiltro.codPuntoVenta, 
                                                                                pFiltro.codPerEntidad, 
                                                                                pFiltro.codRegDestinoDocum,
                                                                                pFiltro.codProducto);
                    foreach (var item in resul)
                    {
                        lstComprobanteEmisionDetalle.Add(new BEComprobanteEmisionDetalle()
                        {
                            refCodigoArguTipoDeOperacion = item.CodigoArguTipoDeOperacion,
                            refCodigoArguTipoDeOperacionNombre = item.CodigoArguTipoDeOperacionNombre,
                            FechaDeEmision = item.FechaDeEmision,
                            codProducto = item.codProducto,
                            CodigoProducto = item.CodigoProducto,
                            Cantidad = item.Cantidad,
                            UnitValorVenta = item.UnitValorVenta,
                            TotItemValorVenta = item.TotItemValorVenta,
                            refCodigoArguMoneda = item.CodigoArguMoneda,
                            refCodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            CodigoArguGarantiaProd = item.CodigoArguGarantiaProd,
                            CodigoArguGarantiaProdNombre = item.CodigoArguGarantiaProdNombre,
                            refTotItemValorVentaExtran = item.TotItemValorVentaExtran == null ? 0 : Convert.ToDecimal(item.TotItemValorVentaExtran),
                            Descripcion = item.Descripción,
                            NumeroComprobante = item.NumeroComprobante,
                            refValorTipoCambio = item.ValorTipoCambio == null ? 0 : Convert.ToDecimal(item.ValorTipoCambio),
                            refCodigoPersonaEntidad = item.ref_CodigoPersonaEntidad,
                            refCodigoPersonaEntidadNombre = item.ref_CodigoPersonaEntidadNombre,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaCrea = item.SegFechaCrea,
                            SegFechaEdita = item.SegFechaEdita,
                            SegMaquina = item.SegMaquina,
                            EsVerificarStock = item.EsVerificarStock,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstComprobanteEmisionDetalle;
        }

        /// <summary>
        /// Listado de movimientos fisicos de los productos
        /// </summary>
        /// <param name="prm_FechaProcesoINI">Fecha de inicio</param>
        /// <param name="prm_FechaProcesoFIN">Fecha de Fin/param>
        /// <param name="prm_CodigoPersonaEmpre">Código de la Empresa</param>
        /// <param name="prm_CodigoPuntoVenta">Código de Punto de venta</param>
        /// <param name="prm_CodigoProducto">Código de producto</param>
        /// <param name="prm_CodigoArguDestinoComp">Tipo de Destino si fue Venta o compra</param>
        /// <returns></returns>
        public List<ProductoMovimientos> ListProductoMovimientosVentasCompras(int prm_codEmpresa, 
                                                                              string prm_FechaProcesoINI, 
                                                                              string prm_FechaProcesoFIN, 
                                                                              string prm_CodigoPuntoVenta, 
                                                                              string prm_codDeposito, int? prm_codProducto, 
                                                                              string prm_CodigoArguDestinoComp)
        {
            List<ProductoMovimientos> lstProductoMovimientos = new List<ProductoMovimientos>();
            try
            {
                using (_ConsultasGCDataContext SQLDC = new _ConsultasGCDataContext(conexion))
                {
                    var resul = SQLDC.omgc_R_ProductoMovimientoVentasCompras(prm_codEmpresa, 
                                                                             prm_CodigoPuntoVenta, 
                                                                             prm_codDeposito, 
                                                                             prm_codProducto, 
                                                                             prm_CodigoArguDestinoComp, 
                                                                             prm_FechaProcesoINI, 
                                                                             prm_FechaProcesoFIN);
                    foreach (var item in resul)
                    {
                        lstProductoMovimientos.Add(new ProductoMovimientos()
                        {
                            Cantidad = item.Cantidad == null ? 0 : item.Cantidad.Value,
                            EntidadRazonSocial = item.EntidadRazonSocial,
                            FechaDeEmision = item.FechaDeEmision,
                            NumeroComprobante = item.NumeroComprobante,
                            TotItemValorVenta = item.TotItemValorVenta,
                            UnitPrecioSinIGV = item.UnitPrecioSinIGV,
                            UnitValorDscto = item.UnitValorDscto,
                            UnitValorVenta = item.UnitValorVenta,

                            UnitValorIGV = item.UnitValorIGV,
                            TotItemValorIGV = item.TotItemValorIGV,

                            UnitValorVentaMnInt = item.UnitValorVentaMnInt == null ? 0 : item.UnitValorVentaMnInt.Value,
                            UnitValorIGVMnInt = item.UnitValorIGVMnInt == null ? 0 : item.UnitValorIGVMnInt.Value,
                            TotItemValorVentaMnInt = item.TotItemValorVentaMnInt == null ? 0 : item.TotItemValorVentaMnInt.Value,
                            TotItemValorIGVMnInt = item.TotItemValorIGVMnInt == null ? 0 : item.TotItemValorIGVMnInt.Value,

                            ValorTipoCambioCMP = item.ValorTipoCambioCMP == null ? 0 : Convert.ToDecimal(item.ValorTipoCambioCMP),
                            ValorTipoCambioVTA = item.ValorTipoCambioVTA == null ? 0 : Convert.ToDecimal(item.ValorTipoCambioVTA),
                            codProducto = item.codProducto,
                            CodigoProducto = item.codigoProducto,
                            CodigoProductoNombre = item.CodigoProductoNombre,
                            CodigoArguMoneda = item.CodigoArguMoneda,
                            CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            CodigoArguTipoDeOperacion = item.CodigoArguTipoDeOperacion,
                            CodigoArguTipoDeOperacionNombre = item.CodigoArguTipoDeOperacionNombre,
                            CodigoComprobante = item.CodigoComprobante,
                            CodigoComprobanteNombre = item.CodigoComprobanteNombre,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                                                                           string prm_FechaProcesoINI, 
                                                                           string prm_FechaProcesoFIN, 
                                                                           string prm_CodigoPuntoVenta, 
                                                                           string prm_CodigoComprobante, 
                                                                           string prm_CodigoPersonaEntidad, 
                                                                           int? prm_codEmpleado, 
                                                                           string prm_CodigoArguDestinoComp, 
                                                                           int prm_NumeroRegistros)
        {
            List<BEComprobanteEmision> miLista = new List<BEComprobanteEmision>();
            try
            {
                using (_ConsultasGCDataContext SQLDC = new _ConsultasGCDataContext(conexion))
                {
                    var resul = SQLDC.omgc_R_RecordDeVentasCompras(prm_codEmpresa, 
                                                                   prm_FechaProcesoINI, 
                                                                   prm_FechaProcesoFIN, 
                                                                   prm_CodigoPuntoVenta, 
                                                                   prm_CodigoComprobante, 
                                                                   prm_CodigoPersonaEntidad, 
                                                                   prm_codEmpleado,
                                                                   prm_CodigoArguDestinoComp, 
                                                                   prm_NumeroRegistros);
                    int CONTADOR = 0;
                    foreach (var item in resul)
                    {
                        ++CONTADOR;
                        miLista.Add(new BEComprobanteEmision()
                        {
                            SegAnio = CONTADOR,
                            CodigoPersonaEntidad = item.CodigoPersonaEntidad,
                            EntidadRazonSocial = item.EntidadRazonSocial,
                            ValorTotalPrecioExtran = item.ValorTotalPrecioExtran == null ? 0 : Convert.ToDecimal(item.ValorTotalPrecioExtran),
                            ValorIGV = item.ValorIGV,
                            ValorTotalImpuesto = item.ValorTotalImpuesto == null ? 0 : Convert.ToDecimal(item.ValorTotalImpuesto),
                            ValorTotalPrecioVenta = item.ValorTotalPrecioVenta == null ? 0 : Convert.ToDecimal(item.ValorTotalPrecioVenta),
                            ValorTotalVenta = item.ValorTotalVenta == null ? 0 : Convert.ToDecimal(item.ValorTotalVenta),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        /// <summary>
        /// Listado del registro de ventas y compras
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEComprobanteEmision> ListRegistroDeVentasCompras(BaseFiltro pFiltro)
        {
            List<BEComprobanteEmision> miLista = new List<BEComprobanteEmision>();
            try
            {
                using (_ConsultasGCDataContext SQLDC = new _ConsultasGCDataContext(conexion))
                {
                    var resul = SQLDC.omgc_R_RegistroDeVentasCompras(pFiltro.codEmpresa,
                                                                     pFiltro.fecInicio,
                                                                     pFiltro.fecFinal, 
                                                                     pFiltro.codPuntoVenta, 
                                                                     pFiltro.codDocumento, 
                                                                     pFiltro.codPerEntidad,
                                                                     pFiltro.codEmpleado,
                                                                     pFiltro.codEmpleadoVendedor, 
                                                                     pFiltro.codRegDestinoDocum);
                    int CONTADOR = 0;
                    foreach (var item in resul)
                    {
                        ++CONTADOR;
                        miLista.Add(new BEComprobanteEmision()
                        {
                            SegAnio = CONTADOR,
                            FechaDeEmision = item.FechaDeEmision,
                            NumeroComprobante = item.NumeroComprobante,
                            EntidadNumeroRUC = item.EntidadNumeroRUC == null ? string.Empty : item.EntidadNumeroRUC,
                            CodigoPersonaEntidad = item.CodigoPersonaEntidad,
                            EntidadRazonSocial = item.EntidadRazonSocial == null ? string.Empty : item.EntidadRazonSocial,
                            CodigoArguEstadoDocu = item.CodigoArguEstadoDocu == null ? string.Empty : item.CodigoArguEstadoDocu,
                            CodigoArguEstadoDocuNombre = item.CodigoArguEstadoDocuNombre == null ? string.Empty : item.CodigoArguEstadoDocuNombre,
                            ValorTotalPrecioExtran = item.ValorTotalPrecioExtran,
                            ValorTotalImpuesto = item.ValorTotalImpuesto == null ? 0 : item.ValorTotalImpuesto.Value,
                            ValorTotalPrecioVenta = item.ValorTotalPrecioVenta == null ? 0 : item.ValorTotalPrecioVenta.Value,
                            ValorTotalVenta = item.ValorTotalVenta == null ? 0 : item.ValorTotalVenta.Value,
                            CodigoArguMoneda = item.CodigoArguMoneda,
                            CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            DocEsGravado = item.DocEsGravado,
                            ValorTipoCambioVTA = item.ValorTipoCambio == null ? 0 : item.ValorTipoCambio.Value,
                            codEmpleadoVendedor = item.codEmpleadoVendedor,
                            auxcodEmpleadoVendedorNombre = item.nomEmpleadoVendedor
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        public List<BEComprobanteEmision> ListRegistroDeVentasComprasContab(BaseFiltro pFiltro) 
        {
            List<BEComprobanteEmision> miLista = new List<BEComprobanteEmision>();
            try
            {
                using (_ConsultasGCDataContext SQLDC = new _ConsultasGCDataContext(conexion))
                {
                    var resul = SQLDC.omgc_R_RegistroDeVentasComprasContab(pFiltro.codEmpresa,
                                                                           pFiltro.fecInicio,
                                                                           pFiltro.fecFinal,
                                                                           pFiltro.codPuntoVenta,
                                                                           pFiltro.codDocumento,
                                                                           pFiltro.codPerEntidad,
                                                                           pFiltro.codEmpleado,
                                                                           pFiltro.codRegDestinoDocum);
                    int CONTADOR = 0;
                    foreach (var item in resul)
                    {
                        ++CONTADOR;
                        miLista.Add(new BEComprobanteEmision()
                        {
                            SegAnio = CONTADOR,
                            FechaDeEmision = item.FechaDeEmision,
                            NumeroComprobante = item.NumeroComprobante,
                            EntidadNumeroRUC = item.EntidadNumeroRUC == null ? string.Empty : item.EntidadNumeroRUC,
                            CodigoPersonaEntidad = item.CodigoPersonaEntidad,
                            EntidadRazonSocial = item.EntidadRazonSocial == null ? string.Empty : item.EntidadRazonSocial,
                            CodigoArguEstadoDocu = item.CodigoArguEstadoDocu,
                            CodigoArguEstadoDocuNombre = item.CodigoArguEstadoDocuNombre == null ? string.Empty : item.CodigoArguEstadoDocuNombre,
                            ValorTotalPrecioExtran = item.ValorTotalPrecioExtran,
                            ValorTotalImpuesto = item.ValorTotalImpuesto == null ? 0 : item.ValorTotalImpuesto.Value,
                            ValorTotalPrecioVenta = item.ValorTotalPrecioVenta == null ? 0 : item.ValorTotalPrecioVenta.Value,
                            ValorTotalVenta = item.ValorTotalVenta == null ? 0 : item.ValorTotalVenta.Value,
                            CodigoArguMoneda = item.CodigoArguMoneda,
                            CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            DocEsGravado = item.DocEsGravado,
                            ValorTipoCambioVTA = item.ValorTipoCambio == null ? 0 : item.ValorTipoCambio.Value,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        /// <summary>
        /// Listado del registro de ventas y compras es`pecificando el detalle
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEComprobanteEmisionDetalle> ListRegistroDeVentasComprasDetallado(BaseFiltro pFiltro)
        {
            List<BEComprobanteEmisionDetalle> lstComprobanteEmisionDetalle = new List<BEComprobanteEmisionDetalle>();
            try
            {
                using (_ConsultasGCDataContext SQLDC = new _ConsultasGCDataContext(conexion))
                {
                    var resul = SQLDC.omgc_R_RegistroDeVentasComprasDetallado(pFiltro.codEmpresa,
                                                                              pFiltro.fecInicio, 
                                                                              pFiltro.fecFinal,
                                                                              pFiltro.codPuntoVenta,
                                                                              pFiltro.codDocumento, 
                                                                              pFiltro.codPerEntidad, 
                                                                              pFiltro.codEmpleado,
                                                                              pFiltro.codEmpleadoVendedor,
                                                                              pFiltro.codRegDestinoDocum);
                    int CONTADOR = 0;
                    foreach (var item in resul)
                    {
                        ++CONTADOR;
                        lstComprobanteEmisionDetalle.Add(new BEComprobanteEmisionDetalle()
                        {
                            CodigoItemDetalle = CONTADOR.ToString(),
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            FechaDeEmision = item.FechaDeEmision,
                            NumeroComprobante = item.NumeroComprobante,
                            refEntidadNumeroRUC = item.EntidadNumeroRUC,
                            refCodigoPersonaEntidad = item.CodigoPersonaEntidad,
                            refCodigoPersonaEntidadNombre = item.EntidadRazonSocial,
                            CodigoArguEstadoDocu = item.CodigoArguEstadoDocu,
                            CodigoArguEstadoDocuNombre = item.CodigoArguEstadoDocuNombre,
                            refUbigeo = item.EntidadDireccionUbigeo,
                            CodigoProducto = item.CodigoProducto,
                            codProducto = item.codProducto,
                            Descripcion = item.Descripcion,
                            Cantidad = item.Cantidad,
                            UnitValorVenta = item.UnitValorVenta,
                            TotItemValorVenta = item.TotItemValorVenta,
                            TotItemValorIGV = item.TotItemValorIGV,
                            TotItemValorBruto = item.TotItemValorBruto == null ? 0 : Convert.ToDecimal(item.TotItemValorBruto),
                            refCodigoArguMoneda = item.CodigoArguMoneda,
                            refCodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            refValorTipoCambio = item.ValorTipoCambio,
                            
                            codEmpleadoVendedor = item.codEmpleadoVendedor,
                            auxcodEmpleadoVendedorNombre = item.nomVendedor,
                            CodigoArguUnidadMedPresen = item.nomUnidadMedida
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstComprobanteEmisionDetalle;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="pFiltro"></param>
        ///// <returns></returns>
        //public List<BEComprobanteEmision> ListComprobantesParaPDTMensual(BaseFiltro pFiltro)
        //{
        //    List<BEComprobanteEmision> miLista = new List<BEComprobanteEmision>();
        //    try
        //    {
        //        using (_ConsultasGCDataContext SQLDC = new _ConsultasGCDataContext(conexion))
        //        {
        //            var resul = SQLDC.omgc_R_DocumRegPDTMensual(pFiltro.codEmpresa, 
        //                                                        pFiltro.perTributario, 
        //                                                        pFiltro.codPuntoVenta, 
        //                                                        pFiltro.codDocumento,
        //                                                        pFiltro.numDocumento, 
        //                                                        pFiltro.codPerEntidad, 
        //                                                        pFiltro.codEmpleado);
        //            int CONTADOR = 0;
        //            foreach (var item in resul)
        //            {
        //                ++CONTADOR;
        //                miLista.Add(new BEComprobanteEmision()
        //                {
        //                    SegAnio = CONTADOR,
        //                    CodigoComprobante = item.CodigoComprobante,
        //                    CodigoComprobanteNombre = item.CodigoComprobanteNombre,
        //                    NumeroComprobante = item.NumeroComprobante,
        //                    CodigoArguEstadoDocu = item.CodigoArguEstadoDocu,
        //                    CodigoArguEstadoDocuNombre = item.CodigoArguEstadoDocuNombre,
        //                    CodigoArguMoneda = item.CodigoArguMoneda,
        //                    CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
        //                    EntidadNumeroRUC = item.EntidadNumeroRUC == null ? string.Empty : item.EntidadNumeroRUC,
        //                    EntidadRazonSocial = item.EntidadRazonSocial == null ? string.Empty : item.EntidadRazonSocial,
        //                    NumeroComprobanteExt = item.NumeroComprobanteExt == null ? string.Empty : item.NumeroComprobanteExt,
        //                    FechaDeEmision = item.FechaDeEmision,
        //                    ValorTipoCambioVTA = item.ValorTipoCambio,
        //                    ValorTotalVenta = item.ValorTotalVenta,
        //                    ValorTotalImpuesto = item.ValorTotalImpuesto,
        //                    ValorTotalPrecioExtran = item.ValorTotalPrecioExtran,
        //                    ValorTotalPrecioVenta = item.ValorTotalPrecioVenta,
        //                    SegMes = Convert.ToInt16(item.SegMes),
        //                    CodigoArguDestinoComp = item.CodigoArguDestinoComp,
        //                    CodigoArguDestinoCompNombre = item.CodigoArguDestinoCompNombre,
        //                    DocEsGravado = item.DocEsGravado,
        //                    FechaDeDeclaracion = item.FechaDeDeclaracion
        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return miLista;
        //}

        public List<BEComprobanteEmisionDetalle> ListPorEntidadesProductosVentasCompras(int prm_codEmpresa, 
                                                                                        string prm_CodigoPersonaEntidad, 
                                                                                        string prm_CodigoPuntoVenta, 
                                                                                        string prm_FechaDeEmisionINI, 
                                                                                        string prm_FechaDeEmisionFIN, 
                                                                                        string prm_CodigoArguDestinoComp, 
                                                                                        string prm_CodigoComprobante)
        {
            List<BEComprobanteEmisionDetalle> listaComprobanteEmisionDetalle = new List<BEComprobanteEmisionDetalle>();
            try
            {
                using (_ConsultasGCDataContext SQLDC = new _ConsultasGCDataContext(conexion))
                {
                    var resul = SQLDC.omgc_R_PorEntidadesProductoVentasCompras(prm_codEmpresa,
                                                                               prm_CodigoPersonaEntidad, 
                                                                                prm_CodigoPuntoVenta, 
                                                                                prm_FechaDeEmisionINI, 
                                                                                prm_FechaDeEmisionFIN, 
                                                                                prm_CodigoArguDestinoComp, 
                                                                                prm_CodigoComprobante);
                    foreach (var item in resul)
                    {
                        listaComprobanteEmisionDetalle.Add(new BEComprobanteEmisionDetalle()
                        {
                            FechaDeEmision = item.FechaDeEmision,
                            codProducto = item.codProducto == null ? 0 : item.codProducto.Value,
                            CodigoProducto = item.CodigoProducto,
                            Cantidad = item.Cantidad.Value,
                            UnitValorVenta = item.UnitValorVenta.Value,
                            TotItemValorVenta = item.TotItemValorVenta.Value,
                            refCodigoArguMoneda = item.CodigoArguMoneda,
                            refCodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            refTotItemValorVentaExtran = item.MonedaExtranjera == null ? 0 : Convert.ToDecimal(item.MonedaExtranjera),
                            Descripcion = item.Descripcion,
                            NumeroComprobante = item.NumeroComprobante,
                            refValorTipoCambio = item.ValorTipoCambioVTA == null ? 0 : Convert.ToDecimal(item.ValorTipoCambioVTA),
                            SegUsuarioEdita = item.SegUsuarioEdita,

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaComprobanteEmisionDetalle;
        }

        public List<InventarioAux> ListProductosReporteDeInventario(string prm_codEmpresaRUC, 
                                                                    string prm_FechaDeEmisionINI, 
                                                                    string prm_FechaDeEmisionFIN, 
                                                                    string prm_CodigoPuntoVenta, 
                                                                    string prm_codDeposito, 
                                                                    string prm_Periodo, 
                                                                    string prm_desAgrupacion)
        {
            List<InventarioAux> listaInventario = new List<InventarioAux>();
            try
            {
                using (_ConsultasGCDataContext SQLDC = new _ConsultasGCDataContext(conexion))
                {
                    var resul = SQLDC.omgc_R_ProductoInventario(prm_codEmpresaRUC, 
                                                                prm_FechaDeEmisionINI, 
                                                                prm_FechaDeEmisionFIN, 
                                                                prm_CodigoPuntoVenta, 
                                                                prm_codDeposito, 
                                                                prm_Periodo, 
                                                                prm_desAgrupacion);
                    foreach (var item in resul)
                    {
                        listaInventario.Add(new InventarioAux()
                        {
                            Periodo = item.Periodo,
                            CodigoPersonaEmpre = item.CodigoPersonaEmpre,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            codDeposito = Extensors.CheckInt(item.codDeposito),
                            codDepositoNombre = item.codDepositoNombre,
                            codProducto = item.codProducto,
                            CodigoProducto = item.CodigoProducto,
                            CodigoProductoNombre = item.CodigoProductoNombre,
                            StockMinimo = item.StockMinimo == null ? 0 : item.StockMinimo.Value,
                            StockMaximo = item.StockMaximo == null ? 0 : item.StockMaximo.Value,
                            StockInicial = item.StockInicial ,
                            StockFisico = item.StockFisico,
                            StockComprometido = item.StoskComprometido,
                            Conteo01 = item.Conteo01,
                            Conteo02 = item.Conteo02,
                            Conteo03 = item.Conteo03,
                            Conteo04 = item.Conteo04,
                            segFechaEdita = item.SegFechaEdita,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            desAgrupacion = item.desAgrupacion
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listaInventario;
        }

        public DataTable ListNumerosDeSerie(string prmProvider, string prmDataSourceFile, string prmExtended, string prmNameRange)
        {
            // Crear el nuevo DataSet para que aloje la información de la hoja de cálculo. 
            DataSet objDataset1 = new DataSet();
            try
            {
                // Crear la variable de cadena de conexión. Modificar el parámetro "Origen de datos" // según corresponda en el entorno. 
                //String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Server.MapPath("../ExcelData.xls") + ";" + "Extended Properties=Excel 8.0;";
                String sConnectionString = prmProvider + " Data Source=" + prmDataSourceFile + "; " + " Extended Properties=" + prmExtended;
                // Crear el objeto de conexión utilizando la cadena de conexión anterior. 
                OleDbConnection objConn = new OleDbConnection(sConnectionString);

                // Abrir la conexión con la base de datos. 
                objConn.Open();

                // El código utiliza un comando SQL SELECT para mostrar los datos de la hoja de cálculo.
                // Crear un nuevo OleDbCommand para devolver los datos de la hoja de cálculo. 
                OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM " + prmNameRange, objConn);

                // Crear un nuevo OleDbDataAdapter que se usa para generar un DataSet 
                // basado en la instrucción SQL SELECT anterior. 
                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();

                // Pasar el comando Select al adaptador. 
                objAdapter1.SelectCommand = objCmdSelect;


                // Llenar el DataSet con la información de la hoja de cálculo. 
                objAdapter1.Fill(objDataset1, "XLData");

                // Enlazar los datos al control DataGrid. 
                //DataGrid1.DataSource = objDataset1.Tables[0].DefaultView; DataGrid1.DataBind();

                // Limpiar los objetos. 
                objConn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objDataset1.Tables[0];
        }

        public List<vwProductoConsignacion> ListProductoConsignacion(BaseFiltroProductoConsignacion pFiltro)
        {
            List<vwProductoConsignacion> lstProductoConsignacion = new List<vwProductoConsignacion>();
            try
            {
                using (_ConsultasGCDataContext SQLDC = new _ConsultasGCDataContext(conexion))
                {
                    var resul = SQLDC.omgc_R_Producto_Consignacion(pFiltro.codEmpresa,
                                                                   pFiltro.fecInicio, 
                                                                   pFiltro.fecFinal, 
                                                                   pFiltro.codProducto, 
                                                                   pFiltro.codPuntoVenta, 
                                                                   pFiltro.codPerEntidad, 
                                                                   pFiltro.codDocumento, 
                                                                   pFiltro.numDocumento, 
                                                                   pFiltro.numSerieProducto);
                    int contador = 1;
                    foreach (var item in resul)
                    {
                        lstProductoConsignacion.Add(new vwProductoConsignacion()
                        {
                            codItem = contador,
                            codDocumReg = item.codDocumReg,
                            cntStockMovimi = item.cntStockMovimi,
                            codCliente = item.codCliente,
                            codProducto = item.CodigoProducto,
                            fecConsignacion = item.fecConsignacion,
                            nomDescripcion = item.nomDescripcion,
                            nomRazonSocial = item.nomRazonSocial,
                            numGuiaRemision = item.numGuiaRemision,
                            numLote = item.numLote,
                            numSerie = item.numSerie,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                        });
                        ++contador;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstProductoConsignacion;
        }

        public List<vwProductoInventario> ListProductoReporteDeInventarioActual(BaseFiltroInventarioActual pFiltro)
        {
            List<vwProductoInventario> listaInventarioActual = new List<vwProductoInventario>();
            try
            {
                using (_ConsultasGCDataContext SQLDC = new _ConsultasGCDataContext(conexion))
                {
                    var resul = SQLDC.omgc_R_ProductoInventarioActual(pFiltro.codEmpresa,
                                                                      pFiltro.codPerEmpresaRUC,
                                                                      pFiltro.codPuntoVenta, 
                                                                      Extensors.CheckStr(pFiltro.codAlmacen), 
                                                                      pFiltro.codGrupo, 
                                                                      pFiltro.codRegCategoria);
                    foreach (var item in resul)
                    {
                        listaInventarioActual.Add(new vwProductoInventario()
                        {
                            codPerEmpresa = item.CodigoPersonaEmpre,
                            codPuntoVenta = item.CodigoPuntoVenta,
                            codDeposito = item.codDeposito,
                            codDepositoNombre = item.codDepositoNombre,
                            codProducto = item.codProducto.ToString(),
                            codigoProducto = item.CodigoProducto,
                            codProductoNombre = item.CodigoProductoNombre,
                            cntStockMinimo = item.StockMinimo == null ? 0 : item.StockMinimo.Value,
                            cntStockInicial = item.StockInicial,
                            cntStockFisico = item.StockFisico,
                            cntStockComprometido = item.StoskComprometido,
                            audFechaActualizacion = item.SegFechaEdita.HasValue ? item.SegFechaEdita.ToString() : string.Empty,
                            audUsuarioActualizacion = item.SegUsuarioEdita,
                            codGrupoNombre = item.codGrupoNombre,
                            codRegCategoriaNombre = item.codRegCategoriaNombre,
                            indSeriado = item.EsConNumeroSeriado ? "SI" : "NO",
                            monTotalCosto = item.Total_Costo.HasValue ? item.Total_Costo.Value : 0,
                            monValorCosto = item.ValorCosto,
                            numOIDUA = item.numOIDUA,
                            numOI = item.numOrdenImportacion,


                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listaInventarioActual;
        }

    }
}

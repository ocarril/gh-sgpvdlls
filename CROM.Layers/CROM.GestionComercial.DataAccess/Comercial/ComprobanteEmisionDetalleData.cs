namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.Almacen;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.ComprobanteEmisionDetalleData.cs]
    /// </summary>
    public class ComprobanteEmisionDetalleData
    {
        private string conexion = string.Empty;
        public ComprobanteEmisionDetalleData()
        {
            conexion = Util.ConexionBD();
        }
        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ComprobanteEmisionDetalle
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmisionDetalle]
        /// <summary>
        /// <param name = >itemComprobanteEmisionDetalle</param>
        public int? Insert(BEComprobanteEmisionDetalle comprobanteEmisionDetalle)
        {
            int? codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_I_DocumRegDetalle(
                       ref codigoRetorno,
                       comprobanteEmisionDetalle.codDocumReg,
                       comprobanteEmisionDetalle.CodigoItemDetalle,
                       comprobanteEmisionDetalle.codProducto,
                       comprobanteEmisionDetalle.CodigoArguUnidadMed,
                       Convert.ToByte(comprobanteEmisionDetalle.CantiDecimales),
                       comprobanteEmisionDetalle.IncluyeIGV,
                       comprobanteEmisionDetalle.CantidadPendente,
                       comprobanteEmisionDetalle.Cantidad,
                       comprobanteEmisionDetalle.UnitDescuento,
                       comprobanteEmisionDetalle.UnitValorCosto,
                       comprobanteEmisionDetalle.UnitPrecioBruto,
                       comprobanteEmisionDetalle.UnitPrecioSinIGV,
                       comprobanteEmisionDetalle.UnitValorDscto,
                       comprobanteEmisionDetalle.UnitValorVenta,
                       comprobanteEmisionDetalle.UnitValorIGV,
                       comprobanteEmisionDetalle.TotItemValorBruto,
                       comprobanteEmisionDetalle.TotItemValorDscto,
                       comprobanteEmisionDetalle.TotItemValorVenta,
                       comprobanteEmisionDetalle.TotItemValorIGV,
                       comprobanteEmisionDetalle.Descripcion,
                       comprobanteEmisionDetalle.CodigoArguTipoProducto,
                       comprobanteEmisionDetalle.EsVerificarStock,
                       comprobanteEmisionDetalle.CodigoCuenta,
                       comprobanteEmisionDetalle.CodigoArguDepositoAlm,
                       comprobanteEmisionDetalle.CodigoArguGarantiaProd == string.Empty ? null : comprobanteEmisionDetalle.CodigoArguGarantiaProd,
                       comprobanteEmisionDetalle.CodigoPartida,
                       comprobanteEmisionDetalle.CodigoCentroCosto,
                       comprobanteEmisionDetalle.CodigoListaPrecio,
                       comprobanteEmisionDetalle.codEmpleadoVendedor,
                       comprobanteEmisionDetalle.Valor_ITC,
                       comprobanteEmisionDetalle.Escanner,
                       comprobanteEmisionDetalle.SegUsuarioCrea,
                       comprobanteEmisionDetalle.PesoUnitario,
                       comprobanteEmisionDetalle.SegMaquina,
                       comprobanteEmisionDetalle.codTipoTributoISC,
                       comprobanteEmisionDetalle.mtoIscItem,
                       comprobanteEmisionDetalle.mtoBaseIscItem,
                       comprobanteEmisionDetalle.codTipoCalculoISC,
                       comprobanteEmisionDetalle.porIscItem,
                       comprobanteEmisionDetalle.codTipoTributoOtro,
                       comprobanteEmisionDetalle.mtoTriOtroItem,
                       comprobanteEmisionDetalle.mtoBaseTriOtroItem,
                       comprobanteEmisionDetalle.porTriOtroItem,
                       comprobanteEmisionDetalle.mtoValorReferencialUnitario,
                       comprobanteEmisionDetalle.gloObservacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno;
        }

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ComprobanteEmisionDetalle
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmisionDetalle]
        /// <summary>
        /// <param name = >itemComprobanteEmisionDetalle</param>
        public int? Insert(List<BEComprobanteEmisionDetalle> lstComprobanteEmisionDetalle)
        {
            int? codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    foreach (BEComprobanteEmisionDetalle comprobanteEmisionDetalle in lstComprobanteEmisionDetalle)
                    {
                        SQLDC.omgc_I_DocumRegDetalle(
                           ref codigoRetorno,
                           comprobanteEmisionDetalle.codDocumReg,
                          comprobanteEmisionDetalle.CodigoItemDetalle,
                          comprobanteEmisionDetalle.codProducto,
                          comprobanteEmisionDetalle.CodigoArguUnidadMed,
                          Convert.ToByte(comprobanteEmisionDetalle.CantiDecimales),
                          comprobanteEmisionDetalle.IncluyeIGV,
                          comprobanteEmisionDetalle.CantidadPendente,
                          comprobanteEmisionDetalle.Cantidad,
                          comprobanteEmisionDetalle.UnitDescuento,
                          comprobanteEmisionDetalle.UnitValorCosto,
                          comprobanteEmisionDetalle.UnitPrecioBruto,
                          comprobanteEmisionDetalle.UnitPrecioSinIGV,
                          comprobanteEmisionDetalle.UnitValorDscto,
                          comprobanteEmisionDetalle.UnitValorVenta,
                          comprobanteEmisionDetalle.UnitValorIGV,
                          comprobanteEmisionDetalle.TotItemValorBruto,
                          comprobanteEmisionDetalle.TotItemValorDscto,
                          comprobanteEmisionDetalle.TotItemValorVenta,
                          comprobanteEmisionDetalle.TotItemValorIGV,
                          comprobanteEmisionDetalle.Descripcion,
                          comprobanteEmisionDetalle.CodigoArguTipoProducto,
                          comprobanteEmisionDetalle.EsVerificarStock,
                          comprobanteEmisionDetalle.CodigoCuenta,
                          comprobanteEmisionDetalle.CodigoArguDepositoAlm,
                          comprobanteEmisionDetalle.CodigoArguGarantiaProd == string.Empty ? null : comprobanteEmisionDetalle.CodigoArguGarantiaProd,
                          comprobanteEmisionDetalle.CodigoPartida,
                          comprobanteEmisionDetalle.CodigoCentroCosto,
                          comprobanteEmisionDetalle.CodigoListaPrecio,
                          comprobanteEmisionDetalle.codEmpleadoVendedor,
                          comprobanteEmisionDetalle.Valor_ITC,
                          comprobanteEmisionDetalle.Escanner,
                          comprobanteEmisionDetalle.SegUsuarioCrea,
                          comprobanteEmisionDetalle.PesoUnitario,
                          comprobanteEmisionDetalle.SegMaquina,
                          comprobanteEmisionDetalle.codTipoTributoISC,
                          comprobanteEmisionDetalle.mtoIscItem,
                          comprobanteEmisionDetalle.mtoBaseIscItem,
                          comprobanteEmisionDetalle.codTipoCalculoISC,
                          comprobanteEmisionDetalle.porIscItem,
                          comprobanteEmisionDetalle.codTipoTributoOtro,
                          comprobanteEmisionDetalle.mtoTriOtroItem,
                          comprobanteEmisionDetalle.mtoBaseTriOtroItem,
                          comprobanteEmisionDetalle.porTriOtroItem,
                          comprobanteEmisionDetalle.mtoValorReferencialUnitario,
                          comprobanteEmisionDetalle.gloObservacion

                          );

                        comprobanteEmisionDetalle.codDocumRegDetalle = codigoRetorno.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno;
        }
    
        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.ComprobanteEmisionDetalle
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmisionDetalle]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(int prm_codDocumReg)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_DocumRegDetalle(prm_codDocumReg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobanteEmisionDetalle
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmisionDetalle]
        /// <summary>
        /// <param name="prm_codDocumReg"></param>
        /// <param name="prm_CodigoItemDetalle"></param>
        /// <returns></returns>
        public List<BEComprobanteEmisionDetalle> List(int pcodEmpresa, int prm_codDocumReg, string prm_CodigoItemDetalle)
        {
            List<BEComprobanteEmisionDetalle> listaComprobanteEmisionDetalle = new List<BEComprobanteEmisionDetalle>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumRegDetalle(pcodEmpresa, 
                                                             prm_codDocumReg, 
                                                             prm_CodigoItemDetalle);
                    foreach (var item in resul)
                    {
                        listaComprobanteEmisionDetalle.Add(new BEComprobanteEmisionDetalle()
                        {
                            codDocumReg = item.codDocumReg,
                            codDocumRegDetalle = item.codDocumRegDetalle,
                            codProducto = item.codProducto,
                            codEmpresa = item.codEmpresa,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            NumeroComprobante = item.NumeroComprobante,
                            CodigoItemDetalle = item.CodigoItemDetalle,
                            CodigoComprobante = item.CodigoComprobante,
                            FechaDeEmision = item.FechaDeEmision,
                            CodigoProducto = item.CodigoProducto,
                            CodigoArguUnidadMed = item.CodigoArguUnidadMed,
                            CodigoArguUnidadMedNombre = item.CodigoArguUnidadMedNombre,
                            CodigoArguUnidadMedPresen = item.CodigoArguUnidadMedPresen,
                            CantiDecimales = item.CantiDecimales,
                            IncluyeIGV = item.IncluyeIGV,
                            CantidadPendente = item.CantidadPendente,
                            Cantidad = item.Cantidad,
                            UnitDescuento = item.UnitDescuento * 100,
                            UnitValorCosto = item.UnitValorCosto,
                            UnitPrecioBruto = item.UnitPrecioBruto,
                            UnitPrecioSinIGV = item.UnitPrecioSinIGV,
                            UnitValorDscto = item.UnitValorDscto,
                            UnitValorVenta = item.UnitValorVenta,
                            UnitValorIGV = item.UnitValorIGV,
                            TotItemValorBruto = item.TotItemValorBruto,
                            TotItemValorDscto = item.TotItemValorDscto,
                            TotItemValorVenta = item.TotItemValorVenta,
                            TotItemValorIGV = item.TotItemValorIGV,
                            Descripcion = item.Descripcion,
                            CodigoArguTipoProducto = item.CodigoArguTipoProducto,
                            CodigoArguTipoProductoNombre = item.CodigoArguTipoProductoNombre,
                            CodigoArguDestinoComp = item.CodigoArguDestinoComp,
                            CodigoArguDestinoCompNombre = item.CodigoArguDestinoCompNombre,
                            EsVerificarStock = item.EsVerificarStock,
                            CodigoCuenta = item.CodigoCuenta,
                            CodigoArguDepositoAlm = item.codDeposito,
                            CodigoArguDepositoAlmNombre = item.codDepositoNombre,
                            CodigoArguEstadoDocu = item.CodigoArguEstadoDocu,
                            CodigoArguEstadoDocuNombre = item.CodigoArguEstadoDocuNombre,
                            CodigoArguGarantiaProd = item.CodigoArguGarantiaProd,
                            CodigoArguGarantiaProdNombre = item.CodigoArguGarantiaProdNombre,
                            CodigoPartida = item.CodigoPartida,
                            CodigoCentroCosto = item.CodigoCentroCosto,
                            CodigoListaPrecio = item.CodigoListaPrecio,
                            codEmpleadoVendedor = item.codEmpleadoVendedor,
                            auxcodEmpleadoVendedorNombre = item.codEmpleadoVendedorNombre,
                            Valor_ITC = item.Valor_ITC,
                            Escanner = item.Escanner,
                            Estado = item.Estado,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaCrea = item.SegFechaCrea,
                            SegFechaEdita = item.SegFechaEdita,
                            SegMaquina = item.SegMaquina,
                            PesoUnitario = item.PesoTotal
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
       
        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobanteEmisionDetalle
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmisionDetalle]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<BEComprobanteEmisionDetalle> ListProductoComercializado(BaseFiltro filtro)
        {
            List<BEComprobanteEmisionDetalle> comprobanteEmisionDetalle = new List<BEComprobanteEmisionDetalle>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumRegDetalle_ProductoComprado(filtro.codRegDestinoDocum, 
                                                                              filtro.codPerEntidad, 
                                                                              filtro.codProducto);
                    foreach (var item in resul)
                    {
                        comprobanteEmisionDetalle.Add(new BEComprobanteEmisionDetalle()
                        {
                            codDocumReg = item.codDocumReg,
                            codDocumRegDetalle = item.codDocumRegDetalle,
                            NumeroComprobante = item.NumeroComprobante,
                            FechaDeEmision = item.FechaDeEmision,
                            codProducto = item.codProducto,
                            CodigoProducto = item.codigoProducto,
                            CodigoArguUnidadMedNombre = item.CodigoArguUnidadMedNombre,
                            Cantidad = item.Cantidad,
                            UnitPrecioSinIGV = item.UnitPrecioSinIGV,
                            UnitValorVenta = item.UnitValorVenta,
                            TotItemValorBruto = item.TotItemValorBruto,
                            TotItemValorVenta = item.TotItemValorVenta,
                            Descripcion = item.Descripcion,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegMaquina = item.SegMaquina
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return comprobanteEmisionDetalle;
        }

        #endregion

    }
} 

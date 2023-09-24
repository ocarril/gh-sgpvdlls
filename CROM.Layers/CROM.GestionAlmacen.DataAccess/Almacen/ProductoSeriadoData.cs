namespace CROM.GestionAlmacen.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Almacen;
    using CROM.Tools.Comun;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 04/02/2010-04:01:30 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Almacen.ProductoSeriadosData.cs]
    /// </summary>
    public class ProductoSeriadoData
    {
        private string conexion = string.Empty;
        public ProductoSeriadoData()
        {
            conexion = Util.ConexionBD();
        }
        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoSeriados
        /// En la BASE de DATO la Tabla : [Almacen.ProductoSeriados]
        /// <summary>
        /// <param name="productoSeriado"></param>
        /// <returns></returns>
        public int Insert(BEProductoSeriado productoSeriado)
        {
            int? codigoRetorno = null;
            string codigoRetornoRef = null;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    SQLDC.omgc_I_ProductoSeriado(
                    ref codigoRetorno,
                    ref codigoRetornoRef,
                    Extensors.CheckStr(productoSeriado.codDeposito),
                    productoSeriado.codProducto,
                    productoSeriado.FechaIngreso,
                    productoSeriado.FechaVencimiento,
                    productoSeriado.NumeroLote == null ? string.Empty : productoSeriado.NumeroLote,
                    productoSeriado.NumeroSerie == null ? string.Empty : productoSeriado.NumeroSerie,
                    productoSeriado.CodigoPersonaProveedor,
                    productoSeriado.Cantidad,
                    productoSeriado.EstadoVendido,
                    productoSeriado.CodigoPersonaCliente,
                    productoSeriado.EstaComprometido,
                    productoSeriado.FechaVenta,
                    productoSeriado.Estado,
                    productoSeriado.SegUsuarioCrea,
                    productoSeriado.CodigoPersonaEmpre,
                    productoSeriado.CodigoPuntoVenta,
                    productoSeriado.NumeroComprobanteVenta,
                    productoSeriado.FechaComprometido,
                    productoSeriado.NumeroComprobanteComprom,
                    productoSeriado.NumeroComprobanteCompra,
                    productoSeriado.CodigoPersonaComprometido,
                    productoSeriado.codRegEstadoMercaderia,
                    productoSeriado.perInventario,
                    productoSeriado.indRegularizar
                    );
                    productoSeriado.codProductoSeriado = codigoRetorno.Value;
                    productoSeriado.CodigoRegistro = codigoRetornoRef;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == null ? 0 : codigoRetorno.Value;
        }

        public List<BEProductoSeriado> Insert(List<BEProductoSeriado> lstProductoSeriado)
        {
            int? codigoRetorno = null;
            string codigoRetornoRef = null;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    foreach (BEProductoSeriado productoSeriado in lstProductoSeriado)
                    {
                        SQLDC.omgc_I_ProductoSeriado(
                        ref codigoRetorno,
                        ref codigoRetornoRef,
                        Extensors.CheckStr(productoSeriado.codDeposito),
                        productoSeriado.codProducto,
                        productoSeriado.FechaIngreso,
                        productoSeriado.FechaVencimiento,
                        productoSeriado.NumeroLote == null ? string.Empty : productoSeriado.NumeroLote,
                        productoSeriado.NumeroSerie == null ? string.Empty : productoSeriado.NumeroSerie,
                        productoSeriado.CodigoPersonaProveedor,
                        productoSeriado.Cantidad,
                        productoSeriado.EstadoVendido,
                        productoSeriado.CodigoPersonaCliente,
                        productoSeriado.EstaComprometido,
                        productoSeriado.FechaVenta,
                        productoSeriado.Estado,
                        productoSeriado.SegUsuarioCrea,
                        productoSeriado.CodigoPersonaEmpre,
                        productoSeriado.CodigoPuntoVenta,
                        productoSeriado.NumeroComprobanteVenta,
                        productoSeriado.FechaComprometido,
                        productoSeriado.NumeroComprobanteComprom,
                        productoSeriado.NumeroComprobanteCompra,
                        productoSeriado.CodigoPersonaComprometido,
                        productoSeriado.codRegEstadoMercaderia,
                        productoSeriado.perInventario,
                        productoSeriado.indRegularizar
                        );
                        productoSeriado.codProductoSeriado = codigoRetorno.Value;
                        productoSeriado.CodigoRegistro = codigoRetornoRef;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductoSeriado;
        }
     
        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoSeriados
        /// En la BASE de DATO la Tabla : [Almacen.ProductoSeriados]
        /// <summary>
        /// <param name="productoSeriado"></param>
        /// <returns></returns>
        public bool Update(List<BEProductoSeriado> lstProductoSeriado)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    foreach (BEProductoSeriado productoSeriado in lstProductoSeriado)
                        codigoRetorno = SQLDC.omgc_U_ProductoSeriadoRetirar(
                        productoSeriado.codProductoSeriado,
                        productoSeriado.CodigoRegistro,
                        Extensors.CheckStr(productoSeriado.codDeposito),
                        productoSeriado.codProducto,
                        productoSeriado.FechaIngreso,
                        productoSeriado.FechaVencimiento,
                        productoSeriado.NumeroLote,
                        productoSeriado.NumeroSerie,
                        productoSeriado.CodigoPersonaProveedor,
                        productoSeriado.Cantidad,
                        productoSeriado.EstadoVendido,
                        productoSeriado.CodigoPersonaCliente,
                        productoSeriado.EstaComprometido,
                        productoSeriado.FechaVenta,
                        productoSeriado.Estado,
                        productoSeriado.SegUsuarioEdita,
                        productoSeriado.NumeroComprobanteVenta,
                        productoSeriado.FechaComprometido,
                        productoSeriado.NumeroComprobanteComprom,
                        productoSeriado.NumeroComprobanteCompra,
                        productoSeriado.CodigoPersonaComprometido,
                        productoSeriado.codRegEstadoMercaderia);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
        public bool UpdateDatoIngreso(List<BEProductoSeriado> lstProductoSeriado)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    foreach (BEProductoSeriado productoSeriado in lstProductoSeriado)
                    {
                        codigoRetorno = SQLDC.omgc_U_ProductoSeriado(
                            productoSeriado.codProductoSeriado,
                            productoSeriado.CodigoPuntoVenta,
                            Extensors.CheckStr(productoSeriado.codDeposito),
                            productoSeriado.codProducto,
                            productoSeriado.FechaIngreso,
                            productoSeriado.FechaVencimiento,
                            productoSeriado.NumeroLote,
                            productoSeriado.NumeroSerie,
                            productoSeriado.Estado,
                            productoSeriado.SegUsuarioEdita,
                            productoSeriado.codRegEstadoMercaderia);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
        public bool UpdateConsignacion(List<BEProductoSeriado> lstProductoSeriado)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    foreach (BEProductoSeriado productoSeriado in lstProductoSeriado)
                    {
                        codigoRetorno = SQLDC.omgc_U_ProductoSeriado_Consignacion(productoSeriado.codProductoSeriado,
                                                                                  productoSeriado.codProducto,
                                                                                  productoSeriado.SegUsuarioEdita,
                                                                                  productoSeriado.codRegEstadoMercaderia);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.ProductoSeriados
        /// En la BASE de DATO la Tabla : [Almacen.ProductoSeriados]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public bool Delete(BaseFiltroAlmacen filtro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_ProductoSeriado(filtro.codId, 
                                                                 filtro.codProducto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
        public bool DeleteDetalleDocum(BaseFiltroAlmacen filtro)
        {
            int codigoRetorno = -1;
            int? numNulo = null;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_ProductoSeriadoDetalle(filtro.codId, 
                                                                        filtro.codProducto, 
                                                                        filtro.codDocumReg == 0 ? numNulo : filtro.codDocumRegDetalle);
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
        /// Retorna un LISTA de registros de la Entidad Almacen.ProductoSeriados
        /// En la BASE de DATO la Tabla : [Almacen.ProductoSeriados]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<BEProductoSeriado> List(BaseFiltroProductoSeriado filtro) 
        {
            List<BEProductoSeriado> lstProductoSeriado = new List<BEProductoSeriado>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.usp_sgcfe_R_ProductoSeriado(filtro.codEmpresaRUC, 
                                                             filtro.codEmpresa,
                                                             filtro.codDeposito, 
                                                             filtro.codPuntoVenta,
                                                             filtro.codItem, 
                                                             filtro.codProducto, 
                                                             filtro.numDocumentoCompromiso,
                                                             filtro.numDocumentoVenta, 
                                                             filtro.numDocumentoCompra, 
                                                             filtro.indComprometido,
                                                             filtro.indVendido, 
                                                             filtro.codRegEstadoMercaderia);

                    foreach (var item in resul)
                    {
                        lstProductoSeriado.Add(new BEProductoSeriado()
                        {
                            codProductoSeriado = item.codProductoSeriado,
                            codProducto = item.codProducto,
                            FechaIngreso = item.FechaIngreso,
                            FechaVencimiento = item.FechaVencimiento,
                            NumeroLote = item.NumeroLote,
                            NumeroSerie = item.NumeroSerie,
                            CodigoPersonaProveedor = item.CodigoPersonaProveedor,
                            Cantidad = item.Cantidad,
                            EstadoVendido = item.EstadoVendido,
                            CodigoPersonaCliente = item.CodigoPersonaCliente,
                            EstaComprometido = item.EstaComprometido,
                            FechaVenta = item.FechaVenta,
                            Estado = item.Estado,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaCrea = item.SegFechaCrea,
                            SegFechaEdita = item.SegFechaEdita,
                            SegMaquina = item.SegMaquina,
                            CodigoPersonaClienteNombre = item.CodigoPersonaClienteNombre,
                            CodigoPersonaEmpre = item.CodigoPersonaEmpre,
                            CodigoPersonaEmpreNombre = item.CodigoPersonaEmpreNombre,
                            CodigoPersonaProveedorNombre = item.CodigoPersonaProveedorNombre,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
                            FechaComprometido = item.FechaComprometido,
                            NumeroComprobanteComprom = item.NumeroComprobanteComprom,
                            NumeroComprobanteVenta = item.NumeroComprobanteVenta,
                            NumeroComprobanteCompra = item.NumeroComprobanteCompra,
                            CodigoPersonaComprometido = item.CodigoPersonaComprometido,
                            CodigoPersonaComprometidoNombre = item.CodigoPersonaComprometidoNombre,
                            codDeposito = Extensors.CheckInt(item.codDeposito),
                            codDepositoNombre = item.codDepositoNombre,
                            CodigoRegistro = item.CodigoRegistro,
                            codigoProducto = item.CodigoProducto,
                            codRegEstadoMercaderia = item.codRegEstadoMercaderia,
                            codRegEstadoMercaderiaNombre = item.codRegEstadoMercaderiaNombre,
                            indRegularizar = item.indRegularizar,
                            perInventario = item.perInventario
                        }); ;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductoSeriado;
        }

        #endregion

    }
} 

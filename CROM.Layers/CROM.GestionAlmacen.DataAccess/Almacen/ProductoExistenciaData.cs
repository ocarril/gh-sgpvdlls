namespace CROM.GestionAlmacen.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Almacen;
    using CROM.Tools.Comun;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Almacen.ProductoExistenciasData.cs]
    /// </summary>
    public class ProductoExistenciaData
    {
        private string conexion = string.Empty;

        public ProductoExistenciaData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        ///// <summary>
        ///// Almacena el registro de una ENTIDAD de registro de Tipo ProductoExistencias
        ///// En la BASE de DATO la Tabla : [Almacen.ProductoExistencias]
        ///// <summary>
        ///// <param name="productoExistencia"></param>
        ///// <returns></returns>
        //public int InsertUpdate(BEProductoExistencia productoExistencia)
        //{
        //    int? codigoRetorno = -1;
        //    try
        //    {
        //        using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
        //        {
        //            SQLDC.omgc_I_ProductoExistencia
        //              (ref codigoRetorno,
        //              productoExistencia.codProducto,
        //              productoExistencia.codDeposito,
        //              productoExistencia.Estado,
        //              productoExistencia.segUsuarioCrea,
        //              productoExistencia.segMaquinaEdita);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == null ? 0 : codigoRetorno.Value;
        //}

        #endregion

        #region /* Proceso de UPDATE RECORD - ACTUALIZADOR DE STOCKS*/

        /// <summary>
        /// ACTUALIZA el registro de una ENTIDAD de registro de Tipo ProductoExistencias
        /// En la BASE de DATO la Tabla : [Almacen.ProductoExistencias]
        /// <summary>
        /// <param name="pUpdate"></param>
        /// <param name="prm_SALDO_StockFisico"></param>
        /// <returns></returns>
        public int UpdateStockInicial(BEProductoExistenciaUpdate pUpdate, ref decimal? prm_SALDO_StockFisico)
        {
            int? codigoRetorno = null;
            try
            {
                prm_SALDO_StockFisico = null;
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var result = SQLDC.omgc_I_ProductoExistencia_StockInicial(
                        ref codigoRetorno,
                        pUpdate.codEmpresa,
                        pUpdate.codProducto,
                        Extensors.CheckStr(pUpdate.codDeposito),
                        pUpdate.cntStockInicial,
                        pUpdate.segUsuarioEdita,
                        pUpdate.segMaquinaEdita,
                        ref prm_SALDO_StockFisico);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == null ? 0 : codigoRetorno.Value;
        }

        public bool UpdateStockInicial(BEProductoExistenciaStockUpdate pFiltro)
        {
            int? codigoRetorno = null;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var result = SQLDC.omgc_U_ProductoExistencia_StockInicial(pFiltro.codEmpresa,
                                                                              pFiltro.codProducto,
                                                                              Extensors.CheckStr(pFiltro.codDeposito),
                                                                              pFiltro.cntStockInicial,
                                                                              pFiltro.segUsuarioEdita,
                                                                              pFiltro.segMaquinaEdita);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        /// <summary>
        /// ACTUALIZA StockFisico el registro de una ENTIDAD de registro de Tipo ProductoExistencias
        /// En la BASE de DATO la Tabla : [Almacen.ProductoExistencias]
        /// <summary>
        /// <param name="pUpdate"></param>
        /// <param name="prm_SALDO_StockFisico"></param>
        public bool UpdateStockFisico(BEProductoExistenciaStockUpdate pUpdate, ref decimal? prm_SALDO_StockFisico)
        {
            int codRetorno = -1;
            try
            {
                prm_SALDO_StockFisico = null;
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    codRetorno = SQLDC.omgc_U_ProductoExistencia_StockFisico(
                        pUpdate.codEmpresa,
                        pUpdate.codProducto,
                        Extensors.CheckStr(pUpdate.codDeposito),
                        pUpdate.cntStockFisico,
                        pUpdate.indOperador,
                        pUpdate.segUsuarioEdita,
                        pUpdate.numDocumentoReferencia,
                        pUpdate.codPerEntidad,
                        pUpdate.segMaquinaEdita,
                        ref prm_SALDO_StockFisico);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codRetorno == 0 ? true : false;
        }

        public bool UpdateStockFisicoConsig(BEProductoExistenciaStockUpdate pUpdate, ref decimal? prm_SALDO_StockFisico)
        {
            int codRetorno = -1;
            try
            {
                prm_SALDO_StockFisico = null;
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    codRetorno = SQLDC.omgc_U_ProductoExistencia_StockFisicoConsig(pUpdate.codEmpresa, pUpdate.codProducto,
                                                                                    Extensors.CheckStr(pUpdate.codDeposito),
                                                                                    pUpdate.cntStockFisico,
                                                                                    pUpdate.indOperador,
                                                                                    pUpdate.segUsuarioEdita,
                                                                                    pUpdate.segMaquinaEdita,
                                                                                    ref prm_SALDO_StockFisico,
                                                                                    pUpdate.cntStockComprometido);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codRetorno == 0 ? true : false;
        }

        /// <summary>
        /// ACTUALIZA StockFisico el registro de una ENTIDAD de registro de Tipo ProductoExistencias
        /// En la BASE de DATO la Tabla : [Almacen.ProductoExistencias]
        /// <summary>
        /// <param name="pUpdate"></param>
        /// <param name="prm_SALDO_StockMerma"></param>
        /// <param name="prm_SALDO_StockSobrante"></param>
        /// <returns></returns>
        public bool UpdateStockFisicoInventario(BEProductoExistenciaStockUpdate pUpdate, 
                                                ref decimal? prm_SALDO_StockMerma, 
                                                ref decimal? prm_SALDO_StockSobrante) 
        {
            bool SUCEDE_OK = false;
            try
            {
                prm_SALDO_StockSobrante = null;
                prm_SALDO_StockMerma = null;
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var result = SQLDC.omgc_U_ProductoExistenciaStockFisicoInventario(pUpdate.codEmpresa, 
                                                                                      pUpdate.codProducto,
                                                                                      Extensors.CheckStr(pUpdate.codDeposito),
                                                                                      pUpdate.cntStockFisico,
                                                                                      pUpdate.segUsuarioEdita,
                                                                                      pUpdate.segMaquinaEdita,
                                                                                      ref prm_SALDO_StockMerma,
                                                                                      ref prm_SALDO_StockSobrante);
                }
                SUCEDE_OK = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return SUCEDE_OK;
        }

        public bool UpdateStockFisicoInventarioAnterior(BEProductoExistenciaStockUpdate pUpdate)
        {
            bool SUCEDE_OK = false;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var result = SQLDC.omgc_U_ProductoExistencia_StockFisicoINVAnterior(pUpdate.codEmpresa, 
                                                                                        pUpdate.codProducto,
                                                                                        Extensors.CheckStr(pUpdate.codDeposito),
                                                                                        pUpdate.cntStockFisico,
                                                                                        pUpdate.cntStockMerma,
                                                                                        pUpdate.cntStockSobrante,
                                                                                        pUpdate.segUsuarioEdita,
                                                                                        pUpdate.segMaquinaEdita);
                }
                SUCEDE_OK = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return SUCEDE_OK;
        }

        /// <summary>
        /// ACTUALIZA Comprometido el registro de una ENTIDAD de registro de Tipo ProductoExistencias
        /// En la BASE de DATO la Tabla : [Almacen.ProductoExistencias]
        /// <summary>
        /// <param name="pUpdate"></param>
        /// <param name="prm_SALDO_StockComprometido"></param>
        /// <returns></returns>
        public bool UpdateStockComprometido(BEProductoExistenciaStockUpdate pUpdate, 
                                            ref decimal? prm_SALDO_StockComprometido)
        {
            bool SUCEDE_OK = false;
            prm_SALDO_StockComprometido = null;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var result = SQLDC.omgc_U_ProductoExistencia_StockComprometido(pUpdate.codEmpresa, 
                                                                                   pUpdate.codProducto,
                                                                                   Extensors.CheckStr(pUpdate.codDeposito),
                                                                                   pUpdate.cntStockComprometido,
                                                                                   pUpdate.indOperador,
                                                                                   pUpdate.segUsuarioEdita,
                                                                                   pUpdate.segMaquinaEdita,
                                                                                   ref prm_SALDO_StockComprometido);
                    SUCEDE_OK = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return SUCEDE_OK;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.ProductoExistencias
        /// En la BASE de DATO la Tabla : [Almacen.ProductoExistencias]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public bool Delete(BEProductoExistenciaFind pFiltro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_ProductoExistencia(pFiltro.codEmpresa,
                                                                    pFiltro.codProducto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.ProductoExistencias
        /// En la BASE de DATO la Tabla : [Almacen.ProductoExistencias]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEProductoExistencia> Find(BEProductoExistenciaFind pFiltro) 
        {
            List<BEProductoExistencia> lstProductoExistencia = new List<BEProductoExistencia>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.usp_sgcfe_R_ProductoExistencia(pFiltro.codEmpresa,
                                                                     pFiltro.codProducto,
                                                                     Extensors.CheckStr(pFiltro.codDeposito));
                    foreach (var item in resul)
                    {
                        lstProductoExistencia.Add(new BEProductoExistencia()
                        {
                            codProductoExistencia = item.codProductoExistencia,
                            codProducto = item.codProducto,
                            codigoProducto = item.codigoProducto,
                            StockInicial = item.StockInicial,
                            StockFisico = item.StockFisico,
                            StoskComprometido = item.StoskComprometido,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaCrea = item.SegMaquina,
                            StockMerma = item.StockMerma,
                            StockSobrante = item.StockSobrante,
                            codDeposito = item.codDeposito,
                            codEmpresa = pFiltro.codEmpresa,
                            auxcodDepositoNombre = item.auxcodDepositoNombre,
                            codProductoNombre = item.codProductoNombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductoExistencia;
        }

        #endregion

    }
} 

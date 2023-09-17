namespace CROM.GestionAlmacen.DataAccess
{
    using CROM.BusinessEntities.Almacen;
    using CROM.Tools.Comun;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Produccion.ProductoKardexData.cs]
    /// </summary>
    public class ProductoKardexData
    {
        private string conexion = string.Empty;
        public ProductoKardexData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoExistenciasKardex
        /// En la BASE de DATO la Tabla : [Produccion.ProductoExistenciasKardex]
        /// <summary>
        /// <param name="productoKardex"></param>
        /// <returns></returns>
        public int Insert(ProductoKardexAux productoKardex)
        {
            int? codigoRetorno = -1;
            try
            {
                using (_ProduccionDataContext SQLDC = new _ProduccionDataContext(conexion))
                {
                    SQLDC.omgc_I_ProductoKardex(
                       ref codigoRetorno,
                       productoKardex.codEmpresa,
                       productoKardex.codProducto,
                       productoKardex.codDocumRegDetalle,
                       productoKardex.fecMovimiento,
                       productoKardex.codRegistroTipoMovimi,
                       productoKardex.codPersonaMovimi,
                       productoKardex.cntSalida,
                       productoKardex.cntEntrada,
                       productoKardex.cntDevolucion,
                       productoKardex.cntSaldo,
                       productoKardex.monCostoUnitSalida,
                       productoKardex.monCostoUnitEntrada,
                       productoKardex.monCostoUnitDevoluc,
                       productoKardex.monCostoUnitSaldo,
                       productoKardex.perKardexAnio,
                       Extensors.CheckStr(productoKardex.codDeposito),
                       productoKardex.codRegistroTipoMotivo,
                       productoKardex.indActivo,
                       productoKardex.segUsuarioCrea);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == null ? 0 : codigoRetorno.Value;
        }

        #endregion

        #region /* Proceso de UPDATE BY ID CODE */

        /// <summary>
        /// ACTUALIZA un registro de la Entidad Produccion.ProductoExistenciasKardex
        /// En la BASE de DATO la Tabla : [Produccion.ProductoExistenciasKardex]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public bool UpdateKardexCierre(BaseFiltroAlmacen filtro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ProduccionDataContext SQLDC = new _ProduccionDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_ProductoKardex_Cierre(filtro.codEmpresa,
                                                                      filtro.codPuntoVenta,
                                                                      Extensors.CheckStr(filtro.codDeposito),
                                                                      filtro.codProducto,
                                                                      filtro.segUsuarioEdita,
                                                                      filtro.perPeriodo,
                                                                      filtro.fecCierreInventario,
                                                                      filtro.codEmpleadoInventario);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
        public bool UpdateKardexCierreDeshacer(BaseFiltroAlmacen filtro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ProduccionDataContext SQLDC = new _ProduccionDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_ProductoKardex_DeshacerCierre(filtro.codEmpresa,
                                                                              filtro.codPuntoVenta,
                                                                              Extensors.CheckStr(filtro.codDeposito),
                                                                              filtro.codProducto,
                                                                              filtro.segUsuarioEdita,
                                                                              filtro.perPeriodo);
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
        /// ELIMINA un registro de la Entidad Produccion.ProductoExistenciasKardex
        /// En la BASE de DATO la Tabla : [Produccion.ProductoExistenciasKardex]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public bool Delete(BaseFiltroAlmacen filtro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ProduccionDataContext SQLDC = new _ProduccionDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_ProductoKardex(filtro.codEmpresa, 
                                                                filtro.codDocumReg,
                                                                Extensors.CheckStr(filtro.codDeposito));
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
        /// Retorna un LISTA de registros de la Entidad Produccion.ProductoExistenciasKardex
        /// En la BASE de DATO la Tabla : [Produccion.ProductoExistenciasKardex]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<ProductoKardexAux> List(BaseFiltroAlmacen filtro)
        {
            List<ProductoKardexAux> lstProductoKardex = new List<ProductoKardexAux>();
            try
            {
                using (_ProduccionDataContext SQLDC = new _ProduccionDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ProductoKardex(filtro.codEmpresa, 
                                                            filtro.fecInicio, 
                                                            filtro.fecFinal,
                                                            Extensors.CheckStr(filtro.codDeposito),
                                                            filtro.codPuntoVenta, 
                                                            filtro.codPerEntidad,
                                                            filtro.codProducto, 
                                                            filtro.codDocumento, 
                                                            filtro.numDocumento,
                                                            filtro.codRegTipoMotivo, 
                                                            filtro.codRegTipoMovimiUno, 
                                                            filtro.codRegTipoMovimiDos,
                                                            filtro.indEstado, filtro.perPeriodo);
                    foreach (var item in resul)
                    {
                        lstProductoKardex.Add(new ProductoKardexAux()
                        {
                            codProductoKardex = item.codProductoKardex,
                            codDocumRegDetalle = item.codDocumRegDetalle,
                            codDocumReg = item.codDocumReg.HasValue ? item.codDocumReg.Value : 0,
                            fecMovimiento = item.fecMovimiento,
                            codProducto = item.codProducto,
                            codigoProducto = item.codigoProducto,
                            codEmpresa = item.codEmpresa.Value,
                            codPuntoDeVenta = item.codPuntoDeVenta,
                            codRegistroTipoMovimi = item.codRegistroTipoMovimi,
                            codPersonaMovimi = item.codPersonaMovimi,
                            codDocumento = item.codDocumento,
                            numDocumento = item.numDocumento,
                            codItemDetalle = item.codItemDetalle,
                            cntEntrada = item.cntEntrada,
                            cntSalida = item.cntSalida,
                            cntSaldo = item.cntSaldo,
                            cntDevolucion = item.cntDevolucion,
                            cntStockInicial = item.cntStockInicial,
                            cntStockConsignacion = item.cntStockConsignacion,

                            monCostoUnitEntrada = item.monCostoUnitEntrada,
                            monCostoUnitSalida = item.monCostoUnitSalida,
                            monCostoUnitSaldo = item.monCostoUnitSaldo,
                            monCostoUnitDevoluc = item.monCostoUnitDevoluc,

                            monTotalEntrada = item.monCostoUnitEntrada == null ? item.monCostoUnitEntrada : item.cntEntrada.Value * item.monCostoUnitEntrada.Value,
                            monTotalSalida = item.monCostoUnitSalida == null ? item.monCostoUnitSalida : item.cntSalida.Value * item.monCostoUnitSalida.Value,
                            monTotalSaldo = item.monCostoUnitSaldo == null ? item.monCostoUnitSaldo : item.cntSaldo.Value * item.monCostoUnitSaldo.Value,
                            monTotalDevolucion = item.monCostoUnitDevoluc == null ? item.monCostoUnitDevoluc : item.cntDevolucion.Value * item.monCostoUnitDevoluc.Value,

                            desRazonSocial = item.desRazonSocial,
                            perKardexAnio = item.perKardexAnio,
                            codDeposito = Extensors.CheckInt(item.codRegistroDeposito),
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquina = item.segMaquina,
                            codRegistroTipoMovimiNombre = item.codRegistroTipoMovimiNombre,
                            codDocumentoNombre = item.codDocumentoNombre,
                            codPersonaEmpreNombre = item.codEmpresaNombre,
                            codPersonaMovimiNombre = item.codPersonaMovimiNombre,
                            codProductoNombre = item.codProductoNombre,
                            codPuntoDeVentaNombre = item.codPuntoDeVentaNombre,
                            codRegistroTipoMotivo = item.codRegistroTipoMotivo,
                            codRegistroTipoMotivoNombre = item.codRegistroTipoMotivoNombre,
                            codProductoRefer = item.codProductoRefer,
                            codRegistroCategProducto = item.codRegistroCategProducto.HasValue? item.codRegistroCategProducto.Value.ToString():string.Empty,
                            codRegistroCategProductoNombre = item.codRegistroCategProductoNombre,
                            codRegistroUnidadMedida = item.codRegistroUnidadMedida,
                            codRegistroUnidadMedidaNombre = item.codRegistroUnidadMedidaNombre,
                            cntStockFisico = item.cntStockFisico,
                            cntStockComprometido = item.cntStockComprometido,
                            codRegistroDepositoNombre = item.codRegistroDepositoNombre,

                            codEmpleado = item.codEmpleado,
                            codEmpleadoNombre = item.codEmpleadoNombre,
                            fecInventarioCierre = item.fecInventarioCierre,
                            perInventario = item.perInventario,

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductoKardex;
        }
        public List<ProductoKardexAux> ListPorDocumento(BaseFiltroAlmacen filtro) 
        {
            List<ProductoKardexAux> lstProductoKardex = new List<ProductoKardexAux>();
            try
            {
                using (_ProduccionDataContext SQLDC = new _ProduccionDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ProductoKardex_codDocumReg(filtro.codEmpresa,
                                                                        filtro.codDocumReg);
                    foreach (var item in resul)
                    {
                        lstProductoKardex.Add(new ProductoKardexAux()
                        {
                            codProductoKardex = item.codProductoKardex,
                            codDocumRegDetalle = item.codDocumRegDetalle,
                            codDocumReg = item.codDocumReg.HasValue ? item.codDocumReg.Value : 0,

                            fecMovimiento = item.fecMovimiento,
                            codProducto = item.codProducto,
                            codigoProducto = item.codigoProducto,
                            codEmpresa = item.codEmpresa.Value,
                            codPuntoDeVenta = item.codPuntoDeVenta,
                            codRegistroTipoMovimi = item.codRegistroTipoMovimi,
                            codPersonaMovimi = item.codPersonaMovimi,
                            codDocumento = item.codDocumento,
                            numDocumento = item.numDocumento,
                            codItemDetalle = item.codItemDetalle,

                            cntEntrada = item.cntEntrada,
                            cntSalida = item.cntSalida,
                            cntSaldo = item.cntSaldo,
                            cntDevolucion = item.cntDevolucion,
                            cntStockInicial = item.cntStockInicial,
                            cntStockConsignacion = item.cntStockConsignacion,

                            monCostoUnitEntrada = item.monCostoUnitEntrada,
                            monCostoUnitSalida = item.monCostoUnitSalida,
                            monCostoUnitSaldo = item.monCostoUnitSaldo,
                            monCostoUnitDevoluc = item.monCostoUnitDevoluc,

                            monTotalEntrada = item.monCostoUnitEntrada == null ? item.monCostoUnitEntrada : item.cntEntrada.Value * item.monCostoUnitEntrada.Value,
                            monTotalSalida = item.monCostoUnitSalida == null ? item.monCostoUnitSalida : item.cntSalida.Value * item.monCostoUnitSalida.Value,
                            monTotalSaldo = item.monCostoUnitSaldo == null ? item.monCostoUnitSaldo : item.cntSaldo.Value * item.monCostoUnitSaldo.Value,
                            monTotalDevolucion = item.monCostoUnitDevoluc == null ? item.monCostoUnitDevoluc : item.cntDevolucion.Value * item.monCostoUnitDevoluc.Value,

                            desRazonSocial = item.desRazonSocial,
                            perKardexAnio = item.perKardexAnio,
                            codDeposito = Extensors.CheckInt(item.codRegistroDeposito),
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquina = item.segMaquina,
                            codRegistroTipoMovimiNombre = item.codRegistroTipoMovimiNombre,
                            codDocumentoNombre = item.codDocumentoNombre,
                            codPersonaEmpreNombre = item.codEmpresaNombre,
                            codPersonaMovimiNombre = item.codPersonaMovimiNombre,
                            codProductoNombre = item.codProductoNombre,
                            codPuntoDeVentaNombre = item.codPuntoDeVentaNombre,
                            codRegistroTipoMotivo = item.codRegistroTipoMotivo,
                            codRegistroTipoMotivoNombre = item.codRegistroTipoMotivoNombre,
                            codProductoRefer = item.codProductoRefer,
                            codRegistroCategProducto = item.codRegistroCategProducto,
                            codRegistroCategProductoNombre = item.codRegistroCategProductoNombre,
                            codRegistroUnidadMedida = item.codRegistroUnidadMedida,
                            codRegistroUnidadMedidaNombre = item.codRegistroUnidadMedidaNombre,
                            cntStockFisico = item.cntStockFisico,
                            cntStockComprometido = item.cntStockComprometido,
                            codRegistroDepositoNombre = item.codRegistroDepositoNombre,
                            fecInventarioCierre = item.fecInventarioCierre,
                            perInventario = item.perInventario,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductoKardex;
        }
        public List<ProductoKardexAux> ListInventariado(BaseFiltroAlmacen filtro) 
        {
            List<ProductoKardexAux> lstProductoKardex = new List<ProductoKardexAux>();
            try
            {
                using (_ProduccionDataContext SQLDC = new _ProduccionDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ProductoKardex_Inventario(filtro.codEmpresa, 
                                                                       filtro.codPuntoVenta,
                                                                       Extensors.CheckStr(filtro.codDeposito), 
                                                                       filtro.codDocumento, 
                                                                       filtro.codRegTipoMovimiUno);
                    foreach (var item in resul)
                    {
                        lstProductoKardex.Add(new ProductoKardexAux()
                        {
                            codProductoKardex = item.codProductoKardex,
                            codDocumRegDetalle = item.codDocumRegDetalle,
                            codDocumReg = item.codDocumReg.HasValue ? item.codDocumReg.Value : 0,
                            fecMovimiento = item.fecMovimiento,
                            codProducto = item.codProducto,
                            codEmpresa = item.codEmpresa.Value,
                            codPuntoDeVenta = item.codPuntoDeVenta,
                            codRegistroTipoMovimi = item.codRegistroTipoMovimi,
                            codPersonaMovimi = item.codPersonaMovimi,
                            codDocumento = item.codDocumento,
                            numDocumento = item.numDocumento,

                            cntEntrada = item.cntEntrada,
                            cntSalida = item.cntSalida,
                            cntSaldo = item.cntSaldo,
                            cntDevolucion = item.cntDevolucion,
                            cntStockInicial = item.cntStockInicial,
                            cntStockConsignacion = item.cntStockConsignacion,

                            monCostoUnitEntrada = item.monCostoUnitEntrada,
                            monCostoUnitSalida = item.monCostoUnitSalida,
                            monCostoUnitSaldo = item.monCostoUnitSaldo,
                            monCostoUnitDevoluc = item.monCostoUnitDevoluc,

                            monTotalEntrada = item.monCostoUnitEntrada == null ? item.monCostoUnitEntrada : item.cntEntrada.Value * item.monCostoUnitEntrada.Value,
                            monTotalSalida = item.monCostoUnitSalida == null ? item.monCostoUnitSalida : item.cntSalida.Value * item.monCostoUnitSalida.Value,
                            monTotalSaldo = item.monCostoUnitSaldo == null ? item.monCostoUnitSaldo : item.cntSaldo.Value * item.monCostoUnitSaldo.Value,
                            monTotalDevolucion = item.monCostoUnitDevoluc == null ? item.monCostoUnitDevoluc : item.cntDevolucion.Value * item.monCostoUnitDevoluc.Value,

                            desRazonSocial = item.desRazonSocial,
                            perKardexAnio = item.perKardexAnio,
                            codDeposito = Extensors.CheckInt(item.codRegistroDeposito),
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquina = item.segMaquina,
                            codRegistroTipoMovimiNombre = item.codRegistroTipoMovimiNombre,
                            codDocumentoNombre = item.codDocumentoNombre,
                            codPersonaEmpreNombre = item.codEmpresaNombre,
                            codPersonaMovimiNombre = item.codPersonaMovimiNombre,
                            codProductoNombre = item.codProductoNombre,
                            codPuntoDeVentaNombre = item.codPuntoDeVentaNombre,
                            codRegistroTipoMotivo = item.codRegistroTipoMotivo,
                            codRegistroTipoMotivoNombre = item.codRegistroTipoMotivoNombre,
                            codProductoRefer = item.codProductoRefer,
                            codRegistroCategProducto = item.codRegistroCategProducto,
                            codRegistroCategProductoNombre = item.codRegistroCategProductoNombre,
                            codRegistroUnidadMedida = item.codRegistroUnidadMedida,
                            codRegistroUnidadMedidaNombre = item.codRegistroUnidadMedidaNombre,
                            cntStockFisico = item.cntStockFisico,
                            cntStockComprometido = item.cntStockComprometido,
                            codRegistroDepositoNombre = item.codRegistroDepositoNombre,

                            codEmpleado = item.codEmpleado,
                            codEmpleadoNombre = item.codEmpleadoNombre,
                            fecInventarioCierre = item.fecInventarioCierre,
                            perInventario = item.perInventario,

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductoKardex;
        }

        #endregion

    }
} 

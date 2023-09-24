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
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Almacen.InventariosData.cs]
    /// </summary>
    public class InventarioData
    {
        private string conexion = string.Empty;
        public InventarioData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Inventarios
        /// En la BASE de DATO la Tabla : [Almacen.Inventarios]
        /// <summary>
        /// <param name="inventario"></param>
        /// <returns></returns>
        public int Insert(List<InventarioAux> lstInventario)
        {
            int? codigoRetorno = -1;
            int? codInventario = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    foreach (InventarioAux inventario in lstInventario)
                    {
                        SQLDC.omgc_I_Inventario(
                            inventario.codEmpresa,
                           ref codInventario,
                           Extensors.CheckStr(inventario.codDeposito),
                           inventario.codProducto,
                           inventario.Periodo,
                           inventario.segUsuarioCrea,
                           inventario.cntOrigStockFisico,
                           inventario.cntOrigStockMerma,
                           inventario.cntOrigStockSobrante,
                           inventario.desAgrupacion);

                        inventario.codInventario = codInventario.Value;

                    }
                    codigoRetorno = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == null ? 0 : codigoRetorno.Value;
        }

        public int InsertInventarioDocumReg(List<BEInventarioDocumReg> lstInventarioDocumReg)
        {
            int? codigoRetorno = -1;
            int? codInventario = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    foreach (BEInventarioDocumReg inventarioDocumReg in lstInventarioDocumReg)
                    {
                        SQLDC.omgc_I_InventarioDocumReg(
                           ref codInventario,
                           inventarioDocumReg.strPeriodo,
                           inventarioDocumReg.codDocumReg,
                           inventarioDocumReg.codInventario,
                            inventarioDocumReg.segUsuarioCrea
                           );
                    }
                    codigoRetorno = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == null ? 0 : codigoRetorno.Value;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Inventarios
        /// En la BASE de DATO la Tabla : [Almacen.Inventarios]
        /// <summary>
        /// <param name="itemInventario"></param>
        /// <returns></returns>
        public bool Update(InventarioAux inventario)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_Inventario(
                        inventario.codEmpresa,
                        inventario.codInventario,
                        Extensors.CheckStr(inventario.codDeposito),
                        inventario.codProducto,
                        inventario.Periodo,
                        inventario.NumeroDeConteo,
                        inventario.Conteo,
                        inventario.ConteoEmpleado,
                        inventario.cntTransacciones,
                        inventario.segUsuarioEdita);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
        
        public bool UpdateInventariosCerrar(InventarioAux inventario)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_Inventario_Cerrar(
                        inventario.codEmpresa,
                        inventario.codInventario,
                        inventario.Periodo,
                        inventario.CierreConteo,
                        inventario.CierreEmpleado,
                        inventario.SALDO_StockMerma,
                        inventario.SALDO_StockSobrante,
                        inventario.segUsuarioEdita,
                        inventario.segMaquinaEdita);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
        public bool UpdateInventariosCerrarDeshacer(InventarioAux itemInventario)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_Inventario_Cerrar_Deshacer(
                        itemInventario.codEmpresa,
                        itemInventario.codInventario,
                        Extensors.CheckStr(itemInventario.codDeposito),
                        itemInventario.codProducto,
                        itemInventario.Periodo,
                        itemInventario.segUsuarioEdita,
                        itemInventario.segMaquinaEdita);
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
        /// ELIMINA un registro de la Entidad Almacen.Inventarios
        /// En la BASE de DATO la Tabla : [Almacen.Inventarios]
        /// <summary>
        /// <param name="prm_codInventario"></param>
        /// <returns></returns>
        public bool DeleteInventarioDocumReg(BaseFiltroAlmacen pfiltro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_InventarioDocumReg(pfiltro.codDocumReg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.Inventarios
        /// En la BASE de DATO la Tabla : [Almacen.Inventarios]
        /// <summary>
        /// <param name="prm_codInventario"></param>
        /// <returns></returns>
        public bool Delete(int pcodEmpresa, int prm_codInventario)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_Inventario(pcodEmpresa, prm_codInventario);
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
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.Inventarios
        /// En la BASE de DATO la Tabla : [Almacen.Inventarios]
        /// <summary>
        /// <returns>Entidad</returns>
        public InventarioAux Find(int pcodEmpresa, int prm_codInventario)
        {
            InventarioAux miEntidad = new InventarioAux();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Inventario_Id(pcodEmpresa, prm_codInventario);
                    foreach (var item in resul)
                    {
                        miEntidad = new InventarioAux()
                        {
                            codInventario = item.codInventario,
                            codDeposito = Extensors.ToInteger( item.codDeposito),
                            CodigoProducto = item.codigoProducto,
                            Periodo = item.Periodo,
                            Conteo01 = item.Conteo01,
                            Conteo01Empleado = item.Conteo01Empleado,
                            Conteo01FechaHora = item.Conteo01FechaHora,
                            Conteo01EmpleadoNombre = item.Conteo01EmpleadoNombre,
                            Conteo02 = item.Conteo02,
                            Conteo02Empleado = item.Conteo02Empleado,
                            Conteo02EmpleadoNombre = item.Conteo02EmpleadoNombre,
                            Conteo02FechaHora = item.Conteo02FechaHora,
                            Conteo03 = item.Conteo03,
                            Conteo03Empleado = item.Conteo03Empleado,
                            Conteo03EmpleadoNombre = item.Conteo03EmpleadoNombre,
                            Conteo03FechaHora = item.Conteo03FechaHora,
                            Conteo04 = item.Conteo04,
                            Conteo04Empleado = item.Conteo04Empleado,
                            Conteo04EmpleadoNombre = item.Conteo04EmpleadoNombre,
                            Conteo04FechaHora = item.Conteo04FechaHora,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaCrea = item.SegMaquina,
                            CierreConteo = item.CierreConteo,
                            CierreEmpleado = item.CierreEmpleado,
                            CierreEmpleadoNombre = item.CierreEmpleadoNombre,
                            CierreFechaHora = item.CierreFechaHora,
                            cntOrigStockFisico = item.cntOrigStockFisico,
                            cntOrigStockMerma = item.cntOrigStockMerma,
                            cntOrigStockSobrante = item.cntOrigStockSobrante,
                            PeriodoAux = item.Periodo
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miEntidad;
        }

        #endregion

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Inventarios
        /// En la BASE de DATO la Tabla : [Almacen.Inventarios]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<InventarioAux> List(BaseFiltroAlmacen pFiltro)
        {
            List<InventarioAux> lstInventario = new List<InventarioAux>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Inventario(pFiltro.codEmpresa,pFiltro.codEmpresaRUC
                                                      , pFiltro.codPuntoVenta
                                                      , Extensors.CheckStr( pFiltro.codDeposito)
                                                      , pFiltro.codProductoRefer
                                                      , pFiltro.perPeriodo
                                                      , pFiltro.indEstado
                                                      , pFiltro.cntConteo
                                                      , pFiltro.desAgrupacion);
                    foreach (var item in resul)
                    {
                        lstInventario.Add(new InventarioAux()
                        {
                            codInventario = item.codInventario,
                            codDeposito = Extensors.ToInteger( item.codDeposito),
                            codProducto = item.codProducto,
                            CodigoProducto = item.codigoProducto,
                            CodigoProductoNombre = item.CodigoProductoNombre,
                            Periodo = item.Periodo,
                            Conteo01 = item.Conteo01,
                            Conteo01Empleado = item.Conteo01Empleado,
                            Conteo01FechaHora = item.Conteo01FechaHora,
                            Conteo01EmpleadoNombre = item.Conteo01EmpleadoNombre,
                            Conteo02 = item.Conteo02,
                            Conteo02Empleado = item.Conteo02Empleado,
                            Conteo02EmpleadoNombre = item.Conteo02EmpleadoNombre,
                            Conteo02FechaHora = item.Conteo02FechaHora,
                            Conteo03 = item.Conteo03,
                            Conteo03Empleado = item.Conteo03Empleado,
                            Conteo03EmpleadoNombre = item.Conteo03EmpleadoNombre,
                            Conteo03FechaHora = item.Conteo03FechaHora,
                            Conteo04 = item.Conteo04,
                            Conteo04Empleado = item.Conteo04Empleado,
                            Conteo04EmpleadoNombre = item.Conteo04EmpleadoNombre,
                            Conteo04FechaHora = item.Conteo04FechaHora,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaCrea = item.SegMaquina,
                            CierreConteo = item.CierreConteo,
                            CierreEmpleado = item.CierreEmpleado,
                            CierreEmpleadoNombre = item.CierreEmpleadoNombre,
                            CierreFechaHora = item.CierreFechaHora,
                            CodigoPersonaEmpre = item.CodigoPersonaEmpre,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            SALDO_StockMerma = item.SALDO_StockMerma,
                            SALDO_StockSobrante = item.SALDO_StockSobrante,
                            cntOrigStockFisico = item.cntOrigStockFisico,
                            cntOrigStockMerma = item.cntOrigStockMerma,
                            cntOrigStockSobrante = item.cntOrigStockSobrante,
                            PeriodoAux = item.Periodo,
                            EsConNumeroSeriado = item.EsConNumeroSeriado == null ? false : item.EsConNumeroSeriado.Value,
                            desAgrupacion = item.desAgrupacion
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInventario;
        }

        public List<InventarioAux> ListInventariosCerrar(BaseFiltroAlmacen pFiltro)
        {
            List<InventarioAux> lstInventario = new List<InventarioAux>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Inventario_Cerrar(pFiltro.codEmpresa, pFiltro.codEmpresaRUC,
                                                               pFiltro.codPuntoVenta,
                                                               Extensors.CheckStr(pFiltro.codDeposito),
                                                               pFiltro.codProducto,
                                                               pFiltro.perPeriodo,
                                                               pFiltro.indEstado,
                                                               pFiltro.cntConteo,
                                                               pFiltro.desAgrupacion);
                    foreach (var item in resul)
                    {
                        lstInventario.Add(new InventarioAux()
                        {
                            codInventario = item.codInventario,
                            codDeposito = Extensors.ToInteger(item.codDeposito),
                            codProducto = item.codProducto,
                            CodigoProducto = item.codigoProducto,
                            CodigoProductoNombre = item.CodigoProductoNombre,
                            Periodo = item.Periodo,

                            Conteo = item.ConteoRealizado == null ? 0 : item.ConteoRealizado.Value,
                            ConteoSel = item.Conteo,
                            EmpleadoSel = item.ConteoEmpleado,
                            EmpleadoNombreSel = item.ConteoEmpleadoNombre,
                            FechaHoraSel = item.ConteoFechaHora,

                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaCrea = item.SegMaquina,
                            CierreConteo = item.CierreConteo,
                            CierreEmpleado = item.CierreEmpleado,
                            CierreEmpleadoNombre = item.CierreEmpleadoNombre,
                            CierreFechaHora = item.CierreFechaHora,
                            CodigoPersonaEmpre = item.CodigoPersonaEmpre,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            cntOrigStockFisico = item.cntOrigStockFisico,
                            cntOrigStockMerma = item.cntOrigStockMerma,
                            cntOrigStockSobrante = item.cntOrigStockSobrante,
                            SALDO_StockMerma = item.SALDO_StockMerma,
                            SALDO_StockSobrante = item.SALDO_StockSobrante,
                            PeriodoAux = item.Periodo,
                            EsConNumeroSeriado = item.EsConNumeroSeriado,
                            ConteoSeriadoChek = item.ConteoSeriado,
                            codRegMoneda = item.codRegMoneda,
                            codRegMonedaNombre = item.codRegMonedaNombre,
                            codRegMonedaSimbolo = item.codRegMonedaSimbolo,
                            ValorCosto = item.ValorCosto,
                            ValorVenta = item.ValorVenta,
                            desAgrupacion = item.desAgrupacion
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInventario;
        }

        public List<InventarioAux> ListInventariosMermaSobrante(BaseFiltroAlmacenMermaSobrante objBaseFiltro)
        {
            List<InventarioAux> lstInventario = new List<InventarioAux>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Inventario_MermaSobrante(objBaseFiltro.codEmpresaRUC,
                                                                      objBaseFiltro.perPeriodo,
                                                                      Extensors.CheckStr(objBaseFiltro.codDeposito),
                                                                      objBaseFiltro.indEstado,
                                                                      objBaseFiltro.desAgrupacion,
                                                                      objBaseFiltro.codProductoRefer);
                    foreach (var item in resul)
                    {
                        lstInventario.Add(new InventarioAux()
                        {
                            CodigoPersonaEmpre = objBaseFiltro.codEmpresaRUC,
                            codDeposito = Extensors.CheckInt(objBaseFiltro.codDeposito),
                            codInventario = item.codInventario,
                            codProducto = item.codProducto,
                            CodigoProducto = item.codigoProducto,
                            CodigoProductoNombre = item.codProductoNombre,
                            Periodo = objBaseFiltro.perPeriodo,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaEdita,
                            CierreConteo = item.numConteoCierre,
                            CierreEmpleado = item.codEmpleadoCierre,
                            CierreFechaHora = item.fecCierre,
                            SALDO_StockMerma = item.SALDO_StockMerma,
                            SALDO_StockSobrante = item.SALDO_StockSobrante,
                            codRegMoneda = item.codRegMoneda,
                            codRegMonedaNombre = item.codRegMonedaNombre,
                            codRegMonedaSimbolo = item.codRegMonedaSimbolo,
                            ValorCosto = item.monValorCosto,
                            ValorVenta = item.monValorVenta,
                            codRegUnidadMedida = item.codRegUnidadMed,
                            codRegTipoProducto = item.codRegTipoProducto
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInventario;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Inventarios
        /// En la BASE de DATO la Tabla : [Almacen.Inventarios]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<BEInventario> ListCons_Paged(BaseFiltroAlmacen pFiltro)
        {
            List<BEInventario> lstInventario = new List<BEInventario>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Inventario_Cons_Paged(pFiltro.jqCurrentPage
                                                                  , pFiltro.jqPageSize
                                                                  , pFiltro.jqSortColumn
                                                                  , pFiltro.jqSortOrder
                                                                  , pFiltro.codEmpresaRUC
                                                                  , pFiltro.codPuntoVenta
                                                                  , Extensors.CheckStr(pFiltro.codDeposito)
                                                                  , pFiltro.codigoProducto
                                                                  , pFiltro.codPeriodo
                                                                  , pFiltro.desAgrupacion);
                    foreach (var item in resul)
                    {
                        BEInventario objInventario = new BEInventario();

                        objInventario.TOTALROWS = item.TOTALROWS.Value;
                        objInventario.ROW = item.ROWNUM.Value;

                        objInventario.codInventario = item.codInventario;
                        objInventario.codProducto = item.codProducto;
                        objInventario.objProducto.Descripcion = item.codProductoNombre;
                        objInventario.Periodo = item.Periodo;
                        objInventario.codDeposito = Extensors.ToInteger(item.codDeposito);
                        objInventario.objProducto.CodigoProducto = item.codigoProducto;
                        objInventario.Periodo = item.Periodo;
                        objInventario.Conteo01Empleado = item.ConteoEmpleado;
                        objInventario.Conteo01FechaHora = item.ConteoFechaHora;
                        objInventario.objEmpConteo01.ApellidosNombres = item.ConteoEmpleadoNombre;
                        objInventario.cntConteoSeriado = item.ConteoSeriado.Value;
                        objInventario.cntTransacciones = item.cntTransacciones.HasValue ? item.cntTransacciones.Value : 0;

                        objInventario.CierreConteo = item.CierreConteo;
                        objInventario.CierreEmpleado = item.CierreEmpleado;
                        objInventario.objEmpCierre.ApellidosNombres = item.CierreEmpleadoNombre;

                        objInventario.CierreFechaHora = item.CierreFechaHora;
                        objInventario.objDeposito.objPuntoDeVenta.codPersonaEmpre = item.CodigoPersonaEmpre;
                        objInventario.objDeposito.codPuntoVenta = item.CodigoPuntoVenta;

                        objInventario.SALDO_StockMerma = item.SALDO_StockMerma;
                        objInventario.SALDO_StockSobrante = item.SALDO_StockSobrante;
                        objInventario.cntOrigStockFisico = item.cntOrigStockFisico;
                        objInventario.cntOrigStockMerma = item.cntOrigStockMerma;
                        objInventario.cntOrigStockSobrante = item.cntOrigStockSobrante;
                        objInventario.objProducto.EsConNumeroSeriado = item.EsConNumeroSeriado;
                        objInventario.desAgrupacion = item.desAgrupacion;

                        objInventario.objProducto.itemProductoPrecio.CodigoArguMoneda = item.codRegMoneda;
                        objInventario.objProducto.itemProductoPrecio.objMoneda.codRegistro = item.codRegMoneda;
                        objInventario.objProducto.itemProductoPrecio.objMoneda.desNombre = item.codRegMonedaNombre;
                        objInventario.objProducto.itemProductoPrecio.objMoneda.desValorCadena = item.codRegMonedaSimbolo;

                        objInventario.Estado = item.Estado;
                        objInventario.segUsuarioCrea = item.SegUsuarioCrea;
                        objInventario.segUsuarioEdita = item.SegUsuarioEdita;
                        objInventario.segFechaCrea = item.SegFechaCrea;
                        objInventario.segFechaEdita = item.SegFechaEdita;
                        objInventario.segMaquinaCrea = item.SegMaquina;

                        lstInventario.Add(objInventario);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInventario;
        }

        #endregion

    }
}

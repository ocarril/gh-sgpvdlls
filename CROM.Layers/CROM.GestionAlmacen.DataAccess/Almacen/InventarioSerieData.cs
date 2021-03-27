namespace CROM.GestionAlmacen.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Almacen;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 19/04/2014-11:35:24 p.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Almacen.InventarioSerieData.cs]
    /// </summary>
    public class InventarioSerieData
    {
        private string conexion = string.Empty;

        public InventarioSerieData()
        {
            conexion = Util.ConexionBD();
        }
   
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.InventarioSerie
        /// En la BASE de DATO la Tabla : [Almacen.InventarioSerie]
        /// <summary>
        /// <returns>List</returns>
        public List<BEInventarioSerie> List(BaseFiltroAlmacen pFiltro)
        {
            List<BEInventarioSerie> lstInventarioSerie = new List<BEInventarioSerie>();
            BEInventarioSerie itemInventarioSerie = null;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_InventarioSerie(pFiltro.codInventario, 
                                                             pFiltro.cntConteo);
                    foreach (var item in resul)
                    {
                        itemInventarioSerie = new BEInventarioSerie();
                        itemInventarioSerie.codInventarioSerie = item.codInventarioSerie;
                        itemInventarioSerie.codInventario = item.codInventario;
                        itemInventarioSerie.codProductoSeriado = item.codProductoSeriado;
                        itemInventarioSerie.indExisteFisico = item.indExisteFisico;
                        itemInventarioSerie.numConteo = item.numConteo;
                        itemInventarioSerie.segUsuarioCrea = item.segUsuarioCrea;
                        itemInventarioSerie.segUsuarioEdita = item.segUsuarioEdita;
                        itemInventarioSerie.segFechaCrea = item.segFechaCrea;
                        itemInventarioSerie.segFechaEdita = item.segFechaEdita;
                        itemInventarioSerie.segMaquinaCrea = item.segMaquina;

                        itemInventarioSerie.objProductoSerie.NumeroSerie = item.NumeroSerie;
                        itemInventarioSerie.objProductoSerie.NumeroLote = item.NumeroLote;
                        itemInventarioSerie.objProductoSerie.codRegEstadoMercaderia = item.codRegEstadoMercaderia;
                        itemInventarioSerie.objProductoSerie.codRegEstadoMercaderiaNombre = item.codRegEstadoMercaderiaNombre;
                        itemInventarioSerie.objProductoSerie.CodigoRegistro = item.CodigoRegistro;
                        lstInventarioSerie.Add(itemInventarioSerie);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInventarioSerie;
        }
    
        /// <summary>
        /// Lista los registros de inventario serie por Periodo de inventario y conteo
        /// </summary>
        /// <param name="pr_Filtro"></param>
        /// <returns></returns>
        public List<BEInventarioSerie> ListPorPeriodo(BaseFiltroAlmacen pr_Filtro)
        {
            List<BEInventarioSerie> lstInventarioSerie = new List<BEInventarioSerie>();
            BEInventarioSerie itemInventarioSerie = null;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_InventarioSerie_codPeriodo(pr_Filtro.perPeriodo, 
                                                                        pr_Filtro.cntConteo);
                    foreach (var item in resul)
                    {
                        itemInventarioSerie = new BEInventarioSerie();
                        itemInventarioSerie.codInventarioSerie = item.codInventarioSerie;
                        itemInventarioSerie.codInventario = item.codInventario;
                        itemInventarioSerie.codProductoSeriado = item.codProductoSeriado;
                        itemInventarioSerie.indExisteFisico = item.indExisteFisico;
                        itemInventarioSerie.numConteo = item.numConteo;
                        itemInventarioSerie.segUsuarioCrea = item.segUsuarioCrea;
                        itemInventarioSerie.segUsuarioEdita = item.segUsuarioEdita;
                        itemInventarioSerie.segFechaCrea = item.segFechaCrea;
                        itemInventarioSerie.segFechaEdita = item.segFechaEdita;
                        itemInventarioSerie.segMaquinaCrea = item.segMaquina;

                        itemInventarioSerie.objProductoSerie.NumeroSerie = item.NumeroSerie;
                        itemInventarioSerie.objProductoSerie.NumeroLote = item.NumeroLote;
                        itemInventarioSerie.objProductoSerie.codRegEstadoMercaderia = item.codRegEstadoMercaderia;
                        itemInventarioSerie.objProductoSerie.codRegEstadoMercaderiaNombre = item.codRegEstadoMercaderiaNombre;
                        itemInventarioSerie.objProductoSerie.CodigoRegistro = item.CodigoRegistro;
                        lstInventarioSerie.Add(itemInventarioSerie);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInventarioSerie;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.InventarioSerie
        /// En la BASE de DATO la Tabla : [Almacen.InventarioSerie]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEInventarioSerie> List_ConsSerie_Paged(BaseFiltroAlmacen pFiltro)
        {
            List<BEInventarioSerie> lstInventarioSerie = new List<BEInventarioSerie>();
            try
            {
                using (_AlmacenDataContext SQLDContext = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDContext.omgc_S_Inventario_ConsSerie_Paged(pFiltro.jqCurrentPage,
                                                                              pFiltro.jqPageSize,
                                                                              pFiltro.jqSortColumn,
                                                                              pFiltro.jqSortOrder, 
                                                                              pFiltro.codInventario);
                    foreach (var item in resul)
                    {
                        BEInventarioSerie objInventarioSerie = new BEInventarioSerie();
                        objInventarioSerie.ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0;
                        objInventarioSerie.TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0;
                        objInventarioSerie.objProductoSerie.CodigoRegistro = item.CodigoRegistro;
                        objInventarioSerie.codInventarioSerie = item.codInventarioSerie;
                        objInventarioSerie.codInventario = item.codInventario;
                        objInventarioSerie.codProductoSeriado = item.codProductoSeriado;
                        objInventarioSerie.objProductoSerie.codProducto = item.codProducto;
                        objInventarioSerie.objProductoSerie.NumeroSerie = item.NumeroSerie;
                        objInventarioSerie.objProductoSerie.objEstadoMercaderia.desNombre = item.codRegEstadoMercaderiaNombre;
                        objInventarioSerie.indExisteFisico = item.indExisteFisico;
                        objInventarioSerie.numConteo = item.numConteo;
                        objInventarioSerie.objProductoSerie.NumeroComprobanteCompra = item.NumeroComprobanteCompra;
                        objInventarioSerie.objProductoSerie.FechaIngreso = item.FechaIngreso;
                        objInventarioSerie.objProductoSerie.NumeroComprobanteComprom = item.NumeroComprobanteComprom;
                        objInventarioSerie.objProductoSerie.FechaComprometido = item.FechaComprometido;
                        objInventarioSerie.objProductoSerie.NumeroComprobanteVenta = item.NumeroComprobanteVenta;
                        objInventarioSerie.objProductoSerie.FechaVenta = item.FechaVenta;
                        objInventarioSerie.segUsuarioCrea = item.segUsuarioCrea;
                        objInventarioSerie.segUsuarioEdita = item.segUsuarioEdita;
                        objInventarioSerie.segFechaCrea = item.segFechaCrea;
                        objInventarioSerie.segFechaEdita = item.segFechaEdita;
                        objInventarioSerie.segMaquinaCrea = item.segMaquina;

                        lstInventarioSerie.Add(objInventarioSerie);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInventarioSerie;
        }
    
        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo InventarioSerie
        /// En la BASE de DATO la Tabla : [Almacen.InventarioSerie]
        /// <summary>
        /// <param name = >itemInventarioSerie</param>
        public bool Insert(List<BEInventarioSerie> lstInventarioSerie)
        {
            int? codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    foreach (BEInventarioSerie itemInventarioSerie in lstInventarioSerie)
                    {
                        SQLDC.omgc_I_InventarioSerie(
                           ref codigoRetorno,
                           itemInventarioSerie.codInventario,
                           itemInventarioSerie.codProductoSeriado,
                           itemInventarioSerie.indExisteFisico,
                           itemInventarioSerie.numConteo,
                           itemInventarioSerie.segUsuarioCrea,
                           itemInventarioSerie.segMaquinaCrea);

                        itemInventarioSerie.codInventarioSerie = codigoRetorno.Value;
                    }
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo InventarioSerie
        /// En la BASE de DATO la Tabla : [Almacen.InventarioSerie]
        /// <summary>
        /// <param name = >itemInventarioSerie</param>
        public bool Update(List<BEInventarioSerie> lstInventarioSerie)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    foreach (BEInventarioSerie itemInventarioSerie in lstInventarioSerie)
                    {
                        codigoRetorno = SQLDC.omgc_U_InventarioSerie(
                         itemInventarioSerie.codInventarioSerie,
                         itemInventarioSerie.codInventario,
                         itemInventarioSerie.codProductoSeriado,
                         itemInventarioSerie.indExisteFisico,
                         itemInventarioSerie.numConteo,
                         itemInventarioSerie.segUsuarioEdita,
                         itemInventarioSerie.segMaquinaEdita
                         );
                    }
                    codigoRetorno = 0;
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
        /// ELIMINA un registro de la Entidad Almacen.InventarioSerie
        /// En la BASE de DATO la Tabla : [Almacen.InventarioSerie]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(BaseFiltroAlmacen pfiltro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_InventarioSerie(pfiltro.codInventario, 
                                                                 pfiltro.codProductoSeriado, 
                                                                 pfiltro.cntConteo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
      
        #endregion
    }
} 

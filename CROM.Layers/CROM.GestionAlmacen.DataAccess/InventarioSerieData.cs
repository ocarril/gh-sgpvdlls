namespace CROM.GestionAlmacen.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.InventarioSerie
        /// En la BASE de DATO la Tabla : [Almacen.InventarioSerie]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<InventarioSerie> List(BaseFiltroAlmacen pFiltro)
        {
            List<InventarioSerie> lstInventarioSerie = new List<InventarioSerie>();
            try
            {
                using (_AlmacenDataContext SQLDContext = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDContext.omgc_S_Inventario_ConsSerie_Paged(pFiltro.grcurrentPage, pFiltro.grpageSize, pFiltro.grsortColumn, pFiltro.grsortOrder, pFiltro.codInventario);
                    foreach (var item in resul)
                    {
                        InventarioSerie objInventarioSerie = new InventarioSerie();
                        objInventarioSerie.ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0;
                        objInventarioSerie.TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0;
                        objInventarioSerie.objProductoSerie.CodigoRegistro = item.CodigoRegistro;
                        objInventarioSerie.codInventarioSerie = item.codInventarioSerie;
                        objInventarioSerie.codInventario = item.codInventario;
                        objInventarioSerie.codProductoSeriado = item.codProductoSeriado;
                        objInventarioSerie.objProductoSerie.codProducto=item.codProducto;
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
    
    }
}

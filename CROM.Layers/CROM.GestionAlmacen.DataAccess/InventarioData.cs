namespace CROM.GestionAlmacen.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CROM.BusinessEntities.Almacen;
    using CROM.BusinessEntities.Comercial;
    
    public class InventarioData
    {
        private string conexion = string.Empty;

        public InventarioData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Inventarios
        /// En la BASE de DATO la Tabla : [Almacen.Inventarios]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<Inventario> List(BaseFiltroAlmacen pFiltro)
        {
            List<Inventario> lstInventario = new List<Inventario>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Inventario_Cons_Paged(pFiltro.grcurrentPage
                                                                  , pFiltro.grpageSize
                                                                  , pFiltro.grsortColumn
                                                                  , pFiltro.grsortOrder
                                                                  , pFiltro.codPerEmpresa
                                                                  , pFiltro.codPuntoVenta
                                                                  , pFiltro.codDeposito
                                                                  , pFiltro.codigoProducto
                                                                  , pFiltro.codPeriodo
                                                                  , pFiltro.desAgrupacion);
                    foreach (var item in resul)
                    {
                        Inventario objInventario = new Inventario();

                        objInventario.TOTALROWS = item.TOTALROWS.Value;
                        objInventario.ROW = item.ROWNUM.Value;

                        objInventario.codInventario = item.codInventario;
                        objInventario.codProducto = item.codProducto.HasValue ? item.codProducto.Value : 0;
                        objInventario.objProducto.Descripcion = item.codProductoNombre;
                        objInventario.Periodo = item.Periodo;
                        objInventario.codDeposito = item.codDeposito;
                        objInventario.objProducto.CodigoProducto = item.codigoProducto;
                        objInventario.Periodo = item.Periodo;
                        objInventario.Conteo01Empleado = item.ConteoEmpleado;
                        objInventario.Conteo01FechaHora = item.ConteoFechaHora;
                        objInventario.objEmpConteo01.objPersona.RazonSocial = item.ConteoEmpleadoNombre;
                        objInventario.cntConteoSeriado = item.ConteoSeriado.Value;
                        objInventario.cntTransacciones = item.cntTransacciones.HasValue ? item.cntTransacciones.Value : 0;

                        objInventario.CierreConteo = item.CierreConteo;
                        objInventario.CierreEmpleado = item.CierreEmpleado;
                        objInventario.objEmpCierre.objPersona.RazonSocial = item.CierreEmpleadoNombre;

                        objInventario.CierreFechaHora = item.CierreFechaHora;
                        objInventario.objDeposito.codPersonaEmpre = item.CodigoPersonaEmpre;
                        objInventario.objDeposito.codPuntoDeVenta = item.CodigoPuntoVenta;

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

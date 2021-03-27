namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/03/2011-05:08:50 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.ListaDePrecioDetalleData.cs]
    /// </summary>
    public class ListaDePrecioDetalleData
    {
        private string conexion = string.Empty;
        public ListaDePrecioDetalleData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ListaDePrecioDetalle
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecioDetalle]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<BEListaDePrecioDetalle> List(BaseFiltro filtro) 
        {
            List<BEListaDePrecioDetalle> lstListaPrecioDetalle = new List<BEListaDePrecioDetalle>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ListaDePrecioDetalle(filtro.codListaPrecio, 
                                                                  filtro.codProducto, 
                                                                  filtro.codRegMoneda, 
                                                                  filtro.indEstado);
                    foreach (var item in resul)
                    {
                        lstListaPrecioDetalle.Add(new BEListaDePrecioDetalle()
                        {
                            codListaDePrecioDetalle = item.codListaDePrecioDetalle,
                            CodigoLista = item.CodigoLista,
                            codProducto = item.codProducto,
                            CodigoProducto = item.codigoProducto,
                            CodigoArguMoneda = item.CodigoArguMoneda,
                            PrecioUnitario = item.PrecioUnitario,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaCrea = item.SegMaquina,
                            CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            CodigoProductoNombre = item.CodigoProductoNombre,
                            refEsParaVenta = item.EsParaVenta == null ? false : Convert.ToBoolean(item.EsParaVenta),

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstListaPrecioDetalle;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ListaDePrecioDetalle
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecioDetalle]
        /// <summary>
        /// <param name="listaDePrecioDetalle"></param>
        /// <returns></returns>
        public int Insert(BEListaDePrecioDetalle listaDePrecioDetalle)
        {
            int? codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_I_ListaDePrecioDetalle(
                      ref codigoRetorno,
                      listaDePrecioDetalle.CodigoLista,
                      listaDePrecioDetalle.codProducto,
                      listaDePrecioDetalle.CodigoArguMoneda,
                      listaDePrecioDetalle.PrecioUnitario,
                      listaDePrecioDetalle.Estado,
                      listaDePrecioDetalle.segUsuarioCrea);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo ListaDePrecioDetalle
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecioDetalle]
        /// <summary>
        /// <param name="lListaDePrecioDetalle"></param>
        /// <returns></returns>
        public bool Update(BEListaDePrecioDetalle listaDePrecioDetalle)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_ListaDePrecioDetalle(
                        listaDePrecioDetalle.codListaDePrecioDetalle,
                        listaDePrecioDetalle.CodigoLista,
                        listaDePrecioDetalle.codProducto,
                        listaDePrecioDetalle.CodigoArguMoneda,
                        listaDePrecioDetalle.PrecioUnitario,
                        listaDePrecioDetalle.Estado,
                        listaDePrecioDetalle.segUsuarioEdita);
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
        /// ELIMINA un registro de la Entidad GestionComercial.ListaDePrecioDetalle
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecioDetalle]
        /// <summary>
        /// <param name="prm_codListaDePrecioDetalle"></param>
        /// <returns></returns>
        public bool Delete(int prm_codListaDePrecioDetalle)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_ListaDePrecioDetalle(prm_codListaDePrecioDetalle);
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

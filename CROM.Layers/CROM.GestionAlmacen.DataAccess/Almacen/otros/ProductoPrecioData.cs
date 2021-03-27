namespace CROM.GestionAlmacen.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.Almacen;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/03/2011-05:08:50 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.ProductoPrecioData.cs]
    /// </summary>
    public class ProductoPrecioData
    {
        private string conexion = string.Empty;
        public ProductoPrecioData()
        {
            conexion = Util.ConexionBD();
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ProductoPrecio
        /// En la BASE de DATO la Tabla : [GestionComercial.ProductoPrecio]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<ProductoPrecio> List(BaseFiltro filtro)
        {
            List<ProductoPrecio> lstProductoPrecio = new List<ProductoPrecio>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ProductoPrecio(filtro.codProducto,
                                                            filtro.codRegMoneda,
                                                            filtro.codListaPrecio,
                                                            filtro.codPerEmpresa,
                                                            filtro.codPuntoVenta,
                                                            filtro.indEstado);
                    foreach (var item in resul)
                    {
                        lstProductoPrecio.Add(new ProductoPrecio()
                        {
                            codProductoPrecio = item.codProductoPrecio,
                            codProducto = item.codProducto.HasValue ? item.codProducto.Value : 0,
                            CodigoProducto = item.CodigoProducto,
                            CodigoArguMoneda = item.CodigoArguMoneda,
                            CodigoListaPrecio = item.CodigoListaPrecio,
                            ValorCosto = item.ValorCosto,
                            ValorVenta = item.ValorVenta,
                            MargenUtilidad = item.MargenUtilidad * 100,
                            MediaPorcentaje = item.MediaPorcentaje * 100,
                            PorcenComision = item.PorcenComision * 100,
                            PorcenComisionMax = item.PorcenComisionMax * 100,
                            DescuentoMaximo = item.DescuentoMaximo * 100,
                            Estado = item.Estado,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaCrea = item.SegFechaCrea,
                            SegFechaEdita = item.SegFechaEdita,
                            SegMaquina = item.SegMaquina,
                            CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            CodigoPersonaEmpre = item.CodigoPersonaEmpre,
                            CodigoPersonaEmpreNombre = item.CodigoPersonaEmpreNombre,
                            CodigoProductoNombre = item.CodigoProductoNombre,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductoPrecio;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoPrecio
        /// En la BASE de DATO la Tabla : [GestionComercial.ProductoPrecio]
        /// <summary>
        /// <param name="productoPrecio"></param>
        /// <returns></returns>
        public int Insert(ProductoPrecio productoPrecio)
        {
            int? codigoRetorno = productoPrecio.codProductoPrecio;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_mnt_Insert_ProductoPrecio(
                       ref codigoRetorno,
                       productoPrecio.codProducto,
                       productoPrecio.CodigoArguMoneda,
                       productoPrecio.CodigoListaPrecio,
                       productoPrecio.CodigoPuntoVenta,
                       productoPrecio.ValorCosto,
                       productoPrecio.ValorVenta,
                       productoPrecio.MargenUtilidad / 100,
                       productoPrecio.MediaPorcentaje / 100,
                       productoPrecio.PorcenComision / 100,
                       productoPrecio.PorcenComisionMax / 100,
                       productoPrecio.DescuentoMaximo / 100,
                       productoPrecio.Estado,
                       productoPrecio.SegUsuarioCrea);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == null ? 0 : codigoRetorno.Value;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.ProductoPrecio
        /// En la BASE de DATO la Tabla : [GestionComercial.ProductoPrecio]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public bool Delete(BaseFiltro filtro) // string prm_CodigoListaPrecio, string prm_CodigoProducto,string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, string prm_CodigoArguMoneda )
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_Delete_ProductoPrecio(filtro.codListaPrecio,
                                                                         filtro.codProducto,
                                                                         filtro.codPuntoVenta,
                                                                         filtro.codRegMoneda);
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

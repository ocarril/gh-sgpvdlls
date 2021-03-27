namespace CROM.GestionComercial.DataAccess
{
    using CROM.BusinessEntities.Almacen;
    using CROM.BusinessEntities.Comercial;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;

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
        public List<BEProductoPrecio> List(BaseFiltroProductoPrecio filtro)
        {
            List<BEProductoPrecio> lstProductoPrecio = new List<BEProductoPrecio>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ProductoPrecio(filtro.codEmpresa, 
                                                            filtro.codProducto,
                                                            filtro.codProductoPrecio,
                                                            filtro.codListaPrecio,
                                                            filtro.codPuntoVenta,
                                                            filtro.indEstado);
                    foreach (var item in resul)
                    {
                        lstProductoPrecio.Add(new BEProductoPrecio()
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
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaEdita = item.SegMaquina,
                            CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
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

        #region /* Proceso de SELECT BY ID CODE */

        public BEProductoPrecio Find(BaseFiltroProductoPrecio filtro)
        {
            BEProductoPrecio objProductoPrecio = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ProductoPrecio(filtro.codEmpresa,
                                                            filtro.codProducto,
                                                            filtro.codProductoPrecio,
                                                            null,
                                                            null,
                                                            filtro.indEstado);
                    foreach (var item in resul)
                    {
                        objProductoPrecio = new BEProductoPrecio()
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
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaEdita = item.SegMaquina,
                            CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            CodigoProductoNombre = item.CodigoProductoNombre,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objProductoPrecio;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoPrecio
        /// En la BASE de DATO la Tabla : [GestionComercial.ProductoPrecio]
        /// <summary>
        /// <param name="productoPrecio"></param>
        /// <returns></returns>
        public DTOResponseProcedure InsertUpdate(BEProductoPrecio productoPrecio)
        {
            DTOResponseProcedure codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resultInsertUpdate = SQLDC.omgc_I_ProductoPrecio(
                          productoPrecio.codProductoPrecio,
                          productoPrecio.codEmpresa,
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
                          productoPrecio.segUsuarioCrea,
                          productoPrecio.segMaquinaCrea);

                    foreach (var item in resultInsertUpdate)
                    {
                        codigoRetorno = new DTOResponseProcedure
                        {
                            ErrorCode = item.ErrorCode,
                            ErrorMessage = item.ErrorMessage
                        };
                    }
                    return codigoRetorno;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.ProductoPrecio
        /// En la BASE de DATO la Tabla : [GestionComercial.ProductoPrecio]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public DTOResponseProcedure Delete(BaseFiltroProductoPrecio filtro) 
        {
            DTOResponseProcedure codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var reslutDelete = SQLDC.omgc_D_ProductoPrecio(filtro.codEmpresa,
                                                                  filtro.codProductoPrecio,
                                                                  filtro.segUsuarioActual,
                                                                  filtro.segIPMaquinaPC);
                    foreach (var item in reslutDelete)
                    {
                        codigoRetorno = new DTOResponseProcedure
                        {
                            ErrorCode = item.ErrorCode.HasValue ? item.ErrorCode.Value : 0,
                            ErrorMessage = item.ErrorMessage
                        };
                    }
                    return codigoRetorno;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
} 

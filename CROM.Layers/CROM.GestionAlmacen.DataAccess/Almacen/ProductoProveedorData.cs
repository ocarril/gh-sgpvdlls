namespace CROM.GestionAlmacen.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Almacen;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Almacen.ProductoProveedoresData.cs]
    /// </summary>
    public class ProductoProveedorData
    {
        private string conexion = string.Empty;
        public ProductoProveedorData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        ///// <summary>
        ///// Almacena el registro de una ENTIDAD de registro de Tipo ProductoProveedores
        ///// En la BASE de DATO la Tabla : [Almacen.ProductoProveedores]
        ///// <summary>
        ///// <param name="productoProveedor"></param>
        ///// <returns></returns>
        //public int Insert(BEProductoProveedor productoProveedor)
        //{
        //    int? codigoRetorno = -1;
        //    try
        //    {
        //        using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
        //        {
        //            SQLDC.omgc_IU_ProductoProveedor( ref codigoRetorno,
        //                                             productoProveedor.codProducto,
        //                                             productoProveedor.CodigoPersona,
        //                                             productoProveedor.Estado,
        //                                             productoProveedor.segUsuarioCrea,
        //                                             productoProveedor.segMaquinaCrea);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == null ? 0 : codigoRetorno.Value;
        //}

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        ///// <summary>
        ///// ELIMINA un registro de la Entidad Almacen.ProductoProveedores
        ///// En la BASE de DATO la Tabla : [Almacen.ProductoProveedores]
        ///// <summary>
        ///// <param name="pDelete"></param>
        ///// <returns></returns>
        //public bool Delete(BEProductoProveedor pDelete) 
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
        //        {
        //            codigoRetorno = SQLDC.omgc_D_ProductoProveedor(pDelete.codEmpresa, 
        //                                                           pDelete.codProductoProveedor, 
        //                                                           pDelete.codProducto, 
        //                                                           pDelete.CodigoPersona,
        //                                                           pDelete.segUsuarioElimina,
        //                                                           pDelete.segMaquinaElimina);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == 0 ? true : false;
        //}

        #endregion

        #region /* Proceso de SELECT ALL */

        ///// <summary>
        ///// Retorna un LISTA de registros de la Entidad Almacen.ProductoProveedores
        ///// En la BASE de DATO la Tabla : [Almacen.ProductoProveedores]
        ///// <summary>
        ///// <param name="filtro"></param>
        ///// <returns></returns>
        //public List<BEProductoProveedor> List(BaseFiltroProductoProveedor filtro) 
        //{
        //    List<BEProductoProveedor> lstProveedor = new List<BEProductoProveedor>();
        //    try
        //    {
        //        using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
        //        {
        //            var resul = SQLDC.omgc_S_ProductoProveedor(filtro.codEmpresa,
        //                                                       filtro.codProductoProveedor,
        //                                                       filtro.codProducto,
        //                                                       filtro.codPersonaProveedor,
        //                                                       filtro.indActivo);
        //            foreach (var item in resul)
        //            {
        //                lstProveedor.Add(new BEProductoProveedor()
        //                {
        //                    codProductoProveedor = item.codProductoProveedor,
        //                    codProducto = item.codProducto,
        //                    codigoProducto = item.CodigoProducto,
        //                    CodigoPersona = item.CodigoPersona,
        //                    CodigoPersonaNombre = item.CodigoPersonaNombre,
        //                    Estado = item.Estado,
        //                    segUsuarioCrea = item.SegUsuarioCrea,
        //                    segUsuarioEdita = item.SegUsuarioEdita,
        //                    segFechaCrea = item.SegFechaCrea,
        //                    segFechaEdita = item.SegFechaEdita,
        //                    segMaquinaEdita = item.SegMaquina,

        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstProveedor;
        //}

        //public List<DTOProductoProveedorResponse> ListPaged(BaseFiltroProductoProveedor filtro)
        //{
        //    List<DTOProductoProveedorResponse> lstProveedor = new List<DTOProductoProveedorResponse>();
        //    try
        //    {
        //        using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
        //        {
        //            var resul = SQLDC.omgc_S_ProductoProveedor_Paged(filtro.jqCurrentPage,
        //                                                             filtro.jqPageSize,
        //                                                             filtro.jqSortColumn,
        //                                                             filtro.jqSortOrder,
        //                                                             filtro.codEmpresa,
        //                                                             filtro.codProducto,
        //                                                             filtro.codPersonaProveedor,
        //                                                             filtro.indActivo);
        //            foreach (var item in resul)
        //            {
        //                lstProveedor.Add(new DTOProductoProveedorResponse()
        //                {
        //                    ROWNUM = item.ROWNUM.Value,
        //                    TOTALROWS = item.TOTALROWS.Value,                              
        //                    codProductoProveedor = item.codProductoProveedor,
        //                     codPersona= item.CodigoPersona,
        //                    codigoProducto = item.CodigoProducto,
        //                    codPersonaNombre = item.CodigoPersonaNombre,
        //                    Estado = item.Estado,
        //                    segFechaEdita = item.segFechaEdita,
        //                    segUsuarioEdita = item.segUsuarioEdita,

        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstProveedor;
        //}


        #endregion


        #region /* Proceso de SELECT BY ID */

        ///// <summary>
        ///// Retorna un LISTA de registros de la Entidad Almacen.ProductoProveedores
        ///// En la BASE de DATO la Tabla : [Almacen.ProductoProveedores]
        ///// <summary>
        ///// <param name="filtro"></param>
        ///// <returns></returns>
        //public BEProductoProveedor Find(BaseFiltroProductoProveedor filtro)
        //{
        //    BEProductoProveedor objProductoProveedor = null;
        //    try
        //    {
        //        using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
        //        {
        //            var resul = SQLDC.omgc_S_ProductoProveedor(filtro.codEmpresa,
        //                                                       filtro.codProductoProveedor,
        //                                                       filtro.codProducto,
        //                                                       filtro.codPersonaProveedor,
        //                                                       filtro.indActivo);
        //            foreach (var item in resul)
        //            {
        //                objProductoProveedor= new BEProductoProveedor()
        //                {
        //                    codProductoProveedor = item.codProductoProveedor,
        //                    codProducto = item.codProducto,
        //                    codigoProducto = item.CodigoProducto,
        //                    CodigoPersona = item.CodigoPersona,
        //                    CodigoPersonaNombre = item.CodigoPersonaNombre,
        //                    Estado = item.Estado,
        //                    segUsuarioCrea = item.SegUsuarioCrea,
        //                    segUsuarioEdita = item.SegUsuarioEdita,
        //                    segFechaCrea = item.SegFechaCrea,
        //                    segFechaEdita = item.SegFechaEdita,
        //                    segMaquinaEdita = item.SegMaquina,

        //                };
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return objProductoProveedor;
        //}

        #endregion
    }
} 

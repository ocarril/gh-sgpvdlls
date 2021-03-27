namespace CROM.GestionAlmacen.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Almacen;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 25/02/2011-1:25:15
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Almacen.ProductoPartesCompuestaData.cs]
    /// </summary>
    public class ProductoPartesCompuestaData
    {
        private string conexion = string.Empty;
        public ProductoPartesCompuestaData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.ProductoPartesCompuesta
        /// En la BASE de DATO la Tabla : [Almacen.ProductoPartesCompuesta]
        /// <summary>
        /// <returns>List</returns>
        public List<BEProductoParteCompuesta> List(string prm_CodigoProducto, string prm_CodigoProductoParte)
        {
            List<BEProductoParteCompuesta> miLista = new List<BEProductoParteCompuesta>();
            try
            {
                //using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                //{
                //    var resul = SQLDC.omgc_mnt_GetAll_ProductoPartesCompuesta(prm_CodigoProducto, prm_CodigoProductoParte);
                //    foreach (var item in resul)
                //    {
                //        miLista.Add(new ProductoPartesCompuesta()
                //        {
                //        CodigoProducto = item.CodigoProducto,
                //        CodigoProductoNombre=item.CodigoProductoNombre,
                //        CodigoProductoParte = item.CodigoProductoParte,
                //        CodigoProductoParteNombre = item.CodigoProductoParteNombre,
                //        CodigoArguUnidadMedC = item.CodigoArguUnidadMedC,
                //        CodigoArguUnidadMedP = item.CodigoArguUnidadMedP,
                //        CodigoArguUnidadMedCNombre = item.CodigoArguUnidadMedCNombre,
                //        CodigoArguUnidadMedPNombre = item.CodigoArguUnidadMedPNombre,
                //        Cantidad = item.Cantidad,
                //        DescontarStock = item.DescontarStock,
                //        Estado = item.Estado,
                //        SegUsuarioCrea = item.SegUsuarioCrea,
                //        SegUsuarioEdita = item.SegUsuarioEdita,
                //        SegFechaCrea = item.SegFechaCrea,
                //        SegFechaEdita = item.SegFechaEdita,
                //        SegMaquina = item.SegMaquina,

                //        });
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }
        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.ProductoPartesCompuesta
        /// En la BASE de DATO la Tabla : [Almacen.ProductoPartesCompuesta]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEProductoParteCompuesta Find(string prm_CodigoProducto, string prm_CodigoProductoParte)
        {
            BEProductoParteCompuesta miEntidad = new BEProductoParteCompuesta();
            try
            {
                //using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                //{
                //    var resul = SQLDC.omgc_mnt_GetByIdCodeProductoPartesCompuesta(prm_CodigoProducto, prm_CodigoProductoParte);
                //    foreach (var item in resul)
                //    {
                //        miEntidad = new ProductoPartesCompuesta()
                //        {
                //            CodigoProducto = item.CodigoProducto,
                //            CodigoProductoParte = item.CodigoProductoParte,
                //            CodigoArguUnidadMedC = item.CodigoArguUnidadMedC,
                //            CodigoArguUnidadMedP = item.CodigoArguUnidadMedP,
                //            Cantidad = item.Cantidad,
                //            DescontarStock = item.DescontarStock,
                //            Estado = item.Estado,
                //            SegUsuarioCrea = item.SegUsuarioCrea,
                //            SegUsuarioEdita = item.SegUsuarioEdita,
                //            SegFechaCrea = item.SegFechaCrea,
                //            SegFechaEdita = item.SegFechaEdita,
                //            SegMaquina = item.SegMaquina,

                //        };
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miEntidad;
        }
        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoPartesCompuesta
        /// En la BASE de DATO la Tabla : [Almacen.ProductoPartesCompuesta]
        /// <summary>
        /// <param name = >itemProductoPartesCompuesta</param>
        public bool Insert(BEProductoParteCompuesta itemProductoPartesCompuesta)
        {
            int codigoRetorno = -1;
            try
            {
                //using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                //{
                //    codigoRetorno = SQLDC.omgc_mnt_InsertProductoPartesCompuesta(
                //        itemProductoPartesCompuesta.CodigoProducto,
                //        itemProductoPartesCompuesta.CodigoProductoParte,
                //        itemProductoPartesCompuesta.CodigoArguUnidadMedP,
                //        itemProductoPartesCompuesta.CodigoArguUnidadMedC,
                //        itemProductoPartesCompuesta.Cantidad,
                //        itemProductoPartesCompuesta.DescontarStock,
                //        itemProductoPartesCompuesta.Estado,
                //        itemProductoPartesCompuesta.SegUsuarioCrea
                //        );
                //}
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoPartesCompuesta
        /// En la BASE de DATO la Tabla : [Almacen.ProductoPartesCompuesta]
        /// <summary>
        /// <param name = >itemProductoPartesCompuesta</param>
        public bool Update(BEProductoParteCompuesta itemProductoPartesCompuesta)
        {
            int codigoRetorno = -1;
            try
            {
                //using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                //{
                //    codigoRetorno = SQLDC.omgc_mnt_UpdateProductoPartesCompuesta(
                //        itemProductoPartesCompuesta.CodigoProducto,
                //        itemProductoPartesCompuesta.CodigoProductoParte,
                //        itemProductoPartesCompuesta.CodigoArguUnidadMedP,
                //        itemProductoPartesCompuesta.CodigoArguUnidadMedC,
                //        itemProductoPartesCompuesta.Cantidad,
                //        itemProductoPartesCompuesta.DescontarStock,
                //        itemProductoPartesCompuesta.Estado,
                //        itemProductoPartesCompuesta.SegUsuarioEdita
                //        );
                //}
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
        /// ELIMINA un registro de la Entidad Almacen.ProductoPartesCompuesta
        /// En la BASE de DATO la Tabla : [Almacen.ProductoPartesCompuesta]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(string prm_CodigoProducto, string prm_CodigoProductoParte)
        {
            int codigoRetorno = -1;
            try
            {
                //using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                //{
                //    codigoRetorno = SQLDC.omgc_mnt_DeleteProductoPartesCompuesta(prm_CodigoProducto,prm_CodigoProductoParte);
                //}
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

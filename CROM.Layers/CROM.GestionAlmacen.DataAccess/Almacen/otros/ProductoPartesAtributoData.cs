namespace CROM.GestionAlmacen.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Almacen;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Produccion.ProductoPartesAtributoData.cs]
    /// </summary>
    public class ProductoPartesAtributoData
    {
        private string conexion = string.Empty;
        public ProductoPartesAtributoData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoPartesAtributo
        /// En la BASE de DATO la Tabla : [Produccion.ProductoPartesAtributo]
        /// <summary>
        /// <param name = >itemProductoPartesAtributo</param>
        public bool InsertUpdate(BEProductoParteAtributo itemProductoPartesAtributo)
        {
            int codigoRetorno = -1;
            try
            {
                //using (_ProduccionDataContext SQLDC = new _ProduccionDataContext(conexion))
                //{
                //    codigoRetorno = SQLDC.omgc_mnt_InsertProductoPartesAtributo(
                //        itemProductoPartesAtributo.CodigoProducto,
                //        itemProductoPartesAtributo.CodigoArguParteProdu,
                //        itemProductoPartesAtributo.CodigoArguAtributoPP,
                //        itemProductoPartesAtributo.Valor,
                //        itemProductoPartesAtributo.Tolerancia,
                //        itemProductoPartesAtributo.Estado,
                //        itemProductoPartesAtributo.SegUsuarioCrea);
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
        /// ELIMINA un registro de la Entidad Produccion.ProductoPartesAtributo
        /// En la BASE de DATO la Tabla : [Produccion.ProductoPartesAtributo]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(string prm_CodigoProducto, string prm_CodigoArguParteProdu, string prm_CodigoArguAtributoPP)
        {
            int codigoRetorno = -1;
            try
            {
                //using (_ProduccionDataContext SQLDC = new _ProduccionDataContext(conexion))
                //{
                //    codigoRetorno = SQLDC.omgc_mnt_DeleteProductoPartesAtributo(prm_CodigoProducto, prm_CodigoArguParteProdu, prm_CodigoArguAtributoPP);
                //}
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
        /// Retorna un LISTA de registros de la Entidad Produccion.ProductoPartesAtributo
        /// En la BASE de DATO la Tabla : [Produccion.ProductoPartesAtributo]
        /// <summary>
        /// <returns>List</returns>
        public List<BEProductoParteAtributo> List(string prm_CodigoProducto, string prm_CodigoArguParteProdu, string prm_CodigoArguAtributoPP, bool prm_Estado)
        {
            List<BEProductoParteAtributo> miLista = new List<BEProductoParteAtributo>();
            try
            {
                //using (_ProduccionDataContext SQLDC = new _ProduccionDataContext(conexion))
                //{
                //    var resul = SQLDC.omgc_mnt_GetAllFromProductoPartesAtributo(prm_CodigoProducto, prm_CodigoArguParteProdu, prm_CodigoArguAtributoPP, prm_Estado );
                //    foreach (var item in resul)
                //    {
                //        miLista.Add(new ProductoPartesAtributo()
                //        {
                //            CodigoProducto = item.CodigoProducto,
                //            CodigoArguParteProdu = item.CodigoArguParteProdu,
                //            CodigoArguAtributoPP = item.CodigoArguAtributoPP,
                //            Valor = item.Valor,
                //            Tolerancia = item.Tolerancia,
                //            Estado = item.Estado,
                //            SegUsuarioCrea = item.SegUsuarioCrea,
                //            SegUsuarioEdita = item.SegUsuarioEdita,
                //            SegFechaCrea = item.SegFechaCrea,
                //            SegFechaEdita = item.SegFechaEdita,
                //            SegMaquina = item.SegMaquina,

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

    }
} 

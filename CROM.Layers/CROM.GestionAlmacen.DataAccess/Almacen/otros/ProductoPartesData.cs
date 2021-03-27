using System;
using System.Collections.Generic;
using System.Configuration;

using CROM.GestionComercial.BusinessEntities;

namespace CROM.GestionComercial.DataAccess
{
    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Produccion.ProductoPartesData.cs]
    /// </summary>
    public class ProductoPartesData
    {
        private string conexion = string.Empty;
        public ProductoPartesData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnxCROMSystema"].ConnectionString;
        }
        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoPartes
        /// En la BASE de DATO la Tabla : [Produccion.ProductoPartes]
        /// <summary>
        /// <param name = >itemProductoPartes</param>
        public bool InsertUpdate(ProductoPartes itemProductoPartes)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ProduccionDataContext SQLDC = new _ProduccionDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_InsertUpdate_ProductoParte(
                        itemProductoPartes.codPersonaEmpre,
                        itemProductoPartes.CodigoProducto,
                        itemProductoPartes.CodigoArguParteProdu,
                        itemProductoPartes.Estado,
                        itemProductoPartes.SegUsuarioCrea);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* << NO ESTA INCLUIDO >> Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoPartes
        /// En la BASE de DATO la Tabla : [Produccion.ProductoPartes]
        /// <summary>
        /// <param name = >itemProductoPartes</param>
        //public bool Update(ProductoPartes itemProductoPartes)
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            codigoRetorno = SQLDC.omgc_mnt_UpdateProductoPartes(
        //                itemProductoPartes.CodigoProducto,
        //                itemProductoPartes.CodigoArguParteProdu,
        //                itemProductoPartes.Estado,
        //                itemProductoPartes.SegUsuarioCrea,
        //                itemProductoPartes.SegUsuarioEdita,
        //                itemProductoPartes.SegFechaCrea,
        //                itemProductoPartes.SegFechaEdita,
        //                itemProductoPartes.SegMaquina);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == 0 ? true : false;
        //}
        
        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Produccion.ProductoPartes
        /// En la BASE de DATO la Tabla : [Produccion.ProductoPartes]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(string prm_codPersonaEmpre, string prm_CodigoProducto, string prm_CodigoArguParteProdu)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ProduccionDataContext SQLDC = new _ProduccionDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_Delete_ProductoParte(prm_codPersonaEmpre, prm_CodigoProducto, prm_CodigoArguParteProdu);
                }
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
        /// Retorna un LISTA de registros de la Entidad Produccion.ProductoPartes
        /// En la BASE de DATO la Tabla : [Produccion.ProductoPartes]
        /// <summary>
        /// <returns>List</returns>
        public List<ProductoPartes> List(string prm_codPersonaEmpre, string prm_CodigoProducto, string prm_CodigoArguParteProdu, bool prm_Estado )
        {
            List<ProductoPartes> miLista = new List<ProductoPartes>();
            try
            {
                using (_ProduccionDataContext SQLDC = new _ProduccionDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_GetAll_ProductoParte(prm_codPersonaEmpre, prm_CodigoProducto, prm_CodigoArguParteProdu, prm_Estado);
                    foreach (var item in resul)
                    {
                        miLista.Add(new ProductoPartes()
                        {
                            CodigoProducto = item.CodigoProducto,
                            CodigoArguParteProdu = item.CodigoArguParteProdu,
                            Estado = item.Estado,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaCrea = item.SegFechaCrea,
                            SegFechaEdita = item.SegFechaEdita,
                            SegMaquina = item.SegMaquina,
                            codPersonaEmpre = item.codPersonaEmpre,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        #endregion

        #region /* << NO ESTA INCLUIDO >>  Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Produccion.ProductoPartes
        /// En la BASE de DATO la Tabla : [Produccion.ProductoPartes]
        /// <summary>
        /// <returns>Entidad</returns>
        //public ProductoPartes Find(string prm_CodigoProducto, string prm_CodigoArguParteProdu)
        //{
        //    ProductoPartes miEntidad = new ProductoPartes();
        //    try
        //    {
        //        using (_ProduccionDataContext SQLDC = new _ProduccionDataContext(conexion))
        //        {
        //            var resul = SQLDC.omgc_mnt_GetByIdCodeProductoPartes(prm_CodigoProducto, prm_CodigoArguParteProdu);
        //            foreach (var item in resul)
        //            {
        //                miEntidad = new ProductoPartes()
        //                {
        //                    CodigoProducto = item.CodigoProducto,
        //                    CodigoArguParteProdu = item.CodigoArguParteProdu,
        //                    Estado = item.Estado,
        //                    SegUsuarioCrea = item.SegUsuarioCrea,
        //                    SegUsuarioEdita = item.SegUsuarioEdita,
        //                    SegFechaCrea = item.SegFechaCrea,
        //                    SegFechaEdita = item.SegFechaEdita,
        //                    SegMaquina = item.SegMaquina,

        //                };
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return miEntidad;
        //}
       
        #endregion

    }
} 

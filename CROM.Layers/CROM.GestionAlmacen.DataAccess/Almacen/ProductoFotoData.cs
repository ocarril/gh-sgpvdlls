namespace CROM.GestionAlmacen.DataAccess
{
    using CROM.BusinessEntities.Almacen;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Almacen.ProductoFotosData.cs]
    /// </summary>
    public class ProductoFotoData
    {
        private string conexion = string.Empty;
        public ProductoFotoData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoFoto
        /// En la BASE de DATO la Tabla : [Almacen.ProductoFotos]
        /// <summary>
        /// <param name="itemProductoFotos"></param>
        /// <returns></returns>
        public DTOResponseProcedure InsertUpdate(BEProductoFoto productoFoto)
        {
            DTOResponseProcedure codigoRetorno = null;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var result = SQLDC.omgc_I_ProductoFoto(productoFoto.codProducto,
                                                           productoFoto.FotografiaF,
                                                           productoFoto.Fotografia,
                                                           productoFoto.Estado,
                                                           productoFoto.segUsuarioCrea,
                                                           productoFoto.segMaquinaEdita);
                    foreach (var item in result)
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

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.ProductoFotos
        /// En la BASE de DATO la Tabla : [Almacen.ProductoFotos]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public bool Delete(int pcodId, int pcodProducto) 
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_ProductoFoto(pcodId, 
                                                              pcodProducto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.ProductoFotos
        /// En la BASE de DATO la Tabla : [Almacen.ProductoFotos]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public BEProductoFoto Find(int pcodEmpresa, int pcodProducto, int? pcodProductoFoto)
        {
            BEProductoFoto productoFoto = null;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ProductoFoto(pcodEmpresa,
                                                          pcodProducto,
                                                          pcodProductoFoto.HasValue ? pcodProductoFoto.Value : 0);
                    foreach (var item in resul)
                    {
                        productoFoto = new BEProductoFoto()
                        {
                            codProductoFoto = item.codProductoFoto,
                            codProducto = item.codProducto,
                            CodigoProducto = item.codigoProducto,
                            FotografiaF = convertirVarBinary(item.imgFotografia),
                            Fotografia = item.desFotografia,
                            Estado = item.indActivo,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productoFoto;
        }

        public List<BEProductoFoto> List(int pcodEmpresa, int pcodProducto)
        {
            List<BEProductoFoto> LstProductoFoto = new List<BEProductoFoto>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ProductoFoto(pcodEmpresa,
                                                          pcodProducto,
                                                          null);
                    foreach (var item in resul)
                    {
                        BEProductoFoto itemProductoFoto = new BEProductoFoto()
                        {
                            codProductoFoto = item.codProductoFoto,
                            codProducto = item.codProducto,
                            CodigoProducto = item.codigoProducto,
                            FotografiaF = convertirVarBinary(item.imgFotografia),
                            Fotografia = item.desFotografia,
                            Estado = item.indActivo,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                        };
                        LstProductoFoto.Add(itemProductoFoto);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return LstProductoFoto;
        }

        #endregion

        private byte[] convertirVarBinary(System.Data.Linq.Binary miVarBinary)
        {
            if (miVarBinary != null)
            {
                byte[] Foto = miVarBinary.ToArray();
                return (Foto);
            }
            else
                return (null);
        }
    }
} 

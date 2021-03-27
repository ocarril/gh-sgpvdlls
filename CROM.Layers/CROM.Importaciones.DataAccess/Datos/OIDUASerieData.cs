namespace CROM.Importaciones.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Importaciones;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 10/10/2014-12:36:46 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Importaciones.OIDUASerieData.cs]
    /// </summary>
    public class OIDUASerieData
    {
        private string conexion = string.Empty;
        public OIDUASerieData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Importaciones.OIDUASerie
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUASerie]
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEOIDUASerie> List(BaseFiltroImp pFiltro)
        {
            List<BEOIDUASerie> lstOIDUASerie = new List<BEOIDUASerie>();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIDUASerie(pFiltro.codOIDUASerie, pFiltro.codOIDUAProducto);
                    foreach (var item in resul)
                    {
                        lstOIDUASerie.Add(new BEOIDUASerie()
                        {
                            codOIDUASerie = item.codOIDUASerie,
                            codOIDUAProducto = item.codOIDUAProducto,
                            codProductoSeriado = item.codProductoSeriado,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            auxcodRegEstadoSerie = item.codRegEstadoMercaderia,
                            auxcodRegEstadoSerieNombre = item.codRegEstadoMercaderiaNombre,
                            auxNumeroDocumentoCompra = item.NumeroComprobanteCompra,
                            auxNumeroSerie = item.NumeroSerie
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOIDUASerie;
        }

        public List<BEOIDUASerie> ListProducto(BaseFiltroImp pFiltro)
        {
            List<BEOIDUASerie> lstOIDUASerie = new List<BEOIDUASerie>();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIDUASerieProducto(pFiltro.codOIDUAProducto);
                    foreach (var item in resul)
                    {
                        lstOIDUASerie.Add(new BEOIDUASerie()
                        {
                            codOIDUAProducto = item.codOIDUAProducto,
                            codProductoSeriado = item.codProductoSeriado,
                            auxcodRegEstadoSerie = item.codRegEstadoMercaderia,
                            auxcodRegEstadoSerieNombre = item.codRegEstadoMercaderiaNombre,
                            auxNumeroDocumentoCompra = item.NumeroComprobanteCompra,
                            auxNumeroSerie = item.NumeroSerie,
                            auxcodDocumRegDetalle = item.codDocumRegDetalle
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOIDUASerie;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Importaciones.OIDUASerie
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUASerie]
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public BEOIDUASerie Find(BaseFiltroImp pFiltro)
        {
            BEOIDUASerie itemOIDUASerie = new BEOIDUASerie();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIDUASerie(pFiltro.codOIDUASerie, null);
                    foreach (var item in resul)
                    {
                        itemOIDUASerie = new BEOIDUASerie()
                        {
                            codOIDUASerie = item.codOIDUASerie,
                            codOIDUAProducto = item.codOIDUAProducto,
                            codProductoSeriado = item.codProductoSeriado,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            auxcodRegEstadoSerie = item.codRegEstadoMercaderia,
                            auxcodRegEstadoSerieNombre = item.codRegEstadoMercaderiaNombre,
                            auxNumeroDocumentoCompra = item.NumeroComprobanteCompra,
                            auxNumeroSerie = item.NumeroSerie

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemOIDUASerie;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDUASerie
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUASerie]
        /// <param name="pOIDUASerie"></param>
        /// <returns></returns>
        public bool Insert(List<BEOIDUASerie> plstOIDUASerie)
        {
            int? codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    foreach (BEOIDUASerie pOIDUASerie in plstOIDUASerie)
                    {
                        SQLDC.omgc_I_OIDUASerie(
                           ref codigoRetorno,
                           pOIDUASerie.codOIDUAProducto,
                           pOIDUASerie.codProductoSeriado,
                           pOIDUASerie.indActivo,
                           pOIDUASerie.segUsuarioCrea);
                        pOIDUASerie.codOIDUASerie = codigoRetorno.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno > 0 ? true : false;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDUASerie
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUASerie]
        /// <param name="pOIDUASerie"></param>
        /// <returns></returns>
        public bool Update(List<BEOIDUASerie> plstOIDUASerie)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    foreach (BEOIDUASerie pOIDUASerie in plstOIDUASerie)
                    {
                        SQLDC.omgc_U_OIDUASerie(
                            pOIDUASerie.codOIDUASerie,
                            pOIDUASerie.codOIDUAProducto,
                            pOIDUASerie.codProductoSeriado,
                            pOIDUASerie.indActivo,
                            pOIDUASerie.segUsuarioEdita
                            );
                        codigoRetorno = 0;
                    }
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
        /// ELIMINA un registro de la Entidad Importaciones.OIDUASerie
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUASerie]
        /// <param name="lstOIDUASerie"></param>
        /// <returns></returns>
        public bool Delete(List<BEOIDUASerie> lstOIDUASerie)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    foreach (BEOIDUASerie item in lstOIDUASerie)
                        SQLDC.omgc_D_OIDUASerie(item.codOIDUASerie);
                    codigoRetorno = 0;
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

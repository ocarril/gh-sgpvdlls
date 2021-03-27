namespace CROM.Importaciones.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Importaciones;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/08/2014-01:23:29 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Importaciones.OIDUAProductoData.cs]
    /// </summary>
    public class OIDUAProductoData
    {
        private string conexion = string.Empty;

        public OIDUAProductoData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Importaciones.OIDUAProducto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUAProducto]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEOIDUAProducto> List(BaseFiltroImp pFiltro)
        {
            List<BEOIDUAProducto> lstOIDUAProducto = new List<BEOIDUAProducto>();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIDUAProducto(pFiltro.codOIDUAProducto, pFiltro.codOIDUA);
                    foreach (var item in resul)
                    {
                        lstOIDUAProducto.Add(new BEOIDUAProducto()
                        {
                            codOIDUAProducto = item.codOIDUAProducto,
                            codOIDUA = item.codOIDUA,
                            codDocumRegDetalle = item.codDocumRegDetalle,
                            decCantidadFOB = item.decCantidadFOB,
                            decPrecioUniFOB = item.decPrecioUniFOB,
                            decTotalUniFOB = item.decTotalUniFOB,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            auxdesProducto = item.desProducto,
                            auxdecCantidadFOBmax = item.decCantidadPendiente == null ? 0 : item.decCantidadPendiente.Value,
                            decPrecioUniCosto = item.decPrecioUniCosto,
                            decTotalUniCosto = item.decTotalUniCosto
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOIDUAProducto;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Importaciones.OIDUAProducto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUAProducto]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public BEOIDUAProducto Find(BaseFiltroImp pFiltro)
        {
            BEOIDUAProducto oIDUAProducto = new BEOIDUAProducto();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIDUAProducto(pFiltro.codOIDUAProducto, null);
                    foreach (var item in resul)
                    {
                        oIDUAProducto = new BEOIDUAProducto()
                        {
                            codOIDUAProducto = item.codOIDUAProducto,
                            codOIDUA = item.codOIDUA,
                            codDocumRegDetalle = item.codDocumRegDetalle,
                            decCantidadFOB = item.decCantidadFOB,
                            decPrecioUniFOB = item.decPrecioUniFOB,
                            decTotalUniFOB = item.decTotalUniFOB,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            auxdesProducto = item.desProducto,
                            auxdecCantidadFOBmax = item.decCantidadPendiente == null ? 0 : item.decCantidadPendiente.Value
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oIDUAProducto;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDUAProducto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUAProducto]
        /// </summary>
        /// <param name="oIDUAProducto"></param>
        /// <returns></returns>
        public bool Insert(BEOIDUAProducto oIDUAProducto)
        {
            int? codigoRetorno = null;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    SQLDC.omgc_I_OIDUAProducto(
                        ref codigoRetorno,
                        oIDUAProducto.codOIDUA,
                        oIDUAProducto.codDocumRegDetalle,
                        oIDUAProducto.decCantidadFOB,
                        oIDUAProducto.decPrecioUniFOB,
                        oIDUAProducto.decTotalUniFOB,
                        oIDUAProducto.indActivo,
                        oIDUAProducto.segUsuarioCrea);
                    oIDUAProducto.codOIDUAProducto = codigoRetorno.Value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno.HasValue ? true : false;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDUAProducto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUAProducto]
        /// <summary>
        /// <param name = >itemOIDUAProducto</param>
        public bool Update(BEOIDUAProducto itemOIDUAProducto)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    SQLDC.omgc_U_OIDUAProducto(
                       itemOIDUAProducto.codOIDUAProducto,
                       itemOIDUAProducto.codOIDUA,
                       itemOIDUAProducto.decCantidadFOB,
                       itemOIDUAProducto.indActivo,
                       itemOIDUAProducto.segUsuarioEdita);
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

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Importaciones.OIDUAProducto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUAProducto]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public bool Delete(List<BEOIDUAProducto> plstOIDUAProducto, string pUsuario)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    foreach (BEOIDUAProducto oiDUAProducto in plstOIDUAProducto)
                        SQLDC.omgc_D_OIDUAProducto(oiDUAProducto.codOIDUAProducto, oiDUAProducto.codOIDUA, pUsuario);
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

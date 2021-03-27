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
    /// Archivo     : [Importaciones.OIDocumentoData.cs]
    /// </summary>
    public class OIDocumentoData
    {
        private string conexion = string.Empty;
        public OIDocumentoData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Importaciones.OIDocumento
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumento]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEOIDocumento> List(BaseFiltroImp pFiltro)
        {
            List<BEOIDocumento> lstOIDocumento = new List<BEOIDocumento>();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIDocumento(null, pFiltro.codOrdenImportacion);
                    foreach (var item in resul)
                    {
                        lstOIDocumento.Add(new BEOIDocumento()
                        {
                            codOIDocumento = item.codOIDocumento,
                            codOrdenImportacion = item.codOrdenImportacion,
                            desNombreArchivo = item.desNombreArchivo,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            auxVistaParcial = item.desVistaParcial
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOIDocumento;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Importaciones.OIDocumento
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumento]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public BEOIDocumento Find(BaseFiltroImp pFiltro)
        {
            BEOIDocumento oIDocumento = new BEOIDocumento();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIDocumento(pFiltro.codOIDocumento, null);
                    foreach (var item in resul)
                    {
                        oIDocumento = new BEOIDocumento()
                        {
                            codOIDocumento = item.codOIDocumento,
                            codOrdenImportacion = item.codOrdenImportacion,
                            desNombreArchivo = item.desNombreArchivo,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            auxVistaParcial = item.desVistaParcial
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oIDocumento;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        public bool Insert(BEOIDocumento pOIDocumento)
        {
            int? codigoRetorno = null;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {

                    SQLDC.omgc_I_OIDocumento(
                      ref codigoRetorno,
                      pOIDocumento.codOrdenImportacion,
                      pOIDocumento.desNombreArchivo,
                      pOIDocumento.indActivo,
                      pOIDocumento.segUsuarioCrea);
                    pOIDocumento.codOIDocumento = codigoRetorno.Value;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno > 0 ? true : false;
        }

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDocumento
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumento]
        /// </summary>
        /// <param name="plstOIDocumento"></param>
        /// <returns></returns>
        public bool Insert(List<BEOIDocumento> plstOIDocumento)
        {
            int? codigoRetorno = null;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    foreach (BEOIDocumento oIDocumento in plstOIDocumento)
                    {
                        SQLDC.omgc_I_OIDocumento(
                          ref codigoRetorno,
                          oIDocumento.codOrdenImportacion,
                          oIDocumento.desNombreArchivo,
                          oIDocumento.indActivo,
                          oIDocumento.segUsuarioCrea);
                        oIDocumento.codOIDocumento = codigoRetorno.Value;
                    }
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

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDocumento
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumento]
        /// <summary>
        /// <param name = >pOIDocumento</param>
        public bool Update(BEOIDocumento pOIDocumento)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    SQLDC.omgc_U_OIDocumento(
                       pOIDocumento.codOIDocumento,
                       pOIDocumento.codOrdenImportacion,
                       pOIDocumento.desNombreArchivo,
                       pOIDocumento.indActivo,
                       pOIDocumento.segUsuarioEdita);
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
        /// ELIMINA un registro de la Entidad Importaciones.OIDocumento
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumento]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public bool Delete(BaseFiltroImp pFiltro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    SQLDC.omgc_D_OIDocumento(pFiltro.codOIDocumento, pFiltro.codOrdenImportacion);
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
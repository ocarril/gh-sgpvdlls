namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/08/2014-01:23:29 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.DocumentoEstadoData.cs]
    /// </summary>
    public class DocumentoEstadoData
    {
        private string conexion = string.Empty;

        public DocumentoEstadoData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.DocumentoEstado
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoEstado]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumentoEstado> List(BaseFiltro pFiltro)
        {
            List<BEDocumentoEstado> lstDocumentoEstado = new List<BEDocumentoEstado>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumentoEstado(null, pFiltro.codRegDocumento, pFiltro.codRegEstado);
                    foreach (var item in resul)
                    {
                        lstDocumentoEstado.Add(new BEDocumentoEstado()
                        {
                            codDocumentoEstado = item.codDocumentoEstado,
                            codRegDocumento = item.codRegDocumento,
                            codRegEstado = item.codRegEstado,
                            codEstado = item.codEstado.HasValue ? item.codEstado.Value : 0,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquinaEdita,
                            auxcodRegDocumento = item.codRegDocumentoNombre,
                            auxcodRegEstado = item.codRegEstadoNombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDocumentoEstado;
        }

        public List<BEDocumentoEstado> ListPaged(BaseFiltro pFiltro)
        {
            List<BEDocumentoEstado> lstDocumentoEstado = new List<BEDocumentoEstado>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumentoEstado_Paged(pFiltro.grcurrentPage,
                                                                   pFiltro.grpageSize,
                                                                   pFiltro.grsortColumn,
                                                                   pFiltro.grsortOrder,
                                                                   null,
                                                                   pFiltro.codRegDocumento,
                                                                   pFiltro.codRegEstado);
                    foreach (var item in resul)
                    {
                        lstDocumentoEstado.Add(new BEDocumentoEstado()
                        {
                            codDocumentoEstado = item.codDocumentoEstado,
                            codRegDocumento = item.codRegDocumento,
                            codRegEstado = item.codRegEstado,
                            codEstado = item.codEstado.HasValue ? item.codEstado.Value : 0,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            auxcodRegDocumento = item.codRegDocumentoNombre,
                            auxcodRegEstado = item.codRegEstadoNombre,
                            codRegEstadoColor = item.codRegEstadoColor,

                            ROW = item.ROWNUM == null ? 0 : item.ROWNUM.Value,
                            TOTALROWS = item.TOTALROWS == null ? 0 : item.TOTALROWS.Value,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDocumentoEstado;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.DocumentoEstado
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoEstado]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public BEDocumentoEstado Find(BaseFiltro pFiltro)
        {
            BEDocumentoEstado documentoEstado = new BEDocumentoEstado();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumentoEstado(pFiltro.codDocumentoEstado, null, null);
                    foreach (var item in resul)
                    {
                        documentoEstado = new BEDocumentoEstado()
                        {
                            codDocumentoEstado = item.codDocumentoEstado,
                            codRegDocumento = item.codRegDocumento,
                            codRegEstado = item.codRegEstado,
                            codEstado = item.codEstado.HasValue ? item.codEstado.Value : 0,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquinaEdita,

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return documentoEstado;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo DocumentoEstado
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoEstado]
        /// </summary>
        /// <param name="lstDocumentoEstado"></param>
        /// <returns></returns>
        public bool Insert(List<BEDocumentoEstado> lstDocumentoEstado)
        {
            int? codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    foreach (BEDocumentoEstado documentoEstado in lstDocumentoEstado)
                    {
                        SQLDC.omgc_I_DocumentoEstado(
                            ref codigoRetorno,
                            documentoEstado.codRegDocumento,
                            documentoEstado.codRegEstado,
                            documentoEstado.codEstado,
                            documentoEstado.indActivo,
                            documentoEstado.segUsuarioCrea);
                        documentoEstado.codDocumentoEstado = codigoRetorno.Value;
                    }
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo DocumentoEstado
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoEstado]
        /// </summary>
        /// <param name="documentoEstado"></param>
        /// <returns></returns>
        public bool Update(BEDocumentoEstado documentoEstado)
        {
            int? codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_U_DocumentoEstado(
                        documentoEstado.codDocumentoEstado,
                        documentoEstado.codRegDocumento,
                        documentoEstado.codRegEstado,
                        documentoEstado.codEstado,
                        documentoEstado.indActivo,
                        documentoEstado.segUsuarioEdita);
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
        /// ELIMINA un registro de la Entidad GestionComercial.DocumentoEstado
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoEstado]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public bool Delete(BaseFiltro pFiltro)
        {
            int? codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_DocumentoEstado(pFiltro.codDocumentoEstado, pFiltro.codRegDocumento);
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

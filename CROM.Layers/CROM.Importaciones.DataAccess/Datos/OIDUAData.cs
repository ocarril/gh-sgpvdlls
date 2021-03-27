namespace CROM.Importaciones.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Importaciones;
    using CROM.BusinessEntities.Importaciones.DTO;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/08/2014-01:23:29 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Importaciones.OIDUAData.cs]
    /// </summary>
    public class OIDUAData
    {
        private string conexion = string.Empty;
        public OIDUAData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Importaciones.OIDUA
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUA]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEOIDUA> List(BaseFiltroImp pFiltro)
        {
            List<BEOIDUA> lstOIDUA = new List<BEOIDUA>();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIDUA(null, pFiltro.codOrdenImportacion, pFiltro.codDocumentoEstado, pFiltro.segUsuario);
                    foreach (var item in resul)
                    {
                        lstOIDUA.Add(new BEOIDUA()
                        {
                            codOIDUA = item.codOIDUA,
                            codOrdenImportacion = item.codOrdenImportacion,
                            codDocumentoEstado = item.codDocumentoEstado,
                            codRegCanal = item.codRegCanal,
                            numOIDUA = item.numOIDUA,
                            fecEmision = item.fecEmision,
                            fecPago = item.fecPago,
                            decFactor = item.decFactor,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            auxcodDocumentoEstado = item.codDocumentoEstadoNombre,
                            auxcodRegCanal = item.codRegCanalNombre,
                            auxOIDUA = item.desOIDUA
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOIDUA;
        }

        /// <summary>
        /// Proósito    :   Permite el listado de todas las DUAS generadas de acuerdo a la busqueda
        /// Fecha       :   25-Ago-2015 - 05:19am
        /// Autor       :   OCR - Orlando Carril Ramirez
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTODUA> ListPaged(BaseFiltroImp pFiltro)
        {
            List<DTODUA> lstDTODUA = new List<DTODUA>();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIDUA_Paged(pFiltro.grcurrentPage,
                                                         pFiltro.grpageSize,
                                                         pFiltro.grsortColumn,
                                                         pFiltro.grsortOrder,
                                                         pFiltro.fecInicio,
                                                         pFiltro.fecFinal,
                                                         pFiltro.numDUA,
                                                         pFiltro.numOrdenImportacion,
                                                         pFiltro.codRegCanal,
                                                         pFiltro.codRegEstado,
                                                         pFiltro.codRegIncotermo,
                                                         pFiltro.codRegNacionalizacion);
                    foreach (var item in resul)
                    {
                        lstDTODUA.Add(new DTODUA()
                        {
                            codOIDUA = item.codOIDUA,
                            codOrdenImportacion = item.codOrdenImportacion,
                            codRegCanalNombre = item.codRegCanalNombre,
                            codRegDocumentoNombre = item.codRegDocumentoNombre,
                            numOIDUA = item.numOIDUA,
                            fecEmision = item.fecEmision,
                            fecPago = item.fecPago,
                            decFactor = item.decFactor,
                            codRegEstadoDUANombre = item.codRegEstadoDUANombre,
                            codRegEstadoOINombre = item.codRegEstadoOINombre,
                            codRegIncotermNombre = item.codRegIncotermNombre,
                            codRegNacionalizacionNombre = item.codRegNacionalizacionNombre,
                            fecEmitido = item.fecEmitido,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea.ToString(),
                            segFechaEdita = item.segFechaEdita.HasValue ? item.segFechaEdita.Value.ToString() : string.Empty,
                            numOrdenImportacion = item.numOrdenImportacion,
                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDTODUA;
        }

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.DocumentoMovDetalle
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUACosto]
        /// </summary>
        /// <param name="pcodDocumRegDetalle"></param>
        /// <returns></returns>
        public DTOCostoDetalle FindDetalleGasto(int pcodDocumRegDetalle)
        {
            DTOCostoDetalle costoDetalle = null;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumRegDetaGasto(pcodDocumRegDetalle);
                    foreach (var item in resul)
                    {
                        costoDetalle = new DTOCostoDetalle()
                        {
                            codOIDUA = item.codOIDUA == null ? 0 : item.codOIDUA.Value,
                            codDocumRegDetalle = item.codDocumRegDetalle,
                            numItem = item.CodigoItemDetalle,
                            codRegResumenCosto = item.codRegResumenCosto,
                            codRegResumenCostoPadre = item.codRegResumenCostoPadre,
                            numOIDUA = item.numOIDUA,
                            monCostoDolar = item.monCostoDolar,
                            monDolar = item.monDolar == null ? 0 : item.monDolar.Value,
                            monSoles = item.monSoles == null ? 0 : item.monSoles.Value,
                            desProveedor = item.nomProveedor,
                            numDocumento = item.numDocumento,
                            editUsuario = item.SegUsuarioEdita,
                            editFecha = item.SegFechaEdita == null ? string.Empty : item.SegFechaEdita.Value.ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return costoDetalle;
        }

        /// <summary>
        /// Permite validar si se puede realizar el cierre de la DUA
        /// </summary>
        /// <param name="pcodOIDUA"></param>
        /// <returns></returns>
        public bool ValidarCierreDeDUA(int pcodOIDUA)
        {
            int? codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    codigoRetorno = SQLDC.fcnValidarCierreDUA(pcodOIDUA);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno > 0 ? false : true;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Importaciones.OIDUA
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUA]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public BEOIDUA Find(BaseFiltroImp pFiltro)
        {
            BEOIDUA oIDUA = new BEOIDUA();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIDUA(pFiltro.codOIDUA, null, null, pFiltro.segUsuario);
                    foreach (var item in resul)
                    {
                        oIDUA = new BEOIDUA()
                        {
                            codOIDUA = item.codOIDUA,
                            codOrdenImportacion = item.codOrdenImportacion,
                            codDocumentoEstado = item.codDocumentoEstado,
                            codRegCanal = item.codRegCanal,
                            numOIDUA = item.numOIDUA,
                            fecEmision = item.fecEmision,
                            fecPago = item.fecPago,
                            decFactor = item.decFactor,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            auxcodDocumentoEstado = item.codDocumentoEstadoNombre,
                            auxcodRegCanal = item.codRegCanalNombre
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oIDUA;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDUA
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUA]
        /// </summary>
        /// <param name="pOIDUA"></param>
        /// <returns></returns>
        public bool Insert(BEOIDUA pOIDUA)
        {
            int? codigoRetorno = null;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    SQLDC.omgc_I_OIDUA(
                      ref codigoRetorno,
                      pOIDUA.codOrdenImportacion,
                      pOIDUA.codDocumentoEstado,
                      pOIDUA.codRegCanal,
                      pOIDUA.numOIDUA,
                      pOIDUA.fecEmision,
                      pOIDUA.fecPago,
                      pOIDUA.decFactor,
                      pOIDUA.indActivo,
                      pOIDUA.segUsuarioCrea);
                    pOIDUA.codOIDUA = codigoRetorno.Value;
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDUA
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUA]
        /// INSERT [GestionComercial.ProductoPrecio]
        /// UPDATE [Almacen.ProductoExistencia]
        /// INSERT [Produccion.ProductoKardex]
        /// UPDATE [Almacen.ProductoSeriado]        Seriado
        /// UPDATE [Almacen.ProductoExistencia]     Seriado
        /// INSERT [Produccion.ProductoKardex ]     Seriado
        /// UPDATE [Importaciones].[OIDUA]
        /// <summary>
        /// <param name = >itemOIDUA</param>
        public bool Update(BEOIDUA pOIDUA)
        {
            int? codigoRetorno = null;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    SQLDC.omgc_U_OIDUA(
                        pOIDUA.codOIDUA,
                        pOIDUA.codOrdenImportacion,
                        pOIDUA.codDocumentoEstado,
                        pOIDUA.codRegCanal,
                        pOIDUA.numOIDUA,
                        pOIDUA.fecEmision,
                        pOIDUA.fecPago,
                        pOIDUA.decFactor,
                        pOIDUA.indActivo,
                        pOIDUA.segUsuarioEdita);
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno.HasValue ? true : false;
        }

        /// <summary>
        /// Permite actualizar el detalle del gasto que se detalla en la DUA
        /// </summary>
        /// <param name="pCostoDetalle"></param>
        /// <returns></returns>
        public bool UpdateDetalleGasto(DTOCostoDetalle pCostoDetalle)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    SQLDC.omgc_U_DocumRegDetaGasto(pCostoDetalle.codDocumRegDetalle,
                                                   pCostoDetalle.codOIDUA,
                                                   pCostoDetalle.codRegResumenCosto,
                                                   pCostoDetalle.editUsuario);
                    codigoRetorno = codigoRetorno = 0;
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
        /// ELIMINA un registro de la Entidad Importaciones.OIDUA
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUA]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public bool Delete(List<BEOIDUA> plstOIDUA)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    foreach (BEOIDUA oidua in plstOIDUA)
                        SQLDC.omgc_D_OIDUA(oidua.codOIDUA, oidua.codOrdenImportacion);
                    codigoRetorno = codigoRetorno = 0;
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
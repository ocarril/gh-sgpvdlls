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
    /// Archivo     : [Importaciones.OrdenImportacionData.cs]
    /// </summary>
    public class OrdenImportacionData
    {
        private string conexion = string.Empty;
        public OrdenImportacionData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Importaciones.OrdenImportacion
        /// En la BASE de DATO la Tabla : [Importaciones.OrdenImportacion]
        /// <summary>
        /// <returns>List</returns>
        public List<BEOrdenImportacion> List(BaseFiltroImp pFiltro)
        {
            List<BEOrdenImportacion> lstOrdenImportacion = new List<BEOrdenImportacion>();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OI(pFiltro.codOrdenImportacion,
                                                pFiltro.numOrdenImportacion,
                                                pFiltro.codDocumentoEstado,
                                                pFiltro.codRegIncotermo,
                                                pFiltro.codRegNacionalizacion);
                    foreach (var item in resul)
                    {
                        lstOrdenImportacion.Add(new BEOrdenImportacion()
                        {
                            codOrdenImportacion = item.codOrdenImportacion,
                            numOrdenImportacion = item.numOrdenImportacion,
                            codRegIncotermo = item.codRegIncotermo,
                            codDocumentoEstado = item.codDocumentoEstado,
                            gloObservacion = item.gloObservacion,
                            fecEmitido = item.fecEmitido,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            auxcodDocumentoEstado = item.codDocumentoEstadoNombre,
                            auxcodRegIncotermo = item.codRegIncotermoNombre,
                            auxcodRegNacionalizacion = item.codRegNacionalizacionNombre,
                            codRegNacionalizacion = item.codRegNacionalizacion,
                            auxcodPerProveedor = item.CodigoPersonaEntidad,
                            auxcodPerProveedorNombre = item.EntidadRazonSocial
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOrdenImportacion;
        }

        public List<BEOrdenImportacion> ListPaged(BaseFiltroImp pFiltro)
        {
            List<BEOrdenImportacion> lstOrdenImportacion = new List<BEOrdenImportacion>();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OI_Paged(pFiltro.grcurrentPage,
                                                      pFiltro.grpageSize,
                                                      pFiltro.grsortColumn,
                                                      pFiltro.grsortOrder,
                                                      pFiltro.codOrdenImportacion,
                                                      pFiltro.numOrdenImportacion,
                                                      pFiltro.codDocumentoEstado,
                                                      pFiltro.codRegIncotermo,
                                                      pFiltro.codRegNacionalizacion);
                    foreach (var item in resul)
                    {
                        lstOrdenImportacion.Add(new BEOrdenImportacion()
                        {
                            codOrdenImportacion = item.codOrdenImportacion,
                            numOrdenImportacion = item.numOrdenImportacion,
                            codRegIncotermo = item.codRegIncotermo,
                            codDocumentoEstado = item.codDocumentoEstado,
                            gloObservacion = item.gloObservacion,
                            fecEmitido = item.fecEmitido,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            auxcodDocumentoEstado = item.codDocumentoEstadoNombre,
                            auxcodRegIncotermo = item.codRegIncotermoNombre,
                            auxcodRegNacionalizacion = item.codRegNacionalizacionNombre,
                            codRegNacionalizacion = item.codRegNacionalizacion,
                            auxcodPerProveedor = item.CodigoPersonaEntidad,
                            auxcodPerProveedorNombre = item.EntidadRazonSocial,

                            ROW = item.ROWNUM == null ? 0 : item.ROWNUM.Value,
                            TOTALROWS = item.TOTALROWS == null ? 0 : item.TOTALROWS.Value
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOrdenImportacion;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Importaciones.OrdenImportacion
        /// En la BASE de DATO la Tabla : [Importaciones.OrdenImportacion]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEOrdenImportacion Find(BaseFiltroImp pFiltro)
        {
            BEOrdenImportacion ordenImportacion = new BEOrdenImportacion();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OI(pFiltro.codOrdenImportacion, null, null, null, null);
                    foreach (var item in resul)
                    {
                        ordenImportacion = new BEOrdenImportacion()
                        {
                            codOrdenImportacion = item.codOrdenImportacion,
                            numOrdenImportacion = item.numOrdenImportacion,
                            codRegIncotermo = item.codRegIncotermo,
                            codDocumentoEstado = item.codDocumentoEstado,
                            gloObservacion = item.gloObservacion,
                            fecEmitido = item.fecEmitido,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            auxcodDocumentoEstado = item.codDocumentoEstadoNombre,
                            auxcodRegIncotermo = item.codRegIncotermoNombre,
                            auxcodRegNacionalizacion = item.codRegNacionalizacionNombre,
                            codRegNacionalizacion = item.codRegNacionalizacion,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ordenImportacion;
        }

        public List<DTODocumentoImp> ListFacturas(BaseFiltroImp pFiltro)
        {
            List<DTODocumentoImp> lstFacturasProv = new List<DTODocumentoImp>();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIFacturas(pFiltro.codPersonaEntidad,
                                                        pFiltro.codRegEstado
                                                       );
                    foreach (var item in resul)
                    {
                        lstFacturasProv.Add(new DTODocumentoImp
                        {
                            codDocumReg = item.codDocumReg,
                            numDocumento = item.numDocumento,
                            numDocumentoRef = item.NumeroComprobanteExt,
                            numDocumentoSec = item.NumeroComprobante,
                            nomProveedor = item.NumeroComprobanteExt == null ? string.Empty : item.NumeroComprobanteExt + " - " + item.EntidadRazonSocial
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFacturasProv;
        }

        public List<DTOProveedor> ListProveedores(BaseFiltroImp pFiltro)
        {
            List<DTOProveedor> lstProveedores = new List<DTOProveedor>();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIProveedores(pFiltro.codPersonaEntidad,
                                                            pFiltro.codRegEstado
                                                       );
                    foreach (var item in resul)
                    {
                        lstProveedores.Add(new DTOProveedor
                        {
                            codPersonaEntidad = item.codPersonaEntidad,
                            codPersonaEntidadNombre = item.codPersonaEntidadNombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProveedores;
        }
        public List<DTOProveedor> ListProveedoresGasto(BaseFiltroImp pFiltro)
        {
            List<DTOProveedor> lstProveedores = new List<DTOProveedor>();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIProveedorGasto();
                    foreach (var item in resul)
                    {
                        lstProveedores.Add(new DTOProveedor
                        {
                            codPersonaEntidad = item.codPersonaEntidad,
                            codPersonaEntidadNombre = item.codPersonaEntidadNombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProveedores;
        }
        public List<DTOCostoDetalle> ListCostoDetalle(BaseFiltroImp pFiltro)
        {
            List<DTOCostoDetalle> lstCostoDetalle = new List<DTOCostoDetalle>();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIDUACostoDetalle(pFiltro.codOIDUA,
                                                               pFiltro.codRegResumenCosto
                                                              );
                    foreach (var item in resul)
                    {
                        lstCostoDetalle.Add(new DTOCostoDetalle
                        {
                            codOIDUA = item.codOIDUA,
                            codOIDUACosto = item.codOIDUACosto,
                            codRegResumenCosto = item.codRegResumenCosto,
                            codRegResumenCostoNombre = item.codRegResumenCostoNombre,
                            codDocumento = item.codDocumento,
                            numDocumento = item.numDocumento,
                            fecEmision = item.fecEmision.ToString(),
                            desProveedor = item.desProveedor,
                            desCosto = item.desCosto,
                            codProducto = item.codProducto,
                            codProductoNombre = item.codProductoNombre,
                            cntCantidad = item.cntCantidad,
                            monUnitPrecioVenta = item.monUnitPrecioVenta == null ? 0 : item.monUnitPrecioVenta.Value,
                            monTotalDocumento = item.monTotalDocumento,
                            monTipoCambioCmp = item.monTipoCambioCmp,
                            monTipoCambioVta = item.monTipoCambioVta
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCostoDetalle;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OrdenImportacion
        /// En la BASE de DATO la Tabla : [Importaciones.OrdenImportacion]
        /// </summary>
        /// <param name="pOrdenImportacion"></param>
        /// <returns></returns>
        public bool Insert(BEOrdenImportacion pOrdenImportacion)
        {
            int? codigoRetorno = null;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    SQLDC.omgc_I_OrdenImportacion(
                       ref codigoRetorno,
                       pOrdenImportacion.numOrdenImportacion,
                       pOrdenImportacion.codRegIncotermo,
                       pOrdenImportacion.codRegNacionalizacion,
                       pOrdenImportacion.codDocumentoEstado,
                       pOrdenImportacion.gloObservacion,
                       pOrdenImportacion.fecEmitido,
                       pOrdenImportacion.indActivo,
                       pOrdenImportacion.segUsuarioCrea
                       );
                    pOrdenImportacion.codOrdenImportacion = codigoRetorno.Value;
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo OrdenImportacion
        /// En la BASE de DATO la Tabla : [Importaciones.OrdenImportacion]
        /// </summary>
        /// <param name="pOrdenImportacion"></param>
        /// <returns></returns>
        public bool Update(BEOrdenImportacion pOrdenImportacion)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    SQLDC.omgc_U_OrdenImportacion(
                        pOrdenImportacion.codOrdenImportacion,
                        pOrdenImportacion.numOrdenImportacion,
                        pOrdenImportacion.codRegIncotermo,
                        pOrdenImportacion.codRegNacionalizacion,
                        pOrdenImportacion.codDocumentoEstado,
                        pOrdenImportacion.gloObservacion,
                        pOrdenImportacion.fecEmitido,
                        pOrdenImportacion.indActivo,
                        pOrdenImportacion.segUsuarioEdita
                        );
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
        /// ELIMINA un registro de la Entidad Importaciones.OrdenImportacion
        /// En la BASE de DATO la Tabla : [Importaciones.OrdenImportacion]
        /// </summary>
        /// <param name="prm_codOrdenImportacion"></param>
        /// <returns></returns>
        public bool Delete(BaseFiltroImp pFiltro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_OrdenImportacion(pFiltro.codOrdenImportacion);
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

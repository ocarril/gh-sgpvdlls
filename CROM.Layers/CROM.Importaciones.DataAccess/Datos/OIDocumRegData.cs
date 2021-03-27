namespace CROM.Importaciones.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Importaciones;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 11/09/2014-06:09:07 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Importaciones.OIDocumRegData.cs]
    /// </summary>
    public class OIDocumRegData
    {
        private string conexion = string.Empty;
        public OIDocumRegData()
        {
            conexion = Util.ConexionBD();
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Importaciones.OIDocumReg
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumReg]
        /// <summary>
        /// <returns>List</returns>
        public List<BEOIDocumReg> List(BaseFiltroImp pFiltro)
        {
            List<BEOIDocumReg> lstOIDocumReg = new List<BEOIDocumReg>();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIDocumReg(null, pFiltro.codOrdenImportacion, null);
                    foreach (var item in resul)
                    {
                        lstOIDocumReg.Add(new BEOIDocumReg()
                        {
                            codOIDocumReg = item.codOIDocumReg,
                            codOrdenImportacion = item.codOrdenImportacion,
                            codDocumReg = item.codDocumReg,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            auxnumDocumento = item.numDocumento,
                            auxnumDocumentoRef = item.NumeroComprobanteExt,
                            auxnumDocumentoSec = item.NumeroComprobante,
                            auxnomProveedor = item.EntidadRazonSocial
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOIDocumReg;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Importaciones.OIDocumReg
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumReg]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEOIDocumReg Find(BaseFiltroImp pFiltro)
        {
            BEOIDocumReg objOIDocumReg = new BEOIDocumReg();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIDocumReg(pFiltro.codOIDocumReg, null, null);
                    foreach (var item in resul)
                    {
                        objOIDocumReg = new BEOIDocumReg()
                        {
                            codOIDocumReg = item.codOIDocumReg,
                            codOrdenImportacion = item.codOrdenImportacion,
                            codDocumReg = item.codDocumReg,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
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
            return objOIDocumReg;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDocumReg
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumReg]
        /// <summary>
        /// <param name = >pOIDocumReg</param>
        public bool Insert(List<BEOIDocumReg> lstOIDocumReg)
        {
            int? codigoRetorno = null;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    foreach (BEOIDocumReg pOIDocumReg in lstOIDocumReg)
                    {
                        SQLDC.omgc_I_OIDocumReg(
                          ref codigoRetorno,
                          pOIDocumReg.codOrdenImportacion,
                          pOIDocumReg.codDocumReg,
                          pOIDocumReg.indActivo,
                          pOIDocumReg.segUsuarioCrea);
                        pOIDocumReg.codOIDocumReg = codigoRetorno.Value;
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDocumReg
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumReg]
        /// <summary>
        /// <param name = >itemOIDocumReg</param>
        public bool Update(BEOIDocumReg pOIDocumReg)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    SQLDC.omgc_U_OIDocumReg(
                      pOIDocumReg.codOIDocumReg,
                      pOIDocumReg.codOrdenImportacion,
                      pOIDocumReg.codDocumReg,
                      pOIDocumReg.indActivo,
                      pOIDocumReg.segUsuarioEdita);
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
        /// ELIMINA un registro de la Entidad Importaciones.OIDocumReg
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumReg]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(BaseFiltroImp pFiltro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    SQLDC.omgc_D_OIDocumReg(pFiltro.codOIDocumReg, pFiltro.codOrdenImportacion);
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

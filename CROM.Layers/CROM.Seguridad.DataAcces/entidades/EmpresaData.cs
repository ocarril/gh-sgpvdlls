namespace CROM.Seguridad.DataAcces
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Tools.Comun.settings;
    using CROM.Tools.Comun.Web;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 8/10/2019-15:55:24
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Seguridad.EmpresaData.cs]
    /// </summary>
    public class EmpresaData
    {
        private string conexion = string.Empty;

        public EmpresaData()
        {
            conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG");
        }

        #region /* Proceso de SELECT ALL */ 

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Seguridad.Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <returns>List</returns>
        public List<BEEmpresaResponse> ListPaged(BEBuscaEmpresaRequest pFiltro)
        {
            List<BEEmpresaResponse> lstEmpresa = new List<BEEmpresaResponse>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_Empresa_Paged(pFiltro.jqCurrentPage,
                                                                    pFiltro.jqPageSize,
                                                                    pFiltro.jqSortColumn,
                                                                    pFiltro.jqSortOrder,
                                                                    pFiltro.nomRazonSocial,
                                                                    pFiltro.numRUC,
                                                                    pFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lstEmpresa.Add(new BEEmpresaResponse()
                        {
                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0,

                            codEmpresa = item.codEmpresa,
                            nomRazonSocial = item.nomRazonSocial,
                            numRUC = item.numRUC,
                            nomLogo = item.nomLogo,
                            nomContacto = item.nomContacto,
                            desCorreo = item.desCorreo,
                            desPaginaWeb = item.desPaginaWeb,
                            codEmpresaKey = item.codEmpresaKey.ToString(),
                            indActivo = item.indActivo,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaEdita = item.segMaquinaEdita,

                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstEmpresa;
        }
      
        #endregion

        #region /* Proceso de SELECT BY ID CODE */ 

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Seguridad.Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEEmpresa Find(int pcodEmpresa)
        {
            BEEmpresa objEntidad = null;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_Empresa(pcodEmpresa);
                    foreach (var item in resul)
                    {
                        objEntidad = new BEEmpresa()
                        {
                            codEmpresa = item.codEmpresa,
                            nomRazonSocial = item.nomRazonSocial,
                            numRUC = item.numRUC,
                            nomLogo = item.nomLogo,
                            nomContacto = item.nomContacto,
                            desCorreo = item.desCorreo,
                            desPaginaWeb = item.desPaginaWeb,
                            codEmpresaKey = item.codEmpresaKey.ToString(),
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraCrea = item.segFechaCrea,
                            segFechaHoraEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquinaCrea,
                            segMaquinaEdita = item.segMaquinaEdita,
                            indEliminado = item.indEliminado,

                        };
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objEntidad;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */ 

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <param name = >itemEmpresa</param>
        public bool Insert(BEEmpresaRequest pEmpresa)
        {
            bool blnResult = false;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resulSet = SeguridadDC.usp_sis_C_Empresa(
                          pEmpresa.nomRazonSocial,
                          pEmpresa.numRUC,
                          pEmpresa.nomLogo,
                          pEmpresa.nomContacto,
                          pEmpresa.desCorreo,
                          pEmpresa.desPaginaWeb,
                          pEmpresa.indActivo,
                          pEmpresa.segUsuarioEdita,
                          pEmpresa.segMaquinaEdita);
                    foreach (var item in resulSet)
                    {
                        pEmpresa.codEmpresa = item.codError.HasValue ? item.codError.Value : 0;
                        blnResult = item.desMessage == WebConstants.DEFAULT_OK ? true : false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return blnResult;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */ 

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <param name = >itemEmpresa</param>
        public bool Update(BEEmpresaRequest pEmpresa)
        {
            bool blnResult = false;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resulSet = SeguridadDC.usp_sis_U_Empresa(
                        pEmpresa.codEmpresa,
                        pEmpresa.nomRazonSocial,
                        pEmpresa.numRUC,
                        pEmpresa.nomLogo,
                        pEmpresa.nomContacto,
                        pEmpresa.desCorreo,
                        pEmpresa.desPaginaWeb,
                        pEmpresa.indActivo,
                        pEmpresa.segUsuarioEdita,
                        pEmpresa.segMaquinaEdita);

                    foreach (var item in resulSet)
                    {
                        blnResult = item.desMessage == WebConstants.DEFAULT_OK ? true : false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return blnResult;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */ 

        /// <summary>
        /// ELIMINA un registro de la Entidad Seguridad.Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(BEEmpresaRequest pEmpresa)
        {
            bool blnResult = false;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resulSet = SeguridadDC.usp_sis_D_Empresa(pEmpresa.codEmpresa, 
                                                                 pEmpresa.segUsuarioEdita,
                                                                 pEmpresa.segMaquinaEdita);
                    foreach (var item in resulSet)
                    {
                        blnResult = item.desMessage == WebConstants.DEFAULT_OK ? true : false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return blnResult;
        }

        #endregion

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

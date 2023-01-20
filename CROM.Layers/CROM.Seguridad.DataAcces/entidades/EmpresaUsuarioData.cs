namespace CROM.Seguridad.DataAcces
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Tools.Comun.Web;
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 8/10/2019-15:55:24
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Seguridad.EmpresaUsuarioData.cs]
    /// </summary>
    public class EmpresaUsuarioData
    {
        private string conexion = string.Empty;
        public EmpresaUsuarioData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnxCROMSystemaSEG"].ConnectionString;
        }

        #region /* Proceso de SELECT ALL */ 

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Seguridad.EmpresaUsuario
        /// En la BASE de DATO la Tabla : [Seguridad.EmpresaUsuario]
        /// <summary>
        /// <returns>List</returns>
        public List<BEEmpresaUsuarioRespose> ListPaged(BEBuscaEmpresaUsuarioRequest pFiltro)
        {
            List<BEEmpresaUsuarioRespose> lstEmpresaUsuario = new List<BEEmpresaUsuarioRespose>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_EmpresaUsuario_Paged(pFiltro.jqCurrentPage,
                                                                            pFiltro.jqPageSize,
                                                                            pFiltro.jqSortColumn,
                                                                            pFiltro.jqSortOrder,
                                                                            pFiltro.codEmpresa,
                                                                            pFiltro.codUsuario,
                                                                            pFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lstEmpresaUsuario.Add(new BEEmpresaUsuarioRespose()
                        {
                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0,


                            codEmpresaUsuario = item.codEmpresaUsuario,
                            nomEmpresa = item.nomEmpresa,
                            desLogin = item.desLogin,
                            nomUsuario = item.nomUsuario,
                            indActivo = item.indActivo,
                            codUsuarioKey = item.codUsuarioKey.ToString(),
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
            return lstEmpresaUsuario;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */ 

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Seguridad.EmpresaUsuario
        /// En la BASE de DATO la Tabla : [Seguridad.EmpresaUsuario]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEEmpresaUsuario Find(int pcodEmpresaUsuario)
        {
            BEEmpresaUsuario objEntidadUsuario = new BEEmpresaUsuario();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_EmpresaUsuario(pcodEmpresaUsuario, null, null);
                    foreach (var item in resul)
                    {
                        objEntidadUsuario = new BEEmpresaUsuario()
                        {
                            codEmpresaUsuario = item.codEmpresaUsuario,
                            codEmpresa = item.codEmpresa,
                            codUsuario = item.codUsuario,
                            indActivo = item.indActivo,
                            codUsuarioKey = item.codUsuarioKey.ToString(),
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraCrea = item.segFechaCrea,
                            segFechaHoraEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquinaCrea,
                            segMaquinaEdita = item.segMaquinaEdita

                        };
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objEntidadUsuario;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */ 

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo EmpresaUsuario
        /// En la BASE de DATO la Tabla : [Seguridad.EmpresaUsuario]
        /// <summary>
        /// <param name = >itemEmpresaUsuario</param>
        public bool Insert(BEEmpresaUsuarioRequest pEmpresaUsuario, out string pMessage)
        {
            bool blnResult = false;
            pMessage = string.Empty;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resulSet = SeguridadDC.usp_sis_C_EmpresaUsuario(
                                                pEmpresaUsuario.codEmpresa,
                                                pEmpresaUsuario.codUsuario,
                                                pEmpresaUsuario.indActivo,
                                                pEmpresaUsuario.segUsuarioEdita,
                                                pEmpresaUsuario.segMaquinaEdita);

                    foreach (var item in resulSet)
                    {
                        pEmpresaUsuario.codEmpresaUsuario = item.codError.HasValue ? item.codError.Value : 0;
                        pMessage = item.desMessage;

                        if (pMessage == WebConstants.DEFAULT_OK)
                            blnResult = true;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnResult;

        }
        #endregion

        #region /* Proceso de UPDATE RECORD */ 

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo EmpresaUsuario
        /// En la BASE de DATO la Tabla : [Seguridad.EmpresaUsuario]
        /// <summary>
        /// <param name = >itemEmpresaUsuario</param>
        public bool Update(BEEmpresaUsuarioRequest pEmpresaUsuario)
        {
            int codigoRetorno = -1;
            bool message = false;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resulSet = SeguridadDC.usp_sis_U_EmpresaUsuario(
                                pEmpresaUsuario.codEmpresaUsuario,
                                pEmpresaUsuario.indActivo,
                                pEmpresaUsuario.segUsuarioEdita,
                                pEmpresaUsuario.segMaquinaEdita);

                    foreach (var item in resulSet)
                    {
                        codigoRetorno = item.codError.HasValue ? item.codError.Value : 0;
                        message = item.desMessage == WebConstants.DEFAULT_OK ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 1 && message ? true : false;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */ 

        /// <summary>
        /// ELIMINA un registro de la Entidad Seguridad.EmpresaUsuario
        /// En la BASE de DATO la Tabla : [Seguridad.EmpresaUsuario]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(BEEmpresaUsuarioRequest pEmpresaUsuario)
        {
            bool blnResult = false;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resulSet = SeguridadDC.usp_sis_D_EmpresaUsuario( pEmpresaUsuario.codEmpresaUsuario,
                                                                         pEmpresaUsuario.segUsuarioEdita,
                                                                         pEmpresaUsuario.segMaquinaEdita);
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

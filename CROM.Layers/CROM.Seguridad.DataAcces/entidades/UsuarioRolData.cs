namespace CROM.Seguridad.DataAcces
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Tools.Comun.settings;

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Seguridad del Sistema
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 08/11/2009
    /// Descripcion : Clase para capa de datos
    /// Archivo     : UsuariosRolesData.cs
    /// </summary
    public class UsuarioRolData
    {
        private string conexion = String.Empty;
        public UsuarioRolData()
        {
            conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG");
        }

        #region " /* Proceso de Insertar */ "
        /// <summary>
        /// Registrar una Entidad UsuariosRoles
        /// </summary>
        /// <param name="pItem">Entidad UsuariosRoles</param>
        public bool Insert(BEUsuarioRol pItem)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    codigoRetorno = SeguridadDC.usp_sis_C_UsuarioRol(
                            pItem.codUsuario,
                            pItem.codSistema,
                            pItem.codRol,
                            Convert.ToBoolean(pItem.indEstado),
                            pItem.segUsuarioCrea
                            );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
        
        #endregion

        #region " /* Proceso de Actualizar */ "
        /// <summary>
        /// Actualiza el registro de un objeto de tipo UsuariosRoles
        /// </summary>
        /// <param name="pItem">Entidad UsuariosRoles</param>
        public bool Update(BEUsuarioRol pItem)
        {
            int CodigoRetorno = -1;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    CodigoRetorno = SeguridadDC.usp_sis_U_UsuarioRol(
                            pItem.codUsuario,
                            pItem.codRol,
                            Convert.ToBoolean(pItem.indEstado),
                            pItem.segUsuarioEdita
                          );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CodigoRetorno == 0 ? true : false;
        }

        #endregion

        #region " /* Proceso de Eliminar */ "

        /// <summary>
        /// Elimina un expediente de la tabla Facturas por una llave primaria compuesta.
        /// </summary>
        //public bool Delete(string CodigoUsuario,string CodigoRol)
        //{
        //    int CodigoRetorno = -1;
        //    try
        //    {
        //        using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
        //        {
        //            CodigoRetorno = SeguridadDC.omgc_mnt_Delete_UsuarioRol(CodigoUsuario, CodigoRol);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return CodigoRetorno == 0 ? true : false;
        //}

        public bool DeleteWS(int codUsuarioRol)
        {
            bool blnResult = false;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resulSet = SeguridadDC.usp_sis_D_UsuarioRol(codUsuarioRol);
                    foreach (var item in resulSet)
                    {
                        blnResult = item.desMessage == "OK" ? true : false;
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

        #region " /* Proceso de Encontrar */ "

        /// <summary>
        /// Retorna un objeto de registros de tipo [Tabla].UsuariosRoles
        /// </summary>
        /// <returns>Lista</returns>
        public BEUsuarioRol Find(string CodigoUsuario,string CodigoRol)
        {
            BEUsuarioRol itemUsuariosRoles = new BEUsuarioRol();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_UsuarioRol(null, CodigoUsuario, CodigoRol);
                    foreach (var item in resul)
                    {
                        itemUsuariosRoles = new BEUsuarioRol()
                        {
                            codRol = item.codRol,
                            codUsuario = item.codUsuario,
                            indEstado = item.indEstado,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segFechaHoraCrea = Convert.ToDateTime(item.segFechaHoraCrea),
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraEdita = item.segFechaHoraEdita,
                            segMaquinaCrea = item.segMaquinaOrigen,

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemUsuariosRoles;
        }

        public BEUsuarioRol FindWS(int codUsuarioRol)
        {
            BEUsuarioRol itemUsuariosRoles = new BEUsuarioRol();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_UsuarioRol(codUsuarioRol, null, null);

                    foreach (var item in resul)
                    {
                        itemUsuariosRoles = new BEUsuarioRol()
                        {
                            codUsuarioRol = item.codUsuarioRol,
                            codEmpresa = item.codEmpresa,
                            codSistema = item.codSistema,
                            codRol = item.codRol,
                            codUsuario = item.codUsuario,
                            indEstado = item.indEstado,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segFechaHoraCrea = Convert.ToDateTime(item.segFechaHoraCrea),
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraEdita = item.segFechaHoraEdita,
                            segMaquinaCrea = item.segMaquinaOrigen,

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemUsuariosRoles;
        }

        #endregion

        #region " /* Proceso de Listar */ "

        ///// <summary>
        ///// Retorna un coleccion de registros de tipo [Tabla].UsuariosRoles
        ///// </summary>
        ///// <returns>Lista</returns>
        //public List<BEUsuarioRolAux> List(string prm_CodigoSistema, string prm_CodigoUsuario)
        //{
        //    List<BEUsuarioRolAux> lista = new List<BEUsuarioRolAux>();
        //    try
        //    {
        //        using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
        //        {
        //            var resul = SeguridadDC.omgc_mnt_GetAll_UsuarioRol(prm_CodigoSistema, prm_CodigoUsuario);
        //            foreach (var item in resul)
        //            {
        //                lista.Add(new BEUsuarioRolAux()
        //                {
        //                    codRol = item.codRol,
        //                    codUsuario = item.codUsuario,
        //                    codRolNombre = item.codRolNombre,
        //                    codUsuarioNombre = item.codUsuarioNombre,
        //                    codUsuarioLogin=item.codUsuarioLogin,
        //                    codSistema = item.codSistema,
        //                    codSistemaNombre = item.codSistemaNombre,
        //                    indEstado = item.indEstado,
        //                    segUsuarioCrea = item.segUsuarioCrea,
        //                    segFechaHoraCrea = Convert.ToDateTime(item.segFechaHoraCrea),
        //                    segUsuarioEdita = item.segUsuarioEdita,
        //                    segFechaHoraEdita = item.SegFechaHoraEdita,
        //                    segMaquinaCrea = item.SegMaquinaOrigen
        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lista;
        //}

        /// <summary>
        /// Listado con paginacion para aplicación WEB 
        /// </summary>
        /// <param name="prm_CodigoSistema"></param>
        /// <param name="prm_CodigoUsuario"></param>
        /// <param name="p_NumPagina"></param>
        /// <param name="p_NumFilasP"></param>
        /// <param name="pNumFilasT"></param>
        /// <returns></returns>
        public List<BEUsuarioRolResponse> ListPaged(BEBuscaRolUsuarioRequest pFiltro)
        {
            List<BEUsuarioRolResponse> lista = new List<BEUsuarioRolResponse>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_UsuarioRol_Paged(pFiltro.jqCurrentPage,
                                                                       pFiltro.jqPageSize,
                                                                       pFiltro.jqSortColumn,
                                                                       pFiltro.jqSortOrder,
                                                                       pFiltro.codEmpresa,
                                                                       pFiltro.codUsuarioRol,
                                                                       pFiltro.codUsuario,
                                                                       pFiltro.codSistema,
                                                                       pFiltro.codRol,
                                                                       pFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lista.Add(new BEUsuarioRolResponse()
                        {
                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0,

                            codUsuarioRol = item.codUsuarioRol,
                            codRol = item.codRol,
                            codUsuario = item.codUsuario,
                            codRolNombre = item.codRolNombre,
                            codUsuarioNombre = item.codUsuarioNombre,
                            codUsuarioLogin = item.desLogin,
                            codSistema = item.codSistema,
                            codSistemaNombre = item.codSistemaNombre,
                            indEstado = item.indEstado,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaHoraEdita,
                            segMaquinaEdita = item.segMaquinaEdita,
                            codEmpresa = pFiltro.codEmpresa,
                            codEmpresaNombre = item.codEmpresaNombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        #endregion

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

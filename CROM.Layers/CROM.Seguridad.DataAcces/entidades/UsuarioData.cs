namespace CROM.Seguridad.DataAcces
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Seguridad.BussinesEntities.entidades.request;
    using CROM.Seguridad.BussinesEntities.entidades.response;
    using CROM.Tools.Comun.settings;
    using CROM.Tools.Comun.Web;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Seguridad del Sistema
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 07/11/2009
    /// Descripcion : Clase para capa de datos
    /// Archivo     : UsuariosData.cs
    /// </summary
    public class UsuarioData:IDisposable
    {
        private string conexion = String.Empty;
        public UsuarioData()
        {
            conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG");
        }

        #region " /* Proceso de Insertar */ "

        /// <summary>
        /// Registrar una Entidad Usuarios
        /// La encriptación del Password es en la BASE DE DATOS
        /// </summary>
        /// <param name="pItem">Entidad Usuarios</param>
        /// <returns></returns>
        public string InsertExt(BEUsuarioRequest pItem, out string pMessage)
        {
            string codigoRetorno = "";
            pMessage = string.Empty;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resulSet = SeguridadDC.usp_sis_C_Usuario(
                       pItem.desLogin,
                       pItem.clvPasswordEncrypt,
                       pItem.desNombres,
                       pItem.desApellidos,
                       pItem.desPregunta,
                       pItem.desRespuesta,
                       pItem.desTelefono,
                       pItem.desCorreo,
                       pItem.indRestricPorPais,
                       pItem.codEmpleado,
                       pItem.indVendedor,
                       pItem.indCambioPrecio,
                       pItem.indAccesoGerencial,
                       pItem.indCambiaDescuento,
                       pItem.indCambiaCodPersona,
                       pItem.indJefeCaja,
                       pItem.indUsuarioSistema,
                       Convert.ToBoolean(pItem.indEstado),
                       pItem.segUsuarioEdita,
                       pItem.codArguPais,

                       pItem.urlPhotoUser,
                       pItem.indOrigenUser,
                       pItem.codGUID,

                       pItem.codSistemaKey,
                       pItem.codRolDefecto,
                       pItem.segMaquinaEdita
                       );
                    foreach (var item in resulSet)
                    {
                        if (item.codError != "-406")
                        {
                            pItem.codUsuario = item.codError;
                            codigoRetorno = item.codError;
                        }

                        pMessage = item.desMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno;
        }

        #endregion

        #region " /* Proceso de Actualizar */ "
     
        /// <summary>
        /// Actualiza el registro de un objeto de tipo Usuarios
        /// </summary>
        /// <param name="pItem">Entidad Usuarios</param>
        public bool Update(BEUsuarioRequest pItem)
        {
            bool blnResult = false;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resulSet = SeguridadDC.usp_sis_U_Usuario(
                        pItem.codUsuario,
                        pItem.desLogin,
                        pItem.desNombres,
                        pItem.desApellidos,
                        pItem.desPregunta,
                        pItem.desRespuesta,
                        pItem.desTelefono,
                        pItem.desCorreo,
                        pItem.indRestricPorPais,
                        pItem.codEmpleado,
                        pItem.indVendedor,
                        pItem.indCambioPrecio,
                        pItem.indAccesoGerencial,
                        pItem.indCambiaDescuento,
                        pItem.indCambiaCodPersona,
                        pItem.indJefeCaja,
                        pItem.indUsuarioSistema,
                        Convert.ToBoolean(pItem.indEstado),
                        pItem.segUsuarioEdita,
                        pItem.codArguPais,
                        pItem.urlPhotoUser
                        );
                    foreach (var item in resulSet)
                    {
                        blnResult = item.desMessage == WebConstants.DEFAULT_OK ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnResult;
        }

        ///// <summary>
        ///// Actualiza el registro de un objeto de tipo Usuarios
        ///// La encriptación del Password es EXTERNO
        ///// </summary>
        ///// <param name="pItem">Entidad Usuarios</param>
        //public bool UpdateExterno(BEUsuarioAux pItem)
        //{
        //    bool blnResult = false;
        //    try
        //    {
        //        using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
        //        {
        //            var resulSet = SeguridadDC.omgc_mnt_Update_UsuarioExterno(
        //                pItem.codUsuario,
        //                pItem.desLogin,
        //                pItem.desNombres,
        //                pItem.desApellidos,
        //                pItem.desPregunta,
        //                pItem.desRespuesta,
        //                pItem.desTelefono,
        //                pItem.desCorreo,
        //                pItem.indRestricPorPais,
        //                pItem.codEmpleado,
        //                pItem.indVendedor,
        //                pItem.indCambioPrecio,
        //                pItem.indAccesoGerencial,
        //                pItem.indCambiaDescuento,
        //                pItem.indCambiaCodPersona,
        //                pItem.indJefeCaja,
        //                pItem.indUsuarioSistema,
        //                Convert.ToBoolean(pItem.indEstado),
        //                pItem.segUsuarioEdita,
        //                pItem.codArguPais
        //                );
        //            foreach (var item in resulSet)
        //            {
        //                blnResult = item.desMessage == WebConstants.DEFAULT_OK? true : false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return blnResult;
        //}

        #endregion

        #region " /* Proceso de Eliminar */ "

        /// <summary>
        /// Elimina un expediente de la tabla Facturas por una llave primaria compuesta.
        /// </summary>
        public bool Delete(string CodigoUsuario)
        {
            int CodigoRetorno = -1;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {

                    CodigoRetorno = SeguridadDC.usp_sis_D_Usuario(CodigoUsuario);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CodigoRetorno == 0 ? true : false;
        }

        #endregion

        #region " /* Proceso de Encontrar */ "

        /// <summary>
        /// Retorna un objeto de registros de tipo [Tabla].Usuarios
        /// </summary>
        /// <returns>Lista</returns>
        public BEUsuarioResponse Find(string pCodUsuario)
        {
            BEUsuarioResponse objUsuario = null;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_Usuario(pCodUsuario, null, null, null, true);
                    foreach (var item in resul)
                    {
                        objUsuario = new BEUsuarioResponse()
                        {
                            codUsuario = item.codUsuario,
                            desLogin = item.desLogin,
                            clvPassword = item.clvPassword,
                            desNombres = item.desNombres,
                            desApellidos = item.desApellidos,
                            desPregunta = item.desPregunta,
                            codEmpleado = item.codEmpleado,
                            desCorreo = item.desCorreo,
                            desRespuesta = item.desRespuesta,
                            indAccesoGerencial = item.indAccesoGerencial,
                            indCambiaCodPersona = item.indCambiaCodPersona,
                            indCambiaDescuento = item.indCambiaDescuento,
                            indCambioPrecio = item.indCambioPrecio,
                            indJefeCaja = item.indJefeCaja,
                            indUsuarioSistema = item.indUsuarioSistema,
                            indVendedor = item.indVendedor,
                            indRestricPorPais = item.indRestricPorPais,
                            desTelefono = item.desTelefono,
                            indEstado = item.indEstado,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraEdita = item.segFechaHoraEdita,
                            segMaquinaEdita = item.segMaquinaOrigen,
                            desApellidosNombres = item.desApellidos.Trim() + ", " + item.desNombres.Trim(),
                            codArguPais = item.codArguPais,

                            fecBloqueUpdate = item.fecBloqueoUpdate,
                            indPasswordReset = item.indPasswordReset,
                            indOrigenUser = item.indOrigenUser,
                            urlPhotoUser = item.urlPhotoUser,

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUsuario;
        }

        #endregion

        #region " /* Proceso de Listar */ "

        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla]..Usuarios
        /// </summary>
        /// <returns>Lista</returns>
        public List<BEUsuarioAux> List(BEBuscaUsuarioRequest pFiltro)
        {
            List<BEUsuarioAux> lista = new List<BEUsuarioAux>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_Usuario(null, 
                                                              pFiltro.desCorreo,
                                                              pFiltro.desNombre, 
                                                              pFiltro.desCorreo,
                                                              pFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lista.Add(new BEUsuarioAux()
                        {
                            codUsuario = item.codUsuario,
                            desLogin = item.desLogin,
                            clvPassword = item.clvPassword,
                            desNombres = item.desNombres,
                            desApellidos = item.desApellidos,
                            desApellidosNombres = item.desApellidos.Trim() + ", " + item.desNombres.Trim(),
                            desPregunta = item.desPregunta,
                            codEmpleado = item.codEmpleado,
                            desCorreo = item.desCorreo,
                            desRespuesta = item.desRespuesta,
                            indAccesoGerencial = item.indAccesoGerencial,
                            indCambiaCodPersona = item.indCambiaCodPersona,
                            indCambiaDescuento = item.indCambiaDescuento,
                            indCambioPrecio = item.indCambioPrecio,
                            indJefeCaja = item.indJefeCaja,
                            indUsuarioSistema = item.indUsuarioSistema,
                            indVendedor = item.indVendedor,
                            indRestricPorPais = item.indRestricPorPais,
                            desTelefono = item.desTelefono,
                            indEstado = item.indEstado,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segFechaHoraCrea = Convert.ToDateTime(item.segFechaHoraCrea),
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraEdita = Convert.ToDateTime(item.segFechaHoraEdita),
                            segMaquinaOrigen = item.segMaquinaOrigen,
                            codArguPais = item.codArguPais,

                            fecBloqueUpdate = item.fecBloqueoUpdate,
                            indPasswordReset = item.indPasswordReset,
                            indOrigenUser = item.indOrigenUser,
                            urlPhotoUser = item.urlPhotoUser,
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

        /// <summary>
        /// Listado con paginacion para aplicación WEB 
        /// </summary>
        /// <param name="prm_LoginUsuario"></param>
        /// <param name="prm_Nombres"></param>
        /// <param name="prm_Apellidos"></param>
        /// <param name="prm_Estado"></param>
        /// <param name="p_NumPagina"></param>
        /// <param name="p_NumFilasP"></param>
        /// <param name="pNumFilasT"></param>
        /// <returns></returns>
        public List<DTOUsuarioResponse> ListPaged(BEBuscaUsuarioRequest pFiltro)
        {
            List<DTOUsuarioResponse> lista = new List<DTOUsuarioResponse>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_Usuario_Paged(pFiltro.jqCurrentPage,
                                                                    pFiltro.jqPageSize,
                                                                    pFiltro.jqSortColumn,
                                                                    pFiltro.jqSortOrder,
                                                                    pFiltro.codEmpleado,
                                                                    pFiltro.desLogin,
                                                                    pFiltro.desNombre,
                                                                    pFiltro.desCorreo,
                                                                    pFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lista.Add(new DTOUsuarioResponse()
                        {
                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0,

                            codUsuario = item.codUsuario,
                            desLogin = item.desLogin,
                            desNombres = item.desNombres,
                            desApellidos = item.desApellidos,

                            codEmpleado = item.codEmpleado,
                            desTelefono = item.desTelefono,
                            desCorreo = item.desCorreo,
                            indVendedor = item.indVendedor,
                            indEstado = item.indEstado,
                            indPasswordReset = item.indPasswordReset,
                            indLockUser = item.indLockUser.HasValue ? item.indLockUser.Value : false,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaHoraEdita,
                            segMaquinaEdita = item.segMaquinaEdita

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

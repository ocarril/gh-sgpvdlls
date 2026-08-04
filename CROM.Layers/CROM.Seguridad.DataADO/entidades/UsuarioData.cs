namespace CROM.Seguridad.DataADO
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Seguridad.BussinesEntities.entidades.request;
    using CROM.Seguridad.BussinesEntities.entidades.response;
    using CROM.Tools.Comun.settings;
    using CROM.Tools.Comun.Web;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Proyecto    : Seguridad del Sistema
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Descripcion : Clase para capa de datos (ADO.NET puro)
    /// Archivo     : UsuariosData.cs
    /// </summary
    public class UsuarioData : IDisposable
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
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_C_Usuario"))
                {
                    cmd.AddParam("@p_desLogin", SqlDbType.VarChar, 50, pItem.desLogin);
                    cmd.AddParam("@p_clvPassword", SqlDbType.VarChar, 150, pItem.clvPasswordEncrypt);
                    cmd.AddParam("@p_desNombres", SqlDbType.VarChar, 40, pItem.desNombres);
                    cmd.AddParam("@p_desApellidos", SqlDbType.VarChar, 40, pItem.desApellidos);
                    cmd.AddParam("@p_desPregunta", SqlDbType.VarChar, 60, pItem.desPregunta);
                    cmd.AddParam("@p_desRespuesta", SqlDbType.VarChar, 30, pItem.desRespuesta);
                    cmd.AddParam("@p_desTelefono", SqlDbType.VarChar, 30, pItem.desTelefono);
                    cmd.AddParam("@p_desCorreo", SqlDbType.VarChar, 30, pItem.desCorreo);
                    cmd.AddParam("@p_indRestricPorPais", SqlDbType.Bit, pItem.indRestricPorPais);
                    cmd.AddParam("@p_codEmpleado", SqlDbType.VarChar, 15, pItem.codEmpleado);
                    cmd.AddParam("@p_indVendedor", SqlDbType.Bit, pItem.indVendedor);
                    cmd.AddParam("@p_indCambioPrecio", SqlDbType.Bit, pItem.indCambioPrecio);
                    cmd.AddParam("@p_indAccesoGerencial", SqlDbType.Bit, pItem.indAccesoGerencial);
                    cmd.AddParam("@p_indCambiaDescuento", SqlDbType.Bit, pItem.indCambiaDescuento);
                    cmd.AddParam("@p_indCambiacodPer", SqlDbType.Bit, pItem.indCambiaCodPersona);
                    cmd.AddParam("@p_indJefeCaja", SqlDbType.Bit, pItem.indJefeCaja);
                    cmd.AddParam("@p_indUsuarioSistema", SqlDbType.Bit, pItem.indUsuarioSistema);
                    cmd.AddParam("@p_indEstado", SqlDbType.Bit, Convert.ToBoolean(pItem.indEstado));
                    cmd.AddParam("@p_segUsuarioCrea", SqlDbType.VarChar, 50, pItem.segUsuarioEdita);
                    cmd.AddParam("@p_codArguPais", SqlDbType.VarChar, 17, pItem.codArguPais);
                    cmd.AddParam("@p_urlPhotoUser", SqlDbType.VarChar, 250, pItem.urlPhotoUser);
                    cmd.AddParam("@p_indOrigenUser", SqlDbType.VarChar, 3, pItem.indOrigenUser);
                    cmd.AddParam("@p_codGUID", SqlDbType.VarChar, 50, pItem.codGUID);
                    cmd.AddParam("@p_codSistemaKey", SqlDbType.UniqueIdentifier, pItem.codSistemaKey);
                    cmd.AddParam("@p_codRolDefecto", SqlDbType.VarChar, 4, pItem.codRolDefecto);
                    cmd.AddParam("@p_segMaquinaIP", SqlDbType.VarChar, 30, pItem.segMaquinaEdita);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string codError = reader.GetStringOrNull("codError");
                            if (codError != "-406")
                            {
                                pItem.codUsuario = codError;
                                codigoRetorno = codError;
                            }

                            pMessage = reader.GetStringOrNull("desMessage");
                        }
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
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_U_Usuario"))
                {
                    cmd.AddParam("@p_codUsuario", SqlDbType.VarChar, 10, pItem.codUsuario);
                    cmd.AddParam("@p_desLogin", SqlDbType.VarChar, 50, pItem.desLogin);
                    cmd.AddParam("@p_desNombres", SqlDbType.VarChar, 40, pItem.desNombres);
                    cmd.AddParam("@p_desApellidos", SqlDbType.VarChar, 40, pItem.desApellidos);
                    cmd.AddParam("@p_desPregunta", SqlDbType.VarChar, 60, pItem.desPregunta);
                    cmd.AddParam("@p_desRespuesta", SqlDbType.VarChar, 30, pItem.desRespuesta);
                    cmd.AddParam("@p_desTelefono", SqlDbType.VarChar, 30, pItem.desTelefono);
                    cmd.AddParam("@p_desCorreo", SqlDbType.VarChar, 30, pItem.desCorreo);
                    cmd.AddParam("@p_indRestricPorPais", SqlDbType.Bit, pItem.indRestricPorPais);
                    cmd.AddParam("@p_codEmpleado", SqlDbType.VarChar, 15, pItem.codEmpleado);
                    cmd.AddParam("@p_indVendedor", SqlDbType.Bit, pItem.indVendedor);
                    cmd.AddParam("@p_indCambioPrecio", SqlDbType.Bit, pItem.indCambioPrecio);
                    cmd.AddParam("@p_indAccesoGerencial", SqlDbType.Bit, pItem.indAccesoGerencial);
                    cmd.AddParam("@p_indCambiaDescuento", SqlDbType.Bit, pItem.indCambiaDescuento);
                    cmd.AddParam("@p_indCambiacodPersona", SqlDbType.Bit, pItem.indCambiaCodPersona);
                    cmd.AddParam("@p_indJefeCaja", SqlDbType.Bit, pItem.indJefeCaja);
                    cmd.AddParam("@p_indUsuarioSistema", SqlDbType.Bit, pItem.indUsuarioSistema);
                    cmd.AddParam("@p_indEstado", SqlDbType.Bit, Convert.ToBoolean(pItem.indEstado));
                    cmd.AddParam("@p_segUsuarioEdita", SqlDbType.VarChar, 50, pItem.segUsuarioEdita);
                    cmd.AddParam("@p_codArguPais", SqlDbType.VarChar, 17, pItem.codArguPais);
                    cmd.AddParam("@p_urlPhotoUser", SqlDbType.VarChar, 250, pItem.urlPhotoUser);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            blnResult = reader.GetStringOrNull("desMessage") == WebConstants.DEFAULT_OK ? true : false;
                        }
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

        #region " /* Proceso de Eliminar */ "

        /// <summary>
        /// Elimina un expediente de la tabla Facturas por una llave primaria compuesta.
        /// </summary>
        public bool Delete(string CodigoUsuario)
        {
            int CodigoRetorno = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_D_Usuario"))
                {
                    cmd.AddParam("@p_codUsuario", SqlDbType.VarChar, 10, CodigoUsuario);
                    SqlParameter pReturn = cmd.AddReturnValueParam();
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    CodigoRetorno = Convert.ToInt32(pReturn.Value);
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
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_Usuario"))
                {
                    cmd.AddParam("@p_codUsuario", SqlDbType.VarChar, 10, pCodUsuario);
                    cmd.AddParam("@p_desLogin", SqlDbType.VarChar, 25, null);
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 25, null);
                    cmd.AddParam("@p_desCorreo", SqlDbType.VarChar, 25, null);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, true);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            objUsuario = new BEUsuarioResponse()
                            {
                                codUsuario = reader.GetStringOrNull("codUsuario"),
                                desLogin = reader.GetStringOrNull("desLogin"),
                                clvPassword = reader.GetStringOrNull("clvPassword"),
                                desNombres = reader.GetStringOrNull("desNombres"),
                                desApellidos = reader.GetStringOrNull("desApellidos"),
                                desPregunta = reader.GetStringOrNull("desPregunta"),
                                codEmpleado = reader.GetStringOrNull("codEmpleado"),
                                desCorreo = reader.GetStringOrNull("desCorreo"),
                                desRespuesta = reader.GetStringOrNull("desRespuesta"),
                                indAccesoGerencial = reader.GetBool("indAccesoGerencial"),
                                indCambiaCodPersona = reader.GetBool("indCambiaCodPersona"),
                                indCambiaDescuento = reader.GetBool("indCambiaDescuento"),
                                indCambioPrecio = reader.GetBool("indCambioPrecio"),
                                indJefeCaja = reader.GetBool("indJefeCaja"),
                                indUsuarioSistema = reader.GetBool("indUsuarioSistema"),
                                indVendedor = reader.GetBool("indVendedor"),
                                indRestricPorPais = reader.GetBool("indRestricPorPais"),
                                desTelefono = reader.GetStringOrNull("desTelefono"),
                                indEstado = reader.GetBool("indEstado"),
                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaHoraEdita = reader.GetDateTimeOrNull("segFechaHoraEdita"),
                                segMaquinaEdita = reader.GetStringOrNull("segMaquinaOrigen"),
                                desApellidosNombres = reader.GetStringOrNull("desApellidos").Trim() + ", " + reader.GetStringOrNull("desNombres").Trim(),
                                codArguPais = reader.GetStringOrNull("codArguPais"),

                                fecBloqueUpdate = reader.GetDateTimeOrNull("fecBloqueoUpdate"),
                                indPasswordReset = reader.GetBool("indPasswordReset"),
                                indOrigenUser = reader.GetStringOrNull("indOrigenUser"),
                                urlPhotoUser = reader.GetStringOrNull("urlPhotoUser"),

                            };
                        }
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
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_Usuario"))
                {
                    // NOTA: comportamiento heredado de CROM.Seguridad.DataAcces (no corregido en esta migración):
                    // pFiltro.desCorreo se envía tanto en la posición de login como en la de correo.
                    cmd.AddParam("@p_codUsuario", SqlDbType.VarChar, 10, null);
                    cmd.AddParam("@p_desLogin", SqlDbType.VarChar, 25, pFiltro.desCorreo);
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 25, pFiltro.desNombre);
                    cmd.AddParam("@p_desCorreo", SqlDbType.VarChar, 25, pFiltro.desCorreo);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pFiltro.indActivo);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BEUsuarioAux()
                            {
                                codUsuario = reader.GetStringOrNull("codUsuario"),
                                desLogin = reader.GetStringOrNull("desLogin"),
                                clvPassword = reader.GetStringOrNull("clvPassword"),
                                desNombres = reader.GetStringOrNull("desNombres"),
                                desApellidos = reader.GetStringOrNull("desApellidos"),
                                desApellidosNombres = reader.GetStringOrNull("desApellidos").Trim() + ", " + reader.GetStringOrNull("desNombres").Trim(),
                                desPregunta = reader.GetStringOrNull("desPregunta"),
                                codEmpleado = reader.GetStringOrNull("codEmpleado"),
                                desCorreo = reader.GetStringOrNull("desCorreo"),
                                desRespuesta = reader.GetStringOrNull("desRespuesta"),
                                indAccesoGerencial = reader.GetBool("indAccesoGerencial"),
                                indCambiaCodPersona = reader.GetBool("indCambiaCodPersona"),
                                indCambiaDescuento = reader.GetBool("indCambiaDescuento"),
                                indCambioPrecio = reader.GetBool("indCambioPrecio"),
                                indJefeCaja = reader.GetBool("indJefeCaja"),
                                indUsuarioSistema = reader.GetBool("indUsuarioSistema"),
                                indVendedor = reader.GetBool("indVendedor"),
                                indRestricPorPais = reader.GetBool("indRestricPorPais"),
                                desTelefono = reader.GetStringOrNull("desTelefono"),
                                indEstado = reader.GetBool("indEstado"),
                                segUsuarioCrea = reader.GetStringOrNull("segUsuarioCrea"),
                                segFechaHoraCrea = reader.GetDateTime("segFechaHoraCrea"),
                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaHoraEdita = reader.GetDateTime("segFechaHoraEdita"),
                                segMaquinaOrigen = reader.GetStringOrNull("segMaquinaOrigen"),
                                codArguPais = reader.GetStringOrNull("codArguPais"),

                                fecBloqueUpdate = reader.GetDateTimeOrNull("fecBloqueoUpdate"),
                                indPasswordReset = reader.GetBool("indPasswordReset"),
                                indOrigenUser = reader.GetStringOrNull("indOrigenUser"),
                                urlPhotoUser = reader.GetStringOrNull("urlPhotoUser"),
                            });
                        }
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
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTOUsuarioResponse> ListPaged(BEBuscaUsuarioRequest pFiltro)
        {
            List<DTOUsuarioResponse> lista = new List<DTOUsuarioResponse>();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_Usuario_Paged"))
                {
                    cmd.AddParam("@p_NumPagina", SqlDbType.Int, pFiltro.jqCurrentPage);
                    cmd.AddParam("@p_TamPagina", SqlDbType.Int, pFiltro.jqPageSize);
                    cmd.AddParam("@p_OrdenPor", SqlDbType.VarChar, 30, pFiltro.jqSortColumn);
                    cmd.AddParam("@p_OrdenTipo", SqlDbType.VarChar, 4, pFiltro.jqSortOrder);
                    cmd.AddParam("@p_codEmpleado", SqlDbType.VarChar, 20, pFiltro.codEmpleado);
                    cmd.AddParam("@p_desLogin", SqlDbType.VarChar, 25, pFiltro.desLogin);
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 25, pFiltro.desNombre);
                    cmd.AddParam("@p_desCorreo", SqlDbType.VarChar, 25, pFiltro.desCorreo);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pFiltro.indActivo);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new DTOUsuarioResponse()
                            {
                                ROW = reader.GetInt("ROWNUM"),
                                TOTALROWS = reader.GetInt("TOTALROWS"),

                                codUsuario = reader.GetStringOrNull("codUsuario"),
                                desLogin = reader.GetStringOrNull("desLogin"),
                                desNombres = reader.GetStringOrNull("desNombres"),
                                desApellidos = reader.GetStringOrNull("desApellidos"),

                                codEmpleado = reader.GetStringOrNull("codEmpleado"),
                                desTelefono = reader.GetStringOrNull("desTelefono"),
                                desCorreo = reader.GetStringOrNull("desCorreo"),
                                indVendedor = reader.GetBool("indVendedor"),
                                indEstado = reader.GetBool("indEstado"),
                                indPasswordReset = reader.GetBool("indPasswordReset"),
                                indLockUser = reader.GetBool("indLockUser"),
                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaEdita = reader.GetDateTimeOrNull("segFechaHoraEdita"),
                                segMaquinaEdita = reader.GetStringOrNull("segMaquinaEdita")

                            });
                        }
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

namespace CROM.Seguridad.DataADO
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.acceso;
    using CROM.Tools.Comun.security;
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
    /// Archivo     : SeguridadData.cs
    /// </summary
    public class SeguridadData
    {
        private string conexion = String.Empty;

        public SeguridadData()
        {
            conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG");
        }

        #region " /* Proceso de Detectar Login y Password */ "

        public BEUsuarioDetectLogin DetectLoginPassword(string pLoginUsuario)
        {
            BEUsuarioDetectLogin pUsuarioDetectLogin = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_pro_SIS_Usuario_DetectLoginPassword"))
                {
                    cmd.AddParam("@p_LoginUsuario", SqlDbType.VarChar, 25, pLoginUsuario);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        pUsuarioDetectLogin = new BEUsuarioDetectLogin();
                        while (reader.Read())
                        {
                            pUsuarioDetectLogin.codError = reader.GetInt("codError");
                            pUsuarioDetectLogin.desMessage = reader.GetStringOrNull("desMessage");
                            pUsuarioDetectLogin.clvPasswordEncripted = reader.GetStringOrNull("clvPassword");
                            pUsuarioDetectLogin.fecBloqueoUpdate = reader.GetDateTimeOrNull("fecBloqueoUpdate");
                            pUsuarioDetectLogin.indBloqueoUpdate = reader.GetBool("indBloqueoUpdate");
                            pUsuarioDetectLogin.indPasswordReset = reader.GetBool("indPasswordReset");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pUsuarioDetectLogin;
        }

        public BEUsuarioAux FindLogin(string prm_LoginUsuario)
        {
            BEUsuarioAux objUsuario = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_pro_SIS_Usuario_LoginValidated"))
                {
                    cmd.AddParam("@p_LoginUsuario", SqlDbType.VarChar, 50, prm_LoginUsuario);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            objUsuario = new BEUsuarioAux()
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
                                segUsuarioCrea = reader.GetStringOrNull("segUsuarioCrea"),
                                segFechaHoraCrea = reader.GetDateTime("segFechaHoraCrea"),
                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaHoraEdita = reader.GetDateTime("segFechaHoraEdita"),
                                segMaquinaOrigen = reader.GetStringOrNull("segMaquinaOrigen"),
                                desApellidosNombres = reader.GetStringOrNull("desApellidos").Trim() + ", " + reader.GetStringOrNull("desNombres").Trim(),
                                codArguPais = reader.GetStringOrNull("codArguPais"),

                                fecBloqueUpdate = reader.GetDateTimeOrNull("fecBloqueoUpdate"),
                                indPasswordReset = reader.GetBool("indPasswordReset"),
                                indOrigenUser = reader.GetStringOrNull("indOrigenUser"),
                                urlPhotoUser = reader.GetStringOrNull("urlPhotoUser"),
                                codGUID = reader.GetStringOrNull("codGUID")

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

        public BEUsuarioValidoResponse FindLoginValidated(string prm_LoginUsuario)
        {
            BEUsuarioValidoResponse objUsuario = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_pro_SIS_Usuario_LoginValidated"))
                {
                    cmd.AddParam("@p_LoginUsuario", SqlDbType.VarChar, 50, prm_LoginUsuario);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            objUsuario = new BEUsuarioValidoResponse();

                            objUsuario.codUsuario = reader.GetStringOrNull("codUsuario");
                            objUsuario.desLogin = reader.GetStringOrNull("desLogin");
                            objUsuario.desNombre = reader.GetStringOrNull("desNombres");
                            objUsuario.desApellido = reader.GetStringOrNull("desApellidos");
                            objUsuario.desNombreUsuario = string.Concat(reader.GetStringOrNull("desNombres"), " ", reader.GetStringOrNull("desApellidos"));
                            objUsuario.desTelefono = reader.GetStringOrNull("desTelefono");
                            objUsuario.desCorreo = reader.GetStringOrNull("desCorreo");
                            objUsuario.codEmpleado = reader.GetStringOrNull("codEmpleado");
                            objUsuario.indVendedor = reader.GetBool("indVendedor");
                            objUsuario.indCambioPrecio = reader.GetBool("indCambioPrecio");
                            objUsuario.indAccesoGerencial = reader.GetBool("indAccesoGerencial");
                            objUsuario.indCambiaDescuento = reader.GetBool("indCambiaDescuento");
                            objUsuario.indCambiaCodPersona = reader.GetBool("indCambiaCodPersona");
                            objUsuario.indJefeCaja = reader.GetBool("indJefeCaja");
                            objUsuario.indUsuarioSistema = reader.GetBool("indUsuarioSistema");
                            objUsuario.codSistemaNombre = reader.GetStringOrNull("codSistemaNombre");
                            objUsuario.codRolNombre = reader.GetStringOrNull("codRolNombre");
                            objUsuario.codEmpresaNombre = reader.GetStringOrNull("codEmpresaNombre");
                            objUsuario.urlPhotoUser = reader.GetStringOrNull("urlPhotoUser");
                            objUsuario.indOrigenUser = reader.GetStringOrNull("indOrigenUser");
                            objUsuario.codGUID = reader.GetStringOrNull("codGUID");
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

        public bool UpdateUserIndPasswordReset(BEUsuarioPasswordResetRequest pUsuarioPassword, out string pMessage)
        {
            bool blnResult = false;
            pMessage = string.Empty;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_pro_SIU_Usuario_indPasswordReset"))
                {
                    cmd.AddParam("@p_codUsuario", SqlDbType.VarChar, 10, pUsuarioPassword.codUsuario);
                    cmd.AddParam("@p_password", SqlDbType.VarChar, 150, pUsuarioPassword.clvPasswordEncrypt);
                    cmd.AddParam("@p_segUsuarioEdita", SqlDbType.VarChar, 50, pUsuarioPassword.segUsuarioEdita);
                    cmd.AddParam("@p_segMaquina", SqlDbType.VarChar, 25, pUsuarioPassword.segMaquinaEdita);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int codError = reader.GetInt("codError");
                            string desMessage = reader.GetStringOrNull("desMessage");
                            if (codError == 1 && desMessage == WebConstants.DEFAULT_OK)
                                blnResult = true;
                            else
                                pMessage = desMessage;
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

        public bool UpdateUserfecBloqueo(BEUsuarioFecBloqueoRequest pUsuarioFecBloqueo, out string pMessage)
        {
            bool blnResult = false;
            pMessage = string.Empty;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_pro_SIU_Usuario_fecBloqueoUpdate"))
                {
                    cmd.AddParam("@p_codUsuario", SqlDbType.VarChar, 10, pUsuarioFecBloqueo.codUsuario);
                    cmd.AddParam("@p_flagBloquea", SqlDbType.Bit, pUsuarioFecBloqueo.flagBloquea);
                    cmd.AddParam("@p_segUsuarioEdita", SqlDbType.VarChar, 50, pUsuarioFecBloqueo.segUsuarioEdita);
                    cmd.AddParam("@p_segMaquina", SqlDbType.VarChar, 25, pUsuarioFecBloqueo.segMaquinaEdita);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int codError = reader.GetInt("codError");
                            string desMessage = reader.GetStringOrNull("desMessage");
                            if (codError == 1 && desMessage == WebConstants.DEFAULT_OK)
                                blnResult = true;
                            else
                                pMessage = desMessage;
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

        public bool UpdatePasswordExterno(BEUsuarioPasswordRequest pUsuarioUpdatePassword, out string pMessage)
        {
            bool blnResult = false;
            pMessage = string.Empty;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_pro_SIU_Usuario_PasswordExterno"))
                {
                    cmd.AddParam("@p_desLogin", SqlDbType.VarChar, 25, pUsuarioUpdatePassword.desLogin);
                    cmd.AddParam("@p_clvPassword", SqlDbType.VarChar, 150, pUsuarioUpdatePassword.clvPasswordEncrypt);
                    cmd.AddParam("@p_segUsuarioEdita", SqlDbType.VarChar, 50, pUsuarioUpdatePassword.segUsuarioEdita);
                    cmd.AddParam("@p_segMaquina", SqlDbType.VarChar, 25, pUsuarioUpdatePassword.segMaquinaEdita);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int codError = reader.GetInt("codError");
                            string desMessage = reader.GetStringOrNull("desMessage");
                            blnResult = codError == 1 ? true : false;
                            pMessage = desMessage == WebConstants.DEFAULT_OK ? string.Empty : desMessage;
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

        public List<BEUsuarioPermisoResponse> ListUserObjectsGrants(BEUsuarioPermisoRequest pUsuarioPermiso)
        {
            List<BEUsuarioPermisoResponse> lista = new List<BEUsuarioPermisoResponse>();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_UsuarioObjeto"))
                {
                    cmd.AddParam("@p_codEmpresa", SqlDbType.Int, pUsuarioPermiso.codEmpresa);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pUsuarioPermiso.codSistema);
                    cmd.AddParam("@p_desLogin", SqlDbType.VarChar, 50, pUsuarioPermiso.desLogin);
                    cmd.AddParam("@p_tipObjeto", SqlDbType.VarChar, 40, pUsuarioPermiso.tipoObjeto);
                    cmd.AddParam("@p_nomAction", SqlDbType.VarChar, 50, pUsuarioPermiso.nomAction);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BEUsuarioPermisoResponse()
                            {
                                codElementoID = reader.GetStringOrNull("codElementoID"),
                                codOpcion = reader.GetStringOrNull("codOpcion"),
                                codOpcionNombre = reader.GetStringOrNull("codOpcionNombre"),
                                codOpcionDescripcion = reader.GetStringOrNull("codOpcionDescripcion"),
                                codOpcionPadre = reader.GetStringOrNull("codOpcionPadre"),
                                codOpcionPadreNombre = reader.GetStringOrNull("codOpcionPadreNombre"),
                                desEnlaceURL = reader.GetStringOrNull("desEnlaceURL"),
                                desEnlaceWIN = reader.GetStringOrNull("desEnlaceWIN"),
                                codSistema = pUsuarioPermiso.codSistema,
                                desEnlacePadre = reader.GetStringOrNull("desEnlacePadre"),

                                indEditar = reader.GetBool("indEditar"),
                                indEliminar = reader.GetBool("indEliminar"),
                                indExporta = reader.GetBool("indExporta"),
                                indImporta = reader.GetBool("indImporta"),
                                indImprime = reader.GetBool("indImprime"),
                                indNuevo = reader.GetBool("indNuevo"),
                                indOtro = reader.GetBool("indOtro"),
                                indVer = reader.GetBool("indVer"),

                                indTipoObjeto = reader.GetStringOrNull("indTipoObjeto"),
                                nomIcono = reader.GetStringOrNull("nomIcono"),
                                numOrden = reader.GetInt("numOrden")

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
        /// Metodo                  :InsertarAuditoria
        /// Propósito               :Permite insertar datos de auditoria al momento de loguear usuario
        /// Autor                   :OCR - Orlando Carril R.
        /// </summary>
        /// <param name="objAuditoria"></param>
        public int InsertarAuditoria(BEAuditoria objAuditoria)
        {
            int codigoRetorno = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_pro_SII_Auditoria"))
                {
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 50, objAuditoria.codSistema);
                    cmd.AddParam("@p_codRol", SqlDbType.VarChar, 4, objAuditoria.codRol);
                    cmd.AddParam("@p_codUsuario", SqlDbType.VarChar, 10, objAuditoria.codUsuario);
                    cmd.AddParam("@p_desLogin", SqlDbType.VarChar, 50, objAuditoria.desLogin);
                    cmd.AddParam("@p_desMensaje", SqlDbType.VarChar, 200, objAuditoria.desMensaje);
                    cmd.AddParam("@p_desTipo", SqlDbType.VarChar, 20, objAuditoria.desTipo);
                    cmd.AddParam("@p_fecRegistroApp", SqlDbType.DateTime, objAuditoria.fecRegistroApp);
                    cmd.AddParam("@p_nomMaquinaIP", SqlDbType.VarChar, 30, objAuditoria.nomMaquinaIP);
                    cmd.AddParam("@p_codEmpresa", SqlDbType.Int, objAuditoria.codEmpresa);
                    SqlParameter pNumVeces = cmd.AddInputOutputParam("@p_numVeces", SqlDbType.Int, 0);

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    codigoRetorno = pNumVeces.Value == DBNull.Value || pNumVeces.Value == null ? 0 : Convert.ToInt32(pNumVeces.Value);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return codigoRetorno;
        }


        /// <summary>
        /// Metodo                  :Dispose
        /// Propósito               :Permite Liberar de la memoria al objeto instanciado
        /// Autor                   :OCR - Orlando Carril R.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

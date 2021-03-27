namespace CROM.Seguridad.DataAcces
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.acceso;
    using CROM.Seguridad.DataAcces.acceso;
    using CROM.Tools.Comun.security;
    using CROM.Tools.Comun.settings;

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Seguridad del Sistema
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 07/11/2009
    /// Descripcion : Clase para capa de datos
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
                using (DBML_AccesoDataContext SQLDC = new DBML_AccesoDataContext(conexion))
                {
                    pUsuarioDetectLogin = new BEUsuarioDetectLogin();
                    
                    var resul = SQLDC.omgc_pro_SIS_Usuario_DetectLoginPassword(pLoginUsuario);
                    foreach(var item in resul)
                    {

                        pUsuarioDetectLogin.codError = item.codError.HasValue? item.codError.Value:0;
                        pUsuarioDetectLogin.desMessage = item.desMessage;
                        pUsuarioDetectLogin.clvPasswordEncripted = item.clvPassword;
                        pUsuarioDetectLogin.fecBloqueoUpdate = item.fecBloqueoUpdate;
                        pUsuarioDetectLogin.indBloqueoUpdate = item.indBloqueoUpdate.HasValue ? item.indBloqueoUpdate.Value : false;
                        pUsuarioDetectLogin.indPasswordReset = item.indPasswordReset.HasValue ? item.indPasswordReset.Value : false;

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
                using (DBML_AccesoDataContext SeguridadDC = new DBML_AccesoDataContext(conexion))
                {
                    var resul = SeguridadDC.omgc_pro_SIS_Usuario_LoginValidated(prm_LoginUsuario);
                    foreach (var item in resul)
                    {
                        objUsuario = new BEUsuarioAux()
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
                            segUsuarioCrea = item.segUsuarioCrea,
                            segFechaHoraCrea = Convert.ToDateTime(item.segFechaHoraCrea),
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraEdita = Convert.ToDateTime(item.segFechaHoraEdita),
                            segMaquinaOrigen = item.segMaquinaOrigen,
                            desApellidosNombres = item.desApellidos.Trim() + ", " + item.desNombres.Trim(),
                            codArguPais = item.codArguPais,

                            fecBloqueUpdate = item.fecBloqueoUpdate,
                            indPasswordReset = item.indPasswordReset,
                            indOrigenUser = item.indOrigenUser,
                            urlPhotoUser = item.urlPhotoUser,
                            codGUID = item.codGUID

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

        public BEUsuarioValidoResponse FindLoginValidated(string prm_LoginUsuario)
        {
            BEUsuarioValidoResponse objUsuario = null;
            try
            {
                using (DBML_AccesoDataContext SeguridadDC = new DBML_AccesoDataContext(conexion))
                {
                    var resul = SeguridadDC.omgc_pro_SIS_Usuario_LoginValidated(prm_LoginUsuario);
                    foreach (var item in resul)
                    {
                        objUsuario = new BEUsuarioValidoResponse();

                        objUsuario.codUsuario = item.codUsuario;
                        objUsuario.desLogin = item.desLogin;
                        objUsuario.desNombre = item.desNombres;
                        objUsuario.desApellido = item.desApellidos;
                        objUsuario.desNombreUsuario = string.Concat(item.desNombres, " ", item.desApellidos);
                        objUsuario.desTelefono = item.desTelefono;
                        objUsuario.desCorreo = item.desCorreo;
                        objUsuario.codEmpleado = item.codEmpleado;
                        objUsuario.indVendedor = item.indVendedor;
                        objUsuario.indCambioPrecio = item.indCambioPrecio;
                        objUsuario.indAccesoGerencial = item.indAccesoGerencial;
                        objUsuario.indCambiaDescuento = item.indCambiaDescuento;
                        objUsuario.indCambiaCodPersona = item.indCambiaCodPersona;
                        objUsuario.indJefeCaja = item.indJefeCaja;
                        objUsuario.indUsuarioSistema = item.indUsuarioSistema;
                        objUsuario.codSistemaNombre = item.codSistemaNombre;
                        objUsuario.codRolNombre = item.codRolNombre;
                        objUsuario.codEmpresaNombre = item.codEmpresaNombre;
                        objUsuario.urlPhotoUser = item.urlPhotoUser;
                        objUsuario.indOrigenUser = item.indOrigenUser;
                        objUsuario.codGUID = item.codGUID;
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
                using (DBML_AccesoDataContext SeguridadDC = new DBML_AccesoDataContext(conexion))
                {
                    var resulSet = SeguridadDC.omgc_pro_SIU_Usuario_indPasswordReset(
                        pUsuarioPassword.codUsuario,
                        pUsuarioPassword.clvPasswordEncrypt,
                        pUsuarioPassword.segUsuarioEdita,
                        pUsuarioPassword.segMaquinaEdita
                    );

                    foreach (var item in resulSet)
                    {
                        if (item.codError == 1 && item.desMessage == "OK")
                            blnResult = true;
                        else
                            pMessage = item.desMessage;
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
                using (DBML_AccesoDataContext SeguridadDC = new DBML_AccesoDataContext(conexion))
                {
                    var resulSet = SeguridadDC.omgc_pro_SIU_Usuario_fecBloqueoUpdate(
                        pUsuarioFecBloqueo.codUsuario,
                        pUsuarioFecBloqueo.flagBloquea,
                        pUsuarioFecBloqueo.segUsuarioEdita,
                        pUsuarioFecBloqueo.segMaquinaEdita
                    );

                    foreach (var item in resulSet)
                    {
                        if (item.codError == 1 && item.desMessage == "OK")
                            blnResult = true;
                        else
                            pMessage = item.desMessage;
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
                using (DBML_AccesoDataContext SeguridadDC = new DBML_AccesoDataContext(conexion))
                {
                    var resulSet = SeguridadDC.omgc_pro_SIU_Usuario_PasswordExterno(
                        pUsuarioUpdatePassword.desLogin,
                        pUsuarioUpdatePassword.clvPasswordEncrypt,
                        pUsuarioUpdatePassword.segUsuarioEdita,
                        pUsuarioUpdatePassword.segMaquinaEdita
                    );
                    foreach (var item in resulSet)
                    {
                        blnResult = item.codError == 1 ? true : false;
                        pMessage = item.desMessage == "OK" ? string.Empty : item.desMessage;
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
                using (DBML_AccesoDataContext SeguridadDC = new DBML_AccesoDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_UsuarioObjeto(pUsuarioPermiso.codEmpresa,
                                                                    pUsuarioPermiso.codSistema,
                                                                    pUsuarioPermiso.desLogin,
                                                                    pUsuarioPermiso.tipoObjeto,
                                                                    pUsuarioPermiso.nomAction);
                    foreach (var item in resul)
                    {
                        lista.Add(new BEUsuarioPermisoResponse()
                        {
                            codElementoID = item.codElementoID,
                            codOpcion = item.codOpcion,
                            codOpcionNombre = item.codOpcionNombre,
                            codOpcionDescripcion = item.codOpcionDescripcion,
                            codOpcionPadre = item.codOpcionPadre,
                            codOpcionPadreNombre = item.codOpcionPadreNombre,
                            desEnlaceURL = item.desEnlaceURL,
                            desEnlaceWIN = item.desEnlaceWIN,
                            codSistema = pUsuarioPermiso.codSistema,
                            desEnlacePadre = item.desEnlacePadre,

                            indEditar = item.indEditar.HasValue ? item.indEditar.Value : false,
                            indEliminar = item.indEliminar.HasValue ? item.indEliminar.Value : false,
                            indExporta = item.indExporta.HasValue ? item.indExporta.Value : false,
                            indImporta = item.indImporta.HasValue ? item.indImporta.Value : false,
                            indImprime = item.indImprime.HasValue ? item.indImprime.Value : false,
                            indNuevo =   item.indNuevo.HasValue ? item.indNuevo.Value : false,
                            indOtro =    item.indOtro.HasValue ? item.indOtro.Value : false,
                            indVer =     item.indVer.HasValue ? item.indVer.Value : false,

                            indTipoObjeto = item.indTipoObjeto,
                            nomIcono = item.nomIcono,
                            numOrden = item.numOrden.HasValue ? item.numOrden.Value : 0

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
        /// Metodo                  :InsertarAuditoria 
        /// Propósito               :Permite insertar datos de auditoria al momento de loguear usuario
        /// Retorno                 :N/A
        /// Notas                   :N/A
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :15/09/2019
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="objAuditoria"></param>
        public int InsertarAuditoria(BEAuditoria objAuditoria)
        {
            int codigoRetorno = 0;
            try
            {
                using (DBML_AccesoDataContext SQLDC = new DBML_AccesoDataContext(conexion))
                {
                    int? intResultado = 0;
                    SQLDC.omgc_pro_SII_Auditoria(objAuditoria.codSistema,
                                             objAuditoria.codRol,
                                             objAuditoria.codUsuario,
                                             objAuditoria.desLogin,
                                             objAuditoria.desMensaje,
                                             objAuditoria.desTipo,
                                             objAuditoria.fecRegistroApp,
                                             objAuditoria.nomMaquinaIP,
                                             objAuditoria.codEmpresa,
                                             ref intResultado);
                    codigoRetorno = intResultado.HasValue ? intResultado.Value : 0;
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
        /// Efectos                 :N/A
        /// Retorno                 :N/A
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :20/10/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

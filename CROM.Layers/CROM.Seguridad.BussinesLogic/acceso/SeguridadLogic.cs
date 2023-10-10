namespace CROM.Seguridad.BussinesLogic
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.acceso;
    using CROM.Seguridad.BussinesEntities.entidades.request;
    using CROM.Seguridad.DataAcces;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.security;
    using CROM.Tools.Comun.security.Extensiones;
    using CROM.Tools.Comun.settings;
    using CROM.Tools.Comun.Web;

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Transactions;
    using static CROM.Tools.Comun.Web.WebConstants;

    /// <summary>
    /// Proyecto    : Seguridad del Sistema
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 07/11/2009
    /// Descripcion : Clase para capa de Negocio
    /// Archivo     : SeguridadLogic.cs
    /// </summary
    public class SeguridadLogic : BaseLayer
    {
        private SeguridadData oSeguridadData = null;
        private ReturnValor oReturn = null;

        public SeguridadLogic()
        {
            oSeguridadData = new SeguridadData();
            oReturn = new ReturnValor();
        }

        #region METODOS USADOS POR LA API DE SEGURIDAD

        /// <summary>
        /// Metodo                  :DetectarUsuario 
        /// Propósito               :Permite detectar la existencia del usuario con Login y Contrasenia
        /// Retorno                 :Verdadero o Falso
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :22/10/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="pdesLogin">Login del usuario</param>
        /// <param name="pclvContrasenia">Contraseña del usuario</param>
        /// <returns></returns>
        public OperationResult ValidarUsuario(string pdesLogin, string pclvContrasenia, string pKeySistema, string numIP)
        {
            BEUsuarioValidoResponse objUsuarioValidado = null;
            SeguridadData objSeguridadDataNx = null;
            try
            {

                objSeguridadDataNx = new SeguridadData();

                var pUserSeek = ValidarDataAccesoUsuario(pdesLogin, pclvContrasenia);

                if (pUserSeek.brokenRulesCollection.Count == 0)
                {
                    string pMessage = string.Empty;
                    if (!DetectLoginPasswordExterno(pdesLogin, pclvContrasenia, out pMessage))
                    {
                        var operationResult = new OperationResult();
                        operationResult.isValid = false;
                        operationResult.brokenRulesCollection.Add(new BrokenRule
                        {
                            description = pMessage,
                            severity = RuleSeverity.Warning
                        });

                        return operationResult;
                    }
                    objUsuarioValidado = objSeguridadDataNx.FindLoginValidated(pdesLogin);

                    if (objUsuarioValidado == null)
                    {
                        /* Guardar auditoria de los ingresos FALLIDOS al sistema  */
                        int codigoRetorno = InsertAuditoria(new BEAuditoria
                        {
                            desLogin = pdesLogin,
                            codRol = null,
                            codSistema = pKeySistema,
                            desMensaje = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2004).Value,
                            desTipo = RuleSeverity.Warning.ToString(),
                            fecRegistroApp = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()),
                            nomMaquinaIP = numIP
                        });

                        var operationResult = new OperationResult();
                        if (codigoRetorno <= 3)
                            operationResult.brokenRulesCollection.Add(new BrokenRule
                            {
                                description = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2004).Value,
                                severity = RuleSeverity.Warning
                            });
                        else
                            operationResult.brokenRulesCollection.Add(new BrokenRule
                            {
                                description = string.Format(WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2013).Value,
                                                              codigoRetorno),
                                severity = RuleSeverity.Warning
                            });
                        return operationResult;
                    }
                    else /* Guardar auditoria de los ingresos SATISFACTORIOS al sistema  */
                    {
                        var operationResult = new OperationResult();
                        operationResult = ValidarAccesoUsuarioSistemaEmpresa(objUsuarioValidado, pKeySistema);

                        if (operationResult.isValid)
                        {
                            objUsuarioValidado.Token = GetToken(objUsuarioValidado);
                            objUsuarioValidado.ResultIndValido = true;

                            var auditoria = new BEAuditoria
                            {
                                desLogin = pdesLogin,
                                codRol = objUsuarioValidado.codRol,
                                codEmpresa = objUsuarioValidado.codEmpresa,
                                codSistema = pKeySistema,
                                desTipo = RuleSeverity.Success.ToString(),
                                fecRegistroApp = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()),
                                nomMaquinaIP = numIP
                            };
                            auditoria.desMensaje = string.Format( WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2000).Value,
                                                                  objUsuarioValidado.codEmpresaNombre);
                            int codigoRetorno = InsertAuditoria(auditoria);

                        }
                        else
                            return operationResult;
                    }


                }
                else
                {
                    objUsuarioValidado = new BEUsuarioValidoResponse();
                    objUsuarioValidado.ResultIMessage = pUserSeek.brokenRulesCollection[0].description;
                    objUsuarioValidado.ResultIndValido = false;
                    
                }
                return OK(objUsuarioValidado);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, "", "");
            }
        }


        public string GetToken(BEUsuarioValidoResponse objUsuarioValidado)
        {
            EmpresaSistemaData oEmpresaSistemaData = new EmpresaSistemaData();
            BEEmpresaSistema oEmpresaSistema = oEmpresaSistemaData.Find(objUsuarioValidado.codEmpresa,
                                                                        objUsuarioValidado.codSistema);

            return StringExtensions.OfuscateUrl(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}",
                             /* 00  */        objUsuarioValidado.codUsuario,
                             /* 01  */        objUsuarioValidado.codEmpleado,
                             /* 02  */        objUsuarioValidado.desLogin,
                             /* 03  */        objUsuarioValidado.desCorreo,
                             /* 04  */        objUsuarioValidado.desNombreUsuario,
                             /* 05  */        objUsuarioValidado.codEmpresa,
                             /* 06  */        objUsuarioValidado.codEmpresaNombre,
                             /* 07  */        objUsuarioValidado.numRUC,
                             /* 08  */        objUsuarioValidado.codSistema,
                             /* 09  */        objUsuarioValidado.codSistemaNombre,
                             /* 10  */        objUsuarioValidado.codRol,
                             /* 11  */        objUsuarioValidado.codRolNombre,
                             /* 12  */        HelpTime.DateTimeToUnixTimestamp(DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).AddHours(
                                              oEmpresaSistema.numTiempoToken == 0 ? 24 :
                                              oEmpresaSistema.numTiempoToken)).ToString())
                                            );
        }


        public OperationResult GetRenovarToken(BEUsuarioValidoResponse pUserValidated)
        {
            try
            {
                pUserValidated.Token = GetToken(pUserValidated);
                return OK(pUserValidated);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pUserValidated.desLogin, "");
            }
        }


        public OperationResult ListUserObjectsGrants(BEUsuarioPermisoRequest pUsuarioPermiso)
        {
            List<BEUsuarioPermisoResponse> lstPermisos = new List<BEUsuarioPermisoResponse>();

            try
            {
                lstPermisos = oSeguridadData.ListUserObjectsGrants(pUsuarioPermiso);

                return OK(lstPermisos);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pUsuarioPermiso.desLogin, pUsuarioPermiso.codEmpresa);
            }
        }


        public bool DetectLoginPasswordExterno(string pLoginUsuario, string pPasswordExterno, out string pMessage)
        {

            bool DetectadoEsValido = false;
            pMessage = string.Empty;
            string PasswordEncriptado = string.Empty;
            try
            {
                var DetectResult = oSeguridadData.DetectLoginPassword(pLoginUsuario);
                if (DetectResult == null)
                {
                    pMessage = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2004).Value;
                    return DetectadoEsValido;
                }
                if (DetectResult.indBloqueoUpdate)
                {
                    pMessage = string.Format(WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2025).Value,
                                              DetectResult.fecBloqueoUpdate != null ?
                                                DetectResult.fecBloqueoUpdate.Value.FormatDateToDDMMYYYY() :
                                                DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).FormatDateToDDMMYYYY());
                    return DetectadoEsValido;
                }
                if (DetectResult.indPasswordReset)
                {
                    pMessage = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2026).Value;
                    return DetectadoEsValido;
                }
                if (DetectResult.desMessage.ToUpper() == WebConstants.DEFAULT_OK)
                {
                    DetectadoEsValido = HelpCrypto.SISValidarTextoEncriptado(pPasswordExterno, DetectResult.clvPasswordEncripted);
                    if (!DetectadoEsValido)
                    {
                        pMessage = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2027).Value;
                    }
                }
                else
                    pMessage = DetectResult.desMessage;


            }
            catch (Exception ex)
            {
                int indExiste = ex.Message.ToLower().IndexOf("ip address");
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pLoginUsuario);
                throw new Exception(string.Concat(returnValor.Message, ". ", indExiste > 0 ? ex.Message : string.Empty));
            }
            return DetectadoEsValido;

        }

        public OperationResult UpdateUserIndPasswordReset(BEUsuarioPasswordResetRequest pUsuarioPasswordReset)
        {
            SeguridadData objSeguridadDataNx = null;
            ReturnValor oReturn = new ReturnValor();
            try
            {
                string clvPasswordEncrypt = HelpCrypto.GenerarContrasenia(8);

                objSeguridadDataNx = new SeguridadData();

                pUsuarioPasswordReset.clvPasswordEncrypt = HelpCrypto.SimetricoEncryptar(clvPasswordEncrypt,
                                                                                         WebConstants.DEFAULT_SeguridadKey);
                string pMessage = string.Empty;
                oReturn.Exitosa = objSeguridadDataNx.UpdateUserIndPasswordReset(pUsuarioPasswordReset, out pMessage);
                oReturn.Message = oReturn.Exitosa ? HelpMessages.Evento_EDIT : string.Empty;

                if (oReturn.Exitosa)
                {
                    BEUsuario pUsuario = new UsuarioData().Find(pUsuarioPasswordReset.codUsuario);
                    pUsuario.clvPassword = clvPasswordEncrypt;
                    string pMessageMail = string.Empty;

                    EnviarCorreo(pUsuario,
                                 pUsuarioPasswordReset.codEmpresa,
                                 pUsuarioPasswordReset.segUsuarioEdita,
                                 pUsuarioPasswordReset.urlWebSistema,
                                 "Solicitud de cambio de contraseña.",
                                 out pMessageMail);

                    oReturn.Message = string.Concat(oReturn.Message, " ", pMessageMail);
                    if (!string.IsNullOrEmpty(pMessageMail))
                        oReturn.Exitosa = false;
                }
                else
                    oReturn.Message = pMessage;

                return OK(oReturn);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pUsuarioPasswordReset.segUsuarioEdita,
                             pUsuarioPasswordReset.codEmpresa);
            }
        }


        public OperationResult UpdateUserfecBloqueo(BEUsuarioFecBloqueoRequest pUsuarioFecBloqueo)
        {
            SeguridadData objSeguridadDataNx = null;
            ReturnValor oReturn = new ReturnValor();
            try
            {
                string clvPasswordEncrypt = HelpCrypto.GenerarContrasenia(8);

                objSeguridadDataNx = new SeguridadData();

                string pMessage = string.Empty;
                oReturn.Exitosa = objSeguridadDataNx.UpdateUserfecBloqueo(pUsuarioFecBloqueo, out pMessage);
                oReturn.Message = oReturn.Exitosa ? HelpMessages.Evento_EDIT : string.Empty;

                if (!oReturn.Exitosa)
                {
                    oReturn.Message = pMessage;
                }

                return OK(oReturn);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pUsuarioFecBloqueo.segUsuarioEdita,
                             pUsuarioFecBloqueo.codEmpresa);
            }
        }


        public OperationResult UpdateUserPassword(BEUsuarioPasswordRequest pUsuarioPassword, bool pEnviaMail)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {

                    string pMessage = string.Empty;
                    pUsuarioPassword.clvPasswordEncrypt = HelpCrypto.SISEncriptarTexto(pUsuarioPassword.clvPassword);
                    oReturn.Exitosa = oSeguridadData.UpdatePasswordExterno(pUsuarioPassword, out pMessage);
                    
                    oReturn.Message = pMessage;

                    if (oReturn.Exitosa)
                    {

                        BEUsuario pUsuario = oSeguridadData.FindLogin(pUsuarioPassword.desLogin);

                        oReturn.Message = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2021).Value;
                        oReturn.codRetorno = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2021).Key;
                        oReturn.CodigoRetorno = oReturn.codRetorno.ToString();
                        oReturn.ErrorCode = TypeError.OK.ToString();

                        if (pEnviaMail)
                        {

                            string pMessageMail = string.Empty;
                            EnviarCorreo(pUsuario,
                                         pUsuarioPassword.codEmpresa,
                                         pUsuarioPassword.segUsuarioEdita,
                                         string.Empty,
                                         "Contraseña de usuario actualizada",
                                         out pMessageMail);

                            oReturn.Message = string.Concat(oReturn.Message, " ", pMessageMail);
                            if (!string.IsNullOrEmpty(pMessageMail))
                                oReturn.Exitosa = false;
                        }

                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
                throw new Exception(returnValor.Message);
            }
            return OK(oReturn);
        }


        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pUsuario"></param>
        public ReturnValor InsertUserFree(BEUsuarioFreeRequest usuarioRequest)
        {
            try
            {
                BEUsuarioRequest pUsuario = PasarDatosUsuario(usuarioRequest);

                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    string pMessage = string.Empty;

                    pUsuario.clvPasswordEncrypt = HelpCrypto.SISEncriptarTexto(pUsuario.clvPassword);

                    using (UsuarioData usuarioData = new UsuarioData())
                    {
                        oReturn.CodigoRetorno = usuarioData.InsertExt(pUsuario, out pMessage);
                    }
                    if (!string.IsNullOrEmpty(oReturn.CodigoRetorno))
                    {
                        oReturn.Exitosa = true;
                        oReturn.Message = HelpMessages.Evento_NEW;
                        tx.Complete();
                    }
                    else
                    {
                        oReturn.Message = pMessage;
                    }
                }
                if (oReturn.Exitosa)
                {
                    using(UsuarioLogic userLogic = new UsuarioLogic())
                    {
                        userLogic.EnviarCorreo(pUsuario);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                if (!oReturn.Exitosa)
                {
                    oReturn = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                              usuarioRequest.desLogin);
                }
                else
                {
                    HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                usuarioRequest.desLogin);
                    oReturn.Message = string.Concat(oReturn.Message, ". No se envió correo electrónico al usuario.");
                }
            }
            return oReturn;
        }

        private BEUsuarioRequest PasarDatosUsuario(BEUsuarioFreeRequest usuarioRequest)
        {
            BEUsuarioRequest usuario = new BEUsuarioRequest
            {
                desLogin = usuarioRequest.desLogin,
                desApellidos = usuarioRequest.desApellidos,
                desNombres = usuarioRequest.desNombres,
                desCorreo = usuarioRequest.desCorreo,
                desTelefono = usuarioRequest.desTelefono,
                clvPassword = usuarioRequest.clvPassword,
                codRolDefecto = usuarioRequest.codRolDefecto,
                codSistemaKey = usuarioRequest.codSistemaKey,
                indOrigenUser = usuarioRequest.indOrigenUser,
                urlPhotoUser = usuarioRequest.urlPhotoUser,
                codGUID = usuarioRequest.codGUID,
                segUsuarioEdita = usuarioRequest.desLogin,
                segMaquinaEdita = usuarioRequest.segMaquinaEdita,

                indRestricPorPais = false,
                desPregunta = "-",
                desRespuesta = "-",
                indVendedor = false,
                indEstado = true,
                indUsuarioSistema = false,
                indAccesoGerencial = false,
                indCambiaCodPersona = false,
                indCambioPrecio = false,
                indCambiaDescuento = false,
                indJefeCaja = false,

            };

            usuario.clvPassword = string.IsNullOrEmpty(usuario.clvPassword) ?
                                    HelpCrypto.GenerarContrasenia(8) :
                                    usuario.clvPassword;

            usuario.codArguPais = WebConstants.PAIS_ORIGEN;

            return usuario;
        }

        #endregion

        public bool UpdatePassword(BEUsuarioPasswordRequest pUsuarioPassword, bool pEnviaMail, int pCodEmpresa = 0)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {

                    pUsuarioPassword.clvPasswordEncrypt = HelpCrypto.SISEncriptarTexto(pUsuarioPassword.clvPassword);
                    string pMessage = string.Empty;
                    oReturn.Exitosa = oSeguridadData.UpdatePasswordExterno(pUsuarioPassword, out pMessage);

                    oReturn.Message = pMessage;

                    if (oReturn.Exitosa)
                    {
                        oReturn.Message = HelpMessages.Evento_EDIT;

                        if (pEnviaMail)
                        {
                            string pMessageMail = string.Empty;

                            BEUsuario usuarioCorreo = FindLogin(pUsuarioPassword.desLogin);
                            EnviarCorreo(usuarioCorreo,
                                         pCodEmpresa,
                                         pUsuarioPassword.segUsuarioEdita,
                                         string.Empty,
                                        "Contraseña de usuario actualizada.",
                                         out pMessageMail);
                            oReturn.Message = string.Concat(oReturn.Message, " ", pMessageMail);

                            if (!string.IsNullOrEmpty(pMessageMail))
                                oReturn.Exitosa = false;
                        }

                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
                throw new Exception(returnValor.Message);
            }
            return oReturn.Exitosa;
        }

        public BEUsuarioAux FindLogin(string prm_LoginUsuario)
        {
            BEUsuarioAux itemUsuario = new BEUsuarioAux();
            try
            {
                itemUsuario = oSeguridadData.FindLogin(prm_LoginUsuario);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, prm_LoginUsuario);
                throw new Exception(returnValor.Message);
            }
            return itemUsuario;

        }


        /// <summary>
        /// Metodo                  :InsertarAuditoria 
        /// Propósito               :Permite insertar datos de auditoria al momento de loguear usuario
        /// Retorno                 :N/A
        /// Notas                   :N/A
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :04/10/2012
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="objUsuario"></param>
        /// <returns objReturnaValor></returns>
        public int InsertAuditoria(BEAuditoria objAuditoria)
        {
            SeguridadData objSeguridadDataNx = null;
            int numVeces = 0;
            try
            {
                objSeguridadDataNx = new SeguridadData();
                numVeces = objSeguridadDataNx.InsertarAuditoria(objAuditoria);
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat(this.GetType().Name, ".", MethodBase.GetCurrentMethod().Name), ex, objAuditoria.desLogin);
                numVeces = -1;
            }
            finally
            {
                if (objSeguridadDataNx != null)
                {
                    objSeguridadDataNx.Dispose();
                    objSeguridadDataNx = null;
                }
            }
            return numVeces;
        }

        #region METODOS PRIVADOS

        private OperationResult ValidarDataAccesoUsuario(string pdesLogin, string pclvContrasenia)
        {
            var operationResult = new OperationResult();
            operationResult.isValid = false;
            if (string.IsNullOrEmpty(pdesLogin) && string.IsNullOrEmpty(pclvContrasenia))
            {
                operationResult.brokenRulesCollection.Add(new BrokenRule
                {
                    description = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2005).Value,
                    severity = RuleSeverity.Warning
                });
                return operationResult;
            }
            if (string.IsNullOrEmpty(pdesLogin))
            {
                operationResult.brokenRulesCollection.Add(new BrokenRule
                {
                    description = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2002).Value,
                    severity = RuleSeverity.Warning
                });
            }
            if (string.IsNullOrEmpty(pclvContrasenia))
            {
                operationResult.brokenRulesCollection.Add(new BrokenRule
                {
                    description = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2003).Value,
                    severity = RuleSeverity.Warning
                });
            }

            return operationResult;
        }

        private OperationResult ValidarAccesoUsuarioSistemaEmpresa(BEUsuarioValidoResponse objUsuarioValidado, string pKeySistema)
        {
            var operationResult = new OperationResult();
            operationResult.isValid = false;
            if (string.IsNullOrEmpty(objUsuarioValidado.codEmpresaNombre) && objUsuarioValidado.codEmpleado != "EXT")
            {
                operationResult.brokenRulesCollection.Add(new BrokenRule
                {
                    description = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2006).Value,
                    severity = RuleSeverity.Warning
                });
                return operationResult;
            }
            else if (string.IsNullOrEmpty(objUsuarioValidado.codSistemaNombre))
            {
                operationResult.brokenRulesCollection.Add(new BrokenRule
                {
                    description = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2007).Value,
                    severity = RuleSeverity.Warning
                });
                return operationResult;
            }
            else if (string.IsNullOrEmpty(objUsuarioValidado.codRolNombre))
            {
                operationResult.brokenRulesCollection.Add(new BrokenRule
                {
                    description = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2008).Value,
                    severity = RuleSeverity.Warning
                });
                return operationResult;
            }

            //Validar si esta asignado a una empresa
            //365A01B7-6C8E-460E-90F4-29C52D6CADD7|1|Sistema SIS|10181980325, 
            //0E48ADC1-21B7-465B-858E-F3A3C608CEB1|2|Sistema GC|10181980327
            bool blnEmpresaEsValido = false;
            string strEmpresa = string.Empty;
            string strnumRUC = string.Empty;
            DateTime? fecLicenciaVenc = null;
            int numCodigoError = 0;
            if (objUsuarioValidado.codEmpleado != "EXT")
            {

                //HelpLogging.Write(TraceLevel.Warning, string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                //                  objUsuarioValidado.codEmpresaNombre, 
                //                  string.Format("Empresa:[{0}], Usuario:[{1}]", "00", objUsuarioValidado.desLogin));

                string[] arrEmpresas = objUsuarioValidado.codEmpresaNombre.Split(',');
                foreach (string itemEmpresa in arrEmpresas)
                {
                    string[] arrDatoEmpresa = itemEmpresa.Split('|');

                    //HelpLogging.Write(TraceLevel.Info, string.Concat(GetType().Name,".", MethodBase.GetCurrentMethod().Name),
                    //              string.Format("arrDatoEmpresa[{0}].Trim() == pKeySistema({1})", arrDatoEmpresa[0].Trim(), pKeySistema),
                    //              string.Format("Empresa:[{0}], Usuario:[{1}]", "00", objUsuarioValidado.desLogin));

                    if (arrDatoEmpresa[0].Trim() == pKeySistema)
                    {
                        //HelpLogging.Write(TraceLevel.Info, string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                        //          string.Format("ConvertYYYYMMDDToDate:[ {0} ] == DateTime.Now=[ {1} ]", HelpTime.ConvertYYYYMMDDToDate(arrDatoEmpresa[1].Trim()), 
                        //                                                                                 DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud())),
                        //          string.Format("Empresa:[{0}], Usuario:[{1}]", "00", objUsuarioValidado.desLogin));

                        if (HelpTime.ConvertYYYYMMDDToDate(arrDatoEmpresa[1].Trim()) > DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()))
                        {
                            blnEmpresaEsValido = true;
                            numCodigoError = 0;
                            fecLicenciaVenc = HelpTime.ConvertYYYYMMDDToDate(arrDatoEmpresa[1].Trim());
                            objUsuarioValidado.codEmpresa = Extensors.CheckInt(arrDatoEmpresa[2]);
                            strEmpresa = arrDatoEmpresa[3].Trim();
                            strnumRUC = arrDatoEmpresa[4].Trim();
                            break;
                        }
                        else
                        {
                            numCodigoError = 2011;
                            strEmpresa = arrDatoEmpresa[3].Trim();
                            fecLicenciaVenc = HelpTime.ConvertYYYYMMDDToDate(arrDatoEmpresa[1].Trim());
                            //HelpLogging.Write(TraceLevel.Warning, string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                            //      string.Format("numCodigoError:[ {0} ] == DateTime.Now=[ {1} ], Message={2}", numCodigoError, 
                            //      DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()),
                            //      string.Format(WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == numCodigoError).Value,
                            //                             strEmpresa, fecLicenciaVenc.Value.ToShortDateString())),
                            //string.Format("Empresa:[{0}], Usuario:[{1}]", "00", objUsuarioValidado.desLogin));
                            break;
                        }

                    }
                    else
                    {
                        numCodigoError = 2010;
                        //HelpLogging.Write(TraceLevel.Warning, string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                        //          string.Format("numCodigoError:[ {0} ] == DateTime.Now=[ {1} ], Message={2}", numCodigoError, 
                        //          DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()),
                        //          string.Format(WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == numCodigoError).Value,
                        //                                 strEmpresa, fecLicenciaVenc.Value.ToShortDateString())),
                        //          string.Format("Empresa:[{0}], Usuario:[{1}]", "00", objUsuarioValidado.desLogin));

                    }
                }

                if (!blnEmpresaEsValido)
                {
                    if (numCodigoError == 2011)
                    {
                        operationResult.brokenRulesCollection.Add(new BrokenRule
                        {
                            description = string.Format(WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == numCodigoError).Value,
                                                         strEmpresa, fecLicenciaVenc.Value.ToShortDateString()),
                            severity = RuleSeverity.Warning
                        });
                    }
                    else
                    {
                        operationResult.brokenRulesCollection.Add(new BrokenRule
                        {
                            description = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == numCodigoError).Value,
                            severity = RuleSeverity.Warning
                        });
                    }

                    HelpLogging.Write(TraceLevel.Warning, string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                                  string.Format("numCodigoError:[ {0} ] == DateTime.Now=[ {1} ], Message={2}", numCodigoError,
                                  DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()),
                                 operationResult.brokenRulesCollection[0].description),
                                   string.Format("Empresa:[{0}], Usuario:[{1}]", "00", objUsuarioValidado.desLogin));

                    return operationResult;
                }
                if (DateTime.Now > fecLicenciaVenc.Value.AddDays(-30))
                    objUsuarioValidado.codEmpresaNombre = string.Concat( strEmpresa, " - Vence: ", fecLicenciaVenc.Value.FormatDateToDDMMYYYY());
                else
                    objUsuarioValidado.codEmpresaNombre = strEmpresa;
                objUsuarioValidado.numRUC = strnumRUC;
            }

            //Validar si esta asignado al sistema
            //365A01B7-6C8E-460E-90F4-29C52D6CADD7|1|Sistema SIS, 
            //0E48ADC1-21B7-465B-858E-F3A3C608CEB1|2|Sistema GC
            bool blnSistemaEsValido = false;
            string strSistema = string.Empty;

            string[] arrSistemas = objUsuarioValidado.codSistemaNombre.Split(',');
            foreach (string itemSistema in arrSistemas)
            {
                string[] strValoresSistema = itemSistema.Split('|');
                if (strValoresSistema[0].Trim() == pKeySistema)
                {
                    strSistema = strValoresSistema[2].Trim();
                    objUsuarioValidado.codSistema = strValoresSistema[1].Trim();
                    blnSistemaEsValido = true;
                    break;
                }
            }
            if (!blnSistemaEsValido)
            {
                operationResult.brokenRulesCollection.Add(new BrokenRule
                {
                    description = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2009).Value,
                    severity = RuleSeverity.Warning
                });
                return operationResult;
            }
            objUsuarioValidado.codSistemaNombre = strSistema;
            //Validar si esta asignado a un rol
            //365A01B7-6C8E-460E-90F4-29C52D6CADD7|1|Administrador, 
            //0E48ADC1-21B7-465B-858E-F3A3C608CEB1|15|Administrador
            bool blnUsuarioEsValido = false;
            string strRol = string.Empty;
            string[] arrRolesUsuario = objUsuarioValidado.codRolNombre.Split(',');
            foreach (string itemRolesUsuario in arrRolesUsuario)
            {
                string[] strValoresRolesUsuario = itemRolesUsuario.Split('|');
                if (strValoresRolesUsuario[0].Trim() == pKeySistema)
                {
                    strRol = strValoresRolesUsuario[2].Trim();
                    objUsuarioValidado.codRol = strValoresRolesUsuario[1].Trim();
                    blnUsuarioEsValido = true;
                    break;
                }
            }
            if (!blnUsuarioEsValido)
            {
                operationResult.brokenRulesCollection.Add(new BrokenRule
                {
                    description = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2012).Value,
                    severity = RuleSeverity.Warning
                });
                return operationResult;
            }

            objUsuarioValidado.codRolNombre = strRol;
            operationResult.isValid = true;
            return operationResult;
        }

        private void EnviarCorreo(BEUsuario pUsuario, int pcodEmpresa, string pUserLogin, string urlWebSistema, string pTitulo, out string pMessage)
        {
            pMessage = string.Empty;
            List<HelpMailDatos> Lista = new List<HelpMailDatos>();
            Lista.Add(new HelpMailDatos { titulo = "Nombres", descripcion = pUsuario.desNombres });
            Lista.Add(new HelpMailDatos { titulo = "Apellidos", descripcion = pUsuario.desApellidos });
            Lista.Add(new HelpMailDatos { titulo = "Usuario", descripcion = pUsuario.desLogin });
            Lista.Add(new HelpMailDatos { titulo = "Contraseña", descripcion = pUsuario.clvPassword });

            Lista.Add(new HelpMailDatos { titulo = "Correo electrónico", descripcion = pUsuario.desCorreo });
            Lista.Add(new HelpMailDatos { titulo = "Teléfono", descripcion = pUsuario.desTelefono });
            Lista.Add(new HelpMailDatos { titulo = "URL de sistema", descripcion = urlWebSistema });

            //string lsNota = "<b>Nota : Se ha modificado su cuenta de usuario, la contraseña se generó de forma aleatoria se recomienda ingresar al sistema y modificarlo.</b>";

            string lsNota = "<b> Nota : La nueva contraseña se generó de forma aleatoria se recomienda ingresar al sistema y modificarlo. </b>";
            lsNota = lsNota + "<div style='font-style:oblique; text-align: center;'> Este correo electrónico fue enviado desde una dirección de correo de notificación, la cual no recepcionará correos de respuesta. Agradeceremos no responder a este mensaje.</div>";

            //"Servicio de envío de contraseña"
            string lsBody = HelpMail.CrearCuerpo(pTitulo, Lista, lsNota, "Empresa");
            List<string> lstCorreos = new List<string>();
            lstCorreos.Add(pUsuario.desCorreo);

            try
            {
                HelpMail.Enviar("Envío de Usuario - Contraseña", lsBody, lstCorreos, false, null, null);
            }
            catch (Exception ex)
            {
                HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                            pUserLogin, pcodEmpresa.ToString());
                pMessage = WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2024).Value;
            }

        }

        #endregion

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
namespace CROM.Seguridad.Login
{
    using CROM.GC.Services.Interfaces.seguridad;
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.acceso;
    using CROM.Seguridad.BussinesLogic;
    using CROM.Tools.Comun.security;

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class  Accesos
    {
        #region IAccess Members

        public BEUsuarioValidoResponse DetectLoginPasswordValid(string pdesLogin, string pPassword, string pKeySistema, string pNumIP)
        {
            BEUsuarioValidoResponse objUsuarioValidado = null;
            try
            {
                var operationResult  = (new SeguridadLogic()).ValidarUsuario(pdesLogin, pPassword, pKeySistema, pNumIP);
                if (operationResult.isValid)
                {
                    objUsuarioValidado = JsonConvert.DeserializeObject<BEUsuarioValidoResponse>(operationResult.data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objUsuarioValidado;
        }

        public List<BEUsuarioPermisoResponse> ListUserObjectsGrants(int pcodEmpresa,string pcodSistema, string pdesLogin, string ptipoObjeto, string pnomAction)
        {
            List<BEUsuarioPermisoResponse> lstUsuarioPermiso = new List<BEUsuarioPermisoResponse>();
            try
            {
                BEUsuarioPermisoRequest pUsuarioPermiso = new BEUsuarioPermisoRequest
                {
                    codSistema = pcodSistema,
                    desLogin = pdesLogin,
                    nomAction = pnomAction,
                    tipoObjeto = ptipoObjeto,
                    codEmpresa = pcodEmpresa
                };
                var operationResult = (new SeguridadLogic()).ListUserObjectsGrants(pUsuarioPermiso);
                if (operationResult.isValid)
                {
                    lstUsuarioPermiso = JsonConvert.DeserializeObject<List<BEUsuarioPermisoResponse>>(operationResult.data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstUsuarioPermiso;
        }

        public BEUsuarioValidoResponse DetectLoginPasswordValidWSAPI(string pdesLogin, string pPassword)
        {
            BEUsuarioValidoResponse usuarioValidado = null;
            try
            {
                BELoginModel plogin = new BELoginModel
                {
                    Contrasenia = pPassword,
                    Usuario = pdesLogin,

                };

                usuarioValidado = ApiServiceSeguridad.ValidarInicioSesion(plogin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usuarioValidado;
        }

        public BEUsuarioAux UserRolOptions(string prm_LoginUsuario, string prm_CodigoRol, string prm_CodigoSistema)
        {
            BEUsuarioAux itemUsuario = new BEUsuarioAux();

            try
            {
                SeguridadLogic oSeguridadLogic = new SeguridadLogic();
                itemUsuario = oSeguridadLogic.FindLogin(prm_LoginUsuario);
                if (prm_CodigoRol.Length > 0)
                {
                    RolOpcionLogic oRolOpcionLogic = new RolOpcionLogic();
                    itemUsuario.listaRolOpcion = oRolOpcionLogic.List(prm_CodigoSistema, prm_CodigoRol);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemUsuario;
        }

        //public List<BEUsuarioAux> ListarUsuarios(bool prmEstado)
        //{
        //    List<BEUsuarioAux> listaUsuario = new List<BEUsuarioAux>();
        //    try
        //    {
        //        UsuarioLogic oUsuariosLogic = new UsuarioLogic();
        //        listaUsuario = oUsuariosLogic.List(string.Empty, string.Empty, string.Empty, prmEstado);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return listaUsuario;
        //}

        public BESistema FindSystem(string prm_CodigoSistema)
        {
            BESistema itemSistema = new BESistema();
            try
            {
                itemSistema = (new SistemaLogic()).Find(prm_CodigoSistema);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemSistema;
        }

        public bool DetectLoginPasswordExterno(string prm_LoginUsuario, string prm_Password, out string pMessage)
        {
            bool Validado = false;
            pMessage = string.Empty;
            try
            {
                
                Validado = (new SeguridadLogic()).DetectLoginPasswordExterno(prm_LoginUsuario, prm_Password, out pMessage);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Validado;
        }

        public bool UpdatePassword(string pLoginUsuario, string pNuevoPassword, bool pEnviaMail, 
                                   string pMaquinaIP, string pSegUsuarioEdita)
        {
            BEUsuarioPasswordRequest oUsuarioPassword = new BEUsuarioPasswordRequest();
            bool RESULTADO;
            try
            {
                oUsuarioPassword.desLogin = pLoginUsuario;
                oUsuarioPassword.clvPassword = pNuevoPassword;
                oUsuarioPassword.segUsuarioEdita = pSegUsuarioEdita;
                oUsuarioPassword.segMaquinaEdita = pMaquinaIP;
                RESULTADO = (new SeguridadLogic().UpdatePassword(oUsuarioPassword, pEnviaMail));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RESULTADO;
        }

        public bool UpdatePasswordRec(string pLoginUsuario, string pNuevoPassword, bool pEnviaMail, 
                                      string pSegMaquinaIP, string pSegUsuarioEdita)
        {
            BEUsuario oUsuarios = new BEUsuario();
            bool RESULTADO = false;
            try
            {
                oUsuarios = (new SeguridadLogic()).FindLogin(pLoginUsuario);
                if (oUsuarios != null)
                {

                    BEUsuarioPasswordRequest pUsuarioPassword = new BEUsuarioPasswordRequest
                    {
                        clvPassword = pNuevoPassword,
                        segMaquinaEdita = pSegMaquinaIP,
                        segUsuarioEdita = pSegUsuarioEdita
                    };
                    RESULTADO = (new SeguridadLogic().UpdatePassword(pUsuarioPassword, pEnviaMail));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RESULTADO;
        }

        #region /* Proceso de INSERT RECORD  AUDITORIA */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo AUDITORIA
        /// En la BASE de DATO la Tabla : [Seguridad.UsuarioIngreso]
        /// </summary>
        /// <param name="itemUsuarioIngreso">Entidad de UsuarioIngreso</param>
        /// <returns>Valor boolean True=ok, y false=no OK</returns>
        public bool InsertAuditoria(BEAuditoria itemUsuarioIngreso)
        {
            int RESULTADO;
            try
            {
                RESULTADO = new SeguridadLogic().InsertAuditoria(itemUsuarioIngreso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RESULTADO > 0;
        }

        #endregion

        #endregion

        #region CODIGO DEPRECADO

        //#region /* Proceso de SELECT ALL */

        ///// <summary>
        ///// Retorna un LISTA de registros de la Entidad Seguridad.UsuarioIngreso
        ///// En la BASE de DATO la Tabla : [Seguridad.UsuarioIngreso]
        ///// </summary>
        ///// <param name="p_codUsuario">Código de usuario del sistema</param>
        ///// <param name="p_codSistema">Código del sistema a consultar</param>
        ///// <param name="p_codRol">Código de rol a consultar</param>
        ///// <param name="p_fecInicio">Parametro de fecha de inicio a consultar</param>
        ///// <param name="p_fecFinal">Parametro de fecha de fin a consultar</param>
        ///// <returns>Lista o colección de la entidad UsuarioIngreso</returns>
        //public object ListAuditoriaPage(BEAuditoriaRequest pFiltro)
        //{
        //    List<BEAuditoriaResponse> lstAuditorias = new List<BEAuditoriaResponse>();
        //    try
        //    {
        //       var lstResult = new SeguridadLogic().ListAuditoriaPage(pFiltro);
        //        if(lstResult.isValid)
        //            lstAuditorias = JsonConvert.DeserializeObject<object>(lstResult.data);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstAuditorias;
        //}

        //#endregion

        //public List<BERolAux> ListRolesUser(string prm_LoginUsuario, string prm_CodigoSistema)
        //{
        //    List<BERolAux> lstUsuario = new List<BERolAux>();
        //    try
        //    {
        //        lstUsuario = (new SeguridadLogic()).ListRolesUser(prm_LoginUsuario, prm_CodigoSistema);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstUsuario;
        //}


        //public List<BERolAux> ListRol(string prm_CodigoSistema)
        //{
        //    List<BERolAux> lstRol = new List<BERolAux>();
        //    try
        //    {
        //        lstRol = (new RolLogic()).List(string.Empty, prm_CodigoSistema, string.Empty, true);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstRol;
        //}


        #endregion
    }
}

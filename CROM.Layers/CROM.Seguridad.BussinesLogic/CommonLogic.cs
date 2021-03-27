namespace CROM.Seguridad.BussinesLogic
{
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Seguridad.DataAcces;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Metodo                  :Dispose 
    /// Propósito               :Permite Liberar de la memoria al objeto instanciado
    /// Retorno                 :Colección o lista de objetos de la entidad
    /// Autor                   :OCR - Orlando Carril R.
    /// Fecha/Hora de Creación  :17/08/2015
    /// Modificado              :N/A
    /// Fecha/Hora Modificación :N/A
    /// </summary>
    public class CommonLogic : BaseLayer
    {

        public CommonLogic()
        {

        }

        public OperationResult GetComboSistema()
        {
            CommonData objCommonData = null;
            IEnumerable<ComboListItemString> lstSistema = null;
            try
            {
                objCommonData = new CommonData();
                lstSistema = objCommonData.GetComboSistemas();
                return OK(lstSistema);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, "", "");
            }
        }

        public OperationResult GetComboRol(string pcodSistema)
        {
            CommonData objCommonData = null;
            IEnumerable<ComboListItemString> lstRoles = null;
            try
            {
                objCommonData = new CommonData();
                lstRoles = objCommonData.GetComboRoles(pcodSistema);
                return OK(lstRoles);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, "", "");
            }
        }

        public OperationResult GetComboUsuarioPorSistema(int pcodEmpresa)
        {
            CommonData objCommonData = null;
            IEnumerable<ComboListItemString> lstUsuarios = null;
            try
            {
                objCommonData = new CommonData();
                lstUsuarios = objCommonData.GetComboUsuarioPorEmpresa(pcodEmpresa);
                return OK(lstUsuarios);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, "", "");
            }
        }

        public OperationResult GetComboUsuario(BEBuscaUsuarioRequest pFiltro)
        {
            UsuarioData objCommonData = null;
            List<ComboListItemString> lstUsuarios = new List<ComboListItemString>();
            try
            {
                objCommonData = new UsuarioData();
                var resultData = objCommonData.List(pFiltro);
                resultData.ForEach(x =>
                {
                    var itemCombo = new ComboListItemString();
                    itemCombo.value = x.codUsuario;
                    itemCombo.text = string.Concat("[ ", x.desLogin.ToUpper()," ]", x.desApellidos, ", ", x.desNombres);

                    lstUsuarios.Add(itemCombo);
                });
                 
                return OK(lstUsuarios);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, "", "");
            }
        }

        public OperationResult GetComboOpcion(string pcodSistema, string pindTipoObjeto)
        {
            CommonData objCommonData = null;
            IEnumerable<ComboListItemString> lstOpciones = null;
            try
            {
                objCommonData = new CommonData();
                lstOpciones = objCommonData.GetComboOpciones(pcodSistema, pindTipoObjeto);
                return OK(lstOpciones);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, "", "");
            }
        }

        public OperationResult GetComboEmpresa()
        {
            CommonData objCommonData = null;
            IEnumerable<ComboListItemString> lstEmpresa = null;
            try
            {
                objCommonData = new CommonData();
                lstEmpresa = objCommonData.GetComboEmpresas();
                return OK(lstEmpresa);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, "", "");
            }
        }

        public OperationResult GetComboSistemaPorEmpresa(int pcodEmpresa)
        {
            CommonData objCommonData = null;
            IEnumerable<ComboListItemString> lstSistema = null;
            try
            {
                objCommonData = new CommonData();
                lstSistema = objCommonData.GetComboSistemasPorEmpresa(pcodEmpresa);
                return OK(lstSistema);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, "", "");
            }
        }

        public IEnumerable<ComboListItemString> GetComboSistemas()
        {
            CommonData objCommonData = null;
            IEnumerable<ComboListItemString> lstSistema = null;
            try
            {
                objCommonData = new CommonData();
                lstSistema = objCommonData.GetComboSistemas();
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
                throw new Exception(returnValor.Message);
            }
            finally
            {
                if (lstSistema == null)
                {
                    lstSistema = new  List<ComboListItemString>();
                }
            }
            return lstSistema;


        }

        public IEnumerable<ComboListItemString> GetComboRoles(string pcodSistema)
        {
            CommonData objCommonData = null;
            IEnumerable<ComboListItemString> lstRol = null;
            try
            {
                objCommonData = new CommonData();
                lstRol = objCommonData.GetComboRoles(pcodSistema);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
                throw new Exception(returnValor.Message);
            }
            finally
            {
                if (lstRol == null)
                {
                    lstRol = new List<ComboListItemString>();
                }
            }
            return lstRol;


        }

        //public IEnumerable<ComboListItemString> GetComboUsuariosPorSistema(string pcodSistema)
        //{
        //    CommonData objCommonData = null;
        //    IEnumerable<ComboListItemString> lstUsuario = null;
        //    try
        //    {
        //        objCommonData = new CommonData();
        //        lstUsuario = objCommonData.GetComboUsuarioPorSistema(pcodSistema);
        //    }
        //    catch (Exception ex)
        //    {
        //        var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
        //        throw new Exception(returnValor.Message);
        //    }
        //    finally
        //    {
        //        if (lstUsuario == null)
        //        {
        //            lstUsuario = new List<ComboListItemString>();
        //        }
        //    }
        //    return lstUsuario;


        //}

        //public IEnumerable<ComboListItemString> GetComboUsuarios(BEBuscaUsuarioRequest pFiltro)
        //{
        //    CommonData objCommonData = null;
        //    IEnumerable<ComboListItemString> lstUsuario = null;
        //    try
        //    {
        //        objCommonData = new CommonData();
        //        lstUsuario = objCommonData.GetComboUsuarios();
        //    }
        //    catch (Exception ex)
        //    {
        //        var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
        //        throw new Exception(returnValor.Message);
        //    }
        //    finally
        //    {
        //        if (lstUsuario == null)
        //        {
        //            lstUsuario = new List<ComboListItemString>();
        //        }
        //    }
        //    return lstUsuario;


        //}

        public IEnumerable<ComboListItemString> GetComboOpciones(string pcodSistema, string pindTipoObjeto)
        {
            CommonData objCommonData = null;
            IEnumerable<ComboListItemString> lstOpciones = null;
            try
            {
                objCommonData = new CommonData();
                lstOpciones = objCommonData.GetComboOpciones(pcodSistema, pindTipoObjeto);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
                throw new Exception(returnValor.Message);
            }
            finally
            {
                if (lstOpciones == null)
                {
                    lstOpciones = new List<ComboListItemString>();
                }
            }
            return lstOpciones;


        }

        public IEnumerable<ComboListItemString> GetComboEmpresas()
        {
            CommonData objCommonData = null;
            IEnumerable<ComboListItemString> lstOpciones = null;
            try
            {
                objCommonData = new CommonData();
                lstOpciones = objCommonData.GetComboEmpresas();
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
                throw new Exception(returnValor.Message);
            }
            finally
            {
                if (lstOpciones == null)
                {
                    lstOpciones = new List<ComboListItemString>();
                }
            }
            return lstOpciones;


        }

        public IEnumerable<ComboListItemString> GetComboSistemasPorEmpresa(int pcodEmpresa)
        {
            CommonData objCommonData = null;
            IEnumerable<ComboListItemString> lstSistema = null;
            try
            {
                objCommonData = new CommonData();
                lstSistema = objCommonData.GetComboSistemasPorEmpresa(pcodEmpresa);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
                throw new Exception(returnValor.Message);
            }
            finally
            {
                if (lstSistema == null)
                {
                    lstSistema = new List<ComboListItemString>();
                }
            }
            return lstSistema;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

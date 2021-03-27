namespace CROM.Seguridad.BussinesLogic
{
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Seguridad.BussinesEntities.entidades.request;
    using CROM.Seguridad.BussinesEntities.entidades.response;
    using CROM.Seguridad.DataAcces;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.Web;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Transactions;

    /// <summary>
    /// Proyecto    : Seguridad del Sistema
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 08/11/2009
    /// Descripcion : Clase para capa LOGICA
    /// Archivo     : UsuarioLogic.cs
    /// </summary
    public class UsuarioLogic : BaseLayer, IDisposable
    {
        private UsuarioData oUsuarioData = null;
        private ReturnValor oReturn = null;

        public UsuarioLogic()
        {
            oUsuarioData = new UsuarioData();
            oReturn = new ReturnValor();
        }

        #region ---- Proceso de Insertar ----

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pUsuario"></param>
        public ReturnValor Insert(BEUsuarioRequest pUsuario)
        {
            try
            {
                pUsuario.clvPassword = HelpCrypto.GenerarContrasenia(8);
                pUsuario.codArguPais = WebConstants.PAIS_ORIGEN;
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    string pMessage = string.Empty;
                    //if (GlobalSettings.GetDEFAULT_Encriptacion() == WebConstants.TipoEncriptacion.SQLDLL.ToString())
                    //    oReturn.CodigoRetorno = oUsuarioData.Insert(pUsuario, out pMessage);

                    //else if (GlobalSettings.GetDEFAULT_Encriptacion() == WebConstants.TipoEncriptacion.EXTDLL.ToString())
                    //{
                        pUsuario.clvPasswordEncrypt = HelpCrypto.SimetricoEncryptar(pUsuario.clvPassword,
                                                                             WebConstants.DEFAULT_SeguridadKey);
                        oReturn.CodigoRetorno = oUsuarioData.InsertExt(pUsuario, out pMessage);
                    //}
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
                if(oReturn.Exitosa)
                {
                    EnviarCorreo(pUsuario);
                }
            }
            catch (Exception ex)
            {
                if (!oReturn.Exitosa)
                    oReturn = HelpException.mTraerMensaje(ex);
                else
                {
                    HelpException.mTraerMensaje(ex);
                    oReturn.Message = string.Concat(oReturn.Message, ". No se envió correo electrónico al usuario.");
                }
            }
            return oReturn;
        }

        public void EnviarCorreo(BEUsuarioRequest pUsuario)
        {
            List<HelpMailDatos> Lista = new List<HelpMailDatos>();
            Lista.Add(new HelpMailDatos { titulo = "Nombres", descripcion = pUsuario.desNombres });
            Lista.Add(new HelpMailDatos { titulo = "Apelidos", descripcion = pUsuario.desApellidos });
            Lista.Add(new HelpMailDatos { titulo = "Teléfono", descripcion = pUsuario.desTelefono });
            Lista.Add(new HelpMailDatos { titulo = "Correo", descripcion = pUsuario.desCorreo });
            Lista.Add(new HelpMailDatos { titulo = "Cueta login", descripcion = pUsuario.desLogin });
            Lista.Add(new HelpMailDatos { titulo = "Contraseña", descripcion = pUsuario.clvPassword });
            Lista.Add(new HelpMailDatos { titulo = "-", descripcion = "-" });
            Lista.Add(new HelpMailDatos { titulo = "Creado desde", descripcion = pUsuario.segMaquinaEdita });

            string lsNota = "<b> Nota : Se ha generado su contraseña. Se generó de forma aleatoria se recomienda ingresar al sistema y modificarlo. </b>";
            lsNota = lsNota + "<div style='font-style:oblique; text-align: center;'> Este correo electrónico fue enviado desde una dirección de correo de notificaciónes, la cual no recepcionará correos de respuesta. Agradeceremos no responder a este mensaje.</div>";

            string lsBody = HelpMail.CrearCuerpo("Envío de contraseña nueva", Lista, lsNota, "CROM SYSTEMS - SIS CROM");
            List<string> lstCorreos = new List<string>();
            lstCorreos.Add(pUsuario.desCorreo);
            HelpMail.Enviar("Envío de Contraseña - Usuario nuevo", lsBody, lstCorreos, false, null, null);
        }

        #endregion

        #region ---- Proceso de Actualizar ----

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pUsuario"></param>
        public ReturnValor Update(BEUsuarioRequest pUsuario)
        {
            try
            {
                pUsuario.codArguPais = WebConstants.PAIS_ORIGEN;
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oUsuarioData.Update(pUsuario);

                    //if (GlobalSettings.GetDEFAULT_Encriptacion() == WebConstants.TipoEncriptacion.SQLDLL.ToString())
                        //oReturn.Exitosa = oUsuarioData.Update(pUsuario);

                    //else if (GlobalSettings.GetDEFAULT_Encriptacion() == WebConstants.TipoEncriptacion.EXTDLL.ToString())
                    //{
                    //    //pUsuario.clvPassword = HelpCrypto.SimetricoEncryptar(pUsuario.clvPassword,
                    //    //                                                     WebConstants.DEFAULT_SeguridadKey);
                    //    oReturn.Exitosa = oUsuarioData.UpdateExterno(pUsuario);
                    //}

                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessages.Evento_EDIT;
                    }
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpException.mTraerMensaje(ex);
            }
            return oReturn;
        }

        #endregion

        #region ---- Proceso de Eliminar ----

        public ReturnValor Delete(string p_CodigoUsuario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oUsuarioData.Delete(p_CodigoUsuario);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessages.Evento_DELETE;
                    }
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpException.mTraerMensaje(ex);
            }
            return oReturn;
        }

        #endregion

        #region ---- Proceso de Encontrar ----

        /// <summary>
        /// Retorna un objeto de registros de tipo Opciones.
        /// </summary>
        /// <returns>Lista</returns>
        public BEUsuarioResponse Find(string pcodUsuario)
        {
            BEUsuarioResponse itemUsuario = new BEUsuarioResponse();
            try
            {
                itemUsuario = oUsuarioData.Find(pcodUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemUsuario;
        }

        #endregion

        #region ---- Proceso de Listar ----

        ///// <summary>
        ///// Retorna un coleccion de registros de tipo [Tabla].
        ///// <summary>
        ///// <returns>List</returns>
        //public List<BEUsuarioAux> List(string prm_LoginUsuario, string prm_Nombres, string prm_Apellidos, bool prm_Estado)
        //{
        //    List<BEUsuarioAux> lista = new List<BEUsuarioAux>();
        //    try
        //    {
        //        lista = oUsuarioData.List(prm_LoginUsuario, prm_Nombres, prm_Apellidos, prm_Estado);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lista;
        //}

        //public List<BEUsuarioAux> List(string prm_LoginUsuario, string prm_Nombres, string prm_Apellidos, bool prm_Estado, Helper.ComboBoxText pTexto)
        //{
        //    List<BEUsuarioAux> lista = new List<BEUsuarioAux>();
        //    try
        //    {
        //        lista = oUsuarioData.List(prm_LoginUsuario, prm_Nombres, prm_Apellidos, prm_Estado);
        //        if (lista.Count > 0)
        //            lista.Insert(0, new BEUsuarioAux { codUsuario = "", desApellidosNombres = Helper.ObtenerTexto(pTexto) });
        //        else
        //            lista.Add(new BEUsuarioAux { codUsuario = "", desApellidosNombres = Helper.ObtenerTexto(pTexto) });
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
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public OperationResult ListPaged(BEBuscaUsuarioRequest pFiltro)
        {
            List<DTOUsuarioResponse> lstUsuario = new List<DTOUsuarioResponse>();
            try
            {
                lstUsuario = oUsuarioData.ListPaged(pFiltro);
                int totalRecords = lstUsuario.Select(x => x.TOTALROWS).FirstOrDefault();
                int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pFiltro.jqPageSize);
                var jsonGrid = new
                {
                    PageCount = totalPages,
                    CurrentPage = pFiltro.jqCurrentPage,
                    RecordCount = totalRecords,
                    Items = (
                        from item in lstUsuario
                        select new
                        {
                            ID = item.codUsuario,
                            Row = new string[] {string.Empty //Botón de EDITAR
                                              , string.Empty //Botón de ELIMINAR
                                              , string.Empty //Botón de RESET PASSWORD USER
                                              , string.Empty //Botón de BLOQUEAR
                                              , string.Concat( item.desApellidos, ", ", item.desNombres)
                                              , item.desLogin
                                              , item.desCorreo
                                              , item.desTelefono
                                              , item.codEmpleado
                                              , item.indLockUser.ToString()
                                              , item.indPasswordReset.ToString()
                                              , item.indVendedor.ToString()
                                              , item.indEstado.ToString()
                                              , item.segUsuarioEdita
                                              , item.segFechaEdita.HasValue? item.segFechaEdita.Value.ToString():""
                            }
                        }).ToArray()
                };
                return OK(jsonGrid);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pFiltro.userActual, pFiltro.codEmpresa);
            }
            finally
            {
                if (oUsuarioData != null)
                {
                    oUsuarioData.Dispose();
                    oUsuarioData = null;
                }
            }
        }

        #endregion


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

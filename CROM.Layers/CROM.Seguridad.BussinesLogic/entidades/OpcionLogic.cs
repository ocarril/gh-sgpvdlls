namespace CROM.Seguridad.BussinesLogic
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.entidades.dto;
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
    /// Archivo     : OpcionLogic.cs
    /// </summary
    public class OpcionLogic: BaseLayer
    {
        private OpcionData oOpcionData = null;
        private ReturnValor oReturn = null;
        public OpcionLogic()
        {
            oOpcionData = new OpcionData();
            oReturn = new ReturnValor();
        }

        #region ----- Proceso de Insertar -----

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public ReturnValor Insert(BEOpcionAux pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    string pMessage = string.Empty;
                    if (pItem.codOpcionPadre == string.Empty)
                        pItem.codOpcionPadre = null;
                    oReturn.CodigoRetorno = this.oOpcionData.Insert(pItem, out pMessage);

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
            }
            catch (Exception ex)
            {
                oReturn = HelpException.mTraerMensaje(ex);
            }
            return oReturn;
        }

        #endregion

        #region ----- Proceso de Actualizar -----

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public ReturnValor Update(BEOpcionAux pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (pItem.codOpcionPadre == string.Empty)
                        pItem.codOpcionPadre = null;
                    oReturn.Exitosa = oOpcionData.Update(pItem);
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

        #region ----- Proceso de Eliminar -----

        public ReturnValor Delete(string p_CodigoRol)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oOpcionData.Delete(p_CodigoRol);
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

        #region ----- Proceso de Encontrar -----

        /// <summary>
        /// Retorna un objeto de registros de tipo Opciones.
        /// </summary>
        /// <returns>Lista</returns>
        public BEOpcionAux Find(string p_CodigoRol)
        {
            BEOpcionAux itemRol = new BEOpcionAux();
            try
            {
                itemRol = oOpcionData.Find(p_CodigoRol);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              string.Format("CodigoRol: {0}.", p_CodigoRol));
                throw new Exception(returnValor.Message);
            }
            return itemRol;
        }

        #endregion

        #region ----- Proceso de Listar -----

        /// <summary>
        /// Retorna un coleccion de registros de tipo [OpcionAux].
        /// <summary>
        /// <returns>List</returns>
        public List<BEOpcionAux> List(string prm_CodigoOpcion, string prm_CodigoSistema, string prm_Nombre, 
                                      string prm_Descripcion, bool prm_Estado, string pTipoObjeto)
        {
            List<BEOpcionAux> lista = new List<BEOpcionAux>();
            try
            {
                lista = oOpcionData.List(prm_CodigoOpcion, prm_CodigoSistema, 
                                         prm_Nombre, 
                                         prm_Descripcion, 
                                         prm_Estado, pTipoObjeto);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                               string.Format("codSistema: {0}.", prm_CodigoSistema));
                throw new Exception(returnValor.Message);
            }
            return lista;
        }

        public List<BEOpcionAux> List(string prm_CodigoOpcion, string prm_CodigoSistema, 
                                      string prm_Nombre, string prm_Descripcion, bool prm_Estado, 
                                      string pTipoObjeto, Helper.ComboBoxText pTexto)
        {
            List<BEOpcionAux> lista = new List<BEOpcionAux>();
            try
            {
                lista = oOpcionData.List(prm_CodigoOpcion, 
                                         prm_CodigoSistema, 
                                         prm_Nombre, 
                                         prm_Descripcion, 
                                         prm_Estado, pTipoObjeto);
                if (lista.Count > 0)
                    lista.Insert(0, new BEOpcionAux { codOpcion = "", desNombre = Helper.ObtenerTexto(pTexto) });
                else
                    lista.Add(new BEOpcionAux { codOpcion = "", desNombre = Helper.ObtenerTexto(pTexto) });
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              string.Format("codSistema: {0}.", prm_CodigoSistema));
                throw new Exception(returnValor.Message);
            }
            return lista;
        }

        /// <summary>
        /// Listado con paginacion para aplicación WEB 
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public OperationResult ListPaged(BEBuscaOpcionRequest pFiltro)
        {
            try
            {
                List<BEOpcionResponse> lstOpcion = new List<BEOpcionResponse>();
                lstOpcion = oOpcionData.ListPaged(pFiltro);
                int totalRecords = lstOpcion.Select(x => x.TOTALROWS).FirstOrDefault();
                int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pFiltro.jqPageSize);
                var jsonGrid = new
                {
                    PageCount = totalPages,
                    CurrentPage = pFiltro.jqCurrentPage,
                    RecordCount = totalRecords,
                    Items = (
                        from item in lstOpcion
                        select new
                        {
                            ID = item.codOpcion,
                            Row = new string[] {string.Empty
                                              , string.Empty
                                              , item.indTipoObjeto
                                              , item.desNombre
                                              , item.codOpcionPadreNombre
                                              , item.desEnlaceURL
                                              , item.desEnlaceWIN
                                              , item.codElementoID
                                              , item.indMenu.ToString()
                                              , item.numOrden.ToString()
                                              , item.nomIcono
                                              , item.desDescripcion
                                              , item.codSistemaNombre
                                              , item.indEstado.ToString()

                                              , item.segUsuarioEdita
                                              , item.segFechaEdita.HasValue? item.segFechaEdita.Value.ToString():string.Empty
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
                if (oOpcionData != null)
                {
                    oOpcionData.Dispose();
                    oOpcionData = null;
                }
            }
        }

        #endregion

        public object ObtenerTipoObjeto()
        {

            List<ComboListItemString> lstTipoObjeto = new List<ComboListItemString>();

            lstTipoObjeto.Add(new ComboListItemString
            {
                text = WebConstants.TipoOpcionPermiso.ACTION.ToString(),
                value = WebConstants.TipoOpcionPermiso.ACTION.ToString()
            });

            lstTipoObjeto.Add(new ComboListItemString
            {
                text = WebConstants.TipoOpcionPermiso.CONTROL.ToString(),
                value = WebConstants.TipoOpcionPermiso.CONTROL.ToString()
            });

            lstTipoObjeto.Add(new ComboListItemString
            {
                text =  WebConstants.TipoOpcionPermiso.MENU.ToString(),
                value = WebConstants.TipoOpcionPermiso.MENU.ToString()
            });

            lstTipoObjeto.Add(new ComboListItemString
            {
                text =  WebConstants.TipoOpcionPermiso.PAGINA.ToString(),
                value = WebConstants.TipoOpcionPermiso.PAGINA.ToString()
            });


            return lstTipoObjeto;
        }
    }
}

namespace CROM.Seguridad.BussinesLogic
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Seguridad.DataAcces;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

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
    /// Archivo     : RolLogic.cs
    /// </summary
    public class RolLogic:BaseLayer
    {
        private RolData oRolData = null;
        private ReturnValor oReturn = null;
        public RolLogic()
        {
            oRolData = new RolData();
            oReturn = new ReturnValor();
        }

        #region ----- Proceso de Insertar -----

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public ReturnValor Insert(BERolAux pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.CodigoRetorno = this.oRolData.Insert(pItem);
                    if (oReturn.CodigoRetorno != null)
                    {
                        oReturn.Exitosa = true;
                        tx.Complete();
                        oReturn.Message = HelpMessages.Evento_NEW;
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
        public ReturnValor Update(BERolAux pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oRolData.Update(pItem);
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

        public ReturnValor Delete(BEEliminaRolRequest pEliminaRol)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oRolData.Delete(pEliminaRol);
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
        public BERol Find(string p_CodigoRol)
        {
            BERol itemRol = new BERol();
            try
            {
                itemRol = oRolData.Find(p_CodigoRol);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             string.Format("CodigoRol: {0}.", p_CodigoRol));
                throw new Exception(returnValor.Message);
            }
            return itemRol;
        }

        public OperationResult FindWS(string p_CodigoRol)
        {
            BERol itemRol = new BERol();
            try
            {
                itemRol = oRolData.Find(p_CodigoRol);
                return OK(itemRol);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, "", "");
            }
        }

        #endregion

        #region ----- Proceso de Listar -----

        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla].
        /// <summary>
        /// <returns>List</returns>
        public List<BERolAux> List(string prm_Nombre, string prm_CodigoSistema, string prm_Descripcion, bool prm_Estado)
        {
            List<BERolAux> lista = new List<BERolAux>();
            try
            {
                lista = oRolData.List(prm_Nombre, prm_CodigoSistema, prm_Descripcion, prm_Estado);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                               string.Format("codSistema: {0}.", prm_CodigoSistema));
                throw new Exception(returnValor.Message);
            }
            return lista;
        }
        public List<BERolAux> List(string prm_Nombre, string prm_CodigoSistema, string prm_Descripcion, bool prm_Estado, Helper.ComboBoxText pTexto)
        {
            List<BERolAux> lista = new List<BERolAux>();
            try
            {
                lista = oRolData.List(prm_Nombre, prm_CodigoSistema, prm_Descripcion, prm_Estado);
                if (lista.Count > 0)
                    lista.Insert(0, new BERolAux { codRol = "", desNombre = Helper.ObtenerTexto(pTexto) });
                else
                    lista.Add(new BERolAux { codRol = "", desNombre = Helper.ObtenerTexto(pTexto) });
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
        public OperationResult ListPaged(BEBuscaRolRequest pFiltro)
        {
            List<BERolResponse> listaRol = new List<BERolResponse>();

            try
            {
                listaRol = oRolData.ListPaged(pFiltro);
                int totalRecords = listaRol.Select(x => x.TOTALROWS).FirstOrDefault();
                int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pFiltro.jqPageSize);
                var jsonGrid = new
                {
                    PageCount = totalPages,
                    CurrentPage = pFiltro.jqCurrentPage,
                    RecordCount = totalRecords,
                    Items = (
                        from item in listaRol
                        select new
                        {
                            ID = item.codRol,
                            Row = new string[] {string.Empty
                                              , string.Empty
                                              , item.desNombre
                                              , item.desDescripcion
                                              , item.codSistemaNombre
                                              , item.indEstado.ToString()
                                              , item.segUsuarioEdita
                                              , item.segFechaEdita.ToString()
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
                if (oRolData != null)
                {
                    oRolData.Dispose();
                    oRolData = null;
                }
            }

        }
        
        #endregion

    }
}

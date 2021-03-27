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
    /// Archivo     : RolOpcionLogic.cs
    /// </summary
    public class RolOpcionLogic : BaseLayer
    {
        private RolOpcionData oRolOpcionData = null;
        private ReturnValor oReturn = null;
        public RolOpcionLogic()
        {
            oRolOpcionData = new RolOpcionData();
            oReturn = new ReturnValor();
        }

        #region ----- Proceso de Insertar -----

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public ReturnValor InsertUpdate(List<BERolOpcionAux> pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    foreach (BERolOpcionAux item in pItem)
                    {
                        oReturn.Exitosa = oRolOpcionData.InsertUpdate(item);
                    }
                    if (oReturn.Exitosa)
                    {
                        oReturn.Message = HelpMessages.Evento_NEW;
                        tx.Complete();
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

        public ReturnValor Delete(string p_CodigoRol, string p_CodigOpcion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oRolOpcionData.Delete(p_CodigoRol, p_CodigOpcion);
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

        public ReturnValor DeleteWS(int pcodRolOpcion, string psegUsuarioEdita)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oRolOpcionData.DeleteWS(pcodRolOpcion);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessages.Evento_DELETE;
                    }
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpException.mTraerMensaje(ex, false, string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                                                            psegUsuarioEdita, "");
            }
            return oReturn;
        }

        #endregion

        #region ----- Proceso de Encontrar -----

        /// <summary>
        /// Retorna un objeto de registros de tipo Opciones.
        /// </summary>
        /// <returns>Lista</returns>
        public BERolOpcion Find(string p_CodigoRol, string p_CodigOpcion)
        {
            BERolOpcion itemRol = new BERolOpcion();
            try
            {
                itemRol = oRolOpcionData.Find(p_CodigoRol, p_CodigOpcion);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                               string.Format("CodigoRol: {0}.", p_CodigoRol));
                throw new Exception(returnValor.Message);
            }
            return itemRol;
        }

        public OperationResult FindWS(int p_codRolOpcion)
        {
            BERolOpcion itemRol = new BERolOpcion();
            try
            {
                itemRol = oRolOpcionData.FindWS(p_codRolOpcion);
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
        public List<BERolOpcionAux> List(string prm_CodigoSistema, string prm_CodigoRol)
        {
            List<BERolOpcionAux> lista = new List<BERolOpcionAux>();
            try
            {
                lista = oRolOpcionData.List(prm_CodigoSistema, prm_CodigoRol);
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
        public OperationResult ListPaged(BEBuscaRolOpcionRequest pFiltro)
        {
            List<BERolOpcionResponse> listaRolOpcion = new List<BERolOpcionResponse>();

            try
            {
                listaRolOpcion = oRolOpcionData.ListPaged(pFiltro);
                int totalRecords = listaRolOpcion.Select(x => x.TOTALROWS).FirstOrDefault();
                int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pFiltro.jqPageSize);
                var jsonGrid = new
                {
                    PageCount = totalPages,
                    CurrentPage = pFiltro.jqCurrentPage,
                    RecordCount = totalRecords,
                    Items = (
                        from item in listaRolOpcion
                        select new
                        {
                            ID = item.codRolOpcion,
                            Row = new string[] {
                                          item.indVer.ToString().ToLower()
                                        , item.indEditar.ToString().ToLower()
                                        , item.indEliminar.ToString().ToLower()
                                        , item.indExporta.ToString().ToLower()
                                        , item.indImporta.ToString().ToLower()
                                        , item.indImprime.ToString().ToLower()
                                        , item.indNuevo.ToString().ToLower()
                                        , item.indOtro.ToString().ToLower()
                                        , item.indActivo.ToString().ToLower()
                                        , item.codRolNombre
                                        , item.codSistemaNombre
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
                if (oRolOpcionData != null)
                {
                    oRolOpcionData.Dispose();
                    oRolOpcionData = null;
                }
            }

        }

        #endregion

    }
}
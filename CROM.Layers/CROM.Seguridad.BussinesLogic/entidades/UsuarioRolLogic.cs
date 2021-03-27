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
    /// Archivo     : UsuarioRolLogic.cs
    /// </summary
    public class UsuarioRolLogic : BaseLayer
    {
        private UsuarioRolData oUsuarioRolData = null;
        private ReturnValor oReturn = null;
        public UsuarioRolLogic()
        {
            oUsuarioRolData = new UsuarioRolData();
            oReturn = new ReturnValor();
        }

        #region ----- Proceso de Insertar -----

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public ReturnValor Insert(BEUsuarioRol pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (Find(pItem.codUsuario, pItem.codRol).codUsuario == null)
                    {
                        oReturn.Exitosa = oUsuarioRolData.Insert(pItem);
                        oReturn.Message = HelpMessages.Evento_NEW;
                    }
                    else
                    {
                        oReturn.Exitosa = oUsuarioRolData.Update(pItem);
                        oReturn.Message = HelpMessages.Evento_EDIT;
                    }
                    if (oReturn.Exitosa)
                    {
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

        #region ----- Proceso de Actualizar -----

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public ReturnValor Update(BEUsuarioRol pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oUsuarioRolData.Update(pItem);
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

        //public ReturnValor Delete(string p_CodigoUsuario, string p_CodigoRol)
        //{
        //    try
        //    {
        //        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
        //        {
        //            oReturn.Exitosa = oUsuarioRolData.Delete(p_CodigoUsuario, p_CodigoRol);
        //            if (oReturn.Exitosa)
        //            {
        //                tx.Complete();
        //                oReturn.Message = HelpMessages.Evento_DELETE;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oReturn = HelpException.mTraerMensaje(ex);
        //    }
        //    return oReturn;
        //}

        public ReturnValor DeleteWS(int pcodRolOpcion, string psegUsuarioEdita)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oUsuarioRolData.DeleteWS(pcodRolOpcion);
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
        public BEUsuarioRol Find(string p_CodigoUsuario, string p_CodigoRol)
        {
            BEUsuarioRol itemRol = new BEUsuarioRol();
            try
            {
                itemRol = oUsuarioRolData.Find(p_CodigoUsuario, p_CodigoRol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemRol;
        }

        public OperationResult FindWS(int p_codRolOpcion)
        {
            BEUsuarioRol itemRol = new BEUsuarioRol();
            try
            {
                itemRol = oUsuarioRolData.FindWS(p_codRolOpcion);
                return OK(itemRol);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, "", "");
            }
        }


        #endregion

        #region ----- Proceso de Listar -----

        ///// <summary>
        ///// Retorna un coleccion de registros de tipo [Tabla].
        ///// <summary>
        ///// <returns>List</returns>
        //public List<BEUsuarioRolAux> List(string prm_CodigoSistema, string prm_CodigoUsuario)
        //{
        //    List<BEUsuarioRolAux> lista = new List<BEUsuarioRolAux>();
        //    try
        //    {
        //        lista = oUsuarioRolData.List(prm_CodigoSistema, prm_CodigoUsuario);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lista;
        //}

        public OperationResult ListPaged(BEBuscaRolUsuarioRequest pFiltro)
        {
            List<BEUsuarioRolResponse> lstUsuarioRol = new List<BEUsuarioRolResponse>();

            try
            {
                lstUsuarioRol = oUsuarioRolData.ListPaged(pFiltro);
                int totalRecords = lstUsuarioRol.Select(x => x.TOTALROWS).FirstOrDefault();
                int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pFiltro.jqPageSize);
                var jsonGrid = new
                {
                    PageCount = totalPages,
                    CurrentPage = pFiltro.jqCurrentPage,
                    RecordCount = totalRecords,
                    Items = (
                        from item in lstUsuarioRol
                        select new
                        {
                            ID = item.codUsuarioRol,
                            Row = new string[] {string.Empty
                                              , string.Empty
                                              , item.codUsuarioLogin
                                              , item.codUsuarioNombre
                                              , item.codRolNombre
                                              , item.codSistemaNombre
                                              , item.codEmpresaNombre
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
                if (oUsuarioRolData != null)
                {
                    oUsuarioRolData.Dispose();
                    oUsuarioRolData = null;
                }
            }

        }

        #endregion

    }
}

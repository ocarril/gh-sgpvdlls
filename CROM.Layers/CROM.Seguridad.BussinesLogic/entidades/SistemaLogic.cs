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
    /// Archivo     : SistemaLogic.cs
    /// </summary
    public class SistemaLogic : BaseLayer
    {
        private SistemaData oSistemaData = null;
        private ReturnValor oReturn = null;
        public SistemaLogic()
        {
            oSistemaData = new SistemaData();
            oReturn = new ReturnValor();
        }

        #region ----- Proceso de Insertar -----

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public ReturnValor Insert(BESistema pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.CodigoRetorno = oSistemaData.Insert(pItem);
                    if (oReturn.CodigoRetorno != null)
                    {
                        oReturn.Exitosa = true;
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

        #region ----- Proceso de Actualizar -----

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public ReturnValor Update(BESistema pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oSistemaData.Update(pItem);
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

        public ReturnValor Delete(string prm_CodigoSistema)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oSistemaData.Delete(prm_CodigoSistema);
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
        public BESistema Find(string prm_CodigoSistema)
        {
            BESistema itemSistemas = new BESistema();
            try
            {
                itemSistemas = oSistemaData.Find(prm_CodigoSistema);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              string.Format("codSistema: {0}.", prm_CodigoSistema));
                throw new Exception(returnValor.Message);
            }
            return itemSistemas;
        }

        public OperationResult FindWS(string prm_CodigoSistema)
        {
            BESistema objSistema = new BESistema();
            try
            {
                objSistema = oSistemaData.Find(prm_CodigoSistema);
                return OK(objSistema);
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
        public List<BESistema> List(string prm_CodigoSistema, string prm_Nombre, string prm_Descripcion, bool? prm_Estado)
        {
            List<BESistema> lista = new List<BESistema>();
            try
            {
                lista = oSistemaData.List(prm_CodigoSistema, prm_Nombre, prm_Descripcion, prm_Estado);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              string.Format("codSistema: {0}.", prm_CodigoSistema));
                throw new Exception(returnValor.Message);
            }
            return lista;
        }

        public List<BESistema> List(string prm_CodigoSistema, string prm_Nombre, string prm_Descripcion, bool? prm_Estado, Helper.ComboBoxText pTexto)
        {
            List<BESistema> lista = new List<BESistema>();
            try
            {
                lista = oSistemaData.List(prm_CodigoSistema, prm_Nombre, prm_Descripcion, prm_Estado);
                if (lista.Count > 0)
                    lista.Insert(0, new BESistema { codSistema = "", desNombre = Helper.ObtenerTexto(pTexto) });
                else
                    lista.Add(new BESistema { codSistema = "", desNombre = Helper.ObtenerTexto(pTexto) });
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
        public OperationResult ListPaged(BEBuscaSistemaRequest pFiltro)
        {
            List<BESistemaResponse> lstSistema = new List<BESistemaResponse>();
            try
            {
                oSistemaData = new SistemaData();
                lstSistema = oSistemaData.ListPaged(pFiltro);
                int totalRecords = lstSistema.Select(x => x.TOTALROWS).FirstOrDefault();
                int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pFiltro.jqPageSize);
                var jsonGrid = new
                {
                    PageCount = totalPages,
                    CurrentPage = pFiltro.jqCurrentPage,
                    RecordCount = totalRecords,
                    Items = (
                        from item in lstSistema
                        select new
                        {
                            ID = item.codSistema,
                            Row = new string[] {string.Empty
                                              , string.Empty
                                              , item.desNombre
                                              , item.desDescripcion
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
                if (oSistemaData != null)
                {
                    oSistemaData.Dispose();
                    oSistemaData = null;
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

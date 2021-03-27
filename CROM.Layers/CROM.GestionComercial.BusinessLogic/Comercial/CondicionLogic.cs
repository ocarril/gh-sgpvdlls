namespace CROM.GestionComercial.BusinessLogic
{
    using CROM.BusinessEntities.Comercial;
    using CROM.GestionComercial.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Transactions;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [GestionComercial.CondicionVentaLogic.cs]
    /// </summary>
    public class CondicionLogic
    {
        private CondicionData objCondicionData = null;
        private ReturnValor oReturnValor = null;
        public CondicionLogic()
        {
            objCondicionData = new CondicionData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.CondicionVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.CondicionVenta]
        /// <summary>
        /// <returns>List</returns>
        public List<BECondicion> List(BaseFiltro pFiltro)
        {
            List<BECondicion> lstCondicion = new List<BECondicion>();
            try
            {
                lstCondicion = objCondicionData.List(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, 
                                    this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pFiltro.segUsuarioEdita);
                throw new Exception(returnValor.Message);
            }
            return lstCondicion;
        }

        public List<BECondicion> List(BaseFiltro pFiltro, Helper.ComboBoxText pTexto)
        {
            List<BECondicion> lstCondicion = new List<BECondicion>();
            try
            {
                lstCondicion = objCondicionData.List(pFiltro);
                if (lstCondicion.Count > 0)
                    lstCondicion.Insert(0, new BECondicion { codCondicion = 0, desNombre = Helper.ObtenerTexto(pTexto) });
                else
                    lstCondicion.Add(new BECondicion { codCondicion = 0, desNombre = Helper.ObtenerTexto(pTexto) });
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, 
                                    this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pFiltro.segUsuarioEdita);
                throw new Exception(returnValor.Message);
            }
            return lstCondicion;
        }

        public List<BECondicion> ListPaginado(BaseFiltroCondicionPage pFiltro)
        {
            List<BECondicion> lstCondicion = new List<BECondicion>();
            try
            {
                lstCondicion = objCondicionData.ListPaginado(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, 
                    this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pFiltro.segUsuarioActual);
                throw new Exception(returnValor.Message);
            }
            return lstCondicion;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.CondicionVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.CondicionVenta]
        /// <summary>
        /// <returns>Entidad</returns>
        public BECondicion Find(int pID, bool? prm_indEsVenta, bool? prm_indActivo)
        {
            BECondicion condicion = new BECondicion();
            try
            {
                condicion = objCondicionData.Find(pID, prm_indEsVenta, prm_indActivo);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
                throw new Exception(returnValor.Message);
            }
            return condicion;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        public ReturnValor Save(BECondicion objCondicion)
        {
            if (objCondicion.codCondicion==0)
                oReturnValor = Insert(objCondicion);
            else
                oReturnValor = Update(objCondicion);
            return oReturnValor;
        }

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo CondicionVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.CondicionVenta]
        /// <summary>
        /// <param name = >itemCondicionVenta</param>
        private ReturnValor Insert(BECondicion pCondicion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.codRetorno = objCondicionData.Insert(pCondicion);
                    if (oReturnValor.codRetorno > 0)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                        oReturnValor.Exitosa = true;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo CondicionVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.CondicionVenta]
        /// <summary>
        /// <param name = >itemCondicionVenta</param>
        private ReturnValor Update(BECondicion pCondicion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objCondicionData.Update(pCondicion);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.CondicionVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.CondicionVenta]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(BECondicion pCondicion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objCondicionData.Delete(pCondicion);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion

    }
} 

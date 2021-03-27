namespace CROM.GestionComercial.BusinessLogic
{
    using CROM.BusinessEntities.Cajas;
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
    /// Fecha       : 05/09/2010-04:41:47 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [CajaBanco.FormasDePagoLogic.cs]
    /// </summary>
    public class FormaDePagoLogic
    {
        private FormaDePagoData oFormaDePagoData = null;
        private ReturnValor oReturnValor = null;

        public FormaDePagoLogic()
        {
            oFormaDePagoData = new FormaDePagoData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.FormasDePago
        /// En la BASE de DATO la Tabla : [GestionComercial.FormasDePago]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEFormaDePago> List(BaseFiltro pFiltro)
        {
            List<BEFormaDePago> lstFormaDePago = new List<BEFormaDePago>();
            try
            {
                lstFormaDePago = oFormaDePagoData.List(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pFiltro.segUsuarioEdita);
                throw new Exception(returnValor.Message);
            }
            return lstFormaDePago;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.FormasDePago con opcion
        /// En la BASE de DATO la Tabla : [GestionComercial.FormasDePago]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <param name="pTexto"></param>
        /// <returns></returns>
        public List<BEFormaDePago> List(BaseFiltro pFiltro, Helper.ComboBoxText pTexto)
        {
            List<BEFormaDePago> lstFormaDePago = new List<BEFormaDePago>();
            try
            {
                lstFormaDePago = oFormaDePagoData.List(pFiltro);
                if (lstFormaDePago.Count > 0)
                    lstFormaDePago.Insert(0, new BEFormaDePago { codFormaDePago = 0, desNombre = Helper.ObtenerTexto(pTexto) });
                else
                    lstFormaDePago.Add(new BEFormaDePago { codFormaDePago = 0, desNombre = Helper.ObtenerTexto(pTexto) });
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pFiltro.segUsuarioEdita);
                throw new Exception(returnValor.Message);
            }
            return lstFormaDePago;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.FormasDePago Paginado
        /// En la BASE de DATO la Tabla : [GestionComercial.FormasDePago]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEFormaDePago> ListPaginado(BaseFiltro pFiltro)
        {
            List<BEFormaDePago> lstFormaDePago = new List<BEFormaDePago>();
            try
            {
                lstFormaDePago = oFormaDePagoData.ListPaginado(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pFiltro.segUsuarioEdita);
                throw new Exception(returnValor.Message);
            }
            return lstFormaDePago;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.FormasDePago
        /// En la BASE de DATO la Tabla : [GestionComercial.FormasDePago]
        /// <summary>
        /// <param name="prm_codFormaDePago"></param>
        /// <returns></returns>
        public BEFormaDePago Find(int prm_codFormaDePago)
        {
            BEFormaDePago objFormaDePago = null;
            try
            {
                objFormaDePago = oFormaDePagoData.Find(prm_codFormaDePago);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
                throw new Exception(returnValor.Message);
            }
            return objFormaDePago;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo FormasDePago
        /// En la BASE de DATO la Tabla : [GestionComercial.FormasDePago]
        /// <summary>
        /// <param name="objFormaDePago"></param>
        /// <returns></returns>
        public ReturnValor Insert(BEFormaDePago objFormaDePago)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oFormaDePagoData.Insert(objFormaDePago);
                    oReturnValor.codRetorno = objFormaDePago.codFormaDePago;
                    if (oReturnValor.codRetorno != 0)
                    {
                        oReturnValor.Exitosa = true;
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo FormasDePago
        /// En la BASE de DATO la Tabla : [GestionComercial.FormasDePago]
        /// <summary>
        /// <param name="objFormaDePago"></param>
        /// <returns></returns>
        public ReturnValor Update(BEFormaDePago objFormaDePago)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oFormaDePagoData.Update(objFormaDePago);
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
        /// ELIMINA un registro de la Entidad GestionComercial.FormasDePago
        /// En la BASE de DATO la Tabla : [GestionComercial.FormaDePago]
        /// <summary>
        /// <param name="prm_codFormaDePago"></param>
        /// <returns></returns>
        public ReturnValor Delete(int prm_codFormaDePago)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oFormaDePagoData.Delete(prm_codFormaDePago);
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

namespace CROM.GestionAlmacen.BusinessLogic
{
    using CROM.BusinessEntities.Almacen;
    using CROM.GestionAlmacen.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Transactions;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 18/01/2012-04:29:36 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Almacen.DepositoLogic.cs]
    /// </summary>
    public class DepositoLogic
    {
        private DepositoData depositoData = null;
        private ReturnValor returnValor = null;
        public DepositoLogic()
        {
            depositoData = new DepositoData();
            returnValor = new ReturnValor();
        }
       
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Deposito
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <returns>List</returns>
        public List<BEDeposito> List(BaseFiltroDeposito pFiltro)
        {
            List<BEDeposito> lstDeposito = new List<BEDeposito>();
            try
            {
                lstDeposito = depositoData.List(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstDeposito;
        }
        
        public List<BEDeposito> List(BaseFiltroDeposito pFiltro, Helper.ComboBoxText pTexto)
        {
            List<BEDeposito> lstDeposito = new List<BEDeposito>();
            try
            {
                lstDeposito = depositoData.List(pFiltro);
                if (lstDeposito.Count > 0)
                    lstDeposito.Insert(0, new BEDeposito { codDeposito = "", desNombre = Helper.ObtenerTexto(pTexto) });
                else
                    lstDeposito.Add(new BEDeposito{ codDeposito = "", desNombre = Helper.ObtenerTexto(pTexto) });
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstDeposito;
        }
      
        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.Deposito
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <param name="prm_codDeposito"></param>
        /// <returns></returns>
        public BEDeposito Find(int pcodEmpresa, string prm_codDeposito, string pUser)
        {
            BEDeposito deposito = null;
            try
            {
                deposito = depositoData.Find(pcodEmpresa, prm_codDeposito);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pUser, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return deposito;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Deposito
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <param name = >itemDeposito</param>
        public ReturnValor Insert(BEDeposito deposito)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.CodigoRetorno = depositoData.Insert(deposito);
                    if (returnValor.CodigoRetorno != null)
                    {
                        returnValor.Exitosa = true;
                        returnValor.Message = HelpMessages.Evento_NEW;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return returnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Deposito
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <param name = >itemDeposito</param>
        public ReturnValor Update(BEDeposito deposito)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = depositoData.Update(deposito);
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpMessages.Evento_EDIT;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return returnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.Deposito
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(int pcodEmpresa, string strCodDeposito)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = depositoData.Delete(pcodEmpresa, strCodDeposito);
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpMessages.Evento_DELETE;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return returnValor;
        }

        #endregion

    }
}

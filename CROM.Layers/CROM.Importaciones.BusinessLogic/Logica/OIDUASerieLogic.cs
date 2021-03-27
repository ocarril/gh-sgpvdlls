namespace CROM.Importaciones.BusinessLogic
{
    using CROM.BusinessEntities.Importaciones;
    using CROM.Importaciones.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Transactions;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 10/10/2014-12:36:46 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Importaciones.OIDUASerieLogic.cs]
    /// </summary>
    public class OIDUASerieLogic
    {
        private OIDUASerieData oOIDUASerieData = null;
        private ReturnValor oReturnValor = null;
        public OIDUASerieLogic()
        {
            oOIDUASerieData = new OIDUASerieData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Importaciones.OIDUASerie
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUASerie]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEOIDUASerie> List(BaseFiltroImp pFiltro)
        {
            List<BEOIDUASerie> lstOIDUASerie = new List<BEOIDUASerie>();
            List<BEOIDUASerie> lstOIDUASerieProdu = new List<BEOIDUASerie>();
            BEOIDUAProducto itemOIDUAProducto = new BEOIDUAProducto();
            try
            {
                OIDUAProductoLogic oOIDUAProductoLogic = new OIDUAProductoLogic();
                itemOIDUAProducto = oOIDUAProductoLogic.Find(new BaseFiltroImp { codOIDUAProducto = pFiltro.codOIDUAProducto });
                lstOIDUASerie = oOIDUASerieData.List(pFiltro);
                lstOIDUASerieProdu = oOIDUASerieData.ListProducto(pFiltro);
                foreach (BEOIDUASerie itemSerie in lstOIDUASerieProdu)
                {
                    itemSerie.auxcantidadTope = (int)itemOIDUAProducto.decCantidadFOB;
                    bool indExisteNumeroSerie = false;
                    foreach (BEOIDUASerie itemSerieGuardado in lstOIDUASerie)
                    {
                        if (itemSerie.codProductoSeriado == itemSerieGuardado.codProductoSeriado)
                            indExisteNumeroSerie = true;
                        itemSerieGuardado.auxcantidadTope = (int)itemOIDUAProducto.decCantidadFOB;
                    }
                    if (!indExisteNumeroSerie)
                        lstOIDUASerie.Add(itemSerie);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOIDUASerie;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Importaciones.OIDUASerie
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUASerie]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEOIDUASerie Find(BaseFiltroImp pFiltro)
        {
            BEOIDUASerie itemOIDUASerie = new BEOIDUASerie();
            try
            {
                itemOIDUASerie = oOIDUASerieData.Find(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemOIDUASerie;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDUASerie
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUASerie]
        /// <summary>
        /// <param name="pOIDUASerie"></param>
        /// <returns></returns>
        public ReturnValor Insert(List<BEOIDUASerie> plstOIDUASerie)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oOIDUASerieData.Insert(plstOIDUASerie);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_NEW;
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDUASerie
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUASerie]
        /// <summary>
        /// <param name="pOIDUASerie"></param>
        /// <returns></returns>
        public ReturnValor Update(List<BEOIDUASerie> plstOIDUASerie)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oOIDUASerieData.Update(plstOIDUASerie);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_EDIT;
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
        /// ELIMINA un registro de la Entidad Importaciones.OIDUASerie
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUASerie]
        /// <summary>
        /// <returns>List<OIDUASerie></returns>
        public ReturnValor Delete(List<BEOIDUASerie> lstOIDUASerie)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oOIDUASerieData.Delete(lstOIDUASerie);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
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

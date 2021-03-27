namespace CROM.Importaciones.BusinessLogic
{
    using CROM.BusinessEntities.Importaciones;
    using CROM.BusinessEntities.Importaciones.DTO;
    using CROM.Importaciones.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Transactions;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/08/2014-01:23:30 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Importaciones.OIDUACostoLogic.cs]
    /// </summary>
    public class OIDUACostoLogic
    {
        private OIDUACostoData oIDUACostoData = null;
        private ReturnValor returnValor = null;
        public OIDUACostoLogic()
        {
            oIDUACostoData = new OIDUACostoData();
            returnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Importaciones.OIDUACosto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUACosto]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEOIDUACosto> List(BaseFiltroImp pFiltro)
        {
            List<BEOIDUACosto> lstOIDUACosto = new List<BEOIDUACosto>();
            try
            {
                lstOIDUACosto = oIDUACostoData.List(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOIDUACosto;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Importaciones.OIDUACosto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUACosto]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public BEOIDUACosto Find(BaseFiltroImp pFiltro)
        {
            BEOIDUACosto oIDUACosto = new BEOIDUACosto();
            try
            {
                oIDUACosto = oIDUACostoData.Find(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oIDUACosto;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDUACosto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUACosto]
        /// </summary>
        /// <param name="oIDUACosto"></param>
        /// <returns></returns>
        public ReturnValor Insert(BEOIDUACosto oIDUACosto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = oIDUACostoData.Insert(oIDUACosto);
                    if (returnValor.Exitosa)
                    {
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDUACosto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUACosto]
        /// </summary>
        /// <param name="oIDUACosto"></param>
        /// <returns></returns>
        public ReturnValor Update(BEOIDUACosto oIDUACosto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = oIDUACostoData.Update(oIDUACosto);
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
        /// ELIMINA un registro de la Entidad Importaciones.OIDUACosto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUACosto]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public ReturnValor Delete(BaseFiltroImp pFiltro)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = oIDUACostoData.Delete(pFiltro);
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

        public ReturnValor Delete(List<BEOIDUACosto> plstOIDUACosto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = oIDUACostoData.Delete(plstOIDUACosto);
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

        public List<DTOAsignaCosto> ListAsignaCosto(BaseFiltroImp pFiltro, bool Paginado)
        {
            List<DTOAsignaCosto> lstAsignaCosto = new List<DTOAsignaCosto>();
            try
            {
                if (HelpTime.EsFechaValida(pFiltro.fecInicio) == string.Empty)
                    pFiltro.fecInicio = HelpTime.ConvertYYYYMMDD(Convert.ToDateTime(pFiltro.fecInicio));
                else
                    pFiltro.fecInicio = string.Empty;
                if (HelpTime.EsFechaValida(pFiltro.fecFinal) == string.Empty)
                    pFiltro.fecFinal = HelpTime.ConvertYYYYMMDD(Convert.ToDateTime(pFiltro.fecFinal));
                else
                    pFiltro.fecFinal = string.Empty;
                if (Paginado)
                    lstAsignaCosto = oIDUACostoData.ListAsignaCostoPaginado(pFiltro);
                else
                    lstAsignaCosto = oIDUACostoData.ListAsignaCosto(pFiltro);

            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return lstAsignaCosto;
        }

        #endregion

    }
} 

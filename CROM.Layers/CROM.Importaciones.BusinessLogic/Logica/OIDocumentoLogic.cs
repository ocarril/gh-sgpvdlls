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
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/08/2014-01:23:30 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Importaciones.OIDocumentoLogic.cs]
    /// </summary>
    public class OIDocumentoLogic
    {
        private OIDocumentoData oIDocumentoData = null;
        private ReturnValor returnValor = null;
        public OIDocumentoLogic()
        {
            oIDocumentoData = new OIDocumentoData();
            returnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Importaciones.OIDocumento
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumento]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEOIDocumento> List(BaseFiltroImp pFiltro)
        {
            List<BEOIDocumento> lstOIDocumento = new List<BEOIDocumento>();
            try
            {
                lstOIDocumento = oIDocumentoData.List(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOIDocumento;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Importaciones.OIDocumento
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumento]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public BEOIDocumento Find(BaseFiltroImp pFiltro)
        {
            BEOIDocumento oIDocumento = new BEOIDocumento();
            try
            {
                oIDocumento = oIDocumentoData.Find(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oIDocumento;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        public ReturnValor Insert(BEOIDocumento pOIDocumento)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = oIDocumentoData.Insert(pOIDocumento);
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

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDocumento
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumento]
        /// <summary>
        /// <param name = >itemOIDocumento</param>
        public ReturnValor Insert(List<BEOIDocumento> lstOIDocumento)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = oIDocumentoData.Insert(lstOIDocumento);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDocumento
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumento]
        /// <summary>
        /// <param name = >itemOIDocumento</param>
        public ReturnValor Update(BEOIDocumento oIDocumento)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = oIDocumentoData.Update(oIDocumento);
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
        /// ELIMINA un registro de la Entidad Importaciones.OIDocumento
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumento]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(BaseFiltroImp pFiltro)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = oIDocumentoData.Delete(pFiltro);
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

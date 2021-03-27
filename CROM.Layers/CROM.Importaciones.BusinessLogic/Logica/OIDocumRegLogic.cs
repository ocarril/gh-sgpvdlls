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
    /// Fecha       : 11/09/2014-06:09:07 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Importaciones.OIDocumRegLogic.cs]
    /// </summary>
    public class OIDocumRegLogic
    {
        private OIDocumRegData oOIDocumRegData = null;
        private ReturnValor oReturnValor = null;
        public OIDocumRegLogic()
        {
            oOIDocumRegData = new OIDocumRegData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Importaciones.OIDocumReg
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumReg]
        /// <summary>
        /// <returns>List</returns>
        public List<BEOIDocumReg> List(BaseFiltroImp pFiltro)
        {
            List<BEOIDocumReg> lstOIDocumReg = new List<BEOIDocumReg>();
            try
            {
                lstOIDocumReg = oOIDocumRegData.List(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOIDocumReg;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Importaciones.OIDocumReg
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumReg]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEOIDocumReg Find(int prm_codOIDocumReg)
        {
            BEOIDocumReg oIDocumReg = new BEOIDocumReg();
            try
            {
                BaseFiltroImp pFiltro = new BaseFiltroImp { codOIDocumReg = prm_codOIDocumReg };
                oIDocumReg = oOIDocumRegData.Find(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oIDocumReg;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDocumReg
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumReg]
        /// <summary>
        /// <param name = >itemOIDocumReg</param>
        public ReturnValor Insert(List<BEOIDocumReg> lstOIDocumReg)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oOIDocumRegData.Insert(lstOIDocumReg);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDocumReg
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumReg]
        /// <summary>
        /// <param name = >itemOIDocumReg</param>
        public ReturnValor Update(BEOIDocumReg pOIDocumReg)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oOIDocumRegData.Update(pOIDocumReg);
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
        /// ELIMINA un registro de la Entidad Importaciones.OIDocumReg
        /// En la BASE de DATO la Tabla : [Importaciones.OIDocumReg]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(BaseFiltroImp pFiltro)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oOIDocumRegData.Delete(pFiltro);
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

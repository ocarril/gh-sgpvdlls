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
    /// Archivo     : [Importaciones.OIDUAProductoLogic.cs]
    /// </summary>
    public class OIDUAProductoLogic
    {
        private OIDUAProductoData oIDUAProductoData = null;
        private ReturnValor returnValor = null;
        public OIDUAProductoLogic()
        {
            oIDUAProductoData = new OIDUAProductoData();
            returnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Importaciones.OIDUAProducto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUAProducto]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEOIDUAProducto> List(BaseFiltroImp pFiltro)
        {
            List<BEOIDUAProducto> lstOIDUAProducto = new List<BEOIDUAProducto>();
            try
            {
                lstOIDUAProducto = oIDUAProductoData.List(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOIDUAProducto;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Importaciones.OIDUAProducto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUAProducto]
        /// </summary>
        /// <param name="pBase"></param>
        /// <returns></returns>
        public BEOIDUAProducto Find(BaseFiltroImp pBase)
        {
            BEOIDUAProducto oIDUAProducto = new BEOIDUAProducto();
            try
            {
                oIDUAProducto = oIDUAProductoData.Find(pBase);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oIDUAProducto;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDUAProducto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUAProducto]
        /// </summary>
        /// <param name="oIDUAProducto"></param>
        /// <returns></returns>
        public ReturnValor Insert(BEOIDUAProducto oIDUAProducto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = oIDUAProductoData.Insert(oIDUAProducto);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDUAProducto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUAProducto]
        /// </summary>
        /// <param name="oIDUAProducto"></param>
        /// <returns></returns>
        public ReturnValor Update(BEOIDUAProducto oIDUAProducto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = oIDUAProductoData.Update(oIDUAProducto);
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
        /// ELIMINA un registro de la Entidad Importaciones.OIDUAProducto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUAProducto]
        /// </summary>
        /// <param name="prm_codOIDUAProducto"></param>
        /// <returns></returns>
        public ReturnValor Delete(List<BEOIDUAProducto> plstOIDUAProducto, string pUsuario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = oIDUAProductoData.Delete(plstOIDUAProducto, pUsuario);
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

namespace CROM.GestionImportacion.BusinessLogic
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
    /// Fecha       : 22/08/2014-01:07:11 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [GestionComercial.DocumentoEstadoLogic.cs]
    /// </summary>
    public class DocumentoEstadoLogic
    {
        private DocumentoEstadoData documentoEstadoData = null;
        private ReturnValor returnValor = null;
        private BEDocumentoEstado documentoEstado = null;

        public DocumentoEstadoLogic()
        {
            documentoEstadoData = new DocumentoEstadoData();
            returnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.DocumentoEstado
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoEstado]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumentoEstado> List(BaseFiltro pFiltro)
        {
            List<BEDocumentoEstado> lstDocumentoEstado = new List<BEDocumentoEstado>();
            try
            {
                lstDocumentoEstado = documentoEstadoData.List(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pFiltro.segUsuarioEdita, pFiltro.codEmpresaRUC);
                throw new Exception(returnValor.Message);
            }
            return lstDocumentoEstado;
        }

        public List<BEDocumentoEstado> ListPaged(BaseFiltro pFiltro)
        {
            List<BEDocumentoEstado> lstDocumentoEstado = new List<BEDocumentoEstado>();
            try
            {
                lstDocumentoEstado = documentoEstadoData.ListPaged(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pFiltro.segUsuarioEdita, pFiltro.codEmpresaRUC);
                throw new Exception(returnValor.Message);
            }
            return lstDocumentoEstado;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.DocumentoEstado
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoEstado]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public BEDocumentoEstado Find(BaseFiltro pFiltro)
        {
            try
            {
                if (pFiltro.codDocumentoEstado != 0)
                    documentoEstado = documentoEstadoData.Find(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pFiltro.segUsuarioEdita, pFiltro.codEmpresaRUC);
                throw new Exception(returnValor.Message);
            }
            return documentoEstado;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        public ReturnValor Insert(BEDocumentoEstado documentoEstado)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (documentoEstado.codDocumentoEstado == 0)
                    {
                        List<BEDocumentoEstado> lstDocumentoEstado = new List<BEDocumentoEstado>();
                        lstDocumentoEstado.Add(documentoEstado);
                        returnValor.Exitosa = documentoEstadoData.Insert(lstDocumentoEstado);
                    }
                    else
                        returnValor.Exitosa = documentoEstadoData.Update(documentoEstado);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo DocumentoEstado
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoEstado]
        /// </summary>
        /// <param name="lstDocumentoEstado"></param>
        /// <returns></returns>
        public ReturnValor Insert(List<BEDocumentoEstado> lstDocumentoEstado)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = documentoEstadoData.Insert(lstDocumentoEstado);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo DocumentoEstado
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoEstado]
        /// </summary>
        /// <param name="documentoEstado"></param>
        /// <returns></returns>
        public ReturnValor Update(BEDocumentoEstado documentoEstado)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = documentoEstadoData.Update(documentoEstado);
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
        /// ELIMINA un registro de la Entidad GestionComercial.DocumentoEstado
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoEstado]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public ReturnValor Delete(List<BEDocumentoEstado> lstDocumentoEstado)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    foreach (BEDocumentoEstado item in lstDocumentoEstado)
                    {
                        returnValor.Exitosa = documentoEstadoData.Delete(new BaseFiltro { codDocumentoEstado = item.codDocumentoEstado });
                    }
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

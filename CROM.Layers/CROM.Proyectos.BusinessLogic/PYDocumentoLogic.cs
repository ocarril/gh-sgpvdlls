namespace CROM.Proyectos.BusinessLogic
{
    using CROM.BusinessEntities.Proyectos;
    using CROM.Proyectos.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Transactions;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 10/12/2014-02:14:06 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Proyectos.PYDocumentoLogic.cs]
    /// </summary>
    public class PYDocumentoLogicNx
    {
        private PYDocumentoDataNx objPYDocumentoDataNx = null;
        private ReturnValor oReturnValor = null;
     
        public PYDocumentoLogicNx()
        {
            objPYDocumentoDataNx = new PYDocumentoDataNx();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.PYDocumento
        /// En la BASE de DATO la Tabla : [Proyectos.PYDocumento]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTODocumentoPry> ListarDocumento(BaseFiltroPry pFiltro)
        {
            List<DTODocumentoPry> lstPYDocumento = new List<DTODocumentoPry>();
            try
            {
                lstPYDocumento = objPYDocumentoDataNx.Listar(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPYDocumento;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Proyectos.PYDocumento
        /// En la BASE de DATO la Tabla : [Proyectos.PYDocumento]
        /// <summary>
        /// <param name="pcodPYDocumento"></param>
        /// <returns></returns>
        public BEPYDocumento BuscarDocumento(int pcodPYDocumento)
        {
            BEPYDocumento objPYDocumento = new BEPYDocumento();
            try
            {
                objPYDocumento = objPYDocumentoDataNx.Buscar(pcodPYDocumento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objPYDocumento;
        }

        #endregion

    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 10/12/2014-02:14:06 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Proyectos.PYDocumentoLogic.cs]
    /// </summary>
    public class PYDocumentoLogicTx 
    {
        private PYDocumentoDataTx objPYDocumentoDataTx = null; 
        private ReturnValor oReturnValor = null;

        public PYDocumentoLogicTx()
        {
            objPYDocumentoDataTx = new PYDocumentoDataTx();
            oReturnValor = new ReturnValor();
        }


        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PYDocumento
        /// En la BASE de DATO la Tabla : [Proyectos.PYDocumento]
        /// <summary>
        /// <param name="pydocumento"></param>
        /// <returns></returns>
        public ReturnValor RegistrarDocumento(BEPYDocumento objPYDocumento)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objPYDocumentoDataTx.Registrar(objPYDocumento);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo PYDocumento
        /// En la BASE de DATO la Tabla : [Proyectos.PYDocumento]
        /// <summary>
        /// <param name="pydocumento"></param>
        /// <returns></returns>
        public ReturnValor ActualizarDocumento(BEPYDocumento objPYDocumento)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objPYDocumentoDataTx.Actualizar(objPYDocumento);
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
        /// ELIMINA un registro de la Entidad Proyectos.PYDocumento
        /// En la BASE de DATO la Tabla : [Proyectos.PYDocumento]
        /// <summary>
        /// <returns></returns>
        public ReturnValor EliminarDocumento(int pcodPYDocumento)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objPYDocumentoDataTx.Eliminar(pcodPYDocumento);
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

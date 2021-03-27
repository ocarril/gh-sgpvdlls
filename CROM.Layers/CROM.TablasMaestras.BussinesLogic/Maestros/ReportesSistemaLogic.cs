namespace CROM.TablasMaestras.BussinesLogic
{
    using CROM.BusinessEntities.Maestros;
    using CROM.TablasMaestras.DataAcces;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Transactions;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 11/01/2010-11:33:49 
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Maestras.ReportesSistemaLogic.cs]
    /// </summary>
    public class ReportesSistemaLogic
    {
        private ReporteData oReportesSistemaData = null;
        private ReturnValor oReturnValor = null;

        public ReportesSistemaLogic()
        {
            oReportesSistemaData = new ReporteData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Maestras.ReportesSistema
        /// En la BASE de DATO la Tabla : [Maestras.ReportesSistema]
        /// <summary>
        /// <param name="prm_ReporteName"></param>
        /// <param name="prm_TipoDeReporte"></param>
        /// <param name="prm_CodigoSistema"></param>
        /// <param name="prm_Estado"></param>
        /// <returns></returns>
        public List<BEReporteSistema> List(string prm_ReporteName, string prm_TipoDeReporte, string prm_CodigoSistema, bool? prm_Estado)
        {
            List<BEReporteSistema> lstReporteSistema = new List<BEReporteSistema>();
            try
            {
                lstReporteSistema = oReportesSistemaData.List(prm_ReporteName, prm_TipoDeReporte, prm_Estado, prm_CodigoSistema);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstReporteSistema;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Maestras.ReportesSistema
        /// En la BASE de DATO la Tabla : [Maestras.ReportesSistema]
        /// <summary>
        /// <param name="pfiltro"></param>
        /// <returns></returns>
        public List<BEReporteSistema> List(BaseFiltroMaestro pfiltro)
        {
            List<BEReporteSistema> lstReporteSistema = new List<BEReporteSistema>();
            try
            {
                lstReporteSistema = oReportesSistemaData.List(pfiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstReporteSistema;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestras.ReportesSistema
        /// En la BASE de DATO la Tabla : [Maestras.ReportesSistema]
        /// <summary>
        /// <param name="prm_CodigoReporte"></param>
        /// <returns></returns>
        public BEReporteSistema Find(string prm_CodigoReporte)
        {
            BEReporteSistema reporteSistema = new BEReporteSistema();
            try
            {
                reporteSistema = oReportesSistemaData.Find(prm_CodigoReporte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reporteSistema;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Maestras.ReportesSistema
        /// En la BASE de DATO la Tabla : [Maestras.ReportesSistema]
        /// <summary>
        /// <param name="itemReportesSistema"></param>
        /// <returns></returns>
        public ReturnValor Insert(BEReporteSistema reportesSistema)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.CodigoRetorno = oReportesSistemaData.Insert(reportesSistema);
                    if (oReturnValor.CodigoRetorno != null)
                    {
                        oReturnValor.Exitosa = true;
                        tx.Complete();
                        oReturnValor.Message = HelpMessages.Evento_NEW;
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo ReportesSistema
        /// En la BASE de DATO la Tabla : [Maestras.ReportesSistema]
        /// <summary>
        /// <param name="reportesSistema"></param>
        /// <returns></returns>
        public ReturnValor Update(BEReporteSistema reportesSistema)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {

                    oReturnValor.Exitosa = oReportesSistemaData.Update(reportesSistema);
                    if (oReturnValor.Exitosa)
                    {
                        tx.Complete();
                        oReturnValor.Message = HelpMessages.Evento_EDIT;
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
        /// ELIMINA un registro de la Entidad Maestras.ReportesSistema
        /// En la BASE de DATO la Tabla : [Maestras.ReportesSistema]
        /// <summary>
        /// <param name="prm_codRegistro"></param>
        /// <returns></returns>
        public ReturnValor Delete(string prm_codRegistro)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oReportesSistemaData.Delete(prm_codRegistro);
                    if (oReturnValor.Exitosa)
                    {
                        tx.Complete();
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
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

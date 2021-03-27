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
    /// Archivo     : [Importaciones.OIDUALogic.cs]
    /// </summary>
    public class OIDUALogic
    {
        private OIDUAData oOIDUAData = null;
        private OIDUACostoData oIDUACostoData = null;
        private OIDUAProductoData oIDUAProductoData = null;
        private ReturnValor oReturnValor = null;

        public OIDUALogic()
        {
            oOIDUAData = new OIDUAData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Importaciones.OIDUA
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUA]
        /// <summary>
        /// <returns>List</returns>
        public List<BEOIDUA> List(BaseFiltroImp pFiltro)
        {
            List<BEOIDUA> lstOIDUA = new List<BEOIDUA>();
            try
            {
                string strIni = HelpTime.EsFechaValida(pFiltro.fecInicio);
                string strFin = HelpTime.EsFechaValida(pFiltro.fecFinal);
                if (string.IsNullOrEmpty(strFin) && string.IsNullOrEmpty(strFin))
                {
                    Nullable<DateTime> fecIni = Convert.ToDateTime(pFiltro.fecInicio);
                    Nullable<DateTime> fecFin = Convert.ToDateTime(pFiltro.fecFinal);
                    pFiltro.fecInicio = HelpTime.ConvertYYYYMMDD(fecIni);
                    pFiltro.fecFinal = HelpTime.ConvertYYYYMMDD(fecFin);

                }
                lstOIDUA = oOIDUAData.List(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOIDUA;
        }

        /// <summary>
        /// Proósito    :   Permite el listado de todas las DUAS generadas de acuerdo a la busqueda
        /// Fecha       :   25-Ago-2015 - 05:19am
        /// Autor       :   OCR - Orlando Carril Ramirez
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTODUA> ListPaged(BaseFiltroImp pFiltro)
        {
            List<DTODUA> lstDTODUA = new List<DTODUA>();
            try
            {
                string strIni = HelpTime.EsFechaValida(pFiltro.fecInicio);
                string strFin = HelpTime.EsFechaValida(pFiltro.fecFinal);
                if (string.IsNullOrEmpty(strIni) && string.IsNullOrEmpty(strFin))
                {
                    Nullable<DateTime> fecIni = Convert.ToDateTime(pFiltro.fecInicio);
                    Nullable<DateTime> fecFin = Convert.ToDateTime(pFiltro.fecFinal);
                    pFiltro.fecInicio = HelpTime.ConvertYYYYMMDD(fecIni);
                    pFiltro.fecFinal = HelpTime.ConvertYYYYMMDD(fecFin);

                }
                lstDTODUA = oOIDUAData.ListPaged(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDTODUA;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Importaciones.OIDUA
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUA]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEOIDUA Find(BaseFiltroImp pFiltro)
        {
            BEOIDUA oIDUA = new BEOIDUA();
            oIDUACostoData = new OIDUACostoData();
            oIDUAProductoData = new OIDUAProductoData();
            try
            {
                oIDUA = oOIDUAData.Find(pFiltro);
                oIDUA.lstOIDUACosto = oIDUACostoData.List(pFiltro);
                oIDUA.lstOIDUAProducto = oIDUAProductoData.List(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oIDUA;
        }

        public BEOIDUA FindAll(BaseFiltroImp pFiltro)
        {
            BEOIDUA oIDUA = new BEOIDUA();
            oIDUACostoData = new OIDUACostoData();
            oIDUAProductoData = new OIDUAProductoData();
            try
            {
                oIDUA = oOIDUAData.Find(pFiltro);
                oIDUA.lstOIDUACosto = oIDUACostoData.List(pFiltro);
                if (oIDUA.lstOIDUACosto.Count > 0)
                {
                    OrdenImportacionData oOrdenImportacionData = new OrdenImportacionData();
                    int contador = 1;
                    foreach (BEOIDUACosto itemCosto in oIDUA.lstOIDUACosto)
                    {

                        if (itemCosto.codRegResumenCosto != "IMCST001")
                            itemCosto.lstCostoDetalle = oOrdenImportacionData.ListCostoDetalle(new BaseFiltroImp { codOIDUA = pFiltro.codOIDUA, codRegResumenCosto = itemCosto.codRegResumenCosto });
                        itemCosto.codOIDUACosto = contador;
                        ++contador;
                    }
                }
                oIDUA.lstOIDUAProducto = oIDUAProductoData.List(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oIDUA;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDUA
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUA]
        /// </summary>
        /// <param name="oIDUA"></param>
        /// <returns></returns>
        public ReturnValor Insert(BEOIDUA oIDUA)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oOIDUAData.Insert(oIDUA);

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
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDUA
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUA]
        /// </summary>
        /// <param name="oIDUA"></param>
        /// <returns></returns>
        public ReturnValor Update(BEOIDUA oIDUA)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oOIDUAData.Update(oIDUA);
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
        /// ELIMINA un registro de la Entidad Importaciones.OIDUA
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUA]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(List<BEOIDUA> plstOIDUA)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oOIDUAData.Delete(plstOIDUA);
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

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.DocumentoMovDetalle
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUACosto]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public DTOCostoDetalle FindDetalleGasto(int pcodDocumRegDetalle)
        {
            DTOCostoDetalle costoDetalle = null;
            try
            {
                oIDUACostoData = new OIDUACostoData();
                costoDetalle = oOIDUAData.FindDetalleGasto(pcodDocumRegDetalle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return costoDetalle;
        }
        public ReturnValor UpdateDetalleGasto(DTOCostoDetalle pCostoDetalle)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oOIDUAData.UpdateDetalleGasto(pCostoDetalle);
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

        public ReturnValor ValidarCierreDeDUA(int pcodOIDUA)
        {
            try
            {
                oReturnValor.Exitosa = oOIDUAData.ValidarCierreDeDUA(pcodOIDUA);
                if (oReturnValor.Exitosa)

                    oReturnValor.Message = HelpMessages.ValidacionDUAok;
                else
                    oReturnValor.Message = HelpMessages.ValidacionDUAkO;

            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

    }
} 

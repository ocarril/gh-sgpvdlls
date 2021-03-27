namespace CROM.Importaciones.BusinessLogic
{
    using CROM.BusinessEntities.Importaciones;
    using CROM.BusinessEntities.Importaciones.DTO;
    using CROM.Importaciones.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Config;

    using System;
    using System.Collections.Generic;
    using System.Transactions;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/08/2014-01:23:29 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Importaciones.OrdenImportacionLogic.cs]
    /// </summary>
    public class OrdenImportacionLogic
    {
        private OrdenImportacionData ordenImportacionData = null;
        private ReturnValor returnValor = null;
        public OrdenImportacionLogic()
        {
            ordenImportacionData = new OrdenImportacionData();
            returnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Importaciones.OrdenImportacion
        /// En la BASE de DATO la Tabla : [Importaciones.OrdenImportacion]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEOrdenImportacion> List(BaseFiltroImp pFiltro)
        {
            List<BEOrdenImportacion> lstOrdenImportacion = new List<BEOrdenImportacion>();
            try
            {
                lstOrdenImportacion = ordenImportacionData.List(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOrdenImportacion;
        }

        public List<BEOrdenImportacion> ListPaged(BaseFiltroImp pFiltro)
        {
            List<BEOrdenImportacion> lstOrdenImportacion = new List<BEOrdenImportacion>();
            try
            {
                lstOrdenImportacion = ordenImportacionData.ListPaged(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOrdenImportacion;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Importaciones.OrdenImportacion
        /// En la BASE de DATO la Tabla : [Importaciones.OrdenImportacion]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public BEOrdenImportacion Find(BaseFiltroImp pFiltro)
        {
            BEOrdenImportacion ordenImportacion = new BEOrdenImportacion();
            try
            {
                ordenImportacion = ordenImportacionData.Find(pFiltro);
                ordenImportacion.lstOIDocumento = new OIDocumentoLogic().List(pFiltro);
                ordenImportacion.lstOIDUA = new OIDUALogic().List(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ordenImportacion;
        }

        /// <summary>
        /// Lista de documentos (Facturas) que generaran ORDEN DE IMPORTACION
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTODocumentoImp> ListFacturas(BaseFiltroImp pFiltro)
        {
            List<DTODocumentoImp> lstFacturasProv = new List<DTODocumentoImp>();
            List<BEOIDocumReg> lstOIDocumReg = new List<BEOIDocumReg>();
            try
            {
                lstFacturasProv = ordenImportacionData.ListFacturas(pFiltro);
                if (pFiltro.codOrdenImportacion != 0)
                {
                    OIDocumRegLogic oIDocumRegLogic = new OIDocumRegLogic();
                    lstOIDocumReg = oIDocumRegLogic.List(new BaseFiltroImp
                    {
                        codOrdenImportacion = pFiltro.codOrdenImportacion
                    });
                    if (lstOIDocumReg.Count > 0)
                    {
                        int contador = 0;
                        foreach (DTODocumentoImp documento in lstFacturasProv)
                        {
                            foreach (BEOIDocumReg documReg in lstOIDocumReg)
                            {
                                if (documento.codDocumReg == documReg.codDocumReg)
                                {
                                    documento.indAsignado = 1;
                                    documReg.segUsuarioCrea = Helper.ComboBoxText.Select.ToString();
                                    ++contador;
                                }
                            }
                        }
                        if (contador < lstOIDocumReg.Count)
                        {
                            foreach (BEOIDocumReg documReg in lstOIDocumReg)
                            {
                                if (documReg.segUsuarioCrea != Helper.ComboBoxText.Select.ToString())
                                    lstFacturasProv.Add(new DTODocumentoImp
                                    {
                                        codDocumReg = documReg.codDocumReg,
                                        indAsignado = 1,
                                        numDocumento = documReg.auxnumDocumento,
                                        numDocumentoSec = documReg.auxnumDocumentoSec,
                                        numDocumentoRef = documReg.auxnumDocumentoRef
                                    });
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFacturasProv;
        }

        public List<DTODocumentoImp> ListFacturas(int pCodEmpresa, List<DTOProveedor> plstProveedor, int? pIdOI)
        {
            List<DTODocumentoImp> lstFacturasProv = new List<DTODocumentoImp>();
            List<DTODocumentoImp> lstFacturasTotal = new List<DTODocumentoImp>();
            List<BEOIDocumReg> lstOIDocumReg = new List<BEOIDocumReg>();
            try
            {
                string codRegEstado = ConfigCROM.AppConfig(pCodEmpresa, ConfigTool.EST_FAC_Emitida);
                List<DTOProveedor> lstProveedor = new List<DTOProveedor>();
                foreach (DTOProveedor provee in plstProveedor)
                {
                    lstFacturasProv = ordenImportacionData.ListFacturas(new BaseFiltroImp
                    {
                        codPersonaEntidad = provee.codPersonaEntidad,
                        codRegEstado = codRegEstado
                    });
                    lstFacturasTotal.AddRange(lstFacturasProv);
                }

                if (pIdOI != 0)
                {
                    OIDocumRegLogic oIDocumRegLogic = new OIDocumRegLogic();
                    lstOIDocumReg = oIDocumRegLogic.List(new BaseFiltroImp
                    {
                        codOrdenImportacion = pIdOI
                    });
                    if (lstOIDocumReg.Count > 0)
                    {
                        int contador = 0;
                        foreach (DTODocumentoImp documento in lstFacturasTotal)
                        {
                            foreach (BEOIDocumReg documReg in lstOIDocumReg)
                            {
                                if (documento.codDocumReg == documReg.codDocumReg)
                                {
                                    documento.indAsignado = 1;
                                    documReg.segUsuarioCrea = Helper.ComboBoxText.Select.ToString();
                                    ++contador;
                                }
                            }
                        }
                        if (contador < lstOIDocumReg.Count)
                        {
                            foreach (BEOIDocumReg documReg in lstOIDocumReg)
                            {
                                if (documReg.segUsuarioCrea != Helper.ComboBoxText.Select.ToString())
                                    lstFacturasTotal.Add(new DTODocumentoImp
                                    {
                                        codDocumReg = documReg.codDocumReg,
                                        indAsignado = 1,
                                        numDocumento = documReg.auxnumDocumento,
                                        numDocumentoSec = documReg.auxnumDocumentoSec,
                                        numDocumentoRef = documReg.auxnumDocumentoRef,
                                        nomProveedor = documReg.auxnomProveedor
                                    });
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFacturasTotal;
        }
        public List<DTOProveedor> ListProveedores(BaseFiltroImp pFiltro)
        {
            List<DTOProveedor> lstProveedores = new List<DTOProveedor>();
            try
            {
                lstProveedores = ordenImportacionData.ListProveedores(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProveedores;
        }
        public List<DTOProveedor> ListProveedoresGasto(BaseFiltroImp pFiltro)
        {
            List<DTOProveedor> lstProveedores = new List<DTOProveedor>();
            try
            {
                lstProveedores = ordenImportacionData.ListProveedoresGasto(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProveedores;
        }
        public List<DTOCostoDetalle> ListCostoDetalle(BaseFiltroImp pFiltro)
        {
            List<DTOCostoDetalle> lstCostoDetalle = new List<DTOCostoDetalle>();
            try
            {
                lstCostoDetalle = ordenImportacionData.ListCostoDetalle(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCostoDetalle;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OrdenImportacion
        /// En la BASE de DATO la Tabla : [Importaciones.OrdenImportacion]
        /// </summary>
        /// <param name="ordenImportacion"></param>
        /// <returns></returns>
        public ReturnValor Insert(BEOrdenImportacion ordenImportacion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    OIDocumRegLogic documRegLogic = new OIDocumRegLogic();
                    returnValor.Exitosa = ordenImportacionData.Insert(ordenImportacion);
                    if (ordenImportacion.lstOIDocumReg.Count > 0)
                    {
                        foreach (BEOIDocumReg oIDocumReg in ordenImportacion.lstOIDocumReg)
                        {
                            oIDocumReg.codOrdenImportacion = ordenImportacion.codOrdenImportacion;
                            oIDocumReg.segUsuarioCrea = ordenImportacion.segUsuarioCrea;
                        }
                        returnValor = documRegLogic.Insert(ordenImportacion.lstOIDocumReg);
                    }

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
        /// Almacena el registro de una ENTIDAD de registro de Tipo OrdenImportacion
        /// En la BASE de DATO la Tabla : [Importaciones.OrdenImportacion]
        /// </summary>
        /// <param name="ordenImportacion"></param>
        /// <returns></returns>
        public ReturnValor Update(BEOrdenImportacion ordenImportacion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    OIDocumRegLogic oIDocumRegLogic = new OIDocumRegLogic();
                    returnValor.Exitosa = ordenImportacionData.Update(ordenImportacion);
                    if (ordenImportacion.lstOIDocumReg.Count > 0)
                    {
                        foreach (BEOIDocumReg regDocu in ordenImportacion.lstOIDocumReg)
                        {
                            regDocu.codOrdenImportacion = ordenImportacion.codOrdenImportacion;
                            regDocu.segUsuarioCrea = ordenImportacion.segUsuarioEdita;
                        }
                        returnValor = oIDocumRegLogic.Insert(ordenImportacion.lstOIDocumReg);
                    }

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
        /// ELIMINA un registro de la Entidad Importaciones.OrdenImportacion
        /// En la BASE de DATO la Tabla : [Importaciones.OrdenImportacion]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(List<BEOrdenImportacion> pFiltro)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    OIDocumentoLogic oiDocumentoLogic = new OIDocumentoLogic();
                    OIDUALogic oiDUALogic = new OIDUALogic();
                    OIDocumRegLogic oIDocumRegLogic = new OIDocumRegLogic();
                    foreach (BEOrdenImportacion item in pFiltro)
                    {
                        BaseFiltroImp filtro = new BaseFiltroImp
                        {
                            codOrdenImportacion = item.codOrdenImportacion
                        };
                        returnValor = oiDocumentoLogic.Delete(filtro);
                        returnValor = oIDocumRegLogic.Delete(filtro);
                        returnValor.Exitosa = ordenImportacionData.Delete(filtro);
                        if (returnValor.Exitosa)
                        {
                            returnValor.Message = HelpMessages.Evento_DELETE;
                            tx.Complete();
                        }
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

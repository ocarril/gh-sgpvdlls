namespace CROM.GestionComercial.BusinessLogic
{
    using CROM.BusinessEntities.Comercial;
    using CROM.GestionComercial.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Config;

    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Transactions;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [GestionComercial.ComprobantesLogic.cs]
    /// </summary>
    public class DocumentoLogic
    {
        private DocumentoData oDocumentoData = null;
        private DocumentoSerieData oDocumentoSerieData = null;
        private DocumentoImpuestoData objDocumentoImpuestoData = null;
        private ReturnValor oReturnValor = null;

        public DocumentoLogic()
        {
            oDocumentoData = new DocumentoData();
            oDocumentoSerieData = new DocumentoSerieData();
            objDocumentoImpuestoData = new DocumentoImpuestoData();
            oReturnValor = new ReturnValor();
        }

        #region /* TABLA / ENTIDAD : Comprobantes */

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.Documento
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumento> List(BaseFiltroDocumento pFiltro)
        {
            List<BEDocumento> listaDocumentos = new List<BEDocumento>();
            try
            {
                listaDocumentos = oDocumentoData.List(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return listaDocumentos;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <param name="pTexto"></param>
        /// <returns></returns>
        public List<BEDocumento> List(BaseFiltroDocumento pFiltro, Helper.ComboBoxText pTexto)
        {
            List<BEDocumento> listaDocumentos = new List<BEDocumento>();
            try
            {
                listaDocumentos = oDocumentoData.List(pFiltro);
                if (listaDocumentos.Count > 0)
                    listaDocumentos.Insert(0, new BEDocumento { CodigoComprobante = "", Descripcion = Helper.ObtenerTexto(pTexto) });
                else
                    listaDocumentos.Add(new BEDocumento { CodigoComprobante = "", Descripcion = Helper.ObtenerTexto(pTexto) });
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return listaDocumentos;
        }

        ///// <summary>
        ///// Retorna un LISTA de registros de la Entidad GestionComercial.Comprobantes Paginado
        ///// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        ///// <summary>
        ///// <param name="pFiltro"></param>
        ///// <returns></returns>
        //public List<BEDocumento> ListPaged(BaseFiltroDocumento pFiltro)
        //{
        //    List<BEDocumento> listaDocumentos = new List<BEDocumento>();
        //    try
        //    {
        //        listaDocumentos = oDocumentoData.ListPaged(pFiltro);
        //    }
        //    catch (Exception ex)
        //    {
        //        var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
        //                                                     pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
        //        throw new Exception(returnValor.Message);
        //    }
        //    return listaDocumentos;
        //}
        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="prm_codDocumento"></param>
        /// <returns></returns>
        public BEDocumento Find(string prm_codDocumento, string codEmpresaRUC, int pcodEmpresa, string pUserActual)
        {
            BEDocumento documento = null;
            try
            {
                documento = oDocumentoData.Find(prm_codDocumento, codEmpresaRUC);
                if (documento != null)
                {
                    int DECIMALS = Convert.ToInt32(ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_CantidadDecimals));
                    if (DECIMALS == 2)
                        documento.DefaultCantidadDecimals = "0.00";
                    else if (DECIMALS == 3)
                        documento.DefaultCantidadDecimals = "0.000";
                    else if (DECIMALS == 4)
                        documento.DefaultCantidadDecimals = "0.0000";
                    else if (DECIMALS == 5)
                        documento.DefaultCantidadDecimals = "0.00000";
                    documento.listaDocumentoImpuesto = objDocumentoImpuestoData.List(new BaseFiltroDocumentoImpuesto
                    {
                        codEmpresaRUC = documento.CodigoPersonaEmpre,
                        codEmpresa = pcodEmpresa,
                        codDocumento = prm_codDocumento,
                        codImpuesto = string.Empty
                    });
                    ImpuestoData oTiposDeImpuestoData = new ImpuestoData();
                    foreach (BEDocumentoImpuesto f in documento.listaDocumentoImpuesto)
                    {
                        f.objImpuesto = oTiposDeImpuestoData.Find(pcodEmpresa, f.CodigoImpuesto);
                    }
                }
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pUserActual, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return documento;
        }
        
        #endregion

        #region /* Proceso de INSERT-UPDATE RECORD */

        public ReturnValor Save(BEDocumento objDocumento)
        {
            if (string.IsNullOrEmpty(objDocumento.CodigoComprobante))
                oReturnValor = Insert(objDocumento);
            else
                oReturnValor = Update(objDocumento);
            return oReturnValor;
        }

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name = >itemComprobantes</param>
        private ReturnValor Insert(BEDocumento objComprobante)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (objComprobante.CodigoArguCentroCosto == string.Empty ||
                        objComprobante.CodigoArguCentroCosto == " ")
                        objComprobante.CodigoArguCentroCosto = null;
                    if (objComprobante.CodigoComprobanteAsos == string.Empty ||
                        objComprobante.CodigoComprobanteAsos == " ")
                        objComprobante.CodigoComprobanteAsos = null;

                    oReturnValor.Exitosa = oDocumentoData.Insert(objComprobante);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                           objComprobante.segUsuarioEdita, objComprobante.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="objComprobante"></param>
        /// <returns></returns>
        private ReturnValor Update(BEDocumento objComprobante)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (objComprobante.CodigoArguCentroCosto == string.Empty ||
                        objComprobante.CodigoArguCentroCosto == " ")
                        objComprobante.CodigoArguCentroCosto = null;
                    if (objComprobante.CodigoComprobanteAsos == string.Empty ||
                        objComprobante.CodigoComprobanteAsos == " ")
                        objComprobante.CodigoComprobanteAsos = null;
                    oReturnValor.Exitosa = oDocumentoData.Update(objComprobante);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                           objComprobante.segUsuarioEdita, objComprobante.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string prm_CodigoComprobante, string pUserActual, int pcodEmpresa)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oDocumentoData.Delete(prm_CodigoComprobante);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                           pUserActual, pcodEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #endregion

        #region /* TABLA / ENTIDAD : ComprobantesSeries */

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobantesSeries
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesSeries]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumentoSerie> ListDocumentoSerie(BaseFiltroDocumentoSerie pFiltro)
        {
            List<BEDocumentoSerie> lstDocumentoSerie = new List<BEDocumentoSerie>();
            try
            {
                lstDocumentoSerie = oDocumentoSerieData.List(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstDocumentoSerie;
        }

        public List<DTODocumentoSerie> ListDocumentoSeriePaginado(BaseFiltroDocumentoSeriePage pFiltro)
        {
            List<DTODocumentoSerie> lstDocumentoSerie = new List<DTODocumentoSerie>();
            try
            {
                lstDocumentoSerie = oDocumentoSerieData.ListPaginado(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstDocumentoSerie;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobantesSeries
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesSeries]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <param name="pTexto"></param>
        /// <returns></returns>
        public List<BEDocumentoSerie> ListDocumentoSerie(BaseFiltroDocumentoSerie pFiltro, Helper.ComboBoxText pTexto)
        {
            List<BEDocumentoSerie> lstDocumentoSerie = new List<BEDocumentoSerie>();
            try
            {
                lstDocumentoSerie = oDocumentoSerieData.List(pFiltro);
                if (lstDocumentoSerie.Count > 0)
                    lstDocumentoSerie.Insert(0, new BEDocumentoSerie
                    {
                        CodigoComprobante = "",
                        Descripcion = Helper.ObtenerTexto(pTexto)
                    });
                else
                    lstDocumentoSerie.Add(new BEDocumentoSerie
                    {
                        CodigoComprobante = "",
                        Descripcion = Helper.ObtenerTexto(pTexto)
                    });
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstDocumentoSerie;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.DocumentoSerie
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoSerie]
        /// <summary>
        /// <param name="prm_CodigoTalonario"></param>
        /// <returns></returns>
        public BEDocumentoSerie FindDocumentoSerie(string pcodEmpresaRUC, int prm_codDocumentoSerie, 
                                                   string pUserActual, int pcodEmpresa)
        {
            BEDocumentoSerie objDocumentoSerie = null;
            try
            {
                objDocumentoSerie = oDocumentoSerieData.Find(pcodEmpresaRUC, prm_codDocumentoSerie, null);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pUserActual, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return objDocumentoSerie;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo DocumentoSerie
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoSerie]
        /// <summary>
        /// <param name="objDocumentoSerie"></param>
        /// <returns></returns>
        public ReturnValor InsertDocumentoSerie(BEDocumentoSerie objDocumentoSerie)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    BEPuntoDeVenta objPuntoDeVenta = new PuntoDeVentaData().Find(objDocumentoSerie.codEmpresaRUC,
                                                                                 objDocumentoSerie.CodigoPuntoVenta);

                    objDocumentoSerie.CodigoPersonaEmpre = objPuntoDeVenta.codPersonaEmpre;
                    var resultInsert = oDocumentoSerieData.Insert(objDocumentoSerie);
                    
                    if (resultInsert.ErrorCode > 0)
                    {
                        oReturnValor.codRetorno = resultInsert.ErrorCode;
                        oReturnValor.Exitosa = true;
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                        tx.Complete();
                    }
                    else
                        oReturnValor.Message = resultInsert.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                           objDocumentoSerie.segUsuarioEdita, objDocumentoSerie.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo DocumentoSerie
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoSerie]
        /// <summary>
        /// <param name="objDocumentoSerie"></param>
        /// <returns></returns>
        public ReturnValor UpdateDocumentoSerie(BEDocumentoSerie objDocumentoSerie)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    var ResultInsert = oDocumentoSerieData.Update(objDocumentoSerie);
                    oReturnValor.Exitosa = ResultInsert.ErrorCode > 0 ? true : false;
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        tx.Complete();
                    }
                    else
                        oReturnValor.Message = ResultInsert.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                           objDocumentoSerie.segUsuarioEdita, objDocumentoSerie.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        public ReturnValor UpdateUltimoDocumentoSerie(BEDocumentoSerie objDocumentoSerie)
        {
            ReturnValor objReturnValor = new ReturnValor();
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    var resultUpdate = oDocumentoSerieData.UpdateUltimo(objDocumentoSerie);
                    objReturnValor.Exitosa = resultUpdate.ErrorCode == 1 ? true : false;
                    objReturnValor.Message = objReturnValor.Exitosa ? HelpEventos.MessageEvento(HelpEventos.Process.NEW) :
                                                                      HelpMessages.gc_DOCUM_NroDefinido;

                    tx.Complete();

                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                           objDocumentoSerie.segUsuarioEdita, objDocumentoSerie.codEmpresa.ToString());
            }
            return oReturnValor;
        }
        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.DocumentoSerie
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoSerie]
        /// <summary>
        /// <param name="prm_CodigoTalonario"></param>
        /// <returns></returns>
        public ReturnValor DeleteDocumentoSerie(string prm_codEmpresaRUC, int prm_codDocumentoSerie, 
                                                string prm_SegUsuarioDelete, string prm_SegMaquina,
                                                int pcodEmpresa)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {

                    var resultDelete = oDocumentoSerieData.Delete(prm_codEmpresaRUC, 
                                                                  prm_codDocumentoSerie,
                                                                  prm_SegUsuarioDelete, 
                                                                  prm_SegMaquina);

                    oReturnValor.Exitosa = resultDelete.ErrorCode > 0 ? true : false;
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                           prm_SegUsuarioDelete, pcodEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #endregion

        #region /* TABLA / ENTIDAD : ComprobantesImpuestos */

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobantesSeries
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesSeries]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumentoImpuesto> ListDocumentoImpuesto(BaseFiltroDocumentoImpuesto pFiltro)
        {
            List<BEDocumentoImpuesto> lstDocumentoImpuesto = new List<BEDocumentoImpuesto>();
            try
            {
                lstDocumentoImpuesto = objDocumentoImpuestoData.List(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstDocumentoImpuesto;
        }

        public List<BEDocumentoImpuesto> ListDocumentoImpuestoPaginado(BaseFiltroDocumentoImpuestoPage pFiltro)
        {
            List<BEDocumentoImpuesto> lstDocumentoImpuesto = new List<BEDocumentoImpuesto>();
            try
            {
                lstDocumentoImpuesto = objDocumentoImpuestoData.ListPaginado(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstDocumentoImpuesto;
        }

        #endregion

        #region /* Proceso de SELECT ID */
         /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobantesImpuestos
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesImpuestos]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public BEDocumentoImpuesto FindDocumentoImpuesto(BaseFiltroDocumentoImpuesto pFiltro)
        {
            BEDocumentoImpuesto objDocumentoImpuesto = null;
            try
            {
                objDocumentoImpuesto = objDocumentoImpuestoData.Find(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return objDocumentoImpuesto;
        }


        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo objDocumentoImpuesto
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesSeries]
        /// <summary>
        /// <param name="objDocumentoImpuesto"></param>
        /// <returns></returns>
        public ReturnValor InsertDocumentoImpuesto(BEDocumentoImpuesto objDocumentoImpuesto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objDocumentoImpuestoData.Insert(objDocumentoImpuesto);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Exitosa = true;
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                           objDocumentoImpuesto.segUsuarioEdita, objDocumentoImpuesto.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.ComprobantesImpuestos
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesImpuestos]
        /// <summary>
        /// <param name="prm_CodigoDocumento"></param>
        /// <param name="prm_codRegTipoImpuesto"></param>
        /// <returns></returns>
        public ReturnValor DeleteDocumentoImpuesto(int pcodEmpresa, int pcodDocumentoImpuesto, string pUserActual)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objDocumentoImpuestoData.Delete(pcodEmpresa, pcodDocumentoImpuesto);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                           pUserActual, pcodEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #endregion

        #region /* PROCESOS DE LA ENTIDAD : Comprobantes y ComprobantesSeries */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumentoSerie> ListDocumentoSeriePorUsuario(BaseFiltroDocumentoSerie pFiltro) 
        {
            List<BEDocumentoSerie> lstDocumentoSerie = new List<BEDocumentoSerie>();
            try
            {
                lstDocumentoSerie = oDocumentoSerieData.ListPorUsuario(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstDocumentoSerie;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="prm_CodigoTalonario"></param>
        /// <returns></returns>
        public ReturnValor UltimoNumeroDocumento(string pcodEmpresaRUC, int prm_codDocumentoSerie, 
                                                 string pUserActual, int pcodEmpresa)
        {
            string NumeroSerie;
            string NumeroDocumento;

            try
            {
                BEDocumentoSerie objDocumentoSerie = new BEDocumentoSerie();
                objDocumentoSerie = oDocumentoSerieData.Find(pcodEmpresaRUC, prm_codDocumentoSerie, true);
                if (objDocumentoSerie.CodigoComprobante != null)
                {
                    NumeroSerie = objDocumentoSerie.NumeroSerie.Trim().PadLeft(4, '0');
                    decimal UltimoAGenerar = objDocumentoSerie.UltimoEmitido + 1;
                    if (UltimoAGenerar > objDocumentoSerie.NumeroFinal)
                    {
                        oReturnValor.Exitosa = false;
                        oReturnValor.Message = HelpMessages.gc_DOCUMENTOS_SeriesUltimo;
                    }
                    else
                    {
                        NumeroDocumento = Convert.ToString(UltimoAGenerar).PadLeft(9, '0');
                        oReturnValor.CodigoRetorno = NumeroSerie + "-" + NumeroDocumento;
                        oReturnValor.Exitosa = true;
                    }
                }
                else
                    oReturnValor.Message = HelpMessages.gc_DOCUMENTOS_Series;
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                           pUserActual, pcodEmpresa.ToString());
            }
            return (oReturnValor);
        }

        #endregion
    }
} 

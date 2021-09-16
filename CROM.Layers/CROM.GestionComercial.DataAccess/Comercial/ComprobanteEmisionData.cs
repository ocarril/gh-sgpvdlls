namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.Reflection;
    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.Comercial.DTO;
    using CROM.Tools.Comun;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.ComprobanteEmisionData.cs]
    /// </summary>
    public class ComprobanteEmisionData
    {
        private string conexion = string.Empty;
        public ComprobanteEmisionData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ComprobanteEmision
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmision]
        /// <summary>
        /// <param name = >itemComprobanteEmision</param>
        public bool Insert(BEComprobanteEmision comprobanteEmision)
        {
            int? codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_I_DocumReg(
                       comprobanteEmision.codEmpresa,
                       comprobanteEmision.codEmpresaRUC,
                       ref codigoRetorno,
                       comprobanteEmision.CodigoPuntoVenta,
                       comprobanteEmision.CodigoComprobante,
                       comprobanteEmision.NumeroComprobante,
                       comprobanteEmision.CodigoArguEstadoDocu,
                       comprobanteEmision.CodigoArguDestinoComp,
                       comprobanteEmision.CodigoPersonaEntidad,
                       comprobanteEmision.codEmpleado,
                       comprobanteEmision.FechaDeEmision,
                       comprobanteEmision.FechaDeVencimiento,
                       comprobanteEmision.CodigoArguMoneda,
                       comprobanteEmision.ValorIGV,
                       comprobanteEmision.ValorTipoCambioVTA,
                       comprobanteEmision.ValorTipoCambioCMP,
                       comprobanteEmision.ValorTotalBruto,
                       comprobanteEmision.ValorTotalDescuento,
                       comprobanteEmision.ValorTotalVenta,
                       comprobanteEmision.ValorTotalImpuesto,
                       comprobanteEmision.ValorTotalPrecioVenta,
                       comprobanteEmision.ValorTotalPrecioExtran,
                       comprobanteEmision.CodigoArguMotivoGuia,
                       comprobanteEmision.CodigoPersonaTransporte,
                       comprobanteEmision.DireccioDePartida,
                       comprobanteEmision.TransporteMarca,
                       comprobanteEmision.TransportePlaca,
                       comprobanteEmision.TransporteConstancia,
                       comprobanteEmision.TransporteLicencia,

                       comprobanteEmision.CodigoComprobanteORIGEN,
                       comprobanteEmision.NumeroComprobanteORIGEN,
                       comprobanteEmision.FechaComprobanteORIGEN,
                       comprobanteEmision.ValorTipoCambioORIGEN,

                       comprobanteEmision.DocOrdenDeCompra,
                       comprobanteEmision.DocGuiaDeSalida,
                       comprobanteEmision.DocPedidoAdquisicion,
                       comprobanteEmision.DocLetrasCambio,
                       comprobanteEmision.EntidadRazonSocial,
                       comprobanteEmision.EntidadDireccion,
                       comprobanteEmision.EntidadNumeroRUC,
                       comprobanteEmision.CodigoArguTipoDomicil,
                       comprobanteEmision.Observaciones,
                       comprobanteEmision.codCondicionVenta,
                       comprobanteEmision.codCondicionCompra,
                       comprobanteEmision.CodigoComprobanteSecun,
                       comprobanteEmision.NumeroComprobanteSecun,
                       comprobanteEmision.CodigoPuntoVentaSecun,
                       comprobanteEmision.codEmpleadoVendedor,
                       comprobanteEmision.CodigoComprobanteFact,
                       comprobanteEmision.NumeroSerie,
                       comprobanteEmision.NumeroMinuta,
                       comprobanteEmision.CodigoArguDepositoDesti,
                       comprobanteEmision.NumeroComprobanteExt,
                       comprobanteEmision.DocEsGravado,
                       comprobanteEmision.DocExigeDocAnexo,
                       comprobanteEmision.DocEsFacturable,
                       comprobanteEmision.Estado,
                       comprobanteEmision.SegUsuarioCrea,
                       comprobanteEmision.Nota01,
                       comprobanteEmision.Nota02,
                       comprobanteEmision.Nota03,
                       comprobanteEmision.CodigoArguTipoDeOperacion,
                       comprobanteEmision.FechaDeEntrega,
                       comprobanteEmision.CodigoArguUbigeo,
                       comprobanteEmision.EntidadDireccionUbigeo,
                       comprobanteEmision.CodigoPersonaEntidadContacto,
                       comprobanteEmision.CodigoArguDepositoOrigen,
                       comprobanteEmision.indInternacional,
                       comprobanteEmision.perTributario,
                       comprobanteEmision.codRegTipoDomicilioTransporte,
                       comprobanteEmision.codRegUbigeoTransporte,
                       comprobanteEmision.desDireccionTransporte,
                       comprobanteEmision.desTotalCaja,
                       comprobanteEmision.desTotalPeso,
                       comprobanteEmision.indImprimeFirma,
                       comprobanteEmision.indImprimeSinIGV,
                       comprobanteEmision.codMotivoNCR,
                       comprobanteEmision.codMotivoNDB,
                       comprobanteEmision.gloMotivoSustento,
                       comprobanteEmision.sumOtrosCargos,
                       comprobanteEmision.sumTotalAnticipos,
                       comprobanteEmision.codRegTipoDocumentoEntidad,
                       comprobanteEmision.codPersonaDomicilio,
                       comprobanteEmision.codDocumentoEstado,
                       Convert.ToByte(comprobanteEmision.indOrigen),
                       comprobanteEmision.numDiasCredito,
                       comprobanteEmision.codDocumentoSerie,
                       comprobanteEmision.codDocumentoSerieOrigen,

                        comprobanteEmision.indAplicaDetraccion,
                        comprobanteEmision.codCuentaBancariaDetraccion,
                        comprobanteEmision.codBienDetraccion,
                        comprobanteEmision.codFormaDePagoDetraccion,
                        comprobanteEmision.prcDetraccion,
                        comprobanteEmision.mtoDetraccion,
                        comprobanteEmision.SegMaquina,

                        comprobanteEmision.codPersonaDomicilioTransportista,
                        comprobanteEmision.codPersonaDomicilioPartida,
                        comprobanteEmision.codModalidadTransporte,
                        comprobanteEmision.numContenedor,
                        comprobanteEmision.codPuerto,
                        comprobanteEmision.indTransbordoProgramado,
                        comprobanteEmision.codRegTipoDocumentoTransportista,
                        comprobanteEmision.fecInicioTraslado,

                        comprobanteEmision.codRegUnidadMedidaGlobal,
                        comprobanteEmision.desMotivoGuiaOtro

                       );
                    comprobanteEmision.codDocumReg = codigoRetorno.HasValue ? codigoRetorno.Value : 0;
                }
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Info, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, ex.StackTrace,
             comprobanteEmision.SegUsuarioEdita, comprobanteEmision.codEmpresa.ToString());

                throw ex;
            }
            return comprobanteEmision.codDocumReg > 0 ? true : false;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ComprobanteEmision
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmision]
        /// <summary>
        /// <param name = >itemComprobanteEmision</param>
        public bool Update(BEComprobanteEmision comprobanteEmision)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_DocumReg(
                        comprobanteEmision.codEmpresa,
                       comprobanteEmision.codEmpresaRUC,
                        comprobanteEmision.codDocumReg,
                        comprobanteEmision.CodigoPuntoVenta,
                        comprobanteEmision.CodigoComprobante,
                        comprobanteEmision.NumeroComprobante,
                        comprobanteEmision.CodigoArguEstadoDocu,
                        comprobanteEmision.CodigoArguDestinoComp,
                        comprobanteEmision.CodigoPersonaEntidad,
                        comprobanteEmision.codEmpleado,
                        comprobanteEmision.FechaDeEmision,
                        comprobanteEmision.FechaDeVencimiento,
                        comprobanteEmision.CodigoArguMoneda,
                        comprobanteEmision.ValorIGV,
                        comprobanteEmision.ValorTipoCambioVTA,
                        comprobanteEmision.ValorTipoCambioCMP,
                        comprobanteEmision.ValorTotalBruto,
                        comprobanteEmision.ValorTotalDescuento,
                        comprobanteEmision.ValorTotalVenta,
                        comprobanteEmision.ValorTotalImpuesto,

                        comprobanteEmision.ValorTotalPrecioVenta,
                        comprobanteEmision.ValorTotalPrecioExtran,
                        comprobanteEmision.CodigoArguMotivoGuia,
                        comprobanteEmision.CodigoPersonaTransporte,
                        comprobanteEmision.DireccioDePartida,
                        comprobanteEmision.TransporteMarca,
                        comprobanteEmision.TransportePlaca,
                        comprobanteEmision.TransporteConstancia,
                        comprobanteEmision.TransporteLicencia,
                        comprobanteEmision.CodigoComprobanteORIGEN,
                        comprobanteEmision.NumeroComprobanteORIGEN,
                        comprobanteEmision.FechaComprobanteORIGEN,
                        comprobanteEmision.ValorTipoCambioORIGEN,
                        comprobanteEmision.DocOrdenDeCompra,
                        comprobanteEmision.DocGuiaDeSalida,
                        comprobanteEmision.DocPedidoAdquisicion,
                        comprobanteEmision.DocLetrasCambio,
                        comprobanteEmision.EntidadRazonSocial,
                        comprobanteEmision.EntidadDireccion,
                        comprobanteEmision.EntidadNumeroRUC,

                        comprobanteEmision.CodigoArguTipoDomicil,
                        comprobanteEmision.Observaciones,
                        comprobanteEmision.codCondicionVenta,
                        comprobanteEmision.codCondicionCompra,
                        comprobanteEmision.CodigoComprobanteSecun,
                        comprobanteEmision.NumeroComprobanteSecun,
                        comprobanteEmision.CodigoPuntoVentaSecun,
                        comprobanteEmision.codEmpleadoVendedor,
                        comprobanteEmision.CodigoComprobanteFact,
                        comprobanteEmision.NumeroSerie,
                        comprobanteEmision.NumeroMinuta,
                        comprobanteEmision.CodigoArguDepositoDesti,
                        comprobanteEmision.NumeroComprobanteExt,
                        comprobanteEmision.DocEsGravado,
                        comprobanteEmision.DocExigeDocAnexo,
                        comprobanteEmision.DocEsFacturable,
                        comprobanteEmision.Estado,
                        comprobanteEmision.SegUsuarioEdita,
                        comprobanteEmision.Nota01,
                        comprobanteEmision.Nota02,

                        comprobanteEmision.Nota03,
                        comprobanteEmision.CodigoArguTipoDeOperacion,
                        comprobanteEmision.FechaDeEntrega,
                        comprobanteEmision.CodigoArguUbigeo,
                        comprobanteEmision.EntidadDireccionUbigeo,
                        comprobanteEmision.CodigoPersonaEntidadContacto,
                        comprobanteEmision.CodigoArguDepositoOrigen,
                        comprobanteEmision.indInternacional,
                        comprobanteEmision.perTributario,
                        comprobanteEmision.codRegTipoDomicilioTransporte,
                        comprobanteEmision.codRegUbigeoTransporte,
                        comprobanteEmision.desDireccionTransporte,
                        comprobanteEmision.desTotalCaja,
                        comprobanteEmision.desTotalPeso,
                        comprobanteEmision.indImprimeFirma,
                        comprobanteEmision.indImprimeSinIGV,
                        comprobanteEmision.codMotivoNCR,
                        comprobanteEmision.codMotivoNDB,
                        comprobanteEmision.gloMotivoSustento,
                        comprobanteEmision.sumOtrosCargos,

                        comprobanteEmision.sumTotalAnticipos,
                        comprobanteEmision.codRegTipoDocumentoEntidad,
                        comprobanteEmision.codPersonaDomicilio,
                        comprobanteEmision.codDocumentoEstado,
                        Convert.ToByte(comprobanteEmision.indOrigen),
                        comprobanteEmision.numDiasCredito,
                        comprobanteEmision.codDocumentoSerie,
                        comprobanteEmision.codDocumentoSerieOrigen,
                        comprobanteEmision.indAplicaDetraccion,
                        comprobanteEmision.codCuentaBancariaDetraccion,
                        comprobanteEmision.codBienDetraccion,
                        comprobanteEmision.codFormaDePagoDetraccion,
                        comprobanteEmision.prcDetraccion,
                        comprobanteEmision.mtoDetraccion,
                        comprobanteEmision.SegMaquina,
                        comprobanteEmision.codPersonaDomicilioTransportista,
                        comprobanteEmision.codPersonaDomicilioPartida,
                        comprobanteEmision.codModalidadTransporte,
                        comprobanteEmision.numContenedor,
                        comprobanteEmision.codPuerto,

                        comprobanteEmision.indTransbordoProgramado,
                        comprobanteEmision.codRegTipoDocumentoTransportista,
                        comprobanteEmision.fecInicioTraslado,
                        comprobanteEmision.codRegUnidadMedidaGlobal,
                        comprobanteEmision.desMotivoGuiaOtro
                    );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        /// <summary>
        /// ACTUALIZA el registro de una ENTIDAD de registro de Tipo ComprobanteEmision
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmision]
        /// SOLO EL DOCUMENTO DE REFERENCIA
        /// <summary>
        /// <param name = >itemComprobanteEmision</param>
        public bool UpdateRefAsigna(int prm_codDocumReg,
                                    string prm_CodigoComprobanteRefers, string prm_NumeroComprobanteRefers,
                                    string prm_SegUsuarioEdita, string prm_CodigoArguEstadoDocu, int? pcodMotivoNCR)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.usp_sgcfe_U_DocumReg_DocumentoRefersAsigna(prm_codDocumReg,
                                                                                     prm_CodigoComprobanteRefers,
                                                                                     prm_NumeroComprobanteRefers,
                                                                                     prm_SegUsuarioEdita,
                                                                                     prm_CodigoArguEstadoDocu,
                                                                                     pcodMotivoNCR);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public bool UpdateRefDesAsigna(int prm_codDocumReg, string prm_CodigoComprobanteRefers,
                                       string prm_NumeroComprobanteRefers, string prm_CodigoArguEstadoDocu,
                                       string prm_SegUsuarioEdita)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.usp_sgcfe_U_DocumReg_RefersDesAsigna(prm_codDocumReg, 
                                                                               prm_CodigoComprobanteRefers, 
                                                                               prm_NumeroComprobanteRefers, 
                                                                               prm_CodigoArguEstadoDocu, 
                                                                               prm_SegUsuarioEdita);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public bool UpdateAnulacion(int prm_codDocumReg, string prm_CodigoArguEstadoDocu,
                                    string prm_CodigoArguAnulacion, string prm_Observaciones,
                                    DateTime prm_FechaDeAnulacion, string prm_SegUsuarioEdita)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_DocumReg_Anulacion(prm_codDocumReg,
                                                                    prm_CodigoArguEstadoDocu,
                                                                    prm_CodigoArguAnulacion,
                                                                    prm_Observaciones,
                                                                    prm_FechaDeAnulacion,
                                                                    prm_SegUsuarioEdita);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public bool UpdateCancelacion(int prm_codDocumReg, string prm_CodigoArguEstadoDocu,
                                      string prm_Observaciones, DateTime prm_FechaDeCancelacion,
                                      string prm_CodigoParte, string prm_SegUsuarioEdita)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_DocumReg_Cancelar(prm_codDocumReg,
                                                                   prm_CodigoArguEstadoDocu,
                                                                   prm_Observaciones,
                                                                   prm_FechaDeCancelacion,
                                                                   prm_CodigoParte,
                                                                   prm_SegUsuarioEdita);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public bool UpdateCancelacionDeshacer(BaseFiltro pDatos)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_DocumReg_CancelarDeshacer(pDatos.codDocumReg,
                                                                           pDatos.codRegEstado,
                                                                           pDatos.gloObservacion,
                                                                           pDatos.segUsuarioEdita);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public bool UpdateEmitido(int prm_codDocumReg, string prm_CodigoArguEstadoDocu,
                                  string prm_Observaciones, string prm_SegUsuarioEdita)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_DocumReg_Emitido(
                              prm_codDocumReg
                            , prm_CodigoArguEstadoDocu
                            , prm_Observaciones
                            , prm_SegUsuarioEdita
                    );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public bool UpdateEmitidoDevolucion(BEComprobanteEmision documentoEmision)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_DocumReg_Devolucion(
                        documentoEmision.codDocumReg,
                        documentoEmision.CodigoArguMotivoGuia,
                        documentoEmision.CodigoArguEstadoDocu,
                        documentoEmision.Observaciones,
                        documentoEmision.SegUsuarioEdita
                    );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        //public bool UpdateAsignaGastoDeAduana(int? prm_codDocumReg, int prm_codGastoDeAduana,
        //                                      string prm_SegUsuarioEdita)
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            codigoRetorno = SQLDC.omgc_pro_Update_DocumentoMovCabecera_codGastoDeAduana(prm_codDocumReg, prm_codGastoDeAduana, prm_SegUsuarioEdita);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == 0 ? true : false;
        //}
        //public bool UpdateAsignaGastoDeAduanaDeshace(int? prm_codDocumReg, int? prm_codGastoDeAduana, string prm_SegUsuarioEdita)
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            codigoRetorno = SQLDC.omgc_pro_Update_DocumentoMovCabecera_codGastoDeAduanaDeshace(prm_codDocumReg, prm_codGastoDeAduana, prm_SegUsuarioEdita);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == 0 ? true : false;
        //}

        public bool UpdateAsignaLetrasEmitidas(int prm_codDocumReg, string prm_DocLetrasCambio, string prm_SegUsuarioEdita)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_DocumReg_DocLetrasCambio(prm_codDocumReg,
                                                                          prm_DocLetrasCambio,
                                                                          prm_SegUsuarioEdita);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        //public bool UpdateDocumentosParaPDT(BaseFiltro parametro)
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            codigoRetorno = SQLDC.omgc_U_DocumReg_DeclaracionSunat(parametro.codDocumReg, 
        //                                                                   parametro.codPerEntidad, 
        //                                                                   parametro.codRegEstado, 
        //                                                                   parametro.fecDeclaracion, 
        //                                                                   parametro.indLogicoFiltro, 
        //                                                                   parametro.segUsuarioEdita, 
        //                                                                   parametro.perTributario);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == 0 ? true : false;
        //}

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.ComprobanteEmision
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmision]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(int prm_codDocumReg)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_DocumReg(prm_codDocumReg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobanteEmision
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmision]
        /// <summary>
        /// <returns>List</returns>
        public List<BEComprobanteEmision> List(BaseFiltro pFiltro)
        {
            List<BEComprobanteEmision> lstComprobanteEmision = new List<BEComprobanteEmision>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    Nullable<DateTime> fechaNula = null;
                    var resul = SQLDC.omgc_S_DocumReg(pFiltro.codEmpresa, pFiltro.fecInicio, pFiltro.fecFinal, pFiltro.codPuntoVenta,
                                                      pFiltro.codDocumento, pFiltro.codRegEstado, pFiltro.codRegDestinoDocum, pFiltro.codPerEntidad,
                                                      pFiltro.codEmpleado, pFiltro.codRegMoneda, pFiltro.codParteDiario, pFiltro.codCondicionVenta,
                                                      pFiltro.codCondicionCompra, pFiltro.indEstado, pFiltro.codRegTipoOperacion,
                                                      pFiltro.indInternacional);
                    foreach (var item in resul)
                    {
                        lstComprobanteEmision.Add(new BEComprobanteEmision()
                        {
                            codDocumReg = item.codDocumReg,
                            codEmpresa = item.codEmpresa,
                            CodigoPersonaEmpreNombre = item.codEmpresaNombre,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
                            CodigoComprobante = item.CodigoComprobante,
                            NumeroComprobante = item.NumeroComprobante,
                            CodigoArguEstadoDocu = item.CodigoArguEstadoDocu,
                            CodigoArguEstadoDocuNombre = item.CodigoArguEstadoDocuNombre,
                            CodigoArguDestinoComp = item.CodigoArguDestinoComp,
                            CodigoArguDestinoCompNombre = item.CodigoArguDestinoCompNombre,
                            CodigoPersonaEntidad = item.CodigoPersonaEntidad,
                            codEmpleado = item.codEmpleado,
                            auxcodEmpleadoNombre = item.codEmpleadoNombre,
                            FechaDeEmision = item.FechaDeEmision,
                            FechaDeVencimiento = item.EntidadRazonSocial == null ? fechaNula : item.FechaDeVencimiento,
                            FechaDeProceso = item.FechaDeProceso,
                            FechaDeCancelacion = item.FechaDeCancelacion,
                            FechaDeAnulacion = item.FechaDeAnulacion,
                            CodigoArguMoneda = item.CodigoArguMoneda,
                            CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            ValorIGV = item.ValorIGV,
                            ValorTipoCambioVTA = item.ValorTipoCambioVTA,
                            ValorTipoCambioCMP = item.ValorTipoCambioCMP,
                            ValorTotalBruto = item.ValorTotalBruto,
                            ValorTotalDescuento = item.ValorTotalDescuento,
                            ValorTotalVenta = item.ValorTotalVenta,
                            ValorTotalImpuesto = item.ValorTotalImpuesto,
                            ValorTotalPrecioVenta = item.ValorTotalPrecioVenta,
                            ValorTotalPrecioExtran = item.ValorTotalPrecioExtran,
                            CodigoArguMotivoGuia = item.CodigoArguMotivoGuia,
                            CodigoArguMotivoGuiaNombre = item.CodigoArguMotivoGuiaNombre,
                            CodigoPersonaTransporteNombre = item.CodigoPersonaTransporteNombre,
                            DireccioDePartida = item.DireccioDePartida,
                            TransporteMarca = item.TransporteMarca,
                            TransportePlaca = item.TransportePlaca,
                            TransporteConstancia = item.TransporteConstancia,
                            TransporteLicencia = item.TransporteLicencia,
                            CodigoArguAnulacion = item.CodigoArguAnulacion,
                            CodigoArguAnulacionNombre = item.CodigoArguAnulacionNombre,

                            CodigoComprobanteORIGEN = item.CodigoComprobanteORIGEN,
                            CodigoComprobanteORIGENNombre = item.CodigoComprobanteORIGENNombre,
                            NumeroComprobanteORIGEN = ObtenerNumeroAbreviado(item.NumeroComprobanteORIGEN),
                            CodigoComprobanteDESTINO = item.CodigoComprobanteDESTINO,
                            CodigoComprobanteDESTINONombre = item.CodigoComprobanteDESTINONombre,
                            NumeroComprobanteDESTINO = item.NumeroComprobanteDESTINO,
                            CodigoComprobanteNCR = item.CodigoComprobanteNCR,
                            NumeroComprobanteNCR = item.NumeroComprobanteNCR,
                            CodigoComprobanteNDB = item.CodigoComprobanteNDB,
                            NumeroComprobanteNDB = item.NumeroComprobanteNDB,
                            ValorTipoCambioORIGEN = item.ValorTipoCambioORIGEN == null ? 0 : item.ValorTipoCambioORIGEN.Value,
                            FechaComprobanteORIGEN = item.FechaComprobanteORIGEN,

                            DocOrdenDeCompra = item.DocOrdenDeCompra,
                            DocGuiaDeSalida = item.DocGuiaDeSalida,
                            DocPedidoAdquisicion = item.DocPedidoAdquisicion,
                            DocLetrasCambio = item.DocLetrasCambio,

                            EntidadRazonSocial = item.EntidadRazonSocial == null ? string.Empty : item.EntidadRazonSocial,
                            EntidadDireccion = item.EntidadDireccion == null ? string.Empty : item.EntidadDireccion,
                            EntidadNumeroRUC = item.EntidadNumeroRUC == null ? string.Empty : item.EntidadNumeroRUC,
                            CodigoArguTipoDomicil = item.CodigoArguTipoDomicil == null ? string.Empty : item.CodigoArguTipoDomicil,
                            CodigoArguTipoDomicilNombre = item.CodigoArguTipoDomicilNombre == null ? string.Empty : item.CodigoArguTipoDomicilNombre,

                            CodigoParte = item.CodigoParte,
                            Observaciones = item.Observaciones,
                            codCondicionVenta = item.codCondicionVenta,
                            codCondicionCompra = item.codCondicionVenta,
                            CodigoComprobanteSecun = item.CodigoComprobanteSecun,
                            NumeroComprobanteSecun = item.NumeroComprobanteSecun,
                            CodigoPuntoVentaSecun = item.CodigoPuntoVentaSecun,
                            CodigoPuntoVentaSecunNombre = item.CodigoPuntoVentaNombre,
                            codEmpleadoVendedor = item.codEmpleadoVendedor,
                            auxcodEmpleadoVendedorNombre = item.codEmpleadoVendedorNombre,
                            CodigoComprobanteFact = item.CodigoComprobanteFact,
                            NumeroSerie = item.NumeroSerie,
                            NumeroMinuta = item.NumeroMinuta,
                            CodigoRegistroUnico = item.CodigoRegistroUnico,
                            CodigoArguDepositoDesti = item.CodigoArguDepositoDesti,
                            NumeroComprobanteExt = item.NumeroComprobanteExt,
                            DocEsGravado = item.DocEsGravado,
                            DocExigeDocAnexo = item.DocExigeDocAnexo,
                            DocEsFacturable = item.DocEsFacturable,
                            SegAnio = item.SegAnio,
                            SegMes = item.SegMes,
                            SegDia = item.SegDia,
                            Estado = item.Estado,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaCrea = item.SegFechaCrea,
                            SegFechaEdita = item.SegFechaEdita,
                            SegMaquina = item.SegMaquina,
                            Nota01 = item.Nota01,
                            Nota02 = item.Nota02,
                            Nota03 = item.Nota03,
                            CodigoArguTipoDeOperacion = item.CodigoArguTipoDeOperacion,
                            CodigoArguTipoDeOperacionNombre = item.CodigoArguTipoDeOperacionNombre,
                            CodigoComprobanteNombre = item.CodigoComprobanteNombre,
                            FechaDeEntrega = item.FechaDeEntrega,
                            FechaDeRecibido = item.FechaDeRecibido,
                            CodigoArguUbigeo = item.CodigoArguUbigeo,
                            EntidadDireccionUbigeo = item.EntidadDireccionUbigeo,
                            CodigoPersonaEntidadContacto = item.CodigoPersonaContacto,
                            CodigoPersonaEntidadContactoNombre = item.CodigoPersonaContactoNombre,
                            CodigoPersonaTransporte = item.CodigoPersonaTransporte,
                            CodigoPersonaEntidadNombre = item.CodigoPersonaEntidadNombre,
                            CondicionCompraNombre = item.CondicionCompraNombre,
                            CondicionVentaNombre = item.CondicionVentaNombre,
                            FechaDeDeclaracion = item.FechaDeDeclaracion,
                            CodigoArguDepositoOrigen = item.CodigoArguDepositoOrigen,
                            CodigoArguDepositoOrigenNombre = item.CodigoArguDepositoOrigenNombre,
                            indInternacional = item.indInternacional,
                            perTributario = item.perTributario,
                            codGastoDeAduana = item.codGastoDeAduana,
                            codRegTipoDomicilioTransporte = item.codRegTipoDomicilioTransporte,
                            codRegUbigeoTransporte = item.codRegUbigeoTransporte,
                            auxcodRegTipoDomicilioTransporteNombre = item.codRegTipoDomicilioTransporteNombre,
                            auxcodRegUbigeoTransporteNombre = item.codRegUbigeoTransporteNombre,
                            desDireccionTransporte = item.desDireccionTransporte,
                            desTotalCaja = item.desTotalCaja,
                            desTotalPeso = item.desTotalPeso,
                            desMotivoGuiaOtro = item.desMotivoGuiaOtro
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstComprobanteEmision;
        }

        //public List<BEComprobanteEmision> ListGeneral(BaseFiltro pFiltro)
        //{
        //    List<BEComprobanteEmision> lstComprobanteEmision = new List<BEComprobanteEmision>();
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            Nullable<DateTime> fechaNula = null;
        //            var resul = SQLDC.omgc_S_DocumReg_General(pFiltro.codEmpresa, pFiltro.fecInicio, pFiltro.fecFinal, pFiltro.codPuntoVenta,
        //                                                      pFiltro.codDocumento, pFiltro.codRegEstado, pFiltro.codRegDestinoDocum, pFiltro.codPerEntidad,
        //                                                      pFiltro.codEmpleado, pFiltro.codRegMoneda, pFiltro.codParteDiario, pFiltro.codCondicionVenta,
        //                                                      pFiltro.codCondicionCompra, pFiltro.indEstado, pFiltro.codRegTipoOperacion, pFiltro.desNombre,
        //                                                      pFiltro.gloDescripcion, pFiltro.indInternacional);
        //            foreach (var item in resul)
        //            {
        //                lstComprobanteEmision.Add(new BEComprobanteEmision()
        //                {
        //                    codDocumReg = item.codDocumReg,
        //                    codEmpresa = item.codEmpresa,
        //                    CodigoPersonaEmpreNombre = item.codEmpresaNombre,
        //                    CodigoPuntoVenta = item.CodigoPuntoVenta,
        //                    CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
        //                    CodigoComprobante = item.CodigoComprobante,
        //                    NumeroComprobante = item.NumeroComprobante,
        //                    CodigoArguEstadoDocu = item.CodigoArguEstadoDocu,
        //                    CodigoArguEstadoDocuNombre = item.CodigoArguEstadoDocuNombre,
        //                    CodigoArguDestinoComp = item.CodigoArguDestinoComp,
        //                    CodigoArguDestinoCompNombre = item.CodigoArguDestinoCompNombre,
        //                    CodigoPersonaEntidad = item.CodigoPersonaEntidad,
        //                    codEmpleado = item.codEmpleado,
        //                    auxcodEmpleadoNombre = item.codEmpleadoNombre,
        //                    FechaDeEmision = item.FechaDeEmision,
        //                    FechaDeVencimiento = item.EntidadRazonSocial == null ? fechaNula : item.FechaDeVencimiento,
        //                    FechaDeProceso = item.FechaDeProceso,
        //                    FechaDeCancelacion = item.FechaDeCancelacion,
        //                    FechaDeAnulacion = item.FechaDeAnulacion,
        //                    CodigoArguMoneda = item.CodigoArguMoneda,
        //                    CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
        //                    ValorIGV = item.ValorIGV,
        //                    ValorTipoCambioVTA = item.ValorTipoCambioVTA,
        //                    ValorTipoCambioCMP = item.ValorTipoCambioCMP,
        //                    ValorTotalBruto = item.ValorTotalBruto,
        //                    ValorTotalDescuento = item.ValorTotalDescuento,
        //                    ValorTotalVenta = item.ValorTotalVenta,
        //                    ValorTotalImpuesto = item.ValorTotalImpuesto,
        //                    ValorTotalPrecioVenta = item.ValorTotalPrecioVenta,
        //                    ValorTotalPrecioExtran = item.ValorTotalPrecioExtran,
        //                    CodigoArguMotivoGuia = item.CodigoArguMotivoGuia,
        //                    CodigoArguMotivoGuiaNombre = item.CodigoArguMotivoGuiaNombre,
        //                    CodigoPersonaTransporteNombre = item.CodigoPersonaTransporteNombre,
        //                    DireccioDePartida = item.DireccioDePartida,
        //                    TransporteMarca = item.TransporteMarca,
        //                    TransportePlaca = item.TransportePlaca,
        //                    TransporteConstancia = item.TransporteConstancia,
        //                    TransporteLicencia = item.TransporteLicencia,
        //                    CodigoArguAnulacion = item.CodigoArguAnulacion,
        //                    CodigoArguAnulacionNombre = item.CodigoArguAnulacionNombre,
        //                    NumeroComprobanteDESTINO = item.NumeroComprobanteDESTINO,
        //                    NumeroComprobanteORIGEN = item.NumeroComprobanteORIGEN,
        //                    NumeroComprobanteNCR = item.NumeroComprobanteNCR,
        //                    NumeroComprobanteNDB = item.NumeroComprobanteNDB,
        //                    DocOrdenDeCompra = item.DocOrdenDeCompra,
        //                    DocGuiaDeSalida = item.DocGuiaDeSalida,
        //                    DocPedidoAdquisicion = item.DocPedidoAdquisicion,
        //                    DocLetrasCambio = item.DocLetrasCambio,

        //                    EntidadRazonSocial = item.EntidadRazonSocial == null ? string.Empty : item.EntidadRazonSocial,
        //                    EntidadDireccion = item.EntidadDireccion == null ? string.Empty : item.EntidadDireccion,
        //                    EntidadNumeroRUC = item.EntidadNumeroRUC == null ? string.Empty : item.EntidadNumeroRUC,
        //                    CodigoArguTipoDomicil = item.CodigoArguTipoDomicil == null ? string.Empty : item.CodigoArguTipoDomicil,
        //                    CodigoArguTipoDomicilNombre = item.CodigoArguTipoDomicilNombre == null ? string.Empty : item.CodigoArguTipoDomicilNombre,

        //                    CodigoParte = item.CodigoParte,
        //                    Observaciones = item.Observaciones,
        //                    codCondicionVenta = item.codCondicionVenta,
        //                    codCondicionCompra = item.codCondicionCompra,
        //                    CodigoComprobanteSecun = item.CodigoComprobanteSecun,
        //                    NumeroComprobanteSecun = item.NumeroComprobanteSecun,
        //                    CodigoPuntoVentaSecun = item.CodigoPuntoVentaSecun,
        //                    codEmpleadoVendedor = item.codEmpleadoVendedor,
        //                    auxcodEmpleadoVendedorNombre = item.codEmpleadoVendedorNombre,
        //                    CodigoComprobanteFact = item.CodigoComprobanteFact,
        //                    NumeroSerie = item.NumeroSerie,
        //                    NumeroMinuta = item.NumeroMinuta,
        //                    CodigoRegistroUnico = item.CodigoRegistroUnico,
        //                    CodigoArguDepositoDesti = item.CodigoArguDepositoDesti,
        //                    NumeroComprobanteExt = item.NumeroComprobanteExt,
        //                    DocEsGravado = item.DocEsGravado,
        //                    DocExigeDocAnexo = item.DocExigeDocAnexo,
        //                    DocEsFacturable = item.DocEsFacturable,
        //                    SegAnio = item.SegAnio,
        //                    SegMes = item.SegMes,
        //                    SegDia = item.SegDia,
        //                    Estado = item.Estado,
        //                    SegUsuarioCrea = item.SegUsuarioCrea,
        //                    SegUsuarioEdita = item.SegUsuarioEdita,
        //                    SegFechaCrea = item.SegFechaCrea,
        //                    SegFechaEdita = item.SegFechaEdita,
        //                    SegMaquina = item.SegMaquina,
        //                    CodigoComprobanteDESTINO = item.CodigoComprobanteDESTINO,
        //                    CodigoComprobanteNCR = item.CodigoComprobanteNCR,
        //                    CodigoComprobanteNDB = item.CodigoComprobanteNDB,
        //                    CodigoComprobanteORIGEN = item.NumeroComprobanteORIGEN,
        //                    Nota01 = item.Nota01,
        //                    Nota02 = item.Nota02,
        //                    Nota03 = item.Nota03,
        //                    CodigoArguTipoDeOperacion = item.CodigoArguTipoDeOperacion,
        //                    CodigoArguTipoDeOperacionNombre = item.CodigoArguTipoDeOperacionNombre,
        //                    CodigoComprobanteNombre = item.CodigoComprobanteNombre,
        //                    FechaDeEntrega = item.FechaDeEntrega,
        //                    FechaDeRecibido = item.FechaDeRecibido,
        //                    CodigoArguUbigeo = item.CodigoArguUbigeo,
        //                    EntidadDireccionUbigeo = item.EntidadDireccionUbigeo,
        //                    CodigoPersonaEntidadContacto = item.CodigoPersonaContacto,
        //                    CodigoPersonaEntidadContactoNombre = item.CodigoPersonaContactoNombre,
        //                    CodigoPersonaTransporte = item.CodigoPersonaTransporte,
        //                    CodigoPersonaEntidadNombre = item.CodigoPersonaEntidadNombre,
        //                    CondicionCompraNombre = item.CondicionCompraNombre,
        //                    CondicionVentaNombre = item.CondicionVentaNombre,
        //                    FechaDeDeclaracion = item.FechaDeDeclaracion,
        //                    REF_TotalItems = item.TotalItems == null ? 0 : Convert.ToInt32(item.TotalItems),
        //                    REF_TotalLetras = item.TotalLetras == null ? 0 : Convert.ToInt32(item.TotalLetras),
        //                    codRegTipoDomicilioTransporte = item.codRegTipoDomicilioTransporte,
        //                    codRegUbigeoTransporte = item.codRegUbigeoTransporte,
        //                    auxcodRegTipoDomicilioTransporteNombre = item.codRegTipoDomicilioTransporteNombre,
        //                    auxcodRegUbigeoTransporteNombre = item.codRegUbigeoTransporteNombre,
        //                    desDireccionTransporte = item.desDireccionTransporte,
        //                    desTotalCaja = item.desTotalCaja,
        //                    desTotalPeso = item.desTotalPeso
        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstComprobanteEmision;
        //}

        public List<vwComprobanteEmision> ListEmision(BaseFiltro pFiltro)
        {
            List<vwComprobanteEmision> lstComprobanteEmision = new List<vwComprobanteEmision>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumReg_Emitidos(pFiltro.codEmpresa, pFiltro.fecInicio, 
                                                               pFiltro.fecFinal, 
                                                               pFiltro.codPuntoVenta,
                                                               pFiltro.codDocumento, pFiltro.codRegEstado, 
                                                               pFiltro.codRegDestinoDocum, pFiltro.codPerEntidad,
                                                               pFiltro.codEmpleado, pFiltro.codRegMoneda, 
                                                               pFiltro.codParteDiario, pFiltro.codCondicionVenta,
                                                               pFiltro.codCondicionCompra, pFiltro.indEstado, 
                                                               pFiltro.codRegTipoOperacion, pFiltro.desNombre,
                                                               pFiltro.gloDescripcion, pFiltro.indInternacional);
                    foreach (var item in resul)
                    {
                        lstComprobanteEmision.Add(new vwComprobanteEmision()
                        {
                            codDocumReg = item.codDocumReg,
                            CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
                            NumeroComprobante = item.NumeroComprobante,
                            CodigoArguEstadoDocuNombre = item.CodigoArguEstadoDocuNombre,
                            CodigoPersonaEmpleadoNombre = item.codEmpleadoNombre,
                            CodigoArguDestinoCompNombre = item.CodigoArguDestinoCompNombre,
                            FechaDeEmision = item.FechaDeEmision,
                            CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            ValorTipoCambioVTA = item.ValorTipoCambioVTA,
                            ValorTipoCambioCMP = item.ValorTipoCambioCMP,
                            ValorTotalBruto = item.ValorTotalBruto,
                            ValorTotalDescuento = item.ValorTotalDescuento,
                            ValorTotalVenta = item.ValorTotalVenta,
                            ValorTotalImpuesto = item.ValorTotalImpuesto,
                            ValorTotalPrecioVenta = item.ValorTotalPrecioVenta,
                            ValorTotalPrecioExtran = item.ValorTotalPrecioExtran,
                            NumeroComprobanteDESTINO = item.NumeroComprobanteDESTINO,
                            NumeroComprobanteORIGEN = item.NumeroComprobanteORIGEN,
                            EntidadRazonSocial = item.EntidadRazonSocial,
                            EntidadNumeroRUC = item.EntidadNumeroRUC,
                            CodigoArguTipoDomicilNombre = item.codRegTipoDomicilNombre,
                            CodigoComprobanteORIGEN = item.NumeroComprobanteORIGEN,
                            CodigoArguTipoDeOperacionNombre = item.CodigoArguTipoDeOperacionNombre,
                            CodigoComprobanteNombre = item.CodigoComprobanteNombre,
                            EntidadDireccionUbigeo = item.EntidadDireccionUbigeo,
                            REF_TotalItems = item.TotalItems == null ? 0 : Convert.ToInt32(item.TotalItems),
                            REF_TotalLetras = item.TotalLetras == null ? 0 : Convert.ToInt32(item.TotalLetras),
                            auxDescripcionDetalle = item.Descripcion
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstComprobanteEmision;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.ComprobanteEmision
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmision]
        /// <summary>
        /// <param name="prm_codDocumReg"></param>
        /// <returns></returns>
        public BEComprobanteEmision Find(int pcodEmpresa, int? prm_codDocumReg)
        {
            BEComprobanteEmision comprobanteEmision = new BEComprobanteEmision();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    Nullable<DateTime> fechaNula = null;
                    var resul = SQLDC.omgc_S_DocumReg_Id(pcodEmpresa, prm_codDocumReg);
                    foreach (var item in resul)
                    {
                        comprobanteEmision = new BEComprobanteEmision()
                        {
                            codDocumReg = item.codDocumReg,
                            codEmpresa = item.codEmpresa,
                            CodigoPersonaEmpreNombre = string.Empty,
                            CodigoPuntoVenta = item.codPuntoDeVenta,
                            CodigoPuntoVentaNombre = item.codPuntoDeVentaNombre,
                            CodigoComprobante = item.codDocumento,
                            NumeroComprobante = item.numDocumento,
                            CodigoArguEstadoDocu = item.codRegEstado,
                            CodigoArguEstadoDocuNombre = item.codRegEstadoNombre,
                            CodigoArguDestinoComp = item.codRegDestinoDocum,
                            CodigoArguDestinoCompNombre = item.codRegDestinoDocumNombre,
                            CodigoPersonaEntidad = item.codPersonaEntidad,
                            codEmpleado = item.codEmpleado,
                            auxcodEmpleadoNombre = item.codEmpleadoNombre,

                            FechaDeEmision = item.fecEmision,
                            FechaDeVencimiento = item.fecVencimiento,
                            FechaDeProceso = item.fecProceso,
                            FechaDeCancelacion = item.fecCancelacion,
                            FechaDeAnulacion = item.fecAnulacion == null ? fechaNula : item.fecAnulacion,
                            CodigoArguMoneda = item.codRegMoneda,
                            CodigoArguMonedaNombre = item.codRegMonedaNombre,

                            ValorIGV = item.prcIGV,
                            ValorTipoCambioVTA = item.monTipoCambioVTA,
                            ValorTipoCambioCMP = item.monTipoCambioCMP,
                            ValorTotalBruto = item.sumTotBruto,
                            ValorTotalDescuento = item.sumDescTotal,
                            ValorTotalVenta = item.sumTotValVenta,
                            ValorTotalImpuesto = item.sumTotTributos,
                            ValorTotalPrecioVenta = item.sumPrecioVenta,
                            ValorTotalPrecioExtran = item.sumPrecioVentaExtran,

                            sumOtrosCargos = item.sumOtrosCargos,
                            sumTotalAnticipos = item.sumTotalAnticipos,
                            sumImpVenta = item.sumImpVenta,
                            flagParaEnvioSUNAT = item.flagParaEnvioSUNAT,
                            flagEnviadoSUNAT = item.flagEnviadoSUNAT,
                            fecEnviadoSUNAT = item.fecEnviadoSUNAT,
                            fecParaEnvioSUNAT = item.fecParaEnvioSUNAT,
                            segUsuarioParaEnvioSUNAT = item.segUsuarioParaEnvioSUNAT,
                            segUsuarioEnviadoSUNAT = item.segUsuarioEnviadoSUNAT,
                            codMotivoNCR = item.codMotivoNCR,
                            codMotivoNDB = item.codMotivoNDB,
                            gloMotivoSustento = item.gloMotivoSustento,
                            codRegTipoDocumentoEntidad = item.codRegTipoDocumentoEntidad,
                            codPersonaDomicilio = item.codPersonaDomicilio,

                            CodigoArguMotivoGuia = item.codRegMotivoGuia,
                            CodigoArguMotivoGuiaNombre = item.codRegMotivoGuiaNombre,
                            CodigoPersonaTransporteNombre = item.codPersonaTransporteNombre,
                            DireccioDePartida = item.gloDireccioDePartida,
                            TransporteMarca = item.desTransporteMarca == null ? string.Empty : item.desTransporteMarca,
                            TransportePlaca = item.desTransportePlaca == null ? string.Empty : item.desTransportePlaca,
                            TransporteConstancia = item.desTransporteConstancia == null ? string.Empty : item.desTransporteConstancia,
                            TransporteLicencia = item.desTransporteLicencia == null ? string.Empty : item.desTransporteLicencia,
                            CodigoArguAnulacion = item.codRegAnulacion,
                            CodigoArguAnulacionNombre = item.codRegAnulacionNombre,

                            CodigoComprobanteORIGEN = item.codDocumentoOrigen,
                            CodigoComprobanteORIGENNombre = item.codDocumentoOrigenNombre,
                            NumeroComprobanteORIGEN = item.numDocumentoOrigen,
                            FechaComprobanteORIGEN = item.fecDocumentoOrigen,
                            ValorTipoCambioORIGEN = item.monTipoCambioOrigen == null ? 0 : item.monTipoCambioOrigen.Value,
                            CodigoComprobanteDESTINO = item.codDocumentoDestino,
                            CodigoComprobanteDESTINONombre = item.codDocumentoDestinoNombre,
                            NumeroComprobanteDESTINO = item.numDocumentoDestino,
                            CodigoComprobanteNCR = item.codDocumentoNCR,
                            NumeroComprobanteNCR = item.numDocumentoNCR,
                            CodigoComprobanteNDB = item.codDocumentoNDB,
                            NumeroComprobanteNDB = item.numDocumentoNDB,

                            DocOrdenDeCompra = item.numOrdenDeCompra,
                            DocGuiaDeSalida = item.numGuiaDeSalida,
                            DocPedidoAdquisicion = item.numPedidoAdquisicion,
                            DocLetrasCambio = item.numLetrasCambio,
                            EntidadRazonSocial = item.nomEntidadRazonSocial == null ? string.Empty : item.nomEntidadRazonSocial,
                            EntidadDireccion = item.nomEntidadDireccion == null ? string.Empty : item.nomEntidadDireccion,
                            EntidadNumeroRUC = item.nomEntidadNumeroRUC == null ? string.Empty : item.nomEntidadNumeroRUC,
                            CodigoArguTipoDomicil = item.codRegTipoDomicilio == null ? string.Empty : item.codRegTipoDomicilio,
                            CodigoArguTipoDomicilNombre = item.codRegTipoDomicilioNombre == null ?
                                                          string.Empty : item.codRegTipoDomicilioNombre,
                            CodigoParte = item.codParte,
                            Observaciones = item.gloObservaciones,
                            codCondicionVenta = item.codCondicionVenta,
                            codCondicionCompra = item.codCondicionCompra,
                            CodigoComprobanteSecun = item.codDocumentoSecun,
                            NumeroComprobanteSecun = item.numDocumentoSecun,
                            CodigoPuntoVentaSecun = item.codPuntoVentaSecun,
                            codEmpleadoVendedor = item.codEmpleadoVendedor,
                            auxcodEmpleadoVendedorNombre = item.codEmpleadoVendedorNombre,
                            CodigoComprobanteFact = item.codDocumentoFact,
                            NumeroSerie = item.numSerie,
                            NumeroMinuta = item.numMinuta,
                            CodigoRegistroUnico = item.codRegistroUnico,
                            CodigoArguDepositoDesti = item.codDepositoDestino,
                            NumeroComprobanteExt = item.numDocumentoExterno,
                            DocEsGravado = item.indDocEsGravado,
                            DocExigeDocAnexo = item.indDocExigeDocAnexo,
                            DocEsFacturable = item.indDocEsFacturable,
                            SegAnio = item.segAnio,
                            SegMes = item.segMes,
                            SegDia = item.segDia,
                            Estado = item.indActivo,
                            SegUsuarioCrea = item.segUsuarioCrea,
                            SegUsuarioEdita = item.segUsuarioEdita,
                            SegFechaCrea = item.segFechaCrea,
                            SegFechaEdita = item.segFechaEdita,
                            SegMaquina = item.segMaquinaEdita,
                            Nota01 = item.desNota01,
                            Nota02 = item.desNota02,
                            Nota03 = item.desNota03,
                            CodigoArguTipoDeOperacion = item.codRegTipoDeOperacion,
                            CodigoArguTipoDeOperacionNombre = item.codRegTipoDeOperacionNombre,
                            CodigoComprobanteNombre = item.codDocumentoNombre,
                            FechaDeEntrega = item.fecDeEntrega,
                            FechaDeRecibido = item.fecDeRecibido,
                            CodigoArguUbigeo = item.codUbigeo,
                            EntidadDireccionUbigeo = item.desEntidadDireccionUbigeo,
                            CodigoPersonaEntidadContacto = item.codPersonaContacto,
                            CodigoPersonaEntidadContactoNombre = item.codPersonaContactoNombre,
                            CodigoPersonaTransporte = item.codPersonaTransporte,
                            CodigoPersonaEntidadNombre = item.codPersonaEntidadNombre,
                            CodigoPersonaTransporteRUC = item.codPersonaTransporteRUC,
                            CondicionCompraNombre = item.codCondicionCompraNombre,
                            CondicionVentaNombre = item.codCondicionVentaNombre,
                            FechaDeDeclaracion = item.fecDeDeclaracion,
                            indInternacional = item.indInternacional,
                            perTributario = item.perTributario,
                            CodigoArguDepositoOrigen = item.codDepositoOrigen,
                            CodigoArguDepositoOrigenNombre = item.codDepositoOrigenNombre,
                            CodigoArguDepositoDestiNombre = item.codDepositoDestinoNombre,
                            codGastoDeAduana = item.codGastoDeAduana,
                            codRegTipoDomicilioTransporte = item.codRegTipoDomicilioTransporte,
                            codRegUbigeoTransporte = item.codRegUbigeoTransporte,
                            auxcodRegTipoDomicilioTransporteNombre = item.codRegTipoDomicilioTransporteNombre,
                            auxcodRegUbigeoTransporteNombre = item.codRegUbigeoTransporteNombre,
                            desDireccionTransporte = item.desDireccionTransporte,
                            desTotalCaja = item.desTotalCaja,
                            desTotalPeso = item.desTotalPeso,
                            auxcodRegTipoEntidad = item.codRegTipoEntidad == null ? string.Empty : item.codRegTipoEntidad,
                            auxcodRegTipoEntidadNombre = item.codRegTipoEntidadNombre == null ? string.Empty : item.codRegTipoEntidadNombre,
                            indImprimeFirma = item.indImprimeFirma.HasValue ? item.indImprimeFirma.Value : false,
                            indImprimeSinIGV = item.indImprimeSinIGV.HasValue ? item.indImprimeSinIGV.Value : false,

                            codModalidadTransporte = item.codModalidadTransporte,
                            codPersonaDomicilioPartida = item.codPersonaDomicilioPartida,
                            codPersonaDomicilioTransportista = item.codPersonaDomicilioTransportista,
                            numContenedor = item.numContenedor,
                            codPuerto = item.codPuerto,
                            indTransbordoProgramado = item.indTransbordoProgramado,
                            codRegTipoDocumentoTransportista = item.codRegTipoDocumentoTransportista,
                            fecInicioTraslado = item.fecInicioTraslado,
                            desMotivoGuiaOtro = item.desMotivoGuiaOtro
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return comprobanteEmision;
        }

        public BEComprobanteEmision FindPrint(int pcodEmpresa, int? prm_codDocumReg, string pcodEmpresaRUC)
        {
            BEComprobanteEmision comprobanteEmision = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    Nullable<DateTime> fechaNula = null;
                    var resul = SQLDC.omgc_S_DocumReg_IdPrint(pcodEmpresa, prm_codDocumReg, pcodEmpresaRUC);
                    foreach (var item in resul)
                    {
                        comprobanteEmision = new BEComprobanteEmision()
                        {
                            codDocumReg = item.codDocumReg,
                            codEmpresa = item.codEmpresa,
                            CodigoPersonaEmpreNombre = item.codEmpresaNombre,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
                            CodigoComprobante = item.CodigoComprobante,
                            NumeroComprobante = item.NumeroComprobante,
                            CodigoArguEstadoDocu = item.CodigoArguEstadoDocu,
                            CodigoArguEstadoDocuNombre = item.CodigoArguEstadoDocuNombre,
                            CodigoArguDestinoComp = item.CodigoArguDestinoComp,
                            CodigoArguDestinoCompNombre = item.CodigoArguDestinoCompNombre,
                            CodigoPersonaEntidad = item.CodigoPersonaEntidad,
                            codEmpleado = item.codEmpleado,
                            auxcodEmpleadoNombre = item.codEmpleadoNombre,

                            FechaDeEmision = item.FechaDeEmision,
                            FechaDeVencimiento = item.FechaDeVencimiento,
                            FechaDeProceso = item.FechaDeProceso,
                            FechaDeCancelacion = item.FechaDeCancelacion,
                            FechaDeAnulacion = item.EntidadRazonSocial == null ? fechaNula : item.FechaDeAnulacion,
                            CodigoArguMoneda = item.CodigoArguMoneda,
                            CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            ValorIGV = item.ValorIGV,
                            ValorTipoCambioVTA = item.ValorTipoCambioVTA,
                            ValorTipoCambioCMP = item.ValorTipoCambioCMP,
                            ValorTotalBruto = item.ValorTotalBruto,
                            ValorTotalDescuento = item.ValorTotalDescuento,
                            ValorTotalVenta = item.ValorTotalVenta,
                            ValorTotalImpuesto = item.ValorTotalImpuesto,
                            ValorTotalPrecioVenta = item.ValorTotalPrecioVenta,
                            ValorTotalPrecioExtran = item.ValorTotalPrecioExtran,
                            CodigoArguMotivoGuia = item.CodigoArguMotivoGuia,
                            CodigoArguMotivoGuiaNombre = item.CodigoArguMotivoGuiaNombre,
                            CodigoPersonaTransporteNombre = item.CodigoPersonaTransporteNombre,
                            DireccioDePartida = item.DireccioDePartida,
                            TransporteMarca = item.TransporteMarca == null ? string.Empty : item.TransporteMarca,
                            TransportePlaca = item.TransportePlaca == null ? string.Empty : item.TransportePlaca,
                            TransporteConstancia = item.TransporteConstancia == null ? string.Empty : item.TransporteConstancia,
                            TransporteLicencia = item.TransporteLicencia == null ? string.Empty : item.TransporteLicencia,
                            CodigoArguAnulacion = item.CodigoArguAnulacion,
                            CodigoArguAnulacionNombre = item.CodigoArguAnulacionNombre,

                            CodigoComprobanteORIGEN = item.CodigoComprobanteORIGEN,
                            CodigoComprobanteORIGENNombre = item.CodigoComprobanteORIGENNombre,
                            NumeroComprobanteORIGEN = item.NumeroComprobanteORIGEN,
                            FechaComprobanteORIGEN = item.FechaComprobanteORIGEN,
                            ValorTipoCambioORIGEN = item.ValorTipoCambioORIGEN == null ? 0 : item.ValorTipoCambioORIGEN.Value,
                            CodigoComprobanteDESTINO = item.CodigoComprobanteDESTINO,
                            CodigoComprobanteDESTINONombre = item.CodigoComprobanteDESTINONombre,
                            NumeroComprobanteDESTINO = item.NumeroComprobanteDESTINO,
                            CodigoComprobanteNCR = item.CodigoComprobanteNCR,
                            NumeroComprobanteNCR = item.NumeroComprobanteNCR,
                            CodigoComprobanteNDB = item.CodigoComprobanteNDB,
                            NumeroComprobanteNDB = item.NumeroComprobanteNDB,

                            DocOrdenDeCompra = item.DocOrdenDeCompra,
                            DocGuiaDeSalida = item.DocGuiaDeSalida,
                            DocPedidoAdquisicion = item.DocPedidoAdquisicion,
                            DocLetrasCambio = item.DocLetrasCambio,
                            EntidadRazonSocial = item.EntidadRazonSocial == null ? string.Empty : item.EntidadRazonSocial,
                            EntidadDireccion = item.EntidadDireccion == null ? string.Empty : item.EntidadDireccion,
                            EntidadNumeroRUC = item.EntidadNumeroRUC == null ? string.Empty : item.EntidadNumeroRUC,
                            CodigoArguTipoDomicil = item.CodigoArguTipoDomicil == null ? string.Empty : item.CodigoArguTipoDomicil,
                            CodigoArguTipoDomicilNombre = item.CodigoArguTipoDomicilNombre == null ? string.Empty : item.CodigoArguTipoDomicilNombre,
                            CodigoParte = item.CodigoParte,
                            Observaciones = item.Observaciones,
                            codCondicionVenta = item.codCondicionVenta,
                            codCondicionCompra = item.codCondicionCompra,
                            CodigoComprobanteSecun = item.CodigoComprobanteSecun,
                            NumeroComprobanteSecun = item.NumeroComprobanteSecun,
                            CodigoPuntoVentaSecun = item.CodigoPuntoVentaSecun,
                            codEmpleadoVendedor = item.codEmpleadoVendedor,
                            auxcodEmpleadoVendedorNombre = item.codEmpleadoVendedorNombre,
                            CodigoComprobanteFact = item.CodigoComprobanteFact,
                            NumeroSerie = item.NumeroSerie,
                            NumeroMinuta = item.NumeroMinuta,
                            CodigoRegistroUnico = item.CodigoRegistroUnico,
                            CodigoArguDepositoDesti = item.CodigoArguDepositoDesti,
                            NumeroComprobanteExt = item.NumeroComprobanteExt,
                            DocEsGravado = item.DocEsGravado,
                            DocExigeDocAnexo = item.DocExigeDocAnexo,
                            DocEsFacturable = item.DocEsFacturable,
                            SegAnio = item.SegAnio,
                            SegMes = item.SegMes,
                            SegDia = item.SegDia,
                            Estado = item.Estado,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaCrea = item.SegFechaCrea,
                            SegFechaEdita = item.SegFechaEdita,
                            SegMaquina = item.SegMaquina,
                            Nota01 = item.Nota01,
                            Nota02 = item.Nota02,
                            Nota03 = item.Nota03,
                            CodigoArguTipoDeOperacion = item.CodigoArguTipoDeOperacion,
                            CodigoArguTipoDeOperacionNombre = item.CodigoArguTipoDeOperacionNombre,
                            CodigoComprobanteNombre = item.CodigoComprobanteNombre,
                            FechaDeEntrega = item.FechaDeEntrega,
                            FechaDeRecibido = item.FechaDeRecibido,
                            CodigoArguUbigeo = item.CodigoArguUbigeo,
                            EntidadDireccionUbigeo = item.EntidadDireccionUbigeo,
                            CodigoPersonaEntidadContacto = item.CodigoPersonaContacto,
                            CodigoPersonaEntidadContactoNombre = item.CodigoPersonaContactoNombre,
                            CodigoPersonaTransporte = item.CodigoPersonaTransporte,
                            CodigoPersonaEntidadNombre = item.CodigoPersonaEntidadNombre,
                            CodigoPersonaTransporteRUC = item.CodigoPersonaTransporteRUC,
                            CondicionCompraNombre = item.CondicionCompraNombre,
                            CondicionVentaNombre = item.CondicionVentaNombre,
                            FechaDeDeclaracion = item.FechaDeDeclaracion,
                            indInternacional = item.indInternacional,
                            perTributario = item.perTributario,
                            CodigoArguDepositoOrigen = item.CodigoArguDepositoOrigen,
                            CodigoArguDepositoOrigenNombre = item.CodigoArguDepositoOrigenNombre,
                            CodigoArguDepositoDestiNombre = item.CodigoArguDepositoDestiNombre,
                            codGastoDeAduana = item.codGastoDeAduana,
                            codRegTipoDomicilioTransporte = item.codRegTipoDomicilioTransporte,
                            codRegUbigeoTransporte = item.codRegUbigeoTransporte,
                            auxcodRegTipoDomicilioTransporteNombre = item.codRegTipoDomicilioTransporteNombre,
                            auxcodRegUbigeoTransporteNombre = item.codRegUbigeoTransporteNombre,
                            desDireccionTransporte = item.desDireccionTransporte,
                            desTotalCaja = item.desTotalCaja,
                            desTotalPeso = item.desTotalPeso,
                            auxcodRegTipoEntidad = item.auxcodRegTipoEntidad == null ? string.Empty : item.auxcodRegTipoEntidad,
                            auxcodRegTipoEntidadNombre = item.auxcodRegTipoEntidadNombre == null ? string.Empty : item.auxcodRegTipoEntidadNombre,
                            indImprimeFirma = item.indImprimeFirma.HasValue ? item.indImprimeFirma.Value : false,
                            indImprimeSinIGV = item.indImprimeSinIGV.HasValue ? item.indImprimeSinIGV.Value : false,
                            desMotivoGuiaOtro = item.desMotivoGuiaOtro
                        };
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return comprobanteEmision;
        }

        public BEComprobanteEmision FindUnique(FiltroDocumReg pFiltro)
            
        {
            BEComprobanteEmision comprobanteEmision = new BEComprobanteEmision();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    Nullable<DateTime> fechaNula = null;
                    var resul = SQLDC.omgc_S_DocumReg_Unique(pFiltro.codEmpresa, pFiltro.codPuntoVenta,
                                                             pFiltro.codDocumento, pFiltro.numDocumento);
                    foreach (var item in resul)
                    {
                        comprobanteEmision = new BEComprobanteEmision()
                        {
                            codDocumReg = item.codDocumReg,
                            codEmpresa = item.codEmpresa,
                            CodigoPersonaEmpreNombre = item.CodigoPersonaEmpreNombre,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
                            CodigoComprobante = item.CodigoComprobante,
                            NumeroComprobante = item.NumeroComprobante,
                            CodigoArguEstadoDocu = item.CodigoArguEstadoDocu,
                            CodigoArguEstadoDocuNombre = item.CodigoArguEstadoDocuNombre,
                            CodigoArguDestinoComp = item.CodigoArguDestinoComp,
                            CodigoArguDestinoCompNombre = item.CodigoArguDestinoCompNombre,
                            CodigoPersonaEntidad = item.CodigoPersonaEntidad,
                            codEmpleado = item.codEmpleado,
                            auxcodEmpleadoNombre = item.auxcodEmpleadoNombre,

                            FechaDeEmision = item.FechaDeEmision,
                            FechaDeVencimiento = item.EntidadRazonSocial == null ? fechaNula : item.FechaDeVencimiento,
                            FechaDeProceso = item.FechaDeProceso,
                            FechaDeCancelacion = item.FechaDeCancelacion,
                            FechaDeAnulacion = item.FechaDeAnulacion,
                            CodigoArguMoneda = item.CodigoArguMoneda,
                            CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
                            ValorIGV = item.ValorIGV,
                            ValorTipoCambioVTA = item.ValorTipoCambioVTA,
                            ValorTipoCambioCMP = item.ValorTipoCambioCMP,
                            ValorTotalBruto = item.ValorTotalBruto,
                            ValorTotalDescuento = item.ValorTotalDescuento,
                            ValorTotalVenta = item.ValorTotalVenta,
                            ValorTotalImpuesto = item.ValorTotalImpuesto,
                            ValorTotalPrecioVenta = item.ValorTotalPrecioVenta,
                            ValorTotalPrecioExtran = item.ValorTotalPrecioExtran,
                            CodigoArguMotivoGuia = item.CodigoArguMotivoGuia,
                            CodigoArguMotivoGuiaNombre = item.CodigoArguMotivoGuiaNombre,
                            CodigoPersonaTransporteNombre = item.CodigoPersonaTransporteNombre,
                            DireccioDePartida = item.DireccioDePartida,
                            TransporteMarca = item.TransporteMarca == null ? string.Empty : item.TransporteMarca,
                            TransportePlaca = item.TransportePlaca == null ? string.Empty : item.TransportePlaca,
                            TransporteConstancia = item.TransporteConstancia == null ? string.Empty : item.TransporteConstancia,
                            TransporteLicencia = item.TransporteLicencia == null ? string.Empty : item.TransporteLicencia,
                            CodigoArguAnulacion = item.CodigoArguAnulacion,
                            CodigoArguAnulacionNombre = item.CodigoArguAnulacionNombre,

                            CodigoComprobanteORIGEN = item.CodigoComprobanteORIGEN,
                            CodigoComprobanteORIGENNombre = item.CodigoComprobanteORIGENNombre,
                            NumeroComprobanteORIGEN = item.NumeroComprobanteORIGEN,
                            FechaComprobanteORIGEN = item.FechaComprobanteORIGEN,
                            ValorTipoCambioORIGEN = item.ValorTipoCambioORIGEN == null ? 0 : item.ValorTipoCambioORIGEN.Value,
                            CodigoComprobanteDESTINO = item.CodigoComprobanteDESTINO,
                            CodigoComprobanteDESTINONombre = item.CodigoComprobanteDESTINONombre,
                            NumeroComprobanteDESTINO = item.NumeroComprobanteDESTINO,
                            CodigoComprobanteNCR = item.CodigoComprobanteNCR,
                            NumeroComprobanteNCR = item.NumeroComprobanteNCR,
                            CodigoComprobanteNDB = item.CodigoComprobanteNDB,
                            NumeroComprobanteNDB = item.NumeroComprobanteNDB,

                            DocOrdenDeCompra = item.DocOrdenDeCompra,
                            DocGuiaDeSalida = item.DocGuiaDeSalida,
                            DocPedidoAdquisicion = item.DocPedidoAdquisicion,
                            DocLetrasCambio = item.DocLetrasCambio,
                            EntidadRazonSocial = item.EntidadRazonSocial == null ? string.Empty : item.EntidadRazonSocial,
                            EntidadDireccion = item.EntidadDireccion == null ? string.Empty : item.EntidadDireccion,
                            EntidadNumeroRUC = item.EntidadNumeroRUC == null ? string.Empty : item.EntidadNumeroRUC,
                            CodigoArguTipoDomicil = item.CodigoArguTipoDomicil == null ? string.Empty : item.CodigoArguTipoDomicil,
                            CodigoArguTipoDomicilNombre = item.CodigoArguTipoDomicilNombre == null ? string.Empty : item.CodigoArguTipoDomicilNombre,
                            CodigoParte = item.CodigoParte,
                            Observaciones = item.Observaciones,
                            codCondicionVenta = item.codCondicionVenta,
                            codCondicionCompra = item.codCondicionCompra,
                            CodigoComprobanteSecun = item.CodigoComprobanteSecun,
                            NumeroComprobanteSecun = item.NumeroComprobanteSecun,
                            CodigoPuntoVentaSecun = item.CodigoPuntoVentaSecun,
                            codEmpleadoVendedor = item.codEmpleadoVendedor,
                            auxcodEmpleadoVendedorNombre = item.auxcodEmpleadoVendedorNombre,
                            CodigoComprobanteFact = item.CodigoComprobanteFact,
                            NumeroSerie = item.NumeroSerie,
                            NumeroMinuta = item.NumeroMinuta,
                            CodigoRegistroUnico = item.CodigoRegistroUnico,
                            CodigoArguDepositoDesti = item.CodigoArguDepositoDesti,
                            NumeroComprobanteExt = item.NumeroComprobanteExt,
                            DocEsGravado = item.DocEsGravado,
                            DocExigeDocAnexo = item.DocExigeDocAnexo,
                            DocEsFacturable = item.DocEsFacturable,
                            SegAnio = item.SegAnio,
                            SegMes = item.SegMes,
                            SegDia = item.SegDia,
                            Estado = item.Estado,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaCrea = item.SegFechaCrea,
                            SegFechaEdita = item.SegFechaEdita,
                            SegMaquina = item.SegMaquina,
                            Nota01 = item.Nota01,
                            Nota02 = item.Nota02,
                            Nota03 = item.Nota03,
                            CodigoArguTipoDeOperacion = item.CodigoArguTipoDeOperacion,
                            CodigoArguTipoDeOperacionNombre = item.CodigoArguTipoDeOperacionNombre,
                            CodigoComprobanteNombre = item.CodigoComprobanteNombre,
                            FechaDeEntrega = item.FechaDeEntrega,
                            FechaDeRecibido = item.FechaDeRecibido,
                            CodigoArguUbigeo = item.CodigoArguUbigeo,
                            EntidadDireccionUbigeo = item.EntidadDireccionUbigeo,
                            CodigoPersonaEntidadContacto = item.CodigoPersonaContacto,
                            CodigoPersonaEntidadContactoNombre = item.CodigoPersonaContactoNombre,
                            CodigoPersonaTransporte = item.CodigoPersonaTransporte,
                            CodigoPersonaEntidadNombre = item.CodigoPersonaEntidadNombre,
                            CodigoPersonaTransporteRUC = item.CodigoPersonaTransporteRUC,
                            CondicionCompraNombre = item.CondicionCompraNombre,
                            CondicionVentaNombre = item.CondicionVentaNombre,
                            FechaDeDeclaracion = item.FechaDeDeclaracion,
                            indInternacional = item.indInternacional,
                            perTributario = item.perTributario,
                            CodigoArguDepositoOrigen = item.CodigoArguDepositoOrigen,
                            CodigoArguDepositoOrigenNombre = item.CodigoArguDepositoOrigenNombre,
                            CodigoArguDepositoDestiNombre = item.CodigoArguDepositoDestiNombre,
                            codGastoDeAduana = item.codGastoDeAduana,
                            codRegTipoDomicilioTransporte = item.codRegTipoDomicilioTransporte,
                            codRegUbigeoTransporte = item.codRegUbigeoTransporte,
                            auxcodRegTipoDomicilioTransporteNombre = item.codRegTipoDomicilioTransporteNombre,
                            auxcodRegUbigeoTransporteNombre = item.codRegUbigeoTransporteNombre,
                            desDireccionTransporte = item.desDireccionTransporte,
                            desTotalCaja = item.desTotalCaja,
                            desTotalPeso = item.desTotalPeso,
                            auxcodRegTipoEntidad = item.auxcodRegTipoEntidad == null ? string.Empty : item.auxcodRegTipoEntidad,
                            auxcodRegTipoEntidadNombre = item.auxcodRegTipoEntidadNombre == null ? string.Empty : item.auxcodRegTipoEntidadNombre,
                            indImprimeFirma = item.indImprimeFirma.HasValue ? item.indImprimeFirma.Value : false,
                            indImprimeSinIGV = item.indImprimeSinIGV.HasValue ? item.indImprimeSinIGV.Value : false,

                              
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return comprobanteEmision;
        }
        //public List<BEComprobanteEmision> ListDocumentosParaPDT(BaseFiltro pBaseFiltro)
        //{
        //    List<BEComprobanteEmision> listaComprobanteEmision = new List<BEComprobanteEmision>();
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            Nullable<DateTime> fechaNula = null;
        //            var resul = SQLDC.omgc_S_DocumReg_Sunat(
        //                pBaseFiltro.codEmpresa,
        //                pBaseFiltro.fecInicio,
        //                pBaseFiltro.fecFinal,
        //                pBaseFiltro.codPuntoVenta,
        //                pBaseFiltro.codDocumento,
        //                pBaseFiltro.numDocumento,
        //                pBaseFiltro.codRegEstado,
        //                pBaseFiltro.codRegDestinoDocum,
        //                pBaseFiltro.codPerEntidad,
        //                pBaseFiltro.codRegMoneda,
        //                pBaseFiltro.perTributario
        //                );
        //            int CONTA = 0;
        //            foreach (var item in resul)
        //            {
        //                ++CONTA;
        //                listaComprobanteEmision.Add(new BEComprobanteEmision()
        //                {
        //                    SegAnio = CONTA,
        //                    codDocumReg = item.codDocumReg,
        //                    codEmpresa = item.codEmpresa,
        //                    CodigoPersonaEmpreNombre = item.codEmpresaNombre,
        //                    CodigoPuntoVenta = item.CodigoPuntoVenta,
        //                    CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
        //                    CodigoComprobante = item.CodigoComprobante,
        //                    NumeroComprobante = item.NumeroComprobante,
        //                    CodigoArguEstadoDocu = item.CodigoArguEstadoDocu,
        //                    CodigoArguEstadoDocuNombre = item.CodigoArguEstadoDocuNombre,
        //                    CodigoArguDestinoComp = item.CodigoArguDestinoComp,
        //                    CodigoArguDestinoCompNombre = item.CodigoArguDestinoCompNombre,
        //                    CodigoPersonaEntidad = item.CodigoPersonaEntidad,
        //                    codEmpleado = item.codEmpleado,
        //                    auxcodEmpleadoNombre = item.codEmpleadoNombre,
        //                    FechaDeEmision = item.FechaDeEmision,
        //                    FechaDeVencimiento = item.EntidadRazonSocial == null ? fechaNula : item.FechaDeVencimiento,
        //                    FechaDeProceso = item.FechaDeProceso,
        //                    FechaDeCancelacion = item.FechaDeCancelacion,
        //                    FechaDeAnulacion = item.FechaDeAnulacion,
        //                    CodigoArguMoneda = item.CodigoArguMoneda,
        //                    CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
        //                    ValorIGV = item.ValorIGV,
        //                    ValorTipoCambioVTA = item.ValorTipoCambioVTA,
        //                    ValorTipoCambioCMP = item.ValorTipoCambioCMP,
        //                    ValorTotalBruto = item.ValorTotalBruto,
        //                    ValorTotalDescuento = item.ValorTotalDescuento,
        //                    ValorTotalVenta = item.ValorTotalVenta,
        //                    ValorTotalImpuesto = item.ValorTotalImpuesto,
        //                    ValorTotalPrecioVenta = item.ValorTotalPrecioVenta,
        //                    ValorTotalPrecioExtran = item.ValorTotalPrecioExtran,
        //                    CodigoArguAnulacion = item.CodigoArguAnulacion,
        //                    CodigoArguAnulacionNombre = item.CodigoArguAnulacionNombre,

        //                    CodigoComprobanteORIGEN = item.CodigoComprobanteORIGEN,
        //                    CodigoComprobanteORIGENNombre = item.CodigoComprobanteDESTINONombre,
        //                    NumeroComprobanteORIGEN = item.NumeroComprobanteORIGEN,
        //                    FechaComprobanteORIGEN = item.FechaComprobanteORIGEN,
        //                    ValorTipoCambioORIGEN = item.ValorTipoCambioORIGEN == null ? 0 : item.ValorTipoCambioORIGEN.Value,
        //                    CodigoComprobanteDESTINO = item.CodigoComprobanteDESTINO,
        //                    CodigoComprobanteDESTINONombre = item.CodigoComprobanteDESTINONombre,
        //                    NumeroComprobanteDESTINO = item.NumeroComprobanteDESTINO,
        //                    CodigoComprobanteNCR = item.CodigoComprobanteNCR,
        //                    NumeroComprobanteNCR = item.NumeroComprobanteNCR,
        //                    CodigoComprobanteNDB = item.CodigoComprobanteNDB,
        //                    NumeroComprobanteNDB = item.NumeroComprobanteNDB,

        //                    DocOrdenDeCompra = item.DocOrdenDeCompra,
        //                    DocGuiaDeSalida = item.DocGuiaDeSalida,
        //                    DocPedidoAdquisicion = item.DocPedidoAdquisicion,
        //                    DocLetrasCambio = item.DocLetrasCambio,
        //                    EntidadRazonSocial = item.EntidadRazonSocial == null ? string.Empty : item.EntidadRazonSocial,
        //                    EntidadDireccion = item.EntidadDireccion == null ? string.Empty : item.EntidadDireccion,
        //                    EntidadNumeroRUC = item.EntidadNumeroRUC == null ? string.Empty : item.EntidadNumeroRUC,
        //                    CodigoArguTipoDomicil = item.CodigoArguTipoDomicil == null ? string.Empty : item.CodigoArguTipoDomicil,
        //                    CodigoArguTipoDomicilNombre = item.CodigoArguTipoDomicilNombre == null ? string.Empty : item.CodigoArguTipoDomicilNombre,
        //                    CodigoParte = item.CodigoParte,
        //                    Observaciones = item.Observaciones,
        //                    codCondicionVenta = item.codCondicionVenta,
        //                    codCondicionCompra = item.codCondicionCompra,
        //                    CodigoComprobanteSecun = item.CodigoComprobanteSecun,
        //                    NumeroComprobanteSecun = item.NumeroComprobanteSecun,
        //                    CodigoPuntoVentaSecun = item.CodigoPuntoVentaSecun,
        //                    codEmpleadoVendedor = item.codEmpleadoVendedor,
        //                    auxcodEmpleadoVendedorNombre = item.codEmpleadoVendedorNombre,
        //                    CodigoComprobanteFact = item.CodigoComprobanteFact,
        //                    NumeroSerie = item.NumeroSerie,
        //                    NumeroMinuta = item.NumeroMinuta,
        //                    CodigoRegistroUnico = item.CodigoRegistroUnico,
        //                    CodigoArguDepositoDesti = item.CodigoArguDepositoDesti,
        //                    NumeroComprobanteExt = item.NumeroComprobanteExt,
        //                    DocEsGravado = item.DocEsGravado,
        //                    DocExigeDocAnexo = item.DocExigeDocAnexo,
        //                    DocEsFacturable = item.DocEsFacturable,
        //                    SegMes = item.SegMes,
        //                    SegDia = item.SegDia,
        //                    Estado = item.Estado,
        //                    SegUsuarioCrea = item.SegUsuarioCrea,
        //                    SegUsuarioEdita = item.SegUsuarioEdita,
        //                    SegFechaCrea = item.SegFechaCrea,
        //                    SegFechaEdita = item.SegFechaEdita,
        //                    SegMaquina = item.SegMaquina,
        //                    CodigoArguTipoDeOperacion = item.CodigoArguTipoDeOperacion,
        //                    CodigoArguTipoDeOperacionNombre = item.CodigoArguTipoDeOperacionNombre,
        //                    CodigoComprobanteNombre = item.CodigoComprobanteNombre,
        //                    FechaDeEntrega = item.FechaDeEntrega,
        //                    FechaDeRecibido = item.FechaDeRecibido,
        //                    CodigoArguUbigeo = item.CodigoArguUbigeo,
        //                    EntidadDireccionUbigeo = item.EntidadDireccionUbigeo,
        //                    CodigoPersonaEntidadContacto = item.CodigoPersonaContacto,
        //                    CodigoPersonaEntidadContactoNombre = item.CodigoPersonaContactoNombre,
        //                    CodigoPersonaEntidadNombre = item.CodigoPersonaEntidadNombre,
        //                    CondicionCompraNombre = item.CondicionCompraNombre,
        //                    CondicionVentaNombre = item.CondicionVentaNombre,
        //                    FechaDeDeclaracion = item.FechaDeDeclaracion,
        //                    perTributario = item.perTributario

        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return listaComprobanteEmision;
        //}
        //public List<BEComprobanteEmision> ListDocumentosParaPDTperTributario(int prm_CodEmpresa, 
        //                                                                     string prm_perTributario, 
        //                                                                     string prm_CodigoPuntoVenta, 
        //                                                                     string prm_CodigoPersonaEntidad, 
        //                                                                     string prm_CodigoComprobante, 
        //                                                                     string prm_NumeroComprobante, 
        //                                                                     string prm_CodigoArguEstadoDocu, 
        //                                                                     string prm_CodigoArguDestinoComp, 
        //                                                                     string prm_CodigoArguMoneda, 
        //                                                                     bool? prm_LogicoDeclarado)
        //{
        //    List<BEComprobanteEmision> listaComprobanteEmision = new List<BEComprobanteEmision>();
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            Nullable<DateTime> fechaNula = null;
        //            var resul = SQLDC.omgc_S_DocumReg_SunatperTributario(
        //                prm_CodEmpresa,
        //                prm_perTributario,
        //                prm_CodigoPuntoVenta,
        //                prm_CodigoComprobante,
        //                prm_NumeroComprobante,
        //                prm_CodigoArguEstadoDocu,
        //                prm_CodigoArguDestinoComp,
        //                prm_CodigoPersonaEntidad,
        //                prm_CodigoArguMoneda,
        //                prm_LogicoDeclarado

        //                );
        //            int CONTA = 0;
        //            foreach (var item in resul)
        //            {
        //                ++CONTA;
        //                listaComprobanteEmision.Add(new BEComprobanteEmision()
        //                {
        //                    SegAnio = CONTA,
        //                    codDocumReg = item.codDocumReg,
        //                    codEmpresa = item.codEmpresa,
        //                    CodigoPersonaEmpreNombre = item.codEmpresaNombre,
        //                    CodigoPuntoVenta = item.CodigoPuntoVenta,
        //                    CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
        //                    CodigoComprobante = item.CodigoComprobante,
        //                    NumeroComprobante = item.NumeroComprobante,
        //                    CodigoArguEstadoDocu = item.CodigoArguEstadoDocu,
        //                    CodigoArguEstadoDocuNombre = item.CodigoArguEstadoDocuNombre,
        //                    CodigoArguDestinoComp = item.CodigoArguDestinoComp,
        //                    CodigoArguDestinoCompNombre = item.CodigoArguDestinoCompNombre,
        //                    CodigoPersonaEntidad = item.CodigoPersonaEntidad,
        //                    codEmpleado = item.codEmpleado,
        //                    auxcodEmpleadoNombre = item.codEmpleadoNombre,
        //                    FechaDeEmision = item.FechaDeEmision,
        //                    FechaDeVencimiento = item.EntidadRazonSocial == null ? fechaNula : item.FechaDeVencimiento,
        //                    FechaDeProceso = item.FechaDeProceso,
        //                    FechaDeCancelacion = item.FechaDeCancelacion,
        //                    FechaDeAnulacion = item.FechaDeAnulacion,
        //                    CodigoArguMoneda = item.CodigoArguMoneda,
        //                    CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
        //                    ValorIGV = item.ValorIGV,
        //                    ValorTipoCambioVTA = item.ValorTipoCambioVTA == null ? 0 : item.ValorTipoCambioVTA.Value,
        //                    ValorTipoCambioCMP = item.ValorTipoCambioCMP == null ? 0 : item.ValorTipoCambioCMP.Value,
        //                    ValorTotalBruto = item.ValorTotalBruto,
        //                    ValorTotalDescuento = item.ValorTotalDescuento,
        //                    ValorTotalVenta = item.ValorTotalVenta,
        //                    ValorTotalImpuesto = item.ValorTotalImpuesto,
        //                    ValorTotalPrecioVenta = item.ValorTotalPrecioVenta,
        //                    ValorTotalPrecioExtran = item.ValorTotalPrecioExtran,
        //                    CodigoArguAnulacion = item.CodigoArguAnulacion,
        //                    CodigoArguAnulacionNombre = item.CodigoArguAnulacionNombre,

        //                    CodigoComprobanteORIGEN = item.CodigoComprobanteORIGEN,
        //                    CodigoComprobanteORIGENNombre = item.CodigoComprobanteDESTINONombre,
        //                    NumeroComprobanteORIGEN = item.NumeroComprobanteORIGEN,
        //                    FechaComprobanteORIGEN = item.FechaComprobanteORIGEN,
        //                    ValorTipoCambioORIGEN = item.ValorTipoCambioORIGEN == null ? 0 : item.ValorTipoCambioORIGEN.Value,
        //                    CodigoComprobanteDESTINO = item.CodigoComprobanteDESTINO,
        //                    CodigoComprobanteDESTINONombre = item.CodigoComprobanteDESTINONombre,
        //                    NumeroComprobanteDESTINO = item.NumeroComprobanteDESTINO,
        //                    CodigoComprobanteNCR = item.CodigoComprobanteNCR,
        //                    NumeroComprobanteNCR = item.NumeroComprobanteNCR,
        //                    CodigoComprobanteNDB = item.CodigoComprobanteNDB,
        //                    NumeroComprobanteNDB = item.NumeroComprobanteNDB,

        //                    DocOrdenDeCompra = item.DocOrdenDeCompra,
        //                    DocGuiaDeSalida = item.DocGuiaDeSalida,
        //                    DocPedidoAdquisicion = item.DocPedidoAdquisicion,
        //                    DocLetrasCambio = item.DocLetrasCambio,

        //                    EntidadRazonSocial = item.EntidadRazonSocial == null ? string.Empty : item.EntidadRazonSocial,
        //                    EntidadDireccion = item.EntidadDireccion == null ? string.Empty : item.EntidadDireccion,
        //                    EntidadNumeroRUC = item.EntidadNumeroRUC == null ? string.Empty : item.EntidadNumeroRUC,
        //                    CodigoArguTipoDomicil = item.CodigoArguTipoDomicil == null ? string.Empty : item.CodigoArguTipoDomicil,
        //                    CodigoArguTipoDomicilNombre = item.CodigoArguTipoDomicilNombre == null ? string.Empty : item.CodigoArguTipoDomicilNombre,

        //                    CodigoParte = item.CodigoParte,
        //                    Observaciones = item.Observaciones,
        //                    codCondicionVenta = item.codCondicionVenta,
        //                    codCondicionCompra = item.codCondicionCompra,
        //                    CodigoComprobanteSecun = item.CodigoComprobanteSecun,
        //                    NumeroComprobanteSecun = item.NumeroComprobanteSecun,
        //                    CodigoPuntoVentaSecun = item.CodigoPuntoVentaSecun,
        //                    codEmpleadoVendedor = item.codEmpleadoVendedor,
        //                    auxcodEmpleadoVendedorNombre = item.codEmpleadoVendedorNombre,
        //                    CodigoComprobanteFact = item.CodigoComprobanteFact,
        //                    NumeroSerie = item.NumeroSerie,
        //                    NumeroMinuta = item.NumeroMinuta,
        //                    CodigoRegistroUnico = item.CodigoRegistroUnico,
        //                    CodigoArguDepositoDesti = item.CodigoArguDepositoDesti,
        //                    NumeroComprobanteExt = item.NumeroComprobanteExt,
        //                    DocEsGravado = item.DocEsGravado,
        //                    DocExigeDocAnexo = item.DocExigeDocAnexo,
        //                    DocEsFacturable = item.DocEsFacturable,
        //                    SegMes = item.SegMes,
        //                    SegDia = item.SegDia,
        //                    Estado = item.Estado,
        //                    SegUsuarioCrea = item.SegUsuarioCrea,
        //                    SegUsuarioEdita = item.SegUsuarioEdita,
        //                    SegFechaCrea = item.SegFechaCrea,
        //                    SegFechaEdita = item.SegFechaEdita,
        //                    SegMaquina = item.SegMaquina,
        //                    CodigoArguTipoDeOperacion = item.CodigoArguTipoDeOperacion,
        //                    CodigoArguTipoDeOperacionNombre = item.CodigoArguTipoDeOperacionNombre,
        //                    CodigoComprobanteNombre = item.CodigoComprobanteNombre,
        //                    FechaDeEntrega = item.FechaDeEntrega,
        //                    FechaDeRecibido = item.FechaDeRecibido,
        //                    CodigoArguUbigeo = item.CodigoArguUbigeo,
        //                    EntidadDireccionUbigeo = item.EntidadDireccionUbigeo,
        //                    CodigoPersonaEntidadContacto = item.CodigoPersonaContacto,
        //                    CodigoPersonaEntidadContactoNombre = item.CodigoPersonaContactoNombre,
        //                    CodigoPersonaEntidadNombre = item.CodigoPersonaEntidadNombre,
        //                    CondicionCompraNombre = item.CondicionCompraNombre,
        //                    CondicionVentaNombre = item.CondicionVentaNombre,
        //                    FechaDeDeclaracion = item.FechaDeDeclaracion,
        //                    perTributario = item.perTributario

        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return listaComprobanteEmision;
        //}
        //public List<BEComprobanteEmision> ListDocumentosParaPDTfecDeclaracion(int prm_CodEmpresa, 
        //                                                                      string prm_FechaDeclaracionInicio, 
        //                                                                      string prm_FechaDeclaracionFinal, 
        //                                                                      string prm_CodigoPuntoVenta, 
        //                                                                      string prm_CodigoPersonaEntidad, 
        //                                                                      string prm_CodigoComprobante, 
        //                                                                      string prm_NumeroComprobante, 
        //                                                                      string prm_CodigoArguEstadoDocu, 
        //                                                                      string prm_CodigoArguDestinoComp, 
        //                                                                      string prm_CodigoArguMoneda, 
        //                                                                      bool? prm_LogicoDeclarado)
        //{
        //    List<BEComprobanteEmision> listaComprobanteEmision = new List<BEComprobanteEmision>();
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            Nullable<DateTime> fechaNula = null;
        //            var resul = SQLDC.omgc_S_DocumReg_SunatFechaDeclaracion(prm_CodEmpresa,
        //                                                                    prm_FechaDeclaracionInicio,
        //                                                                    prm_FechaDeclaracionFinal,
        //                                                                    prm_CodigoPuntoVenta,
        //                                                                    prm_CodigoComprobante,
        //                                                                    prm_NumeroComprobante,
        //                                                                    prm_CodigoArguEstadoDocu,
        //                                                                    prm_CodigoArguDestinoComp,
        //                                                                    prm_CodigoPersonaEntidad,
        //                                                                    prm_CodigoArguMoneda,
        //                                                                    prm_LogicoDeclarado);
        //            int contador = 0;
        //            foreach (var item in resul)
        //            {
        //                ++contador;
        //                listaComprobanteEmision.Add(new BEComprobanteEmision()
        //                {
        //                    SegAnio = contador,
        //                    codDocumReg = item.codDocumReg,
        //                    codEmpresa = item.codEmpresa,
        //                    CodigoPersonaEmpreNombre = item.codEmpresaNombre,
        //                    CodigoPuntoVenta = item.CodigoPuntoVenta,
        //                    CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
        //                    CodigoComprobante = item.CodigoComprobante,
        //                    NumeroComprobante = item.NumeroComprobante,
        //                    CodigoArguEstadoDocu = item.CodigoArguEstadoDocu,
        //                    CodigoArguEstadoDocuNombre = item.CodigoArguEstadoDocuNombre,
        //                    CodigoArguDestinoComp = item.CodigoArguDestinoComp,
        //                    CodigoArguDestinoCompNombre = item.CodigoArguDestinoCompNombre,
        //                    CodigoPersonaEntidad = item.CodigoPersonaEntidad,
        //                    codEmpleado = item.codEmpleado,
        //                    auxcodEmpleadoNombre = item.codEmpleadoNombre,
        //                    FechaDeEmision = item.FechaDeEmision,
        //                    FechaDeVencimiento = item.EntidadRazonSocial == null ? fechaNula : item.FechaDeVencimiento,
        //                    FechaDeProceso = item.FechaDeProceso,
        //                    FechaDeCancelacion = item.FechaDeCancelacion,
        //                    FechaDeAnulacion = item.FechaDeAnulacion,
        //                    CodigoArguMoneda = item.CodigoArguMoneda,
        //                    CodigoArguMonedaNombre = item.CodigoArguMonedaNombre,
        //                    ValorIGV = item.ValorIGV,
        //                    ValorTipoCambioVTA = item.ValorTipoCambioVTA == null ? 0 : item.ValorTipoCambioVTA.Value,
        //                    ValorTipoCambioCMP = item.ValorTipoCambioCMP == null ? 0 : item.ValorTipoCambioCMP.Value,
        //                    ValorTotalBruto = item.ValorTotalBruto,
        //                    ValorTotalDescuento = item.ValorTotalDescuento,
        //                    ValorTotalVenta = item.ValorTotalVenta,
        //                    ValorTotalImpuesto = item.ValorTotalImpuesto,
        //                    ValorTotalPrecioVenta = item.ValorTotalPrecioVenta,
        //                    ValorTotalPrecioExtran = item.ValorTotalPrecioExtran,
        //                    CodigoArguAnulacion = item.CodigoArguAnulacion,
        //                    CodigoArguAnulacionNombre = item.CodigoArguAnulacionNombre,

        //                    CodigoComprobanteORIGEN = item.CodigoComprobanteORIGEN,
        //                    CodigoComprobanteORIGENNombre = item.CodigoComprobanteDESTINONombre,
        //                    NumeroComprobanteORIGEN = item.NumeroComprobanteORIGEN,
        //                    FechaComprobanteORIGEN = item.FechaComprobanteORIGEN,
        //                    ValorTipoCambioORIGEN = item.ValorTipoCambioORIGEN == null ? 0 : item.ValorTipoCambioORIGEN.Value,
        //                    CodigoComprobanteDESTINO = item.CodigoComprobanteDESTINO,
        //                    CodigoComprobanteDESTINONombre = item.CodigoComprobanteDESTINONombre,
        //                    NumeroComprobanteDESTINO = item.NumeroComprobanteDESTINO,
        //                    CodigoComprobanteNCR = item.CodigoComprobanteNCR,
        //                    NumeroComprobanteNCR = item.NumeroComprobanteNCR,
        //                    CodigoComprobanteNDB = item.CodigoComprobanteNDB,
        //                    NumeroComprobanteNDB = item.NumeroComprobanteNDB,

        //                    DocOrdenDeCompra = item.DocOrdenDeCompra,
        //                    DocGuiaDeSalida = item.DocGuiaDeSalida,
        //                    DocPedidoAdquisicion = item.DocPedidoAdquisicion,
        //                    DocLetrasCambio = item.DocLetrasCambio,

        //                    EntidadRazonSocial = item.EntidadRazonSocial == null ? string.Empty : item.EntidadRazonSocial,
        //                    EntidadDireccion = item.EntidadDireccion == null ? string.Empty : item.EntidadDireccion,
        //                    EntidadNumeroRUC = item.EntidadNumeroRUC == null ? string.Empty : item.EntidadNumeroRUC,
        //                    CodigoArguTipoDomicil = item.CodigoArguTipoDomicil == null ? string.Empty : item.CodigoArguTipoDomicil,
        //                    CodigoArguTipoDomicilNombre = item.CodigoArguTipoDomicilNombre == null ? string.Empty : item.CodigoArguTipoDomicilNombre,

        //                    CodigoParte = item.CodigoParte,
        //                    Observaciones = item.Observaciones,
        //                    codCondicionVenta = item.codCondicionVenta,
        //                    codCondicionCompra = item.codCondicionCompra,
        //                    CodigoComprobanteSecun = item.CodigoComprobanteSecun,
        //                    NumeroComprobanteSecun = item.NumeroComprobanteSecun,
        //                    CodigoPuntoVentaSecun = item.CodigoPuntoVentaSecun,
        //                    codEmpleadoVendedor = item.codEmpleadoVendedor,
        //                    auxcodEmpleadoVendedorNombre = item.codEmpleadoVendedorNombre,
        //                    CodigoComprobanteFact = item.CodigoComprobanteFact,
        //                    NumeroSerie = item.NumeroSerie,
        //                    NumeroMinuta = item.NumeroMinuta,
        //                    CodigoRegistroUnico = item.CodigoRegistroUnico,
        //                    CodigoArguDepositoDesti = item.CodigoArguDepositoDesti,
        //                    NumeroComprobanteExt = item.NumeroComprobanteExt,
        //                    DocEsGravado = item.DocEsGravado,
        //                    DocExigeDocAnexo = item.DocExigeDocAnexo,
        //                    DocEsFacturable = item.DocEsFacturable,
        //                    SegMes = item.SegMes,
        //                    SegDia = item.SegDia,
        //                    Estado = item.Estado,
        //                    SegUsuarioCrea = item.SegUsuarioCrea,
        //                    SegUsuarioEdita = item.SegUsuarioEdita,
        //                    SegFechaCrea = item.SegFechaCrea,
        //                    SegFechaEdita = item.SegFechaEdita,
        //                    SegMaquina = item.SegMaquina,
        //                    CodigoArguTipoDeOperacion = item.CodigoArguTipoDeOperacion,
        //                    CodigoArguTipoDeOperacionNombre = item.CodigoArguTipoDeOperacionNombre,
        //                    CodigoComprobanteNombre = item.CodigoComprobanteNombre,
        //                    FechaDeEntrega = item.FechaDeEntrega,
        //                    FechaDeRecibido = item.FechaDeRecibido,
        //                    CodigoArguUbigeo = item.CodigoArguUbigeo,
        //                    EntidadDireccionUbigeo = item.EntidadDireccionUbigeo,
        //                    CodigoPersonaEntidadContacto = item.CodigoPersonaContacto,
        //                    CodigoPersonaEntidadContactoNombre = item.CodigoPersonaContactoNombre,
        //                    CodigoPersonaEntidadNombre = item.CodigoPersonaEntidadNombre,
        //                    CondicionCompraNombre = item.CondicionCompraNombre,
        //                    CondicionVentaNombre = item.CondicionVentaNombre,
        //                    FechaDeDeclaracion = item.FechaDeDeclaracion,
        //                    perTributario = item.perTributario

        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return listaComprobanteEmision;
        //}

        #endregion
        private string ObtenerNumeroAbreviado(string documentoOrigen)
        {
            string numeroAbrevias = "GR-";
            if (string.IsNullOrEmpty(documentoOrigen) || documentoOrigen.Length <= 16)
            {
                numeroAbrevias = string.Empty;
                return numeroAbrevias;
            }
            string[] guias = documentoOrigen.Split(' ');
            string numeroItem = string.Empty;
            foreach (string numero in guias)
            {
                numeroItem = numeroItem + " " + numero.Substring(10, 6);
            }
            return numeroAbrevias + numeroItem;
        }
    }
} 

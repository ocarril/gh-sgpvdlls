namespace CROM.BusinessEntities.SUNAT.response
{
    using CROM.BusinessEntities.Comercial.response;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 20/01/2020-12:45 p.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [SUNAT.TBDocumReg.cs]
    /// </summary>
    public class DTODocumRegFEResponse : BEBaseEntidad
    {
        public DTODocumRegFEResponse()
        {
            codTipoDocumentoNombre = string.Empty;
            DRC_Doc_Serie = string.Empty;
            numEntidadRUC = string.Empty;
            DRC_Doc_Numero = string.Empty;
            DRC_tipOperacion = string.Empty;
            DRC_fecEmision = string.Empty;
            DRC_horEmision = string.Empty;
            DRC_codLocalEmisor = string.Empty;
            DRC_CodBarras = string.Empty;
            DRC_customizationId = string.Empty;
            DRC_Firma = string.Empty;
            codMotivoNCRNombre = string.Empty;

            nomRazonSocialEntidad = string.Empty;
            DRC_tipDocUsuario = string.Empty;
            DRC_tipMoneda = string.Empty;
            DRC_tipOperacion = string.Empty;
            DRC_ublVersionId = string.Empty;

            nomReporteDocumSerie = string.Empty;
            pathLogoEmpresa = string.Empty;
            codEmpleadoNombre = string.Empty;

            EmisorCorreoE = string.Empty;
            EmisorTelefon01 = string.Empty;
            EmisorTelefon02 = string.Empty;
            EmisorUbigeo = string.Empty;
            EmisorWebSite = string.Empty;
            EmisorDomicilio = string.Empty;
            EmisorRUC = String.Empty;

            gloObservaciones = string.Empty;
            numDocumento = string.Empty;

            pTotalLetras = string.Empty;
            pCodBarras = string.Empty;
            pLogoEmpresa = string.Empty;
            codRegUnidadMedidaGlobal = string.Empty;
            desMotivoGuiaOtro = string.Empty;

            desNota01 = string.Empty;
            desNota02 = string.Empty;
            desNota03 = string.Empty;
            desTotalCaja= string.Empty;
            codDocumento = string.Empty;
            codAbreviatura=string.Empty;
            nomDocumento=string.Empty;
            fecPagadoCancelado=string.Empty;

            mtoValorTotalOperacionGratuita = 0u;
            prcDescuentoGlobal = 0u;
            mtoValorTotalDescuentoGlobal = 0u;
            mtoValorTotalFISE = 0u;
            mtoValorTotalRC_Propinas = 0u;
            mtoValorTotalCargosGlobales = 0u;
            mtoValorTotalPercepcion = 0u;

            LstDocumRegDetalle = new List<DTODocumRegFEDetalleResponse>();
            LstDocumRegPagoCredito = new List<DTODocumRegPagoCreditoResponse>();
            LstDocumRegCargoDescuento = new List<DTODocumRegCargoDescuentoResponse>();

        }

        public List<DTODocumRegFEDetalleResponse> LstDocumRegDetalle { get; set; }

        public List<DTODocumRegPagoCreditoResponse> LstDocumRegPagoCredito { get; set; }

        public List<DTODocumRegCargoDescuentoResponse> LstDocumRegCargoDescuento { get; set; }

        public int codDocumRegSunat { get; set; }

        public int codDocumReg { get; set; }

        /// <summary>
        /// DRC_Doc_TipoDocumento 
        /// </summary>
        public string codTipoDocumentoNombre{ get; set; }

        public string numDocumento { get; set; }

        public string DRC_Doc_Serie { get; set; }

        public string DRC_Doc_Numero { get; set; }

        public string DRC_tipOperacion { get; set; }

        public string DRC_fecEmision { get; set; }

        public string DRC_horEmision { get; set; }

        /// <summary>
        /// DRC_fecVencimiento
        /// </summary>
        public DateTime fecDeVencimiento { get; set; }

        public string DRC_codLocalEmisor { get; set; }

        public string DRC_tipDocUsuario { get; set; }

        /// <summary>
        /// DRC_numDocUsuario
        /// </summary>
        public string numEntidadRUC { get; set; }

        /// <summary>
        /// DRC_rznSocialUsuario
        /// </summary>
        public string nomRazonSocialEntidad { get; set; }

        /// <summary>
        /// cliEntidadcodUbigeo
        /// </summary>
        public string codUbigeoEntidad { get; set; }

        public string codPersonaEntidad { get; set; }

        #region DATOS RELACIONADO A SUNAT - ENVIO

        public string DRC_tipMoneda { get; set; }

        public string DRC_ublVersionId { get; set; }

        public string DRC_customizationId { get; set; }

        public bool DRC_Activada { get; set; }

        public int DRC_Doc_Contingencia { get; set; }

        public string DRC_Firma { get; set; }

        public string DRC_CodBarras { get; set; }

        public string DRC_NomArchivo { get; set; }

        public string DRC_RptaSunat { get; set; }

        public bool flagEnviadoSUNAT { get; set; }

        public DateTime? fecEnviadoSUNAT { get; set; }

        public string segUsuarioEnviadoSUNAT { get; set; }

        public bool flagParaEnvioSUNAT { get; set; }


        public string RPS_numTicket { get; set; }

        public DateTime? RPS_fecRecepcion { get; set; }

        #endregion

        #region DATOS DE ANULACION

        public bool DRC_Anulado { get; set; }

        public bool DRC_DeBaja { get; set; }

        public string codRegAnulacion { get; set; }

        public string codRegAnulacionNombre { get; set; }

        #endregion

        #region DATOS DE VALORES MONETARIOS/IMPUESTOS DEL DOCUMENTO

        /// <summary>
        /// DRC_sumTotBruto
        /// </summary>
        public decimal mtoValorTotalBruto { get; set; }

        /// <summary>
        /// DRC_sumTotTributos
        /// </summary>
        public decimal mtoValorTotalImpuesto { get; set; }

        /// <summary>
        /// DRC_sumTotValVenta
        /// </summary>
        public decimal mtoValorTotalVenta { get; set; }

        /// <summary>
        /// DRC_sumPrecioVenta
        /// </summary>
        public decimal mtoValorTotalPrecioVenta { get; set; }

        /// <summary>
        /// DRC_sumDescTotal
        /// </summary>
        public decimal mtoValorTotalDescuento { get; set; }

        /// <summary>
        /// DRC_sumOtrosCargos 
        /// </summary>
        public decimal mtoValorTotalOtrosCargos{ get; set; }

        /// <summary>
        /// DRC_sumTotalAnticipos
        /// </summary>
        public decimal mtoValorTotalAnticipos { get; set; }

        /// <summary>
        /// DRC_sumImpVenta
        /// </summary>
        public decimal mtoValorTotalImpVenta { get; set; }

        /// <summary>
        /// prcImpuestoGV
        /// </summary>
        public decimal prcValorIGV { get; set; }

        /// <summary>
        /// monTipoCambioVTA
        /// </summary>
        public decimal? mtoTipoCambioCMP { get; set; }

        /// <summary>
        /// monTipoCambioCMP
        /// </summary>
        public decimal? mtoTipoCambioVTA { get; set; }

        /// <summary>
        /// sumTotImpuestoIGV
        /// </summary>
        public decimal mtoValorTotalImpuestoIGV { get; set; }

        /// <summary>
        /// sumTotImpuestoICBPER
        /// </summary>
        public decimal mtoValorTotalImpuestoICBPER { get; set; }


        #region CARGOS-DESXUENTOS GLOBALES - VALORES CALCULADOS

        /// <summary>
        /// sumOperacionGratuita
        /// </summary>
        public decimal mtoValorTotalOperacionGratuita { get; set; }  // es igual DRC_sumTotValorReferencia


        public decimal prcDescuentoGlobal { get; set; }

        /// <summary>
        /// sumTotalDescuentoGlobal
        /// </summary>
        public decimal mtoValorTotalDescuentoGlobal { get; set; }

        /// <summary>
        /// sumTotalFISE
        /// </summary>
        public decimal mtoValorTotalFISE { get; set; }

        /// <summary>
        /// sumTotalRC_Propinas
        /// </summary>
        public decimal mtoValorTotalRC_Propinas { get; set; }

        /// <summary>
        /// sumTotalCargosGlobales
        /// </summary>
        public decimal mtoValorTotalCargosGlobales { get; set; }

        /// <summary>
        /// sumTotalPercepcion
        /// </summary>
        public decimal mtoValorTotalPercepcion { get; set; }

        #endregion

        #endregion

        public string gloObservaciones { get; set; }

        /// <summary>
        /// DRC_fecEmisionDT
        /// </summary>
        public DateTime fecDeEmision { get; set; }

        public int codCondicionVenta { get; set; }


        #region DATOS DEL DOCUMENTO DE REFERENCIA - ORIGEN

        public string codDocumentoOrigen { get; set; }

        public string codDocumentoOrigenNombre { get; set; }

        public string desAbreviaturaOrigen { get; set; }

        public string codTipoDocumentOrigen { get; set; }

        public string codTipoDocumentoNombreOrigen { get; set; }

        public string numDocumentoOrigOrigen { get; set; }

        public Nullable<DateTime> fecDocumentoOrigen { get; set; }

        public decimal? monTipoCambioOrigen { get; set; }

        public int? codDocumentoSerieOrigen { get; set; }

        public string numDocumentoOrig { get; set; }

        public int? codDocumRegOrigen { get; set; }


        public string codRegMonedaSimboloOrigen { get; set; }

        public string codRegMonedaNombreOrigen { get; set; }

        public decimal? monTotalPrecioVTAMNOrigen { get; set; }

        public decimal? monTotalPrecioVTAMEOrigen { get; set; }

        public decimal? mtoNetoPendientePagoOrigen { get; set; }

        public bool indAplicaDetraccionOrigen { get; set; }

        public string numSerieOrigen { get; set; }

        public string numDocumentoOrigen { get; set; }

        public decimal prcDetraccionOrigen { get; set; }

        public decimal mtoDetraccionOrigen { get; set; }

        public int numCuotasOrigen { get; set; }

        public int numDiasGraciaOrigen { get; set; }

        public int? codCondicionVentaOrigen { get; set; }
       

        #endregion

        #region DATOS DEL DOCUMENTO DE REFERENCIA - DESTINO


        public string codDocumentoDestino { get; set; }

        public string codDocumentoDestinoNombre { get; set; }

        public string desAbreviaturaDestino { get; set; }

        public string codTipoDocumentoDestino { get; set; }

        public string numDocumentoOrigDestino { get; set; }

        public string codRegMonedaSimboloDestino { get; set; }

        public string codRegMonedaNombreDestino { get; set; }

        public decimal? monTotalPrecioVTAMNDestino { get; set; }

        public decimal? monTotalPrecioVTAMEDestino { get; set; }

        public decimal? mtoNetoPendientePagoDestino { get; set; }

        public bool indAplicaDetraccionDestino { get; set; }

        public string numSerieDestino { get; set; }

        public string numDocumentoDestino { get; set; }

        public decimal prcDetraccionDestino { get; set; }

        public decimal mtoDetraccionDestino { get; set; }

        public int numCuotasDestino { get; set; }

        public int numDiasGraciaDestino { get; set; }

        public int? codCondicionVentaDestino { get; set; }

        #endregion

        #region DATOS DE NOTA DE CREDITO - DEBITO


        public int? codMotivoNCR { get; set; }

        public int? codMotivoNDB { get; set; }

        /// <summary>
        /// gloMotivoSustento
        /// </summary>
        public string desMotivoEmisionNotaCRDB { get; set; }

        public string keyMotivoNCR { get; set; }

        public string keyMotivoNDB { get; set; }

        public string codMotivoNCRNombre { get; set; }

        public string codMotivoNDBNombre { get; set; }

        #endregion

        #region DATOS ADICIONALES DE LA CABECERA DEL DOCUMENTO
        /// <summary>
        /// codTipoDocumentoNombre
        /// </summary>
        public string codDocumentoNombre { get; set; }

        /// <summary>
        /// NombreReporte
        /// </summary>
        public string nomReporteDocumSerie { get; set; }

        /// <summary>
        /// cliEntidadDireccion
        /// </summary>
        public string desEntidadDireccion { get; set; }

        /// <summary>
        /// cliEntidadDireccionUbigeo
        /// </summary>
        public string desDireccionUbigeoEntidad{ get; set; }

        public string codRegMoneda { get; set; }

        public string codRegMonedaNombre { get; set; }

        public string codRegMonedaSimbolo { get; set; }

        public string codCondicionVentaNombre { get; set; }

        /// <summary>
        /// numGuiaDeSalida
        /// </summary>
        public string numDocGuiaDeSalida { get; set; }

        /// <summary>
        /// numOrdenCompra
        /// </summary>
        public string numDocOrdenDeCompra { get; set; }

        /// <summary>
        /// numPedidoAdquisicion
        /// </summary>
        public string numDocPedidoAdquisicion { get; set; }

        public int codEmpleado { get; set; }

        public string codEmpleadoNombre { get; set; }

        public string codDocumento { get; set; }

        public string codAbreviatura { get; set; }

        public string nomDocumento { get; set; }

        public bool indCanceladoPagado { get; set; }

        public string fecPagadoCancelado { get; set; }

        #endregion

        public string pTotalLetras { get; set; }

        public string pCodBarras { get; set; }

        public string pLogoEmpresa { get; set; }

        #region DATOS DE LA EMPRESA EMISOR DEL DOCUMENTO

        public string pathLogoEmpresa { get; set; }

        public string EmisorRazonSocial { get; set; }

        public string EmisorNombre { get; set; }

        public string EmisorRUC { get; set; }

        public string EmisorUbigeo { get; set; }

        public string EmisorCodUbigeo { get; set; }

        public string EmisorTelefon01 { get; set; }

        public string EmisorTelefon02 { get; set; }

        public string EmisorCorreoE { get; set; }

        public string EmisorWebSite { get; set; }

        public string EmisorDomicilio { get; set; }

        public string EmisorTipoDocumento { get; set; }

        public string EmisorPropaganda { get; set; }

        public string LogoAdicionalEmpresa { get; set; }

        #endregion

        #region DATOS DE ENVIO DE CORREO DEL DOCUMENTO AL CLIENTE

        public string ctaEmailEnviar { get; set; }
        public DateTime? fecEmailEnviado { get; set; }
        public bool indEmailEnvioExito { get; set; }

        #endregion

        #region DATOS O PROPIEDADES POR LAS DETRACCIONES

        public bool indAplicaDetraccion { get; set; }

        public int? codCuentaBancariaDetraccion { get; set; }

        public int codBienDetraccion { get; set; }

        public int? codFormaDePagoDetraccion { get; set; }

        public decimal prcDetraccion { get; set; }

        public decimal mtoDetraccion { get; set; }

        public bool? indActivoDetraccion { get; set; }

        public string codBienDetraccionNombre { get; set; }

        #endregion

        #region DATOS DE LA GUIA DE REMISION

        public string codRegUnidadMedidaGlobal { get; set; }

        /// <summary>
        /// numTotalBultos
        /// </summary>
        public string desTotalCaja { get; set; }

        /// <summary>
        /// cntPesoTotalBrutoBienes
        /// </summary>
        public string desTotalPeso { get; set; }

        public DateTime? fecInicioTraslado { get; set; }

        /// <summary>
        /// gloNota
        /// </summary>
        public string desNota01 { get; set; }

        /// <summary>
        /// gloNota02
        /// </summary>
        public string desNota02 { get; set; }

        /// <summary>
        /// gloNota03
        /// </summary>
        public string desNota03 { get; set; }


        public string numOrderReferenceGuiaBaja { get; set; }

        //public string codRegMotivoGuia { get; set; }
        /// <summary>
        /// codMotivoTraslado
        /// </summary>
        public string codRegMotivoGuia { get; set; }
        /// <summary>
        /// codMotivoTrasladoNombre
        /// </summary>
        public string codRegMotivoGuiaNombre { get; set; }

        /// <summary>
        /// numMinuta
        /// </summary>
        public string numDocumentoMinuta { get; set; }

        public int? codModalidadTransporte { get; set; }

        public string codModalidadTransporteKey { get; set; }

        public string codModalidadTransporteNombre { get; set; }

        public string desMotivoGuiaOtro { get; set; }

        #region DATOS DOMICILIO DE PARTIDA

        public int? codPersonaDomicilioPartida { get; set; }

        public string codDomicilioPartidaUbigeo { get; set; }

        public string codDomicilioPartidaUbigeoNombre { get; set; }
        /// <summary>
        /// desDomicilioPartidaRegistrado
        /// </summary>
        public string gloDireccioDePartida { get; set; }

        public string codPersonaDomicilioPartidaNombre { get; set; }


        #endregion

        #region  DATOS DEL TRANSPORTISTA - INICIO

        public string codPersonaTransporte { get; set; }

        public string codPersonaTransporteNombre { get; set; }
        /// <summary>
        /// codPersonaTransporteTipoDocumento
        /// </summary>
        public string codRegTipoDocumentoTransportista { get; set; }
        /// <summary>
        /// codPersonaTransporteTipoDocumentoNombre 
        /// </summary>
        public string codRegTipoDocumentoTransportistaNombre{ get; set; }
        /// <summary>
        /// codPersonaTransporteNumDocumento
        /// </summary>
        public string codPersonaTransporteRUC { get; set; }

        /// <summary>
        /// numPlacaVehiculo
        /// </summary>
        public string desTransportePlaca { get; set; }
        /// <summary>
        /// numLicenciaConducir
        /// </summary>
        public string desTransporteLicencia { get; set; }

        public string desTransporteConstancia { get; set; }

        public string desTransporteMarca { get; set; }


        public int? codPersonaDomicilioTransportista { get; set; }

        public string codPersonaDomicilioTransportistaNombre { get; set; }
        /// <summary>
        /// codRegUbigeoTransporte; codUbigeoTransporte
        /// </summary>
        public string codUbigeoTransporte { get; set; }

        /// <summary>
        /// codRegUbigeoTransporteNombre; codUbigeoTransporteNombre
        /// </summary>
        public string codUbigeoTransporteNombre { get; set; }

        public string codRegTipoDomicilioTransporte { get; set; }


        #endregion FIN DATOS DEL TRANSPORTISTA

        #region DATOS ADICIONALES COMPLETE

        public string numContenedor { get; set; }

        public string codPuerto { get; set; }

        public string indTransbordoProgramado { get; set; }

        public int? codDocumentoTributario { get; set; }

        public string numAdditionalDocumentReference { get; set; }

        public string codEntidadProveedorNumDoc { get; set; }

        public string codEntidadProveedorTipDoc { get; set; }

        public string codEntidadProveedorNombre { get; set; }

        public string codUnidMedPesoTotalBrutoBienes { get; set; }

        #endregion

        #endregion

        #region DATOS DE PAGO A CREDITO

        public bool indFormaPagoRegistra { get; set; }

        public int codCondicionFormaPago { get; set; }

        public string codCondicionFormaPagoNombre { get; set; }

        public decimal mtoNetoPendientePagoMN { get; set; }

        public decimal mtoNetoPendientePagoME { get; set; }

        public string tipMonedaMtoNetoPendientePago { get; set; }

        #endregion

        #region DATOS DE VALIDACION DE DOCUMENTO REGISTRADO EN SUNAT

        public DateTime? fecValidWSoapSunat { get; set; }

        public string desValidWSoapSunat { get; set; }

        public bool indValidWSoapSunat { get; set; }

        #endregion

        public int codDocumentoEstado { get; set; }

        /// <summary>
        /// codRegEstado
        /// </summary>
        public string codRegEstadoDocumento { get; set; }

        public int? RDD_EstadoDelItem { get; set; }
        public DateTime? RDD_FechaEnvioSunat { get; set; }
        public string imgEstado001Docum { get; set; }
        public string imgEstado002Docum { get; set; }

        public string DDB_NombreArchivo { get; set; }
        public string DDB_NombreArchivoTicket { get; set; }

        public int numTotalCuotas { get; set; }







        public int? codEmpleadoVendedor { get; set; }

        public string codEmpleadoVendedorNombre { get; set; }

        public string codEmpleadoVendedorEmail { get; set; }

        public string codParteDiario { get; set; }
        public string codPuntoDeVenta { get; set; }
        public string codPuntoDeVentaNombre { get; set; }
        public string codRegEstadoDocumentoNombre { get; set; }
        public string codRegistroUnicoGUID { get; set; }
        public string codRegTipoDeOperacion { get; set; }
        public string codRegTipoDeOperacionNombre { get; set; }

        public DateTime? fecDeCancelacion { get; set; }
        public DateTime? fecDeEntrega { get; set; }
        public DateTime fecDeProceso { get; set; }
        public decimal mtoValorTotalPrecioExtran { get; set; }
        public string perTributario { get; set; }

    }
}

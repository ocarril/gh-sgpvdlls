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
            DRC_Doc_TipoDocumento = string.Empty;
            DRC_Doc_Serie = string.Empty;
            DRC_numDocUsuario = string.Empty;
            DRC_Doc_Numero = string.Empty;
            DRC_tipOperacion = string.Empty;
            DRC_fecEmision = string.Empty;
            DRC_horEmision = string.Empty;
            DRC_codLocalEmisor = string.Empty;
            DRC_CodBarras = string.Empty;
            DRC_customizationId = string.Empty;
            DRC_Firma = string.Empty;
            codMotivoNCRNombre = string.Empty;
            //RefnumDocumento = string.Empty;
            //RefnumSerie = string.Empty;
            //RefnumDocumentoOrig = string.Empty;
            DRC_rznSocialUsuario = string.Empty;
            DRC_tipDocUsuario = string.Empty;
            DRC_tipMoneda = string.Empty;
            DRC_tipOperacion = string.Empty;
            DRC_ublVersionId = string.Empty;

            NombreReporte = string.Empty;
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
            LstDocumRegDetalle = new List<DTODocumRegFEDetalleResponse>();
            LstDocumRegPagoCredito = new List<DTODocumRegPagoCreditoResponse>();
        }

        public int codDocumRegSunat { get; set; }

        public int codDocumReg { get; set; }

        public string DRC_Doc_TipoDocumento { get; set; }

        public string numDocumento { get; set; }

        public string DRC_Doc_Serie { get; set; }

        public string DRC_Doc_Numero { get; set; }

        public string DRC_tipOperacion { get; set; }

        public string DRC_fecEmision { get; set; }

        public string DRC_horEmision { get; set; }

        public DateTime DRC_fecVencimiento { get; set; }

        public string DRC_codLocalEmisor { get; set; }

        public string DRC_tipDocUsuario { get; set; }

        public string DRC_numDocUsuario { get; set; }

        public string DRC_rznSocialUsuario { get; set; }

        public string cliEntidadcodUbigeo { get; set; }

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

        public Nullable<DateTime> fecEnviadoSUNAT { get; set; }

        public string segUsuarioEnviadoSUNAT { get; set; }

        public bool flagParaEnvioSUNAT { get; set; }

        #endregion

        #region DATOS DE ANULACION

        public bool DRC_Anulado { get; set; }

        public bool DRC_DeBaja { get; set; }

        public string codRegAnulacion { get; set; }

        public string codRegAnulacionNombre { get; set; }

        #endregion


        #region DATOS DE VALORES MONETARIOS/IMPUESTOS DEL DOCUMENTO

        public decimal DRC_sumTotBruto { get; set; }

        public decimal DRC_sumTotTributos { get; set; }

        public decimal DRC_sumTotValVenta { get; set; }

        public decimal DRC_sumPrecioVenta { get; set; }

        public decimal DRC_sumDescTotal { get; set; }

        public decimal DRC_sumOtrosCargos { get; set; }

        public decimal DRC_sumTotalAnticipos { get; set; }

        public decimal DRC_sumImpVenta { get; set; }

        public decimal prcImpuestoGV { get; set; }

        public decimal? monTipoCambioVTA { get; set; }

        public decimal? monTipoCambioCMP { get; set; }


        public decimal DRC_sumTotValorReferencia { get; set; }


        public decimal sumTotImpuestoICBPER { get; set; }

        #endregion

        public string gloObservaciones { get; set; }

        public DateTime DRC_fecEmisionDT { get; set; }

        public int codCondicionVenta { get; set; }

        public List<DTODocumRegFEDetalleResponse> LstDocumRegDetalle { get; set; }

        public List<DTODocumRegPagoCreditoResponse> LstDocumRegPagoCredito { get; set; }

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
       

        //public Nullable<DateTime> Ref { get; set; }

        //public string numDocumentoOrig { get; set; }

        //public int? RefcodDocumReg { get; set; }

        //public string RefcodDocumento { get; set; }

        //public string RefnumDocumentoOrig { get; set; }

        //public decimal? RefmonTipoCambioVTA { get; set; }

        //public string ReftipoDocumento { get; set; }

        //public string ReftipoDocumentoNombre { get; set; }

        //public string RefnumSerie { get; set; }

        //public string RefnumDocumento { get; set; }

        //public Nullable<DateTime> ReffecEmision { get; set; }



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

        public string RefMotivo { get; set; }

        public string keyMotivoNCR { get; set; }

        public string keyMotivoNDB { get; set; }

        public string codMotivoNCRNombre { get; set; }

        public string codMotivoNDBNombre { get; set; }

        #endregion

        #region DATOS ADICIONALES DE LA CABECERA DEL DOCUMENTO

        public string codTipoDocumentoNombre { get; set; }

        public string NombreReporte { get; set; }

        public string cliEntidadDireccion { get; set; }

        public string cliEntidadDireccionUbigeo { get; set; }

        public string codRegMoneda { get; set; }

        public string codRegMonedaNombre { get; set; }

        public string codRegMonedaSimbolo { get; set; }

        public string codCondicionVentaNombre { get; set; }


        public string numGuiaDeSalida { get; set; }

        public string numOrdenCompra { get; set; }

        public string numPedidoAdquisicion { get; set; }

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

        public string numTotalBultos { get; set; }

        public string cntPesoTotalBrutoBienes { get; set; }

        public DateTime? fecInicioTraslado { get; set; }

        public string gloNota { get; set; }

        public string numOrderReferenceGuiaBaja { get; set; }

        public string codRegMotivoGuia { get; set; }

        public string codMotivoTraslado { get; set; }

        public string codMotivoTrasladoNombre { get; set; }

        public string numMinuta { get; set; }

        public int? codModalidadTransporte { get; set; }

        public string codModalidadTransporteKey { get; set; }

        public string codModalidadTransporteNombre { get; set; }

        public string desMotivoGuiaOtro { get; set; }

        #region DATOS DOMICILIO DE PARTIDA

        public int? codPersonaDomicilioPartida { get; set; }

        public string codDomicilioPartidaUbigeo { get; set; }

        public string codDomicilioPartidaUbigeoNombre { get; set; }

        public string desDomicilioPartidaRegistrado { get; set; }

        public string codPersonaDomicilioPartidaNombre { get; set; }


        #endregion

        #region  DATOS DEL TRANSPORTISTA - INICIO

        public string codPersonaTransporte { get; set; }

        public string codPersonaTransporteNombre { get; set; }

        public string codPersonaTransporteTipoDocumento { get; set; }

        public string codPersonaTransporteTipoDocumentoNombre { get; set; }

        public string codPersonaTransporteNumDocumento { get; set; }


        public string numPlacaVehiculo { get; set; }

        public string numLicenciaConducir { get; set; }

        public string desTransporteConstancia { get; set; }

        public string desTransporteMarca { get; set; }


        public int? codPersonaDomicilioTransportista { get; set; }

        public string codPersonaDomicilioTransportistaNombre { get; set; }

        public string codUbigeoTransporte { get; set; }

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

        public string codRegEstado { get; set; }

        public int? RDD_EstadoDelItem { get; set; }
        public DateTime? RDD_FechaEnvioSunat { get; set; }
        public string imgEstado001Docum { get; set; }
        public string imgEstado002Docum { get; set; }

        public string DDB_NombreArchivo { get; set; }
        public string DDB_NombreArchivoTicket { get; set; }

        public int numTotalCuotas { get; set; }
    }
}

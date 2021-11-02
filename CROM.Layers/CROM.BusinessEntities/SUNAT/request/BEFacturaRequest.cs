namespace CROM.BusinessEntities.SUNAT.request
{
    using CROM.BusinessEntities.SUNAT.response;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class BEFacturaRequest : BEBaseEntidad
    {
        public BEFacturaRequest()
        {
            ublVersionId = string.Empty;
            numDocUsuario = string.Empty;
            numDocumento = string.Empty;
            codLocalEmisor = string.Empty;

            LstFacturaDetalleSunat = new List<BEFacturaDetalleRequest>();
            LstDatosLeyendas = new List<BEDocumentoSUNATLeyendaResponse>();
            LstDocumentosRelacionados = new List<BEDocumentoSUNATRelacionadoResponse>();
            LstDocumentoPagoCredito = new List<BEDocumentoSUNATPagoCreditoResponse>();

            ACActaBancoNacionDetraccion = string.Empty;
            ACAcodPaisCliente = string.Empty;
            ACAcodBienDetraccion = string.Empty;
            ACAcodMedioPago = string.Empty;
            ACAcodPaisEntrega = string.Empty;
            ACAcodUbigeoCliente = string.Empty;
            ACAcodUbigeoEntrega = string.Empty;
            ACActaBancoNacionDetraccion = string.Empty;
            ACAdesDireccionCliente = string.Empty;
            ACAdesDireccionEntrega = string.Empty;
            ACAmtoDetraccion = 0.0m;
            ACAporDetraccion = 0.0m;

        }

        public List<BEFacturaDetalleRequest> LstFacturaDetalleSunat { get; set; }

        public List<BEDocumentoSUNATLeyendaResponse> LstDatosLeyendas { get; set; }

        public List<BEDocumentoSUNATRelacionadoResponse> LstDocumentosRelacionados { get; set; }

        public List<BEDocumentoSUNATPagoCreditoResponse> LstDocumentoPagoCredito { get; set; }

        public long codDocumRegSunat { get; set; }

        public int codDocumReg { get; set; }

        public string codTipoComprobante { get; set; }

        public string numSerie { get; set; }

        public string numDocumento { get; set; }


        public string tipOperacion { get; set; }

        public DateTime fecEmision { get; set; }

        public TimeSpan horEmision { get; set; }

        public DateTime fecHoraEmision { get; set; }

        public string fecVencimiento { get; set; }

        public string codLocalEmisor { get; set; }

        public string tipDocUsuario { get; set; }

        public string numDocUsuario { get; set; }

        public string rznSocialUsuario { get; set; }

        public string tipMoneda { get; set; }

        public decimal sumTotBruto { get; set; }

        public decimal sumDescTotal { get; set; }

        public decimal sumTotValVenta { get; set; }

        public decimal sumImpVenta { get; set; }

        public decimal sumOtrosCargos { get; set; }

        public decimal sumTotalAnticipos { get; set; }

        public decimal sumTotTributos { get; set; }

        public decimal sumPrecioVenta { get; set; }

        public string ublVersionId { get; set; }

        public string customizationId { get; set; }

        public bool anulado { get; set; }

        public bool activada { get; set; }


        public bool DeBaja { get; set; }
        public bool DocContingencia { get; set; }
        public string Firma { get; set; }
        public string CodBarras { get; set; }
        public decimal monTipoCambioVTA { get; set; }

        public string codRegMonedaNombre { get; set; }


        #region DATOS DEL DOCUMENTO DE REFERENCIA

        public decimal RefmtoDocRelacionado { get; set; }
        public int? RefcodDocumReg { get; set; }
        public string RefcodDocumento { get; set; }
        public string RefnumDocumentoOrig { get; set; }
        public decimal? RefmonTipoCambioVTA { get; set; }
        public string RefcodTipoComprobante { get; set; }


        public string RefnumSerie { get; set; }
        public string RefnumDocumento { get; set; }
        public Nullable<DateTime> ReffecEmision { get; set; }
        public int? codMotivoNCR { get; set; }
        public int? codMotivoNDB { get; set; }
        public string RefMotivo { get; set; }

        #endregion

        #region ATRIBUTOS ADICIONALES PARA ARCHIVO PLANO .ACA SUNAT - DETRACCIONES

        public bool indAplicaDetraccion { get; set; }
        public string ACActaBancoNacionDetraccion { get; set; }

        public string ACAcodBienDetraccion { get; set; }

        public decimal? ACAporDetraccion { get; set; }

        public decimal? ACAmtoDetraccion { get; set; }
        public decimal? ACAmtoDetraccionMndExt { get; set; }

        public string ACAcodMedioPago { get; set; }

        public string ACAcodPaisCliente { get; set; }

        public string ACAcodUbigeoCliente { get; set; }

        public string ACAdesDireccionCliente { get; set; }

        public string ACAcodPaisEntrega { get; set; }

        public string ACAcodUbigeoEntrega { get; set; }

        public string ACAdesDireccionEntrega { get; set; }

        #endregion

        #region DATOS DE PAGO A CREDITO

        public bool indFormaPagoRegistra { get; set; }

        public int codCondicionFormaPago { get; set; }

        public string codCondicionFormaPagoNombre { get; set; }

        public decimal mtoNetoPendientePagoMN { get; set; }

        public decimal mtoNetoPendientePagoME { get; set; }

        public string tipMonedaMtoNetoPendientePago { get; set; }

        #endregion


        [JsonIgnore]
        public string nomEmpresaRUC { get; set; }


        public string numDocumentoOrig { get; set; }

        public string codDocumento { get; set; }

        public string nomDocumento { get; set; }


        #region DATOS PARA DOCUMENTO GUIA DE REMISIÓN


        public string gloNota { get; set; }

        public string numOrderReferenceGuiaBaja { get; set; }

        public string codMotivoTraslado { get; set; }

        public string codMotivoTrasladoNombre { get; set; }

        public int? codDocumentoTributario { get; set; }

        public string codDocumentoTributarioKey { get; set; }

        public string numAdditionalDocumentReference { get; set; }

        // Datos del Proveedor (cuando se ingrese) SellerSupplierParty
        public string codEntidadProveedorNumDoc { get; set; }

        public string codEntidadProveedorTipDoc { get; set; }

        public string codEntidadProveedorNombre { get; set; }

        // Datos del Evio - Guia d remisión
        public string codUnidMedPesoTotalBrutoBienes { get; set; }

        public bool indTransbordoProgramado { get; set; }

        public decimal? cntPesoTotalBrutoBienes { get; set; }

        public int numTotalBultos { get; set; }

        public string codModalidadTransporte { get; set; }

        public DateTime? fecInicioTraslado { get; set; }

        public string codPersonaTransportista { get; set; }

        public string codPersonaTransportistaNombre { get; set; }

        public string codPersonaTransportistaTipoDocumento { get; set; }

        public string codPersonaTransportistaNumDocumento { get; set; }

        public string numPlacaVehiculo { get; set; }

        public string numLicenciaConducir { get; set; }

        public int? codPersonaDomicilioPartida { get; set; }

        public string codDomicilioPartidaUbigeo { get; set; }

        public string codDomicilioPartidaUbigeoNombre { get; set; }

        public string desDomicilioPartida { get; set; }

        public string codPuerto { get; set; }

        public string numContenedor { get; set; }

        #endregion

        public string nomFileCodBarras { get; set; }

        public long? codDocumRegResumenDiario { get; set; }
    }
}

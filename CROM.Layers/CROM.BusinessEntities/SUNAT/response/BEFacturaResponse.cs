namespace CROM.BusinessEntities.SUNAT.response
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class BEFacturaResponse : BEBasePagedResponse
    {
        public BEFacturaResponse()
        {
            ublVersionId = string.Empty;
            codPuntoVentaNombre = string.Empty;
            numDocUsuario = string.Empty;
            numPedidoAdquisicion = string.Empty;
            numGuiaDeSalida = string.Empty;
            numOrdenDeCompra = string.Empty;
            numDocumento = string.Empty;
            codRegEstadoNombre = string.Empty;
            codRegMonedaNombre = string.Empty;
            codCondicionVentaNombre = string.Empty;
            codLocalEmisor = string.Empty;
            codRegTipoOperacion = string.Empty;
            codRegTipoOperacionNombre = string.Empty;
            RptaSunatFSNote = string.Empty;
            RptaNomArchivoXml = string.Empty;
            RptaSunatFSDescripcionBaja = string.Empty;
            RptaSunatXml = string.Empty;

            gloObservaciones = string.Empty;
            gloMotivoSustento = string.Empty;

            desMotivoEmisionNotaCRDB = string.Empty;

            LstFacturaDetalleSunat = new List<BEFacturaDetalleResponse>();
        }

        public List<BEFacturaDetalleResponse> LstFacturaDetalleSunat { get; set; }

        public long codDocumRegSunat { get; set; }

        public int codDocumReg { get; set; }

        public string tipOperacion { get; set; }

        public string tipoDocumento { get; set; }

        public string fecEmision { get; set; }

        public string horEmision { get; set; }

        public string fecVencimiento { get; set; }

        public string codLocalEmisor { get; set; }

        public string tipDocUsuario { get; set; }

        public string numDocUsuario { get; set; }

        public string rznSocialUsuario { get; set; }

        public string tipMoneda { get; set; }

        #region DATOS DE MONTOS - PRECIOS IMPUESTOS

        public decimal sumTotTributos { get; set; }

        public decimal sumTotValVenta { get; set; }

        public decimal sumPrecioVenta { get; set; }

        public decimal sumDescTotal { get; set; }

        public decimal prcDescuentoGlobal { get; set; }

        public decimal sumDescuentoGlobal { get; set; }

        public decimal sumOperacionGratuita { get; set; }

        public decimal sumOtrosCargos { get; set; }

        public decimal sumTotalAnticipos { get; set; }

        public decimal sumImpVenta { get; set; }

        public decimal sumPrecioVentaExtran { get; set; }

        public decimal sumTotImpuestoICBPER { get; set; }

        #endregion

        public string ublVersionId { get; set; }

        public string customizationId { get; set; }


        #region // ATRIBUTOS ADICIONALES
         
        public int codEmpresa { get; set; }

        public string numSerie { get; set; }

        public string numDocumento { get; set; }

        public int numTotalItems { get; set; }

        public int numTotalLetras { get; set; }

        public string codCondicionVentaNombre { get; set; }

        public string codRegMonedaNombre { get; set; }

        public decimal prcIGV { get; set; }

        public decimal monTotalPrecioExtran { get; set; }

        public decimal monTipoCambioVTA { get; set; }

        public string codPuntoVentaNombre { get; set; }

        public string numOrdenDeCompra { get; set; }

        public string numGuiaDeSalida { get; set; }

        public string numPedidoAdquisicion { get; set; }

        public Nullable<DateTime> fecDeDeclaracion { get; set; }

        public string perTributario { get; set; }

        public string codRegEstadoNombre { get; set; }

        public string codRegEstadoDocumento { get; set; }

        public string codRegEstadoColor { get; set; }

        public string codDocumentoEstadoNombre { get; set; }

        public Int16 indOrigen { get; set; }

        public string codRegTipoOperacion { get; set; }

        public string codRegTipoOperacionNombre { get; set; }


        #endregion

        #region // XLM POR GENERAR Y GENERADO
        public bool flagParaEnvioSUNAT { get; set; }

        public string nomArchivoSunat { get; set; }

        public Nullable<DateTime> fecArchivoCreate { get; set; }

        #endregion

        #region // XLM VALIDADO Y FIRMADO

        public bool indArchivoValidado { get; set; }

        public string FirmaDigestValue { get; set; }

        public string FirmaSignatureValue { get; set; }

        public string codBarras { get; set; }

        public DateTime? fechaXMLValid { get; set; }

        #endregion

        #region // XLM ENVIADO A SUNAT POR SFS

        public string RptaNomArchivoXml { get; set; }

        public string RptaSunatFSDescripcion { get; set; }

        public string RptaSunatFSNote { get; set; }

        public Nullable<DateTime> RptaSunatFSFecha { get; set; }

        public String RptaSunatXml { get; set; }

        public bool flagEnviadoSUNAT { get; set; }

        public Nullable<DateTime> fecEnviadoSUNAT { get; set; }

        public string segUsuarioEnviadoSUNAT { get; set; }

        #endregion

        #region // XLM ENVIADO AL CLIENTE (Archivos PDF y XLM)

        public string ctaEmailEnviar { get; set; }

        public Nullable<DateTime> fecEmailEnviado { get; set; }

        public bool indEmailEnvioExito { get; set; }

        #endregion

        #region // DATOS DEL DOCUMENTO DE REFERENCIA

        public int? RefcodDocumReg { get; set; }
        public string RefcodDocumento { get; set; }
        public string RefnumDocumentoOrig { get; set; }
        public decimal? RefmonTipoCambioVTA { get; set; }
        public string ReftipoDocumento { get; set; }

        public string RefnumSerie { get; set; }
        public string RefnumDocumento { get; set; }
        public Nullable<DateTime> ReffecEmision { get; set; }
        public int? codMotivoNCR { get; set; }
        public int? codMotivoNDB { get; set; }

        public string desMotivoEmisionNotaCRDB { get; set; }

        public string keyMotivoNCR { get; set; }
        public string keyMotivoNDB { get; set; }
        public string codMotivoNCRNombre { get; set; }
        public string codMotivoNDBNombre { get; set; }

        #endregion

        #region // XLM DOCUMENTO DE BAJA
        public bool FlagAnulado { get; set; }

        public bool FlagDeBaja { get; set; }

        public string NomArchivoBaja { get; set; }

        public string MotivoBaja { get; set; }

        public Nullable<DateTime> Fecha_SFSBaja { get; set; }

        public string RptaSunatFSDescripcionBaja { get; set; }

        public Nullable<DateTime> RptaSunatFSFechaBaja { get; set; }

        public string segUsuarioEditaBaja { get; set; }
               
        
        public bool BajaNomArchivoValidado { get; set; }

        public string BajaFirmaDigestValue { get; set; }

        public string NomArchivoTicket { get; set; }

        #endregion

        #region // FECHA DE PAGADO-CANCELADO / ANULADO

        public Nullable<DateTime> fecPagadoCancelado { get; set; }

        public Nullable<DateTime> fecPagadoCanceladoRegis { get; set; }

        public Nullable<DateTime> fecAnulacion { get; set; }

        public int cntRegCtaCte { get; set; }

        public DateTime? fecVencimientoDT { get; set; }

        public int numDiasVencimiento { get; set; }

        #endregion

        public bool flagPermiteDarDeBaja { get; set; }

        public Nullable<DateTime> fecEmisionDate { get; set; }

        public string gloObservaciones { get; set; }

        public string gloMotivoSustento { get; set; }


        [JsonIgnore]
        public string codEmpresaRUC { get; set; }

        public string numDocumentoOrig { get; set; }

        public string codDocumento { get; set; }

        public string codAbreviatura { get; set; }

        public string nomDocumento { get; set; }




        #region PROPIEDADES POR DETRACCIONES

        public bool indAplicaDetraccion { get; set; }

        public string codBienDetraccionNombre { get; set; }

        public string codFormaDePagoDetraccionNombre { get; set; }

        public decimal? prcDetraccion { get; set; }

        public decimal? mtoDetraccion { get; set; }

        #endregion


        #region DATOS DE PAGO A CREDITO

        public bool indFormaPagoRegistra { get; set; }

        public int codCondicionFormaPago { get; set; }

        public string codCondicionFormaPagoNombre { get; set; }

        public decimal mtoNetoPendientePagoMN { get; set; }

        public decimal mtoNetoPendientePagoME { get; set; }

        public string tipMonedaMtoNetoPendientePago { get; set; }

        #endregion


        #region VALIDACION DE DOCUMENTO REGISTRADO EN SUNAT

        public DateTime? fecValidWSoapSunat { get; set; }

        public bool indValidWSoapSunat { get; set; }


        public string  numTicket { get; set; }
        

        public DateTime? fecRecepcion { get; set; }

        #endregion

    }
}

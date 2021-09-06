namespace CROM.BusinessEntities.Comercial.response
{
    using System;


    public class DTODocumRegResponse : BEBaseEntidadItem
    {
        public DTODocumRegResponse()
        {

        }

        public int codDocumReg { get; set; }

        public string codPuntoDeVenta { get; set; }

        public string codPuntoDeVentaNombre { get; set; }

        public string codDocumento { get; set; }

        public string codDocumentoNombre { get; set; }

        public string codDocumentoTipo { get; set; }

        public string numDocumento { get; set; }

        public string codRegEstado { get; set; }

        public string codRegEstadoNombre { get; set; }

        public string codRegDestinoDocum { get; set; }

        public string codRegDestinoDocumNombre { get; set; }

        public int codEmpleado { get; set; }

        public string codEmpleadoNombre { get; set; }

        public string codRegTipoDeOperacion { get; set; }

        public string codRegTipoDeOperacionNombre { get; set; }

        public DateTime fecEmision { get; set; }

        public DateTime fecVencimiento { get; set; }

        public DateTime fecProceso { get; set; }

        public string codParte { get; set; }

        public Nullable<int> codCondicionVenta { get; set; }

        public string codCondicionVentaNombre { get; set; }

        public Nullable<int> codCondicionCompra { get; set; }

        public string codCondicionCompraNombre { get; set; }

        public Nullable<int> codEmpleadoVendedor { get; set; }

        public string codEmpleadoVendedorNombre { get; set; }

        public string codDocumentoFact { get; set; }

        public string gloObservaciones { get; set; }

        public string desNota01 { get; set; }

        public string desNota02 { get; set; }

        public string codRegMoneda { get; set; }

        public string codRegMonedaNombre { get; set; }

        public string codRegMonedaSimbolo { get; set; }

        public decimal prcIGV { get; set; }

        public decimal monTipoCambioVTA { get; set; }

        public decimal monTipoCambioCMP { get; set; }

        public decimal sumTotBruto { get; set; }

        public decimal sumDescTotal { get; set; }

        public Nullable<decimal> sumOtrosCargos { get; set; }

        public Nullable<decimal> sumTotalAnticipos { get; set; }

        public Nullable<decimal> sumImpVenta { get; set; }

        public decimal sumTotValVenta { get; set; }

        public decimal sumTotTributos { get; set; }

        public decimal sumPrecioVenta { get; set; }

        public decimal sumPrecioVentaExtran { get; set; }

        public decimal SUMTotalPagadoCajaMN { get; set; }

        public decimal SUMTotalPagadoCajaMI { get; set; }

        public string codDocumentoDestino { get; set; }

        public string codDocumentoDestinoNombre { get; set; }

        public string numDocumentoDestino { get; set; }

        public string codDocumentoOrigen { get; set; }

        public string codDocumentoOrigenNombre { get; set; }

        public string numDocumentoOrigen { get; set; }

        public Nullable<DateTime> fecDocumentoOrigen { get; set; }

        public Nullable<decimal> monTipoCambioOrigen { get; set; }

        public string codDocumentoNCR { get; set; }

        public string numDocumentoNCR { get; set; }

        public string codDocumentoNDB { get; set; }

        public string numDocumentoNDB { get; set; }

        public string numOrdenDeCompra { get; set; }

        public string numGuiaDeSalida { get; set; }

        public string numPedidoAdquisicion { get; set; }

        public string numLetrasCambio { get; set; }

        public string numDocumentoExterno { get; set; }

        public string numSerie { get; set; }

        public string numMinuta { get; set; }

        public string codDocumentoSecun { get; set; }

        public string numDocumentoSecun { get; set; }

        public string codPuntoVentaSecun { get; set; }

        public string codPersonaEntidad { get; set; }

        public string codPersonaEntidadNombre { get; set; }

        public string codRegTipoEntidad { get; set; }

        public string codRegTipoEntidadNombre { get; set; }

        public string nomEntidadRazonSocial { get; set; }

        public Nullable<int> codPersonaDomicilio { get; set; }

        public string nomEntidadDireccion { get; set; }

        public string codRegTipoDomicilio { get; set; }

        public string codRegTipoDomicilioNombre { get; set; }

        public string codUbigeo { get; set; }

        public string desEntidadDireccionUbigeo { get; set; }

        public string codRegTipoDocumentoEntidad { get; set; }

        public string nomEntidadNumeroRUC { get; set; }

        public string codPersonaContacto { get; set; }

        public string codPersonaContactoNombre { get; set; }

        public Nullable<int> codMotivoNCR { get; set; }

        public Nullable<int> codMotivoNDB { get; set; }

        public string gloMotivoSustento { get; set; }

        public string codDepositoOrigen { get; set; }

        public string codDepositoOrigenNombre { get; set; }

        public string codDepositoDestino { get; set; }

        public string codDepositoDestinoNombre { get; set; }

        public bool indDocEsGravado { get; set; }

        public bool indDocExigeDocAnexo { get; set; }

        public bool indDocEsFacturable { get; set; }

        public Nullable<bool> indImprimeFirma { get; set; }

        public Nullable<bool> indImprimeSinIGV { get; set; }

        public bool indInternacional { get; set; }

        public string perTributario { get; set; }

        public bool flagParaEnvioSUNAT { get; set; }

        #region DATOS DE GUIA DE REMISIÓN

        public string codRegMotivoGuia { get; set; }

        public string codRegMotivoGuiaNombre { get; set; }

        public string codPersonaTransporte { get; set; }

        public string codPersonaTransporteNombre { get; set; }

        public string codPersonaTransporteRUC { get; set; }

        public string gloDireccioDePartida { get; set; }

        public string desTransporteMarca { get; set; }

        public string desTransportePlaca { get; set; }

        public string desTransporteConstancia { get; set; }

        public string desTransporteLicencia { get; set; }

        public string desNota03 { get; set; }

        public string codRegTipoDomicilioTransporte { get; set; }

        public string desDireccionTransporte { get; set; }

        public string desTotalCaja { get; set; }

        public string desTotalPeso { get; set; }

        public string codRegTipoDomicilioTransporteNombre { get; set; }

        public string codRegUbigeoTransporte { get; set; }

        public string codRegUbigeoTransporteNombre { get; set; }


        public int? codPersonaDomicilioTransportista { get; set; }

        public int? codPersonaDomicilioPartida { get; set; }

        public int? codModalidadTransporte { get; set; }

        public string numContenedor { get; set; }

        public string codPuerto { get; set; }

        public string indTransbordoProgramado { get; set; }

        public string codRegTipoDocumentoTransportista { get; set; }

        #endregion

        public Nullable<DateTime> fecCancelacion { get; set; }

        public Nullable<DateTime> fecAnulacion { get; set; }

        public Nullable<int> codGastoDeAduana { get; set; }

        public bool indLogicoFiltro { get; set; }

        public string codRegAnulacion { get; set; }

        public string codRegAnulacionNombre { get; set; }

        public Nullable<DateTime> fecDeEntrega { get; set; }

        public Nullable<DateTime> fecDeRecibido { get; set; }

        public Nullable<DateTime> fecDeDeclaracion { get; set; }

        public bool flagEnviadoSUNAT { get; set; }

        public Nullable<DateTime> fecEnviadoSUNAT { get; set; }

        public Nullable<DateTime> fecParaEnvioSUNAT { get; set; }

        public string segUsuarioParaEnvioSUNAT { get; set; }

        public string segUsuarioEnviadoSUNAT { get; set; }

        public string codRegistroUnico { get; set; }

        public short segAnio { get; set; }

        public byte segMes { get; set; }

        public byte segDia { get; set; }

        public string segUsuarioCrea { get; set; }

        public DateTime segFechaCrea { get; set; }

        public int numTotalCuotas { get; set; }

        #region ATRIBUTOS AGREGADOS PARA OBTENER-EDITAR


        public int codDocumentoSerie { get; set; }

        public int codDocumentoEstado { get; set; }

        public string codRegDocumento { get; set; }

        public int? codDocumentoSerieOrigen { get; set; }

        public int? codDocumRegOrigen { get; set; }

        public decimal sumTotValorIGV { get; set; }

        public decimal sumTotValorISC { get; set; }

        public decimal sumTotValorTribOtros { get; set; }

        public int numDiasCredito { get; set; }

        public bool flagPermiteEditar { get; set; }

        public bool SUNATindDeBaja { get; set; }
        public bool SUNATindAnulado { get; set; }
        public string SUNATdesNomArchivo { get; set; }
        public DateTime? SUNATfecCreateArchivo { get; set; }
        public string SUNATdesFirmaDigestValue { get; set; }
        public DateTime? SUNATfecRptaSunatFS { get; set; }
        public string SUNATdesEmailEnviar { get; set; }
        public DateTime? SUNATfecEmailEnviado { get; set; }
        public DateTime? SUNATindEmailEnvioExito { get; set; }
        public string SUNATdesFirmaSignatureValue { get; set; }
        public string SUNATdesCodBarras { get; set; }
        public string SUNATdesRptaNomArchivo { get; set; }
        public string SUNATdesRptaSunatFS { get; set; }


        #endregion

        public int? codCargoDescuento { get; set; }

        public string codRegTipoPlazo { get; set; }

        public string codPersonaBanco { get; set; }

        public string codPersonaAval { get; set; }

        public string codRegUnidadMedidaGlobal { get; set; }

        public string desMotivoGuiaOtro { get; set; }

        #region PROPIEDADES POR DETRACCION

        public bool indAplicaDetraccion { get; set; }

        public int? codCuentaBancariaDetraccion { get; set; }

        public int codBienDetraccion { get; set; }

        public int? codFormaDePagoDetraccion { get; set; }

        public decimal prcDetraccion { get; set; }

        public decimal mtoDetraccion { get; set; }

        public bool? indActivoDetraccion { get; set; }

        public string codBienDetraccionNombre { get; set; }

        #endregion


        public string imgEstado001Docum { get; set; }
        public string imgEstado002Docum { get; set; }

    }
}

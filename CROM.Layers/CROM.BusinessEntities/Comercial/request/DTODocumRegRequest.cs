namespace CROM.BusinessEntities.Comercial.request
{
    using System;


    public class DTODocumRegRequest : DTODocumRegBaseRequest
    {
        public DTODocumRegRequest()
        {
            numDocumento = string.Empty;
            numDocUsuario = string.Empty;
            numLetrasCambio = string.Empty;
            numDiasCredito = 0;
            numSerieDatoRefer = string.Empty;
            numSerieDatoRefer = string.Empty;

        }

        #region PROPIEDADES DATOS DE COTIZACIONES


        public Nullable<DateTime> fecVencimiento { get; set; }

        public int? codEmpleadoVendedor { get; set; }

        public Nullable<DateTime> fecEntrega { get; set; }

        public string numLetrasCambio { get; set; }

        public string numSerieDatoRefer { get; set; }

        public bool indImprimeFirma { get; set; }

        public bool indImprimeSinIGV { get; set; }

        public string nomAtencionEmpresa { get; set; }

        public int numDiasCredito { get; set; }

        public Nullable<DateTime> fecVencimientoCOT { get; set; }

        #endregion

        #region  PROPIEDADES DATOS DE FACTURA DE PROVEEDORES

        public int? codCondicionCompra { get; set; }

        public bool indInternacional { get; set; }

        public bool DocEsGravado { get; set; }

        public string numDocumentoExtSerie { get; set; }

        public string numDocumentoExt { get; set; }

        public string desTotalCaja { get; set; }

        public string desTotalPeso { get; set; }


        public string perTributario { get; set; }



        public string desNota03 { get; set; }

        public bool indDocEsFacturable { get; set; }


        //public string numLetrasCambio { get; set; }
        //public int numDiasCredito { get; set; }
        //public string numSerieDatoRefer { get; set; }
        //public Nullable<DateTime> fecVencimiento { get; set; }
        //public int? codEmpleadoVendedor { get; set; }
        //public Nullable<DateTime> fecEntrega { get; set; }


        #endregion

        #region PROPIEDADES DATOS DE FACTURA/BOLETA DE VENTA

        public string codDocumentoOrigen { get; set; }

        public string numDocumentoOrigen { get; set; }

        public int? codDocumentoSerieOrigen { get; set; }

        public int? codDocumRegOrigen { get; set; }

        public string codDepositoOrigen { get; set; }

        public Nullable<DateTime> fecEmisionOrigen { get; set; }

        public decimal monTipoCambioVTAOrigen { get; set; }

        public string numOrdenDeCompra { get; set; }

        public string numGuiaDeSalida { get; set; }

        public string numPedidoAdquisicion { get; set; }
        
        public string numMinutaDatoRefer { get; set; }

        public bool indDocEsGravado { get; set; }
                     
        public bool flagParaEnvioSUNAT { get; set; }


        #region PROPIEDADES POR DETRACCIONES

        public bool indAplicaDetraccion { get; set; }

        public int? codCuentaBancariaDetraccion { get; set; }

        public int codBienDetraccion { get; set; }

        public int? codFormaDePagoDetraccion { get; set; }

        public decimal prcDetraccion { get; set; }

        public decimal mtoDetraccion { get; set; }

        #endregion


        //public Nullable<DateTime> fecVencimiento { get; set; }
        //public string numLetrasCambio { get; set; }
        //public string numSerieDatoRefer { get; set; }
        //public Nullable<DateTime> fecEntrega { get; set; }
        //public string perTributario { get; set; }
        //public int numDiasCredito { get; set; }
        //public bool indDocEsFacturable { get; set; }
        //public int? codEmpleadoVendedor { get; set; }

        #endregion

        #region PROPIEDADES DATOS DE LA GUIA DE REMISION


        public string codRegMotivoGuia { get; set; }

        public string desDireccioDePartida { get; set; }

        public string desDireccionTransporte { get; set; }

        public string desUbigeoDePartida { get; set; }

        public string codUbigeoTransporte { get; set; }

        public string codPersonaTransporte { get; set; }

        public string codRegTipoDomicilioTransporte { get; set; }

        public string codRegTipoDocumentoTransportista { get; set; }

        public string codPersonaConductor { get; set; }

        public int? codPersonaDomicilioTransportista { get; set; }

        public DateTime? fecInicioTraslado { get; set; }

        public string desTransporteConstancia { get; set; }

        public string desTransporteMarca { get; set; }

        public string desTransporteLicencia { get; set; }

        public string desTransportePlaca { get; set; }

        public int? codPersonaDomicilioPartida { get; set; }

        public int? codModalidadTransporte { get; set; }

        public string numContenedor { get; set; }

        public string codPuerto { get; set; }

        public string indTransbordoProgramado { get; set; }

        public string codRegUnidadMedidaGlobal { get; set; }

        public string desMotivoGuiaOtro { get; set; }

        //public Nullable<DateTime> fecVencimiento { get; set; }
        //public string codDocumentoOrigen { get; set; }
        //public string numDocumentoOrigen { get; set; }
        //public int? codDocumentoSerieOrigen { get; set; }
        //public int? codDocumRegOrigen { get; set; }
        //public Nullable<DateTime> fecEmisionOrigen { get; set; }
        //public decimal monTipoCambioVTAOrigen { get; set; }
        //public int? codEmpleadoVendedor { get; set; }
        //public string numOrdenDeCompra { get; set; }
        //public string numGuiaDeSalida { get; set; }
        //public string numPedidoAdquisicion { get; set; }
        //public string numSerieDatoRefer { get; set; }
        //public string numMinutaDatoRefer { get; set; }
        //public Nullable<DateTime> fecEntrega { get; set; }
        //public int numDiasCredito { get; set; }
        //public string codDepositoOrigen { get; set; }
        //public bool indDocEsGravado { get; set; }
        //public bool indDocEsFacturable { get; set; }
        //public string perTributario { get; set; }
        //public bool flagParaEnvioSUNAT { get; set; }
        //public string desTotalCaja { get; set; }
        //public string desTotalPeso { get; set; 
        //public string desNota02 { get; set; }

        #endregion

        #region PROPIEDADES DATOS DE NOTA DE CREDITO, NOTA DE DEBITO



        public int? codMotivoNCR { get; set; }

        public int? codMotivoNDB { get; set; }

        public string gloMotivoSustento { get; set; }


        //public string codEmpresaRUC { get; set; }
        //public Nullable<DateTime> fecVencimiento { get; set; }
        //public string codDocumentoOrigen { get; set; }
        //public string numDocumentoOrigen { get; set; }
        //public int? codDocumentoSerieOrigen { get; set; }
        //public int? codDocumRegOrigen { get; set; }
        //public DateTime fecEmisionOrigen { get; set; }
        //public decimal monTipoCambioVTAOrigen { get; set; }
        //public string perTributario { get; set; }
        //public bool flagParaEnvioSUNAT { get; set; }
        //public bool indDocEsGravado { get; set; }
        //public bool indDocEsFacturable { get; set; }
        //public int numDiasCredito { get; set; }

        #endregion

        #region PROPIEDADES DATOS DE NOTA DE INGRESO - NOTA DE SALIDA

        public string codDepositoDestino { get; set; }

        //public string codEmpresaRUC { get; set; }
        //public Nullable<DateTime> fecVencimiento { get; set; }
        //public string perTributario { get; set; }
        //public string codDepositoOrigen { get; set; }


        #endregion

        public DateTime? fecCancelacion { get; set; }

        public int indOrigen { get; set; }

    }
}

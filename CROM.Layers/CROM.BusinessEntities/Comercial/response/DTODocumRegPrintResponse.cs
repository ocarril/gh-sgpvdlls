namespace CROM.BusinessEntities.Comercial.response
{
    using CROM.BusinessEntities.SUNAT;
    using CROM.BusinessEntities.SUNAT.response;

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 05/09/2020-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.ComprobanteEmision.cs]
    /// </summary>
    public class DTODocumRegPrintResponse: DTODocumRegPrintBase, IDocumentoElectronico
    {
        public DTODocumRegPrintResponse()
        {

            CodigoPersonaEmpre = string.Empty;
            nomRazonSocialEntidad = string.Empty;
            codRegTipoDomicilio = string.Empty;
            desEntidadDireccion = string.Empty;
            numEntidadRUC = string.Empty;

            prcDescuentoGlobal = 0u;
            sumOperacionGratuita = 0u;
            sumTotalDescuentoGlobal = 0u;
            sumTotalFISE = 0u;
            sumTotalRC_Propinas = 0u;
            sumTotalCargosGlobales = 0u;
            sumTotalPercepcion = 0u;


            listaComprobanteEmisionDetalle = new List<DTODocumRegDetallePrintResponse>();
            listaComprobanteEmisionImpuestos = new List<BEComprobanteEmisionImpuesto>();
            listaComprobanteEmisionDetalleNrosDeSerie = new List<BEComprobanteEmisionDetalleNrosDeSerie>();
            listaDocumentoPagoCredito = new List<BEDocumentoSUNATPagoCreditoResponse>();
            listaDocumRegCargoDescuento = new List<DTODocumRegCargoDescuentoResponse>();
        }

        public List<DTODocumRegDetallePrintResponse> listaComprobanteEmisionDetalle { get; set; }

        public List<BEComprobanteEmisionImpuesto> listaComprobanteEmisionImpuestos { get; set; }

        public List<BEComprobanteEmisionDetalleNrosDeSerie> listaComprobanteEmisionDetalleNrosDeSerie { get; set; }

        public List<BEDocumentoSUNATPagoCreditoResponse> listaDocumentoPagoCredito { get; set; }

        public List<DTODocumRegCargoDescuentoResponse> listaDocumRegCargoDescuento { get; set; }


        public int codEmpresa { get; set; }
        public string codEmpresaRUC { get; set; }
        public int codDocumReg { get; set; }

        public string codRegDestinoDocumento { get; set; }
        public string CodigoPersonaEmpre { get; set; }
        public string codPuntoDeVenta { get; set; }
        public string codDocumento { get; set; }
        public string numDocumento { get; set; }
        public string codRegEstadoDocumento { get; set; }
        public int codDocumentoSerie { get; set; }
        public string codRegMoneda { get; set; }
        public string codRegMonedaNombre { get; set; }
        public string codRegMonedaSimbolo { get; set; }


        public int? codEmpleado { get; set; }

        #region ATRIBUTOS DE TIPOS FECHA

        public DateTime fecDeEmision { get; set; }
        public Nullable<System.DateTime> fecDeVencimiento { get; set; }
        public Nullable<System.DateTime> fecDeCancelacion { get; set; }
        public Nullable<System.DateTime> fecDeAnulacion { get; set; }
        public Nullable<System.DateTime> fecDeDeclaracion { get; set; }

        #endregion

        public string codParteDiario { get; set; }

        #region ATRIBUTOS DE VALORES MONETARIOS Y PORCENTAJES

        public decimal prcValorIGV { get; set; }
        public decimal mtoValorTotalBruto { get; set; }
        public decimal mtoValorTotalDescuento { get; set; }
        public decimal mtoValorTotalVenta { get; set; }
        public decimal mtoValorTotalImpuesto { get; set; }
        public decimal mtoValorTotalPrecioVenta { get; set; }
        public decimal mtoValorTotalPrecioExtran { get; set; }
        public decimal mtoValorTotalVentaGravada { get; set; }
        public decimal mtoValorTotalImpuestoGravada { get; set; }
        public decimal mtoValorTotalHistorico { get; set; }

        public decimal? sumOtrosCargos { get; set; }
        public decimal? sumTotalAnticipos { get; set; }
        public decimal sumTotImpuestoICBPER { get; set; }
        public decimal? sumImpVenta { get; set; }
        public decimal mtoTipoCambioVTA { get; set; }
        public decimal mtoTipoCambioCMP { get; set; }


        #region CARGOS-DESXUENTOS GLOBALES - VALORES CALCULADOS

        public decimal sumOperacionGratuita { get; set; }

        public decimal prcDescuentoGlobal { get; set; }

        public decimal sumTotalDescuentoGlobal { get; set; }

        public decimal sumTotalFISE { get; set; }

        public decimal sumTotalRC_Propinas { get; set; }

        public decimal sumTotalCargosGlobales { get; set; }

        public decimal sumTotalPercepcion { get; set; }

        #endregion

        #endregion

        public string codnumDocumentoNCR { get; set; }
        public string numDocumentoNCR { get; set; }
        public string codnumDocumentoNDB { get; set; }
        public string numDocumentoNDB { get; set; }

        public string numDocOrdenDeCompra { get; set; }
        public string numDocGuiaDeSalida { get; set; }
        public string numDocPedidoAdquisicion { get; set; }
        public string numDocLetrasCambio { get; set; }

        public string gloObservaciones { get; set; }


        #region ATRIBUTOS DE LA EMPRESA CLIENTE-PROVEEDOR

        public string codPersonaEntidad { get; set; }
        public string numEntidadRUC { get; set; }
        public string codRegTipoEntidad { get; set; }
        public string codRegTipoEntidadNombre { get; set; }
        public string nomRazonSocialEntidad { get; set; }
        public string codRegTipoDomicilio { get; set; }
        public string codRegTipoDomicilioNombre { get; set; }
        public string desEntidadDireccion { get; set; }
        public string codRegTipoDocumentoEntidad { get; set; }
        public int? codPersonaDomicilio { get; set; }

        public string codPersonaEntidadContacto { get; set; }
        public string codPersonaEntidadContactoNombre { get; set; }
        public string codUbigeoEntidad { get; set; }
        public string desDireccionUbigeoEntidad { get; set; }

        #endregion

        public string codDocumentoSecun { get; set; }
        public string numDocumentoSecun { get; set; }
        public string codPuntoVentaSecun { get; set; }

        public int? codEmpleadoVendedor { get; set; }
        public string codEmpleadoVendedorNombre { get; set; }

        public string codDocumentoFact { get; set; }
        public string numDocumentoSerie { get; set; }
        public string numDocumentoMinuta { get; set; }


        public string numDocumentoExterno { get; set; }
        public bool indDocEsGravado { get; set; }
        public bool indDocExigeDocAnexo { get; set; }
        public bool indDocEsFacturable { get; set; }
        public bool indInternacional { get; set; }
        public string perTributario { get; set; }


        #region DATOS DE ANULACION

        public string codRegAnulacion { get; set; }
        public string codRegAnulacionNombre { get; set; }

        #endregion


        public int? codGastoDeAduana { get; set; }
        public string codRegDestinoDocumentoNombre { get; set; }
        public string codPuntoDeVentaNombre { get; set; }
        public string codDocumentoNombre { get; set; }
        public string codRegEstadoDocumentoNombre { get; set; }

        public string codRegTipoDeOperacion { get; set; }
        public string desNota01 { get; set; }
        public string desNota02 { get; set; }


        public Nullable<DateTime> fecDeEntrega { get; set; }
        public Nullable<DateTime> fecDeRecibido { get; set; }

        public int? codCondicionVenta { get; set; }
        public int? codCondicionCompra { get; set; }
        public string codCondicionVentaNombre { get; set; }
        public string codCondicionCompraNombre { get; set; }
        public string codRegTipoDeOperacionNombre { get; set; }



        public string codEmpleadoVendedorTelefono { get; set; }
        public string codEmpleadoVendedorEmail { get; set; }

        #region ARIBUTOS DEL DOCUMENTO ORIGEN

        public int? codDocumRegOrigen { get; set; }

        public string codDepositoOrigen { get; set; }

        public string codDepositoOrigenNombre { get; set; }

        public string codDocumentoOrigen { get; set; }

        public string codDocumentoOrigenNombre { get; set; }

        public string numDocumentoOrigen { get; set; }

        public Nullable<DateTime> fecDocumentoOrigen { get; set; }

        public decimal monTipoCambioOrigen { get; set; }

        public int? codDocumentoSerieOrigen { get; set; }

        #endregion

        #region ATRIBUTOS DEL DOCUMENTO DESTINO

        public string codDepositoDestino { get; set; }

        public string codDepositoDestinoNombre { get; set; }

        public string codDocumentoDestino { get; set; }

        public string numDocumentoDestino { get; set; }

        public string codDocumentoDestinoNombre { get; set; }

        #endregion

        #region APTRIBUTOS Indicadores para visualizar o no Firma-Sello y IGV Desagregado - 13-SET-2015

        public bool indImprimeFirma { get; set; }
        public bool indImprimeSinIGV { get; set; }

        #endregion

        #region  ARIBUTOS DE LA GUIA DE REMISIONES - Tabla: GestionComercial.DocumentoMovAdicional 

        public string desTotalCaja { get; set; }

        public string desTotalPeso { get; set; }

        public string codRegMotivoGuia { get; set; }

        public string gloDireccioDePartida { get; set; }

        public string codPersonaTransporte { get; set; }

        public string codRegTipoDomicilioTransporte { get; set; }

        public string codRegUbigeoTransporte { get; set; }

        public DateTime? fecInicioTraslado { get; set; }

        public string desTransporteConstancia { get; set; }

        public string desTransporteMarca { get; set; }

        public string desTransporteLicencia { get; set; }

        public string desTransportePlaca { get; set; }

        public string desNota03 { get; set; }

        public int? codPersonaDomicilioTransportista { get; set; }

        public string codRegTipoDomicilioTransporteNombre { get; set; }


        public int? codPersonaDomicilioPartida { get; set; }

        public int? codModalidadTransporte { get; set; }

        public string numContenedor { get; set; }

        public string codPuerto { get; set; }

        public string indTransbordoProgramado { get; set; }

        public string codRegTipoDocumentoTransportista { get; set; }

        public string codUbigeoTransporteNombre { get; set; }

        public string codPersonaDomicilioTransportistaNombre { get; set; }

        public string codPersonaDomicilioPartidaNombre { get; set; }

        public string codModalidadTransporteNombre { get; set; }

        public string codRegTipoDocumentoTransportistaNombre { get; set; }

        public string desUbigeoDePartida { get; set; }

        public string desDireccionTransporte { get; set; }


        public string codRegMotivoGuiaNombre { get; set; }
        public string codPersonaTransporteNombre { get; set; }
        public string codoPersonaTransporteRUC { get; set; }

        #endregion


        [JsonIgnore]
        public string codEmpleadoPlanilla { get; set; }


        #region  ATRIBUTOS DE ENVIO A SUNAT -FACT - BLT - NOTA DE CREDITO/DEBITO -      */      

        public int? codMotivoNCR { get; set; }

        public int? codMotivoNDB { get; set; }

        public string codMotivoNCRKey { get; set; }

        public string codMotivoNDBKey { get; set; }

        public string codMotivoNCRNombre { get; set; }

        public string codMotivoNDBNombre { get; set; }

        public string gloMotivoSustento { get; set; }

        public bool flagParaEnvioSUNAT { get; set; }

        public bool flagEnviadoSUNAT { get; set; }

        public Nullable<DateTime> fecEnviadoSUNAT { get; set; }

        public Nullable<DateTime> fecParaEnvioSUNAT { get; set; }

        public string segUsuarioParaEnvioSUNAT { get; set; }

        public string segUsuarioEnviadoSUNAT { get; set; }

        #endregion



        public int? codDocumentoEstado { get; set; }
        public string codTipoDocumentoSUNAT { get; set; }

        public Int16 indOrigen { get; set; }

        public int numDiasCredito { get; set; }

        public string nomReporteDocumSerie { get; set; }



        public string pathLogoEmpresa { get; set; }
        public string desValorTotalPrecioVentaLetras { get; set; }



        #region PROPIEDADES POR DETRACCIONES

        public bool indAplicaDetraccion { get; set; }

        public int? codCuentaBancariaDetraccion { get; set; }

        public int? codBienDetraccion { get; set; }

        public string codBienDetraccionNombre { get; set; }

        public int? codFormaDePagoDetraccion { get; set; }

        public string codFormaDePagoDetraccionNombre { get; set; }

        public decimal? prcDetraccion { get; set; }

        public decimal? mtoDetraccion { get; set; }

        public bool? indActivoDetraccion { get; set; }

        #endregion

        #region ATRIBUTOS DE PAGO A CREDITO

        public bool indFormaPagoRegistra { get; set; }

        public int codCondicionFormaPago { get; set; }

        public string codCondicionFormaPagoNombre { get; set; }

        public decimal mtoNetoPendientePagoMN { get; set; }

        public decimal mtoNetoPendientePagoME { get; set; }

        public string tipMonedaMtoNetoPendientePago { get; set; }


        #endregion

        #region ATRIBUTOS DE AUDITORIA

        public bool indActivo { get; set; }
        public DateTime fecDeProceso { get; set; }
        public string codRegistroUnicoGUID { get; set; }
        public int segAnio { get; set; }
        public Int16 segMes { get; set; }
        public Int16 segDia { get; set; }
        public string segUsuarioCrea { get; set; }
        public string segUsuarioEdita { get; set; }
        public DateTime segFechaCrea { get; set; }
        public Nullable<DateTime> segFechaEdita { get; set; }
        public string segMaquina { get; set; }

        #endregion



    }

}

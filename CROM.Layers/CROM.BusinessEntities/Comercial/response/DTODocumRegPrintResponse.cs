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
            listaComprobanteEmisionDetalle = new List<BEComprobanteEmisionDetalle>();
            listaComprobanteEmisionImpuestos = new List<BEComprobanteEmisionImpuesto>();
            listaComprobanteEmisionDetalleNrosDeSerie = new List<BEComprobanteEmisionDetalleNrosDeSerie>();
            listaDocumentoPagoCredito = new List<BEDocumentoSUNATPagoCreditoResponse>();

            CodigoPersonaEmpre = string.Empty;
            EntidadRazonSocial = string.Empty;
            CodigoArguTipoDomicil = string.Empty;
            EntidadDireccion = string.Empty;
            EntidadNumeroRUC = string.Empty;
        }

        public int codEmpresa { get; set; }
        public string codEmpresaRUC { get; set; }
        public int codDocumReg { get; set; }
        public string CodigoPersonaEmpre { get; set; }
        public string CodigoPuntoVenta { get; set; }
        public string CodigoComprobante { get; set; }
        public int codDocumentoSerie { get; set; }
        public string NumeroComprobante { get; set; }
        public string CodigoArguEstadoDocu { get; set; }
        public string CodigoArguDestinoComp { get; set; }
        public string CodigoPersonaEntidad { get; set; }
        public int? codEmpleado { get; set; }

        #region CAMPOS DE FECHA

        public DateTime FechaDeEmision { get; set; }
        public Nullable<System.DateTime> FechaDeVencimiento { get; set; }
        public Nullable<System.DateTime> FechaDeCancelacion { get; set; }
        public Nullable<System.DateTime> FechaDeAnulacion { get; set; }
        public Nullable<System.DateTime> FechaDeDeclaracion { get; set; }

        #endregion

        public string CodigoArguMoneda { get; set; }

        public decimal ValorIGV { get; set; } // MEMORIA

        public string CodigoParte { get; set; }
        public decimal ValorTotalBruto { get; set; }
        public decimal ValorTotalDescuento { get; set; }
        public decimal ValorTotalVenta { get; set; }
        public decimal ValorTotalImpuesto { get; set; }
        public decimal ValorTotalPrecioVenta { get; set; }//
        public decimal ValorTotalPrecioExtran { get; set; }// 
        public decimal ValorTotalVentaGravada { get; set; }//
        public decimal ValorTotalImpuestoGravada { get; set; }//
        public decimal ValorTotalHistorico { get; set; }//

        public string CodigoComprobanteDESTINO { get; set; }
        public string NumeroComprobanteDESTINO { get; set; }//
        public string CodigoComprobanteORIGEN { get; set; }
        public string NumeroComprobanteORIGEN { get; set; }//

        public Nullable<DateTime> FechaComprobanteORIGEN { get; set; }

        public decimal ValorTipoCambioORIGEN { get; set; }

        public int? codDocumentoSerieOrigen { get; set; }

        public int? codDocumRegOrigen { get; set; }

        public string CodigoComprobanteNCR { get; set; }
        public string NumeroComprobanteNCR { get; set; }//
        public string CodigoComprobanteNDB { get; set; }
        public string NumeroComprobanteNDB { get; set; }//

        public string DocOrdenDeCompra { get; set; }
        public string DocGuiaDeSalida { get; set; }
        public string DocPedidoAdquisicion { get; set; }
        public string DocLetrasCambio { get; set; }
        public string Observaciones { get; set; }

        public string EntidadRazonSocial { get; set; }
        public string CodigoArguTipoDomicil { get; set; }
        public string EntidadDireccion { get; set; }
        public string EntidadNumeroRUC { get; set; }

        public string CodigoComprobanteSecun { get; set; }
        public string NumeroComprobanteSecun { get; set; }
        public string CodigoPuntoVentaSecun { get; set; }

        public int? codEmpleadoVendedor { get; set; }
        public string CodigoComprobanteFact { get; set; }
        public string NumeroSerie { get; set; }
        public string NumeroMinuta { get; set; }
        public string CodigoArguDepositoDesti { get; set; }//
        public string CodigoArguDepositoOrigen { get; set; }//
        public string NumeroComprobanteExt { get; set; }//

        public bool DocEsGravado { get; set; }//MEMORIA
        public bool DocExigeDocAnexo { get; set; }//MEMORIA
        public bool DocEsFacturable { get; set; }//MEMORIA
        public decimal ValorTipoCambioVTA { get; set; }//
        public decimal ValorTipoCambioCMP { get; set; }//

        public bool CHECKED_DECLARA { get; set; }//MEMORIA
        public string CodigoArguAnulacion { get; set; }

        public string CodigoArguTipoDeOperacion { get; set; }
        public string Nota01 { get; set; }
        public string Nota02 { get; set; }


        public Nullable<DateTime> FechaDeEntrega { get; set; }
        public Nullable<DateTime> FechaDeRecibido { get; set; }
        public string CodigoArguUbigeo { get; set; }
        public string EntidadDireccionUbigeo { get; set; }

        public bool Estado { get; set; }

        public DateTime FechaDeProceso { get; set; }
        public string CodigoRegistroUnico { get; set; }
        public int SegAnio { get; set; }
        public Int16 SegMes { get; set; }
        public Int16 SegDia { get; set; }
        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public DateTime SegFechaCrea { get; set; }
        public Nullable<DateTime> SegFechaEdita { get; set; }
        public string SegMaquina { get; set; }
        public int? codGastoDeAduana { get; set; }

        public string CodigoPersonaEmpreNombre { get; set; }
        public string CodigoPuntoVentaNombre { get; set; }
        public string CodigoComprobanteNombre { get; set; }
        public string CodigoArguEstadoDocuNombre { get; set; }
        public string CodigoArguDestinoCompNombre { get; set; }
        public string CodigoPersonaEntidadNombre { get; set; }
        public string CodigoArguMonedaNombre { get; set; }
        public string CodigoArguMotivoGuiaNombre { get; set; }
        public string CodigoPersonaTransporteNombre { get; set; }
        public string CodigoPersonaTransporteRUC { get; set; }
        public string CodigoArguAnulacionNombre { get; set; }
        public string CodigoArguTipoDomicilNombre { get; set; }
        public string CondicionVentaNombre { get; set; }
        public string CondicionCompraNombre { get; set; }
        public string CodigoPuntoVentaSecunNombre { get; set; }
        public string CodigoArguTipoDeOperacionNombre { get; set; }

        public string auxcodEmpleadoVendedorNombre { get; set; }
        public string auxcodEmpleadoNombre { get; set; }

        public List<BEComprobanteEmisionDetalle> listaComprobanteEmisionDetalle { get; set; }
        public List<BEComprobanteEmisionImpuesto> listaComprobanteEmisionImpuestos { get; set; }
        public List<BEComprobanteEmisionDetalleNrosDeSerie> listaComprobanteEmisionDetalleNrosDeSerie { get; set; }
        public List<BEDocumentoSUNATPagoCreditoResponse> listaDocumentoPagoCredito { get; set; }

        public string CodigoPersonaEntidadContacto { get; set; }
        public string CodigoPersonaEntidadContactoNombre { get; set; }

        public string REF_CodigoPersonaEntidadContactoTelefono { get; set; }
        public string REF_CodigoPersonaEntidadContactoEmail { get; set; }
        public string REF_CodigoPersonaVendedorArea { get; set; }
        public string REF_CodigoPersonaVendedorEmail { get; set; }
        public string REF_CodigoPersonaVendedorTelefono { get; set; }
        public string REF_CodigoArguMonedaSimbolo { get; set; }
        public string REF_ValorTotalPrecioVentaLetras { get; set; }
        public string REF_TextoDeLeyenda { get; set; }

        public string CodigoComprobanteDESTINONombre { get; set; }
        public string CodigoComprobanteORIGENNombre { get; set; }
        public string CodigoArguDepositoDestiNombre { get; set; }
        public string CodigoArguDepositoOrigenNombre { get; set; }

        public int REF_TotalItems { get; set; }
        public int REF_TotalLetras { get; set; }

        public bool indInternacional { get; set; }
        public string perTributario { get; set; }

        public string auxcodRegTipoDomicilioTransporteNombre { get; set; }
        public string auxcodRegUbigeoTransporteNombre { get; set; }

        public string auxcodRegTipoEntidad { get; set; }
        public string auxcodRegTipoEntidadNombre { get; set; }
        public string auxEntidadNumeroDNI { get; set; }
        public string auxCuentaBancariaPago { get; set; }

        #region /*13-SET-2015 Indicadores para visualizar o no Firma-Sello y IGV Desagregado*/

        public bool indImprimeFirma { get; set; }
        public bool indImprimeSinIGV { get; set; }

        #endregion

        #region  /*Tabla: GestionComercial.DocumentoMovAdicional - GUIA DE REMISIONES */

        public string desTotalCaja { get; set; }
        public string desTotalPeso { get; set; }
        public string CodigoArguMotivoGuia { get; set; }
        public string DireccioDePartida { get; set; }
        public string CodigoPersonaTransporte { get; set; }
        public string codRegTipoDomicilioTransporte { get; set; }
        public string codRegUbigeoTransporte { get; set; }

        public DateTime? fecInicioTraslado { get; set; }
        public string TransporteConstancia { get; set; }
        public string TransporteMarca { get; set; }
        public string TransporteLicencia { get; set; }
        public string TransportePlaca { get; set; }
        public string Nota03 { get; set; }

        public int? codPersonaDomicilioTransportista { get; set; }

        public int? codPersonaDomicilioPartida { get; set; }

        public int? codModalidadTransporte { get; set; }

        public string numContenedor { get; set; }

        public string codPuerto { get; set; }

        public string indTransbordoProgramado { get; set; }

        public string codRegTipoDocumentoTransportista { get; set; }

        public string codRegMotivoGuiaNombre { get; set; }

        public string codPersonaTransporteNombre { get; set; }

        public string codUbigeoTransporteNombre { get; set; }

        public string codPersonaDomicilioTransportistaNombre { get; set; }

        public string codPersonaDomicilioPartidaNombre { get; set; }

        public string codModalidadTransporteNombre { get; set; }

        public string codRegTipoDocumentoTransportistaNombre { get; set; }

        public string desUbigeoDePartida { get; set; }



        public bool indInventarioAutomatico { get; set; }
        public string strInventarioAutomatico { get; set; }
        public string desDireccionTransporte { get; set; }

        #endregion

        public int? codCondicionVenta { get; set; }
        public int? codCondicionCompra { get; set; }

        [JsonIgnore]
        public string codEmpleadoPlanilla { get; set; }

        public decimal? sumOtrosCargos { get; set; }

        public decimal? sumTotalAnticipos { get; set; }

        public decimal? sumImpVenta { get; set; }


        #region  /*DATOS NOTA DE CREDITO/DEBITO - SUNAT      */      

        public int? codMotivoNCR { get; set; }
        public int? codMotivoNDB { get; set; }
        public string gloMotivoSustento { get; set; }
        public bool flagParaEnvioSUNAT { get; set; }

        public bool flagEnviadoSUNAT { get; set; }

        public Nullable<DateTime> fecEnviadoSUNAT { get; set; }

        public Nullable<DateTime> fecParaEnvioSUNAT { get; set; }

        public string segUsuarioParaEnvioSUNAT { get; set; }

        public string segUsuarioEnviadoSUNAT { get; set; }

        #endregion

        public string codRegTipoDocumentoEntidad { get; set; }

        public int? codPersonaDomicilio { get; set; }

        public int? codDocumentoEstado { get; set; }

        public Int16 indOrigen { get; set; }

        public int numDiasCredito { get; set; }

        public string nomReporteDocumSerie { get; set; }

        public string pathLogoEmpresa { get; set; }


        public string codTipoDocumentoSUNAT { get; set; }


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


        #region DATOS DE PAGO A CREDITO

        public bool indFormaPagoRegistra { get; set; }

        public int codCondicionFormaPago { get; set; }

        public string codCondicionFormaPagoNombre { get; set; }

        public decimal mtoNetoPendientePagoMN { get; set; }

        public decimal mtoNetoPendientePagoME { get; set; }

        public string tipMonedaMtoNetoPendientePago { get; set; }

        #endregion

    }

    public class DTODocumRegPrintBase
    {
        public DTODocumRegPrintBase()
        {
            FirmaDeVendedor = string.Empty;
            EmisorCorreoE = string.Empty;
            EmisorDomicilio = string.Empty;
            EmisorPropaganda = string.Empty;
            EmisorRazonSocial = string.Empty;
            EmisorTelefon01 = string.Empty;
            EmisorTelefon02 = string.Empty;
            EmisorUbigeo = string.Empty;
            EmisorWebSite = string.Empty;
            TiempoEntrega = string.Empty;
            LogoAdicionalEmpresa = string.Empty;
        }

        public string EmisorRazonSocial { get; set; }

        public string EmisorDomicilio { get; set; }

        public string EmisorUbigeo { get; set; }

        public string EmisorTelefon01 { get; set; }

        public string EmisorTelefon02 { get; set; }

        public string EmisorWebSite { get; set; }

        public string EmisorCorreoE { get; set; }

        public string EmisorPropaganda { get; set; }

        public string TiempoEntrega { get; set; }

        public string FirmaDeVendedor { get; set; }

        public string LogoAdicionalEmpresa { get; set; }

    }

}

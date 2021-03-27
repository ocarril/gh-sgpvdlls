namespace CROM.BusinessEntities.Comercial.DTO
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 14/11/2020-05:08:32 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [DTODocumentoResponse.cs]
    /// </summary>
    public class DTODocumentoResponse : BEBaseEntidad
    {
        public DTODocumentoResponse()
        {
            listaDocumentoImpuesto = new List<DTODocumentoImpuestoResponse>();
        }

        public string CodigoComprobante { get; set; }
        public string CodigoPersonaEmpre { get; set; }
        public string CodigoArguComprobante { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public string CodigoArguCentroCosto { get; set; }
        public string CodigoComprobanteAsos { get; set; }
        public string CodigoArguDestinoComp { get; set; }
        
        public int LineasComprobante { get; set; }
        public Int16 CantidadCopias { get; set; }
        public int IncidenciaEnStocks { get; set; }
        public int IncidenciaEnCtaCte { get; set; }
        public int IncidenciaEnCaja { get; set; }

        public bool EsImpRetencion { get; set; }
        public bool EsComprobanteImpreso { get; set; }
        public bool EsFacturadoPorLotes { get; set; }
        public bool EsComprobanteFiscal { get; set; }
        public bool EsComprobanteLocal { get; set; }
        public bool EsNumerAutomatica { get; set; }
        public bool EsPFormaPago { get; set; }
        public bool EsSaleCajaDiaria { get; set; }
        public bool PideComprobanteSecun { get; set; }
        public bool PideNroExternoComp { get; set; }
        public bool PideNroExternoComp2 { get; set; }
        public bool PideMoneda { get; set; }
        public bool PideTransportista { get; set; }
        public bool PideMotivo { get; set; }
        public bool PideDepoDestino { get; set; }
        public bool PidePeriodoFiscal { get; set; }
        public bool PideAnioFiscal { get; set; }
        public bool PideCuentaContable { get; set; }
        public bool PideCodigoProducto { get; set; }
        public bool PideDetalle { get; set; }
        public bool PideCantidad { get; set; }
        public bool PideUnidadMedida { get; set; }
        public bool PidePartida { get; set; }
        public bool PidePrecioUnitario { get; set; }
        public bool PideCostoUnitario { get; set; }
        public bool MuestaTotalDetalle { get; set; }
        public bool PideDsctoDetalle { get; set; }
        public bool PideImpuesto { get; set; }
        public bool PideDeposito { get; set; }
        public bool PideFechaVencimiento { get; set; }
        public bool PideVendedor { get; set; }
        public bool PideDespachador { get; set; }
        public bool PideDocumentoecun { get; set; }
        public bool PideFechaEntrega { get; set; }
        public bool PideCondicion { get; set; }
        public bool PideOrdenDeServicio { get; set; }
        public bool PideObservaciones { get; set; }
        public bool PideReferencia01 { get; set; }
        public bool PideReferencia02 { get; set; }
        public bool PideGuiaDeSalida { get; set; }
        public bool PidePedidoDeAdquis { get; set; }
        public bool ExigeDocumentoAnexo { get; set; }
        public bool Estado { get; set; }
        
        public string CodigoArguEstEMIDefault { get; set; }
        public string CodigoArguEstANUDefault { get; set; }
        public string CodigoArguEstPRODefault { get; set; }
        public bool EsGravado { get; set; }
        public string CodigoArguTipoDeOperacionDefault { get; set; }
        public bool PideContactoEntidad { get; set; }
        public bool IndEnviaSUNAT { get; set; }

        
        public List<DTODocumentoImpuestoResponse> listaDocumentoImpuesto { get; set; }
       
        //////[NotMapped]
        public string DefaultCantidadDecimals { get; set; }
        //////[NotMapped]
        public string CodigoArguComprobanteNombre { get; set; }
        //////[NotMapped]
        public string CodigoArguCentroCostoNombre { get; set; }
        //////[NotMapped]
        public string CodigoComprobanteAsosNombre { get; set; }
        //////[NotMapped]
        public string CodigoArguDestinoCompNombre { get; set; }
        //////[NotMapped]
        public string CodigoPersonaEmpreNombre { get; set; }
        //////[NotMapped]
        public string CodigoArguTipoDeOperacionDefaultNombre { get; set; }

    }
} 

namespace CROM.BusinessEntities.Comercial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CROM.BusinessEntities.Almacen;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.ComprobanteEmisionDetalle.cs]
    /// </summary>
    public class BEComprobanteEmisionDetalle
    {
        public BEComprobanteEmisionDetalle()
        {
            gloObservacion = string.Empty;
            listaProductoSeriados = new List<BEProductoSeriado>();
            listaComprobanteEmisionDetalleResumen = new List<BEComprobanteEmisionDetalleResumen>();
            listaDocumRegSerie = new List<BEDocumRegSerie>();
        }
        public List<BEProductoSeriado> listaProductoSeriados { get; set; }
        public List<BEComprobanteEmisionDetalleResumen> listaComprobanteEmisionDetalleResumen { get; set; }
        public List<BEDocumRegSerie> listaDocumRegSerie { get; set; }

        public int codDocumRegDetalle { get; set; }
        public int codDocumReg { get; set; }
        public int codProducto { get; set; }
        public int codEmpresa { get; set; }
        public string CodigoPuntoVenta { get; set; }
        public string NumeroComprobante { get; set; }
        public string CodigoItemDetalle { get; set; }
        public string CodigoComprobante { get; set; }
        public Nullable<DateTime> FechaDeEmision { get; set; }
        public string CodigoProducto { get; set; }
        public string CodigoArguUnidadMed { get; set; }
        public Int16 CantiDecimales { get; set; }
        public bool IncluyeIGV { get; set; }
        public decimal CantidadPendente { get; set; }
        public decimal Cantidad { get; set; }
        public decimal UnitDescuento { get; set; }
        public decimal UnitValorCosto { get; set; }
        public decimal UnitPrecioBruto { get; set; }
        public decimal UnitPrecioSinIGV { get; set; }
        public decimal UnitValorDscto { get; set; }
        public decimal UnitValorVenta { get; set; }
        public decimal UnitValorIGV { get; set; }
        public decimal TotItemValorBruto { get; set; }
        public decimal TotItemValorDscto { get; set; }
        public decimal TotItemValorVenta { get; set; }
        public decimal TotItemValorIGV { get; set; }
        public string Descripcion { get; set; }
        public string CodigoArguTipoProducto { get; set; }
        public string CodigoArguDestinoComp { get; set; }
        public bool EsVerificarStock { get; set; }
        public string CodigoCuenta { get; set; }
        public string CodigoArguDepositoAlm { get; set; }
        public string CodigoArguEstadoDocu { get; set; }
        public string CodigoArguGarantiaProd { get; set; }
        public string CodigoPartida { get; set; }
        public string CodigoCentroCosto { get; set; }
        public string CodigoListaPrecio { get; set; }
        public int? codEmpleadoVendedor { get; set; }
        public decimal Valor_ITC { get; set; }
        public bool Escanner { get; set; }
        public bool Estado { get; set; }
        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public DateTime SegFechaCrea { get; set; }
        public Nullable<DateTime> SegFechaEdita { get; set; }
        public string SegMaquina { get; set; }
        public string itemObservacion { get; set; }

        public string CodigoPersonaEmpreNombre { get; set; }
        public string CodigoPuntoVentaNombre { get; set; }
        public string CodigoComprobanteNombre { get; set; }
        public string CodigoArguUnidadMedNombre { get; set; }
        public string CodigoArguUnidadMedPresen { get; set; }
        public string CodigoArguTipoProductoNombre { get; set; }
        public string CodigoArguDestinoCompNombre { get; set; }
        public string CodigoCuentaNombre { get; set; }
        public string CodigoArguDepositoAlmNombre { get; set; }
        public string CodigoArguEstadoDocuNombre { get; set; }
        public string CodigoArguGarantiaProdNombre { get; set; }
        public string CodigoPartidaNombre { get; set; }
        public string CodigoCentroCostoNombre { get; set; }
        public string CodigoListaPrecioNombre { get; set; }

        public string refCodigoArguMoneda { get; set; }
        public string refCodigoArguMonedaNombre { get; set; }
        public decimal refValorTipoCambio { get; set; }
        public string refCodigoPersonaEntidad { get; set; }
        public string refCodigoPersonaEntidadNombre { get; set; }
        public decimal refTotItemValorVentaExtran { get; set; }
        public string refCodigoArguTipoDeOperacion { get; set; }
        public string refCodigoArguTipoDeOperacionNombre { get; set; }
        public string refEntidadNumeroRUC { get; set; }
        public string refUbigeo { get; set; }
        public decimal PesoUnitario { get; set; }
        public decimal PesoTotal { get; set; }
        public decimal refUnitValorCosto { get; set; }
        public decimal refTotItemValorCosto { get; set; }
        public decimal refTotItemSaldoStock { get; set; }
        public string auxcodEmpleadoNombre { get; set; }
        public string auxcodEmpleadoVendedorNombre { get; set; }

        public int auxcodInventario { get; set; }



        public int? codTipoTributoISC { get; set; }
        public decimal? mtoIscItem { get; set; }
        public decimal? mtoBaseIscItem { get; set; }
        public int? codTipoCalculoISC { get; set; }
        public decimal? porIscItem { get; set; }
        public int? codTipoTributoOtro { get; set; }
        public decimal? mtoTriOtroItem { get; set; }
        public decimal? mtoBaseTriOtroItem { get; set; }
        public decimal? porTriOtroItem { get; set; }
        public decimal? mtoValorReferencialUnitario { get; set; }

        public string gloObservacion { get; set; }


    }
} 

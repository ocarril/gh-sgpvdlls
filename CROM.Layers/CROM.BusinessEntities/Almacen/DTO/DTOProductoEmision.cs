namespace CROM.BusinessEntities.Almacen
{

    using CROM.BusinessEntities;
    using System;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento - 
    ///               Contiene datos principales del producto al momento de emitir un documento: 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 24/06/2020-08:42:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.DTOProductoEmision.cs]
    /// </summary>
    public class DTOProductoEmision : BEBaseEntidadItem
    {
        public DTOProductoEmision()
        {

        }

        public int codProducto { get; set; }
        public string keyProducto { get; set; }
        public string desNombre { get; set; }

        public string codRegTipoProducto { get; set; }
        public string codRegUnidadMedida { get; set; }
        public string codRegMoneda { get; set; }
        public string codDeposito { get; set; }


        public bool indEditaDescripcion { get; set; }
        public bool indDestinadoACompra { get; set; }
        public bool indDestinadoAVenta { get; set; }
        public bool indVerificacionStock { get; set; }
        public bool indConNumeroSeriado { get; set; }
        public bool indPerecible { get; set; }
        public bool indEsGarantizado { get; set; }
        public bool indEditaValorVenta { get; set; }
        public bool indEditaValorCosto { get; set; }
        public bool indEsListaPrecio { get; set; }
        public bool indEsComboDeOferta { get; set; }

        public decimal monValorCosto { get; set; }
        public decimal monValorVenta { get; set; }


        public decimal cntPesoTotal { get; set; }
        public decimal? cntStockMinimo { get; set; }
        public decimal? cntStockMaximo { get; set; }
        public decimal? cntStockFisico { get; set; }
        public decimal? cntStockInicial { get; set; }
        public decimal? cntStockSobrante { get; set; }
        public decimal? cntStockComprometido { get; set; }

        public decimal? prcImpuestoIGV { get; set; }
        public bool indIncluyeIGV { get; set; }


        public string codGrupoNombre { get; set; }
        public string codMarcaNombre { get; set; }
        public string codModeloNombre { get; set; }
        public string codRegTipoProductoNombre { get; set; }
        public string codRegCategoriaNombre { get; set; }
        public string codRegUnidadMedidaNombre { get; set; }
        public string codPuntoVentaNombre { get; set; }
        public string codRegMonedaNombre { get; set; }
        public string codRegMonedaSimbolo { get; set; }
        public Nullable<DateTime> fecUltimoPrecio { get; set; }
        public string codDepositoNombre { get; set; }


    }
}
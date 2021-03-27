namespace CROM.BusinessEntities.Almacen
{

    using CROM.BusinessEntities;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 19/04/2018-06:24:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.DTOProducto.cs]
    /// </summary>
    public class DTOProducto : BEBasePagedResponse
    {
        public DTOProducto()
        {

        }

        public int codProducto { get; set; }
        public string codGrupoNombre { get; set; }
        public string CodigoProducto { get; set; }
        public string CodigoProductoRefer { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAbreviada { get; set; }
        public string codRegMarcaProdu { get; set; }
        public string codRegMarcaProduNombre { get; set; }
        public string codRegModeloProduNombre { get; set; }
        public string codRegTipoProductoNombre { get; set; }
        public string codRegSectorAlmNombre { get; set; }
        public string codRegMetodoAlmNombre { get; set; }
        public string codRegCentroProdNombre { get; set; }
        public string codRegColorNombre { get; set; }
        public string codRegCategoProdNombre { get; set; }
        public string codRegUnidadMedNombre { get; set; }


        public bool indEditaDescripcion { get; set; }
        public bool indDestinadoACompra { get; set; }
        public bool indDestinadoAVenta { get; set; }
        public bool indVerificacionStock { get; set; }
        public bool indConNumeroSeriado { get; set; }
        public bool indEsPerecible { get; set; }
        public bool indPerecible { get; set; }
        public bool indEsGarantizado { get; set; }
        public bool indEditaValorVenta { get; set; }
        public bool indEditaValorCosto { get; set; }
        public bool indEsListaPrecio { get; set; }
        public bool indEsComboDeOferta { get; set; }


        public string codPuntoVentaNombre { get; set; }
        public string codRegMonedaNombre { get; set; }
        public string codRegMonedaSimbolo { get; set; }
        public decimal ValorCosto { get; set; }
        public decimal ValorVenta { get; set; }
        public string fecPrecio { get; set; }
        public string codDepositoNombre { get; set; }
        public decimal PesoTotal { get; set; }
        public decimal? StockMinimo { get; set; }
        public decimal? StockMaximo { get; set; }
        public decimal? StockFisico { get; set; }
        public decimal? StockInicial { get; set; }
        public decimal? StockSobrante { get; set; }
        public decimal? StockComprometido { get; set; }
    }
}
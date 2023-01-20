namespace CROM.BusinessEntities.Almacen
{
    using CROM.BusinessEntities;
    using System;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2021-03:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.Producto.cs]
    /// </summary>
    public class DTOProductoPagedResponse : BEBasePagedResponse
    {
        public DTOProductoPagedResponse()
        {
            
        }

        public BEProductoPrecio itemProductoPrecio { get; set; }

        public int codProducto { get; set; }

        public string keyProducto { get; set; }

        public string codProductoRefer { get; set; }

        public string desNombre { get; set; }

        public string codGrupoNombre { get; set; }

        public string desNombreAbrev { get; set; }

        public string codMarcaNombre { get; set; }

        public string codModeloNombre { get; set; }

        public string codRegTipoProductoNombre { get; set; }

        public string codCategoriaNombre { get; set; }

        public string codRegUnidadMedNombre { get; set; }

        public bool indIncluyeIGV { get; set; }

        public bool indEditaDescripcion { get; set; }

        public bool indDestinadoACompra { get; set; }

        public bool indDestinadoAVenta { get; set; }

        public bool indVerificacionStock { get; set; }

        public bool indConNumeroSeriado { get; set; }

        public bool indEsPerecible { get; set; }

        public bool indEsGarantizado { get; set; }

        public bool indEditaValorVenta { get; set; }

        public bool indEditaValorCosto { get; set; }

        public bool indEsListaPrecio { get; set; }

        public bool indEsComboDeOferta { get; set; }

        public decimal cntPesoTotal { get; set; }

        public decimal? cntStockMinimo { get; set; }

        public decimal? cntStockMaximo { get; set; }

        public string codRegMonedaSimbolo { get; set; }
 
        public string codRegMonedaNombre { get; set; }

        public decimal monValorCosto { get; set; }

        public decimal monValorVenta { get; set; }

        public DateTime? fecUltimoPrecio { get; set; }



        public decimal? cntStockFisico { get; set; }

        public decimal? cntStockInicial { get; set; }

        public decimal? cntStockSobrante { get; set; }

        public decimal? cntStoskComprometido { get; set; }

        public string codDepositoNombre { get; set; }



    }

   
}

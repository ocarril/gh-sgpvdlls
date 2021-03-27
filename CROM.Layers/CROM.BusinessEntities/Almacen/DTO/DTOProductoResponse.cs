namespace CROM.BusinessEntities.Almacen
{
    using CROM.BusinessEntities;
    using CROM.BusinessEntities.Comercial;

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.Producto.cs]
    /// </summary>
    public class DTOProductoResponse : BEBaseEntidad
    {
        public DTOProductoResponse()
        {
            itemProductoPrecio = new BEProductoPrecio();
        }

        public BEProductoPrecio itemProductoPrecio { get; set; }

        public int codProducto { get; set; }
        public int? codGrupo { get; set; }

        public string CodigoProducto { get; set; }
        public string CodigoProductoRefer { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionComercial { get; set; }
        public string DescripcionAbreviada { get; set; }
        public string Observacion { get; set; }
        public string DatoAdicional_01 { get; set; }
        public string DatoAdicional_02 { get; set; }

        public int? codMarca { get; set; }

        public int? codModelo { get; set; }

        public string CodigoArguTipoProducto { get; set; }

        public bool DestinadoACompra { get; set; }
        public bool DestinadoAVenta { get; set; }
        public string CodigoArguSectorAlm { get; set; }
        public string CodigoArguMetodoAlm { get; set; }
        public string CodigoArguCentroProd { get; set; }
        public string CodigoArguColor { get; set; }
        public string CodigoArguCategoProd { get; set; }
        public string CodigoArguUnidadMed { get; set; }
        public string CodigoCuenta { get; set; }

        public bool EditaDescripcion { get; set; }
        public bool EditaValorVenta { get; set; }
        public bool EditaValorCosto { get; set; }
        public bool EsComboDeOferta { get; set; }
        public bool EsListaPrecio { get; set; }
        public bool EsPerecible { get; set; }
        public bool EsVerificacionStock { get; set; }
        public bool EsConNumeroSeriado { get; set; }

        public bool Estado { get; set; }

        public string PalabrasClaves { get; set; }
        public decimal PesoTotal { get; set; }

        public decimal? StockMinimo { get; set; }
        public decimal? StockMaximo { get; set; }
        public bool indEsGarantizado { get; set; }


        ////[NotMapped]
        public decimal? StockFisico { get; set; }
        ////[NotMapped]
        public decimal? StockInicial { get; set; }
        ////[NotMapped]
        public decimal? StockSobrante { get; set; }
        ////[NotMapped]
        public decimal? StoskComprometido { get; set; }
        ////[NotMapped]
        public string codGrupoNombre { get; set; }
        ////[NotMapped]
        public string codMarcaNombre { get; set; }

        public string codModeloNombre { get; set; }

        ////[NotMapped]
        public string CodigoArguTipoProductoNombre { get; set; }
        ////[NotMapped]
        public string CodigoArguSectorAlmNombre { get; set; }
        ////[NotMapped]
        public string CodigoArguMetodoAlmNombre { get; set; }
        public string CodigoArguCentroProdNombre { get; set; }
        ////[NotMapped]
        public string CodigoArguColorNombre { get; set; }
        public string CodigoArguCategoProdNombre { get; set; }
        ////[NotMapped]
        public string CodigoCuentaNombre { get; set; }
        public string CodigoArguUnidadMedNombre { get; set; }
        ////[NotMapped]
        public string codDeposito { get; set; }
        ////[NotMapped]
        public string codDepositoNombre { get; set; }
        public string codEmpresaRUC { get; set; }
        ////[NotMapped]
        public string numeroSerie { get; set; }

        ////[NotMapped]
        public int? cntInventariar { get; set; }

        ////[NotMapped]
        public string codPuntoVenta { get; set; }
        ////[NotMapped]
        public string codPuntoVentaNombre { get; set; }

        ////[NotMapped]
        public string codRegMoneda { get; set; }
        ////[NotMapped]
        public string codRegMonedaSimbolo { get; set; }
        ////[NotMapped]
        public string codRegMonedaNombre { get; set; }
        public string codListaPrecio { get; set; }
        ////[NotMapped]
        public decimal ValorCosto { get; set; }
        ////[NotMapped]
        public decimal ValorVenta { get; set; }
        ////[NotMapped]
        public string fecPrecio { get; set; }
        ////[NotMapped]
        public decimal prcDescuentoMaximo { get; set; }

        public bool indActualizaPrecioTodos { get; set; }
    }

   
}

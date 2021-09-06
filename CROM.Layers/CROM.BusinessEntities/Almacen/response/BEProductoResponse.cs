namespace CROM.BusinessEntities.Almacen.response
{
    using CROM.BusinessEntities;

    using System;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 04/09/2021-11:23:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.Producto.cs]
    /// </summary>
    public class BEProductoResponse : BEBaseMaestro
    {
        public BEProductoResponse()
        {

        }

        public int codProducto { get; set; }

        public string keyProducto { get; set; }

        public string CodigoProductoRefer { get; set; }

        public int? codGrupo { get; set; }

        public string Descripcion { get; set; }

        public string DescripcionComercial { get; set; }

        public string DescripcionAbreviada { get; set; }

        public string Observacion { get; set; }

        public string DatoAdicional_01 { get; set; }

        public string DatoAdicional_02 { get; set; }

        public int? codMarca { get; set; }

        public int? codModelo { get; set; }

        public string codRegTipoProducto { get; set; }

        public bool DestinadoACompra { get; set; }

        public bool DestinadoAVenta { get; set; }

        public int? codSector { get; set; }

        public string codRegMetodoAlm { get; set; }

        public int? codCentroProduccion { get; set; }

        public string codRegColor { get; set; }

        public int codCategoria { get; set; }

        public string codRegUnidadMedida { get; set; }

        public int? codLinea { get; set; }

        public string codCuenta { get; set; }

        public bool EditaDescripcion { get; set; }

        public bool EditaValorVenta { get; set; }

        public bool EditaValorCosto { get; set; }

        public bool EsComboDeOferta { get; set; }

        public bool EsListaPrecio { get; set; }

        public bool EsPerecible { get; set; }

        public bool EsVerificacionStock { get; set; }

        public bool EsConNumeroSeriado { get; set; }

        public string PalabrasClaves { get; set; }

        public decimal PesoTotal { get; set; }

        public decimal? StockMinimo { get; set; }

        public decimal? StockMaximo { get; set; }

        public bool indEsGarantizado { get; set; }



        public string codRegMoneda { get; set; }

        public string codRegMonedaNombre { get; set; }

        public string codRegMonedaSimbolo { get; set; }

        public decimal ValorCosto { get; set; }

        public decimal ValorVenta { get; set; }

        public DateTime fecUltimoPrecio { get; set; }

        public decimal DescuentoMaximo { get; set; }

        public string codListaPrecio { get; set; }

        public decimal MargenUtilidad { get; set; }

        public decimal MediaPorcentaje { get; set; }

        public decimal PorcenComision { get; set; }

        public decimal PorcenComisionMax { get; set; }

        public int codProductoPrecio { get; set; }
    }

}

namespace CROM.BusinessEntities.Almacen.request
{
    using CROM.BusinessEntities;
    using CROM.BusinessEntities.Comercial;

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 04/09/2021-11:23:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.Producto.cs]
    /// </summary>
    public class BEProductoRequest : BEBaseEntidadRequest
    {
        public BEProductoRequest()
        {
            listaProductoClave = new List<BEProductoClaveRequest>();
            listaProductoProveedores = new List<BEProductoProveedorRequest>();
            itemProductoFoto = new BEProductoFotoRequest();
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

        public bool Estado { get; set; }

        public string PalabrasClaves { get; set; }

        public decimal PesoTotal { get; set; }

        public decimal? StockMinimo { get; set; }

        public decimal? StockMaximo { get; set; }

        public bool indEsGarantizado { get; set; }

        public List<BEProductoClaveRequest> listaProductoClave { get; set; }

        public List<BEProductoProveedorRequest> listaProductoProveedores { get; set; }

        public BEProductoFotoRequest itemProductoFoto { get; set; }

    }


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 29/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// </summary>
    public class BEProductoClaveRequest
    {
        public BEProductoClaveRequest()
        {

        }
        public string CodigoProductoClave { get; set; }

        public int codProducto { get; set; }

        public string DescripcionClave { get; set; }

        public string CodigoProducto { get; set; }
    }

}

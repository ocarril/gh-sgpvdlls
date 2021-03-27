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
    public class BEProducto : BEBaseEntidad
    {
        public BEProducto()
        {
            listaProductoClave = new List<ProductoClave>();
            listaProductoKardex = new List<ProductoKardexAux>();
            listaProductoPartes = new List<BEProductoParte>();
            listaProductoProveedores = new List<BEProductoProveedor>();
            listaProductoProductoSeriados = new List<BEProductoSeriado>();
            listaProductoMovimientos = new List<ProductoMovimientos>();
            listaProductoVentas = new List<ResumenVentasMensuales>();
            listaListaDePrecioDetalle = new List<BEListaDePrecioDetalle>();
            listaProductoPrecio = new List<BEProductoPrecio>();
            itemProductoExistencias = new List<BEProductoExistencia>();
            itemProductoFoto = new BEProductoFoto();
            itemProductoPrecio = new BEProductoPrecio();
        }

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

        public BEProductoFoto itemProductoFoto { get; set; }
        public BEProductoPrecio itemProductoPrecio { get; set; }
        public List<BEProductoExistencia> itemProductoExistencias { get; set; }
        public List<BEProductoParte> listaProductoPartes { get; set; }
        public List<ProductoClave> listaProductoClave { get; set; }
        public List<ProductoKardexAux> listaProductoKardex { get; set; }
        public List<BEProductoProveedor> listaProductoProveedores { get; set; }
        public List<BEProductoSeriado> listaProductoProductoSeriados { get; set; }
        public List<ProductoMovimientos> listaProductoMovimientos { get; set; }
        public List<ResumenVentasMensuales> listaProductoVentas { get; set; }
        public List<BEProductoPrecio> listaProductoPrecio { get; set; }
        public List<BEListaDePrecioDetalle> listaListaDePrecioDetalle { get; set; }



        public string codRegMoneda { get; set; }

        public string codRegMonedaSimbolo { get; set; }

        public string codRegMonedaNombre { get; set; }
        public decimal ValorCosto { get; set; }

        public decimal ValorVenta { get; set; }

        public string fecPrecio { get; set; }

        public decimal prcDescuentoMaximo { get; set; }

        //////[NotMapped]
        //public decimal? StockFisico { get; set; }
        //////[NotMapped]
        //public decimal? StockInicial { get; set; }
        //////[NotMapped]
        //public decimal? StockSobrante { get; set; }
        //////[NotMapped]
        //public decimal? StoskComprometido { get; set; }
        //////[NotMapped]
        //public string codGrupoNombre { get; set; }
        //////[NotMapped]
        //public string codMarcaNombre { get; set; }

        //public string codModeloNombre { get; set; }

        //////[NotMapped]
        //public string CodigoArguTipoProductoNombre { get; set; }
        //////[NotMapped]
        //public string CodigoArguSectorAlmNombre { get; set; }
        //////[NotMapped]
        //public string CodigoArguMetodoAlmNombre { get; set; }
        //public string CodigoArguCentroProdNombre { get; set; }
        //////[NotMapped]
        //public string CodigoArguColorNombre { get; set; }
        //public string CodigoArguCategoProdNombre { get; set; }
        //////[NotMapped]
        //public string CodigoCuentaNombre { get; set; }
        //public string CodigoArguUnidadMedNombre { get; set; }
        //////[NotMapped]
        //public string codDeposito { get; set; }
        //////[NotMapped]
        //public string codDepositoNombre { get; set; }
        //public string codEmpresaRUC { get; set; }
        //////[NotMapped]
        //public string numeroSerie { get; set; }

        //////[NotMapped]
        //public int? cntInventariar { get; set; }

        //////[NotMapped]
        //public string codPuntoVenta { get; set; }
        //////[NotMapped]
        //public string codPuntoVentaNombre { get; set; }

        ////[NotMapped]

        //public string codListaPrecio { get; set; }
        //////[NotMapped]

        //public bool indActualizaPrecioTodos { get; set; }
    }

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 29/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// </summary>
    public class ProductoClave
    {
        public string CodigoProductoClave { get; set; }
        public int codProducto { get; set; }
        public string DescripcionClave { get; set; }

        public bool Estado { get; set; }
        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public DateTime SegFechaCrea { get; set; }
        public Nullable<DateTime> SegFechaEdita { get; set; }
        public string SegMaquina { get; set; }
        public string CodigoProducto { get; set; }
    }

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 29/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// </summary>
    public class ProductoMovimientos
    {
        public int codProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string CodigoProductoNombre { get; set; }
        public Nullable<DateTime> FechaDeEmision { get; set; }
        public decimal Cantidad { get; set; }

        public decimal UnitPrecioSinIGV { get; set; }
        public decimal UnitValorDscto { get; set; }
        public decimal UnitValorVenta { get; set; }
        public decimal TotItemValorVenta { get; set; }
        public decimal UnitValorIGV { get; set; }
        public decimal TotItemValorIGV { get; set; }

        public decimal UnitValorVentaMnInt { get; set; }
        public decimal UnitValorIGVMnInt { get; set; }
        public decimal TotItemValorVentaMnInt { get; set; }
        public decimal TotItemValorIGVMnInt { get; set; }

        public string CodigoArguMoneda { get; set; }
        public string CodigoArguMonedaNombre { get; set; }
        public decimal ValorTipoCambioVTA { get; set; }
        public decimal ValorTipoCambioCMP { get; set; }
        public string NumeroComprobante { get; set; }

        public string EntidadRazonSocial { get; set; }
        public string CodigoArguTipoDeOperacion { get; set; }
        public string CodigoArguTipoDeOperacionNombre { get; set; }

        public string CodigoComprobante { get; set; }
        public string CodigoComprobanteNombre { get; set; }
    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 24/08/2010-00:12:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// </summary>
    public class ResumenVentasMensuales
    {
        public int codProducto { get; set; }
        public string codigoProducto { get; set; }
        public string Descripcion { get; set; }
        public int Años { get; set; }
        public string Meses { get; set; }
        public decimal Cantidad { get; set; }
        public decimal MontoNacional { get; set; }
        public decimal MontoExtranje { get; set; }
        public decimal TipoCambio { get; set; }
        public int ItemMes { get; set; }
        public string CodigoArguTipoDeOperacion { get; set; }
        public string CodigoArguTipoDeOperacionNombre { get; set; }
    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// </summary>
    public class ProductoCodBarras
    {
        public ProductoCodBarras()
        {

        }
        public int codProducto { get; set; }
        public string codigoProducto { get; set; }
        public string codProductoRefer { get; set; }
        public string codProveedores { get; set; }
        public string desNombre { get; set; }

        public string codRegistroMoneda { get; set; }
        public decimal monPrecioVenta { get; set; }
        public decimal canStockFisico { get; set; }
        public decimal canBarraImprime { get; set; }
    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/02/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// </summary>
    public class ProductoEtiqueta
    {
        public ProductoEtiqueta()
        {

        }

        public string codProducto { get; set; }
        public string desNombre { get; set; }

        public string codRegistroUnidMed { get; set; }
        public decimal canPeso { get; set; }
        public DateTime fecVencimiento { get; set; }
        public string codLote { get; set; }
        public string desDato01 { get; set; }
        public string desDato02 { get; set; }
    }
}

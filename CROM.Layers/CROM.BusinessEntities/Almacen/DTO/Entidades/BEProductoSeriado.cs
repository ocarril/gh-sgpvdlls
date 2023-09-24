namespace CROM.BusinessEntities.Almacen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CROM.BusinessEntities.Maestros;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 04/02/2010-04:01:30 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.ProductoSeriados.cs]
    /// </summary>
    public class BEProductoSeriado:BEBaseEntidad
    {
        public BEProductoSeriado()
        {
            objProducto = new BEProducto();
            objDeposito = new BEDeposito();
            objPersonaCliente = new BEPersona();
            objPersonaComprimetido= new BEPersona();
            objPersonäProveedor  = new BEPersona();
            objEstadoMercaderia = new BERegistroNew();
        }

        public int codProductoSeriado { get; set; }

        public int codProducto { get; set; }
        public string CodigoRegistro { get; set; }
        public int codDeposito { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Nullable<DateTime> FechaVencimiento { get; set; }
        public string NumeroLote { get; set; }
        public string NumeroSerie { get; set; }
        public decimal Cantidad { get; set; }

        public bool EstadoVendido { get; set; }
        public Nullable<DateTime> FechaVenta { get; set; }
        public string NumeroComprobanteVenta { get; set; }
        public string CodigoPersonaCliente { get; set; }

        public bool EstaComprometido { get; set; }
        public Nullable<DateTime> FechaComprometido { get; set; }
        public string NumeroComprobanteComprom { get; set; }
        public string CodigoPersonaComprometido { get; set; }

        public bool Estado { get; set; }

        public string CodigoPersonaProveedor { get; set; }
        public string NumeroComprobanteCompra { get; set; }

        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public DateTime SegFechaCrea { get; set; }
        public Nullable<DateTime> SegFechaEdita { get; set; }
        public string SegMaquina { get; set; }
        public string codRegEstadoMercaderia { get; set; }
        
        public string CodigoPersonaEmpre { get; set; }
        public string CodigoPuntoVenta { get; set; }
        public string codigoProducto { get; set; }

        public string perInventario { get; set; }
        public bool? indRegularizar { get; set; }

        public BEProducto objProducto { get; set; }
        public BEDeposito objDeposito { get; set; }
        public BEPersona objPersonaCliente { get; set; }
        public BEPersona objPersonaComprimetido { get; set; }
        public BEPersona objPersonäProveedor { get; set; }
        public BERegistroNew objEstadoMercaderia { get; set; }


        public string CodigoPersonaProveedorNombre { get; set; }
        public string CodigoPersonaClienteNombre { get; set; }
        public string CodigoPersonaComprometidoNombre { get; set; }
        public string CodigoPersonaEmpreNombre { get; set; }
        public string CodigoPuntoVentaNombre { get; set; }
        public string codDepositoNombre { get; set; }
        public string codRegEstadoMercaderiaNombre { get; set; }

    }
}

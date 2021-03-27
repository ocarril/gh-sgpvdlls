namespace CROM.BusinessEntities.Almacen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Produccion.ProductoPartesAtributo.cs]
    /// </summary>
    public class BEProductoParteAtributo
    {
        public string CodigoProducto { get; set; }
        public string CodigoArguParteProdu { get; set; }
        public string CodigoArguAtributoPP { get; set; }
        public decimal Valor { get; set; }
        public decimal Tolerancia { get; set; }
        public bool Estado { get; set; }

        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public DateTime SegFechaCrea { get; set; }
        public DateTime SegFechaEdita { get; set; }
        public string SegMaquina { get; set; }

        public string CodigoArguParteProduNombre { get; set; }
        public string CodigoArguAtributoPPNombre { get; set; }
    }
}

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
    /// Archivo     : [Almacen.ProductoProveedores.cs]
    /// </summary>
    public class BEProductoProveedor : BEBaseEntidad
    {
        public BEProductoProveedor()
        {
            CodigoPersona = string.Empty;
            codigoProducto = string.Empty;
            CodigoPersonaNombre = string.Empty;

        }

        public int? codProductoProveedor { get; set; }

        public int? codProducto { get; set; }
        public string CodigoPersona { get; set; }
        public bool Estado { get; set; }

        public string codigoProducto { get; set; }
        public string CodigoPersonaNombre { get; set; }
    }
}

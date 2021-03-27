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
    /// Archivo     : [Almacen.ProductoFotos.cs]
    /// </summary>
    public class BEProductoFoto : BEBase
    {
        public int codProductoFoto { get; set; }

        public int codProducto { get; set; }
        public byte[] FotografiaF { get; set; }
        public string Fotografia { get; set; }
        public bool Estado { get; set; }

        public string CodigoProducto { get; set; }
    }
}

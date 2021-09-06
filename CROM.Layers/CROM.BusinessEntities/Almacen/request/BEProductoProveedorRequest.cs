namespace CROM.BusinessEntities.Almacen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 04/09/2021 14:52:47 h.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.ProductoProveedores.cs]
    /// </summary>
    public class BEProductoProveedorRequest : BEBaseEntidadRequest
    {
        public BEProductoProveedorRequest()
        {
            CodigoPersona = string.Empty;

        }

        public int? codProductoProveedor { get; set; }

        public int? codProducto { get; set; }

        public string CodigoPersona { get; set; }

        public bool Estado { get; set; }
    }
}

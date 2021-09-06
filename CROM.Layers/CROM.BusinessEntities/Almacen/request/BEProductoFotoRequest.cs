namespace CROM.BusinessEntities.Almacen.request
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 04/09/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.ProductoFotos.cs]
    /// </summary>
    public class BEProductoFotoRequest : BEBaseEntidadRequest
    {
        public BEProductoFotoRequest()
        {

        }

        public int codProductoFoto { get; set; }

        public int codProducto { get; set; }

        public byte[] imgFotografia { get; set; }

        public string desFotografia { get; set; }

        public bool indActivo { get; set; }

    }
}

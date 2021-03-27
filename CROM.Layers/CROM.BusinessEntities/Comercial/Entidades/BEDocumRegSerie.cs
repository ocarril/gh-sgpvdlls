namespace CROM.BusinessEntities.Comercial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CROM.BusinessEntities.Almacen;
    
    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 20/11/2013-05:21:18
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.DocumRegSerie.cs]
    /// </summary>
    public class BEDocumRegSerie : BEBase
    {
        public BEDocumRegSerie()
        {
            objDocumRegDetalle = new BEComprobanteEmisionDetalle();
            objProductoSeriado = new BEProductoSeriado();
            objProducto = new BEProducto();
        }

        public int codDocumRegSerie { get; set; }
        public int codDocumRegDetalle { get; set; }
        public int codProductoSeriado { get; set; }
        public int codProducto { get; set; }

        public BEComprobanteEmisionDetalle objDocumRegDetalle { get; set; }
        public BEProductoSeriado objProductoSeriado { get; set; }
        public BEProducto objProducto { get; set; }


    }
} 

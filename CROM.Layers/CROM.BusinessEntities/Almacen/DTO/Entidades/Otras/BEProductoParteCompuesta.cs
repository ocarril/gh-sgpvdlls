namespace CROM.BusinessEntities.Almacen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 25/02/2011-1:25:14
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.ProductoPartesCompuesta.cs]
    /// </summary>
    public class BEProductoParteCompuesta
    {
        public string CodigoProducto { get; set; }
        public string CodigoProductoParte { get; set; }
        public string CodigoArguUnidadMedC { get; set; }
        public string CodigoArguUnidadMedP { get; set; }
        public decimal Cantidad { get; set; }
        public bool DescontarStock { get; set; }
        public bool Estado { get; set; }
        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public DateTime SegFechaCrea { get; set; }
        public DateTime SegFechaEdita { get; set; }
        public string SegMaquina { get; set; }

        public string CodigoProductoNombre { get; set; }
        public string CodigoProductoParteNombre { get; set; }
        public string CodigoArguUnidadMedCNombre { get; set; }
        public string CodigoArguUnidadMedPNombre { get; set; }

    }
}

namespace CROM.BusinessEntities.Almacen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 19/04/2014-11:35:24 p.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.InventarioSerie.cs]
    /// </summary>
    public class BEInventarioSerie : BEBase
    {
        public BEInventarioSerie()
        {
            objInventario = new BEInventario();
            objProductoSerie = new BEProductoSeriado();
        }

        public int codInventarioSerie { get; set; }
        public int codInventario { get; set; }
        public int codProductoSeriado { get; set; }
        public bool indExisteFisico { get; set; }
        public int numConteo { get; set; }

        public BEInventario objInventario { get; set; }
        public BEProductoSeriado objProductoSerie { get; set; }

    }
}

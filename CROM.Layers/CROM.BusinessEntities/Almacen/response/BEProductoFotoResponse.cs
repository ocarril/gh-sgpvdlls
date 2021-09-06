namespace CROM.BusinessEntities.Almacen.response
{
    using CROM.BusinessEntities;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 04/09/2021-11:23:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.Producto.cs]
    /// </summary>
    public class BEProductoFotoResponse : BEBaseEntidadItem
    {
        public BEProductoFotoResponse()
        {

        }
        
        public int codProductoFoto { get; set; }

        public int codProducto { get; set; }

        public byte[] imgFotografia { get; set; }

        public string desFotografia { get; set; }

        public string codigoProducto { get; set; }
    }

}

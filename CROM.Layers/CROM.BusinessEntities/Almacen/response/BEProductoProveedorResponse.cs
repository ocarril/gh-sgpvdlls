namespace CROM.BusinessEntities.Almacen
{
    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 04/09/2021 14:52:47 h.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.ProductoProveedores.cs]
    /// </summary>
    public class BEProductoProveedorResponse : BEBaseEntidadItem
    {
        public BEProductoProveedorResponse()
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

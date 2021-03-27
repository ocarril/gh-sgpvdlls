namespace CROM.BusinessEntities.Almacen
{
    using Newtonsoft.Json;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.ProductoProveedores.cs]
    /// </summary>
    public class DTOProductoProveedorResponse : BEBasePagedResponse
    {
        public DTOProductoProveedorResponse()
        {
            codigoProducto = string.Empty;
            codPersona = string.Empty;
            codPersonaNombre = string.Empty;
        }

        [JsonProperty("codProductoProveedor")]
        public int? codProductoProveedor { get; set; }

        [JsonProperty("codigoProducto")]
        public string codigoProducto { get; set; }

        [JsonProperty("codPersona")]
        public string codPersona { get; set; }

        [JsonProperty("codPersonaNombre")]
        public string codPersonaNombre { get; set; }
    }
}

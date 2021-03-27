namespace CROM.BusinessEntities.Comercial.DTO
{
    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 26/06/2020-6:51:18
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.DTODocumentoImpuestoResponse.cs]
    /// </summary>
    public class DTODocumentoImpuestoResponse : BEBaseEntidadItem
    {
        public DTODocumentoImpuestoResponse()
        {
            objImpuesto = new BEImpuesto();
        }

        public int codDocumentoImpuesto { get; set; }
        public string CodigoComprobante { get; set; }
        public string CodigoImpuesto { get; set; }
        public bool VeoImporte { get; set; }
        public int Orden { get; set; }
                
        public BEImpuesto objImpuesto { get; set; }

        public string CodigoComprobanteNombre { get; set; }
        public string CodigoImpuestoNombre { get; set; }

    }
}

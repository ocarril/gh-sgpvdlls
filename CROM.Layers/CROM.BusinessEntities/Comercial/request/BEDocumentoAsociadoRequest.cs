namespace CROM.BusinessEntities.Comercial.request
{
    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 08/12/2022-17:37:18
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.BEDocumentoAsociado.cs]
    /// </summary>
    public class BEDocumentoAsociadoRequest : BEBaseEntidadRequest
    {
        public BEDocumentoAsociadoRequest()
        {
           
        }

        public int codDocumentoAsociado { get; set; }

        public string codDocumento { get; set; }

        public string codDocumentoOrigen { get; set; }

        public bool indActivo { get; set; }
               

    }
}

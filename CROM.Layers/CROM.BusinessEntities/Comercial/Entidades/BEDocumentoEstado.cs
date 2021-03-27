namespace CROM.BusinessEntities.Comercial
{
    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 22/08/2014-01:07:10 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.DocumentoEstado.cs]
    /// </summary>
    public class BEDocumentoEstado : BEBase
    {

        public BEDocumentoEstado()
        {
            auxcodRegEstado = string.Empty;
            codRegDocumento = string.Empty;
            auxcodRegDocumento = string.Empty;
            codRegEstado = string.Empty;
        }

        public int codDocumentoEstado { get; set; }

        public string codRegDocumento { get; set; }

        public string codRegEstado { get; set; }

        public int codEstado { get; set; }

        public bool indActivo { get; set; }

        public string auxcodRegDocumento { get; set; }

        public string auxcodRegEstado { get; set; }

        public string codRegEstadoColor { get; set; }

    }
}

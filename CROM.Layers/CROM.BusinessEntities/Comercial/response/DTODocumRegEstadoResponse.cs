namespace CROM.BusinessEntities.Comercial.response
{
    using System;

    public class DTODocumRegEstadoResponse : BEBasePagedResponse
    {
        public DTODocumRegEstadoResponse()
        {
            codDocumentoEstadoNombre = string.Empty;
            codDocumentoEstadoColor = string.Empty;
            gloSuceso = string.Empty;
            segUsuarioEdita = string.Empty;
            segUsuarioEdita = string.Empty;
        }

        public long codDocumRegEstado { get; set; }

        public int codDocumReg { get; set; }

        public int codDocumentoEstado { get; set; }

        public string codDocumentoEstadoNombre { get; set; }

        public string codDocumentoEstadoColor { get; set; }

        public DateTime fecSuceso { get; set; }

        public string gloSuceso { get; set; }

        public bool indEliminado { get; set; }
        
    }
}

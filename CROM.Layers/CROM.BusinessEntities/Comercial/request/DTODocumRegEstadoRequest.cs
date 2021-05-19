namespace CROM.BusinessEntities.Comercial.request
{
    public class DTODocumRegEstadoRequest: BEBaseEntidadRequest
    {

        public DTODocumRegEstadoRequest()
        {

            gloSuceso = string.Empty;
            segUsuarioEdita = string.Empty;
            segUsuarioEdita = string.Empty;
        }

        public long codDocumRegEstado { get; set; }

        public int codDocumReg { get; set; }

        public int codDocumentoEstado { get; set; }

        public string gloSuceso { get; set; }

        public bool indEliminado { get; set; }


        public string codRegEstado { get; set; }

    }


    public class DTODocumRegEstadoFoundRequest: BEBuscadorBaseRequest
    {
        public DTODocumRegEstadoFoundRequest()
        {

        }

        public int codDocumReg { get; set; }

    }
}

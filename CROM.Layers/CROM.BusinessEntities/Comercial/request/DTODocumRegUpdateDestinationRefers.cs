namespace CROM.BusinessEntities.Comercial.request
{
    using Newtonsoft.Json;

    public class DTODocumRegUpdateDestinationRefers : BEBaseEntidadItem
    {
        public DTODocumRegUpdateDestinationRefers()
        {

            codDocumentoOrigen = string.Empty;
            numDocumentoOrigenFull = string.Empty;
        }

        public int codDocumReg { get; set; }

        [JsonIgnore]
        public string codDocumentoOrigen { get; set; }

        [JsonIgnore]
        public string numDocumentoOrigenFull { get; set; }

        [JsonIgnore]
        public int? codDocumentoEstadoOrigen { get; set; }

        [JsonIgnore]
        public int? codMotivoNCR { get; set; }

    }
}

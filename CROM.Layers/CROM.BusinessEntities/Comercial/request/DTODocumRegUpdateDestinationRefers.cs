namespace CROM.BusinessEntities.Comercial.request
{
    using Newtonsoft.Json;

    public class DTODocumRegUpdateDestinationRefers : BEBaseEntidadItem
    {
        public DTODocumRegUpdateDestinationRefers()
        {

            codDocumentoOrigen = string.Empty;
            numDocumentoOrigenFull = string.Empty;
            codRegEstadoDocuOrigen = string.Empty;
        }

        public int codDocumReg { get; set; }

        [JsonIgnore]
        public string codDocumentoOrigen { get; set; }

        [JsonIgnore]
        public string numDocumentoOrigenFull { get; set; }

        [JsonIgnore]
        public string codRegEstadoDocuOrigen { get; set; }

        [JsonIgnore]
        public int? codMotivoNCR { get; set; }

    }
}

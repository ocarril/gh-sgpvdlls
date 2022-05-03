namespace CROM.BusinessEntities.Comercial.request
{
    using Newtonsoft.Json;



    public class DTODocumRegUpdateDesasignaRefers : BEBaseEntidadItem
    {
        public DTODocumRegUpdateDesasignaRefers()
        {

            codDocumentoRefer = string.Empty;
            numDocumentoRefer = string.Empty;
            numDocumentoRefersXML = string.Empty;
        }

        public int codDocumReg { get; set; }

        [JsonIgnore]
        public string codDocumentoRefer { get; set; }

        [JsonIgnore]
        public string numDocumentoRefersXML { get; set; }

        [JsonIgnore]
        public string numDocumentoRefer { get; set; }

        [JsonIgnore]
        public int? codDocumentoEstadoRefer { get; set; }

        [JsonIgnore]
        public string tokenUser { get; set; }
    }
}

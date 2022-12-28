using Newtonsoft.Json;
using System.Collections.Generic;

namespace CROM.BusinessEntities.SUNAT.WSGuiaRemision
{
    public class BEApiGuiaRemisionConsultarTicketResponse
    {

        public BEApiGuiaRemisionConsultarTicketResponse()
        {
            codRespuesta = string.Empty;
            arcCdr= string.Empty;
            indCdrGenerado = string.Empty;
            ItemError = new ResponseErrorSunat(); 
        }


        [JsonProperty("codRespuesta")]
        public string codRespuesta { get; set; }


        [JsonProperty("error")]
        public ResponseErrorSunat ItemError { get; set; }



        [JsonProperty("arcCdr")]
        public string arcCdr { get; set; }


        [JsonProperty("indCdrGenerado")]
        public string indCdrGenerado { get; set; }

    }


    public class ResponseErrorSunat
    {
        public ResponseErrorSunat()
        {
            NumError = string.Empty;
            DescriptionError = string.Empty;
        }

        [JsonProperty("numError")]
        public string NumError { get; set; }


        [JsonProperty("desError")]
        public string DescriptionError { get; set; }
    }


}

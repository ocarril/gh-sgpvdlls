namespace CROM.BusinessEntities.SUNAT.response
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class BEGenerarApiConsultaValidDocumentRespone
    {
        public BEGenerarApiConsultaValidDocumentRespone()
        {

            Success = string.Empty;
            Message = string.Empty;
            Data = new BEGenerarApiConsultaValidDocumentDataRespone();
        }


        [JsonProperty("success")]
        public string Success { get; set; }


        [JsonProperty("message")]
        public string Message { get; set; }


        [JsonProperty("data")]
        public BEGenerarApiConsultaValidDocumentDataRespone Data { get; set; }


    }


    public class BEGenerarApiConsultaValidDocumentDataRespone
    {
        public BEGenerarApiConsultaValidDocumentDataRespone()
        {
            EstadoCp = string.Empty;
            EstadoRuc = string.Empty;
            CondDomiRuc = string.Empty;
            Observaciones = new List<string>();
        }

        [JsonProperty("estadoCp")]
        public string EstadoCp { get; set; }


        [JsonProperty("estadoRuc")]
        public string EstadoRuc { get; set; }


        [JsonProperty("condDomiRuc")]
        public string CondDomiRuc { get; set; }


        [JsonProperty("observaciones")]
        public List<string> Observaciones { get; set; }


        [JsonProperty("flagAnalisisOK")]
        public bool FlagAnalisisOK { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}

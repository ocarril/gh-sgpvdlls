
namespace CROM.BusinessEntities.SUNAT.WSConsulta
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

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

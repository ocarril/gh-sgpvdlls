
namespace CROM.BusinessEntities.SUNAT.WSConsulta
{
    using Newtonsoft.Json;

    public class BEGenerarApiConsultaValidDocumentRequest
    {
        public BEGenerarApiConsultaValidDocumentRequest()
        {
            CodComp = string.Empty;
            NumRuc = string.Empty;
            NumeroSerie = string.Empty;
            Numero = string.Empty;
            FechaEmision = string.Empty;
            Monto = string.Empty;
        }

        [JsonProperty("numRuc")]
        public string NumRuc { get; set; }


        [JsonProperty("codComp")]
        public string CodComp { get; set; }


        [JsonProperty("numeroSerie")]
        public string NumeroSerie { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }


        [JsonProperty("fechaEmision")]

        public string FechaEmision { get; set; }

        [JsonProperty("monto")]
        public string Monto { get; set; }



        [JsonIgnore]
        public string Token { get; set; }

        [JsonIgnore]
        public string UrlApiConsultaSUNAT { get; set; }
    }
}

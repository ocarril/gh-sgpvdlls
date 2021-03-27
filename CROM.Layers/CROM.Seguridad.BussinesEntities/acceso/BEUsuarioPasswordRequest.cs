namespace CROM.Seguridad.BussinesEntities.acceso
{
    using Newtonsoft.Json;


    public class BEUsuarioPasswordRequest : BEBaseRequest
    {

        public BEUsuarioPasswordRequest()
        {
        }

        [JsonProperty("desLogin")]
        public string desLogin { get; set; }


        [JsonProperty("clvPassword")]
        public string clvPassword { get; set; }

        [JsonIgnore]
        public string clvPasswordEncrypt { get; set; }

    }
}

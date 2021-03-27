namespace CROM.Seguridad.BussinesEntities.acceso
{
    using Newtonsoft.Json;


    public class BEUsuarioPasswordResetRequest: BEBaseRequest
    {
        public BEUsuarioPasswordResetRequest()
        {
        }

        [JsonProperty("codUsuario")]
        public string codUsuario { get; set; }


        [JsonProperty("urlWebSistema")]
        public string urlWebSistema { get; set; }

        [JsonIgnore]
        public string clvPasswordEncrypt { get; set; }



    }
}

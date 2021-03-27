namespace CROM.Seguridad.BussinesEntities.acceso
{
    using Newtonsoft.Json;

    public class BEUsuarioFecBloqueoRequest : BEBaseRequest
    {
        public BEUsuarioFecBloqueoRequest()
        {
        }

        [JsonProperty("codUsuario")]
        public string codUsuario { get; set; }

        [JsonProperty("flagBloquea")]
        public bool flagBloquea { get; set; }

    }
}

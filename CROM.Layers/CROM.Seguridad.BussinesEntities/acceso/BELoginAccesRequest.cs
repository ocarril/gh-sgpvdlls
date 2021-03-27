namespace CROM.Seguridad.BussinesEntities.acceso
{
    using Newtonsoft.Json;


    public class BELoginAccesRequest
    {
        public BELoginAccesRequest()
        {
            Login = string.Empty; ;
            Contrasenia = string.Empty;
            KeySistema = string.Empty;
        }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("contrasenia")]
        public string Contrasenia { get; set; }

        [JsonProperty("keySistema")]
        public string KeySistema { get; set; }

        [JsonIgnore]
        public int codRol { get; set; }

        [JsonIgnore]
        public int codSistema { get; set; }
    }
}

namespace CROM.Tools.Comun.security
{
    using Newtonsoft.Json;


    public class TokenBE
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("isValid")]
        public bool IsValid { get; set; }
    }
}

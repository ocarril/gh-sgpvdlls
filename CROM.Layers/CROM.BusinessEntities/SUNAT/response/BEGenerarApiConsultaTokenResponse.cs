namespace CROM.BusinessEntities.SUNAT.response
{
    using Newtonsoft.Json;


    public class BEGenerarApiConsultaTokenResponse
    {
        public BEGenerarApiConsultaTokenResponse()
        {
            AccessToken = string.Empty;
            TokenType = string.Empty;
        }

        [JsonProperty ("access_token")]
        public string AccessToken { get; set; }


        [JsonProperty("token_type")]
        public string TokenType { get; set; }


        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

    }
}

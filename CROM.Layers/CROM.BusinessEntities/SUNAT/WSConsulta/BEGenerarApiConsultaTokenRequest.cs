namespace CROM.BusinessEntities.SUNAT.WSConsulta
{
    public class BEGenerarApiConsultaTokenRequest
    {
        public BEGenerarApiConsultaTokenRequest()
        {
            grant_type = string.Empty;
            scope = string.Empty;
            client_id = string.Empty;
            client_secret = string.Empty;
        }

        public string grant_type { get; set; }

        public string scope { get; set; }

        public string client_id { get; set; }

        public string client_secret { get; set; }
    }
}

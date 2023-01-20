namespace CROM.BusinessEntities.SUNAT.WSConsulta
{
    public class BEApiConsultaTokenRequest
    {
        public BEApiConsultaTokenRequest()
        {
            DataInput = new BEGenerarApiConsultaTokenRequest();
        }

        public BEGenerarApiConsultaTokenRequest DataInput { get; set; }

        public string UrlApiGenToken { get; set; }

        public string client_id { get; set; }
    }

}

namespace CROM.BusinessEntities.SUNAT.WSGuiaRemision
{
    using CROM.BusinessEntities.SUNAT.WSConsulta;

    public class BEGenerarApiGuiaRemisionTokenRequest : BEGenerarApiConsultaTokenRequest
    {
        public BEGenerarApiGuiaRemisionTokenRequest()
        {
            username = string.Empty;
            password = string.Empty;
        }


        public string username { get; set; }

        public string password { get; set; }


    }
}

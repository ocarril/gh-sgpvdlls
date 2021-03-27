namespace CROM.BusinessEntities.SUNAT.ubl21.aggregate
{
    using System;


    [Serializable]
    public class SunatRoadTransport
    {
        public string LicensePlateId { get; set; }

        public string TransportAuthorizationCode { get; set; }

        public string BrandName { get; set; }
    }
}

namespace CROM.BusinessEntities.SUNAT.ubl21.aggregate
{
    using System;


    [Serializable]
    public class SunatCosts
    {
        public SunatRoadTransport RoadTransport { get; set; }

        public SunatCosts()
        {
            RoadTransport = new SunatRoadTransport();
        }
    }
}

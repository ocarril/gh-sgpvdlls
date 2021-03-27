namespace CROM.BusinessEntities.SUNAT.ubl21.structures
{
    using CROM.BusinessEntities.SUNAT.ubl21.basic;

    using System;


    [Serializable]
    public class OrderReference
    {
        public string Id { get; set; }

        public OrderTypeCode OrderTypeCode { get; set; }

        public OrderReference()
        {
            OrderTypeCode = new OrderTypeCode();
        }
    }
}

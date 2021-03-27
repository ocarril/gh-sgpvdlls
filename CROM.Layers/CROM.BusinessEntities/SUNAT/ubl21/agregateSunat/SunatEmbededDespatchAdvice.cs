namespace CROM.BusinessEntities.SUNAT.ubl21.agregateSunat
{
    using CROM.BusinessEntities.SUNAT.ubl21.aggregate;
    using CROM.BusinessEntities.SUNAT.ubl21.basic;

    using System;


    [Serializable]
    public class SunatEmbededDespatchAdvice
    {
        public PostalAddress DeliveryAddress { get; set; }

        public PostalAddress OriginAddress { get; set; }

        public AccountingSupplierParty SunatCarrierParty { get; set; }

        public AgentParty DriverParty { get; set; }

        public SunatRoadTransport SunatRoadTransport { get; set; }

        public string TransportModeCode { get; set; }

        public InvoicedQuantity GrossWeightMeasure { get; set; }

        public SunatEmbededDespatchAdvice()
        {
            DeliveryAddress = new PostalAddress();
            OriginAddress = new PostalAddress();
            SunatCarrierParty = new AccountingSupplierParty();
            DriverParty = new AgentParty();
            SunatRoadTransport = new SunatRoadTransport();
            GrossWeightMeasure = new InvoicedQuantity();
        }
    }
}

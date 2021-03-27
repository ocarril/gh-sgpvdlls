namespace CROM.BusinessEntities.SUNAT.ubl21.aggregate
{
    using System;


    [Serializable]
    public class CarrierParty
    {
        public PartyIdentification PartyIdentification { get; set; }

        public PartyLegalEntity PartyLegalEntity { get; set; }

        public CarrierParty()
        {
            PartyIdentification = new PartyIdentification();
            PartyLegalEntity = new PartyLegalEntity();
        }
    }
}

namespace CROM.BusinessEntities.SUNAT.ubl21.aggregate
{
    using CROM.BusinessEntities.SUNAT.ubl21.basic;
    using System;


    [Serializable]
    public class PartyIdentification
    {
        public PartyIdentificationId Id { get; set; }

        public PartyIdentification()
        {
            Id = new PartyIdentificationId();
        }
    }
}

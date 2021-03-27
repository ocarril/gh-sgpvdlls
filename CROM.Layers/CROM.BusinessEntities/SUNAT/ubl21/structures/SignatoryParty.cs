namespace CROM.BusinessEntities.SUNAT.ubl21.structures
{
    using CROM.BusinessEntities.SUNAT.ubl21.aggregate;

    using System;


    [Serializable]
    public class SignatoryParty
    {
        public PartyIdentification PartyIdentification { get; set; }

        public PartyName PartyName { get; set; }

        public SignatoryParty()
        {
            PartyIdentification = new PartyIdentification();
            PartyName = new PartyName();
        }
    }
}

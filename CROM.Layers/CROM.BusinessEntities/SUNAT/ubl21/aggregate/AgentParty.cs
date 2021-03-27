namespace CROM.BusinessEntities.SUNAT.ubl21.aggregate
{
   
    using System;


    [Serializable]
    public class AgentParty
    {
        public PartyIdentification PartyIdentification { get; set; }

        public PartyName PartyName { get; set; }

        public PostalAddress PostalAddress { get; set; }

        public PartyLegalEntity PartyLegalEntity { get; set; }

        public AgentParty()
        {
            PartyIdentification = new PartyIdentification();
            PartyName = new PartyName();
            PostalAddress = new PostalAddress();
            PartyLegalEntity = new PartyLegalEntity();
        }
    }
}

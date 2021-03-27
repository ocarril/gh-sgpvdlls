namespace CROM.BusinessEntities.SUNAT.ubl21.structures
{
    using System;


    [Serializable]
    public class DigitalSignatureAttachment
    {
        public ExternalReference ExternalReference { get; set; }

        public DigitalSignatureAttachment()
        {
            ExternalReference = new ExternalReference();
        }
    }

}

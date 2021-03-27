namespace CROM.BusinessEntities.SUNAT.ubl21.extension
{
    using CROM.BusinessEntities.SUNAT.ubl21.agregateSunat;

    using System;


    [Serializable]
    public class ExtensionContent
    {
        public AdditionalInformation AdditionalInformation { get; set; }

        public ExtensionContent()
        {
            AdditionalInformation = new AdditionalInformation();
        }
    }
}

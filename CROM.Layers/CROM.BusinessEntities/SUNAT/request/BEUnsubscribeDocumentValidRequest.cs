namespace CROM.BusinessEntities.SUNAT.request
{
    using Newtonsoft.Json;

    public class BEUnsubscribeDocumentValidRequest : BEBaseEntidadItem
    {
        public BEUnsubscribeDocumentValidRequest()
        {
            FirmaSignatureValue = string.Empty;
            numDocumentoXML = string.Empty;
            FirmaSignatureValue = string.Empty;
            NomArchivoTicket = string.Empty;
        }

        public string numDocumentoXML { get; set; }

        public string FirmaDigestValue { get; set; }

        public string FirmaSignatureValue { get; set; }

        [JsonIgnore]
        public string NomArchivoTicket { get; set; }

    }
}

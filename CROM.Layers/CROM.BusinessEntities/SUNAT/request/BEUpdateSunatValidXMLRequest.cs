namespace CROM.BusinessEntities.SUNAT.request
{
    using System;

    public class BEUpdateSunatValidXMLRequest : BEBuscadorBase
    {
        public BEUpdateSunatValidXMLRequest()
        {
            nomArchivoSUNAT = string.Empty;
            FirmaDigestValue = string.Empty;
            FirmaSignatureValue = string.Empty;
        }

        public int codDocumReg { get; set; }

        public string nomArchivoSUNAT { get; set; }

        public bool nomArchivoValidado { get; set; }

        public String FirmaDigestValue { get; set; }

        public String FirmaSignatureValue { get; set; }

        public string codBarras { get; set; }

        public DateTime? fechaXMLValid { get; set; }

    }

}

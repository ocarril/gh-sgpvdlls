namespace CROM.BusinessEntities.SUNAT.response
{
    public class BEDocumentoSUNATRelacionadoResponse
    {
        public BEDocumentoSUNATRelacionadoResponse()
        {
            indDocRelacionado = string.Empty;
            numIdeAnticipo = string.Empty;
            tipDocRelacionado = string.Empty;
            numDocRelacionado = string.Empty;
            tipDocEmisor = string.Empty;
            numDocEmisor = string.Empty;
        }

        public int codDocumReg { get; set; }

        public string indDocRelacionado { get; set; }
        public string numIdeAnticipo { get; set; }
        public string tipDocRelacionado { get; set; }
        public string numDocRelacionado { get; set; }
        public string tipDocEmisor { get; set; }
        public string numDocEmisor { get; set; }
        public decimal mtoDocRelacionado { get; set; }

    }
}

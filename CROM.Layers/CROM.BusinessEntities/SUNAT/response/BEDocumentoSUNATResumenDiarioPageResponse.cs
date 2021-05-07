
namespace CROM.BusinessEntities.SUNAT.response
{
    using System;

    public class BEDocumentoSUNATResumenDiarioPageResponse : BEBasePagedResponse
    {
        public BEDocumentoSUNATResumenDiarioPageResponse()
        {
            desFirmaDigestValue = string.Empty;
            desFirmaSignatureValue = string.Empty;
            verCustomizationID = string.Empty;
            verUBLId = string.Empty;
            verCustomizationID = string.Empty;
            desNomArchivoTicket = string.Empty;
        }

        public long codDocumRegResumenDiario { get; set; }

        public int codEmpresa { get; set; }

        public DateTime fecGenera { get; set; }

        public DateTime fecVenta { get; set; }

        public string desNomArchivo { get; set; }

        public string desRptaSunatFS { get; set; }

        public DateTime? fecRptaSunatFS { get; set; }

        public bool desNomArchivoValidado { get; set; }

        public string desFirmaDigestValue { get; set; }

        public string desFirmaSignatureValue { get; set; }

        public string desNomArchivoTicket { get; set; }

        public string verUBLId { get; set; }

        public string verCustomizationID { get; set; }

    }
}

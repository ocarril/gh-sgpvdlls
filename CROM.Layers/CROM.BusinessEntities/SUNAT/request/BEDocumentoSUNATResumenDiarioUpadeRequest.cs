namespace CROM.BusinessEntities.SUNAT.request
{
    using System;


    public class BEDocumentoSUNATResumenDiarioUpdateRequest : BEBaseEntidadRequest
    {
        public BEDocumentoSUNATResumenDiarioUpdateRequest()
        {
            RptaSunatFSDescripcion = string.Empty;
            FirmaSignatureValue = string.Empty;
            FirmaDigestValue = string.Empty;
        }

        public int codDocumRegResumenDiario { get; set; }

        public string RptaSunatFSDescripcion { get; set; }

        public DateTime RptaSunatFSFecha { get; set; }

        public bool indNomArchivoValidado { get; set; }

        public string FirmaDigestValue { get; set; }

        public string FirmaSignatureValue { get; set; }

        public string NomArchivoTicket { get; set; }

        public DateTime fecGeneracionRD { get; set; }
    }
}

namespace CROM.BusinessEntities.SUNAT.request
{
    using System;


    public class BEDocumentoSUNATResumenDiarioRequest : BEBaseEntidadRequest
    {
        public BEDocumentoSUNATResumenDiarioRequest()
        {
            nomFileSunat = string.Empty;
            verCustomizationID = string.Empty;
            verUBLId = string.Empty;
        }

        public int codDocumRegResumenDiario { get; set; }

        public DateTime fecProcesoVenta { get; set; }

        public DateTime fecGeneracionRD { get; set; }

        public string nomFileSunat { get; set; }

        public string verUBLId { get; set; }

        public string verCustomizationID { get; set; }


    }
}

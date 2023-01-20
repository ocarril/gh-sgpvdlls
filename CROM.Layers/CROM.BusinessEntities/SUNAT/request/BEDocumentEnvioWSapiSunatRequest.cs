namespace CROM.BusinessEntities.SUNAT.request
{
    using System;

    public class BEDocumentEnvioWSapiSunatRequest : BEBaseEntidadItem
    {
        public BEDocumentEnvioWSapiSunatRequest()
        {

            numTicket = string.Empty;

        }

        public int codDocumReg { get; set; }

        public DateTime? fecRecepcion { get; set; }

        public string numTicket { get; set; }

    }
}

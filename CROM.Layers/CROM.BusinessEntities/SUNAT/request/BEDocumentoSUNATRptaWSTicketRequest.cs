namespace CROM.BusinessEntities.SUNAT.request
{
    using System;

    public class BEDocumentoSUNATRptaWSTicketRequest : BEBaseEntidadItem
    {
        public BEDocumentoSUNATRptaWSTicketRequest()
        {

            numTicket = string.Empty;

        }

        public int codDocumReg { get; set; }

        public string numTicket { get; set; }

        public string RptaNomArchivoXML { get; set; }

        public string RptaSunatFSDescripcion { get; set; }

        public DateTime? RptaSunatFSFecha { get; set; }

        public string RptaSunatFSNote { get; set; }

        public string codRespuesta { get; set; }
        
        public string indCdrGenerado { get; set; }


    }
}

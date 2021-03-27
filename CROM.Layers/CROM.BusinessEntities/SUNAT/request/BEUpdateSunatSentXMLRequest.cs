namespace CROM.BusinessEntities.SUNAT.request
{
    using System;

    public class BEUpdateSunatSentXMLRequest : BEBuscadorBase
    {
        public BEUpdateSunatSentXMLRequest()
        {
            RptaSunatFSDescripcion = String.Empty;
            RptaNomArchivoXml = String.Empty;
            RptaSunatFSNote = String.Empty;
        }

        public int codDocumReg { get; set; }

        public String RptaNomArchivoXml { get; set; }

        public Nullable<DateTime> RptaSunatFSFecha { get; set; }

        public String  RptaSunatFSDescripcion { get; set; }

        public String RptaSunatFSNote { get; set; }
    }

}

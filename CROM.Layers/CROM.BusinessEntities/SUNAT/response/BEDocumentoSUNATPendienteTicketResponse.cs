namespace CROM.BusinessEntities.SUNAT.response
{
    using System;

    public class BEDocumentoSUNATPendienteTicketResponse
    {
        public BEDocumentoSUNATPendienteTicketResponse()
        {
            numDocumento = string.Empty;
            desAbreviatura = string.Empty;
            codRegEstado = string.Empty;
            numDocumento = string.Empty;
        }


        public int codEmpresa { get; set; }

        public string desAbreviatura { get; set; }

        public int codDocumReg { get; set; }

        public Nullable<DateTime> fecEmisionDate { get; set; }

        public string codRegEstado { get; set; }

        public string numDocumento { get; set; }


        public string NomArchivoXml { get; set; }

        public string RptaNomArchivoXml          { get; set; }
        public string RptaSunatFSDescripcion     { get; set; }
        public string RptaSunatFSNote            { get; set; }
        public DateTime? RptaSunatFSFecha           { get; set; }
        public bool flagEnviadoSUNAT { get; set; }
        public DateTime? fecEnviadoSUNAT { get; set; }



        public DateTime? fecValidWSoapSunat  { get; set; }
        public string desValidWSoapSunat  { get; set; }
        public string indValidWSoapSunat  { get; set; }
        public string numTicket           { get; set; }
        public DateTime? fecRecepcion        { get; set; }
        public string TCK_codRespuesta    { get; set; }
        public string TCK_indCdrGenerado { get; set; }
    }
}

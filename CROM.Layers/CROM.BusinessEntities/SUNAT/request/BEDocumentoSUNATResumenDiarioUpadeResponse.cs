namespace CROM.BusinessEntities.SUNAT.request
{
    using Newtonsoft.Json;
    using System;


    public class BEDocumentoSUNATResumenDiarioUpadeResponse : BEBaseEntidadRequest
    {
        public BEDocumentoSUNATResumenDiarioUpadeResponse()
        {
            RptaSunatFSDescripcion = string.Empty;
        }

        public int codDocumRegResumenDiario { get; set; }

        public string RptaSunatFSDescripcion { get; set; }

        public DateTime? RptaSunatFSFecha { get; set; }

        public string RptaSunatFSNote { get; set; }

        [JsonIgnore]
        public string NombreArchivoRD { get; set; }

    }
}

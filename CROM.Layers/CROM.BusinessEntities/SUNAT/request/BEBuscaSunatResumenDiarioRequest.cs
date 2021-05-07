namespace CROM.BusinessEntities.SUNAT.request
{
    using Newtonsoft.Json;
    using System;


    public class BEBuscaSunatResumenDiarioRequest : BEBuscadorBaseRequest
    {
        public BEBuscaSunatResumenDiarioRequest()
        {
            fecVentaInicio = string.Empty;
            fecVentaFinal = string.Empty;
        }


        public DateTime? fecVentaInicioDate { get; set; }

        public DateTime? fecVentaFinalDate { get; set; }

        public string NomArchivo { get; set; }

        public string NomArchivoTicket { get; set; }

        public bool flagArchivoValidado { get; set; }
   
        [JsonIgnore]
        public string fecVentaInicio { get; set; }

        [JsonIgnore]
        public string fecVentaFinal { get; set; }
 }
}

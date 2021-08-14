namespace CROM.BusinessEntities.SUNAT.request
{
    using Newtonsoft.Json;


    public class BEGetStatusTicketSunatRequest: BEBuscadorBase
    {
        public BEGetStatusTicketSunatRequest()
        {

        }

        public int indOrigenPeticion { get; set; }

        public int codEntidadID { get; set; }

        [JsonIgnore]
        public string numTicket { get; set; }

        [JsonIgnore]
        public string desDocumento { get; set; }

        [JsonIgnore]
        public string PathRutaSendWSCDRZIPFile { get; set; }

        [JsonIgnore]
        public string indTipoDocRpta { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.BusinessEntities.SUNAT.WSGuiaRemision
{
    public class BEApiGuiaRemisionTicketResponse
    {

        public BEApiGuiaRemisionTicketResponse()
        {
            NumeroTicket = string.Empty;
        }

        [JsonProperty("numTicket")]
        public string NumeroTicket { get; set; }

        [JsonProperty("fecRecepcion")]
        public DateTime FechaRecepcion { get; set; }

    }
}

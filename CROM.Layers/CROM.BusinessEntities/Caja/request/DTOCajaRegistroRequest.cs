namespace CROM.BusinessEntities.Caja.request
{
    using CROM.BusinessEntities.Cajas;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class DTOCajaRegistroRequest: BECajaRegistro
    {

        public DTOCajaRegistroRequest()
        {
            LstCuotasId = new List<EntidadId>();
        }

        public decimal totMontoRecibido { get; set; }
        public decimal totMontoRecibido_MN { get; set; }
        public decimal totMontoRecibido_MI { get; set; }


        public decimal totMontoPagado { get; set; }
        public decimal totMontoPagado_MN { get; set; }
        public decimal totMontoPagado_MI { get; set; }

        public decimal totImporteVuelto { get; set; }
        public decimal totImporteVuelto_MN { get; set; }
        public decimal totImporteVuelto_MI { get; set; }


        public decimal totSaldoActual { get; set; }
        public decimal totSaldoActual_MN { get; set; }
        public decimal totSaldoActual_MI { get; set; }

        public bool indFormaPagoRegistra { get; set; }

        public List<EntidadId> LstCuotasId { get; set; }

        [JsonIgnore]
        public string codPlanilla { get; set; }
    }
}

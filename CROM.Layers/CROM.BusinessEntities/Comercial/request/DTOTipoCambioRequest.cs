namespace CROM.BusinessEntities.Comercial.request
{
    using System;


    public class DTOTipoCambioRequest: BEBaseEntidadRequest
    {
        public DTOTipoCambioRequest()
        {

        }
        public int codTipoCambio { get; set; }

        public DateTime fecProceso { get; set; }

        public string codRegMoneda { get; set; }

        public decimal monCompraGOB { get; set; }

        public decimal monVentasGOB { get; set; }

        public decimal monCompraPRL { get; set; }

        public decimal monVentasPRL { get; set; }

        public bool indActivo { get; set; }

    }
}

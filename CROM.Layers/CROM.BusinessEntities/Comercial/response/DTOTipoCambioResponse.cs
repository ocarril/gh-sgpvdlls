namespace CROM.BusinessEntities.Comercial.response
{
    using System;

    public class DTOTipoCambioResponse : BEBasePagedResponse
    {
        public DTOTipoCambioResponse()
        {
            codRegMoneda = string.Empty;
            codRegMonedaNombre = string.Empty;
            monCompraGOB = 0;
            monCompraPRL = 0;
            monVentasGOB = 0;
            monVentasPRL = 0;
        }

        public int codTipoCambio { get; set; }

        public DateTime fecProceso { get; set; }

        public string codRegMoneda { get; set; }

        public decimal monCompraGOB { get; set; }

        public decimal monVentasGOB { get; set; }

        public decimal monCompraPRL { get; set; }

        public decimal monVentasPRL { get; set; }

        public string codRegMonedaNombre { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.BusinessEntities.Comercial.request
{
    public class DTOTipoDeCambioRequest
    {
        public DTOTipoDeCambioRequest()
        {

        }

        public int codTipoCambio { get; set; }
        public DateTime FechaProceso { get; set; }
        public string CodigoArguMoneda { get; set; }
        public decimal CambioCompraGOB { get; set; }
        public decimal CambioVentasGOB { get; set; }
        public decimal CambioCompraPRL { get; set; }
        public decimal CambioVentasPRL { get; set; }
        public bool Estado { get; set; }

    }
}

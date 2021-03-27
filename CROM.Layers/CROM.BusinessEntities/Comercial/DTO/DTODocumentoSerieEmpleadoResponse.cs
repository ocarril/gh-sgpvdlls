using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.BusinessEntities.Comercial.DTO
{
    public class DTODocumentoSerieEmpleadoResponse : BEBasePagedResponse
    {
        public DTODocumentoSerieEmpleadoResponse()
        {

        }

        public int codDocumentoSerieEmpleado { get; set; }

        public int codDocumentoSerie { get; set; }

        public string codDocumentoSerieNombre { get; set; }

        public string codPlanilla { get; set; }

        public string codEmpleadoNombre { get; set; }
    }
}

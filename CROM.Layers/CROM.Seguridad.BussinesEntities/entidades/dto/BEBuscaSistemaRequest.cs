using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.Seguridad.BussinesEntities.entidades.dto
{
    public class BEBuscaSistemaRequest : BEBuscadorBaseRequest
    {
        public BEBuscaSistemaRequest()
        {
            desNombre = string.Empty;
        }

        public string codSistema { get; set; }
        public string desNombre { get; set; }
        public string gloDescripcion { get; set; }
        public bool indActivo { get; set; }
    }
}

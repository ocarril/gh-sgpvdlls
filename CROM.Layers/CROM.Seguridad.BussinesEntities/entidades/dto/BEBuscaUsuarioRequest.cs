using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.Seguridad.BussinesEntities.entidades.dto
{
    public class BEBuscaUsuarioRequest : BEBuscadorBaseRequest
    {
        public BEBuscaUsuarioRequest()
        {
            desNombre = string.Empty;
            desCorreo = string.Empty;
            desLogin = string.Empty;
            codEmpleado = string.Empty;
            indActivo = true;
        }

        public string codEmpleado { get; set; }
        public string desLogin { get; set; }
        public string desNombre { get; set; }
        public string desCorreo { get; set; }
        public bool indActivo { get; set; }
    }
}

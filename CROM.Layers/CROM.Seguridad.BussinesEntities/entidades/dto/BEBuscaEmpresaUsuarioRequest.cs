using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.Seguridad.BussinesEntities.entidades.dto
{
    public class BEBuscaEmpresaUsuarioRequest : BEBuscadorBaseRequest
    {
        public BEBuscaEmpresaUsuarioRequest()
        {
            codUsuario = string.Empty;
        }

        public string codUsuario { get; set; }
        public bool indActivo { get; set; }
    }
}

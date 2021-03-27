using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.Seguridad.BussinesEntities.entidades.dto
{
    public class BEBuscaRolUsuarioRequest : BEBuscadorBaseRequest
    {
        public BEBuscaRolUsuarioRequest()
        {
            codSistema = string.Empty;
            codUsuario = string.Empty;
            codRol = string.Empty;
        }

        public int codUsuarioRol { get; set; }

        public string codRol { get; set; }

        public string codSistema { get; set; }

        public string codUsuario { get; set; }

        public bool indActivo { get; set; }

       
    }
}

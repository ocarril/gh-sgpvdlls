using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.Seguridad.BussinesEntities.entidades.dto
{
    public class BEBuscaRolOpcionRequest : BEBuscadorBaseRequest
    {
        public BEBuscaRolOpcionRequest()
        {
            codOpcion = string.Empty;
            codSistema = string.Empty;
        }

        public string codRol { get; set; }

        public string codSistema { get; set; }

        public string codOpcion { get; set; }

        public bool indVisualiza { get; set; }
        public bool indActivo { get; set; }

       
    }
}

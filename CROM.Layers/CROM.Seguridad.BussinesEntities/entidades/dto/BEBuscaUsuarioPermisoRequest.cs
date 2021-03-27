using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.Seguridad.BussinesEntities.entidades.dto
{

    public class BEBuscaUsuarioPermisoRequest : BEBuscadorBase
    {
        public BEBuscaUsuarioPermisoRequest()
        {
            codSistema = string.Empty;
            nomAction = string.Empty;
            desLogin = string.Empty;
            tipoOpcion = string.Empty;
        }

        public string codSistema { get; set; }
        public string desLogin { get; set; }
        public string tipoOpcion { get; set; }
        public string nomAction { get; set; }
    }
}

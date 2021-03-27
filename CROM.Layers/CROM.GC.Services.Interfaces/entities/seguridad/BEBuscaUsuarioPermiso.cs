using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.GC.Services.Interfaces.entities.seguridad
{
    public class BEBuscaUsuarioPermiso
    {
        public BEBuscaUsuarioPermiso()
        {
            nomAction = string.Empty;
            tipoOpcion = string.Empty;
            desLogin = string.Empty;
            codSistema = string.Empty;
            token = string.Empty;
        }

        public string codSistema { get; set; }
        public string desLogin { get; set; }
        public string tipoOpcion { get; set; }
        public string nomAction { get; set; }
        public string token { get; set; }
    }
}

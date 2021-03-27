using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.Seguridad.BussinesEntities.acceso
{
    public class BEUsuarioDetectLogin
    {
        public BEUsuarioDetectLogin()
        {
            desMessage = string.Empty;
            clvPasswordEncripted = string.Empty;
        }

        public int codError { get; set; }

        public string desMessage { get; set; }

        public string clvPasswordEncripted { get; set; }

        public bool indPasswordReset { get; set; }

        public bool indBloqueoUpdate { get; set; }

        public Nullable<DateTime> fecBloqueoUpdate { get; set; }
    }
}

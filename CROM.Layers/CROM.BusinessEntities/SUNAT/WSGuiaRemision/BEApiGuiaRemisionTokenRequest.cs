using CROM.BusinessEntities.SUNAT.WSConsulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.BusinessEntities.SUNAT.WSGuiaRemision
{
    public class BEApiGuiaRemisionTokenRequest
    {
        public BEApiGuiaRemisionTokenRequest()
        {

        }

        public BEGenerarApiGuiaRemisionTokenRequest DataInput { get; set; }

        public string UrlApiGenToken { get; set; }

        public string client_id { get; set; }
    }
}

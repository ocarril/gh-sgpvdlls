using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.Seguridad.BussinesEntities.entidades.dto
{
    public class BEBuscaEmpresaRequest: BEBuscadorBaseRequest
    {
        public BEBuscaEmpresaRequest()
        {
            nomRazonSocial = string.Empty;
            numRUC = string.Empty;
        }

        public string numRUC { get; set; }

        public string nomRazonSocial { get; set; }

        public bool indActivo { get; set; }
    }
}

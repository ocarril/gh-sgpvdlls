using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.Seguridad.BussinesEntities.entidades.dto
{
    public class BEBuscaEmpresaSistemaRequest : BEBuscadorBaseRequest
    {
        public BEBuscaEmpresaSistemaRequest()
        {
            codSistema = string.Empty;
        }

        public string codSistema { get; set; }
        public bool indActivo { get; set; }
    }
}

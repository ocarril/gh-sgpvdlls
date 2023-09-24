using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.Seguridad.BussinesEntities.entidades.dto
{
    public class BEBuscaEmpresaSistemaLicenciaRequest : BEBuscadorBaseRequest
    {
        public BEBuscaEmpresaSistemaLicenciaRequest()
        {
            codSistema = string.Empty;
        }

        public int codEmpresaSistema { get; set; }

        public string codSistema { get; set; }

        public bool indActivo { get; set; }

    }
}

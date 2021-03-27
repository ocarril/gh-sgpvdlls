using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.Seguridad.BussinesEntities.entidades.dto
{
    public class BEBuscaOpcionRequest : BEBuscadorBaseRequest
    {
        public BEBuscaOpcionRequest()
        {
            desNombre = string.Empty;
        }

        public string indTipoObjeto { get; set; }

        public string desNombre { get; set; }

        public string desEnlaceURL { get; set; }

        public bool indActivo { get; set; }

        public string codSistema { get; set; }

        public string codObjeto { get; set; }

        public string tipObjeto { get; set; }

        public string desNombrePadre { get; set; }

        public string codObjetoPadre { get; set; }
    }
}

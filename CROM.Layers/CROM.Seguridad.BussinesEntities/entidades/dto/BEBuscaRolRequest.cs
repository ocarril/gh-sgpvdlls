using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.Seguridad.BussinesEntities.entidades.dto
{
    public class BEBuscaRolRequest : BEBuscadorBaseRequest
    {
        public BEBuscaRolRequest()
        {
            desNombre = string.Empty;
            gloDescripcion = string.Empty;
        }

        public string codRol { get; set; }

        public string codSistema { get; set; }
        public string desNombre { get; set; }
        public string gloDescripcion { get; set; }
        public bool indActivo { get; set; }

       
    }

    public class BEEliminaRolRequest : BEBaseUpdate
    {
        public BEEliminaRolRequest()
        {
            UsuarioEdita = string.Empty;
            SegMaquina = string.Empty;
        }

        public string codRol { get; set; }

    }
}

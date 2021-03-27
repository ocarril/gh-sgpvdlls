using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CROM.Seguridad.BussinesEntities.acceso
{
    [DataContract]
    public class BEAuditoria
    {
        [DataMember]
        public string codSistema { get; set; }
        [DataMember]
        public string codRol { get; set; }
        [DataMember]
        public string codUsuario { get; set; }
        [DataMember]
        public string desLogin { get; set; }
        [DataMember]
        public string desMensaje { get; set; }
        [DataMember]
        public string desTipo { get; set; }
        [DataMember]
        public DateTime fecRegistroApp { get; set; }
        [DataMember]
        public string nomMaquinaIP { get; set; }

        public decimal? numLatitud { get; set; }
        public decimal? numLongitud { get; set; }


        public int? codEmpresa { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.Seguridad.BussinesEntities.entidades.dto
{

    public class BEBuscadorBase
    {
        public BEBuscadorBase()
        {
            
        }


        [JsonProperty("codEmpresa")]
        public int codEmpresa { get; set; }
        [JsonIgnore]
        public string userActual { get; set; }
        [JsonIgnore]
        public string maquinaPC { get; set; }
    }

    public class BEBuscadorBaseRequest: BEBuscadorBase
    {
        public BEBuscadorBaseRequest()
        {
            jqPageSize = 10;
            jqCurrentPage = 1;
            jqSortOrder = "Asc";
        }
        public int jqPageSize { get; set; }
        public int jqCurrentPage { get; set; }
        public string jqSortColumn { get; set; }
        public string jqSortOrder { get; set; }

        
    }

    public class BEBasePaged
    {
        public string segUsuarioEdita { get; set; }

        public Nullable<DateTime> segFechaEdita { get; set; }

        public string segMaquinaEdita { get; set; }

        public long ROW { get; set; }
        public int TOTALROWS { get; set; }
    }

    public class BEBaseUpdate
    {
        public string UsuarioEdita { get; set; }
        public string SegMaquina { get; set; }
    }
}

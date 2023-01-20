using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.BusinessEntities.SUNAT.WSConsulta
{

    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class BEGenerarApiConsultaValidDocumentRespone
    {
        public BEGenerarApiConsultaValidDocumentRespone()
        {

            Success = string.Empty;
            Message = string.Empty;
            Data = new BEGenerarApiConsultaValidDocumentDataRespone();
        }


        [JsonProperty("success")]
        public string Success { get; set; }


        [JsonProperty("message")]
        public string Message { get; set; }


        [JsonProperty("data")]
        public BEGenerarApiConsultaValidDocumentDataRespone Data { get; set; }


    }
}

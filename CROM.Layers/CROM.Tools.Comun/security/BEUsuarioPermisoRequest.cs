namespace CROM.Tools.Comun.security
{
    using Newtonsoft.Json;
    using System.Runtime.Serialization;

    [DataContract]
    public class BEUsuarioPermisoRequest
    {
        public BEUsuarioPermisoRequest()
        {
            nomAction = string.Empty;
            tipoObjeto = string.Empty;
            desLogin = string.Empty;
            codSistema = string.Empty;
            token = string.Empty;
        }

        public int codEmpresa { get; set; }

        [JsonIgnore]
        public string codSistema { get; set; }

        [JsonIgnore]
        public string desLogin { get; set; }

        [JsonIgnore]
        public string token { get; set; }

        [DataMember]
        public string tipoObjeto { get; set; }

        [DataMember]
        public string nomAction { get; set; }


    }

}

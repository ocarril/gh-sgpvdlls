namespace CROM.Seguridad.BussinesEntities.entidades.request
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Runtime.Serialization;



    [DataContract]
    public class BEUsuarioPasswordRequest : BEBaseRequest
    {
        public BEUsuarioPasswordRequest()
        {

        }

        #region ATRIBUTOS

        [DataMember]
        [JsonProperty("desLogin")]
        public string desLogin { get; set; }

        [DataMember]
        [JsonProperty("clvPassword")]
        public string clvPassword { get; set; }

        [JsonIgnore]
        public string clvPasswordEncrypt { get; set; }

        #endregion

    }

}

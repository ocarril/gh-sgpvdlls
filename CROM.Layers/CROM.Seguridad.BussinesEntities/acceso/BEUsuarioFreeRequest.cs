namespace CROM.Seguridad.BussinesEntities.acceso
{
    using Newtonsoft.Json;
    using System;
    using System.Runtime.Serialization;

    
    [DataContract]
    public class BEUsuarioFreeRequest : BEBaseRequest
    {
        public BEUsuarioFreeRequest()
        {
            indEstado = true;
            desLogin = string.Empty;
            clvPassword = string.Empty;
            desNombres = string.Empty;
            desApellidos = string.Empty;
            desTelefono = string.Empty;
            desCorreo = string.Empty;
            urlPhotoUser = string.Empty;
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

        [DataMember]
        [JsonProperty("desNombres")]
        public string desNombres { get; set; }

        [DataMember]
        [JsonProperty("desApellidos")]
        public string desApellidos { get; set; }

        [DataMember]
        [JsonProperty("desTelefono")]
        public string desTelefono { get; set; }

        [DataMember]
        [JsonProperty("desCorreo")]
        public string desCorreo { get; set; }

        [DataMember]
        [JsonProperty("urlPhotoUser")]
        public string urlPhotoUser { get; set; }
        
        [DataMember]
        [JsonProperty("indOrigenUser")]
        public string indOrigenUser { get; set; }

        [DataMember]
        [JsonProperty("codGUID")]
        public string codGUID { get; set; }

        [DataMember]
        [JsonProperty("codSistemaKey")]
        public Guid codSistemaKey { get; set; }


        [DataMember]
        [JsonProperty("codRolDefecto")]
        public string codRolDefecto { get; set; }


        [DataMember]
        [JsonIgnore]
        public bool indUsuarioSistema { get; set; }

        [DataMember]
        [JsonIgnore]
        public bool indEstado { get; set; }

        #endregion

    }

}

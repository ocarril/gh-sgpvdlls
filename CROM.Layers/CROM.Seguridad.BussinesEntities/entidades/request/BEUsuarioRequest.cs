namespace CROM.Seguridad.BussinesEntities.entidades.request
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;



    [DataContract]
    public class BEUsuarioRequest: BEBaseRequest
    {
        public BEUsuarioRequest()
        {

        }

        #region ATRIBUTOS

        [DataMember]
        [JsonProperty("codUsuario")]
        public string codUsuario { get; set; }

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
        [JsonProperty("desPregunta")]
        public string desPregunta { get; set; }

        [DataMember]
        [JsonProperty("desRespuesta")]
        public string desRespuesta { get; set; }

        [DataMember]
        [JsonProperty("desTelefono")]
        public string desTelefono { get; set; }

        [DataMember]
        [JsonProperty("desCorreo")]
        public string desCorreo { get; set; }

        [DataMember]
        [JsonProperty("indRestricPorPais")]
        public bool indRestricPorPais { get; set; }

        [DataMember]
        [JsonProperty("codArguPais")]
        public string codArguPais { get; set; }

        [DataMember]
        [JsonProperty("codEmpleado")]
        public string codEmpleado { get; set; }

        [DataMember]
        [JsonProperty("indVendedor")]
        public bool indVendedor { get; set; }

        [DataMember]
        [JsonProperty("indCambioPrecio")]
        public bool indCambioPrecio { get; set; }

        [DataMember]
        [JsonProperty("indAccesoGerencial")]
        public bool indAccesoGerencial { get; set; }

        [DataMember]
        [JsonProperty("indCambiaDescuento")]
        public bool indCambiaDescuento { get; set; }

        [DataMember]
        [JsonProperty("indCambiaCodPersona")]
        public bool indCambiaCodPersona { get; set; }

        [DataMember]
        [JsonProperty("indJefeCaja")]
        public bool indJefeCaja { get; set; }

        [DataMember]
        [JsonProperty("indUsuarioSistema")]
        public bool indUsuarioSistema { get; set; }

        [DataMember]
        [JsonProperty("indEstado")]
        public bool indEstado { get; set; }

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

        #endregion

    }

}

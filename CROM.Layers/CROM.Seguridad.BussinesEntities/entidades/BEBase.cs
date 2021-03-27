namespace CROM.Seguridad.BussinesEntities
{
    using Newtonsoft.Json;
    using System;
    using System.Runtime.Serialization;

    public class BEBase
    {


        [DataMember]
        [JsonProperty("segUsuarioCrea")]
        public string segUsuarioCrea { get; set; }

        [DataMember]
        [JsonProperty("segUsuarioEdita")]
        public string segUsuarioEdita { get; set; }

        [DataMember]
        [JsonProperty("segFechaHoraCrea")]
        public DateTime segFechaHoraCrea { get; set; }

        [DataMember]
        [JsonProperty("segFechaHoraEdita")]
        public Nullable<DateTime> segFechaHoraEdita { get; set; }

        [DataMember]
        [JsonProperty("segMaquinaCrea")]
        public string segMaquinaCrea { get; set; }

        [DataMember]
        [JsonProperty("segMaquinaEdita")]
        public string segMaquinaEdita { get; set; }
    }

    public class BEBaseRequest
    {
        public BEBaseRequest()
        {
            segUsuarioEdita = string.Empty;
            segMaquinaEdita = string.Empty;
        }

        [JsonIgnore]
        public string segUsuarioEdita { get; set; }

        [JsonIgnore]
        public Nullable<DateTime> segFechaHoraEdita { get; set; }

        [JsonIgnore]
        public string segMaquinaEdita { get; set; }

        [JsonIgnore]
        public int codEmpresa { get; set; }
    }
}

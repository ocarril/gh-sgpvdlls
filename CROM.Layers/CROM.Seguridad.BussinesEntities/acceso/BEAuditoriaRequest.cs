namespace CROM.Seguridad.BussinesEntities.acceso
{
    using CROM.Seguridad.BussinesEntities.entidades.dto;

    using System.Runtime.Serialization;


    [DataContract]
    public class BEAuditoriaRequest : BEBuscadorBaseRequest
    {
        [DataMember]
        public string codSistema { get; set; }

        [DataMember]
        public string codRol { get; set; }

        [DataMember]
        public string codUsuario { get; set; }

        [DataMember]
        public string fecInicio { get; set; }

        [DataMember]
        public string fecFinal { get; set; }
    }
}
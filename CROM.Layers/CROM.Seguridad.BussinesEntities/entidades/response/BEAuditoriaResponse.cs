
namespace CROM.Seguridad.BussinesEntities.entidades.response
{
    using CROM.Seguridad.BussinesEntities.entidades.dto;

    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class BEAuditoriaResponse : BEBasePaged
    {
        public BEAuditoriaResponse()
        {

        }

        [DataMember]
        public int codAuditoria { get; set; }

        [DataMember]
        public int? codEmpresa { get; set; }

        [DataMember]
        public string nomRazonSocial { get; set; }

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
        public DateTime fecRegistroBD { get; set; }

        [DataMember]
        public string nomMaquinaIP { get; set; }

        [DataMember]
        public string codEmpresaNombre { get; set; }

        [DataMember]
        public string codSistemaNombre { get; set; }

        [DataMember]
        public string codRolNombre { get; set; }

        [DataMember]
        public string codUsuarioNombre { get; set; }
    }
}

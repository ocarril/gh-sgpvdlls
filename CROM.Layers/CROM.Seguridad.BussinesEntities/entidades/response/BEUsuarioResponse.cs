namespace CROM.Seguridad.BussinesEntities.entidades.response
{
    using System.Runtime.Serialization;


    [DataContract]
    public class BEUsuarioResponse : BEUsuario
    {
    
        public BEUsuarioResponse()
        {
           
        }

        [DataMember]
        public string desApellidosNombres { get; set; }


    }
}

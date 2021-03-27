namespace CROM.Seguridad.BussinesEntities.entidades.response
{
    using CROM.Seguridad.BussinesEntities.entidades.dto;
       
    public class DTOUsuarioResponse : BEBasePaged
    {
        public DTOUsuarioResponse()
        {

        }

        public string codUsuario { get; set; }

        public string desLogin { get; set; }

        public string desNombres { get; set; }

        public string desApellidos { get; set; }

        public string desCorreo { get; set; }

        public string desTelefono { get; set; }

        public string codEmpleado { get; set; }

        public bool indVendedor { get; set; }

        public bool indEstado { get; set; }

        public bool indPasswordReset { get; set; }

        public bool indLockUser { get; set; }
    }
}

namespace CROM.Seguridad.BussinesEntities
{
    using CROM.Seguridad.BussinesEntities.entidades.dto;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 8/10/2019-15:55:24
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Seguridad.EmpresaUsuario.cs]
    /// </summary>
    public class BEEmpresaUsuario : BEBase
    {
        public BEEmpresaUsuario()
        {
            codUsuarioKey = string.Empty;
            codUsuario = string.Empty;
            segUsuarioEdita = string.Empty;
            segMaquinaEdita = string.Empty;
        }

        public int codEmpresaUsuario { get; set; }

        public int codEmpresa { get; set; }

        public string codUsuario { get; set; }

        public bool indActivo { get; set; }

        public string codUsuarioKey { get; set; }

    }

    public class BEEmpresaUsuarioRespose : BEBasePaged
    {
        public BEEmpresaUsuarioRespose()
        {
            nomEmpresa = string.Empty;
            nomUsuario = string.Empty;
            segUsuarioEdita = string.Empty;
            segMaquinaEdita = string.Empty;
        }

        public int codEmpresaUsuario { get; set; }
        public string nomEmpresa { get; set; }
        public string nomUsuario { get; set; }
        public bool indActivo { get; set; }
        public string codUsuarioKey { get; set; }

        public string desLogin { get; set; }
    }

    public class BEEmpresaUsuarioRequest : BEBaseRequest
    {
        public BEEmpresaUsuarioRequest()
        {
            codEmpresaUsuario = 0;
            codUsuario = string.Empty;
            segUsuarioEdita = string.Empty;
            segMaquinaEdita = string.Empty;
        }

        public int codEmpresaUsuario { get; set; }
        public int codEmpresa { get; set; }
        public string codUsuario { get; set; }
        public bool indActivo { get; set; }
    }

}

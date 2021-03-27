namespace CROM.Tools.Comun.security
{
    using System;


    public class DatoValidoUserSecurity
    {
        public DatoValidoUserSecurity()
        {
            nomRol = string.Empty;
            nomSistema = string.Empty;
            nomEmpresa = string.Empty;
            strMensajeValidado = string.Empty;
        }

        public int codSistema { get; set; }

        public int codEmpresa { get; set; }

        public int codRol { get; set; }

        public DateTime fechaLicencia { get; set; }

        public string nomRol { get; set; }

        public string nomSistema { get; set; }

        public string nomEmpresa { get; set; }

        public bool indValidado { get; set; }

        public string strMensajeValidado { get; set; }
    }
}

namespace CROM.Tools.Comun.security
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class BELoginModel
    {
        public BELoginModel()
        {
            Usuario = string.Empty;
            Contrasenia = string.Empty;
            rutaURL = string.Empty;
        }

        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public bool OlvidoContrasenia { get; set; }
        public int indOlvContrasenia { get; set; }
        public string rutaURL { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.Seguridad.BussinesEntities.acceso
{
    public class BEUsuarioRegister
    {
        public BEUsuarioRegister()
        {
            Email = string.Empty;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Pregunta = string.Empty;
            Respuesta = string.Empty;
            Telefono = string.Empty;
            Correo = string.Empty;
        }

        public string Email { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Pregunta { get; set; }

        public string Respuesta { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }
    }
}

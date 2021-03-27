namespace CROM.BusinessEntities.Maestros
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;



    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de la Tabla PersonasAsistencia
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 30/12/2009
    /// Descripcion : Entidad de negocio
    /// Archivo     : PersonasDatosAdicionales.cs
    /// </summary>
    public class BEPersonaDato:BEBaseMaestro
    {
        public BEPersonaDato ()
        {
            ApellidoPaterno = string.Empty;
            ApellidoMaterno = string.Empty;
            Nombre1 = string.Empty;
            Nombre2 = string.Empty;
            Apellidos = string.Empty;
            Nombres = string.Empty;
            CodigoArguAreaEmpleadoNombre = string.Empty;
        }

        public string CodigoPersona { get; set; }

        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string CodigoArguAreaEmpleado { get; set; }

        public string CodigoArguAreaEmpleadoNombre { get; set; }

    }
}

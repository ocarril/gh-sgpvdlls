namespace CROM.BusinessEntities.Maestros
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de la Tabla PersonasAsignaciones
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 03/04/2012
    /// Descripcion : Entidad de negocio
    /// Archivo     : PersonaCalendario.cs
    /// </summary>
    public class BEPersonaCalendario
    {
        public string CodigoCalendario { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de la Tabla PersonasAsignaciones
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 30/12/2009
    /// Descripcion : Entidad de negocio
    /// Archivo     : PersonasAsignaciones.cs
    /// </summary>
    public class PersonasCalendario
    {
        public string CodigoCalendario { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}

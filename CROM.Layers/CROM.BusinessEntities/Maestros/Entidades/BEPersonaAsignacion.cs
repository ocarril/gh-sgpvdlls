namespace CROM.BusinessEntities.Maestros
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;



    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de la Tabla PersonasAsignaciones
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 30/12/2009
    /// Descripcion : Entidad de negocio
    /// Archivo     : PersonasAsignaciones.cs
    /// </summary>
    public class BEPersonasAsignacion: BEBaseMaestro
    {
        public BEPersonasAsignacion()
        {
            CodigoArguAsignacionNombre = string.Empty;
        }

        public int codEmpresa { get; set; }
        public string CodigoPersona { get; set; }
        public string CodigoArguAsignacion { get; set; }

        public string CodigoArguAsignacionNombre { get; set; }
    }
}

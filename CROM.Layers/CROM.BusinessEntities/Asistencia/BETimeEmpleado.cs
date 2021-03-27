namespace CROM.BusinessEntities.Asistencia
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CROM.BusinessEntities.Maestros;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de la Tabla PersonasAsistencia
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 30/12/2009
    /// Descripcion : Entidad de negocio
    /// Archivo     : TimeEmpleado.cs
    /// </summary>
    public class BETimeEmpleado : BEPersonaDato
    {
        public BETimeEmpleado()
        {
            listaTimeMarcaciones = new List<BETimeMarcacion>();
            listaMarcaciones = new List<BEMarcacion>();
        }
        public string CodigoPersonaEmpresa { get; set; }
        public string CodigoPersonaEmpresaNombre { get; set; }
        public List<BETimeMarcacion> listaTimeMarcaciones { get; set; }
        public List<BEMarcacion> listaMarcaciones { get; set; }

    }
}

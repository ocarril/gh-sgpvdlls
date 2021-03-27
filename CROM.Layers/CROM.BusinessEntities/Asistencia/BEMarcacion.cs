namespace CROM.BusinessEntities.Asistencia
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Proyecto    : Control de Asistencia
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 01/08/2009
    /// Descripcion : Entidad de negocio
    /// Archivo     : Marcaciones.cs
    /// </summary>
    public class BEMarcacion : BEMarcaje
    {
        public string CodigoJustificacion { get; set; }
        public string Edicion { get; set; }

        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public string SegMaquinaOrigen { get; set; }
        public DateTime SegFechaHoraCrea { get; set; }
        public DateTime SegFechaHoraEdita { get; set; }
    }
}

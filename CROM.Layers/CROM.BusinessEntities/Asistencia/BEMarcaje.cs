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
    /// Archivo     : Marcajes.cs
    /// </summary>
    public class BEMarcaje
    {
        public string IdRegistro { get; set; }
        public string NumeroMarcacion { get; set; }
        public DateTime FechaTexto { get; set; }
        public DateTime FechaHora { get; set; }
        public string Hora { get; set; }
        public string CodigoReloj { get; set; }
        public string TeclaReloj { get; set; }
        public bool Estado { get; set; }
        public string SegUsuarioCreaL { get; set; }
    }
}

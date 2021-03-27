namespace CROM.BusinessEntities.Asistencia
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 12/01/2010-05:21:26 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Asistencia.PersonasAgenda.cs]
    /// </summary>
    public class BEPersonaAgenda
    {
        public string Item { get; set; }
        public string CodigoPersona { get; set; }
        public string CodigoJustificacion { get; set; }
        public int Anio { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public bool Estado { get; set; }

        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public DateTime SegFechaHoraCrea { get; set; }
        public DateTime SegFechaHoraEdita { get; set; }
        public string SegMaquinaOrigen { get; set; }

        public string CodigoPersonaNombre { get; set; }
        public string CodigoJustificacionNombre { get; set; }
    }
} 

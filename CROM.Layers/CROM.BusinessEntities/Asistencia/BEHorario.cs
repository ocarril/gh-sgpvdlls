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
    /// Archivo     : [Asistencia.Horario.cs]
    /// </summary>
    public class BEHorario
    {
        public int CodigoHorario { get; set; }
        public string Descripcion { get; set; }
        public decimal HorasLabor { get; set; }
        public string HEntrada { get; set; }
        public string HSalida { get; set; }
        public int Tolerancia { get; set; }
        public string CodigoArguTipoHorario { get; set; }
        public int CodigoHorarioRefer { get; set; }
        public bool DiaSabado { get; set; }
        public int MinAlmuerzo { get; set; }
        public string RefrigerioSalida { get; set; }
        public string RefrigerioEntrada { get; set; }
        public bool Estado { get; set; }

        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public DateTime SegFechaHoraCrea { get; set; }
        public DateTime SegFechaHoraEdita { get; set; }
        public string SegMaquinaOrigen { get; set; }

        public string CodigoArguTipoHorarioNombre { get; set; }
    }
} 

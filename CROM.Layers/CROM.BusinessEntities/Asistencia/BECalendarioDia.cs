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
    /// Archivo     : CalendariosDias.cs
    /// </summary>
    public class BECalendarioDia
    {
        public string CodigoCalendario { get; set; }
        public string CodigoArguDiaSemana { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public bool Estado { get; set; }
        public int CodigoHorario { get; set; }
        public string Registro { get; set; }
        public string CodArguClaveReg { get; set; }

        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public string SegMaquinaOrigen { get; set; }
        public DateTime SegFechaHoraCrea { get; set; }
        public DateTime SegFechaHoraEdita { get; set; }

        public string CodigoHorarioNombre { get; set; }
        public string CodigoArguDiaSemanaNombre { get; set; }
        public string Proceso { get; set; }

        public BEHorario itemHorario { get; set; }
    }
}
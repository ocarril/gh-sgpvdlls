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
    /// Archivo     : TimeMarcaciones.cs
    /// </summary>
    public class BETimeMarcacion
    {
        public string CodigoPersona { get; set; }
        public string DiaSemana { get; set; }
        public DateTime FechaHora { get; set; }

        public string MarcacionesDescripcion { get; set; }

        public string Entra01 { get; set; }
        public string Salid01 { get; set; }
        public string Entra02 { get; set; }
        public string Salid02 { get; set; }
        public string Entra03 { get; set; }
        public string Salid03 { get; set; }
        public string Entra04 { get; set; }
        public string Salid04 { get; set; }
        public string Entra05 { get; set; }
        public string Salid05 { get; set; }
        public string Entra06 { get; set; }
        public string Salid06 { get; set; }

        public string HorarioEntrada { get; set; }

        public string HorasTeoricasTIME60 { get; set; }
        public string HorasLaboradaTIME60 { get; set; }
        public string HorasPermanenTIME60 { get; set; }
        public string HorasDebeTiemTIME60 { get; set; }
        public string HorasExtras01TIME60 { get; set; }
        public string HorasExtras02TIME60 { get; set; }
        public string HorasExtras03TIME60 { get; set; }
        public string RefrigerTeoriTIME60 { get; set; }
        public string RefrigerRealiTIME60 { get; set; }
        public string RefrigerExcesTIME60 { get; set; }

        public double HorasTeoricasDOUBLE { get; set; }
        public double HorasLaboradaDOUBLE { get; set; }
        public double HorasPermanenDOUBLE { get; set; }
        public double HorasDebeTiemDOUBLE { get; set; }
        public double HorasExtras01DOUBLE { get; set; }
        public double HorasExtras02DOUBLE { get; set; }
        public double HorasExtras03DOUBLE { get; set; }
        public double RefrigerTeoriDOUBLE { get; set; }
        public double RefrigerRealiDOUBLE { get; set; }
        public double RefrigerExcesDOUBLE { get; set; }

        public int CONTADOR_VecesTarde { get; set; }
        public int CONTADOR_MinutosTarde { get; set; }
        public int CONTADOR_VecesFalta { get; set; }

        public string CodigoPersonaNombre { get; set; }
        public string CodigoPersonaDNI { get; set; }
    }
}

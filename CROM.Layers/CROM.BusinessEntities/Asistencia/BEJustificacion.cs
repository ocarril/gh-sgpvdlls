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
    /// Archivo     : [Asistencia.Justificaciones.cs]
    /// </summary>
    public class BEJustificacion
    {
        public string CodigoJustificacion { get; set; }
        public string Descripcion { get; set; }
        public bool EsRemunerable { get; set; }
        public bool EsEspecial { get; set; }
        public bool EsEliminado { get; set; }
        public string EnlaceJustificacion { get; set; }
        public string CodigoArguTeclaReloj { get; set; }
        public string CodigoArguNombreReloj { get; set; }
        public string CodigoArguComputa { get; set; }
        public bool Estado { get; set; }

        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public DateTime SegFechaHoraCrea { get; set; }
        public DateTime SegFechaHoraEdita { get; set; }
        public string SegMaquinaOrigen { get; set; }

        public string CodigoArguTeclaRelojNombre { get; set; }
        public string CodigoArguNombreRelojNombre { get; set; }
        public string CodigoArguComputaNombre { get; set; }
    }
} 

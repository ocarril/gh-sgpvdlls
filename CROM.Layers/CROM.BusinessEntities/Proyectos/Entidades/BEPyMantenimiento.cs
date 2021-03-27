namespace CROM.BusinessEntities.Proyectos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CROM.BusinessEntities;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 15/09/2015-02:06:46 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Proyectos.PyMantenimiento.cs]
    /// </summary>
    public class BEPyMantenimiento : BEBase
    {
        public int codPyMantenimiento { get; set; }
        public int codProyecto { get; set; }
        public Nullable<DateTime> fecProgramada { get; set; }
        public Nullable<DateTime> fecRealizada { get; set; }
        public int codDocumEstado { get; set; }
        public string gloObservacion { get; set; }
        public int? codPyEquipo { get; set; }
        public int? codEmpleadoResp { get; set; }
        public bool indActivo { get; set; }

    }
} 

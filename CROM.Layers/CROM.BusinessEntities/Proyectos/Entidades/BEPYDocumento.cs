namespace CROM.BusinessEntities.Proyectos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CROM.BusinessEntities;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : (OCR) Orlando Carril Ramirez
    /// Fecha       : 10/12/2014-02:14:05 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Proyectos.PYDocumento.cs]
    /// </summary>
    public class BEPYDocumento : BEBase
    {

        public int codPYDocumento { get; set; }
        public int codProyecto { get; set; }
        public string desNombreArchivo { get; set; }
        public string desGlosa { get; set; }
        public bool indActivo { get; set; }
    }
}

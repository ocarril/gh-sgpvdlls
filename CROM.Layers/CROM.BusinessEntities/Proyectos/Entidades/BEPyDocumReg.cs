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
    /// Archivo     : [Proyectos.PyDocumReg.cs]
    /// </summary>
    public class BEPyDocumReg : BEBase
    {
        public int codPyDocumReg { get; set; }
        public int codProyecto { get; set; }
        public int codDocumReg { get; set; }
        public string gloNota { get; set; }

        public bool indActivo { get; set; }
    }
}

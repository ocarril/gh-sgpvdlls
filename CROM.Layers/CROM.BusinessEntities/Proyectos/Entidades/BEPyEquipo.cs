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
    /// Archivo     : [Proyectos.PyEquipo.cs]
    /// </summary>
    public class BEPyEquipo : BEBase
    {
        public int codPyEquipo { get; set; }
        public int codPyDocumReg { get; set; }
        public int? codDocumRegDetalle { get; set; }
        public Nullable<DateTime> fecCompra { get; set; }
        public Nullable<DateTime> fecInstalacion { get; set; }
        public Nullable<DateTime> fecVencGarantia { get; set; }
        public int codDocumEstado { get; set; }
        public string gloNota { get; set; }
        public bool indActivo{ get; set; }

        public int codDocumReg { get; set; }
    }
}

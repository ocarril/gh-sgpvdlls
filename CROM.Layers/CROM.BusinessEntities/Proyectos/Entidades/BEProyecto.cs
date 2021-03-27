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
    /// Archivo     : [Proyectos.Proyecto.cs]
    /// </summary>
    public class BEProyecto : BEBase
    {
        public BEProyecto()
        {
            lstDocumento = new List<BEPYDocumento>();
        }

        public int codProyecto { get; set; }
        public string codPerCliente { get; set; }
        public int codRegEstado { get; set; }
        public string desNombre { get; set; }
        public DateTime fecInicio { get; set; }
        public Nullable<DateTime> fecFinal { get; set; }
        public bool indActivo { get; set; }

        public List<BEPYDocumento> lstDocumento { get; set; }
    }
}

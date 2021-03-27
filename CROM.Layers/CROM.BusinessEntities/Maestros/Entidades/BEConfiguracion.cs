namespace CROM.BusinessEntities.Maestros
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 06/04/2014-06:27:34 p.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Maestros.Configuracion.cs]
    /// </summary>
    public class BEConfiguracion : BEBase
    {

        public int codConfiguracion { get; set; }
        public string codKeyConfig { get; set; }
        public string codTabla { get; set; }
        public int numNivel { get; set; }
        public string indOrden { get; set; }
        public string indTipoValor { get; set; }
        public string desValor { get; set; }
        public string desNombre { get; set; }
        public string gloDescripcion { get; set; }
        public bool indGenerico { get; set; }
        public string desGrupo { get; set; }
        public bool indActivo { get; set; }

    }
}

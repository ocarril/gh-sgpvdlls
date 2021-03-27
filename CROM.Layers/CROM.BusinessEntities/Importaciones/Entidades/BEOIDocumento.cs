namespace CROM.BusinessEntities.Importaciones
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 22/08/2014-01:23:28 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Importaciones.OIDocumento.cs]
    /// </summary>
    public class BEOIDocumento : BEBase
    {
        public int codOIDocumento { get; set; }
        public int codOrdenImportacion { get; set; }
        public string desNombreArchivo { get; set; }
        public bool indActivo { get; set; }

        public string auxVistaParcial { get; set; }
    }
}

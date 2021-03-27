namespace CROM.BusinessEntities.Importaciones
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : TS(OCR)
    /// Fecha       : 11/09/2014-06:09:07 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Importaciones.OIDocumReg.cs]
    /// </summary>
    public class BEOIDocumReg : BEBase
    {
        public int codOIDocumReg { get; set; }
        public int codOrdenImportacion { get; set; }
        public int codDocumReg { get; set; }
        public bool indActivo { get; set; }

        public string auxnumDocumento { get; set; }
        public string auxnumDocumentoRef { get; set; }
        public string auxnumDocumentoSec { get; set; }
        public string auxnomProveedor { get; set; }
    }
}

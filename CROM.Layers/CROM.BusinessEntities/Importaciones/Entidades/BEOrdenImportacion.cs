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
    /// Archivo     : [Importaciones.OrdenImportacion.cs]
    /// </summary>
    public class BEOrdenImportacion : BEBase
    {
        public BEOrdenImportacion()
        {
            lstOIDocumento = new List<BEOIDocumento>();
            lstOIDUA = new List<BEOIDUA>();
            lstOIDocumReg = new List<BEOIDocumReg>();
        }

        public int codOrdenImportacion { get; set; }
        public string numOrdenImportacion { get; set; }
        public string codRegIncotermo { get; set; }
        public string codRegNacionalizacion { get; set; }
        public int codDocumentoEstado { get; set; }
        public string gloObservacion { get; set; }
        public DateTime fecEmitido { get; set; }
        public bool indActivo { get; set; }

        public List<BEOIDocumento> lstOIDocumento { get; set; }
        public List<BEOIDUA> lstOIDUA { get; set; }
        public List<BEOIDocumReg> lstOIDocumReg { get; set; }

        public string auxcodRegIncotermo { get; set; }
        public string auxcodRegNacionalizacion { get; set; }
        public string auxcodDocumentoEstado { get; set; }
        public string auxcodPerProveedor { get; set; }
        public string auxcodPerProveedorNombre { get; set; }
        public string auxfecEmitido { get; set; }

    }
}

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
    /// Archivo     : [Importaciones.OIDUA.cs]
    /// </summary>
    public class BEOIDUA : BEBase
    {
        public BEOIDUA()
        {
            lstOIDUACosto = new List<BEOIDUACosto>();
            lstOIDUAProducto = new List<BEOIDUAProducto>();
        }

        public int codOIDUA { get; set; }
        public int codOrdenImportacion { get; set; }
        public int codDocumentoEstado { get; set; }
        public string codRegCanal { get; set; }
        public string numOIDUA { get; set; }
        public DateTime fecEmision { get; set; }
        public Nullable<DateTime> fecPago { get; set; }
        public decimal? decFactor { get; set; }
        public bool indActivo { get; set; }

        public List<BEOIDUACosto> lstOIDUACosto { get; set; }
        public List<BEOIDUAProducto> lstOIDUAProducto { get; set; }

        public string auxcodDocumentoEstado { get; set; }
        public string auxcodRegCanal { get; set; }
        public string auxOIDUA { get; set; }
    }
}

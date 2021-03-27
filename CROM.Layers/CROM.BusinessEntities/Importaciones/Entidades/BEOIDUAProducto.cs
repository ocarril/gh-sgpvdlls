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
    /// Archivo     : [Importaciones.OIDUAProducto.cs]
    /// </summary>
    public class BEOIDUAProducto : BEBase
    {
        public BEOIDUAProducto()
        {
            lstOIDUASerie = new List<BEOIDUASerie>();
        }
        public int codOIDUAProducto { get; set; }
        public int codOIDUA { get; set; }
        public int codDocumRegDetalle { get; set; }
        public decimal? decCantidadFOB { get; set; }
        public decimal? decPrecioUniFOB { get; set; }
        public decimal? decTotalUniFOB { get; set; }
        public bool indActivo { get; set; }

        public List<BEOIDUASerie> lstOIDUASerie { get; set; }

        public string auxdesProducto { get; set; }
        public decimal? auxdecCantidadFOBmax { get; set; }

        public decimal? decPrecioUniCosto { get; set; }
        public decimal? decTotalUniCosto { get; set; }
    }
}

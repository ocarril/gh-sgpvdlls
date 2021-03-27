namespace CROM.BusinessEntities.Importaciones
{
    using CROM.BusinessEntities.Importaciones.DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 22/08/2014-01:23:28 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Importaciones.OIDUACosto.cs]
    /// </summary>
    public class BEOIDUACosto : BEBase
    {
        public BEOIDUACosto()
        {
            objOIDUA = new BEOIDUA();
            lstCostoDetalle = new List<DTOCostoDetalle>();
        }
        public int codOIDUACosto { get; set; }
        public int codOIDUA { get; set; }
        public string codRegResumenCosto { get; set; }
        public decimal decMontoCosto { get; set; }
        public bool indActivo { get; set; }
        public string codRegMoneda { get; set; }

        public BEOIDUA objOIDUA { get; set; }

        public string auxcodRegResumenCosto { get; set; }
        public string desOrigenDesde { get; set; }
        public decimal monTipoCambio { get; set; }
        public string auxcodRegMoneda { get; set; }

        public List<DTOCostoDetalle> lstCostoDetalle { get; set; }
    }
}

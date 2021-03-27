namespace CROM.BusinessEntities.Importaciones.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class DTOCostoDetalle
    {
        public int codOIDUA { get; set; }
        public int codOIDUACosto { get; set; }
        public string codRegResumenCosto { get; set; }
        public string codRegResumenCostoPadre { get; set; }
        public string codRegResumenCostoNombre { get; set; }
        public string codDocumento { get; set; }
        public string numDocumento { get; set; }
        public string fecEmision { get; set; }
        public string desProveedor { get; set; }
        public string desCosto { get; set; }
        public string codProducto { get; set; }
        public string codProductoNombre { get; set; }
        public decimal cntCantidad { get; set; }
        public decimal monUnitPrecioVenta { get; set; }
        public decimal monTotalDocumento { get; set; }

        public decimal monSoles { get; set; }
        public decimal monDolar { get; set; }
        public decimal monCostoDolar { get; set; }
        public string numOIDUA { get; set; }
        public string numItem { get; set; }
        public string editUsuario { get; set; }
        public string editFecha { get; set; }
        public int codDocumRegDetalle { get; set; }

        public string codRegMoneda { get; set; }
        public string codRegMonedaNombre { get; set; }
        public decimal monTipoCambioVta { get; set; }
        public decimal monTipoCambioCmp { get; set; }
    }
}

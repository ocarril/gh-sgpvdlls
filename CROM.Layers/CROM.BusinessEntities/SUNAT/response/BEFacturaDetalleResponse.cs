namespace CROM.BusinessEntities.SUNAT.response
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class BEFacturaDetalleResponse
    {
        public BEFacturaDetalleResponse()
        {
            codUnidadMedida = string.Empty;
            codProductoSUNAT = string.Empty;
            codProducto = string.Empty;
            desItem = string.Empty;
            codTipTributoIgvItem = string.Empty;
            codTipTributoIOtroItem = string.Empty;
            codTipTributoIscItem = string.Empty;
            codTriIGV = string.Empty;
            codTriISC = string.Empty;
            codTriOtroItem = string.Empty;
            nomTributoIgvItem = string.Empty;
            nomTributoIOtroItem = string.Empty;
            nomTributoIscItem = string.Empty;
            tipAfeIGV = string.Empty;
            tipSisISC = string.Empty;
        }

        public long codDocumRegDetalleSunat { get; set; }

        public long codDocumRegSunat { get; set; }

        public int codDocumReg { get; set; }

        public int codDocumRegDetalle { get; set; }

        public int codProductoDRD { get; set; }
        public string codUnidadMedida { get; set; }
        public decimal ctdUnidadItem { get; set; }
        public string codProducto { get; set; }
        public string codProductoSUNAT { get; set; }
        public string desItem { get; set; }
        public decimal mtoValorUnitario { get; set; }
        public decimal sumTotTributosItem { get; set; }
        public string codTriIGV { get; set; }
        public decimal mtoIgvItem { get; set; }
        public decimal mtoBaseIgvItem { get; set; }
        public string nomTributoIgvItem { get; set; }
        public string codTipTributoIgvItem { get; set; }
        public string tipAfeIGV { get; set; }
        public decimal porIgvItem { get; set; }
        public string codTriISC { get; set; }
        public decimal mtoIscItem { get; set; }
        public decimal mtoBaseIscItem { get; set; }
        public string nomTributoIscItem { get; set; }
        public string codTipTributoIscItem { get; set; }
        public string tipSisISC { get; set; }
        public decimal porIscItem { get; set; }
        public string codTriOtroItem { get; set; }
        public decimal mtoTriOtroItem { get; set; }
        public decimal mtoBaseTriOtroItem { get; set; }
        public string nomTributoIOtroItem { get; set; }
        public string codTipTributoIOtroItem { get; set; }
        public decimal porTriOtroItem { get; set; }
        public decimal mtoPrecioVentaUnitario { get; set; }
        public decimal mtoValorVentaItem { get; set; }
        public decimal mtoValorReferencialUnitario { get; set; }


        public Int16 cntDecimales { get; set; }

        #region montos adicionales según el negocio

        public decimal mtoUnitPrecioBruto { get; set; }
        public decimal mtoUnitDescuento { get; set; }
        public decimal mtoUnitValorCosto { get; set; }
        public decimal mtoUnitValorDscto { get; set; }
        public decimal mtoUnitPrecioSinIGV { get; set; }
        public decimal mtoUnitValorIGV { get; set; }
        public decimal mtoValorBrutoItem { get; set; }
        public decimal mtoValorDsctoItem { get; set; }

        #endregion
    }
}

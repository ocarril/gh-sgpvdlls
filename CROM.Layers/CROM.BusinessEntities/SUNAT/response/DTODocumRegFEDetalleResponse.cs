namespace CROM.BusinessEntities.SUNAT.response
{
    using System;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 20/01/2020-12:45 p.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [SUNAT.TBDocumRegDetalle.cs]
    /// </summary>
    public class DTODocumRegFEDetalleResponse: BEBaseEntidad
    {
        public DTODocumRegFEDetalleResponse()
        {
            DRD_codProducto = string.Empty;
            DRD_codProductoSUNAT = string.Empty;
            DRD_codTipTributoIgvItem = string.Empty;
            DRD_codTipTributoIOtroItem = string.Empty;
            DRD_codTipTributoIscItem = string.Empty;
            DRD_codTriIGV = string.Empty;
            DRD_codTriISC = string.Empty;
            DRD_codTriOtroItem = string.Empty;
            DRD_codUnidadDeMedida = string.Empty;
            DRD_desItem = string.Empty;
            DRD_nomTributoIgvItem = string.Empty;
            DRD_nomTributoIOtroItem = string.Empty;
            DRD_nomTributoIscItem = string.Empty;
            DRD_tipAfeIGV = string.Empty;
            DRD_tipSisISC = string.Empty;
        }

        public int codDocumRegDetalleSunat { get; set; }
        public int codDocumRegSunat { get; set; }
        public int codDocumReg { get; set; }
        public int codDocumRegDetalle { get; set; }
        public int codProductoDRD { get; set; }
        public string DRD_codUnidadDeMedida { get; set; }
        public decimal DRD_ctdUnidadItem { get; set; }
        public string DRD_codProducto { get; set; }
        public string DRD_codProductoSUNAT { get; set; }
        public string DRD_desItem { get; set; }
        public decimal DRD_mtoValorUnitario { get; set; }
        public decimal DRD_sumTotTributosItem { get; set; }
        public string DRD_codTriIGV { get; set; }
        public decimal DRD_mtoIgvItem { get; set; }
        public decimal DRD_mtoBaseIgvItem { get; set; }
        public string DRD_nomTributoIgvItem { get; set; }
        public string DRD_codTipTributoIgvItem { get; set; }
        public string DRD_tipAfeIGV { get; set; }
        public decimal DRD_porIgvItem { get; set; }
        public string DRD_codTriISC { get; set; }
        public decimal DRD_mtoIscItem { get; set; }
        public decimal DRD_mtoBaseIscItem { get; set; }


        public string DRD_nomTributoIscItem { get; set; }
        public string DRD_codTipTributoIscItem { get; set; }
        public string DRD_tipSisISC { get; set; }
        public decimal DRD_porIscItem { get; set; }
        public string DRD_codTriOtroItem { get; set; }
        public decimal DRD_mtoTriOtroItem { get; set; }
        public decimal DRD_mtoBaseTriOtroItem { get; set; }
        public string DRD_nomTributoIOtroItem { get; set; }
        public string DRD_codTipTributoIOtroItem { get; set; }
        public decimal DRD_porTriOtroItem { get; set; }
        public decimal DRD_mtoPrecioVentaUnitario { get; set; }
        public decimal DRD_mtoValorVentaItem { get; set; }
        public decimal DRD_mtoValorReferencialUnitario { get; set; }
        public bool DRD_ACTIVADA { get; set; }
        public bool DRD_DEBAJA { get; set; }

        public Int16 cntDecimales { get; set; }

        public string codUnidadDeMedidaAbrev { get; set; }

        public string codUnidadDeMedidaNombre { get; set; }

        //public decimal UnitDescuento { get; set; }

        //public decimal UnitValorDscto { get; set; }

        //public decimal TotItemValorDscto { get; set; }


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

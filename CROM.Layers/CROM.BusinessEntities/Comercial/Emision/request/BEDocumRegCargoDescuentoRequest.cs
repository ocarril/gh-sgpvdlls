namespace CROM.BusinessEntities.Comercial.emision.request
{
    using System;


    public class BEDocumRegCargoDescuentoRequest: BEBaseEntidadRequest
    {
        public BEDocumRegCargoDescuentoRequest()
        {

        }

        public int codDocumRegCargoDescuento { get; set; }

        public int? codDocumRegDetalle { get; set; }

        #region CUANDO ES EN TABLA TEMPORAL

        public Guid? keyDocumRegCargoDescuento { get; set; }

        public Guid? keyDocumRegDetalle { get; set; }

        public string keyTokenUser { get; set; }

        #endregion

        public int? codDocumReg { get; set; }

        public string numItem { get; set; }

        public bool indNivelOrigen { get; set; }

        public bool indTipoVariable { get; set; }

        public int codCargoDescuento { get; set; }

        public decimal prcItem { get; set; }

        public string codRegMonedaMontoItem { get; set; }

        public decimal mtoItem { get; set; }

        public string codRegMonedaBaseImpon { get; set; }

        public decimal mtoBaseImponible { get; set; }


    }
}

namespace CROM.BusinessEntities.Comercial.response
{
    public class DTODocumRegCargoDescuentoResponse : BEBasePagedResponse
    {
        public DTODocumRegCargoDescuentoResponse()
        {
            numItem=string.Empty;
            KeyCargoDescuento = string.Empty;
            codCargoDescuentoNombre = string.Empty;
            codRegMonedaBaseImpon = string.Empty;
            codRegMonedaMontoItem = string.Empty;
        }

        public int codDocumRegCargoDescuento { get; set; }

        public int? codDocumRegDetalle { get; set; }

        public int? codDocumReg { get; set; }

        public string numItem { get; set; }

        public bool indNivelOrigen { get; set; }

        public bool indTipoVariable { get; set; }

        public int codCargoDescuento { get; set; }

        public string KeyCargoDescuento { get; set; }

        public string codCargoDescuentoNombre { get; set; }

        public decimal prcItem { get; set; }

        public string codRegMonedaMontoItem { get; set; }

        public decimal mtoItem { get; set; }

        public string codRegMonedaBaseImpon { get; set; }

        public decimal mtoBaseImponible { get; set; }

    }
}

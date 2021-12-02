namespace CROM.BusinessEntities.Temporales.request
{
    using System;


    public class BEDocumRegTMPDetalleUpdateMonedaRequest : BEBaseEntidadItem
    {
        public BEDocumRegTMPDetalleUpdateMonedaRequest()
        {
            keyTokenUser = string.Empty;
            codRegMoneda = string.Empty;
            codPersonaEntidad = string.Empty;
        }

        public string keyTokenUser { get; set; }

        public string codPersonaEntidad { get; set; }

        public string codRegMoneda { get; set; }

        public decimal monTipoCambioVTA { get; set; }

        public decimal monTipoCambioCMP { get; set; }

        public bool indGravadoIGV { get; set; }
    }
}

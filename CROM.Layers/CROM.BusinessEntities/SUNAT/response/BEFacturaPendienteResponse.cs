namespace CROM.BusinessEntities.SUNAT.response
{
    using System;

    public class BEFacturaPendienteResponse : BEBasePagedResponse
    {
        public BEFacturaPendienteResponse()
        {
            numDocumento = string.Empty;
            codRegMonedaNombre = string.Empty;
            codCondicionVentaNombre = string.Empty;
        }

        public Nullable<DateTime> fecEmisionDate { get; set; }

        public Nullable<DateTime> fecVencimiento { get; set; }

        public string Abreviatura { get; set; }

        public string numDocumento { get; set; }

        public string rznSocialUsuario { get; set; }
        
        public string codRegMonedaNombre { get; set; }

        public decimal sumPrecioVenta { get; set; }

        public decimal monTotalPrecioExtran { get; set; }

        public decimal? prcDetraccion { get; set; }

        public decimal? mtoDetraccion { get; set; }

        public string codCondicionVentaNombre { get; set; }

        public Nullable<DateTime> RptaSunatFSFecha { get; set; }


    }
}

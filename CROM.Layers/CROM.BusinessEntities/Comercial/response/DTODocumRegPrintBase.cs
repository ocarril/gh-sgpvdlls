namespace CROM.BusinessEntities.Comercial.response
{
    public class DTODocumRegPrintBase
    {
        public DTODocumRegPrintBase()
        {
            FirmaDeVendedor = string.Empty;
            EmisorCorreoE = string.Empty;
            EmisorDomicilio = string.Empty;
            EmisorPropaganda = string.Empty;
            EmisorRazonSocial = string.Empty;
            EmisorTelefon01 = string.Empty;
            EmisorTelefon02 = string.Empty;
            EmisorUbigeo = string.Empty;
            EmisorWebSite = string.Empty;
            TiempoEntrega = string.Empty;
            LogoAdicionalEmpresa = string.Empty;
        }

        public string EmisorRazonSocial { get; set; }

        public string EmisorDomicilio { get; set; }

        public string EmisorUbigeo { get; set; }

        public string EmisorTelefon01 { get; set; }

        public string EmisorTelefon02 { get; set; }

        public string EmisorWebSite { get; set; }

        public string EmisorCorreoE { get; set; }

        public string EmisorPropaganda { get; set; }

        public string TiempoEntrega { get; set; }

        public string FirmaDeVendedor { get; set; }

        public string LogoAdicionalEmpresa { get; set; }

    }

}

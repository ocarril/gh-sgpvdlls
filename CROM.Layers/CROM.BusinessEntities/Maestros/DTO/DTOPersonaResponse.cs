namespace CROM.BusinessEntities.Maestros.DTO
{
    public class DTOPersonaResponse: BEBasePagedResponse
    {
        public DTOPersonaResponse()
        {
            CodigoPersona = string.Empty;
            CodigoArguTipoEntidad = string.Empty;
            CodigoArguRubroComercialNombre = string.Empty;
            RazonSocial = string.Empty;
            NombreComercial = string.Empty;
            Observaciones = string.Empty;
            desDomicilio = string.Empty;
            desTelefono = string.Empty;
            desNumDocumento = string.Empty;
        }

        public int codEmpresa { get; set; }

        public string CodigoPersona { get; set; }

        public string CodigoArguTipoEntidad { get; set; }

        public string CodigoArguRubroComercial { get; set; }

        public string CodigoPersonaEmpresa { get; set; }

        public string RazonSocial { get; set; }

        public string NombreComercial { get; set; }

        public string Observaciones { get; set; }
        
        public string CodigoArguTipoEntidadNombre { get; set; }

        public string CodigoArguRubroComercialNombre { get; set; }

        public string CodigoPersonaEmpresaNombre { get; set; }

        public string desDomicilio { get; set; }

        public string desTelefono { get; set; }

        public string desNumDocumento { get; set; }


    }
}

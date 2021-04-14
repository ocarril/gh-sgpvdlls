namespace CROM.BusinessEntities.Maestros.DTO
{
    public class DTOPersonaPagedResponse : BEBasePagedResponse
    {
        public DTOPersonaPagedResponse()
        {
            codPersona = string.Empty;
            codRegTipoEntidad = string.Empty;
            codRegRubroComercial = string.Empty;
            codRegTipoEntidadNombre = string.Empty;
            codRegRubroComercialNombre = string.Empty;
            RazonSocial = string.Empty;
            NombreComercial = string.Empty;
            Observaciones = string.Empty;
            desDomicilio = string.Empty;
            desTelefono = string.Empty;
            desNumDocumento = string.Empty;
        }

        public int codEmpresa { get; set; }

        public string codPersona { get; set; }

        public string codRegTipoEntidad { get; set; }

        public string codRegRubroComercial { get; set; }

        public string codPerEmpresa { get; set; }

        public string RazonSocial { get; set; }

        public string NombreComercial { get; set; }

        public string Observaciones { get; set; }
        
        public string codRegTipoEntidadNombre { get; set; }

        public string codRegRubroComercialNombre { get; set; }

        public string codPerEmpresaNombre { get; set; }

        public string desDomicilio { get; set; }

        public string desTelefono { get; set; }

        public string desNumDocumento { get; set; }


    }
}

namespace CROM.BusinessEntities.Maestros.DTO
{
    public class DTOPersonaContactoResponse : BEBaseEntidadItem
    {
        public DTOPersonaContactoResponse()
        {
            codPersona = string.Empty;
            codRegTipoEntidad = string.Empty;
            codRegRubroComercialNombre = string.Empty;
            nomRazonSocial = string.Empty;
            nomComercial = string.Empty;
            gloObservacion = string.Empty;
            desNombres = string.Empty;
            desApellidos = string.Empty;
        }

        public string codPersona { get; set; }

        public string codRegTipoEntidad { get; set; }

        public string codRegRubroComercial { get; set; }

        public string desApellidos { get; set; }

        public string desNombres { get; set; }

        public string codPersonaEmpresa { get; set; }

        public string nomRazonSocial { get; set; }

        public string nomComercial { get; set; }

        public string gloObservacion { get; set; }
        
        public string codRegTipoEntidadNombre { get; set; }

        public string codRegRubroComercialNombre { get; set; }

        public string codPersonaEmpresaNombre { get; set; }

    }
}

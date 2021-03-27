namespace CROM.BusinessEntities.Maestros.DTO
{
    public class DTOEmpresaPersonaResponse: BEBaseEntidadItem
    {

        public DTOEmpresaPersonaResponse()
        {
            codPersona = string.Empty;
            codRegRubroComercialNombre = string.Empty;
            nomRazonSocial = string.Empty;
            nomComercial = string.Empty;
            gloObservacion = string.Empty;
            desDomicilio = string.Empty;
            desTelefono = string.Empty;
            desNumDocumento = string.Empty;
            nomUbigeo = string.Empty;
            desWebSite = string.Empty;
            desCorreoElectronico = string.Empty;
            desNumeroCuentaDetrac = string.Empty;
        }

        public string codPersona { get; set; }

        public string codRegTipoEntidadNombre { get; set; }

        public string codRegRubroComercialNombre { get; set; }

        public string nomRazonSocial { get; set; }

        public string nomComercial { get; set; }

        public string gloObservacion { get; set; }

        public int cntDomicilio { get; set; }

        public int? codPersonaDomicilio { get; set; }

        public int codRegTipo { get; set; }

        public string codRegTipoStr { get; set; }

        public string codRegTipoNombre { get; set; }

        public string desDomicilio { get; set; }

        public string codUbigeo { get; set; }

        public string nomUbigeo { get; set; }

        public string desTelefono { get; set; }

        public string codRegTipoDocumentoEntidad { get; set; }

        public string tipoDocumento { get; set; }

        public string desNumDocumento { get; set; }

        public bool indClienteCROM { get; set; }

        public string desCorreoElectronico { get; set; }

        public string desWebSite { get; set; }

        public string imgFirmaPersona { get; set; }

        public int codCuentaBancariaDetrac { get; set; }
        public string desNumeroCuentaDetrac { get; set; }

        public int numDocumentoPendSUNAT  { get; set; }
        public int numDiasPendMinimoSUNAT { get; set; }
        public int numDiasPendMaximoSUNAT { get; set; }
    }
}

namespace CROM.BusinessEntities.Maestros.DTO
{
    public class DTOPersonasDomicilioResponse : BEBasePagedResponse
    {
        public DTOPersonasDomicilioResponse()
        {
            codPersona = string.Empty;
            gloDireccion = string.Empty;
            desNucleoUrb = string.Empty;
            desNumero = string.Empty;
            gloDireccion = string.Empty;
            gloDireccionConcat = string.Empty;
            gloDireccionGeoCod = string.Empty;
            gloDireccionSunat = string.Empty;
            gloReferencia = string.Empty;
            numLatitud = 0;
            numLongitud = 0;
        }

        public int codPersonaDomicilio { get; set; }
        public string codPersona { get; set; }
        public string codRegTipoNombre { get; set; }
        public string codRegViaNombre { get; set; }
        public string gloDireccion { get; set; }
        public string desNumero { get; set; }
        public string codRegNucleoUrbNombre { get; set; }
        public string desNucleoUrb { get; set; }
        public int codUbigeo { get; set; }
        public string nomUbigeo { get; set; }
        public string gloReferencia { get; set; }
        public string gloDireccionConcat { get; set; }
        public string gloDireccionGeoCod { get; set; }
        public string gloDireccionSunat { get; set; }
        public double? numLatitud { get; set; }
        public double? numLongitud { get; set; }

        public bool indActivo { get; set; }

        public string codUbigeoCode { get; set; }

        public string codUbigeoNombre { get; set; }
    }
}

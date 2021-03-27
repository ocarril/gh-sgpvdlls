namespace CROM.BusinessEntities.Maestros
{
    using CROM.BusinessEntities.Maestros.Entidades;

    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de la Tablas Personas
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 30/12/2009
    /// Descripcion : Entidad de negocio
    /// Archivo     : Personas.cs
    /// </summary>
    public class BEPersona : BEBaseMaestro
    {
        public BEPersona()
        {
            CodigoPersona = string.Empty;
            RazonSocial = string.Empty;
            NombreComercial = string.Empty;
            Observaciones = string.Empty;
            CodigoArguRubroComercialNombre = string.Empty;
            CodigoArguTipoEntidadNombre = string.Empty;
            SegMaquinaOrigen = string.Empty;
            CodigoPersonaEmpresaNombre = string.Empty;
            SegUsuarioCrea = string.Empty;
            SegUsuarioEdita = string.Empty;
            desDomicilio = string.Empty;
            desNumDocumento = string.Empty;
            desTelefono = string.Empty;
            itemDatoAdicional = new BEPersonaDato();
            itemPersonasFotoLogo = new BEPersonaFotoLogo();
            listaPersonasAtributos = new List<BEPersonaAtributo>();
            listaPersonasAsignaciones = new List<BEPersonasAsignacion>();
            listaPersonasDomicilio = new List<BEPersonasDomicilio>();
        }

        public string CodigoPersona { get; set; }

        public string CodigoArguTipoEntidad { get; set; }

        public string CodigoArguRubroComercial { get; set; }

        public string CodigoPersonaEmpresa { get; set; }

        public string RazonSocial { get; set; }

        public string NombreComercial { get; set; }

        public string Observaciones { get; set; }
        
        public bool EsClienteCROM { get; set; }

        public string CodigoArguTipoEntidadNombre { get; set; }

        public string CodigoArguRubroComercialNombre { get; set; }

        public string CodigoPersonaEmpresaNombre { get; set; }

        public BEPersonaFotoLogo itemPersonasFotoLogo { get; set; }

        public BEPersonaDato itemDatoAdicional { get; set; }

        public List<BEPersonaAtributo> listaPersonasAtributos { get; set; }

        public List<BEPersonasAsignacion> listaPersonasAsignaciones { get; set; }

        public List<BEPersonasDomicilio> listaPersonasDomicilio { get; set; }

        public string desDomicilio { get; set; }

        public string desTelefono  { get; set; }

        public string desNumDocumento { get; set; }

        [JsonIgnore]
        public int TOTAL_AFECT { get; set; }

    }
}

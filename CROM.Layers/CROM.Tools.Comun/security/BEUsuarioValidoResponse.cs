namespace CROM.Tools.Comun.security
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public class BEUsuarioValidoResponse
    {
        public BEUsuarioValidoResponse()
        {

        }

        [JsonProperty("codUsuario")]
        public string codUsuario { get; set; }


        [JsonProperty("desCorreo")]
        public string desCorreo { get; set; }


        [JsonProperty("codEmpresa")]
        public int codEmpresa { get; set; }


        [JsonProperty("codEmpresaNombre")]
        public string codEmpresaNombre { get; set; }


        [JsonProperty("codEmpleado")]
        public string codEmpleado { get; set; }


        [JsonProperty("desLogin")]
        public string desLogin { get; set; }


        [JsonProperty("codSistema")]
        public string codSistema { get; set; }


        [JsonProperty("codSistemaNombre")]
        public string codSistemaNombre { get; set; }


        [JsonProperty("codRol")]
        public string codRol { get; set; }


        [JsonProperty("codRolNombre")]
        public string codRolNombre { get; set; }


        [JsonProperty("desNombreUsuario")]
        public string desNombreUsuario { get; set; }


        [JsonProperty("desApellido")]
        public string desApellido { get; set; }


        [JsonProperty("desNombre")]
        public string desNombre { get; set; }


        [JsonProperty("token")]
        public string Token { get; set; }


        [JsonProperty("desTelefono")]
        public string desTelefono { get; set; }


        [JsonProperty("indVendedor")]
        public bool indVendedor { get; set; }


        [JsonProperty("indCambioPrecio")]
        public bool indCambioPrecio { get; set; }


        [JsonProperty("indAccesoGerencial")]
        public bool indAccesoGerencial { get; set; }


        [JsonProperty("indCambiaDescuento")]
        public bool indCambiaDescuento { get; set; }


        [JsonProperty("indCambiaCodPersona")]
        public bool indCambiaCodPersona { get; set; }


        [JsonProperty("indJefeCaja")]
        public bool indJefeCaja { get; set; }


        [JsonProperty("indUsuarioSistema")]
        public bool indUsuarioSistema { get; set; }


        [JsonProperty("lstObjeto")]
        public List<BEUsuarioPermisoResponse> lstObjeto { get; set; }

        [JsonProperty("numRUC")]
        public string numRUC { get; set; }


        [JsonProperty("resultIndValido")]
        public bool ResultIndValido { get; set; }

        [JsonProperty("resultIMessage")]
        public string ResultIMessage { get; set; }



        [DataMember]
        public string codPersonaEmpresa { get; set; }
        [DataMember]
        public string codPersonaRUCEmpresa { get; set; }
        [DataMember]
        public string codPersonaEmpresaNombre { get; set; }
        [DataMember]
        public string codPersonaEmpresaDomicilio { get; set; }
        [DataMember]
        public string codPuntoVenta { get; set; }
        [DataMember]
        public string codPuntoVentaNombre { get; set; }


        [DataMember]
        [JsonProperty("urlPhotoUser")]
        public string urlPhotoUser { get; set; }


        [DataMember]
        [JsonProperty("indOrigenUser")]
        public string indOrigenUser { get; set; }

        [DataMember]
        [JsonProperty("codGUID")]
        public string codGUID { get; set; }
    }

}

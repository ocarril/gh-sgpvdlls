namespace CROM.Tools.Comun.security
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Runtime.Serialization;


    [DataContract]
    public class BEUsuarioPermisoResponse
    {

        public BEUsuarioPermisoResponse()
        {
            codOpcionNombre = string.Empty;
            codOpcionPadreNombre = string.Empty;
            lstSubMenus = new List<BEUsuarioPermisoResponse>();
        }

        [DataMember]
        [JsonProperty("codOpcion")]
        public string codOpcion { get; set; }

        [DataMember]
        [JsonProperty("codOpcionPadre")]
        public string codOpcionPadre { get; set; }

         [DataMember]
        [JsonProperty("codOpcionNombre")]
        public string codOpcionNombre { get; set; }

        [DataMember]
        [JsonProperty("codOpcionDescripcion")]
        public string codOpcionDescripcion { get; set; }

        [DataMember]
        [JsonProperty("codOpcionPadreNombre")]
        public string codOpcionPadreNombre { get; set; }

        [DataMember]
        [JsonProperty("desEnlaceURL")]
        public string desEnlaceURL { get; set; }

        [DataMember]
        [JsonProperty("desEnlaceWIN")]
        public string desEnlaceWIN { get; set; }


        [DataMember]
        [JsonProperty("desEnlacePadre")]
        public string desEnlacePadre { get; set; }


        [DataMember]
        [JsonProperty("indVer")]
        public bool indVer { get; set; }
        [DataMember]
        [JsonProperty("indNuevo")]
        public bool indNuevo { get; set; }
        [DataMember]
        [JsonProperty("indEditar")]
        public bool indEditar { get; set; }
        [DataMember]
        [JsonProperty("indEliminar")]
        public bool indEliminar { get; set; }
        [DataMember]
        [JsonProperty("indImprime")]
        public bool indImprime { get; set; }
        [DataMember]
        [JsonProperty("indImporta")]
        public bool indImporta { get; set; }
        [DataMember]
        [JsonProperty("indExporta")]
        public bool indExporta { get; set; }
        [DataMember]
        [JsonProperty("indOtro")]
        public bool indOtro { get; set; }


        [DataMember]
        [JsonProperty("nomIcono")]
        public string nomIcono { get; set; }



        [DataMember]
        [JsonProperty("codSistema")]
        public string codSistema { get; set; }


        [JsonProperty("indTipoObjeto")]
        public string indTipoObjeto { get; set; }

        [DataMember]
        [JsonProperty("numOrden")]
        public int numOrden { get; set; }

        [JsonProperty("numOrdenPadre")]
        public int numOrdenPadre { get; set; }

        [DataMember]
        [JsonProperty("codElementoID")]
        public string codElementoID { get; set; }


        [JsonProperty("lstSubMenus")]
        public List<BEUsuarioPermisoResponse> lstSubMenus { get; set; }

    }
}

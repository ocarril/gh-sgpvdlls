namespace CROM.Tools.Comun.security
{
    using Newtonsoft.Json;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de SEGURIDAD del Sistema 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 04/11/2019
    /// Fecha edit  :
    /// Descripcion : Entidad de negocio
    /// Archivo     : Opcion.cs 
    /// </summary>
    public class BEOpcionPermiso
    {
        [JsonProperty("codOpcion")]
        public string codOpcion { get; set; }

        [JsonProperty("codOpcionNombre")]
        public string codOpcionNombre { get; set; }

        [JsonProperty("codOpcionDescripcion")]
        public string codOpcionDescripcion { get; set; }

        [JsonProperty("codOpcionPadre")]
        public string codOpcionPadre { get; set; }

        [JsonProperty("codOpcionNombrePadre")]
        public string codOpcionNombrePadre { get; set; }

        [JsonProperty("codSistema")]
        public string codSistema { get; set; }

        [JsonProperty("desNombre")]
        public string desNombre { get; set; }

        [JsonProperty("desDescripcion")]
        public string desDescripcion { get; set; }

        [JsonProperty("desEnlaceURL")]
        public string desEnlaceURL { get; set; }

        [JsonProperty("desEnlaceWIN")]
        public string desEnlaceWIN { get; set; }

        [JsonProperty("indMenu")]
        public bool indMenu { get; set; }

        [JsonProperty("indEstado")]
        public bool indEstado { get; set; }

        [JsonProperty("segMaquinaOrigen")]
        public string segMaquinaOrigen { get; set; }

        [JsonProperty("numOrden")]
        public int numOrden { get; set; }

        [JsonProperty("nomIcono")]
        public string nomIcono { get; set; }

        [JsonProperty("indTipoObjeto")]
        public string indTipoObjeto { get; set; }

        [JsonProperty("codElementoID")]
        public string codElementoID { get; set; }


        [JsonProperty("indVer")]
        public bool indVer { get; set; }

        [JsonProperty("indNuevo")]
        public bool indNuevo { get; set; }

        [JsonProperty("indEditar")]
        public bool indEditar { get; set; }

        [JsonProperty("indEliminar")]
        public bool indEliminar { get; set; }

        [JsonProperty("indImprime")]
        public bool indImprime { get; set; }

        [JsonProperty("indImporta")]
        public bool indImporta { get; set; }

        [JsonProperty("indExporta")]
        public bool indExporta { get; set; }

        [JsonProperty("indOtro")]
        public bool indOtro { get; set; }

    }
}

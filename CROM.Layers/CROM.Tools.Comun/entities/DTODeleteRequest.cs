namespace CROM.Tools.Comun.entities
{
    using Newtonsoft.Json;
       
    public class DTODeleteRequest
    {
        public DTODeleteRequest()
        {
            DelUser = string.Empty;
            IdRecordStr = string.Empty;
            segIPMaquinaPC = string.Empty;
        }

        [JsonIgnore]
        public int codEmpresa { get; set; }

        [JsonIgnore]
        public string codEmpresaRUC { get; set; }

        [JsonIgnore]
        public string DelUser { get; set; }

        [JsonIgnore]
        public int IdRecord { get; set; }

        [JsonIgnore]
        public string IdRecordStr { get; set; }

        [JsonIgnore]
        public string segIPMaquinaPC { get; set; }
    }
}

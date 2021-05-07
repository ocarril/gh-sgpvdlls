namespace CROM.BusinessEntities.SUNAT.request
{
    using Newtonsoft.Json;


    public class BETypeSummaryCorrelativeRequest
    {
        public BETypeSummaryCorrelativeRequest()
        {
            codEmpresaRUC = string.Empty;
            FechaProceso = string.Empty;
            TipoResumen = string.Empty;
        }

        [JsonIgnore]
        public int codEmpresa { get; set; }

        [JsonIgnore]
        public string codEmpresaRUC { get; set; }

        public string FechaProceso { get; set; }

        public string TipoResumen { get; set; }

        public int numCorrelativo { get; set; }
    }
}

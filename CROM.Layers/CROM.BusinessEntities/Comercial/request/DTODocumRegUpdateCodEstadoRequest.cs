namespace CROM.BusinessEntities.Comercial.request
{
    using Newtonsoft.Json;
    using System.Collections.Generic;


    public class DTODocumRegUpdateCodEstadoRequest : BEBaseEntidadItem
    {
        public DTODocumRegUpdateCodEstadoRequest()
        {

            ListDocumReg = new List<ItemDocumRegUpdate>();
        }

        public List<ItemDocumRegUpdate> ListDocumReg { get; set; }


        public string codDocumento { get; set; }

        public string codRegDocumento { get; set; }


        [JsonIgnore]
        public int codDocumReg { get; set; }

        [JsonIgnore]
        public string codRegEstadoDocu { get; set; }

        [JsonIgnore]
        public int codDocumentoEstado { get; set; }
    }

    public class ItemDocumRegUpdate
    {

        public int codDocumReg { get; set; }

        public string codAbreviatura { get; set; }

        public string numDocumento { get; set; }

    }

}

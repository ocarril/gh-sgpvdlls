namespace CROM.BusinessEntities.Comercial.request
{
    using System.Collections.Generic;


    public class DTODocumRegUpdateCodEstadoRequest : BEBaseEntidadItem
    {
        public DTODocumRegUpdateCodEstadoRequest()
        {

            gloObservaciones = string.Empty;
            ListDocumReg = new List<ItemDocumRegUpdate>();
        }

        public List<ItemDocumRegUpdate> ListDocumReg { get; set; }

        public int codDocumReg { get; set; }

        public string codDocumento { get; set; }

        public string codRegDocumento { get; set; }

        public string codRegEstadoDocu { get; set; }

        public string gloObservaciones { get; set; }
    }

    public class ItemDocumRegUpdate
    {

        public int codDocumReg { get; set; }

        public string codAbreviatura { get; set; }

    }

}

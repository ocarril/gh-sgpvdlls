namespace CROM.BusinessEntities.Comercial.request
{
    using System;


    public class DTODocumRegUnsubscribeDocumentRequest : BEBaseEntidadItem
    {
        public DTODocumRegUnsubscribeDocumentRequest()
        {

            gloObservaciones = string.Empty;
        }

        public int codDocumReg { get; set; }

        public string codRegAnulacion { get; set; }

        public DateTime? fecAnulacion { get; set; }

        public string gloObservaciones { get; set; }
    }

}

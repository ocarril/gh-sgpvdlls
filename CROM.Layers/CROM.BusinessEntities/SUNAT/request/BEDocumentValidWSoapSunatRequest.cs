namespace CROM.BusinessEntities.SUNAT.request
{
    using System;

    public class BEDocumentValidWSoapSunatRequest : BEBaseEntidadItem
    {
        public BEDocumentValidWSoapSunatRequest()
        {

            desValidWSoapSunat = string.Empty;

        }

        public int codDocumReg { get; set; }

        public DateTime? fecValidWSoapSunat { get; set; }

        public string desValidWSoapSunat { get; set; }

        public bool indValidWSoapSunat { get; set; }

    }
}

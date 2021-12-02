using System.Collections.Generic;

namespace CROM.BusinessEntities.Temporales.request
{
    public class BEDocumRegTMPDetalleBuscaRequest : BEBuscadorBaseRequest
    {
        public BEDocumRegTMPDetalleBuscaRequest()
        {
            keyTokenUser = string.Empty;
            LstcodDocumReg = new List<EntidadId>();
        }

        public string keyTokenUser { get; set; }

        public string codPersonaEntidad { get; set; }

        public int? codDocumReg { get; set; }


        public List<EntidadId> LstcodDocumReg { get; set; }

        public string keyDocumRegDetalle { get; set; }
    }
}

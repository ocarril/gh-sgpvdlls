namespace CROM.BusinessEntities.SUNAT.request
{
    using System.Collections.Generic;

    public class BEBUpdateResumenDiarioRequest : BEBuscadorBase
    {
        public BEBUpdateResumenDiarioRequest()
        {

            LstCodDocumReg = new List<BEDocumRegUpdate>();

        }

        public long codResumenDiario { get; set; }

        public List<BEDocumRegUpdate> LstCodDocumReg { get; set; }

    }



    public class BEDocumRegUpdate
    {
        public BEDocumRegUpdate()
        {

        }

        public int codDocumReg { get; set; }

    }


    public class BEDocumRegUpdateResponse
    {
        public BEDocumRegUpdateResponse()
        {

        }

        public int codDocumReg { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
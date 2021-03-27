namespace CROM.BusinessEntities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class DTOResponseProcedure
    {
        public DTOResponseProcedure()
        {
            ErrorCode = -1;
            ErrorCodeStr = string.Empty;
            ErrorMessage = string.Empty;
        }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public string ErrorCodeStr { get; set; }
    }

}

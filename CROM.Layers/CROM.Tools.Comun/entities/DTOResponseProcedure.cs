namespace CROM.Tools.Comun.entities
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
            ErrorMessage = string.Empty;
        }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

    }

    public class DTOResponseProcedureStr
    {
        public DTOResponseProcedureStr()
        {
            ErrorCode = string.Empty;
            ErrorMessage = string.Empty;
        }

        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }

    public class DTOResponseProcedureGuid
    {
        public DTOResponseProcedureGuid()
        {
            ErrorMessage = string.Empty;
        }

        public Guid? ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }

}

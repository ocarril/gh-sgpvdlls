namespace CROM.BusinessEntities.SUNAT.response
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class BEDocumentoSUNATLeyendaResponse
    {
        public BEDocumentoSUNATLeyendaResponse()
        {
            desLeyendaSunat = string.Empty;
            codLeyendaSunat = string.Empty;
        }

        public long codDocumRegSunat { get; set; }

        public int codDocumReg { get; set; }

        public string desLeyendaSunat { get; set; }

        public string codLeyendaSunat { get; set; }

    }
}

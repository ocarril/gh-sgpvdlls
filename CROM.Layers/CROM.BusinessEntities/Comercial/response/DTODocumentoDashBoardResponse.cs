namespace CROM.BusinessEntities.Comercial.response
{
    using System.Collections.Generic;

    public class DTODocumentoDashBoardResponse 
    {
        public DTODocumentoDashBoardResponse()
        {
            codDocumento = string.Empty;
            nomDocumento = string.Empty;
            sumPrecioVentaME = 0;
            sumPrecioVentaMN = 0;
            cntEmitido = 0;
            tipDocumento = string.Empty;
            ListDocumentoDashBoardEstado = new List<DTODocumentoDashBoardEstado>();
        }

        public string codDocumento { get; set; }

        public string nomDocumento { get; set; }

        public int? cntEmitido { get; set; }

        public decimal? sumPrecioVentaMN { get; set; }

        public decimal? sumPrecioVentaME { get; set; }

        public bool flagFiscal { get; set; }

        public bool flagCtaCte { get; set; }

        public string tipDocumento { get; set; }

        public List<DTODocumentoDashBoardEstado> ListDocumentoDashBoardEstado { get; set; }
    }

    public class DTODocumentoDashBoardEstado 
    {
        public DTODocumentoDashBoardEstado()
        {
            codDocumento = string.Empty;
            nomDocumento = string.Empty;
            sumPrecioVentaME = 0;
            sumPrecioVentaMN = 0;
            cntEmitido = 0;
        }

        public string codDocumento { get; set; }

        public string nomDocumento { get; set; }

        public int? cntEmitido { get; set; }

        public decimal? sumPrecioVentaMN { get; set; }

        public decimal? sumPrecioVentaME { get; set; }

        public string codEstado { get; set; }

        public string nomEstado { get; set; }


    }
}

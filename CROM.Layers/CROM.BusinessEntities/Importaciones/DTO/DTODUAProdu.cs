namespace CROM.BusinessEntities.Importaciones.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class DTODUAProdu
    {
        public int codDocumReg { get; set; }
        public string numDocumento { get; set; }
        public string numDocumentoRef { get; set; }
        public string codigoProducto { get; set; }
        public string desProducto { get; set; }
        public int codProducto { get; set; }
        public decimal cntCantidadOri { get; set; }
        public decimal cntCantidadRec { get; set; }

    }
}

namespace CROM.BusinessEntities.Importaciones.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class DTODocumentoImp
    {
        public int codDocumReg { get; set; }
        public string numDocumento { get; set; }
        public string numDocumentoRef { get; set; }
        public string numDocumentoSec { get; set; }
        public string nomProveedor { get; set; }
        public int indAsignado { get; set; }
    }
}

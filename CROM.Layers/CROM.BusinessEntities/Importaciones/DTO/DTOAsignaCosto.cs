namespace CROM.BusinessEntities.Importaciones.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class DTOAsignaCosto
    {

        public int codDocumRegDetalle { get; set; }
        public string numeroDocumento { get; set; }
        public string fechaEmision { get; set; }
        public string nombreEmpresa { get; set; }
        public string item { get; set; }
        public string descriDetalle { get; set; }
        public decimal valorTC { get; set; }
        public decimal cantidad { get; set; }
        public decimal montoNacional { get; set; }
        public decimal montoInternacional { get; set; }
        public string CostoReferenciado { get; set; }

        public long TOTALROWS { get; set; }
        public long ROWNUM { get; set; }

    }
}

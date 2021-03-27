namespace CROM.BusinessEntities.Proyectos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class DTODocumReg
    {
        public long ROW { get; set; }
        public int TOTALROWS { get; set; }

        public int codDocumReg { get; set; }
        public string desMonDocumento { get; set; }

        public int codProyecto { get; set; }
        public int codPyDocumReg { get; set; }
        public string gloNota { get; set; }

        public string numDocumento { get; set; }
        public string desMoneda { get; set; }
        public decimal monTotal { get; set; }
        public decimal monTCVenta { get; set; }
        public string fecEmision { get; set; }
        public string codDocumEstado { get; set; }
        public bool indActivo { get; set; }
        public string segUsuarioCrea { get; set; }
        public string segUsuarioEdita { get; set; }
        public string segFechaCrea { get; set; }
        public string segFechaEdita { get; set; }
        public string segMaquina { get; set; }

        public int codDocumRegDetalle { get; set; }
        public decimal cntCantidad { get; set; }
        public decimal monPrecioVenta { get; set; }
        public string desProducto { get; set; }
        public bool indSeriado { get; set; }
    }
}

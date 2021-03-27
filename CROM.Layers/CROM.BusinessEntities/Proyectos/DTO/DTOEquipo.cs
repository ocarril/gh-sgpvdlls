namespace CROM.BusinessEntities.Proyectos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class DTOEquipo
    {
        public long ROW { get; set; }
        public int TOTALROWS { get; set; }

        public int codPyEquipo { get; set; }
        public int codPyDocumReg { get; set; }
        public int? codDocumRegDetalle { get; set; }
        public Nullable<DateTime> fecCompra { get; set; }
        public Nullable<DateTime> fecInstalacion { get; set; }
        public Nullable<DateTime> fecVencGarantia { get; set; }
        public int codDocumEstado { get; set; }
        public string gloNota { get; set; }

        public string desProducto { get; set; }
        public string desEstado { get; set; }
        public decimal cntCantidad { get; set; }
        public decimal monPrecioVenta { get; set; }
        public bool indSeriado { get; set; }

        public bool indActivo { get; set; }
        public string segUsuarioCrea { get; set; }
        public string segUsuarioEdita { get; set; }
        public DateTime segFechaCrea { get; set; }
        public Nullable<DateTime> segFechaEdita { get; set; }
        public string segMaquina { get; set; }

    }
}

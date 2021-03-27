namespace CROM.BusinessEntities.Proyectos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class DTOMantenimiento
    {
        public long ROW { get; set; }
        public int TOTALROWS { get; set; }

        public int codPyMantenimiento { get; set; }
        public int codProyecto { get; set; }
        public Nullable<DateTime> fecProgramada { get; set; }
        public Nullable<DateTime> fecRealizada { get; set; }
        public int codDocumEstado { get; set; }
        public string gloObservacion { get; set; }
        public int? codPyEquipo { get; set; }
        public int? codEmpleadoResp { get; set; }

        public string desProyecto { get; set; }
        public string desProducto { get; set; }
        public string desEstado { get; set; }
        public string desCliente { get; set; }
        public string fecCompra { get; set; }
        public string fecVencGarantia { get; set; }
        public bool indSeriado { get; set; }

        public bool indActivo { get; set; }
        public string segUsuarioCrea { get; set; }
        public string segUsuarioEdita { get; set; }
        public DateTime segFechaCrea { get; set; }
        public Nullable<DateTime> segFechaEdita { get; set; }
        public string segMaquina { get; set; }

    }
}

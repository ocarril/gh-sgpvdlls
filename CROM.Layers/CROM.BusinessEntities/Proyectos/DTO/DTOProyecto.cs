namespace CROM.BusinessEntities.Proyectos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DTOProyecto
    {
        public int ROW { get; set; }
        public int TOTALROWS { get; set; }

        public int codProyecto { get; set; }
        public string codPerCliente { get; set; }
        public int codRegEstado { get; set; }
        public string desNombre { get; set; }
        public DateTime fecInicio { get; set; }
        public Nullable<DateTime> fecFinal { get; set; }
        public bool indActivo { get; set; }

        public string desNombreCliente { get; set; }
        public string desEstado { get; set; }

        public string segUsuarioCrea { get; set; }
        public string segUsuarioEdita { get; set; }
        public DateTime segFechaCrea { get; set; }
        public Nullable<DateTime> segFechaEdita { get; set; }
        public string segMaquina { get; set; }

    }
}

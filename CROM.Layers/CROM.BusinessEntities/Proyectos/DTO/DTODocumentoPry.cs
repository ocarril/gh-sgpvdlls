namespace CROM.BusinessEntities.Proyectos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DTODocumentoPry
    {
        public int ROW { get; set; }
        public int TOTALROWS { get; set; }

        public int codPYDocumento { get; set; }
        public int codProyecto { get; set; }
        public string desNombreArchivo { get; set; }
        public string desGlosa { get; set; }
        public bool indActivo { get; set; }

        public string desNombreProyecto { get; set; }
        public string desNombreCliente { get; set; }
        public string desEstado { get; set; }

        public string segUsuarioEdita { get; set; }
        public Nullable<DateTime> segFechaEdita { get; set; }

        public string auxVistaParcial { get; set; }

    }
}

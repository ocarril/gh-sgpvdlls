namespace CROM.BusinessEntities.Importaciones.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class DTODUA
    {
        public int codOIDUA { get; set; }
        public int codOrdenImportacion { get; set; }
        public string numOIDUA { get; set; }
        public string numOrdenImportacion { get; set; }
        public string fecEmision { get; set; }
        public string fecPago { get; set; }
        public decimal? decFactor { get; set; }
        public string codRegCanalNombre { get; set; }
        public string codRegEstadoDUANombre { get; set; }
        public string codRegDocumentoNombre { get; set; }
        public string fecEmitido { get; set; }
        public string codRegIncotermNombre { get; set; }
        public string codRegEstadoOINombre { get; set; }
        public string codRegNacionalizacionNombre { get; set; }
        public string segUsuarioCrea { get; set; }
        public string segUsuarioEdita { get; set; }
        public string segFechaCrea { get; set; }
        public string segFechaEdita { get; set; }

        public long ROW { get; set; }
        public int TOTALROWS { get; set; }
    }
}

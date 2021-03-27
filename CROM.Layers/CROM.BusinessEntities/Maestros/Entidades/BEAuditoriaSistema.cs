namespace CROM.BusinessEntities.Maestros
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class BEAuditoriaSistema
    {

        public int codAuditoriaSistema { get; set; }
        public string CodigoPersonaEmpre { get; set; }
        public string CodigoPuntoVenta { get; set; }
        public string CodigoPersonaRespon { get; set; }
        public string Descripcion { get; set; }
        public string Clase { get; set; }
        public string Metodo { get; set; }
        public string OtroDato { get; set; }
        public bool ProcesoOK { get; set; }
        public string SegUsuarioCrea { get; set; }
        public DateTime SegFechaHoraCrea { get; set; }
        public string SegMaquinaOrigen { get; set; }

    }
}

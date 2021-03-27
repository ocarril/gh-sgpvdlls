namespace CROM.BusinessEntities.Maestros
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Maestros.ReportesSistema.cs]
    /// </summary>
    public class BEReporteSistema: BEBaseMaestro
    {
        public BEReporteSistema()
        {
            ReporteName = string.Empty;
            NombreArchivoRDLC = string.Empty;
            OtroDato = string.Empty;
            CodigoReporte = string.Empty;
            CodigoSistema = string.Empty;
        }

        public string CodigoReporte { get; set; }
        public string ReporteName { get; set; }
        public string CodigoSistema { get; set; }
        public string NombreArchivoRDLC { get; set; }
        public string TipodeReporte { get; set; }
        public Int32 Orden { get; set; }
        public string OtroDato { get; set; }
       
        public long ROW { get; set; }
        public int TOTALROWS { get; set; }
    }
}

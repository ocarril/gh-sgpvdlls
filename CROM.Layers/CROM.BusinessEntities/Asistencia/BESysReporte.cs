namespace CROM.BusinessEntities.Asistencia
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 28/08/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.SysReportes.cs]
    /// </summary>
    public class BESysReporte
    {
        public string CodigoReporte { get; set; }
        public string ReporteName { get; set; }
        public int Orden { get; set; }
        public string OrdenTexto { get; set; }
        public bool Estado { get; set; }


    }
}

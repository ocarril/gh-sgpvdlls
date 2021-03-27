namespace CROM.BusinessEntities.Almacen
{
    using System;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 16/08/2014-12:20:06 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.Periodo.cs]
    /// </summary>
    public class BEPeriodo : BEBase
    {
        public string codPeriodo { get; set; }
        public string desNombre { get; set; }
        public bool indModalidad { get; set; }
        public DateTime fecInicio { get; set; }
        public Nullable<DateTime> fecApertura { get; set; }
        public Nullable<DateTime> fecCierre { get; set; }
        public bool indActivo { get; set; }
    }
}

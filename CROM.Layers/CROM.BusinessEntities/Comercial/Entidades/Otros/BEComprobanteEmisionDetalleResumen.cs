namespace CROM.BusinessEntities.Comercial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 21/11/2011-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Maestros.SysTablas.cs]
    /// </summary>
    public class BEComprobanteEmisionDetalleResumen
    {
        public string Item { get; set; }
        public string CodigoProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal TotalMonedaNacional { get; set; }
        public decimal TotalMonedaExtranjero { get; set; }
    }
}
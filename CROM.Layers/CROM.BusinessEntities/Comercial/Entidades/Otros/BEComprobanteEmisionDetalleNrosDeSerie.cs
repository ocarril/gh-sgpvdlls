namespace CROM.BusinessEntities.Comercial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 08/06/2010-04:30:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.ComprobanteEmisionDetalleNrosDeSerie.cs]
    /// </summary>
    public class BEComprobanteEmisionDetalleNrosDeSerie
    {
        public BEComprobanteEmisionDetalleNrosDeSerie()
        {

        }
        public string CodigoProducto { get; set; }
        public string NrosDeSeriesDelProducto { get; set; }
    }
}

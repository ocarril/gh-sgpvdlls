namespace CROM.BusinessEntities.Comercial.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2013-01:57:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [vwProductoConsignacion.cs]
    /// </summary>
    public class vwProductoConsignacion
    {
        public vwProductoConsignacion()
        {

        }
        public int codItem { get; set; }
        public int codDocumReg { get; set; }
        public string codCliente { get; set; }
        public string nomRazonSocial { get; set; }
        public DateTime fecConsignacion { get; set; }
        public string numGuiaRemision { get; set; }
        public string codProducto { get; set; }
        public string nomDescripcion { get; set; }
        public decimal? cntStockMovimi { get; set; }
        public string numSerie { get; set; }
        public string numLote { get; set; }
        public string segUsuarioCrea { get; set; }
        public string segUsuarioEdita { get; set; }

    }
}

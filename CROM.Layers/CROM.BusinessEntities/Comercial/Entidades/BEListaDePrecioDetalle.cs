namespace CROM.BusinessEntities.Comercial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/03/2011-05:08:50 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.ListaDePrecioDetalle.cs]
    /// </summary>
    public class BEListaDePrecioDetalle : BEBase
    {
        public int codListaDePrecioDetalle { get; set; }

        public int codProducto { get; set; }
        public string CodigoLista { get; set; }
        public string CodigoArguMoneda { get; set; }
        public decimal PrecioUnitario { get; set; }
        public bool Estado { get; set; }

        public string CodigoProductoNombre { get; set; }
        public string CodigoArguMonedaNombre { get; set; }
        public string CodigoPersonaEmpreNombre { get; set; }
        public string CodigoPuntoVentaNombre { get; set; }
        public bool refEsParaVenta { get; set; }
        public string CodigoPersonaEmpre { get; set; }
        public string CodigoPuntoVenta { get; set; }
        public string CodigoProducto { get; set; }

    }
} 

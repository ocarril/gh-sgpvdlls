namespace CROM.BusinessEntities.Almacen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CROM.BusinessEntities.Maestros;
    using CROM.BusinessEntities.Comercial;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/03/2011-05:08:50 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.ProductoPrecio.cs]
    /// </summary>
    public class BEProductoPrecio : BEBaseEntidad
    {
        public BEProductoPrecio()
        {
            CodigoProducto = string.Empty;
            CodigoArguMonedaNombre = string.Empty;
            CodigoPersonaEmpreNombre = string.Empty;
            CodigoProductoNombre = string.Empty;
            CodigoPuntoVentaNombre = string.Empty;

            objMoneda = new BERegistroNew();
            objPuntoDeVenta = new BEPuntoDeVenta();
            objListaDePrecio = new BEListaDePrecio();
        }

        public int codProductoPrecio { get; set; }
        public int codProducto { get; set; }
        public string CodigoPuntoVenta { get; set; }
        public string CodigoArguMoneda { get; set; }
        public string CodigoListaPrecio { get; set; }
        public decimal ValorCosto { get; set; }
        public decimal ValorVenta { get; set; }
        public decimal MargenUtilidad { get; set; }
        public decimal MediaPorcentaje { get; set; }
        public decimal PorcenComision { get; set; }
        public decimal PorcenComisionMax { get; set; }
        public decimal DescuentoMaximo { get; set; }
        public bool Estado { get; set; }
       


        /*Atributos auxiliares */
        public string CodigoProducto { get; set; }
        public string CodigoProductoNombre { get; set; }
        public string CodigoArguMonedaNombre { get; set; }
        public string CodigoPuntoVentaNombre { get; set; }
        public string CodigoPersonaEmpreNombre { get; set; }
        
        public BERegistroNew objMoneda { get; set; }
        public BEPuntoDeVenta objPuntoDeVenta { get; set; }
        public BEListaDePrecio objListaDePrecio { get; set; }
    }
}

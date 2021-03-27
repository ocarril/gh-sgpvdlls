namespace CROM.BusinessEntities.Comercial
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
    public class DTOProductoPrecioResponse: BEBasePagedResponse
    {
        public DTOProductoPrecioResponse()
        {
            codiListaPrecioNombre = string.Empty;
            CodigoProducto = string.Empty;
            codPuntoVentaNombre = string.Empty;
            codRegMonedaNombre = string.Empty;
        }

        public int codProductoPrecio { get; set; }

        public string CodigoProducto { get; set; }
        public string codProductoNombre { get; set; }

        public string codPuntoVentaNombre { get; set; }

        public string codRegMonedaNombre { get; set; }

        public string codiListaPrecioNombre { get; set; }

        public decimal ValorCosto { get; set; }

        public decimal ValorVenta { get; set; }

        public decimal MargenUtilidad { get; set; }

        public decimal MediaPorcentaje { get; set; }

        public decimal PorcenComision { get; set; }

        public decimal PorcenComisionMax { get; set; }

        public decimal DescuentoMaximo { get; set; }
        

    }
}

namespace CROM.BusinessEntities.Comercial.request
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
    public class BEProductoPrecioRequest : BEBaseEntidadRequest
    {
        public BEProductoPrecioRequest()
        {
            codPuntoVenta = string.Empty;
        }

        public int codProductoPrecio { get; set; }

        public int codProducto { get; set; }

        public string codPuntoVenta { get; set; }

        public string codRegMoneda { get; set; }


        public string codiListaPrecio { get; set; }

        public decimal ValorCosto { get; set; }

        public decimal ValorVenta { get; set; }

        public decimal MargenUtilidad { get; set; }

        public decimal MediaPorcentaje { get; set; }

        public decimal PorcenComision { get; set; }

        public decimal PorcenComisionMax { get; set; }

        public decimal DescuentoMaximo { get; set; }

        public bool? indActivo { get; set; }
    }
}

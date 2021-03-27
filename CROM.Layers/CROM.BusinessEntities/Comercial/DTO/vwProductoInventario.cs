namespace CROM.BusinessEntities.Comercial.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    : Modulo de Consultas/Reportes : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 15/04/2015-04:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.vwProductoInventario.cs]
    /// </summary>
    public class vwProductoInventario
    {
        public vwProductoInventario()
        {

        }

        public string codPerEmpresa { get; set; }
        public string codPuntoVenta { get; set; }
        public string codDeposito { get; set; }//
        public string codDepositoNombre { get; set; }//
        public string codProducto { get; set; }
        public string codigoProducto { get; set; }
        public string codProductoNombre { get; set; }
        public string indSeriado { get; set; }

        public decimal cntStockInicial { get; set; }
        public decimal cntStockFisico { get; set; }
        public decimal monValorCosto { get; set; }
        public decimal monTotalCosto { get; set; }
        public decimal cntStockMinimo { get; set; }
        public decimal cntStockComprometido { get; set; }
        public string audFechaActualizacion { get; set; }
        public string audUsuarioActualizacion { get; set; }
        public string numOIDUA { get; set; }
        public string numOI { get; set; }
        public string codRegCategoriaNombre { get; set; }
        public string codGrupoNombre { get; set; }

    }
}

namespace CROM.BusinessEntities.Almacen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.ProductoExistencias.cs]
    /// </summary>
    public class BEProductoExistencia : BEBase
    {
        public BEProductoExistencia()
        {
            listaInventario = new List<InventarioAux>();
        }

        public int codProductoExistencia { get; set; }

        public int codProducto { get; set; }
        public string codDeposito { get; set; }
        public decimal? StockInicial { get; set; }
        public decimal? StockFisico { get; set; }
        public decimal StoskComprometido { get; set; }
        public decimal StockMerma { get; set; }
        public decimal StockSobrante { get; set; }
        public bool Estado { get; set; }

        public List<InventarioAux> listaInventario { get; set; }

        public string auxcodDepositoNombre { get; set; }
        public string codProductoNombre { get; set; }
        public string codigoProducto { get; set; }
        public string codPersonaEmpre { get; set; }

    }


    public class BEProductoExistenciaUpdate : BEBase
    {
        public BEProductoExistenciaUpdate()
        {
            
        }

        public int codProductoExistencia { get; set; }

        public int codProducto { get; set; }
        public int? codDeposito { get; set; }
        public decimal? cntStockInicial { get; set; }
        public decimal? StockFisico { get; set; }
        public decimal StoskComprometido { get; set; }
        public decimal StockMerma { get; set; }
        public decimal StockSobrante { get; set; }
        public bool Estado { get; set; }


    }

    public class BEProductoExistenciaStockUpdate : BEBase
    {
        public BEProductoExistenciaStockUpdate()
        {

        }

        public int codProductoExistencia { get; set; }

        public int codProducto { get; set; }

        public int codDeposito { get; set; }

        public decimal? cntStockInicial { get; set; }

        public decimal? cntStockFisico { get; set; }

        public decimal cntStockComprometido { get; set; }

        public decimal cntStockMerma { get; set; }

        public decimal cntStockSobrante { get; set; }

        public bool Estado { get; set; }

        public int indOperador { get; set; }

        public string numDocumentoReferencia { get; set; }

        public string codPerEntidad { get; set; }
    }

    public class BEProductoExistenciaFind : BEBase
    {
        public BEProductoExistenciaFind()
        {

        }

        public int codProducto { get; set; }

        public int? codDeposito { get; set; }

    }
}

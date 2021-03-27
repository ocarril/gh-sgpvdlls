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
    /// Archivo     : [Produccion.ProductoKardexBE.cs]
    /// </summary>
    public class BEProductoKardex
    {
        public BEProductoKardex()
        {
            cntEntrada = 0;
            cntDevolucion = 0;
            cntSaldo = 0;
            cntSalida = 0;
        }

        public int codProductoKardex { get; set; }
        public int codProducto { get; set; }
        public int codDocumRegDetalle { get; set; }

        public DateTime fecMovimiento { get; set; }
        public string codRegistroTipoMovimi { get; set; }
        public string codPersonaMovimi { get; set; }
        public decimal? cntEntrada { get; set; }
        public decimal? monCostoUnitEntrada { get; set; }
        public decimal? cntSalida { get; set; }
        public decimal? monCostoUnitSalida { get; set; }
        public decimal? cntDevolucion { get; set; }
        public decimal? monCostoUnitDevoluc { get; set; }
        public decimal? cntSaldo { get; set; }
        public decimal? monCostoUnitSaldo { get; set; }
        public string desRazonSocial { get; set; }
        public int perKardexAnio { get; set; }
        public string codDeposito { get; set; }
        public string codRegistroTipoMotivo { get; set; }
        public string perInventario { get; set; }
        public Nullable<DateTime> fecInventarioCierre { get; set; }
        public int? codEmpleado { get; set; }
        public bool indActivo { get; set; }

        public string segUsuarioCrea { get; set; }
        public string segUsuarioEdita { get; set; }
        public DateTime segFechaCrea { get; set; }
        public Nullable<DateTime> segFechaEdita { get; set; }
        public string segMaquina { get; set; }
    }

    public class ProductoKardexAux : BEProductoKardex
    {
        public int codEmpresa { get; set; }
        public string codDocumento { get; set; }
        public string numDocumento { get; set; }
        public string codItemDetalle { get; set; }
        public decimal? cntRegistrado { get; set; }
        public decimal? monRegistrado { get; set; }
        public string codPersonaEmpre { get; set; }
        public string codPuntoDeVenta { get; set; }
        public string codProductoNombre { get; set; }
        public string codProductoRefer { get; set; }
        public string codPersonaEmpreNombre { get; set; }
        public string codPuntoDeVentaNombre { get; set; }
        public string codRegistroTipoMovimiNombre { get; set; }
        public string codRegistroTipoMotivoNombre { get; set; }
        public string codPersonaMovimiNombre { get; set; }
        public string codDocumentoNombre { get; set; }
        public string codRegistroDepositoNombre { get; set; }
        public string codEmpleadoNombre { get; set; }

        public decimal? cntStockFisico { get; set; }
        public decimal? cntStockComprometido { get; set; }
        public string codRegistroCategProducto { get; set; }
        public string codRegistroCategProductoNombre { get; set; }
        public string codRegistroUnidadMedida { get; set; }
        public string codRegistroUnidadMedidaNombre { get; set; }
        public decimal? monTotalEntrada { get; set; }
        public decimal? monTotalSalida { get; set; }
        public decimal? monTotalDevolucion { get; set; }
        public decimal? monTotalSaldo { get; set; }
        public int indMovimiento { get; set; }
        public int codDocumReg { get; set; }
        public string codigoProducto { get; set; }

        public decimal? cntStockInicial { get; set; }
        public decimal? cntStockConsignacion { get; set; }
    }
}

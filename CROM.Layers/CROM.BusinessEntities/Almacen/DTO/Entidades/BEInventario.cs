namespace CROM.BusinessEntities.Almacen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CROM.BusinessEntities.RecursosHumanos;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 07/01/2011-01:57:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.Inventario.cs]
    /// </summary>
    public class BEInventario : BEBase
    {
        public int codInventario { get; set; }
        public int codProducto { get; set; }

        public int codDeposito { get; set; }
        public string Periodo { get; set; }

        public decimal Conteo01 { get; set; }
        public int? Conteo01Empleado { get; set; }
        public Nullable<DateTime> Conteo01FechaHora { get; set; }

        public decimal Conteo02 { get; set; }
        public int? Conteo02Empleado { get; set; }
        public Nullable<DateTime> Conteo02FechaHora { get; set; }

        public decimal Conteo03 { get; set; }
        public int? Conteo03Empleado { get; set; }
        public Nullable<DateTime> Conteo03FechaHora { get; set; }

        public decimal Conteo04 { get; set; }
        public int? Conteo04Empleado { get; set; }
        public Nullable<DateTime> Conteo04FechaHora { get; set; }

        public int CierreConteo { get; set; }
        public Nullable<DateTime> CierreFechaHora { get; set; }
        public int? CierreEmpleado { get; set; }
        public bool Estado { get; set; }

        public decimal SALDO_StockMerma { get; set; }
        public decimal SALDO_StockSobrante { get; set; }
        public decimal cntOrigStockFisico { get; set; }
        public decimal cntOrigStockMerma { get; set; }
        public decimal cntOrigStockSobrante { get; set; }

        public int cntTransacciones { get; set; }
        public string desAgrupacion { get; set; }

        ////[NotMapped]
        public int cntConteoSeriado { get; set; }
        ////[NotMapped]
        public int numConteoCerrado { get; set; }

        public BEProducto objProducto { get; set; }
        public BEDeposito objDeposito { get; set; }
        public BEPeriodo objPeriodo { get; set; }
        public BEEmpleado objEmpConteo01 { get; set; }
        public BEEmpleado objEmpConteo02 { get; set; }
        public BEEmpleado objEmpConteo03 { get; set; }
        public BEEmpleado objEmpConteo04 { get; set; }
        public BEEmpleado objEmpCierre { get; set; }
        public List<BEInventarioSerie> lstInventarioSerie { get; set; }

        public BEInventario()
        {
            objProducto = new BEProducto();
            objDeposito = new BEDeposito();
            objPeriodo = new BEPeriodo();
            objEmpConteo01 = new BEEmpleado();
            objEmpConteo02 = new BEEmpleado();
            objEmpConteo03 = new BEEmpleado();
            objEmpConteo04 = new BEEmpleado();
            objEmpCierre = new BEEmpleado();
            lstInventarioSerie = new List<BEInventarioSerie>();
        }
    }

    public class InventarioAux : BEInventario
    {

        public string CodigoPersonaEmpre { get; set; }
        public string CodigoPuntoVenta { get; set; }
        public string CodigoProducto { get; set; }
        public string codDepositoNombre { get; set; }
        public int? NumeroDeConteo { get; set; }
        public decimal Conteo { get; set; }
        public int ConteoEmpleado { get; set; }
        public string Conteo01EmpleadoNombre { get; set; }
        public string Conteo02EmpleadoNombre { get; set; }
        public string Conteo03EmpleadoNombre { get; set; }
        public string Conteo04EmpleadoNombre { get; set; }
        public string CierreEmpleadoNombre { get; set; }
        public string CodigoProductoNombre { get; set; }
        public string PeriodoAux { get; set; }

        public decimal StockMinimo { get; set; }
        public decimal StockMaximo { get; set; }
        public decimal StockInicial { get; set; }
        public decimal StockFisico { get; set; }
        public decimal StockComprometido { get; set; }
        public bool EsConNumeroSeriado { get; set; }

        public decimal? ConteoSel { get; set; }
        public decimal? ConteoSeriadoChek { get; set; }
        public Nullable<DateTime> FechaHoraSel { get; set; }
        public int? EmpleadoSel { get; set; }
        public string EmpleadoNombreSel { get; set; }

        public decimal? ValorCosto { get; set; }
        public decimal? ValorVenta { get; set; }
        public string codRegMoneda { get; set; }
        public string codRegMonedaNombre { get; set; }
        public string codRegMonedaSimbolo { get; set; }
        public string codRegUnidadMedida { get; set; }
        public string codRegTipoProducto { get; set; }
    }

}

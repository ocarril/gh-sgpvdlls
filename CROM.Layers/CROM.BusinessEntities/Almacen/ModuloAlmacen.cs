namespace CROM.BusinessEntities.Almacen
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 28/05/2014-06:32:44 
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [BaseFiltroImp.cs]
    /// </summary>
    public class BaseFiltroAlmacen
    {
        public int jqPageSize { get; set; }
        public int jqCurrentPage { get; set; }
        public string jqSortColumn { get; set; }
        public string jqSortOrder { get; set; }

        public int? codId { get; set; }
        public int codEmpresa { get; set; }
        public string codEmpresaRUC { get; set; }
        public string codPuntoVenta { get; set; }
        public string codDeposito { get; set; }
        public string codigoProducto { get; set; }
        public string codPeriodo { get; set; }
        public string desAgrupacion { get; set; }
        public string desNombre { get; set; }
        public string codRegLineaProd { get; set; }
        public string codRegMaterialProd { get; set; }
        public string codRegUnidadMedida { get; set; }
        public string codProductoRefer { get; set; }
        public string codRegMarca { get; set; }
        public string codRegMoneda { get; set; }
        public string desComercial { get; set; }
        public string codRegCentroProducc { get; set; }
        public string desPalabraClave { get; set; }
        public string codRegTipo { get; set; }
        public string codRegCategoria { get; set; }
        public string numSerieProducto { get; set; }
        public string codListaPrecio { get; set; }
        public string perPeriodo { get; set; }
        public string segUsuarioEdita { get; set; }
        public string numDocumentoReferencia { get; set; }
        public string codPerEntidad { get; set; }
        public string fecInicio { get; set; }
        public string fecFinal { get; set; }
        public string codDocumento { get; set; }
        public string numDocumento { get; set; }
        public string numDocumentoCompromiso { get; set; }
        public string numDocumentoVenta { get; set; }
        public string numDocumentoCompra { get; set; }
        public string codRegTipoMotivo { get; set; }
        public string codRegTipoMovimiUno { get; set; }
        public string codRegTipoMovimiDos { get; set; }
        public string codPerProveedor { get; set; }
        public string codItem { get; set; }
        public string codRegEstadoMercaderia { get; set; }

        public int codInventario { get; set; }
        public int? codGrupo { get; set; }
        public int? codProducto { get; set; }
        public int? cntConteo { get; set; }
        public int codDocumReg { get; set; }
        public int codProductoSeriado { get; set; }
        public decimal cntStockInicial { get; set; }
        public decimal cntStockFisico { get; set; }
        public decimal? cntStockComprometido { get; set; }
        public decimal cntStockMerma { get; set; }
        public decimal cntStockSobrante { get; set; }
        public int? indOperador { get; set; }
        public int? codEmpleadoInventario { get; set; }
        public int? codDocumRegDetalle { get; set; }

        public bool? indEstado { get; set; }
        public bool indTodos { get; set; }
        public bool? indComprometido { get; set; }
        public bool? indDestinaVenta { get; set; }
        public bool? indDestinoCompra { get; set; }
        public bool? indVentaCompra { get; set; }
        public bool? indVendido { get; set; }
        public bool indArticuloExistencia { get; set; }

        public Nullable<DateTime> fecCierreInventario { get; set; }
        public Nullable<DateTime> fecInicioDate { get; set; }
        public Nullable<DateTime> fecFinalDate { get; set; }
    }


    public class BaseFiltroProducto: BEBuscadorBaseRequest
    {

        public BaseFiltroProducto()
        {
            codPuntoVenta = string.Empty;
            codDeposito = string.Empty;
            codigoProducto = string.Empty;
            desNombre = string.Empty;
            codRegUnidadMedida = string.Empty;
            codProductoRefer = string.Empty;
            codRegTipo  =  string.Empty;
            codRegCategoria = string.Empty;
            desComercial = string.Empty;
            desPalabraClave = string.Empty;
            numSerieProducto = string.Empty;
            codPerProveedor = string.Empty;
        }

        public string codPuntoVenta { get; set; }
        public string codDeposito { get; set; }
        public string codigoProducto { get; set; }
        public string desNombre { get; set; }
        public string codRegUnidadMedida { get; set; }
        public string codProductoRefer { get; set; }
        public int? codMarca { get; set; }

        public int? codModelo { get; set; }

        public string codRegTipo { get; set; }
        public string codRegCategoria { get; set; }
        public int? codGrupo { get; set; }


        public string codRegCentroProducc { get; set; }
        public string desComercial { get; set; }
        public string desPalabraClave { get; set; }
        public string numSerieProducto { get; set; }
        public string codPerProveedor { get; set; }
        public string perPeriodo { get; set; }

        public bool? indEstado { get; set; }
        public bool? indDestinaVenta { get; set; }
        public bool? indDestinoCompra { get; set; }
        public bool? indVentaCompra { get; set; }

        public bool? indTodos { get; set; }

        public bool? indSoloVerificaStock { get; set; }

        [JsonIgnore]
        public int codProducto { get; set; }
    }

    public class BaseFiltroAlmacenCerrarInventario
    {
        public BaseFiltroAlmacenCerrarInventario()
        {
            indEstado = true;
        }

        public int codEmpresa { get; set; }

        public string codEmpresaRUC { get; set; }

        public string codPuntoVenta { get; set; }

        public int? codEmpleado { get; set; }

        public string codAlmacen { get; set; }

        public string codPlanilla { get; set; }

        public string perPeriodo { get; set; }

        public string UserActual { get; set; }

        public bool? indEstado { get; set; }
    }

    public class BaseFiltroAlmacenMermaSobrante
    {
        public BaseFiltroAlmacenMermaSobrante()
        {
            desAgrupacion = string.Empty;
            codDeposito = string.Empty;
            codProductoRefer = string.Empty;
            perPeriodo = string.Empty;
        }

        public string codEmpresaRUC { get; set; }
        public string perPeriodo { get; set; }
        public string codDeposito { get; set; }

        public bool? indEstado { get; set; }

        public string desAgrupacion { get; set; }

        public string codProductoRefer { get; set; }
    }

    public class BaseFiltroDeposito : BEBuscadorBaseRequest
    {

        public BaseFiltroDeposito()
        {
            codPuntoVenta = string.Empty;
            codDeposito = string.Empty;
            codigoProducto = string.Empty;
            desNombre = string.Empty;
            
        }

        public string codPuntoVenta { get; set; }
        public string codDeposito { get; set; }
        public string codigoProducto { get; set; }
        public string desNombre { get; set; }
        public bool? indEstado { get; set; }
    }

    public class BaseFiltroGrupo : BEBuscadorBaseRequest
    {

        public BaseFiltroGrupo()
        {
            codRegMaterialProd = string.Empty;
            codRegLineaProd = string.Empty;
            codRegUnidadMedida = string.Empty;
            desNombre = string.Empty;
        }

        public int? codGrupo { get; set; }

        public string desNombre { get; set; }

        public string codRegLineaProd { get; set; }

        public string codRegMaterialProd { get; set; }

        public string codRegUnidadMedida { get; set; }

        public bool? indEstado { get; set; }
    }

    public class BaseFiltroPeriodo : BEBuscadorBaseRequest
    {

        public BaseFiltroPeriodo()
        {
            perPeriodo = string.Empty;
        }

        public string perPeriodo { get; set; }

        public string desNombre { get; set; }

        public bool? indEstado { get; set; }
    }

    public class BaseFiltroMarca : BEBuscadorBaseRequest
    {

        public BaseFiltroMarca()
        {
            codPersona = string.Empty;
            codMarcaKEY = string.Empty;
            codRegPais = string.Empty;
            desNombre = string.Empty;
        }

        public string codPersona { get; set; }

        public string codMarcaKEY { get; set; }

        public string codRegPais { get; set; }

        public string desNombre { get; set; }

        public bool? indActivo { get; set; }
    }

    public class BaseFiltroModelo : BEBuscadorBaseRequest
    {

        public BaseFiltroModelo()
        {
            codModeloKEY = string.Empty;
            desNombre = string.Empty;
        }

        public int? codMarca { get; set; }

        public string codModeloKEY { get; set; }
        
        public string desNombre { get; set; }

        public bool? indActivo { get; set; }
    }


    public class BaseFiltroProductoProveedor : BEBuscadorBaseRequest
    {

        public BaseFiltroProductoProveedor()
        {
            codPersonaProveedor = string.Empty;
        }

        public int? codProductoProveedor { get; set; }

        public string codPersonaProveedor { get; set; }

        public int? codProducto { get; set; }

        public bool? indActivo { get; set; }
    }

}

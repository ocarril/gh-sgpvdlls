namespace CROM.BusinessEntities.Temporales.request
{
    using Newtonsoft.Json;
    using System;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 14/05/2020-22:20:45
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Temporales.DocumRegDetalle.cs]
    /// </summary>
    public class BEDocumRegTMPDetalle : BEBasePagedResponse
    {
        public BEDocumRegTMPDetalle()
        {

        }

        [JsonIgnore]
        public int codEmpresa { get; set; }
        public Guid? keyDocumRegDetalle { get; set; }
        public string codPersonaEntidad { get; set; }
        public string keyTokenUser { get; set; }

        public int? codDocumReg { get; set; }

        public int codProducto { get; set; }
        public string codigoProducto { get; set; }
        public string numItem { get; set; }
        public string codRegUnidadMed { get; set; }
        public Int16 cntDecimales { get; set; }
        public bool indIncluyeIGV { get; set; }
        public decimal CantidadPendente { get; set; }
        public decimal Cantidad { get; set; }
        public decimal UnitDescuento { get; set; }
        public decimal UnitValorCosto { get; set; }
        public decimal UnitPrecioBruto { get; set; }
        public decimal UnitPrecioSinIGV { get; set; }
        public decimal UnitValorDscto { get; set; }
        public decimal UnitValorVenta { get; set; }
        public decimal UnitValorIGV { get; set; }
        public decimal TotItemValorBruto { get; set; }
        public decimal TotItemValorDscto { get; set; }
        public decimal TotItemValorVenta { get; set; }
        public decimal TotItemValorIGV { get; set; }
        public string gloDescripcion { get; set; }
        public string codRegTipoProducto { get; set; }
        public bool indVerificarStock { get; set; }
        public string codCuenta { get; set; }
        public string codDeposito { get; set; }
        public string codRegGarantiaProd { get; set; }
        public string codPartida { get; set; }
        public string codCentroCosto { get; set; }
        public string codListaPrecio { get; set; }
        public int codEmpleadoVendedor { get; set; }
        public bool indEscanner { get; set; }
        public decimal cntPesoTotal { get; set; }
        public int? codTipoTributoISC { get; set; }
        public decimal mtoIscItem { get; set; }
        public decimal mtoBaseIscItem { get; set; }
        public int? codTipoCalculoISC { get; set; }
        public decimal porIscItem { get; set; }
        public int? codTipoTributoOtro { get; set; }
        public decimal mtoTriOtroItem { get; set; }
        public decimal mtoBaseTriOtroItem { get; set; }
        public decimal porTriOtroItem { get; set; }
        public decimal mtoValorReferencialUnitario { get; set; }
        public bool indEstado { get; set; }
        public string segUsuarioCrea { get; set; }
        public DateTime segFechaCrea { get; set; }
        public string segMaquina { get; set; }

        public string codRegMoneda { get; set; }

        public decimal monTipoCambioVTA { get; set; }

        public decimal monTipoCambioCMP { get; set; }



        public string codRegMonedaSelect { get; set; }

        public string codRegDestinoDocum { get; set; }

        public bool indEsGravado { get; set; }

        public decimal prcImpuestoIGV { get; set; }

        public string gloObs { get; set; }


        public bool indOperacionGratuita { get; set; }

        public int codTipoAfectacionIGV { get; set; }
    }
} 

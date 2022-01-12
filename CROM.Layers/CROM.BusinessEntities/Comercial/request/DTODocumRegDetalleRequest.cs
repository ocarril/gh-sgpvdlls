namespace CROM.BusinessEntities.Comercial.request
{
    using System;


    public class DTODocumRegDetalleRequest: BEBaseEntidadRequest
    {

        public DTODocumRegDetalleRequest()
        {
            codUnidadMedida = string.Empty;
            codProductoSUNAT = string.Empty;
            codRegTipoProducto = string.Empty;
            codRegTipoProductoNombre = string.Empty;
            codPuntoVenta = string.Empty;
            codRegUnidadMedNombre = string.Empty;
            codRegUnidadMed = string.Empty;
            desItem = string.Empty;
            codTipTributoIgvItem = string.Empty;
            codTipTributoOtroItem = string.Empty;
            codTipTributoOtroItem = string.Empty;
            codTriIGV = string.Empty;
            codTriISC = string.Empty;
            codTriOtroItem = string.Empty;
            nomTributoIgvItem = string.Empty;
            nomTributoOtroItem = string.Empty;
            nomTributoIscItem = string.Empty;
            tipAfeIGV = string.Empty;
            tipSisISC = string.Empty;
            codRegMonedaNombre = string.Empty;

            mtoValorReferencialUnitario = 0;
        }

        public int codEmpresa { get; set; }

        public int codDocumRegDetalle { get; set; }


        public string codPersonaEntidad { get; set; }

        public int codDocumReg { get; set; }

        public string codPuntoVenta { get; set; }

        public string codDocumento { get; set; }

        public string numDocumento { get; set; }

        public string numItem { get; set; }

        public DateTime fecEmision { get; set; }

        public int codProducto { get; set; }

        public string codigoProducto { get; set; }

        public string codProductoSUNAT { get; set; }

        public string codUnidadMedida { get; set; }

        public string codRegUnidadMed { get; set; }

        public string codRegUnidadMedNombre { get; set; }

        public string codRegUnidadMedPresen { get; set; }

        public Int16 cntDecimales { get; set; }

        public string desItem { get; set; }

        public string codRegTipoProducto { get; set; }

        public string codRegTipoProductoNombre { get; set; }

        public string codRegDestinoDocum { get; set; }

        public string codRegDestinoDocumNombre { get; set; }

        public bool indIncluyeIGV { get; set; }

        public decimal ctdUnidadItemPend { get; set; }

        public decimal ctdUnidadItem { get; set; }

        public decimal mtoUnitPrecioBruto { get; set; }
        public decimal mtoUnitDescuento { get; set; }
        public decimal mtoUnitValorCosto { get; set; }
        public decimal mtoUnitValorDscto { get; set; }
        public decimal mtoUnitValorVenta { get; set; }
        public decimal mtoUnitPrecioSinIGV { get; set; }
        public decimal mtoValorUnitario { get; set; }
        public decimal mtoUnitValorIGV { get; set; }

        public decimal mtoValorBrutoItem { get; set; }
        public decimal mtoValorDsctoItem { get; set; }
        public decimal mtoBaseIgvItem { get; set; }
        public decimal mtoIgvItem { get; set; }
        public decimal sumTotTributosItem { get; set; }
        public decimal mtoPrecioVentaUnitario { get; set; }
        public decimal mtoValorVentaItem { get; set; }


        /// <summary>
        /// Total item por operaciones GRATUITAS
        /// </summary>
        public decimal mtoValorReferenciaItem { get; set; }


        public string codTriIGV { get; set; }
        public string nomTributoIgvItem { get; set; }
        public string codTipTributoIgvItem { get; set; }
        public string tipAfeIGV { get; set; }
        public decimal porIgvItem { get; set; }


        public int? codTipoTributoISC { get; set; }
        public decimal mtoIscItem { get; set; }
        public decimal mtoBaseIscItem { get; set; }
        public string nomTributoIscItem { get; set; }
        public string codTriISC { get; set; }
        public int? codTipoCalculoISC { get; set; }
        public string tipSisISC { get; set; }
        public decimal porIscItem { get; set; }


        public int? codTipoTributoOtro { get; set; }
        public string codTriOtroItem { get; set; }
        public decimal mtoTriOtroItem { get; set; }
        public decimal mtoBaseTriOtroItem { get; set; }
        public string nomTributoOtroItem { get; set; }

        public string codTipTributoOtroItem { get; set; }

        public decimal porTriOtroItem { get; set; }

        public decimal mtoValorReferencialUnitario { get; set; }

        public bool indVerificarStock { get; set; }

        public string codCuenta { get; set; }

        public string codDeposito { get; set; }
        public string codDepositoNombre { get; set; }
        public string codRegEstadoDocu { get; set; }
        public string codRegEstadoDocuNombre { get; set; }
        public string codRegGarantiaProd { get; set; }
        public string codRegGarantiaProdNombre { get; set; }
        public string codPartida { get; set; }
        public string codCentroCosto { get; set; }
        public string codListaPrecio { get; set; }
        public int? codEmpleadoVendedor { get; set; }
        public string codEmpleadoVendedorNombre { get; set; }
        public bool indEscanner { get; set; }
        public decimal cntPesoTotal { get; set; }

        public bool indEstado { get; set; }


        public string codRegMoneda { get; set; }

        public string codRegMonedaNombre { get; set; }

        public string codRegMonedaSimbolo { get; set; }

        public decimal monTipoCambioVTA { get; set; }

        public decimal monTipoCambioCMP { get; set; }


        public bool indEditaDescripcion { get; set; }
        public bool indDestinadoACompra { get; set; }
        public bool indDestinadoAVenta { get; set; }
        public bool indVerificacionStock { get; set; }
        public bool indConNumeroSeriado { get; set; }
        public bool indEsPerecible { get; set; }
        public bool indEsGarantizado { get; set; }
        public bool indEditaValorVenta { get; set; }
        public bool indEditaValorCosto { get; set; }
        public bool indEsListaPrecio { get; set; }
        public bool indEsComboDeOferta { get; set; }

        public string gloObs { get; set; }

        public bool indGravadoIGV { get; set; }


        public bool indOperacionGratuita { get; set; }
        public int codTipoAfectacionIGV { get; set; }

    }
}

namespace CROM.BusinessEntities.Comercial.response
{

    using System;


    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 19/04/2021-20:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.ComprobanteEmisionDetalle.cs]
    /// </summary>
    public class DTODocumRegDetallePrintResponse
    {
        public DTODocumRegDetallePrintResponse()
        {
            gloObservacion = string.Empty;
            codDepositoNombre = string.Empty;
            codEmpleadoVendedorNombre = string.Empty;
            codListaPrecioNombre = string.Empty;
            codRegDestinoDocumentoNombre = string.Empty;
            codRegEstadoDocumentoNombre = string.Empty;
            codRegGarantiaProdNombre = string.Empty;
            codRegTipoProductoNombre = string.Empty;
            codRegUnidadMedNombre = string.Empty;
            gloObservacion = string.Empty;
            gloDescripcion = string.Empty;
            numDocumento = string.Empty;
            codPartida = string.Empty;
            codPuntoDeVenta = string.Empty;
            codProductoSUNAT = string.Empty;
            codigoProducto = string.Empty;
            codItemDetalle = string.Empty;
        }

        public int codDocumRegDetalle { get; set; }

        public int codDocumReg { get; set; }
        public int codEmpresa { get; set; }
        public string codRegDestinoDocumento { get; set; }
        public string codPuntoDeVenta { get; set; }
        public string codDocumento { get; set; }
        public string numDocumento { get; set; }
        public Nullable<DateTime> fecDeEmision { get; set; }

        public string codItemDetalle { get; set; }
        public string codDeposito { get; set; }
        public int codProducto { get; set; }
        public string codigoProducto { get; set; }
        public string codProductoSUNAT { get; set; }
        public string codRegTipoProducto { get; set; }
        public string codRegGarantiaProd { get; set; }


        public string codRegUnidadMed { get; set; }
        public Int16 cntDecimales { get; set; }
        public bool indIncluyeIGV { get; set; }

        public decimal cntStockPendiente { get; set; }
        public decimal cntCantidadItem { get; set; }

        public decimal mtoUnitDescuento { get; set; }
        public decimal mtoUnitValorCosto { get; set; }
        public decimal mtoUnitPrecioBruto { get; set; }
        public decimal mtoUnitPrecioSinIGV { get; set; }
        public decimal mtoUnitValorDscto { get; set; }
        public decimal mtoUnitValorVenta { get; set; }
        public decimal mtoUnitValorIGV { get; set; }
        public decimal mtoTotItemValorBruto { get; set; }
        public decimal mtoTotItemValorDscto { get; set; }
        public decimal mtoTotItemValorVenta { get; set; }
        public decimal mtoTotItemValorIGV { get; set; }


        public int? codTipoTributoISC { get; set; }
        public decimal? mtoIscItem { get; set; }
        public decimal? mtoBaseIscItem { get; set; }
        public int? codTipoCalculoISC { get; set; }
        public decimal? porIscItem { get; set; }
        public int? codTipoTributoOtro { get; set; }
        public decimal? mtoTriOtroItem { get; set; }
        public decimal? mtoBaseTriOtroItem { get; set; }
        public decimal? porTriOtroItem { get; set; }
        public decimal? mtoValorReferencialUnitario { get; set; }
        public int? codCargoDescuento { get; set; }


        public decimal cntPesoUnitario { get; set; }
        public decimal cntPesoTotal { get; set; }

        public string gloDescripcion { get; set; }
        public string gloObservacion { get; set; }


        public int? codEmpleadoVendedor { get; set; }
        public string codEmpleadoVendedorNombre { get; set; }


        public bool indVerificarStock { get; set; }
        public bool indEscanner { get; set; }

        public string codCuenta { get; set; }
        public string codPartida { get; set; }

        public string codCentroCosto { get; set; }
        public string codListaPrecio { get; set; }


        public string codRegTipoProductoNombre { get; set; }
        public string codDepositoNombre { get; set; }
        public string codRegGarantiaProdNombre { get; set; }
        public string codRegUnidadMedNombre { get; set; }
        public string codRegUnidadMedPresen { get; set; }
        public string codRegEstadoDocumento { get; set; }
        public string codRegEstadoDocumentoNombre { get; set; }
        public string codRegDestinoDocumentoNombre { get; set; }
        public string codListaPrecioNombre { get; set; }


        public bool indActivo { get; set; }

        public string segUsuarioEdita { get; set; }

        public Nullable<DateTime> segFechaEdita { get; set; }

        public string segMaquinaEdita { get; set; }



        public bool indOperacionGratuita { get; set; }

        /// <summary>
        /// Id de tipo de Afectacon al IGV, relacionado a la tabla [Sunat].[TS07TipoAfectacionIGV]
        /// </summary>
        public int? codTipoAfectacionIGV { get; set; }
        public string codTipoAfectacionIGVNombre { get; set; }

        #region ATRIBUTOS ADICIONALES


        //public string refCodigoArguMoneda { get; set; }
        //public string refCodigoArguMonedaNombre { get; set; }
        //public decimal refValorTipoCambio { get; set; }
        //public string refCodigoPersonaEntidad { get; set; }
        //public string refCodigoPersonaEntidadNombre { get; set; }
        //public decimal refTotItemValorVentaExtran { get; set; }
        //public string refCodigoArguTipoDeOperacion { get; set; }
        //public string refCodigoArguTipoDeOperacionNombre { get; set; }
        //public string refEntidadNumeroRUC { get; set; }
        //public string refUbigeo { get; set; }
        //public decimal refUnitValorCosto { get; set; }
        //public decimal refTotItemValorCosto { get; set; }
        //public decimal refTotItemSaldoStock { get; set; }


        #endregion
    }
}

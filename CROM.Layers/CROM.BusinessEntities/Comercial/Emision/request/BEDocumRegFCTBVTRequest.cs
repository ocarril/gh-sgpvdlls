namespace CROM.BusinessEntities.Comercial.emision.request
{

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 04/07/2020-05:06:47 p.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.DTODocumRegNCRRequest.cs]
    /// Documento   : FACTURA - BOLETA DE VENTA
    /// </summary>
    public class BEDocumRegFCTBVTRequest : BEDocumRegBaseRequest
    {

        public BEDocumRegFCTBVTRequest()
        {

            numDocumentoOrigen = string.Empty;
            codDocumentoOrigen = string.Empty;
            numOrdenDeCompra = string.Empty;
            numDocumento = string.Empty;
            numDocUsuario = string.Empty;
            numGuiaDeSalida = string.Empty;
            numLetrasCambio = string.Empty;
            numMinutaDatoRefer = string.Empty;
            numOrdenDeCompra = string.Empty;
            numPedidoAdquisicion = string.Empty;
            numSerieDatoRefer = string.Empty;
            perTributario = string.Empty;

        }

        public Nullable<DateTime> fecVencimiento { get; set; }

        public string codDocumentoOrigen { get; set; }        

        public string numDocumentoOrigen { get; set; }

        public int? codDocumentoSerieOrigen { get; set; }

        public int? codDocumRegOrigen { get; set; }

        public string codDepositoOrigen { get; set; }

        public Nullable<DateTime> fecEmisionOrigen { get; set; }

        public decimal monTipoCambioVTAOrigen { get; set; }


        public int? codEmpleadoVendedor { get; set; }

        public string numOrdenDeCompra { get; set; }

        public string numGuiaDeSalida { get; set; }

        public string numPedidoAdquisicion { get; set; }

        public string numLetrasCambio { get; set; }

        public string numSerieDatoRefer { get; set; }

        public string numMinutaDatoRefer { get; set; }

        public bool indDocEsGravado { get; set; }

        public bool indDocEsFacturable { get; set; }

        public Nullable<DateTime> fecEntrega{ get; set; }

        public string perTributario { get; set; }

        public bool flagParaEnvioSUNAT { get; set; }
        
        public int numDiasCredito { get; set; }


        #region PROPIEDADES POR DETRACCIONES

        public bool indAplicaDetraccion { get; set; }

        public int? codCuentaBancariaDetraccion { get; set; }

        public int codBienDetraccion { get; set; }

        public int? codFormaDePagoDetraccion { get; set; }

        public decimal prcDetraccion { get; set; }

        public decimal mtoDetraccion { get; set; }

        #endregion
    }
}

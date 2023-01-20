namespace CROM.BusinessEntities.Comercial.emision.request
{

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 31/10/2020-10:59:47 p.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.DTODocumRegFCTBVTProvRequest.cs]
    /// Documento   : FACTURA - BOLETA DE VENTA
    /// </summary>
    public class BEDocumRegFCTBVTProvRequest : BEDocumRegBaseRequest
    {

        public BEDocumRegFCTBVTProvRequest()
        {

            numDocumento = string.Empty;
            numDocUsuario = string.Empty;
            numDocumentoExtSerie = string.Empty;
            numLetrasCambio = string.Empty;
            numDocumentoExt = string.Empty;
            desNota03 = string.Empty;
            numSerieDatoRefer = string.Empty;
            desTotalPeso = string.Empty;
            perTributario = string.Empty;

        }

        public bool indInternacional { get; set; }

        public bool DocEsGravado { get; set; }

        public string numDocumentoExtSerie { get; set; }

        public string numDocumentoExt { get; set; }

        public string desTotalCaja { get; set; }

        public string desTotalPeso { get; set; }


        public string numLetrasCambio { get; set; }

        public string numSerieDatoRefer { get; set; }

        public string perTributario { get; set; }

        public int numDiasCredito { get; set; }

        public Nullable<DateTime> fecVencimiento { get; set; }

        public int? codEmpleadoVendedor { get; set; }

        public Nullable<DateTime> fecEntrega{ get; set; }
        
        public string desNota03 { get; set; }

        public bool indDocEsFacturable { get; set; }

        //public string codDocumentoOrigen { get; set; }        

        //public string numDocumentoOrigen { get; set; }

        //public int? codDocumentoSerieOrigen { get; set; }

        //public int? codDocumRegOrigen { get; set; }

        //public string codDepositoOrigen { get; set; }

        //public Nullable<DateTime> fecEmisionOrigen { get; set; }

        //public decimal monTipoCambioVTAOrigen { get; set; }


        //public string numOrdenDeCompra { get; set; }

        //public string numGuiaDeSalida { get; set; }

        //public string numPedidoAdquisicion { get; set; }

        //public string numMinutaDatoRefer { get; set; }

        //public bool flagParaEnvioSUNAT { get; set; }

    }
}

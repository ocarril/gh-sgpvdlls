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
    /// Documento   : GUIA DE REMISION
    /// </summary>
    public class BEDocumRegGUIAREMRequest : BEDocumRegBaseRequest
    {

        public BEDocumRegGUIAREMRequest()
        {

            numDocumentoOrigen = string.Empty;
            codDocumentoOrigen = string.Empty;
            numOrdenDeCompra = string.Empty;
            numDocumento = string.Empty;
            numDocUsuario = string.Empty;
            numGuiaDeSalida = string.Empty;
            desNota03 = string.Empty;
            numMinutaDatoRefer = string.Empty;
            numOrdenDeCompra = string.Empty;
            numPedidoAdquisicion = string.Empty;
            numSerieDatoRefer = string.Empty;
            desTransporteConstancia = string.Empty;
            desTransporteLicencia = string.Empty;
            desTransportePlaca = string.Empty;
            desTransporteMarca = string.Empty;
            desDireccioDePartida = string.Empty;
            numContenedor = string.Empty;
            desTotalCaja = string.Empty;
            desTotalPeso = string.Empty;
            codRegUnidadMedidaGlobal = string.Empty;
            desMotivoGuiaOtro = string.Empty;
        }

        public Nullable<DateTime> fecVencimiento { get; set; }

        public string codDocumentoOrigen { get; set; }

        public string numDocumentoOrigen { get; set; }

        public int? codDocumentoSerieOrigen { get; set; }

        public int? codDocumRegOrigen { get; set; }

        public Nullable<DateTime> fecEmisionOrigen { get; set; }

        public decimal monTipoCambioVTAOrigen { get; set; }


        public int? codEmpleadoVendedor { get; set; }

        public string numOrdenDeCompra { get; set; }

        public string numGuiaDeSalida { get; set; }

        public string numPedidoAdquisicion { get; set; }


        public string numSerieDatoRefer { get; set; }

        public string numMinutaDatoRefer { get; set; }


        public Nullable<DateTime> fecEntrega { get; set; }

        public int numDiasCredito { get; set; }

        public int? codDepositoOrigen { get; set; }


        public string desTotalCaja { get; set; }

        public string desTotalPeso { get; set; }


        public string codRegMotivoGuia { get; set; }

        public string desDireccioDePartida { get; set; }

        //public string desUbigeoDePartida { get; set; }

        public string codPersonaTransporte { get; set; }

        public string codRegTipoDomicilioTransporte { get; set; }


        public string codUbigeoTransporte { get; set; }


        public string codPersonaConductor { get; set; }

        public DateTime? fecInicioTraslado { get; set; }

        public string desTransporteConstancia { get; set; }

        public string desTransporteMarca { get; set; }

        public string desTransporteLicencia { get; set; }

        public string desTransportePlaca { get; set; }


        public string desNota03 { get; set; }


        public int? codPersonaDomicilioTransportista { get; set; }

        public int? codPersonaDomicilioPartida { get; set; }

        public int? codModalidadTransporte { get; set; }


        public string codRegTipoDocumentoTransportista { get; set; }

        public string codRegUnidadMedidaGlobal { get; set; }

        public string desMotivoGuiaOtro { get; set; }






        #region DATOS DEL PROVEEDOR


        public string codPersonaProveedor { get; set; }


        public string codTipoDocumentoProveedor { get; set; }

        public string numDocumentoProveedor { get; set; }

        public string nomRazonSocialProveedor { get; set; }

        #endregion


        #region DATOS DEL COMPRADOR


        public string codPersonaComprador { get; set; }


        public string codTipoDocumentoComprador { get; set; }

        public string numDocumentoComprador { get; set; }

        public string nomRazonSocialComprador { get; set; }

        #endregion

        #region DATOS DE IMPORTACION - EXPORTACION


        public string numContenedor { get; set; }

        public string numPrecinto { get; set; }

        public string numContenedor02 { get; set; }

        public string numPrecinto02 { get; set; }


        public string codPuerto { get; set; }

        public string codAeroPuerto { get; set; }

        public string indTransbordoProgramado { get; set; }


        #endregion

    }
}

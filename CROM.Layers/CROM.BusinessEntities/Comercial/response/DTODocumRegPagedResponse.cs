namespace CROM.BusinessEntities.Comercial.response
{
    using System;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 19/04/2018-06:24:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.DTODocumReg.cs]
    /// </summary>
    public class DTODocumRegPagedResponse : BEBasePagedResponse
    {

        public DTODocumRegPagedResponse()
        {
            codPuntoVentaNombre = string.Empty;
            numDocUsuario = string.Empty;
            numPedidoAdquisicion = string.Empty;
            numGuiaDeSalida = string.Empty;
            numOrdenDeCompra = string.Empty;
            numDocumento = string.Empty;
            codRegEstadoNombre = string.Empty;
            codRegMonedaNombre = string.Empty;
            codCondicionVentaNombre = string.Empty;
            codLocalEmisor = string.Empty;
            codRegTipoOperacion = string.Empty;
            codRegTipoOperacionNombre = string.Empty;
            gloObservaciones = string.Empty;
            gloMotivoSustento = string.Empty;

            codBienDetraccionNombre = string.Empty;
            indAbreviaturaDest = string.Empty;
            indAbreviaturaOrig = string.Empty;
        }


        public int codDocumReg { get; set; }

        public string tipOperacion { get; set; }

        public string indAbreviatura { get; set; }

        public string codTipoComprobante { get; set; }

        public string codDocumentoNombre { get; set; }

        public DateTime fecEmision { get; set; }

        public Nullable<DateTime> fecVencimiento { get; set; }

        public Nullable<DateTime> fecPago { get; set; }

        public string codLocalEmisor { get; set; }

        public string tipDocUsuario { get; set; }

        public string numDocUsuario { get; set; }

        public string rznSocialUsuario { get; set; }

        public string desDomicilioUsuario { get; set; }

        public string codRegUbigeoNombre { get; set; }

        public string codRegTipoDomicilNombre { get; set; }

        public string tipMoneda { get; set; }

        public string codRegMonedaNombre { get; set; }

        public string codEmpleadoNombre { get; set; }

        public string codRegDestinoDocumNombre { get; set; }

        public decimal sumTotBruto { get; set; }

        public decimal prcIGV { get; set; }

        public decimal sumDescTotal { get; set; }

        public decimal sumTotValVenta { get; set; }

        public decimal sumTotTributos { get; set; }

        public decimal sumPrecioVenta { get; set; }

        public decimal sumPrecioVentaExtran { get; set; }

        public string numDocumentoDESTINO { get; set; }

        public string numDocumentoORIGEN { get; set; }

        public decimal sumOtrosCargos { get; set; }

        public decimal sumTotalAnticipos { get; set; }

        public decimal sumImpVenta { get; set; }


        /**
         * ATRIBUTOS ADICIONALES
         */
        public int codEmpresa { get; set; }

        public string codRegEstadoNombre { get; set; }

        public string codRegEstadoColor { get; set; }

        public string codDocumentoEstadoNombre { get; set; }

        public Int16 indOrigen { get; set; }


        public string numDocumento { get; set; }

        public int numTotalItems { get; set; }

        public int numTotalLetras { get; set; }



        public string codCondicionVentaNombre { get; set; }

        public decimal monTipoCambioVTA { get; set; }

        public decimal monTipoCambioCMP { get; set; }

        public string codPuntoVentaNombre { get; set; }

        public string numOrdenDeCompra { get; set; }

        public string numGuiaDeSalida { get; set; }

        public string numPedidoAdquisicion { get; set; }

        public Nullable<DateTime> fecDeDeclaracion { get; set; }

        public string perTributario { get; set; }

        public bool flagParaEnvioSUNAT { get; set; }

        public bool flagEnviadoSUNAT { get; set; }

        public Nullable<DateTime> fecEnviadoSUNAT { get; set; }

        public bool flagPermiteEditar { get; set; }

        public string codRegDocumento { get; set; }

        public string codRegEstado { get; set; }

        public int? codDocumentoEstado { get; set; }

        public string codDocumento { get; set; }

        public string codRegTipoOperacion { get; set; }

        public string codRegTipoOperacionNombre { get; set; }


        public string codRegDestinoDocum { get; set; }

        public bool indEsGravado { get; set; }

        #region // XLM DOCUMENTO DE BAJA

        public bool FlagAnulado { get; set; }

        public bool FlagDeBaja { get; set; }

        public string NomArchivoBaja { get; set; }

        public string MotivoBaja { get; set; }

        public Nullable<DateTime> Fecha_SFSBaja { get; set; }

        public string RptaSunatFSDescripcionBaja { get; set; }

        public Nullable<DateTime> RptaSunatFSFechaBaja { get; set; }

        public string segUsuarioEditaBaja { get; set; }


        public bool BajaNomArchivoValidado { get; set; }

        public string BajaFirmaDigestValue { get; set; }

        public string NomArchivoTicket { get; set; }

        public string gloObservaciones { get; set; }

        public string gloMotivoSustento { get; set; }

        public bool indArchivoValidado { get; set; }

        #endregion

        #region // DATOS DEL DOCUMENTO DE REFERENCIA

        public int? RefcodDocumReg { get; set; }
        public string RefcodDocumento { get; set; }
        public string RefnumDocumentoOrig { get; set; }
        public decimal? RefmonTipoCambioVTA { get; set; }
        public string ReftipoDocumento { get; set; }
        public string ReftipoDocumentoNombre { get; set; }


        public string RefnumSerie { get; set; }
        public string RefnumDocumento { get; set; }
        public Nullable<DateTime> ReffecEmision { get; set; }
        public int? codMotivoNCR { get; set; }
        public int? codMotivoNDB { get; set; }
        public string RefMotivo { get; set; }

        public string keyMotivoNCR { get; set; }
        public string keyMotivoNDB { get; set; }
        public string codMotivoNCRNombre { get; set; }
        public string codMotivoNDBNombre { get; set; }

        public string indAbreviaturaOrig { get; set; }

        public string indAbreviaturaDest { get; set; }

        #endregion

        #region // PROPIEDADES POR DETRACCIONES

        public bool indAplicaDetraccion { get; set; }

        public int? codCuentaBancariaDetraccion { get; set; }

        public int codBienDetraccion { get; set; }

        public int? codFormaDePagoDetraccion { get; set; }

        public decimal prcDetraccion { get; set; }

        public decimal mtoDetraccion { get; set; }

        public bool? indActivoDetraccion { get; set; }

        public string codBienDetraccionNombre { get; set; }

        #endregion

        #region // PROPIEDADES POR LA GUIA DE REMISIÓN

        public string desTotalCaja { get; set; }
        public string desTotalPeso { get; set; }
        public string codModalidadTransporteNombre { get; set; }
        public DateTime? fecInicioTraslado { get; set; }
        public string codRegMotivoGuiaNombre { get; set; }
        public string codPersonaTransporteNombre { get; set; }

        #endregion

        public int? codDocumRegSunat { get; set; }

        public string codFormaDePagoNombre { get; set; }

        public bool indFormaPagoRegistra { get; set; }

        public bool indImprimePDF { get; set; }

        public bool indGeneraEnvioResumDiarioSFS { get; set; }


        public bool indCanceladoPagado { get; set; }

        public string fecPagadoCancelado { get; set; }

    }

}

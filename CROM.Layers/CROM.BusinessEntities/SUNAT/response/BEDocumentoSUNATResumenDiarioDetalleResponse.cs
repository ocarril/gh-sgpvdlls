namespace CROM.BusinessEntities.SUNAT.response
{
    using System;


    public class BEDocumentoSUNATResumenDiarioDetalleResponse : BEBasePagedResponse
    {
        public BEDocumentoSUNATResumenDiarioDetalleResponse()
        {
            codDocumento = string.Empty;
            indAbreviatura = string.Empty;
            numDocumento = string.Empty;
            RD_codRegimenPercepcion = string.Empty;
            RD_codTipDocUsuario = string.Empty;
            RD_codTipoDocumento = string.Empty;
            RD_codTipoDocumentoModifica = string.Empty;
            RD_codTipoMoneda = string.Empty;
            RD_codTributoIGV = string.Empty;
            RD_codTributoIGVInter = string.Empty;
            RD_codTributoISC = string.Empty;
            RD_codTributoISCInter = string.Empty;
            RD_codTributoOTRO = string.Empty;
            RD_codTributoOTROInter = string.Empty;
            RD_EstadoDelItem = string.Empty;
            RD_nomTributoIGV = string.Empty;
            RD_nomTributoISC = string.Empty;
            RD_nomTributoOTRO = string.Empty;
            RD_numDocumento = string.Empty;
            RD_numDocumentoModifica = string.Empty;
            RD_numDocUsuario = string.Empty;
            RD_numSerie = string.Empty;
            RD_numSerieModifica = string.Empty;
        }

        public int codEmpresa { get; set; }
        public string codDocumento { get; set; }
        public string indAbreviatura { get; set; }
        public int codDocumReg { get; set; }
        public string numDocumento { get; set; }

        /// <summary>
        /// Sólo se admite los códigos: 
        /// '03' - "Boleta de venta", 
        /// '07' - "Nota de crédito" u 
        /// '08' - "Nota de débito".
        /// </summary>
        public string RD_codTipoDocumento { get; set; }

        public string RD_numSerie { get; set; }

        public string RD_numDocumento { get; set; }

        public string RD_codTipDocUsuario { get; set; }

        public string RD_numDocUsuario { get; set; }

        /// <summary>
        /// Se indicará para cada línea (documento informado) los siguientes
        /// códigos: 
        /// 1 = Adicionar. 
        /// 2 = Modificar.  Para utilizar este estado, el documento debe estar previamente informado.
        /// 3 = Anulado.    Para utilizar este estado, el documento debe estar previamente informado.
        /// </summary>
        public string RD_EstadoDelItem { get; set; }

        public string RD_codTipoMoneda { get; set; }


        public decimal RD_sumTotValVenta { get; set; }

        public decimal RD_sumPrecioVentaMN { get; set; }

        public decimal RD_sumPrecioVentaME { get; set; }


        public string RD_codTributoISC { get; set; }
        public string RD_nomTributoISC { get; set; }
        public string RD_codTributoISCInter { get; set; }
        public decimal RD_sumTributoISC { get; set; }


        public string RD_codTributoIGV { get; set; }
        public string RD_nomTributoIGV { get; set; }
        public string RD_codTributoIGVInter { get; set; }
        public decimal prcImpuestoGV { get; set; }
        public decimal RD_sumTributoIGV { get; set; }


        public string RD_codTributoOTRO { get; set; }
        public string RD_nomTributoOTRO { get; set; }
        public string RD_codTributoOTROInter { get; set; }
        public decimal RD_sumTributoOTRO { get; set; }

        /// <summary>
        /// 01	Gravado
        /// 02	Exonerado
        /// 03	Inafecto
        /// 04	Exportación
        /// 05	Gratuitas
        /// </summary>
        public string RD_TipoValorVentaRD { get; set; }


        public bool RD_indOtrosCargos { get; set; }


        /// <summary>
        /// Campo obligatorio, sólo si se consigna en el campo Tipo de documento el
        /// código '07' - "Nota de crédito" u '08' - "Nota de débito". 
        /// En el campo Tipde documento que se modifica se puede consignar  
        /// el código '03' - "Boletde venta" o '12' - "Ticket o cinta emitido por máquina registradora".
        /// </summary>
        public string RD_codTipoDocumentoModifica { get; set; }

        public string RD_numSerieModifica { get; set; }

        public string RD_numDocumentoModifica { get; set; }

        public string RD_codDocumentoModifica { get; set; }

        public DateTime? RD_fecEmisionModifica { get; set; }

        public decimal? RD_monTipoCambioVTAModifica { get; set; }

        public decimal? RD_mtoDocRelacionadoModifica { get; set; }

        public string RD_codMotivoNCR { get; set; }

        public string RD_codMotivoNDB { get; set; }

        public string RD_MotivoModifica { get; set; }


        /// <summary>
        /// Datos de la percepción incluida en la boleta de venta electrónica que se informa
        /// Los datos de la percepción deben ser informados en moneda nacional.
        /// </summary>
        public string RD_codRegimenPercepcion { get; set; }

        public decimal RD_prcPercepcion { get; set; }

        public decimal RD_sumPrecioVentaPercepcion { get; set; }

        public decimal RD_sumMontoPercepcion { get; set; }

        public decimal RD_sumMontoIncluidaPercepcion { get; set; }

        public bool flagEnviadoSUNAT { get; set; }


        public DateTime fecEmision { get; set; }
        public decimal? monTipoCambioVTA { get; set; }
        public decimal sumTotBruto { get; set; }
        public decimal sumDescTotal { get; set; }
        public decimal sumImpVenta { get; set; }

        public decimal sumOtrosCargos { get; set; }
        public decimal sumTotalAnticipos { get; set; }
        public decimal sumTotTributos { get; set; }
        public string ublVersionId { get; set; }
        public string customizationId { get; set; }
        public decimal? monTipoCambioCMP { get; set; }

        public string nomRazonSocial { get; set; }

        public string desFirmaDigestValue { get; set; }
        public string desRptaNomArchivoXml { get; set; }
        public DateTime? fecRptaSunatFSFecha { get; set; }
    }
}              

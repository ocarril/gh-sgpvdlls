namespace CROM.BusinessEntities.Comercial.response
{
    using System;

    public class DTODocumRegReferenciaResponse
    {
        public DTODocumRegReferenciaResponse()
        {
            ErrorMessage = string.Empty;
            refcodDocumento = string.Empty;
            refnumDocumento = string.Empty;
            refmonTipoCambioVTA = 0;
        }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public int refcodDocumReg { get; set; }

        public string refcodPersonaEntidad { get; set; }

        public DateTime reffecEmision { get; set; }

        public string refcodDocumento { get; set; }

        public string refnumDocumento { get; set; }

        public decimal refmonTipoCambioVTA { get; set; }

        public string refnumOrdenDeCompra { get; set; }
        public string refnumGuiaDeSalida { get; set; }
        public string refnumPedidoAdquisicion { get; set; }
        public string refnumMinuta { get; set; }
        public string refnumSerie { get; set; }



        public decimal refmonTotalPrecioVTA { get; set; }

        public decimal refmonTotalPrecioExtran { get; set; }

        public string refcodRegMoneda { get; set; }

        public decimal refmonTotalDocumOrigen { get; set; }

        public decimal refmonTotalDocumDestino { get; set; }


        public int? refcodCondicionVenta { get; set; }

        public int refnumDiasCredito { get; set; }
        public string refNota01 { get; set; }
        public string refNota02 { get; set; }
        public string refObservaciones { get; set; }
        public string refReferencia { get; set; }
        public string refNota03 { get; set; }
        public string refDireccioDePartida { get; set; }
        public string refdesTotalCaja { get; set; }
        public string refdesTotalPeso { get; set; }

        /* DATOS PARA NOTA DE CREDITO */
        public string refcodRegMonedaNombre { get; set; }
        public string refcodRegMonedaSimbolo { get; set; }
        public string refcodDocumentoAbreviatura { get; set; }
        public string refcodDocumentoNombre { get; set; }
        public bool refindAplicaDetraccion { get; set; }
        public decimal refprcDetraccion { get; set; }
        public decimal refmtoDetraccion { get; set; }
        public int? refodCondicionVenta { get; set; }
        public string refodCondicionVentaNombre { get; set; }
        public DateTime reffecDeVencimiento { get; set; }

        public int refnumCuotas { get; set; }
        public int refnumDiasGracia             { get; set; }
        public string refcodRegTipoPlazo           { get; set; }
        public string refcodRegTipoPlazoNombre      { get; set; }
        public string refcodPersonaBanco           { get; set; }
        public string refcodPersonaBancoNombre      { get; set; }
        public string refcodPersonaAval            { get; set; }
        public string refcodPersonaAvalNombre      { get; set; }
    }
}

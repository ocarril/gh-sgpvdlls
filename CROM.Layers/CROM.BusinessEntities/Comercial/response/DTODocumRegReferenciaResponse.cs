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
    }
}

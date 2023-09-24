
namespace CROM.BusinessEntities.SUNAT.response
{
    using System;
    using System.Collections.Generic;

    public class BEDocumentoSUNATResumenDiarioResponse : BEBasePagedResponse
    {
        public BEDocumentoSUNATResumenDiarioResponse()
        {
            numRUCEmpresa = string.Empty;
            nomRazonSocialEmisor = string.Empty;
            nomFileSunat = string.Empty;
            verCustomizationID = string.Empty;
            verUBLId = string.Empty;
            gloNota = string.Empty;
            LstDocumentosBVTA = new List<BEDocumentoSUNATResumenDiarioDetalleResponse>();
            DatoEmpresa = new BEDatoEmpresa();
        }


        public List<BEDocumentoSUNATResumenDiarioDetalleResponse> LstDocumentosBVTA { get; set; }

        public BEDatoEmpresa DatoEmpresa { get; set; }

        public int codEmpresa { get; set; }

        public int codDocumRegResumenDiario { get; set; }

        public string numRUCEmpresa { get; set; }

        public string nomRazonSocialEmisor { get; set; }

        public DateTime fecProcesoVenta { get; set; }

        public DateTime fecGeneracionRD { get; set; }

        public string nomFileSunat { get; set; }

        public string verUBLId { get; set; }

        public string verCustomizationID { get; set; }

        public string desRptaSunatFS { get; set; }

        public DateTime? fecRptaSunatFS { get; set; }

        public string desNomArchivoValidado { get; set; }

        public string desFirmaDigestValue { get; set; }

        public string desFirmaSignatureValue { get; set; }

        public string desNomArchivoTicket { get; set; }

        public string numCorrelativo { get; set; }

        public string pathFileResumenDiario { get; set; }

        public string gloNota { get; set; }

        public string codTipoDocumentoEmisor { get; set; }

        public string totEnLetras { get; set; }



        public decimal sumPrecioVentaADIC { get; set; }

        public decimal sumPrecioVentaMODI { get; set; }

        public decimal sumPrecioVentaANUL { get; set; }

        public decimal sumPrecioVentaTOTA { get; set; }


    }
}

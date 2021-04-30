
namespace CROM.BusinessEntities.SUNAT.response
{
    using System;
    using System.Collections.Generic;

    public class BEDocumentoSUNATResumenDiarioResponse
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
        }

        public string numRUCEmpresa { get; set; }

        public string nomRazonSocialEmisor { get; set; }

        public DateTime fecProcesoVenta { get; set; }

        public DateTime fecGeneraciónRD { get; set; }

        public string nomFileSunat { get; set; }

        public string verUBLId { get; set; }

        public string verCustomizationID { get; set; }

        public string gloNota { get; set; }

        public string codTipoDocumentoEmisor { get; set; }

        public string numCorrelativo { get; set; }

        public List<BEDocumentoSUNATResumenDiarioDetalleResponse> LstDocumentosBVTA { get; set; }

        public string pathFileResumenDiario { get; set; }
    }
}

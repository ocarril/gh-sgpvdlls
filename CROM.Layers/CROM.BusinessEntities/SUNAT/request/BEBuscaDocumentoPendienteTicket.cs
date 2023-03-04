using System.Collections.Generic;

namespace CROM.BusinessEntities.SUNAT.request
{
    public class BEBuscaDocumentoPendienteTicket : BEBuscadorBase
    {
        public BEBuscaDocumentoPendienteTicket()
        {
            segIPMaquinaPC = string.Empty;
            codEmpresaRUC = string.Empty;
            segUsuarioActual = string.Empty;
            LstCodDocumReg = new List<DocumRegSelect>();
        }


        public string codTipoDocumento { get; set; }

        public string numDocumento { get; set; }

        public List<DocumRegSelect> LstCodDocumReg { get; set; }

    }
}

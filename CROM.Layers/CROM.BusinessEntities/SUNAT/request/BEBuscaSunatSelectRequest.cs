namespace CROM.BusinessEntities.SUNAT.request
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class BEBuscaSunatSelectRequest : BEBuscadorBase
    {
        public BEBuscaSunatSelectRequest()
        {
            LstCodDocumReg = new List<DocumRegSelect>();
        }

        public int indOrigenPeticion { get; set; }
        public List<DocumRegSelect> LstCodDocumReg { get; set; }

    }

    public class DocumRegSelect
    {
        public DocumRegSelect()
        {
            nomArchivoSUNAT = string.Empty;
        }

        public int codDocumReg { get; set; }

        public string nomArchivoSUNAT { get; set; }
    }
}

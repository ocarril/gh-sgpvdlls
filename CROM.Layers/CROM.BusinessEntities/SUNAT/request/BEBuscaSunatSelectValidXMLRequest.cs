namespace CROM.BusinessEntities.SUNAT.request
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class BEBuscaSunatSelectValidXMLRequest : BEBuscadorBase
    {
        public BEBuscaSunatSelectValidXMLRequest()
        {
            LstCodDocumReg = new List<DocumRegSelect>();
        }

        public int indOrigenPeticion { get; set; }

        public bool indNomArchivoValidado { get; set; }

        public bool flagUpdateFileXML { get; set; }

        public List<DocumRegSelect> LstCodDocumReg { get; set; }

    }

}

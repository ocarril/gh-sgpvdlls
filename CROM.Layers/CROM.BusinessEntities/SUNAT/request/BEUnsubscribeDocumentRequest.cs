namespace CROM.BusinessEntities.SUNAT.request
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class BEUnsubscribeDocumentRequest : BEBaseEntidadItem
    {
        public BEUnsubscribeDocumentRequest()
        {
            gloMotivoBaja = string.Empty;
            LstCodDocumRegBaja = new List<DocumRegBajaSelect>();
        }

        public List<DocumRegBajaSelect> LstCodDocumRegBaja { get; set; }
        
        public DateTime fecEnvioBaja { get; set; }

        public string  gloMotivoBaja { get; set; }


        [JsonIgnore]
        public string NomArchivo { get; set; }

        [JsonIgnore]
        public int codDocumReg { get; set; }


        #region ATRIBUTOS PARA ACTUALIZAR RPTA SUNAT

        [JsonIgnore]
        public DateTime? RptaFecha_SFS { get; set; }

        [JsonIgnore]
        public string RptaSunatFSDescripcion { get; set; }


        [JsonIgnore]
        public string RptaSunatFSNote { get; set; }


        [JsonIgnore]
        public DateTime? RptaSunatFSFecha { get; set; }


        [JsonIgnore]
        public string NomArchivoTicket { get; set; }

        #endregion

    }

    public class DocumRegBajaSelect
    {

        public DocumRegBajaSelect()
        {
            codTipoComprobante = string.Empty;
            numSerie = string.Empty;
            numDocumento = string.Empty;
        }

        public int codDocumReg { get; set; }
        
        public string codTipoComprobante { get; set; }

        public string numSerie { get; set; }

        public string numDocumento { get; set; }

        public Nullable<DateTime> fecEmision { get; set; }

        public bool flagUpdated { get; set; }

        public bool flagValidated { get; set; }

        public string gloMotivoBaja { get; set; }

        public string NumeroCorrelative { get; set; }

    }

}

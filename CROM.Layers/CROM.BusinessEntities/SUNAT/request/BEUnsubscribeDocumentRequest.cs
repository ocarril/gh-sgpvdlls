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
            LstCodDocumRegBaja = new List<BEDocumRegBajaSelect>();
        }

        public List<BEDocumRegBajaSelect> LstCodDocumRegBaja { get; set; }

        public DateTime fecEnvioBaja { get; set; }

        public string gloMotivoBaja { get; set; }

        public string codRegMotivoAnulacion { get; set; }

        public int indOrigenPeticion { get; set; }



        public string horEnvioBaja { get; set; }




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

    public class BEDocumRegBajaSelect
    {

        public BEDocumRegBajaSelect()
        {
            codTipoComprobante = string.Empty;
            numSerie = string.Empty;
            numDocumento = string.Empty;
        }
        public int codEmpresa { get; set; }

        public int codDocumReg { get; set; }

        public string numSerie { get; set; }

        public string numDocumento { get; set; }

        public string codTipoComprobante { get; set; }

        public Nullable<DateTime> fecEmision { get; set; }

        public TimeSpan horEmision { get; set; }

        public DateTime? segFechaEdita { get; set; }

        public string segUsuarioEdita { get; set; }

        #region DATOS ADICIONALES

        public string ublVersionId { get; set; }

        public string customizationId { get; set; }

        public DateTime fecEmisionDT { get; set; }

        public string EmisorNumRUC { get; set; }

        public string EmisorNombre { get; set; }

        public string EmisorTipoDocumento { get; set; }

        #endregion

        public bool flagUpdated { get; set; }

        public bool flagValidated { get; set; }

        #region DATOS INPUT

        public string gloMotivoBaja { get; set; }

        public string NumeroCorrelative { get; set; }

        #endregion

        public int codDocumentoEstado { get; set; }
    }

    public class BEDocumRegBajaResponse
    {

        public BEDocumRegBajaResponse()
        {
            segUsuarioEdita = string.Empty;
            numSerie = string.Empty;
            numDocumento = string.Empty;
        }


        public int codDocumReg { get; set; }

        public string numSerie { get; set; }

        public string numDocumento { get; set; }

        public Nullable<DateTime> fecEmision { get; set; }
       
        public bool flagUpdated { get; set; }

        public int codDocumentoEstado { get; set; }

        public bool flagValidated { get; set; }

        [JsonIgnore]
        public int codEmpresa { get; set; }

        [JsonIgnore]
        public string segUsuarioEdita { get; set; }
    }


}

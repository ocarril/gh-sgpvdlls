namespace CROM.BusinessEntities.SUNAT.request
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class BEUnsubscribeDocumentDailySummaryRequest : BEBaseEntidadItem
    {
        public BEUnsubscribeDocumentDailySummaryRequest()
        {
            gloMotivoBaja = string.Empty;
            codRegMotivoAnulacion = string.Empty;
        }

        public  int codDocumRegResumenDiario { get; set; }

        public DateTime fecEnvioBaja { get; set; }

        public string gloMotivoBaja { get; set; }

        public string codRegMotivoAnulacion { get; set; }


        public int codDocumReg { get; set; }

    }

    public class BEUnsubscribeDocumentDailySummaryAcceptedRequest : BEBaseEntidadItem
    {
        public BEUnsubscribeDocumentDailySummaryAcceptedRequest()
        {
            RptaSunatFSDescripcion = string.Empty;

        }


        public int codDocumReg { get; set; }


        public DateTime? RptaFecha_SFS { get; set; }

        public string RptaSunatFSDescripcion { get; set; }


    }

    public class BEDocumRegBajaDailySummarySelect
    {

        public BEDocumRegBajaDailySummarySelect()
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

    public class BEDocumRegBajaDailySummaryResponse
    {

        public BEDocumRegBajaDailySummaryResponse()
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

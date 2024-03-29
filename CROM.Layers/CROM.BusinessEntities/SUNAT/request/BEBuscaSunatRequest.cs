﻿namespace CROM.BusinessEntities.SUNAT.request
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class BEBuscaSunatRequest : BEBuscadorBaseRequest
    {
        public BEBuscaSunatRequest()
        {
            fecInicio = string.Empty;
            fecFinal = string.Empty;
            codDocumento = string.Empty;
            numDocumento = string.Empty;
            codRegEstadoDocu = string.Empty;
            numRUCEntidad = string.Empty;
            desNombreEntidad = string.Empty;
            perTributario = string.Empty;
            codRegDestinoDocum = string.Empty;
            codEmpleadoSIS = string.Empty;
        }

        public Nullable<DateTime> fecInicioDate { get; set; }

        public Nullable<DateTime> fecFinalDate { get; set; }

        public string codDocumento { get; set; }

        public string numDocumento { get; set; }

        public string codRegEstadoDocu { get; set; }

        public string numRUCEntidad { get; set; }

        public string desNombreEntidad { get; set; }

        public string perTributario { get; set; }

        public bool flagParaEnvioSUNAT { get; set; }

        public bool flagEnviadoSUNAT { get; set; }

        public bool? indNomArchivoValidado { get; set; }

        public string codRegDestinoDocum { get; set; }

        public int indOrigenPeticion { get; set; }

        [JsonIgnore]
        public string fecInicio { get; set; }

        [JsonIgnore]
        public string fecFinal { get; set; }

        public bool flagUpdateFileXML { get; set; }


        [JsonIgnore]
        public string codEmpleadoSIS { get; set; }

    }


    public class BEBuscaDocumento : BEBuscadorBase
    {
        public BEBuscaDocumento()
        {
            codEmpleadoSIS = string.Empty;
            segIPMaquinaPC = string.Empty;
            codEmpresaRUC = string.Empty;
            segUsuarioActual = string.Empty;
        }


        public int codDocumReg { get; set; }
        
       
        public string codTipoDocumento { get; set; }

        [JsonIgnore]
        public string numDocumento { get; set; }

        [JsonIgnore]
        public DateTime? fecProceso { get; set; }

        [JsonIgnore]
        public bool flagEnvioMailOk { get; set; }


        [JsonIgnore]
        public string codEmpleadoSIS { get; set; }


        [JsonIgnore]
        public string nomArchivo { get; set; }
    }


    


    public class BEBuscaDocumentoPendienteTicketRequest : BEBuscaDocumentoPendienteTicket
    {
        public BEBuscaDocumentoPendienteTicketRequest()
        {
            segIPMaquinaPC = string.Empty;
            codEmpresaRUC = string.Empty;
            segUsuarioActual = string.Empty;
        }


        public string numTicket { get; set; }

    }


}

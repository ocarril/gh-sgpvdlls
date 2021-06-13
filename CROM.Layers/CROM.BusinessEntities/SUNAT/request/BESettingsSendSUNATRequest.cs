using Newtonsoft.Json;

namespace CROM.BusinessEntities.SUNAT.request
{
    public class BESettingsSendSUNATRequest
    {
        public BESettingsSendSUNATRequest()
        {
            PathRutaSendWSXML = string.Empty;
            PasswordCertificado = string.Empty;
            PathRutaCertificado = string.Empty;
            PathRutaSendWSEnviosZIP = string.Empty;
            PathRutaSendWSCDRS = string.Empty;
            PathRutaSendWSXMLFile = string.Empty;
            PathRutaSendWSSigned = string.Empty;
            PathRutaSendWSZIPFile = string.Empty;
        }

        public string PathRutaSendWSXML { get; set; }

        public string PathRutaSendWSEnviosZIP { get; set; }

        public string PathRutaSendWSCDRS { get; set; }

        public string PathRutaSendWSSigned { get; set; }

        public string PathRutaIMGCodBarras { get; set; }


        public string PathRutaCertificado { get; set; }

        public string PasswordCertificado { get; set; }


        public string PathRutaSendWSXMLFile { get; set; }

        public string PathRutaSendWSZIPFile { get; set; }

        public string PathRutaSendWSCDRZIPFile { get; set; }

        [JsonIgnore]
        public int codEmpresa { get; set; }

        [JsonIgnore]
        public string UserLoginCurrent { get; set; }

        [JsonIgnore]
        public bool indEnvioDirectoSUNAT { get; set; }

        [JsonIgnore]
        public string numDocumento { get; set; }

        [JsonIgnore]
        public int indOrigenPeticion { get; set; }
    }
}

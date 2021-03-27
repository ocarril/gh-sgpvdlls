namespace CROM.BusinessEntities.SUNAT.response
{
    using System;

    public class DTOCertificadoDigitalResponse: BEBaseEntidadItem
    {
        public DTOCertificadoDigitalResponse()
        {

            codPersonaNombre = string.Empty;
            desPathFile = string.Empty;
            ctaEmailAlertar = string.Empty;
            numTelefono = string.Empty;
            numRUC = string.Empty;
        }

        public int codCertificadoDigital { get; set; }

        public string codPersona { get; set; }

        public string desPathFile { get; set; }

        public DateTime fecInicio { get; set; }

        public DateTime fecFinal { get; set; }

        public string codPersonaNombre { get; set; }

        public string numRUC { get; set; }

        public string numTelefono { get; set; }
        public string desCorreoElectronico { get; set; }

        public string ctaEmailAlertar { get; set; }

        public int numDiasVencimiento { get; set; }

    }
}

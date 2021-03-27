using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.BusinessEntities.SUNAT.request
{
    public class BEArchivoSunatRequest
    {
        public BEArchivoSunatRequest()
        {
            codTipoComprobante = string.Empty;
            NumeroSerie = string.Empty;
            NumeroDocumento = string.Empty;
            RutaPlanoSUNAT = string.Empty;
            NumRUCEmpresa = string.Empty;
            indDocumentoRelacionado = string.Empty;
            NombreArchivoREL = string.Empty;
            NombreArchivoCAB = string.Empty;
            NombreArchivoNOT = string.Empty;
            DescripcionBaja = string.Empty;
            PathRutaFiles = string.Empty;
            ExtensionFile = string.Empty;
        }

        public string codTipoComprobante { get; set; }

        public string NumeroSerie { get; set; }

        public string NumeroDocumento { get; set; }

        public string RutaPlanoSUNAT { get; set; }

        public string NumRUCEmpresa { get; set; }

        public string indDocumentoRelacionado { get; set; }

        public string NombreArchivoREL { get; set; }

        public string NombreArchivoCAB { get; set; }

        public string NombreArchivoDET { get; set; }

        public string NombreArchivoNOT { get; set; }

        public string NombreArchivoTRI { get; set; }

        public string NombreArchivoACA { get; set; }

        public string NombreArchivoLEY { get; set; }

        public string NombreArchivoADE { get; set; }

        public string DescripcionBaja { get; set; }

        public string NumeroCorrelative { get; set; }

        public string PathRutaFiles { get; set; }

        public string ExtensionFile { get; set; }

        public string segUsuarioActual { get; set; }

        /// <summary>
        /// Archivo: Datos de la forma de pago (RRRRRRRRRRR-CC-XXXX-999999999.PAG)
        /// </summary>
        public string NombreArchivoPAG { get; set; }

        /// <summary>
        /// Archivo: Detalles de la forma de pago al crédito (RRRRRRRRRRR-CC-XXXX-999999999.DPA)
        /// </summary>
        public string NombreArchivoDPA { get; set; }

    }
}

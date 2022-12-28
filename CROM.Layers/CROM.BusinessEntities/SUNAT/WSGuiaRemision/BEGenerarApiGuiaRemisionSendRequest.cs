using Newtonsoft.Json;

namespace CROM.BusinessEntities.SUNAT.WSGuiaRemision
{
    public class BEGenerarApiGuiaRemisionSendRequest
    {
        public BEGenerarApiGuiaRemisionSendRequest()
        {
            archivo = new BEApiGuiaRemisionArchivo();
        }

        public string UrlApiGuiaRemisionSUNAT { get; set; }


        /// <summary>
        /// RUC del contribuyente Emisor
        /// </summary>
        public string numRucEmisor { get; set; }

        /// <summary>
        /// Solo se permite
        /// 09: Guía de Remisión Remitente - Electrónica
        /// 31: Guía de Remisión Transportista - Electrónica
        /// </summary>
        public string codCpe { get; set; }

        /// <summary>
        /// Numero de serie de comprobante: Solo se permite:
        /// Si codCpe 09 => T###
        /// Si codCpe 31 => V###
        /// </summary>
        public string numSerie { get; set; }


        /// <summary>
        /// Número de comprobante => De 1 hasta 8 valores numéricos
        /// </summary>
        public string numCpe { get; set; }


        /// <summary>
        /// Authorization	Bearer + token(*)
        /// </summary>
        public string Token { get; set; }

        public BEApiGuiaRemisionArchivo archivo { get; set; }

        [JsonIgnore]
        public string UserLoginCurrent { get; set; }


        [JsonIgnore]
        public int codEmpresa { get; set; }
    }

    public class BEApiGuiaRemisionArchivo
    {
        public BEApiGuiaRemisionArchivo()
        {

        }

        public string RutanomArchivoZIP { get; set; }
        /// <summary>
        /// Nombre del archivo zip enviado.
        /// Estructura: RRRRRRRRRRR-TT-SSSS-NNNNNNNN.zip
        /// Donde: 
        /// RRRRRRRRRR: Número de RUC, de 11 valores numéricos
        /// TT: Tipo de comprobante, solo se permite 09 y 31
        /// SSSS: Serie del comprobante, solo se permite T### y V###
        /// NNNNNNNN: Número de comprobante, se permite de 1 hasta 8 valores numéricos
        /// </summary>
        public string nomArchivo { get; set; }

        /// <summary>
        /// Base 64 del archivo zip enviado
        /// </summary>
        public string arcGreZip { get; set; }

        /// <summary>
        /// Hash del archivo zip enviado
        /// Debe calcularse el hash del archivo zip haciendo uso del algoritmo SHA-256.
        /// </summary>
        public string hashZip { get; set; }

    }
}

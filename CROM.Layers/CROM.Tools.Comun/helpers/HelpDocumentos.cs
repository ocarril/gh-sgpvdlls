using System;

namespace CROM.Tools.Comun
{
    public static class HelpDocumentos
    {
        /// <summary>
        /// TIPOS DE DOCUMENTOS DE EMISION EN EL SISTEMA
        /// </summary>
        public enum Tipos
        {
            /// <summary>
            /// BOLETA DE VENTA
            /// </summary>
            BVT,
            /// <summary>
            /// COTIZACIONES
            /// </summary>
            COT,
            /// <summary>
            /// FACTURAS
            /// </summary>
            FCT,
            /// <summary>
            /// GUIAS DE FREMISIONES
            /// </summary>
            GRE,   
            /// <summary>
            /// INVENTARIOS
            /// </summary>
            INV,   
            /// <summary>
            /// NOTA DE COBRANZA
            /// </summary>
            NCB,
            /// <summary>
            /// NOTA DE CRÉDITO
            /// </summary>
            NCR,
            /// <summary>
            /// NOTA DE DÉBITO
            /// </summary>
            NDB,
            /// <summary>
            /// NOTA DE INGRESO
            /// </summary>
            NIN,
            /// <summary>
            /// NOTA DE PEDIDO
            /// </summary>
            NPD,
            /// <summary>
            /// NOTA DE SALIDA
            /// </summary>
            NSL,
            /// <summary>
            /// NOTA DE VENTA
            /// </summary>
            NVT,
            /// <summary>
            /// ORDEN DE COMPRA
            /// </summary>
            ORC,
            /// <summary>
            /// ORDEN DE PAGO
            /// </summary>
            OPG,
            /// <summary>
            /// OTROS
            /// </summary>
            OTR,
            RPG,
            /// <summary>
            /// TICKECT
            /// </summary>
            TCK,
            /// <summary>
            /// RECIBO POR HONORARIOS
            /// </summary>
            RPH
        }

        public enum EstadosFCT
        {
            EMITIDO,
            CANCELADO,
            ANULADO,
            PROCESADO
        }

        public enum Destino
        {
            CLIENTE,
            PROVEEDOR,
            INTERNO,
            NINGUNO
        }

        public static string ObtenerFormatNumeroDocumento(string pnumDocumento)
        {
            string misdestino = pnumDocumento.Trim();
            string misDocumentos = "";

            if (misdestino.Length == 0)
                return misDocumentos;

            string[] idsdestino = misdestino.Split(' ');
            foreach (string CADA_DOCUMENTO in idsdestino)
            {
                
                string numPosicion04 = CADA_DOCUMENTO.Substring(3, 1);

                string numSerie = string.Empty;
                string numNumero = string.Empty;
                if (char.IsDigit(Convert.ToChar(numPosicion04)))
                {
                    numSerie = CADA_DOCUMENTO.Substring(0, 6);
                    numNumero = CADA_DOCUMENTO.Substring(9, 7);
                }
                else
                {
                    numSerie = CADA_DOCUMENTO.Substring(3, 4);
                    numNumero = CADA_DOCUMENTO.Substring(9, 7);
                }
                string NUM_DOCUMENTO = string.Concat(numSerie, "-", numNumero);
                               
                misDocumentos = misDocumentos + (NUM_DOCUMENTO + ", ");
            }
            misDocumentos = misDocumentos.Substring(0, misDocumentos.Length - 2);

            return misDocumentos;
        }
    }
}

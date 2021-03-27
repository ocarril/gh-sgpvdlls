using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CROM.Tools.Comun
{
    public static class HelpDocumentos
    {
        /// <summary>
        /// TIPOS DE DOCUMENTOS DE EMISION EN EL SISTEMA
        /// </summary>
        public enum Tipos
        {
            BVT, /// BOLETA DE VENTA
            COT, /// COTIZACIONES
            FCT,
            GRE,
            INV,
            NCB,
            NCR,
            NDB,
            NIN,
            NPD,
            NSL,
            NVT,
            OCM,
            OPG,
            OTR,
            RPG,
            TCK,
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

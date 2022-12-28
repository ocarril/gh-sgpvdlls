using System.Collections.Generic;

namespace CROM.Tools.Comun.constants
{
    public static class ConstantsComercial
    {

        // TIPOS DE IMPUESTOS 
        public const string SUNAT_IMPU_IGV = "001";
        public const string SUNAT_IMPU_DSCTO = "002";
        public const string SUNAT_IMPU_IVARROZ_PILADO = "003";
        public const string SUNAT_IMPU_ISC = "004";
        public const string SUNAT_IMPU_EXPORTACION = "005";
        public const string SUNAT_IMPU_GRATUITO = "006";
        public const string SUNAT_IMPU_EXONERADO = "007";
        public const string SUNAT_IMPU_INAFECTO = "008";
        public const string SUNAT_IMPU_OTROS_TRIBUTOS = "009";

        public const string SUNAT_TipoDocumento_FACTURA = "01";
        public const string SUNAT_TipoDocumento_BOLETA_VENTA = "03";
        public const string SUNAT_TipoDocumento_BOLETA_TRANSPORTE = "06";
        public const string SUNAT_TipoDocumento_NOTA_CREDITO = "07";
        public const string SUNAT_TipoDocumento_NOTA_DEBITO = "08";
        public const string SUNAT_TipoDocumento_GUIA_REMISION = "09";
        public const string SUNAT_TipoDocumento_TICKET_MAQ_REGIST = "12";
        public const string SUNAT_TipoDocumento_RECIBO_SERV_PUBLICOS = "14";
        public const string SUNAT_TipoDocumento_BOLETO_SERV_TRANSP_URB = "15";
        public const string SUNAT_TipoDocumento_BOLETO_SERV_TRANSP_INTERPROV = "16";
        public const string SUNAT_TipoDocumento_COMPROBANTE_RETENCION = "20";
        public const string SUNAT_TipoDocumento_GUIA_REMISION_TRANSPORTISTA = "31";
        public const string SUNAT_TipoDocumento_SOLICITUD_BAJA = "99";
        public const string SUNAT_TipoDocumento_RESUMEN_DIARIO = "RD";


        public const string SUNAT_TipoDocumento_IDENTIDAD_SIN_RUC = "0";
        public const string SUNAT_TipoDocumento_IDENTIDAD_DNI = "1";
        public const string SUNAT_TipoDocumento_IDENTIDAD_CE = "4";
        public const string SUNAT_TipoDocumento_IDENTIDAD_RUC = "6";
        public const string SUNAT_TipoDocumento_IDENTIDAD_PASAPORTE = "7";
        public const string SUNAT_TipoDocumento_IDENTIDAD_CDI = "A";


        public const string SUNAT_ModalidadTransporte_PUBLICO = "01";
        public const string SUNAT_ModalidadTransporte_PRIVADO = "02";



        public const string SUNAT_GUIA_MotivoTraslado_Venta = "01";
        public const string SUNAT_GUIA_MotivoTraslado_Compra = "02";
        public const string SUNAT_GUIA_MotivoTraslado_VentaConEntrTerceros = "03";
        public const string SUNAT_GUIA_MotivoTraslado_TrasladoEEstMEmpresa = "04";
        public const string SUNAT_GUIA_MotivoTraslado_Consignacion = "05";
        public const string SUNAT_GUIA_MotivoTraslado_Devolucion = "06";
        public const string SUNAT_GUIA_MotivoTraslado_RecojoBienesTransfor = "07";
        public const string SUNAT_GUIA_MotivoTraslado_Importación = "08";
        public const string SUNAT_GUIA_MotivoTraslado_Exportación = "09";
        public const string SUNAT_GUIA_MotivoTraslado_Otros = "13";
        public const string SUNAT_GUIA_MotivoTraslado_VentaSujAConfDelComprador = "14";
        public const string SUNAT_GUIA_MotivoTraslado_TrasladoBienesParaTransform = "17";
        public const string SUNAT_GUIA_MotivoTraslado_TrasladoEmisorItinerante_CP = "18";
        public const string SUNAT_GUIA_MotivoTraslado_Traslado_a_zona_primaria = "19";





        public const string SUNAT_FOLDER_BARRAS = "BARRAS";
        public const string SUNAT_FOLDER_DATA = "DATA";
        public const string SUNAT_FOLDER_FIRMA = "FIRMA";
        public const string SUNAT_FOLDER_REPO = "REPO";
        public const string SUNAT_FOLDER_REPOPDF = "PDF";
        public const string SUNAT_FOLDER_RPTA = "RPTA";
        public const string SUNAT_FOLDER_ENVIO = "ENVIO";
        public const string SUNAT_FOLDER_BAJA = "BAJA";

        public const string SUNAT_NIVEL_GLOBAL = "Global";
        public const string SUNAT_NIVEL_ITEM = "Item";

        public const string SUNAT_TIPO_VARIABLE_CARGO = "CARGO";
        public const string SUNAT_TIPO_VARIABLE_DSCTO = "DESCUEN";

        public const int COMERCIAL_VENTA_CONTADO = 1;
        public const int COMERCIAL_VENTA_CREDITO = 2;
        public const int COMERCIAL_COMPRA_CONTADO = 3;
        public const int COMERCIAL_COMPRA_CREDITO = 4;

        public const string SUNAT_FILE_CAB_FCT_BLT = ".CAB";
        public const string SUNAT_FILE_CAB_NCR_NDB = ".NOT";
        public const string SUNAT_FILE_TRIBUTO = ".TRI";
        public const string SUNAT_FILE_LEYENDA = ".LEY";
        public const string SUNAT_FILE_DOC_REL = ".REL";
        public const string SUNAT_FILE_ADICIONAL = ".ACA";
        public const string SUNAT_FILE_PAGO = ".PAG";
        public const string SUNAT_FILE_PAGDETA = ".DPA";
        public const string SUNAT_FILE_BAJA_CBA = ".CBA";
        public const string SUNAT_FILE_ADIC_CABECERA_VARIABLE = ".ACV";

        public const string SUNAT_FILE_RESUMEN_BAJA_XML = "-RA-";
        public const string SUNAT_FILE_RESUMEN_BVTA_XML = "-RC-";
        public const string SUNAT_FILE_RESUMEN_REVER_XML = "-RR-";

        public const string COMERCIAL_Path_Compras = "Compras";
        public const string COMERCIAL_Path_Venta = "Ventas";
        public const string COMERCIAL_Path_Internas = "Internas";


        public const string DOCUMENTO_ESTADO_EMITIDA = "ESTLC001";
        public const string DOCUMENTO_ESTADO_SUNAT_ANULADA = "ESTLC002";
        public const string DOCUMENTO_ESTADO_PROTESTADA = "ESTLC003";
        public const string DOCUMENTO_ESTADO_CANCELADA = "ESTLC004";
        public const string DOCUMENTO_ESTADO_PENDIENTE = "ESTLC005";
        public const string DOCUMENTO_ESTADO_CERRADO = "ESTLC006";
        public const string DOCUMENTO_ESTADO_NACIONALIZADO = "ESTLC007";
        public const string DOCUMENTO_ESTADO_APROBADO = "ESTLC008";
        public const string DOCUMENTO_ESTADO_POR_PAGAR = "ESTLC009";
        public const string DOCUMENTO_ESTADO_ARCHIVADO = "ESTLC010";
        public const string DOCUMENTO_ESTADO_REFERENCIADO = "ESTLC011";
        public const string DOCUMENTO_ESTADO_PROCESADO = "ESTLC012";
        public const string DOCUMENTO_ESTADO_EN_PROCESO_SUNAT = "ESTLC013";
        public const string DOCUMENTO_ESTADO_SUNAT_ACEPTADA = "ESTLC014";
        public const string DOCUMENTO_ESTADO_RECEPCIONADO = "ESTLC015";
        public const string DOCUMENTO_ESTADO_SUNAT_SOLIC_BAJA = "ESTLC016";
        public const string DOCUMENTO_ESTADO_SUNAT_RECHAZADO_ANL = "ESTLC017";
        public const string DOCUMENTO_ESTADO_SUNAT_ACEPT_OBSERVADA = "ESTLC018";
        public const string DOCUMENTO_ESTADO_ANULADO = "ESTLC019";
        public const string DOCUMENTO_ESTADO_PAGADA_CANCELADA = "ESTLC020";


        public static Dictionary<string, string> dctEstadosDocumentos = new Dictionary<string, string>()
        {
            {"ESTLC001","EMITIDA"},
            {"ESTLC002","SUNAT-ANULADA"},
            {"ESTLC003","PROTESTADA"},
            {"ESTLC004","CANCELADA"},
            {"ESTLC005","PENDIENTE"},
            {"ESTLC006","CERRADO"},
            {"ESTLC007","NACIONALIZADO"},
            {"ESTLC008","APROBADO"},
            {"ESTLC009","POR PAGAR"},
            {"ESTLC010","ARCHIVADO"},
            {"ESTLC011","REFERENCIADO"},
            {"ESTLC012","PROCESADO"},
            {"ESTLC013","EN-PROCESO SUNAT"},
            {"ESTLC014","SUNAT-ACEPTADA"},
            {"ESTLC015","RECEPCIONADO"},
            {"ESTLC016","SUNAT-SOLIC-BAJA"},
            {"ESTLC017","SUNAT-RECHAZADO-ANL"},
            {"ESTLC018","SUNAT-ACEPT-OBSERVADA"},
            {"ESTLC019","ANULADO"},
            {"ESTLC020","PAGADA-CANCELADA" }
        };

        public static Dictionary<string, string> ConsultaWS_estadoCp = new Dictionary<string, string>()
        {
          { "0",  "NO EXISTE. (COMPROBANTE NO INFORMADO)" },
          { "1",  "ACEPTADO. (COMPROBANTE ACEPTADO)." },
          { "2",  "ANULADO. (COMUNICADO EN UNA BAJA)" },
          { "3",  "AUTORIZADO. (CON AUTORIZACIÓN DE IMPRENTA)" },
          { "4",  "NO AUTORIZADO. (NO AUTORIZADO POR IMPRENTA)" }
        };

        public static Dictionary<string, string> ConsultaWS_estadoRuc = new Dictionary<string, string>()
        {
          { "00",  "ACTIVO" },
          { "01",  "BAJA PROVISIONAL" },
          { "02",  "BAJA PROV. POR OFICIO" },
          { "03",  "SUSPENSION TEMPORAL" },
          { "10",  "BAJA DEFINITIVA" },
          { "11",  "BAJA DE OFICIO" },
          { "22",  "INHABILITADO-VENT.UNICA" }
        };

        public static Dictionary<string, string> ConsultaWS_condDomiRuc = new Dictionary<string, string>()
        {
          { "00",  "HABIDO" },
          { "09",  "PENDIENTE" },
          { "11",  "POR VERIFICAR" },
          { "12",  "NO HABIDO" },
          { "20",  "NO HALLADO" }
        };

        public static Dictionary<string, string> EstadoDelItemResumenDiario = new Dictionary<string, string>()
        {
          { "1",  "ADICIONAR" },
          { "2",  "MODIFICAR" },
          { "3",  "ANULADO" },
          { "4",  "ANULADO EN EL DÍA (anulado antes de informar comprobante)" }
        };


        public enum CodigoNotaCREDITO
        {
            NC_01_ANULA_OPERACION = 1,
            NC_02_ANULA_OPERACION_RUC = 2,
            NC_03_CORRECCION_DESCRIPCION = 3,
            NC_04_DESCUENTO_GLOBAL = 4,
            NC_05_DESCUENTO_POR_ITEM = 5,
            NC_06_DEVOLUCION_TOTAL = 6,
            NC_07_DEVOLUCION_POR_ITEM = 7,
            NC_08_BONIFICACION = 8,
            NC_09_DISMINUCION_VALOR = 9,
            NC_13_AJUSTES_MONT_FEC_PAGO = 13
        };

        public enum CodigoNotaDEBITO
        {
            ND_01_INTERESES_X_MORA = 1,
            ND_02_AUMENTO_EN_EL_VALOR = 2,
            ND_03_PENALIDAD_OTR_CONCEPTOS = 3
        };

        public static Dictionary<string, string> EstadoTicketGuiaRemision = new Dictionary<string, string>()
        {
          { "0",   "N° GUIA:{0}:  ENVIO OK" },
          { "98",  "N° GUIA:{0}:  ENVÍO DE DOCUMENTO EN PROCESO" },
          { "991", "N° GUIA:{0}:  ENVÍO CON ERROR, CON GENERACIÓN DE CDR" },
          { "990", "N° GUIA:{0}:  Envío CON ERROR, NO GENERA CDR" }
        };


    }
}
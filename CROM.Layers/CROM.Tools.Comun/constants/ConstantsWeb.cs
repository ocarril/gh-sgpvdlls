namespace CROM.Tools.Comun.Web
{
    using System.Collections.Generic;


    public static class WebConstants
    {
        // TIPO DE PERSONA
        public const string DEFAULT_PersJuridica = "PASIG001";
        public const string DEFAULT_PersonaNatural = "PASIG002";

        // ATRIBUTOS DE LAS PERSONAS
        public const string DEFAULT_PersonaFonos = "PATRB002";
        public const string DEFAULT_PersonaDocumento = "PATRB003";
        public const string DEFAULT_PersonaCorreo = "PATRB004";

        // DOCUMENTOS - DESTINO DE COMPROBANTES
        public const string DEFAULT_DOCUM_DESTINADO_CLIENTES = "GDSTC001";
        public const string DEFAULT_DOCUM_DESTINADO_PROVEEDORES = "GDSTC002";
        public const string DEFAULT_DOCUM_DESTINADO_INTERNO = "GDSTC003";

        // MONEDA - TIPO DE MONEDA SEGUN SUNAT
        public const string DEFAULT_TIPO_MONEDA_SUNAT_SOLES = "PEN";
        public const string DEFAULT_TIPO_MONEDA_SUNAT_DOLAR = "USD";
        public const string DEFAULT_TIPO_MONEDA_SOLES = "GTMND001";
        public const string DEFAULT_TIPO_MONEDA_DOLAR = "GTMND002";

        public const string DEFAULT_Owner = "OMGC$";
        public const string DEFAULT_Clave = "OMcrGCpn$";
        public const string DEFAULT_SeguridadKey = "CROMGCPN";

        public const string DEFAULT_OK = "OK";

        // ESTADO DE LA LETRA DE CAMBIO
        public const int DEFAULT_EstadoDeLetra_POR_PAGAR = 52;
        public const int DEFAULT_EstadoDeLetra_PAGADA_CANCELADA = 53;
        public const int DEFAULT_EstadoDeLetra_PROTESTADA = 54;
        public const int DEFAULT_EstadoDeLetra_ANULADA = 55;

        #region VARIABLES CONSTANTES

        public const string METHOD_POST = "POST";
        public const string METHOD_GET = "GET";
        public const string METHOD_PUT = "PUT";
        public const string METHOD_DELETE = "DELETE";

        public const string SERVICE_RESPONSE_ERROR_CODE = "errorCode";
        public const string SERVICE_OK = "Resultado satisfactorio.";
        public const string SERVICE_ERROR = "No se ha identificado parámetros al servicio.";
        public const string ENTIDAD_ESTRUCTURA_GEOM_COLUMN_NAME = "geom";
        public const string CONTENT_TYPE_IMAGE_PNG = "image/png";
        public const string DEFAULT_CHAR_SET = "utf-8";

        public const string CONTENT_TYPE_JSON = "application/json";
        public const string CONTENT_TYPE_XML = "application/xml";
        public const string CONTENT_TYPE_TEXT_PLAIN = "text/plain";
        public const string CONTENT_TYPE_TEXT_XML = "text/xml;charset=UTF-8";
        public const string CONTENT_TYPE_JSON_UTF8 = "application/json;charset=utf-8";
        public const string CONTENT_TYPE_OGC_SLD_XML = "application/vnd.ogc.sld+xml";

        public const string FILE_JSON_EXTENSION = ".json";
        public const string FILE_XML_EXTENSION = ".xml";
        public const string FILE_ZIP_EXTENSION = ".zip";
        public const string FILE_PDF_EXTENSION = ".zip";
        public const string FILE_XLSX_EXTENSION = ".xlsx";

        public const string REQUEST_HEADER_AUTHORIZATION_SCHEME = "Bearer";
        public const string URI_SEGMENT_SEPARATOR = "/";
        public const string URI_PARAMETER_SEPARATOR = "?";
        public const string ValorParametroIncorrecto = "El Valor del Parámetro \"{0}\" es incorrecto.";
        public const string PAIS_ORIGEN = "es-PE";

        public const string PathImages = "Content/Images/";

        public const string URI_SEGURIDAD_POST_VALIDATE_USER = "/api/security/getvalidateuser";
        public const string URI_SEGURIDAD_POST_LIST_USER_OBJECTS_GRANTS = "/api/security/listuserobjectsgrants";

        public const string JQ_SORT_ORDER_ASC = "ASC";
        public const string JQ_SORT_ORDER_DESC = "DESC";
        public const string JQ_SORT_COLUMN_PERSONA = "RAZONSOCIAL";
        public const string JQ_SORT_COLUMN_NOMBRE = "DESNOMBRE";

        #endregion


        public enum TypeError
        {
            NO_UPDATE = 0,
            WARNING = -406
        }


        public enum TipoEncriptacion
        {
            SQLDLL,
            EXTDLL
        }

        public enum TipoRegistro
        {
            EMPLEADO = 1,

        }

        public enum TipoOpcionPermiso
        {
            MENU = 1,
            CONTROL = 2,
            PAGINA = 3,
            ACTION = 4
        }

        public enum TipoDomicilio
        {
            FISCAL_PRINCIPAL = 1,
            CASA_MATRIZ = 2,
            SUCURSAL = 3,
            AGENCIA = 4,
            LOCAL_COMERCIAL_SERV = 5,
            SEDE_PRODUCTIVA = 6,
            DEPOSITO_ALMACEN = 7,
            OFICINA_ADMINISTRATIVA = 8
        }

        public enum DatoUbigeo
        {
            UbigeoCodigo = 1,
            UbigeoNombre = 2,
            Domicilio = 3
        };

        public enum TipoArchivo
        {
            Imagenes = 1,
            Documentos = 2,
            Archivos = 3
        };

        public enum TipoEntidad
        {
            Personas = 1,
            Productos = 2,
            Documentos = 3,
            Logos = 4
        };

        public enum OrigenApp
        {
            WINDOWS = 1,
            WEB = 2
        };

        public enum OrigenPeticionDocSUNAT
        {
            BAND_FACTURA_BOLETA = 1,
            BAND_NOTA_CRED_DEBI = 2,
            BAND_RESUMEN_DIARIO = 3,
            BAND_GUIA_REMISION = 4
        };

        public static Dictionary<int, string> MensajesServicios = new Dictionary<int, string>()
        {
          { 100,  "Registrado satisfactoriamente." },
          { 101,  "Actualizado satisfactoriamente." },
          { 102,  "Eliminado satisfactoriamnte." },
          { 103,  "Tipo de cambio ya existe para la fecha: [ {0} ]" },
          { 104,  "Código de producto ya existe: [ {0} ]" },
          { 105,  "Asignar grupo al producto." },
          { 106,  "Asignar código al producto." },
          { 107,  "Asignar código de referencia al producto." },
          { 108,  "Ingresar nombre al producto." },
          { 109,  "Ingresar nombre comercial." },
          { 110,  "Ingresar descripción abreviada." },
          { 111,  "Asignar el tipo de producto." },
          { 112,  "Asignar unidad de medida." },
          { 113,  "Asignar categoría de producto." },
          { 114,  "Registro de {0} no existe." },
        };

        public static Dictionary<int, string> ErroresEjecucion = new Dictionary<int, string>()
        {
          { 1000,  "Ejecución correcta." },
          { 1001,  "Error Interno." },
          { 1002,  "Error en Autenticación." },
          { 1003,  "Error de Parámetros." },
          { 1004,  "Error de Consistencia de Datos." },
          { 1005,  "Error de Límites de Uso del Servicio." },
          { 1006,  "Error. Valor de cabecera no existe." },
          { 1007,  "Error de Dato de autorización." },
          { 1008,  "Alerta. La sesión ya ha caducado." }
        };

        public static Dictionary<int, string> ValidacionDatosSEGURIDAD = new Dictionary<int, string>()
        {
          { 2000,  "Ingreso al sistema satisfactoriamente."},
          { 2001,  "Datos no identificados." },
          { 2002,  "Ingresar login/cuenta de usuario." },
          { 2003,  "Ingresar contraseña de usuario." },
          { 2004,  "Cuenta de usuario y/o contraseña inválida." },
          { 2005,  "Datos no identificados." },
          { 2006,  "Usuario no esta asignado a una empresa." },
          { 2007,  "Usuario no esta asignado a un sistema." },
          { 2008,  "Usuario no esta asignado a un rol." },
          { 2009,  "Sistema no identificado." },
          { 2010,  "Sistema no identificado para la empresa." },
          { 2011,  "Licencia vencida para la empresa: {0} - Hasta : {1}" },
          { 2012,  "Usuario de sistema no tiene rol asignado." },
          { 2013,  "Esta intentando : [ {0} ] veces ingresar al sistema. Credenciales incorrectas." },
          { 2014,  "TOKEN no ha sido validado."},
          { 2015,  "Usuario identificado no pertenece a la empresa."},
          { 2016,  "No existe configurado empresa como cliente en la base de datos."},
          { 2017,  "El usuario no se encuentra registrado."},
          { 2018,  "Ingresar nueva contraseña de usuario." },
          { 2019,  "Ingresar confirmación de contraseña." },
          { 2020,  "Contraseña de confirmación es incorrecta." },
          { 2021,  "Se cambio la contraseña de usuario con exito." },
          { 2022,  "Se produjo un error al modificar el Password. consulte con el administrador." },
          { 2023,  "Se envió correo de cambio de contraseña con exito." },
          { 2024,  "Correo de solicitud no se envió con éxito." },
          { 2025,  "Cuenta de usuario se encuentra bloqueada desde [ {0} ]." },
          { 2026,  "Cuenta de usuario esta pendiente de cambio de contraseña." },
          { 2027,  "Contraseña de usuario es inválida." },

        };

        public static Dictionary<int, string> ValidacionDatosComercial = new Dictionary<int, string>()
        {
          { 3000,  "Datos no identificados."},
          { 3001,  "Documento no cuenta con detalle/items." },
          { 3002,  "Documento no tiene asignado destino." },
          { 3003,  "Documento no tiene asignado entidad {0}." },
          { 3004,  "Documento no tiene asignado tipo de documento." },
          { 3005,  "Documento no tiene asignado empleado." },
          { 3006,  "Documento no tiene asignado moneda." },
          { 3007,  "Documento no tiene asignado empresa." },
          { 3008,  "Documento no tiene asignado punto de venta." },
          { 3009,  "Documento no tiene asignado dirección." },
          { 3010,  "Documento no tiene asignado razón social." },
          { 3011,  "Documento no tiene asignado número de R.U.C." },
          { 3012,  "Documento no tiene asignado nombre de ubigeo." },
          { 3013,  "TOKEN no identificado." },
          { 3014,  "ID de documento no identificado."},
          { 3015,  "Se importaron [ {0} ] items Fal documento."},
          { 3016,  "No se ha encontrado ningun documento XML FIRMADO por SFS-SUNAT." },
          { 3017,  "No se ha encontrado ningun documento XML/ZIP RESPUESTA por SFS-SUNAT." },
          { 3018,  "El número de cuotas debe ser mayor que cero."},
          { 3019,  "Seleccionar el tipo de plazo para cada cuota del credito."},
          { 3020,  "El valor pendiente de pago debe ser mayor que cero."},
          { 3021,  "Seleccionar condición de forma de pago para el docuemnto."},
          { 3022,  "No ha seleccionados mínimo un N° de cuota para pagar el crédito."},
          { 3023,  "Servicio Web de la SUNAT para enviar Guia de remisión no esta disponible."},
          { 3024,  "Documento [ {0} - {1} ] FUE enviado a SUNAT con EXITO."},
          { 3025,  "Documento [ {0} - {1} ] NO FUÉ enviado a SUNAT con EXITO." },
          { 3026,  "No se ha generado documento XML de [ {0} - {1} ] para enviar a SUNAT." },
          { 3027,  "Archivos planos SUNAT del documento no se ha creado con EXITO." },
          { 3028,  "Archivos para SFS creados OK N°: [{0}] - : [{1}]" },
          { 3029,  "Documento [ {0} - {1} / .ZIP ] FUE creado con EXITO."},
          { 3030,  "No se ha creado Zip de Documento [ {0} - {1} ]."},
          { 3031,  "Documento [ {2} ] CREADO, FIRMADO por Enviar a SUNAT N°: [ {0} ] - [ {1} ]"},
          { 3032,  "Documento [ {2} ] CREADO, FIRMADO y ENVIADO a  SUNAT N°: [ {0} ] - [ {1} ]"},
          { 3033,  "La generación de archivos DATA para el facturador SUNAT NO fue exitoso : [ {0} ] "},
          { 3034,  "Documento SUNAT no tiene detalle de pagos/cuotas a CRÉDITO  : [ {0} ] - [ {1} ]"},
          { 3035,  "Documento SUNAT: [ {0} ], enviado por correo satisfactoriamente al cliente: [ {1} ]."},
          { 3036,  "Documento SUNAT: [ {0} ], NO se envió por correo satisfactoriamente."},
          { 3037,  "Documento SUNAT: [ {0} ], ya fue enviado. Tiene archivo de RPTA: [ {1} ]"},
          { 3038,  "Documento SUNAT: [ {0} ] XML VALIDADO en SFS N°: [ {1} ]"},
          { 3039,  "La actualización por validación XML de SFS NO FUE EXITOSO : [ {0} ] "},
          { 3040,  "Error al momento de leer el archivo : [ {0} ] - Documento: [ {1} ]"},
          { 3041,  "Archivo de BAJA XML VALIDADO en SFS N°: [ {0} ] - : [ {1} ]"},
          { 3042,  "Archivos para SFS creados OK N°: [ {0} ] - : [ {1} ]"},
          { 3043,  "La generación de archivos DATA para el facturador SUNAT NO FUE EXITOSO : [{0}] "},
          { 3044,  "No existe documento seleccionado para dar de BAJA."},
          { 3045,  "Comunicación de baja: [ {0} ], creado satisfactoriamente."},
          { 3046,  "Comunicación de baja no creado."},
          { 3047,  "La actualización por envio de SFS NO FUE EXITOSO : [ {0} ]"},
          { 3048,  "ZIP BAJA ENVIADO-PROCESADO por SFS N°: [ {0} ] - : [ {1} ]"},
          { 3049,  "ZIP BAJA ENVIADO por SFS N°: [ {0} ] - : [ {1} ]"},
        };

    }
}

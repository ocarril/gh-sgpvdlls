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

        // MONEDA - TIPO DE MONEDA SEGUN SUNAT
        public const string DEFAULT_TIPO_UNIDAD_MEDIDA_GRE = "PMEDI009";

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
        public const string CONTENT_TYPE_X_WWW_FORM = "application/x-www-form-urlencoded";

        public const string FILE_JSON_EXTENSION = ".json";
        public const string FILE_XML_EXTENSION = ".xml";
        public const string FILE_ZIP_EXTENSION = ".zip";
        public const string FILE_PDF_EXTENSION = ".zip";
        public const string FILE_XLSX_EXTENSION = ".xlsx";
        public const string FILE_PNG_EXTENSION = ".png";

        public const string REQUEST_HEADER_AUTHORIZATION_SCHEME = "Bearer";
        public const string URI_SEGMENT_SEPARATOR = "/";
        public const string URI_PARAMETER_SEPARATOR = "?";
        public const string ValorParametroIncorrecto = "El Valor del Parámetro \"{0}\" es incorrecto.";
        public const string PAIS_ORIGEN = "es-PE";

        public const string PathImages = @"Content\Images\";
        public const string PathLogos = @"content\logos\";

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
            WEB = 2,
            WEB_API = 3
        };

        public enum OrigenPeticionDocSUNAT
        {
            BAND_FACTURA_BOLETA = 1,
            BAND_NOTA_CRED_DEBI = 2,
            BAND_RESUMEN_DIARIO = 3,
            BAND_GUIA_REMISION = 4,
            BAND_DOCUMENTO_EMIS = 5
        };

        public enum TipoENCODING
        {
            UTF8 = 1,
            ISO_8859_1 = 2,
            UTF32 = 3,
            UTF7= 4,
            Unicode = 5,
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
          { 1008,  "Alerta. La sesión ya ha caducado." },
          { 1010,  "WS Sunat de consulta no respondio con éxito." },
          { 1011,  "WS Sunat de GRE no respondio con éxito." },

        };

        public static Dictionary<int, string> ValidacionDatosSEGURIDAD = new Dictionary<int, string>()
        {
          { 2000,  "Ingreso al sistema satisfactoriamente. {0} "},
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
          { 3019,  "Seleccionar el tipo de plazo para cada cuota del crédito."},
          { 3020,  "El valor pendiente de pago debe ser mayor que cero."},
          { 3021,  "Seleccionar condición de forma de pago para el documento."},
          { 3022,  "No ha seleccionados mínimo un N° de cuota para pagar el crédito."},
          { 3023,  "Servicio Web de la SUNAT para enviar Guia de remisión no esta disponible."},
          { 3024,  "Documento [ {0} - {1} ] FUE enviado a SUNAT con EXITO."},
          { 3025,  "Documento [ {0} - {1} ] NO FUÉ enviado a SUNAT con EXITO." },
          { 3026,  "No se ha generado documento XML de [ {0} - {1} ] para enviar a SUNAT." },
          { 3027,  "Archivos SFS SUNAT del documento no se ha creado con EXITO." },
          { 3028,  "Archivos SFS OK N°: [{0}] - [{1}]" },
          { 3029,  "Documento [ {0} - {1} / .ZIP ] FUE creado con EXITO."},
          { 3030,  "No se ha creado Zip de Documento [ {0} - {1} ]."},
          { 3031,  "Documento [ {2} ] CREADO, FIRMADO. <BR> Documento: [ {0} ] - [ {1} ] por Enviar a SUNAT"},
          { 3032,  "Documento [ {2} ] CREADO, FIRMADO y ENVIADO a  SUNAT. <BR> N°: [ {0} ] - [ {1} ]"},
          { 3033,  "La generación de archivos DATA para el facturador SUNAT NO fue exitoso : [ {0} ] "},
          { 3034,  "Documento no tiene detalle de pagos/cuotas a CRÉDITO: [ {0} ] - [ {1} ]"},
          { 3035,  "Documento: [ {0} ], enviado por correo satisfactoriamente al cliente: [ {1} ]."},
          { 3036,  "Documento: [ {0} ], NO se envió por correo satisfactoriamente."},
          { 3037,  "Documento: [ {0} ], ya fue enviado. Tiene archivo de RPTA: [ {1} ]"},
          { 3038,  "Documento: [ {0} ] - [ {1} ] XML Validado SFS/WS"},
          { 3039,  "La actualización por validación XML de SFS NO FUE EXITOSO : [ {0} ] "},
          { 3040,  "Error al momento de leer el archivo : [ {0} ] - Documento: [ {1} ]"},
          { 3041,  "Archivo de BAJA XML VALIDADO en SFS N°: [ {0} ] : [ {1} ]"},
          { 3042,  "Archivos para SFS creados OK N°: [ {0} ] - [ {1} ]"},
          { 3043,  "La generación de archivos DATA para el facturador SUNAT NO FUE EXITOSO : [{0}] "},
          { 3044,  "No existe documento seleccionado para dar de BAJA."},
          { 3045,  "Comunicación de baja: [ {0} ], creado satisfactoriamente."},
          { 3046,  "Comunicación de baja no creado."},
          { 3047,  "La actualización por envio de SFS NO FUE EXITOSO : [ {0} ]"},
          { 3048,  "ZIP BAJA ENVIADO-PROCESADO por SFS N°: [ {0} ] - [ {1} ]"},
          { 3049,  "ZIP BAJA ENVIADO por SFS N°: [ {0} ] - [ {1} ]"},
          { 3050,  "Documento N°: [ {0} - {1}-{2} ], fue ANULADO/DADO DE BAJA con éxito."},
          { 3051,  "Documento N°: [ {0} - {1}-{2} ], NO fue ANULADO/DADO DE BAJA con éxito."},
          { 3052,  "Correlativo para resumen diario no se ha generado."},
          { 3053,  "[ {0} ] actualizado para envio por Resumen diario."},
          { 3054,  "[ {0} ] validado y pendiente de envio por Resumen diario."},
          { 3055,  "Se actualizaron para RESUMEN DIARIO: [ {0} ] de [ {1} ] Documentos electrónicos."},
          { 3056,  "No se encontraron documentos electrónicos para RESUMEN DIARIO."},
          { 3057,  "Resumen Diario [ {0} ] NO FUÉ enviado a SUNAT con EXITO." },
          { 3058,  "Resumen Diario [ {0} ] creado con EXITO."},
          { 3059,  "Servicio Web de la SUNAT para enviar Resumen Diario no esta disponible /ERROR."},
          { 3060,  "Resumen Diario [ {0} ] FUE enviado a SUNAT con EXITO."},
          { 3061,  "No se ha generado XML de resumen diario [ {0} ] para enviar a SUNAT." },
          { 3062,  "Opción no válida para enviar resumen diario a SUNAT." },
          { 3063,  "Se actualizó N° de tickect [{0}] para resumen diario: [{1}]." },
          { 3064,  "NO Se actualizó N° de tickect para resumen diario: [{0}]." },
          { 3065,  "Alerta : Documento [ {0} ] aún no tiene registrado N° de ticket." },
          { 3066,  "Pendiente de baja: [ {0} ], creado satisfactoriamente."},
          { 3067,  "Aun no esta habilitado para emitir Guías de Remisión Electrónica. A partir de: [ {0} ]"},
          { 3068,  "Archivo generado y enviado a la SUNAT con exito. CDR: [ {0} ]"},
          { 3069,  "Se archiva documento, sin uso de referencia: [ {0} ]"},
        };


        public static Dictionary<string, string> ValidacionWS_SUNAT = new Dictionary<string, string>()
        {
          {"env:Server", "Internal Error (from server)"},
          {"soap:Server", "0100"},
          {"100", "soap:Server"},
          {"soap-env:Client.0132", "El sistema no puede responder su solicitud. (No se pudo grabar escribir en el archivo zip)"},
          {"132", "El sistema no puede responder su solicitud. (No se pudo grabar escribir en el archivo zip)"},
          {"soap-env:Client.0109", "El sistema no puede responder su solicitud. (El servicio de autenticación no está disponible)"},
          {"109", "El sistema no puede responder su solicitud. (El servicio de autenticación no está disponible)"},
          {"soap-env:Client.0402", "La numeracion o nombre del documento ya ha sido enviado anteriormente"},
          {"402", "La numeracion o nombre del documento ya ha sido enviado anteriormente"},
          {"soap-env:Client.0200", "No se pudo procesar su solicitud. (Ocurrio un error en el batch)"},
          {"133", "El sistema no puede responder su solicitud. (No se pudo grabar la entrada del log)"},
          {"154", "El RUC del archivo no corresponde al RUC del usuario o el proveedor no esta autorizado a enviar comprobantes del contribuyente"},
          {"200", "No se pudo procesar su solicitud. (Ocurrio un error en el batch)"},
          {"0100", "El sistema no puede responder su solicitud. Intente nuevamente o comuníquese con su Administrador"},
          {"0101", "El encabezado de seguridad es incorrecto"},
          {"0102", "Usuario o contraseña incorrectos"},
          {"0103", "El Usuario ingresado no existe"},
          {"0104", "La Clave ingresada es incorrecta"},
          {"0105", "El Usuario no está activo"},
          {"0106", "El Usuario no es válido"},
          {"0109", "El sistema no puede responder su solicitud. (El servicio de autenticación no está disponible)"},
          {"0110", "No se pudo obtener la informacion del tipo de usuario"},
          {"0111", "No tiene el perfil para enviar comprobantes electronicos"},
          {"0112", "El usuario debe ser secundario"},
          {"0113", "El usuario no esta afiliado a Factura Electronica"},
          {"0125", "No se pudo obtener la constancia"},
          {"0126", "El ticket no le pertenece al usuario"},
          {"0127", "El ticket no existe"},
          {"0130", "El sistema no puede responder su solicitud. (No se pudo obtener el ticket de proceso)"},
          {"0131", "El sistema no puede responder su solicitud. (No se pudo grabar el archivo en el directorio)"},
          {"0132", "El sistema no puede responder su solicitud. (No se pudo grabar escribir en el archivo zip)"},
          {"0133", "El sistema no puede responder su solicitud. (No se pudo grabar la entrada del log)"},
          {"0134", "El sistema no puede responder su solicitud. (No se pudo grabar en el storage)"},
          {"0135", "El sistema no puede responder su solicitud. (No se pudo encolar el pedido)"},
          {"0136", "El sistema no puede responder su solicitud. (No se pudo recibir una respuesta del batch)"},
          {"0137", "El sistema no puede responder su solicitud. (Se obtuvo una respuesta nula)"},
          {"0138", "El sistema no puede responder su solicitud. (Error en Base de Datos)"},
          {"0151", "El nombre del archivo ZIP es incorrecto"},
          {"0152", "No se puede enviar por este método un archivo de resumen"},
          {"0153", "No se puede enviar por este método un archivo por lotes"},
          {"0154", "El RUC del archivo no corresponde al RUC del usuario o el proveedor no esta autorizado a enviar comprobantes del contribuyente"},
          {"0155", "El archivo ZIP esta vacio"},
          {"0156", "El archivo ZIP esta corrupto"},
          {"0157", "El archivo ZIP no contiene comprobantes"},
          {"0158", "El archivo ZIP contiene demasiados comprobantes para este tipo de envío"},
          {"0159", "El nombre del archivo XML es incorrecto"},
          {"0160", "El archivo XML esta vacio"},
          {"0161", "El nombre del archivo XML no coincide con el nombre del archivo ZIP"},
          {"0200", "No se pudo procesar su solicitud. (Ocurrio un error en el batch)"},
          {"0201", "No se pudo procesar su solicitud. (Llego un requerimiento nulo al batch)"},
          {"0202", "No se pudo procesar su solicitud. (No llego información del archivo ZIP)"},
          {"0203", "No se pudo procesar su solicitud. (No se encontro archivos en la informacion del archivo ZIP)"},
          {"0204", "No se pudo procesar su solicitud. (Este tipo de requerimiento solo acepta 1 archivo)"},
          {"0250", "No se pudo procesar su solicitud. (Ocurrio un error desconocido al hacer unzip)"},
          {"0251", "No se pudo procesar su solicitud. (No se pudo crear un directorio para el unzip)"},
          {"0252", "No se pudo procesar su solicitud. (No se encontro archivos dentro del zip)"},
          {"0253", "No se pudo procesar su solicitud. (No se pudo comprimir la constancia)"},
          {"0300", "No se encontró la raíz documento xml"},
          {"0301", "Elemento raiz del xml no esta definido"},
          {"0302", "Codigo del tipo de comprobante no registrado"},
          {"0303", "No existe el directorio de schemas"},
          {"0304", "No existe el archivo de schema"},
          {"0305", "El sistema no puede procesar el archivo xml"},
          {"0306", "No se puede leer (parsear) el archivo XML"},
          {"0307", "No se pudo recuperar la constancia"},
          {"0400", "No tiene permiso para enviar casos de pruebas"},
          {"0401", "El caso de prueba no existe"},
          {"0402", "La numeracion o nombre del documento ya ha sido enviado anteriormente"},
          {"0403", "El documento afectado por la nota no existe"},
          {"0404", "El documento afectado por la nota se encuentra rechazado"},

        };
    }
}
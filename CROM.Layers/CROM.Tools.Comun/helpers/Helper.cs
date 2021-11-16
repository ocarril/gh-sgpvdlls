using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Reflection;
using System.Data;
using System.Globalization;
using System.IO;
using System.Drawing;
using System.Security.Cryptography;
using System.Threading;
using System.Diagnostics;
using System.Xml.Serialization;
using CROM.Tools.Comun.settings;

namespace CROM.Tools.Comun
{
    public static class Helper
    {
        public enum ValorSiNo
        {
            S,
            N
        }

        public enum CategEvento
        {
            LIST = 0,
            INSERT = 1,
            UPDATE = 2,
            DELETE = 3,
            TRANSACTION = 4,
            MESSAGE = 5,
            OK
        }

        public enum FormatTipo
        {
            Descripcion,
            Codigo
        }

        public enum TablaReporte
        {
            Documento, // ya
            DocumentoImpuesto, // ya
            DocumentoSerie, // ya
            CondicionCompra,// ya
            CondicionVenta, // ya
            Feriado,
            FormaDePago, // ya
            ListaDePrecio,
            ParteDiario, // ya
            ParteDiarioTurno, // ya
            Persona, Producto,  // ya
            ProductoCompuesto,
            PuntoDeVenta, // ya
            ReporteSistema,
            TablasMaestra,
            TablasMaestrasRegistro,
            Impuesto, // ya
            GrupoDeProducto, // ya
            ParteAtributo, // ya
            TipoDeCambio,
            Inventario,
            Auditorias
        }

        public static string CaptionDeMessageBox()
        {
            string nameProgram = AppDomain.CurrentDomain.FriendlyName;
            string Titulo = "[ " + nameProgram.Substring(0, nameProgram.Length - 4) + " ] - Verificar !";
            return (Titulo);
        }

        public static class Converter<T> where T : new()
        {
            public static DataTable ConvertList(List<T> items)
            {
                // Instancia del objeto a devolver
                DataTable returnValue = new DataTable();
                // Información del tipo de datos de los elementos del List
                Type itemsType = typeof(T);
                // Recorremos las propiedades para crear las columnas del datatable
                foreach (PropertyInfo prop in itemsType.GetProperties())
                {
                    // Crearmos y agregamos una columna por cada propiedad de la entidad
                    DataColumn column = new DataColumn(prop.Name);
                    string nombreFull = prop.PropertyType.FullName;
                    if (nombreFull.ToLower().Substring(0, 10) != "system.nul")
                        column.DataType = prop.PropertyType;
                    else
                    {
                        column.AllowDBNull = true;
                        if (nombreFull.ToLower().IndexOf("system.date") != -1)
                            column.DataType = typeof(DateTime);
                        if (nombreFull.ToLower().IndexOf("system.bool") != -1)
                            column.DataType = typeof(Boolean);
                        if (nombreFull.ToLower().IndexOf("system.int") != -1)
                            column.DataType = typeof(Int32);
                        if (nombreFull.ToLower().IndexOf("system.stri") != -1)
                            column.DataType = typeof(String);
                        if (nombreFull.ToLower().IndexOf("system.decim") != -1)
                            column.DataType = typeof(Decimal);
                    }
                    returnValue.Columns.Add(column);
                }

                int j;
                // ahora recorremos la colección para guardar los datos
                // en el DataTable
                foreach (T item in items)
                {
                    j = 0;
                    object[] newRow = new object[returnValue.Columns.Count];
                    // Volvemos a recorrer las propiedades de cada item para
                    // obtener su valor guardarlo en la fila de la tabla
                    foreach (PropertyInfo prop in itemsType.GetProperties())
                    {
                        newRow[j] = prop.GetValue(item, null);
                        j++;
                    }
                    returnValue.Rows.Add(newRow);
                }
                // Devolver el objeto creado
                return returnValue;
            }

            public static T ConvertItem(DataRowView item)
            {
                Type itemsType = typeof(T);
                int cols = 0;
                Object oObjeto = Activator.CreateInstance(itemsType);
                foreach (PropertyInfo myProp in itemsType.GetProperties())
                {
                    if (!(item.Row.ItemArray[cols] is DBNull))
                        myProp.SetValue(oObjeto, item.Row.ItemArray[cols], null);
                    cols++;
                }
                return (T)oObjeto;
            }

            public static List<string> ListaDeAtributos() //System.Type t
            {
                List<string> lstNameFields = new List<string>();
                Type itemsType = typeof(T);
                Object oObjeto = Activator.CreateInstance(itemsType);
                foreach (PropertyInfo myProp in itemsType.GetProperties())
                {
                    lstNameFields.Add(myProp.Name);
                }
                return lstNameFields;
            }

            public static void XmlListFile(List<T> lstItems, string strDatosWeb="")
            {
                if(string.IsNullOrEmpty(strDatosWeb))
                    strDatosWeb = AppDomain.CurrentDomain.BaseDirectory.ToString();
                string msPathWork = strDatosWeb;
                // Información del tipo de datos de los elementos del List
                Type itemsType = typeof(T);
                string msFileUser = itemsType.BaseType.Name + ".XML";
                // Crear Archivo para Guardar los Datos de La Clase
                FileStream fs = new FileStream(msPathWork + msFileUser, FileMode.Create);
                // Crear un Objeto XmlSerializer to perform the serialization
                XmlSerializer xs = new XmlSerializer(typeof(T));
                // Use the XmlSerializer object to serialize the data to the file
                xs.Serialize(fs, lstItems);
                // Close the file
                fs.Close();
                return;
            }

            public static void XmlItemFile(T items, string strDatosWeb="")
            {
                if (string.IsNullOrEmpty(strDatosWeb))
                    strDatosWeb = AppDomain.CurrentDomain.BaseDirectory.ToString();
                string msPathWork =strDatosWeb;
                // Información del tipo de datos de los elementos del List
                Type itemsType = typeof(T);
                string msFileUser = itemsType.Name + ".XML";
                // Crear Archivo para Guardar los Datos de La Clase
                FileStream fs = new FileStream(msPathWork + msFileUser, FileMode.Create);
                // Crear un Objeto XmlSerializer to perform the serialization
                XmlSerializer xs = new XmlSerializer(typeof(T));
                // Use the XmlSerializer object to serialize the data to the file
                xs.Serialize(fs, items);
                // Close the file
                fs.Close();
                return;
            }
        }

        public static decimal DecimalRound(decimal Argument, int Digits)
        {
            decimal rounded = decimal.Round(Argument, Digits, MidpointRounding.AwayFromZero);
            return (rounded);
        }

        public static String Numero_A_Texto(Int64 value)
        {
            string num2Text = "";
            Int64 ValueNum = value;
            switch (value)
            {
                case 0:
                    return "CERO";
                case 1:
                    return "UNO";
                case 2:
                    return "DOS";
                case 3:
                    return "TRES";
                case 4:
                    return "CUATRO";
                case 5:
                    return "CINCO";
                case 6:
                    return "SEIS";
                case 7:
                    return "SIETE";
                case 8:
                    return "OCHO";
                case 9:
                    return "NUEVE";
                case 10:
                    return "DIEZ";
                case 11:
                    return "ONCE";
                case 12:
                    return "DOCE";
                case 13:
                    return "TRECE";
                case 14:
                    return "CATORCE";
                case 15:
                    return "QUINCE";
            }
            if (ValueNum < 20)
                return ("DIECI" + Numero_A_Texto(ValueNum - 10));
            if (ValueNum == 20)
                return "VEINTE";
            if (ValueNum < 30)
                return ("VEINTI" + Numero_A_Texto(ValueNum - 20));
            if (ValueNum == 30)
                return "TREINTA";
            if (ValueNum == 40)
                return "CUARENTA";
            if (ValueNum == 50)
                return "CINCUENTA";
            if (ValueNum == 60)
                return "SESENTA";
            if (ValueNum == 70)
                return "SETENTA";
            if (ValueNum == 80)
                return "OCHENTA";
            if (ValueNum == 90)
                return "NOVENTA";
            if (ValueNum < 100)
                return (Numero_A_Texto((ValueNum / 10) * 10) + " Y " + Numero_A_Texto(ValueNum % 10));
            if (ValueNum == 100)
                return "CIEN";
            if (ValueNum < 200)
                return ("CIENTO " + Numero_A_Texto(ValueNum - 100));
            if ((ValueNum == 200) || (ValueNum == 300) || (ValueNum == 400) || (ValueNum == 600) || (ValueNum == 800))
                return (Numero_A_Texto(ValueNum / 100) + "CIENTOS");
            if (ValueNum == 500)
                return "QUINIENTOS";
            if (ValueNum == 700)
                return "SETECIENTOS";
            if (ValueNum == 900)
                return "NOVECIENTOS";
            if (ValueNum < 1000)
                return (Numero_A_Texto((ValueNum / 100) * 100) + " " + Numero_A_Texto(ValueNum % 100));
            if (ValueNum == 1000)
                return "MIL";
            if (ValueNum < 2000)
                return ("MIL " + Numero_A_Texto(ValueNum % 1000));
            if (ValueNum < 1000000)
            {
                num2Text = Numero_A_Texto((ValueNum / 1000)) + " MIL";
                if ((ValueNum % 1000) != 0)
                {
                    num2Text = num2Text + " " + Numero_A_Texto(ValueNum % 1000);
                }
                return num2Text;
            }
            if (ValueNum == 1000000)
            {
                return "UN MILLON";
            }
            if (ValueNum < 2000000)
            {
                return ("UN MILLON " + Numero_A_Texto(ValueNum % 1000000));
            }
            if (ValueNum < 1000000000000)
            {
                num2Text = Numero_A_Texto(ValueNum / 1000000) + " MILLONES ";
                if ((ValueNum - (ValueNum / 1000000) * 1000000) != 0)
                {
                    num2Text = num2Text + " " + Numero_A_Texto((ValueNum - (ValueNum / 1000000) * 1000000));
                }
                return num2Text;
            }
            if (ValueNum == 1000000000000)
            {
                return "UN BILLON";
            }
            //if (ValueNum < 2000000000000)
            //{
            //    return ("UN BILLON " + this.Num2Text(value - (Conversion.Int((double) (value / 1000000000000)) * 1000000000000)));
            //}
            //Num2Text = this.Num2Text(Conversion.Int((double) (value / 1000000000000))) + " BILLONES";
            //if ((value - (Conversion.Int((double) (value / 1000000000000)) * 1000000000000)) != 0)
            //{
            //    Num2Text = Num2Text + " " + this.Num2Text(value - (Conversion.Int((double) (value / 1000000000000)) * 1000000000000));
            //}
            return num2Text;
        }


        public static String Numero_A_Texto(decimal pMontoValor, string pcodRegMonedaNombre)
        {
            string strSoloEntero = string.Empty;
            string strSoloDecima = string.Empty;
            decimal decEnteroD = 0;
            Int64 intEntero = 0;
            string strDatoNumero1 = pMontoValor.ToString("0.00");


            HelpLogging.Write(TraceLevel.Info, string.Concat("Helper", ".", MethodBase.GetCurrentMethod().Name),
                string.Concat("documRegPrint.strDatoNumero1: ", strDatoNumero1), "segUsuarioActual", "0");


            strSoloEntero = strDatoNumero1.Substring(0, strDatoNumero1.IndexOf('.'));



            HelpLogging.Write(TraceLevel.Info, string.Concat("Helper", ".", MethodBase.GetCurrentMethod().Name),
                string.Concat("documRegPrint.strSoloEntero: ", strSoloEntero), "segUsuarioActual", "0");


            strSoloDecima = strDatoNumero1.Substring(strDatoNumero1.IndexOf('.') + 1, 2);

            HelpLogging.Write(TraceLevel.Info, string.Concat("Helper", ".", MethodBase.GetCurrentMethod().Name),
                string.Concat("documRegPrint.strSoloDecima: ", strSoloDecima), "segUsuarioActual", "0");

            decEnteroD = Convert.ToDecimal(strSoloEntero);
            intEntero = Convert.ToInt64(decEnteroD);

            string strValorTotalPrecioVentaLetras = Helper.Numero_A_Texto(intEntero) + " CON " +
                                                    strSoloDecima + "/100 " + (string.IsNullOrEmpty(pcodRegMonedaNombre) ?
                                                    string.Empty : pcodRegMonedaNombre.Trim().ToUpper());

            HelpLogging.Write(TraceLevel.Info, string.Concat("Helper", ".", MethodBase.GetCurrentMethod().Name),
                string.Concat("strValorTotalPrecioVentaLetras: ", strValorTotalPrecioVentaLetras), "segUsuarioActual", "0");

            return strValorTotalPrecioVentaLetras;
        }

        public static String Numero_A_Texto(string pMontoValor, string pcodRegMonedaNombre)
        {
            string strSoloEntero = string.Empty;
            string strSoloDecima = string.Empty;
            decimal decEnteroD = 0;
            Int64 intEntero = 0;
            string strDatoNumero1 = pMontoValor; //.ToString("0.00");


            HelpLogging.Write(TraceLevel.Info, string.Concat("Helper", ".", MethodBase.GetCurrentMethod().Name),
                string.Concat("documRegPrint.strDatoNumero1: ", strDatoNumero1), "segUsuarioActual", "0");


            strSoloEntero = strDatoNumero1.Substring(0, strDatoNumero1.IndexOf('.'));



            HelpLogging.Write(TraceLevel.Info, string.Concat("Helper", ".", MethodBase.GetCurrentMethod().Name),
                string.Concat("documRegPrint.strSoloEntero: ", strSoloEntero), "segUsuarioActual", "0");


            strSoloDecima = strDatoNumero1.Substring(strDatoNumero1.IndexOf('.') + 1, 2);

            HelpLogging.Write(TraceLevel.Info, string.Concat("Helper", ".", MethodBase.GetCurrentMethod().Name),
                string.Concat("documRegPrint.strSoloDecima: ", strSoloDecima), "segUsuarioActual", "0");

            decEnteroD = Convert.ToDecimal(strSoloEntero);
            intEntero = Convert.ToInt64(decEnteroD);

            string strValorTotalPrecioVentaLetras = Helper.Numero_A_Texto(intEntero) + " CON " +
                                                    strSoloDecima + "/100 " + (string.IsNullOrEmpty(pcodRegMonedaNombre) ?
                                                    string.Empty : pcodRegMonedaNombre.Trim().ToUpper());

            HelpLogging.Write(TraceLevel.Info, string.Concat("Helper", ".", MethodBase.GetCurrentMethod().Name),
                string.Concat("strValorTotalPrecioVentaLetras: ", strValorTotalPrecioVentaLetras), "segUsuarioActual", "0");

            return strValorTotalPrecioVentaLetras;
        }

        public static void CargarInformaciondeCultura(string strCantiDecimal)
        {
            string cultura = GlobalSettings.GetDEFAULT_Idioma();
            string cantDec = strCantiDecimal;
            CultureInfo CulturadeUsuario = new CultureInfo(cultura, true);
            CultureInfo CultureSystema = (CultureInfo)CulturadeUsuario.Clone();
            CulturadeUsuario.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            CultureSystema.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            CultureSystema.DateTimeFormat.ShortTimePattern = "HH:mm";
            CultureSystema.DateTimeFormat.LongTimePattern = "HH:mm:ss";
            CultureSystema.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            CultureSystema.NumberFormat.NumberGroupSeparator = ",";
            CultureSystema.NumberFormat.NumberDecimalSeparator = ".";
            CultureSystema.NumberFormat.NumberDecimalDigits = Convert.ToInt16(cantDec);
            CultureSystema.NumberFormat.NumberNegativePattern = 1;

            Thread.CurrentThread.CurrentCulture = CultureSystema;
        }

        public static void CreateEventLog(string prm_Informacion, int prm_EventoID, CategEvento prm_Categoria)
        {
            string NameEventLog = GlobalSettings.GetDEFAULT_NombreEventLog();

            bool logExists = EventLog.Exists(NameEventLog);

            EventLog DemoLog = new EventLog(NameEventLog, ".");
            if (!logExists)
            {
                System.Diagnostics.EventSourceCreationData creationData = new
                System.Diagnostics.EventSourceCreationData(NameEventLog, NameEventLog);
                creationData.MachineName = ".";

                EventLog.CreateEventSource(creationData);
                DemoLog.Source = NameEventLog;
                DemoLog.MaximumKilobytes = 2048;

                DemoLog.ModifyOverflowPolicy(OverflowAction.OverwriteAsNeeded, 7);
            }
            Trace.AutoFlush = true;
            EventLogTraceListener MyListener = new EventLogTraceListener(DemoLog);
            DemoLog.Source = NameEventLog;
            short CATEGORIA = 0;
            EventLogEntryType prm_Tipo = EventLogEntryType.SuccessAudit;
            switch (prm_Categoria)
            {
                case CategEvento.OK:
                    CATEGORIA = 0;
                    prm_Tipo = System.Diagnostics.EventLogEntryType.Warning;
                    break;
                case CategEvento.INSERT:
                    CATEGORIA = 1;
                    prm_Tipo = System.Diagnostics.EventLogEntryType.FailureAudit;
                    break;
                case CategEvento.UPDATE:
                    prm_Tipo = System.Diagnostics.EventLogEntryType.FailureAudit;
                    CATEGORIA = 2;
                    break;
                case CategEvento.DELETE:
                    prm_Tipo = System.Diagnostics.EventLogEntryType.FailureAudit;
                    CATEGORIA = 3;
                    break;
                case CategEvento.TRANSACTION:
                    prm_Tipo = System.Diagnostics.EventLogEntryType.Error;
                    CATEGORIA = 4;
                    break;
                case CategEvento.MESSAGE:
                    CATEGORIA = 5;
                    prm_Tipo = System.Diagnostics.EventLogEntryType.Warning;
                    break;
                case CategEvento.LIST:
                    CATEGORIA = 5;
                    prm_Tipo = System.Diagnostics.EventLogEntryType.Warning;
                    break;
            }
            DemoLog.WriteEntry(prm_Informacion, prm_Tipo, prm_EventoID, CATEGORIA); //
        }

        public enum ComboBoxText
        {
            Todos,
            Select,
            Otros,
            No_Agregar

        }
        /// <summary>
        /// <para>Objetivo: Obtener el texto asignado a.</para>
        /// <para>Prueba: </para>
        /// <para>Creacion: Luis Chavarria(OXINET) 20090501 - REQ:XXX.</para>
        /// <para>Modificacion: Luis Chavarria(OXINET) 20090501 - REQ:XXX.</para>
        /// </summary>
        /// <param name="valor"></param>
        public static string ObtenerTexto(ComboBoxText valor)
        {
            string nombre = string.Empty; ;
            switch (valor)
            {
                case ComboBoxText.Select:
                    nombre = "-- Seleccionar --";
                    break;
                case ComboBoxText.Todos:
                    nombre = "-- Todos --";
                    break;
                case ComboBoxText.Otros:
                    nombre = "-- Otros --";
                    break;
            }

            return nombre;
        }

        public static string ObtenerNombreArchivo(string pNombreArchivo)
        {
            string nombreArchivoNuevo=string.Empty;
            string[] nombrePartes = pNombreArchivo.Split('.');
            nombreArchivoNuevo = String.Format(LimpiarNombreArchivo(nombrePartes[0]) + "{0}_{1}." + nombrePartes[1],
                HelpTime.ConvertYYYYMMDD(DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud())),
                DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).Hour.ToString().PadLeft(2,'0') +
                DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).Minute.ToString().PadLeft(2, '0') +
                DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).Second.ToString().PadLeft(2, '0')
                );
            return nombreArchivoNuevo;
        }

        public static string LimpiarNombreArchivo(string pNombreArchivo)
        {
            string strNuevoNombreArchivo = string.Empty;
            string strCaracteresNoValidos = "!#$#%#&#/#(#)#=#?#¡#¿#'#!#|#°#¬#-#:#;#,#<#>#¨#´#[#]#{#}#*#+#`#@";
            string[] strData = strCaracteresNoValidos.Split('#');
            foreach (string caracter in strData)
            {
                strNuevoNombreArchivo = pNombreArchivo.Replace(caracter, "");
            }
            return strNuevoNombreArchivo;
        }
    }
}

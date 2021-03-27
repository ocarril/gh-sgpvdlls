namespace CROM.Tools.Windows
{
    using CROM.Tools.Comun.settings;

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Security.Principal;
    using System.Threading;
    using System.Windows.Forms;


    public static class HelpWindows
    {
        public static Dictionary<string, string> XML_NombreFormatosDocumentos(string strPath = @"\")
        {
            try
            {
                Dictionary<string, string> lstFormatoDocumento = new Dictionary<string, string>();

                DataTable dtFormatoDocumento = new DataTable();

                DataSet DataSetFormatos = new DataSet("FormatosDocumentos");
                DataSetFormatos.Reset();
                DataSetFormatos.ReadXml(strPath.Length > 1 ? strPath + "FormatList.XML" : Application.StartupPath.Trim() + strPath + "FormatList.XML");
                dtFormatoDocumento = DataSetFormatos.Tables[0];
                foreach (DataRow dr in dtFormatoDocumento.Rows)
                {
                    if (!lstFormatoDocumento.ContainsValue(dr["Nombre"].ToString()))
                        lstFormatoDocumento.Add(dr["Tipo"].ToString() + " - " + dr["Nombre"].ToString(), dr["Nombre"].ToString());
                }
                lstFormatoDocumento.OrderBy(fd => fd.Key);
                var sortedDict = (from entry in lstFormatoDocumento orderby entry.Value ascending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
                return (sortedDict);
            }
            catch (Exception ex)
            {
                throw new Exception("¡ NO SE PUEDE LEER el Archivo XML !" + ex.Message);
            }

        }

        public static string Usuario(bool FULL_NAME)
        {
            WindowsIdentity winUsers = WindowsIdentity.GetCurrent() as WindowsIdentity;
            string[] usersName = winUsers.Name.Trim().Split(new char[] { '\\' });
            int Posi = usersName.Length;
            return (FULL_NAME == false ? usersName[Posi - 1] : winUsers.Name.Trim());
        }
        public static string HostName()
        {
            string Host = Dns.GetHostName();
            return Host;
        }

        public static void AsignarCulturaAlSistema()
        {
            string cultura = GlobalSettings.GetDEFAULT_Idioma();
            CultureInfo CulturadeUsuario = new CultureInfo(cultura, true);
            CultureInfo CultureSystema = (CultureInfo)CulturadeUsuario.Clone();
            CulturadeUsuario.DateTimeFormat.ShortDatePattern =  GlobalSettings.GetDEFAULT_DatePattern();
            CultureSystema.DateTimeFormat.ShortDatePattern =    GlobalSettings.GetDEFAULT_DatePattern();
            CultureSystema.DateTimeFormat.ShortTimePattern =    GlobalSettings.GetDEFAULT_ShortTimePattern();
            CultureSystema.DateTimeFormat.LongTimePattern =     GlobalSettings.GetDEFAULT_LongTimePattern();
            CultureSystema.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            CultureSystema.NumberFormat.NumberGroupSeparator = ",";
            CultureSystema.NumberFormat.NumberDecimalSeparator = ".";
            CultureSystema.NumberFormat.NumberNegativePattern = 1;
            Thread.CurrentThread.CurrentCulture = CultureSystema;
        }

        public static string MessageBoxCaption()
        {
            string nameProgram = AppDomain.CurrentDomain.FriendlyName;
            string Titulo = "[ " + nameProgram.Substring(0, nameProgram.Length - 4) + " ] - Mensaje!!";
            return (Titulo);
        }

        public static bool IsNetworkConnected()
        {
            bool connectado = SystemInformation.Network;
            if (connectado)
            {
                connectado = false;
                System.Management.ManagementObjectSearcher searcher = new
                    System.Management.ManagementObjectSearcher("SELECT NetConnectionStatus FROM Win32_NetworkAdapter");
                foreach (System.Management.ManagementObject networkAdapter in searcher.Get())
                {
                    if (networkAdapter["NetConnectionStatus"] != null)
                    {
                        if (Convert.ToInt32(networkAdapter["NetConnectionStatus"]).Equals(2))
                        {
                            connectado = true;
                            break;
                        }
                    }
                }
                searcher.Dispose();
            }
            return connectado;
        }



        public static void ProcessStartExecuteCommand(string command)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true; //Esta propiedad oculta la consola
            processInfo.UseShellExecute = false;

            process = Process.Start(processInfo);
            process.WaitForExit();

            exitCode = process.ExitCode; //Si tu bat tiene exit code lo obtendrá aquí

            process.Close();
        }

    }
}

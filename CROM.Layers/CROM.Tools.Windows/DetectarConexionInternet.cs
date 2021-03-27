using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CROM.Tools.Windows
{
    /// <summary>
    /// CLASE
    /// </summary>
    public static class DetectarConexionInternet
    {
        /// <summary>
        /// Detecta la conectividad de la RED
        /// </summary>
        /// <returns></returns>
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
    }
}

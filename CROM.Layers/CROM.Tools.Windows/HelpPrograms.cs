using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace CROM.Tools.Windows
{
    public static class HelpPrograms
    {
        public static void Call_Calculadora()
        {
            try
            {
                Process MiCalculadora = new Process();
                MiCalculadora.StartInfo.FileName = @"C:\WINDOWS\system32\calc.exe";
                MiCalculadora.StartInfo.CreateNoWindow = false;
                MiCalculadora.Start();
                MiCalculadora.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, HelpWindows.MessageBoxCaption(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
    }
}

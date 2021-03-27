using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using CROM.Tools.Comun;
using CROM.Tools.Comun.settings;

namespace CROM.Tools.Windows
{
    public static class HelpMaestrasWindows
    {
  
        //public static void ComboBoxaddItemText(ref  ComboBox pComboBox, Helper.ComboBoxText pTexto)
        //{
        //    List<ListItem> Lista = new List<ListItem>();
        //    Lista.Add(new ListItem { CodigoArgumento = "", Nombre = Helper.ObtenerTexto(pTexto) });
        //    for (int i = 0; i < pComboBox.Items.Count; i++)
        //    {
        //        string DESCRIPCION = pComboBox.Text.ToString();
        //        Lista.Add(new ListItem { CodigoArgumento = pComboBox.SelectedValue.ToString(), Nombre = DESCRIPCION });
        //    }

        //    pComboBox.DataSource = Lista;
        //    pComboBox.ValueMember = "CodigoArgumento";
        //    pComboBox.DisplayMember = "Nombre";

        //}
        

        public static void LlenarAnios(ref ComboBox miCombo, int tipo)
        {
            switch (tipo)
            {
                case 1:
                    for (int i = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).Year - 15; i <= 
                                 DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).Year + 2; ++i)
                    {
                        miCombo.Items.Add(i);
                    }
                    miCombo.SelectedItem = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).Year;
                    break;
                case 2:
                    for (int i = 1; i <= 12; ++i)
                    {
                        miCombo.Items.Add(i);
                    }
                    miCombo.SelectedItem = DateTime.Now.Month - 1;
                    break;
            }
        }
    }
}

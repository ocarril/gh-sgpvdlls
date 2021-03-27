using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace CROM.Tools.Web
{
    public class HelpComboBox
    {
        public enum Texto
        {
            Todos,
            Select,
            Otros,
            No_Agregar
        }

        public static string ObtenerTexto(Texto valor)
        {
            string nombre = string.Empty; ;
            switch (valor)
            {
                case Texto.Select:
                    nombre = "-- Seleccionar --";
                    break;
                case Texto.Todos:
                    nombre = "-- Todos --";
                    break;
                case Texto.Otros:
                    nombre = "-- Otros --";
                    break;
            }

            return nombre;
        }

        public static void AddItemText(ref  DropDownList pDropDownList, Texto pTexto)
        {
            pDropDownList.Items.Insert(0, new ListItem(ObtenerTexto(pTexto), ""));
        }
    }
}

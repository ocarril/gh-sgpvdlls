using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Globalization;
using System.Diagnostics;
using System.Reflection;

namespace CROM.Tools.Comun
{
    public static class HelpColor
    {
        public enum Colores
        {
            Pendiente,
            Cerrado
        }

        public static Color ObtenerColor(Colores tipoColores)
        {
            Color ColorElegido = Color.White;
            switch (tipoColores)
            {
                case Colores.Pendiente:
                    ColorElegido = Color.LightSteelBlue;
                    break;
                case Colores.Cerrado:
                    ColorElegido = Color.Gainsboro;
                    break;
            }
            return ColorElegido;
        }

        public static Color HexToColor(string hexString)
        {
            Color colorDefault = Color.White;
            try
            {
                if (!string.IsNullOrWhiteSpace(hexString)){
                    // REPLACE # OCCURENCES
                    if (hexString.IndexOf('#') != -1)
                        hexString = hexString.Replace("#", "");

                    int RED, GREEN, BLUE = 0;

                    RED = int.Parse(hexString.Substring(0, 2), NumberStyles.AllowHexSpecifier);
                    GREEN = int.Parse(hexString.Substring(2, 2), NumberStyles.AllowHexSpecifier);
                    BLUE = int.Parse(hexString.Substring(4, 2), NumberStyles.AllowHexSpecifier);

                    colorDefault = Color.FromArgb(RED, GREEN, BLUE);
                }
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat("HelpColor.", MethodBase.GetCurrentMethod().Name), ex, "USERerror", "0");
            }
            return colorDefault;
        }

    }
}

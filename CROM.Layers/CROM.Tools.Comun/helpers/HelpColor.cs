using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

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
    }
}

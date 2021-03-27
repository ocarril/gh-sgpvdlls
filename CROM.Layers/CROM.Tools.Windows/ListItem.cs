using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CROM.Tools.Windows
{
    public class ListItem
    {
        public string CodigoTabla { get; set; }
        public string CodigoArgumento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal ValorDecimal { get; set; }
        public string ValorCadena { get; set; }
        public bool ValorBoolean { get; set; }
        public int ValorEntero { get; set; }
        public Nullable<DateTime> ValorFecha { get; set; }
    }
}

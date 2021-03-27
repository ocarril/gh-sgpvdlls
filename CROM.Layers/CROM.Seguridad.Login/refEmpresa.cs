using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CROM.Seguridad.Login
{
    public class refEmpresa
    {
        public string codPersona { get; set; }
        public string desRazonSocial { get; set; }
        public string desDomicilio { get; set; }
        public string codRuc { get; set; }
        public byte[] imgLogo { get; set; }
    }

    public class refPuntoDeVenta
    {
        public string codPuntoVenta { get; set; }
        public string codPersonaEmpre { get; set; }
        public string desDescripcion { get; set; }
    }

    //public class refDeposito
    //{
    //    public string codDeposito { get; set; }
    //    public string codPersonaEmpre { get; set; }
    //    public string desDescripcion { get; set; }
    //}
}

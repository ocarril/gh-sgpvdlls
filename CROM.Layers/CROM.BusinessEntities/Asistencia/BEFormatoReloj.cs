namespace CROM.BusinessEntities.Asistencia
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BEFormatoReloj
    {
        public string CodigoFormato { get; set; }
        public string Descripcion { get; set; }
        public short RegistroLong { get; set; }
        public string RegistroDeta { get; set; }
        public short PosicionTarjetaIni { get; set; }
        public short PosicionTarjetaFin { get; set; }
        public short PosicionFechaIni { get; set; }
        public short PosicionFechaFin { get; set; }
        public short PosicionAnioIni { get; set; }
        public short PosicionAnioFin { get; set; }
        public short PosicionMesIni { get; set; }
        public short PosicionMesFin { get; set; }
        public short PosicionDiaIni { get; set; }
        public short PosicionDiaFin { get; set; }
        public short PosicionHoraIni { get; set; }
        public short PosicionHoraFin { get; set; }
        public short PosicionMinutoIni { get; set; }
        public short PosicionMinutoFin { get; set; }
        public short PosicionSegundoIni { get; set; }
        public short PosicionSegundoFin { get; set; }
        public short PosicionTeclaIni { get; set; }
        public short PosicionTeclaFin { get; set; }
        public bool Estado { get; set; }

        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public string SegMaquinaOrigen { get; set; }
        public DateTime SegFechaHoraCrea { get; set; }
        public DateTime SegFechaHoraEdita { get; set; }

    }
}

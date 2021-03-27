namespace CROM.Tools.Comun.utils.excel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
   
    /// <summary>
    /// Objeto que representa la exportacion a excel
    /// </summary>
    /// <remarks>
    /// Creacion: 	LOG(JCBL) 20120820 <br />
    /// </remarks>
    public class FilaExcel
    {
        public List<CeldaExcel> Fila { get; set; }
        public byte NivelAgrupacion { get; set; }

        public GridExcel GridAnidado { get; set; }

        public void CrearCelda(dynamic value, string estilo = "")
        {
            this.Fila.Add(new CeldaExcel() { Value = value, Style = estilo });
        }
    }

    public class CabeceraColumna
    {
        public string Texto { get; set; }
        public int PosicionColumna { get; set; }
        public int PosicionFila { get; set; }
        public int CantidadCeldas { get; set; }
    }

    public class CeldaExcel
    {
        public CeldaExcel()
        {
            this.Style = string.Empty;
        }

        public dynamic Value { get; set; }
        public string Style { get; set; }
    }

    public class GridExcel
    {
        public List<FilaExcel> Datos { get; set; }
        public List<CabeceraColumna> Cabeceras { get; set; }
        public List<string> Cabecera { get; set; }
        public byte NivelAgrupacionCabecera { get; set; }
        public string NombreGrid { get; set; }
        public int NivelesCabecera { get; set; }
    }
}

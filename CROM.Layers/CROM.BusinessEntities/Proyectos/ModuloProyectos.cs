namespace CROM.BusinessEntities.Proyectos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class BaseFiltroPry
    {
        public string codPersonaEntidad { get; set; }
        public string codRegEstado { get; set; }
        public string desNombre { get; set; }
        public string desNombreArchivo { get; set; }
        public string desGlosa { get; set; }
        public int? codProyecto { get; set; }
        public bool? indActivo { get; set; }

        public string fecInicio { get; set; }
        public string fecFinal { get; set; }
        public string fecInicioGarantia { get; set; }
        public string fecFinalGarantia { get; set; }

        public int? codPyEquipo { get; set; }
        public int? codEmpleadoResp { get; set; }
        public int? codDocumEstado { get; set; }
        public int? codPyDocumReg { get; set; }
        public int? codDocumReg { get; set; }
        public int? codDocumRegDetalle { get; set; }

        public string segUsuario { get; set; }

        public int grpageSize { get; set; }
        public int grcurrentPage { get; set; }
        public string grsortColumn { get; set; }
        public string grsortOrder { get; set; }

    }


    public enum ReportesPRY : int
    {
        CalculoCostosDUA = 1,
        CostosPorOI = 2,
        PrecioCompraVsCosto = 3
    }

    /// <summary>
    /// Enumeración de Estilos para Reportes PRY
    /// </summary>
    /// <remarks>
    /// Creacion: 	LOG(OCR) 20141210 <br />
    /// </remarks>
    public enum EstilosReportePRY : int
    {
        FondoLila = 1,
        FondoBase = 2,
        FondoNegro = 3,
        FondoPost = 4,
        FondoPostPais = 5,
        FondoVerde = 6,
        FondoValorPagina = 7,
        ColorWorkingPage = 8,
        FondoDefecto = 9,
        CabeceraCuadro = 10,
        FondoGranate = 11,
        TituloReporte = 12
    }
}

namespace CROM.BusinessEntities.Importaciones
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public struct ParametroGlobal
    {
        public const string SessionDatosReportesDUA = "DatosReporteDUA";
        public const string SessionNombreReportesDUA = "NombreReporteDUA";
    }

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 28/05/2014-06:32:44 
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [BaseFiltroImp.cs]
    /// </summary>
    public class BaseFiltroImp
    {
        public int? codOIDUACosto { get; set; }
        public int? codOIDUA { get; set; }
        public int? codOrdenImportacion { get; set; }
        public string numOrdenImportacion { get; set; }
        public string numDUA { get; set; }
        public int? codOIDocumento { get; set; }
        public int? codOIDUAProducto { get; set; }
        public int? codOIDocumReg { get; set; }
        public int? codOIDUASerie { get; set; }

        public int? codDocumentoEstado { get; set; }
        public string codRegIncotermo { get; set; }
        public string codRegNacionalizacion { get; set; }

        public string codPersonaEntidad { get; set; }
        public string codRegEstado { get; set; }
        public string codRegCanal { get; set; }

        public int? codPlantillaCosto { get; set; }
        public string codRegResumenCosto { get; set; }
        public bool? indActivo { get; set; }

        public string fecInicio { get; set; }
        public string fecFinal { get; set; }

        public int? codDocumRegDetalle { get; set; }

        public int tipoCombo { get; set; }
        public string codCostoPadre { get; set; }
        public string segUsuario { get; set; }

        public int grpageSize { get; set; }
        public int grcurrentPage { get; set; }
        public string grsortColumn { get; set; }
        public string grsortOrder { get; set; }

    }

    public enum ReportesOIDUA : int
    {
        CalculoCostosDUA = 1,
        CostosPorOI = 2,
        PrecioCompraVsCosto = 3
    }

    /// <summary>
    /// Enumeración de Estilos para Reportes DUA
    /// </summary>
    /// <remarks>
    /// Creacion: 	LOG(OCR) 20120918 <br />
    /// </remarks>
    public enum EstilosReporteDUA : int
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

    /// <summary>
    /// Vista de resultado de PxP para exportacion a Excel de Banderitas y PxP
    /// por países hijos
    /// </summary>
    /// <remarks>
    /// Creacion: 	    LOG(OCR) 20121003
    /// Modificacion:	
    /// </remarks>
    public class FiltroExportar
    {
        public int codOIDUA { get; set; }
        public int? codOI { get; set; }
        public int IdReporte { get; set; }

        public string NombreDUA { get; set; }
        public BEOIDUA itemOIDUA { get; set; }
    }

    public class LadoElemento
    {
        public string DatoElemento { get; set; }
        public string ColorElemento { get; set; }
    }
}

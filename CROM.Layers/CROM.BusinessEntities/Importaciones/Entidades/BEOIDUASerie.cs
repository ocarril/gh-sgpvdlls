namespace CROM.BusinessEntities.Importaciones
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 10/10/2014-12:36:45 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Importaciones.OIDUASerie.cs]
    /// </summary>
    public class BEOIDUASerie : BEBase
    {
        public int codOIDUASerie { get; set; }
        public int codOIDUAProducto { get; set; }
        public int codProductoSeriado { get; set; }
        public bool indActivo { get; set; }

        public string auxNumeroSerie { get; set; }
        public string auxNumeroDocumentoCompra { get; set; }
        public string auxcodRegEstadoSerie { get; set; }
        public string auxcodRegEstadoSerieNombre { get; set; }
        public int auxcodDocumRegDetalle { get; set; }
        public int auxcantidadTope { get; set; }
    }
}

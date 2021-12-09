namespace CROM.BusinessEntities.Comercial.DTO
{
    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 26/06/2020-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.DTODocumentoSerieResponse.cs]
    /// </summary>
    public class DTODocumentoSerieResponse : BEBaseEntidadItem
    {
        public DTODocumentoSerieResponse()
        {
            objDocumentoEmision = new DTODocumentoResponse();
        }

        public int codDocumentoSerie { get; set; }
        public string CodigoComprobante { get; set; }
        public string Descripcion { get; set; }
        public string CodigoPuntoVenta { get; set; }
        public string CodigoPersonaEmpre { get; set; }
        public string NombreReporte { get; set; }
        public string NumeroSerie { get; set; }
        public decimal NumeroInicio { get; set; }
        public decimal NumeroFinal { get; set; }
        public decimal UltimoEmitido { get; set; }
        public bool Estado { get; set; }

        public DTODocumentoResponse objDocumentoEmision { get; set; }
        
        public string CodigoComprobanteNombre { get; set; }

        public string CodigoPersonaEmpreNombre { get; set; }

        public string CodigoPuntoVentaNombre { get; set; }

        public string Abreviatura { get; set; }
        public string codRegDocumentoSunat { get; set; }
    }
}

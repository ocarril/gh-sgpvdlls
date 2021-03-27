namespace CROM.BusinessEntities.Comercial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Resources;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.ComprobantesSeries.cs]
    /// </summary>
    public class DTODocumentoSerie : BEBasePagedResponse
    {
        public DTODocumentoSerie()
        {
            codDocumento = string.Empty;
            Descripcion = string.Empty;
            CodigoPuntoVenta = string.Empty;
            NombreReporte = string.Empty;
            NumeroSerie = string.Empty;
            codPuntoVentaNombre = string.Empty;
            codDocumentoNombre = string.Empty;
            codEmpleadoNombre = string.Empty;
        }

        public int codDocumentoSerie { get; set; }

        public string codDocumento { get; set; }

        public string Descripcion { get; set; }

        public string CodigoPuntoVenta { get; set; }

        public string CodigoPersonaEmpre { get; set; }

        public string NombreReporte { get; set; }

        public string NumeroSerie { get; set; }

        public decimal NumeroInicio { get; set; }

        public decimal NumeroFinal { get; set; }

        public decimal UltimoEmitido { get; set; }

        public string codDocumentoNombre { get; set; }

        public string codPuntoVentaNombre { get; set; }

        public string codEmpleadoNombre { get; set; }

    }
}

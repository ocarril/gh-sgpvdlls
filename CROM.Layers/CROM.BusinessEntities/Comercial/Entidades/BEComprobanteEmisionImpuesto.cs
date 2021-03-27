namespace CROM.BusinessEntities.Comercial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 16/09/2010-6:51:18
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.ComprobanteEmisionImpuestos.cs]
    /// </summary>
    public class BEComprobanteEmisionImpuesto
    {
        public int codDocumRegImpuesto { get; set; }
        public int codDocumReg { get; set; }

        public int codEmpresa { get; set; }
        public string CodigoPuntoVenta { get; set; }
        public string CodigoComprobante { get; set; }
        public string NumeroComprobante { get; set; }
        public string CodigoImpuesto { get; set; }
        public decimal ValorDeImpuesto { get; set; }
        public decimal ValorDeImpuesto100 { get; set; }
        public decimal ValorTotalImpuesto { get; set; }
        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public DateTime SegFechaCrea { get; set; }
        public Nullable<DateTime> SegFechaEdita { get; set; }
        public string SegMaquina { get; set; }

        public string CodigoImpuestoNombre { get; set; }
    }
} 

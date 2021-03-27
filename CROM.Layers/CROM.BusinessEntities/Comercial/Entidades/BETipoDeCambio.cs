namespace CROM.BusinessEntities.Comercial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    using CROM.BusinessEntities.Maestros;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.TiposdeCambio.cs]
    /// </summary>
    public class BETipoDeCambio : BEBase
    {
        public BETipoDeCambio()
        {
            objMoneda = new BERegistroNew();
        }

        public int codTipoCambio { get; set; }
        public DateTime FechaProceso { get; set; }
        public string CodigoArguMoneda { get; set; }
        public decimal CambioCompraGOB { get; set; }
        public decimal CambioVentasGOB { get; set; }
        public decimal CambioCompraPRL { get; set; }
        public decimal CambioVentasPRL { get; set; }
        public bool Estado { get; set; }

        public BERegistroNew objMoneda { get; set; }

        ////[NotMapped]
        public string CodigoArguMonedaNombre { get; set; }
    }
} 

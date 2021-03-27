namespace CROM.BusinessEntities.Comercial.DTO
{
    using System;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.TiposdeCambio.cs]
    /// </summary>
    public class DTOTipoDeCambio : BEBaseEntidadItem
    {
        public DTOTipoDeCambio()
        {
            codRegMoneda = string.Empty;
            codRegMonedaNombre = string.Empty;
            indActivo = true;
            monCompraGOB = 0;
            monCompraPRL = 0;
            monVentasGOB = 0;
            monVentasPRL = 0;
        }

        public int codTipoCambio { get; set; }

        public DateTime fecProceso { get; set; }

        public string codRegMoneda { get; set; }

        public decimal monCompraGOB { get; set; }

        public decimal monVentasGOB { get; set; }

        public decimal monCompraPRL { get; set; }

        public decimal monVentasPRL { get; set; }

        public string codRegMonedaNombre { get; set; }
    }
} 

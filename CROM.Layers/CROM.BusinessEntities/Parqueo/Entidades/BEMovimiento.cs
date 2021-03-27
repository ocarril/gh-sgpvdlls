namespace CROM.BusinessEntities.Parqueo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 28/11/2011-06:25:39 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Parqueo.Movimiento.cs]
    /// </summary>
    public class BEMovimiento
    {
        public string codMovimiento { get; set; }
        public string codPersonaEmpresa { get; set; }
        public string codPuntoDeVenta { get; set; }
        public string codVehiculo { get; set; }
        public string codRegTipoVehiculo { get; set; }
        public string codRegSectorParqueo { get; set; }
        public string codPersonaCliente { get; set; }
        public DateTime fecHoraIngreso { get; set; }
        public Nullable<DateTime> fecHoraSalida { get; set; }
        public string perTotalHora { get; set; }
        public string perTotalHoraFraccion { get; set; }
        public string codTarifa { get; set; }
        public decimal monTarifaBase { get; set; }
        public decimal? monMontoPagado { get; set; }
        public string gloObservacion { get; set; }
        public bool indAbonado { get; set; }
        public bool indFacturado { get; set; }
        public bool indActivo { get; set; }
        public string segUsuarioCrea { get; set; }
        public string segUsuarioEdita { get; set; }
        public DateTime segFechaHoraCrea { get; set; }
        public Nullable<DateTime> segFechaHoraEdita { get; set; }
        public string segMaquinaOrigen { get; set; }

        public string codDocumento { get; set; }
        public string numDocumento { get; set; }
        public bool indCancelado { get; set; }

        public decimal? monTotalTarifado { get; set; }
        public decimal? monTotalNoche { get; set; }
        public decimal? monTotalDscto { get; set; }

    }

    public class MovimientoAux : BEMovimiento
    {
        public string codPersonaEmpresaNombre { get; set; }
        public string codPuntoDeVentaNombre { get; set; }
        public string codVehiculoNombre { get; set; }
        public string codRegTipoVehiculoNombre { get; set; }
        public string codRegSectorParqueoNombre { get; set; }
        public string codPersonaClienteNombre { get; set; }
        public string codTarifaNombre { get; set; }
        public string codRegMarcaModelo { get; set; }

        public string codRegEstadoDocumento { get; set; }
        public decimal? ValorTipoCambioCMP { get; set; }
        public decimal? ValorTipoCambioVTA { get; set; }
        public string codParte { get; set; }
    }
} 

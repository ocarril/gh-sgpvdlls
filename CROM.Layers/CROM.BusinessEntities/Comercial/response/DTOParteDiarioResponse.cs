namespace CROM.BusinessEntities.Comercial.response
{
    using CROM.BusinessEntities.Caja.response;
    using CROM.BusinessEntities.Cajas;
    using CROM.BusinessEntities.Maestros;
    using CROM.BusinessEntities.RecursosHumanos;

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 16/02/2021-13:52:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.ParteDiario.cs]
    /// </summary>
    public class DTOParteDiarioResponse : BEBasePagedResponse
    {
        public DTOParteDiarioResponse()
        {
            gloObservacion = string.Empty;
            codEmpleadoNombre = string.Empty;
            codParteDiarioTurnoNombre = string.Empty;
            codPuntoVentaNombre = string.Empty;
            desHorario = string.Empty;
        }

        public string codParteDiario { get; set; }
        public string codPuntoVenta { get; set; }
        public DateTime fecParte { get; set; }
        public int? codEmpleado { get; set; }
        public string gloObservacion { get; set; }
        public string codParteDiarioTurno { get; set; }
        public string indTurno { get; set; }
        public bool indCajaActiva { get; set; }
        public bool indCaja { get; set; }
        public decimal mtoTotalIngreso { get; set; }
        public decimal mtoTotalEgreso { get; set; }


        public decimal mtoTotalSaldo { get; set; }       
        public string codPuntoVentaNombre { get; set; }
        public string codEmpleadoNombre { get; set; }
        public string codParteDiarioTurnoNombre { get; set; }
        public string desHorario { get; set; }

        public int cntRegPagos { get; set; }

    }
} 

namespace CROM.BusinessEntities.Comercial.request
{
    using CROM.BusinessEntities.Caja.response;

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 16/02/2021-13:52:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.ParteDiario.cs]
    /// </summary>
    public class DTOParteDiarioRequest : BEBaseEntidadRequest
    {
        public DTOParteDiarioRequest()
        {
            gloObservacion = string.Empty;

            lstCajaRegistro = new List<DTOCajaRegistroResponse>();
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
        public bool indActivo { get; set; }


        public decimal mtoTotalIngreso { get; set; }
        public decimal mtoTotalEgreso { get; set; }

        public List<DTOCajaRegistroResponse> lstCajaRegistro { get; set; }

    }
} 

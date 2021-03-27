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
    /// Archivo     : [Parqueo.Vehiculo.cs]
    /// </summary>
    public class BEVehiculo
    {
        public string codVehiculo { get; set; }
        public string codPersonaCliente { get; set; }
        public string codRegTipoVehiculo { get; set; }
        public string codRegMarcaModelo { get; set; }
        public string codRegColorInterno { get; set; }
        public string codRegColorExterno { get; set; }
        public string codRegTipoAbono { get; set; }
        public string codNroChasis { get; set; }
        public string codNroMotor { get; set; }
        public int perAnio { get; set; }
        public string gloObservacion { get; set; }
        public bool indActivo { get; set; }
        public string segUsuarioCrea { get; set; }
        public string segUsuarioEdita { get; set; }
        public DateTime segFechaHoraCrea { get; set; }
        public Nullable<DateTime> segFechaHoraEdita { get; set; }
        public string segMaquinaOrigen { get; set; }
    }
    public class VehiculoAux : BEVehiculo
    {
        public string codPersonaClienteNombre { get; set; }
        public string codRegTipoVehiculoNombre { get; set; }
        public string codRegMarcaModeloNombre { get; set; }
        public string codRegColorInternoNombre { get; set; }
        public string codRegColorExternoNombre { get; set; }
        public string codRegTipoAbonoNombre { get; set; }

    }
}

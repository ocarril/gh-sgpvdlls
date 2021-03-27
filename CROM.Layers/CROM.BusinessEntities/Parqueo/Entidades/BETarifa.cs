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
    /// Archivo     : [Parqueo.Tarifa.cs]
    /// </summary>
    public class BETarifa
    {
        public string codTarifa { get; set; }
        public string codPersonaEmpresa { get; set; }
        public string codPuntoDeVenta { get; set; }
        public string codRegTipoVehiculo { get; set; }
        public int codProducto { get; set; }
        public string codiProducto { get; set; }
        public string desNombre { get; set; }
        public decimal monPrecioBase { get; set; }
        public int perMinutoMinimo { get; set; }
        public decimal monPrecioAdicional1 { get; set; }
        public int perMinutoAplicaDesde { get; set; }
        public decimal monPrecioAdicional2 { get; set; }
        public int perMinutoFrecuencia { get; set; }
        public decimal perHoraDeEstadia { get; set; }
        public int perHoraAplicaDespuesDe { get; set; }
        public int perMinutoTolerancia { get; set; }
        public bool indActivo { get; set; }
        public string segUsuarioCrea { get; set; }
        public string segUsuarioEdita { get; set; }
        public DateTime segFechaHoraCrea { get; set; }
        public Nullable<DateTime> segFechaHoraEdita { get; set; }
        public string segMaquinaOrigen { get; set; }
    }
    public class TarifaAux : BETarifa
    {
        public string codPersonaEmpresaNombre { get; set; }
        public string codPuntoDeVentaNombre { get; set; }
        public string codRegTipoVehiculoNombre { get; set; }
        public string codProductoNombre { get; set; }

    }
} 

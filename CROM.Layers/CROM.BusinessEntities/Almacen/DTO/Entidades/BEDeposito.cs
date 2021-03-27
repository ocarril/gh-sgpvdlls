namespace CROM.BusinessEntities.Almacen
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    using CROM.BusinessEntities.Maestros;
    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.RecursosHumanos;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 18/01/2012-04:29:32 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.Deposito.cs]
    /// </summary>
    public class BEDeposito : BEBase
    {
        public BEDeposito()
        {
            objEmpleado = new BEEmpleado();
            objPuntoDeVenta = new BEPuntoDeVenta();
        }

        public string codDeposito { get; set; }
        public string codPuntoVenta { get; set; }
        public string desNombre { get; set; }
        public int? codEmpleado { get; set; }
        public string gloObservacion { get; set; }
        public bool indPrincipal { get; set; }
        public bool indActivo { get; set; }

        ////[NotMapped]
        public string auxcodEmpleadoNombre { get; set; }
        ////[NotMapped]
        public string auxcodPersonaEmpreNombre { get; set; }
        ////[NotMapped]
        public string auxcodPuntoDeVentaNombre { get; set; }

        public BEPuntoDeVenta objPuntoDeVenta { get; set; }
        public BEEmpleado objEmpleado { get; set; }
    }

}

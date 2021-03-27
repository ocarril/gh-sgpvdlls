namespace CROM.BusinessEntities.Comercial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    using CROM.BusinessEntities.Maestros;
    using CROM.BusinessEntities.RecursosHumanos;
    
    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.PuntoDeVenta.cs]
    /// </summary>
    public class BEPuntoDeVenta : BEBase
    {
        public BEPuntoDeVenta()
        {
            objPersonaEmpre = new BEPersona();
            objEmpleadoRespon = new BEEmpleado();
        }
        public int codEmpresa { get; set; }

        public string codPuntoDeVenta { get; set; }
        public string codPersonaEmpre { get; set; }
        public int codEmpleadoRespon { get; set; }
        public string desNombre { get; set; }
        public string desPathFiles { get; set; }
        public bool indActivo { get; set; }

        public BEPersona objPersonaEmpre { get; set; }
        public BEEmpleado objEmpleadoRespon { get; set; }

        ////[NotMapped]
        public string codPersonaEmpreNombre { get; set; }
        ////[NotMapped]
        public string codEmpleadoResponNombre { get; set; }
    }
}

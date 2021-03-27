namespace CROM.BusinessEntities.Comercial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    using CROM.BusinessEntities.Maestros;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.ParteDiarioTurnos.cs]
    /// </summary>
    public class BEParteDiarioTurno : BEBase
    {
        public BEParteDiarioTurno()
        {
            objTipo = new BERegistroNew();
            objDiaSemana = new BERegistroNew();
            objPuntoDeVenta = new BEPuntoDeVenta();
            objEmpresa = new BEPersona();
        }

        public string CodigoTurno { get; set; }
        public string CodigoPersonaEmpre { get; set; }
        public string CodigoPuntoVenta { get; set; }
        public string CodigoArguTipoTurno { get; set; }
        public string CodigoArguDiaSemana { get; set; }
        public string Descripcion { get; set; }
        public string HoraDeInicio { get; set; }
        public string HoraDeFinal { get; set; }
        public bool Estado { get; set; }

        public BERegistroNew objTipo { get; set; }
        public BERegistroNew objDiaSemana { get; set; }
        public BEPuntoDeVenta objPuntoDeVenta { get; set; }
        public BEPersona objEmpresa { get; set; }

        ////[NotMapped]
        public string CodigoArguTipoTurnoNombre { get; set; }
        ////[NotMapped]
        public string CodigoArguDiaSemanaNombre { get; set; }
        ////[NotMapped]
        public string CodigoPersonaEmpreNombre { get; set; }
        ////[NotMapped]
        public string CodigoPuntoVentaNombre { get; set; }

    }
}
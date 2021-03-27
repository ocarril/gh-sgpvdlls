namespace CROM.BusinessEntities.Comercial
{
    using CROM.BusinessEntities.Caja.response;
    using CROM.BusinessEntities.Cajas;
    using CROM.BusinessEntities.Maestros;
    using CROM.BusinessEntities.RecursosHumanos;

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.ParteDiario.cs]
    /// </summary>
    public class BEParteDiario : BEBase
    {
        public BEParteDiario()
        {
            objEmpleado = new BEEmpleado();
            objEmpresa= new BEPersona();
            objPuntoDeVenta= new BEPuntoDeVenta();
            objTurno= new BEParteDiarioTurno();
            listaCajaRegistro = new List<CajaRegistroAux>();
            lstCajaRegistro = new List<DTOCajaRegistroResponse>();
        }

        public string CodigoParte { get; set; }
        public string CodigoPersonaEmpre { get; set; }
        public string CodigoPuntoVenta { get; set; }
        public DateTime FechaParte { get; set; }
        public int? codEmpleado { get; set; }
        public string Observaciones { get; set; }
        public string CodigoTurno { get; set; }
        public string Turno { get; set; }
        public bool CajaActiva { get; set; }
        public bool Caja { get; set; }
        public bool Estado { get; set; }
        public string Descripcion { get; set; }
        public decimal TotalIngreso { get; set; }
        public decimal TotalEgreso { get; set; }
        
        ////////[NotMapped]
        public string CodigoPersonaEmpreNombre { get; set; }
        ////[NotMapped]
        public string CodigoPuntoVentaNombre { get; set; }
        ////[NotMapped]
        public string codEmpleadoNombre { get; set; }
        ////[NotMapped]
        public string CodigoTurnoNombre { get; set; }
        ////[NotMapped]
        public string FechaParteYYYMMDD { get; set; }
        ////[NotMapped]
        public string CodigoParteAux { get; set; }
        ////[NotMapped]
        public decimal TotalSaldo { get; set; }
        ////[NotMapped]
        public string Horario { get; set; }

        public List<CajaRegistroAux> listaCajaRegistro { get; set; }

        public List<DTOCajaRegistroResponse> lstCajaRegistro { get; set; }
        public BEEmpleado objEmpleado { get; set; }
        public BEParteDiarioTurno objTurno { get; set; }
        public BEPuntoDeVenta objPuntoDeVenta { get; set; }
        public BEPersona objEmpresa { get; set; }
    }
} 

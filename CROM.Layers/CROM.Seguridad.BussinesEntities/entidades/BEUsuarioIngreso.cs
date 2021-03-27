using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CROM.Seguridad.BussinesEntities
{ 
	/// <summary>
	/// Proyecto    :  Modulo de Mantenimiento de : 
	/// Creacion    : CROM - Orlando Carril Ramírez
	/// Fecha       : 12/11/2011-09:45:33 a.m.
	/// Descripcion : Capa de Entidades 
	/// Archivo     : [Seguridad.UsuarioIngreso.cs]
	/// </summary>
    [DataContract]
	public class BEUsuarioIngreso
	{
        [DataMember]
        public string codUsuario { get; set; }
        [DataMember]
        public string codSistema { get; set; }
        [DataMember]
        public string codRol { get; set; }
        [DataMember]
        public string desLogin { get; set; }
        [DataMember]
        public DateTime fecAcceso { get; set; }
        [DataMember]
        public string desIngreso { get; set; }
        [DataMember]
        public DateTime segFechaHoraEdita { get; set; }
        [DataMember]
        public string segMaquinaOrigen { get; set; }
	}

    public class BEUsuarioIngresoAux : BEUsuarioIngreso
    {
        [DataMember]
        public string codUsuarioNombre { get; set; }
        [DataMember]
        public string codSistemaNombre { get; set; }
        [DataMember]
        public string codRolNombre { get; set; }
        [DataMember]
        public string desLoginActual { get; set; }
    } 
} 

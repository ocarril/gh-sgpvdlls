using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using CROM.Seguridad.BussinesEntities.entidades.dto;

namespace CROM.Seguridad.BussinesEntities
{
    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de SEGURIDAD del Sistema 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 06/11/2009
    /// Fecha edit  : 07/10/2011
    /// Descripcion : Entidad de negocio
    /// Archivo     : UsuarioRol.cs
    /// </summary>
    [DataContract]
    public class BEUsuarioRol:BEBase
    {
        [DataMember]
        public int codUsuarioRol { get; set; }
        [DataMember]
        public string codUsuario { get; set; }
        [DataMember]
        public string codRol { get; set; }
        [DataMember]
        public string codSistema { get; set; }
        [DataMember]
        public bool indEstado { get; set; }
        [DataMember]
        public int codEmpresa { get; set; }
    }

    [DataContract]
    public class BEUsuarioRolAux : BEUsuarioRol
    {
        [DataMember]
        public string codRolNombre { get; set; }
        [DataMember]
        public string codSistemaNombre { get; set; }
        [DataMember]
        public string codUsuarioNombre { get; set; }
        [DataMember]
        public string codUsuarioLogin { get; set; }
    }


    [DataContract]
    public class BEUsuarioRolResponse : BEBasePaged
    {
        public int codUsuarioRol { get; set; }

        public int codEmpresa { get; set; }

        public string codSistema { get; set; }

        public string codUsuario { get; set; }

        public string codRol { get; set; }

        public bool indEstado { get; set; }

        public string codRolNombre { get; set; }

        public string codSistemaNombre { get; set; }

        public string codUsuarioNombre { get; set; }

        public string codUsuarioLogin { get; set; }

        public string codEmpresaNombre { get; set; }
    }
}

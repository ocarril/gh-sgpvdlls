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
    /// Archivo     : Rol.cs
    /// </summary>
    [DataContract]
    public class BERol: BEBase
    {
        [DataMember]
        public string codRol { get; set; }
        [DataMember]
        public string codSistema { get; set; }
        [DataMember]
        public string desNombre { get; set; }
        [DataMember]
        public string desDescripcion { get; set; }
        [DataMember]
        public bool indEstado { get; set; }
        
    }

    [DataContract]
    public class BERolAux : BERol
    {
        [DataMember]
        public string codSistemaNombre { get; set; }
    }

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de SEGURIDAD del Sistema 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 06/11/2009
    /// Fecha edit  : 17/09/2019
    /// Descripcion : Entidad de negocio
    /// Archivo     : Rol.cs
    /// </summary>
    public class BERolResponse : BEBasePaged
    {
        public BERolResponse()
        {
            codRol = string.Empty;
            codSistema = string.Empty;
            desNombre = string.Empty;
            desDescripcion = string.Empty;
        }

        public string codRol { get; set; }

        public string codSistema { get; set; }

        public string desNombre { get; set; }

        public string desDescripcion { get; set; }

        public bool indEstado { get; set; }

        public string codSistemaNombre { get; set; }

    }
}

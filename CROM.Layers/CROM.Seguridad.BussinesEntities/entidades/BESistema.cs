using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CROM.Seguridad.BussinesEntities.entidades.dto;

namespace CROM.Seguridad.BussinesEntities
{
    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de SEGURIDAD del Sistema 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 06/11/2009
    /// Fecha edit  : 07/10/2011
    /// Descripcion : Entidad de negocio
    /// Archivo     : Sistema.cs
    /// </summary>
    [DataContract]
    public class BESistema:BEBase
    {
        #region Entidades
        [DataMember]
        public string codSistema { get; set; }
        [DataMember]
        public string desNombre { get; set; }
        [DataMember]
        public string desDescripcion { get; set; }
        [DataMember]
        public bool indEstado { get; set; }
        
        
        #endregion
    }


    public class BESistemaResponse: BEBasePaged
    {
        public BESistemaResponse()
        {

        }

        #region Entidades
        public string codSistema { get; set; }
        [DataMember]
        public string desNombre { get; set; }
        [DataMember]
        public string desDescripcion { get; set; }
        [DataMember]
        public bool indEstado { get; set; }
        
        #endregion
    }
}

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
    /// Archivo     : Opcion.cs
    /// </summary>
    /// 
    [DataContract]
    public class BEOpcion: BEBase
    {
        [DataMember]
        public string codOpcion { get; set; }
        [DataMember]
        public string codOpcionPadre { get; set; }
        [DataMember]
        public string codSistema { get; set; }
        [DataMember]
        public string desNombre { get; set; }
        [DataMember]
        public string desDescripcion { get; set; }
        [DataMember]
        public string desEnlaceURL { get; set; }
        [DataMember]
        public string desEnlaceWIN { get; set; }
        [DataMember]
        public bool  indMenu { get; set; }
        [DataMember]
        public bool indEstado { get; set; }
        
        [DataMember]
        public string segMaquinaOrigen { get; set; }

        [DataMember]
        public int numOrden { get; set; }
        [DataMember]
        public string nomIcono { get; set; }
        [DataMember]
        public string indTipoObjeto { get; set; }
        [DataMember]
        public string codElementoID { get; set; }
    }

    [DataContract]
    public class BEOpcionAux : BEOpcion
    {
        [DataMember]
        public string codSistemaNombre { get; set; }
    }

    public class BEOpcionResponse: BEBasePaged
    {
        public string codSistemaNombre { get; set; }

        public string codOpcion { get; set; }
         public string codOpcionPadre { get; set; }

        public string codOpcionPadreNombre { get; set; }

        public string codSistema { get; set; }

        public string desNombre { get; set; }

        public string desDescripcion { get; set; }

        public string desEnlaceURL { get; set; }

        public string desEnlaceWIN { get; set; }

        public bool indMenu { get; set; }

        public bool indEstado { get; set; }

        public string indTipoObjeto{ get; set; }

        public string codElementoID{ get; set; }

        public string nomIcono     { get; set; }

        public int numOrden     { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using CROM.Seguridad.BussinesEntities.entidades.dto;
using Newtonsoft.Json;

namespace CROM.Seguridad.BussinesEntities
{
    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de SEGURIDAD del Sistema 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 06/11/2009
    /// Fecha edit  : 07/10/2011
    /// Descripcion : Entidad de negocio
    /// Archivo     : RolOpcion.cs
    /// </summary>
    [DataContract]
    public class BERolOpcion : BEBase
    {

        [DataMember]
        public int codRolOpcion { get; set; }
        [DataMember]
        public string codRol { get; set; }
        [DataMember]
        public string codOpcion { get; set; }
        [DataMember]
        public bool indVer { get; set; }
        [DataMember]
        public bool indNuevo { get; set; }
        [DataMember]
        public bool indEditar { get; set; }
        [DataMember]
        public bool indEliminar { get; set; }
        [DataMember]
        public bool indImprime { get; set; }
        [DataMember]
        public bool indImporta { get; set; }
        [DataMember]
        public bool indExporta { get; set; }
        [DataMember]
        public bool indOtro { get; set; }
        [DataMember]
        public bool indMenu { get; set; }

        [DataMember]
        public string segMaquinaOrigen { get; set; }

        [DataMember]
        public bool indActivo { get; set; }
    }

    [DataContract]
    public class BERolOpcionAux : BERolOpcion
    {
        [DataMember]
        public bool indAsignar { get; set; }
        [DataMember]
        public string codOpcionNombre { get; set; }
        [DataMember]
        public string codOpcionDescripcion { get; set; }
        [DataMember]
        public string codRolNombre { get; set; }
        [DataMember]
        public string codOpcionEnlaceWIN { get; set; }
        [DataMember]
        public string codOpcionEnlaceURL { get; set; }
        [DataMember]
        public string codOpcionPadre { get; set; }


    }


    public class BERolOpcionResponse : BEBasePaged
    {
        public BERolOpcionResponse()
        {

        }

        public int codRolOpcion { get; set; }

        public string codOpcionNombre { get; set; }

        public string codElementoID { get; set; }
        public string desEnlaceURL { get; set; }
        public string desEnlaceWIN { get; set; }

        public string codRolNombre { get; set; }

        public string codSistemaNombre { get; set; }

        public bool indActivo { get; set; }


        [JsonProperty("indVer")]
        public bool indVer { get; set; }

        [JsonProperty("indNuevo")]
        public bool indNuevo { get; set; }

        [JsonProperty("indEditar")]
        public bool indEditar { get; set; }

        [JsonProperty("indEliminar")]
        public bool indEliminar { get; set; }

        [JsonProperty("indImprime")]
        public bool indImprime { get; set; }

        [JsonProperty("indImporta")]
        public bool indImporta { get; set; }

        [JsonProperty("indExporta")]
        public bool indExporta { get; set; }

        [JsonProperty("indOtro")]
        public bool indOtro { get; set; }

        public string indTipoObjeto { get; set; }

        public string nomIcono { get; set; }

        public int numOrden { get; set; }
    }
}

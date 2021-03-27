namespace CROM.Seguridad.BussinesEntities
{
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de SEGURIDAD del Sistema 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 06/11/2009
    /// Fecha edit  : 07/10/2011
    /// Descripcion : Entidad de negocio
    /// Archivo     : Usuarios.cs
    /// </summary>
    [DataContract]
    public class BEUsuario : BEBase
    {

        #region Entidades
        [DataMember]
        public string codUsuario { get; set; }

        [DataMember]
        public string desLogin { get; set; }

        [DataMember]
        public string clvPassword { get; set; }

        public string clvPasswordEncrypt { get; set; }

        [DataMember]
        public string desNombres { get; set; }

        [DataMember]
        public string desApellidos { get; set; }

        [DataMember]
        public string desPregunta { get; set; }

        [DataMember]
        public string desRespuesta { get; set; }

        [DataMember]
        public string desTelefono { get; set; }

        [DataMember]
        public string desCorreo { get; set; }

        [DataMember]
        public bool indRestricPorPais { get; set; }

        [DataMember]
        public string codArguPais { get; set; }

        [DataMember]
        public string codEmpleado { get; set; }

        [DataMember]
        public bool indVendedor { get; set; }

        [DataMember]
        public bool indCambioPrecio { get; set; }

        [DataMember]
        public bool indAccesoGerencial { get; set; }

        [DataMember]
        public bool indCambiaDescuento { get; set; }

        [DataMember]
        public bool indCambiaCodPersona { get; set; }

        [DataMember]
        public bool indJefeCaja { get; set; }

        [DataMember]
        public bool indUsuarioSistema { get; set; }

        [DataMember]
        public bool indEstado { get; set; }

        [DataMember]
        public string segMaquinaOrigen { get; set; }





        [DataMember]
        [JsonProperty("urlPhotoUser")]
        public string urlPhotoUser { get; set; }


        [DataMember]
        [JsonProperty("indOrigenUser")]
        public string indOrigenUser { get; set; }

        [DataMember]
        [JsonProperty("codGUID")]
        public string codGUID { get; set; }


        [JsonIgnore]
        public bool indPasswordReset { get; set; }

        [JsonIgnore]
        public bool indLockUser { get; set; }

        [JsonIgnore]
        public Nullable<DateTime> fecBloqueUpdate { get; set; }

        #endregion
    }

    [DataContract]
    public class BEUsuarioAux : BEUsuario
    {
        public BEUsuarioAux()
        {
            listaRolOpcion = new List<BERolOpcionAux>();
            listaUsuarioIngreso = new List<BEUsuarioIngresoAux>();
        }

        [DataMember]
        public string desApellidosNombres { get; set; }
        [DataMember]
        public string codrguPaisNombre { get; set; }
        [DataMember]
        public string codRol { get; set; }
        [DataMember]
        public string codRolNombre { get; set; }
        [DataMember]
        public string codPersonaEmpresa { get; set; }
        [DataMember]
        public string codPersonaRUCEmpresa { get; set; }
        [DataMember]
        public string codPersonaEmpresaNombre { get; set; }
        [DataMember]
        public string codPersonaEmpresaDomicilio { get; set; }
        [DataMember]
        public string codPuntoVenta { get; set; }
        [DataMember]
        public string codPuntoVentaNombre { get; set; }
        [DataMember]
        public List<BERolOpcionAux> listaRolOpcion { get; set; }
        [DataMember]
        public List<BEUsuarioIngresoAux> listaUsuarioIngreso { get; set; }

        //[DataMember]
        //public string codDeposito { get; set; }
        //[DataMember]
        //public string codDepositoNombre { get; set; }

    }


}

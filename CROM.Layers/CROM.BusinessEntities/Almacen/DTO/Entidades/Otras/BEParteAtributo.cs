namespace CROM.BusinessEntities.Almacen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 26/02/2010-09:55:44 
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Produccion.PartesAtributos.cs]
    /// </summary>
    public class BEParteAtributo
    {
        public string CodigoArguParteProdu { get; set; }
        public string CodigoArguAtributoPP { get; set; }
        public bool Estado { get; set; }
        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public DateTime SegFechaCrea { get; set; }
        public DateTime SegFechaEdita { get; set; }
        public string SegMaquina { get; set; }

        public string CodigoArguParteProduNombre { get; set; }
        public string CodigoArguAtributoPPNombre { get; set; }
    }
}

namespace CROM.BusinessEntities.Cajas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 05/09/2010-04:20:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [CajaBancos.FormasDePago.cs]
    /// </summary>
    public class BEFormaDePago : BEBase
    {
        public int codFormaDePago { get; set; }
        public string desNombre { get; set; }
        public bool indVenta { get; set; }
        public bool indCobranza { get; set; }
        public bool indIngreso { get; set; }
        public bool indEgreso { get; set; }
        public bool indNotacredito { get; set; }
        public bool indActivo { get; set; }

    }
}

namespace CROM.BusinessEntities.Comercial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/03/2011-05:08:50 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.ListaDePrecio.cs]
    /// </summary>
    public class BEListaDePrecio : BEBase
    {
        public BEListaDePrecio()
        {
            listaListaDePrecioDetalle = new List<BEListaDePrecioDetalle>();
        }

        public string CodigoLista { get; set; }
        public string CodigoPersonaEmpre { get; set; }
        public string CodigoPuntoVenta { get; set; }
        public string Descripcion { get; set; }
        public bool EsParaVenta { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaGenerada { get; set; }
        public bool Estado { get; set; }

        public List<BEListaDePrecioDetalle> listaListaDePrecioDetalle { get; set; }
        public string CodigoPersonaEmpreNombre { get; set; }
        public string CodigoPuntoVentaNombre { get; set; }

    }
}

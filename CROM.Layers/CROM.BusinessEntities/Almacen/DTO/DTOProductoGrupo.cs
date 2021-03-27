namespace CROM.BusinessEntities.Almacen
{
    using System;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Produccion.ProductoGrupos.cs]
    /// </summary>
    public class DTOProductoGrupo : BEBasePagedResponse
    {
        public string codPersonaEmpre { get; set; }
        public string CodigoGrupo { get; set; }
        public string CodigoGrupoRef { get; set; }
        public string CodigoArguLineaProd { get; set; }
        public string CodigoArguMaterialProd { get; set; }
        public string CodigoArguUnidadMed { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public string SegUsuarioCrea { get; set; }
        public string SegUsuarioEdita { get; set; }
        public DateTime SegFechaCrea { get; set; }
        public Nullable<DateTime> SegFechaEdita { get; set; }
        public string SegMaquina { get; set; }

        public string CodigoArguLineaProdNombre { get; set; }
        public string CodigoArguMaterialProdNombre { get; set; }
        public string CodigoArguUnidadMedNombre { get; set; }

    }
}

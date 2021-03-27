namespace CROM.BusinessEntities.Almacen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 20/04/2013-05:39:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Almacen.Grupo.cs]
    /// </summary>
    public class BEGrupo : BEBase
    {
        public int codGrupo { get; set; }
        public string codPersonaEmpre { get; set; }
        public string codGrupoRef { get; set; }
        public string codRegLinea { get; set; }
        public string codRegMaterial { get; set; }
        public string codRegUnidadMedida { get; set; }
        public string desNombre { get; set; }
        public bool indActivo { get; set; }
    }

    public class GrupoAux : BEGrupo
    {
        public string auxcodRegLineaProdNombre { get; set; }
        public string auxcodRegMaterialProdNombre { get; set; }
        public string auxcodRegUnidadMedNombre { get; set; }
    }
}

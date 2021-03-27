namespace CROM.BusinessEntities.Almacen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 19/07/2014-01:57:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.InventarioDocumReg.cs]
    /// </summary>
    public class BEInventarioDocumReg : BEBase
    {
        public int codInventarioDocumReg { get; set; }
        public string strPeriodo { get; set; }
        public int codInventario { get; set; }
        public int codDocumReg { get; set; }
        public bool indActivo { get; set; }

        public BEInventarioDocumReg()
        {

        }
    }
}

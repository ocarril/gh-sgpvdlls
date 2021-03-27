namespace CROM.BusinessEntities.Comercial
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m./ 07-feb-2018 05:14
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.CondicionVenta.cs]
    /// </summary>
    public class BECondicion : BEBase
    {
        public BECondicion()
        {
            desNombre = string.Empty;
            numCuota = 1;
            numDiasCCtaCte = 0;
            numDiasCVcto = 1;
        }

        public int codCondicion { get; set; }
        public string desNombre { get; set; }
        public int numCuota { get; set; }
        public int numDiasCCtaCte { get; set; }
        public int numDiasVCtaCte { get; set; }
        public int numDiasCVcto { get; set; }
        public int numDecimalRedondeo { get; set; }
        public bool indEsGravaCtaCte { get; set; }
        public bool indEsPredeterminado { get; set; }
        public bool indEsContraEntrega { get; set; }
        public bool indEsEnCuota { get; set; }
        public bool indEsVenta { get; set; }
        public bool indActivo { get; set; }

    }
}

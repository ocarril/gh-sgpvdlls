namespace CROM.BusinessEntities.Comercial
{

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 18/09/2010-5:10:36
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.TiposDeImpuesto.cs]
    /// </summary>
    public class BEImpuesto: BEBase
    {
        public BEImpuesto()
        {
            Descripcion = string.Empty;
            CodigoArguAbrevFiscal = string.Empty;
        }

        public string CodigoImpuesto { get; set; }
        public string Descripcion { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal Porcentaje100 { get; set; }
        public decimal PorceAcre { get; set; }
        public bool DiscriminaAcrec { get; set; }
        public bool DiscriminaIGV { get; set; }
        public bool DiscriminaIngBruto { get; set; }
        public string CodigoArguAbrevFiscal { get; set; }
        public bool Estado { get; set; }

    }
}

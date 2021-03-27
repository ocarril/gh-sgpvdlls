namespace CROM.BusinessEntities.Comercial
{

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 18/09/2010-5:10:36
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.TiposDeImpuesto.cs]
    /// </summary>
    public class DTOImpuestoResponse : BEBaseEntidadItem
    {
        public DTOImpuestoResponse()
        {
            desNombre = string.Empty;
            codImpuestoSUNAT = string.Empty;
        }

        public string codImpuesto { get; set; }
        public string codImpuestoSUNAT { get; set; }
        public string desNombre { get; set; }
        public decimal prcValor { get; set; }
        public decimal prcValor100 { get; set; }
        public decimal prcAcrec { get; set; }
        public bool indDiscriminaAcrec { get; set; }
        public bool indDiscriminaIGV { get; set; }
        public bool indDiscriminaIngBruto { get; set; }

    }
}

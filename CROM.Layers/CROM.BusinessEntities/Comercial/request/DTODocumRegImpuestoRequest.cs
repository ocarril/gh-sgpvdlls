namespace CROM.BusinessEntities.Comercial.request
{
    public class DTODocumRegImpuestoRequest: BEBaseEntidadRequest
    {
        public DTODocumRegImpuestoRequest()
        {

        }

        public int codDocumRegImpuesto { get; set; }

        public int codDocumReg { get; set; }

        public string codImpuesto { get; set; }

        public decimal prcValorImpuesto { get; set; }

        public decimal mntValorTotalImpuesto { get; set; }

    }
}

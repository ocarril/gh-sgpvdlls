namespace CROM.BusinessEntities.Comercial.emision.request
{
    public class BEDocumRegImpuestoRequest: BEBaseEntidadRequest
    {
        public BEDocumRegImpuestoRequest()
        {

        }

        public int codDocumRegImpuesto { get; set; }

        public int codDocumReg { get; set; }

        public string codImpuesto { get; set; }

        public decimal prcValorImpuesto { get; set; }

        public decimal mntValorTotalImpuesto { get; set; }

    }
}

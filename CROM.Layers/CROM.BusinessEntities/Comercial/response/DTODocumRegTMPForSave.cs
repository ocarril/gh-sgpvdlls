namespace CROM.BusinessEntities.Comercial.response
{
    using CROM.BusinessEntities.Comercial.emision.request;
    using System.Collections.Generic;


    public class DTODocumRegTMPForSave
    {
        public DTODocumRegTMPForSave()
        {
            ListDetails = new List<DTODocumRegDetalleResponseSave>();
            ListChargeDiscount = new List<BEDocumRegCargoDescuentoRequest>();
        }

        public List<DTODocumRegDetalleResponseSave> ListDetails { get; set; }

        public List<BEDocumRegCargoDescuentoRequest> ListChargeDiscount { get; set; }

    }
}

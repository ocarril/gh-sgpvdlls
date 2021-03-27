namespace CROM.BusinessEntities.SUNAT.ubl21.aggregate
{
    using CROM.BusinessEntities.SUNAT.ubl21.basic;

    using System;


    [Serializable]
    public class DespatchLine
    {
        public int Id { get; set; }

        public InvoicedQuantity DeliveredQuantity { get; set; }

        /// <summary>
        /// cac:OrderLineReference/cbc:LineID
        /// </summary>
        public int OrderLineReferenceId { get; set; }

        public DespatchLineItem Item { get; set; }
    }
}

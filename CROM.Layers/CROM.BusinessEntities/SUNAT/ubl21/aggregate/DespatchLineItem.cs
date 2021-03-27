namespace CROM.BusinessEntities.SUNAT.ubl21.aggregate
{
    using System;


    [Serializable]
    public class DespatchLineItem
    {
        public string Description { get; set; }

        /// <remarks>
        /// cac:SellersItemIdentification/cbc:ID
        /// </remarks>
        public string SellersIdentificationId { get; set; }
    }
}

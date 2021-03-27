namespace CROM.BusinessEntities.SUNAT.ubl21.aggregate
{
    using System;


    [Serializable]
    public class AccountingSupplierParty
    {
        public string CustomerAssignedAccountId { get; set; }

        public string AdditionalAccountId { get; set; }

        public string CodDomicilioFiscal { get; set; }

        public Party Party { get; set; }

    }
}

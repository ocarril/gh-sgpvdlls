namespace CROM.BusinessEntities.SUNAT.ubl21.basic
{
    using System;


    [Serializable]
    public class PayableAmount
    {
        public string CurrencyId { get; set; }

        public decimal Value { get; set; }

        public decimal MultiplierFactorNumeric { get; set; }
    }
}

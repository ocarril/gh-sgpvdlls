namespace CROM.BusinessEntities.SUNAT.ubl21.interfaces
{
    using System;

    public interface IEstructuraXml
    {
        string UblVersionId { get; set; }

        string CustomizationId { get; set; }

        string Id { get; set; }

        IFormatProvider Formato { get; set; }
    }
}

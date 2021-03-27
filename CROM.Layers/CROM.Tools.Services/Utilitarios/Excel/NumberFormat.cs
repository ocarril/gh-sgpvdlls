namespace CROM.Tools.Services.Utilitarios.Excel
{
    using System;
    using System.Collections.Generic;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    using DocumentFormat.OpenXml;

    public class NumberFormat
    {
        public NumberingFormats numberingFormats { get; set; }
        public uint HomeIndex { get; set; }
        public NumberingFormat TwoDecimalFormat { get; set; }
        public NumberingFormat PercentageFormat { get; set; }

        public NumberFormat()
        {
            this.numberingFormats = new NumberingFormats();
            this.HomeIndex = 164;
            this.TwoDecimalFormat = CreateTwoDecimalFormat();
            this.PercentageFormat = CreateFormatPercent();
        }


        private NumberingFormat CreateTwoDecimalFormat() {
            NumberingFormat decimalFormat2 = new NumberingFormat();
            decimalFormat2.NumberFormatId = UInt32Value.FromUInt32(HomeIndex++);
            decimalFormat2.FormatCode = StringValue.FromString("#,##0.00");
            this.numberingFormats.Append(decimalFormat2);

            return decimalFormat2;
        }

        private NumberingFormat CreateFormatPercent()
        {
            NumberingFormat percentageFormat = new NumberingFormat();
            percentageFormat.NumberFormatId = UInt32Value.FromUInt32(HomeIndex++);
            percentageFormat.FormatCode = StringValue.FromString("#,##0.00%");
            this.numberingFormats.Append(percentageFormat);

            return percentageFormat;
        }
    }

    
}

namespace CROM.Tools.Comun.utils.excel
{
    /// <summary>
    /// Objeto que define un tipo de estilo a ser usado por una o mas celdas
    /// </summary>
    /// <remarks>
    /// Creacion: 	LOG(EMP) 20120620 <br />
    /// </remarks>
    public class Style
    {
        public Style()
        {
            this.BackGroundColor = "ffffff";
            this.Color = "000000";
            this.Border = false;
            this.FontBold = false;
            this.FontSize = 11;
        }

        public string Id { get; set; }

        public string FontName { get; set; }
        public int FontSize { get; set; }
        public bool FontBold { get; set; }
        public string Color { get; set; }

        public string BackGroundColor { get; set; }
        public bool Border { get; set; }

        public int StyleIndex { get; set; }
        public uint FontId { get; set; }
        public uint FillId { get; set; }
        public bool WrapText { get; set; }

        public uint? NumericFormat { get; set; }

        public HorizontalAlignmentOptions HorizontalAlignment { get; set; }

        public enum HorizontalAlignmentOptions : int
        {
            Left = 1,
            Center = 2,
            Right = 3
        }
    }
}

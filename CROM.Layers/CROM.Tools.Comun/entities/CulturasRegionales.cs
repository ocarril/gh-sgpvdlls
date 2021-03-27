namespace CROM.Tools.Comun.entities
{
    public class CulturasRegionales
    {
        public CulturasRegionales()
        {
            CodArguPais = string.Empty;
            NativeName = string.Empty;
            DisplayName = string.Empty;
            EnglishName = string.Empty;
            LCID = string.Empty;
        }
        public string CodArguPais { get; set; }
        public string NativeName { get; set; }
        public string DisplayName { get; set; }
        public string EnglishName { get; set; }
        public string LCID { get; set; }

    }
}

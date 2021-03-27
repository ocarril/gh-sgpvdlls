namespace CROM.Tools.Comun.Web
{
    using System.Collections.Generic;
    using System.IO;


    public class HelperThemas
    {
        public static List<ThemasType> ListaThemas(string fileThemas)
        {
            List<ThemasType> misThemas = new List<ThemasType>();
            foreach (DirectoryInfo cheminThemas in (new FileInfo(fileThemas).Directory.GetDirectories()))
            {
                string thema = cheminThemas.Name;
                ThemasType miThema = new ThemasType();
                miThema.nameThemas = thema;
                miThema.nameDescri = thema;
                misThemas.Add(miThema);
            }
            return (misThemas);
        }
    }
}

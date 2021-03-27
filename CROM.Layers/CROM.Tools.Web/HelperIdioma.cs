using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Globalization;
using CROM.Tools.Comun.settings;

namespace CROM.Tools.Web
{
    public class HelperIdioma
    {
        protected System.Resources.ResourceManager rm = null;
        public HelperIdioma(string pCultura, string pRecursoResx)
        {
            string nombreDLL = "CROM.Time.RecursoIdioma." + pCultura;
            string nombreRecurso = "CROM.Time.RecursoIdioma." + pCultura.Replace("-", "_") + "." + pRecursoResx;
            rm = new System.Resources.ResourceManager(nombreRecurso, System.Reflection.Assembly.Load(nombreDLL));
        }


        public static List<IdiomaDataType> ListaIdiomas()
        {
            List<IdiomaDataType> misIdiomas = new List<IdiomaDataType>();
            string PrefijoclaseIdioma = GlobalSettings.GetPrefijoclaseIdioma();
            string PathFilesIdiomasCl = GlobalSettings.GetPathFilesIdiomasCl();
            string NombreIdiomaComple = GlobalSettings.GetNombreIdiomaComple();

            foreach (FileInfo cheminAssembly in (new FileInfo(PathFilesIdiomasCl).Directory.GetFiles(PrefijoclaseIdioma + "*.dll")))
            {
                string cultura = cheminAssembly.Name.Substring(PrefijoclaseIdioma.Length, 5);
                CultureInfo miCultura = new CultureInfo(cultura);
                IdiomaDataType miIdioma = new IdiomaDataType();
                miIdioma.nameCultura = cultura;
                if (NombreIdiomaComple == "0")
                    miIdioma.nameIdioma = miCultura.NativeName;
                else
                    miIdioma.nameIdioma = miCultura.NativeName.Substring(0, miCultura.NativeName.IndexOf(" "));
                misIdiomas.Add(miIdioma);
            }
            return (misIdiomas);
        }

        public string mGetString(string objNonbre)
        {
            string traducido = string.Empty;
            traducido = rm.GetString(objNonbre);

            return traducido;
        }

        public static string mensaje(string idioma, string nombre)
        {
            string lsMensaje = String.Empty;

            switch (idioma)
            {
                case "ES":
                    {

                        lsMensaje = "";
                    }
                    break;
                case "EN":
                    {
                        lsMensaje = "";
                    }
                    break;
            }
            return lsMensaje;
        }
    }
}
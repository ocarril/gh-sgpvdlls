namespace CROM.Tools.Comun
{
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.settings;

    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;


    public static class HelpCulture
    {
        public static string FormateaFechaYMD(DateTime fecha)
        {
            return String.Format("{0}{1}{2}", fecha.Year, fecha.Month.ToString().PadLeft(2, '0'), fecha.Day.ToString().PadLeft(2, '0'));
        }

        public static List<CulturasRegionales> CulturasRegionales( Helper.ComboBoxText pTexto)
        {
            List<CulturasRegionales> listaCulturasRegionales = new List<CulturasRegionales>();
            foreach (CultureInfo Culturas in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                listaCulturasRegionales.Add(new CulturasRegionales()
                {
                    CodArguPais = Culturas.Name,
                    NativeName = Culturas.NativeName,
                    DisplayName = Culturas.DisplayName,
                    EnglishName = Culturas.EnglishName,
                    LCID = Culturas.LCID.ToString()
                });
            }
            var query = from culturas in listaCulturasRegionales
                        orderby culturas.DisplayName
                        select culturas;
            List<CulturasRegionales> listaCulturasRegionalesOrder = new List<CulturasRegionales>();
            listaCulturasRegionalesOrder = query.ToList<CulturasRegionales>();
            if (listaCulturasRegionalesOrder.Count > 0)
                listaCulturasRegionalesOrder.Insert(0, new CulturasRegionales { CodArguPais = "", DisplayName = Helper.ObtenerTexto(pTexto) });
            else
                listaCulturasRegionalesOrder.Add(new CulturasRegionales { CodArguPais = "", DisplayName = Helper.ObtenerTexto(pTexto) });
            return listaCulturasRegionalesOrder;
        }

        public static DateTime ConvertAFechaNuevo(string strDate)
        {
            DateTime fecConvertida = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud());
            try
            {
                string strConReg = GlobalSettings.GetDEFAULT_Idioma();
                CultureInfo provider = new CultureInfo("es-PE");
                fecConvertida = DateTime.ParseExact(strDate, "d", provider);
            }
            catch (Exception ex)
            {

                throw new Exception("El formato de fecha es incorrecto. " + ex.Message );
            }

            return fecConvertida;
        }
    }
}

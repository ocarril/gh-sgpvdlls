namespace CROM.Tools.Comun.utils.excel
{
    using System.Collections.Generic;

    /// <summary>
    /// Clase que contiene la libreria de estilos a ser usados en la generación de los excel
    /// se pretende centralizar
    /// </summary>
    /// <remarks>
    /// Creacion: 	LOG(DQY) 20120907 <br />
    /// </remarks>
    public static class EstilosPlanit
    {
        //TODO : LOG(DQY) Pendiente de renombrar y reubicar clase y archivo

        private static IDictionary<string, Style> ObtenerDiccionarioDeEstilos()
        {
            IDictionary<string, Style> dicccionarioEstilos = new Dictionary<string,Style>();

            dicccionarioEstilos.Add(IdentificadoresCabecera.CabeceraSubtitulo, new Style { Id = IdentificadoresCabecera.CabeceraSubtitulo, BackGroundColor = "8064A2", Border = true, FontBold = false, FontSize = 11, Color = "ffffff", HorizontalAlignment = Style.HorizontalAlignmentOptions.Center });
            dicccionarioEstilos.Add(IdentificadoresCabecera.TitulosColumna, new Style { Id = IdentificadoresCabecera.TitulosColumna, BackGroundColor = "990066", Border = true, FontBold = true, FontSize = 12, Color = "ffffff", HorizontalAlignment = Style.HorizontalAlignmentOptions.Center });
            dicccionarioEstilos.Add(IdentificadoresCabecera.CabeceraCampania, new Style { Id = IdentificadoresCabecera.CabeceraCampania, BackGroundColor = "FFE38B", Border = true, FontBold = true, FontSize = 9, Color = "000000", HorizontalAlignment = Style.HorizontalAlignmentOptions.Center });
            dicccionarioEstilos.Add(IdentificadoresCabecera.TituloReporte, new Style { Id = IdentificadoresCabecera.TituloReporte, BackGroundColor = "F2F2F2", Border = false, FontBold = true, FontSize = 20, Color = "000000", HorizontalAlignment = Style.HorizontalAlignmentOptions.Left });

            return dicccionarioEstilos;
        }

        public static Style ObtenerEstilo(string llave)
        {
            Style estiloBuscado = null;

            var diccionarioEstilo = ObtenerDiccionarioDeEstilos();

            estiloBuscado = diccionarioEstilo[llave];

            return estiloBuscado;
        }

        public struct IdentificadoresCabecera
        {
            public const string CabeceraSubtitulo = "CabeceraSubtitulo";
            public const string TitulosColumna = "TitulosColumna";
            public const string CabeceraCampania = "CabeceraCampania";
            public const string TituloReporte = "TituloReporte";
        }
    }
}

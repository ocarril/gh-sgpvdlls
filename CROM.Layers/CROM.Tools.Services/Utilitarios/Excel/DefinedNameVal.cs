namespace CROM.Tools.Services.Utilitarios.Excel
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    //using Belcorp.Planit.Domain.Entities.Views;
    using DocumentFormat.OpenXml.Spreadsheet;

    /// <summary>
    /// Objeto que representa una hoja de excel
    /// </summary>
    /// <remarks>
    /// Creacion: 	LOG(JLRR) 20121005 <br />
    /// </remarks>
    public class DefinedNameVal
    {
        public string Key { get; set; }
        public string SheetName { get; set; }
        public string StartColumn { get; set; }
        public string EndColumn { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
    }
}

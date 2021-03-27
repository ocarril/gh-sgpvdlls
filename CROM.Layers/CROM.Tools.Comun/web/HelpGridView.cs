namespace CROM.Tools.Comun.Web
{
    using System.Web.UI.WebControls;
    
    public class HelpGridView
    {
        public static void Caption(ref GridView pGridView, string pTitulo, string RowCount)
        {
            string lRowCount = "<div style='width:140px; float:right; font-size:11px'>" + "Nº de Registros:  " + RowCount.PadLeft(5, '0') + "</div>";
            string lTitulo = "<div style=' float:left;'>" + pTitulo + "</div>";
            pGridView.Caption = lTitulo + lRowCount;


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;

namespace CROM.Tools.Web
{
    public class Menus
    {

        private string MenuId = "CodigoOpcion";
        private string PadreId = "CodigoPadre";
        private string descripcion ="Nombre";
        private string Url = "EnlaceURL";

        public void CreateMenu(ref Menu mnuPrincipal, DataTable dtMenuItems)
        {
            mnuPrincipal.DynamicMenuItemStyle.CssClass = "cssLabel";
            foreach (DataRow drMenuItem in dtMenuItems.Rows)
            {

                //esta condicion indica q son elementos padre.
                if (drMenuItem[MenuId].Equals(drMenuItem[PadreId]) || drMenuItem[PadreId].ToString() == "")
                {
                    MenuItem mnuMenuItem = new MenuItem();
                    mnuMenuItem.Value = drMenuItem[MenuId].ToString();
                
                    mnuMenuItem.Text = drMenuItem[descripcion].ToString();
                    //mnuMenuItem.ImageUrl = drMenuItem["Icono"].ToString();
                    mnuMenuItem.NavigateUrl = drMenuItem[Url].ToString();
                   
                    //agregamos el Ítem al menú
                    mnuPrincipal.Items.Add(mnuMenuItem);

                    //hacemos un llamado al metodo recursivo encargado de generar el árbol del menú.
                    AddMenuItem(ref mnuMenuItem, dtMenuItems);

                }


            }

        }
        public void AddMenuItem(ref MenuItem mnuMenuItem, DataTable dtMenuItems)
        {
            //recorremos cada elemento del datatable para poder determinar cuales son elementos hijos
            //del menuitem dado pasado como parametro ByRef.
            foreach (DataRow drMenuItem in dtMenuItems.Rows)
            {
                if (drMenuItem[PadreId].ToString().Equals(mnuMenuItem.Value) && !drMenuItem[MenuId].Equals(drMenuItem[PadreId]))
                {
                    MenuItem mnuNewMenuItem = new MenuItem();
                    mnuNewMenuItem.Value = drMenuItem[MenuId].ToString();
                    mnuNewMenuItem.Text = drMenuItem[descripcion].ToString();
                    //mnuNewMenuItem.ImageUrl = drMenuItem["Icono"].ToString();
                    mnuNewMenuItem.NavigateUrl = drMenuItem[Url].ToString();

                    //Agregamos el Nuevo MenuItem al MenuItem que viene de un nivel superior.
                    mnuMenuItem.ChildItems.Add(mnuNewMenuItem);

                    //llamada recursiva para ver si el nuevo menú ítem aun tiene elementos hijos.
                    AddMenuItem(ref mnuNewMenuItem, dtMenuItems);
                }

            }



        }

    }

    public class ItemMenu
    {
        public int Id { get; set; }
        public int Orden { get; set; }
        public int ParentId { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }

}

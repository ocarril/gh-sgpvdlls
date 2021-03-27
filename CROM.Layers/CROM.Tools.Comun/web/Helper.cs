namespace CROM.Tools.Comun.Web
{
    using System.Web.UI.WebControls;


    public static class HelperWeb
    {
        #region Help para trabajar los DropDownList ---------------->

        /// <summary>Adiere un contenido ItemText al DropDownList 
        /// <para>Objetivo: Ingresa un texto en el index "0" del DropDownList </para>
        /// <para>Prueba: </para>
        /// <para>Creacion: Luis Chavarria(OXINET) 20090501 - REQ:XXX.</para>
        /// <para>Modificacion: Luis Chavarria(OXINET) 20090501 - REQ:XXX.</para>
        /// </summary>
        /// <param name="pDropDownList">DropDownList al que de le ingresara el texto</param>
        /// <param name="pTexto">Enumerador que indica el texto que se indresara</param>
        public static void DropDownListAddItemText(ref  DropDownList pDropDownList, DropDownListText pTexto)
        {
            pDropDownList.Items.Insert(0, new ListItem(ObtenerTexto(pTexto), ""));
        }
        /// <summary>Enumerador de Contenidos para los Textos del DropDownList
        /// <para>Objetivo: Enumerador de Contetenidos</para>
        /// <para>Prueba: </para>
        /// <para>Creacion: Luis Chavarria(OXINET) 20090501 - REQ:XXX.</para>
        /// <para>Modificacion: Luis Chavarria(OXINET) 20090501 - REQ:XXX.</para>
        /// </summary>
        public enum DropDownListText
        {
            Todos,
            Select,
            Otros,
            No_Agregar

        }
        /// <summary>Optiene el Texto de Enumerador DropDownListText
        /// <para>Objetivo: Obtener el texto asignado a.</para>
        /// <para>Prueba: </para>
        /// <para>Creacion: Luis Chavarria(OXINET) 20090501 - REQ:XXX.</para>
        /// <para>Modificacion: Luis Chavarria(OXINET) 20090501 - REQ:XXX.</para>
        /// </summary>
        /// <param name="valor">Enumerador del cual se optiene el significado o valor</param>
        public static string ObtenerTexto(DropDownListText valor)
        {
            string nombre = string.Empty; ;
            switch (valor)
            {
                case DropDownListText.Select:
                    nombre = "-- Seleccionar --";
                    break;
                case DropDownListText.Todos:
                    nombre = "-- Todos --";
                    break;
                case DropDownListText.Otros:
                    nombre = "-- Otros --";
                    break;
            }

            return nombre;
        }
        #endregion

        
    }

    public enum Sesion
    {
        User,
        Admin,
        EsAdmin
    }

    public static class ConstantesWeb
    {
        public const string ERROR_TYPE_TIMEOUT = "Error, Sesión terminada.";
    }
}

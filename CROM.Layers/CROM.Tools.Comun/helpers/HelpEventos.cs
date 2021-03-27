using CROM.Tools.Comun.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CROM.Tools.Comun
{
    public static class HelpEventos
    {
        public enum Process
        {
            NEW,
            EDIT,
            DELETE,
            FIND,
            PRINT,
            EXPORT,
            PRINT_FMT,
            VIEW,
            VIEW_DETAIL,
            EXIT,
            SAVE,
            REFRESH,
            UNDO,
            DEPENDENCIA,
            PERS_ASISTENCIA,
            PERS_AGENDA,
            ANNULLED,

            GC_DOCUM_SERIES,
            GC_DOCUM_SELECT,
            GC_DOCUM_PAGOS,
            GC_DOCUM_LETRAS,
            GC_DOCUM_GASTOADUANERO,
            GC_DOCUM_COPIAR,
            GC_DOCUM_DESHACER,
            GC_DOCUM_ANULAR,
            GC_DOCUM_ELIMINAR,
            GC_DOCUM_ARCHIVAR,
            GC_DOCUM_DEVOLVER,

            GC_DOCUM_ITEM_ADD,
            GC_DOCUM_ITEM_DELETE,
            GC_DOCUM_ITEM_EDIT,

            DOC_RECEIVABLE,
            DOC_PAYMENTS,
            DOC_RELEASE,
            ENTRY,
            OUTPUT
        }

        public enum Accion
        {
            Nuevo,
            Edición,
            Ver
        }

        public static string MessageEvento(HelpEventos.Process p_Evento)
        {
            string MESSAGE = string.Empty;
            switch (p_Evento)
            {
                case HelpEventos.Process.NEW:
                    MESSAGE = HelpMessages.Evento_NEW;
                    break;
                case HelpEventos.Process.EDIT:
                    MESSAGE = HelpMessages.Evento_EDIT;
                    break;
                case HelpEventos.Process.DELETE:
                    MESSAGE = HelpMessages.Evento_DELETE;
                    break;
                case HelpEventos.Process.DEPENDENCIA:
                    MESSAGE = HelpMessages.Evento_DEPEND;
                    break;
                case HelpEventos.Process.GC_DOCUM_ANULAR:
                    MESSAGE = HelpMessages.gc_DOCUM_YA_ANULADO;
                    break;
                case HelpEventos.Process.FIND:
                    MESSAGE = WebConstants.MensajesServicios.FirstOrDefault(x => x.Key == 114).Value;
                    break;
            }
            return MESSAGE;
        }

        public static string MessagePregunta(HelpEventos.Process p_Evento)
        {
            string MESSAGE = string.Empty;
            switch (p_Evento)
            {
                case HelpEventos.Process.NEW:
                    MESSAGE = "¿ Confirma AGREGAR el NUEVO Registro ?";
                    break;
                case HelpEventos.Process.EDIT:
                    MESSAGE = "¿ Confirma ACTUALIZAR el Registro ?";
                    break;
                case HelpEventos.Process.DELETE:
                    MESSAGE = "¿ Confirma ELIMINAR el Registro Seleccionado?";
                    break;
            }
            return MESSAGE;
        }

        public static string TituloGroupBox(HelpEventos.Accion p_Accion)
        {
            string MESSAGE = string.Empty;
            switch (p_Accion)
            {
                case HelpEventos.Accion.Nuevo:
                    MESSAGE = "Nuevo registro";
                    break;
                case HelpEventos.Accion.Edición:
                    MESSAGE = "Editar registro ";
                    break;
                case HelpEventos.Accion.Ver:
                    MESSAGE = "Ver registro";
                    break;
            }
            return MESSAGE;
        }
    }
}

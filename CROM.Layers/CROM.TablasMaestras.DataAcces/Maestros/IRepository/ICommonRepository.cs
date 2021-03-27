namespace CROM.TablasMaestras.DataAcces.Maestros.IRepository
{
    using CROM.BusinessEntities.Maestros;
    using CROM.Tools.Comun.entities;

    using System.Collections.Generic;

    public interface ICommonRepository
    {
        List<ComboListItemString> ListComboRegistro(BaseFiltroMaestro pFiltro);

        List<ComboListItem> ListComboRegistroId(BaseFiltroMaestro pFiltro);

        List<ComboListItemString> ListComboUbiDepartamentos();

        List<ComboListItemString> ListComboUbiProvincias(string pcodUbiDPto);

        List<ComboListItem> ListComboUbiDistritos(string pcodUbiDPto);
    }
}

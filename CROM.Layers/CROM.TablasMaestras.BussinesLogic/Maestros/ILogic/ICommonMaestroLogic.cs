namespace CROM.TablasMaestras.BussinesLogic.Maestros.ILogic
{
    using CROM.BusinessEntities.Maestros;
    using CROM.Tools.Comun.entities;

    public interface ICommonMaestroLogic
    {
        OperationResult ListComboRegistro(BaseFiltroMaestro pFiltro);

        OperationResult ListComboRegistroId(BaseFiltroMaestro pFiltro);
        
        OperationResult ListComboUbiDepartamentos(int pcodEmpresa, string pcodUser);

        OperationResult ListComboUbiProvincias(int pcodEmpresa, string pcodUser, string pcodUbiDPto);

        OperationResult ListComboUbiDistritos(int pcodEmpresa, string pcodUser, string pcodUbiProvin);

    }
}

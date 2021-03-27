namespace CROM.TablasMaestras.BussinesLogic.Maestros.Logic
{
    using CROM.BusinessEntities.Maestros;
    using CROM.TablasMaestras.BussinesLogic.Maestros.ILogic;
    using CROM.TablasMaestras.DataAcces.Maestros.IRepository;
    using CROM.TablasMaestras.DataAcces.Maestros.Repository;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Reflection;

    public class CommonMaestroLogic :BaseLayer, ICommonMaestroLogic
    {
        ICommonRepository commonData = new CommonRepository();

        public OperationResult ListComboRegistro(BaseFiltroMaestro pFiltro)
        {
            OperationResult operationResult = new OperationResult();
            try
            {

                return OK(commonData.ListComboRegistro(pFiltro));
                
            }
            catch (Exception ex)
            {
                 return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pFiltro.segUsuario, pFiltro.codEmpresa);
            }
        }

        public OperationResult ListComboRegistroId(BaseFiltroMaestro pFiltro)
        {
            OperationResult operationResult = new OperationResult();
            try
            {

                return OK(commonData.ListComboRegistroId(pFiltro));

            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pFiltro.segUsuario, pFiltro.codEmpresa);
            }
        }

        public OperationResult ListComboUbiDepartamentos(int pcodEmpresa, string pcodUser)
        {
            OperationResult operationResult = new OperationResult();
            try
            {

                return OK(commonData.ListComboUbiDepartamentos());

            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pcodUser, pcodEmpresa);
            }
        }

        public OperationResult ListComboUbiProvincias(int pcodEmpresa, string pcodUser, string pcodUbiDPto)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
               
                return OK(commonData.ListComboUbiProvincias(pcodUbiDPto));

            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pcodUser, pcodEmpresa);
            }
        }

        public OperationResult ListComboUbiDistritos(int pcodEmpresa, string pcodUser, string pcodUbiProvin)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
  
                return OK(commonData.ListComboUbiDistritos(pcodUbiProvin));

            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pcodUser, pcodEmpresa);
            }
        }
    }
}

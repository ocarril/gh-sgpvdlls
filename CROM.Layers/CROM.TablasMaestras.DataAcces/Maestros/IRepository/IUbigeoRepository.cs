namespace CROM.TablasMaestras.DataAcces.Maestros.IRepository
{
    using CROM.BusinessEntities.Maestros;


    public interface IUbigeoRepository
    {
        BEUbigeo FindUbigeoById(int pUbigeoId);

        BEUbigeo FindUbigeoCode(string pUbigeoCode);

    }
}

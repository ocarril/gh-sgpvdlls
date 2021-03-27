namespace CROM.TablasMaestras.DataAcces.Maestros.Repository
{
    using CROM.BusinessEntities.Maestros;
    using CROM.TablasMaestras.DataAcces.Maestros.IRepository;

    using System;


    public class UbigeoRepository : IUbigeoRepository
    {
        private string conexion = string.Empty;
        public UbigeoRepository()
        {
            conexion = Util.ConexionBD();
        }

        public BEUbigeo FindUbigeoById(int pUbigeoId)
        {
            BEUbigeo objUbigeo = null;
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Ubigeo_codUbigeo(pUbigeoId, null);
                    foreach (var item in resul)
                    {
                        objUbigeo = new BEUbigeo()
                        {
                             codEmpresa=item.codUbigeo,
                             codUbigeoDist=item.codUbigeoDist,
                             nomDistrito=item.nomDistrito,
                             nomProvincia=item.nomDistrito,
                              nomDepartamento=item.nomDepartamento,
                            nomRegion= item.nomRegion
                        };
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return objUbigeo;
        }

        public BEUbigeo FindUbigeoCode(string pUbigeoCode)
        {
            BEUbigeo objUbigeo = null;
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Ubigeo_codUbigeo(null, pUbigeoCode);
                    foreach (var item in resul)
                    {
                        objUbigeo = new BEUbigeo()
                        {
                            codEmpresa = item.codUbigeo,
                            codUbigeoDist = item.codUbigeoDist,
                            nomDistrito = item.nomDistrito,
                            nomProvincia = item.nomDistrito,
                            nomDepartamento = item.nomDepartamento,
                            nomRegion = item.nomRegion
                        };
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return objUbigeo;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CROM.Tools.Comun;
using CROM.BusinessEntities.Maestros;
using CROM.TablasMaestras.DataAcces.Maestros.IRepository;
using CROM.Tools.Comun.entities;

namespace CROM.TablasMaestras.DataAcces.Maestros.Repository
{
    public class CommonRepository : ICommonRepository
    {
        private string conexion = string.Empty;
        public CommonRepository()
        {
            conexion = Util.ConexionBD();
        }

        public List<ComboListItemString> ListComboRegistro(BaseFiltroMaestro pFiltro)
        {
            List<ComboListItemString> listaCombo = new List<ComboListItemString>();
            try
            {
                using (_DBMLMaestrosDataContext SQLDC = new _DBMLMaestrosDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Registro_Combo(pFiltro.codTabla,
                                                            pFiltro.codRegistro,
                                                            pFiltro.numNivel,
                                                            pFiltro.indActivo);
                    foreach (var item in resul) 
                    {
                        listaCombo.Add(new ComboListItemString()
                        {
                            value = item.codRegistro,
                            text = item.desNombre,

                        });
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return listaCombo;
        }


        public List<ComboListItem> ListComboRegistroId(BaseFiltroMaestro pFiltro)
        {
            List<ComboListItem> listaCombo = new List<ComboListItem>();
            try
            {
                using (_DBMLMaestrosDataContext SQLDC = new _DBMLMaestrosDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Registro_Combo(pFiltro.codTabla,
                                                            pFiltro.codRegistro,
                                                            pFiltro.numNivel,
                                                            pFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        listaCombo.Add(new ComboListItem()
                        {
                            value = item.desValorEntero.HasValue ? item.desValorEntero.Value : 0,
                            text = item.desNombre,

                        });
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return listaCombo;
        }

        public List<ComboListItemString> ListComboUbiDepartamentos()
        {
            List<ComboListItemString> listaCombo = new List<ComboListItemString>();
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Ubigeo_Departamento();
                    foreach (var item in resul)
                    {
                        listaCombo.Add(new ComboListItemString()
                        {
                             value = item.Value,
                            text = item.Text,

                        });
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return listaCombo;
        }

        public List<ComboListItemString> ListComboUbiProvincias(string pcodUbiDPto)
        {
            List<ComboListItemString> listaCombo = new List<ComboListItemString>();
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Ubigeo_Provincia(pcodUbiDPto);
                    foreach (var item in resul)
                    {
                        listaCombo.Add(new ComboListItemString()
                        {
                            value = item.Value,
                            text = item.Text,

                        });
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return listaCombo;
        }

        public List<ComboListItem> ListComboUbiDistritos(string pcodUbiProvincia)
        {
            List<ComboListItem> listaCombo = new List<ComboListItem>();
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Ubigeo_Distrito(pcodUbiProvincia);
                    foreach (var item in resul)
                    {
                        listaCombo.Add(new ComboListItem()
                        {
                            value = item.Value,
                            text = item.Text,

                        });
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return listaCombo;
        }
    }
}

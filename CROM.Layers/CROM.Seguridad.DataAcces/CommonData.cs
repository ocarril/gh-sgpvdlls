namespace CROM.Seguridad.DataAcces
{
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.settings;
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class CommonData
    {
        private string conexion = string.Empty;

        public CommonData()
        {
            conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG");
        }

        public IEnumerable<ComboListItemString> GetComboSistemas()
        {
            List<ComboListItemString> lstSistema = null;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SQLDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    lstSistema = new List<ComboListItemString>();
                    var resul = from s in SQLDC.omgc_mnt_GetAll_Sistema(string.Empty, string.Empty,string.Empty, true)
                                where s.indEstado == true
                                orderby s.desNombre
                                select s;

                    foreach (var item in resul)
                    {
                        var itemCombo = new ComboListItemString();

                        itemCombo.value = item.codSistema;
                        itemCombo.text = item.desNombre;
                        lstSistema.Add(itemCombo);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (lstSistema == null)
                {
                    lstSistema = new List<ComboListItemString>();
                }
            }
            return lstSistema;
        }

        public IEnumerable<ComboListItemString> GetComboRoles(string pcodSistema)
        {
            List<ComboListItemString> lstRoles = null;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SQLDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    lstRoles = new List<ComboListItemString>();
                    var resul = from s in SQLDC.omgc_mnt_GetAll_Rol(string.Empty, pcodSistema, string.Empty, true)
                                where s.indEstado == true && s.codSistema == pcodSistema
                                orderby s.desNombre
                                select s;

                    foreach (var item in resul)
                    {
                        var itemCombo = new ComboListItemString();

                        itemCombo.value = item.codRol;
                        itemCombo.text = item.desNombre;
                        lstRoles.Add(itemCombo);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (lstRoles == null)
                {
                    lstRoles = new List<ComboListItemString>();
                }
            }
            return lstRoles;
        }
       
        public IEnumerable<ComboListItemString> GetComboUsuarioPorEmpresa(int pcodEmpresa)
        {
            List<ComboListItemString> lstUsuarios = null;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SQLDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    lstUsuarios = new List<ComboListItemString>();
                    var resul = from s in SQLDC.usp_sis_R_EmpresaUsuario(null, pcodEmpresa, null)
                                orderby s.codUsuarioLogin, s.codUsuarioNombre
                                select new
                                {
                                    codUsuario = s.codUsuario,
                                    nomUsuario = string.Concat("[ ", s.codUsuarioLogin, " ] - ", s.codUsuarioNombre)
                                };

                    foreach (var item in resul)
                    {
                        var itemCombo = new ComboListItemString();

                        itemCombo.value = item.codUsuario;
                        itemCombo.text = item.nomUsuario.ToUpper();
                        lstUsuarios.Add(itemCombo);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (lstUsuarios == null)
                {
                    lstUsuarios = new List<ComboListItemString>();
                }
            }
            return lstUsuarios;
        }

        public IEnumerable<ComboListItemString> GetComboOpciones(string pcodSistema, string pindTipoObjeto)
        {
            List<ComboListItemString> lstOpciones = new List<ComboListItemString>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SQLDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    lstOpciones = new List<ComboListItemString>();
                    var resul = from s in SQLDC.omgc_mnt_GetAll_Opcion(string.Empty, pcodSistema,
                                                                       string.Empty, string.Empty,
                                                                       true, pindTipoObjeto)
                                where s.indEstado == true
                                 && s.codSistema == pcodSistema
                                orderby s.codOpcionPadre, s.desNombreFull
                                select s;

                    foreach (var item in resul)
                    {
                        var itemCombo = new ComboListItemString();

                        itemCombo.value = item.codOpcion;
                        itemCombo.text = item.desNombreFull;
                        lstOpciones.Add(itemCombo);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (lstOpciones == null)
                {
                    lstOpciones = new List<ComboListItemString>();
                }
            }
            return lstOpciones;
        }

        public IEnumerable<ComboListItemString> GetComboEmpresas()
        {
            List<ComboListItemString> lstEmpresas = new List<ComboListItemString>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SQLDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    lstEmpresas = new List<ComboListItemString>();
                    var resul = from s in SQLDC.usp_sis_R_Empresa_Paged(1, 1000, "desNombre", "asc", null, string.Empty, true)
                                where s.indActivo == true
                                orderby s.nomRazonSocial
                                select s;

                    foreach (var item in resul)
                    {
                        var itemCombo = new ComboListItemString();

                        itemCombo.value = item.codEmpresa.ToString();
                        itemCombo.text = item.nomRazonSocial;
                        lstEmpresas.Add(itemCombo);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (lstEmpresas == null)
                {
                    lstEmpresas = new List<ComboListItemString>();
                }
            }
            return lstEmpresas;
        }

        public IEnumerable<ComboListItemString> GetComboSistemasPorEmpresa(int pcodEmpresa)
        {
            List<ComboListItemString> lstSistema = null;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SQLDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    lstSistema = new List<ComboListItemString>();
                    var resul = from s in SQLDC.usp_sis_R_EmpresaSistema_Paged(1, 1000, "nomSistema", "asc", pcodEmpresa,string.Empty, true)
                                where s.indActivo == true
                                orderby s.nomSistema
                                select s;

                    foreach (var item in resul)
                    {
                        var itemCombo = new ComboListItemString();

                        itemCombo.value = item.codSistema;
                        itemCombo.text = item.nomSistema;
                        lstSistema.Add(itemCombo);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (lstSistema == null)
                {
                    lstSistema = new List<ComboListItemString>();
                }
            }
            return lstSistema;
        }

    }
}

namespace CROM.Seguridad.DataADO
{
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.settings;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
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
                lstSistema = new List<ComboListItemString>();
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_GetAll_Sistema"))
                {
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, string.Empty);
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 20, string.Empty);
                    cmd.AddParam("@p_desDescripcion", SqlDbType.VarChar, 20, string.Empty);
                    cmd.AddParam("@p_indEstado", SqlDbType.Bit, true);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetBool("indEstado") == true)
                            {
                                var itemCombo = new ComboListItemString();
                                itemCombo.value = reader.GetStringOrNull("codSistema");
                                itemCombo.text = reader.GetStringOrNull("desNombre");
                                lstSistema.Add(itemCombo);
                            }
                        }
                    }
                }
                lstSistema = lstSistema.OrderBy(x => x.text).ToList();
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
                lstRoles = new List<ComboListItemString>();
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_GetAll_Rol"))
                {
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 15, string.Empty);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pcodSistema);
                    cmd.AddParam("@p_desDescripcion", SqlDbType.VarChar, 15, string.Empty);
                    cmd.AddParam("@p_indEstado", SqlDbType.Bit, true);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetBool("indEstado") == true && reader.GetStringOrNull("codSistema") == pcodSistema)
                            {
                                var itemCombo = new ComboListItemString();
                                itemCombo.value = reader.GetStringOrNull("codRol");
                                itemCombo.text = reader.GetStringOrNull("desNombre");
                                lstRoles.Add(itemCombo);
                            }
                        }
                    }
                }
                lstRoles = lstRoles.OrderBy(x => x.text).ToList();
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
                lstUsuarios = new List<ComboListItemString>();
                var filas = new List<Tuple<string, string, string>>();
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_EmpresaUsuario"))
                {
                    cmd.AddParam("@p_codEmpresaUsuario", SqlDbType.Int, null);
                    cmd.AddParam("@p_codEmpresa", SqlDbType.Int, pcodEmpresa);
                    cmd.AddParam("@p_codUsuario", SqlDbType.VarChar, 10, null);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            filas.Add(Tuple.Create(
                                reader.GetStringOrNull("codUsuario"),
                                reader.GetStringOrNull("codUsuarioLogin"),
                                reader.GetStringOrNull("codUsuarioNombre")));
                        }
                    }
                }
                var resul = from s in filas
                            orderby s.Item2, s.Item3
                            select s;
                foreach (var item in resul)
                {
                    var itemCombo = new ComboListItemString();
                    itemCombo.value = item.Item1;
                    itemCombo.text = string.Concat("[ ", item.Item2, " ] - ", item.Item3).ToUpper();
                    lstUsuarios.Add(itemCombo);
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
            List<ComboListItemString> lstOpciones = null;
            try
            {
                lstOpciones = new List<ComboListItemString>();
                var filas = new List<Tuple<string, string, string, string>>();
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_GetAll_Opcion"))
                {
                    cmd.AddParam("@p_codOpcion", SqlDbType.VarChar, 4, string.Empty);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pcodSistema);
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 15, string.Empty);
                    cmd.AddParam("@p_desDescripcion", SqlDbType.VarChar, 15, string.Empty);
                    cmd.AddParam("@p_indEstado", SqlDbType.Bit, true);
                    cmd.AddParam("@p_TipoObjeto", SqlDbType.VarChar, 15, pindTipoObjeto);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetBool("indEstado") == true && reader.GetStringOrNull("codSistema") == pcodSistema)
                            {
                                filas.Add(Tuple.Create(
                                    reader.GetStringOrNull("codOpcion"),
                                    reader.GetStringOrNull("codOpcionPadre"),
                                    reader.GetStringOrNull("desNombreFull"),
                                    reader.GetStringOrNull("desNombreFull")));
                            }
                        }
                    }
                }
                var resul = from s in filas
                            orderby s.Item2, s.Item3
                            select s;
                foreach (var item in resul)
                {
                    var itemCombo = new ComboListItemString();
                    itemCombo.value = item.Item1;
                    itemCombo.text = item.Item3;
                    lstOpciones.Add(itemCombo);
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
            List<ComboListItemString> lstEmpresas = null;
            try
            {
                lstEmpresas = new List<ComboListItemString>();
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_Empresa_Paged"))
                {
                    cmd.AddParam("@p_NumPagina", SqlDbType.Int, 1);
                    cmd.AddParam("@p_TamPagina", SqlDbType.Int, 1000);
                    cmd.AddParam("@p_OrdenPor", SqlDbType.VarChar, 30, "desNombre");
                    cmd.AddParam("@p_OrdenTipo", SqlDbType.VarChar, 4, "asc");
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 20, null);
                    cmd.AddParam("@p_numRUC", SqlDbType.VarChar, 15, string.Empty);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, true);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetBool("indActivo") == true)
                            {
                                var itemCombo = new ComboListItemString();
                                itemCombo.value = reader.GetInt("codEmpresa").ToString();
                                itemCombo.text = reader.GetStringOrNull("nomRazonSocial");
                                lstEmpresas.Add(itemCombo);
                            }
                        }
                    }
                }
                lstEmpresas = lstEmpresas.OrderBy(x => x.text).ToList();
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
                lstSistema = new List<ComboListItemString>();
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_EmpresaSistema_Paged"))
                {
                    cmd.AddParam("@p_NumPagina", SqlDbType.Int, 1);
                    cmd.AddParam("@p_TamPagina", SqlDbType.Int, 1000);
                    cmd.AddParam("@p_OrdenPor", SqlDbType.VarChar, 30, "nomSistema");
                    cmd.AddParam("@p_OrdenTipo", SqlDbType.VarChar, 4, "asc");
                    cmd.AddParam("@p_codEmpresa", SqlDbType.Int, pcodEmpresa);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, string.Empty);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, true);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetBool("indActivo") == true)
                            {
                                var itemCombo = new ComboListItemString();
                                itemCombo.value = reader.GetStringOrNull("codSistema");
                                itemCombo.text = reader.GetStringOrNull("nomSistema");
                                lstSistema.Add(itemCombo);
                            }
                        }
                    }
                }
                lstSistema = lstSistema.OrderBy(x => x.text).ToList();
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

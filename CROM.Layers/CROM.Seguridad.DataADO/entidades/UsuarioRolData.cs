namespace CROM.Seguridad.DataADO
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Tools.Comun.settings;
    using CROM.Tools.Comun.Web;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Proyecto    : Seguridad del Sistema
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Descripcion : Clase para capa de datos (ADO.NET puro)
    /// Archivo     : UsuariosRolesData.cs
    /// </summary
    public class UsuarioRolData
    {
        private string conexion = String.Empty;
        public UsuarioRolData()
        {
            conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG");
        }

        #region " /* Proceso de Insertar */ "

        public bool Insert(BEUsuarioRol pItem)
        {
            int codigoRetorno = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_C_UsuarioRol"))
                {
                    cmd.AddParam("@p_codUsuario", SqlDbType.VarChar, 10, pItem.codUsuario);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pItem.codSistema);
                    cmd.AddParam("@p_codRol", SqlDbType.VarChar, 4, pItem.codRol);
                    cmd.AddParam("@p_indEstado", SqlDbType.Bit, Convert.ToBoolean(pItem.indEstado));
                    cmd.AddParam("@p_segUsuarioCrea", SqlDbType.VarChar, 50, pItem.segUsuarioCrea);
                    SqlParameter pReturn = cmd.AddReturnValueParam();
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    codigoRetorno = Convert.ToInt32(pReturn.Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region " /* Proceso de Actualizar */ "

        public bool Update(BEUsuarioRol pItem)
        {
            int CodigoRetorno = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_U_UsuarioRol"))
                {
                    cmd.AddParam("@p_codUsuarioRol", SqlDbType.Int, pItem.codUsuarioRol);
                    cmd.AddParam("@p_codUsuario", SqlDbType.VarChar, 10, pItem.codUsuario);
                    cmd.AddParam("@p_codRol", SqlDbType.VarChar, 4, pItem.codRol);
                    cmd.AddParam("@p_indEstado", SqlDbType.Bit, Convert.ToBoolean(pItem.indEstado));
                    cmd.AddParam("@p_segUsuarioEdita", SqlDbType.VarChar, 50, pItem.segUsuarioEdita);
                    SqlParameter pReturn = cmd.AddReturnValueParam();
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    CodigoRetorno = Convert.ToInt32(pReturn.Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CodigoRetorno == 0 ? true : false;
        }

        #endregion

        #region " /* Proceso de Eliminar */ "

        public bool DeleteWS(int codUsuarioRol)
        {
            bool blnResult = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_D_UsuarioRol"))
                {
                    cmd.AddParam("@p_codUsuarioRol", SqlDbType.Int, codUsuarioRol);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            blnResult = reader.GetStringOrNull("desMessage") == WebConstants.DEFAULT_OK ? true : false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return blnResult;
        }

        #endregion

        #region " /* Proceso de Encontrar */ "

        public BEUsuarioRol Find(string CodigoUsuario, string CodigoRol)
        {
            BEUsuarioRol itemUsuariosRoles = new BEUsuarioRol();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_UsuarioRol"))
                {
                    cmd.AddParam("@p_codUsuarioRol", SqlDbType.Int, null);
                    cmd.AddParam("@p_codUsuario", SqlDbType.VarChar, 10, CodigoUsuario);
                    cmd.AddParam("@p_codRol", SqlDbType.VarChar, 4, CodigoRol);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            itemUsuariosRoles = new BEUsuarioRol()
                            {
                                codRol = reader.GetStringOrNull("codRol"),
                                codUsuario = reader.GetStringOrNull("codUsuario"),
                                indEstado = reader.GetBool("indEstado"),
                                segUsuarioCrea = reader.GetStringOrNull("segUsuarioCrea"),
                                segFechaHoraCrea = reader.GetDateTime("segFechaHoraCrea"),
                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaHoraEdita = reader.GetDateTimeOrNull("segFechaHoraEdita"),
                                segMaquinaCrea = reader.GetStringOrNull("segMaquinaOrigen"),

                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemUsuariosRoles;
        }

        public BEUsuarioRol FindWS(int codUsuarioRol)
        {
            BEUsuarioRol itemUsuariosRoles = new BEUsuarioRol();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_UsuarioRol"))
                {
                    cmd.AddParam("@p_codUsuarioRol", SqlDbType.Int, codUsuarioRol);
                    cmd.AddParam("@p_codUsuario", SqlDbType.VarChar, 10, null);
                    cmd.AddParam("@p_codRol", SqlDbType.VarChar, 4, null);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            itemUsuariosRoles = new BEUsuarioRol()
                            {
                                codUsuarioRol = reader.GetInt("codUsuarioRol"),
                                codEmpresa = reader.GetInt("codEmpresa"),
                                codSistema = reader.GetStringOrNull("codSistema"),
                                codRol = reader.GetStringOrNull("codRol"),
                                codUsuario = reader.GetStringOrNull("codUsuario"),
                                indEstado = reader.GetBool("indEstado"),
                                segUsuarioCrea = reader.GetStringOrNull("segUsuarioCrea"),
                                segFechaHoraCrea = reader.GetDateTime("segFechaHoraCrea"),
                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaHoraEdita = reader.GetDateTimeOrNull("segFechaHoraEdita"),
                                segMaquinaCrea = reader.GetStringOrNull("segMaquinaOrigen"),

                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemUsuariosRoles;
        }

        #endregion

        #region " /* Proceso de Listar */ "

        /// <summary>
        /// Listado con paginacion para aplicación WEB
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEUsuarioRolResponse> ListPaged(BEBuscaRolUsuarioRequest pFiltro)
        {
            List<BEUsuarioRolResponse> lista = new List<BEUsuarioRolResponse>();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_UsuarioRol_Paged"))
                {
                    cmd.AddParam("@p_NumPagina", SqlDbType.Int, pFiltro.jqCurrentPage);
                    cmd.AddParam("@p_TamPagina", SqlDbType.Int, pFiltro.jqPageSize);
                    cmd.AddParam("@p_OrdenPor", SqlDbType.VarChar, 30, pFiltro.jqSortColumn);
                    cmd.AddParam("@p_OrdenTipo", SqlDbType.VarChar, 4, pFiltro.jqSortOrder);
                    cmd.AddParam("@p_codEmpresa", SqlDbType.Int, pFiltro.codEmpresa);
                    cmd.AddParam("@p_codUsuarioRol", SqlDbType.Int, pFiltro.codUsuarioRol);
                    cmd.AddParam("@p_codUsuario", SqlDbType.VarChar, 10, pFiltro.codUsuario);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pFiltro.codSistema);
                    cmd.AddParam("@p_codRol", SqlDbType.VarChar, 4, pFiltro.codRol);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pFiltro.indActivo);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BEUsuarioRolResponse()
                            {
                                ROW = reader.GetInt("ROWNUM"),
                                TOTALROWS = reader.GetInt("TOTALROWS"),

                                codUsuarioRol = reader.GetInt("codUsuarioRol"),
                                codRol = reader.GetStringOrNull("codRol"),
                                codUsuario = reader.GetStringOrNull("codUsuario"),
                                codRolNombre = reader.GetStringOrNull("codRolNombre"),
                                codUsuarioNombre = reader.GetStringOrNull("codUsuarioNombre"),
                                codUsuarioLogin = reader.GetStringOrNull("desLogin"),
                                codSistema = reader.GetStringOrNull("codSistema"),
                                codSistemaNombre = reader.GetStringOrNull("codSistemaNombre"),
                                indEstado = reader.GetBool("indEstado"),
                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaEdita = reader.GetDateTimeOrNull("segFechaHoraEdita"),
                                segMaquinaEdita = reader.GetStringOrNull("segMaquinaEdita"),
                                codEmpresa = pFiltro.codEmpresa,
                                codEmpresaNombre = reader.GetStringOrNull("codEmpresaNombre")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        #endregion

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

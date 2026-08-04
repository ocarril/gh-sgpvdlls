namespace CROM.Seguridad.DataADO
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Tools.Comun.Web;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de :
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Descripcion : Capa de Datos (ADO.NET puro)
    /// Archivo     : [Seguridad.EmpresaUsuarioData.cs]
    /// </summary>
    public class EmpresaUsuarioData
    {
        private string conexion = string.Empty;
        public EmpresaUsuarioData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnxCROMSystemaSEG"].ConnectionString;
        }

        #region /* Proceso de SELECT ALL */

        public List<BEEmpresaUsuarioRespose> ListPaged(BEBuscaEmpresaUsuarioRequest pFiltro)
        {
            List<BEEmpresaUsuarioRespose> lstEmpresaUsuario = new List<BEEmpresaUsuarioRespose>();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_EmpresaUsuario_Paged"))
                {
                    cmd.AddParam("@p_NumPagina", SqlDbType.Int, pFiltro.jqCurrentPage);
                    cmd.AddParam("@p_TamPagina", SqlDbType.Int, pFiltro.jqPageSize);
                    cmd.AddParam("@p_OrdenPor", SqlDbType.VarChar, 30, pFiltro.jqSortColumn);
                    cmd.AddParam("@p_OrdenTipo", SqlDbType.VarChar, 4, pFiltro.jqSortOrder);
                    cmd.AddParam("@p_codEmpresa", SqlDbType.Int, pFiltro.codEmpresa);
                    cmd.AddParam("@p_codUsuario", SqlDbType.VarChar, 10, pFiltro.codUsuario);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pFiltro.indActivo);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstEmpresaUsuario.Add(new BEEmpresaUsuarioRespose()
                            {
                                ROW = reader.GetInt("ROWNUM"),
                                TOTALROWS = reader.GetInt("TOTALROWS"),

                                codEmpresaUsuario = reader.GetInt("codEmpresaUsuario"),
                                nomEmpresa = reader.GetStringOrNull("nomEmpresa"),
                                desLogin = reader.GetStringOrNull("desLogin"),
                                nomUsuario = reader.GetStringOrNull("nomUsuario"),
                                indActivo = reader.GetBool("indActivo"),
                                codUsuarioKey = reader.GetAsStringOrNull("codUsuarioKey"),
                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaEdita = reader.GetDateTimeOrNull("segFechaEdita"),
                                segMaquinaEdita = reader.GetStringOrNull("segMaquinaEdita"),
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstEmpresaUsuario;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        public BEEmpresaUsuario Find(int pcodEmpresaUsuario)
        {
            BEEmpresaUsuario objEntidadUsuario = new BEEmpresaUsuario();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_EmpresaUsuario"))
                {
                    cmd.AddParam("@p_codEmpresaUsuario", SqlDbType.Int, pcodEmpresaUsuario);
                    cmd.AddParam("@p_codEmpresa", SqlDbType.Int, null);
                    cmd.AddParam("@p_codUsuario", SqlDbType.VarChar, 10, null);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            objEntidadUsuario = new BEEmpresaUsuario()
                            {
                                codEmpresaUsuario = reader.GetInt("codEmpresaUsuario"),
                                codEmpresa = reader.GetInt("codEmpresa"),
                                codUsuario = reader.GetStringOrNull("codUsuario"),
                                indActivo = reader.GetBool("indActivo"),
                                codUsuarioKey = reader.GetAsStringOrNull("codUsuarioKey"),
                                segUsuarioCrea = reader.GetStringOrNull("segUsuarioCrea"),
                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaHoraCrea = reader.GetDateTime("segFechaCrea"),
                                segFechaHoraEdita = reader.GetDateTimeOrNull("segFechaEdita"),
                                segMaquinaCrea = reader.GetStringOrNull("segMaquinaCrea"),
                                segMaquinaEdita = reader.GetStringOrNull("segMaquinaEdita")

                            };
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objEntidadUsuario;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        public bool Insert(BEEmpresaUsuarioRequest pEmpresaUsuario, out string pMessage)
        {
            bool blnResult = false;
            pMessage = string.Empty;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_C_EmpresaUsuario"))
                {
                    cmd.AddParam("@p_codEmpresa", SqlDbType.Int, pEmpresaUsuario.codEmpresa);
                    cmd.AddParam("@p_codUsuario", SqlDbType.VarChar, 10, pEmpresaUsuario.codUsuario);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pEmpresaUsuario.indActivo);
                    cmd.AddParam("@p_segUsuarioCrea", SqlDbType.VarChar, 50, pEmpresaUsuario.segUsuarioEdita);
                    cmd.AddParam("@p_segMaquinaCrea", SqlDbType.VarChar, 30, pEmpresaUsuario.segMaquinaEdita);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pEmpresaUsuario.codEmpresaUsuario = reader.GetInt("codError");
                            pMessage = reader.GetStringOrNull("desMessage");

                            if (pMessage == WebConstants.DEFAULT_OK)
                                blnResult = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnResult;

        }
        #endregion

        #region /* Proceso de UPDATE RECORD */

        public bool Update(BEEmpresaUsuarioRequest pEmpresaUsuario)
        {
            int codigoRetorno = -1;
            bool message = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_U_EmpresaUsuario"))
                {
                    cmd.AddParam("@p_codEmpresaUsuario", SqlDbType.Int, pEmpresaUsuario.codEmpresaUsuario);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pEmpresaUsuario.indActivo);
                    cmd.AddParam("@p_segUsuarioEdita", SqlDbType.VarChar, 50, pEmpresaUsuario.segUsuarioEdita);
                    cmd.AddParam("@p_segMaquinaEdita", SqlDbType.VarChar, 30, pEmpresaUsuario.segMaquinaEdita);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            codigoRetorno = reader.GetInt("codError");
                            message = reader.GetStringOrNull("desMessage") == WebConstants.DEFAULT_OK ? true : false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 1 && message ? true : false;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        public bool Delete(BEEmpresaUsuarioRequest pEmpresaUsuario)
        {
            bool blnResult = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_D_EmpresaUsuario"))
                {
                    cmd.AddParam("@p_codEmpresaUsuario", SqlDbType.Int, pEmpresaUsuario.codEmpresaUsuario);
                    cmd.AddParam("@p_segUsuario", SqlDbType.VarChar, 50, pEmpresaUsuario.segUsuarioEdita);
                    cmd.AddParam("@p_segMaquina", SqlDbType.VarChar, 30, pEmpresaUsuario.segMaquinaEdita);
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

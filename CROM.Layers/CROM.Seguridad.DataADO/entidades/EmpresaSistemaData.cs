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
    /// Proyecto    :  Modulo de Mantenimiento de :
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Descripcion : Capa de Datos (ADO.NET puro)
    /// Archivo     : [Seguridad.EmpresaSistemaData.cs]
    /// </summary>
    public class EmpresaSistemaData
    {
        private string conexion = string.Empty;

        public EmpresaSistemaData()
        {
            conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG");
        }

        #region /* Proceso de SELECT ALL */

        public List<BEEmpresaSistemaRespose> ListPaged(BEBuscaEmpresaSistemaRequest pFiltro)
        {
            List<BEEmpresaSistemaRespose> lstEmpresaSistema = new List<BEEmpresaSistemaRespose>();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_EmpresaSistema_Paged"))
                {
                    cmd.AddParam("@p_NumPagina", SqlDbType.Int, pFiltro.jqCurrentPage);
                    cmd.AddParam("@p_TamPagina", SqlDbType.Int, pFiltro.jqPageSize);
                    cmd.AddParam("@p_OrdenPor", SqlDbType.VarChar, 30, pFiltro.jqSortColumn);
                    cmd.AddParam("@p_OrdenTipo", SqlDbType.VarChar, 4, pFiltro.jqSortOrder);
                    cmd.AddParam("@p_codEmpresa", SqlDbType.Int, pFiltro.codEmpresa);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pFiltro.codSistema);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pFiltro.indActivo);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstEmpresaSistema.Add(new BEEmpresaSistemaRespose()
                            {
                                codEmpresaSistema = reader.GetInt("codEmpresaSistema"),
                                nomEmpresa = reader.GetStringOrNull("nomEmpresa"),
                                nomSistema = reader.GetStringOrNull("nomSistema"),
                                indActivo = reader.GetBool("indActivo"),
                                fecInicio = reader.GetDateTime("fecInicio"),
                                fecFinal = reader.GetDateTime("fecFinal"),
                                numTiempoToken = reader.GetInt("numTiempoToken"),
                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaEdita = reader.GetDateTimeOrNull("segFechaEdita"),
                                segMaquinaEdita = reader.GetStringOrNull("segMaquinaEdita"),

                                indFaltoPago = reader.GetBool("indFaltoPago"),
                                fecFinalLicFE = reader.GetDateTimeOrNull("fecFinalLicFE"),

                                ROW = reader.GetInt("ROWNUM"),
                                TOTALROWS = reader.GetInt("TOTALROWS"),

                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstEmpresaSistema;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        public BEEmpresaSistema Find(int pcodEmpresaSistema)
        {
            BEEmpresaSistema objEntidadSistema = new BEEmpresaSistema();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_EmpresaSistema"))
                {
                    cmd.AddParam("@p_codEmpresaSistema", SqlDbType.Int, pcodEmpresaSistema);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            objEntidadSistema = new BEEmpresaSistema()
                            {
                                codEmpresaSistema = reader.GetInt("codEmpresaSistema"),
                                codEmpresa = reader.GetInt("codEmpresa"),
                                codSistema = reader.GetStringOrNull("codSistema"),
                                indActivo = reader.GetBool("indActivo"),
                                fecInicio = reader.GetDateTime("fecInicio"),
                                fecFinal = reader.GetDateTime("fecFinal"),
                                numTiempoToken = reader.GetInt("numTiempoToken"),
                                segUsuarioCrea = reader.GetStringOrNull("segUsuarioCrea"),
                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaHoraCrea = reader.GetDateTime("segFechaCrea"),
                                segFechaHoraEdita = reader.GetDateTimeOrNull("segFechaEdita"),
                                segMaquinaCrea = reader.GetStringOrNull("segMaquinaCrea"),
                                segMaquinaEdita = reader.GetStringOrNull("segMaquinaEdita"),
                                indEliminado = reader.GetBool("indEliminado"),

                                indFaltoPago = reader.GetBool("indFaltoPago"),
                                fecFinalLicFE = reader.GetDateTimeOrNull("fecFinalLicFE"),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objEntidadSistema;
        }

        public BEEmpresaSistema Find(int pcodEmpresa, string pcodSistema)
        {
            BEEmpresaSistema objEntidadSistema = new BEEmpresaSistema();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_EmpresaSistema_Paged"))
                {
                    cmd.AddParam("@p_NumPagina", SqlDbType.Int, 1);
                    cmd.AddParam("@p_TamPagina", SqlDbType.Int, 100);
                    cmd.AddParam("@p_OrdenPor", SqlDbType.VarChar, 30, "codSistemaNombre");
                    cmd.AddParam("@p_OrdenTipo", SqlDbType.VarChar, 4, "asc");
                    cmd.AddParam("@p_codEmpresa", SqlDbType.Int, pcodEmpresa);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pcodSistema);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, true);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            objEntidadSistema = new BEEmpresaSistema()
                            {
                                codEmpresaSistema = reader.GetInt("codEmpresaSistema"),
                                codEmpresa = reader.GetInt("codEmpresa"),
                                codSistema = reader.GetStringOrNull("codSistema"),
                                indActivo = reader.GetBool("indActivo"),
                                fecInicio = reader.GetDateTime("fecInicio"),
                                fecFinal = reader.GetDateTime("fecFinal"),
                                numTiempoToken = reader.GetInt("numTiempoToken"),
                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaHoraEdita = reader.GetDateTimeOrNull("segFechaEdita"),
                                segMaquinaEdita = reader.GetStringOrNull("segMaquinaEdita"),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objEntidadSistema;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        public bool Insert(BEEmpresaSistemaRequest pEmpresaSistema)
        {
            bool blnResult = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_C_EmpresaSistema"))
                {
                    cmd.AddParam("@p_codEmpresa", SqlDbType.Int, pEmpresaSistema.codEmpresa);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pEmpresaSistema.codSistema);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pEmpresaSistema.indActivo);
                    cmd.AddParam("@p_fecInicio", SqlDbType.Date, pEmpresaSistema.fecInicio);
                    cmd.AddParam("@p_fecFinal", SqlDbType.Date, pEmpresaSistema.fecFinal);
                    cmd.AddParam("@p_numTiempoToken", SqlDbType.Int, pEmpresaSistema.numTiempoToken);

                    cmd.AddParam("@p_fecFinalLicFE", SqlDbType.Date, pEmpresaSistema.fecFinalLicFE);
                    cmd.AddParam("@p_indFaltoPago", SqlDbType.Bit, pEmpresaSistema.indFaltoPago);

                    cmd.AddParam("@p_segUsuarioCrea", SqlDbType.VarChar, 50, pEmpresaSistema.segUsuarioEdita);
                    cmd.AddParam("@p_segMaquinaCrea", SqlDbType.VarChar, 30, pEmpresaSistema.segMaquinaEdita);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pEmpresaSistema.codEmpresaSistema = reader.GetInt("codError");
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

        #region /* Proceso de UPDATE RECORD */

        public bool Update(BEEmpresaSistemaRequest pEmpresaSistema)
        {
            int codigoRetorno = -1;
            bool message = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_U_EmpresaSistema"))
                {
                    cmd.AddParam("@p_codEmpresaSistema", SqlDbType.Int, pEmpresaSistema.codEmpresaSistema);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pEmpresaSistema.indActivo);
                    cmd.AddParam("@p_fecInicio", SqlDbType.Date, pEmpresaSistema.fecInicio);
                    cmd.AddParam("@p_fecFinal", SqlDbType.Date, pEmpresaSistema.fecFinal);
                    cmd.AddParam("@p_numTiempoToken", SqlDbType.Int, pEmpresaSistema.numTiempoToken);

                    cmd.AddParam("@p_fecFinalLicFE", SqlDbType.Date, pEmpresaSistema.fecFinalLicFE);
                    cmd.AddParam("@p_indFaltoPago", SqlDbType.Bit, pEmpresaSistema.indFaltoPago);

                    cmd.AddParam("@p_segUsuarioEdita", SqlDbType.VarChar, 50, pEmpresaSistema.segUsuarioEdita);
                    cmd.AddParam("@p_segMaquinaEdita", SqlDbType.VarChar, 30, pEmpresaSistema.segMaquinaEdita);
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

        public bool Delete(BEEmpresaSistemaRequest pEmpresaSistema)
        {
            bool blnResult = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_D_EmpresaSistema"))
                {
                    cmd.AddParam("@p_codEmpresaSistema", SqlDbType.Int, pEmpresaSistema.codEmpresaSistema);
                    cmd.AddParam("@p_segUsuario", SqlDbType.VarChar, 50, pEmpresaSistema.segUsuarioEdita);
                    cmd.AddParam("@p_segMaquina", SqlDbType.VarChar, 30, pEmpresaSistema.segMaquinaEdita);
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

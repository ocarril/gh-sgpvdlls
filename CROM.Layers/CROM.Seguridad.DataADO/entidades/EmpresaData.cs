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
    /// Archivo     : [Seguridad.EmpresaData.cs]
    /// </summary>
    public class EmpresaData
    {
        private string conexion = string.Empty;

        public EmpresaData()
        {
            conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG");
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Seguridad.Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <returns>List</returns>
        public List<BEEmpresaResponse> ListPaged(BEBuscaEmpresaRequest pFiltro)
        {
            List<BEEmpresaResponse> lstEmpresa = new List<BEEmpresaResponse>();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_Empresa_Paged"))
                {
                    cmd.AddParam("@p_NumPagina", SqlDbType.Int, pFiltro.jqCurrentPage);
                    cmd.AddParam("@p_TamPagina", SqlDbType.Int, pFiltro.jqPageSize);
                    cmd.AddParam("@p_OrdenPor", SqlDbType.VarChar, 30, pFiltro.jqSortColumn);
                    cmd.AddParam("@p_OrdenTipo", SqlDbType.VarChar, 4, pFiltro.jqSortOrder);
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 20, pFiltro.nomRazonSocial);
                    cmd.AddParam("@p_numRUC", SqlDbType.VarChar, 15, pFiltro.numRUC);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pFiltro.indActivo);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstEmpresa.Add(new BEEmpresaResponse()
                            {
                                ROW = reader.GetInt("ROWNUM"),
                                TOTALROWS = reader.GetInt("TOTALROWS"),

                                codEmpresa = reader.GetInt("codEmpresa"),
                                nomRazonSocial = reader.GetStringOrNull("nomRazonSocial"),
                                numRUC = reader.GetStringOrNull("numRUC"),
                                nomLogo = reader.GetStringOrNull("nomLogo"),
                                nomContacto = reader.GetStringOrNull("nomContacto"),
                                desCorreo = reader.GetStringOrNull("desCorreo"),
                                desPaginaWeb = reader.GetStringOrNull("desPaginaWeb"),
                                codEmpresaKey = reader.GetAsStringOrNull("codEmpresaKey"),
                                indActivo = reader.GetBool("indActivo"),
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
            return lstEmpresa;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Seguridad.Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEEmpresa Find(int pcodEmpresa)
        {
            BEEmpresa objEntidad = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_Empresa"))
                {
                    cmd.AddParam("@p_codEmpresa", SqlDbType.Int, pcodEmpresa);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            objEntidad = new BEEmpresa()
                            {
                                codEmpresa = reader.GetInt("codEmpresa"),
                                nomRazonSocial = reader.GetStringOrNull("nomRazonSocial"),
                                numRUC = reader.GetStringOrNull("numRUC"),
                                nomLogo = reader.GetStringOrNull("nomLogo"),
                                nomContacto = reader.GetStringOrNull("nomContacto"),
                                desCorreo = reader.GetStringOrNull("desCorreo"),
                                desPaginaWeb = reader.GetStringOrNull("desPaginaWeb"),
                                codEmpresaKey = reader.GetAsStringOrNull("codEmpresaKey"),
                                indActivo = reader.GetBool("indActivo"),
                                segUsuarioCrea = reader.GetStringOrNull("segUsuarioCrea"),
                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaHoraCrea = reader.GetDateTime("segFechaCrea"),
                                segFechaHoraEdita = reader.GetDateTimeOrNull("segFechaEdita"),
                                segMaquinaCrea = reader.GetStringOrNull("segMaquinaCrea"),
                                segMaquinaEdita = reader.GetStringOrNull("segMaquinaEdita"),
                                indEliminado = reader.GetBool("indEliminado"),

                            };
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objEntidad;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <param name = >itemEmpresa</param>
        public bool Insert(BEEmpresaRequest pEmpresa)
        {
            bool blnResult = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_C_Empresa"))
                {
                    cmd.AddParam("@p_nomRazonSocial", SqlDbType.VarChar, 150, pEmpresa.nomRazonSocial);
                    cmd.AddParam("@p_numRUC", SqlDbType.VarChar, 15, pEmpresa.numRUC);
                    cmd.AddParam("@p_nomLogo", SqlDbType.VarChar, 50, pEmpresa.nomLogo);
                    cmd.AddParam("@p_nomContacto", SqlDbType.VarChar, 60, pEmpresa.nomContacto);
                    cmd.AddParam("@p_desCorreo", SqlDbType.VarChar, 100, pEmpresa.desCorreo);
                    cmd.AddParam("@p_desPaginaWeb", SqlDbType.VarChar, 100, pEmpresa.desPaginaWeb);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pEmpresa.indActivo);
                    cmd.AddParam("@p_segUsuarioCrea", SqlDbType.VarChar, 50, pEmpresa.segUsuarioEdita);
                    cmd.AddParam("@p_segMaquinaCrea", SqlDbType.VarChar, 30, pEmpresa.segMaquinaEdita);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pEmpresa.codEmpresa = reader.GetInt("codError");
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

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <param name = >itemEmpresa</param>
        public bool Update(BEEmpresaRequest pEmpresa)
        {
            bool blnResult = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_U_Empresa"))
                {
                    cmd.AddParam("@p_codEmpresa", SqlDbType.Int, pEmpresa.codEmpresa);
                    cmd.AddParam("@p_nomRazonSocial", SqlDbType.VarChar, 150, pEmpresa.nomRazonSocial);
                    cmd.AddParam("@p_numRUC", SqlDbType.VarChar, 15, pEmpresa.numRUC);
                    cmd.AddParam("@p_nomLogo", SqlDbType.VarChar, 50, pEmpresa.nomLogo);
                    cmd.AddParam("@p_nomContacto", SqlDbType.VarChar, 60, pEmpresa.nomContacto);
                    cmd.AddParam("@p_desCorreo", SqlDbType.VarChar, 100, pEmpresa.desCorreo);
                    cmd.AddParam("@p_desPaginaWeb", SqlDbType.VarChar, 100, pEmpresa.desPaginaWeb);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pEmpresa.indActivo);
                    cmd.AddParam("@p_segUsuarioEdita", SqlDbType.VarChar, 50, pEmpresa.segUsuarioEdita);
                    cmd.AddParam("@p_segMaquinaEdita", SqlDbType.VarChar, 30, pEmpresa.segMaquinaEdita);
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

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Seguridad.Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(BEEmpresaRequest pEmpresa)
        {
            bool blnResult = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_D_Empresa"))
                {
                    cmd.AddParam("@p_codEmpresa", SqlDbType.Int, pEmpresa.codEmpresa);
                    cmd.AddParam("@p_segUsuario", SqlDbType.VarChar, 50, pEmpresa.segUsuarioEdita);
                    cmd.AddParam("@p_segMaquina", SqlDbType.VarChar, 30, pEmpresa.segMaquinaEdita);
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

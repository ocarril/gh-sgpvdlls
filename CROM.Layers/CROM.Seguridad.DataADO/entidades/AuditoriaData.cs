namespace CROM.Seguridad.DataADO
{
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Seguridad.BussinesEntities.entidades.response;
    using CROM.Tools.Comun.settings;

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de :
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Descripcion : Capa de Datos (ADO.NET puro)
    /// Archivo     : [Seguridad.AuditoriaData.cs]
    /// </summary>
    public class AuditoriaData
    {
        private string conexion = string.Empty;

        public AuditoriaData()
        {
            conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG");
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Seguridad.Auditoria
        /// En la BASE de DATO la Tabla : [Seguridad.Auditoria]
        /// <summary>
        /// <returns>List</returns>
        public List<BEAuditoriaResponse> ListAuditoriaPage(BEBuscaAuditoriaRequest pFiltro)
        {
            List<BEAuditoriaResponse> lista = new List<BEAuditoriaResponse>();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_Auditoria_Paged"))
                {
                    cmd.AddParam("@p_NumPagina", SqlDbType.Int, pFiltro.jqCurrentPage);
                    cmd.AddParam("@p_TamPagina", SqlDbType.Int, pFiltro.jqPageSize);
                    cmd.AddParam("@p_OrdenPor", SqlDbType.VarChar, 30, pFiltro.jqSortColumn);
                    cmd.AddParam("@p_OrdenTipo", SqlDbType.VarChar, 4, pFiltro.jqSortOrder);
                    cmd.AddParam("@p_codEmpresa", SqlDbType.Int, pFiltro.codEmpresa);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pFiltro.codSistema);
                    cmd.AddParam("@p_codRol", SqlDbType.VarChar, 4, pFiltro.codRol);
                    cmd.AddParam("@p_codUsuario", SqlDbType.VarChar, 10, pFiltro.codUsuario);
                    cmd.AddParam("@p_fecINICIO", SqlDbType.VarChar, 8, pFiltro.fecInicioStr);
                    cmd.AddParam("@p_fecFINAL", SqlDbType.VarChar, 8, pFiltro.fecFinalStr);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BEAuditoriaResponse()
                            {
                                ROW = reader.GetInt("ROWNUM"),
                                TOTALROWS = reader.GetInt("TOTALROWS"),

                                codAuditoria = reader.GetInt("codAuditoria"),
                                codEmpresa = reader.GetIntOrNull("codEmpresa"),
                                codEmpresaNombre = reader.GetStringOrNull("codEmpresaNombre"),
                                codSistema = reader.GetStringOrNull("codSistema"),
                                codSistemaNombre = reader.GetStringOrNull("codSistemaNombre"),
                                codRol = reader.GetStringOrNull("codRol"),
                                codRolNombre = reader.GetStringOrNull("codRolNombre"),
                                codUsuario = reader.GetStringOrNull("codUsuario"),
                                codUsuarioNombre = reader.GetStringOrNull("codUsuarioNombre"),
                                fecRegistroApp = reader.GetDateTime("fecRegistroApp"),
                                fecRegistroBD = reader.GetDateTime("fecRegistroBD"),

                                desLogin = reader.GetStringOrNull("desLogin"),
                                desMensaje = reader.GetStringOrNull("desMensaje"),
                                desTipo = reader.GetStringOrNull("desTipo"),
                                nomMaquinaIP = reader.GetStringOrNull("nomMaquinaIP")

                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
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

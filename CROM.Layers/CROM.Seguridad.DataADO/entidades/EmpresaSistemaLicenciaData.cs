namespace CROM.Seguridad.DataADO
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Tools.Comun.settings;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de :
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Descripcion : Capa de Datos (ADO.NET puro)
    /// Archivo     : [Seguridad.EmpresaSistemaLicenciaData.cs]
    /// </summary>
    public class EmpresaSistemaLicenciaData
    {
        private string conexion = string.Empty;

        public EmpresaSistemaLicenciaData()
        {
            conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG");
        }

        #region /* Proceso de SELECT ALL */

        public List<BEEmpresaSistemaLicenciaRespose> ListPaged(BEBuscaEmpresaSistemaLicenciaRequest pFiltro)
        {
            List<BEEmpresaSistemaLicenciaRespose> lstEmpresaSistema = new List<BEEmpresaSistemaLicenciaRespose>();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_ESLicencia_Paged"))
                {
                    cmd.AddParam("@p_NumPagina", SqlDbType.Int, pFiltro.jqCurrentPage);
                    cmd.AddParam("@p_TamPagina", SqlDbType.Int, pFiltro.jqPageSize);
                    cmd.AddParam("@p_OrdenPor", SqlDbType.VarChar, 30, pFiltro.jqSortColumn);
                    cmd.AddParam("@p_OrdenTipo", SqlDbType.VarChar, 4, pFiltro.jqSortOrder);
                    cmd.AddParam("@p_codEmpresaSistema", SqlDbType.Int, pFiltro.codEmpresaSistema);
                    cmd.AddParam("@p_codEmpresa", SqlDbType.Int, pFiltro.codEmpresa);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pFiltro.codSistema);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pFiltro.indActivo);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstEmpresaSistema.Add(new BEEmpresaSistemaLicenciaRespose()
                            {
                                codEmpresaSistemaLic = reader.GetInt("codEmpresaSistemaLic"),
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


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

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
    /// Proyecto    : Seguridad del Sistema
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Descripcion : Clase para capa de datos (ADO.NET puro)
    /// Archivo     : SistemasData.cs
    /// </summary
    public class SistemaData
    {
        private string conexion = String.Empty;
        public SistemaData()
        {
            conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG");
        }

        #region " /* Proceso de Insertar */ "
        public string Insert(BESistema pItem)
        {
            string codigoRetorno = "";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_Insert_Sistema"))
                {
                    SqlParameter pCodSistema = cmd.AddInputOutputParam("@p_codSistema", SqlDbType.VarChar, 4, codigoRetorno);
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 40, pItem.desNombre);
                    cmd.AddParam("@p_desDescripcion", SqlDbType.VarChar, 100, pItem.desDescripcion);
                    cmd.AddParam("@p_indEstado", SqlDbType.Bit, Convert.ToBoolean(pItem.indEstado));
                    cmd.AddParam("@p_segUsuarioCrea", SqlDbType.VarChar, 50, pItem.segUsuarioCrea);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    codigoRetorno = pCodSistema.Value == null || pCodSistema.Value == DBNull.Value ? "" : pCodSistema.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno;
        }

        #endregion

        #region " /* Proceso de Actualizar */ "
        public bool Update(BESistema pItem)
        {
            int CodigoRetorno = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_Update_Sistema"))
                {
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pItem.codSistema);
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 40, pItem.desNombre);
                    cmd.AddParam("@p_desDescripcion", SqlDbType.VarChar, 100, pItem.desDescripcion);
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

        public bool Delete(string CodigoSistema)
        {
            int CodigoRetorno = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_Delete_Sistema"))
                {
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, CodigoSistema);
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

        #region " /* Proceso de Encontrar */ "

        public BESistema Find(string CodigoSistema)
        {
            BESistema itemSistemas = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_Find_Sistema"))
                {
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, CodigoSistema);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            itemSistemas = new BESistema()
                            {
                                codSistema = reader.GetStringOrNull("codSistema"),
                                desDescripcion = reader.GetStringOrNull("desDescripcion"),
                                desNombre = reader.GetStringOrNull("desNombre"),
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
            return itemSistemas;
        }

        #endregion

        #region " /* Proceso de Listar */ "

        public List<BESistema> List(string prm_CodigoSistema, string prm_Nombre, string prm_Descripcion, bool? prm_Estado)
        {
            List<BESistema> lista = new List<BESistema>();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_GetAll_Sistema"))
                {
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, prm_CodigoSistema);
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 20, prm_Nombre);
                    cmd.AddParam("@p_desDescripcion", SqlDbType.VarChar, 20, prm_Descripcion);
                    cmd.AddParam("@p_indEstado", SqlDbType.Bit, prm_Estado);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BESistema()
                            {
                                codSistema = reader.GetStringOrNull("codSistema"),
                                desDescripcion = reader.GetStringOrNull("desDescripcion"),
                                desNombre = reader.GetStringOrNull("desNombre"),
                                indEstado = reader.GetBool("indEstado"),
                                segUsuarioCrea = reader.GetStringOrNull("segUsuarioCrea"),
                                segFechaHoraCrea = reader.GetDateTime("segFechaHoraCrea"),
                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaHoraEdita = reader.GetDateTimeOrNull("segFechaHoraEdita"),
                                segMaquinaCrea = reader.GetStringOrNull("segMaquinaOrigen")

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

        public List<BESistemaResponse> ListPaged(BEBuscaSistemaRequest pFiltro)
        {
            List<BESistemaResponse> lista = new List<BESistemaResponse>();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_Sistema_Paged"))
                {
                    cmd.AddParam("@p_NumPagina", SqlDbType.Int, pFiltro.jqCurrentPage);
                    cmd.AddParam("@p_TamPagina", SqlDbType.Int, pFiltro.jqPageSize);
                    cmd.AddParam("@p_OrdenPor", SqlDbType.VarChar, 30, pFiltro.jqSortColumn);
                    cmd.AddParam("@p_OrdenTipo", SqlDbType.VarChar, 4, pFiltro.jqSortOrder);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pFiltro.codSistema);
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 20, pFiltro.desNombre);
                    cmd.AddParam("@p_gloDescripcion", SqlDbType.VarChar, 20, pFiltro.gloDescripcion);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pFiltro.indActivo);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BESistemaResponse()
                            {
                                ROW = reader.GetInt("ROWNUM"),
                                TOTALROWS = reader.GetInt("TOTALROWS"),

                                codSistema = reader.GetStringOrNull("codSistema"),
                                desDescripcion = reader.GetStringOrNull("desDescripcion"),
                                desNombre = reader.GetStringOrNull("desNombre"),
                                indEstado = reader.GetBool("indEstado"),

                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaEdita = reader.GetDateTimeOrNull("segFechaHoraEdita"),
                                segMaquinaEdita = reader.GetStringOrNull("segMaquinaEdita"),


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

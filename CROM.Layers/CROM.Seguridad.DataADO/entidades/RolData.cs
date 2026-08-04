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
    /// Archivo     : RolesData.cs
    /// </summary
    public class RolData
    {
        private string conexion = String.Empty;
        public RolData()
        {
            conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG");
        }

        #region " /* Proceso de Insertar */ "
        public string Insert(BERolAux pItem)
        {
            string codigoRetorno = "";
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_Insert_Rol"))
                {
                    SqlParameter pCodRol = cmd.AddInputOutputParam("@p_codRol", SqlDbType.VarChar, 4, codigoRetorno);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pItem.codSistema);
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 25, pItem.desNombre);
                    cmd.AddParam("@p_desDescripcion", SqlDbType.VarChar, 50, pItem.desDescripcion);
                    cmd.AddParam("@p_indEstado", SqlDbType.Bit, Convert.ToBoolean(pItem.indEstado));
                    cmd.AddParam("@p_segUsuarioCrea", SqlDbType.VarChar, 50, pItem.segUsuarioCrea);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    codigoRetorno = pCodRol.Value == null || pCodRol.Value == DBNull.Value ? "" : pCodRol.Value.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return codigoRetorno;
        }

        #endregion

        #region " /* Proceso de Actualizar */ "
        public bool Update(BERolAux pItem)
        {
            int CodigoRetorno = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_Update_Rol"))
                {
                    cmd.AddParam("@p_codRol", SqlDbType.VarChar, 4, pItem.codRol);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pItem.codSistema);
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 25, pItem.desNombre);
                    cmd.AddParam("@p_desDescripcion", SqlDbType.VarChar, 50, pItem.desDescripcion);
                    cmd.AddParam("@p_indEstado", SqlDbType.Bit, Convert.ToBoolean(pItem.indEstado));
                    cmd.AddParam("@p_SegUsuarioEdita", SqlDbType.VarChar, 50, pItem.segUsuarioCrea);
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

        public bool Delete(BEEliminaRolRequest pEliminaRol)
        {
            int CodigoRetorno = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_Delete_Rol"))
                {
                    cmd.AddParam("@p_codRol", SqlDbType.VarChar, 4, pEliminaRol.codRol);
                    cmd.AddParam("@p_usuarioEdita", SqlDbType.VarChar, 25, pEliminaRol.UsuarioEdita);
                    cmd.AddParam("@p_segMaquina", SqlDbType.VarChar, 25, pEliminaRol.SegMaquina);
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

        public BERol Find(string CodigoRol)
        {
            BERol itemRol = new BERol();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_Find_Rol"))
                {
                    cmd.AddParam("@p_codRol", SqlDbType.VarChar, 4, CodigoRol);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            itemRol = new BERol()
                            {
                                codRol = reader.GetStringOrNull("codRol"),
                                desDescripcion = reader.GetStringOrNull("desDescripcion"),
                                desNombre = reader.GetStringOrNull("desNombre"),
                                indEstado = reader.GetBool("indEstado"),
                                segUsuarioCrea = reader.GetStringOrNull("segUsuarioCrea"),
                                segFechaHoraCrea = reader.GetDateTime("SegFechaHoraCrea"),
                                segUsuarioEdita = reader.GetStringOrNull("SegUsuarioEdita"),
                                segFechaHoraEdita = reader.GetDateTimeOrNull("SegFechaHoraEdita"),
                                segMaquinaCrea = reader.GetStringOrNull("SegMaquinaOrigen"),
                                codSistema = reader.GetStringOrNull("codSistema"),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemRol;
        }

        #endregion

        #region " /* Proceso de Listar */ "

        public List<BERolAux> List(string prm_Nombre, string prm_CodigoSistema, string prm_Descripcion, bool prm_Estado)
        {
            List<BERolAux> lista = new List<BERolAux>();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_GetAll_Rol"))
                {
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 15, prm_Nombre);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, prm_CodigoSistema);
                    cmd.AddParam("@p_desDescripcion", SqlDbType.VarChar, 15, prm_Descripcion);
                    cmd.AddParam("@p_indEstado", SqlDbType.Bit, prm_Estado);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BERolAux()
                            {
                                codRol = reader.GetStringOrNull("codRol"),
                                codSistema = reader.GetStringOrNull("codSistema"),
                                desDescripcion = reader.GetStringOrNull("desDescripcion"),
                                desNombre = reader.GetStringOrNull("desNombre"),
                                indEstado = reader.GetBool("indEstado"),
                                segUsuarioCrea = reader.GetStringOrNull("SegUsuarioCrea"),
                                segFechaHoraCrea = reader.GetDateTime("SegFechaHoraCrea"),
                                segUsuarioEdita = reader.GetStringOrNull("SegUsuarioEdita"),
                                segFechaHoraEdita = reader.GetDateTimeOrNull("SegFechaHoraEdita"),
                                segMaquinaCrea = reader.GetStringOrNull("SegMaquinaOrigen"),
                                codSistemaNombre = reader.GetStringOrNull("codSistemaNombre"),
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

        public List<BERolResponse> ListPaged(BEBuscaRolRequest pFiltro)
        {
            List<BERolResponse> lista = new List<BERolResponse>();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_Rol_Paged"))
                {
                    cmd.AddParam("@p_NumPagina", SqlDbType.Int, pFiltro.jqCurrentPage);
                    cmd.AddParam("@p_TamPagina", SqlDbType.Int, pFiltro.jqPageSize);
                    cmd.AddParam("@p_OrdenPor", SqlDbType.VarChar, 30, pFiltro.jqSortColumn);
                    cmd.AddParam("@p_OrdenTipo", SqlDbType.VarChar, 4, pFiltro.jqSortOrder);
                    cmd.AddParam("@p_codRol", SqlDbType.VarChar, 4, pFiltro.codRol);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pFiltro.codSistema);
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 20, pFiltro.desNombre);
                    cmd.AddParam("@p_gloDescripcion", SqlDbType.VarChar, 20, pFiltro.gloDescripcion);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pFiltro.indActivo);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BERolResponse()
                            {
                                ROW = reader.GetInt("ROWNUM"),
                                TOTALROWS = reader.GetInt("TOTALROWS"),

                                codRol = reader.GetStringOrNull("codRol"),
                                codSistema = reader.GetStringOrNull("codSistema"),
                                desDescripcion = reader.GetStringOrNull("desDescripcion"),
                                desNombre = reader.GetStringOrNull("desNombre"),
                                indEstado = reader.GetBool("indEstado"),
                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaEdita = reader.GetDateTimeOrNull("segFechaHoraEdita"),
                                segMaquinaEdita = reader.GetStringOrNull("segMaquinaEdita"),

                                codSistemaNombre = reader.GetStringOrNull("codSistemaNombre")

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

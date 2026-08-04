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
    /// Archivo     : OpcionesData.cs
    /// </summary
    public class OpcionData
    {

        private string conexion = String.Empty;
        public OpcionData()
        {
            conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG");
        }

        #region " /* Proceso de Insertar */ "
        public string Insert(BEOpcion pItem, out string pMessage)
        {
            string codigoRetorno = "";
            pMessage = string.Empty;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_Insert_Opcion"))
                {
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pItem.codSistema);
                    cmd.AddParam("@p_codOpcionPadre", SqlDbType.VarChar, 4, pItem.codOpcionPadre);
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 60, pItem.desNombre);
                    cmd.AddParam("@p_desDescripcion", SqlDbType.VarChar, 100, pItem.desDescripcion);
                    cmd.AddParam("@p_desEnlaceWIN", SqlDbType.VarChar, 100, pItem.desEnlaceWIN);
                    cmd.AddParam("@p_desEnlaceURL", SqlDbType.VarChar, 100, pItem.desEnlaceURL);
                    cmd.AddParam("@p_indMenu", SqlDbType.Bit, Convert.ToBoolean(pItem.indMenu));
                    cmd.AddParam("@p_indEstado", SqlDbType.Bit, Convert.ToBoolean(pItem.indEstado));
                    cmd.AddParam("@p_segUsuarioCrea", SqlDbType.VarChar, 50, pItem.segUsuarioCrea);
                    cmd.AddParam("@p_segMaquinaOrigen", SqlDbType.VarChar, 25, pItem.segMaquinaOrigen);
                    cmd.AddParam("@p_numOrden", SqlDbType.Int, pItem.numOrden);
                    cmd.AddParam("@p_nomIcono", SqlDbType.VarChar, 40, pItem.nomIcono);
                    cmd.AddParam("@p_indTipoObjeto", SqlDbType.VarChar, 40, pItem.indTipoObjeto);
                    cmd.AddParam("@p_codElementoID", SqlDbType.VarChar, 70, pItem.codElementoID);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string codError = reader.GetStringOrNull("codError");
                            if (codError != "-406")
                            {
                                pItem.codOpcion = codError;
                                codigoRetorno = codError;
                            }

                            pMessage = reader.GetStringOrNull("desMessage");
                        }
                    }
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
        public bool Update(BEOpcion pItem)
        {
            bool blnResult = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_Update_Opcion"))
                {
                    cmd.AddParam("@p_codOpcion", SqlDbType.VarChar, 4, pItem.codOpcion);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pItem.codSistema);
                    cmd.AddParam("@p_codOpcionPadre", SqlDbType.VarChar, 4, pItem.codOpcionPadre);
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 60, pItem.desNombre);
                    cmd.AddParam("@p_desDescripcion", SqlDbType.VarChar, 100, pItem.desDescripcion);
                    cmd.AddParam("@p_desEnlaceWIN", SqlDbType.VarChar, 100, pItem.desEnlaceWIN);
                    cmd.AddParam("@p_desEnlaceURL", SqlDbType.VarChar, 100, pItem.desEnlaceURL);
                    cmd.AddParam("@p_indMenu", SqlDbType.Bit, Convert.ToBoolean(pItem.indMenu));
                    cmd.AddParam("@p_indEstado", SqlDbType.Bit, Convert.ToBoolean(pItem.indEstado));
                    cmd.AddParam("@p_SegUsuarioEdita", SqlDbType.VarChar, 50, pItem.segUsuarioEdita);
                    cmd.AddParam("@p_segMaquinaOrigen", SqlDbType.VarChar, 25, pItem.segMaquinaOrigen);
                    cmd.AddParam("@p_numOrden", SqlDbType.Int, pItem.numOrden);
                    cmd.AddParam("@p_nomIcono", SqlDbType.VarChar, 40, pItem.nomIcono);
                    cmd.AddParam("@p_indTipoObjeto", SqlDbType.VarChar, 40, pItem.indTipoObjeto);
                    cmd.AddParam("@p_codElementoID", SqlDbType.VarChar, 70, pItem.codElementoID);
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
            catch (Exception ex)
            {
                throw ex;
            }
            return blnResult;
        }

        #endregion

        #region " /* Proceso de Eliminar */ "

        public bool Delete(string CodigoOpcion)
        {
            int CodigoRetorno = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_Delete_Opcion"))
                {
                    cmd.AddParam("@p_codOpcion", SqlDbType.VarChar, 4, CodigoOpcion);
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

        #region " /* Proceso de Buscar */ "

        public BEOpcionAux Find(string CodigoOpcion)
        {
            BEOpcionAux itemOpcion = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_Find_Opcion"))
                {
                    cmd.AddParam("@p_codOpcion", SqlDbType.VarChar, 4, CodigoOpcion);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            itemOpcion = new BEOpcionAux()
                            {
                                codSistema = reader.GetStringOrNull("codSistema"),
                                codOpcion = reader.GetStringOrNull("codOpcion"),
                                codOpcionPadre = reader.GetStringOrNull("codOpcionPadre"),
                                desEnlaceWIN = reader.GetStringOrNull("desEnlaceWIN"),
                                desEnlaceURL = reader.GetStringOrNull("desEnlaceURL"),
                                indMenu = reader.GetBool("indMenu"),
                                desDescripcion = reader.GetStringOrNull("desDescripcion"),
                                desNombre = reader.GetStringOrNull("desNombre"),
                                indEstado = reader.GetBool("indEstado"),
                                segUsuarioCrea = reader.GetStringOrNull("SegUsuarioCrea"),
                                segFechaHoraCrea = reader.GetDateTime("SegFechaHoraCrea"),
                                segUsuarioEdita = reader.GetStringOrNull("SegUsuarioEdita"),
                                segFechaHoraEdita = reader.GetDateTimeOrNull("SegFechaHoraEdita"),
                                segMaquinaOrigen = reader.GetStringOrNull("SegMaquinaOrigen"),
                                numOrden = reader.GetInt("numOrden"),
                                nomIcono = reader.GetStringOrNull("nomIcono"),
                                indTipoObjeto = reader.GetStringOrNull("indTipoObjeto"),
                                codElementoID = reader.GetStringOrNull("codElementoID")
                            };
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return itemOpcion;
        }

        #endregion

        #region " /* Proceso de Listar */ "

        public List<BEOpcionAux> List(string prm_CodigoOpcion, string prm_CodigoSistema, string prm_Nombre,
                                      string prm_Descripcion, bool prm_Estado, string pTipoObjeto)
        {
            List<BEOpcionAux> lista = new List<BEOpcionAux>();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_GetAll_Opcion"))
                {
                    cmd.AddParam("@p_codOpcion", SqlDbType.VarChar, 4, prm_CodigoOpcion);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, prm_CodigoSistema);
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 15, prm_Nombre);
                    cmd.AddParam("@p_desDescripcion", SqlDbType.VarChar, 15, prm_Descripcion);
                    cmd.AddParam("@p_indEstado", SqlDbType.Bit, prm_Estado);
                    cmd.AddParam("@p_TipoObjeto", SqlDbType.VarChar, 15, pTipoObjeto);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BEOpcionAux()
                            {
                                codOpcion = reader.GetStringOrNull("codOpcion"),
                                codOpcionPadre = reader.GetStringOrNull("codOpcionPadre"),
                                desEnlaceWIN = reader.GetStringOrNull("desEnlaceWIN"),
                                desEnlaceURL = reader.GetStringOrNull("desEnlaceURL"),
                                indMenu = reader.GetBool("indMenu"),
                                desDescripcion = reader.GetStringOrNull("desDescripcion"),
                                desNombre = reader.GetStringOrNull("desNombre"),
                                indEstado = reader.GetBool("indEstado"),
                                codSistema = reader.GetStringOrNull("codSistema"),
                                codSistemaNombre = reader.GetStringOrNull("codSistemaNombre"),
                                segUsuarioCrea = reader.GetStringOrNull("segUsuarioCrea"),
                                segFechaHoraCrea = reader.GetDateTime("segFechaHoraCrea"),
                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaHoraEdita = reader.GetDateTimeOrNull("segFechaHoraEdita"),
                                segMaquinaOrigen = reader.GetStringOrNull("segMaquinaOrigen"),
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

        public List<BEOpcionResponse> ListPaged(BEBuscaOpcionRequest pFiltro)
        {
            List<BEOpcionResponse> lista = new List<BEOpcionResponse>();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_Opcion_Paged"))
                {
                    cmd.AddParam("@p_TamPagina", SqlDbType.Int, pFiltro.jqPageSize);
                    cmd.AddParam("@p_NumPagina", SqlDbType.Int, pFiltro.jqCurrentPage);
                    cmd.AddParam("@p_OrdenPor", SqlDbType.VarChar, 30, pFiltro.jqSortColumn);
                    cmd.AddParam("@p_OrdenTipo", SqlDbType.VarChar, 4, pFiltro.jqSortOrder);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pFiltro.codSistema);
                    cmd.AddParam("@p_codOpcion", SqlDbType.VarChar, 4, pFiltro.codObjeto);
                    cmd.AddParam("@p_codOpcionPadre", SqlDbType.VarChar, 4, pFiltro.codObjetoPadre);
                    cmd.AddParam("@p_desNombre", SqlDbType.VarChar, 20, pFiltro.desNombre);
                    cmd.AddParam("@p_desEnlace", SqlDbType.VarChar, 20, pFiltro.desEnlaceURL);
                    cmd.AddParam("@p_tipObjeto", SqlDbType.VarChar, 20, pFiltro.tipObjeto);
                    cmd.AddParam("@p_desNombrePadre", SqlDbType.VarChar, 20, pFiltro.desNombrePadre);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pFiltro.indActivo);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BEOpcionResponse()
                            {
                                ROW = reader.GetInt("ROWNUM"),
                                TOTALROWS = reader.GetInt("TOTALROWS"),

                                codOpcion = reader.GetStringOrNull("codOpcion"),
                                codOpcionPadre = reader.GetStringOrNull("codOpcionPadre"),
                                codOpcionPadreNombre = reader.GetStringOrNull("codObjetoPadreNombre"),
                                desEnlaceWIN = reader.GetStringOrNull("desEnlaceWin"),
                                desEnlaceURL = reader.GetStringOrNull("desEnlaceURL"),
                                indMenu = reader.GetBool("indMenu"),
                                desDescripcion = reader.GetStringOrNull("desDescripcion"),
                                desNombre = reader.GetStringOrNull("desNombre"),
                                indTipoObjeto = reader.GetStringOrNull("indTipoObjeto"),
                                codElementoID = reader.GetStringOrNull("codElementoID"),
                                nomIcono = reader.GetStringOrNull("nomIcono"),
                                numOrden = reader.GetInt("numOrden"),
                                indEstado = reader.GetBool("indEstado"),
                                codSistemaNombre = reader.GetStringOrNull("codSistemaNombre"),

                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaEdita = reader.GetDateTimeOrNull("segFechaHoraEdita"),
                                segMaquinaEdita = reader.GetStringOrNull("segMaquinaEdita")
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

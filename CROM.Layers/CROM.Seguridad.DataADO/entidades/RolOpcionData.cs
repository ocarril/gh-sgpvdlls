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
    /// Archivo     : RolesOpcionesData.cs
    /// </summary
    public class RolOpcionData
    {
        private string conexion = String.Empty;
        public RolOpcionData()
        {
            conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG");
        }

        #region " /* Proceso de Insertar / Actualizar*/ "

        public bool InsertUpdate(BERolOpcionAux pItem)
        {
            int CodigoRetorno = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_Insert_RolOpcion"))
                {
                    cmd.AddParam("@p_codRol", SqlDbType.VarChar, 4, pItem.codRol);
                    cmd.AddParam("@p_codOpcion", SqlDbType.VarChar, 4, pItem.codOpcion);
                    cmd.AddParam("@p_indVer", SqlDbType.Bit, pItem.indVer);
                    cmd.AddParam("@p_indNuevo", SqlDbType.Bit, pItem.indNuevo);
                    cmd.AddParam("@p_indEditar", SqlDbType.Bit, pItem.indEditar);
                    cmd.AddParam("@p_indEliminar", SqlDbType.Bit, pItem.indEliminar);
                    cmd.AddParam("@p_indImprime", SqlDbType.Bit, pItem.indImprime);
                    cmd.AddParam("@p_indImporta", SqlDbType.Bit, pItem.indImporta);
                    cmd.AddParam("@p_indExporta", SqlDbType.Bit, pItem.indExporta);
                    cmd.AddParam("@p_indOtro", SqlDbType.Bit, pItem.indOtro);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pItem.indActivo);
                    cmd.AddParam("@p_segUsuarioCrea", SqlDbType.VarChar, 50, pItem.segUsuarioCrea);
                    cmd.AddParam("@p_segMaquinaOrigen", SqlDbType.VarChar, 25, pItem.segMaquinaOrigen);
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

        public bool Delete(string CodigoRol, string CodigoOpcion)
        {
            int CodigoRetorno = -1;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_Delete_RolOpcion"))
                {
                    cmd.AddParam("@p_codRol", SqlDbType.VarChar, 4, CodigoRol);
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

        public bool DeleteWS(int pcodRolOpcion)
        {
            bool blnResult = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_D_RolOpcion"))
                {
                    cmd.AddParam("@p_codRolOpcion", SqlDbType.Int, pcodRolOpcion);
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

        public BERolOpcion Find(string CodigoRol, string CodigoOpcion)
        {
            BERolOpcion itemRolesOpciones = new BERolOpcion();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_Find_RolOpcion"))
                {
                    cmd.AddParam("@p_codRol", SqlDbType.VarChar, 4, CodigoRol);
                    cmd.AddParam("@p_codOpcion", SqlDbType.VarChar, 4, CodigoOpcion);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            itemRolesOpciones = new BERolOpcion()
                            {
                                codRol = reader.GetStringOrNull("codRol"),
                                codOpcion = reader.GetStringOrNull("codOpcion"),
                                indEditar = reader.GetBool("indEditar"),
                                indEliminar = reader.GetBool("indEliminar"),
                                indExporta = reader.GetBool("indExporta"),
                                indImporta = reader.GetBool("indImporta"),
                                indImprime = reader.GetBool("indImprime"),
                                indNuevo = reader.GetBool("indNuevo"),
                                indOtro = reader.GetBool("indOtro"),
                                indVer = reader.GetBool("indVer"),
                                segUsuarioCrea = reader.GetStringOrNull("SegUsuarioCrea"),
                                segFechaHoraCrea = reader.GetDateTime("SegFechaHoraCrea"),
                                segUsuarioEdita = reader.GetStringOrNull("SegUsuarioEdita"),
                                segFechaHoraEdita = reader.GetDateTime("SegFechaHoraEdita"),
                                segMaquinaOrigen = reader.GetStringOrNull("SegMaquinaOrigen")
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemRolesOpciones;
        }

        public BERolOpcion FindWS(int p_codRolOpcion)
        {
            BERolOpcion itemRolesOpciones = new BERolOpcion();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_RolOpcion"))
                {
                    cmd.AddParam("@p_codRolOpcion", SqlDbType.Int, p_codRolOpcion);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            itemRolesOpciones = new BERolOpcion()
                            {
                                codRolOpcion = reader.GetInt("codRolOpcion"),
                                codRol = reader.GetStringOrNull("codRol"),
                                codOpcion = reader.GetStringOrNull("codOpcion"),
                                indEditar = reader.GetBool("indEditar"),
                                indEliminar = reader.GetBool("indEliminar"),
                                indExporta = reader.GetBool("indExporta"),
                                indImporta = reader.GetBool("indImporta"),
                                indImprime = reader.GetBool("indImprime"),
                                indNuevo = reader.GetBool("indNuevo"),
                                indOtro = reader.GetBool("indOtro"),
                                indVer = reader.GetBool("indVer"),
                                indActivo = reader.GetBool("indActivo"),
                                segUsuarioCrea = reader.GetStringOrNull("segUsuarioCrea"),
                                segFechaHoraCrea = reader.GetDateTime("segFechaHoraCrea"),
                                segUsuarioEdita = reader.GetStringOrNull("segUsuarioEdita"),
                                segFechaHoraEdita = reader.GetDateTime("segFechaHoraEdita"),
                                segMaquinaOrigen = reader.GetStringOrNull("segMaquinaOrigen")
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemRolesOpciones;
        }

        #endregion

        #region " /* Proceso de Listar */ "

        public List<BERolOpcionAux> List(string prm_CodigoSistema, string prm_CodigoRol)
        {
            List<BERolOpcionAux> lista = new List<BERolOpcionAux>();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.omgc_mnt_GetAll_RolOpcion"))
                {
                    cmd.AddParam("@p_CodSistema", SqlDbType.VarChar, 4, prm_CodigoSistema);
                    cmd.AddParam("@p_codRol", SqlDbType.VarChar, 4, prm_CodigoRol);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BERolOpcionAux()
                            {
                                codRol = reader.GetStringOrNull("codRol"),
                                codOpcion = reader.GetStringOrNull("codOpcion"),
                                indEditar = reader.GetBool("indEditar"),
                                indEliminar = reader.GetBool("indEliminar"),
                                indExporta = reader.GetBool("indExporta"),
                                indImporta = reader.GetBool("indImporta"),
                                indImprime = reader.GetBool("indImprime"),
                                indNuevo = reader.GetBool("indNuevo"),
                                indOtro = reader.GetBool("indOtro"),
                                indVer = reader.GetBool("indVer"),
                                indMenu = reader.GetBool("indMenu") == true ? true : false,
                                segUsuarioCrea = reader.GetStringOrNull("SegUsuarioCrea"),
                                segFechaHoraCrea = reader.GetDateTime("SegFechaHoraCrea"),
                                segUsuarioEdita = reader.GetStringOrNull("SegUsuarioEdita"),
                                segFechaHoraEdita = reader.GetDateTime("SegFechaHoraEdita"),
                                segMaquinaOrigen = reader.GetStringOrNull("SegMaquinaOrigen"),
                                codOpcionNombre = reader.GetStringOrNull("codOpcionNombre"),
                                codRolNombre = reader.GetStringOrNull("codRolNombre"),
                                codOpcionEnlaceWIN = reader.GetStringOrNull("codOpcionEnlaceWIN"),
                                codOpcionEnlaceURL = reader.GetStringOrNull("codOpcionEnlaceURL"),
                                codOpcionPadre = reader.GetStringOrNull("codOpcionPadre"),
                                codOpcionDescripcion = reader.GetStringOrNull("codOpcionDescripcion")
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

        public List<BERolOpcionResponse> ListPaged(BEBuscaRolOpcionRequest pFiltro)
        {
            List<BERolOpcionResponse> lista = new List<BERolOpcionResponse>();
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                using (SqlCommand cmd = cn.CreateStoredProcCommand("Seguridad.usp_sis_R_RolOpcion_Paged"))
                {
                    cmd.AddParam("@p_NumPagina", SqlDbType.Int, pFiltro.jqCurrentPage);
                    cmd.AddParam("@p_TamPagina", SqlDbType.Int, pFiltro.jqPageSize);
                    cmd.AddParam("@p_OrdenPor", SqlDbType.VarChar, 30, pFiltro.jqSortColumn);
                    cmd.AddParam("@p_OrdenTipo", SqlDbType.VarChar, 4, pFiltro.jqSortOrder);
                    cmd.AddParam("@p_codSistema", SqlDbType.VarChar, 4, pFiltro.codSistema);
                    cmd.AddParam("@p_codRol", SqlDbType.VarChar, 4, pFiltro.codRol);
                    cmd.AddParam("@p_codOpcion", SqlDbType.VarChar, 4, pFiltro.codOpcion);
                    cmd.AddParam("@p_indVisualiza", SqlDbType.Bit, pFiltro.indVisualiza);
                    cmd.AddParam("@p_indActivo", SqlDbType.Bit, pFiltro.indActivo);
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new BERolOpcionResponse()
                            {
                                ROW = reader.GetInt("ROWNUM"),
                                TOTALROWS = reader.GetInt("TOTALROWS"),

                                codRolOpcion = reader.GetInt("codRolOpcion"),
                                codOpcionNombre = reader.GetStringOrNull("codOpcionNombre"),
                                codElementoID = reader.GetStringOrNull("codElementoID"),
                                desEnlaceURL = reader.GetStringOrNull("desEnlaceURL"),
                                desEnlaceWIN = reader.GetStringOrNull("desEnlaceWIN"),
                                numOrden = reader.GetInt("numOrden"),
                                nomIcono = reader.GetStringOrNull("nomIcono"),
                                indTipoObjeto = reader.GetStringOrNull("indTipoObjeto"),

                                indEditar = reader.GetBool("indEditar"),
                                indEliminar = reader.GetBool("indEliminar"),
                                indExporta = reader.GetBool("indExporta"),
                                indImporta = reader.GetBool("indImporta"),
                                indImprime = reader.GetBool("indImprime"),
                                indNuevo = reader.GetBool("indNuevo"),
                                indOtro = reader.GetBool("indOtro"),
                                indVer = reader.GetBool("indVer"),

                                indActivo = reader.GetBool("indActivo"),
                                codRolNombre = reader.GetStringOrNull("codRolNombre"),
                                codSistemaNombre = reader.GetStringOrNull("codSistemaNombre"),

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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

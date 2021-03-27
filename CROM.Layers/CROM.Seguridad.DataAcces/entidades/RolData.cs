namespace CROM.Seguridad.DataAcces
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Tools.Comun.settings;

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Seguridad del Sistema
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 06/11/2009
    /// Descripcion : Clase para capa de datos
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
        /// <summary>
        /// Registrar una Entidad Roles
        /// </summary>
        /// <param name="pItem">Entidad Roles</param>
        public string Insert(BERolAux pItem)
        {
            string codigoRetorno = "";
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    SeguridadDC.omgc_mnt_Insert_Rol(
                            ref codigoRetorno,
                            pItem.codSistema,
                            pItem.desNombre,
                            pItem.desDescripcion,
                            Convert.ToBoolean(pItem.indEstado),
                            pItem.segUsuarioCrea);
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
        /// <summary>
        /// Actualiza el registro de un objeto de tipo Roles
        /// </summary>
        /// <param name="pItem">Entidad Roles</param>
        public bool Update(BERolAux pItem)
        {
            int CodigoRetorno = -1;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    CodigoRetorno = SeguridadDC.omgc_mnt_Update_Rol
                        (
                        pItem.codRol,
                        pItem.codSistema,
                        pItem.desNombre,
                        pItem.desDescripcion,
                        Convert.ToBoolean(pItem.indEstado),
                        pItem.segUsuarioCrea
                        );
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

        /// <summary>
        /// Elimina un expediente de la tabla Facturas por una llave primaria compuesta.
        /// </summary>
        public bool Delete(BEEliminaRolRequest pEliminaRol)
        {
            int CodigoRetorno = -1;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {

                    CodigoRetorno = SeguridadDC.omgc_mnt_Delete_Rol(pEliminaRol.codRol, 
                                                                    pEliminaRol.UsuarioEdita,
                                                                    pEliminaRol.SegMaquina);
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

        /// <summary>
        /// Retorna un objeto de registros de tipo [Tabla].Roles
        /// </summary>
        /// <returns>Lista</returns>
        public BERol Find(string CodigoRol)
        {
            BERol itemRol = new BERol();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.omgc_mnt_Find_Rol(CodigoRol);
                    foreach (var item in resul)
                    {
                        itemRol = new BERol()
                        {
                            codRol = item.codRol,
                            desDescripcion = item.desDescripcion,
                            desNombre = item.desNombre,
                            indEstado = item.indEstado,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segFechaHoraCrea = Convert.ToDateTime(item.SegFechaHoraCrea),
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaHoraEdita = item.SegFechaHoraEdita,
                            segMaquinaCrea = item.SegMaquinaOrigen,
                            codSistema = item.codSistema,
                        };
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

        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla]..Roles
        /// </summary>
        /// <returns>Lista</returns>
        public List<BERolAux> List(string prm_Nombre, string prm_CodigoSistema, string prm_Descripcion, bool prm_Estado)
        {
            List<BERolAux> lista = new List<BERolAux>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.omgc_mnt_GetAll_Rol(prm_Nombre, prm_CodigoSistema, prm_Descripcion, prm_Estado);
                    foreach (var item in resul)
                    {
                        lista.Add(new BERolAux()
                        {
                            codRol = item.codRol,
                            codSistema = item.codSistema,
                            desDescripcion = item.desDescripcion,
                            desNombre = item.desNombre,
                            indEstado = item.indEstado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segFechaHoraCrea = Convert.ToDateTime(item.SegFechaHoraCrea),
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaHoraEdita = item.SegFechaHoraEdita,
                            segMaquinaCrea = item.SegMaquinaOrigen,
                            codSistemaNombre = item.codSistemaNombre,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        /// <summary>
        /// Listado con paginacion para aplicación WEB 
        /// </summary>
        /// <param name="prm_Nombre"></param>
        /// <param name="prm_CodigoSistema"></param>
        /// <param name="prm_Descripcion"></param>
        /// <param name="prm_Estado"></param>
        /// <param name="p_NumPagina"></param>
        /// <param name="p_NumFilasP"></param>
        /// <param name="pNumFilasT"></param>
        /// <returns></returns>
        public List<BERolResponse> ListPaged(BEBuscaRolRequest pFiltro)
        {
            List<BERolResponse> lista = new List<BERolResponse>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_Rol_Paged(pFiltro.jqCurrentPage,
                                                                pFiltro.jqPageSize,
                                                                pFiltro.jqSortColumn,
                                                                pFiltro.jqSortOrder,
                                                                pFiltro.codRol,
                                                                pFiltro.codSistema,
                                                                pFiltro.desNombre,
                                                                pFiltro.gloDescripcion,
                                                                pFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lista.Add(new BERolResponse()
                        {
                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0,

                            codRol = item.codRol,
                            codSistema = item.codSistema,
                            desDescripcion = item.desDescripcion,
                            desNombre = item.desNombre,
                            indEstado = item.indEstado,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaHoraEdita,
                            segMaquinaEdita = item.segMaquinaEdita,

                            codSistemaNombre = item.codSistemaNombre

                        });
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
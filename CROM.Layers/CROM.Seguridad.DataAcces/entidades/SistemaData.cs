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
    /// Fecha       : 30/11/2009
    /// Descripcion : Clase para capa de datos
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
        /// <summary>
        /// Registrar una Entidad Roles
        /// </summary>
        /// <param name="pItem">Entidad Roles</param>
        public string Insert(BESistema pItem)
        {
            string codigoRetorno = "";
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    SeguridadDC.omgc_mnt_Insert_Sistema(
                            ref	codigoRetorno,
                            pItem.desNombre,
                            pItem.desDescripcion,
                            Convert.ToBoolean(pItem.indEstado),
                            pItem.segUsuarioCrea);
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
        /// <summary>
        /// Actualiza el registro de un objeto de tipo Roles
        /// </summary>
        /// <param name="pItem">Entidad Roles</param>
        public bool Update(BESistema pItem)
        {
            int CodigoRetorno = -1;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    CodigoRetorno = SeguridadDC.omgc_mnt_Update_Sistema(
                         pItem.codSistema,
                            pItem.desNombre,
                            pItem.desDescripcion,
                            Convert.ToBoolean(pItem.indEstado),
                            pItem.segUsuarioEdita
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
        public bool Delete(string CodigoSistema)
        {
            int CodigoRetorno = -1;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {

                    CodigoRetorno = SeguridadDC.omgc_mnt_Delete_Sistema(CodigoSistema);
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
        public BESistema Find(string CodigoSistema)
        {
            BESistema itemSistemas = null;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.omgc_mnt_Find_Sistema(CodigoSistema);
                    foreach (var item in resul)
                    {
                        itemSistemas = new BESistema()
                        {
                            codSistema = item.codSistema,
                            desDescripcion = item.desDescripcion,
                            desNombre = item.desNombre,
                            indEstado = item.indEstado,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segFechaHoraCrea = Convert.ToDateTime(item.segFechaHoraCrea),
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraEdita = item.segFechaHoraEdita,
                            segMaquinaCrea = item.segMaquinaOrigen,
                        };
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

        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla]..Roles
        /// </summary>
        /// <returns>Lista</returns>
        public List<BESistema> List(string prm_CodigoSistema, string prm_Nombre, string prm_Descripcion, bool ? prm_Estado)
        {
            List<BESistema> lista = new List<BESistema>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.omgc_mnt_GetAll_Sistema(prm_CodigoSistema, prm_Nombre, prm_Descripcion, prm_Estado);
                    foreach (var item in resul)
                    {
                        lista.Add(new BESistema()
                        {
                            codSistema = item.codSistema,
                            desDescripcion = item.desDescripcion,
                            desNombre = item.desNombre,
                            indEstado = item.indEstado,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segFechaHoraCrea = Convert.ToDateTime(item.segFechaHoraCrea),
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraEdita = item.segFechaHoraEdita,
                            segMaquinaCrea = item.segMaquinaOrigen

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ;
            }
            return lista;
        }

        /// <summary>
        /// Listado con paginacion para aplicación WEB 
        /// </summary>
        /// <param name="prm_CodigoSistema"></param>
        /// <param name="prm_Nombre"></param>
        /// <param name="prm_Descripcion"></param>
        /// <param name="prm_Estado"></param>
        /// <returns></returns>
        public List<BESistemaResponse> ListPaged(BEBuscaSistemaRequest pFiltro)
        {
            List<BESistemaResponse> lista = new List<BESistemaResponse>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_Sistema_Paged(pFiltro.jqCurrentPage, 
                                                                    pFiltro.jqPageSize,
                                                                    pFiltro.jqSortColumn,
                                                                    pFiltro.jqSortOrder,
                                                                    pFiltro.codSistema,
                                                                    pFiltro.desNombre,
                                                                    pFiltro.gloDescripcion,
                                                                    pFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lista.Add(new BESistemaResponse()
                        {
                            ROW   = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0,

                            codSistema = item.codSistema,
                            desDescripcion = item.desDescripcion,
                            desNombre = item.desNombre,
                            indEstado = item.indEstado,

                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaHoraEdita,
                            segMaquinaEdita = item.segMaquinaEdita,


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

        #endregion

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

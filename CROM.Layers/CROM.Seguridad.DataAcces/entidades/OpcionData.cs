namespace CROM.Seguridad.DataAcces
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Tools.Comun.settings;
    using CROM.Tools.Comun.Web;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Seguridad del Sistema
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 07/11/2009
    /// Descripcion : Clase para capa de datos
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
        /// <summary>
        /// Registrar una Entidad Opciones
        /// </summary>
        /// <param name="pItem">Entidad Opciones</param>
        public string Insert(BEOpcion pItem, out string pMessage)
        {
            string codigoRetorno = "";
            pMessage = string.Empty;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resulSet = SeguridadDC.omgc_mnt_Insert_Opcion(
                            pItem.codSistema,
                            pItem.codOpcionPadre,
                            pItem.desNombre,
                            pItem.desDescripcion,
                            pItem.desEnlaceWIN,
                            pItem.desEnlaceURL,
                            Convert.ToBoolean(pItem.indMenu),
                            Convert.ToBoolean(pItem.indEstado),
                            pItem.segUsuarioCrea,
                            pItem.segMaquinaOrigen,
                            pItem.numOrden,
                            pItem.nomIcono,
                            pItem.indTipoObjeto,
                            pItem.codElementoID);
                    foreach (var item in resulSet)
                    {
                        if (item.codError != "-406")
                        {
                            pItem.codOpcion = item.codError;
                            codigoRetorno = item.codError;
                        }

                        pMessage = item.desMessage;
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
        /// <summary>
        /// Actualiza el registro de un objeto de tipo Opciones
        /// </summary>
        /// <param name="pItem">Entidad Opciones</param>
        public bool Update(BEOpcion pItem)
        {
            bool blnResult = false;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resulSet = SeguridadDC.omgc_mnt_Update_Opcion(
                         pItem.codOpcion,
                         pItem.codSistema,
                         pItem.codOpcionPadre,
                         pItem.desNombre,
                         pItem.desDescripcion,
                         pItem.desEnlaceWIN,
                         pItem.desEnlaceURL,
                         Convert.ToBoolean(pItem.indMenu),
                         Convert.ToBoolean(pItem.indEstado),
                         pItem.segUsuarioEdita,
                            pItem.segMaquinaOrigen,
                            pItem.numOrden,
                            pItem.nomIcono,
                            pItem.indTipoObjeto,
                            pItem.codElementoID
                         );
                    foreach (var item in resulSet)
                    {
                        blnResult = item.desMessage == WebConstants.DEFAULT_OK ? true : false;
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

        /// <summary>
        /// Elimina un expediente de la tabla Facturas por una llave primaria compuesta.
        /// </summary>
        public bool Delete(string CodigoOpcion)
        {
            int CodigoRetorno = -1;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    CodigoRetorno = SeguridadDC.omgc_mnt_Delete_Opcion(CodigoOpcion);
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

        /// <summary>
        /// Retorna un objeto de registros de tipo [Tabla].Roles
        /// </summary>
        /// <returns>Lista</returns>
        public BEOpcionAux Find(string CodigoOpcion)
        {
            BEOpcionAux itemOpcion = null;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.omgc_mnt_Find_Opcion(CodigoOpcion);
                    foreach (var item in resul)
                    {
                        itemOpcion = new BEOpcionAux()
                        {
                            codSistema = item.codSistema,
                            codOpcion = item.codOpcion,
                            codOpcionPadre = item.codOpcionPadre,
                            desEnlaceWIN = item.desEnlaceWIN,
                            desEnlaceURL = item.desEnlaceURL,
                            indMenu = item.indMenu,
                            desDescripcion = item.desDescripcion,
                            desNombre = item.desNombre,
                            indEstado = item.indEstado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segFechaHoraCrea = Convert.ToDateTime(item.SegFechaHoraCrea),
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaHoraEdita = item.SegFechaHoraEdita,
                            segMaquinaOrigen = item.SegMaquinaOrigen,
                            numOrden = item.numOrden,
                            nomIcono = item.nomIcono,
                            indTipoObjeto = item.indTipoObjeto,
                            codElementoID = item.codElementoID
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return itemOpcion;
        }

        #endregion

        #region " /* Proceso de Listar */ "

        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla].Opciones
        /// </summary>
        /// <returns>Lista</returns>
        public List<BEOpcionAux> List(string prm_CodigoOpcion, string prm_CodigoSistema, string prm_Nombre, 
                                      string prm_Descripcion, bool prm_Estado, string pTipoObjeto)
        {
            List<BEOpcionAux> lista = new List<BEOpcionAux>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.omgc_mnt_GetAll_Opcion(prm_CodigoOpcion,
                                                                   prm_CodigoSistema, 
                                                                   prm_Nombre, 
                                                                   prm_Descripcion, 
                                                                   prm_Estado,
                                                                   pTipoObjeto
                                                                   );
                    foreach (var item in resul)
                    {
                        lista.Add(new BEOpcionAux()
                        {
                            codOpcion = item.codOpcion,
                            codOpcionPadre = item.codOpcionPadre,
                            desEnlaceWIN = item.desEnlaceWIN,
                            desEnlaceURL = item.desEnlaceURL,
                            indMenu = item.indMenu,
                            desDescripcion = item.desDescripcion,
                            desNombre = item.desNombre,
                            indEstado = item.indEstado,
                            codSistema=item.codSistema,
                            codSistemaNombre = item.codSistemaNombre,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segFechaHoraCrea = Convert.ToDateTime(item.segFechaHoraCrea),
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraEdita = item.segFechaHoraEdita,
                            segMaquinaOrigen = item.segMaquinaOrigen,
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
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEOpcionResponse> ListPaged(BEBuscaOpcionRequest pFiltro)
        {
            List<BEOpcionResponse> lista = new List<BEOpcionResponse>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_Opcion_Paged(pFiltro.jqPageSize,
                                                                   pFiltro.jqCurrentPage,
                                                                   pFiltro.jqSortColumn,
                                                                   pFiltro.jqSortOrder,
                                                                   pFiltro.codSistema,
                                                                   pFiltro.codObjeto,
                                                                   pFiltro.codObjetoPadre,
                                                                   pFiltro.desNombre,
                                                                   pFiltro.desEnlaceURL,
                                                                   pFiltro.tipObjeto,
                                                                   pFiltro.desNombrePadre,
                                                                   pFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lista.Add(new BEOpcionResponse()
                        {
                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0,

                            codOpcion = item.codOpcion,
                            codOpcionPadre = item.codOpcionPadre,
                            codOpcionPadreNombre = item.codObjetoPadreNombre,
                            desEnlaceWIN = item.desEnlaceWin,
                            desEnlaceURL = item.desEnlaceURL,
                            indMenu = item.indMenu,
                            desDescripcion = item.desDescripcion,
                            desNombre = item.desNombre,
                            indTipoObjeto = item.indTipoObjeto,
                            codElementoID = item.codElementoID,
                            nomIcono = item.nomIcono,
                            numOrden = item.numOrden,
                            indEstado = item.indEstado,
                            codSistemaNombre = item.codSistemaNombre,

                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaHoraEdita,
                            segMaquinaEdita = item.segMaquinaEdita
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

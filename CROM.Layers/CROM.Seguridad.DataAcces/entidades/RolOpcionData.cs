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
      
        /// <summary>
        /// Registrar una Entidad RolesOpciones
        /// </summary>
        /// <param name="pItem">Entidad RolesOpciones</param>
        public bool InsertUpdate(BERolOpcionAux pItem)
        {
            int CodigoRetorno = -1;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    CodigoRetorno = SeguridadDC.omgc_mnt_Insert_RolOpcion(
                            pItem.codRol,
                            pItem.codOpcion,
                            pItem.indVer,
                            pItem.indNuevo,
                            pItem.indEditar,
                            pItem.indEliminar,
                            pItem.indImprime,
                            pItem.indImporta,
                            pItem.indExporta,
                            pItem.indOtro,
                            pItem.indActivo,
                            pItem.segUsuarioCrea,
                            pItem.segMaquinaCrea
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
        public bool Delete(string CodigoRol, string CodigoOpcion)
        {
            int CodigoRetorno = -1;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    CodigoRetorno = SeguridadDC.omgc_mnt_Delete_RolOpcion(CodigoRol, CodigoOpcion);
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
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resulSet =  SeguridadDC.usp_sis_D_RolOpcion(pcodRolOpcion);
                    foreach (var item in resulSet)
                    {
                        blnResult = item.desMessage == WebConstants.DEFAULT_OK ? true : false;
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

        /// <summary>
        /// Retorna un objeto de registros de tipo [Tabla].RolesOpciones
        /// </summary>
        /// <returns>Lista</returns>
        public BERolOpcion Find(string CodigoRol, string CodigoOpcion)
        {
            BERolOpcion itemRolesOpciones = new BERolOpcion();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.omgc_mnt_Find_RolOpcion(CodigoRol, CodigoOpcion);
                    foreach (var item in resul)
                    {
                        itemRolesOpciones = new BERolOpcion()
                        {
                            codRol = item.codRol,
                            codOpcion = item.codOpcion,
                            indEditar = item.indEditar,
                            indEliminar = item.indEliminar,
                            indExporta = item.indExporta,
                            indImporta = item.indImporta,
                            indImprime = item.indImprime,
                            indNuevo = item.indNuevo,
                            indOtro = item.indOtro,
                            indVer = item.indVer,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segFechaHoraCrea = Convert.ToDateTime(item.SegFechaHoraCrea),
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaHoraEdita = Convert.ToDateTime(item.SegFechaHoraEdita),
                            segMaquinaOrigen = item.SegMaquinaOrigen
                        };
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
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_RolOpcion(p_codRolOpcion);
                    foreach (var item in resul)
                    {
                        itemRolesOpciones = new BERolOpcion()
                        {
                            codRolOpcion = item.codRolOpcion,
                            codRol = item.codRol,
                            codOpcion = item.codOpcion,
                            indEditar = item.indEditar,
                            indEliminar = item.indEliminar,
                            indExporta = item.indExporta,
                            indImporta = item.indImporta,
                            indImprime = item.indImprime,
                            indNuevo = item.indNuevo,
                            indOtro = item.indOtro,
                            indVer = item.indVer,
                            indActivo= item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segFechaHoraCrea = Convert.ToDateTime(item.segFechaHoraCrea),
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraEdita = Convert.ToDateTime(item.segFechaHoraEdita),
                            segMaquinaOrigen = item.segMaquinaOrigen
                        };
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

        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla]..RolesOpciones
        /// </summary>
        /// <returns>Lista</returns>
        public List<BERolOpcionAux> List(string prm_CodigoSistema, string prm_CodigoRol)
        {
            List<BERolOpcionAux> lista = new List<BERolOpcionAux>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.omgc_mnt_GetAll_RolOpcion(prm_CodigoSistema, prm_CodigoRol);
                    foreach (var item in resul)
                    {
                        lista.Add(new BERolOpcionAux()
                        {
                            codRol = item.codRol,
                            codOpcion = item.codOpcion,
                            indEditar = item.indEditar,
                            indEliminar = item.indEliminar,
                            indExporta = item.indExporta,
                            indImporta = item.indImporta,
                            indImprime = item.indImprime,
                            indNuevo = item.indNuevo,
                            indOtro = item.indOtro,
                            indVer = item.indVer,
                            indMenu = item.indMenu == true ? true : false,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segFechaHoraCrea = Convert.ToDateTime(item.SegFechaHoraCrea),
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaHoraEdita = Convert.ToDateTime(item.SegFechaHoraEdita),
                            segMaquinaOrigen = item.SegMaquinaOrigen,
                            codOpcionNombre = item.codOpcionNombre,
                            codRolNombre = item.codRolNombre,
                            codOpcionEnlaceWIN = item.codOpcionEnlaceWIN,
                            codOpcionEnlaceURL = item.codOpcionEnlaceURL,
                            codOpcionPadre = item.codOpcionPadre,
                            codOpcionDescripcion = item.codOpcionDescripcion
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
        /// <param name="prm_CodigoSistema"></param>
        /// <param name="prm_CodigoRol"></param>
        /// <param name="p_NumPagina"></param>
        /// <param name="p_NumFilasP"></param>
        /// <param name="pNumFilasT"></param>
        /// <returns></returns>
        public List<BERolOpcionResponse> ListPaged(BEBuscaRolOpcionRequest pFiltro)
        {
            List<BERolOpcionResponse> lista = new List<BERolOpcionResponse>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_RolOpcion_Paged(pFiltro.jqCurrentPage,
                                                                      pFiltro.jqPageSize,
                                                                      pFiltro.jqSortColumn,
                                                                      pFiltro.jqSortOrder,
                                                                      pFiltro.codSistema,
                                                                      pFiltro.codRol,
                                                                      pFiltro.codOpcion,
                                                                      pFiltro.indVisualiza,
                                                                      pFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lista.Add(new BERolOpcionResponse()
                        {
                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0,

                            codRolOpcion = item.codRolOpcion,
                            codOpcionNombre = item.codOpcionNombre,
                            codElementoID = item.codElementoID,
                            desEnlaceURL = item.desEnlaceURL,
                            desEnlaceWIN = item.desEnlaceWIN,
                            numOrden = item.numOrden,
                            nomIcono = item.nomIcono,
                            indTipoObjeto = item.indTipoObjeto,

                            indEditar = item.indEditar,
                            indEliminar = item.indEliminar,
                            indExporta = item.indExporta,
                            indImporta = item.indImporta,
                            indImprime = item.indImprime,
                            indNuevo = item.indNuevo,
                            indOtro = item.indOtro,
                            indVer = item.indVer,

                            indActivo = item.indActivo,
                            codRolNombre = item.codRolNombre,
                            codSistemaNombre = item.codSistemaNombre,

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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

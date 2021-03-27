namespace CROM.TablasMaestras.DataAcces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;

    using CROM.BusinessEntities.Maestros;
    using CROM.BusinessEntities;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de Tablas Maestras
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 26/03/2012
    /// Descripcion : Clase para capa de datos
    /// Archivo     : TablaData.cs
    /// </summary>
    public class TablaData
    {
        private string conexion = String.Empty;

        public TablaData()
        {
            conexion = Util.ConexionBD();
        }

        //----------------------------------------------------------
        // VERSION 2.0
        //----------------------------------------------------------
        /// <summary>
        /// LISTADO de la Entidad TEMaestro
        /// </summary>
        /// <param name="pCaso">Opción para Tipo de Búsqueda</param>
        /// <param name="pCodTabla">Código de la Tabla</param>
        /// <param name="pNomTabla">Nombre de la Tabla</param>
        /// <param name="pIdioma">Idioma a Seleccionar</param>
        /// <param name="modifyc">Indicador de Retorno</param>
        /// <returns>Retorna una colección de registros de tipo TEMaestro</returns>
        public List<BETablaMaestra> Listar(int pCaso, string pCodTabla, string pNomTabla, bool? p_Estado)
        {
            List<BETablaMaestra> lista = new List<BETablaMaestra>();
            try
            {
                using (_DBMLMaestrosDataContext tablasMaestrosDC = new _DBMLMaestrosDataContext(conexion))
                {
                    var query = tablasMaestrosDC.omgc_S_Tabla(pCodTabla, pNomTabla, p_Estado);
                    foreach (var item in query)
                    {
                        lista.Add(new BETablaMaestra()
                        {
                            CodigoTabla = item.codTabla,
                            Niveles = item.indNivel,
                            LongitudNivel = Convert.ToInt32(item.numLongitudNivel),
                            NombreTabla = item.desNombre,
                            DescripcionTabla = item.gloDescripcion,
                            TipoArgumento = Convert.ToString("A"),
                            TipoGeneracion = Convert.ToString("A"),
                            Estado = Convert.ToBoolean(item.indActivo),
                            SegUsuarioCrea = item.segUsuCrea,
                            SegUsuarioEdita = item.segUsuEdita,
                            SegFechaHoraCrea = item.segFechaCrea,
                            SegFechaHoraEdita = item.segFechaEdita,
                            SegMaquinaOrigen = item.segMaquinaOrigen
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

        public List<BETablaMaestra> ListarPaginado(BaseFiltroMaestro pFiltro)
        {
            List<BETablaMaestra> lista = new List<BETablaMaestra>();
            try
            {
                using (_DBMLMaestrosDataContext tablasMaestrosDC = new _DBMLMaestrosDataContext(conexion))
                {
                    var query = tablasMaestrosDC.omgc_S_Tabla_Paged(pFiltro.GNumPagina,
                                                                    pFiltro.GTamPagina,
                                                                    pFiltro.GOrdenPor,
                                                                    pFiltro.GOrdenTipo,
                                                                    pFiltro.codTabla,
                                                                    pFiltro.desNombre,
                                                                    pFiltro.indActivo);
                    foreach (var item in query)
                    {
                        lista.Add(new BETablaMaestra()
                        {
                            CodigoTabla = item.codTabla,
                            Niveles = item.indNivel,
                            LongitudNivel = Convert.ToInt32(item.numLongitudNivel),
                            NombreTabla = item.desNombre,
                            DescripcionTabla = item.gloDescripcion,
                            TipoArgumento = Convert.ToString("A"),
                            TipoGeneracion = Convert.ToString("A"),
                            Estado = Convert.ToBoolean(item.indActivo),
                            SegUsuarioCrea = item.segUsuCrea,
                            SegUsuarioEdita = item.segUsuEdita,
                            SegFechaHoraCrea = item.segFechaCrea,
                            SegFechaHoraEdita = item.segFechaEdita,
                            SegMaquinaOrigen = item.segMaquinaOrigen,

                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0
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

        //public List<SysTablas> ListarTablaBD()
        //{
        //    List<SysTablas> miLista = new List<SysTablas>();
        //    try
        //    {
        //        using (_DBMLMaestrosDataContext SQLDC = new _DBMLMaestrosDataContext(conexion))
        //        {
        //            int i = 0;
        //            var resul = SQLDC.omgc_P_Tabla_Sys();
        //            foreach (var item in resul)
        //            {
        //                ++i;
        //                miLista.Add(new SysTablas()
        //                {
        //                    EsquemaNombreTabla = item.EsquemaNombreTabla,
        //                    NombreTabla = item.NombreTabla,
        //                    Item = i.ToString().PadLeft(3, '0')
        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return miLista;
        //}

        /// <summary>
        /// Registrar una Entidad TablaMaestra
        /// </summary>
        /// <param name="pItem">Entidad TablaMaestra</param>
        public bool Registrar(BETablaMaestra pItem)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLMaestrosDataContext tablaMaestroDC = new _DBMLMaestrosDataContext(conexion))
                {
                    tablaMaestroDC.omgc_I_Tabla(
                           pItem.CodigoTabla,
                           pItem.NombreTabla,
                           pItem.DescripcionTabla,
                           Convert.ToBoolean(pItem.Niveles),
                           Convert.ToInt32(pItem.LongitudNivel),
                           Convert.ToBoolean(pItem.Estado),
                           pItem.SegUsuarioCrea,
                           pItem.SegMaquinaOrigen);
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        /// <summary>
        /// Actualiza el registro de un objeto de tipo TEMaestro
        /// </summary>
        /// <param name="pItem">Entidad TEMaestro</param>
        public bool Actualizar(BETablaMaestra pItem)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLMaestrosDataContext tablaMaestroDC = new _DBMLMaestrosDataContext(conexion))
                {
                    tablaMaestroDC.omgc_U_Tabla(pItem.CodigoTabla,
                                                pItem.NombreTabla,
                                                pItem.DescripcionTabla,
                                                pItem.Niveles,
                                                pItem.LongitudNivel,
                                                pItem.Estado,
                                                pItem.SegUsuarioEdita,
                                                pItem.SegMaquinaOrigen);
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        /// <summary>
        /// Elimina el registro de un objeto de tipo TEMaestro
        /// </summary>
        /// <param name="pCodigoItem">Código que identifica a una entidad TEMaestro</param>
        public bool Eliminar(string pCodigoItem)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLMaestrosDataContext tablaMaestroDC = new _DBMLMaestrosDataContext(conexion))
                {
                    tablaMaestroDC.omgc_D_Tabla(pCodigoItem, "Usu_" + pCodigoItem, "Maq_" + pCodigoItem);
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }


    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de Registros de las tablas maestras
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/03/2015
    /// Descripcion : Clase para capa de datos
    /// Archivo     : TablaData.cs
    /// </summary>
    public class TablaDataNx
    {
        private string conexion = String.Empty;

        /// <summary>
        /// Metodo                  :Dispose 
        /// Propósito               :Permite Liberar de la memoria al objeto instanciado
        /// Efectos                 :N/A
        /// Retorno                 :N/A
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :23/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public TablaDataNx()
        {
            conexion = Util.ConexionBD();
        }

        /// <summary>
        /// BUSCAR un registro de la Entidad Tabla por ID
        /// </summary>
        /// <param name="objFiltro"></param>
        /// <returns></returns>
        public TablaBE Buscar(string codTabla)
        {
            TablaBE objTabla = null;
            try
            {
                using (_DBMLMaestrosDataContext tablasMaestrosDC = new _DBMLMaestrosDataContext(conexion))
                {
                    var query = tablasMaestrosDC.omgc_S_Tabla(codTabla, string.Empty, null);
                    foreach (var item in query)
                    {
                        objTabla = new TablaBE()
                        {
                            codTabla = item.codTabla,
                            indNivel = item.indNivel,
                            numLongitudNivel = item.numLongitudNivel,
                            desNombre = item.desNombre,
                            gloDescripcion = item.gloDescripcion,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuCrea,
                            segUsuarioEdita = item.segUsuEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquinaOrigen,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objTabla;
        }

        /// <summary>
        /// LISTADO de la Entidad Tabla con filtro
        /// </summary>
        /// <param name="objFiltroMaestro"></param>
        /// <returns></returns>
        public List<TablaBE> Listar(BaseFiltroMaestro objFiltroMaestro)
        {
            List<TablaBE> lstTabla = new List<TablaBE>();
            try
            {
                using (_DBMLMaestrosDataContext tablasMaestrosDC = new _DBMLMaestrosDataContext(conexion))
                {
                    var query = tablasMaestrosDC.omgc_S_Tabla(objFiltroMaestro.codTabla,
                                                              objFiltroMaestro.desNombre,
                                                              objFiltroMaestro.indActivo);
                    foreach (var item in query)
                    {
                        lstTabla.Add(new TablaBE()
                        {
                            codTabla = item.codTabla,
                            indNivel = item.indNivel,
                            numLongitudNivel = item.numLongitudNivel,
                            desNombre = item.desNombre,
                            gloDescripcion = item.gloDescripcion,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuCrea,
                            segUsuarioEdita = item.segUsuEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquinaOrigen,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstTabla;
        }

        /// <summary>
        /// LISTADO de la entidad Tabla de forma paginado para JQuery
        /// </summary>
        /// <param name="pFiltroMaestro"></param>
        /// <returns></returns>
        public List<TablaBE> ListarPaginado(BaseFiltroMaestro pFiltroMaestro)
        {
            List<TablaBE> lstTabla = new List<TablaBE>();
            try
            {
                using (_DBMLMaestrosDataContext tablasMaestrosDC = new _DBMLMaestrosDataContext(conexion))
                {
                    var query = tablasMaestrosDC.omgc_S_Tabla_Paged(pFiltroMaestro.GNumPagina,
                                                                    pFiltroMaestro.GTamPagina,
                                                                    pFiltroMaestro.GOrdenPor,
                                                                    pFiltroMaestro.GOrdenTipo,
                                                                    pFiltroMaestro.codTabla,
                                                                    pFiltroMaestro.desNombre,
                                                                    pFiltroMaestro.indActivo);
                    foreach (var item in query)
                    {
                        lstTabla.Add(new TablaBE()
                        {
                            codTabla = item.codTabla,
                            indNivel = item.indNivel,
                            numLongitudNivel = item.numLongitudNivel,
                            desNombre = item.desNombre,
                            gloDescripcion = item.gloDescripcion,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuCrea,
                            segUsuarioEdita = item.segUsuEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquinaOrigen,

                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstTabla;
        }

        ///// <summary>
        ///// Listar todas las tablas que invlolucra el sistema
        ///// </summary>
        ///// <returns></returns>
        //public List<SysTablas> ListarTablasBD()
        //{
        //    List<SysTablas> lstSysTablas = new List<SysTablas>();
        //    try
        //    {
        //        using (_DBMLMaestrosDataContext SQLDC = new _DBMLMaestrosDataContext(conexion))
        //        {
        //            int i = 0;
        //            var resul = SQLDC.omgc_P_Tabla_Sys();
        //            foreach (var item in resul)
        //            {
        //                ++i;
        //                lstSysTablas.Add(new SysTablas()
        //                {
        //                    EsquemaNombreTabla = item.EsquemaNombreTabla,
        //                    NombreTabla = item.NombreTabla,
        //                    Item = i.ToString().PadLeft(3, '0')
        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstSysTablas;
        //}

    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de Registros de las tablas maestras
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/03/2015
    /// Descripcion : Clase para capa de datos
    /// Archivo     : TablaData.cs
    /// </summary>
    public class TablaDataTx
    {
        private string conexion = String.Empty;

        /// <summary>
        /// Metodo                  :Dispose 
        /// Propósito               :Permite Liberar de la memoria al objeto instanciado
        /// Efectos                 :N/A
        /// Retorno                 :N/A
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :23/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public TablaDataTx()
        {
            conexion = Util.ConexionBD();
        }

        /// <summary>
        /// Registrar una Entidad Tabla
        /// </summary>
        /// <param name="objTabla">Entidad TablaMaestra</param>
        public bool Registrar(TablaBE objTabla)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLMaestrosDataContext tablaMaestroDC = new _DBMLMaestrosDataContext(conexion))
                {
                    tablaMaestroDC.omgc_I_Tabla(objTabla.codTabla,
                                                objTabla.desNombre,
                                                objTabla.gloDescripcion,
                                                objTabla.indNivel,
                                                objTabla.numLongitudNivel,
                                                objTabla.indActivo,
                                                objTabla.segUsuarioCrea,
                                                objTabla.segMaquinaCrea);
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        /// <summary>
        /// Actualiza el registro de un objeto de tipo TEMaestro
        /// </summary>
        /// <param name="objTabla">Entidad TEMaestro</param>
        public bool Actualizar(TablaBE objTabla)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLMaestrosDataContext tablaMaestroDC = new _DBMLMaestrosDataContext(conexion))
                {
                    tablaMaestroDC.omgc_U_Tabla(objTabla.codTabla,
                                                objTabla.desNombre,
                                                objTabla.gloDescripcion,
                                                objTabla.indNivel,
                                                objTabla.numLongitudNivel,
                                                objTabla.indActivo,
                                                objTabla.segUsuarioEdita,
                                                objTabla.segMaquinaCrea);
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        /// <summary>
        /// Elimina el registro de un objeto de tipo Tabla
        /// </summary>
        /// <param name="objFiltroMaestro"></param>
        /// <returns></returns>
        public bool Eliminar(BaseFiltroMaestro objFiltroMaestro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLMaestrosDataContext tablaMaestroDC = new _DBMLMaestrosDataContext(conexion))
                {
                    tablaMaestroDC.omgc_D_Tabla(objFiltroMaestro.codTabla, objFiltroMaestro.segUsuarioEdita, objFiltroMaestro.segMaquinaOrigen);
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

    }

}

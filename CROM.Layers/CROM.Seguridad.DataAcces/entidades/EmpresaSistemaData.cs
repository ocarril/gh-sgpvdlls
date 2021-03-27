namespace CROM.Seguridad.DataAcces
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Tools.Comun.settings;

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 8/10/2019-15:55:24
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Seguridad.EmpresaSistemaData.cs]
    /// </summary>
    public class EmpresaSistemaData
    {
        private string conexion = string.Empty;

        public EmpresaSistemaData()
        {
            conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG");
        }

        #region /* Proceso de SELECT ALL */ 

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Seguridad.EmpresaSistema
        /// En la BASE de DATO la Tabla : [Seguridad.EmpresaSistema]
        /// <summary>
        /// <returns>List</returns>
        public List<BEEmpresaSistemaRespose> ListPaged(BEBuscaEmpresaSistemaRequest pFiltro)
        {
            List<BEEmpresaSistemaRespose> lstEmpresaSistema = new List<BEEmpresaSistemaRespose>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_EmpresaSistema_Paged(pFiltro.jqCurrentPage,
                                                                            pFiltro.jqPageSize,
                                                                            pFiltro.jqSortColumn,
                                                                            pFiltro.jqSortOrder,
                                                                            pFiltro.codEmpresa,
                                                                            pFiltro.codSistema,
                                                                            pFiltro.indActivo);

                    
                    foreach (var item in resul)
                    {
                        lstEmpresaSistema.Add(new BEEmpresaSistemaRespose()
                        {
                            codEmpresaSistema = item.codEmpresaSistema,
                            nomEmpresa = item.nomEmpresa,
                            nomSistema = item.nomSistema,
                            indActivo = item.indActivo,
                            fecInicio = item.fecInicio,
                            fecFinal = item.fecFinal,
                            numTiempoToken = item.numTiempoToken,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaEdita = item.segMaquinaEdita,

                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0,

                        });
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

        #region /* Proceso de SELECT BY ID CODE */ 

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Seguridad.EmpresaSistema
        /// En la BASE de DATO la Tabla : [Seguridad.EmpresaSistema]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEEmpresaSistema Find(int pcodEmpresaSistema)
        {
            BEEmpresaSistema objEntidadSistema = new BEEmpresaSistema();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_EmpresaSistema(pcodEmpresaSistema);
                    foreach (var item in resul)
                    {
                        objEntidadSistema = new BEEmpresaSistema()
                        {
                            codEmpresaSistema = item.codEmpresaSistema,
                            codEmpresa = item.codEmpresa,
                            codSistema = item.codSistema,
                            indActivo = item.indActivo,
                            fecInicio = item.fecInicio,
                            fecFinal = item.fecFinal,
                            numTiempoToken=item.numTiempoToken,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraCrea = item.segFechaCrea,
                            segFechaHoraEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquinaCrea,
                            segMaquinaEdita = item.segMaquinaEdita,
                            indEliminado = item.indEliminado,
                             
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objEntidadSistema;
        }

        public BEEmpresaSistema Find(int pcodEmpresa, string   pcodSistema)
        {
            BEEmpresaSistema objEntidadSistema = new BEEmpresaSistema();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_EmpresaSistema_Paged(1,
                                                                           100,
                                                                          "codSistemaNombre",
                                                                          "asc",
                                                                           pcodEmpresa,
                                                                           pcodSistema,
                                                                           true);
                    foreach (var item in resul)
                    {
                        objEntidadSistema = new BEEmpresaSistema()
                        {
                            codEmpresaSistema = item.codEmpresaSistema,
                            codEmpresa = item.codEmpresa,
                            codSistema = item.codSistema,
                            indActivo = item.indActivo,
                            fecInicio = item.fecInicio,
                            fecFinal = item.fecFinal,
                            numTiempoToken = item.numTiempoToken,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraEdita = item.segFechaEdita,
                            segMaquinaEdita = item.segMaquinaEdita,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objEntidadSistema;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */ 

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo EmpresaSistema
        /// En la BASE de DATO la Tabla : [Seguridad.EmpresaSistema]
        /// <summary>
        /// <param name = >itemEmpresaSistema</param>
        public bool Insert(BEEmpresaSistemaRequest pEmpresaSistema)
        {
            bool blnResult = false;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resulSet = SeguridadDC.usp_sis_C_EmpresaSistema(
                                               pEmpresaSistema.codEmpresa,
                                               pEmpresaSistema.codSistema,
                                               pEmpresaSistema.indActivo,
                                               pEmpresaSistema.fecInicio,
                                               pEmpresaSistema.fecFinal,
                                               pEmpresaSistema.numTiempoToken,
                                               pEmpresaSistema.segUsuarioEdita,
                                               pEmpresaSistema.segMaquinaEdita);

                    foreach (var item in resulSet)
                    {
                        pEmpresaSistema.codEmpresaSistema = item.codError.HasValue ? item.codError.Value : 0;
                        blnResult = item.desMessage == "OK" ? true : false;
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

        #region /* Proceso de UPDATE RECORD */ 

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo EmpresaSistema
        /// En la BASE de DATO la Tabla : [Seguridad.EmpresaSistema]
        /// <summary>
        /// <param name = >itemEmpresaSistema</param>
        public bool Update(BEEmpresaSistemaRequest pEmpresaSistema)
        {
            int codigoRetorno = -1;
            bool message = false;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resulSet = SeguridadDC.usp_sis_U_EmpresaSistema(
                        pEmpresaSistema.codEmpresaSistema,
                        pEmpresaSistema.indActivo,
                        pEmpresaSistema.fecInicio,
                        pEmpresaSistema.fecFinal,
                        pEmpresaSistema.numTiempoToken,
                        pEmpresaSistema.segUsuarioEdita,
                        pEmpresaSistema.segMaquinaEdita);

                    foreach (var item in resulSet)
                    {
                        codigoRetorno = item.codError.HasValue ? item.codError.Value : 0;
                        message = item.desMessage == "OK" ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 1  && message? true : false;
        }
        
        #endregion

        #region /* Proceso de DELETE BY ID CODE */ 

        /// <summary>
        /// ELIMINA un registro de la Entidad Seguridad.EmpresaSistema 
        /// En la BASE de DATO la Tabla : [Seguridad.EmpresaSistema]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(BEEmpresaSistemaRequest pEmpresaSistema)
        {
            bool blnResult = false;
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resulSet = SeguridadDC.usp_sis_D_EmpresaSistema(pEmpresaSistema.codEmpresaSistema,
                                                                         pEmpresaSistema.segUsuarioEdita,
                                                                         pEmpresaSistema.segMaquinaEdita);
                    foreach (var item in resulSet)
                    {
                        blnResult = item.desMessage == "OK" ? true : false;
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

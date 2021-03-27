namespace CROM.TablasMaestras.DataAcces
{
    using CROM.BusinessEntities.Maestros;

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 06/04/2014-06:27:34 p.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Maestros.ConfiguracionData.cs]
    /// </summary>
    public class ConfiguracionData
    {
        private string conexion = string.Empty;
        public ConfiguracionData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Maestros.Configuracion
        /// En la BASE de DATO la Tabla : [Maestros.Configuracion]
        /// <summary>
        /// <returns>List</returns>
        public List<BEConfiguracion> List(BaseFiltroConfiguracion pFiltroConfig)
        {
            List<BEConfiguracion> lstConfiguracion = new List<BEConfiguracion>();
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Configuracion(pFiltroConfig.codEmpresa,
                                                           pFiltroConfig.codConfiguracion,
                                                           pFiltroConfig.codKeyConfig,
                                                           pFiltroConfig.desValor,
                                                           pFiltroConfig.indActivo);
                    foreach (var item in resul)
                    {
                        lstConfiguracion.Add(new BEConfiguracion()
                        {
                            codConfiguracion = item.codConfiguracion,
                            codKeyConfig = item.codKeyConfig,
                            codTabla = item.codTabla,
                            indOrden = item.indOrden,
                            indTipoValor = item.indTipoValor,
                            desValor = item.desValor,
                            desGrupo = item.desGrupo,
                            desNombre = item.desNombre,
                            gloDescripcion = item.gloDescripcion,
                            indGenerico = item.indGenerico,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            numNivel = item.numNivel.HasValue ? item.numNivel.Value : 0
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstConfiguracion;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Maestros.Configuracion
        /// En la BASE de DATO la Tabla : [Maestros.Configuracion]
        /// <summary>
        /// <returns>List</returns>
        public List<BEConfiguracion> ListPaginado(BaseFiltroConfiguracion pFiltroConfig)
        {
            List<BEConfiguracion> lstConfiguracion = new List<BEConfiguracion>();
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Configuracion_Paged(pFiltroConfig.jqCurrentPage,
                                                                 pFiltroConfig.jqPageSize,
                                                                 pFiltroConfig.jqSortColumn,
                                                                 pFiltroConfig.jqSortOrder,
                                                                 pFiltroConfig.codEmpresa,
                                                                 pFiltroConfig.desNombre,
                                                                 pFiltroConfig.codKeyConfig,
                                                                 pFiltroConfig.codTabla,
                                                                 pFiltroConfig.desValor,
                                                                 pFiltroConfig.indActivo);
                    foreach (var item in resul)
                    {
                        lstConfiguracion.Add(new BEConfiguracion()
                        {
                            codConfiguracion = item.codConfiguracion,
                            codKeyConfig = item.codKeyConfig,
                            codTabla = item.codTabla,
                            indOrden = item.indOrden,
                            numNivel = item.numNivel.HasValue ? item.numNivel.Value : 0,
                            indTipoValor = item.indTipoValor,
                            desValor = item.desValor,
                            desNombre = item.desNombre,
                            desGrupo = item.desGrupo,
                            gloDescripcion = item.gloDescripcion,
                            indGenerico = item.indGenerico,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaEdita = item.segMaquina,

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
            return lstConfiguracion;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestros.Configuracion
        /// En la BASE de DATO la Tabla : [Maestros.Configuracion]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEConfiguracion Find(int pcodEmpresa, int pIdConfiguracion)
        {
            BEConfiguracion configuracion = null;
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Configuracion(pcodEmpresa,
                                                           pIdConfiguracion,
                                                           string.Empty,
                                                           string.Empty,
                                                           null);
                    foreach (var item in resul)
                    {
                        configuracion = new BEConfiguracion()
                        {
                            codConfiguracion = item.codConfiguracion,
                            codKeyConfig = item.codKeyConfig,
                            codTabla = item.codTabla,
                            numNivel = item.numNivel.HasValue ? item.numNivel.Value : 0,
                            indOrden = item.indOrden,
                            indTipoValor = item.indTipoValor,
                            desValor = item.desValor,
                            desNombre = item.desNombre,
                            gloDescripcion = item.gloDescripcion,
                            indGenerico = item.indGenerico,
                            desGrupo = item.desGrupo,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return configuracion;
        }

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestros.Configuracion
        /// En la BASE de DATO la Tabla : [Maestros.Configuracion]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEConfiguracion Find(int pcodEmpresa, string pcodKeyConfig)
        {
            BEConfiguracion configuracion = null;
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Configuracion(pcodEmpresa, 0, pcodKeyConfig, null, null);
                    foreach (var item in resul)
                    {
                        configuracion = new BEConfiguracion()
                        {
                            codConfiguracion = item.codConfiguracion,
                            codKeyConfig = item.codKeyConfig,
                            codTabla = item.codTabla,
                            numNivel = item.numNivel.HasValue ? item.numNivel.Value : 0,
                            indOrden = item.indOrden,
                            indTipoValor = item.indTipoValor,
                            desValor = item.desValor,
                            desNombre = item.desNombre,
                            gloDescripcion = item.gloDescripcion,
                            indGenerico = item.indGenerico,
                            desGrupo = item.desGrupo,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                        };
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return configuracion;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Configuracion
        /// En la BASE de DATO la Tabla : [Maestros.Configuracion]
        /// <summary>
        /// <param name = >itemConfiguracion</param>
        public bool Insert(BEConfiguracion configuracion)
        {
            int? codigoRetorno = -1;
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    SQLDC.omgc_I_Configuracion(
                       ref codigoRetorno,
                       configuracion.codEmpresa,
                       configuracion.codKeyConfig,
                       configuracion.codTabla,
                       configuracion.numNivel,
                       configuracion.indOrden,
                       configuracion.indTipoValor,
                       configuracion.desValor,
                       configuracion.desNombre,
                       configuracion.gloDescripcion,
                       configuracion.indGenerico,
                       configuracion.desGrupo,
                       configuracion.indActivo,
                       configuracion.segUsuarioCrea,
                       configuracion.segMaquinaCrea);

                    configuracion.codConfiguracion = codigoRetorno.Value;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return codigoRetorno != 0 ? true : false;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Configuracion
        /// En la BASE de DATO la Tabla : [Maestros.Configuracion]
        /// <summary>
        /// <param name = >itemConfiguracion</param>
        public bool Update(BEConfiguracion configuracion)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_Configuracion(
                        configuracion.codEmpresa,
                        configuracion.codConfiguracion,
                        configuracion.codKeyConfig,
                        configuracion.codTabla,
                        configuracion.numNivel,
                        configuracion.indOrden,
                        configuracion.indTipoValor,
                        configuracion.desValor,
                        configuracion.desNombre,
                        configuracion.gloDescripcion,
                        configuracion.indGenerico,
                        configuracion.desGrupo,
                        configuracion.indActivo,
                        configuracion.segUsuarioEdita);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public bool UpdateConfig(BEConfiguracion configuracion)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    SQLDC.omgc_U_ConfiguracionConfig(
                        configuracion.codEmpresa,
                        configuracion.codKeyConfig,
                        configuracion.desValor,
                        configuracion.segUsuarioEdita,
                        configuracion.segMaquinaEdita);
                    codigoRetorno = 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Maestros.Configuracion
        /// En la BASE de DATO la Tabla : [Maestros.Configuracion]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(BEConfiguracion pConfiguracion)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_Configuracion(pConfiguracion.codEmpresa,
                                                               pConfiguracion.codConfiguracion,
                                                               pConfiguracion.segUsuarioElimina);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

    }
}

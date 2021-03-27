namespace CROM.GestionAlmacen.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Almacen;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 16/08/2014-12:20:07 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Almacen.PeriodoData.cs]
    /// </summary>
    public class PeriodoData
    {
        private string conexion = string.Empty;

        public PeriodoData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Periodo
        /// En la BASE de DATO la Tabla : [Almacen.Periodo]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEPeriodo> List(BaseFiltroPeriodo pFiltro)
        {
            List<BEPeriodo> lstPeriodo = new List<BEPeriodo>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Periodo(pFiltro.codEmpresa,
                                                     pFiltro.desNombre,
                                                     pFiltro.perPeriodo,
                                                     pFiltro.indEstado);
                    foreach (var item in resul)
                    {
                        lstPeriodo.Add(new BEPeriodo()
                        {
                            codPeriodo = item.codPeriodo,
                            desNombre = item.desNombre,
                            indModalidad = item.indModalidad,
                            fecInicio = item.fecInicio,
                            fecApertura = item.fecApertura,
                            fecCierre = item.fecCierre,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,

                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstPeriodo;
        }
       
        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.Periodo
        /// En la BASE de DATO la Tabla : [Almacen.Periodo]
        /// </summary>
        /// <param name="prm_codPeriodo"></param>
        /// <returns></returns>
        public BEPeriodo Find(int pcodEmpresa, string prm_codPeriodo)
        {
            BEPeriodo objPeriodo = new BEPeriodo();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Periodo(pcodEmpresa, string.Empty, prm_codPeriodo, true);
                    foreach (var item in resul)
                    {
                        objPeriodo = new BEPeriodo()
                        {
                            codPeriodo = item.codPeriodo,
                            desNombre = item.desNombre,
                            indModalidad = item.indModalidad,
                            fecInicio = item.fecInicio,
                            fecApertura = item.fecApertura,
                            fecCierre = item.fecCierre,
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
            return objPeriodo;
        }

        #endregion

        #region /* Proceso de INSERT */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Periodo
        /// En la BASE de DATO la Tabla : [Almacen.Periodo]
        /// <summary>
        /// <param name = >periodo</param>
        public bool Insert(BEPeriodo periodo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    SQLDC.omgc_I_Periodo(
                      periodo.codEmpresa,
                      periodo.codPeriodo,
                      periodo.desNombre,
                      periodo.indModalidad,
                      periodo.fecInicio,
                      periodo.indActivo,
                      periodo.segUsuarioCrea,
                      periodo.segMaquinaCrea
                      );
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de UPDATE */

        /// <summary>
        /// Actualiza el registro de una ENTIDAD de registro de Tipo Periodo
        /// En la BASE de DATO la Tabla : [Almacen.Periodo]
        /// </summary>
        /// <param name="pPeriodo"></param>
        /// <returns></returns>
        public bool Update(BEPeriodo pPeriodo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    SQLDC.omgc_U_Periodo(
                        pPeriodo.codEmpresa,
                        pPeriodo.codPeriodo,
                        pPeriodo.desNombre,
                        pPeriodo.indModalidad,
                        pPeriodo.fecInicio,
                        pPeriodo.indActivo,
                        pPeriodo.segUsuarioEdita,
                        pPeriodo.segMaquinaEdita
                        );
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
        /// Realiza la apertura de periodo de inventario
        /// </summary>
        /// <param name="pPeriodo"></param>
        /// <returns></returns>
        public bool UpdateApertura(BEPeriodo pPeriodo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    SQLDC.omgc_U_Periodo_Aperturar(
                        pPeriodo.codEmpresa,
                        pPeriodo.codPeriodo,
                        pPeriodo.fecApertura,
                        pPeriodo.segUsuarioEdita,
                        pPeriodo.segMaquinaEdita
                        );
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
        /// Realiza el cierre de periodo de inventario
        /// </summary>
        /// <param name="pPeriodo"></param>
        /// <returns></returns>
        public bool UpdateCierre(BEPeriodo pPeriodo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    SQLDC.omgc_U_Periodo_Cierre(
                        pPeriodo.codEmpresa,
                        pPeriodo.codPeriodo,
                        pPeriodo.fecCierre,
                        pPeriodo.segUsuarioEdita,
                        pPeriodo.segMaquinaEdita
                        );
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de DELETE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.Periodo
        /// En la BASE de DATO la Tabla : [Almacen.Periodo]
        /// </summary>
        /// <param name="pcodPeriodo"></param>
        /// <returns></returns>
        public bool Delete(int pcodEmpresa, string pcodPeriodo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    SQLDC.omgc_D_Periodo(pcodEmpresa, pcodPeriodo);
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

    }
} 

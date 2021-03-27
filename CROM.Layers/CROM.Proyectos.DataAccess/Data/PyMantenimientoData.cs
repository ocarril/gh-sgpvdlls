namespace CROM.Proyectos.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Proyectos;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 15/09/2015-02:06:46 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Proyectos.PyMantenimientoData.cs]
    /// </summary>
    public class PyMantenimientoDataNx
    {
        private string conexion = string.Empty;

        public PyMantenimientoDataNx()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.PyMantenimiento
        /// En la BASE de DATO la Tabla : [Proyectos.PyMantenimiento]
        /// <summary>
        /// <param name="objFiltro"></param>
        /// <returns></returns>
        public List<DTOMantenimiento> Listar(BaseFiltroPry objFiltro)
        {
            List<DTOMantenimiento> lstPyMantenimiento = new List<DTOMantenimiento>();
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PyMantenimiento(0,
                                                             objFiltro.codProyecto,
                                                             objFiltro.codPyEquipo,
                                                             objFiltro.codDocumEstado,
                                                             objFiltro.codEmpleadoResp,
                                                             objFiltro.fecInicio,
                                                             objFiltro.fecFinal,
                                                             objFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lstPyMantenimiento.Add(new DTOMantenimiento()
                        {
                            codPyMantenimiento = item.codPyMantenimiento,
                            codProyecto = item.codProyecto,
                            fecProgramada = item.fecProgramada,
                            fecRealizada = item.fecRealizada,
                            codDocumEstado = item.codDocumEstado,
                            gloObservacion = item.gloObservacion,
                            codPyEquipo = item.codPyEquipo,
                            codEmpleadoResp = item.codEmpleadoResp,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquina = item.segMaquina,

                            desCliente = item.codPerClienteNombre,
                            desEstado = item.codDocumEstadoNombre,
                            desProducto = item.codProductoNombre,
                            desProyecto = item.codProyectoNombre,
                            fecCompra = item.fecCompra.Value.ToShortDateString(),
                            fecVencGarantia = item.fecVencGarantia.Value.ToShortDateString(),
                            indSeriado = item.indSeriado

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPyMantenimiento;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.PyMantenimiento
        /// En la BASE de DATO la Tabla : [Proyectos.PyMantenimiento]
        /// <summary>
        /// <param name="objFiltro"></param>
        /// <returns></returns>
        public List<DTOMantenimiento> ListarPaginado(BaseFiltroPry objFiltro)
        {
            List<DTOMantenimiento> lstPyMantenimiento = new List<DTOMantenimiento>();
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PyMantenimiento_Paged(objFiltro.grcurrentPage,
                                                                   objFiltro.grpageSize,
                                                                   objFiltro.grsortColumn,
                                                                   objFiltro.grsortOrder,
                                                                   0,
                                                                   objFiltro.codProyecto,
                                                                   objFiltro.codPyEquipo,
                                                                   objFiltro.codDocumEstado,
                                                                   objFiltro.codEmpleadoResp,
                                                                   objFiltro.fecInicio,
                                                                   objFiltro.fecFinal,
                                                                   objFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lstPyMantenimiento.Add(new DTOMantenimiento()
                        {
                            ROW = item.ROWNUM.Value,
                            TOTALROWS = item.TOTALROWS.Value,

                            codPyMantenimiento = item.codPyMantenimiento,
                            codProyecto = item.codProyecto,
                            fecProgramada = item.fecProgramada,
                            fecRealizada = item.fecRealizada,
                            codDocumEstado = item.codDocumEstado,
                            gloObservacion = item.gloObservacion,
                            codPyEquipo = item.codPyEquipo,
                            codEmpleadoResp = item.codEmpleadoResp,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquina = item.segMaquina,

                            desCliente = item.codPerClienteNombre,
                            desEstado = item.codDocumEstadoNombre,
                            desProducto = item.codProductoNombre,
                            desProyecto = item.codProyectoNombre,
                            fecCompra = item.fecCompra.HasValue? item.fecCompra.Value.ToShortDateString():string.Empty,
                            fecVencGarantia = item.fecVencGarantia.HasValue ? item.fecVencGarantia.Value.ToShortDateString() : string.Empty,
                            indSeriado = item.indSeriado
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPyMantenimiento;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Proyectos.PyMantenimiento
        /// En la BASE de DATO la Tabla : [Proyectos.PyMantenimiento]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEPyMantenimiento Buscar(int codPyMantenimiento)
        {
            BEPyMantenimiento objPyMantenimiento = null;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PyMantenimiento(codPyMantenimiento, 0, 0, 0, 0, null, null, null);
                    foreach (var item in resul)
                    {
                        objPyMantenimiento = new BEPyMantenimiento()
                        {
                            codPyMantenimiento = item.codPyMantenimiento,
                            codProyecto = item.codProyecto,
                            fecProgramada = item.fecProgramada,
                            fecRealizada = item.fecRealizada,
                            codDocumEstado = item.codDocumEstado,
                            gloObservacion = item.gloObservacion,
                            codPyEquipo = item.codPyEquipo,
                            codEmpleadoResp = item.codEmpleadoResp,
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
            return objPyMantenimiento;
        }

        #endregion

    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 15/09/2015-02:06:46 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Proyectos.PyMantenimientoData.cs]
    /// </summary>
    public class PyMantenimientoDataTx
    {
        private string conexion = string.Empty;

        public PyMantenimientoDataTx()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PyMantenimiento
        /// En la BASE de DATO la Tabla : [Proyectos.PyMantenimiento]
        /// <summary>
        /// <param name="objPyMantenimiento"></param>
        /// <returns></returns>
        public bool Registrar(BEPyMantenimiento objPyMantenimiento)
        {
            int? codigoRetorno = -1;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                     SQLDC.omgc_I_PyMantenimiento(
                        ref codigoRetorno,
                        objPyMantenimiento.codProyecto,
                        objPyMantenimiento.fecProgramada,
                        objPyMantenimiento.fecRealizada,
                        objPyMantenimiento.codDocumEstado,
                        objPyMantenimiento.gloObservacion,
                        objPyMantenimiento.codPyEquipo,
                        objPyMantenimiento.codEmpleadoResp,
                        objPyMantenimiento.indActivo,
                        objPyMantenimiento.segUsuarioEdita,
                        objPyMantenimiento.segMaquinaCrea);
                    objPyMantenimiento.codPyMantenimiento = codigoRetorno.HasValue ? codigoRetorno.Value : 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno > 0 ? true : false;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PyMantenimiento
        /// En la BASE de DATO la Tabla : [Proyectos.PyMantenimiento]
        /// <summary>
        /// <param name="objPyMantenimiento"></param>
        /// <returns></returns>
        public bool Actualizar(BEPyMantenimiento objPyMantenimiento)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    SQLDC.omgc_U_PyMantenimiento(
                        objPyMantenimiento.codPyMantenimiento,
                        objPyMantenimiento.codProyecto,
                        objPyMantenimiento.fecProgramada,
                        objPyMantenimiento.fecRealizada,
                        objPyMantenimiento.codDocumEstado,
                        objPyMantenimiento.gloObservacion,
                        objPyMantenimiento.codPyEquipo,
                        objPyMantenimiento.codEmpleadoResp,
                        objPyMantenimiento.indActivo,
                        objPyMantenimiento.segUsuarioEdita,
                        objPyMantenimiento.segMaquinaCrea);
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

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Proyectos.PyMantenimiento
        /// En la BASE de DATO la Tabla : [Proyectos.PyMantenimiento]
        /// <summary>
        /// <param name="objPyMantenimiento"></param>
        /// <returns></returns>
        public bool Eliminar(BEPyMantenimiento objPyMantenimiento)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_PyMantenimiento(objPyMantenimiento.codPyMantenimiento,
                                                                 objPyMantenimiento.segUsuarioEdita,
                                                                 objPyMantenimiento.segMaquinaCrea);
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

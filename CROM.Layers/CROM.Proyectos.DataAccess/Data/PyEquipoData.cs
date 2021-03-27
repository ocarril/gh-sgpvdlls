namespace CROM.Proyectos.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Proyectos;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 15/09/2015-02:06:46 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Proyectos.PyEquipoData.cs]
    /// </summary>
    public class PyEquipoDataNx
    {
        private string conexion = string.Empty;

        public PyEquipoDataNx()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.PyEquipo
        /// En la BASE de DATO la Tabla : [Proyectos.PyEquipo]
        /// <summary>
        /// <param name="objFiltro"></param>
        /// <returns></returns>
        public List<DTOEquipo> Listar(BaseFiltroPry objFiltro)
        {
            List<DTOEquipo> lstPyEquipo = new List<DTOEquipo>();
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PyEquipo(objFiltro.codPyEquipo,
                                                      objFiltro.codProyecto,
                                                      objFiltro.codPyDocumReg,
                                                      objFiltro.codDocumRegDetalle,
                                                      objFiltro.fecInicio,
                                                      objFiltro.fecFinal,
                                                      objFiltro.fecInicioGarantia,
                                                      objFiltro.fecFinalGarantia,
                                                      objFiltro.codDocumEstado,
                                                      objFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lstPyEquipo.Add(new DTOEquipo()
                        {

                            codPyEquipo = item.codPyEquipo,
                            codPyDocumReg = item.codPyDocumReg,
                            codDocumRegDetalle = item.codDocumRegDetalle,
                            fecCompra = item.fecCompra,
                            fecInstalacion = item.fecInstalacion,
                            fecVencGarantia = item.fecVencGarantia,
                            codDocumEstado = item.codDocumEstado,
                            gloNota = item.gloNota,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquina = item.segMaquina,

                            cntCantidad = item.cntCantidad,
                            desProducto = item.codProductoNombre,
                            indSeriado = item.indSeriado,
                            desEstado = item.codDocumEstadoNombre,
                            monPrecioVenta = item.monPrecioVenta.HasValue ? item.monPrecioVenta.Value : 0
                       

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPyEquipo;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.PyEquipo
        /// En la BASE de DATO la Tabla : [Proyectos.PyEquipo]
        /// <summary>
        /// <param name="objFiltro"></param>
        /// <returns></returns>
        public List<DTOEquipo> ListarPaginado(BaseFiltroPry objFiltro)
        {
            List<DTOEquipo> lstPyEquipo = new List<DTOEquipo>();
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PyEquipo_Paged(objFiltro.grcurrentPage,
                                                            objFiltro.grpageSize,
                                                            objFiltro.grsortColumn,
                                                            objFiltro.grsortOrder,
                                                            objFiltro.codProyecto,
                                                            objFiltro.codPyDocumReg,
                                                            objFiltro.codDocumRegDetalle,
                                                            objFiltro.fecInicio,
                                                            objFiltro.fecFinal,
                                                            objFiltro.fecInicioGarantia,
                                                            objFiltro.fecFinalGarantia,
                                                            objFiltro.codDocumEstado,
                                                            objFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lstPyEquipo.Add(new DTOEquipo()
                        {
                            ROW = item.ROWNUM.Value,
                            TOTALROWS = item.TOTALROWS.Value,
                            codPyEquipo = item.codPyEquipo,
                            codPyDocumReg = item.codPyDocumReg,
                            codDocumRegDetalle = item.codDocumRegDetalle,
                            fecCompra = item.fecCompra,
                            fecInstalacion = item.fecInstalacion,
                            fecVencGarantia = item.fecVencGarantia,
                            codDocumEstado = item.codDocumEstado,
                            gloNota = item.gloNota,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquina = item.segMaquina,

                            cntCantidad = item.cntCantidad,
                            desProducto = item.codProductoNombre,
                            indSeriado = item.indSeriado,
                            desEstado = item.codDocumEstadoNombre,
                            monPrecioVenta = item.monPrecioVenta.HasValue ? item.monPrecioVenta.Value : 0
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPyEquipo;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Proyectos.PyEquipo
        /// En la BASE de DATO la Tabla : [Proyectos.PyEquipo]
        /// <summary>
        /// <param name="codPyEquipo"></param>
        /// <returns></returns>
        public BEPyEquipo Buscar(int codPyEquipo)
        {
            BEPyEquipo objPyEquipo = null;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PyEquipo(codPyEquipo, 
                                                      0, 0, 0, null, null, null, null, 0, null);
                    foreach (var item in resul)
                    {
                        objPyEquipo = new BEPyEquipo()
                        {
                            codPyEquipo = item.codPyEquipo,
                            codPyDocumReg = item.codPyDocumReg,
                            codDocumRegDetalle = item.codDocumRegDetalle,
                            fecCompra = item.fecCompra,
                            fecInstalacion = item.fecInstalacion,
                            fecVencGarantia = item.fecVencGarantia,
                            codDocumEstado = item.codDocumEstado,
                            gloNota = item.gloNota,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            codDocumReg = item.codDocumReg
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objPyEquipo;
        }

        #endregion

    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 15/09/2015-02:06:46 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Proyectos.PyEquipoData.cs]
    /// </summary>
    public class PyEquipoDataTx
    {
        private string conexion = string.Empty;

        public PyEquipoDataTx()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PyEquipo
        /// En la BASE de DATO la Tabla : [Proyectos.PyEquipo]
        /// <summary>
        /// <param name="objPyEquipo"></param>
        /// <returns></returns>
        public bool Registrar(BEPyEquipo objPyEquipo)
        {
            int? codigoRetorno = -1;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    SQLDC.omgc_I_PyEquipo(
                        ref codigoRetorno,
                        objPyEquipo.codDocumReg,
                        objPyEquipo.codDocumRegDetalle,
                        objPyEquipo.fecCompra,
                        objPyEquipo.fecInstalacion,
                        objPyEquipo.fecVencGarantia,
                        objPyEquipo.codDocumEstado,
                        objPyEquipo.gloNota,
                        objPyEquipo.indActivo,
                        objPyEquipo.segUsuarioCrea,
                        objPyEquipo.segMaquinaCrea);
                    objPyEquipo.codPyEquipo = codigoRetorno.HasValue ? codigoRetorno.Value : 0;
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo PyEquipo
        /// En la BASE de DATO la Tabla : [Proyectos.PyEquipo]
        /// <summary>
        /// <param name="objPyEquipo"></param>
        /// <returns></returns>
        public bool Actualizar(BEPyEquipo objPyEquipo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    SQLDC.omgc_U_PyEquipo(
                       objPyEquipo.codPyEquipo,
                       objPyEquipo.codPyDocumReg,
                       objPyEquipo.codDocumRegDetalle,
                       objPyEquipo.fecCompra,
                       objPyEquipo.fecInstalacion,
                       objPyEquipo.fecVencGarantia,
                       objPyEquipo.codDocumEstado,
                       objPyEquipo.gloNota,
                       objPyEquipo.indActivo,
                       objPyEquipo.segUsuarioEdita,
                       objPyEquipo.segMaquinaCrea);
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
        /// ELIMINA un registro de la Entidad Proyectos.PyEquipo
        /// En la BASE de DATO la Tabla : [Proyectos.PyEquipo]
        /// <summary>
        /// <param name="objPyEquipo"></param>
        /// <returns></returns>
        public bool Eliminar(BEPyEquipo objPyEquipo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_PyEquipo(objPyEquipo.codPyEquipo,
                                                          objPyEquipo.segUsuarioEdita,
                                                          objPyEquipo.segMaquinaCrea);
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

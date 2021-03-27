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
    /// Archivo     : [Proyectos.PyDocumRegData.cs]
    /// </summary>
    public class PyDocumRegDataNx
    {
        private string conexion = string.Empty;

        public PyDocumRegDataNx()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.PyDocumReg
        /// En la BASE de DATO la Tabla : [Proyectos.PyDocumReg]
        /// <summary>
        /// <param name="objfiltro"></param>
        /// <returns></returns>
        public List<BEPyDocumReg> Listar(BaseFiltroPry objFiltro)
        {
            List<BEPyDocumReg> lstPyDocumReg = new List<BEPyDocumReg>();
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PyDocumReg(0,
                                                        objFiltro.codProyecto,
                                                        objFiltro.codDocumRegDetalle,
                                                        objFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lstPyDocumReg.Add(new BEPyDocumReg()
                        {
                            codPyDocumReg = item.codPyDocumReg,
                            codProyecto = item.codProyecto,
                            codDocumReg = item.codDocumReg,
                            gloNota = item.gloNota,
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
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPyDocumReg;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.PyDocumReg
        /// En la BASE de DATO la Tabla : [Proyectos.PyDocumReg]
        /// <summary>
        /// <param name="objfiltro"></param>
        /// <returns></returns>
        public List<DTODocumReg> ListarPaginado(BaseFiltroPry objFiltro)
        {
            List<DTODocumReg> lstPyDocumReg = new List<DTODocumReg>();
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PyDocumReg_Paged(objFiltro.grcurrentPage,
                                                              objFiltro.grpageSize,
                                                              objFiltro.grsortColumn,
                                                              objFiltro.grsortOrder,
                                                              0,
                                                              objFiltro.codProyecto,
                                                              objFiltro.codDocumRegDetalle,
                                                              objFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lstPyDocumReg.Add(new DTODocumReg()
                        {
                            codPyDocumReg = item.codPyDocumReg,
                            codProyecto = item.codProyecto,
                            codDocumReg = item.codDocumReg,
                            gloNota = item.gloNota,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea.ToString(),
                            segFechaEdita = item.segFechaEdita == null ? string.Empty : item.segFechaEdita.Value.ToString(),
                            segMaquina = item.segMaquina,

                            codDocumEstado = item.codDocumEstado,
                            desMoneda = item.desMoneda,
                            fecEmision = item.fecEmision.ToString(),
                            monTCVenta = item.monTCVenta,
                            monTotal = item.monTotal,
                            numDocumento = item.numDocumento,
                            ROW = item.ROWNUM.Value,
                            TOTALROWS = item.TOTALROWS.Value
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPyDocumReg;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Proyectos.PyDocumReg
        /// En la BASE de DATO la Tabla : [Proyectos.PyDocumReg]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEPyDocumReg Buscar(int codPyDocumReg)
        {
            BEPyDocumReg objPyDocumReg = null;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PyDocumReg(codPyDocumReg, 0, 0, null);
                    foreach (var item in resul)
                    {
                        objPyDocumReg = new BEPyDocumReg()
                        {
                            codPyDocumReg = item.codPyDocumReg,
                            codProyecto = item.codProyecto,
                            codDocumReg = item.codDocumReg,
                            gloNota = item.gloNota,
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
            return objPyDocumReg;
        }

        #endregion

    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 15/09/2015-02:06:46 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Proyectos.PyDocumRegData.cs]
    /// </summary>
    public class PyDocumRegDataTx
    {
        private string conexion = string.Empty;

        public PyDocumRegDataTx()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PyDocumReg
        /// En la BASE de DATO la Tabla : [Proyectos.PyDocumReg]
        /// <summary>
        /// <param name="objPyDocumReg"></param>
        /// <returns></returns>
        public bool Registrar(BEPyDocumReg objPyDocumReg)
        {
            int? codigoRetorno = -1;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    SQLDC.omgc_I_PyDocumReg(
                      ref codigoRetorno,
                      objPyDocumReg.codProyecto,
                      objPyDocumReg.codDocumReg,
                      objPyDocumReg.gloNota,
                      objPyDocumReg.indActivo,
                      objPyDocumReg.segUsuarioCrea,
                      objPyDocumReg.segMaquinaCrea);
                    objPyDocumReg.codPyDocumReg = codigoRetorno.HasValue ? codigoRetorno.Value : 0;
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo PyDocumReg
        /// En la BASE de DATO la Tabla : [Proyectos.PyDocumReg]
        /// <summary>
        /// <param name="objPyDocumReg"></param>
        /// <returns></returns>
        public bool Actualizar(BEPyDocumReg objPyDocumReg)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    SQLDC.omgc_U_PyDocumReg(
                        objPyDocumReg.codPyDocumReg,
                        objPyDocumReg.gloNota,
                        objPyDocumReg.indActivo,
                        objPyDocumReg.segUsuarioEdita,
                        objPyDocumReg.segMaquinaCrea);
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
        /// ELIMINA un registro de la Entidad Proyectos.PyDocumReg
        /// En la BASE de DATO la Tabla : [Proyectos.PyDocumReg]
        /// <summary>
        /// <param name="objPyDocumReg"></param>
        /// <returns></returns>
        public bool Eliminar(BEPyDocumReg objPyDocumReg)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    SQLDC.omgc_D_PyDocumReg(objPyDocumReg.codPyDocumReg,
                                                            objPyDocumReg.segUsuarioEdita,
                                                            objPyDocumReg.segMaquinaCrea);
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
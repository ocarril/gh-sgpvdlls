namespace CROM.Proyectos.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Proyectos;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 10/12/2014-02:14:05 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Proyectos.ProyectoData.cs]
    /// </summary>
    public class ProyectoDataNx
    {
        private string conexion = string.Empty;
    
        public ProyectoDataNx()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.Proyecto
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEProyecto> Listar(BaseFiltroPry pFiltro)
        {
            List<BEProyecto> lstProyecto = new List<BEProyecto>();
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Proyecto(null, pFiltro.codPersonaEntidad, pFiltro.codRegEstado, pFiltro.desNombre);
                    foreach (var item in resul)
                    {
                        lstProyecto.Add(new BEProyecto()
                        {
                            codProyecto = item.codProyecto,
                            codPerCliente = item.codPerCliente,
                            codRegEstado = item.codRegEstado,
                            desNombre = item.desNombre,
                            fecInicio = item.fecInicio,
                            fecFinal = item.fecFinal,
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
            return lstProyecto;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.Proyecto
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTOProyecto> ListarPaginado(BaseFiltroPry pFiltro)
        {
            List<DTOProyecto> lstProyecto = new List<DTOProyecto>();
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Proyecto_Paged(pFiltro.grcurrentPage,
                                                            pFiltro.grpageSize,
                                                            pFiltro.grsortOrder,
                                                            pFiltro.grsortOrder, 
                                                            pFiltro.codPersonaEntidad, 
                                                            pFiltro.codDocumEstado, 
                                                            pFiltro.desNombre,
                                                            pFiltro.fecInicio,
                                                            pFiltro.fecFinal,
                                                            pFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lstProyecto.Add(new DTOProyecto()
                        {
                            codProyecto = item.codProyecto,
                            codPerCliente = item.codPerCliente,
                            codRegEstado = item.codRegEstado,
                            desNombre = item.desNombre,
                            fecInicio = item.fecInicio,
                            fecFinal = item.fecFinal,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquina = item.segMaquina,

                            desEstado = item.codRegEstadoNombre,
                            desNombreCliente = item.codProyectoCliente,
                            TOTALROWS = item.TOTALROWS == null ? 0 : item.TOTALROWS.Value,
                            ROW = item.ROWNUM.HasValue ? Convert.ToInt32(item.ROWNUM.Value) : 0

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProyecto;
        }

        /// <summary>
        /// Retorna un LISTA de registros de los documentos emitidos
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoMovCabecera]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTODocumReg> ListarDocumentosEmitidos(BaseFiltroPry pFiltro)
        {
            List<DTODocumReg> lstDocumReg = new List<DTODocumReg>();
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumReg_codCliente(pFiltro.codProyecto);
                    foreach (var item in resul)
                    {
                        lstDocumReg.Add(new DTODocumReg()
                        {
                            codDocumReg = item.codDocumReg,
                            desMonDocumento = item.desmonDocumento

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDocumReg;
        }

        /// <summary>
        /// Retorna un LISTA de registros de los detalles de los documentos emitidos
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoMovDetalle]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTODocumReg> ListarDocumentoDetalle(BaseFiltroPry pFiltro)
        {
            List<DTODocumReg> lstDocumRegDetalle = new List<DTODocumReg>();
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumRegDetalle_codProyecto(pFiltro.codProyecto, pFiltro.codDocumReg);
                    foreach (var item in resul)
                    {
                        lstDocumRegDetalle.Add(new DTODocumReg()
                        {
                            codDocumRegDetalle = item.codDocumRegDetalle,
                            desProducto = item.desProducto,
                            cntCantidad = item.cntCantidad,
                            monPrecioVenta = item.monPrecioVenta.HasValue ? item.monPrecioVenta.Value : 0,
                            indSeriado = item.indSeriado
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDocumRegDetalle;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Proyectos.Proyecto
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        /// <param name="pcodProyecto"></param>
        /// <returns></returns>
        public BEProyecto Buscar(int pcodProyecto)
        {
            BEProyecto proyecto = new BEProyecto();
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Proyecto(pcodProyecto, null, null, null);
                    foreach (var item in resul)
                    {
                        proyecto = new BEProyecto()
                        {
                            codProyecto = item.codProyecto,
                            codPerCliente = item.codPerCliente,
                            codRegEstado = item.codRegEstado,
                            desNombre = item.desNombre,
                            fecInicio = item.fecInicio,
                            fecFinal = item.fecFinal,
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
            return proyecto;
        }

        #endregion

    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 10/12/2014-02:14:05 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Proyectos.ProyectoData.cs]
    /// </summary>
    public class ProyectoDataTx
    {
        private string conexion = string.Empty;
       
        public ProyectoDataTx()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Proyecto
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        public bool Registrar(BEProyecto objProyecto)
        {
            int? codigoRetorno = -1;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    SQLDC.omgc_I_Proyecto(
                         ref codigoRetorno,
                        objProyecto.codPerCliente,
                        objProyecto.codRegEstado,
                        objProyecto.desNombre,
                        objProyecto.fecInicio,
                        objProyecto.fecFinal,
                        objProyecto.indActivo,
                        objProyecto.segUsuarioCrea);
                    objProyecto.codProyecto = codigoRetorno.HasValue ? codigoRetorno.Value : 0;
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Proyecto
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        /// <param name="proyecto"></param>
        /// <returns></returns>
        public bool Actualizar(BEProyecto proyecto)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    SQLDC.omgc_U_Proyecto(
                       proyecto.codProyecto,
                       proyecto.codPerCliente,
                       proyecto.codRegEstado,
                       proyecto.desNombre,
                       proyecto.fecInicio,
                       proyecto.fecFinal,
                       proyecto.indActivo,
                       proyecto.segUsuarioEdita
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

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Proyectos.Proyecto
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        /// <param name="objProyecto"></param>
        /// <returns></returns>
        public bool Eliminar(BEProyecto objProyecto)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_Proyecto(objProyecto.codProyecto,
                                                          objProyecto.segUsuarioEdita,
                                                          objProyecto.segMaquinaCrea);
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

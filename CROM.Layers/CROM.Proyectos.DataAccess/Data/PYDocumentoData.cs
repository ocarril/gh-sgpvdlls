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
    /// Archivo     : [Proyectos.PYDocumentoData.cs]
    /// </summary>
    public class PYDocumentoDataNx
    {
        private string conexion = string.Empty;

        public PYDocumentoDataNx()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.PYDocumento
        /// En la BASE de DATO la Tabla : [Proyectos.PYDocumento]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTODocumentoPry> Listar(BaseFiltroPry pFiltro)
        {
            List<DTODocumentoPry> lstDocumento = new List<DTODocumentoPry>();
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PYDocumento(pFiltro.grcurrentPage, 
                                                        pFiltro.grpageSize,
                                                        pFiltro.grsortOrder,
                                                        null, 
                                                        pFiltro.codProyecto, 
                                                        pFiltro.desNombre, 
                                                        pFiltro.desNombreArchivo, 
                                                        pFiltro.desGlosa);
                    foreach (var item in resul)
                    {
                        DTODocumentoPry pyDocumento = new DTODocumentoPry();
                        pyDocumento.codPYDocumento = item.codPYDocumento; 
                        pyDocumento.codProyecto = item.codProyecto;
                        pyDocumento.desNombreArchivo = item.desNombreArchivo;
                        pyDocumento.desGlosa = item.desGlosa;
                        pyDocumento.indActivo = item.indActivo;
                        pyDocumento.segUsuarioEdita = item.segUsuarioCrea;
                        pyDocumento.segFechaEdita = item.segFechaCrea;

                        pyDocumento.desEstado = item.codRegEstadoNombre;
                        pyDocumento.desNombreCliente = item.codProyectoCliente;
                        pyDocumento.desNombreProyecto = item.codProyectoNombre;

                        pyDocumento.TOTALROWS = item.TOTALROWS == null ? 0 : item.TOTALROWS.Value;
                        pyDocumento.ROW = item.ROWNUM.HasValue?Convert.ToInt32(item.ROWNUM.Value):0;
                        pyDocumento.auxVistaParcial = item.desVistaParcial;
                        lstDocumento.Add(pyDocumento);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDocumento;
        }
       
        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Proyectos.PYDocumento
        /// En la BASE de DATO la Tabla : [Proyectos.PYDocumento]
        /// <summary>
        /// <param name="pcodPYDocumento"></param>
        /// <returns></returns>
        public BEPYDocumento Buscar(int pcodPYDocumento)
        {
            BEPYDocumento pyDocumento = new BEPYDocumento();
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PYDocumento(1, 1, "", pcodPYDocumento, null, null, null, null);
                    foreach (var item in resul)
                    {
                        pyDocumento.codPYDocumento = item.codPYDocumento; 
                        pyDocumento.codProyecto = item.codProyecto;
                        pyDocumento.desNombreArchivo = item.desNombreArchivo;
                        pyDocumento.desGlosa = item.desGlosa;
                        pyDocumento.indActivo = item.indActivo;
                        pyDocumento.segUsuarioCrea = item.segUsuarioCrea;
                        pyDocumento.segUsuarioEdita = item.segUsuarioEdita;
                        pyDocumento.segFechaCrea = item.segFechaCrea;
                        pyDocumento.segFechaEdita = item.segFechaEdita;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pyDocumento;
        }
       
        #endregion

    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 10/12/2014-02:14:05 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Proyectos.PYDocumentoData.cs]
    /// </summary>
    public class PYDocumentoDataTx
    {
        private string conexion = string.Empty;

        public PYDocumentoDataTx()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PYDocumento
        /// En la BASE de DATO la Tabla : [Proyectos.PYDocumento]
        /// <summary>
        /// <param name="pydocumento"></param>
        /// <returns></returns>
        public bool Registrar(BEPYDocumento pydocumento)
        {
            int? codigoRetorno = -1;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    SQLDC.omgc_I_PYDocumento(
                      ref codigoRetorno,
                      pydocumento.codProyecto,
                      pydocumento.desNombreArchivo,
                      pydocumento.desGlosa,
                      pydocumento.segUsuarioCrea,
                      pydocumento.segFechaCrea,
                      pydocumento.segMaquinaCrea);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo PYDocumento
        /// En la BASE de DATO la Tabla : [Proyectos.PYDocumento]
        /// <summary>
        /// <param name="pydocumento"></param>
        /// <returns></returns>
        public bool Actualizar(BEPYDocumento pydocumento)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    SQLDC.omgc_U_PYDocumento(
                        pydocumento.codPYDocumento,
                        pydocumento.codProyecto,
                        pydocumento.desNombreArchivo,
                        pydocumento.desGlosa,
                        pydocumento.indActivo,
                        pydocumento.segUsuarioEdita,
                        pydocumento.segFechaCrea
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
        /// ELIMINA un registro de la Entidad Proyectos.PYDocumento
        /// En la BASE de DATO la Tabla : [Proyectos.PYDocumento]
        /// <summary>
        /// <param name="pcodPYDocumento"></param>
        /// <returns></returns>
        public bool Eliminar(int pcodPYDocumento)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ProyectoDataContext SQLDC = new _ProyectoDataContext(conexion))
                {
                    SQLDC.omgc_D_PYDocumento(pcodPYDocumento);
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

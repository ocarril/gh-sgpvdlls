namespace CROM.GestionComercial.DataAccess
{
    using CROM.BusinessEntities.Comercial;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.DocumentoSerieData.cs]
    /// </summary>
    public class DocumentoSerieData
    {
        private string conexion = string.Empty;

        public DocumentoSerieData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ComprobantesSeries
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesSeries]
        /// <summary>
        /// <param name="objDocumentoSerie"></param>
        /// <returns></returns>
        public DTOResponseProcedure Insert(BEDocumentoSerie objDocumentoSerie)
        {
            DTOResponseProcedure codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var result = SQLDC.omgc_I_DocumentoSerie(
                            objDocumentoSerie.CodigoPersonaEmpre,
                            objDocumentoSerie.CodigoComprobante,
                            objDocumentoSerie.Descripcion,
                            objDocumentoSerie.CodigoPuntoVenta,
                            objDocumentoSerie.NombreReporte,
                            objDocumentoSerie.NumeroSerie,
                            objDocumentoSerie.NumeroInicio,
                            objDocumentoSerie.NumeroFinal,
                            objDocumentoSerie.UltimoEmitido,
                            objDocumentoSerie.Estado,
                            objDocumentoSerie.segUsuarioCrea,
                            objDocumentoSerie.segMaquinaCrea);

                    foreach (var item in result)
                    {
                        codigoRetorno = new DTOResponseProcedure
                        {
                            ErrorCode = item.ErrorCode.HasValue ? item.ErrorCode.Value : 0,
                            ErrorMessage = item.ErrorMessage
                        };
                    }
                    return codigoRetorno;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ComprobantesSeries
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesSeries]
        /// <summary>
        /// <param name="objDocumentoSerie"></param>
        /// <returns></returns>
        public DTOResponseProcedure Update(BEDocumentoSerie objDocumentoSerie)
        {
            DTOResponseProcedure codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var result = SQLDC.omgc_U_DocumentoSerie(
                       objDocumentoSerie.CodigoPersonaEmpre,
                       objDocumentoSerie.codDocumentoSerie,
                       objDocumentoSerie.CodigoComprobante,
                       objDocumentoSerie.Descripcion,
                       objDocumentoSerie.CodigoPuntoVenta,
                       objDocumentoSerie.NombreReporte,
                       objDocumentoSerie.NumeroSerie,
                       objDocumentoSerie.NumeroInicio,
                       objDocumentoSerie.NumeroFinal,
                       objDocumentoSerie.UltimoEmitido,
                       objDocumentoSerie.Estado,
                       objDocumentoSerie.segUsuarioEdita,
                       objDocumentoSerie.segMaquinaEdita);

                    foreach (var item in result)
                    {
                        codigoRetorno = new DTOResponseProcedure
                        {
                            ErrorCode = item.ErrorCode.HasValue ? item.ErrorCode.Value : 0,
                            ErrorMessage = item.ErrorMessage
                        };
                    }
                    return codigoRetorno; 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.ComprobantesSeries
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesSeries]
        /// <summary>
        /// <param name="prm_CodigoTalonario"></param>
        /// <returns></returns>
        public DTOResponseProcedure Delete(string prm_codEmpresaRUC, int prm_codDocumentoSerie, 
                                           string prm_SegUsuarioDelete, string prm_SegMaquina)
        {
            DTOResponseProcedure codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var result = SQLDC.omgc_D_DocumentoSerie(prm_codEmpresaRUC,
                                                             prm_codDocumentoSerie,
                                                             prm_SegUsuarioDelete,
                                                             prm_SegMaquina);
                    foreach (var item in result)
                    {
                        codigoRetorno = new DTOResponseProcedure
                        {
                            ErrorCode = item.ErrorCode.HasValue ? item.ErrorCode.Value : 0,
                            ErrorMessage = item.ErrorMessage
                        };
                    }
                    return codigoRetorno;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobantesSeries
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesSeries]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumentoSerie> List(BaseFiltroDocumentoSerie pFiltro)
        {
            List<BEDocumentoSerie> lstDocumentoSerie = new List<BEDocumentoSerie>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumentoSerie(pFiltro.codEmpresaRUC,
                                                            pFiltro.codPuntoVenta,
                                                            pFiltro.codDocumento,
                                                            pFiltro.codDocumentoSerie,
                                                            pFiltro.desNombre,
                                                            pFiltro.codPlanilla,
                                                            pFiltro.indEstado,
                                                            pFiltro.tipDocumento,
                                                            pFiltro.codRegDestino);
                    foreach (var item in resul)
                    {
                        BEDocumentoSerie objDocumentoSerie = new BEDocumentoSerie();
                        objDocumentoSerie.codDocumentoSerie = item.codDocumentoSerie;
                        objDocumentoSerie.CodigoComprobante = item.CodigoComprobante;
                        objDocumentoSerie.Descripcion = item.Descripcion;
                        objDocumentoSerie.CodigoPuntoVenta = item.CodigoPuntoVenta;
                        objDocumentoSerie.CodigoPersonaEmpre = item.CodigoPersonaEmpre;
                        objDocumentoSerie.NombreReporte = item.NombreReporte;
                        objDocumentoSerie.NumeroSerie = item.NumeroSerie;
                        objDocumentoSerie.NumeroInicio = item.NumeroInicio;
                        objDocumentoSerie.NumeroFinal = item.NumeroFinal;
                        objDocumentoSerie.UltimoEmitido = item.UltimoEmitido;
                        objDocumentoSerie.Estado = item.Estado;
                        objDocumentoSerie.segUsuarioCrea = item.SegUsuarioCrea;
                        objDocumentoSerie.segUsuarioEdita = item.SegUsuarioEdita;
                        objDocumentoSerie.segFechaCrea = item.SegFechaCrea;
                        objDocumentoSerie.segFechaEdita = item.SegFechaEdita;
                        objDocumentoSerie.segMaquinaEdita = item.SegMaquina;
                        objDocumentoSerie.CodigoComprobanteNombre = item.CodigoComprobanteNombre;
                        objDocumentoSerie.CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre;
                        objDocumentoSerie.objDocumento.Descripcion = item.CodigoComprobanteNombre;
                        objDocumentoSerie.objPuntoDeVenta.desNombre = item.CodigoPuntoVentaNombre;

                        lstDocumentoSerie.Add(objDocumentoSerie);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDocumentoSerie;
        }

        public List<DTODocumentoSerie> ListPaginado(BaseFiltroDocumentoSeriePage pFiltro)
        {
            List<DTODocumentoSerie> lstDocumentoSerie = new List<DTODocumentoSerie>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumentoSerie_Paged(pFiltro.jqCurrentPage,
                                                                  pFiltro.jqPageSize,
                                                                  pFiltro.jqSortColumn,
                                                                  pFiltro.jqSortOrder,
                                                                  pFiltro.codEmpresaRUC,
                                                                  pFiltro.codPuntoVenta,
                                                                  pFiltro.codDocumento,
                                                                  pFiltro.codDocumentoSerie,
                                                                  pFiltro.desNombre,
                                                                  pFiltro.nomEmpleado,
                                                                  pFiltro.indEstado);
                    foreach (var item in resul)
                    {
                        DTODocumentoSerie objDocumentoSerie = new DTODocumentoSerie();
                        objDocumentoSerie.codDocumentoSerie = item.codDocumentoSerie;
                        objDocumentoSerie.codDocumento = item.CodigoComprobante;
                        objDocumentoSerie.codDocumentoNombre = item.CodigoComprobanteNombre;
                        objDocumentoSerie.Descripcion = item.Descripcion;
                        objDocumentoSerie.CodigoPuntoVenta = item.CodigoPuntoVenta;
                        objDocumentoSerie.codPuntoVentaNombre = item.CodigoPuntoVentaNombre;
                        objDocumentoSerie.CodigoPersonaEmpre = item.CodigoPersonaEmpre;
                        objDocumentoSerie.NombreReporte = item.NombreReporte;
                        objDocumentoSerie.NumeroSerie = item.NumeroSerie;
                        objDocumentoSerie.NumeroInicio = item.NumeroInicio;
                        objDocumentoSerie.NumeroFinal = item.NumeroFinal;
                        objDocumentoSerie.UltimoEmitido = item.UltimoEmitido;
                        objDocumentoSerie.Estado = item.Estado;
                        objDocumentoSerie.segUsuarioEdita = item.segUsuarioEdita;
                        objDocumentoSerie.segFechaEdita = item.segFechaEdita;
                        objDocumentoSerie.segMaquinaEdita = item.SegMaquina;
                        objDocumentoSerie.codEmpleadoNombre = item.codEmpleadoNombre;

                        objDocumentoSerie.ROWNUM = item.ROWNUM == null ? 0 : item.ROWNUM.Value;
                        objDocumentoSerie.TOTALROWS = item.TOTALROWS == null ? 0 : item.TOTALROWS.Value;

                        lstDocumentoSerie.Add(objDocumentoSerie);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDocumentoSerie;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.ComprobantesSeries
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesSeries]
        /// <summary>
        /// <param name="prm_codDocumentoSerie"></param>
        /// <returns></returns>
        public BEDocumentoSerie Find(string pcodEmpresaRUC, int prm_codDocumentoSerie, bool? prm_Estado)
        {
            BEDocumentoSerie objDocumentoSerie = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumentoSerie(pcodEmpresaRUC,null, null, 
                                                            prm_codDocumentoSerie, string.Empty, null,
                                                            prm_Estado, string.Empty, string.Empty);
                    foreach (var item in resul)
                    {
                        objDocumentoSerie = new BEDocumentoSerie();
                        objDocumentoSerie.codDocumentoSerie = item.codDocumentoSerie;
                        objDocumentoSerie.CodigoComprobante = item.CodigoComprobante;
                        objDocumentoSerie.Descripcion = item.Descripcion;
                        objDocumentoSerie.CodigoPuntoVenta = item.CodigoPuntoVenta;
                        objDocumentoSerie.CodigoPersonaEmpre = item.CodigoPersonaEmpre;
                        objDocumentoSerie.NombreReporte = item.NombreReporte;
                        objDocumentoSerie.NumeroSerie = item.NumeroSerie;
                        objDocumentoSerie.NumeroInicio = item.NumeroInicio;
                        objDocumentoSerie.NumeroFinal = item.NumeroFinal;
                        objDocumentoSerie.UltimoEmitido = item.UltimoEmitido;
                        objDocumentoSerie.Estado = item.Estado;
                        objDocumentoSerie.segUsuarioCrea = item.SegUsuarioCrea;
                        objDocumentoSerie.segUsuarioEdita = item.SegUsuarioEdita;
                        objDocumentoSerie.segFechaCrea = item.SegFechaCrea;
                        objDocumentoSerie.segFechaEdita = item.SegFechaEdita;
                        objDocumentoSerie.segMaquinaEdita = item.SegMaquina;
                        objDocumentoSerie.CodigoComprobanteNombre = item.CodigoComprobanteNombre;
                        objDocumentoSerie.CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre;
                        objDocumentoSerie.objDocumento.Descripcion = item.CodigoComprobanteNombre;
                        objDocumentoSerie.objPuntoDeVenta.desNombre = item.CodigoPuntoVentaNombre;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objDocumentoSerie;
        }

        #endregion

        #region /* Proceso de OPERACIONES ESPECÍFICAS */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumentoSerie> ListPorUsuario(BaseFiltroDocumentoSerie pFiltro) 
        {
            List<BEDocumentoSerie> lstDocumentoSerie = new List<BEDocumentoSerie>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumentoSerie(pFiltro.codEmpresaRUC,
                                                            pFiltro.codPuntoVenta,
                                                            pFiltro.codDocumento,
                                                            pFiltro.codDocumentoSerie,
                                                            pFiltro.desNombre,
                                                            pFiltro.codPlanilla,
                                                            pFiltro.indEstado,
                                                            string.Empty, 
                                                            string.Empty);
                    foreach (var item in resul)
                    {
                        lstDocumentoSerie.Add(new BEDocumentoSerie()
                        {
                            codDocumentoSerie = item.codDocumentoSerie,
                            CodigoComprobante = item.CodigoComprobante,
                            CodigoComprobanteNombre = item.CodigoComprobanteNombre,
                            Descripcion = item.Descripcion,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
                            CodigoPersonaEmpre = item.CodigoPersonaEmpre,
                            NombreReporte = item.NombreReporte,
                            NumeroSerie = item.NumeroSerie,
                            NumeroInicio = item.NumeroInicio,
                            NumeroFinal = item.NumeroFinal,
                            UltimoEmitido = item.UltimoEmitido,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaEdita = item.SegMaquina,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDocumentoSerie;
        }

        /// <summary>
        /// ACTUALIZA EL ULTIMO Nº EMITIDO EN +1 del registro de una ENTIDAD de registro de Tipo ComprobantesSeries
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesSeries]
        /// <summary>
        /// <param name="objDocumentoSerie"></param>
        /// <returns></returns> 
        public DTOResponseProcedure UpdateUltimo(BEDocumentoSerie objDocumentoSerie)
        {
            DTOResponseProcedure codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var result = SQLDC.omgc_U_DocumentoSerie_Ultimo(objDocumentoSerie.codEmpresaRUC,
                                                       objDocumentoSerie.codDocumentoSerie,
                                                       objDocumentoSerie.segUsuarioEdita,
                                                       objDocumentoSerie.segMaquinaEdita);
                    foreach (var item in result)
                    {
                        codigoRetorno = new DTOResponseProcedure
                        {
                            ErrorCode = item.ErrorCode.HasValue ? item.ErrorCode.Value : 0,
                            ErrorMessage = item.ErrorMessage
                        };
                    }
                    return codigoRetorno;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
} 

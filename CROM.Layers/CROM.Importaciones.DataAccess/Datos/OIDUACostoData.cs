namespace CROM.Importaciones.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Importaciones;
    using CROM.BusinessEntities.Importaciones.DTO;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/08/2014-01:23:29 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Importaciones.OIDUACostoData.cs]
    /// </summary>
    public class OIDUACostoData
    {
        private string conexion = string.Empty;

        public OIDUACostoData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Importaciones.OIDUACosto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUACosto]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEOIDUACosto> List(BaseFiltroImp pFiltro)
        {
            List<BEOIDUACosto> lstOIDUACosto = new List<BEOIDUACosto>();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIDUACosto(pFiltro.codOIDUACosto, pFiltro.codOIDUA);
                    foreach (var item in resul)
                    {
                        BEOIDUACosto itemCosto = new BEOIDUACosto();
                        itemCosto.codOIDUACosto = item.codOIDUACosto;
                        itemCosto.codOIDUA = item.codOIDUA;
                        itemCosto.codRegResumenCosto = item.codRegResumenCosto;
                        itemCosto.decMontoCosto = item.decMontoCosto == null ? 0 : item.decMontoCosto.Value;
                        itemCosto.indActivo = item.indActivo;
                        itemCosto.segUsuarioCrea = item.segUsuarioCrea;
                        itemCosto.segUsuarioEdita = item.segUsuarioEdita;
                        itemCosto.segFechaCrea = item.segFechaCrea;
                        itemCosto.segFechaEdita = item.segFechaEdita;
                        itemCosto.segMaquinaCrea = item.segMaquina;
                        itemCosto.auxcodRegResumenCosto = item.codRegResumenCostoNombre;
                        itemCosto.objOIDUA.numOIDUA = item.codOIDUANumero;
                        itemCosto.desOrigenDesde = item.OrigenDesde;
                        itemCosto.monTipoCambio = item.ValorTipoCambio == null ? 0 : item.ValorTipoCambio.Value;
                        itemCosto.auxcodRegMoneda = item.codRegMonedaNombre;
                        lstOIDUACosto.Add(itemCosto);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstOIDUACosto;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Importaciones.OIDUACosto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUACosto]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public BEOIDUACosto Find(BaseFiltroImp pFiltro)
        {
            BEOIDUACosto itemCosto = null;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_OIDUACostoId(pFiltro.codOIDUACosto);
                    foreach (var item in resul)
                    {
                        itemCosto = new BEOIDUACosto();
                        itemCosto.codOIDUACosto = item.codOIDUACosto;
                        itemCosto.codOIDUA = item.codOIDUA;
                        itemCosto.codRegResumenCosto = item.codRegResumenCosto;
                        itemCosto.decMontoCosto = item.decMontoCosto == null ? 0 : item.decMontoCosto.Value;
                        itemCosto.indActivo = item.indActivo;
                        itemCosto.segUsuarioCrea = item.segUsuarioCrea;
                        itemCosto.segUsuarioEdita = item.segUsuarioEdita;
                        itemCosto.segFechaCrea = item.segFechaCrea;
                        itemCosto.segFechaEdita = item.segFechaEdita;
                        itemCosto.segMaquinaCrea = item.segMaquina;
                        itemCosto.auxcodRegResumenCosto = item.codRegResumenCostoNombre;
                        itemCosto.objOIDUA.numOIDUA = item.codOIDUANumero;

                        itemCosto.desOrigenDesde = item.desOrigenDesde;
                        itemCosto.monTipoCambio = item.monTipoCambioDUA == null ? 0 : item.monTipoCambioDUA.Value;
                        itemCosto.codRegMoneda = item.codRegMoneda;
                        itemCosto.objOIDUA.fecEmision = item.fecEmisionDUA;
                        itemCosto.auxcodRegMoneda = item.codRegMonedaNombre;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemCosto;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDUACosto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUACosto]
        /// <summary>
        /// <param name = >pOIDUACosto</param>
        public bool Insert(BEOIDUACosto pOIDUACosto)
        {
            int? codigoRetorno = null;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    SQLDC.omgc_I_OIDUACosto(
                      ref codigoRetorno,
                      pOIDUACosto.codOIDUA,
                      pOIDUACosto.codRegResumenCosto,
                      pOIDUACosto.decMontoCosto,
                      pOIDUACosto.indActivo,
                      pOIDUACosto.segUsuarioCrea,
                      pOIDUACosto.codRegMoneda
                      );
                    pOIDUACosto.codOIDUACosto = codigoRetorno.Value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno.HasValue ? true : false;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo OIDUACosto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUACosto]
        /// </summary>
        /// <param name="pOIDUACosto"></param>
        /// <returns></returns>
        public bool Update(BEOIDUACosto pOIDUACosto)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    SQLDC.omgc_U_OIDUACosto(
                        pOIDUACosto.codOIDUACosto,
                        pOIDUACosto.codOIDUA,
                        pOIDUACosto.codRegResumenCosto,
                        pOIDUACosto.decMontoCosto,
                        pOIDUACosto.indActivo,
                        pOIDUACosto.segUsuarioEdita,
                        pOIDUACosto.codRegMoneda
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
        /// ELIMINA un registro de la Entidad Importaciones.OIDUACosto
        /// En la BASE de DATO la Tabla : [Importaciones.OIDUACosto]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public bool Delete(BaseFiltroImp pFiltro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    SQLDC.omgc_D_OIDUACosto(pFiltro.codOIDUACosto, pFiltro.codOIDUA);
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public bool Delete(List<BEOIDUACosto> plstOIDUACosto)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    foreach (BEOIDUACosto itemCosto in plstOIDUACosto)
                        SQLDC.omgc_D_OIDUACosto(itemCosto.codOIDUACosto, itemCosto.codOIDUA);
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

        public List<DTOAsignaCosto> ListAsignaCosto(BaseFiltroImp pFiltro)
        {
            List<DTOAsignaCosto> lstAsignaCosto = new List<DTOAsignaCosto>();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DUADetalleCosto(pFiltro.fecInicio, pFiltro.fecFinal, pFiltro.codPersonaEntidad);
                    foreach (var item in resul)
                    {
                        DTOAsignaCosto itemCosto = new DTOAsignaCosto();
                        itemCosto.codDocumRegDetalle = item.IdDetalle;
                        itemCosto.cantidad = item.Cantidad;
                        itemCosto.descriDetalle = item.Descripcion;
                        itemCosto.fechaEmision = item.FechaEmision;
                        itemCosto.item = item.Item;
                        itemCosto.montoInternacional = item.MoneInternacional == null ? 0 : item.MoneInternacional.Value;
                        itemCosto.montoNacional = item.MoneNacional == null ? 0 : item.MoneNacional.Value;
                        itemCosto.nombreEmpresa = item.NombreEmpresa;
                        itemCosto.numeroDocumento = item.NumeroComprobante;
                        itemCosto.valorTC = item.TipoCambio;
                        itemCosto.CostoReferenciado = item.CostoReferenciado;
                        lstAsignaCosto.Add(itemCosto);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAsignaCosto;
        }

        public List<DTOAsignaCosto> ListAsignaCostoPaginado(BaseFiltroImp pFiltro)
        {
            List<DTOAsignaCosto> lstAsignaCosto = new List<DTOAsignaCosto>();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DUADetalleCostoPage(pFiltro.grcurrentPage
                                                               , pFiltro.grpageSize
                                                               , pFiltro.grsortOrder
                                                               , pFiltro.fecInicio
                                                               , pFiltro.fecFinal
                                                               , pFiltro.codPersonaEntidad);
                    foreach (var item in resul)
                    {
                        DTOAsignaCosto itemCosto = new DTOAsignaCosto();
                        itemCosto.codDocumRegDetalle = item.IdDetalle;
                        itemCosto.cantidad = item.Cantidad;
                        itemCosto.descriDetalle = item.Descripcion;
                        itemCosto.fechaEmision = item.FechaEmision;
                        itemCosto.item = item.Item;
                        itemCosto.montoInternacional = item.MoneInternacional == null ? 0 : item.MoneInternacional.Value;
                        itemCosto.montoNacional = item.MoneNacional == null ? 0 : item.MoneNacional.Value;
                        itemCosto.nombreEmpresa = item.NombreEmpresa;
                        itemCosto.numeroDocumento = item.NumeroComprobante;
                        itemCosto.valorTC = item.TipoCambio;
                        itemCosto.CostoReferenciado = item.CostoReferenciado;
                        itemCosto.ROWNUM = item.ROWNUM == null ? 0 : item.ROWNUM.Value;
                        itemCosto.TOTALROWS = item.TOTALROWS == null ? 0 : item.TOTALROWS.Value;
                        lstAsignaCosto.Add(itemCosto);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAsignaCosto;
        }
    }
} 

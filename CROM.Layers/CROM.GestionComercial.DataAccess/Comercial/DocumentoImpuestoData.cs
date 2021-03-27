namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 16/09/2010-6:51:19
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.DocumentoImpuestoData.cs]
    /// </summary>
    public class DocumentoImpuestoData
    {
        private string conexion = string.Empty;

        public DocumentoImpuestoData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ComprobantesImpuestos
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesImpuestos]
        /// <summary>
        /// <param name="objDocumentoImpuesto"></param>
        /// <returns></returns>
        public bool Insert(BEDocumentoImpuesto objDocumentoImpuesto)
        {
            int? codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_I_DocumentoImpuesto(
                        ref codigoRetorno,
                        objDocumentoImpuesto.codEmpresa,
                        objDocumentoImpuesto.CodigoComprobante,
                        objDocumentoImpuesto.CodigoImpuesto,
                        objDocumentoImpuesto.VeoImporte,
                        objDocumentoImpuesto.Orden,
                        objDocumentoImpuesto.segUsuarioEdita,
                        objDocumentoImpuesto.segMaquinaCrea);

                    if (objDocumentoImpuesto.codDocumentoImpuesto == 0)
                        objDocumentoImpuesto.codDocumentoImpuesto = codigoRetorno.Value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (codigoRetorno >0 )? true : false;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.ComprobantesImpuestos
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesImpuestos]
        /// <summary>
        /// <param name="prm_CodigoDocumento"></param>
        /// <param name="prm_CodigoArguTipoImpuesto"></param>
        /// <returns></returns>
        public bool Delete(int pcodEmpresa, int pcodDocumentoImpuesto)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_D_DocumentoImpuesto(pcodEmpresa,
                                                   pcodDocumentoImpuesto);
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

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobantesImpuestos
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesImpuestos]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumentoImpuesto> List(BaseFiltroDocumentoImpuesto pFiltro)
        {
            List<BEDocumentoImpuesto> lstDocumentoImpuesto = new List<BEDocumentoImpuesto>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumentoImpuesto(pFiltro.codEmpresa,
                                                               pFiltro.codEmpresaRUC, 
                                                               pFiltro.codDocumento, 
                                                               pFiltro.codImpuesto,
                                                               null); ;
                    foreach (var item in resul)
                    {
                        BEDocumentoImpuesto objDocumentoImpuesto = new BEDocumentoImpuesto();
                        objDocumentoImpuesto.codDocumentoImpuesto = item.codDocumentoImpuesto;
                        objDocumentoImpuesto.CodigoComprobante = item.CodigoComprobante;
                        objDocumentoImpuesto.CodigoImpuesto = item.CodigoImpuesto;
                        objDocumentoImpuesto.VeoImporte = item.VeoImporte;
                        objDocumentoImpuesto.Orden = item.Orden;
                        objDocumentoImpuesto.segUsuarioCrea = item.SegUsuarioCrea;
                        objDocumentoImpuesto.segUsuarioEdita = item.SegUsuarioEdita;
                        objDocumentoImpuesto.segFechaCrea = item.SegFechaCrea;
                        objDocumentoImpuesto.segFechaEdita = item.SegFechaEdita;
                        objDocumentoImpuesto.segMaquinaEdita = item.SegMaquina;
                        objDocumentoImpuesto.CodigoImpuestoNombre = item.codImpuestoNombre;
                        objDocumentoImpuesto.CodigoComprobanteNombre = item.codDocumentoNombre;

                        objDocumentoImpuesto.objDocumento.Descripcion = item.codDocumentoNombre;
                        objDocumentoImpuesto.objImpuesto.Descripcion = item.codImpuestoNombre;
                        lstDocumentoImpuesto.Add(objDocumentoImpuesto);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDocumentoImpuesto;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobantesImpuestos
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesImpuestos]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumentoImpuesto> ListPaginado(BaseFiltroDocumentoImpuestoPage pFiltro)
        {
            List<BEDocumentoImpuesto> lstDocumentoImpuesto = new List<BEDocumentoImpuesto>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumentoImpuesto_Paged(pFiltro.jqCurrentPage,
                                                                     pFiltro.jqPageSize,
                                                                     pFiltro.jqSortColumn,
                                                                     pFiltro.jqSortOrder,
                                                                     pFiltro.codEmpresa,
                                                                     pFiltro.codEmpresaRUC,
                                                                     pFiltro.codDocumento,
                                                                     pFiltro.codImpuesto); ;
                    foreach (var item in resul)
                    {
                        BEDocumentoImpuesto objDocumentoImpuesto = new BEDocumentoImpuesto();

                        objDocumentoImpuesto.codEmpresa = item.codEmpresa;
                        objDocumentoImpuesto.codDocumentoImpuesto = item.codDocumentoImpuesto;
                        objDocumentoImpuesto.CodigoComprobante = item.CodigoComprobante;
                        objDocumentoImpuesto.CodigoImpuesto = item.CodigoImpuesto;
                        objDocumentoImpuesto.VeoImporte = item.VeoImporte;
                        objDocumentoImpuesto.Orden = item.Orden;
                        objDocumentoImpuesto.segUsuarioCrea = item.SegUsuarioCrea;
                        objDocumentoImpuesto.segUsuarioEdita = item.SegUsuarioEdita;
                        objDocumentoImpuesto.segFechaCrea = item.SegFechaCrea;
                        objDocumentoImpuesto.segFechaEdita = item.SegFechaEdita;
                        objDocumentoImpuesto.segMaquinaEdita = item.SegMaquina;
                        objDocumentoImpuesto.CodigoImpuestoNombre = item.codImpuestoNombre;
                        objDocumentoImpuesto.CodigoComprobanteNombre = item.codDocumentoNombre;

                        objDocumentoImpuesto.objDocumento.Descripcion = item.codDocumentoNombre;
                        objDocumentoImpuesto.objImpuesto.Descripcion = item.codImpuestoNombre;
                        lstDocumentoImpuesto.Add(objDocumentoImpuesto);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDocumentoImpuesto;
        }

        #endregion

        #region /* Proceso de SELECT ID */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobantesImpuestos
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesImpuestos]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public BEDocumentoImpuesto Find(BaseFiltroDocumentoImpuesto pFiltro)
        {
            BEDocumentoImpuesto objDocumentoImpuesto = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumentoImpuesto(pFiltro.codEmpresa,
                                                               pFiltro.codEmpresaRUC,
                                                               pFiltro.codDocumento,
                                                               pFiltro.codImpuesto,
                                                               pFiltro.codDocumentoImpuesto); ;
                    foreach (var item in resul)
                    {
                        objDocumentoImpuesto = new BEDocumentoImpuesto();
                        objDocumentoImpuesto.codEmpresa = item.codEmpresa;
                        objDocumentoImpuesto.CodigoComprobante = item.CodigoComprobante;
                        objDocumentoImpuesto.CodigoImpuesto = item.CodigoImpuesto;
                        objDocumentoImpuesto.VeoImporte = item.VeoImporte;
                        objDocumentoImpuesto.Orden = item.Orden;
                        objDocumentoImpuesto.segUsuarioCrea = item.SegUsuarioCrea;
                        objDocumentoImpuesto.segUsuarioEdita = item.SegUsuarioEdita;
                        objDocumentoImpuesto.segFechaCrea = item.SegFechaCrea;
                        objDocumentoImpuesto.segFechaEdita = item.SegFechaEdita;
                        objDocumentoImpuesto.segMaquinaEdita = item.SegMaquina;
                        objDocumentoImpuesto.CodigoImpuestoNombre = item.codImpuestoNombre;
                        objDocumentoImpuesto.CodigoComprobanteNombre = item.codDocumentoNombre;

                        objDocumentoImpuesto.objDocumento.Descripcion = item.codDocumentoNombre;
                        objDocumentoImpuesto.objImpuesto.Descripcion = item.codImpuestoNombre;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objDocumentoImpuesto;
        }

        #endregion
    }
} 

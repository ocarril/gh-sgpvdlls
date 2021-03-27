namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.Cajas;
    using CROM.BusinessEntities.Comercial.DTO;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 05/09/2010-04:26:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [CajaBanco.FormaDePagoData.cs]
    /// </summary>
    public class FormaDePagoData
    {
        private string conexion = string.Empty;

        public FormaDePagoData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de FormaDePago
        /// En la BASE de DATO la Tabla : [GestionComercialFormaDePago]
        /// </summary>
        /// <param name="objFormaDePago"></param>
        /// <returns></returns>
        public void Insert(BEFormaDePago objFormaDePago)
        {
            int? codigoRetorno = null;
            try
            {
                using (_CajaBancosDataContext SQLDC = new _CajaBancosDataContext(conexion))
                {
                    SQLDC.omgc_I_FormaDePago(
                        ref codigoRetorno,
                        objFormaDePago.desNombre,
                        objFormaDePago.indCobranza,
                        objFormaDePago.indEgreso,
                        objFormaDePago.indActivo,
                        objFormaDePago.indIngreso,
                        objFormaDePago.indNotacredito,
                        objFormaDePago.indVenta,
                        objFormaDePago.segUsuarioCrea,
                        objFormaDePago.segMaquinaCrea
                        );
                    objFormaDePago.codFormaDePago = codigoRetorno.HasValue ? codigoRetorno.Value : 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <param name = >itemTiposdeCambio</param>
        public bool Update(BEFormaDePago objFormaDePago)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CajaBancosDataContext SQLDC = new _CajaBancosDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_FormaDePago(
                        objFormaDePago.codFormaDePago,
                        objFormaDePago.desNombre,
                        objFormaDePago.indCobranza,
                        objFormaDePago.indEgreso,
                        objFormaDePago.indActivo,
                        objFormaDePago.indIngreso,
                        objFormaDePago.indNotacredito,
                        objFormaDePago.indVenta,
                        objFormaDePago.segUsuarioEdita,
                        objFormaDePago.segMaquinaEdita);
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
        /// ELIMINA un registro de la Entidad GestionComercial.TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(int prm_codFormaDePago)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CajaBancosDataContext SQLDC = new _CajaBancosDataContext(conexion))
                {
                    SQLDC.omgc_D_FormaDePago(prm_codFormaDePago);
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
        /// Retorna un LISTA de registros de la Entidad GestionComercial.TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <returns>List</returns>
        public List<BEFormaDePago> List(BaseFiltro pFiltro)// string prm_codFormaDePago, string prm_desNombre, bool? prm_indActivo)
        {
            List<BEFormaDePago> lstFormaDePago = new List<BEFormaDePago>();
            try
            {
                using (_CajaBancosDataContext SQLDC = new _CajaBancosDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_FormaDePago(pFiltro.codsFormaPago, pFiltro.desNombre, pFiltro.indEstado);
                    foreach (var item in resul)
                    {
                        lstFormaDePago.Add(new BEFormaDePago()
                        {
                            codFormaDePago = item.codFormaDePago,
                            desNombre = item.desNombre,
                            indCobranza = item.indCobranza,
                            indEgreso = item.indEgreso,
                            indIngreso = item.indIngreso,
                            indNotacredito = item.indNotacredito,
                            indVenta = item.indVenta,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaEdita = item.segMaquina,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstFormaDePago;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <returns>List</returns>
        public List<BEFormaDePago> ListPaginado(BaseFiltro pFiltro)
        {
            List<BEFormaDePago> lstFormaDePago = new List<BEFormaDePago>();
            try
            {
                using (_CajaBancosDataContext SQLDC = new _CajaBancosDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_FormaDePago_Paged(pFiltro.grcurrentPage,
                                                                  pFiltro.grpageSize,
                                                                  pFiltro.grsortColumn,
                                                                  pFiltro.grsortOrder,
                                                                  pFiltro.codFormaPago,
                                                                  pFiltro.desNombre,
                                                                  pFiltro.indEstado);
                    foreach (var item in resul)
                    {
                        lstFormaDePago.Add(new BEFormaDePago()
                        {
                            codFormaDePago = item.codFormaDePago,
                            desNombre = item.desNombre,
                            indCobranza = item.indCobranza,
                            indEgreso = item.indEgreso,
                            indIngreso = item.indIngreso,
                            indNotacredito = item.indNotacredito,
                            indVenta = item.indVenta,
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
            return lstFormaDePago;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEFormaDePago Find(int prm_codFormaDePago)
        {
            BEFormaDePago objFormaDePago = null;
            try
            {
                using (_CajaBancosDataContext SQLDC = new _CajaBancosDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_FormaDePago(prm_codFormaDePago, null, null);
                    foreach (var item in resul)
                    {
                        objFormaDePago = new BEFormaDePago()
                        {
                            codFormaDePago = item.codFormaDePago,
                            desNombre = item.desNombre,
                            indCobranza = item.indCobranza,
                            indEgreso = item.indEgreso,
                            indIngreso = item.indIngreso,
                            indNotacredito = item.indNotacredito,
                            indVenta = item.indVenta,
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
            return objFormaDePago;
        }

        #endregion

    }
} 

namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m. - 07/feb/2018 05:22
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.CondicionVentaData.cs]
    /// </summary>
    public class CondicionData
    {
        private string conexion = string.Empty;
      
        public CondicionData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Condicion
        /// En la BASE de DATO la Tabla : [GestionComercial.Condicion]
        /// <summary>
        /// <param name = >itemCondicionVenta</param>
        public int Insert(BECondicion pCondicion)
        {
            int? codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_I_Condicion(
                        ref codigoRetorno,
                        pCondicion.desNombre,
                        pCondicion.numCuota,
                        pCondicion.numDiasCCtaCte,
                        pCondicion.numDiasVCtaCte,
                        pCondicion.numDiasCVcto,
                        pCondicion.numDecimalRedondeo,
                        pCondicion.indEsGravaCtaCte,
                        pCondicion.indEsPredeterminado,
                        pCondicion.indEsContraEntrega,
                        pCondicion.indEsEnCuota,
                        pCondicion.indEsVenta,
                        pCondicion.indActivo,
                        pCondicion.segUsuarioCrea,
                        pCondicion.segMaquinaCrea);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno.HasValue ? codigoRetorno.Value : 0;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Condicion
        /// En la BASE de DATO la Tabla : [GestionComercial.Condicion]
        /// <summary>
        /// <param name = >itemCondicionVenta</param>
        public bool Update(BECondicion pCondicion)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_U_Condicion(
                        pCondicion.codCondicion,
                        pCondicion.desNombre,
                        pCondicion.numCuota,
                        pCondicion.numDiasCCtaCte,
                        pCondicion.numDiasVCtaCte,
                        pCondicion.numDiasCVcto,
                        pCondicion.numDecimalRedondeo,
                        pCondicion.indEsGravaCtaCte,
                        pCondicion.indEsPredeterminado,
                        pCondicion.indEsContraEntrega,
                        pCondicion.indEsEnCuota,
                        pCondicion.indEsVenta,
                        pCondicion.indActivo,
                        pCondicion.segUsuarioEdita,
                        pCondicion.segMaquinaEdita);
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
        /// ELIMINA un registro de la Entidad GestionComercial.CondicionVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.Condicion]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(BECondicion pCondicion)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_D_Condicion(pCondicion.codCondicion, 
                                           pCondicion.segUsuarioElimina, 
                                           pCondicion.segMaquinaElimina);
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
        /// Retorna un LISTA de registros de la Entidad GestionComercial.Condicion
        /// En la BASE de DATO la Tabla : [GestionComercial.Condicion]
        /// <summary>
        /// <returns>List</returns>
        public List<BECondicion> List(BaseFiltro pFiltro)
        {
            List<BECondicion> lstCondicion = new List<BECondicion>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Condicion(pFiltro.codCondicionVenta, 
                                                       pFiltro.desNombre, 
                                                       pFiltro.indVentaCompra, 
                                                       pFiltro.indEstado);
                    foreach (var item in resul)
                    {
                        lstCondicion.Add(new BECondicion()
                        {
                            codCondicion = item.codCondicion,
                            desNombre = item.desNombre,
                            numCuota = item.numCuota,
                            numDiasCCtaCte = item.numDiasCCtaCte,
                            numDiasVCtaCte = item.numDiasVCtaCte,
                            numDiasCVcto = item.numDiasCVcto,
                            numDecimalRedondeo = item.numDecimalRedondeo,
                            indEsGravaCtaCte = item.indEsGravaCtaCte,
                            indEsPredeterminado = item.indEsPredeterminado,
                            indEsEnCuota = item.indEsEnCuota,
                            indEsContraEntrega = item.indEsContraEntrega,
                            indEsVenta = item.indEsVenta,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquinaCrea,
                            segMaquinaEdita = item.segMaquinaEdita,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCondicion;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.CondicionVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.CondicionVenta]
        /// <summary>
        /// <returns>List</returns>
        public List<BECondicion> ListPaginado(BaseFiltroCondicionPage pFiltro)
        {
            List<BECondicion> lstCondicion = new List<BECondicion>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Condicion_Paged(pFiltro.jqCurrentPage,
                                                             pFiltro.jqPageSize,
                                                             pFiltro.jqSortColumn,
                                                             pFiltro.jqSortOrder,
                                                             pFiltro.desNombre,
                                                             pFiltro.indEstado,
                                                             pFiltro.indDestinoVenta);
                    foreach (var item in resul)
                    {
                        lstCondicion.Add(new BECondicion()
                        {
                            codCondicion = item.codCondicion,
                            desNombre = item.desNombre,
                            numCuota = item.numCuota,
                            numDiasCCtaCte = item.numDiasCCtaCte,
                            numDiasVCtaCte = item.numDiasVCtaCte,
                            numDiasCVcto = item.numDiasCVcto,
                            numDecimalRedondeo = item.numDecimalRedondeo,
                            indEsGravaCtaCte = item.indEsGravaCtaCte,
                            indEsPredeterminado = item.indEsPredeterminado,
                            indEsEnCuota = item.indEsEnCuota,
                            indEsContraEntrega = item.indEsContraEntrega,
                            indEsVenta = item.indEsVenta,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquinaCrea,
                            segMaquinaEdita = item.segMaquinaEdita,

                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0,
                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCondicion;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.CondicionVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.CondicionVenta]
        /// <summary>
        /// <returns>Entidad</returns>
        public BECondicion Find(int pcodCondicion, bool? prm_indEsVenta, bool? prm_indActivo)
        {
            BECondicion condicion = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Condicion(pcodCondicion, null, prm_indEsVenta, prm_indActivo);
                    foreach (var item in resul)
                    {
                        condicion = new BECondicion()
                        {
                            codCondicion = item.codCondicion,
                            desNombre = item.desNombre,
                            numCuota = item.numCuota,
                            numDiasCCtaCte = item.numDiasCCtaCte,
                            numDiasVCtaCte = item.numDiasVCtaCte,
                            numDiasCVcto = item.numDiasCVcto,
                            numDecimalRedondeo = item.numDecimalRedondeo,
                            indEsGravaCtaCte = item.indEsGravaCtaCte,
                            indEsPredeterminado = item.indEsPredeterminado,
                            indEsEnCuota = item.indEsEnCuota,
                            indEsContraEntrega = item.indEsContraEntrega,
                            indEsVenta = item.indEsVenta,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquinaCrea,
                            segMaquinaEdita = item.segMaquinaEdita
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return condicion;
        }

        #endregion

    }
} 

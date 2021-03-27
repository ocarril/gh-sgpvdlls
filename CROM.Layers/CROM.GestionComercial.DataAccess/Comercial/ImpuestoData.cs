namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;
    using CROM.Tools.Comun.entities;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 18/09/2010-5:10:38
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.TiposDeImpuestoData.cs]
    /// </summary>
    public class ImpuestoData
    {
        private string conexion = string.Empty;
        
        public ImpuestoData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Impuesto
        /// En la BASE de DATO la Tabla : [GestionComercial.Impuesto]
        /// <summary>
        /// <param name="objImpuesto"></param>
        /// <returns></returns>
        public string Insert(BEImpuesto objImpuesto)
        {
            string codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_I_Impuesto(
                        ref codigoRetorno,
                        objImpuesto.Descripcion,
                        objImpuesto.Porcentaje,
                        objImpuesto.PorceAcre,
                        objImpuesto.DiscriminaAcrec,
                        objImpuesto.DiscriminaIGV,
                        objImpuesto.DiscriminaIngBruto,
                        objImpuesto.CodigoArguAbrevFiscal,
                        objImpuesto.Estado,
                        objImpuesto.segUsuarioCrea,
                        objImpuesto.segMaquinaCrea);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo TiposDeImpuesto
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposDeImpuesto]
        /// <summary>
        /// <param name="objImpuesto"></param>
        /// <returns></returns>
        public bool Update(BEImpuesto objImpuesto)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_Impuesto(
                        objImpuesto.CodigoImpuesto,
                        objImpuesto.Descripcion,
                        objImpuesto.Porcentaje,
                        objImpuesto.PorceAcre,
                        objImpuesto.DiscriminaAcrec,
                        objImpuesto.DiscriminaIGV,
                        objImpuesto.DiscriminaIngBruto,
                        objImpuesto.CodigoArguAbrevFiscal,
                        objImpuesto.Estado,
                        objImpuesto.segUsuarioEdita,
                        objImpuesto.segMaquinaEdita);
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
        /// Retorna un LISTA de registros de la Entidad GestionComercial.Impuesto
        /// En la BASE de DATO la Tabla : [GestionComercial.Impuesto]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEImpuesto> List(BaseFiltroImpuesto pFiltro)
        {
            List<BEImpuesto> lstImpuesto = new List<BEImpuesto>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Impuesto(pFiltro.codImpuesto,
                                                      pFiltro.desNombre,
                                                      pFiltro.indEstado);
                    foreach (var item in resul)
                    {
                        BEImpuesto objImpuesto = new BEImpuesto();
                        objImpuesto.CodigoImpuesto = item.codImpuesto;
                        objImpuesto.Descripcion = item.desNombre;
                        objImpuesto.Porcentaje = item.prcValor;
                        objImpuesto.PorceAcre = item.prcAcrec;
                        objImpuesto.DiscriminaAcrec = item.indDiscriminaAcrec;
                        objImpuesto.DiscriminaIGV = item.indDiscriminaIGV;
                        objImpuesto.DiscriminaIngBruto = item.indDiscriminaIngBruto;
                        objImpuesto.CodigoArguAbrevFiscal = item.codImpuestoSUNAT;
                        objImpuesto.Estado = item.indActivo;
                        objImpuesto.segUsuarioCrea = item.segUsuarioCrea;
                        objImpuesto.segUsuarioEdita = item.segUsuarioEdita;
                        objImpuesto.segFechaCrea = item.segFechaCrea;
                        objImpuesto.segFechaEdita = item.segFechaEdita;
                        objImpuesto.segMaquinaCrea = item.segMaquinaEdita;
                        objImpuesto.Porcentaje100 = item.prcValor* 100;

                        lstImpuesto.Add(objImpuesto);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstImpuesto;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.Impuesto Paginado
        /// En la BASE de DATO la Tabla : [GestionComercial.Impuesto]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEImpuesto> ListPaged(BaseFiltroImpuestoPage pFiltro)
        {
            List<BEImpuesto> lstImpuesto = new List<BEImpuesto>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Impuesto_Paged(pFiltro.jqCurrentPage,
                                                            pFiltro.jqPageSize,
                                                            pFiltro.jqSortColumn,
                                                            pFiltro.jqSortOrder,
                                                            pFiltro.codImpuesto,
                                                            pFiltro.desNombre,
                                                            pFiltro.indEstado);
                    foreach (var item in resul)
                    {
                        BEImpuesto objImpuesto = new BEImpuesto();
                        objImpuesto.ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0;
                        objImpuesto.TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0;

                        objImpuesto.codEmpresa = pFiltro.codEmpresa;
                        objImpuesto.CodigoImpuesto = item.CodigoImpuesto;
                        objImpuesto.Descripcion = item.Descripcion;
                        objImpuesto.Porcentaje = item.Porcentaje;
                        objImpuesto.PorceAcre = item.PorceAcre;
                        objImpuesto.DiscriminaAcrec = item.DiscriminaAcrec;
                        objImpuesto.DiscriminaIGV = item.DiscriminaIGV;
                        objImpuesto.DiscriminaIngBruto = item.DiscriminaIngBruto;
                        objImpuesto.CodigoArguAbrevFiscal = item.CodigoArguAbrevFiscal;
                        objImpuesto.Estado = item.Estado;
                        objImpuesto.segUsuarioCrea = item.SegUsuarioCrea;
                        objImpuesto.segUsuarioEdita = item.SegUsuarioEdita;
                        objImpuesto.segFechaCrea = item.SegFechaCrea;
                        objImpuesto.segFechaEdita = item.SegFechaEdita;
                        objImpuesto.segMaquinaCrea = item.SegMaquina;
                        objImpuesto.Porcentaje100 = item.Porcentaje * 100;
                        lstImpuesto.Add(objImpuesto);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstImpuesto;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.TiposDeImpuesto
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposDeImpuesto]
        /// <summary>
        /// <param name="pCodigoImpuesto"></param>
        /// <returns></returns>
        public BEImpuesto Find(int pcodEmpresa, string pCodigoImpuesto)
        {
            BEImpuesto objImpuesto = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Impuesto(pCodigoImpuesto, 
                                                      null, 
                                                      null);
                    foreach (var item in resul)
                    {
                        objImpuesto = new BEImpuesto();
                        objImpuesto.CodigoImpuesto = item.codImpuesto;
                        objImpuesto.Descripcion = item.desNombre;
                        objImpuesto.Porcentaje = item.prcValor;
                        objImpuesto.PorceAcre = item.prcAcrec;
                        objImpuesto.DiscriminaAcrec = item.indDiscriminaAcrec;
                        objImpuesto.DiscriminaIGV = item.indDiscriminaIGV;
                        objImpuesto.DiscriminaIngBruto = item.indDiscriminaIngBruto;
                        objImpuesto.CodigoArguAbrevFiscal = item.codImpuestoSUNAT;
                        objImpuesto.Estado = item.indActivo;
                        objImpuesto.segUsuarioCrea = item.segUsuarioCrea;
                        objImpuesto.segUsuarioEdita = item.segUsuarioEdita;
                        objImpuesto.segFechaCrea = item.segFechaCrea;
                        objImpuesto.segFechaEdita = item.segFechaEdita;
                        objImpuesto.segMaquinaCrea = item.segMaquinaEdita;
                        objImpuesto.Porcentaje100 = item.prcValor * 100;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objImpuesto;
        }

        public DTOImpuestoResponse Find(BaseFiltroImpuesto pFiltro)
        {
            DTOImpuestoResponse objImpuesto = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Impuesto(pFiltro.codImpuesto,
                                                      null,
                                                      null);
                    foreach (var item in resul)
                    {
                        objImpuesto = new DTOImpuestoResponse();
                        objImpuesto.codImpuesto = item.codImpuesto;
                        objImpuesto.desNombre = item.desNombre;
                        objImpuesto.prcValor = item.prcValor;
                        objImpuesto.prcAcrec = item.prcAcrec;
                        objImpuesto.indDiscriminaAcrec = item.indDiscriminaAcrec;
                        objImpuesto.indDiscriminaIGV = item.indDiscriminaIGV;
                        objImpuesto.indDiscriminaIngBruto = item.indDiscriminaIngBruto;
                        objImpuesto.codImpuestoSUNAT = item.codImpuestoSUNAT;
                        objImpuesto.indActivo = item.indActivo;
                        objImpuesto.segUsuarioEdita = item.segUsuarioEdita;
                        objImpuesto.segFechaEdita = item.segFechaEdita;
                        objImpuesto.segMaquinaEdita = item.segMaquinaEdita;
                        objImpuesto.prcValor100 = item.prcValor * 100;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objImpuesto;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.TiposDeImpuesto
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposDeImpuesto]
        /// <summary>
        /// <param name="pCodigoImpuesto"></param>
        /// <returns></returns>
        public ReturnValor Delete(DTODeleteRequest pDelete)
        {
            ReturnValor codigoRetorno = new ReturnValor();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                  var resultDelete =   SQLDC.omgc_D_Impuesto(pDelete.IdRecordStr, 
                                                             pDelete.DelUser, 
                                                             pDelete.segIPMaquinaPC);

                    foreach(var result in resultDelete)
                    {
                        codigoRetorno.codRetorno = result.codError.HasValue ? result.codError.Value : 0;
                        codigoRetorno.Message = result.desMessage;
                        ; codigoRetorno.Exitosa = codigoRetorno.codRetorno == 1 ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno;
        }
    
        #endregion

    }
} 

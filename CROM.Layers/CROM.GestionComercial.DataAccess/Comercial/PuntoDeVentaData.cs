namespace CROM.GestionComercial.DataAccess
{
    using CROM.BusinessEntities.Comercial;

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.PuntoDeVentaData.cs]
    /// </summary>
    public class PuntoDeVentaData
    {
        private string conexion = string.Empty;
        
        public PuntoDeVentaData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PuntosDeVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.PuntoDeVenta]
        /// <summary>
        /// <param name="objPuntoDeVenta"></param>
        /// <param name="prm_codPrefijoEmpre"></param>
        /// <returns></returns>
        public string Insert(BEPuntoDeVenta objPuntoDeVenta, string prm_codPrefijoEmpre)
        {
            string codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_I_PuntoDeVenta(
                    ref codigoRetorno,
                    prm_codPrefijoEmpre,
                    objPuntoDeVenta.codPersonaEmpre,
                    objPuntoDeVenta.codEmpleadoRespon,
                    objPuntoDeVenta.desNombre,
                    objPuntoDeVenta.desPathFiles,
                    objPuntoDeVenta.indActivo,
                    objPuntoDeVenta.segUsuarioCrea,
                    objPuntoDeVenta.segMaquinaCrea);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo PuntosDeVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.PuntosDeVenta]
        /// <summary>
        /// <param name="objPuntoDeVenta"></param>
        /// <returns></returns>
        public bool Update(BEPuntoDeVenta objPuntoDeVenta)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_U_PuntoDeVenta(
                        objPuntoDeVenta.codPuntoDeVenta,
                        objPuntoDeVenta.codPersonaEmpre,
                        objPuntoDeVenta.codEmpleadoRespon,
                        objPuntoDeVenta.desNombre,
                        objPuntoDeVenta.desPathFiles,
                        objPuntoDeVenta.indActivo,
                        objPuntoDeVenta.segUsuarioEdita,
                        objPuntoDeVenta.segMaquinaEdita);
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
        /// ELIMINA un registro de la Entidad GestionComercial.PuntosDeVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.PuntosDeVenta]
        /// <summary>
        /// <param name="prm_codPuntoDeVenta"></param>
        /// <returns></returns>
        public bool Delete(string prm_codPuntoDeVenta)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_D_PuntoDeVenta(prm_codPuntoDeVenta);
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
        /// Retorna un LISTA de registros de la Entidad GestionComercial.PuntosDeVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.PuntosDeVenta]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEPuntoDeVenta> List(BaseFiltroPuntoDeVenta pFiltro)
        {
            List<BEPuntoDeVenta> lstPuntoDeVenta = new List<BEPuntoDeVenta>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PuntoDeVenta(pFiltro.codEmpresaRUC,
                                                          pFiltro.codPuntoVenta,
                                                          pFiltro.desNombre,
                                                          pFiltro.indEstado);
                    foreach (var item in resul)
                    {
                        BEPuntoDeVenta objPuntoDeVenta = new BEPuntoDeVenta();
                        objPuntoDeVenta.codPuntoDeVenta = item.codPuntoDeVenta;
                        objPuntoDeVenta.codPersonaEmpre = item.codPersonaEmpre;
                        objPuntoDeVenta.codEmpleadoRespon = item.codEmpleadoRespon;
                        objPuntoDeVenta.desNombre = item.desNombre;
                        objPuntoDeVenta.desPathFiles = item.desPathFiles;
                        objPuntoDeVenta.indActivo = item.indActivo;
                        objPuntoDeVenta.segUsuarioCrea = item.segUsuarioCrea;
                        objPuntoDeVenta.segUsuarioEdita = item.segUsuarioEdita;
                        objPuntoDeVenta.segFechaCrea = item.segFechaCrea;
                        objPuntoDeVenta.segFechaEdita = item.segFechaEdita;
                        objPuntoDeVenta.segMaquinaEdita = item.segMaquina;
                        objPuntoDeVenta.codPersonaEmpreNombre = item.auxcodPersonaEmpreNombre;
                        objPuntoDeVenta.codEmpleadoResponNombre = item.auxcodEmpleadoResponNombre;
                        objPuntoDeVenta.objPersonaEmpre.RazonSocial = item.auxcodPersonaEmpreNombre;
                        objPuntoDeVenta.objEmpleadoRespon.ApellidosNombres = item.auxcodEmpleadoResponNombre;

                        lstPuntoDeVenta.Add(objPuntoDeVenta);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPuntoDeVenta;
        }

        public List<BEPuntoDeVenta> ListPaginado(BaseFiltroPuntoDeVenta pFiltro)
        {
            List<BEPuntoDeVenta> lstPuntoDeVenta = new List<BEPuntoDeVenta>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PuntoDeVenta_Paged(pFiltro.jqCurrentPage,
                                                                pFiltro.jqPageSize,
                                                                pFiltro.jqSortColumn,
                                                                pFiltro.jqSortOrder,
                                                                pFiltro.codPuntoVenta,
                                                                pFiltro.codEmpresaRUC,
                                                                pFiltro.desNombre,
                                                                pFiltro.indEstado);
                    foreach (var item in resul)
                    {
                        BEPuntoDeVenta objPuntoDeVenta = new BEPuntoDeVenta();

                        objPuntoDeVenta.codPuntoDeVenta = item.codPuntoDeVenta;
                        objPuntoDeVenta.codPersonaEmpre = item.codPersonaEmpre;
                        objPuntoDeVenta.codEmpleadoRespon = item.codEmpleadoRespon;
                        objPuntoDeVenta.desNombre = item.desNombre;
                        objPuntoDeVenta.desPathFiles = item.desPathFiles;
                        objPuntoDeVenta.indActivo = item.indActivo;
                        objPuntoDeVenta.segUsuarioCrea = item.segUsuarioCrea;
                        objPuntoDeVenta.segUsuarioEdita = item.segUsuarioEdita;
                        objPuntoDeVenta.segFechaCrea = item.segFechaCrea;
                        objPuntoDeVenta.segFechaEdita = item.segFechaEdita;
                        objPuntoDeVenta.segMaquinaEdita = item.segMaquina;
                        objPuntoDeVenta.objPersonaEmpre.RazonSocial = item.auxcodPersonaEmpreNombre;
                        objPuntoDeVenta.objEmpleadoRespon.ApellidosNombres = item.auxcodEmpleadoResponNombre;

                        objPuntoDeVenta.ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0;
                        objPuntoDeVenta.TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0;
                        lstPuntoDeVenta.Add(objPuntoDeVenta);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPuntoDeVenta;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.PuntosDeVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.PuntosDeVenta]
        /// <summary>
        /// <param name="prm_codPuntoDeVenta"></param>
        /// <returns></returns>
        public BEPuntoDeVenta Find(string pcodEmpresaRUC, string pcodPuntoDeVenta)
        {
            BEPuntoDeVenta objPuntoDeVenta = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PuntoDeVenta(pcodEmpresaRUC, pcodPuntoDeVenta, null, null);
                    foreach (var item in resul)
                    {
                        objPuntoDeVenta = new BEPuntoDeVenta();
                        objPuntoDeVenta.codPuntoDeVenta = item.codPuntoDeVenta;
                        objPuntoDeVenta.codPersonaEmpre = item.codPersonaEmpre;
                        objPuntoDeVenta.codEmpleadoRespon = item.codEmpleadoRespon;
                        objPuntoDeVenta.desNombre = item.desNombre;
                        objPuntoDeVenta.desPathFiles = item.desPathFiles;
                        objPuntoDeVenta.indActivo = item.indActivo;
                        objPuntoDeVenta.segUsuarioCrea = item.segUsuarioCrea;
                        objPuntoDeVenta.segUsuarioEdita = item.segUsuarioEdita;
                        objPuntoDeVenta.segFechaCrea = item.segFechaCrea;
                        objPuntoDeVenta.segFechaEdita = item.segFechaEdita;
                        objPuntoDeVenta.segMaquinaEdita = item.segMaquina;
                        objPuntoDeVenta.codPersonaEmpreNombre = item.auxcodPersonaEmpreNombre;
                        objPuntoDeVenta.codEmpleadoResponNombre = item.auxcodEmpleadoResponNombre;
                        objPuntoDeVenta.objPersonaEmpre.RazonSocial = item.auxcodPersonaEmpreNombre;
                        objPuntoDeVenta.objEmpleadoRespon.ApellidosNombres = item.auxcodEmpleadoResponNombre;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objPuntoDeVenta;
        }

        #endregion

    }
} 

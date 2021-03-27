namespace CROM.GestionAlmacen.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Almacen;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 18/01/2012-04:29:35 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Almacen.DepositoData.cs]
    /// </summary>
    public class DepositoData
    {
        private string conexion = string.Empty;
        public DepositoData()
        {
            conexion = Util.ConexionBD();
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Deposito
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <param name="prm_codPersonaEmpre"></param>
        /// <param name="codPuntoDeVenta"></param>
        /// <param name="prm_desNombre"></param>
        /// <param name="prm_indActivo"></param>
        /// <returns></returns>
        public List<BEDeposito> List(BaseFiltroDeposito pFiltro) 
        {
            List<BEDeposito> lstDeposito = new List<BEDeposito>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Deposito(pFiltro.codEmpresa,
                                                      pFiltro.codEmpresaRUC,
                                                      pFiltro.codPuntoVenta,
                                                      string.Empty,
                                                      pFiltro.desNombre,
                                                      pFiltro.indEstado);
                    foreach (var item in resul)
                    {
                        BEDeposito objDeposito = new BEDeposito();
                        objDeposito.codDeposito = item.codDeposito;
                        objDeposito.objPuntoDeVenta.codPersonaEmpre = item.codPersonaEmpre;
                        objDeposito.codPuntoVenta = item.codPuntoDeVenta;
                        objDeposito.desNombre = item.desNombre;
                        objDeposito.codEmpleado = item.codEmpleado;
                        objDeposito.gloObservacion = item.gloObservacion;
                        objDeposito.indPrincipal = item.indPrincipal;
                        objDeposito.indActivo = item.indActivo;
                        objDeposito.segUsuarioCrea = item.segUsuarioCrea;
                        objDeposito.segUsuarioEdita = item.segUsuarioEdita;
                        objDeposito.segFechaCrea = item.segFechaCrea;
                        objDeposito.segFechaEdita = item.segFechaEdita;
                        objDeposito.segMaquinaCrea = item.segMaquina;
                        objDeposito.auxcodEmpleadoNombre = item.auxcodEmpleadoNombre;
                        objDeposito.auxcodPersonaEmpreNombre = item.auxcodPersonaEmpreNombre;
                        objDeposito.auxcodPuntoDeVentaNombre = item.auxcodPuntoDeVentaNombre;

                        objDeposito.objPuntoDeVenta.objPersonaEmpre.RazonSocial = item.auxcodPersonaEmpreNombre;
                        objDeposito.objPuntoDeVenta.desNombre = item.auxcodPuntoDeVentaNombre;
                        lstDeposito.Add(objDeposito);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDeposito;
        }
        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.Deposito
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <param name="prm_codDeposito"></param>
        /// <returns></returns>
        public BEDeposito Find(int pcodEmpresa, string prm_codDeposito)
        {
            BEDeposito objDeposito = null;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Deposito(pcodEmpresa, string.Empty, string.Empty, prm_codDeposito, string.Empty, null);
                    foreach (var item in resul)
                    {
                        objDeposito = new BEDeposito();

                        objDeposito.codDeposito = item.codDeposito;
                        objDeposito.objPuntoDeVenta.codPersonaEmpre = item.codPersonaEmpre;
                        objDeposito.codPuntoVenta = item.codPuntoDeVenta;
                        objDeposito.desNombre = item.desNombre;
                        objDeposito.codEmpleado = item.codEmpleado;
                        objDeposito.gloObservacion = item.gloObservacion;
                        objDeposito.indPrincipal = item.indPrincipal;
                        objDeposito.indActivo = item.indActivo;
                        objDeposito.segUsuarioCrea = item.segUsuarioCrea;
                        objDeposito.segUsuarioEdita = item.segUsuarioEdita;
                        objDeposito.segFechaCrea = item.segFechaCrea;
                        objDeposito.segFechaEdita = item.segFechaEdita;
                        objDeposito.segMaquinaCrea = item.segMaquina;
                        objDeposito.auxcodEmpleadoNombre = item.auxcodEmpleadoNombre;
                        objDeposito.auxcodPersonaEmpreNombre = item.auxcodPersonaEmpreNombre;
                        objDeposito.auxcodPuntoDeVentaNombre = item.auxcodPuntoDeVentaNombre;
                        
                        objDeposito.objPuntoDeVenta.objPersonaEmpre.RazonSocial = item.auxcodPersonaEmpreNombre;
                        objDeposito.objPuntoDeVenta.desNombre = item.auxcodPuntoDeVentaNombre;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objDeposito;
        }
       
        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Deposito
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <param name="itemDeposito"></param>
        /// <returns></returns>
        public string Insert(BEDeposito itemDeposito)
        {
            string codigoRetorno = null;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    SQLDC.omgc_I_Deposito(
                       ref codigoRetorno,
                       itemDeposito.codEmpresa,
                       itemDeposito.codPuntoVenta,
                       itemDeposito.desNombre,
                       itemDeposito.codEmpleado,
                       itemDeposito.gloObservacion,
                       itemDeposito.indPrincipal,
                       itemDeposito.indActivo,
                       itemDeposito.segUsuarioCrea);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Deposito
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <param name="pDeposito"></param>
        /// <returns></returns>
        public bool Update(BEDeposito pDeposito)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_Deposito(
                        pDeposito.codEmpresa,
                        pDeposito.codDeposito,
                        pDeposito.codPuntoVenta,
                        pDeposito.desNombre,
                        pDeposito.codEmpleado,
                        pDeposito.gloObservacion,
                        pDeposito.indPrincipal,
                        pDeposito.indActivo,
                        pDeposito.segUsuarioEdita
                        );
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
        /// ELIMINA un registro de la Entidad Almacen.Deposito
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <param name="pcodDeposito"></param>
        /// <returns></returns>
        public bool Delete(int pcodEmpresa, string pcodDeposito)
        {
            int codigoRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    SQLDC.omgc_D_Deposito(pcodEmpresa, pcodDeposito);
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

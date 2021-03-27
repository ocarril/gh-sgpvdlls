namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Cajas;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 14/11/2010-6:34:47
    /// Descripcion : Capa de Datos 
    /// Archivo     : [CajaBancos.CajaRegistroData.cs]
    /// </summary>
    public class CajaRegistroData
    {
        private string conexion = string.Empty;

        public CajaRegistroData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        ///// <summary>
        ///// Almacena el registro de una ENTIDAD de registro de Tipo ComprobanteEmitidos
        ///// En la BASE de DATO la Tabla : [CajaBancos.ComprobanteEmitidos]
        ///// <summary>
        ///// <param name = >itemCajaRegistro</param>
        //public bool Insert(CajaRegistroAux itemCajaRegistro)
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_CajaBancosDataContext SQLDC = new _CajaBancosDataContext(conexion))
        //        {
        //            codigoRetorno = SQLDC.omgc_I_CajaRegistro(
        //                itemCajaRegistro.codDocumReg,
        //                itemCajaRegistro.codEmpresaRUC,
        //                itemCajaRegistro.codPuntoDeVenta,
        //                itemCajaRegistro.codDocumento,
        //                itemCajaRegistro.numDocumento,
        //                itemCajaRegistro.codEmpleado,
        //                itemCajaRegistro.codParteDiario,
        //                itemCajaRegistro.codFormaDePago,
        //                itemCajaRegistro.fecIngreso,
        //                itemCajaRegistro.codRegistroMoneda,
        //                itemCajaRegistro.monImporteRecibido,
        //                itemCajaRegistro.monImportePagado,
        //                itemCajaRegistro.monImportePagadoEx,
        //                itemCajaRegistro.monImporteVuelto,
        //                itemCajaRegistro.monTCambioVTA,
        //                itemCajaRegistro.monTCambioCMP,
        //                itemCajaRegistro.gloObservacion,
        //                itemCajaRegistro.segUsuarioCrea,
        //                itemCajaRegistro.codDocumRegPagoCredito);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == 0 ? true : false;
        //}

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad CajaBancos.CajaRegistro
        /// En la BASE de DATO la Tabla : [CajaBancos.CajaRegistro]
        /// </summary>
        /// <param name="itemCajaRegistro"></param>
        /// <returns></returns>
        public bool Delete(string prm_codEmpresaRUC, int prm_numItem, int prm_codDocumReg)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CajaBancosDataContext SQLDC = new _CajaBancosDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_CajaRegistro(prm_codEmpresaRUC, prm_numItem, prm_codDocumReg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
     
        public bool Delete(string prm_codEmpresaRUC, int prm_codDocumReg)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CajaBancosDataContext SQLDC = new _CajaBancosDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_CajaRegistro_Varios(prm_codEmpresaRUC, prm_codDocumReg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de SELECT ALL*/

        ///// <summary>
        ///// Retorna una LISTA de registro de la Entidad CajaBancos.ComprobanteEmitidos POR FOREIGN KEY
        ///// En la BASE de DATO la Tabla : [CajaBancos.ComprobanteEmitidos]
        ///// <summary>
        ///// <returns>Entidad</returns>
        //public List<CajaRegistroAux> List(int pcodEmpresa, string prm_fecIngresoInicio, string prm_fecIngresoFinal, 
        //                                  int? prm_codDocumReg, string prm_codRegistroDestinoComp, 
        //                                  string prm_codPersonaEntidad, int? prm_codEmpleado, 
        //                                  string prm_codRegistroMoneda, string prm_codParteDiario, 
        //                                  string prm_codFormaDePago, bool? prm_indConciliado)
        //{
        //    List<CajaRegistroAux> lstCajaRegistro = new List<CajaRegistroAux>();
        //    try
        //    {
        //        using (_CajaBancosDataContext SQLDC = new _CajaBancosDataContext(conexion))
        //        {
        //            var resul = SQLDC.omgc_S_CajaRegistro(pcodEmpresa, prm_fecIngresoInicio, prm_fecIngresoFinal, 
        //                                                  prm_codDocumReg, prm_codRegistroDestinoComp, 
        //                                                  prm_codPersonaEntidad, prm_codEmpleado, 
        //                                                  prm_codRegistroMoneda, prm_codParteDiario, 
        //                                                  prm_codFormaDePago, prm_indConciliado);
        //            foreach (var item in resul)
        //            {
        //                lstCajaRegistro.Add(new CajaRegistroAux()
        //                {
        //                    numItem = item.numItem,
        //                    codDocumReg = item.codDocumReg,
        //                    codEmpresa= item.codEmpresa.HasValue? item.codEmpresa.Value:0,
        //                    codEmpresaRUC = item.codPersonaEmpre,
        //                    codPuntoDeVenta = item.codPuntoDeVenta,
        //                    codDocumento = item.codDocumento,
        //                    numDocumento = item.numDocumento,
        //                    codEmpleado = item.codEmpleado,
        //                    codParteDiario = item.codParteDiario,
        //                    codFormaDePago = item.codFormaDePago.HasValue ? item.codFormaDePago.Value : 0,
        //                    fecIngreso = item.fecIngreso,
        //                    codRegistroMoneda = item.codRegistroMoneda,
        //                    monImporteRecibido = item.monImporteRecibido == null ? 0 : item.monImporteRecibido.Value,
        //                    monImportePagado = item.monImportePagado == null ? 0 : item.monImportePagado.Value,
        //                    monImportePagadoEx = item.monImportePagadoEx == null ? 0 : item.monImportePagadoEx.Value,
        //                    monImporteVuelto = item.monImporteVuelto == null ? 0 : item.monImporteVuelto.Value,
        //                    monTCambioVTA = item.monTCambioVTA,
        //                    monTCambioCMP = item.monTCambioCMP,
        //                    gloObservacion = item.gloObservacion,
        //                    indConciliado = item.indConciliado,
        //                    segUsuarioCrea = item.segUsuarioCrea,
        //                    segUsuarioEdita = item.segUsuarioEdita,
        //                    segFechaCrea = item.segFechaCrea,
        //                    segFechaEdita = item.segFechaEdita,
        //                    segMaquina = item.segMaquina,
        //                    auxcodEmpleadoNombre = item.auxcodEmpleadoNombre,
        //                    auxcodFormaDePagoNombre = item.auxcodFormaDePagoNombre,
        //                    auxcodRegistroMonedaNombre = item.auxcodRegistroMonedaNombre,
        //                    auxcodDocumentoNombre = item.auxcodDocumentoNombre,
        //                    auxcodPuntoDeVentaNombre = item.auxcodPuntoDeVentaNombre,
        //                    codDocumRegPagoCredito = item.codLetraDeCambio,
        //                    fecVencimientoLetra = item.fecVencimientoLetra,
        //                    auxnumLetraExterno = item.numLetraExterno
        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstCajaRegistro;
        //}

        #endregion

        #region /* Proceso de UPDATE*/
        /// <summary>
        /// ACTUALIZA el registro de una ENTIDAD de registro de Tipo CajaRegistro
        /// En la BASE de DATO la Tabla : [CajaBancos.CajaRegistro]
        /// <summary>
        /// <param name = >itemParteDiario</param>
        public bool UpdateCajaClose(CajaRegistroAux itemCajaRegistro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CajaBancosDataContext SQLDC = new _CajaBancosDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_CajaRegistro_Conciliar(
                        itemCajaRegistro.codEmpresaRUC,
                        itemCajaRegistro.codDocumReg,
                        itemCajaRegistro.codParteDiario,
                        itemCajaRegistro.indConciliado,
                        itemCajaRegistro.segUsuarioEdita
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
    }
} 

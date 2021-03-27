namespace CROM.GestionComercial.BusinessLogic
{
    using CROM.BusinessEntities.Cajas;
    using CROM.BusinessEntities.Comercial;
    using CROM.GestionComercial.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Config;

    using System;
    using System.Collections.Generic;
    using System.Transactions;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 14/11/2010-6:34:49
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [CajaBancos.ComprobanteEmitidosLogic.cs]
    /// </summary>
    public class CajaRegistroLogic
    {
        private CajaRegistroData oCajaRegistroData = null;
        private ComprobanteEmisionData oComprobanteEmisionData = null;
        private ReturnValor oReturnValor = null;
        public CajaRegistroLogic()
        {
            oCajaRegistroData = new CajaRegistroData();
            oComprobanteEmisionData = new ComprobanteEmisionData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT BY ID CODE FOREIGN KEY*/

        ///// <summary>
        ///// Retorna una LISTA de registro de la Entidad CajaBancos.ComprobanteEmitidos POR FOREIGN KEY
        ///// En la BASE de DATO la Tabla : [CajaBancos.ComprobanteEmitidos]
        ///// <summary>
        ///// <returns>Entidad</returns>
        //public List<CajaRegistroAux> List(int pcodEmpresa, Nullable<DateTime> prm_fecIngresoInicio, 
        //                                  Nullable<DateTime> prm_fecIngresoFinal, int? prm_codDocumReg, 
        //                                  string prm_codRegistroDestinoComp, string prm_codPersonaEntidad, 
        //                                  int? prm_codEmpleado, string prm_codRegistroMoneda, 
        //                                  string prm_codParteDiario, string prm_codFormaDePago, 
        //                                  bool? prm_indConciliado)
        //{
        //    List<CajaRegistroAux> listaCajaRegistro = new List<CajaRegistroAux>();
        //    try
        //    {
        //        listaCajaRegistro = oCajaRegistroData.List(pcodEmpresa,
        //               HelpTime.ConvertYYYYMMDD(prm_fecIngresoInicio),
        //               HelpTime.ConvertYYYYMMDD(prm_fecIngresoFinal),
        //               prm_codDocumReg,
        //               prm_codRegistroDestinoComp,
        //               prm_codPersonaEntidad,
        //               prm_codEmpleado,
        //               prm_codRegistroMoneda,
        //               prm_codParteDiario,
        //               prm_codFormaDePago,
        //               prm_indConciliado);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return listaCajaRegistro;
        //}

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ComprobanteEmitidos
        /// En la BASE de DATO la Tabla : [CajaBancos.ComprobanteEmitidos]
        /// </summary>
        /// <param name="itemComprobanteEmitidos"></param>
        /// <param name="comprobanteEmision"></param>
        /// <returns></returns>
        public ReturnValor PagarEfectivo(CajaRegistroAux cajaRegistro, BEComprobanteEmision comprobanteEmision, 
                                         decimal prm_MontoPagadoMN, decimal prm_MontoPagadoMI, 
                                         decimal prm_SaldoActualMN, decimal prm_SaldoActualMI)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    //oReturnValor.Exitosa = oCajaRegistroData.Insert(cajaRegistro);
                    bool SUCEDE_OK = true;
                    bool SUCEDE_CT = true;
                    decimal DIFERENCIA = 0;
                    if (cajaRegistro.codRegistroMoneda == ConfigCROM.AppConfig(cajaRegistro.codEmpresa, ConfigTool.DEFAULT_MonedaNac))
                    {
                        if (prm_MontoPagadoMN < 0)
                            prm_MontoPagadoMN = prm_MontoPagadoMN * (-1);
                        decimal pagadoHastaAhora = prm_MontoPagadoMN + cajaRegistro.monImportePagado;
                        if (pagadoHastaAhora == comprobanteEmision.ValorTotalPrecioVenta)
                            SUCEDE_OK = oComprobanteEmisionData.UpdateCancelacion(comprobanteEmision.codDocumReg, comprobanteEmision.CodigoArguEstadoDocu, cajaRegistro.gloObservacion, cajaRegistro.fecIngreso, cajaRegistro.codParteDiario, cajaRegistro.segUsuarioCrea);
                    }
                    else
                    {
                        if (prm_SaldoActualMI == cajaRegistro.monImportePagadoEx)
                            SUCEDE_OK = oComprobanteEmisionData.UpdateCancelacion(comprobanteEmision.codDocumReg, comprobanteEmision.CodigoArguEstadoDocu, cajaRegistro.gloObservacion, cajaRegistro.fecIngreso, cajaRegistro.codParteDiario, cajaRegistro.segUsuarioCrea);

                    }

                    CuentasCorrientesData oCuentasCorrientesData = new CuentasCorrientesData();
                    BECuentaCorriente cuentacorriente = new BECuentaCorriente
                    {
                        codEmpresa = comprobanteEmision.codEmpresa,
                        codDocumReg = comprobanteEmision.codDocumReg,
                        CodigoArguDestinoComp = comprobanteEmision.CodigoArguDestinoComp,
                        CodigoArguMoneda = comprobanteEmision.CodigoArguMoneda,
                        CodigoArguTipoMovimi = comprobanteEmision.CodigoArguTipoDeOperacion,
                        CodigoComprobante = comprobanteEmision.CodigoComprobante,
                        codEmpleado = cajaRegistro.codEmpleado,
                        CodigoPersonaEmpre = comprobanteEmision.CodigoPersonaEmpre,
                        CodigoPuntoVenta = cajaRegistro.codPuntoDeVenta,
                        DEBETipoCambioVTA = cajaRegistro.monTCambioVTA,
                        DEBETipoCambioCMP = cajaRegistro.monTCambioCMP,
                        DEBETotalCuotaNacion = cajaRegistro.monImportePagado,
                        DEBETotalCuotaExtran = cajaRegistro.monImportePagadoEx,
                        Estado = true,
                        NumeroComprobante = comprobanteEmision.NumeroComprobante,
                        FechaDeEmisionDeuda = cajaRegistro.fecIngreso,
                        FechaDeVencimiento = comprobanteEmision.FechaDeEmision,
                        NumeroDeCuota = 0,
                        Observaciones = comprobanteEmision.Observaciones == null ? 
                            "Registro automático desde Pago en efectivo - " : 
                            "Registro automático desde Pago en efectivo - " + comprobanteEmision.Observaciones,
                        SegUsuarioCrea = comprobanteEmision.SegUsuarioCrea,
                        SegUsuarioEdita = comprobanteEmision.SegUsuarioCrea,
                        DHDiferenciaMonto = DIFERENCIA,
                        TipoDeIngreso = comprobanteEmision.CodigoArguTipoDeOperacion == 
                                        ConfigCROM.AppConfig(cajaRegistro.codEmpresa, ConfigTool.DEFAULT_Movim_Venta) ? "H" : "D",
                        CodigoParte = comprobanteEmision.CodigoParte
                    };

                    SUCEDE_CT = oCuentasCorrientesData.Insert(cuentacorriente) == null ? false : true;

                    if (oReturnValor.Exitosa && SUCEDE_OK && SUCEDE_CT)
                    {
                        oReturnValor.Message = HelpMessages.gc_DOCUM_YA_CANCELADO;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        public ReturnValor DeshacerPagoEfectivo(BaseFiltro pDatos)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oComprobanteEmisionData.UpdateCancelacionDeshacer(pDatos);

                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.gc_DOCUM_YA_CANCELADO;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }
        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad CajaBancos.ComprobanteEmitidos
        /// En la BASE de DATO la Tabla : [CajaBancos.ComprobanteEmitidos]
        /// </summary>
        /// <param name="prm_CodigoPersonaEmpre"></param>
        /// <param name="prm_CodigoPuntoVenta"></param>
        /// <param name="prm_CodigoComprobante"></param>
        /// <param name="prm_NumeroComprobante"></param>
        /// <returns></returns>
        public ReturnValor Delete(int pcodEmpresa, string pcodEmpresaRUC, int prm_numItem, int prm_codDocumReg, string prm_codDocumento, bool prm_CAMBIA_ESTADO, string prm_CodigoParte, string prm_UsuarioEdita)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    bool SUCEDE_OK = true;
                    bool SUCEDE_CT = true;
                    CuentasCorrientesData oCuentasCorrientesData = new CuentasCorrientesData();
                    SUCEDE_CT = oCuentasCorrientesData.DeleteCodDocumReg(pcodEmpresa, 
                                                              prm_codDocumReg, 
                                                              prm_CodigoParte,
                                                              prm_UsuarioEdita);

                    oReturnValor.Exitosa = oCajaRegistroData.Delete(pcodEmpresaRUC, prm_numItem, prm_codDocumReg);
                    if (prm_CAMBIA_ESTADO)
                    {
                        BEDocumento itemComprobantes = new DocumentoData().Find(prm_codDocumento, pcodEmpresaRUC);
                        SUCEDE_OK = oComprobanteEmisionData.UpdateEmitido(prm_codDocumReg, 
                                                                          itemComprobantes.CodigoArguEstEMIDefault, 
                                                                          string.Empty, 
                                                                          prm_UsuarioEdita);
                    }
                    if (oReturnValor.Exitosa && SUCEDE_OK && SUCEDE_CT)
                    {
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion
    }
} 

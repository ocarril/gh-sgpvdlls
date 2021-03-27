namespace CROM.GestionComercial.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Transactions;

    using CROM.BusinessEntities.Comercial;
    using CROM.GestionComercial.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Config;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 06/02/2012-03:37:18 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [GestionComercial.GastoDeAduanaLogic.cs]
    /// </summary>
    public class GastoDeAduanaLogic
    {
        private GastoDeAduanaData oGastoDeAduanaData = null;
        private ReturnValor oReturnValor = null;
        public GastoDeAduanaLogic()
        {
            oGastoDeAduanaData = new GastoDeAduanaData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.GastoDeAduana
        /// En la BASE de DATO la Tabla : [GestionComercial.GastoDeAduana]
        /// <summary>
        /// <returns>List</returns>
        public List<GastoDeAduanaAux> List(Nullable<DateTime> prm_FecInicio, Nullable<DateTime> prm_FecFinal, string prm_codPersonaEmpre, string prm_codPuntoDeVenta, string prm_codPersonaEntidad, string prm_codDocumento, string prm_numDocumento, string prm_codRegistroGasto, bool? indCancelado)
        {
            List<GastoDeAduanaAux> lstGastoDeAduana = new List<GastoDeAduanaAux>();
            try
            {
                lstGastoDeAduana = oGastoDeAduanaData.List(HelpTime.ConvertYYYYMMDD(prm_FecInicio), HelpTime.ConvertYYYYMMDD(prm_FecFinal), prm_codPersonaEmpre, prm_codPuntoDeVenta, prm_codPersonaEntidad, prm_codDocumento, prm_numDocumento, prm_codRegistroGasto, indCancelado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstGastoDeAduana;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo GastoDeAduana
        /// En la BASE de DATO la Tabla : [GestionComercial.GastoDeAduana]
        /// <summary>
        /// <param name = >itemGastoDeAduana</param>
        public ReturnValor InsertUpdate(GastoDeAduanaAux itemGastoDeAduana)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (string.IsNullOrEmpty(itemGastoDeAduana.codDocumentoDest))
                        itemGastoDeAduana.codDocumentoDest = null;
                    if (string.IsNullOrEmpty(itemGastoDeAduana.numDocumentoDest))
                        itemGastoDeAduana.numDocumentoDest = null;

                    if (itemGastoDeAduana.codDocumentoDest != null && itemGastoDeAduana.numDocumentoDest != null)
                    {
                        ComprobanteEmisionData comprobanteEmisionData = new ComprobanteEmisionData();
                        BEComprobanteEmision comprobanteEmision = new BEComprobanteEmision();
                        comprobanteEmision = comprobanteEmisionData.Find(itemGastoDeAduana.codDocumRegDestino);
                        if (itemGastoDeAduana.codRegistroMoneda != comprobanteEmision.CodigoArguMoneda)
                            throw new Exception("El gasto a registrar no tiene el mismo tipo de moneda del documento asigando.");
                        if (itemGastoDeAduana.codRegistroMoneda == ConfigCROM.AppConfig(ConfigTool.DEFAULT_MonedaNac))
                        {
                            if (itemGastoDeAduana.monValorDeGasto != comprobanteEmision.ValorTotalPrecioVenta)
                                throw new Exception("El monto del gasto a registrar no es igual que el documento asigando.  Se esperaba el monto de : [ " + comprobanteEmision.ValorTotalPrecioVenta.ToString("N2") + " ]");
                        }
                        else if (itemGastoDeAduana.codRegistroMoneda == ConfigCROM.AppConfig(ConfigTool.DEFAULT_MonedaInt))
                        {
                            if (itemGastoDeAduana.monValorDeGasto != comprobanteEmision.ValorTotalPrecioExtran)
                                throw new Exception("El monto del gasto a registrar no es igual que el documento asigando.  Se esperaba el monto de : [ " + comprobanteEmision.ValorTotalPrecioExtran.ToString("N2") + " ]");
                        }
                    }

                    int? resultado = null;

                    if (itemGastoDeAduana.codGastoDeAduana == 0)
                    {
                        resultado = oGastoDeAduanaData.Insert(itemGastoDeAduana);
                        if (resultado != null)
                        {
                            itemGastoDeAduana.codGastoDeAduana = resultado.Value;
                            oReturnValor.Exitosa = GuardaRefDocumento(itemGastoDeAduana, resultado);
                        }
                        if (oReturnValor.Exitosa && resultado != null)
                        {
                            oReturnValor.Message = HelpMessages.Evento_NEW;
                            tx.Complete();
                        }
                    }
                    else if (itemGastoDeAduana.codGastoDeAduana > 0)
                    {
                        bool resultadoB = oGastoDeAduanaData.Update(itemGastoDeAduana);
                        oReturnValor.Exitosa = GuardaRefDocumento(itemGastoDeAduana, itemGastoDeAduana.codGastoDeAduana);
                        if (oReturnValor.Exitosa && resultadoB)
                        {
                            oReturnValor.Message = HelpMessages.Evento_EDIT;
                            tx.Complete();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor.Message = ex.Message;
            }
            return oReturnValor;
        }

        private bool GuardaRefDocumento(GastoDeAduanaAux itemGastoDeAduana, int? codGastoDeAduana)
        {
            ComprobanteEmisionData comprobanteEmisionData = new ComprobanteEmisionData();
            bool exitosa = comprobanteEmisionData.UpdateAsignaGastoDeAduana(itemGastoDeAduana.codDocumRegDestino,

                                                             codGastoDeAduana.Value,
                                                             itemGastoDeAduana.segUsuarioEdita);
            return exitosa;
        }

        public ReturnValor DesAsignaGastoDeAduana(GastoDeAduanaAux gastoDeAduana, int? prm_codGastoDeAduana)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    ComprobanteEmisionData comprobanteEmisionData = new ComprobanteEmisionData();
                    bool exitosa = comprobanteEmisionData.UpdateAsignaGastoDeAduanaDeshace(gastoDeAduana.codDocumRegDestino,
                                                                     prm_codGastoDeAduana.Value,
                                                                     gastoDeAduana.segUsuarioEdita);
                    oReturnValor.Exitosa = oGastoDeAduanaData.Delete(gastoDeAduana.codDocumReg, gastoDeAduana.codRegistroGasto, gastoDeAduana.segUsuarioEdita, false);
                    if (oReturnValor.Exitosa && exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_EDIT;
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
        /// ELIMINA un registro de la Entidad GestionComercial.GastoDeAduana
        /// En la BASE de DATO la Tabla : [GestionComercial.GastoDeAduana]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(GastoDeAduanaAux gastoDeAduana)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oGastoDeAduanaData.Delete(gastoDeAduana.codDocumReg, gastoDeAduana.codRegistroGasto, gastoDeAduana.segUsuarioEdita, true);

                    ComprobanteEmisionData comprobanteEmisionData = new ComprobanteEmisionData();
                    bool sucede = comprobanteEmisionData.UpdateAsignaGastoDeAduanaDeshace(gastoDeAduana.codDocumRegDestino, gastoDeAduana.codGastoDeAduana, gastoDeAduana.segUsuarioEdita);
                    if (oReturnValor.Exitosa && sucede)
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

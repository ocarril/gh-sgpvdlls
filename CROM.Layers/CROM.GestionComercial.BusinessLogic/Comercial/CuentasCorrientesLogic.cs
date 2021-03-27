namespace CROM.GestionComercial.BusinessLogic
{
    using CROM.BusinessEntities.Comercial;
    using CROM.GestionComercial.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using static CROM.Tools.Comun.Web.WebConstants;

    using System;
    using System.Collections.Generic;
    using System.Transactions;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 25/08/2010-3:28:34
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [GestionComercial.CuentasCorrientesLogic.cs]
    /// </summary>
    public class CuentasCorrientesLogic
    {
        private CuentasCorrientesData oCuentasCorrientesData = null;
        private ReturnValor oReturnValor = null;

        public CuentasCorrientesLogic()
        {
            oCuentasCorrientesData = new CuentasCorrientesData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.CuentasCorrientes
        /// En la BASE de DATO la Tabla : [GestionComercial.CuentasCorrientes]
        /// <summary>
        /// <returns>List</returns>
        public List<BECuentaCorriente> List(int prm_codEmpresa, 
                                            Nullable<DateTime> prm_FechaDeINICIO, Nullable<DateTime> prm_FechaDeFINAL, 
                                            string prm_CodigoPuntoVenta, 
                                            string prm_CodigoPersonaEntidad, 
                                            string prm_CodigoComprobante, 
                                            string prm_NumeroComprobante, 
                                            string prm_CodigoArguDestinoComp, 
                                            bool? prm_Estado)
        {
            List<BECuentaCorriente> lstCuentaCorriente = new List<BECuentaCorriente>();
            try
            {
                lstCuentaCorriente = oCuentasCorrientesData.List(prm_codEmpresa,
                                                                 HelpTime.ConvertYYYYMMDD(prm_FechaDeINICIO), 
                                                                 HelpTime.ConvertYYYYMMDD(prm_FechaDeFINAL), 
                                                                 prm_CodigoPuntoVenta, 
                                                                 prm_CodigoPersonaEntidad, 
                                                                 prm_CodigoComprobante, 
                                                                 prm_NumeroComprobante, 
                                                                 prm_CodigoArguDestinoComp, 
                                                                 prm_Estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCuentaCorriente;
        }

        public List<BECuentaCorriente> ListConCuadre(int prm_codEmpresa, 
                                                     Nullable<DateTime> prm_FechaDeINICIO, 
                                                     Nullable<DateTime> prm_FechaDeFINAL,
                                                     string prm_CodigoPuntoVenta, 
                                                     string prm_CodigoPersonaEntidad, 
                                                     string prm_CodigoComprobante, 
                                                     string prm_NumeroComprobante, 
                                                     string prm_CodigoArguDestinoComp, 
                                                     bool? prm_Estado)
        {
            List<BECuentaCorriente> lstCuentaCorriente = new List<BECuentaCorriente>();
            try
            {
                lstCuentaCorriente = oCuentasCorrientesData.ListConCuadre(prm_codEmpresa, 
                                                                          HelpTime.ConvertYYYYMMDD(prm_FechaDeINICIO), 
                                                                          HelpTime.ConvertYYYYMMDD(prm_FechaDeFINAL), 
                                                                          prm_CodigoPuntoVenta, 
                                                                          prm_CodigoPersonaEntidad, 
                                                                          prm_CodigoComprobante, 
                                                                          prm_NumeroComprobante, 
                                                                          prm_CodigoArguDestinoComp, 
                                                                          prm_Estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCuentaCorriente;
        }
        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.CuentasCorrientes
        /// En la BASE de DATO la Tabla : [GestionComercial.CuentasCorrientes]
        /// <summary>
        /// <returns>Entidad</returns>
        public BECuentaCorriente Find(int pcodEmpresa, string prm_NumeroOperacion)
        {
            BECuentaCorriente miEntidad = new BECuentaCorriente();
            try
            {
                miEntidad = oCuentasCorrientesData.Find(pcodEmpresa, prm_NumeroOperacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miEntidad;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo CuentasCorrientes
        /// En la BASE de DATO la Tabla : [GestionComercial.CuentasCorrientes]
        /// <summary>
        /// <param name = >itemCuentasCorrientes</param>
        public ReturnValor Insert(BECuentaCorriente pcuentaCorriente)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    
                    oReturnValor.CodigoRetorno = oCuentasCorrientesData.Insert(pcuentaCorriente);
                    if (oReturnValor.CodigoRetorno != null)
                    {
                        oReturnValor.Exitosa = true;
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
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

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo CuentasCorrientes
        /// En la BASE de DATO la Tabla : [GestionComercial.CuentasCorrientes]
        /// <summary>
        /// <param name = >itemCuentasCorrientes</param>
        //public ReturnValor Update(BECuentaCorriente itemCuentasCorrientes)
        //{
        //    try
        //    {
        //        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
        //        {
        //            oReturnValor.Exitosa = oCuentasCorrientesData.Update(itemCuentasCorrientes);
        //            if (oReturnValor.Exitosa)
        //            {
        //                oReturnValor.Message = HelpMessages.Evento_EDIT;
        //                tx.Complete();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oReturnValor = HelpException.mTraerMensaje(ex);
        //    }
        //    return oReturnValor;
        //}

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.CuentasCorrientes
        /// En la BASE de DATO la Tabla : [GestionComercial.CuentasCorrientes]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(int pcodEmpresa, int prm_codDocumReg, string prm_CodigoParte, string prmUserDelete)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oCuentasCorrientesData.DeleteCodDocumReg(pcodEmpresa, 
                                                                         prm_codDocumReg, 
                                                                         prm_CodigoParte,
                                                                         prmUserDelete);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
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

namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 06/02/2012-03:37:18 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.GastoDeAduanaData.cs]
    /// </summary>
    public class GastoDeAduanaData
    {
        private string conexion = string.Empty;
        public GastoDeAduanaData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de FIND */

        ///// <summary>
        ///// Retorna un LISTA de registros de la Entidad GestionComercial.GastoDeAduana
        ///// En la BASE de DATO la Tabla : [GestionComercial.GastoDeAduana]
        ///// <summary>
        ///// <returns>List</returns>
        //public GastoDeAduanaAux Find(int codGastoDeAduana)
        //{
        //    GastoDeAduanaAux gastoDeAduana = new GastoDeAduanaAux();
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            var resul = SQLDC.omgc_mnt_Find_GastoDeAduana(codGastoDeAduana);
        //            foreach (var item in resul)
        //            {
        //                gastoDeAduana = new GastoDeAduanaAux()
        //                {
        //                    codDocumReg = item.codDocumReg,
        //                    codDocumRegDestino = item.codDocumRegDestino,
        //                    codGastoDeAduana = item.codGastoDeAduana,
        //                    codPersonaEmpre = item.codPersonaEmpre,
        //                    codPuntoDeVenta = item.codPuntoDeVenta,
        //                    codDocumento = item.codDocumento,
        //                    numDocumento = item.numDocumento,
        //                    codRegistroGasto = item.codRegistroGasto,
        //                    monValorDeGasto = item.monValorDeGasto,
        //                    fecDePago = item.fecDePago,
        //                    gloComentario = item.gloComentario,
        //                    indCancelado = item.indCancelado,
        //                    segUsuarioCrea = item.segUsuarioCrea,
        //                    segUsuarioEdita = item.segUsuarioEdita,
        //                    segFechaCrea = item.segFechaCrea,
        //                    segFechaEdita = item.segFechaEdita,
        //                    segMaquina = item.segMaquina,
        //                    codRegistroMoneda = item.codRegistroMoneda,
        //                    codDocumentoDest = item.codDocumentoDest,
        //                    numDocumentoDest = item.numDocumentoDest,
        //                    codPersonaEmpreDest = item.codPersonaEmpreDest,
        //                    codPuntoDeVentaDest = item.codPuntoDeVentaDest,

        //                    auxcodPersonaEmpreNombre = item.auxcodPersonaEmpreNombre,
        //                    auxcodRegistroGastoNombre = item.auxcodRegistroGastoNombre,

        //                    auxFechaDeEmisionFactura = item.auxFechaDeEmisionFactura,
        //                    auxcodRegistroMonedaNombre = item.auxcodRegistroMonedaNombre,
        //                    auxcodPersonaEntidad = item.auxCodigoPersonaEntidad,
        //                    auxcodPersonaEntidadNombre = item.auxCodigoPersonaEntidadNombre,
        //                    auxmonValorTipoCambioCMP = item.auxmonValorTipoCambioCMP,
        //                    auxmonValorTipoCambioVTA = item.auxmonValorTipoCambioVTA,
        //                    auxnumNumeroComprobanteExt = item.auxnumNumeroComprobanteExt,

        //                    auxFechaDeEmisionFacturaDest = item.auxFechaDeEmisionFacturaDest,
        //                    auxcodRegistroMonedaNombreDest = item.auxcodRegistroMonedaNombreDest,
        //                    auxcodPersonaEntidadDest = item.auxCodigoPersonaEntidadDest,
        //                    auxcodPersonaEntidadNombreDest = item.auxCodigoPersonaEntidadNombreDest,
        //                    auxmonValorTipoCambioCMPDest = item.auxmonValorTipoCambioCMPDest,
        //                    auxmonValorTipoCambioVTADest = item.auxmonValorTipoCambioVTADest,
        //                    auxnumNumeroComprobanteExtDest = item.auxnumNumeroComprobanteExtDest

        //                };
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return gastoDeAduana;
        //}

        #endregion
        #region /* Proceso de SELECT ALL */

        ///// <summary>
        ///// Retorna un LISTA de registros de la Entidad GestionComercial.GastoDeAduana
        ///// En la BASE de DATO la Tabla : [GestionComercial.GastoDeAduana]
        ///// <summary>
        ///// <returns>List</returns>
        //public List<GastoDeAduanaAux> List(string prm_FecInicio, string prm_FecFinal, string prm_codPersonaEmpre, string prm_codPuntoDeVenta, string prm_codPersonaEntidad, string prm_codDocumento, string prm_numDocumento, string prm_codRegistroGasto, bool? indCancelado)
        //{
        //    List<GastoDeAduanaAux> lstGastoDeAduana = new List<GastoDeAduanaAux>();
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            var resul = SQLDC.omgc_mnt_GetAll_GastoDeAduana(prm_FecInicio, prm_FecFinal, prm_codPersonaEmpre, prm_codPuntoDeVenta, prm_codPersonaEntidad, prm_codDocumento, prm_numDocumento, prm_codRegistroGasto, indCancelado);
        //            foreach (var item in resul)
        //            {
        //                lstGastoDeAduana.Add(new GastoDeAduanaAux()
        //                {
        //                    codDocumReg = item.codDocumReg,
        //                    codDocumRegDestino = item.codDocumRegDestino,
        //                    codGastoDeAduana = item.codGastoDeAduana,
        //                    codPersonaEmpre = item.codPersonaEmpre,
        //                    codPuntoDeVenta = item.codPuntoDeVenta,
        //                    codDocumento = item.codDocumento,
        //                    numDocumento = item.numDocumento,
        //                    codRegistroGasto = item.codRegistroGasto,
        //                    monValorDeGasto = item.monValorDeGasto,
        //                    fecDePago = item.fecDePago,
        //                    gloComentario = item.gloComentario,
        //                    indCancelado = item.indCancelado,
        //                    segUsuarioCrea = item.segUsuarioCrea,
        //                    segUsuarioEdita = item.segUsuarioEdita,
        //                    segFechaCrea = item.segFechaCrea,
        //                    segFechaEdita = item.segFechaEdita,
        //                    segMaquina = item.segMaquina,
        //                    codRegistroMoneda = item.codRegistroMoneda,
        //                    codDocumentoDest = item.codDocumentoDest,
        //                    numDocumentoDest = item.numDocumentoDest,
        //                    codPersonaEmpreDest = item.codPersonaEmpreDest,
        //                    codPuntoDeVentaDest = item.codPuntoDeVentaDest,

        //                    auxcodPersonaEmpreNombre = item.auxcodPersonaEmpreNombre,
        //                    auxcodRegistroGastoNombre = item.auxcodRegistroGastoNombre,

        //                    auxFechaDeEmisionFactura = item.auxFechaDeEmisionFactura,
        //                    auxcodRegistroMonedaNombre = item.auxcodRegistroMonedaNombre,
        //                    auxcodPersonaEntidad = item.auxCodigoPersonaEntidad,
        //                    auxcodPersonaEntidadNombre = item.auxCodigoPersonaEntidadNombre,
        //                    auxmonValorTipoCambioCMP = item.auxmonValorTipoCambioCMP,
        //                    auxmonValorTipoCambioVTA = item.auxmonValorTipoCambioVTA,
        //                    auxnumNumeroComprobanteExt = item.auxnumNumeroComprobanteExt,

        //                    auxFechaDeEmisionFacturaDest = item.auxFechaDeEmisionFacturaDest,
        //                    auxcodRegistroMonedaNombreDest = item.auxcodRegistroMonedaNombreDest,
        //                    auxcodPersonaEntidadDest = item.auxCodigoPersonaEntidadDest,
        //                    auxcodPersonaEntidadNombreDest = item.auxCodigoPersonaEntidadNombreDest,
        //                    auxmonValorTipoCambioCMPDest = item.auxmonValorTipoCambioCMPDest,
        //                    auxmonValorTipoCambioVTADest = item.auxmonValorTipoCambioVTADest,
        //                    auxnumNumeroComprobanteExtDest = item.auxnumNumeroComprobanteExtDest,
        //                    monSoles = item.monSoles,
        //                    monDolar = item.monDolar,

        //                    auxmonDolarTotalDocumento = item.ValorTotalPrecioExtran,
        //                    auxmonSolesTotalDocumento = item.ValorTotalPrecioVenta
        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstGastoDeAduana;
        //}

        #endregion

        #region /* Proceso de INSERT RECORD */

        ///// <summary>
        ///// Almacena el registro de una ENTIDAD de registro de Tipo GastoDeAduana
        ///// En la BASE de DATO la Tabla : [GestionComercial.GastoDeAduana]
        ///// <summary>
        ///// <param name = >itemGastoDeAduana</param>
        //public int? Insert(GastoDeAduanaAux itemGastoDeAduana)
        //{
        //    int? codigoRetorno = null;
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            SQLDC.omgc_mnt_Insert_GastoDeAduana(
        //                ref codigoRetorno,
        //                itemGastoDeAduana.codDocumReg,
        //               itemGastoDeAduana.codRegistroGasto,
        //               itemGastoDeAduana.monValorDeGasto,
        //               itemGastoDeAduana.fecDePago,
        //               itemGastoDeAduana.gloComentario,
        //               itemGastoDeAduana.indCancelado,
        //               itemGastoDeAduana.segUsuarioCrea,
        //               itemGastoDeAduana.segUsuarioEdita,
        //               itemGastoDeAduana.codRegistroMoneda,
        //               itemGastoDeAduana.codDocumRegDestino);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno;
        //}

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo GastoDeAduana
        /// En la BASE de DATO la Tabla : [GestionComercial.GastoDeAduana]
        /// <summary>
        /// <param name = >itemGastoDeAduana</param>
        public bool Update(GastoDeAduanaAux itemGastoDeAduana)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_Update_GastoDeAduana(
                        itemGastoDeAduana.codGastoDeAduana,
                        itemGastoDeAduana.codDocumReg,
                        itemGastoDeAduana.codRegistroGasto,
                        itemGastoDeAduana.monValorDeGasto,
                        itemGastoDeAduana.fecDePago,
                        itemGastoDeAduana.gloComentario,
                        itemGastoDeAduana.indCancelado,
                        itemGastoDeAduana.segUsuarioCrea,
                        itemGastoDeAduana.segUsuarioEdita,
                        itemGastoDeAduana.codRegistroMoneda,
                        itemGastoDeAduana.codDocumRegDestino);
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

        ///// <summary>
        ///// ELIMINA un registro de la Entidad GestionComercial.GastoDeAduana
        ///// En la BASE de DATO la Tabla : [GestionComercial.GastoDeAduana]
        ///// <summary>
        ///// <returns>bool</returns>
        //public bool Delete(int? prm_codDocumReg, string prm_codRegistroGasto, string prm_segUsuarioEdita, bool prm_indEliminado)
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            codigoRetorno = SQLDC.omgc_mnt_Delete_GastoDeAduana(prm_codDocumReg, prm_codRegistroGasto, prm_segUsuarioEdita, prm_indEliminado);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == 0 ? true : false;
        //}

        #endregion
    }
} 

namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Cajas;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 21/04/2014-04:51:32 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [CajaBancos.CuentaBancariaData.cs]
    /// </summary>
    public class CuentaBancariaData
    {
        private string conexion = string.Empty;
        public CuentaBancariaData()
        {
            conexion = Util.ConexionBD();
        }

        //#region /* Proceso de SELECT ALL */

        ///// <summary>
        ///// Retorna un LISTA de registros de la Entidad CajaBancos.CuentaBancaria
        ///// En la BASE de DATO la Tabla : [CajaBancos.CuentaBancaria]
        ///// <summary>
        ///// <returns>List</returns>
        //public List<BECuentaBancaria> List(BECuentaBancaria pcuentaBancaria)
        //{
        //    List<BECuentaBancaria> lstCuentaBancaria = new List<BECuentaBancaria>();
        //    try
        //    {
        //        using (_CajaBancosDataContext SQLDC = new _CajaBancosDataContext(conexion))
        //        {
        //            var resul = SQLDC.omgc_S_CuentaBancaria(pcuentaBancaria.codPersonaEmpresa, pcuentaBancaria.codPersonaBanco, pcuentaBancaria.codRegMoneda, pcuentaBancaria.indActivo);
        //            foreach (var item in resul)
        //            {
        //                lstCuentaBancaria.Add(new BECuentaBancaria()
        //                {
        //                    codCuentaBancaria = item.codCuentaBancaria,
        //                    codPersonaEmpresa = item.codPersonaEmpresa,
        //                    codPersonaBanco = item.codPersonaBanco,
        //                    codRegMoneda = item.codRegMoneda,
        //                    codRegTipoCuenta = item.codRegTipoCuenta,
        //                    desNumeroCuenta = item.desNumeroCuenta,
        //                    fecApertura = item.fecApertura,
        //                    fecCierre = item.fecCierre,
        //                    gloObservacion = item.gloObservacion,
        //                    indActivo = item.indActivo,
        //                    indEliminado = item.indEliminado,
        //                    segUsuarioCrea = item.segUsuarioCrea,
        //                    segUsuarioEdita = item.segUsuarioEdita,
        //                    segFechaCrea = item.segFechaCrea,
        //                    segFechaEdita = item.segFechaEdita,
        //                    segMaquinaCrea = item.segMaquina,
                           
        //                    auxcodPersonaBanco = item.codPersonaBancoNombre,
        //                    auxcodPersonaEmpresa = item.codPersonaEmpresaNombre,
        //                    auxcodRegMoneda = item.codRegMonedaNombre,
        //                    auxcodRegTipoCuenta = item.codRegTipoCuentaNombre,
                             
        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstCuentaBancaria;
        //}
        //#endregion

        //#region /* Proceso de SELECT BY ID CODE */

        ///// <summary>
        ///// Retorna una ENTIDAD de registro de la Entidad CajaBancos.CuentaBancaria
        ///// En la BASE de DATO la Tabla : [CajaBancos.CuentaBancaria]
        ///// <summary>
        ///// <returns>Entidad</returns>
        //public BECuentaBancaria Find(string prm_codEmpresaRUC, int pcodCuentaBancaria)
        //{
        //    BECuentaBancaria cuentaBancaria = new BECuentaBancaria();
        //    try
        //    {
        //        using (_CajaBancosDataContext SQLDC = new _CajaBancosDataContext(conexion))
        //        {
        //            var resul = SQLDC.omgc_S_CuentaBancaria_Id(prm_codEmpresaRUC, pcodCuentaBancaria);
        //            foreach (var item in resul)
        //            {
        //                cuentaBancaria = new BECuentaBancaria()
        //                {
        //                    codCuentaBancaria = item.codCuentaBancaria,
        //                    codPersonaEmpresa = item.codPersonaEmpresa,
        //                    codPersonaBanco = item.codPersonaBanco,
        //                    codRegMoneda = item.codRegMoneda,
        //                    codRegTipoCuenta = item.codRegTipoCuenta,
        //                    desNumeroCuenta = item.desNumeroCuenta,
        //                    fecApertura = item.fecApertura,
        //                    fecCierre = item.fecCierre,
        //                    gloObservacion = item.gloObservacion,
        //                    indActivo = item.indActivo,
        //                    indEliminado = item.indEliminado,
        //                    segUsuarioCrea = item.segUsuarioCrea,
        //                    segUsuarioEdita = item.segUsuarioEdita,
        //                    segFechaCrea = item.segFechaCrea,
        //                    segFechaEdita = item.segFechaEdita,
        //                    segMaquinaCrea = item.segMaquina,

        //                    auxcodPersonaBanco = item.codPersonaBancoNombre,
        //                    auxcodPersonaEmpresa = item.codPersonaEmpresaNombre,
        //                    auxcodRegMoneda = item.codRegMonedaNombre,
        //                    auxcodRegTipoCuenta = item.codRegTipoCuentaNombre,
        //                };
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return cuentaBancaria;
        //}
        //#endregion

        //#region /* Proceso de INSERT RECORD */

        ///// <summary>
        ///// Almacena el registro de una ENTIDAD de registro de Tipo CuentaBancaria
        ///// En la BASE de DATO la Tabla : [CajaBancos.CuentaBancaria]
        ///// <summary>
        ///// <param name = >itemCuentaBancaria</param>
        //public bool Insert(BECuentaBancaria pCuentaBancaria)
        //{
        //    int? codigoRetorno = -1;
        //    try
        //    {
        //        using (_CajaBancosDataContext SQLDC = new _CajaBancosDataContext(conexion))
        //        {
        //              SQLDC.omgc_I_CuentaBancaria(
        //                ref codigoRetorno,
        //                pCuentaBancaria.codPersonaEmpresa,
        //                pCuentaBancaria.codPersonaBanco,
        //                pCuentaBancaria.codRegMoneda,
        //                pCuentaBancaria.codRegTipoCuenta,
        //                pCuentaBancaria.desNumeroCuenta,
        //                pCuentaBancaria.fecApertura,
        //                pCuentaBancaria.fecCierre,
        //                pCuentaBancaria.gloObservacion,
        //                pCuentaBancaria.segUsuarioCrea);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno > 0 ? true : false;
        //}
       
        //#endregion

        //#region /* Proceso de UPDATE RECORD */

        ///// <summary>
        ///// Almacena el registro de una ENTIDAD de registro de Tipo CuentaBancaria
        ///// En la BASE de DATO la Tabla : [CajaBancos.CuentaBancaria]
        ///// <summary>
        ///// <param name = >itemCuentaBancaria</param>
        //public bool Update(BECuentaBancaria pcuentaBancaria)
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_CajaBancosDataContext SQLDC = new _CajaBancosDataContext(conexion))
        //        {
        //             SQLDC.omgc_U_CuentaBancaria(
        //                pcuentaBancaria.codCuentaBancaria,
        //                pcuentaBancaria.codPersonaEmpresa,
        //                pcuentaBancaria.codPersonaBanco,
        //                pcuentaBancaria.codRegMoneda,
        //                pcuentaBancaria.codRegTipoCuenta,
        //                pcuentaBancaria.desNumeroCuenta,
        //                pcuentaBancaria.fecApertura,
        //                pcuentaBancaria.fecCierre,
        //                pcuentaBancaria.gloObservacion,
        //                pcuentaBancaria.indActivo,
        //                pcuentaBancaria.segUsuarioEdita);
        //             codigoRetorno = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == 0 ? true : false;
        //}
   
        //#endregion

        //#region /* Proceso de DELETE BY ID CODE */

        ///// <summary>
        ///// ELIMINA un registro de la Entidad CajaBancos.CuentaBancaria
        ///// En la BASE de DATO la Tabla : [CajaBancos.CuentaBancaria]
        ///// <summary>
        ///// <returns>bool</returns>
        //public bool Delete(string prm_codEmpresaRUC, int? pcodCuentaBancaria)
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_CajaBancosDataContext SQLDC = new _CajaBancosDataContext(conexion))
        //        {
        //            var resultDelete =  SQLDC.usp_sgcfe_D_CuentaBancaria(prm_codEmpresaRUC, pcodCuentaBancaria);
        //             codigoRetorno = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == 0 ? true : false;
        //}
        //#endregion

    }
} 

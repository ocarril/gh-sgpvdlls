namespace CROM.GestionComercial.BusinessLogic
{
    using CROM.BusinessEntities.Cajas;
    using CROM.GestionComercial.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Transactions;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 21/04/2014-04:51:32 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [CajaBancos.CuentaBancariaLogic.cs]
    /// </summary>
    public class CuentaBancariaLogic
    {
        private CuentaBancariaData cuentaBancariaData = null;
        private ReturnValor returnValor = null;
        public CuentaBancariaLogic()
        {
            cuentaBancariaData = new CuentaBancariaData();
            returnValor = new ReturnValor();
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
        //        lstCuentaBancaria = cuentaBancariaData.List(pcuentaBancaria);
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
        //public BECuentaBancaria Find(string prm_codEmpresaRUC,int prm_codCuentaBancaria)
        //{
        //    BECuentaBancaria cuentaBancaria = new BECuentaBancaria();
        //    try
        //    {
        //        cuentaBancaria = cuentaBancariaData.Find(prm_codEmpresaRUC, prm_codCuentaBancaria);
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
        //public ReturnValor Insert(BECuentaBancaria pcuentaBancaria)
        //{
        //    try
        //    {
        //        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
        //        {
        //            returnValor.Exitosa = cuentaBancariaData.Insert(pcuentaBancaria);
        //            if (returnValor.Exitosa)
        //            {
        //                returnValor.Exitosa = true;
        //                returnValor.Message = HelpMessages.Evento_NEW;
        //                tx.Complete();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        returnValor = HelpException.mTraerMensaje(ex);
        //    }
        //    return returnValor;
        //}

        //#endregion

        //#region /* Proceso de UPDATE RECORD */

        ///// <summary>
        ///// Almacena el registro de una ENTIDAD de registro de Tipo CuentaBancaria
        ///// En la BASE de DATO la Tabla : [CajaBancos.CuentaBancaria]
        ///// <summary>
        ///// <param name = >itemCuentaBancaria</param>
        //public ReturnValor Update(BECuentaBancaria pcuentaBancaria)
        //{
        //    try
        //    {
        //        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
        //        {
        //            returnValor.Exitosa = cuentaBancariaData.Update(pcuentaBancaria);
        //            if (returnValor.Exitosa)
        //            {
        //                returnValor.Message = HelpMessages.Evento_EDIT;
        //                tx.Complete();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        returnValor = HelpException.mTraerMensaje(ex);

        //    }
        //    return returnValor;
        //}

        //#endregion

        //#region /* Proceso de DELETE BY ID CODE */

        ///// <summary>
        ///// ELIMINA un registro de la Entidad CajaBancos.CuentaBancaria
        ///// En la BASE de DATO la Tabla : [CajaBancos.CuentaBancaria]
        ///// <summary>
        ///// <returns>bool</returns>
        //public ReturnValor Delete(string prm_codEmpresaRUC, int prm_codCuentaBancaria)
        //{
        //    try
        //    {
        //        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
        //        {
        //            returnValor.Exitosa = cuentaBancariaData.Delete(prm_codEmpresaRUC, prm_codCuentaBancaria);
        //            if (returnValor.Exitosa)
        //            {
        //                returnValor.Message = HelpMessages.Evento_DELETE;
        //                tx.Complete();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        returnValor = HelpException.mTraerMensaje(ex);
        //    }
        //    return returnValor;
        //}

        //#endregion

    }
}

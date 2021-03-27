namespace CROM.ComercialAlmacen.Interfaces
{
    using CROM.BusinessEntities.Cajas;
    using CROM.GestionComercial.BusinessLogic;
    using CROM.Tools.Comun;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class ICuentaBancariaLogic
    {
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad CajaBancos.CuentaBancaria
        /// En la BASE de DATO la Tabla : [CajaBancos.CuentaBancaria]
        /// <summary>
        /// <returns>List</returns>
        public List<BECuentaBancaria> List(BECuentaBancaria pcuentaBancaria)
        {
            List<BECuentaBancaria> lstCuentaBancaria = new CuentaBancariaLogic().List(pcuentaBancaria);
            return lstCuentaBancaria;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad CajaBancos.CuentaBancaria
        /// En la BASE de DATO la Tabla : [CajaBancos.CuentaBancaria]
        /// <summary>
        /// <returns>Entidad</returns>
        public BECuentaBancaria Find(int pcodCuentaBancaria)
        {
            BECuentaBancaria cuentaBancaria = new CuentaBancariaLogic().Find(pcodCuentaBancaria);
            return cuentaBancaria;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo CuentaBancaria
        /// En la BASE de DATO la Tabla : [CajaBancos.CuentaBancaria]
        /// <summary>
        /// <param name = >itemCuentaBancaria</param>
        public ReturnValor Insert(BECuentaBancaria pcuentaBancaria)
        {
            ReturnValor objReturnValor = new CuentaBancariaLogic().Insert(pcuentaBancaria);
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo CuentaBancaria
        /// En la BASE de DATO la Tabla : [CajaBancos.CuentaBancaria]
        /// <summary>
        /// <param name = >itemCuentaBancaria</param>
        public ReturnValor Update(BECuentaBancaria pcuentaBancaria)
        {
            ReturnValor objReturnValor = new CuentaBancariaLogic().Update(pcuentaBancaria);
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad CajaBancos.CuentaBancaria
        /// En la BASE de DATO la Tabla : [CajaBancos.CuentaBancaria]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(int pcodCuentaBancaria)
        {
            ReturnValor objReturnValor = new CuentaBancariaLogic().Delete(pcodCuentaBancaria);
            return objReturnValor;
        }

        #endregion
    }
}

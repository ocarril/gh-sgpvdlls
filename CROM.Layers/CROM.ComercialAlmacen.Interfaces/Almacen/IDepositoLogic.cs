namespace CROM.ComercialAlmacen.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CROM.BusinessEntities.Almacen;
    using CROM.GestionAlmacen.BusinessLogic;
    using CROM.Tools.Comun;
    
    public class IDepositoLogic
    {
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Deposito
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <returns>List</returns>
        public List<BEDeposito> List(string pcodPersonaEmpre,
                                   string pcodPuntoDeVenta,
                                   string pdesNombre,
                                   bool? pindActivo)
        {
            return new DepositoLogic().List(pcodPersonaEmpre,
                                            pcodPuntoDeVenta,
                                            pdesNombre,
                                            pindActivo);
             
        }

        public List<BEDeposito> List(string pcodPersonaEmpre,
                                   string pcodPuntoDeVenta,
                                   string pdesNombre,
                                   bool? pindActivo,
                                   Helper.ComboBoxText pTexto)
        {
            return new DepositoLogic().List(pcodPersonaEmpre,
                                            pcodPuntoDeVenta,
                                            pdesNombre,
                                            pindActivo,
                                            pTexto);
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.Deposito
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <param name="prm_codDeposito"></param>
        /// <returns></returns>
        public BEDeposito Find(string pcodDeposito)
        {
            return new DepositoLogic().Find(pcodDeposito);
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Deposito
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <param name = >itemDeposito</param>
        public ReturnValor Insert(BEDeposito deposito)
        {
            return  new DepositoLogic().Insert(deposito);
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Deposito
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <param name = >itemDeposito</param>
        public ReturnValor Update(BEDeposito deposito)
        {
            return new DepositoLogic().Update(deposito);
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.Deposito
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string strCodDeposito)
        {
            return new DepositoLogic().Delete(strCodDeposito);
        }

        #endregion
    }
}

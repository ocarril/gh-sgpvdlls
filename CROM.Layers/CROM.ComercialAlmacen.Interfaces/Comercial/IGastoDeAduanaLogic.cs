namespace CROM.ComercialAlmacen.Interfaces
{
    using CROM.Tools.Comun;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CROM.BusinessEntities.Comercial;
    using CROM.GestionComercial.BusinessLogic;

    public class IGastoDeAduanaLogic
    {

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.GastoDeAduana
        /// En la BASE de DATO la Tabla : [GestionComercial.GastoDeAduana]
        /// <summary>
        /// <returns>List</returns>
        public List<GastoDeAduanaAux> List(Nullable<DateTime> prm_FecInicio,
                                           Nullable<DateTime> prm_FecFinal,
                                           string prm_codPersonaEmpre,
                                           string prm_codPuntoDeVenta,
                                           string prm_codPersonaEntidad,
                                           string prm_codDocumento,
                                           string prm_numDocumento,
                                           string prm_codRegistroGasto,
                                           bool? indCancelado)
        {
            List<GastoDeAduanaAux> lstGastoDeAduana = new GastoDeAduanaLogic().List(prm_FecInicio,
                                                                                    prm_FecFinal,
                                                                                    prm_codPersonaEmpre,
                                                                                    prm_codPuntoDeVenta,
                                                                                    prm_codPersonaEntidad,
                                                                                    prm_codDocumento,
                                                                                    prm_numDocumento,
                                                                                    prm_codRegistroGasto,
                                                                                    indCancelado);
            return lstGastoDeAduana;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo GastoDeAduana
        /// En la BASE de DATO la Tabla : [GestionComercial.GastoDeAduana]
        /// <summary>
        /// <param name = >itemGastoDeAduana</param>
        public ReturnValor InsertUpdate(GastoDeAduanaAux pGastoDeAduana)
        {
            ReturnValor objReturnValor = new GastoDeAduanaLogic().InsertUpdate(pGastoDeAduana);
            return objReturnValor;
        }

        public ReturnValor DesAsignaGastoDeAduana(GastoDeAduanaAux pgastoDeAduana, int? pcodGastoDeAduana)
        {
            ReturnValor objReturnValor = new GastoDeAduanaLogic().DesAsignaGastoDeAduana(pgastoDeAduana,
                                                                                         pcodGastoDeAduana);
            return objReturnValor;
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
            ReturnValor objReturnValor = new GastoDeAduanaLogic().Delete(gastoDeAduana);
            return objReturnValor;
        }

        #endregion
    }
}

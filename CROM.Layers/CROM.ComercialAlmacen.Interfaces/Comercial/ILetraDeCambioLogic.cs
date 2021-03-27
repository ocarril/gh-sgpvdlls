namespace CROM.ComercialAlmacen.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CROM.BusinessEntities.Comercial;
    using CROM.GestionComercial.BusinessLogic;
    using CROM.Tools.Comun;
    
    public class ILetraDeCambioLogic
    {
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.LetraDeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.LetraDeCambio]
        /// <summary>
        /// <returns>List</returns>>
        public List<LetraDeCambioAux> List(BaseFiltro pFiltro)
        {
            List<LetraDeCambioAux> lstLetraDeCambio = new LetraDeCambioLogic().List(pFiltro);
            return lstLetraDeCambio;
        }

        public List<LetraDeCambioAux> List(int pcodDocumReg)
        {
            List<LetraDeCambioAux> lstLetraDeCambio = new LetraDeCambioLogic().List(pcodDocumReg);
            return lstLetraDeCambio;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.LetraDeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.LetraDeCambio]
        /// <summary>
        /// <returns>Entidad</returns>
        public LetraDeCambioAux Find(int prm_codLetraDeCambio)
        {
            LetraDeCambioAux objLetraDeCambio = new LetraDeCambioLogic().Find(prm_codLetraDeCambio);
            return objLetraDeCambio;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo LetraDeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.LetraDeCambio]
        /// <summary>
        /// <param name = >itemLetraDeCambio</param>
        public ReturnValor Insert(List<LetraDeCambioAux> listaLetraDeCambio)
        {
            ReturnValor oReturnValor = new LetraDeCambioLogic().Insert(listaLetraDeCambio);
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo LetraDeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.LetraDeCambio]
        /// <summary>
        /// <param name = >itemLetraDeCambio</param>
        public ReturnValor Update(List<LetraDeCambioAux> listaLetraDeCambio)
        {
            ReturnValor oReturnValor = new LetraDeCambioLogic().Update(listaLetraDeCambio);
            return oReturnValor;
        }

        public ReturnValor UpdatecodRegistroEstado(LetraDeCambioAux pLetraDeCambio)
        {
            ReturnValor oReturnValor = new LetraDeCambioLogic().UpdatecodRegistroEstado(pLetraDeCambio);
            return oReturnValor;
        }

        public ReturnValor UpdatefecRecepcion(LetraDeCambioAux itemLetraDeCambio)
        {
            ReturnValor oReturnValor = new LetraDeCambioLogic().UpdatefecRecepcion(itemLetraDeCambio);
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.LetraDeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.LetraDeCambio]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(int prm_codLetraDeCambio)
        {
            ReturnValor oReturnValor = new LetraDeCambioLogic().Delete(prm_codLetraDeCambio);
            return oReturnValor;
        }

        #endregion

    }
}

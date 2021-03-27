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
    
    public class ITipoDeCambioLogic
    {

        #region /* Proceso de INSERT RECORD */

        public ReturnValor Insert(BETipoDeCambio objTipoDeCambio)
        {
            ReturnValor intReturnValor = new TipoDeCambioLogic().Insert(objTipoDeCambio);
            return intReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <param name="objTipoDeCambio"></param>
        /// <returns></returns>
        public ReturnValor Update(BETipoDeCambio objTipoDeCambio)
        {
            ReturnValor objReturnValor = new TipoDeCambioLogic().Update(objTipoDeCambio);
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <param name="prm_codTipoCambio"></param>
        /// <returns></returns>
        public ReturnValor Delete(int pcodTipoCambio)
        {
            ReturnValor objReturnValor = new TipoDeCambioLogic().Delete(pcodTipoCambio);
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<BETipoDeCambio> List(BaseFiltro filtro)
        {
            List<BETipoDeCambio> lstTipoDeCambio = new TipoDeCambioLogic().List(filtro);
            return lstTipoDeCambio;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<BETipoDeCambio> ListPaged(BaseFiltro filtro)
        {
            List<BETipoDeCambio> lstTipoDeCambio = new TipoDeCambioLogic().ListPaged(filtro);
            return lstTipoDeCambio;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        public BETipoDeCambio Find(int pcodTipoCambio)
        {
            BETipoDeCambio tiposDeCambio = new TipoDeCambioLogic().Find(pcodTipoCambio);
            return tiposDeCambio;
        }

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.TiposdeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposdeCambio]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public BETipoDeCambio Find(BaseFiltro filtro)
        {
            BETipoDeCambio tiposDeCambio = new TipoDeCambioLogic().Find(filtro);
            return tiposDeCambio;
        }

        #endregion

    }
}

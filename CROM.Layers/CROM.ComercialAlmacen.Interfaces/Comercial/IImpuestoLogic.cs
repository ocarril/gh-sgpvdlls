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

    public class IImpuestoLogic
    {
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.TiposDeImpuesto
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposDeImpuesto]
        /// <summary>
        /// <returns>List</returns>
        public List<BEImpuesto> List(BaseFiltro pFiltro)
        {
            return new ImpuestoLogic().List(pFiltro);
        }

        public List<BEImpuesto> List(BaseFiltro pFiltro, Helper.ComboBoxText pTexto)
        {
            return new ImpuestoLogic().List(pFiltro, pTexto);
        }

        public List<BEImpuesto> ListPaged(BaseFiltro pFiltro)
        {
            return new ImpuestoLogic().ListPaged(pFiltro);
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.Impuesto
        /// En la BASE de DATO la Tabla : [GestionComercial.Impuesto]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEImpuesto Find(string pcodigoImpuesto)
        {
            return  new ImpuestoLogic().Find(pcodigoImpuesto);
        }

        #endregion

        #region /* Proceso de INSERT-UPDATE RECORD */

        public ReturnValor Save(BEImpuesto objImpuesto)
        {
            return new ImpuestoLogic().Save(objImpuesto);
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.TiposDeImpuesto
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposDeImpuesto]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string pcodigoImpuesto)
        {
            return new ImpuestoLogic().Delete(pcodigoImpuesto);
        }

        #endregion
    }
}

namespace CROM.ComercialAlmacen.Interfaces
{
    using CROM.BusinessEntities.Comercial;
    using CROM.GestionComercial.BusinessLogic;
    using CROM.Tools.Comun;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class ICondicionLogic
    {

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.CondicionVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.CondicionVenta]
        /// <summary>
        /// <returns>List</returns>
        public List<BECondicion> List(BaseFiltro pFiltro)
        {
            return  new CondicionLogic().List(pFiltro);
        }

        public List<BECondicion> List(BaseFiltro pFiltro, Helper.ComboBoxText pTexto)
        {
            return  new CondicionLogic().List(pFiltro, pTexto);
        }

        public List<BECondicion> ListPaginado(BaseFiltro pFiltro)
        {
            return new CondicionLogic().ListPaginado(pFiltro);
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.CondicionVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.CondicionVenta]
        /// <summary>
        /// <returns>Entidad</returns>
        public BECondicion Find(int pcodCondicion)
        {
            return new CondicionLogic().Find(pcodCondicion);
        }

        #endregion

        #region /* Proceso de INSERT-UPDATE RECORD */

        public ReturnValor Save(BECondicion objCondicion)
        {
            return new CondicionLogic().Save(objCondicion);
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.CondicionVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.CondicionVenta]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(BECondicion objCondicion)
        {
            return new CondicionLogic().Delete(objCondicion);
        }

        #endregion

    }
}
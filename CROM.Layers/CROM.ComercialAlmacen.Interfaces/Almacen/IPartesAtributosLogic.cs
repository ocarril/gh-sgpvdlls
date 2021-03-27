namespace CROM.ComercialAlmacen.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CROM.BusinessEntities.Almacen;
    using CROM.BusinessEntities.Maestros;
    using CROM.GestionAlmacen.BusinessLogic;
    using CROM.Tools.Comun;
    
    public class IPartesAtributosLogic
    {
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Produccion.PartesAtributos
        /// En la BASE de DATO la Tabla : [Produccion.PartesAtributos]
        /// <summary>
        /// <returns>List</returns>
        public List<BEParteAtributo> List(string pCodigoArguParteProdu, 
                                          string pCodigoArguAtributoPP, 
                                          bool pEstado)
        {
            return new PartesAtributosLogic().List(pCodigoArguParteProdu, 
                                                   pCodigoArguAtributoPP, 
                                                   pEstado);
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PartesAtributos
        /// En la BASE de DATO la Tabla : [Produccion.PartesAtributos]
        /// <summary>
        /// <param name = >itemPartesAtributos</param>
        public ReturnValor InsertUpdate(List<BEParteAtributo> listaPartesAtributos, 
                                        BERegistro pTablaMaestraRegistro, 
                                        bool pindNUEVO)
        {
            return new PartesAtributosLogic().InsertUpdate(listaPartesAtributos, pTablaMaestraRegistro, pindNUEVO);
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Produccion.PartesAtributos
        /// En la BASE de DATO la Tabla : [Produccion.PartesAtributos]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string pCodigoArguParteProdu, 
                                  string pCodigoArguAtributoPP)
        {
            return new PartesAtributosLogic().Delete(pCodigoArguParteProdu, 
                                                     pCodigoArguAtributoPP);
        }

        #endregion

    }
}

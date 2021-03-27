namespace CROM.ComercialAlmacen.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CROM.BusinessEntities.Cajas;
    using CROM.BusinessEntities.Comercial;
    using CROM.GestionComercial.BusinessLogic;
    using CROM.Tools.Comun;
    
    public class IFormaDePagoLogic
    {
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.FormasDePago
        /// En la BASE de DATO la Tabla : [GestionComercial.FormasDePago]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEFormaDePago> List(BaseFiltro pFiltro)
        {
            List<BEFormaDePago> lstFormaDePago = new FormaDePagoLogic().List(pFiltro);
            return lstFormaDePago;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.FormasDePago con opcion
        /// En la BASE de DATO la Tabla : [GestionComercial.FormasDePago]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <param name="pTexto"></param>
        /// <returns></returns>
        public List<BEFormaDePago> List(BaseFiltro pFiltro, Helper.ComboBoxText pTexto)
        {
            List<BEFormaDePago> lstFormaDePago = new FormaDePagoLogic().List(pFiltro, pTexto);
            return lstFormaDePago;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.FormasDePago Paginado
        /// En la BASE de DATO la Tabla : [GestionComercial.FormasDePago]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEFormaDePago> ListPaginado(BaseFiltro pFiltro)
        {
            List<BEFormaDePago> lstFormaDePago = new FormaDePagoLogic().ListPaginado(pFiltro);
           
            return lstFormaDePago;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.FormasDePago
        /// En la BASE de DATO la Tabla : [GestionComercial.FormasDePago]
        /// <summary>
        /// <param name="prm_codFormaDePago"></param>
        /// <returns></returns>
        public BEFormaDePago Find(int pcodFormaDePago)
        {
            BEFormaDePago objFormaDePago =new FormaDePagoLogic().Find(pcodFormaDePago);

            return objFormaDePago;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo FormasDePago
        /// En la BASE de DATO la Tabla : [GestionComercial.FormasDePago]
        /// <summary>
        /// <param name="objFormaDePago"></param>
        /// <returns></returns>
        public ReturnValor Insert(BEFormaDePago pFormaDePago)
        {
            ReturnValor objReturnValor = new FormaDePagoLogic().Insert(pFormaDePago);

            return objReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo FormasDePago
        /// En la BASE de DATO la Tabla : [GestionComercial.FormasDePago]
        /// <summary>
        /// <param name="objFormaDePago"></param>
        /// <returns></returns>
        public ReturnValor Update(BEFormaDePago pFormaDePago)
        {
            ReturnValor objReturnValor = new FormaDePagoLogic().Update(pFormaDePago);
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.FormasDePago
        /// En la BASE de DATO la Tabla : [GestionComercial.FormaDePago]
        /// <summary>
        /// <param name="prm_codFormaDePago"></param>
        /// <returns></returns>
        public ReturnValor Delete(int pcodFormaDePago) 
        {
            ReturnValor objReturnValor = new FormaDePagoLogic().Delete(pcodFormaDePago);
            return objReturnValor;
            
        }

        #endregion
    }
}

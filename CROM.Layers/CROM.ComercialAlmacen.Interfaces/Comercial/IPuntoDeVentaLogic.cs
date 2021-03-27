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

    public class IPuntoDeVentaLogic
    {
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.PuntosDeVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.PuntosDeVenta]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEPuntoDeVenta> List(BaseFiltro pFiltro)
        {
            List<BEPuntoDeVenta> lstPuntoDeVenta = new PuntoDeVentaLogic().List(pFiltro);
            return lstPuntoDeVenta;
        }

        public List<BEPuntoDeVenta> List(BaseFiltro pFiltro, Helper.ComboBoxText pTexto)
        {
            List<BEPuntoDeVenta> lstPuntoDeVenta = new PuntoDeVentaLogic().List(pFiltro, pTexto);
            return lstPuntoDeVenta;
        }

        public List<BEPuntoDeVenta> ListPaginado(BaseFiltro pFiltro)
        {
            List<BEPuntoDeVenta> lstPuntoDeVenta = new PuntoDeVentaLogic().ListPaginado(pFiltro);
            return lstPuntoDeVenta;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.PuntosDeVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.PuntosDeVenta]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEPuntoDeVenta Find(string pcodPuntoDeVenta)
        {
            BEPuntoDeVenta objPuntoVenta = new PuntoDeVentaLogic().Find(pcodPuntoDeVenta);
            return objPuntoVenta;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PuntosDeVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.PuntosDeVenta]
        /// <summary>
        /// <param name="itemPuntoDeVenta"></param>
        /// <returns></returns>
        public ReturnValor Insert(BEPuntoDeVenta objPuntoDeVenta)
        {
            ReturnValor objReturnValor = new PuntoDeVentaLogic().Insert(objPuntoDeVenta);
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PuntosDeVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.PuntosDeVenta]
        /// <summary>
        /// <param name="objPuntoDeVenta"></param>
        /// <returns></returns>
        public ReturnValor Update(BEPuntoDeVenta objPuntoDeVenta)
        {
            ReturnValor objReturnValor = new PuntoDeVentaLogic().Update(objPuntoDeVenta);
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcodPuntoDeVenta"></param>
        /// <returns></returns>
        public ReturnValor Delete(string pcodPuntoDeVenta)
        {
            ReturnValor objReturnValor = new PuntoDeVentaLogic().Delete(pcodPuntoDeVenta);
            return objReturnValor;
        }

        #endregion
    }
}

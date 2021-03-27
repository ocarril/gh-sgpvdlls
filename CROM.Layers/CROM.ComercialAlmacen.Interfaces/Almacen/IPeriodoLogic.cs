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
    
    public class IPeriodoLogic
    {

        #region /* Proceso de SELECT  */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Periodo
        /// En la BASE de DATO la Tabla : [Almacen.Periodo]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEPeriodo> List(BaseFiltroAlmacen pFiltro, 
                                  bool pSinCerrar = false)
        {
            return new PeriodoLogic().List(pFiltro, 
                                           pSinCerrar);
        }

        public List<BEPeriodo> List(BaseFiltroAlmacen pFiltro, Helper.ComboBoxText pTexto)
        {
            return new PeriodoLogic().List(pFiltro, pTexto);
        }
     
        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.Periodo
        /// En la BASE de DATO la Tabla : [Almacen.Periodo]
        /// </summary>
        /// <param name="pcodPeriodo"></param>
        /// <returns></returns>
        public BEPeriodo Find(string pcodPeriodo)
        {
            return new PeriodoLogic().Find(pcodPeriodo);
        }

        #endregion

        #region /* Proceso de INSERT */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Periodo
        /// En la BASE de DATO la Tabla : [Almacen.Periodo]
        /// </summary>
        /// <param name="pPeriodo"></param>
        /// <returns></returns>
        public ReturnValor Insert(BEPeriodo pPeriodo)
        {
            return new PeriodoLogic().Insert(pPeriodo);
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Actualiza el registro de una ENTIDAD de registro de Tipo Periodo
        /// En la BASE de DATO la Tabla : [Almacen.Periodo]
        /// </summary>
        /// <param name="pPeriodo"></param>
        /// <returns></returns>
        public ReturnValor Update(BEPeriodo pPeriodo)
        {
            return new PeriodoLogic().Update(pPeriodo);
        }

        /// <summary>
        ///  Realiza la apertura de periodo de inventario
        /// </summary>
        /// <param name="pPeriodo"></param>
        /// <returns></returns>
        public ReturnValor UpdateApertura(BEPeriodo pPeriodo)
        {
            return new PeriodoLogic().UpdateApertura(pPeriodo);
        }

        /// <summary>
        /// Realiza el cierre de periodo de inventario
        /// </summary>
        /// <param name="pPeriodo"></param>
        /// <returns></returns>
        public ReturnValor UpdateCierre(BEPeriodo pPeriodo)
        {
            return new PeriodoLogic().UpdateCierre(pPeriodo);
        }

        #endregion

        #region /* Proceso de DELETE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.Periodo
        /// En la BASE de DATO la Tabla : [Almacen.Periodo]
        /// </summary>
        /// <param name="pcodPeriodo"></param>
        /// <returns></returns>
        public ReturnValor Delete(string pcodPeriodo)
        {
            return new PeriodoLogic().Delete(pcodPeriodo);
        }

        #endregion

    }
}
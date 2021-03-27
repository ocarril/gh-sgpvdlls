namespace CROM.ComercialAlmacen.Interfaces
{
    using CROM.BusinessEntities.Comercial;
    using CROM.GestionImportacion.BusinessLogic;
    using CROM.Tools.Comun;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class IDocumentoEstadoLogic
    {

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.DocumentoEstado
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoEstado]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumentoEstado> List(BaseFiltro pFiltro)
        {
            List<BEDocumentoEstado> lstDocumentoEstado = new DocumentoEstadoLogic().List(pFiltro);
            return lstDocumentoEstado;
        }

        public List<BEDocumentoEstado> ListPaged(BaseFiltro pFiltro)
        {
            List<BEDocumentoEstado> lstDocumentoEstado = new DocumentoEstadoLogic().ListPaged(pFiltro);
            return lstDocumentoEstado;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.DocumentoEstado
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoEstado]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public BEDocumentoEstado Find(BaseFiltro pFiltro)
        {
            BEDocumentoEstado objDocumentoEstado = new DocumentoEstadoLogic().Find(pFiltro);
            return objDocumentoEstado;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */
        public ReturnValor Insert(BEDocumentoEstado pDocumentoEstado)
        {
            ReturnValor objReturnValor = new DocumentoEstadoLogic().Insert(pDocumentoEstado);
            return objReturnValor;
        }

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo DocumentoEstado
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoEstado]
        /// </summary>
        /// <param name="lstDocumentoEstado"></param>
        /// <returns></returns>
        public ReturnValor Insert(List<BEDocumentoEstado> lstDocumentoEstado)
        {
            ReturnValor objReturnValor = new DocumentoEstadoLogic().Insert(lstDocumentoEstado);
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo DocumentoEstado
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoEstado]
        /// </summary>
        /// <param name="pDocumentoEstado"></param>
        /// <returns></returns>
        public ReturnValor Update(BEDocumentoEstado pDocumentoEstado)
        {
            ReturnValor objReturnValor = new DocumentoEstadoLogic().Update(pDocumentoEstado);
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.DocumentoEstado
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoEstado]
        /// </summary>
        /// <param name="lstDocumentoEstado"></param>
        /// <returns></returns>
        public ReturnValor Delete(List<BEDocumentoEstado> lstDocumentoEstado)
        {
            ReturnValor objReturnValor = new DocumentoEstadoLogic().Delete(lstDocumentoEstado);
            return objReturnValor;
        }

        #endregion
    }
}

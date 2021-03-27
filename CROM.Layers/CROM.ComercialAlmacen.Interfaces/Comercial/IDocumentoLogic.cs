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

    public class IDocumentoLogic
    {
        #region /* TABLA / ENTIDAD : Documento */

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.Documento
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumento> List(BaseFiltro pFiltro)
        {
            List<BEDocumento> listaDocumentos = new DocumentoLogic().List(pFiltro);
            return listaDocumentos;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <param name="pTexto"></param>
        /// <returns></returns>
        public List<BEDocumento> List(BaseFiltro pFiltro, Helper.ComboBoxText pTexto)
        {
            List<BEDocumento> listaDocumentos = new DocumentoLogic().List(pFiltro, pTexto);
            return listaDocumentos;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.Comprobantes Paginado
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumento> ListPaged(BaseFiltro pFiltro)
        {
            List<BEDocumento> listaDocumentos = new DocumentoLogic().ListPaged(pFiltro);
            return listaDocumentos;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="prm_codDocumento"></param>
        /// <returns></returns>
        public BEDocumento Find(string pcodDocumento)
        {
            BEDocumento objDocumento = new DocumentoLogic().Find(pcodDocumento);
            return objDocumento;
        }

        #endregion
 
        #region /* Proceso de INSERT-UPDATE RECORD */

        public ReturnValor Save(BEDocumento objDocumento)
        {
            ReturnValor objReturnValor = new DocumentoLogic().Save(objDocumento);
            return objReturnValor;
        }


        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string pCodigoComprobante)
        {
            ReturnValor objReturnValor = new DocumentoLogic().Delete(pCodigoComprobante);
            return objReturnValor;
        }

        #endregion

        #endregion

        #endregion

        #region /* TABLA / ENTIDAD : DocumentoSeries */

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobantesSeries
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesSeries]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumentoSerie> ListDocumentoSerie(BaseFiltro pFiltro)
        {
            List<BEDocumentoSerie> lstDocumentoSerie = new DocumentoLogic().ListDocumentoSerie(pFiltro);
            return lstDocumentoSerie;
        }

        public List<BEDocumentoSerie> ListDocumentoSeriePaginado(BaseFiltro pFiltro)
        {
            List<BEDocumentoSerie> lstDocumentoSerie = new DocumentoLogic().ListDocumentoSeriePaginado(pFiltro);
            return lstDocumentoSerie;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobantesSeries
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesSeries]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <param name="pTexto"></param>
        /// <returns></returns>
        public List<BEDocumentoSerie> ListDocumentoSerie(BaseFiltro pFiltro, Helper.ComboBoxText pTexto)
        {
            List<BEDocumentoSerie> lstDocumentoSerie = new DocumentoLogic().ListDocumentoSerie(pFiltro, pTexto);
            return lstDocumentoSerie;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.DocumentoSerie
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoSerie]
        /// <summary>
        /// <param name="pCodigoTalonario"></param>
        /// <returns></returns>
        public BEDocumentoSerie FindDocumentoSerie(string pCodigoTalonario)
        {
            BEDocumentoSerie objDocumentoSerie = new DocumentoLogic().FindDocumentoSerie(pCodigoTalonario);
            return objDocumentoSerie;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo DocumentoSerie
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoSerie]
        /// <summary>
        /// <param name="objDocumentoSerie"></param>
        /// <returns></returns>
        public ReturnValor InsertDocumentoSerie(BEDocumentoSerie objDocumentoSerie)
        {
            ReturnValor objReturnValor = new DocumentoLogic().InsertDocumentoSerie(objDocumentoSerie);
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo DocumentoSerie
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoSerie]
        /// <summary>
        /// <param name="objDocumentoSerie"></param>
        /// <returns></returns>
        public ReturnValor UpdateDocumentoSerie(BEDocumentoSerie objDocumentoSerie)
        {
            ReturnValor objReturnValor = new DocumentoLogic().UpdateDocumentoSerie(objDocumentoSerie);
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.DocumentoSerie
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoSerie]
        /// <summary>
        /// <param name="pCodigoTalonario"></param>
        /// <returns></returns>
        public ReturnValor DeleteDocumentoSerie(string pCodigoTalonario)
        {
            ReturnValor objReturnValor = new DocumentoLogic().DeleteDocumentoSerie(pCodigoTalonario);
            return objReturnValor;
        }

        #endregion

        #endregion

        #region /* TABLA / ENTIDAD : DocumentoImpuestos */

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobantesSeries
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesSeries]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumentoImpuesto> ListDocumentoImpuesto(BaseFiltro pFiltro)
        {
            List<BEDocumentoImpuesto> lstDocumentoImpuesto = new DocumentoLogic().ListDocumentoImpuesto(pFiltro);
            return lstDocumentoImpuesto;
        }

        public List<BEDocumentoImpuesto> ListDocumentoImpuestoPaginado(BaseFiltro pFiltro)
        {
            List<BEDocumentoImpuesto> lstDocumentoImpuesto = new DocumentoLogic().ListDocumentoImpuestoPaginado(pFiltro);
            return lstDocumentoImpuesto;
        }

        #endregion

        #region /* Proceso de SELECT ID */
        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobantesImpuestos
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesImpuestos]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public BEDocumentoImpuesto FindDocumentoImpuesto(BaseFiltro pFiltro)
        {
            BEDocumentoImpuesto objDocumentoImpuesto = new DocumentoLogic().FindDocumentoImpuesto(pFiltro);
            return objDocumentoImpuesto;
        }


        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo objDocumentoImpuesto
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesSeries]
        /// <summary>
        /// <param name="objDocumentoImpuesto"></param>
        /// <returns></returns>
        public ReturnValor InsertDocumentoImpuesto(BEDocumentoImpuesto objDocumentoImpuesto)
        {
            ReturnValor objReturnValor = new DocumentoLogic().InsertDocumentoImpuesto(objDocumentoImpuesto);
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.ComprobantesImpuestos
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobantesImpuestos]
        /// <summary>
        /// <param name="prm_CodigoDocumento"></param>
        /// <param name="prm_codRegTipoImpuesto"></param>
        /// <returns></returns>
        public ReturnValor DeleteDocumentoImpuesto(string pcodigoDocumento, string pcodRegTipoImpuesto)
        {
            ReturnValor objReturnValor = new DocumentoLogic().DeleteDocumentoImpuesto(pcodigoDocumento,
                                                                                      pcodRegTipoImpuesto);
            return objReturnValor;
        }

        #endregion

        #region /* PROCESOS DE LA ENTIDAD : Comprobantes y ComprobantesSeries */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumentoSerie> ListDocumentoSeriePorUsuario(BaseFiltro pFiltro)
        {
            List<BEDocumentoSerie> lstDocumentoSerie = new DocumentoLogic().ListDocumentoSeriePorUsuario(pFiltro);
            return lstDocumentoSerie;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="prm_CodigoTalonario"></param>
        /// <returns></returns>
        public ReturnValor UltimoNumeroDocumento(string pcodigoTalonario)
        {
            ReturnValor objReturnValor = new DocumentoLogic().UltimoNumeroDocumento(pcodigoTalonario);
            return (objReturnValor);
        }

        #endregion

        #endregion
    }
}

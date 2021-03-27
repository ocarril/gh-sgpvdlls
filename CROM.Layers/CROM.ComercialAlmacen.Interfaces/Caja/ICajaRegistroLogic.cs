namespace CROM.ComercialAlmacen.Interfaces
{
    using CROM.Tools.Comun;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CROM.GestionComercial.BusinessLogic;
    using CROM.BusinessEntities.Comercial;
    using CROM.Tools.Config;
    using CROM.BusinessEntities.Cajas;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 14/11/2010-6:34:49
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [CajaBancos.ComprobanteEmitidosLogic.cs]
    /// </summary>
    public class ICajaRegistroLogic
    {

        #region /* Proceso de SELECT BY ID CODE FOREIGN KEY*/

        /// <summary>
        /// Retorna una LISTA de registro de la Entidad CajaBancos.ComprobanteEmitidos POR FOREIGN KEY
        /// En la BASE de DATO la Tabla : [CajaBancos.ComprobanteEmitidos]
        /// <summary>
        /// <returns>Entidad</returns>
        public List<CajaRegistroAux> List(Nullable<DateTime> prm_fecIngresoInicio,
                                          Nullable<DateTime> prm_fecIngresoFinal,
                                          int? prm_codDocumReg,
                                          string prm_codRegistroDestinoComp,
                                          string prm_codPersonaEntidad,
                                          int? prm_codEmpleado,
                                          string prm_codRegistroMoneda,
                                          string prm_codParteDiario,
                                          string prm_codFormaDePago,
                                          bool? prm_indConciliado)
        {
            return new CajaRegistroLogic().List(prm_fecIngresoInicio,
                                                prm_fecIngresoFinal,
                                                prm_codDocumReg,
                                                prm_codRegistroDestinoComp,
                                                prm_codPersonaEntidad,
                                                prm_codEmpleado,
                                                prm_codRegistroMoneda,
                                                prm_codParteDiario,
                                                prm_codFormaDePago,
                                                prm_indConciliado);

        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ComprobanteEmitidos
        /// En la BASE de DATO la Tabla : [CajaBancos.ComprobanteEmitidos]
        /// </summary>
        /// <param name="itemComprobanteEmitidos"></param>
        /// <param name="comprobanteEmision"></param>
        /// <returns></returns>
        public ReturnValor PagarEfectivo(CajaRegistroAux cajaRegistro,
                                         BEComprobanteEmision comprobanteEmision,
                                         decimal prm_MontoPagadoMN,
                                         decimal prm_MontoPagadoMI,
                                         decimal prm_SaldoActualMN,
                                         decimal prm_SaldoActualMI)
        {
            return new CajaRegistroLogic().PagarEfectivo(cajaRegistro,
                                                         comprobanteEmision,
                                                         prm_MontoPagadoMN,
                                                         prm_MontoPagadoMI,
                                                         prm_SaldoActualMN,
                                                         prm_SaldoActualMI); 
        }

        public ReturnValor DeshacerPagoEfectivo(BaseFiltro pDatos)
        {
            return new CajaRegistroLogic().DeshacerPagoEfectivo(pDatos);;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad CajaBancos.ComprobanteEmitidos
        /// En la BASE de DATO la Tabla : [CajaBancos.ComprobanteEmitidos]
        /// </summary>
        /// <param name="prm_CodigoPersonaEmpre"></param>
        /// <param name="prm_CodigoPuntoVenta"></param>
        /// <param name="prm_CodigoComprobante"></param>
        /// <param name="prm_NumeroComprobante"></param>
        /// <returns></returns>
        public ReturnValor Delete(int prm_numItem,
                                  int prm_codDocumReg,
                                  string prm_codDocumento,
                                  bool prm_CAMBIA_ESTADO,
                                  string prm_CodigoParte,
                                  string prm_UsuarioEdita)
        {
            return new CajaRegistroLogic().Delete(prm_numItem,
                                                  prm_codDocumReg,
                                                  prm_codDocumento,
                                                  prm_CAMBIA_ESTADO,
                                                  prm_CodigoParte,
                                                  prm_UsuarioEdita);
        }

        #endregion
    }
}

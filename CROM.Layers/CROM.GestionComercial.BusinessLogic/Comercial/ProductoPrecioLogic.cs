namespace CROM.GestionComercial.BusinessLogic.Comercial
{
    using CROM.BusinessEntities.Almacen;
    using CROM.BusinessEntities.Comercial;
    using CROM.GestionComercial.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Transactions;

    public class ProductoPrecioLogic
    {
        private ProductoPrecioData productoPrecioData = null;
        private ReturnValor oReturnValor = null;

        public ProductoPrecioLogic()
        {
            productoPrecioData = new ProductoPrecioData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.PuntosDeVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.PuntosDeVenta]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEProductoPrecio> List(BaseFiltroProductoPrecio pFiltro)
        {
            List<BEProductoPrecio> lstProductoPrecio = new List<BEProductoPrecio>();
            try
            {
                lstProductoPrecio = productoPrecioData.List(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstProductoPrecio;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.ProductoPrecio
        /// En la BASE de DATO la Tabla : [GestionComercial.ProductoPrecio]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEProductoPrecio Find(BaseFiltroProductoPrecio pProductoPrecioBuscar)
        {
            BEProductoPrecio objProductoPrecio = null;
            try
            {
                objProductoPrecio = productoPrecioData.Find(pProductoPrecioBuscar);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             pProductoPrecioBuscar.segUsuarioActual, pProductoPrecioBuscar.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return objProductoPrecio;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        ///// <summary>
        ///// Almacena el registro de una ENTIDAD de registro de Tipo ProductoPrecio
        ///// En la BASE de DATO la Tabla : [GestionComercial.ProductoPrecio]
        ///// <summary>
        ///// <param name="itemProductoPrecio"></param>
        ///// <returns></returns>
        //public ReturnValor InsertUpdate(BEProductoPrecio objProductoPrecio)
        //{
        //    try
        //    {
        //        oReturnValor = validaDatos(objProductoPrecio, HelpEventos.Accion.Nuevo);
        //        if (!oReturnValor.Exitosa)
        //            return oReturnValor;

        //        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
        //        {
        //            var resultUpdate = productoPrecioData.InsertUpdate(objProductoPrecio);

        //            oReturnValor.Exitosa = resultUpdate.ErrorCode > 0 ? true : false;
        //            oReturnValor.Message = oReturnValor.Exitosa ? HelpEventos.MessageEvento(HelpEventos.Process.NEW) :
        //                                          resultUpdate.ErrorMessage;
        //            if(oReturnValor.Exitosa)
        //                tx.Complete();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
        //                                                   objProductoPrecio.segUsuarioEdita,
        //                                                   objProductoPrecio.codEmpresa.ToString());
        //    }
        //    return oReturnValor;
        //}

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prm_codProductoPrecio"></param>
        /// <returns></returns>
        public ReturnValor Delete(BaseFiltroProductoPrecio pDelete)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    var oReturnValorDelete = productoPrecioData.Delete(pDelete);
                    oReturnValor.Exitosa = oReturnValorDelete.ErrorCode > 0 ? true : false;
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                           pDelete.segUsuarioActual,
                                                           pDelete.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        private ReturnValor validaDatos(BEProductoPrecio objProductoPrecio, HelpEventos.Accion pAccion)
        {
            ReturnValor returnValor = new ReturnValor();
            if (string.IsNullOrEmpty(objProductoPrecio.CodigoArguMoneda))
            {
                returnValor.Message = HelpMessages.gc_DOCUM_SeleccionaMoneda;
                return returnValor;
            }
            if (string.IsNullOrEmpty(objProductoPrecio.CodigoPuntoVenta)) {
                returnValor.Message = HelpMessages.VALIDACIONPuntoDeVenta; 
                return returnValor;
            }
            if (pAccion == HelpEventos.Accion.Nuevo)
            {
                if (string.IsNullOrEmpty(objProductoPrecio.segUsuarioCrea))
                {
                    returnValor.Message = HelpMessages.VALIDACIONUsuarioEmpleado;
                    return returnValor;
                }
            }
            if (pAccion == HelpEventos.Accion.Edición)
            {
                if (string.IsNullOrEmpty(objProductoPrecio.segUsuarioEdita))
                {
                    returnValor.Message = HelpMessages.VALIDACIONUsuarioEmpleado;
                    return returnValor;
                }
            }
            returnValor.Exitosa = true;
            return returnValor;
        }
    }
}

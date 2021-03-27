namespace CROM.GestionAlmacen.BusinessLogic
{
    using CROM.BusinessEntities.Almacen;
    using CROM.GestionAlmacen.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Transactions;

    public class ProductoKardexLogic
    {
        private ProductoKardexData objProductoKardexData = null;
        public ProductoKardexLogic()
        {
            objProductoKardexData = new ProductoKardexData();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoKardexAux
        /// En la BASE de DATO la Tabla : [Produccion.ProductoExistenciasKardex]
        /// <summary>
        /// <param name="productoKardex"></param>
        /// <returns></returns>
        public ReturnValor Insert(ProductoKardexAux productoKardex)
        {
            ReturnValor objReturnValor = new ReturnValor();
            try
            {
                //using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                //{
                    objReturnValor.codRetorno = objProductoKardexData.Insert(productoKardex);
                    if (objReturnValor.codRetorno > 0)
                    {
                        objReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                        objReturnValor.Exitosa = true;
                        //tx.Complete();
                    }
                    else
                        objReturnValor.Message = HelpMessages.KARDEX_NoRegistrado;
                //}
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat(this.GetType().Name, ".", MethodBase.GetCurrentMethod().Name), ex, productoKardex.segUsuarioEdita);
                objReturnValor = HelpException.mTraerMensaje(ex);
            }
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Actualiza el registro de una ENTIDAD de registro de Tipo ProductoKardexAux
        /// En la BASE de DATO la Tabla : [Produccion.ProductoExistenciasKardex]
        /// <summary>
        /// <param name="productoKardex"></param>
        /// <returns></returns>
        public ReturnValor UpdateKardexCierre(BaseFiltroAlmacen pFiltro)
        {
            ReturnValor objReturnValor = new ReturnValor();
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    objReturnValor.Exitosa = objProductoKardexData.UpdateKardexCierre(pFiltro);
                    if (objReturnValor.codRetorno > 0)
                    {
                        objReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        objReturnValor.Exitosa = true;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                objReturnValor = HelpException.mTraerMensaje(ex);
            }
            return objReturnValor;
        }

        /// <summary>
        /// Actualiza el registro de una ENTIDAD de registro de Tipo ProductoKardexAux
        /// En la BASE de DATO la Tabla : [Produccion.ProductoExistenciasKardex]
        /// <summary>
        /// <param name="productoKardex"></param>
        /// <returns></returns>
        public ReturnValor UpdateKardexCierreDeshacer(BaseFiltroAlmacen pFiltro)
        {
            ReturnValor objReturnValor = new ReturnValor();
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    objReturnValor.Exitosa = objProductoKardexData.UpdateKardexCierreDeshacer(pFiltro);
                    if (objReturnValor.Exitosa)
                    {
                        objReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        objReturnValor.Exitosa = true;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                objReturnValor = HelpException.mTraerMensaje(ex);
            }
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// Elimina el registro de una ENTIDAD de registro de Tipo ProductoKardexAux
        /// En la BASE de DATO la Tabla : [Produccion.ProductoExistenciasKardex]
        /// <summary>
        /// <param name="productoKardex"></param>
        /// <returns></returns>
        public ReturnValor Delete(BaseFiltroAlmacen pFiltro)
        {
            ReturnValor objReturnValor = new ReturnValor();
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    objReturnValor.Exitosa = objProductoKardexData.Delete(pFiltro);
                    if (objReturnValor.Exitosa)
                    {
                        objReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        objReturnValor.Exitosa = true;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                objReturnValor = HelpException.mTraerMensaje(ex);
            }
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Produccion.ProductoExistenciasKardex
        /// En la BASE de DATO la Tabla : [Produccion.ProductoExistenciasKardex]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<ProductoKardexAux> List(BaseFiltroAlmacen pFiltro)
        {
            List<ProductoKardexAux> lstProductoKardex = new List<ProductoKardexAux>();
            try
            {
                lstProductoKardex = objProductoKardexData.List(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductoKardex;
        }

        public List<ProductoKardexAux> ListPorDocumento(BaseFiltroAlmacen pFiltro)
        {
            List<ProductoKardexAux> lstProductoKardex = new List<ProductoKardexAux>();
            try
            {
                lstProductoKardex = objProductoKardexData.ListPorDocumento(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductoKardex;
        }

        public List<ProductoKardexAux> ListInventariado(BaseFiltroAlmacen pFiltro)
        {
            List<ProductoKardexAux> lstProductoKardex = new List<ProductoKardexAux>();
            try
            {
                lstProductoKardex = objProductoKardexData.ListInventariado(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductoKardex;
        }

        #endregion
    }

}

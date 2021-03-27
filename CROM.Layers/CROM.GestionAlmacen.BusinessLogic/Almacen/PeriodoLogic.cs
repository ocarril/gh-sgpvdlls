namespace CROM.GestionAlmacen.BusinessLogic
{
    using CROM.BusinessEntities.Almacen;
    using CROM.GestionAlmacen.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Transactions;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 16/08/2014-12:20:07 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Almacen.PeriodoLogic.cs]
    /// </summary>
    public class PeriodoLogic
    {
        private PeriodoData periodoData = null;
        private ReturnValor returnValor = null;

        public PeriodoLogic()
        {
            periodoData = new PeriodoData();
            returnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT  */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Periodo
        /// En la BASE de DATO la Tabla : [Almacen.Periodo]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEPeriodo> List(BaseFiltroPeriodo pFiltro, bool pSinCerrar = false)
        {
            List<BEPeriodo> lstPeriodo = new List<BEPeriodo>();
            try
            {
                if (pSinCerrar == false)
                    lstPeriodo = periodoData.List(pFiltro);
                else
                {
                    lstPeriodo = periodoData.List(pFiltro).FindAll(x => x.fecCierre == null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPeriodo;
        }
        public List<BEPeriodo> List(BaseFiltroPeriodo pFiltro, Helper.ComboBoxText pTexto)
        {
            List<BEPeriodo> lstPeriodo = new List<BEPeriodo>();
            try
            {
                lstPeriodo = periodoData.List(pFiltro);
                if (lstPeriodo.Count > 0)
                    lstPeriodo.Insert(0, new BEPeriodo { codPeriodo = "", desNombre = Helper.ObtenerTexto(pTexto) });
                else
                    lstPeriodo.Add(new BEPeriodo { codPeriodo = "", desNombre = Helper.ObtenerTexto(pTexto) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPeriodo;
        }
        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.Periodo
        /// En la BASE de DATO la Tabla : [Almacen.Periodo]
        /// </summary>
        /// <param name="prm_codPeriodo"></param>
        /// <returns></returns>
        public BEPeriodo Find(int pcodEmpresa, string prm_codPeriodo)
        {
            BEPeriodo miEntidad = new BEPeriodo();
            try
            {
                miEntidad = periodoData.Find(pcodEmpresa, prm_codPeriodo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miEntidad;
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
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = periodoData.Insert(pPeriodo);
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return returnValor;
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
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = periodoData.Update(pPeriodo);
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return returnValor;
        }
        /// <summary>
        ///  Realiza la apertura de periodo de inventario
        /// </summary>
        /// <param name="pPeriodo"></param>
        /// <returns></returns>
        public ReturnValor UpdateApertura(BEPeriodo pPeriodo)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = periodoData.UpdateApertura(pPeriodo);
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return returnValor;
        }
        /// <summary>
        /// Realiza el cierre de periodo de inventario
        /// </summary>
        /// <param name="pPeriodo"></param>
        /// <returns></returns>
        public ReturnValor UpdateCierre(BEPeriodo pPeriodo)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = periodoData.UpdateCierre(pPeriodo);
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return returnValor;
        }

        #endregion

        #region /* Proceso de DELETE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.Periodo
        /// En la BASE de DATO la Tabla : [Almacen.Periodo]
        /// </summary>
        /// <param name="prm_codPeriodo"></param>
        /// <returns></returns>
        public ReturnValor Delete(int pcodEmpresa, string prm_codPeriodo)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = periodoData.Delete(pcodEmpresa, prm_codPeriodo);
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return returnValor;
        }

        #endregion

    }
} 

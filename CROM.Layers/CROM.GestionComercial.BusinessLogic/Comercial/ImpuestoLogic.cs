namespace CROM.GestionComercial.BusinessLogic
{
    using CROM.BusinessEntities.Comercial;
    using CROM.GestionComercial.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Transactions;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 18/09/2010-5:10:40
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [GestionComercial.TiposDeImpuestoLogic.cs]
    /// </summary>
    public class ImpuestoLogic
    {
        private ImpuestoData objImpuestoData = null;
        private ReturnValor oReturnValor = null;

        public ImpuestoLogic()
        {
            objImpuestoData = new ImpuestoData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.TiposDeImpuesto
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposDeImpuesto]
        /// <summary>
        /// <returns>List</returns>
        public List<BEImpuesto> List(BaseFiltroImpuesto pFiltro)
        {
            List<BEImpuesto> lstImpuesto = new List<BEImpuesto>();
            try
            {
                lstImpuesto = objImpuestoData.List(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstImpuesto;
        }

        public List<BEImpuesto> List(BaseFiltroImpuesto pFiltro, Helper.ComboBoxText pTexto)
        {
            List<BEImpuesto> lstImpuesto = new List<BEImpuesto>();
            try
            {
                lstImpuesto = objImpuestoData.List(pFiltro);
                if (lstImpuesto.Count > 0)
                    lstImpuesto.Insert(0, new BEImpuesto { CodigoImpuesto = "", Descripcion = Helper.ObtenerTexto(pTexto) });
                else
                    lstImpuesto.Add(new BEImpuesto { CodigoImpuesto = "", Descripcion = Helper.ObtenerTexto(pTexto) });
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstImpuesto;
        }

        public List<BEImpuesto> ListPaged(BaseFiltroImpuestoPage pFiltro)
        {
            List<BEImpuesto> lstImpuesto = new List<BEImpuesto>();
            try
            {
                lstImpuesto = objImpuestoData.ListPaged(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstImpuesto;
        }
       
        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.Impuesto
        /// En la BASE de DATO la Tabla : [GestionComercial.Impuesto]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEImpuesto Find(int pcodEmpresa, string prm_CodigoImpuesto, string pUserActual)
        {
            BEImpuesto objImpuesto = null;
            try
            {
                objImpuesto = objImpuestoData.Find(pcodEmpresa, prm_CodigoImpuesto);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pUserActual, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return objImpuesto;
        }

        public DTOImpuestoResponse Find(BaseFiltroImpuesto pFiltro)
        {
            DTOImpuestoResponse objImpuesto = null;
            try
            {
                objImpuesto = objImpuestoData.Find(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return objImpuesto;
        }

        #endregion

        #region /* Proceso de INSERT-UPDATE RECORD */

        public ReturnValor Save(BEImpuesto objImpuesto)
        {
            var VALIDA = ValidarDatos(objImpuesto);
            if (!VALIDA.Exitosa)
                return VALIDA;

            if (string.IsNullOrEmpty(objImpuesto.CodigoImpuesto))
                oReturnValor = Insert(objImpuesto);
            else
                oReturnValor = Update(objImpuesto);
            return oReturnValor;
        }

        private ReturnValor ValidarDatos(BEImpuesto objImpuesto)
        {
            ReturnValor validado = new ReturnValor();

            if (string.IsNullOrEmpty(objImpuesto.Descripcion))
            {
                validado.Message = HelpMessages.gc_PRODUValidaDescrip;
                return validado;
            }

            validado.Exitosa = true;
            return validado;
        }

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo TiposDeImpuesto
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposDeImpuesto]
        /// <summary>
        /// <param name = >itemTiposDeImpuesto</param>
        private ReturnValor Insert(BEImpuesto objImpuesto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.CodigoRetorno = objImpuestoData.Insert(objImpuesto);
                    if (oReturnValor.CodigoRetorno != null)
                    {
                        oReturnValor.Exitosa = true;
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo TiposDeImpuesto
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposDeImpuesto]
        /// <summary>
        /// <param name = >itemTiposDeImpuesto</param>
        private ReturnValor Update(BEImpuesto objImpuesto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objImpuestoData.Update(objImpuesto);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.TiposDeImpuesto
        /// En la BASE de DATO la Tabla : [GestionComercial.TiposDeImpuesto]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(DTODeleteRequest pDelete)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor = objImpuestoData.Delete(pDelete);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        tx.Complete();
                    }
                    else
                        oReturnValor.Message = HelpMessages.VALIDACIONNoExiste;
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                           pDelete.DelUser, pDelete.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

    }
} 

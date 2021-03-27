namespace CROM.GestionComercial.BusinessLogic
{
    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.Maestros;
    using CROM.GestionComercial.DataAccess;
    using CROM.TablasMaestras.BussinesLogic;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Config;

    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Transactions;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [GestionComercial.PuntosDeVentaLogic.cs]
    /// </summary>
    public class PuntoDeVentaLogic
    {
        private PuntoDeVentaData oPuntosDeVentaData = null;
        private ReturnValor oReturnValor = null;

        public PuntoDeVentaLogic()
        {
            oPuntosDeVentaData = new PuntoDeVentaData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.PuntosDeVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.PuntosDeVenta]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEPuntoDeVenta> List(BaseFiltroPuntoDeVenta pFiltro)
        {
            List<BEPuntoDeVenta> lstPuntoDeVenta = new List<BEPuntoDeVenta>();
            try
            {
                lstPuntoDeVenta = oPuntosDeVentaData.List(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, 
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresaRUC);
                throw new Exception(returnValor.Message);
            }
            return lstPuntoDeVenta;
        }

        public List<BEPuntoDeVenta> List(BaseFiltroPuntoDeVenta pFiltro, Helper.ComboBoxText pTexto)
        {
            List<BEPuntoDeVenta> lstPuntoDeVenta = new List<BEPuntoDeVenta>();
            try
            {
                lstPuntoDeVenta = oPuntosDeVentaData.List(pFiltro);
                if (lstPuntoDeVenta.Count > 0)
                    lstPuntoDeVenta.Insert(0, new BEPuntoDeVenta{ codPuntoDeVenta = "", desNombre = Helper.ObtenerTexto(pTexto) });
                else
                    lstPuntoDeVenta.Add(new BEPuntoDeVenta{ codPuntoDeVenta = "", desNombre = Helper.ObtenerTexto(pTexto) });
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, 
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresaRUC);
                throw new Exception(returnValor.Message);
            }
            return lstPuntoDeVenta;
        }

        public List<BEPuntoDeVenta> ListPaginado(BaseFiltroPuntoDeVenta pFiltro)
        {
            List<BEPuntoDeVenta> lstPuntoDeVenta = new List<BEPuntoDeVenta>();
            try
            {
                lstPuntoDeVenta = oPuntosDeVentaData.ListPaginado(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, 
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresaRUC);
                throw new Exception(returnValor.Message);
            }
            return lstPuntoDeVenta;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.PuntosDeVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.PuntosDeVenta]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEPuntoDeVenta Find(string pcodEmpresaRUC, string prm_codPuntoDeVenta)
        {
            BEPuntoDeVenta objPuntoVenta = new BEPuntoDeVenta();
            try
            {
                objPuntoVenta = oPuntosDeVentaData.Find(pcodEmpresaRUC, prm_codPuntoDeVenta);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
                throw new Exception(returnValor.Message);
            }
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
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    PersonasLogic objPersonasLogic = new PersonasLogic();
                    BEPersona objPersonas = objPersonasLogic.Find(objPuntoDeVenta.codEmpresa ,
                                                                  objPuntoDeVenta.codPersonaEmpre,
                                                                  objPuntoDeVenta.segUsuarioCrea);

                    string prm_Prefijo = objPersonasLogic.AtributoPersona(objPersonas, 
                                                                          ConfigCROM.AppConfig(objPuntoDeVenta.codEmpresa,
                                                                                               ConfigTool.DEFAULT_PrefijoPtoVta));

                    oReturnValor.CodigoRetorno = oPuntosDeVentaData.Insert(objPuntoDeVenta, prm_Prefijo);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo PuntosDeVenta
        /// En la BASE de DATO la Tabla : [GestionComercial.PuntosDeVenta]
        /// <summary>
        /// <param name="objPuntoDeVenta"></param>
        /// <returns></returns>
        public ReturnValor Update(BEPuntoDeVenta objPuntoDeVenta)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oPuntosDeVentaData.Update(objPuntoDeVenta);
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
        /// 
        /// </summary>
        /// <param name="prm_codPuntoDeVenta"></param>
        /// <returns></returns>
        public ReturnValor Delete(string prm_codPuntoDeVenta)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oPuntosDeVentaData.Delete(prm_codPuntoDeVenta);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
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

    }
} 

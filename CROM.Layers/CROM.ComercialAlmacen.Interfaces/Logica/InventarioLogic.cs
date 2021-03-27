namespace CROM.ComercialAlmacen.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Transactions;

    using CROM.BusinessEntities.Almacen;
    using CROM.GestionAlmacen.DataAccess;
    using CROM.GestionComercial.DataAccess;
    using CROM.BusinessEntities.Maestros;
    using CROM.TablasMaestras.BussinesLogic;
    using CROM.BusinessEntities.RecursosHumanos;
    using CROM.RecursosHumanos.BusinessLogic;
    using CROM.GestionComercial.BusinessLogic;
    using CROM.Tools;
    using CROM.Tools.Comun;
    using CROM.Tools.Config;
    using CROM.BusinessEntities.Comercial;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 05/09/2010-04:41:47 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Almacen.Inventarios.cs]
    /// </summary>
    public class InventarioLogic
    {
        private InventarioData inventarioData = null;
        private InventarioSerieData inventarioSerieData = null;
        private ReturnValor returnValor = null;
        public InventarioLogic()
        {
            inventarioData = new InventarioData();
            inventarioSerieData = new InventarioSerieData();
            returnValor = new ReturnValor();
        }

        #region /*TABLA: Inventario*/

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.Inventarios
        /// En la BASE de DATO la Tabla : [GestionComercial.Inventarios]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<InventarioAux> List(BaseFiltroAlmacen filtro)
        {
            List<InventarioAux> lstInventario = new List<InventarioAux>();
            try
            {
                lstInventario = inventarioData.List(filtro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInventario;
        }
        public List<InventarioAux> ListInventariosCerrar(BaseFiltroAlmacen filtro)
        {
            List<InventarioAux> lstInventario = new List<InventarioAux>();
            try
            {
                lstInventario = inventarioData.ListInventariosCerrar(filtro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInventario;
        }

        public List<InventarioAux> ListInventariosMermaSobrante(BaseFiltroAlmacen objBaseFiltro)
        {
            List<InventarioAux> lstInventario = new List<InventarioAux>();
            try
            {
                lstInventario = inventarioData.ListInventariosMermaSobrante(objBaseFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInventario;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Inventarios
        /// En la BASE de DATO la Tabla : [GestionComercial.Inventarios]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<BEInventario> ListProductosInventariados(BaseFiltroAlmacen pFiltro)
        {
            List<BEInventario> lstInventario = new List<BEInventario>();
            try
            {
                lstInventario = inventarioData.ListCons_Paged(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInventario;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.Inventarios
        /// En la BASE de DATO la Tabla : [Almacen.Inventarios]
        /// <summary>
        /// <param name="prm_codInventario"></param>
        /// <returns></returns>
        public InventarioAux Find(int prm_codInventario)
        {
            InventarioAux inventario = new InventarioAux();
            try
            {
                inventario = inventarioData.Find(prm_codInventario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return inventario;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */


        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Inventarios
        /// En la BASE de DATO la Tabla : [Almacen.Inventarios]
        /// <summary>
        /// <param name="lstInventario"></param>
        /// <returns></returns>
        public ReturnValor Insert(List<InventarioAux> lstInventario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {

                    returnValor.codRetorno = inventarioData.Insert(lstInventario);

                    if (returnValor.codRetorno != 0)
                        returnValor.Exitosa = true;

                    if (returnValor.Exitosa)
                    {
                        returnValor.Exitosa = true;
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Inventarios
        /// En la BASE de DATO la Tabla : [Almacen.Inventarios]
        /// <summary>
        /// <param name="inventario"></param>
        /// <returns></returns>
        public ReturnValor Update(InventarioAux inventario)
        {
            try
            {
                ReturnValor returnValorSeries = new ReturnValor();
                returnValorSeries.Exitosa = true;
                EmpleadoAux empleado = new EmpleadoAux();
                EmpleadoLogic empleadoLogic = new EmpleadoLogic();
                int? codEmpleado = null;
                decimal cntCantidadFisicas = 0;
                decimal cntCantidadContada = 0;
                if (inventario.NumeroDeConteo == 1)
                {
                    empleado = empleadoLogic.Find(inventario.ConteoEmpleado);
                    codEmpleado = inventario.Conteo01Empleado;
                    cntCantidadContada = inventario.Conteo01;
                    cntCantidadFisicas = inventario.cntOrigStockFisico;
                }
                else if (inventario.NumeroDeConteo == 2)
                {
                    empleado = empleadoLogic.Find(inventario.ConteoEmpleado);
                    codEmpleado = inventario.Conteo02Empleado;
                    cntCantidadContada = inventario.Conteo02;
                    cntCantidadFisicas = inventario.cntOrigStockFisico;
                }
                else if (inventario.NumeroDeConteo == 3)
                {
                    empleado = empleadoLogic.Find(inventario.ConteoEmpleado);
                    codEmpleado = inventario.Conteo03Empleado;
                    cntCantidadContada = inventario.Conteo03;
                    cntCantidadFisicas = inventario.cntOrigStockFisico;
                }
                else if (inventario.NumeroDeConteo == 4)
                {
                    empleado = empleadoLogic.Find(inventario.ConteoEmpleado);
                    cntCantidadContada = inventario.Conteo04;
                    cntCantidadFisicas = inventario.cntOrigStockFisico;
                }

                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (empleado.codEmpleado != 0)
                    {
                        returnValor.Exitosa = inventarioData.Update(inventario);
                        if (inventario.lstInventarioSerie.Count > 0)
                        {
                            List<BEInventarioSerie> lstInventarioSerie = new List<BEInventarioSerie>();
                            lstInventarioSerie = ListInventarioSerie(new BaseFiltroAlmacen
                            {
                                codInventario = inventario.codInventario,
                                cntConteo = inventario.NumeroDeConteo
                            });
                            foreach (BEInventarioSerie itemInventarioSerie in lstInventarioSerie)
                                DeleteInventarioSerie(new BaseFiltroAlmacen
                                {
                                    codInventario = itemInventarioSerie.codInventario,
                                    codProductoSeriado = itemInventarioSerie.codProductoSeriado,
                                    cntConteo = itemInventarioSerie.numConteo
                                });
                            returnValorSeries = InsertInventarioSerie(inventario.lstInventarioSerie);
                        }
                        if (returnValor.Exitosa)
                        {
                            returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                            tx.Complete();
                        }
                    }
                    else
                        returnValor.Message = HelpMessages.VALIDACIONEmpleado + " - Código [ " + inventario.ConteoEmpleado + " ] no existe.";
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return returnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.Inventarios
        /// En la BASE de DATO la Tabla : [Almacen.Inventarios]
        /// <summary>
        /// <param name="prm_codInventario"></param>
        /// <returns></returns>
        public ReturnValor Delete(int intCodInventario) //string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, string prm_codDeposito, string prm_CodigoFormaPago, string prm_Periodo)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = inventarioData.Delete(intCodInventario); //prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta, prm_codDeposito,prm_CodigoFormaPago, prm_Periodo);
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

        #endregion

        #region /*TABLA: InventarioSerie*/

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.InventarioSerie
        /// En la BASE de DATO la Tabla : [Almacen.InventarioSerie]
        /// <summary>
        /// <returns>List</returns>
        public List<BEInventarioSerie> ListInventarioSerieBusca(BaseFiltroAlmacen prmFiltro)
        {
            List<BEInventarioSerie> lstInventarioSerie = new List<BEInventarioSerie>();
            try
            {
                lstInventarioSerie = inventarioSerieData.List(prmFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInventarioSerie;
        }

        /// <summary>
        /// Lista los registros de inventario serie por Periodo de inventario y conteo
        /// </summary>
        /// <param name="prmFiltro"></param>
        /// <returns></returns>
        public List<BEInventarioSerie> ListInventarioSeriePorPeriodo(BaseFiltroAlmacen prmFiltro)
        {
            List<BEInventarioSerie> lstInventarioSerie = new List<BEInventarioSerie>();
            try
            {
                lstInventarioSerie = inventarioSerieData.ListPorPeriodo(prmFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInventarioSerie;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.InventarioSerie
        /// En la BASE de DATO la Tabla : [Almacen.InventarioSerie]
        /// <summary>
        /// <returns>List</returns>
        public List<BEInventarioSerie> ListInventarioSerie(BaseFiltroAlmacen pFiltro)
        {
            List<BEInventarioSerie> lstInventarioSerie = new List<BEInventarioSerie>();
            try
            {
                lstInventarioSerie = inventarioSerieData.List(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstInventarioSerie;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.InventarioSerie
        /// En la BASE de DATO la Tabla : [Almacen.InventarioSerie]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor DeleteInventarioSerie(BaseFiltroAlmacen prm_Filtro)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = inventarioSerieData.Delete(prm_Filtro);
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpMessages.Evento_DELETE;
                        tx.Complete();
                    }
                    else
                        returnValor.Message = HelpMessages.gc_DOCUM_NoGuardado;
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return returnValor;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo InventarioSerie
        /// En la BASE de DATO la Tabla : [Almacen.InventarioSerie]
        /// <summary>
        /// <param name = >itemInventarioSerie</param>
        public ReturnValor InsertInventarioSerie(List<BEInventarioSerie> lstInventarioSerie)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = inventarioSerieData.Insert(lstInventarioSerie);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo InventarioSerie
        /// En la BASE de DATO la Tabla : [Almacen.InventarioSerie]
        /// <summary>
        /// <param name = >itemInventarioSerie</param>
        public ReturnValor UpdateInventarioSerie(List<BEInventarioSerie> lstInventarioSerie)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = inventarioSerieData.Update(lstInventarioSerie);
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        tx.Complete();
                    }
                    else
                        returnValor.Message = HelpMessages.gc_DOCUM_NoGuardado;
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return returnValor;
        }

        #endregion

        #endregion
    }
}

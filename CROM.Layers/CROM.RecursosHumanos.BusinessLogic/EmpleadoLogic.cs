namespace CROM.RecursosHumanos.BusinessLogic
{
    using CROM.BusinessEntities.RecursosHumanos;
    using CROM.BusinessEntities.RecursosHumanos.DTO;
    using CROM.RecursosHumanos.DataAcces;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Transactions;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/08/2013-05:58:47 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [RecursosHumanos.EmpleadoLogic.cs]
    /// </summary>
    public class EmpleadoLogic : BaseLayer
    {
        private EmpleadoData empleadoData = null;
        private ReturnValor returnValor = null;

        public EmpleadoLogic()
		{
            empleadoData = new EmpleadoData();
			returnValor = new ReturnValor();
		}

        #region /* Proceso de INSERT RECORD */

        public ReturnValor Save(BEEmpleadoRequest pEmpresa)
        {
            if (pEmpresa.codEmpleado == 0)
                returnValor = Insert(pEmpresa);
            else if (pEmpresa.codEmpresa > 0)
                returnValor = Update(pEmpresa);

            return returnValor;
        }

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo EmpleadoAux
        /// En la BASE de DATO la Tabla : [Almacen.EmpleadoAux]
        /// <summary>
        /// <param name = >empleado</param>
        private ReturnValor Insert(BEEmpleadoRequest empleado)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = empleadoData.Insert(empleado);
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                        returnValor.Exitosa = true;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex, false,
                                string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                                empleado.segUsuarioEdita, empleado.codEmpresa.ToString());
            }
            return returnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo EmpleadoAux
        /// En la BASE de DATO la Tabla : [Almacen.EmpleadoAux]
        /// <summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
        private ReturnValor Update(BEEmpleadoRequest empleado)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = empleadoData.Update(empleado);
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex, false,
                                string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name), 
                                empleado.segUsuarioEdita, empleado.codEmpresa.ToString());

            }
            return returnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.EmpleadoAux
        /// En la BASE de DATO la Tabla : [Almacen.EmpleadoAux]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(int pcodEmpresa, int pcodEmpleado, string pUser, string pMaquina)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = empleadoData.Delete(pcodEmpresa, pcodEmpleado, pUser, pMaquina);
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex, false,
                                string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                                pUser, pcodEmpresa.ToString());
            }
            return returnValor;
        }

        #endregion

        #region /* Proceso de SELECT ALL */

        public OperationResult ListPaged(BEBuscaEmpleadoRequest pFiltro)
        {
            try
            {
                var lstEmpresa = empleadoData.ListPaged(pFiltro);
               
                return OK(lstEmpresa);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pFiltro.segUsuarioActual, pFiltro.codEmpresa);
            }
            finally
            {
                if (empleadoData != null)
                {
                    empleadoData.Dispose();
                    empleadoData = null;
                }
            }
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad RecursosHumanos.Empleado
        /// En la BASE de DATO la Tabla : [RecursosHumanos.Empleado]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public OperationResult List(BaseFiltroEmpleado filtro)
        {
            List<BEEmpleado> lstEmpleado = new List<BEEmpleado>();
            try
            {
                lstEmpleado = empleadoData.List(filtro);
                return OK(lstEmpleado);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, filtro.segUsuarioActual, filtro.codEmpresa);
            }
        }

        public OperationResult List(BaseFiltroEmpleado filtro, Helper.ComboBoxText pTexto)
        {
            List<BEEmpleado> lstEmpleado = new List<BEEmpleado>();
            try
            {
                lstEmpleado = empleadoData.List(filtro);
                if (lstEmpleado.Count > 0)
                    lstEmpleado.Insert(0, new BEEmpleado { codEmpleado = 0, desEmpleado = Helper.ObtenerTexto(pTexto) });
                else
                    lstEmpleado.Add(new BEEmpleado { codEmpleado = 0, desEmpleado = Helper.ObtenerTexto(pTexto) });

                return OK(lstEmpleado);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, filtro.segUsuarioActual, filtro.codEmpresa);
            }
        }

        #endregion 

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.Empleado
        /// En la BASE de DATO la Tabla : [Almacen.Empleado]
        /// <summary>
        /// <param name="prm_codEmpleado"></param>
        /// <returns></returns>
        public OperationResult Find(int pcodEmpresa, int pcodEmpleado, string pUser)
        {
            BEEmpleado empleado = new BEEmpleado();
            try
            {
                empleado = empleadoData.Find(pcodEmpresa, pcodEmpleado);
                return OK(empleado);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pUser, pcodEmpresa);
            }
        }

        public OperationResult FindByPlanilla(int pcodEmpresa, string pcodPlanilla, string pUser)
        {
            BEEmpleado empleado = new BEEmpleado();
            try
            {
                empleado = empleadoData.FindByPlanilla(pcodEmpresa, pcodPlanilla);
                return OK(empleado);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pUser, pcodEmpresa);
            }
        }

        public OperationResult Find(int pcodEmpresa, string pcodPersonaEmpresa, string pcodPersonaNatural, string pUser)
        {
            BEEmpleado empleado = null;
            try
            {
                empleado = empleadoData.Find(pcodEmpresa, pcodPersonaEmpresa, pcodPersonaNatural);
                return OK(empleado);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pUser, pcodEmpresa);
            }
            
        }
   
        #endregion 
    }
}


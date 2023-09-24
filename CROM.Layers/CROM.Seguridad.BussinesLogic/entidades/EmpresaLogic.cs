namespace CROM.Seguridad.BussinesLogic
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Seguridad.DataAcces;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Linq;
    using System.Reflection;
    using System.Transactions;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 8/10/2019-15:55:25
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Seguridad.EmpresaLogic.cs]
    /// </summary>
    public class EmpresaLogic : BaseLayer
    {
        private EmpresaData oEmpresaData = null;
        private EmpresaSistemaData oEmpresaSistemaData = null;
        private EmpresaUsuarioData oEmpresaUsuarioData = null;
        private EmpresaSistemaLicenciaData oEmpresaSistemaLicenciaData = null;
        private ReturnValor oReturnValor = null;

        public EmpresaLogic()
        {
            oEmpresaData = new EmpresaData();
            oEmpresaSistemaData = new EmpresaSistemaData();
            oEmpresaUsuarioData = new EmpresaUsuarioData();
            oEmpresaSistemaLicenciaData = new EmpresaSistemaLicenciaData();
            oReturnValor = new ReturnValor();
        }

        #region /* EMPRESA  Proceso de SELECT ALL */ 

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Seguridad.Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <returns>List</returns>
        public OperationResult ListPaged(BEBuscaEmpresaRequest pFiltro)
        {
            try
            {
                var lstEmpresa = oEmpresaData.ListPaged(pFiltro);
                int totalRecords = lstEmpresa.Select(x => x.TOTALROWS).FirstOrDefault();
                int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pFiltro.jqPageSize);
                var jsonGrid = new
                {
                    PageCount = totalPages,
                    CurrentPage = pFiltro.jqCurrentPage,
                    RecordCount = totalRecords,
                    Items = (
                        from item in lstEmpresa
                        select new
                        {
                            ID = item.codEmpresa,
                            Row = new string[] {string.Empty
                                              , string.Empty
                                              , item.numRUC
                                              , item.nomRazonSocial
                                              , item.nomContacto
                                              , item.desCorreo
                                              , item.nomLogo
                                              , item.desPaginaWeb
                                              , item.indActivo.ToString()
                                              , item.segUsuarioEdita
                                              , item.segFechaEdita.ToString()
                            }
                        }).ToArray()
                };
                return OK(jsonGrid);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pFiltro.userActual, pFiltro.codEmpresa);
            }
            finally
            {
                if (oEmpresaData != null)
                {
                    oEmpresaData.Dispose();
                    oEmpresaData = null;
                }
            }
        }

        #endregion

        #region /* EMPRESA  Proceso de SELECT BY ID CODE */ 

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Seguridad.Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <returns>Entidad</returns>
        public OperationResult Find(int pcodEmpresa)
        {
            BEEmpresa objEmpresa = new BEEmpresa();
            try
            {
                objEmpresa = oEmpresaData.Find(pcodEmpresa);
                return OK(objEmpresa);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, "", "");
            }
        }

        #endregion

        #region /* EMPRESA  Proceso de INSERT RECORD */ 

        public ReturnValor Save(BEEmpresaRequest pEmpresa)
        {
            if (pEmpresa.codEmpresa == 0)
                oReturnValor = Insert(pEmpresa);
            else if (pEmpresa.codEmpresa > 0)
                oReturnValor = Update(pEmpresa);

            return oReturnValor;
        }
        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <param name = >itemEmpresa</param>
        private ReturnValor Insert(BEEmpresaRequest pEmpresa)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oEmpresaData.Insert(pEmpresa);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_NEW;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex,false);
            }
            return oReturnValor;
        }

        #endregion

        #region /* EMPRESA  Proceso de UPDATE RECORD */ 

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <param name = >itemEmpresa</param>
        private ReturnValor Update(BEEmpresaRequest pEmpresa)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oEmpresaData.Update(pEmpresa);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_EDIT;
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

        #region /* EMPRESA  Proceso de DELETE BY ID CODE */ 

        /// <summary>
        /// ELIMINA un registro de la Entidad Seguridad.Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(BEEmpresaRequest pEmpresa)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oEmpresaData.Delete(pEmpresa);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex,false, string.Concat(GetType().Name,".", MethodBase.GetCurrentMethod().Name), 
                                                           pEmpresa.segUsuarioEdita, pEmpresa.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion


        #region /* EMPRESA-SISTEMA  Proceso de SELECT ALL */ 

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Seguridad.Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <returns>List</returns>
        public OperationResult ListEmpresaSistemaPaged(BEBuscaEmpresaSistemaRequest pFiltro)
        {
            try
            {
                var lstEmpresa = oEmpresaSistemaData.ListPaged(pFiltro);
                int totalRecords = lstEmpresa.Select(x => x.TOTALROWS).FirstOrDefault();
                int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pFiltro.jqPageSize);
                var jsonGrid = new
                {
                    PageCount = totalPages,
                    CurrentPage = pFiltro.jqCurrentPage,
                    RecordCount = totalRecords,
                    Items = (
                        from item in lstEmpresa
                        select new
                        {
                            ID = item.codEmpresaSistema,
                            Row = new string[] {string.Empty
                                              , string.Empty
                                              , item.nomEmpresa
                                              , item.nomSistema
                                              , item.fecInicio.ToShortDateString()
                                              , item.fecFinal.ToShortDateString()
                                              , item.numTiempoToken.ToString()
                                              , item.indActivo.ToString()
                                              , item.segUsuarioEdita
                                              , item.segFechaEdita.ToString()
                            }
                        }).ToArray()
                };
                return OK(jsonGrid);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pFiltro.userActual, pFiltro.codEmpresa);
            }
            finally
            {
                if (oEmpresaData != null)
                {
                    oEmpresaData.Dispose();
                    oEmpresaData = null;
                }
            }
        }

        #endregion

        #region /* EMPRESA-SISTEMA  Proceso de SELECT BY ID CODE */ 

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Seguridad.Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <returns>Entidad</returns>
        public OperationResult FindEmpresaSistema(int pcodEmpresaSistema)
        {
            BEEmpresaSistema objEmpresaSistema = new BEEmpresaSistema();
            try
            {
                objEmpresaSistema = oEmpresaSistemaData.Find(pcodEmpresaSistema);
                return OK(objEmpresaSistema);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, "", "");
            }
        }

        public BEEmpresaSistema FindEmpresaSistema(int pcodEmpresa, string pcodSistema)
        {
            BEEmpresaSistema objEmpresaSistema = new BEEmpresaSistema();
            try
            {
                objEmpresaSistema = oEmpresaSistemaData.Find(pcodEmpresa, pcodSistema);
                return objEmpresaSistema;
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
                throw new Exception(oReturnValor.Message);
            }
        }

        #endregion

        #region /* EMPRESA-SISTEMA  Proceso de INSERT RECORD */ 

        public ReturnValor SaveEmpresaSistema(BEEmpresaSistemaRequest pEmpresaSistema)
        {
            if (pEmpresaSistema.codEmpresaSistema == 0)
                oReturnValor = InsertEmpresaSistema(pEmpresaSistema);
            else if (pEmpresaSistema.codEmpresaSistema > 0)
                oReturnValor = UpdateEmpresaSistema(pEmpresaSistema);

            return oReturnValor;
        }
        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <param name = >itemEmpresa</param>
        private ReturnValor InsertEmpresaSistema(BEEmpresaSistemaRequest pEmpresaSistema)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oEmpresaSistemaData.Insert(pEmpresaSistema);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_NEW;
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

        #region /* EMPRESA-SISTEMA  Proceso de UPDATE RECORD */ 

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <param name = >itemEmpresa</param>
        private ReturnValor UpdateEmpresaSistema(BEEmpresaSistemaRequest pEmpresaSistema)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oEmpresaSistemaData.Update(pEmpresaSistema);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_EDIT;
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

        #region /* EMPRESA-SISTEMA  Proceso de DELETE BY ID CODE */ 

        /// <summary>
        /// ELIMINA un registro de la Entidad Seguridad.Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor DeleteEmpresaSistema(BEEmpresaSistemaRequest pEmpresaSistema)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oEmpresaSistemaData.Delete(pEmpresaSistema);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                                                           pEmpresaSistema.segUsuarioEdita, pEmpresaSistema.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion


        #region /* EMPRESA-USUARIO  Proceso de SELECT ALL */ 

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Seguridad.Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <returns>List</returns>
        public OperationResult ListEmpresaUsuarioPaged(BEBuscaEmpresaUsuarioRequest pFiltro)
        {
            try
            {
                var lstEmpresa = oEmpresaUsuarioData.ListPaged(pFiltro);
                int totalRecords = lstEmpresa.Select(x => x.TOTALROWS).FirstOrDefault();
                int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pFiltro.jqPageSize);
                var jsonGrid = new
                {
                    PageCount = totalPages,
                    CurrentPage = pFiltro.jqCurrentPage,
                    RecordCount = totalRecords,
                    Items = (
                        from item in lstEmpresa
                        select new
                        {
                            ID = item.codEmpresaUsuario,
                            Row = new string[] {string.Empty
                                              , string.Empty
                                              , item.desLogin
                                              , item.nomUsuario
                                              , item.codUsuarioKey
                                              , item.nomEmpresa
                                              , item.indActivo.ToString()
                                              , item.segUsuarioEdita
                                              , item.segFechaEdita.ToString()
                            }
                        }).ToArray()
                };
                return OK(jsonGrid);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pFiltro.userActual, pFiltro.codEmpresa);
            }
            finally
            {
                if (oEmpresaData != null)
                {
                    oEmpresaData.Dispose();
                    oEmpresaData = null;
                }
            }
        }

        #endregion

        #region /* EMPRESA-USUARIO  Proceso de SELECT BY ID CODE */ 

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Seguridad.Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <returns>Entidad</returns>
        public OperationResult FindEmpresaUsuario(int pcodEmpresaUsuario)
        {
            BEEmpresaUsuario objEmpresaUsuario = new BEEmpresaUsuario();
            try
            {
                objEmpresaUsuario = oEmpresaUsuarioData.Find(pcodEmpresaUsuario);
                return OK(objEmpresaUsuario);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, "", "");
            }
        }

        #endregion

        #region /* EMPRESA-USUARIO  Proceso de INSERT RECORD */ 

        public ReturnValor SaveEmpresaUsuario(BEEmpresaUsuarioRequest pEmpresaUsuario)
        {
            if (pEmpresaUsuario.codEmpresaUsuario == 0)
                oReturnValor = InsertEmpresaUsuario(pEmpresaUsuario);
            else if (pEmpresaUsuario.codEmpresaUsuario > 0)
                oReturnValor = UpdateEmpresaUsuario(pEmpresaUsuario);

            return oReturnValor;
        }
     
        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <param name = >itemEmpresa</param>
        private ReturnValor InsertEmpresaUsuario(BEEmpresaUsuarioRequest pEmpresaUsuario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    string pMessage = string.Empty;
                    oReturnValor.Exitosa = oEmpresaUsuarioData.Insert(pEmpresaUsuario, out pMessage);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_NEW;
                        tx.Complete();
                    }
                    else
                        oReturnValor.Message = pMessage;
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* EMPRESA-USUARIO  Proceso de UPDATE RECORD */ 

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <param name = >itemEmpresa</param>
        private ReturnValor UpdateEmpresaUsuario(BEEmpresaUsuarioRequest pEmpresaUsuario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oEmpresaUsuarioData.Update(pEmpresaUsuario);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_EDIT;
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

        #region /* EMPRESA-USUARIO  Proceso de DELETE BY ID CODE */ 

        /// <summary>
        /// ELIMINA un registro de la Entidad Seguridad.Empresa
        /// En la BASE de DATO la Tabla : [Seguridad.Empresa]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor DeleteEmpresaUsuario(BEEmpresaUsuarioRequest pEmpresaUsuario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oEmpresaUsuarioData.Delete(pEmpresaUsuario);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                                                           pEmpresaUsuario.segUsuarioEdita, pEmpresaUsuario.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion


        #region /* EMPRESA-SISTEMA-LICENCIA  Proceso de SELECT ALL PAGED*/ 

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Seguridad.EmpresaLicencia
        /// En la BASE de DATO la Tabla : [Seguridad.ESLicencia]
        /// <summary>
        /// <returns>List</returns>
        public OperationResult ListEmpresaSistemaLicenciaPaged(BEBuscaEmpresaSistemaLicenciaRequest pFiltro)
        {
            try
            {
                var lstEmpresa = oEmpresaSistemaLicenciaData.ListPaged(pFiltro);
                int totalRecords = lstEmpresa.Select(x => x.TOTALROWS).FirstOrDefault();
                int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pFiltro.jqPageSize);
                var jsonGrid = new
                {
                    PageCount = totalPages,
                    CurrentPage = pFiltro.jqCurrentPage,
                    RecordCount = totalRecords,
                    Items = (
                        from item in lstEmpresa
                        select new
                        {
                            ID = item.codEmpresaSistema,
                            Row = new string[] {string.Empty
                                              , string.Empty
                                              , item.fecInicio.ToShortDateString()
                                              , item.fecFinal.ToShortDateString()
                                              , item.numTiempoToken.ToString()
                                              , item.indActivo.ToString()
                                              , item.segUsuarioEdita
                                              , item.segFechaEdita.ToString()
                            }
                        }).ToArray()
                };
                return OK(jsonGrid);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pFiltro.userActual, pFiltro.codEmpresa);
            }
            finally
            {
                if (oEmpresaData != null)
                {
                    oEmpresaData.Dispose();
                    oEmpresaData = null;
                }
            }
        }

        #endregion

    }
}
namespace CROM.TablasMaestras.BussinesLogic
{
    using CROM.BusinessEntities.Maestros;
    using CROM.TablasMaestras.DataAcces;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Transactions;

    /// <summary>
    /// Proyecto    : Control de Asistencia
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 01/08/2009
    /// Descripcion : Clase para capa de negocio
    /// Archivo     : MaestroLogic.cs
    /// </summary>
    public class MaestroLogic
    {
        private TablaData oTablaData = null;
        private TablaRegistroData oTablaRegistroData = null;
        private ReturnValor oReturn = null;

        public MaestroLogic()
        {
            oTablaData = new TablaData();
            oTablaRegistroData = new TablaRegistroData();
            oReturn = new ReturnValor();
        }
        
        //string msjCodigoMaestroYaExiste = "El Codigo de la Tabla Maestra ya se encuentra Registrado.";
        //string msjDescripcionMaestroYaExiste = "El Nombre de la Tabla Maestra ya se encuentra Registrado.";
        //string msjCodigoDetalleYaExiste = "El Codigo de la Tabla Detalle ya se encuentra Registrado.";
        //string msjDescripcionDetalleEspanolYaExiste = "El Nombre de la Tabla Detalle en ESPAÑOL ya se encuentra Registrado.";
        //string msjDescripcionDetalleInglesYaExiste = "El Nombre de la Tabla Detalle en INGLES ya se encuentra Registrado.";
        //string msjExisteDependenciaDetalle = "Existe Dependencia de registros de la Tabla Detalle.";
        //string msjExisteDependenciaMaestro = "Existe Dependencia de registros de la Tabla Maestra.";
        public enum FiltroMaestro : int
        {
            Todos = 1,
            Codigo = 2,
            DescripcionCoincidencia = 3,
            DescripcionLiteral = 4
        }

        public enum FiltroDetalle : int
        {
            PorTablaMaestra = 1,
            PorCodigoArgumento = 2,
            PorDescripcionCoincidencia = 3,
            PorDescripcionLiteral = 4,
            PorNivel = 5,
            PorUnNivelInferior = 6
        }

        public enum EstadoDetalle : int
        {
            Deshabilitado = 0,
            Habilitado = 1,
            PorValidar = 2,
            Todos = 3,
            Habilitado_PorValidar = 4
        }

        public enum TipoLongitudDetalle : int
        {
            Larga = 0,
            Corta = 1,
        }

        public string ObtenerCodigoCorrelativo(string pCodTabla, string pTipoDato, int pNivel, int pLongNivel, string pCodPadre,
                                               int pcodEmpresa, string pSegUsuario)
        {
            string codigoGenerado = String.Empty;
            try
            {
                codigoGenerado = oTablaRegistroData.ObtenerCodigoCorrelativo(pCodTabla, pTipoDato, pNivel, pLongNivel, pCodPadre);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pSegUsuario, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return codigoGenerado;
        }

        //-------------------------------------------------------------------
        //Nombre:	ListarMaestro
        //Objetivo: Retorna una colección de registros de tipo TEMaestro
        //Valores Prueba: 
        //Creacion: WF(JAZH) 20080917 - REQ:XXX
        //Modificacion: WF(JAZH) 20080917 - REQ:XXX
        //-------------------------------------------------------------------
        public List<BETablaMaestra> ListarMaestro(FiltroMaestro pCaso, string pCodTabla, string pNomTabla, bool? p_Estado, 
                                                  int pcodEmpresa, string pSegUsuario)
        {
            List<BETablaMaestra> lista = null;
            try
            {
                lista = this.oTablaData.Listar(Convert.ToInt32(pCaso), pCodTabla, pNomTabla, p_Estado);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pSegUsuario, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lista;
        }

        public List<BETablaMaestra> ListarTablaPaginado(BaseFiltroMaestro pFiltro)
        {
            List<BETablaMaestra> lista = new List<BETablaMaestra>();
            try
            {
                lista = this.oTablaData.ListarPaginado(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             pFiltro.segUsuario, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lista;
        }


        //-------------------------------------------------------------------
        //Nombre:	RegistrarMaestro
        //Objetivo: Almacena el registro de un objeto de tipo
        //          TEMaestro
        //Valores Prueba: 
        //Creacion: WF(JAZH) 20080917 - REQ:XXX
        //Modificacion: WF(JAZH) 20080917 - REQ:XXX
        //-------------------------------------------------------------------
        public ReturnValor RegistrarMaestro(BETablaMaestra pItem)
        {
            try
            {

                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oTablaData.Registrar(pItem);
                    if (oReturn.Exitosa)
                    {
                        oReturn.Message = HelpMessages.Evento_NEW;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                      pItem.SegUsuarioEdita, pItem.codEmpresa.ToString());
            }
            return oReturn;
        }

        //-------------------------------------------------------------------
        //Nombre:	ActualizarMaestro
        //Objetivo: Actualiza el registro de un objeto de tipo TEMaestro
        //Valores Prueba: 
        //Creacion: WF(JAZH) 20080917 - REQ:XXX
        //Modificacion: WF(JAZH) 20080917 - REQ:XXX
        //-------------------------------------------------------------------
        public ReturnValor ActualizarMaestro(BETablaMaestra pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oTablaData.Actualizar(pItem);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessages.Evento_EDIT;
                    }
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                      pItem.SegUsuarioEdita, pItem.codEmpresa.ToString());
            }
            return oReturn;
        }

        //-------------------------------------------------------------------
        //Nombre:	EliminarMaestro
        //Objetivo: Elimina el registro de un objeto de tipo TEMaestro
        //Valores Prueba: 
        //Creacion: WF(JAZH) 20080917 - REQ:XXX
        //Modificacion: WF(JAZH) 20080917 - REQ:XXX
        //-------------------------------------------------------------------
        public ReturnValor EliminarMaestro(string pCodigoItem,int pcodEmpresa, string pSegUsuario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oTablaData.Eliminar(pCodigoItem);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessages.Evento_DELETE;
                    }
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                      pSegUsuario, pcodEmpresa.ToString());
            }
            return oReturn;
        }

        //-------------------------------------------------------------------
        //Nombre:	ListarDetalle
        //Objetivo: Retorna una colección de registros de tipo TEDetalle
        //Valores Prueba: 
        //Creacion: WF(JAZH) 20080917 - REQ:XXX
        //Modificacion: WF(JAZH) 20080917 - REQ:XXX
        //-------------------------------------------------------------------
        public List<BERegistro> ListDetalle(FiltroDetalle pCaso, string pCodTabla, string pCodArgu, string pDescripcion, int pNivel,
                                            int pcodEmpresa, string pSegUsuario)
        {
            List<BERegistro> lista = null;
            try
            {
                lista = oTablaRegistroData.Listar(Convert.ToInt32(pCaso), pCodTabla, pCodArgu, pDescripcion, pNivel);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             pSegUsuario, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lista;
        }

        public List<BERegistro> ListarRegistroPaginado(BaseFiltroMaestro pFiltro)
        {
            List<BERegistro> lista = new List<BERegistro>();
            try
            {
                lista = oTablaRegistroData.ListarPaginado(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             pFiltro.segUsuario, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lista;
        }

        //-------------------------------------------------------------------
        //Nombre:	ListarComboDetalle
        //Objetivo: Retorna una colección de registros de tipo TEDetalle
        //Valores Prueba: 
        //Creacion: WF(JAZH) 20080917 - REQ:XXX
        //Modificacion: WF(JAZH) 20080917 - REQ:XXX
        //-------------------------------------------------------------------
        public List<BERegistro> ListarComboDetalle(string pCodTabla, string pCodArgu, int pNivel, EstadoDetalle pEstado, 
                                                   int pcodEmpresa, string pSegUsuario)
        {
            List<BERegistro> lista = null;
            try
            {
                lista = this.oTablaRegistroData.ListarCombo(Convert.ToInt32(pEstado) < 3 ? "=" : ">", pCodTabla, pCodArgu, pNivel, Convert.ToInt32(pEstado) < 3 ? Convert.ToInt32(pEstado) : Convert.ToInt32(pEstado) - 3);
                if (lista.Count == 0)
                {
                    lista.Add(new BERegistro() { CodigoTabla = "", CodigoArgumento = "", DescripcionCorta = "", DescripcionLarga = "" });
                }
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pSegUsuario, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lista;
        }

        //-------------------------------------------------------------------
        //Nombre:	RegistrarDetalle
        //Objetivo: Almacena el registro de un objeto de tipo
        //          TEDetalle
        //Valores Prueba: 
        //Creacion: WF(JAZH) 20080917 - REQ:XXX
        //Modificacion: WF(JAZH) 20080917 - REQ:XXX
        //-------------------------------------------------------------------
        public ReturnValor InsertDetalleDetalle(BERegistro pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oTablaRegistroData.Registrar(pItem);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessages.Evento_NEW;
                    }
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpException.mTraerMensaje(ex);
            }
            return oReturn;
        }

        //-------------------------------------------------------------------
        //Nombre:	ActualizarDetalle
        //Objetivo: Actualiza el registro de un objeto de tipo TEDetalle
        //Valores Prueba: 
        //Creacion: WF(JAZH) 20080917 - REQ:XXX
        //Modificacion: WF(JAZH) 20080917 - REQ:XXX
        //-------------------------------------------------------------------
        public ReturnValor ActualizarDetalle(BERegistro pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oTablaRegistroData.Actualizar(pItem);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessages.Evento_EDIT;
                    }
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpException.mTraerMensaje(ex);
            }
            return oReturn;
        }

        //-------------------------------------------------------------------
        //Nombre:	EliminarDetalle
        //Objetivo: Elimina el registro de un objeto de tipo TEDetalle
        //Valores Prueba: 
        //Creacion: WF(JAZH) 20080917 - REQ:XXX
        //Modificacion: WF(JAZH) 20080917 - REQ:XXX
        //-------------------------------------------------------------------
        public ReturnValor EliminarDetalle(string pCodTabla, string pCodArgu)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oTablaRegistroData.Eliminar(pCodTabla, pCodArgu);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessages.Evento_DELETE;
                    }
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpException.mTraerMensaje(ex);
            }
            return oReturn;
        }

        /// <summary>
        /// Obtiene todos los nombres de ubigeos por el codigo de argumento ingresado
        /// </summary>
        /// <param name="prm_CodigoArgumento">Código ARGUMENTO de la Tabla</param>
        /// <param name="prm_Idioma">Tipo de Idioma</param>
        public string ObtenerUbigeo(string pCodigoUBIGEO, int pcodEmpresa, string pSegUsuario)
        {
            try
            {
                return oTablaRegistroData.ObtenerUbigeo(pCodigoUBIGEO);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pSegUsuario, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
        }

        #region " /* Otros métodos */ "

        /// <summary>
        /// GENERA un nuevo codigo de registro para la entidad TablaRegistro
        /// </summary>
        /// <param name="prm_codTabla">Código de tabla</param>
        /// <param name="prm_indTipoDato">Indicador de tipo de dato (N,A)</param>
        /// <param name="prm_indNivel">Indicador de Nivel</param>
        /// <param name="prm_numTamanioCod">Número de tamaño de código</param>
        /// <param name="prm_codPadre">Código padre del codRegistro</param>
        /// <returns></returns>
        public string NewcodRegistro(string prm_codTabla, string prm_indTipoDato, int prm_indNivel, int prm_numTamanioCod, 
                                     string prm_codPadre, int pcodEmpresa, string pSegUsuario)
        {
            string codigoGenerado = String.Empty;
            try
            {
                codigoGenerado = oTablaRegistroData.NewcodRegistro(prm_codTabla, prm_indTipoDato, prm_indNivel, prm_numTamanioCod, prm_codPadre);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pSegUsuario, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return codigoGenerado;
        }

        //public List<SysTablas> ListarTablaBD()
        //{
        //    List<SysTablas> lstTablasBD = new List<SysTablas>();
        //    try
        //    {
        //        lstTablasBD = oTablaData.ListarTablaBD();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstTablasBD;
        //}

        #endregion
    }

    public class TablaLogicNx
    {
        
        /// <summary>
        /// Metodo                  :Dispose 
        /// Propósito               :Permite Liberar de la memoria al objeto instanciado
        /// Retorno                 :Colección o lista de objetos de la entidad
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :23/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #region Métodos de la clase-entidad TABLA

        /// <summary>
        /// Metodo                  :Buscar 
        /// Propósito               :Permite buscar un registro de la entidad
        /// Retorno                 :Datos de la entidad del objeto
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :13/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="codRegistro">Indica el ID de la entidad</param>
        /// <returns></returns>
        public TablaBE BuscarTabla(string codTabla, int pcodEmpresa, string pSegUsuario)
        {
            TablaDataNx objTablaDataNx = null;
            TablaBE objTabla = null;
            try
            {
                objTablaDataNx = new TablaDataNx();
                objTabla = objTablaDataNx.Buscar(codTabla);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             pSegUsuario, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            finally
            {
                if (objTablaDataNx != null)
                {
                    objTablaDataNx.Dispose();
                    objTablaDataNx = null;
                }
            }
            return objTabla;
        }

        /// <summary>
        /// Metodo                  :Listar 
        /// Propósito               :Permite Listar las tablas registrados como maestras
        /// Retorno                 :Colección o lista de objetos de la entidad
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :23/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="objFiltroMaestro">Contiene parametros para listar la entidad</param>
        /// <returns></returns>
        public List<TablaBE> ListarTabla(BaseFiltroMaestro objFiltroMaestro)
        {
            TablaDataNx objTablaDataNx = null;
            List<TablaBE> lstTabla = null;
            try
            {
                objTablaDataNx = new TablaDataNx();
                lstTabla = objTablaDataNx.Listar(objFiltroMaestro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              objFiltroMaestro.segUsuario, objFiltroMaestro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            finally
            {
                if (objTablaDataNx != null)
                {
                    objTablaDataNx.Dispose();
                    objTablaDataNx = null;
                }
            }
            return lstTabla;
        }

        /// <summary>
        /// Metodo                  :ListarPaginado 
        /// Propósito               :Permite Listar los sistemas registrados en seguridad paginado para JQGrid
        /// Retorno                 :Colección o lista de objetos de la entidad
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :23/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="objFiltroMaestro">Contiene parametros para listar la entidad</param>
        /// <returns></returns>
        public List<TablaBE> ListarTablaPaginado(BaseFiltroMaestro objFiltroMaestro)
        {
            TablaDataNx objTablaDataNx = null;
            List<TablaBE> lstTabla = null;
            try
            {
                objTablaDataNx = new TablaDataNx();
                lstTabla = objTablaDataNx.ListarPaginado(objFiltroMaestro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              objFiltroMaestro.segUsuario, objFiltroMaestro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            finally
            {
                if (objTablaDataNx != null)
                {
                    objTablaDataNx.Dispose();
                    objTablaDataNx = null;
                }
            }
            return lstTabla;
        }

        ///// <summary>
        ///// Metodo                  :ListarTablasBD 
        ///// Propósito               :Permite Listar las tablas del sistema de la base de datos
        ///// Retorno                 :Colección o lista de objetos de la entidad
        ///// Autor                   :OCR - Orlando Carril R.
        ///// Fecha/Hora de Creación  :23/08/2015
        ///// Modificado              :N/A
        ///// Fecha/Hora Modificación :N/A
        ///// </summary>
        ///// <returns></returns>
        //public List<SysTablas> ListarTablasBD()
        //{
        //    List<SysTablas> lstSysTablas = new List<SysTablas>();
        //    TablaDataNx objTablaDataNx = null;
        //    try
        //    {
        //        objTablaDataNx = new TablaDataNx();
        //        lstSysTablas = objTablaDataNx.ListarTablasBD();
        //    }
        //    catch (Exception ex)
        //    {
        //        //log.Error(String.Concat("ListarTablasBD", " | ", ex.Message.ToString()));
        //        lstSysTablas = null;
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (objTablaDataNx != null)
        //        {
        //            objTablaDataNx.Dispose();
        //            objTablaDataNx = null;
        //        }
        //    }
        //    return lstSysTablas;

        //}

        #endregion

        #region Métodos de la clase-entidad REGISTRO

        /// <summary>
        /// Metodo                  :Buscar 
        /// Propósito               :Permite buscar un registro de la entidad
        /// Retorno                 :Datos de la entidad del objeto
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :23/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="codTabla">Indica el ID de la entidad</param>
        /// <returns></returns>
        public BERegistroNew BuscarRegistro(string codRegistro, int pcodEmpresa, string pSegUsuario)
        {
            RegistroDataNx objRegistroDataNx = null;
            BERegistroNew objRegistro = null;
            try
            {
                objRegistroDataNx = new RegistroDataNx();
                objRegistro = objRegistroDataNx.Buscar(codRegistro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                           pSegUsuario, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            finally
            {
                if (objRegistroDataNx != null)
                {
                    objRegistroDataNx.Dispose();
                    objRegistroDataNx = null;
                }
            }
            return objRegistro;
        }

        /// <summary>
        /// Metodo                  :Listar 
        /// Propósito               :Permite Listar los registros de las tablas registrados como maestras
        /// Retorno                 :Colección o lista de objetos de la entidad
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :23/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="objFiltroMaestro">Contiene parametros para listar la entidad</param>
        /// <returns></returns>
        public List<BERegistroNew> ListarRegistro(BaseFiltroMaestro objFiltroMaestro)
        {
            RegistroDataNx objRegistroDataNx = null;
            List<BERegistroNew> lstRegistro = null;
            try
            {
                objRegistroDataNx = new RegistroDataNx();
                lstRegistro = objRegistroDataNx.Listar(objFiltroMaestro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                           objFiltroMaestro.segUsuario, objFiltroMaestro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            finally
            {
                if (objRegistroDataNx != null)
                {
                    objRegistroDataNx.Dispose();
                    objRegistroDataNx = null;
                }
            }
            return lstRegistro;
        }

        /// <summary>
        /// Metodo                  :ListarPaginado 
        /// Propósito               :Permite Listar los sistemas registrados en seguridad paginado para JQGrid
        /// Retorno                 :Colección o lista de objetos de la entidad
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :23/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="objFiltroMaestro">Contiene parametros para listar la entidad</param>
        /// <returns></returns>
        public List<BERegistroNew> ListarRegistroPaginado(BaseFiltroMaestro objFiltroMaestro)
        {
            RegistroDataNx objRegistroDataNx = null;
            List<BERegistroNew> lstRegistro = null;
            try
            {
                objRegistroDataNx = new RegistroDataNx();
                lstRegistro = objRegistroDataNx.ListarPaginado(objFiltroMaestro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                            objFiltroMaestro.segUsuario, objFiltroMaestro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            finally
            {
                if (objRegistroDataNx != null)
                {
                    objRegistroDataNx.Dispose();
                    objRegistroDataNx = null;
                }
            }
            return lstRegistro;
        }

        /// <summary>
        /// Metodo                  :Listar 
        /// Propósito               :Permite Listar los registros de las tablas para llenar combos
        /// Retorno                 :Colección o lista de objetos de la entidad
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :23/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="objFiltroMaestro">Contiene parametros para listar la entidad</param>
        /// <returns></returns>
        public List<BERegistroNew> ListarRegistroCombo(BaseFiltroMaestro objFiltroMaestro)
        {
            RegistroDataNx objRegistroDataNx = null;
            List<BERegistroNew> lstRegistro = null;
            try
            {
                objRegistroDataNx = new RegistroDataNx();
                lstRegistro = objRegistroDataNx.ListarCombo(objFiltroMaestro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             objFiltroMaestro.segUsuario, objFiltroMaestro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            finally
            {
                if (objRegistroDataNx != null)
                {
                    objRegistroDataNx.Dispose();
                    objRegistroDataNx = null;
                }
            }
            return lstRegistro;
        }

        /// <summary>
        /// Propósito               :Obtiene todos los nombres de ubigeos por el codigo de argumento ingresado
        /// Retorno                 :Una variable string con el valor obtenido
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :23/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="codRegistroUbigeo"></param>
        /// <returns></returns>
        public string ObtenerUbigeo(string codRegistroUbigeo, int pcodEmpresa, string pSegUsuario)
        {
            RegistroDataNx objRegistroDataNx = null;
            string strRegistro = null;
            try
            {
                objRegistroDataNx = new RegistroDataNx();
                strRegistro = objRegistroDataNx.ObtenerUbigeo(codRegistroUbigeo);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                            pSegUsuario, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return strRegistro;
        }

        /// <summary>
        /// Propósito               :Generar un nuevo codigo de registro de acuerdo a los parametros
        /// Retorno                 :Una variable string con el valor obtenido
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :23/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="objFiltro"></param>
        /// <returns></returns>
        public string GenerarCodRegistro(BaseFiltroMaestro objFiltro)
        {
            RegistroDataNx objRegistroDataNx = null;
            string codRegistroGenerado = null;
            try
            {
                objRegistroDataNx = new RegistroDataNx();
                codRegistroGenerado = objRegistroDataNx.GenerarCodRegistro(objFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                            objFiltro.segUsuario, objFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return codRegistroGenerado;
        }

        #endregion
    }

    public class TablaLogicTx
    {
        
        /// <summary>
        /// Metodo                  :Dispose 
        /// Propósito               :Permite Liberar de la memoria al objeto instanciado
        /// Retorno                 :Colección o lista de objetos de la entidad
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :23/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #region Métodos de la clase-entidad TABLA

        /// <summary>
        /// Metodo                  :Insertar 
        /// Propósito               :Permite insertar los datos de esta clase
        /// Retorno                 :Objeto que contiene el resultado del método
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :23/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="objTabla"></param>
        /// <returns></returns>
        public ReturnValor Insertar(TablaBE objTabla)
        {
            TablaDataTx objTablaDataTx = null;
            TablaDataNx objTablaDataNx = null;
            ReturnValor objReturnaValor = new ReturnValor();
            try
            {
                objTablaDataTx = new TablaDataTx();
                objTablaDataNx = new TablaDataNx();
                TablaBE objTablaBusca = objTablaDataNx.Buscar(objTabla.codTabla);
                if (objTablaBusca == null)
                {
                    objReturnaValor.Exitosa = objTablaDataTx.Registrar(objTabla);
                    objReturnaValor.Message = HelpMessages.Evento_NEW;
                }
                else
                {
                    objReturnaValor.Exitosa = objTablaDataTx.Actualizar(objTabla);
                    objReturnaValor.Message = HelpMessages.Evento_EDIT;
                }
                objReturnaValor.CodigoRetorno = objTabla.codTabla;
            }
            catch (Exception ex)
            {
                ///log.Error(String.Concat("Insertar Tabla", " | ", ex.Message.ToString()));
                objReturnaValor = HelpException.mTraerMensaje(ex);
            }
            finally
            {
                if (objTablaDataTx != null)
                {
                    objTablaDataTx.Dispose();
                    objTablaDataTx = null;
                }
            }
            return objReturnaValor;
        }

        /// <summary>
        /// Metodo                  :Actualizar 
        /// Propósito               :Permite actualizar los datos de esta clase
        /// Retorno                 :Objeto que contiene el resultado del método
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :23/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="pSistema"></param>
        /// <returns objReturnaValor></returns>
        public ReturnValor Actualizar(TablaBE objTabla)
        {
            TablaDataTx objTablaDataTx = null;
            ReturnValor objReturnaValor = new ReturnValor();
            try
            {
                objTablaDataTx = new TablaDataTx();
                objReturnaValor.Exitosa = objTablaDataTx.Actualizar(objTabla);
                objReturnaValor.Message = HelpMessages.Evento_EDIT;
            }
            catch (Exception ex)
            {
                //log.Error(String.Concat("Actualizar Tabla", " | ", ex.Message.ToString()));
                objReturnaValor = HelpException.mTraerMensaje(ex);
            }
            finally
            {
                if (objTablaDataTx != null)
                {
                    objTablaDataTx.Dispose();
                    objTablaDataTx = null;
                }
            }
            return objReturnaValor;
        }

        /// <summary>
        /// Metodo                  :Eliminar 
        /// Propósito               :Permite eliminar un registro de esta clase
        /// Retorno                 :Objeto que contiene el resultado del método
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :13/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="objFiltroSeguridad"></param>
        /// <returns objReturnaValor></returns>
        public ReturnValor EliminarTabla(BaseFiltroMaestro objFiltroMaestro)
        {
            TablaDataTx objTablaDataTx = null;
            ReturnValor objReturnaValor = new ReturnValor();
            try
            {
                objTablaDataTx = new TablaDataTx();
                objReturnaValor.Exitosa = objTablaDataTx.Eliminar(objFiltroMaestro);
                objReturnaValor.Message = HelpMessages.Evento_DELETE;
            }
            catch (Exception ex)
            {
                objReturnaValor = HelpException.mTraerMensaje(ex);
                objReturnaValor.Message = String.Concat("Eliminar Tabla", " | ",objReturnaValor.Message);
            }
            finally
            {
                if (objTablaDataTx != null)
                {
                    objTablaDataTx.Dispose();
                    objTablaDataTx = null;
                }
            }
            return objReturnaValor;
        }

        #endregion

        #region Métodos de la clase-entidad REGISTRO

        /// <summary>
        /// Metodo                  :Insertar 
        /// Propósito               :Permite insertar los datos de esta clase
        /// Retorno                 :Objeto que contiene el resultado del método
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :23/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="objRegistro"></param>
        /// <returns></returns>
        public ReturnValor Insertar(BERegistroNew objRegistro)
        {
            RegistroDataTx objRegistroDataTx = null;
            RegistroDataNx objRegistroDataNx = null;
            ReturnValor objReturnaValor = new ReturnValor();
            try
            {
                objRegistroDataTx = new RegistroDataTx();
                objRegistroDataNx = new RegistroDataNx();
                BERegistroNew objRegistroBusca = objRegistroDataNx.Buscar(objRegistro.codRegistro);
                if (objRegistroBusca == null)
                {
                    objReturnaValor.Exitosa = objRegistroDataTx.Registrar(objRegistro);
                    objReturnaValor.Message = HelpMessages.Evento_NEW;
                }
                else
                {
                    objReturnaValor.Exitosa = objRegistroDataTx.Actualizar(objRegistro);
                    objReturnaValor.Message = HelpMessages.Evento_EDIT;
                }
                objReturnaValor.CodigoRetorno = objRegistro.codRegistro;
            }
            catch (Exception ex)
            {
                //log.Error(String.Concat("Insertar Registro", " | ", ex.Message.ToString()));
                objReturnaValor = HelpException.mTraerMensaje(ex);
            }
            finally
            {
                if (objRegistroDataTx != null)
                {
                    objRegistroDataTx.Dispose();
                    objRegistroDataTx = null;
                }
            }
            return objReturnaValor;
        }

        /// <summary>
        /// Metodo                  :Actualizar 
        /// Propósito               :Permite actualizar los datos de esta clase
        /// Retorno                 :Objeto que contiene el resultado del método
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :23/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="pSistema"></param>
        /// <returns objReturnaValor></returns>
        public ReturnValor Actualizar(BERegistroNew objRegistro)
        {
            RegistroDataTx objRegistroDataTx = null;
            ReturnValor objReturnaValor = new ReturnValor();
            try
            {
                objRegistroDataTx = new RegistroDataTx();
                objReturnaValor.Exitosa = objRegistroDataTx.Actualizar(objRegistro);
                objReturnaValor.Message = HelpMessages.Evento_EDIT;
            }
            catch (Exception ex)
            {
                //log.Error(String.Concat("Actualizar Registro", " | ", ex.Message.ToString()));
                objReturnaValor = HelpException.mTraerMensaje(ex);
            }
            finally
            {
                if (objRegistroDataTx != null)
                {
                    objRegistroDataTx.Dispose();
                    objRegistroDataTx = null;
                }
            }
            return objReturnaValor;
        }

        /// <summary>
        /// Metodo                  :Eliminar 
        /// Propósito               :Permite eliminar un registro de esta clase
        /// Retorno                 :Objeto que contiene el resultado del método
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :13/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        /// <param name="objFiltroSeguridad"></param>
        /// <returns objReturnaValor></returns>
        public ReturnValor EliminarRegistro(BaseFiltroMaestro objFiltroMaestro)
        {
            RegistroDataTx objRegistroDataTx = null;
            ReturnValor objReturnaValor = new ReturnValor();
            try
            {
                objRegistroDataTx = new RegistroDataTx();
                objReturnaValor.Exitosa = objRegistroDataTx.Eliminar(objFiltroMaestro);
                objReturnaValor.Message = HelpMessages.Evento_DELETE;
            }
            catch (Exception ex)
            {
                objReturnaValor = HelpException.mTraerMensaje(ex);
                objReturnaValor.Message = String.Concat("Eliminar Registro", " | ", objReturnaValor.Message);
            }
            finally
            {
                if (objRegistroDataTx != null)
                {
                    objRegistroDataTx.Dispose();
                    objRegistroDataTx = null;
                }
            }
            return objReturnaValor;
        }


        #endregion
    }
}

namespace CROM.Proyectos.BusinessLogic
{
    using CROM.BusinessEntities.Proyectos;
    using CROM.Proyectos.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Transactions;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 10/12/2014-02:14:06 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Proyectos.ProyectoLogic.cs]
    /// </summary>
    public class ProyectoLogicNx
    {
        private ProyectoDataNx objProyectoDataNx = null;
        private PyEquipoDataNx objPyEquipoDataNx = null;
        private PyMantenimientoDataNx objPyMantenimientoDataNx = null;
        private PyDocumRegDataNx objPyDocumRegDataNx = null;

        public ProyectoLogicNx()
        {
            objProyectoDataNx = new ProyectoDataNx();
            objPyEquipoDataNx = new PyEquipoDataNx();
            objPyMantenimientoDataNx = new PyMantenimientoDataNx();
            objPyDocumRegDataNx = new PyDocumRegDataNx();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.Proyecto
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEProyecto> ListarProyecto(BaseFiltroPry pFiltro)
        {
            List<BEProyecto> lstProyecto = new List<BEProyecto>();
            try
            {
                lstProyecto = objProyectoDataNx.Listar(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProyecto;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.Proyecto para JQGrid
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTOProyecto> ListarProyectoPaginado(BaseFiltroPry pFiltro)
        {
            List<DTOProyecto> lstProyecto = new List<DTOProyecto>();
            try
            {
                lstProyecto = objProyectoDataNx.ListarPaginado(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProyecto;
        }

        /// <summary>
        /// Retorna un LISTA de registros de los documentos emitidos
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoMovCabecera]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTODocumReg> ListarDocumentosEmitidos(BaseFiltroPry pFiltro)
        {
            List<DTODocumReg> lstDocumReg = new List<DTODocumReg>();
            try
            {
                lstDocumReg = objProyectoDataNx.ListarDocumentosEmitidos(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDocumReg;
        }

        /// <summary>
        /// Retorna un LISTA de registros de los documentos emitidos
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumentoMovDetalle]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTODocumReg> ListarDocumentoDetalle(BaseFiltroPry pFiltro)
        {
            List<DTODocumReg> lstDocumRegDetalle = new List<DTODocumReg>();
            try
            {
                lstDocumRegDetalle = objProyectoDataNx.ListarDocumentoDetalle(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDocumRegDetalle;
        }
        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.PyEquipo
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTOEquipo> ListarEquipo(BaseFiltroPry pFiltro)
        {
            List<DTOEquipo> lstPyEquipo = new List<DTOEquipo>();
            try
            {
                lstPyEquipo = objPyEquipoDataNx.Listar(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPyEquipo;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.PyEquipo
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTOEquipo> ListarEquipoPaginado(BaseFiltroPry pFiltro)
        {
            List<DTOEquipo> lstPyEquipo = new List<DTOEquipo>();
            try
            {
                lstPyEquipo = objPyEquipoDataNx.ListarPaginado(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPyEquipo;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.PyMantenimiento
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTOMantenimiento> ListarMantenimiento(BaseFiltroPry pFiltro)
        {
            List<DTOMantenimiento> lstPyMantenimiento = new List<DTOMantenimiento>();
            try
            {
                lstPyMantenimiento = objPyMantenimientoDataNx.Listar(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPyMantenimiento;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.PyMantenimiento
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTOMantenimiento> ListarMantenimientoPaginado(BaseFiltroPry pFiltro)
        {
            List<DTOMantenimiento> lstPyMantenimiento = new List<DTOMantenimiento>();
            try
            {
                lstPyMantenimiento = objPyMantenimientoDataNx.ListarPaginado(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPyMantenimiento;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.PyDocumReg
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEPyDocumReg> ListarDocumReg(BaseFiltroPry pFiltro)
        {
            List<BEPyDocumReg> lstPyDocumReg = new List<BEPyDocumReg>();
            try
            {
                lstPyDocumReg = objPyDocumRegDataNx.Listar(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPyDocumReg;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Proyectos.PyDocumReg
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTODocumReg> ListarDocumRegPaginado(BaseFiltroPry pFiltro)
        {
            List<DTODocumReg> lstPyDocumReg = new List<DTODocumReg>();
            try
            {
                lstPyDocumReg = objPyDocumRegDataNx.ListarPaginado(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPyDocumReg;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Proyectos.Proyecto
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        /// <param name="pcodProyecto"></param>
        /// <returns></returns>
        public BEProyecto BuscarProyecto(int pcodProyecto)
        {
            BEProyecto proyecto = null;
            try
            {
                if (pcodProyecto > 0)
                    proyecto = objProyectoDataNx.Buscar(pcodProyecto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return proyecto;
        }

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Proyectos.PyEquipo
        /// En la BASE de DATO la Tabla : [Proyectos.PyEquipo]
        /// <summary>
        /// <param name="pcodProyecto"></param>
        /// <returns></returns>
        public BEPyEquipo BuscarEquipo(int codPyEquipo)
        {
            BEPyEquipo objPyEquipo = null;
            try
            {
                if (codPyEquipo > 0)
                    objPyEquipo = objPyEquipoDataNx.Buscar(codPyEquipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objPyEquipo;
        }

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Proyectos.PyMantenimiento
        /// En la BASE de DATO la Tabla : [Proyectos.PyMantenimiento]
        /// <summary>
        /// <param name="codPyMantenimiento"></param>
        /// <returns></returns>
        public BEPyMantenimiento BuscarMantenimiento(int codPyMantenimiento)
        {
            BEPyMantenimiento objPyMantenimiento = null;
            try
            {
                if (codPyMantenimiento > 0)
                    objPyMantenimiento = objPyMantenimientoDataNx.Buscar(codPyMantenimiento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objPyMantenimiento;
        }

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Proyectos.PyDocumReg
        /// En la BASE de DATO la Tabla : [Proyectos.PyDocumReg]
        /// <summary>
        /// <param name="codPyDocumReg"></param>
        /// <returns></returns>
        public BEPyDocumReg BuscarDocumReg(int codPyDocumReg)
        {
            BEPyDocumReg objPyDocumReg = null;
            try
            {
                if (codPyDocumReg > 0)
                    objPyDocumReg = objPyDocumRegDataNx.Buscar(codPyDocumReg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objPyDocumReg;
        }

        #endregion

    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 10/12/2014-02:14:06 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Proyectos.ProyectoLogic.cs]
    /// </summary>
    public class ProyectoLogicTx
    {
        private ProyectoDataTx objProyectoDataTx = null;
        private PyEquipoDataTx objPyEquipoDataTx = null;
        private PyMantenimientoDataTx objPyMantenimientoDataTx = null;
        private PyDocumRegDataTx objPyDocumRegDataTx = null;
        private ReturnValor oReturnValor = null;

        public ProyectoLogicTx()
        {
            objProyectoDataTx = new ProyectoDataTx();
            objPyEquipoDataTx = new PyEquipoDataTx();
            objPyMantenimientoDataTx = new PyMantenimientoDataTx();
            objPyDocumRegDataTx = new PyDocumRegDataTx();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Proyecto
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        /// <param name="objProyecto"></param>
        /// <returns></returns>
        public ReturnValor RegistrarProyecto(BEProyecto objProyecto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objProyectoDataTx.Registrar(objProyecto);
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

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PyEquipo
        /// En la BASE de DATO la Tabla : [Proyectos.PyEquipo]
        /// <summary>
        /// <param name="objProyecto"></param>
        /// <returns></returns>
        public ReturnValor RegistrarEquipo(BEPyEquipo objPyEquipo)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objPyEquipoDataTx.Registrar(objPyEquipo);
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

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PyMantenimiento
        /// En la BASE de DATO la Tabla : [Proyectos.PyMantenimiento]
        /// <summary>
        /// <param name="objProyecto"></param>
        /// <returns></returns>
        public ReturnValor RegistrarMantenimiento(BEPyMantenimiento objPyMantenimiento)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objPyMantenimientoDataTx.Registrar(objPyMantenimiento);
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

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PyDocumReg
        /// En la BASE de DATO la Tabla : [Proyectos.PyDocumReg]
        /// <summary>
        /// <param name="objProyecto"></param>
        /// <returns></returns>
        public ReturnValor RegistrarDocumReg(BEPyDocumReg objPyDocumReg)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objPyDocumRegDataTx.Registrar(objPyDocumReg);
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

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Proyecto
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        /// <param name="proyecto"></param>
        /// <returns></returns>
        public ReturnValor ActualizarProyecto(BEProyecto objProyecto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objProyectoDataTx.Actualizar(objProyecto);
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

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PyEquipo
        /// En la BASE de DATO la Tabla : [Proyectos.PyEquipo]
        /// <summary>
        /// <param name="objProyecto"></param>
        /// <returns></returns>
        public ReturnValor ActualizarEquipo(BEPyEquipo objPyEquipo)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objPyEquipoDataTx.Actualizar(objPyEquipo);
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

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PyMantenimiento
        /// En la BASE de DATO la Tabla : [Proyectos.PyMantenimiento]
        /// <summary>
        /// <param name="objProyecto"></param>
        /// <returns></returns>
        public ReturnValor ActualizarMantenimiento(BEPyMantenimiento objPyMantenimiento)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objPyMantenimientoDataTx.Actualizar(objPyMantenimiento);
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

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PyDocumReg
        /// En la BASE de DATO la Tabla : [Proyectos.PyDocumReg]
        /// <summary>
        /// <param name="objPyDocumReg"></param>
        /// <returns></returns>
        public ReturnValor ActualizarDocumReg(BEPyDocumReg objPyDocumReg)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objPyDocumRegDataTx.Actualizar(objPyDocumReg);
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

        #region /* Proceso de DELETE RECORD */

        /// <summary>
        /// Elimina el registro de una ENTIDAD de registro de Tipo Proyecto
        /// En la BASE de DATO la Tabla : [Proyectos.Proyecto]
        /// <summary>
        /// <param name="proyecto"></param>
        /// <returns></returns>
        public ReturnValor EliminarProyecto(BEProyecto objProyecto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objProyectoDataTx.Eliminar(objProyecto);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
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

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PyEquipo
        /// En la BASE de DATO la Tabla : [Proyectos.PyEquipo]
        /// <summary>
        /// <param name="objProyecto"></param>
        /// <returns></returns>
        public ReturnValor EliminarEquipo(BEPyEquipo objPyEquipo)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objPyEquipoDataTx.Eliminar(objPyEquipo);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
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

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PyMantenimiento
        /// En la BASE de DATO la Tabla : [Proyectos.PyMantenimiento]
        /// <summary>
        /// <param name="objProyecto"></param>
        /// <returns></returns>
        public ReturnValor EliminarMantenimiento(BEPyMantenimiento objPyMantenimiento)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objPyMantenimientoDataTx.Eliminar(objPyMantenimiento);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
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

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PyDocumReg
        /// En la BASE de DATO la Tabla : [Proyectos.PyDocumReg]
        /// <summary>
        /// <param name="objPyDocumReg"></param>
        /// <returns></returns>
        public ReturnValor EliminarDocumReg(BEPyDocumReg objPyDocumReg)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = objPyDocumRegDataTx.Eliminar(objPyDocumReg);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
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

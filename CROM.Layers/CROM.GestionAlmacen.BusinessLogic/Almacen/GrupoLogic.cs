namespace CROM.GestionAlmacen.BusinessLogic
{
    using CROM.BusinessEntities.Almacen;
    using CROM.GestionAlmacen.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Transactions;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Almacen.GrupoLogic.cs]
    /// </summary>
    public class GrupoLogic
    {
        private GrupoData grupoData = null;
        private ReturnValor returnValor = null;

        public GrupoLogic()
        {
            grupoData = new GrupoData();
            returnValor = new ReturnValor();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo GrupoAux
        /// En la BASE de DATO la Tabla : [Almacen.GrupoAux]
        /// <summary>
        /// <param name = >grupo</param>
        public ReturnValor Insert(GrupoAux grupo)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.codRetorno = grupoData.Insert(grupo);
                    if (returnValor.codRetorno != 0)
                    {
                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                        returnValor.Exitosa = true;
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo GrupoAux
        /// En la BASE de DATO la Tabla : [Almacen.GrupoAux]
        /// <summary>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public ReturnValor Update(GrupoAux grupo)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = grupoData.Update(grupo);
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

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.GrupoAux
        /// En la BASE de DATO la Tabla : [Almacen.GrupoAux]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(int prm_codGrupo)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = grupoData.Delete(prm_codGrupo);
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

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.GrupoAux
        /// En la BASE de DATO la Tabla : [Almacen.GrupoAux]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<GrupoAux> List(BaseFiltroGrupo pFiltro)
        {
            List<GrupoAux> lstGrupo = new List<GrupoAux>();
            try
            {
                lstGrupo = grupoData.List(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstGrupo;
        }

        public List<GrupoAux> List(BaseFiltroGrupo pFiltro, Helper.ComboBoxText pTexto)
        {
            List<GrupoAux> lstGrupo = new List<GrupoAux>();
            try
            {
                lstGrupo = grupoData.List(pFiltro);
                if (lstGrupo.Count > 0)
                    lstGrupo.Insert(0, new GrupoAux { codGrupo = 0, desNombre = Helper.ObtenerTexto(pTexto) });
                else
                    lstGrupo.Add(new GrupoAux { codGrupo = 0, desNombre = Helper.ObtenerTexto(pTexto) });

            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstGrupo;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.Grupo
        /// En la BASE de DATO la Tabla : [Almacen.Grupo]
        /// <summary>
        /// <param name="prm_codGrupo"></param>
        /// <returns></returns>
        public GrupoAux Find(int pcodEmpresa, string pUser, int prm_codGrupo)
        {
            GrupoAux grupo = new GrupoAux();
            try
            {
                BaseFiltroGrupo filtro = new BaseFiltroGrupo
                {
                    codGrupo = prm_codGrupo,
                    indEstado = true
                };

                grupo = grupoData.Find(filtro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             pUser, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return grupo;
        }

        #endregion

    }
} 

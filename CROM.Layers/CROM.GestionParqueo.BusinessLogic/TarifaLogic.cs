namespace CROM.GestionParqueo.BusinessLogic
{
    using CROM.BusinessEntities.Parqueo;
    using CROM.GestionParqueo.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Transactions;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 28/11/2011-06:25:40 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Parqueo.TarifaLogic.cs]
    /// </summary>
    public class TarifaLogic
    {
        private TarifaData oTarifaData = null;
        private ReturnValor oReturnValor = null;
        public TarifaLogic()
        {
            oTarifaData = new TarifaData();
            oReturnValor = new ReturnValor();
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Parqueo.Tarifa
        /// En la BASE de DATO la Tabla : [Parqueo.Tarifa]
        /// <summary>
        /// <returns>List</returns>
        public List<TarifaAux> List(string p_codPersonaEmpresa, string p_codPuntoDeventa, string p_desNombre, string p_codRepTipoVehiculo, bool? p_indActivo)
        {
            List<TarifaAux> miLista = new List<TarifaAux>();
            try
            {
                miLista = oTarifaData.List(p_codPersonaEmpresa, p_codPuntoDeventa, p_desNombre, p_codRepTipoVehiculo, p_indActivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }
        public List<TarifaAux> List(string p_codPersonaEmpresa, string p_codPuntoDeventa, string p_desNombre, string p_codRepTipoVehiculo, bool? p_indActivo, Helper.ComboBoxText pTexto)
        {
            List<TarifaAux> miLista = new List<TarifaAux>();
            try
            {
                miLista = oTarifaData.List(p_codPersonaEmpresa, p_codPuntoDeventa, p_desNombre, p_codRepTipoVehiculo, p_indActivo);
                if (miLista.Count > 0)
                    miLista.Insert(0, new TarifaAux { codTarifa = "", desNombre = Helper.ObtenerTexto(pTexto) });
                else
                    miLista.Add(new TarifaAux { codTarifa = "", desNombre = Helper.ObtenerTexto(pTexto) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Parqueo.Tarifa
        /// En la BASE de DATO la Tabla : [Parqueo.Tarifa]
        /// <summary>
        /// <returns>Entidad</returns>
        public TarifaAux Find(string prm_codTarifa)
        {
            TarifaAux miEntidad = new TarifaAux();
            try
            {
                miEntidad = oTarifaData.Find(prm_codTarifa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miEntidad;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Tarifa
        /// En la BASE de DATO la Tabla : [Parqueo.Tarifa]
        /// <summary>
        /// <param name = >itemTarifa</param>
        public ReturnValor Insert(TarifaAux itemTarifa)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.CodigoRetorno = oTarifaData.Insert(itemTarifa);
                    if (oReturnValor.CodigoRetorno != null)
                    {
                        oReturnValor.Exitosa = true;
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Tarifa
        /// En la BASE de DATO la Tabla : [Parqueo.Tarifa]
        /// <summary>
        /// <param name = >itemTarifa</param>
        public ReturnValor Update(TarifaAux itemTarifa)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oTarifaData.Update(itemTarifa);
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

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Parqueo.Tarifa
        /// En la BASE de DATO la Tabla : [Parqueo.Tarifa]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string prm_codTarifa)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oTarifaData.Delete(prm_codTarifa);
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

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
    /// Archivo     : [Parqueo.VehiculoLogic.cs]
    /// </summary>
    public class VehiculoLogic
    {
        private VehiculoData oVehiculoData = null;
        private ReturnValor oReturnValor = null;
        public VehiculoLogic()
        {
            oVehiculoData = new VehiculoData();
            oReturnValor = new ReturnValor();
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Parqueo.Vehiculo
        /// En la BASE de DATO la Tabla : [Parqueo.Vehiculo]
        /// <summary>
        /// <returns>List</returns>
        public List<VehiculoAux> List(string p_codVehiculo, string p_codRegTipoVehiculo, string p_codRegMarcaModelo, string p_codRegColorExterno, bool? p_indActivo)
        {
            List<VehiculoAux> miLista = new List<VehiculoAux>();
            try
            {
                miLista = oVehiculoData.List(p_codVehiculo, p_codRegTipoVehiculo, p_codRegMarcaModelo, p_codRegColorExterno, p_indActivo);
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
        /// Retorna una ENTIDAD de registro de la Entidad Parqueo.Vehiculo
        /// En la BASE de DATO la Tabla : [Parqueo.Vehiculo]
        /// <summary>
        /// <returns>Entidad</returns>
        public VehiculoAux Find(string prm_codVehiculo)
        {
            VehiculoAux miEntidad = new VehiculoAux();
            try
            {
                miEntidad = oVehiculoData.Find(prm_codVehiculo);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Vehiculo
        /// En la BASE de DATO la Tabla : [Parqueo.Vehiculo]
        /// <summary>
        /// <param name = >itemVehiculo</param>
        public ReturnValor Insert(VehiculoAux itemVehiculo)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (itemVehiculo.codPersonaCliente == string.Empty)
                        itemVehiculo.codPersonaCliente = null;
                    if (itemVehiculo.codRegColorExterno == string.Empty)
                        itemVehiculo.codRegColorExterno = null;
                    if (itemVehiculo.codRegColorInterno == string.Empty)
                        itemVehiculo.codRegColorInterno = null;
                    if (itemVehiculo.codRegMarcaModelo == string.Empty)
                        itemVehiculo.codRegMarcaModelo = null;
                    if (itemVehiculo.codRegTipoAbono == string.Empty)
                        itemVehiculo.codRegTipoAbono = null;

                    oReturnValor.Exitosa = oVehiculoData.Insert(itemVehiculo);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Vehiculo
        /// En la BASE de DATO la Tabla : [Parqueo.Vehiculo]
        /// <summary>
        /// <param name = >itemVehiculo</param>
        public ReturnValor Update(VehiculoAux itemVehiculo)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (itemVehiculo.codPersonaCliente == string.Empty)
                        itemVehiculo.codPersonaCliente = null;
                    if (itemVehiculo.codRegColorExterno == string.Empty)
                        itemVehiculo.codRegColorExterno = null;
                    if (itemVehiculo.codRegColorInterno == string.Empty)
                        itemVehiculo.codRegColorInterno = null;
                    if (itemVehiculo.codRegMarcaModelo == string.Empty)
                        itemVehiculo.codRegMarcaModelo = null;
                    if (itemVehiculo.codRegTipoAbono == string.Empty)
                        itemVehiculo.codRegTipoAbono = null;

                    oReturnValor.Exitosa = oVehiculoData.Update(itemVehiculo);
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
        /// ELIMINA un registro de la Entidad Parqueo.Vehiculo
        /// En la BASE de DATO la Tabla : [Parqueo.Vehiculo]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string prm_codVehiculo)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oVehiculoData.Delete(prm_codVehiculo);
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

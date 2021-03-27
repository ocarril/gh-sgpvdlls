namespace CROM.GestionParqueo.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Parqueo;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 28/11/2011-06:25:40 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Parqueo.VehiculoData.cs]
    /// </summary>
    public class VehiculoData
    {
        private string conexion = string.Empty;
        public VehiculoData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnxCROMSystema"].ConnectionString;
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
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_GetAll_Vehiculo(p_codVehiculo, p_codRegTipoVehiculo, p_codRegMarcaModelo, p_codRegColorExterno, p_indActivo);
                    foreach (var item in resul)
                    {
                        miLista.Add(new VehiculoAux()
                        {
                            codVehiculo = item.codVehiculo,
                            codPersonaCliente = item.codPersonaCliente == null ? string.Empty : item.codPersonaCliente,
                            codRegTipoVehiculo = item.codRegTipoVehiculo == null ? string.Empty : item.codRegTipoVehiculo,
                            codRegMarcaModelo = item.codRegMarcaModelo == null ? string.Empty : item.codRegMarcaModelo,
                            codRegColorInterno = item.codRegColorInterno == null ? string.Empty : item.codRegColorInterno,
                            codRegColorExterno = item.codRegColorExterno == null ? string.Empty : item.codRegColorExterno,
                            codRegTipoAbono = item.codRegTipoAbono == null ? string.Empty : item.codRegTipoAbono,
                            codNroChasis = item.codNroChasis,
                            codNroMotor = item.codNroMotor,
                            perAnio = item.perAnio == null ? 0 : item.perAnio.Value,
                            gloObservacion = item.gloObservacion,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraCrea = item.segFechaHoraCrea,
                            segFechaHoraEdita = item.segFechaHoraEdita,
                            segMaquinaOrigen = item.segMaquinaOrigen,
                            codPersonaClienteNombre = item.codPersonaClienteNombre,
                            codRegTipoVehiculoNombre = item.codRegTipoVehiculoNombre,
                            codRegMarcaModeloNombre = item.codRegMarcaModeloNombre,
                            codRegColorInternoNombre = item.codRegColorInternoNombre,
                            codRegColorExternoNombre = item.codRegColorExternoNombre,
                            codRegTipoAbonoNombre = item.codRegTipoAbonoNombre,

                        });
                    }
                }
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
        public VehiculoAux Find(string p_codVehiculo)
        {
            VehiculoAux miEntidad = new VehiculoAux();
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_Find_Vehiculo(p_codVehiculo);
                    foreach (var item in resul)
                    {
                        miEntidad = new VehiculoAux()
                        {
                            codVehiculo = item.codVehiculo,
                            codPersonaCliente = item.codPersonaCliente == null ? string.Empty : item.codPersonaCliente,
                            codRegTipoVehiculo = item.codRegTipoVehiculo == null ? string.Empty : item.codRegTipoVehiculo,
                            codRegMarcaModelo = item.codRegMarcaModelo == null ? string.Empty : item.codRegMarcaModelo,
                            codRegColorInterno = item.codRegColorInterno == null ? string.Empty : item.codRegColorInterno,
                            codRegColorExterno = item.codRegColorExterno == null ? string.Empty : item.codRegColorExterno,
                            codRegTipoAbono = item.codRegTipoAbono == null ? string.Empty : item.codRegTipoAbono,
                            codNroChasis = item.codNroChasis,
                            codNroMotor = item.codNroMotor,
                            perAnio = item.perAnio == null ? 0 : item.perAnio.Value,
                            gloObservacion = item.gloObservacion,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraCrea = item.segFechaHoraCrea,
                            segFechaHoraEdita = item.segFechaHoraEdita,
                            segMaquinaOrigen = item.segMaquinaOrigen,

                            codPersonaClienteNombre = item.codPersonaClienteNombre,
                            codRegTipoVehiculoNombre = item.codRegTipoVehiculoNombre,
                            codRegMarcaModeloNombre = item.codRegMarcaModeloNombre,
                            codRegColorInternoNombre = item.codRegColorInternoNombre,
                            codRegColorExternoNombre = item.codRegColorExternoNombre,
                            codRegTipoAbonoNombre = item.codRegTipoAbonoNombre,
                        };
                    }
                }
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
        public bool Insert(VehiculoAux itemVehiculo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_Insert_Vehiculo(
                        itemVehiculo.codVehiculo,
                        itemVehiculo.codPersonaCliente,
                        itemVehiculo.codRegTipoVehiculo,
                        itemVehiculo.codRegMarcaModelo,
                        itemVehiculo.codRegColorInterno,
                        itemVehiculo.codRegColorExterno,
                        itemVehiculo.codRegTipoAbono,
                        itemVehiculo.codNroChasis,
                        itemVehiculo.codNroMotor,
                        itemVehiculo.perAnio,
                        itemVehiculo.gloObservacion,
                        itemVehiculo.indActivo,
                        itemVehiculo.segUsuarioCrea,
                        itemVehiculo.segMaquinaOrigen);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Vehiculo
        /// En la BASE de DATO la Tabla : [Parqueo.Vehiculo]
        /// <summary>
        /// <param name = >itemVehiculo</param>
        public bool Update(VehiculoAux itemVehiculo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_Update_Vehiculo(
                        itemVehiculo.codVehiculo,
                        itemVehiculo.codPersonaCliente,
                        itemVehiculo.codRegTipoVehiculo,
                        itemVehiculo.codRegMarcaModelo,
                        itemVehiculo.codRegColorInterno,
                        itemVehiculo.codRegColorExterno,
                        itemVehiculo.codRegTipoAbono,
                        itemVehiculo.codNroChasis,
                        itemVehiculo.codNroMotor,
                        itemVehiculo.perAnio,
                        itemVehiculo.gloObservacion,
                        itemVehiculo.indActivo,
                        itemVehiculo.segUsuarioEdita,
                        itemVehiculo.segMaquinaOrigen);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Parqueo.Vehiculo
        /// En la BASE de DATO la Tabla : [Parqueo.Vehiculo]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(string prm_codVehiculo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_Delete_Vehiculo(prm_codVehiculo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
        #endregion

    }
} 

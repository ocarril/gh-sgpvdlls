namespace CROM.GestionParqueo.DataAccess
{using System;
using System.Collections.Generic;
using System.Configuration;

using CROM.BusinessEntities.Parqueo;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 28/11/2011-06:25:40 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Parqueo.MovimientoData.cs]
    /// </summary>
    public class MovimientoData
    {
        private string conexion = string.Empty;
        public MovimientoData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnxCROMSystema"].ConnectionString;
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Parqueo.Movimiento
        /// En la BASE de DATO la Tabla : [Parqueo.Movimiento]
        /// <summary>
        /// <returns>List</returns>
        public List<MovimientoAux> List(string p_FechaIngreso_desde, string p_FechaIngreso_Hasta, string p_codPersonaEmpresa, string p_codPuntoDeVenta, string p_codVehiculo, string p_codRegTipoVehiculo, string p_codPersonaCliente, string p_codTarifa, bool? p_indAbonado, bool? p_indFacturado, string p_segUsuarioCrea, ref int ? p_TotalOcupados)
        {
            List<MovimientoAux> miLista = new List<MovimientoAux>();
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_GetAll_Movimiento(p_FechaIngreso_desde, p_FechaIngreso_Hasta, p_codPersonaEmpresa, p_codPuntoDeVenta, p_codVehiculo, p_codRegTipoVehiculo, p_codPersonaCliente, p_codTarifa, p_indAbonado, p_indFacturado, p_segUsuarioCrea, ref p_TotalOcupados);
                    foreach (var item in resul)
                    {
                        miLista.Add(new MovimientoAux()
                        {
                            codMovimiento = item.codMovimiento,
                            codPersonaEmpresa = item.codPersonaEmpresa,
                            codPuntoDeVenta = item.codPuntoDeVenta,
                            codVehiculo = item.codVehiculo,
                            codRegTipoVehiculo = item.codRegTipoVehiculo,
                            codRegSectorParqueo = item.codRegSectorParqueo,
                            codPersonaCliente = item.codPersonaCliente,
                            fecHoraIngreso = item.fecHoraIngreso,
                            fecHoraSalida = item.fecHoraSalida,
                            perTotalHora = item.perTotalHora,
                            perTotalHoraFraccion = item.perTotalHoraFraccion,
                            codTarifa = item.codTarifa,
                            monTarifaBase = item.monTarifaBase,
                            monMontoPagado = item.monMontoPagado,
                            gloObservacion = item.gloObservacion,
                            indAbonado = item.indAbonado,
                            indFacturado = item.indFacturado,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraCrea = item.segFechaHoraCrea,
                            segFechaHoraEdita = item.segFechaHoraEdita,
                            segMaquinaOrigen = item.segMaquinaOrigen,
                            codPersonaClienteNombre = item.codPersonaClienteNombre,
                            codPersonaEmpresaNombre = item.codPersonaEmpresaNombre,
                            codPuntoDeVentaNombre = item.codPuntoDeVentaEmpresa,
                            codRegSectorParqueoNombre = item.codRegTipoVehiculoNombre,
                            codRegTipoVehiculoNombre = item.codRegTipoVehiculoNombre,
                            codTarifaNombre = item.codTarifaNombre,
                            codVehiculoNombre = item.codVehiculoNombre,
                            codDocumento = item.codDocumento,
                            numDocumento = item.numDocumento,
                            codRegEstadoDocumento = item.codRegEstadoDocumento,
                            ValorTipoCambioCMP = item.ValorTipoCambioCMP,
                            ValorTipoCambioVTA = item.ValorTipoCambioVTA,
                            codParte = item.CodigoParte,
                            indCancelado = item.indCancelado,

                            monTotalTarifado = item.monTotalTarifado,
                            monTotalNoche = item.monTotalNoche,
                            monTotalDscto = item.monTotalDscto,
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
        /// Retorna una ENTIDAD de registro de la Entidad Parqueo.Movimiento
        /// En la BASE de DATO la Tabla : [Parqueo.Movimiento]
        /// <summary>
        /// <returns>Entidad</returns>
        public MovimientoAux Find(string prm_codMovimiento)
        {
            MovimientoAux miEntidad = new MovimientoAux();
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_Find_Movimiento(prm_codMovimiento);
                    foreach (var item in resul)
                    {
                        miEntidad = new MovimientoAux()
                        {
                            codMovimiento = item.codMovimiento,
                            codPersonaEmpresa = item.codPersonaEmpresa,
                            codPuntoDeVenta = item.codPuntoDeVenta,
                            codVehiculo = item.codVehiculo,
                            codRegTipoVehiculo = item.codRegTipoVehiculo,
                            codRegSectorParqueo = item.codRegSectorParqueo,
                            codPersonaCliente = item.codPersonaCliente,
                            fecHoraIngreso = item.fecHoraIngreso,
                            fecHoraSalida = item.fecHoraSalida,
                            perTotalHora = item.perTotalHora,
                            perTotalHoraFraccion = item.perTotalHoraFraccion,
                            codTarifa = item.codTarifa,
                            monTarifaBase = item.monTarifaBase,
                            monMontoPagado = item.monMontoPagado,
                            gloObservacion = item.gloObservacion,
                            indAbonado = item.indAbonado,
                            indFacturado = item.indFacturado,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraCrea = item.segFechaHoraCrea,
                            segFechaHoraEdita = item.segFechaHoraEdita,
                            segMaquinaOrigen = item.segMaquinaOrigen,
                            codPersonaClienteNombre = item.codPersonaClienteNombre,
                            codPersonaEmpresaNombre = item.codPersonaEmpresaNombre,
                            codPuntoDeVentaNombre = item.codPuntoDeVentaEmpresa,
                            codRegTipoVehiculoNombre = item.codRegTipoVehiculoNombre,
                            codVehiculoNombre = item.codVehiculoNombre,
                            codRegSectorParqueoNombre = item.codRegSectorParqueoNombre,
                            codTarifaNombre = item.codTarifaNombre,
                            codDocumento = item.codDocumento,
                            numDocumento = item.numDocumento,
                            codParte = item.CodigoParte,
                            codRegEstadoDocumento = item.codRegEstadoDocumento,
                            indCancelado = item.indCancelado,
                            ValorTipoCambioCMP = item.ValorTipoCambioCMP,
                            ValorTipoCambioVTA = item.ValorTipoCambioVTA,

                            monTotalTarifado = item.monTotalTarifado,
                            monTotalNoche = item.monTotalNoche,
                            monTotalDscto = item.monTotalDscto,
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
        public MovimientoAux FindFecHoraSalida(string prm_codVehiculo)
        {
            MovimientoAux miEntidad = new MovimientoAux();
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_pro_FindFecHoraSalida_Movimiento(prm_codVehiculo);
                    foreach (var item in resul)
                    {
                        miEntidad = new MovimientoAux()
                        {
                            codMovimiento = item.codMovimiento,
                            codPersonaEmpresa = item.codPersonaEmpresa,
                            codPuntoDeVenta = item.codPuntoDeVenta,
                            codVehiculo = item.codVehiculo,
                            codRegTipoVehiculo = item.codRegTipoVehiculo,
                            codRegSectorParqueo = item.codRegSectorParqueo,
                            codPersonaCliente = item.codPersonaCliente,
                            fecHoraIngreso = item.fecHoraIngreso,
                            fecHoraSalida = item.fecHoraSalida,
                            perTotalHora = item.perTotalHora,
                            perTotalHoraFraccion = item.perTotalHoraFraccion,
                            codTarifa = item.codTarifa,
                            monTarifaBase = item.monTarifaBase,
                            monMontoPagado = item.monMontoPagado,
                            gloObservacion = item.gloObservacion,
                            indAbonado = item.indAbonado,
                            indFacturado = item.indFacturado,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraCrea = item.segFechaHoraCrea,
                            segFechaHoraEdita = item.segFechaHoraEdita,
                            segMaquinaOrigen = item.segMaquinaOrigen,
                            codPersonaClienteNombre = item.codPersonaClienteNombre,
                            codPersonaEmpresaNombre = item.codPersonaEmpresaNombre,
                            codPuntoDeVentaNombre = item.codPuntoDeVentaEmpresa,
                            codRegTipoVehiculoNombre = item.codRegTipoVehiculoNombre,
                            codVehiculoNombre = item.codVehiculoNombre,
                            codRegSectorParqueoNombre = item.codRegSectorParqueoNombre,
                            codTarifaNombre = item.codTarifaNombre,
                            codDocumento = item.codDocumento,
                            numDocumento = item.numDocumento,
                            codParte = item.CodigoParte,
                            codRegEstadoDocumento = item.codRegEstadoDocumento,
                            indCancelado = item.indCancelado,
                            ValorTipoCambioCMP = item.ValorTipoCambioCMP,
                            ValorTipoCambioVTA = item.ValorTipoCambioVTA,

                            monTotalTarifado = item.monTotalTarifado,
                            monTotalNoche = item.monTotalNoche,
                            monTotalDscto = item.monTotalDscto,
                             
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Movimiento
        /// En la BASE de DATO la Tabla : [Parqueo.Movimiento]
        /// <summary>
        /// <param name = >itemMovimiento</param>
        public string Insert(MovimientoAux itemMovimiento)
        {
            string codigoRetorno = null;
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    SQLDC.omgc_mnt_Insert_Movimiento(
                      ref codigoRetorno,
                      itemMovimiento.codPersonaEmpresa,
                      itemMovimiento.codPuntoDeVenta,
                      itemMovimiento.codVehiculo,
                      itemMovimiento.codRegTipoVehiculo,
                      itemMovimiento.codRegSectorParqueo,
                      itemMovimiento.codPersonaCliente,
                      itemMovimiento.fecHoraIngreso,
                      itemMovimiento.codTarifa,
                      itemMovimiento.monTarifaBase,
                      itemMovimiento.gloObservacion,
                      itemMovimiento.indAbonado,
                      itemMovimiento.indActivo,
                      itemMovimiento.segUsuarioCrea,
                      itemMovimiento.segMaquinaOrigen);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Movimiento
        /// En la BASE de DATO la Tabla : [Parqueo.Movimiento]
        /// <summary>
        /// <param name = >itemMovimiento</param>
        public bool Update(MovimientoAux itemMovimiento)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_Update_Movimiento(
                        itemMovimiento.codMovimiento,
                        itemMovimiento.codPersonaEmpresa,
                        itemMovimiento.codPuntoDeVenta,
                        itemMovimiento.codVehiculo,
                        itemMovimiento.codRegTipoVehiculo,
                        itemMovimiento.codRegSectorParqueo,
                        itemMovimiento.codPersonaCliente,
                        itemMovimiento.fecHoraIngreso,
                        itemMovimiento.codTarifa,
                        itemMovimiento.monTarifaBase,
                        itemMovimiento.gloObservacion,
                        itemMovimiento.indAbonado,
                        itemMovimiento.indActivo,
                        itemMovimiento.segUsuarioEdita,
                        itemMovimiento.segMaquinaOrigen);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
        public bool UpdateFecHoraSalida(MovimientoAux itemMovimiento)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_pro_UpdateFecHoraSalida_Movimiento(
                        itemMovimiento.codMovimiento,
                        itemMovimiento.fecHoraSalida,
                       itemMovimiento.perTotalHora,
                       itemMovimiento.perTotalHoraFraccion,
                        itemMovimiento.codTarifa,
                        itemMovimiento.monTarifaBase,

                        itemMovimiento.monTotalTarifado,
                        itemMovimiento.monTotalNoche,
                        itemMovimiento.monTotalDscto,

                        itemMovimiento.monMontoPagado,
                        itemMovimiento.gloObservacion,
                        itemMovimiento.indAbonado,
                        itemMovimiento.indActivo,
                        itemMovimiento.segUsuarioEdita,
                        itemMovimiento.segMaquinaOrigen);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
        public bool UpdateIndFacturado(MovimientoAux itemMovimiento)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_pro_UpdateindFacturado_Movimiento(
                        itemMovimiento.codMovimiento,
                        itemMovimiento.indFacturado,
                        itemMovimiento.segUsuarioEdita,
                        itemMovimiento.segMaquinaOrigen,
                        itemMovimiento.codDocumento,
                        itemMovimiento.numDocumento);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;

        }
        public bool UpdateIndCancelado(MovimientoAux itemMovimiento)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_pro_UpdateindCancelado_Movimiento(
                        itemMovimiento.codMovimiento,
                        itemMovimiento.indCancelado,
                        itemMovimiento.segUsuarioEdita,
                        itemMovimiento.segMaquinaOrigen);
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
        /// ELIMINA un registro de la Entidad Parqueo.Movimiento
        /// En la BASE de DATO la Tabla : [Parqueo.Movimiento]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(string p_codMovimiento, string p_UsuarioEdita)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_Delete_Movimiento(p_codMovimiento, p_UsuarioEdita);
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

namespace CROM.GestionParqueo.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Parqueo;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 28/11/2011-06:25:40 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Parqueo.TarifaData.cs]
    /// </summary>
    public class TarifaData
    {
        private string conexion = string.Empty;
        public TarifaData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnxCROMSystema"].ConnectionString;
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Parqueo.Tarifa
        /// En la BASE de DATO la Tabla : [Parqueo.Tarifa]
        /// </summary>
        /// <param name="p_codPersonaEmpresa">Código de la empresa</param>
        /// <param name="p_codPuntoDeventa">Código del punto de venta</param>
        /// <param name="p_codRegTipoVehiculo">Código de tipo de vehículo</param>
        /// <param name="p_indActivo">Estado del vehículo</param>
        /// <returns>Una lista/colección de la entidad TarifaAux</returns>
        public List<TarifaAux> List(string p_codPersonaEmpresa, string p_codPuntoDeventa, string p_desNombre, string p_codRepTipoVehiculo, bool? p_indActivo)
        {
            List<TarifaAux> miLista = new List<TarifaAux>();
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_GetAll_Tarifa(p_codPersonaEmpresa, p_codPuntoDeventa, p_desNombre, p_codRepTipoVehiculo, p_indActivo);
                    foreach (var item in resul)
                    {
                        miLista.Add(new TarifaAux()
                        {
                            codTarifa = item.codTarifa,
                            codPersonaEmpresa = item.codPersonaEmpresa,
                            codPuntoDeVenta = item.codPuntoDeVenta,
                            codRegTipoVehiculo = item.codRegTipoVehiculo,
                            codProducto = Convert.ToInt32(item.codProducto),
                            desNombre = item.desNombre,
                            monPrecioBase = item.monPrecioBase,
                            perMinutoMinimo = item.perMinutoMinimo,
                            monPrecioAdicional1 = item.monPrecioAdicional1,
                            perMinutoAplicaDesde = item.perMinutoAplicaDesde,
                            monPrecioAdicional2 = item.monPrecioAdicional2,
                            perMinutoFrecuencia = item.perMinutoFrecuencia,
                            perHoraDeEstadia = item.perHoraDeEstadia,
                            perHoraAplicaDespuesDe = item.perHoraAplicaDespuesDe,
                            perMinutoTolerancia = item.perMinutoTolerancia,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraCrea = item.segFechaHoraCrea,
                            segFechaHoraEdita = item.segFechaHoraEdita,
                            segMaquinaOrigen = item.segMaquinaOrigen,
                            codPersonaEmpresaNombre = item.codPersonaEmpresaNombre,
                            codProductoNombre = item.codProductoNombre,
                            codPuntoDeVentaNombre = item.codPuntoDeVentaNombre,
                            codRegTipoVehiculoNombre = item.codRegTipoVehiculoNombre
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
        /// Retorna una ENTIDAD de registro de la Entidad Parqueo.Tarifa
        /// En la BASE de DATO la Tabla : [Parqueo.Tarifa]
        /// </summary>
        /// <param name="p_codTarifa">Código de tarifa</param>
        /// <returns>Devuelve la entidad Tarifa</returns>
        public TarifaAux Find(string p_codTarifa)
        {
            TarifaAux miEntidad = new TarifaAux();
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_Find_Tarifa(p_codTarifa);
                    foreach (var item in resul)
                    {
                        miEntidad = new TarifaAux()
                        {
                            codTarifa = item.codTarifa,
                            codPersonaEmpresa = item.codPersonaEmpresa,
                            codPuntoDeVenta = item.codPuntoDeVenta,
                            codRegTipoVehiculo = item.codRegTipoVehiculo,
                            codProducto = Convert.ToInt32(item.codProducto),
                            desNombre = item.desNombre,
                            monPrecioBase = item.monPrecioBase,
                            perMinutoMinimo = item.perMinutoMinimo,
                            monPrecioAdicional1 = item.monPrecioAdicional1,
                            perMinutoAplicaDesde = item.perMinutoAplicaDesde,
                            monPrecioAdicional2 = item.monPrecioAdicional2,
                            perMinutoFrecuencia = item.perMinutoFrecuencia,
                            perHoraDeEstadia = item.perHoraDeEstadia,
                            perHoraAplicaDespuesDe = item.perHoraAplicaDespuesDe,
                            perMinutoTolerancia = item.perMinutoTolerancia,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraCrea = item.segFechaHoraCrea,
                            segFechaHoraEdita = item.segFechaHoraEdita,
                            segMaquinaOrigen = item.segMaquinaOrigen,
                            codPersonaEmpresaNombre = item.codPersonaEmpresaNombre,
                            codProductoNombre = item.codProductoNombre,
                            codPuntoDeVentaNombre = item.codPuntoDeVentaNombre,
                            codRegTipoVehiculoNombre = item.codRegTipoVehiculoNombre

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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Tarifa
        /// En la BASE de DATO la Tabla : [Parqueo.Tarifa]
        /// </summary>
        /// <param name="p_itemTarifa">Entidad de tarifa</param>
        /// <returns>Código generado de la entidad tarifa</returns>
        public string Insert(TarifaAux p_itemTarifa)
        {
            string codigoRetorno = null;
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    SQLDC.omgc_mnt_Insert_Tarifa(
                    ref codigoRetorno,
                    p_itemTarifa.codPersonaEmpresa,
                    p_itemTarifa.codPuntoDeVenta,
                    p_itemTarifa.codRegTipoVehiculo,
                    p_itemTarifa.codProducto.ToString(),
                    p_itemTarifa.desNombre,
                    p_itemTarifa.monPrecioBase,
                    p_itemTarifa.perMinutoMinimo,
                    p_itemTarifa.monPrecioAdicional1,
                    p_itemTarifa.perMinutoAplicaDesde,
                    p_itemTarifa.monPrecioAdicional2,
                    p_itemTarifa.perMinutoFrecuencia,
                    p_itemTarifa.perHoraDeEstadia,
                    p_itemTarifa.perHoraAplicaDespuesDe,
                    p_itemTarifa.perMinutoTolerancia,
                    p_itemTarifa.indActivo,
                    p_itemTarifa.segUsuarioCrea,
                    p_itemTarifa.segMaquinaOrigen);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Tarifa
        /// En la BASE de DATO la Tabla : [Parqueo.Tarifa]
        /// </summary>
        /// <param name="itemTarifa">Entidad tarifa con datos</param>
        /// <returns>Valor Boolean true=OK false=No OK</returns>
        public bool Update(TarifaAux p_itemTarifa)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_Update_Tarifa(
                        p_itemTarifa.codTarifa,
                        p_itemTarifa.codPersonaEmpresa,
                        p_itemTarifa.codPuntoDeVenta,
                        p_itemTarifa.codRegTipoVehiculo,
                        p_itemTarifa.codProducto.ToString(),
                        p_itemTarifa.desNombre,
                        p_itemTarifa.monPrecioBase,
                        p_itemTarifa.perMinutoMinimo,
                        p_itemTarifa.monPrecioAdicional1,
                        p_itemTarifa.perMinutoAplicaDesde,
                        p_itemTarifa.monPrecioAdicional2,
                        p_itemTarifa.perMinutoFrecuencia,
                        p_itemTarifa.perHoraDeEstadia,
                        p_itemTarifa.perHoraAplicaDespuesDe,
                        p_itemTarifa.perMinutoTolerancia,
                        p_itemTarifa.indActivo,
                        p_itemTarifa.segUsuarioEdita,
                        p_itemTarifa.segMaquinaOrigen);
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
        /// ELIMINA un registro de la Entidad Parqueo.Tarifa
        /// En la BASE de DATO la Tabla : [Parqueo.Tarifa]
        /// </summary>
        /// <param name="p_codTarifa">Código de Tarifa</param>
        /// <returns></returns>
        public bool Delete(string p_codTarifa)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ParqueoDataContext SQLDC = new _ParqueoDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_Delete_Tarifa(p_codTarifa);
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

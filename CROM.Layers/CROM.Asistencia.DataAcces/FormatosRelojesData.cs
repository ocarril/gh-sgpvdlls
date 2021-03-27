namespace CROM.Asistencia.DataAcces
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Asistencia;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 12/01/2010-05:21:26 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Asistencia.FormatosRelojesData.cs]
    /// </summary>
    public class FormatosRelojesData
    {
        private string conexion = string.Empty;
        public FormatosRelojesData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnxCROMSystema"].ConnectionString;
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Asistencia.FormatosRelojes
        /// En la BASE de DATO la Tabla : [Asistencia.FormatosRelojes]
        /// <summary>
        /// <returns>List</returns>
        public List<BEFormatoReloj> List(string prm_CodigoFormato, string prm_Descripcion, bool prm_Estado)
        {
            List<BEFormatoReloj> miLista = new List<BEFormatoReloj>();
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_GetAllFromFormatosRelojes(prm_CodigoFormato, prm_Descripcion, prm_Estado);
                    foreach (var item in resul)
                    {
                        miLista.Add(new BEFormatoReloj()
                        {
                            CodigoFormato = item.CodigoFormato,
                            Descripcion = item.Descripcion,
                            RegistroLong = Convert.ToInt16(item.RegistroLong),
                            RegistroDeta = item.RegistroDeta,
                            PosicionTarjetaIni = item.PosicionTarjetaIni,
                            PosicionTarjetaFin = item.PosicionTarjetaFin,
                            PosicionFechaIni = item.PosicionFechaIni,
                            PosicionFechaFin = item.PosicionFechaFin,
                            PosicionAnioIni = item.PosicionAnioIni,
                            PosicionAnioFin = item.PosicionAnioFin,
                            PosicionMesIni = item.PosicionMesIni,
                            PosicionMesFin = item.PosicionMesFin,
                            PosicionDiaIni = item.PosicionDiaIni,
                            PosicionDiaFin = item.PosicionDiaFin,
                            PosicionHoraIni = item.PosicionHoraIni,
                            PosicionHoraFin = item.PosicionHoraFin,
                            PosicionMinutoIni = item.PosicionMinutoIni,
                            PosicionMinutoFin = item.PosicionMinutoFin,
                            PosicionSegundoIni = item.PosicionSegundoIni,
                            PosicionSegundoFin = item.PosicionSegundoFin,
                            PosicionTeclaIni = item.PosicionTeclaIni,
                            PosicionTeclaFin = item.PosicionTeclaFin,
                            Estado = item.Estado,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegFechaHoraEdita = item.SegFechaHoraEdita,
                            SegMaquinaOrigen = item.SegMaquinaOrigen,

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
        /// Retorna una ENTIDAD de registro de la Entidad Asistencia.FormatosRelojes
        /// En la BASE de DATO la Tabla : [Asistencia.FormatosRelojes]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEFormatoReloj Find(string prm_CodigoFormato)
        {
            BEFormatoReloj miEntidad = new BEFormatoReloj();
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_GetByIdCodeFormatosRelojes(prm_CodigoFormato);
                    foreach (var item in resul)
                    {
                        miEntidad = new BEFormatoReloj()
                        {
                            CodigoFormato = item.CodigoFormato,
                            Descripcion = item.Descripcion,
                            RegistroLong = Convert.ToInt16(item.RegistroLong),
                            RegistroDeta = item.RegistroDeta,
                            PosicionTarjetaIni = item.PosicionTarjetaIni,
                            PosicionTarjetaFin = item.PosicionTarjetaFin,
                            PosicionFechaIni = item.PosicionFechaIni,
                            PosicionFechaFin = item.PosicionFechaFin,
                            PosicionAnioIni = item.PosicionAnioIni,
                            PosicionAnioFin = item.PosicionAnioFin,
                            PosicionMesIni = item.PosicionMesIni,
                            PosicionMesFin = item.PosicionMesFin,
                            PosicionDiaIni = item.PosicionDiaIni,
                            PosicionDiaFin = item.PosicionDiaFin,
                            PosicionHoraIni = item.PosicionHoraIni,
                            PosicionHoraFin = item.PosicionHoraFin,
                            PosicionMinutoIni = item.PosicionMinutoIni,
                            PosicionMinutoFin = item.PosicionMinutoFin,
                            PosicionSegundoIni = item.PosicionSegundoIni,
                            PosicionSegundoFin = item.PosicionSegundoFin,
                            PosicionTeclaIni = item.PosicionTeclaIni,
                            PosicionTeclaFin = item.PosicionTeclaFin,
                            Estado = item.Estado,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegFechaHoraEdita = item.SegFechaHoraEdita,
                            SegMaquinaOrigen = item.SegMaquinaOrigen,

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
        /// Almacena el registro de una ENTIDAD de registro de Tipo FormatosRelojes
        /// En la BASE de DATO la Tabla : [Asistencia.FormatosRelojes]
        /// <summary>
        /// <param name = >itemFormatosRelojes</param>
        public bool Insert(BEFormatoReloj itemFormatosRelojes)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_InsertFormatosRelojes(
                        itemFormatosRelojes.CodigoFormato,
                        itemFormatosRelojes.Descripcion,
                        itemFormatosRelojes.RegistroLong,
                        itemFormatosRelojes.RegistroDeta,
                        Convert.ToByte(itemFormatosRelojes.PosicionTarjetaIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionTarjetaFin),
                        Convert.ToByte(itemFormatosRelojes.PosicionFechaIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionFechaFin),
                        Convert.ToByte(itemFormatosRelojes.PosicionAnioIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionAnioFin),
                        Convert.ToByte(itemFormatosRelojes.PosicionMesIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionMesFin),
                        Convert.ToByte(itemFormatosRelojes.PosicionDiaIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionDiaFin),
                        Convert.ToByte(itemFormatosRelojes.PosicionHoraIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionHoraFin),
                        Convert.ToByte(itemFormatosRelojes.PosicionMinutoIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionMinutoFin),
                        Convert.ToByte(itemFormatosRelojes.PosicionSegundoIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionSegundoFin),
                        Convert.ToByte(itemFormatosRelojes.PosicionTeclaIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionTeclaFin),
                        itemFormatosRelojes.Estado,
                        itemFormatosRelojes.SegUsuarioCrea);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo FormatosRelojes
        /// En la BASE de DATO la Tabla : [Asistencia.FormatosRelojes]
        /// <summary>
        /// <param name = >itemFormatosRelojes</param>
        public bool Update(BEFormatoReloj itemFormatosRelojes)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_UpdateFormatosRelojes(
                        itemFormatosRelojes.CodigoFormato,
                        itemFormatosRelojes.Descripcion,
                        itemFormatosRelojes.RegistroLong,
                        itemFormatosRelojes.RegistroDeta,
                        Convert.ToByte(itemFormatosRelojes.PosicionTarjetaIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionTarjetaFin),
                        Convert.ToByte(itemFormatosRelojes.PosicionFechaIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionFechaFin),
                        Convert.ToByte(itemFormatosRelojes.PosicionAnioIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionAnioFin),
                        Convert.ToByte(itemFormatosRelojes.PosicionMesIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionMesFin),
                        Convert.ToByte(itemFormatosRelojes.PosicionDiaIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionDiaFin),
                        Convert.ToByte(itemFormatosRelojes.PosicionHoraIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionHoraFin),
                        Convert.ToByte(itemFormatosRelojes.PosicionMinutoIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionMinutoFin),
                        Convert.ToByte(itemFormatosRelojes.PosicionSegundoIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionSegundoFin),
                        Convert.ToByte(itemFormatosRelojes.PosicionTeclaIni),
                        Convert.ToByte(itemFormatosRelojes.PosicionTeclaFin),
                        itemFormatosRelojes.Estado,
                        itemFormatosRelojes.SegUsuarioEdita
                        );
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
        /// ELIMINA un registro de la Entidad Asistencia.FormatosRelojes
        /// En la BASE de DATO la Tabla : [Asistencia.FormatosRelojes]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(string prm_CodigoFormato)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_DeleteFormatosRelojes(prm_CodigoFormato);
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

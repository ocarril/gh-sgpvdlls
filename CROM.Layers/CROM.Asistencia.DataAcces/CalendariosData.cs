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
    /// Archivo     : [Asistencia.CalendariosData.cs]
    /// </summary>
    public class CalendariosData
    {
        private string conexion = string.Empty;
        public CalendariosData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnxCROMSystema"].ConnectionString;
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Asistencia.Calendarios
        /// En la BASE de DATO la Tabla : [Asistencia.Calendarios]
        /// <summary>
        /// <returns>List</returns>
        public List<BECalendario> List(string prm_CodigoCalendario, string prm_Descripcion, bool prm_Estado)
        {
            List<BECalendario> miLista = new List<BECalendario>();
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_GetAllFromCalendarios(prm_CodigoCalendario, prm_Descripcion, prm_Estado);
                    foreach (var item in resul)
                    {
                        miLista.Add(new BECalendario()
                        {
                            CodigoCalendario = item.CodigoCalendario,
                            Descripcion = item.Descripcion,
                            Anio = item.Anio,
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
        /// Retorna una ENTIDAD de registro de la Entidad Asistencia.Calendarios
        /// En la BASE de DATO la Tabla : [Asistencia.Calendarios]
        /// <summary>
        /// <returns>Entidad</returns>
        public BECalendario Find(string prm_CodigoCalendario)
        {
            BECalendario miEntidad = new BECalendario();
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_GetByIdCodeCalendarios(prm_CodigoCalendario);
                    foreach (var item in resul)
                    {
                        miEntidad = new BECalendario()
                        {
                            CodigoCalendario = item.CodigoCalendario,
                            Descripcion = item.Descripcion,
                            Anio = item.Anio,
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Calendarios
        /// En la BASE de DATO la Tabla : [Asistencia.Calendarios]
        /// <summary>
        /// <param name = >itemCalendarios</param>
        public bool Insert(BECalendario itemCalendarios)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_InsertCalendarios(
                        itemCalendarios.CodigoCalendario,
                        itemCalendarios.Descripcion,
                        itemCalendarios.Anio,
                        itemCalendarios.Estado,
                        itemCalendarios.SegUsuarioCrea);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Calendarios
        /// En la BASE de DATO la Tabla : [Asistencia.Calendarios]
        /// <summary>
        /// <param name = >itemCalendarios</param>
        public bool Update(BECalendario itemCalendarios)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_UpdateCalendarios(
                        itemCalendarios.CodigoCalendario,
                        itemCalendarios.Descripcion,
                        itemCalendarios.Anio,
                        itemCalendarios.Estado,
                        itemCalendarios.SegUsuarioEdita);
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
        /// ELIMINA un registro de la Entidad Asistencia.Calendarios
        /// En la BASE de DATO la Tabla : [Asistencia.Calendarios]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(string prm_CodigoCalendario)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_DeleteCalendarios(prm_CodigoCalendario);
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

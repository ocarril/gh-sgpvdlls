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
    /// Archivo     : [Asistencia.CalendariosDiasData.cs]
    /// </summary>
    public class CalendariosDiasData
    {
        private string conexion = string.Empty;
        public CalendariosDiasData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnxCROMSystema"].ConnectionString;
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Asistencia.CalendariosDias
        /// En la BASE de DATO la Tabla : [Asistencia.CalendariosDias]
        /// <summary>
        /// <returns>List</returns>
        public List<BECalendarioDia> List(string prm_CodigoCalendario, string prm_CodigoArguDiaSemana, string prm_Registro, bool prm_Estado, string prm_CodigoTabla)
        {
            List<BECalendarioDia> miLista = new List<BECalendarioDia>();
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_GetAllFromCalendariosDias(prm_CodigoCalendario, prm_CodigoArguDiaSemana, prm_Registro, prm_Estado, prm_CodigoTabla);
                    foreach (var item in resul)
                    {
                        miLista.Add(new BECalendarioDia()
                        {
                            CodigoCalendario = item.CodigoCalendario,
                            CodigoArguDiaSemana = item.CodigoArguDiaSemana,
                            CodigoArguDiaSemanaNombre = item.CodigoArguDiaSemanaNombre,
                            Registro = item.Registro,
                            FechaInicio = item.FechaInicio,
                            FechaFinal = item.FechaFinal,
                            CodigoHorario = item.CodigoHorario,
                            CodigoHorarioNombre = item.CodigoHorarioNombre,
                            Estado = item.Estado,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegFechaHoraEdita = item.SegFechaHoraEdita,
                            SegMaquinaOrigen = item.SegMaquinaOrigen,
                            Proceso = "Registrada"
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

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo CalendariosDias
        /// En la BASE de DATO la Tabla : [Asistencia.CalendariosDias]
        /// <summary>
        /// <param name = >itemCalendariosDias</param>
        public string Insert(BECalendarioDia itemCalendariosDias)
        {
            string codigoRetorno = "";
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    SQLDC.omgc_mnt_InsertCalendariosDias(
                        ref codigoRetorno,
                        itemCalendariosDias.CodigoCalendario,
                        itemCalendariosDias.CodigoArguDiaSemana,
                        Convert.ToDateTime(itemCalendariosDias.FechaInicio.ToShortDateString()),
                        Convert.ToDateTime(itemCalendariosDias.FechaFinal.ToShortDateString()),
                        itemCalendariosDias.CodigoHorario,
                        itemCalendariosDias.Estado,
                        itemCalendariosDias.SegUsuarioCrea
                    );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno != null ? codigoRetorno : null;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo CalendariosDias
        /// En la BASE de DATO la Tabla : [Asistencia.CalendariosDias]
        /// <summary>
        /// <param name = >itemCalendariosDias</param>
        public bool Update(BECalendarioDia itemCalendariosDias)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_UpdateCalendariosDias(
                        itemCalendariosDias.Registro,
                        itemCalendariosDias.CodigoCalendario,
                        itemCalendariosDias.CodigoArguDiaSemana,
                        Convert.ToDateTime(itemCalendariosDias.FechaInicio.ToShortDateString()),
                        Convert.ToDateTime(itemCalendariosDias.FechaFinal.ToShortDateString()),
                        itemCalendariosDias.CodigoHorario,
                        itemCalendariosDias.Estado,
                        itemCalendariosDias.SegUsuarioEdita
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
        /// ELIMINA un registro de la Entidad Asistencia.CalendariosDias
        /// En la BASE de DATO la Tabla : [Asistencia.CalendariosDias]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(string prm_Registro, string prm_CodigoCalendario)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_DeleteCalendariosDias(prm_Registro, prm_CodigoCalendario);
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

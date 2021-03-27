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
    /// Archivo     : [Asistencia.PersonasAgendaData.cs]
    /// </summary>
    public class PersonasAgendaData
    {
        private string conexion = string.Empty;
        public PersonasAgendaData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnxCROMSystema"].ConnectionString;
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Asistencia.PersonasAgenda
        /// En la BASE de DATO la Tabla : [Asistencia.PersonasAgenda]
        /// <summary>
        /// <returns>List</returns>
        public List<BEPersonaAgenda> List(string prm_CodigoPersona, string prm_CodigoJustificacion, bool prm_Estado)
        {
            List<BEPersonaAgenda> miLista = new List<BEPersonaAgenda>();
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_GetAllFromPersonasAgenda(prm_CodigoPersona, prm_CodigoJustificacion, prm_Estado);
                    foreach (var item in resul)
                    {
                        miLista.Add(new BEPersonaAgenda()
                        {
                            Item = item.Item,
                            CodigoPersona = item.CodigoPersona,
                            CodigoJustificacion = item.CodigoJustificacion,
                            CodigoJustificacionNombre = item.CodigoJustificacionNombre,
                            Anio = item.Anio,
                            FechaInicio = item.FechaInicio,
                            FechaFinal = item.FechaFinal,
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
        /// Retorna una ENTIDAD de registro de la Entidad Asistencia.PersonasAgenda
        /// En la BASE de DATO la Tabla : [Asistencia.PersonasAgenda]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEPersonaAgenda Find(string prm_Item)
        {
            BEPersonaAgenda miEntidad = new BEPersonaAgenda();
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_GetByIdCodePersonasAgenda(prm_Item);
                    foreach (var item in resul)
                    {
                        miEntidad = new BEPersonaAgenda()
                        {
                            Item = item.Item,
                            CodigoPersona = item.CodigoPersona,
                            CodigoJustificacion = item.CodigoJustificacion,
                            Anio = item.Anio,
                            FechaInicio = item.FechaInicio,
                            FechaFinal = item.FechaFinal,
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo PersonasAgenda
        /// En la BASE de DATO la Tabla : [Asistencia.PersonasAgenda]
        /// <summary>
        /// <param name = >itemPersonasAgenda</param>
        public string Insert(BEPersonaAgenda itemPersonasAgenda)
        {
            string codigoRetorno = string.Empty;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    SQLDC.omgc_mnt_InsertPersonasAgenda
                        (
                        ref codigoRetorno,
                        itemPersonasAgenda.CodigoPersona,
                        itemPersonasAgenda.CodigoJustificacion,
                        itemPersonasAgenda.Anio,
                        Convert.ToDateTime(itemPersonasAgenda.FechaInicio.ToShortDateString()),
                        Convert.ToDateTime(itemPersonasAgenda.FechaFinal.ToShortDateString()),
                        itemPersonasAgenda.Estado,
                        itemPersonasAgenda.SegUsuarioCrea
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo PersonasAgenda
        /// En la BASE de DATO la Tabla : [Asistencia.PersonasAgenda]
        /// <summary>
        /// <param name = >itemPersonasAgenda</param>
        public bool Update(BEPersonaAgenda itemPersonasAgenda)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_UpdatePersonasAgenda
                    (
                        itemPersonasAgenda.Item,
                        itemPersonasAgenda.CodigoPersona,
                        itemPersonasAgenda.CodigoJustificacion,
                        itemPersonasAgenda.Anio,
                        Convert.ToDateTime(itemPersonasAgenda.FechaInicio.ToShortDateString()),
                        Convert.ToDateTime(itemPersonasAgenda.FechaFinal.ToShortDateString()),
                        itemPersonasAgenda.Estado,
                        itemPersonasAgenda.SegUsuarioEdita
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
        /// ELIMINA un registro de la Entidad Asistencia.PersonasAgenda
        /// En la BASE de DATO la Tabla : [Asistencia.PersonasAgenda]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(string prm_Item)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_DeletePersonasAgenda(prm_Item);
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

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
    /// Archivo     : [Asistencia.HorarioData.cs]
    /// </summary>
    public class HorarioData
    {
        private string conexion = string.Empty;
        public HorarioData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnxCROMSystema"].ConnectionString;
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Asistencia.Horario
        /// En la BASE de DATO la Tabla : [Asistencia.Horario]
        /// <summary>
        /// <returns>List</returns>
        public List<BEHorario> List(string Descripcion, string CodigoArguTipoHorario, bool Estado)
        {
            List<BEHorario> miLista = new List<BEHorario>();
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_GetAllFromHorario(Descripcion, CodigoArguTipoHorario, Estado);
                    foreach (var item in resul)
                    {
                        miLista.Add(new BEHorario()
                        {
                            CodigoHorario = item.CodigoHorario,
                            Descripcion = item.Descripcion,
                            HorasLabor = item.HorasLabor,
                            HEntrada = item.HEntrada,
                            HSalida = item.HSalida,
                            Tolerancia = item.Tolerancia,
                            CodigoArguTipoHorario = item.CodigoArguTipoHorario,
                            CodigoArguTipoHorarioNombre = item.CodigoArguTipoHorarioNombre,
                            CodigoHorarioRefer = item.CodigoHorarioRefer,
                            DiaSabado = item.DiaSabado,
                            MinAlmuerzo = item.MinAlmuerzo,
                            RefrigerioSalida = item.RefrigerioSalida,
                            RefrigerioEntrada = item.RefrigerioEntrada,
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
        /// Retorna una ENTIDAD de registro de la Entidad Asistencia.Horario
        /// En la BASE de DATO la Tabla : [Asistencia.Horario]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEHorario Find(int prm_CodigoHorario)
        {
            BEHorario miEntidad = new BEHorario();
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_GetByIdCodeHorario(prm_CodigoHorario);
                    foreach (var item in resul)
                    {
                        miEntidad = new BEHorario()
                        {
                            CodigoHorario = item.CodigoHorario,
                            Descripcion = item.Descripcion,
                            HorasLabor = item.HorasLabor,
                            HEntrada = item.HEntrada,
                            HSalida = item.HSalida,
                            Tolerancia = item.Tolerancia,
                            CodigoArguTipoHorario = item.CodigoArguTipoHorario,
                            CodigoHorarioRefer = item.CodigoHorarioRefer,
                            DiaSabado = item.DiaSabado,
                            MinAlmuerzo = item.MinAlmuerzo,
                            RefrigerioSalida = item.RefrigerioSalida,
                            RefrigerioEntrada = item.RefrigerioEntrada,
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Horario
        /// En la BASE de DATO la Tabla : [Asistencia.Horario]
        /// <summary>
        /// <param name = >itemHorario</param>
        public bool Insert(BEHorario itemHorario)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_InsertHorario(
                        itemHorario.CodigoHorario,
                        itemHorario.Descripcion,
                        itemHorario.HorasLabor,
                        itemHorario.HEntrada,
                        itemHorario.HSalida,
                        itemHorario.Tolerancia,
                        itemHorario.CodigoArguTipoHorario,
                        itemHorario.CodigoHorarioRefer,
                        itemHorario.DiaSabado,
                        itemHorario.MinAlmuerzo,
                        itemHorario.RefrigerioSalida,
                        itemHorario.RefrigerioEntrada,
                        itemHorario.Estado,
                        itemHorario.SegUsuarioCrea);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Horario
        /// En la BASE de DATO la Tabla : [Asistencia.Horario]
        /// <summary>
        /// <param name = >itemHorario</param>
        public bool Update(BEHorario itemHorario)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_UpdateHorario(
                        itemHorario.CodigoHorario,
                        itemHorario.Descripcion,
                        itemHorario.HorasLabor,
                        itemHorario.HEntrada,
                        itemHorario.HSalida,
                        itemHorario.Tolerancia,
                        itemHorario.CodigoArguTipoHorario,
                        itemHorario.CodigoHorarioRefer,
                        itemHorario.DiaSabado,
                        itemHorario.MinAlmuerzo,
                        itemHorario.RefrigerioSalida,
                        itemHorario.RefrigerioEntrada,
                        itemHorario.Estado,
                        itemHorario.SegUsuarioEdita);
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
        /// ELIMINA un registro de la Entidad Asistencia.Horario
        /// En la BASE de DATO la Tabla : [Asistencia.Horario]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(int prm_CodigoHorario)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_DeleteHorario(prm_CodigoHorario);
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

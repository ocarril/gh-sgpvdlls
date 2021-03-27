namespace CROM.Asistencia.DataAcces
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Asistencia;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 19/01/2010-11:21:54 p.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Asistencia.MarcacionesData.cs]
    /// </summary>
    public class MarcacionesData
    {
        private string conexion = string.Empty;
        public MarcacionesData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnxCROMSystema"].ConnectionString;
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Asistencia.Marcaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Marcaciones]
        /// <summary>
        /// <returns>List</returns>
        public List<BEMarcacion> List(string prm_NumeroMarcacion, DateTime prm_FechaHoraINI, DateTime prm_FechaHoraFIN)
        {
            List<BEMarcacion> miLista = new List<BEMarcacion>();
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_GetAllFromMarcaciones(prm_NumeroMarcacion, prm_FechaHoraINI, prm_FechaHoraFIN);
                    foreach (var item in resul)
                    {
                        miLista.Add(new BEMarcacion()
                        {
                            IdRegistro = item.IdRegistro,
                            NumeroMarcacion = item.NumeroMarcacion,
                            FechaTexto = item.FechaTexto,
                            Hora = item.Hora,
                            FechaHora = item.FechaHora,
                            CodigoReloj = item.CodigoReloj,
                            TeclaReloj = item.TeclaReloj,
                            CodigoJustificacion = item.CodigoJustificacion,
                            Edicion = item.Edicion,
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
        /// Retorna una ENTIDAD de registro de la Entidad Asistencia.Marcaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Marcaciones]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEMarcacion Find(string prm_NumeroMarcacion, DateTime prm_FechaHora, string prm_Hora)
        {
            BEMarcacion miEntidad = new BEMarcacion();
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    var resul = SQLDC.omgc_pro_GetByIdCodeMarcaciones(prm_NumeroMarcacion, prm_FechaHora, prm_Hora);
                    foreach (var item in resul)
                    {
                        miEntidad = new BEMarcacion()
                        {
                            IdRegistro = item.IdRegistro,
                            NumeroMarcacion = item.NumeroMarcacion,
                            FechaTexto = item.FechaTexto,
                            Hora = item.Hora,
                            FechaHora = item.FechaHora,
                            CodigoReloj = item.CodigoReloj,
                            TeclaReloj = item.TeclaReloj,
                            CodigoJustificacion = item.CodigoJustificacion,
                            Edicion = item.Edicion,
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

        public BEMarcacion Find(string prm_IdRegistro)
        {
            BEMarcacion miEntidad = new BEMarcacion();
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_GetByIdCodeMarcaciones(prm_IdRegistro);
                    foreach (var item in resul)
                    {
                        miEntidad = new BEMarcacion()
                        {
                            IdRegistro = item.IdRegistro,
                            NumeroMarcacion = item.NumeroMarcacion,
                            FechaTexto = item.FechaTexto,
                            Hora = item.Hora,
                            FechaHora = item.FechaHora,
                            CodigoReloj = item.CodigoReloj,
                            TeclaReloj = item.TeclaReloj,
                            CodigoJustificacion = item.CodigoJustificacion,
                            Edicion = item.Edicion,
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Marcaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Marcaciones]
        /// <summary>
        /// <param name = >itemMarcaciones</param>
        public string Insert(BEMarcacion itemMarcaciones)
        {
            string codigoRetorno = null;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    SQLDC.omgc_mnt_InsertMarcaciones(
                    ref codigoRetorno,
                    itemMarcaciones.NumeroMarcacion,
                    itemMarcaciones.FechaTexto,
                    itemMarcaciones.Hora,
                    itemMarcaciones.FechaHora,
                    itemMarcaciones.CodigoReloj,
                    itemMarcaciones.TeclaReloj,
                    itemMarcaciones.CodigoJustificacion,
                    itemMarcaciones.Edicion,
                    itemMarcaciones.Estado,
                    itemMarcaciones.SegUsuarioCrea);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno;
        }


        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Marcaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Marcaciones]
        /// <summary>
        /// <param name = >itemMarcaciones</param>
        public bool Insert(BEMarcaje itemMarcajes)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_InsertMarcajes(
                       itemMarcajes.NumeroMarcacion,
                       itemMarcajes.FechaTexto,
                       itemMarcajes.Hora,
                       itemMarcajes.FechaHora,
                       itemMarcajes.CodigoReloj,
                       itemMarcajes.TeclaReloj,
                       itemMarcajes.Estado,
                       itemMarcajes.SegUsuarioCreaL);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public string InsertInterno(BEMarcacion itemMarcaciones)
        {
            string codigoRetorno = null;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    SQLDC.omgc_mnt_InsertMarcacionesInterno(
                    ref codigoRetorno,
                    itemMarcaciones.NumeroMarcacion,
                    itemMarcaciones.CodigoReloj,
                    itemMarcaciones.TeclaReloj,
                    itemMarcaciones.CodigoJustificacion,
                    itemMarcaciones.Edicion,
                    itemMarcaciones.Estado,
                    itemMarcaciones.SegUsuarioCrea);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Marcaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Marcaciones]
        /// <summary>
        /// <param name = >itemMarcaciones</param>
        public bool Update(BEMarcacion itemMarcaciones)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_UpdateMarcaciones(
                        itemMarcaciones.IdRegistro,
                        itemMarcaciones.NumeroMarcacion,
                        itemMarcaciones.FechaTexto,
                        itemMarcaciones.Hora,
                        itemMarcaciones.FechaHora,
                        itemMarcaciones.CodigoReloj,
                        itemMarcaciones.TeclaReloj,
                        itemMarcaciones.CodigoJustificacion,
                        itemMarcaciones.Edicion,
                        itemMarcaciones.Estado,
                        itemMarcaciones.SegUsuarioEdita
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
        /// ELIMINA un registro de la Entidad Asistencia.Marcaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Marcaciones]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(string prm_IdRegistro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_DeleteMarcaciones(prm_IdRegistro);
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

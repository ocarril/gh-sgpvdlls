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
    /// Archivo     : [Asistencia.JustificacionesData.cs]
    /// </summary>
    public class JustificacionesData
    {
        private string conexion = string.Empty;
        public JustificacionesData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnxCROMSystema"].ConnectionString;
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Asistencia.Justificaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Justificaciones]
        /// <summary>
        /// <returns>List</returns>
        public List<BEJustificacion> List(string prm_CodigoJustificacion, string prm_Descripcion, bool prm_Estado)
        {
            List<BEJustificacion> miLista = new List<BEJustificacion>();
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_GetAllFromJustificaciones(prm_CodigoJustificacion, prm_Descripcion, prm_Estado);
                    foreach (var item in resul)
                    {
                        miLista.Add(new BEJustificacion()
                        {
                            CodigoJustificacion = item.CodigoJustificacion,
                            Descripcion = item.Descripcion,
                            EsRemunerable = item.EsRemunerable,
                            EsEspecial = item.EsEspecial,
                            EsEliminado = item.EsEliminado,
                            EnlaceJustificacion = item.EnlaceJustificacion,
                            CodigoArguTeclaReloj = item.CodigoArguTeclaReloj,
                            CodigoArguNombreReloj = item.CodigoArguNombreReloj,
                            CodigoArguComputa = item.CodigoArguComputa,
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
        /// Retorna una ENTIDAD de registro de la Entidad Asistencia.Justificaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Justificaciones]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEJustificacion Find(string prm_CodigoJustificacion)
        {
            BEJustificacion miEntidad = new BEJustificacion();
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_GetByIdCodeJustificaciones(prm_CodigoJustificacion);
                    foreach (var item in resul)
                    {
                        miEntidad = new BEJustificacion()
                        {
                            CodigoJustificacion = item.CodigoJustificacion,
                            Descripcion = item.Descripcion,
                            EsRemunerable = item.EsRemunerable,
                            EsEspecial = item.EsEspecial,
                            EsEliminado = item.EsEliminado,
                            EnlaceJustificacion = item.EnlaceJustificacion,
                            CodigoArguTeclaReloj = item.CodigoArguTeclaReloj,
                            CodigoArguNombreReloj = item.CodigoArguNombreReloj,
                            CodigoArguComputa = item.CodigoArguComputa,
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Justificaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Justificaciones]
        /// <summary>
        /// <param name = >itemJustificaciones</param>
        public bool Insert(BEJustificacion itemJustificaciones)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_InsertJustificaciones(
                        itemJustificaciones.CodigoJustificacion,
                        itemJustificaciones.Descripcion,
                        itemJustificaciones.EsRemunerable,
                        itemJustificaciones.EsEspecial,
                        itemJustificaciones.EsEliminado,
                        itemJustificaciones.EnlaceJustificacion,
                        itemJustificaciones.CodigoArguTeclaReloj,
                        itemJustificaciones.CodigoArguNombreReloj,
                        itemJustificaciones.CodigoArguComputa,
                        itemJustificaciones.Estado,
                        itemJustificaciones.SegUsuarioCrea);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Justificaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Justificaciones]
        /// <summary>
        /// <param name = >itemJustificaciones</param>
        public bool Update(BEJustificacion itemJustificaciones)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_UpdateJustificaciones(
                        itemJustificaciones.CodigoJustificacion,
                        itemJustificaciones.Descripcion,
                        itemJustificaciones.EsRemunerable,
                        itemJustificaciones.EsEspecial,
                        itemJustificaciones.EsEliminado,
                        itemJustificaciones.EnlaceJustificacion,
                        itemJustificaciones.CodigoArguTeclaReloj,
                        itemJustificaciones.CodigoArguNombreReloj,
                        itemJustificaciones.CodigoArguComputa,
                        itemJustificaciones.Estado,
                        itemJustificaciones.SegUsuarioEdita);
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
        /// ELIMINA un registro de la Entidad Asistencia.Justificaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Justificaciones]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(string prm_CodigoJustificacion)
        {
            int codigoRetorno = -1;
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_DeleteJustificaciones(prm_CodigoJustificacion);
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

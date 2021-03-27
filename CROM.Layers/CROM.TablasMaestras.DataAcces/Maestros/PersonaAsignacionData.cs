namespace CROM.TablasMaestras.DataAcces
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Maestros;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 07/01/2010-04:07:28 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Maestros.PersonasAsignacionesData.cs]
    /// </summary>
    public class PersonasAsignacionesData
    {
        private string conexion = string.Empty;

        public PersonasAsignacionesData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT BY ID CODE */


        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestros.PersonasAsignaciones
        /// En la BASE de DATO la Tabla : [Maestros.PersonasAsignaciones]
        /// <summary>
        /// <param name="prm_CodigoPersona"></param>
        /// <param name="prm_CodigoArguAsignacion"></param>
        /// <returns></returns>
        public BEPersonasAsignacion Find(int pcodEmpresa, string prm_codPersona, string prm_codRegAsignacion)
        {
            BEPersonasAsignacion personaAsignacion = new BEPersonasAsignacion();
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PersonaAsignacion_ID(pcodEmpresa, prm_codPersona, prm_codRegAsignacion);
                    foreach (var item in resul)
                    {
                        personaAsignacion = new BEPersonasAsignacion()
                        {
                            CodigoPersona = item.codPersona,
                            CodigoArguAsignacion = item.codRegAsignacion,
                            CodigoArguAsignacionNombre = item.codRegAsignacionNombre,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaHoraEdita = item.SegFechaHoraEdita,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegMaquinaOrigen = item.SegMaquinaOrigen,
                            SegEliminado = item.SegEliminado,
                            Estado = item.Estado,

                        };
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return personaAsignacion;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE FOREIGN KEY*/

        /// <summary>
        /// Retorna una LISTA de registro de la Entidad Maestros.PersonasAsignaciones POR FOREIGN KEY
        /// En la BASE de DATO la Tabla : [Maestros.PersonasAsignaciones]
        /// <summary>
        /// <param name="prm_CodigoPersona"></param>
        /// <returns></returns>
        public List<BEPersonasAsignacion> ListBy_Persona(int pcodEmpresa, string prm_codPersona)
        {
            List<BEPersonasAsignacion> lstPersonasAsignaciones = new List<BEPersonasAsignacion>();
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PersonaAsignacion(pcodEmpresa, prm_codPersona);
                    foreach (var item in resul)
                    {
                        lstPersonasAsignaciones.Add(new BEPersonasAsignacion()
                        {
                            CodigoPersona = item.codPersona,
                            CodigoArguAsignacion = item.codRegAsignacion,
                            CodigoArguAsignacionNombre = item.codRegAsignacionNombre,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaHoraEdita = item.SegFechaHoraEdita,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegMaquinaOrigen = item.SegMaquinaOrigen,
                            SegEliminado = item.SegEliminado,
                            Estado = item.Estado,

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPersonasAsignaciones;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PersonasAsignaciones
        /// En la BASE de DATO la Tabla : [Maestros.PersonasAsignaciones]
        /// <summary>
        /// <param name = >itemPersonasAsignaciones</param>
        public bool Insert(BEPersonasAsignacion personaAsignacion, out string pMensaje)
        {
            int codigoRetorno = -1;
            pMensaje = string.Empty;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resulSet = SQLDC.omgc_I_PersonaAsignacion(
                        personaAsignacion.codEmpresa,
                        personaAsignacion.CodigoPersona,
                        personaAsignacion.CodigoArguAsignacion,
                        personaAsignacion.SegUsuarioCrea,
                        personaAsignacion.SegMaquinaOrigen,
                        personaAsignacion.Estado);

                    foreach (var item in resulSet)
                    {
                        codigoRetorno = item.codError.Value;
                        pMensaje = item.desMessage;
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return codigoRetorno > 0 ? true : false;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        ///// <summary>
        ///// Almacena el registro de una ENTIDAD de registro de Tipo PersonasAsignaciones
        ///// En la BASE de DATO la Tabla : [Maestros.PersonasAsignaciones]
        ///// <summary>
        ///// <param name="personaAsignacion"></param>
        ///// <returns></returns>
        //public bool Update(BEPersonasAsignacion personaAsignacion)
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
        //        {
        //            codigoRetorno = SQLDC.omgc_U_PersonaAsignacion(
        //                personaAsignacion.CodigoPersona,
        //                personaAsignacion.CodigoArguAsignacion,
        //                personaAsignacion.SegUsuarioEdita,
        //                personaAsignacion.Estado);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == 0 ? true : false;
        //}

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Maestros.PersonasAsignaciones
        /// En la BASE de DATO la Tabla : [Maestros.PersonasAsignaciones]
        /// <summary>
        /// <param name="prm_codPersona"></param>
        /// <param name="prm_codRegAsignacion"></param>
        /// <returns></returns>
        public bool Delete(int pcodEmpresa, string prm_codPersona, string prm_codRegAsignacion, string pUsuarioEdita,
                           out string pMensaje)
        {
            int codigoRetorno = -1;
            pMensaje = string.Empty;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resulSet = SQLDC.omgc_D_PersonaAsignacion(pcodEmpresa, 
                                                                  prm_codPersona, 
                                                                  prm_codRegAsignacion, 
                                                                  pUsuarioEdita);
                    foreach (var item in resulSet)
                    {
                        codigoRetorno = item.codError.Value;
                        pMensaje = item.desMessage;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return codigoRetorno > 0 ? true : false;
        }

        #endregion

    }


}
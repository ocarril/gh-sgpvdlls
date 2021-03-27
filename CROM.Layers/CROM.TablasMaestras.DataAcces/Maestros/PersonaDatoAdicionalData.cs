namespace CROM.TablasMaestras.DataAcces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CROM.BusinessEntities.Maestros;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 07/01/2010-11:20:20 p.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Maestros.PersonasDatosAdicionalesData.cs]
    /// </summary>
    public class PersonasDatosAdicionalesData
    {
        private string conexion = string.Empty;

        public PersonasDatosAdicionalesData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestros.PersonasDatosAdicionales
        /// En la BASE de DATO la Tabla : [Maestros.PersonasDatosAdicionales]
        /// <summary>
        /// <param name="prm_codPersona"></param>
        /// <returns></returns>
        public BEPersonaDato Find(int pcodEmpresa, string prm_codPersona)
        {
            BEPersonaDato personaDatoAdicional = new BEPersonaDato();
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PersonaDatoAdicional_ID(pcodEmpresa, prm_codPersona);
                    foreach (var item in resul)
                    {
                        personaDatoAdicional = new BEPersonaDato()
                        {
                            CodigoPersona = item.CodigoPersona,
                            ApellidoPaterno = item.ApellidoPaterno,
                            ApellidoMaterno = item.ApellidoMaterno,
                            Nombre1 = item.Nombre1,
                            Nombre2 = item.Nombre2,
                            CodigoArguAreaEmpleado = item.CodigoArguAreaEmpleado,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaHoraEdita = item.SegFechaHoraEdita,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegMaquinaOrigen = item.SegMaquinaOrigen,
                            SegEliminado = item.SegurEliminado,
                            Estado = item.Estado,
                            Apellidos = item.ApellidoPaterno == null ? string.Empty : item.ApellidoPaterno + " " + item.ApellidoMaterno == null ? string.Empty : item.ApellidoMaterno,
                            Nombres = item.Nombre1 == null ? string.Empty : item.Nombre1 + " " + item.Nombre2 == null ? string.Empty : item.Nombre2,
                        };
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return personaDatoAdicional;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE FOREIGN KEY*/

        /// <summary>
        /// Retorna una LISTA de registro de la Entidad Maestros.PersonasDatosAdicionales POR FOREIGN KEY
        /// En la BASE de DATO la Tabla : [Maestros.PersonasDatosAdicionales]
        /// <summary>
        /// <param name="prm_codPersona"></param>
        /// <param name="prm_codPerEmpresa"></param>
        /// <returns></returns>
        public List<BEPersonaDato> ListBy_Persona(int pcodEmpresa, string prm_codPersona, string prm_codPerEmpresa)
        {
            List<BEPersonaDato> lstPersonaDatoAdicional = new List<BEPersonaDato>();
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PersonaDatoAdicional_codEmpresa(pcodEmpresa, prm_codPersona, prm_codPerEmpresa);
                    foreach (var item in resul)
                    {
                        lstPersonaDatoAdicional.Add(new BEPersonaDato()
                        {
                            CodigoPersona = item.codPersona,
                            ApellidoPaterno = item.ApellidoPaterno,
                            ApellidoMaterno = item.ApellidoMaterno,
                            Nombre1 = item.Nombre1,
                            Nombre2 = item.Nombre2,
                            CodigoArguAreaEmpleado = item.codRegAreaEmpleado,
                            CodigoArguAreaEmpleadoNombre = item.codRegAreaEmpleadoNombre,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaHoraEdita = item.SegFechaHoraEdita,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegMaquinaOrigen = item.SegMaquinaOrigen,
                            SegEliminado = item.SegurEliminado,
                            Estado = item.Estado,

                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstPersonaDatoAdicional;
        }

        #endregion

        #region /* Proceso de INSERT RECORD - UPDATE RECORD  */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PersonasDatosAdicionales
        /// En la BASE de DATO la Tabla : [Maestros.PersonasDatosAdicionales]
        /// <summary>
        /// <param name="personaDatoAdicional"></param>
        /// <returns></returns>
        public bool InsertUpdate(BEPersonaDato personaDatoAdicional, out string pMensaje)
        {
            int codigoRetorno = -1;
            pMensaje = string.Empty;

            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resulSet = SQLDC.omgc_I_PersonaDatoAdicional(
                        personaDatoAdicional.CodigoPersona,
                        personaDatoAdicional.ApellidoPaterno,
                        personaDatoAdicional.ApellidoMaterno,
                        personaDatoAdicional.Nombre1,
                        personaDatoAdicional.Nombre2,
                        personaDatoAdicional.CodigoArguAreaEmpleado,
                        personaDatoAdicional.SegUsuarioCrea,
                        personaDatoAdicional.Estado);

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

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Maestros.PersonasDatosAdicionales
        /// En la BASE de DATO la Tabla : [Maestros.PersonasDatosAdicionales]
        /// <summary>
        /// <param name="prm_codPersona"></param>
        /// <returns></returns>
        public bool Delete(int pcodEmpresa, string prm_codPersona, string prm_Usuario, out string pMensaje)
        {
            int codigoRetorno = -1;
            pMensaje = string.Empty;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resulSet = SQLDC.omgc_D_PersonaDatoAdicional(pcodEmpresa, prm_codPersona, prm_Usuario);

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

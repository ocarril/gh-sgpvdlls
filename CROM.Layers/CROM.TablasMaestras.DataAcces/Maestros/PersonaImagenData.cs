namespace CROM.TablasMaestras.DataAcces
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Maestros;
    
    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 07/01/2010-04:07:28 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Maestros.PersonasFotoLogoData.cs]
    /// </summary>
    public class PersonasFotoLogoData
    {
        private string conexion = string.Empty;

        public PersonasFotoLogoData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestros.PersonasFotoLogo
        /// En la BASE de DATO la Tabla : [Maestros.PersonasFotoLogo]
        /// <summary>
        /// <param name="prm_codPersona"></param>
        /// <returns></returns>
        public BEPersonaFotoLogo Find(int pcodEmpresa, string prm_codPersona)
        {
            BEPersonaFotoLogo personaFotoLogo = new BEPersonaFotoLogo();
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PersonaFotoLogo_ID(pcodEmpresa, prm_codPersona);
                    foreach (var item in resul)
                    {
                        personaFotoLogo = new BEPersonaFotoLogo()
                        {
                            CodigoPersona = item.CodigoPersona,
                            FotoLogoNombre = item.FotoLogoNombre,
                            FotoLogoBinary = convertirVarBinary(item.FotoLogoBinary),
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
            catch (Exception ex)
            {
                throw ex;
            }
            return personaFotoLogo;
        }

        private byte[] convertirVarBinary(System.Data.Linq.Binary miVarBinary)
        {
            if (miVarBinary != null)
            {
                byte[] Foto = miVarBinary.ToArray();
                return (Foto);
            }
            else
                return (null);
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PersonasFotoLogo
        /// En la BASE de DATO la Tabla : [Maestros.PersonasFotoLogo]
        /// <summary>
        /// <param name="personaFotoLogo"></param>
        /// <returns></returns>
        public bool Insert(BEPersonaFotoLogo personaFotoLogo, out string pMensaje)
        {
            int codigoRetorno = -1;
            pMensaje = string.Empty;
            try
            {

                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resulSet = SQLDC.omgc_I_PersonaFotoLogo(
                        personaFotoLogo.codEmpresa,
                        personaFotoLogo.CodigoPersona,
                        personaFotoLogo.FotoLogoNombre,
                        personaFotoLogo.FotoLogoBinary,
                        personaFotoLogo.SegUsuarioCrea,
                        personaFotoLogo.Estado);

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
        /// ELIMINA un registro de la Entidad Maestros.PersonasFotoLogo
        /// En la BASE de DATO la Tabla : [Maestros.PersonasFotoLogo]
        /// <summary>
        /// <param name="prm_codPersona"></param>
        /// <returns></returns>
        public bool Delete(int pcodEmpresa, string prm_codPersona, string pUser, out string pMensaje)
        {
            int codigoRetorno = -1;
            pMensaje = string.Empty;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resulSet = SQLDC.omgc_D_PersonaFotoLogo(pcodEmpresa, prm_codPersona, pUser);

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

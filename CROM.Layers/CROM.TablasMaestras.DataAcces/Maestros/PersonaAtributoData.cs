namespace CROM.TablasMaestras.DataAcces
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Maestros;
    using CROM.BusinessEntities;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 07/01/2010-04:07:28 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Maestros.PersonasAtributosData.cs]
    /// </summary>
    public class PersonasAtributosData
    {
        private string conexion = string.Empty;
        public PersonasAtributosData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestros.PersonasAtributos
        /// En la BASE de DATO la Tabla : [Maestros.PersonasAtributos]
        /// <summary>
        /// <param name="prm_codPersona"></param>
        /// <param name="prm_codRegTipoAtributo"></param>
        /// <returns></returns>
        public BEPersonaAtributo Find(int pcodEmpresa, string prm_codPersona, string prm_codRegTipoAtributo)
        {
            BEPersonaAtributo personaAtributo = null;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PersonaAtributo_ID(pcodEmpresa, prm_codPersona, prm_codRegTipoAtributo);
                    foreach (var item in resul)
                    {
                        personaAtributo = new BEPersonaAtributo()
                        {
                            CodigoPersona = item.codPersona,
                            CodigoArguAtributo = item.codRegAtributo,
                            CodigoArguAtributoNombre = item.codRegAtributoNombre,
                            CodigoArguTipoAtributo = item.codRegTipoAtributo,
                            CodigoArguTipoAtributoNombre = item.codRegTipoAtributoNombre,
                            DescripcionAtributo = item.codRegAtributoValor,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaHoraEdita = item.SegFechaHoraEdita,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegMaquinaOrigen = item.SegMaquinaOrigen,
                            SegEliminado = item.SegEliminado,
                            Estado = item.Estado,
                            Proceso = "Registrada"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return personaAtributo;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE FOREIGN KEY*/

        /// <summary>
        /// Retorna una LISTA de registro de la Entidad Maestros.PersonasAtributos POR FOREIGN KEY
        /// En la BASE de DATO la Tabla : [Maestros.PersonasAtributos]
        /// <summary>
        /// <param name="prm_codPersona"></param>
        /// <returns></returns>
        public List<BEPersonaAtributo> ListBy_Persona(int pcodEmpresa, string prm_codPersona)
        {
            List<BEPersonaAtributo> listaPersonaAtributo = new List<BEPersonaAtributo>();
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PersonaAtributo_codPersona(pcodEmpresa, prm_codPersona);

                    foreach (var item in resul)
                    {
                        listaPersonaAtributo.Add(new BEPersonaAtributo()
                        {
                            CodigoPersona = item.codPersona,
                            CodigoArguAtributo = item.codRegAtributo,
                            CodigoArguAtributoNombre = item.codRegAtributoNombre,
                            CodigoArguTipoAtributo = item.codRegTipoAtributo,
                            CodigoArguTipoAtributoNombre = item.codRegTipoAtributoNombre,
                            DescripcionAtributo = item.codRegTipoAtributoValor,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaHoraEdita = item.SegFechaHoraEdita,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegMaquinaOrigen = item.SegMaquinaOrigen,
                            SegEliminado = item.SegEliminado,
                            Estado = item.Estado,
                            Proceso = "Registrada"
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listaPersonaAtributo;
        }

        public List<BEPersonaAtributo> ListBy_Persona_Paged(BaseFiltroMaestro pFiltro)
        {
            List<BEPersonaAtributo> listaPersonaAtributo = new List<BEPersonaAtributo>();
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PersonaAtributo_Paged(pFiltro.codEmpresa,
                                                                   pFiltro.GNumPagina, 
                                                                   pFiltro.GTamPagina, 
                                                                   pFiltro.GOrdenPor, 
                                                                   pFiltro.GOrdenTipo, 
                                                                   pFiltro.codigoEntidad,
                                                                   string.Empty);
                    foreach (var item in resul)
                    {
                        listaPersonaAtributo.Add(new BEPersonaAtributo()
                        {
                            CodigoPersona = item.codPersona,
                            CodigoArguAtributo = item.codRegAtributo,
                            CodigoArguAtributoNombre = item.codRegAtributoNombre,
                            CodigoArguTipoAtributo = item.codRegTipoAtributo,
                            CodigoArguTipoAtributoNombre = item.codRegTipoAtributoNombre,
                            DescripcionAtributo = item.codRegTipoAtributoValor,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaHoraEdita = item.SegFechaHoraEdita,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegMaquinaOrigen = item.SegMaquinaOrigen,
                            SegEliminado = item.SegEliminado,
                            Estado = item.Estado,
                            Proceso = "Registrada",

                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaPersonaAtributo;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PersonasAtributos
        /// En la BASE de DATO la Tabla : [Maestros.PersonasAtributos]
        /// <summary>
        /// <param name = >itemPersonasAtributos</param>
        public bool Insert(BEPersonaAtributo personaAtributo, out string pMensaje)
        {
            int codigoRetorno = -1;
            pMensaje = string.Empty;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resulSet = SQLDC.omgc_IU_PersonaAtributo(
                        personaAtributo.codEmpresa,
                        personaAtributo.CodigoPersona,
                        personaAtributo.CodigoArguTipoAtributo,
                        personaAtributo.DescripcionAtributo,
                        personaAtributo.SegUsuarioCrea,
                        personaAtributo.SegMaquinaOrigen,
                        personaAtributo.Estado);

                    foreach (var item in resulSet)
                    {
                        codigoRetorno = item.codError.Value;
                        pMensaje = item.desMessage;
                    }
                }
            }
            catch (Exception )
            {
                throw ;
            }
            return codigoRetorno > 0 ? true : false;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        ///// <summary>
        ///// Almacena el registro de una ENTIDAD de registro de Tipo PersonasAtributos
        ///// En la BASE de DATO la Tabla : [Maestros.PersonasAtributos]
        ///// <summary>
        ///// <param name="personaAtributo"></param>
        ///// <returns></returns>
        //public bool Update(BEPersonaAtributo personaAtributo, out string pMensaje)
        //{
        //    int codigoRetorno = -1;
        //    pMensaje = string.Empty;
        //    try
        //    {
        //        using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
        //        {
        //            var resulSet = SQLDC.omgc_U_PersonaAtributo(
        //                personaAtributo.codEmpresa,
        //                personaAtributo.CodigoPersona,
        //                personaAtributo.CodigoArguTipoAtributo,
        //                personaAtributo.DescripcionAtributo,
        //                personaAtributo.CodigoArguUbigeo,
        //                personaAtributo.SegUsuarioEdita,
        //                personaAtributo.Estado);

        //            foreach (var item in resulSet)
        //            {
        //                codigoRetorno = item.codError.Value;
        //                pMensaje = item.desMessage;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return codigoRetorno > 0 ? true : false;
        //}

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Maestros.PersonasAtributos
        /// En la BASE de DATO la Tabla : [Maestros.PersonasAtributos]
        /// <summary>
        /// <param name="prm_codPersona"></param>
        /// <param name="prm_codRegTipoAtributo"></param>
        /// <returns></returns>
        public bool Delete(int pcodEmpresa, string prm_codPersona, string prm_codRegTipoAtributo, string pUsuarioEdita,
                           out string pMensaje)
        {
            int codigoRetorno = -1;
            pMensaje = string.Empty;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resulSet = SQLDC.omgc_D_PersonaAtributo(pcodEmpresa, 
                                                                 prm_codPersona, 
                                                                 prm_codRegTipoAtributo,
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

        public bool ValidarAtributo(BEPersonaAtributo pItem, ref string p_Cod_personaExist, ref string p_Name_personaExist)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_P_PersonaAtributo_Valida
                        (
                        pItem.codEmpresa,
                        pItem.CodigoPersona,
                        pItem.CodigoArguTipoAtributo,
                        pItem.DescripcionAtributo,
                        ref p_Cod_personaExist,
                        ref p_Name_personaExist
                        );
                }
                if (p_Cod_personaExist == null)
                    codigoRetorno = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

    }
}

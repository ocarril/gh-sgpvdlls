namespace CROM.TablasMaestras.DataAcces.Maestros
{
    using CROM.BusinessEntities.Maestros;
    using CROM.BusinessEntities.Maestros.DTO;
    using CROM.BusinessEntities.Maestros.Entidades;
    using CROM.Tools.Comun;
    using System;
    using System.Collections.Generic;


    /// <summary>
	/// Proyecto    :  Modulo de Mantenimiento de : 
	/// Creacion    : CROM - Orlando Carril Ramírez
	/// Fecha       : 29/11/2019-11:45:02
	/// Descripcion : Capa de Datos 
	/// Archivo     : [Maestros.PersonasDomicilioData.cs]
	/// </summary>
	public class PersonasDomicilioData
    {
        private string conexion = string.Empty;
        public PersonasDomicilioData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */ 

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Maestros.PersonasDomicilio
        /// En la BASE de DATO la Tabla : [Maestros.PersonasDomicilio]
        /// <summary>
        /// <returns>List</returns>
        public List<BEPersonasDomicilio> List(int pcodEmpresa, string pcodPersona, bool pActivo)
        {
            List<BEPersonasDomicilio> lstPersonasDomicilio = new List<BEPersonasDomicilio>();
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PersonasDomicilio(pcodEmpresa, pcodPersona, null, pActivo);
                    foreach (var item in resul)
                    {
                        lstPersonasDomicilio.Add(new BEPersonasDomicilio()
                        {
                            codPersonaDomicilio = item.codPersonaDomicilio,
                            codPersona = item.codPersona,
                            codRegTipo = item.codRegTipo,
                            codRegVia = item.codRegVia,
                            codRegTipoNombre = item.codRegTipoNombre,
                            codRegViaNombre = item.codRegViaNombre,
                            codRegNucleoUrbNombre = item.codRegNucleoUrbNombre,

                            gloDireccion = item.gloDireccion,
                            

                            desNumero = item.desNumero,
                            codRegNucleoUrb = item.codRegNucleoUrb,
                            desNucleoUrb = item.desNucleoUrb,
                            codUbigeo = item.codUbigeo,
                            codUbigeoCode = item.codUbigeoCode,
                            codUbigeoNombre = item.codUbigeoNombre,
                            gloReferencia = item.gloReferencia,
                            gloDireccionConcat = item.gloDireccionConcat,
                            gloDireccionGeoCod = item.gloDireccionGeoCod,
                            gloDireccionSunat = item.gloDireccionSunat,
                            numLatitud = Extensors.CheckDecimal( item.numLatitud),
                            numLongitud = Extensors.CheckDecimal(item.numLongitud),
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquinaCrea,
                            segMaquinaEdita = item.segMaquinaEdita,

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPersonasDomicilio;
        }
      
        #endregion

        #region /* Proceso de SELECT BY ID CODE */ 

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestros.PersonasDomicilio
        /// En la BASE de DATO la Tabla : [Maestros.PersonasDomicilio]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEPersonasDomicilio Find(int pcodEmpresa, string pcodPersona, int? pcodPersonaDomicilio)
        {
            BEPersonasDomicilio objPersonasDomicilio = null;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PersonasDomicilio(pcodEmpresa, 
                                                               pcodPersona, 
                                                               pcodPersonaDomicilio, null);
                    foreach (var item in resul)
                    {
                        objPersonasDomicilio = new BEPersonasDomicilio()
                        {
                            codPersonaDomicilio = item.codPersonaDomicilio,
                            codPersona = item.codPersona,
                            codRegTipo = item.codRegTipo,
                            codRegVia = item.codRegVia,
                            gloDireccion = item.gloDireccion,
                            desNumero = item.desNumero,
                            codRegNucleoUrb = item.codRegNucleoUrb,
                            desNucleoUrb = item.desNucleoUrb,
                            codUbigeo = item.codUbigeo,
                            gloReferencia = item.gloReferencia,
                            gloDireccionConcat = item.gloDireccionConcat,
                            gloDireccionGeoCod = item.gloDireccionGeoCod,
                            gloDireccionSunat = item.gloDireccionSunat,
                            numLatitud = Extensors.CheckDecimal(item.numLatitud),
                            numLongitud = Extensors.CheckDecimal(item.numLongitud),
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquinaCrea,
                            segMaquinaEdita = item.segMaquinaEdita,

                            codUbigeoProv = item.codUbigeoProv,
                            codUbigeoDpto= item.codUbigeoDpto
                        };
                    }
                }
            }
            catch (Exception)
            {
                throw ;
            }
            return objPersonasDomicilio;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE FOREIGN KEY*/ 

        /// <summary>
        /// Retorna una LISTA de registro de la Entidad Maestros.BEPersonasDomicilio POR FOREIGN KEY
        /// En la BASE de DATO la Tabla : [Maestros.BEPersonasDomicilio]
        /// <summary>
        /// <returns>Entidad</returns>
        public List<DTOPersonasDomicilioResponse> ListPage(BaseFiltroPersonaDomicilio pFiltro)
        {
            List<DTOPersonasDomicilioResponse> lstPersonasDomicilio = new List<DTOPersonasDomicilioResponse>();
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PersonasDomicilio_Page(pFiltro.jqCurrentPage,
                                                                    pFiltro.jqPageSize,
                                                                    pFiltro.jqSortColumn,
                                                                    pFiltro.jqSortOrder,
                                                                    pFiltro.codEmpresa,
                                                                    pFiltro.codPersona,
                                                                    pFiltro.desDireccion,
                                                                    pFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lstPersonasDomicilio.Add(new DTOPersonasDomicilioResponse()
                        {
                            ROWNUM = item.ROWNUM.HasValue? item.ROWNUM.Value:0,
                            TOTALROWS= item.TOTALROWS.HasValue? item.TOTALROWS.Value:0,

                            codPersonaDomicilio = item.codPersonaDomicilio,
                            codPersona = item.codPersona,
                            codRegTipoNombre = item.codRegTipoNombre,
                            codRegViaNombre = item.codRegViaNombre,
                            gloDireccion = item.gloDireccion,
                            desNumero = item.desNumero,
                            codRegNucleoUrbNombre = item.codRegNucleoUrbNombre,
                            desNucleoUrb = item.desNucleoUrb,
                            codUbigeo = item.codUbigeo,
                            codUbigeoCode = item.codUbigeoCode,
                            codUbigeoNombre = item.codUbigeoNombre,
                            nomUbigeo = item.nomUbigeo,
                            gloReferencia = item.gloReferencia,
                            gloDireccionConcat = item.gloDireccionConcat,
                            gloDireccionGeoCod = item.gloDireccionGeoCod,
                            gloDireccionSunat = item.gloDireccionSunat,
                            numLatitud = item.numLatitud,
                            numLongitud = item.numLongitud,
                            indActivo = item.indActivo,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaEdita = item.segMaquinaEdita,

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPersonasDomicilio;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */ 

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo BEPersonasDomicilio
        /// En la BASE de DATO la Tabla : [Maestros.BEPersonasDomicilio]
        /// <summary>
        /// <param name = >itemBEPersonasDomicilio</param>
        public bool Insert(BEPersonasDomicilio pPersonasDomicilio, out string pMensaje)
        {
            int codigoRetorno = -1;
            pMensaje = string.Empty;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var result = SQLDC.omgc_I_PersonasDomicilio(
                        pPersonasDomicilio.codPersona,
                        pPersonasDomicilio.codRegTipo,
                        pPersonasDomicilio.codRegVia,
                        pPersonasDomicilio.gloDireccion,
                        pPersonasDomicilio.desNumero,
                        pPersonasDomicilio.codRegNucleoUrb,
                        pPersonasDomicilio.desNucleoUrb,
                        pPersonasDomicilio.codUbigeo,
                        pPersonasDomicilio.gloReferencia,
                        pPersonasDomicilio.gloDireccionConcat,
                        pPersonasDomicilio.gloDireccionGeoCod,
                        pPersonasDomicilio.gloDireccionSunat,
                        Extensors.CheckDbl(pPersonasDomicilio.numLatitud),
                        Extensors.CheckDbl(pPersonasDomicilio.numLongitud),
                        pPersonasDomicilio.indActivo,
                        pPersonasDomicilio.segUsuarioCrea,
                        pPersonasDomicilio.segMaquinaCrea);

                    foreach (var item in result)
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

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PersonasDomicilio
        /// En la BASE de DATO la Tabla : [Maestros.PersonasDomicilio]
        /// <summary>
        /// <param name = >itemPersonasDomicilio</param>
        public bool Update(BEPersonasDomicilio pPersonasDomicilio, out string pMensaje)
        {
            int codigoRetorno = -1;
            pMensaje = string.Empty;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var result = SQLDC.omgc_U_PersonasDomicilio(
                        pPersonasDomicilio.codEmpresa,
                        pPersonasDomicilio.codPersonaDomicilio,
                        pPersonasDomicilio.codRegTipo,
                        pPersonasDomicilio.codRegVia,
                        pPersonasDomicilio.gloDireccion,
                        pPersonasDomicilio.desNumero,
                        pPersonasDomicilio.codRegNucleoUrb,
                        pPersonasDomicilio.desNucleoUrb,
                        pPersonasDomicilio.codUbigeo,
                        pPersonasDomicilio.gloReferencia,
                        pPersonasDomicilio.gloDireccionConcat,
                        pPersonasDomicilio.gloDireccionGeoCod,
                        pPersonasDomicilio.gloDireccionSunat,
                        Extensors.CheckDbl(pPersonasDomicilio.numLatitud),
                        Extensors.CheckDbl(pPersonasDomicilio.numLongitud),
                        pPersonasDomicilio.indActivo,
                        pPersonasDomicilio.segUsuarioEdita,
                        pPersonasDomicilio.segMaquinaEdita);

                    foreach (var item in result)
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
        /// ELIMINA un registro de la Entidad Maestros.PersonasDomicilio
        /// En la BASE de DATO la Tabla : [Maestros.PersonasDomicilio]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(int pcodEmpresa, 
                           string pcodEmpresaRUC,
                           int prm_codPersonaDomicilio, 
                           string pUsername, 
                           string pMaquina, out string pMensaje)
        {
            int codigoRetorno = -1;
            pMensaje = string.Empty;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resulSet = SQLDC.omgc_D_PersonasDomicilio(pcodEmpresa, 
                                                                  pcodEmpresaRUC, 
                                                                  prm_codPersonaDomicilio,
                                                                  pUsername,
                                                                  pMaquina);
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

}

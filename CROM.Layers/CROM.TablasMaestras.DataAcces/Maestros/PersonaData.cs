namespace CROM.TablasMaestras.DataAcces
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Maestros;
    using CROM.BusinessEntities;
    using CROM.BusinessEntities.Comercial.DTO;
    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.Maestros.DTO;
    using CROM.Tools.Comun.Web;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 07/01/2010-04:07:28 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Maestros.PersonasData.cs]
    /// </summary>
    public class PersonaData
    {
        private string conexion = string.Empty;

        public PersonaData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */


        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Maestros.Personas
        /// En la BASE de DATO la Tabla : [Maestros.Personas]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTOPersonaResponse> List(BaseFiltroPersona pFiltro)
        {
            List<DTOPersonaResponse> lstPersonas = new List<DTOPersonaResponse>();
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Persona(pFiltro.codEmpresa,
                                                     pFiltro.codRegTipoEntidad, 
                                                     pFiltro.codRegAsignacion, 
                                                     pFiltro.desNombre, 
                                                     pFiltro.codigoEntidad, 
                                                     pFiltro.codPersonaRefer, 
                                                     pFiltro.codRegAreaEmpresa, 
                                                     pFiltro.codRegCategoria, 
                                                     pFiltro.codRegTipoAtributo, 
                                                     pFiltro.desValor, 
                                                     pFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lstPersonas.Add(new DTOPersonaResponse()
                        {
                            codEmpresa = item.codEmpresa,
                            CodigoPersona = item.codPersona,
                            CodigoArguTipoEntidad = item.codRegTipoEntidad,
                            CodigoArguRubroComercial = item.codRegRubroComercial,
                            CodigoPersonaEmpresa = item.codPerEmpresa,
                            CodigoArguTipoEntidadNombre = item.codRegTipoEntidadNombre,
                            CodigoArguRubroComercialNombre = item.codRegRubroComercialNombre,
                            CodigoPersonaEmpresaNombre = item.codPerEmpresaNombre,
                            RazonSocial = item.RazonSocial,
                            NombreComercial = item.NombreComercial,
                            Observaciones = item.Observaciones,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaHoraEdita,
                            segMaquinaEdita = item.SegMaquinaOrigen,
                             Estado = item.Estado,
                            desDomicilio=item.desDomicilio,
                            desTelefono=item.desTelefono,
                            desNumDocumento=item.desNumDocumento 
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstPersonas;
        }

        //public List<DTOPersonaResponse> ListPaged(BaseFiltroPersona pFiltro)
        //{
        //    List<DTOPersonaResponse> lstPersonas = new List<DTOPersonaResponse>();
        //    try
        //    {
        //        using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
        //        {
        //            var resul = SQLDC.omgc_S_Persona_Paged(pFiltro.codEmpresa,
        //                                                    pFiltro.jqCurrentPage,
        //                                                    pFiltro.jqPageSize,
        //                                                    pFiltro.jqSortColumn,
        //                                                    pFiltro.jqSortOrder,
        //                                                    pFiltro.codRegTipoEntidad,
        //                                                    pFiltro.codRegAsignacion,
        //                                                    pFiltro.desNombre,
        //                                                    pFiltro.codigoEntidad,
        //                                                    pFiltro.codPersonaRefer,
        //                                                    pFiltro.codRegAreaEmpresa,
        //                                                    pFiltro.codRegCategoria,
        //                                                    pFiltro.codRegTipoAtributo,
        //                                                    pFiltro.desValor,
        //                                                    pFiltro.indActivo);
        //            foreach (var item in resul)
        //            {
        //                lstPersonas.Add(new DTOPersonaResponse()
        //                {
        //                    codEmpresa = item.codEmpresa,
        //                    CodigoPersona = item.codPersona,
        //                    CodigoArguTipoEntidad = item.codRegTipoEntidad,
        //                    CodigoArguRubroComercial = item.codRegRubroComercial,
        //                    CodigoPersonaEmpresa = item.codPerEmpresa,

        //                    CodigoArguTipoEntidadNombre = item.codRegTipoEntidadNombre,
        //                    CodigoArguRubroComercialNombre = item.codRegRubroComercialNombre,
        //                    CodigoPersonaEmpresaNombre = item.codPerEmpresaNombre,
        //                    desDomicilio = item.desDomicilio,
        //                    desNumDocumento = item.desNumDocumento,
        //                    desTelefono = item.desTelefono,

        //                    RazonSocial = item.RazonSocial,
        //                    NombreComercial = item.NombreComercial,
        //                    Observaciones = item.Observaciones,
        //                    segUsuarioEdita = item.segUsuarioEdita,
        //                    segFechaEdita = item.segFechaHoraEdita,
        //                    segMaquinaEdita = item.SegMaquinaOrigen,
        //                    Estado = item.Estado,

        //                    ROWNUM = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
        //                    TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0

        //                });
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return lstPersonas;
        //}

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Maestros.Personas clientes CROM
        /// En la BASE de DATO la Tabla : [Maestros.Personas]
        /// <summary>
        /// <returns>List</returns>
        public List<DTOEmpresaPersonaResponse> ListEmpresaEmision(int pcodEmpresa, string pnumRUC)
        {
            List<DTOEmpresaPersonaResponse> lstEmpresaEmision = new List<DTOEmpresaPersonaResponse>();
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Persona_EmpresaEmision(pcodEmpresa, pnumRUC);
                    foreach (var item in resul)
                    {
                        lstEmpresaEmision.Add(new DTOEmpresaPersonaResponse()
                        {
                            codEmpresa = item.codEmpresa,
                            codPersona = item.codPersona,
                            desDomicilio = item.desDomicilio,
                            desNumDocumento = item.desNumDocumento,

                            codRegTipoEntidadNombre = item.codRegTipoEntidadNombre,
                            nomRazonSocial = item.nomRazonSocial,
                            nomComercial = item.nomComercial,
                            codRegRubroComercialNombre = item.codRegRubroComercialNombre,
                            cntDomicilio = item.cntDomicilio.HasValue ? item.cntDomicilio.Value : 0,
                            codPersonaDomicilio = item.codPersonaDomicilio,
                            codRegTipo = item.codRegTipo,
                            codRegTipoDocumentoEntidad = item.codRegTipoDocumentoEntidad,
                            codRegTipoNombre = item.codRegTipoNombre,
                            codRegTipoStr = item.codRegTipoStr,
                            codUbigeo = item.codUbigeo,
                            nomUbigeo = item.nomUbigeo,
                            gloObservacion = item.gloObservacion,
                            desTelefono = item.desTelefono,
                            tipoDocumento = item.tipoDocumento,
                            indClienteCROM = item.indClienteCROM,
                            indActivo = item.indActivo,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaEdita = item.segMaquinaEdita
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstEmpresaEmision;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestros.Personas
        /// En la BASE de DATO la Tabla : [Maestros.Personas]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEPersona Find(int pcodEmpresa, string prm_codPersona)
        {
            BEPersona persona = null;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Persona_ID(pcodEmpresa, prm_codPersona);
                    foreach (var item in resul)
                    {
                        persona = new BEPersona()
                        {
                            codEmpresa = item.codEmpresa,
                            CodigoPersona = item.codPersona,
                            CodigoArguTipoEntidad = item.codRegTipoEntidad,
                            CodigoArguRubroComercial = item.codRegRubroComercial,

                            CodigoArguTipoEntidadNombre = item.codRegTipoEntidadNombre,
                            CodigoArguRubroComercialNombre = item.codRegRubroComercialNombre,
                            CodigoPersonaEmpresa = item.codPerEmpresa,
                            CodigoPersonaEmpresaNombre = item.codPerEmpresaNombre,
                            RazonSocial = item.RazonSocial,
                            NombreComercial = item.NombreComercial,
                            Observaciones = item.Observaciones,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaHoraEdita = item.SegFechaHoraEdita,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegMaquinaOrigen = item.SegMaquinaOrigen,
                            SegEliminado = item.SegEliminado,
                            Estado = item.Estado,
                            EsClienteCROM = item.EsClienteCROM,
                        };
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return persona;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE FOREIGN KEY*/

        /// <summary>
        /// Retorna una LISTA de registro de la Entidad Maestros.Personas POR FOREIGN KEY
        /// En la BASE de DATO la Tabla : [Maestros.Personas]
        /// <summary>
        /// <returns>Entidad</returns>
        public List<DTOPersonaResponse> ListByEmpresa(int pcodEmpresa, string prm_codPersona)
        {
            List<DTOPersonaResponse> lstPersona = new List<DTOPersonaResponse>();
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Persona_codEmpresa(pcodEmpresa, prm_codPersona);
                    foreach (var item in resul)
                    {
                        lstPersona.Add(new DTOPersonaResponse()
                        {
                            codEmpresa = item.codEmpresa,
                            CodigoPersona = item.codPersona,
                            CodigoArguTipoEntidad = item.codRegTipoEntidad,
                            CodigoArguRubroComercial = item.codRegRubroComercial,
                            CodigoArguTipoEntidadNombre = item.codRegTipoEntidadNombre,
                            CodigoArguRubroComercialNombre = item.codRegRubroComercialNombre,
                            CodigoPersonaEmpresa = item.codPersonaEmpresa,
                            RazonSocial = item.nomRazonSocial,
                            NombreComercial = item.nomComercial,
                            Observaciones = item.gloObservacion,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaEdita = item.segMaquinaEdita,
                            Estado = item.indActivo,

                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstPersona;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Personas
        /// En la BASE de DATO la Tabla : [Maestros.Personas]
        /// <summary>
        /// <param name = >itemPersonas</param>
        public bool Insert(BEPersona itemPersona, out string pMensaje)
        {
            int codigoRetorno = -1;
            pMensaje = string.Empty;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resulSet = SQLDC.omgc_I_Persona(
                        itemPersona.codEmpresa,
                        itemPersona.CodigoPersona,
                        itemPersona.CodigoArguTipoEntidad,
                        itemPersona.CodigoArguRubroComercial,
                        itemPersona.CodigoPersonaEmpresa,
                        itemPersona.RazonSocial,
                        itemPersona.NombreComercial,
                        itemPersona.Observaciones,
                        itemPersona.SegUsuarioCrea,
                        itemPersona.Estado);

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

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Personas
        /// En la BASE de DATO la Tabla : [Maestros.Personas]
        /// <summary>
        /// <param name = >itemPersonas</param>
        public string InsertOutput(BEPersona itemPersona)
        {
            string codigoRetorno = null;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    SQLDC.omgc_I_Persona_Output(
                       ref codigoRetorno,
                       itemPersona.codEmpresa,
                       itemPersona.CodigoArguTipoEntidad,
                       itemPersona.CodigoArguRubroComercial,
                       itemPersona.CodigoPersonaEmpresa,
                       itemPersona.RazonSocial,
                       itemPersona.NombreComercial,
                       itemPersona.Observaciones,
                       itemPersona.SegUsuarioCrea,
                       itemPersona.Estado);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Personas
        /// En la BASE de DATO la Tabla : [Maestros.Personas]
        /// <summary>
        /// <param name = >itemPersonas</param>
        public bool Update(BEPersona pPersona)
        {
            bool result = false;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resulSet = SQLDC.omgc_U_Persona(
                        pPersona.codEmpresa,
                        pPersona.CodigoPersona,
                        pPersona.CodigoArguTipoEntidad,
                        pPersona.CodigoArguRubroComercial,
                        pPersona.CodigoPersonaEmpresa,
                        pPersona.RazonSocial,
                        pPersona.NombreComercial,
                        pPersona.Observaciones,
                        pPersona.SegUsuarioEdita,
                        pPersona.Estado);
                    foreach (var item in resulSet)
                    {
                        pPersona.TOTAL_AFECT = item.codError.Value;
                        result = item.desMessage == WebConstants.DEFAULT_OK ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool UpdateCROM(string prm_CodigoPersona, bool prm_EsCROM, string prm_WordKey, string prm_Usuario, out string pMensaje)
        {
            int codigoRetorno = -1;
            pMensaje = string.Empty;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resulSet = SQLDC.omgc_U_Persona_CROM(
                        prm_CodigoPersona,
                        prm_EsCROM,
                        prm_WordKey,
                        prm_Usuario);

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
        /// ELIMINA un registro de la Entidad Maestros.Personas
        /// En la BASE de DATO la Tabla : [Maestros.Personas]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(int pcodEmpresa, string prm_codPersona, string pUser, out string pMensaje)
        {
            int codigoRetorno = -1;
            pMensaje = string.Empty;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resulSet = SQLDC.omgc_D_Persona(pcodEmpresa, prm_codPersona, pUser);
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

        public bool ValidRazonSocial(string prm_RazonSocial, ref string p_Codi_personaExist, ref string p_Name_personaExist)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    SQLDC.omgc_P_Persona_Valida
                        (
                        prm_RazonSocial,
                        ref p_Codi_personaExist,
                        ref p_Name_personaExist
                        );
                }
                if (p_Codi_personaExist == null)
                    codigoRetorno = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }


        public List<vwDocumRegVendedor> ListVendedoresAtendidosPorEntidad(BaseFiltroDocumRegVendedor pFiltro)
        {
            List<vwDocumRegVendedor> listaDocumRegVendedor = new List<vwDocumRegVendedor>();
            try
            {
                using (_DBMLPersonasDataContext SQLDC = new _DBMLPersonasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumReg_Vendedor(pFiltro.codEmpresa, 
                                                               pFiltro.codPerEntidad, 
                                                               pFiltro.codRegDestinoDocum);
                    foreach (var item in resul)
                    {
                        listaDocumRegVendedor.Add(new vwDocumRegVendedor()
                        {
                            CantidadDocumento = item.CantidadDocumento.HasValue ? item.CantidadDocumento.Value : 0,
                            codEmpleadoVendedor = item.codEmpleadoVendedor.HasValue ? item.codEmpleadoVendedor.Value : 0,
                            desDato0 = item.desDato01,
                            desDato02 = item.desDato02,
                            nomVendedor = item.nomVendedor
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaDocumRegVendedor;
        }

    }
} 

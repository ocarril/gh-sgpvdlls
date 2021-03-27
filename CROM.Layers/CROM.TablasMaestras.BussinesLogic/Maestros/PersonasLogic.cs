namespace CROM.TablasMaestras.BussinesLogic
{
    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.Comercial.DTO;
    using CROM.BusinessEntities.Maestros;
    using CROM.BusinessEntities.Maestros.DTO;
    using CROM.BusinessEntities.Maestros.Entidades;
    using CROM.TablasMaestras.DataAcces;
    using CROM.TablasMaestras.DataAcces.Maestros;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.Web;
    using CROM.Tools.Config;

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Transactions;
    using static CROM.Tools.Comun.Web.WebConstants;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 07/01/2010-04:07:28 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Maestros.PersonasLogic.cs]
    /// </summary>
    public class PersonasLogic: BaseLayer
    {
        private PersonaData oPersonasData = null;
        private PersonasAsignacionesData oPersonasAsignacionesData = null;
        private PersonasAtributosData oPersonasAtributosData = null;
        private PersonasFotoLogoData oPersonasFotoLogoData = null;
        private PersonasDatosAdicionalesData oPersonasDatosAdicionalesData = null;
        private PersonasDomicilioData oPersonasDomicilioData = null;
        private ReturnValor oReturnValor = null;

        public PersonasLogic()
        {
            oPersonasData = new PersonaData();
            oPersonasAsignacionesData = new PersonasAsignacionesData();
            oPersonasAtributosData = new PersonasAtributosData();
            oPersonasFotoLogoData = new PersonasFotoLogoData();
            oPersonasDatosAdicionalesData = new PersonasDatosAdicionalesData();
            oPersonasDomicilioData = new PersonasDomicilioData();
            oReturnValor = new ReturnValor();
        }

        #region TABLA PERSONAS

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Maestros.Personas
        /// En la BASE de DATO la Tabla : [Maestros.Personas]
        /// <summary>
        /// <returns>List</returns>
        public List<DTOPersonaResponse> List(BaseFiltroPersona pFiltro)
        {
            List<DTOPersonaResponse> lstPersona = new List<DTOPersonaResponse>();
            try
            {
                lstPersona = oPersonasData.List(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, 
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstPersona;
        }

        public List<DTOPersonaResponse> List(BaseFiltroPersona pFiltro, Helper.ComboBoxText pTexto)
        {
            List<DTOPersonaResponse> lstPersona = new List<DTOPersonaResponse>();
            try
            {
                lstPersona = oPersonasData.List(pFiltro);
                if (lstPersona.Count > 0)
                    lstPersona.Insert(0, new DTOPersonaResponse { CodigoPersona = "", RazonSocial = Helper.ObtenerTexto(pTexto) });
                else
                    lstPersona.Add(new DTOPersonaResponse { CodigoPersona = "", RazonSocial = Helper.ObtenerTexto(pTexto) });
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, 
                                  pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstPersona;
        }

        public List<DTOPersonaResponse> ListPaged(BaseFiltroPersona pFiltro)
        {
            List<DTOPersonaResponse> lstPersonas = new List<DTOPersonaResponse>();
            try
            {
                lstPersonas = oPersonasData.ListPaged(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, 
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstPersonas;
        }

        public List<DTOEmpresaPersonaResponse> ListEmpresaEmision(int pcodEmpresa, string pnumRUC)
        {
            List<DTOEmpresaPersonaResponse> lstEmpresaEmision = new List<DTOEmpresaPersonaResponse>();
            try
            {

                lstEmpresaEmision = oPersonasData.ListEmpresaEmision(pcodEmpresa,
                                                                     pnumRUC);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
                throw new Exception(returnValor.Message);
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
        public BEPersona Find(int pcodEmpresa, string prm_CodigoPersona, string pUser, string pnumRUC = "")
        {
            BEPersona persona = null;
            try
            {
                persona = oPersonasData.Find(pcodEmpresa, prm_CodigoPersona);
                if (persona != null)
                {
                    persona.itemDatoAdicional = oPersonasDatosAdicionalesData.Find(pcodEmpresa, prm_CodigoPersona);
                    persona.itemPersonasFotoLogo = oPersonasFotoLogoData.Find(pcodEmpresa, prm_CodigoPersona);
                    persona.listaPersonasAsignaciones = oPersonasAsignacionesData.ListBy_Persona(pcodEmpresa, prm_CodigoPersona);
                    persona.listaPersonasAtributos = oPersonasAtributosData.ListBy_Persona(pcodEmpresa, prm_CodigoPersona);
                    persona.listaPersonasDomicilio = oPersonasDomicilioData.List(pcodEmpresa, prm_CodigoPersona, true);

                    if (persona.itemPersonasFotoLogo != null)
                        if (persona.itemPersonasFotoLogo.FotoLogoBinary != null)
                        {
                            UpdatePhotographyPath(persona, pnumRUC);
                        }
                }
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pUser, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return persona;
        }

        public BEPersona Find(int pcodEmpresa, string prm_CodigoPersona, string prm_CodigoArguTipoEntidad, string pUser, string pnumRUC = "")
        {
            BEPersona persona = new BEPersona();
            try
            {
                persona = oPersonasData.Find(pcodEmpresa, prm_CodigoPersona);
                if (persona != null)
                {
                    if (persona.CodigoArguTipoEntidad == prm_CodigoArguTipoEntidad)
                    {
                        persona.itemDatoAdicional = oPersonasDatosAdicionalesData.Find(pcodEmpresa, prm_CodigoPersona);
                        persona.itemPersonasFotoLogo = oPersonasFotoLogoData.Find(pcodEmpresa, prm_CodigoPersona);
                        persona.listaPersonasAsignaciones = oPersonasAsignacionesData.ListBy_Persona(pcodEmpresa, prm_CodigoPersona);
                        persona.listaPersonasAtributos = oPersonasAtributosData.ListBy_Persona(pcodEmpresa, prm_CodigoPersona);
                        persona.listaPersonasDomicilio = oPersonasDomicilioData.List(pcodEmpresa, prm_CodigoPersona, true);

                        if (persona.itemPersonasFotoLogo != null)
                            if (persona.itemPersonasFotoLogo.FotoLogoBinary != null)
                            {
                                UpdatePhotographyPath(persona, pnumRUC);
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                    pUser, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return persona;
        }



        private void UpdatePhotographyPath(BEPersona pPersona, string pnumRUC)
        {
            try
            {
                string nameFile = string.IsNullOrEmpty(pPersona.itemPersonasFotoLogo.FotoLogoNombre) ?
                                    string.Concat(pPersona.codEmpresa.ToString().PadLeft(3, '0'),
                                                 "_",
                                                 pPersona.CodigoPersona,
                                                 ".png") :
                                    pPersona.itemPersonasFotoLogo.FotoLogoNombre;

                string strPathImagenes = Path.Combine(ConfigCROM.AppConfig(pPersona.codEmpresa, ConfigTool.DEFAULT_Path_Empleados),
                                                       TipoEntidad.Personas.ToString(),
                                                       nameFile);

                var resultImage = HelpImages.CrearArchivoDesdeBinario(strPathImagenes, 
                                                                      pPersona.itemPersonasFotoLogo.FotoLogoBinary, 
                                                                      false);

                if (resultImage.Exitosa)
                {
                    if (!string.IsNullOrEmpty(pnumRUC))
                    {
                        bool CREA_IMAGE_LOGO = false;
                        foreach (BEPersonaAtributo itemPersonasAtributos in pPersona.listaPersonasAtributos)
                        {



                            if (itemPersonasAtributos.CodigoArguTipoAtributo == ConfigCROM.AppConfig(pPersona.codEmpresa,
                                                                                                     ConfigTool.DEFAULT_Atributo_NumerDNI))
                            {
                                if (pnumRUC.Trim() == itemPersonasAtributos.DescripcionAtributo.Trim())
                                    CREA_IMAGE_LOGO = true;
                                
                            }

                            else if (itemPersonasAtributos.CodigoArguTipoAtributo == ConfigCROM.AppConfig(pPersona.codEmpresa,
                                                                                                          ConfigTool.DEFAULT_Atributo_NumerRUC))
                            {
                                if (pnumRUC.Trim() == itemPersonasAtributos.DescripcionAtributo.Trim())
                                    CREA_IMAGE_LOGO = true;
                            }
                        }
                        if (CREA_IMAGE_LOGO)
                        {
                            string strPathImagenesLogo = Path.Combine(ConfigCROM.AppConfig(pPersona.codEmpresa, ConfigTool.DEFAULT_Path_Empleados),
                                                                      TipoEntidad.Logos.ToString(),
                                                                      nameFile);

                            var resultImageLogo = HelpImages.CrearArchivoDesdeBinario(strPathImagenesLogo, 
                                                                                      pPersona.itemPersonasFotoLogo.FotoLogoBinary, 
                                                                                      false);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        #region /* Proceso de SELECT BY ID CODE FOREIGN KEY*/

        /// <summary>
        /// Retorna una LISTA de registro de la Entidad Maestros.Personas POR FOREIGN KEY
        /// En la BASE de DATO la Tabla : [Maestros.Personas]
        /// <summary>
        /// <returns>Entidad</returns>
        public List<DTOPersonaResponse> ListByEmpresa(int pcodEmpresa, string prm_codPersona, string pUser)
        {
            List<DTOPersonaResponse> lstPersonas = new List<DTOPersonaResponse>();
            try
            {
                lstPersonas = oPersonasData.ListByEmpresa(pcodEmpresa,  prm_codPersona);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                    pUser, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstPersonas;
        }

        public List<DTOPersonaResponse> ListByEmpresa(int pcodEmpresa, string prm_codPersona, string pUser, Helper.ComboBoxText pTexto)
        {
            List<DTOPersonaResponse> lstPersonas = new List<DTOPersonaResponse>();
            try
            {
                lstPersonas = oPersonasData.ListByEmpresa(pcodEmpresa, prm_codPersona);
                if (lstPersonas.Count > 0)
                    lstPersonas.Insert(0, new DTOPersonaResponse
                    {
                        CodigoPersona = "",
                        RazonSocial = Helper.ObtenerTexto(pTexto)
                    });
                else
                    lstPersonas.Add(new DTOPersonaResponse
                    {
                        CodigoPersona = "",
                        RazonSocial = Helper.ObtenerTexto(pTexto)
                    });
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                    pUser, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstPersonas;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Personas
        /// En la BASE de DATO la Tabla : [Maestros.Personas]
        /// <summary>
        /// <param name = >itemPersonas</param>
        public ReturnValor Insert(BEPersona persona)
        {
            string mensajeValid_Atrib = string.Empty;
            string pMensaje = string.Empty;

            try
            {
                if (oPersonasData.Find(persona.codEmpresa, persona.CodigoPersona) != null)
                {
                    oReturnValor.Message = HelpMessages.VALIDACIONDuplicadoID;
                    return oReturnValor;
                }
                bool ValidaAtributo = ValidaPersonasAtributosRequeridos(persona.codEmpresa,
                                                                        persona.CodigoArguTipoEntidad, 
                                                                        persona.listaPersonasAtributos,
                                                                        ref mensajeValid_Atrib);
                if (ValidaAtributo)
                    using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                    {
                        if (persona.CodigoArguRubroComercial == string.Empty)
                            persona.CodigoArguRubroComercial = null;

                        string p_Codi_personaExist = null;
                        string p_Name_personaExist = null;
                        bool p_ExisteRazonsocial = oPersonasData.ValidRazonSocial(persona.RazonSocial, 
                                                                                  ref p_Codi_personaExist, 
                                                                                  ref p_Name_personaExist);
                        if (p_Name_personaExist != null)
                        {
                            oReturnValor.Message = HelpMessages.MAESTROSRazonSocialValida + " [Código]: " + 
                                                    p_Codi_personaExist + " - [Nombre]:" + 
                                                    p_Name_personaExist;
                            oReturnValor.Exitosa = false;
                            return oReturnValor;
                        }

                        if (persona.CodigoArguTipoEntidad == WebConstants.DEFAULT_PersonaNatural)
                        {
                            string AP1 = string.IsNullOrEmpty(persona.itemDatoAdicional.ApellidoPaterno) == false ? 
                                persona.itemDatoAdicional.ApellidoPaterno.Substring(0, 1) + "." : ".";
                            string AP2 = string.IsNullOrEmpty(persona.itemDatoAdicional.ApellidoMaterno) == false ? 
                                persona.itemDatoAdicional.ApellidoMaterno.Substring(0, 1) + "." : ".";
                            string NO1 = string.IsNullOrEmpty(persona.itemDatoAdicional.Nombre1) == false ? 
                                persona.itemDatoAdicional.Nombre1.Substring(0, 1) + "." : ".";
                            string NO2 = string.IsNullOrEmpty(persona.itemDatoAdicional.Nombre2) == false ? 
                                persona.itemDatoAdicional.Nombre2.Substring(0, 1) + "." : ".";
                            persona.NombreComercial = AP1 + AP2 + NO1 + NO2;
                        }

                        if (persona.CodigoPersonaEmpresa == string.Empty)
                            persona.CodigoPersonaEmpresa = null;

                        if (string.IsNullOrEmpty(persona.CodigoPersona))
                        {
                            persona.CodigoPersona = oPersonasData.InsertOutput(persona);
                            if (!string.IsNullOrEmpty(persona.CodigoPersona))
                            {
                                oReturnValor.Exitosa = true;
                                oReturnValor.CodigoRetorno = persona.CodigoPersona;
                            }
                        }
                        else
                        {
                            oReturnValor.Exitosa = oPersonasData.Insert(persona, out pMensaje);
                        }
                        foreach (BEPersonasAsignacion itemPersonasAsignaciones in persona.listaPersonasAsignaciones)
                        {
                            itemPersonasAsignaciones.codEmpresa = persona.codEmpresa;
                            itemPersonasAsignaciones.SegUsuarioCrea = persona.SegUsuarioCrea;
                            itemPersonasAsignaciones.SegMaquinaOrigen = persona.SegMaquinaOrigen;
                            itemPersonasAsignaciones.CodigoPersona = persona.CodigoPersona;
                            oReturnValor.Exitosa = oPersonasAsignacionesData.Insert(itemPersonasAsignaciones, out pMensaje);
                        }

                        foreach (BEPersonasDomicilio itemPersonasDomicilio in persona.listaPersonasDomicilio)
                        {
                            itemPersonasDomicilio.codEmpresa = persona.codEmpresa;
                            itemPersonasDomicilio.segUsuarioCrea = persona.SegUsuarioCrea;
                            itemPersonasDomicilio.segMaquinaCrea = persona.SegMaquinaOrigen;
                            itemPersonasDomicilio.codPersona = persona.CodigoPersona;
                            oReturnValor.Exitosa = oPersonasDomicilioData.Insert(itemPersonasDomicilio, out pMensaje);
                        }

                        foreach (BEPersonaAtributo itemPersonasAtributos in persona.listaPersonasAtributos)
                        {
                            itemPersonasAtributos.codEmpresa = persona.codEmpresa;
                            itemPersonasAtributos.SegUsuarioCrea = persona.SegUsuarioCrea;
                            itemPersonasAtributos.SegMaquinaOrigen = persona.SegMaquinaOrigen;

                            if (itemPersonasAtributos.DescripcionAtributo != null)
                                if (itemPersonasAtributos.DescripcionAtributo.Length > 0)
                                {
                                    itemPersonasAtributos.SegUsuarioCrea = persona.SegUsuarioCrea;
                                    itemPersonasAtributos.CodigoPersona = persona.CodigoPersona;
                                    bool p_Existe = false;

                                    if (itemPersonasAtributos.CodigoArguTipoAtributo.Substring(0, 8) == 
                                        ConfigCROM.AppConfig(persona.codEmpresa, ConfigTool.DEFAULT_AsistenciaValores))
                                        p_Existe = false;
                                    else if (itemPersonasAtributos.CodigoArguTipoAtributo.Substring(0, 8) == 
                                             ConfigCROM.AppConfig(persona.codEmpresa, ConfigTool.DEFAULT_AsistenciaLogicos))
                                        p_Existe = false;
                                    else if (itemPersonasAtributos.CodigoArguTipoAtributo.Substring(0, 8) == 
                                             ConfigCROM.AppConfig(persona.codEmpresa, ConfigTool.DEFAULT_Atributo_Telefono))
                                        p_Existe = false;
                                    else
                                        p_Existe = oPersonasAtributosData.ValidarAtributo(itemPersonasAtributos, 
                                                                                          ref p_Codi_personaExist, 
                                                                                          ref p_Name_personaExist);

                                    if (!p_Existe)
                                    {
                                        oReturnValor.Message = string.Empty;
                                        oReturnValor.Exitosa = oPersonasAtributosData.Insert(itemPersonasAtributos, 
                                                                                             out pMensaje);
                                    }
                                    else
                                    {
                                        oReturnValor.Message = HelpMessages.MAESTROSAtributoValida;
                                        oReturnValor.Exitosa = false;
                                        return oReturnValor;
                                    }
                                }
                        }

                        if (persona.CodigoArguTipoEntidad == WebConstants.DEFAULT_PersonaNatural)
                        {
                            persona.itemDatoAdicional.SegUsuarioCrea = persona.SegUsuarioCrea;
                            persona.itemDatoAdicional.SegUsuarioCrea = persona.SegUsuarioCrea;
                            persona.itemDatoAdicional.CodigoPersona = persona.CodigoPersona;
                            oReturnValor.Exitosa = oPersonasDatosAdicionalesData.InsertUpdate(persona.itemDatoAdicional,
                                                                                              out pMensaje);
                        }
                        persona.itemPersonasFotoLogo.CodigoPersona = persona.CodigoPersona;
                        persona.itemPersonasFotoLogo.Estado = true;
                        persona.itemPersonasFotoLogo.SegUsuarioEdita = persona.SegUsuarioEdita;
                        persona.itemPersonasFotoLogo.SegUsuarioCrea = persona.SegUsuarioCrea;
                        if (persona.itemPersonasFotoLogo.FotoLogoBinary != null)
                            oReturnValor.Exitosa = oPersonasFotoLogoData.Insert(persona.itemPersonasFotoLogo,
                                                                                              out pMensaje);

                        if (oReturnValor.Exitosa)
                        {
                            oReturnValor.Message = HelpMessages.Evento_NEW;
                            tx.Complete();
                        }
                    }
                else
                    oReturnValor.Message = mensajeValid_Atrib;
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                    persona.SegUsuarioCrea, persona.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        public ReturnValor InsertWEB(BEPersona persona)
        {
            string mensajeValid_Atrib = string.Empty;
            string pMensaje = string.Empty;
            try
            {
                if (oPersonasData.Find(persona.codEmpresa, persona.CodigoPersona) != null)
                {
                    oReturnValor.Message = HelpMessages.VALIDACIONDuplicadoID;
                    return oReturnValor;
                }

                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (persona.CodigoArguRubroComercial == string.Empty)
                        persona.CodigoArguRubroComercial = null;
                    string p_Codi_personaExist = null;
                    string p_Name_personaExist = null;
                    bool p_ExisteRazonsocial = oPersonasData.ValidRazonSocial(persona.RazonSocial, 
                                                                              ref p_Codi_personaExist, 
                                                                              ref p_Name_personaExist);
                    if (p_Name_personaExist != null)
                    {
                        oReturnValor.Message = HelpMessages.MAESTROSRazonSocialValida + " [Código]: " + 
                                               p_Codi_personaExist + " - [Nombre]:" + 
                                               p_Name_personaExist;

                        oReturnValor.Exitosa = false;
                        return oReturnValor;
                    }

                    if (persona.CodigoArguTipoEntidad == WebConstants.DEFAULT_PersonaNatural)
                    {
                        string AP1 = string.IsNullOrEmpty(persona.itemDatoAdicional.ApellidoPaterno) == false ?
                            persona.itemDatoAdicional.ApellidoPaterno.Substring(0, 1) + ". " : " ";
                        string AP2 = string.IsNullOrEmpty(persona.itemDatoAdicional.ApellidoMaterno) == false ?
                            persona.itemDatoAdicional.ApellidoMaterno.Substring(0, 1) + ". " : " ";
                        string NO1 = string.IsNullOrEmpty(persona.itemDatoAdicional.Nombre1) == false ?
                            persona.itemDatoAdicional.Nombre1.Substring(0, 1) + ". " : " ";
                        string NO2 = string.IsNullOrEmpty(persona.itemDatoAdicional.Nombre2) == false ?
                            persona.itemDatoAdicional.Nombre2.Substring(0, 1) + ". " : " ";
                        persona.NombreComercial = AP1 + AP2 + NO1 + NO2;
                        persona.RazonSocial = string.Concat(!string.IsNullOrEmpty(persona.itemDatoAdicional.ApellidoPaterno) ? persona.itemDatoAdicional.ApellidoPaterno : string.Empty, " ",
                                                            !string.IsNullOrEmpty(persona.itemDatoAdicional.ApellidoMaterno) ? persona.itemDatoAdicional.ApellidoMaterno : string.Empty, " ",
                                                            !string.IsNullOrEmpty(persona.itemDatoAdicional.Nombre1) ? persona.itemDatoAdicional.Nombre1 : string.Empty, " ",
                                                            !string.IsNullOrEmpty(persona.itemDatoAdicional.Nombre2) ? persona.itemDatoAdicional.Nombre2 : string.Empty, " ");
                    }

                    if (persona.CodigoPersonaEmpresa == string.Empty)
                        persona.CodigoPersonaEmpresa = null;

                    if (string.IsNullOrEmpty(persona.CodigoPersona))
                    {
                        persona.CodigoPersona = oPersonasData.InsertOutput(persona);
                        if (!string.IsNullOrEmpty(persona.CodigoPersona))
                        {
                            oReturnValor.Exitosa = true;
                            oReturnValor.CodigoRetorno = persona.CodigoPersona;
                        }
                    }
                    else
                        oReturnValor.Exitosa = oPersonasData.Insert(persona, out pMensaje);

                    foreach (BEPersonasAsignacion itemPersonasAsignaciones in persona.listaPersonasAsignaciones)
                    {
                        itemPersonasAsignaciones.codEmpresa = persona.codEmpresa;
                        itemPersonasAsignaciones.SegMaquinaOrigen = persona.SegMaquinaOrigen;
                        itemPersonasAsignaciones.SegUsuarioCrea = persona.SegUsuarioCrea;
                        itemPersonasAsignaciones.CodigoPersona = persona.CodigoPersona;
                        oReturnValor.Exitosa = oPersonasAsignacionesData.Insert(itemPersonasAsignaciones, out pMensaje);
                    }

                    foreach (BEPersonasDomicilio itemPersonasDomicilio in persona.listaPersonasDomicilio)
                    {
                        itemPersonasDomicilio.codEmpresa = persona.codEmpresa;
                        itemPersonasDomicilio.segUsuarioCrea = persona.SegUsuarioCrea;
                        itemPersonasDomicilio.segMaquinaCrea = persona.SegMaquinaOrigen;
                        itemPersonasDomicilio.codPersona = persona.CodigoPersona;
                        oReturnValor.Exitosa = oPersonasDomicilioData.Insert(itemPersonasDomicilio, out pMensaje);
                    }

                    foreach (BEPersonaAtributo itemPersonasAtributos in persona.listaPersonasAtributos)
                    {
                        itemPersonasAtributos.codEmpresa = persona.codEmpresa;
                        if (!string.IsNullOrEmpty(itemPersonasAtributos.DescripcionAtributo))

                        {
                            itemPersonasAtributos.SegUsuarioCrea = persona.SegUsuarioCrea;
                            itemPersonasAtributos.CodigoPersona = persona.CodigoPersona;
                            bool p_Existe = false;

                            if (itemPersonasAtributos.CodigoArguTipoAtributo.Substring(0, 8) == 
                                ConfigCROM.AppConfig(persona.codEmpresa, ConfigTool.DEFAULT_AsistenciaValores))
                                p_Existe = false;
                            else if (itemPersonasAtributos.CodigoArguTipoAtributo.Substring(0, 8) == 
                                ConfigCROM.AppConfig(persona.codEmpresa, ConfigTool.DEFAULT_AsistenciaLogicos))
                                p_Existe = false;
                            else if (itemPersonasAtributos.CodigoArguTipoAtributo.Substring(0, 8) == 
                                ConfigCROM.AppConfig(persona.codEmpresa, ConfigTool.DEFAULT_Atributo_Telefono))
                                p_Existe = false;
                            else
                                p_Existe = oPersonasAtributosData.ValidarAtributo(itemPersonasAtributos, ref p_Codi_personaExist, ref p_Name_personaExist);

                            if (!p_Existe)
                            {
                                oReturnValor.Message = string.Empty;
                                oReturnValor.Exitosa = oPersonasAtributosData.Insert(itemPersonasAtributos, out pMensaje);
                            }
                            else
                            {
                                oReturnValor.Message = HelpMessages.MAESTROSAtributoValida;
                                oReturnValor.Exitosa = false;
                                return oReturnValor;
                            }
                        }
                    }
                    if (persona.CodigoArguTipoEntidad == WebConstants.DEFAULT_PersonaNatural)
                    {
                        persona.itemDatoAdicional.SegUsuarioCrea = persona.SegUsuarioCrea;
                        persona.itemDatoAdicional.SegUsuarioCrea = persona.SegUsuarioCrea;
                        persona.itemDatoAdicional.CodigoPersona = persona.CodigoPersona;

                        string pMensajeDataAdic = string.Empty;
                        oReturnValor.Exitosa = oPersonasDatosAdicionalesData.InsertUpdate(persona.itemDatoAdicional, out pMensajeDataAdic);
                        if (!oReturnValor.Exitosa)
                        {
                            oReturnValor.Message = pMensajeDataAdic;
                            return oReturnValor;
                        }
                    }
                    persona.itemPersonasFotoLogo.CodigoPersona = persona.CodigoPersona;
                    persona.itemPersonasFotoLogo.Estado = true;
                    persona.itemPersonasFotoLogo.SegUsuarioEdita = persona.SegUsuarioEdita;
                    persona.itemPersonasFotoLogo.SegUsuarioCrea = persona.SegUsuarioCrea;
                    persona.itemPersonasFotoLogo.codEmpresa = persona.codEmpresa;
                    if (persona.itemPersonasFotoLogo.FotoLogoBinary != null)
                    {
                        string pMensajeFoto = string.Empty;
                        oReturnValor.Exitosa = oPersonasFotoLogoData.Insert(persona.itemPersonasFotoLogo, out pMensajeFoto);
                        if (!oReturnValor.Exitosa)
                        {
                            oReturnValor.Message = pMensajeFoto;
                            return oReturnValor;
                        }
                    }

                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_NEW;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Personas
        /// En la BASE de DATO la Tabla : [Maestros.Personas]
        /// <summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public ReturnValor Update(BEPersona persona)
        {
            string mensajeValid_Atrib = string.Empty;
            try
            {
                bool ValidaAtributo = ValidaPersonasAtributosRequeridos(persona.codEmpresa,
                                                                        persona.CodigoArguTipoEntidad, 
                                                                        persona.listaPersonasAtributos,
                                                                        ref mensajeValid_Atrib);
                if (ValidaAtributo)
                    using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                    {
                        string p_Codi_personaExist = null;
                        string p_Name_personaExist = null;

                        if (persona.CodigoArguRubroComercial == string.Empty)
                            persona.CodigoArguRubroComercial = null;

                        bool p_ExisteRazonsocial = oPersonasData.ValidRazonSocial(persona.RazonSocial, 
                                                                                  ref p_Codi_personaExist, 
                                                                                  ref p_Name_personaExist);
                        if (p_Codi_personaExist != null)
                            if (persona.CodigoPersona != p_Codi_personaExist)
                            {
                                oReturnValor.Message = HelpMessages.MAESTROSRazonSocialValida + " [Código]: " + p_Codi_personaExist + " - [Nombre]:" + p_Name_personaExist;
                                oReturnValor.Exitosa = false;
                                return oReturnValor;
                            }

                        if (persona.CodigoPersonaEmpresa == string.Empty)
                            persona.CodigoPersonaEmpresa = null;

                        if (persona.CodigoArguTipoEntidad == WebConstants.DEFAULT_PersonaNatural)
                        {
                            string AP1 = string.IsNullOrEmpty(persona.itemDatoAdicional.ApellidoPaterno) == false ? 
                                         persona.itemDatoAdicional.ApellidoPaterno.Substring(0, 1) + "." : ".";
                            string AP2 = string.IsNullOrEmpty(persona.itemDatoAdicional.ApellidoMaterno) == false ? 
                                         persona.itemDatoAdicional.ApellidoMaterno.Substring(0, 1) + "." : ".";
                            string NO1 = string.IsNullOrEmpty(persona.itemDatoAdicional.Nombre1) == false ? 
                                         persona.itemDatoAdicional.Nombre1.Substring(0, 1) + "." : ".";
                            string NO2 = string.IsNullOrEmpty(persona.itemDatoAdicional.Nombre2) == false ? 
                                         persona.itemDatoAdicional.Nombre2.Substring(0, 1) + "." : ".";
                            persona.NombreComercial = AP1 + AP2 + NO1 + NO2;
                        }

                        oReturnValor.Exitosa = oPersonasData.Update(persona);

                        string pMensajePerAtributo = string.Empty;
                        bool sucedeDelete = oPersonasAtributosData.Delete(persona.codEmpresa, 
                                                                          persona.CodigoPersona, 
                                                                          string.Empty, 
                                                                          persona.SegUsuarioEdita, 
                                                                          out pMensajePerAtributo);

                        foreach (BEPersonaAtributo itemPersonasAtributos in persona.listaPersonasAtributos)
                        {
                            itemPersonasAtributos.codEmpresa = persona.codEmpresa;
                            if (itemPersonasAtributos.DescripcionAtributo != null)
                                if (itemPersonasAtributos.DescripcionAtributo.Length > 0)
                                {
                                    itemPersonasAtributos.CodigoPersona = persona.CodigoPersona;
                                    itemPersonasAtributos.SegUsuarioEdita = persona.SegUsuarioEdita;
                                    bool p_Existe = false;

                                    if (itemPersonasAtributos.CodigoArguTipoAtributo.Substring(0, 8) == 
                                        ConfigCROM.AppConfig(persona.codEmpresa, ConfigTool.DEFAULT_AsistenciaValores))
                                        p_Existe = false;
                                    else if (itemPersonasAtributos.CodigoArguTipoAtributo.Substring(0, 8) == 
                                        ConfigCROM.AppConfig(persona.codEmpresa, ConfigTool.DEFAULT_AsistenciaLogicos))
                                        p_Existe = false;
                                    else if (itemPersonasAtributos.CodigoArguTipoAtributo.Substring(0, 8) == 
                                        ConfigCROM.AppConfig(persona.codEmpresa, ConfigTool.DEFAULT_Atributo_Telefono))
                                        p_Existe = false;
                                    else
                                        p_Existe = oPersonasAtributosData.ValidarAtributo(itemPersonasAtributos, 
                                                                                          ref p_Codi_personaExist, 
                                                                                          ref p_Name_personaExist);

                                    if (!p_Existe)
                                    {
                                        oReturnValor.Message = string.Empty;
                                        oReturnValor.Exitosa = oPersonasAtributosData.Insert(itemPersonasAtributos, 
                                                                                             out pMensajePerAtributo);
                                    }
                                    else
                                    {
                                        oReturnValor.Message = HelpMessages.MAESTROSAtributoValida;
                                        oReturnValor.Exitosa = false;
                                        return oReturnValor;
                                    }
                                }
                        }

                        oPersonasAsignacionesData.Delete(persona.codEmpresa, 
                                                         persona.CodigoPersona, string.Empty, 
                                                         persona.SegUsuarioEdita, out pMensajePerAtributo);

                        foreach (BEPersonasAsignacion itemPersonasAsignaciones in persona.listaPersonasAsignaciones)
                        {
                            itemPersonasAsignaciones.codEmpresa = persona.codEmpresa;
                            itemPersonasAsignaciones.SegMaquinaOrigen = persona.SegMaquinaOrigen;
                            itemPersonasAsignaciones.CodigoPersona = persona.CodigoPersona;
                            itemPersonasAsignaciones.SegUsuarioEdita = persona.SegUsuarioEdita;

                            oReturnValor.Exitosa = oPersonasAsignacionesData.Insert(itemPersonasAsignaciones, 
                                                                                    out pMensajePerAtributo);
                        }
                        if (persona.CodigoArguTipoEntidad == WebConstants.DEFAULT_PersonaNatural)
                        {
                            persona.itemDatoAdicional.SegUsuarioCrea = persona.SegUsuarioEdita;
                            persona.itemDatoAdicional.SegUsuarioEdita = persona.SegUsuarioEdita;
                            persona.itemDatoAdicional.CodigoPersona = persona.CodigoPersona;
                            if (persona.itemDatoAdicional.CodigoArguAreaEmpleado == string.Empty)
                                persona.itemDatoAdicional.CodigoArguAreaEmpleado = null;

                            oReturnValor.Exitosa = oPersonasDatosAdicionalesData.InsertUpdate(persona.itemDatoAdicional, 
                                                                                              out pMensajePerAtributo);
                        }

                        persona.itemPersonasFotoLogo.codEmpresa = persona.codEmpresa;
                        persona.itemPersonasFotoLogo.CodigoPersona = persona.CodigoPersona;
                        persona.itemPersonasFotoLogo.Estado = true;
                        persona.itemPersonasFotoLogo.SegUsuarioEdita = persona.SegUsuarioEdita;
                        persona.itemPersonasFotoLogo.SegUsuarioCrea = persona.SegUsuarioCrea;

                        if (persona.itemPersonasFotoLogo.FotoLogoBinary != null)
                            oReturnValor.Exitosa = oPersonasFotoLogoData.Insert(persona.itemPersonasFotoLogo, out pMensajePerAtributo);
                        if (oReturnValor.Exitosa)
                        {
                            oReturnValor.Message = HelpMessages.Evento_EDIT;
                            tx.Complete();
                        }
                    }
                else
                    oReturnValor.Message = mensajeValid_Atrib;
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name), persona.SegUsuarioEdita, persona.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        public ReturnValor UpdateWEB(BEPersona persona)
        {
            string mensajeValid_Atrib = string.Empty;
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    string p_Codi_personaExist = null;
                    string p_Name_personaExist = null;
                    if (persona.CodigoArguRubroComercial == string.Empty)
                        persona.CodigoArguRubroComercial = null;
                    bool p_ExisteRazonsocial = oPersonasData.ValidRazonSocial(persona.RazonSocial, 
                                                                              ref p_Codi_personaExist, 
                                                                              ref p_Name_personaExist);
                    if (p_Codi_personaExist != null)
                        if (persona.CodigoPersona != p_Codi_personaExist)
                        {
                            oReturnValor.Message = HelpMessages.MAESTROSRazonSocialValida + " [Código]: " + 
                                                   p_Codi_personaExist + " - [Nombre]:" + p_Name_personaExist;
                            oReturnValor.Exitosa = false;
                            return oReturnValor;
                        }

                    if (persona.CodigoPersonaEmpresa == string.Empty)
                        persona.CodigoPersonaEmpresa = null;

                    if (persona.CodigoArguTipoEntidad == WebConstants.DEFAULT_PersonaNatural)
                    {
                        string AP1 = string.IsNullOrEmpty(persona.itemDatoAdicional.ApellidoPaterno) == false ? 
                                        persona.itemDatoAdicional.ApellidoPaterno.Substring(0, 1) + ". " : " ";
                        string AP2 = string.IsNullOrEmpty(persona.itemDatoAdicional.ApellidoMaterno) == false ? 
                                        persona.itemDatoAdicional.ApellidoMaterno.Substring(0, 1) + ". " : " ";
                        string NO1 = string.IsNullOrEmpty(persona.itemDatoAdicional.Nombre1) == false ? 
                                        persona.itemDatoAdicional.Nombre1.Substring(0, 1) + ". " : " ";
                        string NO2 = string.IsNullOrEmpty(persona.itemDatoAdicional.Nombre2) == false ? 
                                        persona.itemDatoAdicional.Nombre2.Substring(0, 1) + ". " : " ";

                        persona.NombreComercial = AP1 + AP2 + NO1 + NO2;
                        persona.RazonSocial = string.Concat(!string.IsNullOrEmpty(persona.itemDatoAdicional.ApellidoPaterno) ? persona.itemDatoAdicional.ApellidoPaterno : string.Empty, " ",
                                                            !string.IsNullOrEmpty(persona.itemDatoAdicional.ApellidoMaterno) ? persona.itemDatoAdicional.ApellidoMaterno : string.Empty, " ",
                                                            !string.IsNullOrEmpty(persona.itemDatoAdicional.Nombre1) ? persona.itemDatoAdicional.Nombre1 : string.Empty, " ",
                                                            !string.IsNullOrEmpty(persona.itemDatoAdicional.Nombre2) ? persona.itemDatoAdicional.Nombre2 : string.Empty, " ");

                    }

                    oReturnValor.Exitosa = oPersonasData.Update(persona);

                    string pMensajePerAtributo = string.Empty;
                    oPersonasAsignacionesData.Delete(persona.codEmpresa, 
                                                     persona.CodigoPersona,
                                                     string.Empty, 
                                                     persona.SegUsuarioEdita, 
                                                     out pMensajePerAtributo);

                    foreach (BEPersonasAsignacion itemPersonasAsignaciones in persona.listaPersonasAsignaciones)
                    {
                        itemPersonasAsignaciones.codEmpresa = persona.codEmpresa;
                        itemPersonasAsignaciones.SegMaquinaOrigen = persona.SegMaquinaOrigen;
                        itemPersonasAsignaciones.CodigoPersona = persona.CodigoPersona;
                        itemPersonasAsignaciones.SegUsuarioEdita = persona.SegUsuarioEdita;
                        oReturnValor.Exitosa = oPersonasAsignacionesData.Insert(itemPersonasAsignaciones, out pMensajePerAtributo);
                    }
                    if (persona.CodigoArguTipoEntidad == WebConstants.DEFAULT_PersonaNatural)
                    {
                        persona.itemDatoAdicional.SegUsuarioCrea = persona.SegUsuarioEdita;
                        persona.itemDatoAdicional.SegUsuarioEdita = persona.SegUsuarioEdita;
                        persona.itemDatoAdicional.CodigoPersona = persona.CodigoPersona;
                        if (persona.itemDatoAdicional.CodigoArguAreaEmpleado == string.Empty)
                            persona.itemDatoAdicional.CodigoArguAreaEmpleado = null;

                        string pMensajeDataAdic = string.Empty;
                        oReturnValor.Exitosa = oPersonasDatosAdicionalesData.InsertUpdate(persona.itemDatoAdicional, 
                                                                                          out pMensajeDataAdic);
                    }
                    persona.itemPersonasFotoLogo.CodigoPersona = persona.CodigoPersona;
                    persona.itemPersonasFotoLogo.Estado = true;
                    persona.itemPersonasFotoLogo.SegUsuarioEdita = persona.SegUsuarioEdita;
                    persona.itemPersonasFotoLogo.SegUsuarioCrea = persona.SegUsuarioCrea;
                    persona.itemPersonasFotoLogo.codEmpresa = persona.codEmpresa;

                    string pMensajeFoto = string.Empty;
                    if (persona.itemPersonasFotoLogo.FotoLogoBinary != null)
                        oReturnValor.Exitosa = oPersonasFotoLogoData.Insert(persona.itemPersonasFotoLogo, out pMensajeFoto);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_EDIT;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        public ReturnValor UpdatePersonaCROM(int pcodEmpresa, string prm_CodigoPersona, bool prm_EsCROM, 
                                             string prm_WordKey, string prm_Usuario)
        {
            try
            {
                BEPersona persona = new BEPersona();
                persona = oPersonasData.Find(pcodEmpresa,prm_CodigoPersona);
                string pMensaje = string.Empty;
                if (persona.CodigoPersona != null)
                {
                    using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                    {
                        oReturnValor.Exitosa = oPersonasData.UpdateCROM(prm_CodigoPersona, 
                                                                        prm_EsCROM, 
                                                                        prm_WordKey, 
                                                                        prm_Usuario,
                                                                        out pMensaje);
                        if (oReturnValor.Exitosa)
                        {
                            oReturnValor.Message = HelpMessages.Evento_EDIT;
                            tx.Complete();
                        }
                    }
                }
                else
                    oReturnValor.Message = HelpMessages.VALIDACIONGeneral;
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Maestros.Personas
        /// En la BASE de DATO la Tabla : [Maestros.Personas]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(int pcodEmpresa, string strCodPersona, string pUser, string pMaquina)
        {
            string pMensaje = string.Empty;
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    bool blnFotoLogo = oPersonasFotoLogoData.Delete(pcodEmpresa,strCodPersona, pUser, out pMensaje );
                    bool blnAtributo = oPersonasAtributosData.Delete(pcodEmpresa, strCodPersona, string.Empty, pUser, out pMensaje);
                    bool blnAsignaciones = oPersonasAsignacionesData.Delete(pcodEmpresa, strCodPersona, string.Empty, pUser, out pMensaje);
                    bool blnDatoAdicional = oPersonasDatosAdicionalesData.Delete(pcodEmpresa, strCodPersona, pUser, out pMensaje);
                    bool blnDatoDomicilio = oPersonasDomicilioData.Delete(pcodEmpresa, strCodPersona, 0, pUser, pMaquina, out pMensaje);

                    oReturnValor.Exitosa = oPersonasData.Delete(pcodEmpresa, strCodPersona, pUser, out pMensaje);

                    if (oReturnValor.Exitosa && blnFotoLogo && blnAtributo && blnAsignaciones && blnDatoAdicional)
                    {
                        tx.Complete();
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                string.Concat(GetType().Name,".", MethodBase.GetCurrentMethod().Name),pUser, pcodEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #endregion

        #region TABLA PERSONAS_ASIGNACIONES

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestros.PersonasAsignaciones
        /// En la BASE de DATO la Tabla : [Maestros.PersonasAsignaciones]
        /// <summary>
        /// <param name="prm_CodigoPersona"></param>
        /// <param name="prm_CodigoArguAsignacion"></param>
        /// <returns></returns>
        public BEPersonasAsignacion FindAsignaciones(int pcodEmpresa, string prm_CodigoPersona, string prm_CodigoArguAsignacion)
        {
            BEPersonasAsignacion personaAsignacion = new BEPersonasAsignacion();
            try
            {
                personaAsignacion = oPersonasAsignacionesData.Find(pcodEmpresa, prm_CodigoPersona, prm_CodigoArguAsignacion);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, 
                                 this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,string.Empty, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return personaAsignacion;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE FOREIGN KEY*/

        /// <summary>
        /// Retorna una LISTA de registro de la Entidad Maestros.PersonasAsignaciones POR FOREIGN KEY
        /// En la BASE de DATO la Tabla : [Maestros.PersonasAsignaciones]
        /// <summary>
        /// <returns>Entidad</returns>
        public List<BEPersonasAsignacion> ListBy_PersonaAsignacion(int pcodEmpresa, string prm_CodigoPersona, string pUser)
        {
            List<BEPersonasAsignacion> lstPersonaAsignacion = new List<BEPersonasAsignacion>();
            try
            {
                lstPersonaAsignacion = oPersonasAsignacionesData.ListBy_Persona(pcodEmpresa, prm_CodigoPersona);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                  pUser, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstPersonaAsignacion;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        ///// <summary>
        ///// Almacena el registro de una ENTIDAD de registro de Tipo PersonasAsignaciones
        ///// En la BASE de DATO la Tabla : [Maestros.PersonasAsignaciones]
        ///// <summary>
        ///// <param name="personaAsignacion"></param>
        ///// <returns></returns>
        //public ReturnValor InsertPersonasAsignaciones(BEPersonasAsignacion personaAsignacion)
        //{
        //    string pMensaje = string.Empty;
        //    try
        //    {
        //        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
        //        {
        //            oReturnValor.Exitosa = oPersonasAsignacionesData.Insert(personaAsignacion, out pMensaje);
        //            if (oReturnValor.Exitosa)
        //            {
        //                oReturnValor.Message = HelpMessages.Evento_NEW;
        //                tx.Complete();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oReturnValor = HelpException.mTraerMensaje(ex);
        //    }
        //    return oReturnValor;
        //}

        #endregion

        #region /* Proceso de UPDATE RECORD */

        ///// <summary>
        ///// Almacena el registro de una ENTIDAD de registro de Tipo PersonasAsignaciones
        ///// En la BASE de DATO la Tabla : [Maestros.PersonasAsignaciones]
        ///// <summary>
        ///// <param name="itemPersonasAsignaciones"></param>
        ///// <returns></returns>
        //public ReturnValor UpdatePersonasAsignaciones(BEPersonasAsignacion personaAsignacion)
        //{
        //    try
        //    {
        //        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
        //        {
        //            oReturnValor.Exitosa = oPersonasAsignacionesData.Update(personaAsignacion);
        //            if (oReturnValor.Exitosa)
        //            {
        //                oReturnValor.Message = HelpMessages.Evento_EDIT;
        //                tx.Complete();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oReturnValor = HelpException.mTraerMensaje(ex);
        //    }
        //    return oReturnValor;
        //}

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Maestros.PersonasAsignaciones
        /// En la BASE de DATO la Tabla : [Maestros.PersonasAsignaciones]
        /// <summary>
        /// <param name="prm_CodigoPersona"></param>
        /// <param name="prm_CodigoArguAsignacion"></param>
        /// <returns></returns>
        public ReturnValor DeletePersonasAsignaciones(int pcodEmpresa, string prm_CodigoPersona, string prm_CodigoArguAsignacion,
                                                      string pUsuarioEdita)
        {
            string pMensaje = string.Empty;
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oPersonasAsignacionesData.Delete(pcodEmpresa,
                                                                            prm_CodigoPersona, 
                                                                            prm_CodigoArguAsignacion,
                                                                            pUsuarioEdita, 
                                                                            out pMensaje);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
                        tx.Complete();
                    }
                    else
                        oReturnValor.Message = pMensaje;
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                               this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pUsuarioEdita, pcodEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #endregion

        #region TABLA PERSONAS_ATRIBUTOS

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestros.PersonasAtributos
        /// En la BASE de DATO la Tabla : [Maestros.PersonasAtributos]
        /// <summary>
        /// <param name="prm_CodigoPersona"></param>
        /// <param name="prm_CodigoArguTipoAtributo"></param>
        /// <returns></returns>
        public BEPersonaAtributo FindPersonasAtributos(int pcodEmpresa, string prm_CodigoPersona, string prm_CodigoArguTipoAtributo,
                                                       string pUser)
        {
            BEPersonaAtributo personaAtributo = null;
            try
            {
                personaAtributo = oPersonasAtributosData.Find(pcodEmpresa ,prm_CodigoPersona, prm_CodigoArguTipoAtributo);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, 
                    this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pUser, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return personaAtributo;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE FOREIGN KEY*/

        /// <summary>
        /// Retorna una LISTA de registro de la Entidad Maestros.PersonasAtributos POR FOREIGN KEY
        /// En la BASE de DATO la Tabla : [Maestros.PersonasAtributos]
        /// <summary>
        /// <param name="prm_CodigoPersona"></param>
        /// <returns></returns>
        public List<BEPersonaAtributo> ListBy_PersonasAtributos(int pcodEmpresa, string prm_CodigoPersona)
        {
            List<BEPersonaAtributo> lstPersonaAtributo = new List<BEPersonaAtributo>();
            try
            {
                lstPersonaAtributo = oPersonasAtributosData.ListBy_Persona(pcodEmpresa, prm_CodigoPersona);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
                throw new Exception(returnValor.Message);
            }
            return lstPersonaAtributo;
        }

        public List<BEPersonaAtributo> ListBy_PersonasAtributos_Paged(BaseFiltroMaestro pFiltro)
        {
            List<BEPersonaAtributo> lstPersonaAtributo = new List<BEPersonaAtributo>();
            try
            {
                lstPersonaAtributo = oPersonasAtributosData.ListBy_Persona_Paged(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pFiltro.segUsuario, pFiltro.codPerEmpresa);
                throw new Exception(returnValor.Message);
            }
            return lstPersonaAtributo;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PersonasAtributos
        /// En la BASE de DATO la Tabla : [Maestros.PersonasAtributos]
        /// <summary>
        /// <param name="personaAtributo"></param>
        /// <returns></returns>
        public ReturnValor InsertPersonasAtributos(BEPersonaAtributo personaAtributo)
        {
            string pMensaje = string.Empty;
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    string p_Codi_personaExist = null;
                    string p_Name_personaExist = null;
                    bool p_Existe = false;
                    //if (personaAtributo.CodigoArguTipoAtributo.Substring(0, 8) == 
                    //    ConfigCROM.AppConfig(ConfigTool.DEFAULT_Atributo_Domicilio))
                    //    p_Existe = false;
                    //else 
                    if (personaAtributo.CodigoArguTipoAtributo.Substring(0, 8) == 
                        ConfigCROM.AppConfig(personaAtributo.codEmpresa, ConfigTool.DEFAULT_AsistenciaValores))
                        p_Existe = false;
                    else if (personaAtributo.CodigoArguTipoAtributo.Substring(0, 8) == 
                        ConfigCROM.AppConfig(personaAtributo.codEmpresa, ConfigTool.DEFAULT_AsistenciaLogicos))
                        p_Existe = false;
                    else if (personaAtributo.CodigoArguTipoAtributo.Substring(0, 8) == 
                        ConfigCROM.AppConfig(personaAtributo.codEmpresa, ConfigTool.DEFAULT_Atributo_Telefono))
                        p_Existe = false;
                    else
                        p_Existe = oPersonasAtributosData.ValidarAtributo(personaAtributo, ref p_Codi_personaExist, ref p_Name_personaExist);
                    if (!p_Existe)
                    {
                        oReturnValor.Exitosa = oPersonasAtributosData.Insert(personaAtributo, out pMensaje);
                        if (oReturnValor.Exitosa)
                        {
                            oReturnValor.Message = HelpMessages.Evento_NEW;
                            tx.Complete();
                        }
                    }
                    else
                        oReturnValor.Message = "¡ El Atributo  " + personaAtributo.CodigoArguTipoAtributoNombre + 
                                               "  ya Existe ! [Código]: " + p_Codi_personaExist + 
                                               " - [Nombre]:" + p_Name_personaExist;

                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, 
                                personaAtributo.SegUsuarioCrea, personaAtributo.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Actualiza la tabla Maestros.PersonasAtributos
        /// </summary>
        /// <param name="personaAtributo"></param>
        /// <returns></returns>
        public ReturnValor UpdatePersonasAtributos(BEPersonaAtributo personaAtributo)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    string p_Codi_personaExist = null;
                    string p_Name_personaExist = null;
                    bool p_Existe = false;

                    //if (personaAtributo.CodigoArguTipoAtributo.Substring(0, 8) == 
                    //    ConfigCROM.AppConfig(ConfigTool.DEFAULT_Atributo_Domicilio))
                    //    p_Existe = false;
                    //else 
                    if (personaAtributo.CodigoArguTipoAtributo.Substring(0, 8) == 
                        ConfigCROM.AppConfig(personaAtributo.codEmpresa, ConfigTool.DEFAULT_AsistenciaValores))
                        p_Existe = false;
                    else if (personaAtributo.CodigoArguTipoAtributo.Substring(0, 8) == 
                        ConfigCROM.AppConfig(personaAtributo.codEmpresa, ConfigTool.DEFAULT_AsistenciaLogicos))
                        p_Existe = false;
                    else if (personaAtributo.CodigoArguTipoAtributo.Substring(0, 8) == 
                        ConfigCROM.AppConfig(personaAtributo.codEmpresa, ConfigTool.DEFAULT_Atributo_Telefono))
                        p_Existe = false;
                    else
                        p_Existe = oPersonasAtributosData.ValidarAtributo(personaAtributo, ref p_Codi_personaExist, ref p_Name_personaExist);

                    if (!p_Existe)
                    {
                        string pMensaje = string.Empty;
                        oReturnValor.Exitosa = oPersonasAtributosData.Insert(personaAtributo, out pMensaje);
                        if (oReturnValor.Exitosa)
                        {
                            oReturnValor.Message = HelpMessages.Evento_EDIT;
                            tx.Complete();
                        }
                        else
                            oReturnValor.Message = pMensaje;
                    }
                    else
                        oReturnValor.Message = "¡ El Atributo  " + personaAtributo.CodigoArguTipoAtributoNombre + "  ya Existe ! [Código]: " + p_Codi_personaExist + " - [Nombre]:" + p_Name_personaExist;

                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// Elimina registro de la tabla Maestros.PersonasAtributos
        /// </summary>
        /// <param name="prm_CodigoPersona">Código de persona</param>
        /// <param name="prm_CodigoArguTipoAtributo">Código de tipo de atributo</param>
        /// <returns>objeto oReturnValor</returns>
        public ReturnValor DeletePersonasAtributos(int pcodEmpresa, string prm_CodigoPersona, string prm_CodigoArguTipoAtributo, string pUser)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    string pMensaje = string.Empty;
                    oReturnValor.Exitosa = oPersonasAtributosData.Delete(pcodEmpresa,
                                                                         prm_CodigoPersona, 
                                                                         prm_CodigoArguTipoAtributo,
                                                                         pUser,
                                                                         out pMensaje);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                    this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pUser, pcodEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #endregion

        #region TABLA PERSONAS_FOTOS LOGO

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestros.PersonasFotoLogo
        /// En la BASE de DATO la Tabla : [Maestros.PersonasFotoLogo]
        /// <summary>
        /// <param name="prm_CodigoPersona"></param>
        /// <returns></returns>
        public BEPersonaFotoLogo FindPersonasFotoLogoData(int pcodEmpresa, string prm_CodigoPersona, string pUser)
        {
            BEPersonaFotoLogo personaFotoLogo = new BEPersonaFotoLogo();
            try
            {
                personaFotoLogo = oPersonasFotoLogoData.Find(pcodEmpresa, prm_CodigoPersona);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                  pUser, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return personaFotoLogo;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PersonasFotoLogo
        /// En la BASE de DATO la Tabla : [Maestros.PersonasFotoLogo]
        /// <summary>
        /// <param name="personaFotoLogo"></param>
        /// <returns></returns>
        public ReturnValor InsertPersonasFotoLogo(BEPersonaFotoLogo personaFotoLogo)
        {
            string pMensaje = string.Empty;
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oPersonasFotoLogoData.Insert(personaFotoLogo, out pMensaje);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_NEW;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                               this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, 
                               personaFotoLogo.SegUsuarioCrea, personaFotoLogo.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Maestros.PersonasFotoLogo
        /// En la BASE de DATO la Tabla : [Maestros.PersonasFotoLogo]
        /// <summary>
        /// <param name="prm_CodigoPersona"></param>
        /// <returns></returns>
        public ReturnValor DeletePersonasFotoLogo(int pcodEmpresa, string prm_CodigoPersona, string pUser)
        {
            string pMensaje = string.Empty;
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oPersonasFotoLogoData.Delete(pcodEmpresa,prm_CodigoPersona, pUser, out pMensaje);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pUser, pcodEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #endregion

        #region TABLA PERSONAS_DATOS ADICIONALES

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Asistencia.PersonasDatosAdicionales
        /// En la BASE de DATO la Tabla : [Asistencia.PersonasDatosAdicionales]
        /// <summary>
        /// <param name="prm_CodigoPersona"></param>
        /// <returns></returns>
        public BEPersonaDato FindPersonasDatosAdicionales(int pcodEmpresa, string prm_CodigoPersona, string pLogin)
        {
            BEPersonaDato personaDatoAdicional = new BEPersonaDato();
            try
            {
                personaDatoAdicional = oPersonasDatosAdicionalesData.Find(pcodEmpresa, prm_CodigoPersona);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                  pLogin, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return personaDatoAdicional;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE FOREIGN KEY*/

        /// <summary>
        /// Retorna una LISTA de registro de la Entidad Asistencia.PersonasDatosAdicionales POR FOREIGN KEY
        /// En la BASE de DATO la Tabla : [Asistencia.PersonasDatosAdicionales]
        /// <summary>
        /// <param name="prm_CodigoPersona"></param>
        /// <param name="prm_CodigoPersonaPersona"></param>
        /// <returns></returns>
        public List<BEPersonaDato> ListBy_PersonasDatosAdicionales(int pcodEmpresa, string prm_CodigoPersona, 
                                                                   string prm_CodigoPersonaPersona, string pUser)
        {
            List<BEPersonaDato> lstPersonaDatoAdicional = new List<BEPersonaDato>();
            try
            {
                lstPersonaDatoAdicional = oPersonasDatosAdicionalesData.ListBy_Persona(pcodEmpresa, 
                                                                                       prm_CodigoPersona, 
                                                                                       prm_CodigoPersonaPersona);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                  pUser, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstPersonaDatoAdicional;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PersonasDatosAdicionales
        /// En la BASE de DATO la Tabla : [Asistencia.PersonasDatosAdicionales]
        /// <summary>
        /// <param name="personaDatoAdicional"></param>
        /// <returns></returns>
        public ReturnValor InsertUpdatedPersonasDatosAdicionales(BEPersonaDato personaDatoAdicional)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    BEPersonaDato xitem = new BEPersonaDato();

                    string pMensaje = string.Empty;
                    oReturnValor.Exitosa = oPersonasDatosAdicionalesData.InsertUpdate(personaDatoAdicional, out pMensaje);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        tx.Complete();
                    }
                    else
                        oReturnValor.Message = pMensaje;
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                  personaDatoAdicional.SegUsuarioEdita, personaDatoAdicional.codEmpresa.ToString());
            }
            return oReturnValor;

        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Asistencia.PersonasDatosAdicionales
        /// En la BASE de DATO la Tabla : [Asistencia.PersonasDatosAdicionales]
        /// <summary>
        /// <param name="prm_CodigoPersona"></param>
        /// <returns></returns>
        public ReturnValor DeletePersonasDatosAdicionales(int pcodEmpresa, string prm_CodigoPersona, string pLogin)
        {
            string pMensaje = string.Empty;
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oPersonasDatosAdicionalesData.Delete(pcodEmpresa,
                                                                                prm_CodigoPersona,
                                                                                pLogin,
                                                                                out pMensaje);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
                        tx.Complete();
                    }
                    else
                        oReturnValor.Message = pMensaje;
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                  pLogin, pcodEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #endregion

        #region TABLA PERSONAS_DOMICILIOS

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestros.PersonasDomicilio
        /// En la BASE de DATO la Tabla : [Maestros.PersonasDomicilio]
        /// <summary>
        /// <param name="pcodEmpresa"></param>
        /// <param name="pCodigoPersona"></param>
        /// <param name="pcodPersonaDomicilio"></param>
        /// <param name="pUser"></param>
        /// <returns></returns>
        public BEPersonasDomicilio FindPersonasDomicilio(int pcodEmpresa, string pCodigoPersona, 
                                                         int pcodPersonaDomicilio,
                                                         string pUser)
        {
            BEPersonasDomicilio personaDomicilio = null;
            try
            {
                personaDomicilio = oPersonasDomicilioData.Find(pcodEmpresa, pCodigoPersona, pcodPersonaDomicilio);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false,
                    this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pUser, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return personaDomicilio;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE FOREIGN KEY*/

        /// <summary>
        /// Retorna una LISTA de registro de la Entidad Maestros.PersonasAtributos POR FOREIGN KEY
        /// En la BASE de DATO la Tabla : [Maestros.PersonasAtributos]
        /// <summary>
        /// <param name="prm_CodigoPersona"></param>
        /// <returns></returns>
        public List<BEPersonasDomicilio> ListBy_PersonasDomicilio(int pcodEmpresa, string prm_CodigoPersona, bool pindActivo)
        {
            List<BEPersonasDomicilio> lstPersonaDomicilio = new List<BEPersonasDomicilio>();
            try
            {
                lstPersonaDomicilio = oPersonasDomicilioData.List(pcodEmpresa, prm_CodigoPersona, pindActivo);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name);
                throw new Exception(returnValor.Message);
            }
            return lstPersonaDomicilio;
        }

        //public OperationResult ListBy_PersonasDomicilioPaged(BaseFiltroPersonaDomicilio pFiltro)
        //{
        //    List<DTOPersonasDomicilioResponse> lstPersonasDomicilio = new List<DTOPersonasDomicilioResponse>();
        //    try
        //    {
        //        lstPersonasDomicilio = oPersonasDomicilioData.ListPage(pFiltro);
        //        int totalRecords = lstPersonasDomicilio.Select(x => x.TOTALROWS).FirstOrDefault();
        //        int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pFiltro.jqPageSize);

        //        var jsonGrid = new
        //        {
        //            PageCount = totalPages,
        //            CurrentPage = pFiltro.jqCurrentPage,
        //            RecordCount = totalRecords,
        //            Items = (
        //                from item in lstPersonasDomicilio
        //                select new
        //                {
        //                    ID = item.codPersonaDomicilio,
        //                    Row = new string[] {
        //                                        item.codRegTipoNombre
        //                                      , item.codRegViaNombre
        //                                      , item.gloDireccion
        //                                      , item.desNumero
        //                                      , item.codRegNucleoUrbNombre
        //                                      , item.desNucleoUrb
        //                                      , item.codUbigeoCode
        //                                      , item.nomUbigeo
        //                                      , item.numLongitud.Value.ToString("N8")
        //                                      , item.numLatitud.Value.ToString("N8")
        //                                      , item.Estado.ToString()
        //                                      , item.segFechaEdita.ToString()
        //                                      , item.segUsuarioEdita
        //                                       }
        //                }).ToArray()
        //        };
        //        return OK(jsonGrid);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pFiltro.userActual, pFiltro.codEmpresa);
        //    }
        //    finally
        //    {
        //        if (oPersonasDomicilioData != null)
        //        {
        //            oPersonasDomicilioData.Dispose();
        //            oPersonasDomicilioData = null;
        //        }
        //    }
        //}

        public List<DTOPersonasDomicilioResponse> ListBy_PersonasDomicilioPaged(BaseFiltroPersonaDomicilio pFiltro)
        {
            List<DTOPersonasDomicilioResponse> lstPersonasDomicilio = new List<DTOPersonasDomicilioResponse>();
            try
            {
                lstPersonasDomicilio = oPersonasDomicilioData.ListPage(pFiltro);
                
                return lstPersonasDomicilio;
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false,
                    this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            finally
            {
                if (oPersonasDomicilioData != null)
                {
                    oPersonasDomicilioData.Dispose();
                    oPersonasDomicilioData = null;
                }
            }
        }
        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PersonasAtributos
        /// En la BASE de DATO la Tabla : [Maestros.PersonasAtributos]
        /// <summary>
        /// <param name="personaDomicilio"></param>
        /// <returns></returns>
        public ReturnValor InsertPersonasDomicilio(BEPersonasDomicilio personaDomicilio)
        {
            string pMensaje = string.Empty;
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oPersonasDomicilioData.Insert(personaDomicilio, out pMensaje);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_NEW;
                        tx.Complete();
                    }
                    else
                    {
                        oReturnValor.Message = pMensaje;
                        return oReturnValor;
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                personaDomicilio.segUsuarioCrea, personaDomicilio.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Actualiza la tabla Maestros.PersonasAtributos
        /// </summary>
        /// <param name="personaDomicilio"></param>
        /// <returns></returns>
        public ReturnValor UpdatePersonasDomicilio(BEPersonasDomicilio personaDomicilio)
        {
            string pMensaje = string.Empty;
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oPersonasDomicilioData.Update(personaDomicilio, out pMensaje);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_EDIT;
                        tx.Complete();
                    }
                    else
                    {
                        oReturnValor.Message = pMensaje;
                        return oReturnValor;
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// Elimina registro de la tabla Maestros.PersonasAtributos
        /// </summary>
        /// <param name="pCodigoPersona">Código de persona</param>
        /// <param name="prm_CodigoArguTipoAtributo">Código de tipo de atributo</param>
        /// <returns>objeto oReturnValor</returns>
        public ReturnValor DeletePersonasDomicilio(int pcodEmpresa, string pCodigoPersona, int pcodPersonaDomicilio, 
                                                   string pUser, string pMaquina)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    string pMensaje = string.Empty;
                    oReturnValor.Exitosa = oPersonasDomicilioData.Delete(pcodEmpresa,
                                                                         pCodigoPersona,
                                                                         pcodPersonaDomicilio,
                                                                         pUser,
                                                                         pMaquina,
                                                                         out pMensaje);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                    this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, pUser, pcodEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #endregion

        #region METODOS ADICIONALES

        private bool ValidaPersonasAtributosRequeridos(int codEmpresa, 
                                                       string prm_TipoEntidad, List<BEPersonaAtributo> lstPersonasAtributos, 
                                                       ref string prm_Mensaje)
        {
            bool EXISTE_DOMICILIO = false;
            bool EXISTE_DOCUM_PERS_FISCAL = false;
            bool EXISTE_DOCUM_PERS_NATURAL = true;
            bool PERSONA_EXTRANJERA = false;
                
            foreach (BEPersonaAtributo itemPersonasAtributos in lstPersonasAtributos)
            {

                //itemPersonasAtributos.codEmpresa = persona.codEmpresa;
                //if (itemPersonasAtributos.CodigoArguTipoAtributo == ConfigCROM.AppConfig(ConfigTool.DEFAULT_Atributo_DomicFiscal))
                //{
                //    EXISTE_DOMICILIO = true;
                //    if (itemPersonasAtributos.CodigoArguUbigeo.Substring(0, 7) == ConfigCROM.AppConfig(ConfigTool.DEFAULT_Ubigeo))
                //        PERSONA_EXTRANJERA = false;
                //    else
                //        PERSONA_EXTRANJERA = true;
                //}

                if (prm_TipoEntidad == WebConstants.DEFAULT_PersonaNatural)
                {
                    if (itemPersonasAtributos.CodigoArguTipoAtributo == ConfigCROM.AppConfig(codEmpresa, 
                                                                                             ConfigTool.DEFAULT_Atributo_NumerDNI))
                    {
                        EXISTE_DOCUM_PERS_NATURAL = true;
                        EXISTE_DOCUM_PERS_FISCAL = true;
                    }
                }
                else if (itemPersonasAtributos.CodigoArguTipoAtributo == ConfigCROM.AppConfig(codEmpresa, 
                                                                                              ConfigTool.DEFAULT_Atributo_NumerRUC))
                {
                    EXISTE_DOCUM_PERS_FISCAL = true;
                    EXISTE_DOCUM_PERS_NATURAL = true;
                }
            }
            if (!EXISTE_DOMICILIO)
                prm_Mensaje = HelpMessages.MAESTROSAtributoValidaDomicFiscal;

            if (prm_TipoEntidad == WebConstants.DEFAULT_PersonaNatural)
            {
                if (!EXISTE_DOCUM_PERS_NATURAL)
                    prm_Mensaje = prm_Mensaje + ", " + HelpMessages.MAESTROSAtributoValidaDocumNatural;
            }
            else if (!EXISTE_DOCUM_PERS_FISCAL)
                prm_Mensaje = prm_Mensaje + ", " + HelpMessages.MAESTROSAtributoValidaDocumFiscal;

            bool RESULTADO = false;
            if (PERSONA_EXTRANJERA)
                RESULTADO = true;
            if (EXISTE_DOMICILIO && EXISTE_DOCUM_PERS_FISCAL)
                RESULTADO = true;
            else if (EXISTE_DOMICILIO && EXISTE_DOCUM_PERS_NATURAL)
                RESULTADO = true;
            return RESULTADO;
        }

        public string AtributoPersona(BEPersona itemEmpresa, string CodigoAtributo)
        {

            string UBIGEOS_CAD = string.Empty;
            string DATO_DEVUELTO = string.Empty;

            var query = from item in itemEmpresa.listaPersonasAtributos
                        where item.CodigoArguTipoAtributo == CodigoAtributo
                        select item;

            List<BEPersonaAtributo> listaPA = new List<BEPersonaAtributo>();
            listaPA = query.ToList<BEPersonaAtributo>();
            if (listaPA.Count > 0)
            {
                BEPersonaAtributo itemPA = new BEPersonaAtributo();
                itemPA = listaPA[0];

                DATO_DEVUELTO = itemPA.DescripcionAtributo;
                //if (ubigeo)
                //{
                //    string d1prm_EmisorUbigeo = itemPA.CodigoArguUbigeoNombre.Trim();
                //    DATO_DEVUELTO = NombreDeUbigeo(ObtenerUbigeo(itemPA.CodigoArguUbigeo));
                //}
            }
            return DATO_DEVUELTO;
        }

        public string DomicilioPersona(BEPersona itemEmpresa, bool ubigeo, 
                                       int pcodEmpresa, string pSegUsuario,
                                       TipoDomicilio pTipoDomicilio = TipoDomicilio.FISCAL_PRINCIPAL)
        {
            int codRegTipo = pTipoDomicilio.ToInteger();
            string UBIGEOS_CAD = string.Empty;
            string DATO_DEVUELTO = string.Empty;

            var query = from item in itemEmpresa.listaPersonasDomicilio
                        where item.codRegTipo == codRegTipo
                        select item;

            List<BEPersonasDomicilio> listaPDomicilio = new List<BEPersonasDomicilio>();
            listaPDomicilio = query.ToList<BEPersonasDomicilio>();
            if (listaPDomicilio.Count > 0)
            {
                BEPersonasDomicilio itemPersonaDomicilio = new BEPersonasDomicilio();
                itemPersonaDomicilio = listaPDomicilio[0];

                DATO_DEVUELTO = itemPersonaDomicilio.gloDireccionSunat;
                if (ubigeo)
                {
                    string d1prm_EmisorUbigeo = itemPersonaDomicilio.codUbigeoNombre.Trim();
                    DATO_DEVUELTO = string.Concat( DATO_DEVUELTO ," ", NombreDeUbigeo(ObtenerUbigeo(itemPersonaDomicilio.codUbigeoCode, 
                                                                                pcodEmpresa, pSegUsuario)));
                                                                 
                }
            }
            return DATO_DEVUELTO;
        }

        public string NombreDeUbigeo(string UBIGEOS_CAD)
        {
            string[] ubigeos;
            string d1prm_EmisorUbigeo = string.Empty;
            ubigeos = UBIGEOS_CAD.Split('@');
            if (ubigeos.Length == 1)
            {
                d1prm_EmisorUbigeo = ubigeos[0];
            }
            else if (ubigeos.Length == 2)
            {
                d1prm_EmisorUbigeo = ubigeos[1];
            }
            else if (ubigeos.Length == 3)
            {
                d1prm_EmisorUbigeo = ubigeos[2] + " - " + ubigeos[1];
            }
            else if (ubigeos.Length == 4)
            {
                d1prm_EmisorUbigeo = ubigeos[3] + " - " + ubigeos[1];
            }
            return d1prm_EmisorUbigeo;
        }

        public string ObtenerAtributoPersona(BEPersona itemEmpresa, string CodigoAtributo)
        {
            string UBIGEOS_CAD = string.Empty;
            string DATO_DEVUELTO = string.Empty;

            var query = from item in itemEmpresa.listaPersonasAtributos
                        where item.CodigoArguTipoAtributo == CodigoAtributo
                        select item;

            List<BEPersonaAtributo> listaPA = new List<BEPersonaAtributo>();
            listaPA = query.ToList<BEPersonaAtributo>();
            if (listaPA.Count > 0)
            {
                BEPersonaAtributo itemPA = new BEPersonaAtributo();
                itemPA = listaPA[0];

                DATO_DEVUELTO = itemPA.CodigoArguTipoAtributo;
                //if (ubigeo)
                //{
                //    DATO_DEVUELTO = itemPA.CodigoArguUbigeo;
                //}
            }
            return DATO_DEVUELTO;
        }

        public string ObtenerUbigeoPersona(BEPersona itemEmpresa,
                                           DatoUbigeo pDatoUbigeo, 
                                           TipoDomicilio pTipoDomicilio = TipoDomicilio.FISCAL_PRINCIPAL)
        {
            string UBIGEOS_CAD = string.Empty;
            string DATO_DEVUELTO = string.Empty;

            var query = from item in itemEmpresa.listaPersonasDomicilio
                        where item.codRegTipo == (int)pTipoDomicilio
                        select item;

            List<BEPersonasDomicilio> listaPersonaDomicilio = new List<BEPersonasDomicilio>();
            listaPersonaDomicilio = query.ToList<BEPersonasDomicilio>();
            if (listaPersonaDomicilio.Count > 0)
            {
                BEPersonasDomicilio itemPersonasDomicilio = new BEPersonasDomicilio();
                itemPersonasDomicilio = listaPersonaDomicilio[0];

                if (pDatoUbigeo == DatoUbigeo.UbigeoCodigo)
                {
                    DATO_DEVUELTO = itemPersonasDomicilio.codUbigeoCode;
                }
                else if (pDatoUbigeo == DatoUbigeo.Domicilio)
                {
                    DATO_DEVUELTO = itemPersonasDomicilio.gloDireccionSunat;
                }
                else if (pDatoUbigeo == DatoUbigeo.UbigeoNombre)
                {
                    DATO_DEVUELTO = itemPersonasDomicilio.codUbigeoNombre;
                }
                        
            }
            return DATO_DEVUELTO;
        }

        public string ObtenerDatoAtributoPersona(BEPersona itemEmpresa, string CodigoAtributo)
        {
            string UBIGEOS_CAD = string.Empty;
            string DATO_DEVUELTO = string.Empty;

            var query = from item in itemEmpresa.listaPersonasAtributos
                        where item.CodigoArguTipoAtributo == CodigoAtributo
                        select item;

            List<BEPersonaAtributo> listaPA = new List<BEPersonaAtributo>();
            listaPA = query.ToList<BEPersonaAtributo>();
            if (listaPA.Count > 0)
            {
                BEPersonaAtributo itemPA = new BEPersonaAtributo();
                itemPA = listaPA[0];

                DATO_DEVUELTO = itemPA.DescripcionAtributo;
                
            }
            return DATO_DEVUELTO;
        }

        public string ObtenerUbigeo(string pCodigoUBIGEO, int pcodEmpresa, string pSegUsuario)
        {
            MaestroLogic oMaestroLogic = new MaestroLogic();
            return oMaestroLogic.ObtenerUbigeo(pCodigoUBIGEO, pcodEmpresa, pSegUsuario);
        }

        #endregion

        public List<vwDocumRegVendedor> ListVendedoresAtendidosPorEntidad(BaseFiltroDocumRegVendedor pFiltro)
        {
            List<vwDocumRegVendedor> listaDocumRegVendedor = new List<vwDocumRegVendedor>();
            try
            {
                listaDocumRegVendedor = oPersonasData.ListVendedoresAtendidosPorEntidad(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, 
                                                              this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, 
                                                              pFiltro.segUsuarioEdita, 
                                                              pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return listaDocumRegVendedor;
        }

    }
} 

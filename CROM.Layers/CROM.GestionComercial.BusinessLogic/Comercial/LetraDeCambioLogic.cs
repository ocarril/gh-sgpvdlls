namespace CROM.GestionComercial.BusinessLogic
{
    using CROM.BusinessEntities.Comercial;
    using CROM.GestionComercial.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 24/01/2012-03:48:42 p.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [GestionComercial.LetraDeCambioLogic.cs]
    /// </summary>
    public class LetraDeCambioLogic
    {
        private LetraDeCambioData oLetraDeCambioData = null;
        private ComprobanteEmisionData comprobanteEmisionData = null;
        private ReturnValor oReturnValor = null;
        public LetraDeCambioLogic()
        {
            oLetraDeCambioData = new LetraDeCambioData();
            comprobanteEmisionData = new ComprobanteEmisionData();
            oReturnValor = new ReturnValor();
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.LetraDeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.LetraDeCambio]
        /// <summary>
        /// <returns>List</returns>>
        public List<LetraDeCambioAux> List(BaseFiltro pFiltro)
        {
            List<LetraDeCambioAux> lstLetraDeCambio = new List<LetraDeCambioAux>();
            List<LetraDeCambioAux> lstLetraDeCambioOrder = new List<LetraDeCambioAux>();
            try
            {
                pFiltro.fecInicio=HelpTime.ConvertYYYYMMDD( pFiltro.fecInicioDate);
                pFiltro.fecFinal=HelpTime.ConvertYYYYMMDD(pFiltro.fecFinalDate);
                lstLetraDeCambio = oLetraDeCambioData.List(pFiltro); 

                var query1 = from item in lstLetraDeCambio
                             orderby item.numDocumento, item.numLetraInterna
                             select item;

                lstLetraDeCambioOrder = query1.ToList<LetraDeCambioAux>();

                string parteEntera = string.Empty;
                string parteDecimal = string.Empty;
                decimal EnteroD = 0;
                Int64 Entero = 0;
                lstLetraDeCambioOrder.ForEach(lc =>
                {
                    string strDatoNumero1 = lc.monValorDeLetra.Value.ToString("N2");
                    parteEntera = strDatoNumero1.Substring(0, strDatoNumero1.IndexOf('.'));
                    parteDecimal = strDatoNumero1.Substring(strDatoNumero1.IndexOf('.') + 1, 2);
                    EnteroD = Convert.ToDecimal(parteEntera);
                    Entero = Convert.ToInt64(EnteroD);

                    lc.auxdesMontoEnLetras = Helper.Numero_A_Texto(Entero) + " CON " + parteDecimal + "/100 " + (lc.auxcodRegistroMonedaNombre == null ? string.Empty : lc.auxcodRegistroMonedaNombre.Trim().ToUpper());
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstLetraDeCambioOrder;
        }
        public List<LetraDeCambioAux> List(int pcodEmpresa, int prm_codDocumReg)
        {
            List<LetraDeCambioAux> miLista = new List<LetraDeCambioAux>();
            List<LetraDeCambioAux> miListaOrder = new List<LetraDeCambioAux>();
            try
            {
                miLista = oLetraDeCambioData.List(pcodEmpresa, prm_codDocumReg);

                var query1 = from item in miLista
                             orderby item.numDocumento, item.numLetraInterna
                             select item;

                miListaOrder = query1.ToList<LetraDeCambioAux>();

                string parteEntera = string.Empty;
                string parteDecimal = string.Empty;
                decimal EnteroD = 0;
                Int64 Entero = 0;
                miListaOrder.ForEach(lc =>
                {
                    string strDatoNumero1 = lc.monValorDeLetra.Value.ToString("N2");
                    parteEntera = strDatoNumero1.Substring(0, strDatoNumero1.IndexOf('.'));
                    parteDecimal = strDatoNumero1.Substring(strDatoNumero1.IndexOf('.') + 1, 2);
                    EnteroD = Convert.ToDecimal(parteEntera);
                    Entero = Convert.ToInt64(EnteroD);

                    lc.auxdesMontoEnLetras = Helper.Numero_A_Texto(Entero) + " CON " + parteDecimal + "/100 " + (lc.auxcodRegistroMonedaNombre == null ? string.Empty : lc.auxcodRegistroMonedaNombre.Trim().ToUpper());
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miListaOrder;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.LetraDeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.LetraDeCambio]
        /// <summary>
        /// <returns>Entidad</returns>
        public LetraDeCambioAux Find(int pcodEmpresa, int prm_codLetraDeCambio)
        {
            LetraDeCambioAux objLetraDeCambio = new LetraDeCambioAux();
            try
            {
                objLetraDeCambio = oLetraDeCambioData.Find(pcodEmpresa, prm_codLetraDeCambio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objLetraDeCambio;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo LetraDeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.LetraDeCambio]
        /// <summary>
        /// <param name = >itemLetraDeCambio</param>
        public ReturnValor Insert(List<LetraDeCambioAux> listaLetraDeCambio)
        {
            try
            {
                //using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                //{
                foreach (LetraDeCambioAux letraDeCambio in listaLetraDeCambio)
                {
                    oLetraDeCambioData.Insert(letraDeCambio);
                    oReturnValor.codRetorno = letraDeCambio.codLetraDeCambio;
                }

                bool sucedeOK = comprobanteEmisionData.UpdateAsignaLetrasEmitidas(listaLetraDeCambio[0].codDocumReg, ObtenerDescripcionLetra(listaLetraDeCambio), listaLetraDeCambio[0].segUsuarioEdita);

                if (oReturnValor.codRetorno > 0 && sucedeOK)
                {
                    oReturnValor.Exitosa = true;
                    oReturnValor.Message = HelpMessages.gc_LETRASCreadas;
                    //tx.Complete();
                }
                //}
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo LetraDeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.LetraDeCambio]
        /// <summary>
        /// <param name = >itemLetraDeCambio</param>
        public ReturnValor Update(List<LetraDeCambioAux> listaLetraDeCambio)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    foreach (LetraDeCambioAux itemLC in listaLetraDeCambio)
                    {
                        if (itemLC.codLetraDeCambio != 0)
                            oReturnValor.Exitosa = oLetraDeCambioData.Update(itemLC);
                        else
                        {
                            oLetraDeCambioData.Insert(itemLC);
                            oReturnValor.codRetorno = itemLC.codLetraDeCambio;
                            if (oReturnValor.codRetorno != 0)
                                oReturnValor.Exitosa = true;
                            else
                            {
                                oReturnValor.Exitosa = false;
                                oReturnValor.Message = "La letra N° [ " + itemLC.numLetraInterna + " ] no se ha registrado.";
                                break;
                            }
                        }
                    }

                    bool sucedeOK = comprobanteEmisionData.UpdateAsignaLetrasEmitidas(listaLetraDeCambio[0].codDocumReg, 
                                                                                      ObtenerDescripcionLetra(listaLetraDeCambio), 
                                                                                      listaLetraDeCambio[0].segUsuarioEdita);

                    if (oReturnValor.Exitosa && sucedeOK)
                    {
                        oReturnValor.Message = HelpMessages.gc_LETRASEditadas;
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
        public ReturnValor UpdatecodRegistroEstado(LetraDeCambioAux itemLetraDeCambio)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oLetraDeCambioData.UpdatecodRegistroEstado(itemLetraDeCambio);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.gc_LETRASEditadas;
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
        public ReturnValor UpdatefecRecepcion(LetraDeCambioAux itemLetraDeCambio)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {

                    oReturnValor.Exitosa = oLetraDeCambioData.UpdatefecRecepcion(itemLetraDeCambio);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.gc_LETRASEditadas;
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

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.LetraDeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.LetraDeCambio]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(int prm_codLetraDeCambio)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oLetraDeCambioData.Delete(prm_codLetraDeCambio);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
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

        private string ObtenerDescripcionLetra(List<LetraDeCambioAux> listaLetraDeCambio)
        {
            string descripcionGlosaFactura = "LETRAS A : ";
            DateTime fechaEmision = listaLetraDeCambio[0].fecEmision;
            foreach (LetraDeCambioAux itemLC in listaLetraDeCambio)
            {
                string letraADias = (itemLC.fecVencimiento - fechaEmision).Days.ToString() + " Dias,";
                descripcionGlosaFactura = descripcionGlosaFactura + letraADias;
            }
            return descripcionGlosaFactura;
        }
    }
} 

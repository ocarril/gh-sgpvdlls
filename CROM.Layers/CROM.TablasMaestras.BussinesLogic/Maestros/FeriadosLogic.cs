namespace CROM.TablasMaestras.BussinesLogic
{
    using CROM.BusinessEntities.Maestros;
    using CROM.TablasMaestras.DataAcces;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 09/07/2010-11:33:49 
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Maestras.FeriadosLogic.cs]
    /// </summary>
    public class FeriadosLogic
    {
        private FeriadoData oFeriadosData = null;
        private ReturnValor oReturnValor = null;

        public FeriadosLogic()
        {
            oFeriadosData = new FeriadoData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Maestras.Feriados
        /// En la BASE de DATO la Tabla : [Maestras.Feriados]
        /// <summary>
        /// <returns>List</returns>
        public List<BEFeriado> List(string prm_Anio, string prm_Descripcion, bool? prm_Fijo, bool? prm_Estado)
        {
            List<BEFeriado> miLista = new List<BEFeriado>();
            try
            {
                miLista = oFeriadosData.List(prm_Anio, prm_Descripcion, prm_Fijo, prm_Estado);
                foreach (BEFeriado xFeriados in miLista)
                {
                    if (!xFeriados.Fijo)
                    {
                        string sFECHA_DATO = xFeriados.Feriado.Substring(6, 2) + "/" +
                                             xFeriados.Feriado.Substring(4, 2) + "/" +
                                             xFeriados.Feriado.Substring(0, 4);
                        xFeriados.FechaIndicada = Convert.ToDateTime(sFECHA_DATO);
                    }
                }

                var feriadoOrden = from x in miLista
                                   orderby x.Descripcion
                                   select x;

                miLista = feriadoOrden.ToList<BEFeriado>();
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
        /// Retorna una ENTIDAD de registro de la Entidad Maestras.Feriados
        /// En la BASE de DATO la Tabla : [Maestras.Feriados]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEFeriado Find(string prm_CodigoFeriado)
        {
            BEFeriado miEntidad = new BEFeriado();
            try
            {
                miEntidad = oFeriadosData.Find(prm_CodigoFeriado);
                if (!miEntidad.Fijo)
                {
                    string sFECHA_DATO = miEntidad.Feriado.Substring(6, 2) + "/" +
                                         miEntidad.Feriado.Substring(4, 2) + "/" +
                                         miEntidad.Feriado.Substring(0, 4);
                    miEntidad.FechaIndicada = Convert.ToDateTime(sFECHA_DATO);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Feriados
        /// En la BASE de DATO la Tabla : [Maestras.Feriados]
        /// <summary>
        /// <param name = >itemFeriados</param>
        public ReturnValor Insert(BEFeriado itemFeriados)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    string sFeriadox = oFeriadosData.FindByFeriado(itemFeriados.Feriado).Feriado;
                    if (sFeriadox == null)
                    {
                        oReturnValor.CodigoRetorno = oFeriadosData.Insert(itemFeriados);
                        if (oReturnValor.CodigoRetorno != null)
                        {
                            oReturnValor.Exitosa = true;
                            tx.Complete();
                            oReturnValor.Message = HelpMessages.Evento_NEW;
                        }
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Feriados
        /// En la BASE de DATO la Tabla : [Maestras.Feriados]
        /// <summary>
        /// <param name = >itemFeriados</param>
        public ReturnValor Update(BEFeriado itemFeriados)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    List<BEFeriado> listaFeriados = new List<BEFeriado>();
                    listaFeriados = oFeriadosData.List(string.Empty, string.Empty, null, null);
                    int CONTADOR = 0;
                    foreach (BEFeriado kExamina in listaFeriados)
                    {
                        if (kExamina.Feriado.Substring(4, 4) == itemFeriados.Feriado.Substring(4, 4))
                            ++CONTADOR;
                    }
                    if (CONTADOR < 2)
                    {
                        oReturnValor.Exitosa = oFeriadosData.Update(itemFeriados);
                        if (oReturnValor.Exitosa)
                        {
                            tx.Complete();
                            oReturnValor.Message = HelpMessages.Evento_EDIT;
                        }
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
        /// ELIMINA un registro de la Entidad Maestras.Feriados
        /// En la BASE de DATO la Tabla : [Maestras.Feriados]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string prm_sCodRegistro)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oFeriadosData.Delete(prm_sCodRegistro);
                    if (oReturnValor.Exitosa)
                    {
                        tx.Complete();
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
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

    }
}

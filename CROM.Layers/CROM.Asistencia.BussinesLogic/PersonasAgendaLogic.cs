namespace CROM.Asistencia.BussinesLogic
{
    using CROM.Asistencia.DataAcces;
    using CROM.BusinessEntities.Asistencia;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Transactions;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 12/01/2010-05:21:26 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Asistencia.PersonasAgendaLogic.cs]
    /// </summary>
    public class PersonasAgendaLogic
    {
        private PersonasAgendaData oPersonasAgendaData = null;
        private ReturnValor oReturnValor = null;
        public PersonasAgendaLogic()
        {
            oPersonasAgendaData = new PersonasAgendaData();
            oReturnValor = new ReturnValor();
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Asistencia.PersonasAgenda
        /// En la BASE de DATO la Tabla : [Asistencia.PersonasAgenda]
        /// <summary>
        /// <returns>List</returns>
        public List<BEPersonaAgenda> List(string prm_CodigoPersona, string prm_CodigoJustificacion, bool prm_Estado)
        {
            List<BEPersonaAgenda> miLista = new List<BEPersonaAgenda>();
            try
            {
                miLista = oPersonasAgendaData.List(prm_CodigoPersona, prm_CodigoJustificacion, prm_Estado);
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
        /// Retorna una ENTIDAD de registro de la Entidad Asistencia.PersonasAgenda
        /// En la BASE de DATO la Tabla : [Asistencia.PersonasAgenda]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEPersonaAgenda Find(string prm_Item)
        {
            BEPersonaAgenda miEntidad = new BEPersonaAgenda();
            try
            {
                miEntidad = oPersonasAgendaData.Find(prm_Item);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo PersonasAgenda
        /// En la BASE de DATO la Tabla : [Asistencia.PersonasAgenda]
        /// <summary>
        /// <param name = >itemPersonasAgenda</param>
        public ReturnValor Insert(BEPersonaAgenda itemPersonasAgenda)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (!ValidarDatosDeAgenda(itemPersonasAgenda))
                    {
                        oReturnValor.CodigoRetorno = oPersonasAgendaData.Insert(itemPersonasAgenda);
                        if (oReturnValor.CodigoRetorno != null)
                        {
                            oReturnValor.Exitosa = true;
                            oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                            tx.Complete();
                        }
                    }
                    else
                    {
                        oReturnValor.Exitosa = false;
                        oReturnValor.Message = "¡ ERROR en el Ingeso de los Rangos de Fecha en DESDE y HASTA !";
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo PersonasAgenda
        /// En la BASE de DATO la Tabla : [Asistencia.PersonasAgenda]
        /// <summary>
        /// <param name = >itemPersonasAgenda</param>
        public ReturnValor Update(BEPersonaAgenda itemPersonasAgenda)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oPersonasAgendaData.Update(itemPersonasAgenda);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
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
        /// ELIMINA un registro de la Entidad Asistencia.PersonasAgenda
        /// En la BASE de DATO la Tabla : [Asistencia.PersonasAgenda]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string prm_Item)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oPersonasAgendaData.Delete(prm_Item);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
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

        private bool ValidarDatosDeAgenda(BEPersonaAgenda itemPersonaAgenda)
        {
            List<BEPersonaAgenda> miLista = new List<BEPersonaAgenda>();
            bool Validado = false;
            miLista = oPersonasAgendaData.List(itemPersonaAgenda.CodigoPersona, string.Empty, true);
            foreach (BEPersonaAgenda item in miLista)
            {
                int nDiaFin = item.FechaFinal.DayOfYear;
                int nDiaIni = item.FechaInicio.DayOfYear;
                int nDiaHoy = itemPersonaAgenda.FechaInicio.DayOfYear;
                if (nDiaHoy <= nDiaFin && nDiaHoy >= nDiaIni)
                {
                    Validado = true;
                    break;
                }
            }
            return Validado;
        }
    }
} 

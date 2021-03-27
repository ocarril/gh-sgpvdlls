namespace CROM.Asistencia.BussinesLogic
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Transactions;

    using CROM.BusinessEntities.Asistencia;
    using CROM.Asistencia.DataAcces;
    using CROM.Tools;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 12/01/2010-05:21:26 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Asistencia.CalendariosLogic.cs]
    /// </summary>
    public class CalendariosLogic
    {
        private CalendariosData oCalendariosData = null;
        private CalendariosDiasData oCalendariosDiasData = null;
        private HorarioData oHorarioData = null;
        private ReturnValor oReturnValor = null;
        public CalendariosLogic()
        {
            oCalendariosData = new CalendariosData();
            oCalendariosDiasData = new CalendariosDiasData();
            oHorarioData = new HorarioData();
            oReturnValor = new ReturnValor();
        }

        #region CALENDARIOS

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Asistencia.Calendarios
        /// En la BASE de DATO la Tabla : [Asistencia.Calendarios]
        /// <summary>
        /// <returns>List</returns>
        public List<BECalendario> List(string prm_CodigoCalendario, string prm_Descripcion, bool prm_Estado)
        {
            List<BECalendario> miLista = new List<BECalendario>();
            try
            {
                miLista = oCalendariosData.List(prm_CodigoCalendario, prm_Descripcion, prm_Estado);
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
        /// Retorna una ENTIDAD de registro de la Entidad Asistencia.Calendarios
        /// En la BASE de DATO la Tabla : [Asistencia.Calendarios]
        /// <summary>
        /// <returns>Entidad</returns>
        public BECalendario Find(string prm_CodigoCalendario, bool prm_Estado)
        {
            BECalendario miEntidad = new BECalendario();
            try
            {
                miEntidad = oCalendariosData.Find(prm_CodigoCalendario);
                miEntidad.listaCalendariosDias = oCalendariosDiasData.List(prm_CodigoCalendario, string.Empty, string.Empty, prm_Estado, HelpTMaestras.CodigoTabla(HelpTMaestras.TM.DiasDeLaSemana));
                foreach (BECalendarioDia itemCalendariosDias in miEntidad.listaCalendariosDias)
                {
                    itemCalendariosDias.itemHorario = oHorarioData.Find(itemCalendariosDias.CodigoHorario);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Calendarios
        /// En la BASE de DATO la Tabla : [Asistencia.Calendarios]
        /// <summary>
        /// <param name = >itemCalendarios</param>
        public ReturnValor Insert(BECalendario itemCalendarios)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oCalendariosData.Insert(itemCalendarios);
                    foreach (BECalendarioDia itemCalendariosDias in itemCalendarios.listaCalendariosDias)
                    {
                        oReturnValor.CodigoRetorno = oCalendariosDiasData.Insert(itemCalendariosDias);
                    }
                    if (oReturnValor.Exitosa && oReturnValor.CodigoRetorno != null)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                        tx.Complete();
                    }
                    else
                        oReturnValor.Exitosa = false;
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Calendarios
        /// En la BASE de DATO la Tabla : [Asistencia.Calendarios]
        /// <summary>
        /// <param name = >itemCalendarios</param>
        public ReturnValor Update(BECalendario itemCalendarios)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oCalendariosData.Update(itemCalendarios);
                    foreach (BECalendarioDia itemCalendariosDias in itemCalendarios.listaCalendariosDias)
                    {
                        itemCalendariosDias.CodigoCalendario = itemCalendarios.CodigoCalendario;
                        itemCalendariosDias.SegUsuarioCrea = itemCalendarios.SegUsuarioCrea;
                        itemCalendariosDias.SegUsuarioEdita = itemCalendarios.SegUsuarioEdita;
                        if (itemCalendariosDias.Registro == null)
                            oReturnValor.CodigoRetorno = oCalendariosDiasData.Insert(itemCalendariosDias);
                        else
                            oReturnValor.Exitosa = oCalendariosDiasData.Update(itemCalendariosDias);
                    }
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
        /// ELIMINA un registro de la Entidad Asistencia.Calendarios
        /// En la BASE de DATO la Tabla : [Asistencia.Calendarios]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string prm_CodigoCalendario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oCalendariosDiasData.Delete(string.Empty, prm_CodigoCalendario);
                    oReturnValor.Exitosa = oCalendariosData.Delete(prm_CodigoCalendario);
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

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo CalendariosDias
        /// En la BASE de DATO la Tabla : [Asistencia.CalendariosDias]
        /// <summary>
        /// <param name = >itemCalendariosDias</param>
        public ReturnValor Insert(BECalendarioDia itemCalendariosDias)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (itemCalendariosDias.Registro == null || itemCalendariosDias.Registro == string.Empty)
                    {
                        oReturnValor.CodigoRetorno = oCalendariosDiasData.Insert(itemCalendariosDias);
                        if (oReturnValor.CodigoRetorno != null)
                        {
                            oReturnValor.Exitosa = true;
                            oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                            tx.Complete();
                        }
                    }
                    else
                    {
                        oReturnValor.Exitosa = oCalendariosDiasData.Update(itemCalendariosDias);
                        if (oReturnValor.Exitosa)
                        {
                            oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                            tx.Complete();
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
        /// ELIMINA un registro de la Entidad Asistencia.CalendariosDias
        /// En la BASE de DATO la Tabla : [Asistencia.CalendariosDias]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string prm_Registro, string prm_CodigoCalendario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oCalendariosDiasData.Delete(prm_Registro, prm_CodigoCalendario);
                    oReturnValor.Exitosa = oCalendariosData.Delete(prm_CodigoCalendario);
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

        #endregion
    }
} 

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
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 12/01/2010-05:21:26 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Asistencia.HorarioLogic.cs]
    /// </summary>
    public class HorarioLogic
    {
        private HorarioData oHorarioData = null;
        private ReturnValor oReturnValor = null;
        public HorarioLogic()
        {
            oHorarioData = new HorarioData();
            oReturnValor = new ReturnValor();
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Asistencia.Horario
        /// En la BASE de DATO la Tabla : [Asistencia.Horario]
        /// <summary>
        /// <returns>List</returns>
        public List<BEHorario> List(string Descripcion, string CodigoArguTipoHorario, bool Estado)
        {
            List<BEHorario> miLista = new List<BEHorario>();
            try
            {
                miLista = oHorarioData.List(Descripcion, CodigoArguTipoHorario, Estado);
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
        /// Retorna una ENTIDAD de registro de la Entidad Asistencia.Horario
        /// En la BASE de DATO la Tabla : [Asistencia.Horario]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEHorario Find(int prm_CodigoHorario)
        {
            BEHorario miEntidad = new BEHorario();
            try
            {
                miEntidad = oHorarioData.Find(prm_CodigoHorario);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Horario
        /// En la BASE de DATO la Tabla : [Asistencia.Horario]
        /// <summary>
        /// <param name = >itemHorario</param>
        public ReturnValor Insert(BEHorario itemHorario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oHorarioData.Insert(itemHorario);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Horario
        /// En la BASE de DATO la Tabla : [Asistencia.Horario]
        /// <summary>
        /// <param name = >itemHorario</param>
        public ReturnValor Update(BEHorario itemHorario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oHorarioData.Update(itemHorario);
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
        /// ELIMINA un registro de la Entidad Asistencia.Horario
        /// En la BASE de DATO la Tabla : [Asistencia.Horario]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(int prm_CodigoHorario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oHorarioData.Delete(prm_CodigoHorario);
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

    }

}
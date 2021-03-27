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
    /// Archivo     : [Asistencia.JustificacionesLogic.cs]
    /// </summary>
    public class JustificacionesLogic
    {
        private JustificacionesData oJustificacionesData = null;
        private ReturnValor oReturnValor = null;
        public JustificacionesLogic()
        {
            oJustificacionesData = new JustificacionesData();
            oReturnValor = new ReturnValor();
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Asistencia.Justificaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Justificaciones]
        /// <summary>
        /// <returns>List</returns>
        public List<BEJustificacion> List(string prm_CodigoJustificacion, string prm_Descripcion, bool prm_Estado)
        {
            List<BEJustificacion> miLista = new List<BEJustificacion>();
            try
            {
                miLista = oJustificacionesData.List(prm_CodigoJustificacion, prm_Descripcion, prm_Estado);
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
        /// Retorna una ENTIDAD de registro de la Entidad Asistencia.Justificaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Justificaciones]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEJustificacion Find(string prm_CodigoJustificacion)
        {
            BEJustificacion miEntidad = new BEJustificacion();
            try
            {
                miEntidad = oJustificacionesData.Find(prm_CodigoJustificacion);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Justificaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Justificaciones]
        /// <summary>
        /// <param name = >itemJustificaciones</param>
        public ReturnValor Insert(BEJustificacion itemJustificaciones)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oJustificacionesData.Insert(itemJustificaciones);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Justificaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Justificaciones]
        /// <summary>
        /// <param name = >itemJustificaciones</param>
        public ReturnValor Update(BEJustificacion itemJustificaciones)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oJustificacionesData.Update(itemJustificaciones);
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
        /// ELIMINA un registro de la Entidad Asistencia.Justificaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Justificaciones]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string prm_CodigoJustificacion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oJustificacionesData.Delete(prm_CodigoJustificacion);
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

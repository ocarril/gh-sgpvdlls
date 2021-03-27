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
    /// Archivo     : [Asistencia.FormatosRelojesLogic.cs]
    /// </summary>
    public class FormatosRelojesLogic
    {
        private FormatosRelojesData oFormatosRelojesData = null;
        private ReturnValor oReturnValor = null;
        public FormatosRelojesLogic()
        {
            oFormatosRelojesData = new FormatosRelojesData();
            oReturnValor = new ReturnValor();
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Asistencia.FormatosRelojes
        /// En la BASE de DATO la Tabla : [Asistencia.FormatosRelojes]
        /// <summary>
        /// <returns>List</returns>
        public List<BEFormatoReloj> List(string prm_CodigoFormato, string prm_Descripcion, bool prm_Estado)
        {
            List<BEFormatoReloj> miLista = new List<BEFormatoReloj>();
            try
            {
                miLista = oFormatosRelojesData.List(prm_CodigoFormato, prm_Descripcion, prm_Estado);
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
        /// Retorna una ENTIDAD de registro de la Entidad Asistencia.FormatosRelojes
        /// En la BASE de DATO la Tabla : [Asistencia.FormatosRelojes]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEFormatoReloj Find(string prm_CodigoFormato)
        {
            BEFormatoReloj miEntidad = new BEFormatoReloj();
            try
            {
                miEntidad = oFormatosRelojesData.Find(prm_CodigoFormato);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo FormatosRelojes
        /// En la BASE de DATO la Tabla : [Asistencia.FormatosRelojes]
        /// <summary>
        /// <param name = >itemFormatosRelojes</param>
        public ReturnValor Insert(BEFormatoReloj itemFormatosRelojes)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oFormatosRelojesData.Insert(itemFormatosRelojes);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo FormatosRelojes
        /// En la BASE de DATO la Tabla : [Asistencia.FormatosRelojes]
        /// <summary>
        /// <param name = >itemFormatosRelojes</param>
        public ReturnValor Update(BEFormatoReloj itemFormatosRelojes)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oFormatosRelojesData.Update(itemFormatosRelojes);
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
        /// ELIMINA un registro de la Entidad Asistencia.FormatosRelojes
        /// En la BASE de DATO la Tabla : [Asistencia.FormatosRelojes]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string prm_CodigoFormato)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oFormatosRelojesData.Delete(prm_CodigoFormato);
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

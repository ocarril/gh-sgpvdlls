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
    /// Fecha       : 19/01/2010-11:21:54 p.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Asistencia.MarcacionesLogic.cs]
    /// </summary>
    public class MarcacionesLogic
    {
        private MarcacionesData oMarcacionesData = null;
        private ReturnValor oReturnValor = null;
        public MarcacionesLogic()
        {
            oMarcacionesData = new MarcacionesData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Asistencia.Marcaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Marcaciones]
        /// <summary>
        /// <returns>List</returns>
        public List<BEMarcacion> List(string NumeroMarcacion, DateTime prm_FechaHoraINI, DateTime prm_FechaHoraFIN)
        {
            List<BEMarcacion> miLista = new List<BEMarcacion>();
            try
            {
                miLista = oMarcacionesData.List(NumeroMarcacion, prm_FechaHoraINI, prm_FechaHoraFIN);
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
        /// Retorna una ENTIDAD de registro de la Entidad Asistencia.Marcaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Marcaciones]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEMarcacion Find(string prm_IdRegistro)
        {
            BEMarcacion miEntidad = new BEMarcacion();
            try
            {
                miEntidad = oMarcacionesData.Find(prm_IdRegistro);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Marcaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Marcaciones]
        /// <summary>
        /// <param name = >itemMarcaciones</param>
        public ReturnValor Insert(BEMarcacion itemMarcaciones)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    string FECHA_Sola = itemMarcaciones.FechaHora.ToShortDateString();
                    itemMarcaciones.FechaTexto = Convert.ToDateTime(FECHA_Sola);
                    itemMarcaciones.FechaHora = Convert.ToDateTime(FECHA_Sola + " " + itemMarcaciones.Hora + ":00");
                    if (itemMarcaciones.TeclaReloj == null) itemMarcaciones.TeclaReloj = ""; else itemMarcaciones.TeclaReloj = itemMarcaciones.TeclaReloj;

                    oReturnValor.CodigoRetorno = oMarcacionesData.Insert(itemMarcaciones);
                    if (oReturnValor.CodigoRetorno != null)
                    {
                        oReturnValor.Exitosa = true;
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

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Marcaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Marcaciones]
        /// <summary>
        /// <param name = >itemMarcaciones</param>
        public ReturnValor InsertInterno(BEMarcacion itemMarcaciones)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.CodigoRetorno = oMarcacionesData.InsertInterno(itemMarcaciones);
                    if (oReturnValor.CodigoRetorno != null)
                    {
                        oReturnValor.Exitosa = true;
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

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Marcaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Marcaciones]
        /// <summary>
        /// <param name = >itemMarcaciones</param>
        public ReturnValor Insert(List<BEMarcaje> listaMarcajes, BEFormatoReloj prmFormatosRelojes)
        {
            Int32 CONTADOR = 0;
            try
            {
                //using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                //{
                foreach (BEMarcaje itemMarcaje in listaMarcajes)
                {
                    itemMarcaje.NumeroMarcacion = itemMarcaje.NumeroMarcacion.Trim().PadLeft(prmFormatosRelojes.PosicionTarjetaFin - prmFormatosRelojes.PosicionTarjetaIni, '0');
                    if (oMarcacionesData.Find(itemMarcaje.NumeroMarcacion, itemMarcaje.FechaHora, itemMarcaje.Hora).NumeroMarcacion == null)
                    {
                        oMarcacionesData.Insert(itemMarcaje);
                        ++CONTADOR;
                    }
                }
                oReturnValor.Exitosa = true;
                if (oReturnValor.Exitosa)
                {
                    oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                    //tx.Complete();
                }
                //}
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
                oReturnValor.Message = "POSICIÓN : " + CONTADOR.ToString().PadLeft(6, '0') + " - " + oReturnValor.Message;
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Marcaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Marcaciones]
        /// <summary>
        /// <param name = >itemMarcaciones</param>
        public ReturnValor Update(BEMarcacion itemMarcaciones)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    string FECHA_Sola = itemMarcaciones.FechaHora.ToShortDateString();
                    itemMarcaciones.FechaTexto = Convert.ToDateTime(FECHA_Sola);
                    itemMarcaciones.FechaHora = Convert.ToDateTime(FECHA_Sola + " " + itemMarcaciones.Hora + ":00");
                    itemMarcaciones.Edicion = "EDT";
                    oReturnValor.Exitosa = oMarcacionesData.Update(itemMarcaciones);
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
        /// ELIMINA un registro de la Entidad Asistencia.Marcaciones
        /// En la BASE de DATO la Tabla : [Asistencia.Marcaciones]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string prm_IdRegistro)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oMarcacionesData.Delete(prm_IdRegistro);
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

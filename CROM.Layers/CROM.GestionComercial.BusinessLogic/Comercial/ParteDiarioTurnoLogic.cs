namespace CROM.GestionComercial.BusinessLogic
{
    using CROM.BusinessEntities.Comercial;
    using CROM.GestionComercial.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.settings;
    using System;
    using System.Collections.Generic;
    using System.Transactions;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [GestionComercial.ParteDiarioTurnosLogic.cs]
    /// </summary>
    public class ParteDiarioTurnoLogic
    {
        private ParteDiarioTurnoData oParteDiarioTurnosData = null;
        private ReturnValor oReturnValor = null;
       
        public ParteDiarioTurnoLogic()
        {
            oParteDiarioTurnosData = new ParteDiarioTurnoData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ParteDiarioTurnos
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiarioTurnos]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEParteDiarioTurno> List(BaseFiltro pFiltro) 
        {
            List<BEParteDiarioTurno> lstParteDiarioTurno = new List<BEParteDiarioTurno>();
            try
            {
                lstParteDiarioTurno = oParteDiarioTurnosData.List(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstParteDiarioTurno;
        }
        public List<BEParteDiarioTurno> List(BaseFiltro pFiltro, Helper.ComboBoxText pTexto) 
        {
            List<BEParteDiarioTurno> lstParteDiarioTurno = new List<BEParteDiarioTurno>();
            try
            {
                lstParteDiarioTurno = oParteDiarioTurnosData.List(pFiltro);
                if (lstParteDiarioTurno.Count > 0)
                    lstParteDiarioTurno.Insert(0, new BEParteDiarioTurno { CodigoTurno = "", Descripcion = Helper.ObtenerTexto(pTexto) });
                else
                    lstParteDiarioTurno.Add(new BEParteDiarioTurno { CodigoTurno = "", Descripcion = Helper.ObtenerTexto(pTexto) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstParteDiarioTurno;
        }
        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ParteDiarioTurnos
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiarioTurnos]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEParteDiarioTurno> ListPaged(BaseFiltro pFiltro) 
        {
            List<BEParteDiarioTurno> lstParteDiarioTurno = new List<BEParteDiarioTurno>();
            try
            {
                lstParteDiarioTurno = oParteDiarioTurnosData.ListPaged(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstParteDiarioTurno;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.ParteDiarioTurnos
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiarioTurnos]
        /// <summary>
        /// <param name="prm_CodigoTurno"></param>
        /// <returns></returns>
        public BEParteDiarioTurno Find(string prm_codEmpresa, string prm_CodigoTurno)
        {
            BEParteDiarioTurno objParteDiarioTurno = null;
            try
            {
                objParteDiarioTurno = oParteDiarioTurnosData.Find(prm_codEmpresa, prm_CodigoTurno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objParteDiarioTurno;
        }

        public BEParteDiarioTurno Find(string pcodEmpresaRUC, string prm_CodigoArguTipoTurno, string prm_CodigoArguDiaSemana)
        {
            BEParteDiarioTurno objParteDiarioTurno = null;
            try
            {
                objParteDiarioTurno = oParteDiarioTurnosData.Find(pcodEmpresaRUC, prm_CodigoArguTipoTurno, prm_CodigoArguDiaSemana);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objParteDiarioTurno;
        }
  
        public BEParteDiarioTurno FindTurnoActual(string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta)
        {
            string sdia = string.Empty;
            string CodiDia = HelpTime.DiaDeLaSemana(DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()), out sdia).ToString().Trim().PadLeft(3, '0');
            BEParteDiarioTurno itemTurno = new BEParteDiarioTurno();
            ParteDiarioTurnoLogic oParteDiarioTurnosLogic = new ParteDiarioTurnoLogic();
            List<BEParteDiarioTurno> listaParteDiarioTurnos = new List<BEParteDiarioTurno>();

            listaParteDiarioTurnos = oParteDiarioTurnosLogic.List(new BaseFiltro
                                                                {
                                                                 codEmpresaRUC = prm_CodigoPersonaEmpre
                                                                ,codPuntoVenta = prm_CodigoPuntoVenta
                                                                ,codRegTipoTurno = string.Empty
                                                                ,desNombre = string.Empty
                                                                ,codRegDiaSemana = HelpTMaestras.CodigoTabla(HelpTMaestras.TM.DiasDeLaSemana) + CodiDia
                                                                ,indEstado = true
                                                                });
            foreach (BEParteDiarioTurno iPDT in listaParteDiarioTurnos)
            {
                double horaActual = HelpTime.CantidadTiempoEn_DECIMAL(DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).ToShortTimeString());
                double horaInicio = HelpTime.CantidadTiempoEn_DECIMAL(iPDT.HoraDeInicio);
                double horaFinal = HelpTime.CantidadTiempoEn_DECIMAL(iPDT.HoraDeFinal);
                if (horaActual >= horaInicio && horaActual < horaFinal)
                {
                    itemTurno = iPDT;
                    break;
                }
                else
                {
                    iPDT.HoraDeInicio = DateTime.Now.ToShortTimeString().Substring(0, 5);
                    itemTurno = iPDT;
                }
            }
            return itemTurno;
        }

        #endregion

        #region /* Proceso de INSERT-UPDATE RECORD */

        public ReturnValor Save(BEParteDiarioTurno objParteDiarioTurno)
        {
            if (string.IsNullOrEmpty(objParteDiarioTurno.CodigoTurno))
                oReturnValor = Insert(objParteDiarioTurno);
            else
                oReturnValor = Update(objParteDiarioTurno);
            return oReturnValor;
        }

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ParteDiarioTurnos
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiarioTurnos]
        /// <summary>
        /// <param name="objParteDiarioTurno"></param>
        /// <returns></returns>
        private ReturnValor Insert(BEParteDiarioTurno objParteDiarioTurno)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.CodigoRetorno = oParteDiarioTurnosData.Insert(objParteDiarioTurno);
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

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ParteDiarioTurnos
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiarioTurnos]
        /// <summary>
        /// <param name="objParteDiarioTurno"></param>
        /// <returns></returns>
        private ReturnValor Update(BEParteDiarioTurno objParteDiarioTurno)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oParteDiarioTurnosData.Update(objParteDiarioTurno);
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
        /// ELIMINA un registro de la Entidad GestionComercial.ParteDiarioTurnos
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiarioTurnos]
        /// <summary>
        /// <param name="prm_CodigoTurno"></param>
        /// <returns></returns>
        public ReturnValor Delete(string prm_CodigoTurno)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oParteDiarioTurnosData.Delete(prm_CodigoTurno);
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

namespace CROM.GestionComercial.BusinessLogic
{
    using CROM.BusinessEntities.Cajas;
    using CROM.BusinessEntities.Comercial;
    using CROM.GestionComercial.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Transactions;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [GestionComercial.ParteDiarioLogic.cs]
    /// </summary>
    public class ParteDiarioLogic
    {
        private ParteDiarioData oParteDiarioData = null;
        private ReturnValor oReturnValor = null;
        public ParteDiarioLogic()
        {
            oParteDiarioData = new ParteDiarioData();
            oReturnValor = new ReturnValor();
        }
       
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <returns>List</returns>
        public List<BEParteDiario> List(Nullable<DateTime> prm_FechaParteInicio, Nullable<DateTime> prm_FechaParteFinal, string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, int? prm_codEmpleado, string prm_CodigoTurno, bool prm_Estado)
        {
            List<BEParteDiario> listaParteDiario = new List<BEParteDiario>();
            try
            {
                listaParteDiario = oParteDiarioData.List(HelpTime.ConvertYYYYMMDD(prm_FechaParteInicio), HelpTime.ConvertYYYYMMDD(prm_FechaParteFinal), prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta, prm_codEmpleado, prm_CodigoTurno, prm_Estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaParteDiario;
        }
        public List<BEParteDiario> List(Nullable<DateTime> prm_FechaParteInicio, Nullable<DateTime> prm_FechaParteFinal, string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, int? prm_codEmpleado, string prm_CodigoTurno, bool prm_Estado, Helper.ComboBoxText pTexto)
        {
            List<BEParteDiario> listaParteDiario = new List<BEParteDiario>();
            try
            {
                listaParteDiario = oParteDiarioData.List(HelpTime.ConvertYYYYMMDD(prm_FechaParteInicio), HelpTime.ConvertYYYYMMDD(prm_FechaParteFinal), prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta, prm_codEmpleado, prm_CodigoTurno, prm_Estado);
                if (listaParteDiario.Count > 0)
                    listaParteDiario.Insert(0, new BEParteDiario { CodigoParte = "", CodigoParteAux = Helper.ObtenerTexto(pTexto) });
                else
                    listaParteDiario.Add(new BEParteDiario { CodigoParte = "", CodigoParteAux = Helper.ObtenerTexto(pTexto) });

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaParteDiario;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEParteDiario Find(string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, string prm_CodigoParte)
        {
            BEParteDiario objParteDiario = new BEParteDiario();
            try
            {
                objParteDiario = oParteDiarioData.Find(prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta, prm_CodigoParte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objParteDiario;
        }

        public List<BEParteDiario> ListCajas(string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, string prm_CodigoParte, Nullable<DateTime> prm_FechaParte, string prm_CodigoTurno, int? prm_codEmpleado, bool? prm_CajaActiva)
        {
            List<BEParteDiario> parteDiario = new List<BEParteDiario>();
            try
            {
                parteDiario = oParteDiarioData.ListCajas(prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta, prm_CodigoParte, HelpTime.ConvertYYYYMMDD(prm_FechaParte), prm_CodigoTurno, prm_codEmpleado, prm_CajaActiva);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return parteDiario;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <param name = >itemParteDiario</param>
        public ReturnValor Insert(BEParteDiario parteDiario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    List<BEParteDiario> buscadoParteDiario = new List<BEParteDiario>();
                    buscadoParteDiario = oParteDiarioData.ListCajas(parteDiario.CodigoPersonaEmpre, parteDiario.CodigoPuntoVenta, string.Empty, string.Empty, string.Empty, parteDiario.codEmpleado, true);
                    int? p_codEmpleado = null;
                    string p_nomEmpleado = string.Empty;
                    string p_codParte = string.Empty;
                    int ContadorIgual = 0;
                    int ContadorDifer = 0;
                    foreach (BEParteDiario xParte in buscadoParteDiario)
                    {
                        if (xParte.CajaActiva)
                        {
                            p_codEmpleado = xParte.codEmpleado;
                            p_nomEmpleado = xParte.codEmpleadoNombre;
                            p_codParte = xParte.CodigoParte;
                            if (xParte.FechaParte.ToShortDateString() != parteDiario.FechaParte.ToShortDateString())
                                ++ContadorDifer;
                            else
                            {
                                ++ContadorIgual;
                                break;
                            }
                        }
                    }
                    if (ContadorDifer == 0)
                    {
                        if (ContadorIgual == 1)
                        {
                            oReturnValor.Exitosa = true;
                            oReturnValor.CodigoRetorno = p_codParte;
                        }
                        else
                        {
                            oReturnValor.CodigoRetorno = oParteDiarioData.Insert(parteDiario);
                            if (oReturnValor.CodigoRetorno != null)
                            {
                                oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                                oReturnValor.Exitosa = true;
                                tx.Complete();
                            }
                        }
                    }
                    else if (ContadorDifer == 1)
                    {
                        oReturnValor.Exitosa = false;
                        if (buscadoParteDiario[0].FechaParte.ToShortDateString() == parteDiario.FechaParte.ToShortDateString())
                        {
                            oReturnValor.CodigoRetorno = buscadoParteDiario[0].CodigoParte;
                            oReturnValor.Message = "[ " + p_codEmpleado + " - " + p_nomEmpleado + " ]. ¡Contador == 1 Tiene registro caja de parte diario sin CERRAR, el día de HOY !";
                        }
                        else
                            oReturnValor.Message = "[ " + p_codEmpleado + " - " + p_nomEmpleado + " ]. ¡ " + buscadoParteDiario[0].FechaParte.ToShortDateString() + " == " + parteDiario.FechaParte.ToShortDateString() + " - Tiene registro caja de parte diario sin CERRAR, Por favor cerrar !";
                    }
                    else
                        oReturnValor.Message = " [ " + p_codEmpleado + " - " + p_nomEmpleado + " ]. ¡Contador == " + ContadorDifer.ToString() + " Tiene registro caja de parte diario sin CERRAR, Por favor cerrar !";
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
                oReturnValor.Message = " [ No se ha generado parte diario. ] - " + oReturnValor.Message;
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <param name = >itemParteDiario</param>
        public ReturnValor Update(BEParteDiario itemParteDiario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oParteDiarioData.Update(itemParteDiario);
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

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <param name = >itemParteDiario</param>
        public ReturnValor UpdateCajaActiva(BEParteDiario itemParteDiario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    itemParteDiario.FechaParteYYYMMDD = HelpTime.ConvertYYYYMMDD(itemParteDiario.FechaParte);
                    oReturnValor.Exitosa = oParteDiarioData.UpdateCajaActiva(itemParteDiario);
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

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <param name = >itemParteDiario</param>
        public ReturnValor UpdateCajaCierre(BEParteDiario itemParteDiario)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    CajaRegistroData oCajaRegistroData = new CajaRegistroData();

                    bool SUCEDE_CONCILIADO = true;
                    oReturnValor.Exitosa = oParteDiarioData.UpdateCajaClose(itemParteDiario);
                    foreach (CajaRegistroAux xCajReg in itemParteDiario.listaCajaRegistro)
                    {
                        xCajReg.indConciliado = true;
                        xCajReg.segUsuarioEdita = itemParteDiario.segUsuarioEdita;
                        SUCEDE_CONCILIADO = oCajaRegistroData.UpdateCajaClose(xCajReg);
                        if (SUCEDE_CONCILIADO == false)
                            break;
                    }

                    if (oReturnValor.Exitosa && SUCEDE_CONCILIADO)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
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

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, string prm_CodigoParte)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oParteDiarioData.Delete(prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta, prm_CodigoParte);
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

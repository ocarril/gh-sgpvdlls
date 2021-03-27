namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.ParteDiarioData.cs]
    /// </summary>
    public class ParteDiarioData
    {
        private string conexion = string.Empty;
        public ParteDiarioData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <param name = >itemParteDiario</param>
        public string Insert(BEParteDiario parteDiario)
        {
            string codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_I_ParteDiario(
                        ref codigoRetorno,
                        parteDiario.CodigoPersonaEmpre,
                        parteDiario.CodigoPuntoVenta,
                        parteDiario.FechaParte,
                        parteDiario.codEmpleado,
                        parteDiario.Observaciones,
                        parteDiario.CodigoTurno,
                        Convert.ToChar(parteDiario.Turno),
                        parteDiario.CajaActiva,
                        parteDiario.Caja,
                        parteDiario.Estado,
                        parteDiario.segUsuarioCrea);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <param name = >itemParteDiario</param>
        public bool Update(BEParteDiario parteDiario)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_ParteDiario(
                        parteDiario.CodigoParte,
                        parteDiario.CodigoPersonaEmpre,
                        parteDiario.CodigoPuntoVenta,
                        parteDiario.FechaParte,
                        parteDiario.codEmpleado,
                        parteDiario.Observaciones,
                        parteDiario.CodigoTurno,
                        Convert.ToChar(parteDiario.Turno),
                        parteDiario.CajaActiva,
                        parteDiario.Caja,
                        parteDiario.Estado,
                        parteDiario.segUsuarioEdita);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        /// <summary>
        /// ACTUALIZA el registro de una ENTIDAD de registro de Tipo ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <param name = >itemParteDiario</param>
        public bool UpdateCajaActiva(BEParteDiario parteDiario)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_ParteDiario_CajaActiva(
                        parteDiario.CodigoPersonaEmpre,
                        parteDiario.CodigoPuntoVenta,
                        parteDiario.codEmpleado,
                        parteDiario.CodigoParte,
                        parteDiario.CodigoTurno,
                        parteDiario.FechaParteYYYMMDD,
                        parteDiario.segUsuarioEdita);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        /// <summary>
        /// ACTUALIZA el registro de una ENTIDAD de registro de Tipo ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <param name = >itemParteDiario</param>
        public bool UpdateCajaClose(BEParteDiario parteDiario)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_ParteDiario_Close(
                        parteDiario.CodigoParte,
                        parteDiario.CodigoPersonaEmpre,
                        parteDiario.CodigoPuntoVenta,
                        parteDiario.segUsuarioEdita,
                        parteDiario.TotalIngreso,
                        parteDiario.TotalEgreso
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, string prm_CodigoParte)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_ParteDiario(prm_CodigoPersonaEmpre, 
                                                             prm_CodigoPuntoVenta, 
                                                             prm_CodigoParte);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ParteDiario
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiario]
        /// <summary>
        /// <returns>List</returns>
        public List<BEParteDiario> List(string prm_FechaParteInicio, string prm_FechaParteFinal, string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, int? prm_codEmpleado, string prm_CodigoTurno, bool prm_Estado)
        {
            List<BEParteDiario> listaParteDiario = new List<BEParteDiario>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ParteDiario(prm_FechaParteInicio, 
                                                         prm_FechaParteFinal, 
                                                         prm_CodigoPersonaEmpre, 
                                                         prm_CodigoPuntoVenta, 
                                                         prm_codEmpleado, 
                                                         prm_CodigoTurno, 
                                                         prm_Estado);
                    foreach (var item in resul)
                    {
                        listaParteDiario.Add(new BEParteDiario()
                        {
                            CodigoParte = item.CodigoParte,
                            CodigoPersonaEmpre = item.CodigoPersonaEmpre,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            FechaParte = item.FechaParte,
                            codEmpleado = item.codEmpleado,
                            Observaciones = item.Observaciones,
                            CodigoTurno = item.CodigoTurno,
                            Turno = item.Turno.ToString(),
                            CajaActiva = item.CajaActiva,
                            Caja = item.Caja,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaCrea = item.SegMaquina,
                            codEmpleadoNombre = item.codEmpleadoNombre,
                            CodigoPersonaEmpreNombre = item.CodigoPersonaEmpreNombre,
                            CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
                            CodigoTurnoNombre = item.CodigoTurnoNombre,
                            Descripcion = item.FechaParte.ToShortDateString() + "-" + item.CodigoParte + "-" + item.CodigoTurnoNombre,
                            Horario = item.Horario,
                            TotalIngreso = item.TotalIngreso,
                            TotalEgreso = item.TotalEgreso,
                            TotalSaldo = item.TotalSaldo == null ? 0 : Convert.ToDecimal(item.TotalSaldo),
                            CodigoParteAux = item.CodigoParte,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaParteDiario;
        }
        public List<BEParteDiario> ListCajas(string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, string prm_CodigoParte, string prm_FechaParte, string prm_CodigoTurno, int? prm_codEmpleado, bool? prm_CajaActiva)
        {
            List<BEParteDiario> listaParteDiario = new List<BEParteDiario>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ParteDiario_CajaActiva(prm_CodigoPersonaEmpre, 
                                                                    prm_CodigoPuntoVenta, 
                                                                    prm_CodigoParte, 
                                                                    prm_FechaParte, 
                                                                    prm_CodigoTurno, 
                                                                    prm_codEmpleado, 
                                                                    prm_CajaActiva);
                    foreach (var item in resul)
                    {
                        listaParteDiario.Add(new BEParteDiario()
                        {
                            CodigoParte = item.CodigoParte,
                            CodigoPersonaEmpre = item.CodigoPersonaEmpre,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            FechaParte = item.FechaParte,
                            codEmpleado = item.codEmpleado,
                            Observaciones = item.Observaciones,
                            CodigoTurno = item.CodigoTurno,
                            Turno = item.Turno.ToString(),
                            CajaActiva = item.CajaActiva,
                            Caja = item.Caja,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaCrea = item.SegMaquina,
                            codEmpleadoNombre = item.codEmpleadoNombre,
                            CodigoPersonaEmpreNombre = item.CodigoPersonaEmpreNombre,
                            CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
                            CodigoTurnoNombre = item.CodigoTurnoNombre,
                            Descripcion = item.FechaParte.ToShortDateString() + "-" + item.CodigoParte + "-" + item.CodigoTurnoNombre,
                            CodigoParteAux = item.CodigoParte,
                        });
                    }
                }
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
            BEParteDiario parteDiario = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ParteDiario_codParte(prm_CodigoPersonaEmpre, 
                                                                  prm_CodigoPuntoVenta,
                                                                  prm_CodigoParte);
                    foreach (var item in resul)
                    {
                        parteDiario = new BEParteDiario()
                        {
                            CodigoParte = item.CodigoParte,
                            CodigoPersonaEmpre = item.CodigoPersonaEmpre,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            FechaParte = item.FechaParte,
                            codEmpleado = item.codEmpleado,
                            Observaciones = item.Observaciones,
                            CodigoTurno = item.CodigoTurno,
                            Turno = item.Turno.ToString(),
                            CajaActiva = item.CajaActiva,
                            Caja = item.Caja,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaCrea = item.SegMaquina,
                            codEmpleadoNombre = item.codEmpleadoNombre,
                            CodigoPersonaEmpreNombre = item.CodigoPersonaEmpreNombre,
                            CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
                            CodigoTurnoNombre = item.CodigoTurnoNombre,
                            CodigoParteAux = item.CodigoParte,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return parteDiario;
        }

        #endregion

    }
} 

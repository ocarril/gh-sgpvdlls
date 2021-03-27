namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.ParteDiarioTurnosData.cs]
    /// </summary>
    public class ParteDiarioTurnoData
    {
        private string conexion = string.Empty;

        public ParteDiarioTurnoData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ParteDiarioTurnos
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiarioTurnos]
        /// <summary>
        /// <param name="objParteDiarioTurno"></param>
        /// <returns></returns>
        public string Insert(BEParteDiarioTurno objParteDiarioTurno)
        {
            string codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_I_ParteDiarioTurno(
                       ref codigoRetorno,
                       objParteDiarioTurno.CodigoPersonaEmpre,
                       objParteDiarioTurno.CodigoPuntoVenta,
                       objParteDiarioTurno.CodigoArguTipoTurno,
                       objParteDiarioTurno.CodigoArguDiaSemana,
                       objParteDiarioTurno.Descripcion,
                       objParteDiarioTurno.HoraDeInicio,
                       objParteDiarioTurno.HoraDeFinal,
                       objParteDiarioTurno.Estado,
                       objParteDiarioTurno.segUsuarioCrea,
                       objParteDiarioTurno.segMaquinaCrea
                       );
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo ParteDiarioTurnos
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiarioTurnos]
        /// <summary>
        /// <param name="objParteDiarioTurnos"></param>
        /// <returns></returns>
        public bool Update(BEParteDiarioTurno objParteDiarioTurnos)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                     SQLDC.omgc_U_ParteDiarioTurno(
                        objParteDiarioTurnos.CodigoTurno,
                        objParteDiarioTurnos.CodigoPersonaEmpre,
                        objParteDiarioTurnos.CodigoPuntoVenta,
                        objParteDiarioTurnos.CodigoArguTipoTurno,
                        objParteDiarioTurnos.CodigoArguDiaSemana,
                        objParteDiarioTurnos.Descripcion,
                        objParteDiarioTurnos.HoraDeInicio,
                        objParteDiarioTurnos.HoraDeFinal,
                        objParteDiarioTurnos.Estado,
                        objParteDiarioTurnos.segUsuarioEdita,
                        objParteDiarioTurnos.segMaquinaEdita
                        );
                     codigoRetorno = 0;
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
        /// ELIMINA un registro de la Entidad GestionComercial.ParteDiarioTurnos
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiarioTurnos]
        /// <summary>
        /// <param name="prm_CodigoTurno"></param>
        /// <returns></returns>
        public bool Delete(string prm_CodigoTurno)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_D_ParteDiarioTurno(prm_CodigoTurno);
                    codigoRetorno = 0;
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
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ParteDiarioTurno(pFiltro.codEmpresaRUC
                                                              , null
                                                              , pFiltro.codPuntoVenta
                                                              , pFiltro.codRegTipoTurno 
                                                              , pFiltro.desNombre 
                                                              , pFiltro.codRegDiaSemana
                                                              , pFiltro.indEstado);
                    foreach (var item in resul)
                    {
                        BEParteDiarioTurno objParteDiarioTurno = new BEParteDiarioTurno();
                        objParteDiarioTurno.CodigoTurno = item.CodigoTurno;
                        objParteDiarioTurno.CodigoArguTipoTurno = item.CodigoArguTipoTurno;
                        objParteDiarioTurno.CodigoArguDiaSemana = item.CodigoArguDiaSemana;
                        objParteDiarioTurno.Descripcion = item.Descripcion;
                        objParteDiarioTurno.HoraDeInicio = item.HoraDeInicio;
                        objParteDiarioTurno.HoraDeFinal = item.HoraDeFinal;
                        objParteDiarioTurno.Estado = item.Estado;
                        objParteDiarioTurno.segUsuarioCrea = item.SegUsuarioCrea;
                        objParteDiarioTurno.segUsuarioEdita = item.SegUsuarioEdita;
                        objParteDiarioTurno.segFechaCrea = item.SegFechaCrea;
                        objParteDiarioTurno.segFechaEdita = item.SegFechaEdita;
                        objParteDiarioTurno.segMaquinaCrea = item.SegMaquina;
                        objParteDiarioTurno.segMaquinaEdita = item.SegMaquina;
                        objParteDiarioTurno.CodigoArguTipoTurnoNombre = item.CodigoArguTipoTurnoNombre;
                        objParteDiarioTurno.CodigoArguDiaSemanaNombre = item.CodigoArguDiaSemanaNombre;
                        objParteDiarioTurno.CodigoPersonaEmpre = item.CodigoPuntoVenta;
                        objParteDiarioTurno.CodigoPuntoVenta = item.CodigoPuntoVenta;
                        objParteDiarioTurno.objDiaSemana.desNombre = item.CodigoArguDiaSemanaNombre;
                        objParteDiarioTurno.objTipo.desNombre = item.CodigoArguTipoTurnoNombre;
                        objParteDiarioTurno.objPuntoDeVenta.desNombre = item.CodigoPuntoVentaNombre;
                        objParteDiarioTurno.objEmpresa.RazonSocial = item.CodigoPersonaEmpreNombre;

                        lstParteDiarioTurno.Add(objParteDiarioTurno);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstParteDiarioTurno;
        }
        public List<BEParteDiarioTurno> ListPaged(BaseFiltro pFiltro)
        {
            List<BEParteDiarioTurno> lstParteDiarioTurno = new List<BEParteDiarioTurno>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ParteDiarioTurno_Paged(pFiltro.grcurrentPage
                                                                  , pFiltro.grpageSize
                                                                  , pFiltro.grsortColumn
                                                                  , pFiltro.grsortOrder
                                                                  , pFiltro.codEmpresaRUC
                                                                  , null
                                                                  , pFiltro.codPuntoVenta
                                                                  , pFiltro.codRegTipoTurno
                                                                  , pFiltro.desNombre
                                                                  , pFiltro.codRegDiaSemana
                                                                  , pFiltro.indEstado);
                    foreach (var item in resul)
                    {
                        BEParteDiarioTurno objParteDiarioTurno = new BEParteDiarioTurno();
                        objParteDiarioTurno.ROW = item.ROWNUM.HasValue?item.ROWNUM.Value:0;
                        objParteDiarioTurno.TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0;
                        objParteDiarioTurno.CodigoTurno = item.CodigoTurno;
                        objParteDiarioTurno.CodigoArguTipoTurno = item.CodigoArguTipoTurno;
                        objParteDiarioTurno.CodigoArguDiaSemana = item.CodigoArguDiaSemana;
                        objParteDiarioTurno.Descripcion = item.Descripcion;
                        objParteDiarioTurno.HoraDeInicio = item.HoraDeInicio;
                        objParteDiarioTurno.HoraDeFinal = item.HoraDeFinal;
                        objParteDiarioTurno.Estado = item.Estado;
                        objParteDiarioTurno.segUsuarioCrea = item.SegUsuarioCrea;
                        objParteDiarioTurno.segUsuarioEdita = item.SegUsuarioEdita;
                        objParteDiarioTurno.segFechaCrea = item.SegFechaCrea;
                        objParteDiarioTurno.segFechaEdita = item.SegFechaEdita;
                        objParteDiarioTurno.segMaquinaCrea = item.SegMaquina;
                        objParteDiarioTurno.segMaquinaEdita = item.SegMaquina;
                        objParteDiarioTurno.CodigoArguTipoTurnoNombre = item.CodigoArguTipoTurnoNombre;
                        objParteDiarioTurno.CodigoArguDiaSemanaNombre = item.CodigoArguDiaSemanaNombre;
                        objParteDiarioTurno.CodigoPersonaEmpre = item.CodigoPuntoVenta;
                        objParteDiarioTurno.CodigoPuntoVenta = item.CodigoPuntoVenta;
                        objParteDiarioTurno.objDiaSemana.desNombre = item.CodigoArguDiaSemanaNombre;
                        objParteDiarioTurno.objTipo.desNombre = item.CodigoArguTipoTurnoNombre;
                        objParteDiarioTurno.objPuntoDeVenta.desNombre = item.CodigoPuntoVentaNombre;
                        objParteDiarioTurno.objEmpresa.RazonSocial = item.CodigoPersonaEmpreNombre;

                        lstParteDiarioTurno.Add(objParteDiarioTurno);
                    }
                }
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
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ParteDiarioTurno(prm_codEmpresa, prm_CodigoTurno, null, null, null, null, null);
                    foreach (var item in resul)
                    {
                        objParteDiarioTurno = new BEParteDiarioTurno();
                        objParteDiarioTurno.CodigoTurno = item.CodigoTurno;
                        objParteDiarioTurno.CodigoArguTipoTurno = item.CodigoArguTipoTurno;
                        objParteDiarioTurno.CodigoArguDiaSemana = item.CodigoArguDiaSemana;
                        objParteDiarioTurno.Descripcion = item.Descripcion;
                        objParteDiarioTurno.HoraDeInicio = item.HoraDeInicio;
                        objParteDiarioTurno.HoraDeFinal = item.HoraDeFinal;
                        objParteDiarioTurno.Estado = item.Estado;
                        objParteDiarioTurno.segUsuarioCrea = item.SegUsuarioCrea;
                        objParteDiarioTurno.segUsuarioEdita = item.SegUsuarioEdita;
                        objParteDiarioTurno.segFechaCrea = item.SegFechaCrea;
                        objParteDiarioTurno.segFechaEdita = item.SegFechaEdita;
                        objParteDiarioTurno.segMaquinaCrea = item.SegMaquina;
                        objParteDiarioTurno.segMaquinaEdita = item.SegMaquina;
                        objParteDiarioTurno.CodigoArguTipoTurnoNombre = item.CodigoArguTipoTurnoNombre;
                        objParteDiarioTurno.CodigoArguDiaSemanaNombre = item.CodigoArguDiaSemanaNombre;
                        objParteDiarioTurno.CodigoPersonaEmpre = item.CodigoPersonaEmpre;
                        objParteDiarioTurno.CodigoPuntoVenta = item.CodigoPuntoVenta;

                        objParteDiarioTurno.objDiaSemana.desNombre = item.CodigoArguDiaSemanaNombre;
                        objParteDiarioTurno.objTipo.desNombre = item.CodigoArguTipoTurnoNombre;
                        objParteDiarioTurno.objPuntoDeVenta.desNombre = item.CodigoPuntoVentaNombre;
                        objParteDiarioTurno.objEmpresa.RazonSocial = item.CodigoPersonaEmpreNombre;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objParteDiarioTurno;
        }

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.ParteDiarioTurnos
        /// En la BASE de DATO la Tabla : [GestionComercial.ParteDiarioTurnos]
        /// <summary>
        /// <param name="prm_CodigoArguTipoTurno"></param>
        /// <param name="prm_CodigoArguDiaSemana"></param>
        /// <returns></returns>
        public BEParteDiarioTurno Find(string pcodEmpresaRUC, string prm_CodigoArguTipoTurno, string prm_CodigoArguDiaSemana)
        {
            BEParteDiarioTurno objParteDiarioTurno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ParteDiarioTurno(pcodEmpresaRUC, null, null, prm_CodigoArguTipoTurno, null, prm_CodigoArguDiaSemana, null);
                    foreach (var item in resul)
                    {
                        objParteDiarioTurno = new BEParteDiarioTurno();
                        objParteDiarioTurno.CodigoTurno = item.CodigoTurno;
                        objParteDiarioTurno.CodigoArguTipoTurno = item.CodigoArguTipoTurno;
                        objParteDiarioTurno.CodigoArguDiaSemana = item.CodigoArguDiaSemana;
                        objParteDiarioTurno.Descripcion = item.Descripcion;
                        objParteDiarioTurno.HoraDeInicio = item.HoraDeInicio;
                        objParteDiarioTurno.HoraDeFinal = item.HoraDeFinal;
                        objParteDiarioTurno.Estado = item.Estado;
                        objParteDiarioTurno.segUsuarioCrea = item.SegUsuarioCrea;
                        objParteDiarioTurno.segUsuarioEdita = item.SegUsuarioEdita;
                        objParteDiarioTurno.segFechaCrea = item.SegFechaCrea;
                        objParteDiarioTurno.segFechaEdita = item.SegFechaEdita;
                        objParteDiarioTurno.segMaquinaCrea = item.SegMaquina;
                        objParteDiarioTurno.segMaquinaEdita = item.SegMaquina;
                        objParteDiarioTurno.CodigoArguTipoTurnoNombre = item.CodigoArguTipoTurnoNombre;
                        objParteDiarioTurno.CodigoArguDiaSemanaNombre = item.CodigoArguDiaSemanaNombre;
                        objParteDiarioTurno.CodigoPersonaEmpre = item.CodigoPuntoVenta;
                        objParteDiarioTurno.CodigoPuntoVenta = item.CodigoPuntoVenta;

                        objParteDiarioTurno.objDiaSemana.desNombre = item.CodigoArguDiaSemanaNombre;
                        objParteDiarioTurno.objTipo.desNombre = item.CodigoArguTipoTurnoNombre;
                        objParteDiarioTurno.objPuntoDeVenta.desNombre = item.CodigoPuntoVentaNombre;
                        objParteDiarioTurno.objEmpresa.RazonSocial = item.CodigoPersonaEmpreNombre;

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objParteDiarioTurno;
        }

        #endregion

    }
} 

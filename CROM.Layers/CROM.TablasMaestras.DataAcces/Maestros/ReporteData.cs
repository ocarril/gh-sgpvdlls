namespace CROM.TablasMaestras.DataAcces
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Maestros;
    using CROM.BusinessEntities;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Maestros.ReportesSistemaData.cs]
    /// </summary>
    public class ReporteData
    {
        private string conexion = string.Empty;
        public ReporteData()
        {
            conexion = Util.ConexionBD();
        }
        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ReportesSistema
        /// En la BASE de DATO la Tabla : [Maestros.ReportesSistema]
        /// <summary>
        /// <param name = >itemReportesSistema</param>
        public string Insert(BEReporteSistema itemReportesSistema)
        {
            string codigoRetorno = null;
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    SQLDC.omgc_I_Reporte(
                    ref codigoRetorno,
                    itemReportesSistema.ReporteName,
                    itemReportesSistema.CodigoSistema,
                    itemReportesSistema.NombreArchivoRDLC,
                    itemReportesSistema.TipodeReporte,
                    itemReportesSistema.Orden,
                    itemReportesSistema.Estado,
                    itemReportesSistema.OtroDato,
                    itemReportesSistema.SegUsuarioCrea,
                    itemReportesSistema.CodigoSistema);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo ReportesSistema
        /// En la BASE de DATO la Tabla : [Maestros.ReportesSistema]
        /// <summary>
        /// <param name = >itemReportesSistema</param>
        public bool Update(BEReporteSistema itemReportesSistema)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_Reporte(
                        itemReportesSistema.CodigoReporte,
                        itemReportesSistema.ReporteName,
                        itemReportesSistema.CodigoSistema,
                        itemReportesSistema.NombreArchivoRDLC,
                        itemReportesSistema.TipodeReporte,
                        itemReportesSistema.Orden,
                        itemReportesSistema.Estado,
                        itemReportesSistema.OtroDato,
                        itemReportesSistema.SegUsuarioEdita);
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
        /// ELIMINA un registro de la Entidad Maestros.ReportesSistema
        /// En la BASE de DATO la Tabla : [Maestros.ReportesSistema]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(string prm_CodigoReporte)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_Reporte(prm_CodigoReporte);
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
        /// Retorna un LISTA de registros de la Entidad Maestros.ReportesSistema
        /// En la BASE de DATO la Tabla : [Maestros.ReportesSistema]
        /// <summary>
        /// <returns>List</returns>
        public List<BEReporteSistema> List(string prm_ReporteName, string prm_TipodeReporte, bool? prm_Estado, string prm_CodigoSistema)
        {
            List<BEReporteSistema> lstReporte = new List<BEReporteSistema>();
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Reporte(prm_ReporteName, prm_TipodeReporte, prm_Estado, prm_CodigoSistema);
                    foreach (var item in resul)
                    {
                        lstReporte.Add(new BEReporteSistema()
                        {
                            CodigoReporte = item.CodigoReporte,
                            ReporteName = item.ReporteName,
                            CodigoSistema = item.CodigoSistema,
                            NombreArchivoRDLC = item.NombreArchivoRDLC,
                            TipodeReporte = item.TipodeReporte,
                            Orden = item.Orden,
                            Estado = item.Estado,
                            OtroDato = item.OtroDato,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegFechaHoraEdita = item.SegFechaHoraEdita,
                            SegMaquinaOrigen = item.SegMaquinaOrigen,

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstReporte;
        }

        public List<BEReporteSistema> List(BaseFiltroMaestro filtro)
        {
            List<BEReporteSistema> lstReporteSistema = new List<BEReporteSistema>();
            try
            {
                using (_DBMLTablasDataContext oMaestrosDC = new _DBMLTablasDataContext(conexion))
                {
                    var resul = oMaestrosDC.omgc_S_Reporte_Paged(filtro.GNumPagina, filtro.GTamPagina, filtro.GOrdenPor, filtro.GOrdenTipo, filtro.desNombre, filtro.codigoEntidad, filtro.codTipo01, filtro.indActivo);
                    foreach (var item in resul)
                    {
                        lstReporteSistema.Add(new BEReporteSistema()
                        {

                            CodigoReporte = item.CodigoReporte,
                            CodigoSistema = item.CodigoSistema,
                            Estado = item.Estado,
                            ReporteName = item.ReporteName,
                            NombreArchivoRDLC = item.NombreArchivoRDLC,
                            Orden = item.Orden,
                            OtroDato = item.OtroDato,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegFechaHoraEdita = item.SegFechaHoraEdita,
                            SegMaquinaOrigen = item.SegMaquinaOrigen,
                            TipodeReporte = item.TipodeReporte,

                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstReporteSistema;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestros.ReportesSistema
        /// En la BASE de DATO la Tabla : [Maestros.ReportesSistema]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEReporteSistema Find(string prm_CodigoReporte)
        {
            BEReporteSistema miEntidad = new BEReporteSistema();
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Reporte_Id(prm_CodigoReporte);
                    foreach (var item in resul)
                    {
                        miEntidad = new BEReporteSistema()
                        {
                            CodigoReporte = item.CodigoReporte,
                            ReporteName = item.ReporteName,
                            CodigoSistema = item.CodigoSistema,
                            NombreArchivoRDLC = item.NombreArchivoRDLC,
                            TipodeReporte = item.TipodeReporte,
                            Orden = item.Orden,
                            Estado = item.Estado,
                            OtroDato = item.OtroDato,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegFechaHoraEdita = item.SegFechaHoraEdita,
                            SegMaquinaOrigen = item.SegMaquinaOrigen,

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miEntidad;
        }

        #endregion

    }
}

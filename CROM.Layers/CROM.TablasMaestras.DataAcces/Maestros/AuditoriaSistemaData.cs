namespace CROM.TablasMaestras.DataAcces
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Maestros;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 09/07/2010-11:33:49 
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Maestras.AuditoriaSistema.cs]
    /// </summary>
    public class AuditoriaSistemaData
    {
        private string conexion = string.Empty;

        public AuditoriaSistemaData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Maestras.TFeriados
        /// En la BASE de DATO la Tabla : [Maestras.TFeriados]
        /// <summary>
        /// <returns>List</returns>
        public List<BEAuditoriaSistema> List(string prm_FechaInicio, string prm_FechaFin)
        {
            List<BEAuditoriaSistema> lstAuditoriaSistema = new List<BEAuditoriaSistema>();
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_AuditoriaSistema(prm_FechaInicio, prm_FechaFin);
                    foreach (var item in resul)
                    {
                        lstAuditoriaSistema.Add(new BEAuditoriaSistema()
                        {
                            codAuditoriaSistema = item.codAuditoriaSistema,
                            CodigoPersonaEmpre = item.CodigoPersonaEmpre,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            CodigoPersonaRespon = item.CodigoPersonaRespon,
                            Descripcion = item.Descripcion,
                            Clase = item.Clase,
                            Metodo = item.Metodo,
                            OtroDato = item.OtroDato,
                            ProcesoOK = item.ProcesoOK,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegMaquinaOrigen = item.SegMaquinaOrigen


                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstAuditoriaSistema;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo TFeriados
        /// En la BASE de DATO la Tabla : [Maestras.TFeriados]
        /// <summary>
        /// <param name = >itemTFeriados</param>
        public void Insert(BEAuditoriaSistema pAuditoriaSistema)
        {
            int? codAuditoriaSistema = 0;
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    SQLDC.omgc_I_AuditoriaSistema(
                        ref codAuditoriaSistema,
                        pAuditoriaSistema.CodigoPersonaEmpre,
                        pAuditoriaSistema.CodigoPuntoVenta,
                        pAuditoriaSistema.CodigoPersonaRespon,
                        pAuditoriaSistema.Descripcion,
                        pAuditoriaSistema.Clase,
                        pAuditoriaSistema.Metodo,
                        pAuditoriaSistema.OtroDato,
                        pAuditoriaSistema.ProcesoOK,
                        pAuditoriaSistema.SegUsuarioCrea);

                    pAuditoriaSistema.codAuditoriaSistema = codAuditoriaSistema.Value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return;
        }

        #endregion

    }
}

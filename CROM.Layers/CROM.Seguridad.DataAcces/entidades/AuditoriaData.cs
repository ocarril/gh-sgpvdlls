namespace CROM.Seguridad.DataAcces
{
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Seguridad.BussinesEntities.entidades.response;
    using CROM.Tools.Comun.settings;

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 8/10/2021-03:18:24
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Seguridad.EmpresaData.cs]
    /// </summary>
    public class AuditoriaData
    {
        private string conexion = string.Empty;

        public AuditoriaData()
        {
            conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG");
        }

        #region /* Proceso de SELECT ALL */ 

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Seguridad.Auditoria
        /// En la BASE de DATO la Tabla : [Seguridad.Auditoria]
        /// <summary>
        /// <returns>List</returns>
        public List<BEAuditoriaResponse> ListAuditoriaPage(BEBuscaAuditoriaRequest pFiltro)
        {
            List<BEAuditoriaResponse> lista = new List<BEAuditoriaResponse>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_Auditoria_Paged(pFiltro.jqCurrentPage,
                                                                   pFiltro.jqPageSize,
                                                                   pFiltro.jqSortColumn,
                                                                   pFiltro.jqSortOrder,
                                                                   pFiltro.codEmpresa,
                                                                   pFiltro.codSistema,
                                                                   pFiltro.codRol,
                                                                   pFiltro.codUsuario,
                                                                   pFiltro.fecInicioStr,
                                                                   pFiltro.fecFinalStr);
                    foreach (var item in resul)
                    {
                        lista.Add(new BEAuditoriaResponse()
                        {
                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0,

                            codAuditoria = item.codAuditoria,
                            codEmpresa = item.codEmpresa,
                            codEmpresaNombre = item.codEmpresaNombre,
                            codSistema = item.codSistema,
                            codSistemaNombre = item.codSistemaNombre,
                            codRol = item.codRol,
                            codRolNombre = item.codRolNombre,
                            codUsuario = item.codUsuario,
                            codUsuarioNombre = item.codUsuarioNombre,
                            fecRegistroApp = item.fecRegistroApp,
                            fecRegistroBD = item.fecRegistroBD,

                            desLogin = item.desLogin,
                            desMensaje = item.desMensaje,
                            desTipo = item.desTipo,
                            nomMaquinaIP = item.nomMaquinaIP

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        #endregion




        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

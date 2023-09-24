namespace CROM.Seguridad.DataAcces
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Tools.Comun.settings;
    using CROM.Tools.Comun.Web;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 24/09/2023-00:30:24
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Seguridad.EmpresaSistemaLicenciaData.cs]
    /// </summary>
    public class EmpresaSistemaLicenciaData
    {
        private string conexion = string.Empty;

        public EmpresaSistemaLicenciaData()
        {
            conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystemaSEG");
        }

        #region /* Proceso de SELECT ALL */ 

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Seguridad.EmpresaSistema
        /// En la BASE de DATO la Tabla : [Seguridad.EmpresaSistema]
        /// <summary>
        /// <returns>List</returns>
        public List<BEEmpresaSistemaLicenciaRespose> ListPaged(BEBuscaEmpresaSistemaLicenciaRequest pFiltro)
        {
            List<BEEmpresaSistemaLicenciaRespose> lstEmpresaSistema = new List<BEEmpresaSistemaLicenciaRespose>();
            try
            {
                using (_DBMLSeguridadSistemaDataContext SeguridadDC = new _DBMLSeguridadSistemaDataContext(conexion))
                {
                    var resul = SeguridadDC.usp_sis_R_ESLicencia_Paged(pFiltro.jqCurrentPage,
                                                                            pFiltro.jqPageSize,
                                                                            pFiltro.jqSortColumn,
                                                                            pFiltro.jqSortOrder,
                                                                            pFiltro.codEmpresaSistema,
                                                                            pFiltro.codEmpresa,
                                                                            pFiltro.codSistema,
                                                                            pFiltro.indActivo);


                    foreach (var item in resul)
                    {
                        lstEmpresaSistema.Add(new BEEmpresaSistemaLicenciaRespose()
                        {
                            codEmpresaSistemaLic = item.codEmpresaSistemaLic,
                            codEmpresaSistema = item.codEmpresaSistema,
                            nomEmpresa = item.nomEmpresa,
                            nomSistema = item.nomSistema,
                            indActivo = item.indActivo,
                            fecInicio = item.fecInicio,
                            fecFinal = item.fecFinal,
                            numTiempoToken = item.numTiempoToken,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaEdita = item.segMaquinaEdita,

                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0,

                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstEmpresaSistema;
        }

        #endregion

     
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

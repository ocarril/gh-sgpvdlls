namespace CROM.Seguridad.BussinesLogic
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using CROM.Seguridad.BussinesEntities.entidades.response;
    using CROM.Seguridad.DataADO;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.Web;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Proyecto    : Seguridad del Sistema
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 08/11/2009
    /// Descripcion : Clase para capa LOGICA
    /// Archivo     : SistemaLogic.cs
    /// </summary
    public class AuditoriaLogic : BaseLayer
    {
        private AuditoriaData oAuditoriaData = null;
        private ReturnValor oReturn = null;

        public AuditoriaLogic()
        {
            oAuditoriaData = new AuditoriaData();
            oReturn = new ReturnValor();
        }

        #region ----- Proceso de Listar -----

        public OperationResult ListAuditoriaPageJQGrid(BEBuscaAuditoriaRequest pFiltro)
        {
            try
            {
                pFiltro.fecInicioStr = HelpTime.ConvertYYYYMMDD(pFiltro.fecInicio);
                pFiltro.fecFinalStr = HelpTime.ConvertYYYYMMDD(pFiltro.fecFinal);
                var lstEmpresa = oAuditoriaData.ListAuditoriaPage(pFiltro);
                int totalRecords = lstEmpresa.Select(x => x.TOTALROWS).FirstOrDefault();
                int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pFiltro.jqPageSize);
                var jsonGrid = new
                {
                    PageCount = totalPages,
                    CurrentPage = pFiltro.jqCurrentPage,
                    RecordCount = totalRecords,
                    Items = (
                        from item in lstEmpresa
                        select new
                        {
                            ID = item.codAuditoria,
                            Row = new string[] {
                                                item.fecRegistroBD.ToString("dd-MM-yyyy HH:mm:ss"),
                                                item.desLogin,
                                                item.codUsuarioNombre,
                                                item.codEmpresa.ToString(),
                                                item.codEmpresaNombre,
                                                item.codSistema,
                                                item.codSistemaNombre,
                                                item.codRol,
                                                item.codRolNombre,
                                                item.codUsuario,
                                                item.desTipo,
                                                item.fecRegistroApp.ToString("dd-MM-yyyy HH:mm:ss"),
                                                item.desMensaje,
                                                item.nomMaquinaIP
                            }
                        }).ToArray()
                };
                return OK(jsonGrid);
            }
            catch (Exception ex)
            {
                return Error(GetType().Name, MethodBase.GetCurrentMethod().Name, ex, pFiltro.userActual, pFiltro.codEmpresa);
            }
            finally
            {
                if (oAuditoriaData != null)
                {
                    oAuditoriaData.Dispose();
                    oAuditoriaData = null;
                }
            }
        }


        public ResultResponse<List<BEAuditoriaResponse>> ListAuditoriaPageTable(BEBuscaAuditoriaRequest pFiltro)
        {
            ResultResponse<List<BEAuditoriaResponse>> result = new ResultResponse<List<BEAuditoriaResponse>>();
            try
            {

                pFiltro.fecInicioStr = HelpTime.ConvertYYYYMMDD(pFiltro.fecInicio);
                pFiltro.fecFinalStr = HelpTime.ConvertYYYYMMDD(pFiltro.fecFinal);

                var lstEmpresa = oAuditoriaData.ListAuditoriaPage(pFiltro);

                result.Data = lstEmpresa;
                result.Success = true;
                result.Message = WebConstants.DEFAULT_OK;

            }
            catch (Exception ex)
            {
                oReturn = HelpException.mTraerMensaje(ex, false, pFiltro.maquinaPC, pFiltro.userActual, pFiltro.codEmpresa.ToString());
                result.Message = oReturn.Message;
            }
            finally
            {
                if (oAuditoriaData != null)
                {
                    oAuditoriaData.Dispose();
                    oAuditoriaData = null;
                }
            }
            return result;
        }


        #endregion

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

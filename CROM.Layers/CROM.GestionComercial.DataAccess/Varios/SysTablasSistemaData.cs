using System;
using System.Collections.Generic;
using System.Configuration;

using CROM.GestionComercial.BusinessEntities;

namespace CROM.GestionComercial.DataAccess
{
    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 28/08/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.SysTablasSistemaData.cs]
    /// </summary>
    public class SysTablasSistemaData
    {
        private string conexion = string.Empty;
        public SysTablasSistemaData()
        {
            conexion = Util.ConexionBD();
        }
        #region /* Proceso de INSERT RECORD */


        #endregion

        #region /* Proceso de SELECT ALL */

        public List<SysReportes> ListSysReportes(string p_codigoSistema)
        {
            List<SysReportes> miLista = new List<SysReportes>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_pro_GetAll_Reportes(p_codigoSistema);
                    foreach (var item in resul)
                    {
                        miLista.Add(new SysReportes()
                        {
                            CodigoReporte = item.CodigoReporte,
                            Estado = item.Estado,
                            Orden = item.Orden,
                            ReporteName = item.ReporteName,
                            OrdenTexto = item.Orden.ToString().Trim().PadLeft(5, '0')
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        public List<SysTablas> ListSysTablas()
        {
            List<SysTablas> miLista = new List<SysTablas>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    int i = 0;
                    var resul = SQLDC.omgc_pro_GetAll_SysTablas();
                    foreach (var item in resul)
                    {
                        ++i;
                        miLista.Add(new SysTablas()
                        {
                            EsquemaNombreTabla = item.EsquemaNombreTabla,
                            NombreTabla = item.NombreTabla,
                            Item = i.ToString().PadLeft(3, '0')
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        #endregion


    }
} 

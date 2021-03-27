namespace CROM.Asistencia.DataAcces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;

    using CROM.BusinessEntities.Asistencia;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 07/01/2010-11:20:20 p.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Asistencia.ReportesData.cs]
    /// </summary>
    public class SysData
    {
        private string conexion = string.Empty;
        public SysData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnxCROMSystema"].ConnectionString;
        }

        public List<BESysReporte> ListSysReportes()
        {
            List<BESysReporte> miLista = new List<BESysReporte>();
            try
            {
                using (_CROMTimeDataContext SQLDC = new _CROMTimeDataContext(conexion))
                {
                    var resul = SQLDC.omgc_pro_GetAllFrom_Reportes();
                    foreach (var item in resul)
                    {
                        miLista.Add(new BESysReporte()
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
    }
}

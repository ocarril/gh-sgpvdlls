using System;
using System.Collections.Generic;
using System.Configuration;
using System.Transactions;
using System.Linq;

using CROM.GestionComercial.BusinessEntities;
using CROM.GestionComercial.DataAccess;
using CROM.Tools;
using CROM.Tools.Comun;

namespace CROM.GestionComercial.BusinessLogic
{
    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 28/08/2010-02:40:47 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [GestionComercial.SysTablasSistemaLogic.cs]
    /// </summary>
    public class SysTablasSistemaLogic
    {
        private SysTablasSistemaData oSysTablasSistemaData = null;
        private ReturnValor oReturnValor = null;

        public SysTablasSistemaLogic()
        {
            oSysTablasSistemaData = new SysTablasSistemaData();
            oReturnValor = new ReturnValor();
        }
        #region /* Proceso de SELECT ALL */

        public List<SysReportes> ListSysReportes(string p_codigoSistema)
        {
            List<SysReportes> miLista = new List<SysReportes>();
            try
            {
                miLista = oSysTablasSistemaData.ListSysReportes(p_codigoSistema);
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
                miLista = oSysTablasSistemaData.ListSysTablas();
                var query = from item in miLista
                            orderby item.EsquemaNombreTabla
                            select item;
                miLista = query.ToList<SysTablas>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }
        
        #endregion

        #region /* Proceso de INSERT RECORD */

        #endregion

    }
} 

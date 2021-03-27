namespace CROM.Asistencia.BussinesLogic
{
    using CROM.Asistencia.DataAcces;
    using CROM.BusinessEntities.Asistencia;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 11/01/2011-17:40:47 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : SysLogic.cs]
    /// </summary>
    public class SysLogic
    {
        private SysData oSysData = null;
        private ReturnValor oReturnValor = null;

        public SysLogic()
        {
            oSysData = new SysData();
            oReturnValor = new ReturnValor();
        }

        public List<BESysReporte> ListSysReportes()
        {
            List<BESysReporte> miLista = new List<BESysReporte>();
            try
            {
                miLista = oSysData.ListSysReportes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }
    }
}

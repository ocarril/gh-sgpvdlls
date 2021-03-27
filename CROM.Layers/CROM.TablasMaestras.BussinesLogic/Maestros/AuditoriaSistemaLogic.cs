namespace CROM.TablasMaestras.BussinesLogic
{
    using CROM.BusinessEntities.Maestros;
    using CROM.TablasMaestras.DataAcces;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 09/07/2010-11:33:49 
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Maestras.AuditoriaSistemaLogic.cs]
    /// </summary>
    public class AuditoriaSistemaLogic
    {
        private AuditoriaSistemaData oAuditoriaSistemaData = null;
        private ReturnValor oReturnValor = null;

        public AuditoriaSistemaLogic()
        {
            oAuditoriaSistemaData = new AuditoriaSistemaData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        ///// <summary>
        ///// Retorna un LISTA de registros de la Entidad Maestras.Feriados
        ///// En la BASE de DATO la Tabla : [Maestras.Feriados]
        ///// <summary>
        ///// <param name="prm_FechaInicio"></param>
        ///// <param name="prm_FechaFin"></param>
        ///// <returns></returns>
        //public List<BEAuditoriaSistema> List(DateTime prm_FechaInicio, DateTime prm_FechaFin)
        //{
        //    List<BEAuditoriaSistema> lstAuditoriaSistema = new List<BEAuditoriaSistema>();
        //    try
        //    {
        //        lstAuditoriaSistema = oAuditoriaSistemaData.List(HelpTime.ConvertYYYYMMDD(prm_FechaInicio), HelpTime.ConvertYYYYMMDD(prm_FechaFin));

        //        var AuditoriaOrden = from x in lstAuditoriaSistema
        //                             orderby x.codAuditoriaSistema descending
        //                             select x;

        //        lstAuditoriaSistema = AuditoriaOrden.ToList<BEAuditoriaSistema>();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstAuditoriaSistema;
        //}

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Feriados
        /// En la BASE de DATO la Tabla : [Maestras.Feriados]
        /// <summary>
        /// <param name="auditoriaSistema"></param>
        /// <returns></returns>
        //public ReturnValor Insert(BEAuditoriaSistema auditoriaSistema)
        //{
        //    try
        //    {
        //        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
        //        {
        //            oAuditoriaSistemaData.Insert(auditoriaSistema);
        //            oReturnValor.codRetorno = auditoriaSistema.codAuditoriaSistema;
        //            if (oReturnValor.codRetorno != 0)
        //            {
        //                oReturnValor.Exitosa = true;
        //                tx.Complete();
        //                oReturnValor.Message = HelpMessages.Evento_NEW;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oReturnValor = HelpException.mTraerMensaje(ex);
        //    }
        //    return oReturnValor;
        //}

        #endregion

    }
} 

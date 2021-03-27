namespace CROM.GestionAlmacen.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Transactions;

    using CROM.BusinessEntities.Maestros;
    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.Almacen;
    using CROM.TablasMaestras.BussinesLogic;
    using CROM.GestionAlmacen.DataAccess;
    using CROM.Tools.Comun;
    

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 26/02/2010-09:55:44 
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Produccion.PartesAtributosLogic.cs]
    /// </summary>
    public class PartesAtributosLogic
    {
        private PartesAtributosData oPartesAtributosData = null;
        private ReturnValor oReturnValor = null;
        public PartesAtributosLogic()
        {
            oPartesAtributosData = new PartesAtributosData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Produccion.PartesAtributos
        /// En la BASE de DATO la Tabla : [Produccion.PartesAtributos]
        /// <summary>
        /// <returns>List</returns>
        public List<BEParteAtributo> List(string prm_CodigoArguParteProdu, string prm_CodigoArguAtributoPP, bool prm_Estado)
        {
            List<BEParteAtributo> miLista = new List<BEParteAtributo>();
            try
            {
                miLista = oPartesAtributosData.List(prm_CodigoArguParteProdu, prm_CodigoArguAtributoPP, prm_Estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PartesAtributos
        /// En la BASE de DATO la Tabla : [Produccion.PartesAtributos]
        /// <summary>
        /// <param name = >itemPartesAtributos</param>
        public ReturnValor InsertUpdate(List<BEParteAtributo> listaPartesAtributos, BERegistro itemTablaMaestraRegistro, bool NUEVO)
        {
            ReturnValor xReturnValor = new ReturnValor();
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    MaestroLogic oMaestroLogic = new MaestroLogic();
                    if (NUEVO)
                        oMaestroLogic.InsertDetalleDetalle(itemTablaMaestraRegistro);
                    else
                        oMaestroLogic.ActualizarDetalle(itemTablaMaestraRegistro);
                    oPartesAtributosData.Delete(itemTablaMaestraRegistro.CodigoArgumento, string.Empty);

                    foreach (BEParteAtributo pItem in listaPartesAtributos)
                    {
                        oReturnValor.Exitosa = oPartesAtributosData.InsertUpdate(pItem);
                    }
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                        tx.Complete();

                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Produccion.PartesAtributos
        /// En la BASE de DATO la Tabla : [Produccion.PartesAtributos]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string prm_CodigoArguParteProdu, string prm_CodigoArguAtributoPP)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    MaestroLogic oMaestroLogic = new MaestroLogic();
                    oMaestroLogic.EliminarDetalle(HelpTMaestras.CodigoTabla(HelpTMaestras.TM.ProducPartes), prm_CodigoArguParteProdu);
                    oReturnValor.Exitosa = oPartesAtributosData.Delete(prm_CodigoArguParteProdu, prm_CodigoArguAtributoPP);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion

    }
} 

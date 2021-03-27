namespace CROM.Importaciones.BusinessLogic
{
    using CROM.BusinessEntities.Importaciones;
    using CROM.Importaciones.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Transactions;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 11/09/2014-06:09:07 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Importaciones.PlantillaCostoLogic.cs]
    /// </summary>
    public class PlantillaCostoLogic
    {
        private PlantillaCostoData plantillaCostoData = null;
        private ReturnValor returnValor = null;

        public PlantillaCostoLogic()
        {
            plantillaCostoData = new PlantillaCostoData();
            returnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Importaciones.PlantillaCosto
        /// En la BASE de DATO la Tabla : [Importaciones.PlantillaCosto]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEPlantillaCosto> List(BaseFiltroImp pFiltro)
        {
            List<BEPlantillaCosto> lstPlantillaCosto = new List<BEPlantillaCosto>();
            try
            {
                lstPlantillaCosto = plantillaCostoData.List(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPlantillaCosto;
        }

        public List<BEPlantillaCosto> ListPaged(BaseFiltroImp pFiltro)
        {
            List<BEPlantillaCosto> lstPlantillaCosto = new List<BEPlantillaCosto>();
            try
            {
                lstPlantillaCosto = plantillaCostoData.ListPaged(pFiltro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPlantillaCosto;
        }
        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Importaciones.PlantillaCosto
        /// En la BASE de DATO la Tabla : [Importaciones.PlantillaCosto]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public BEPlantillaCosto Find(BaseFiltroImp pFiltro)
        {
            BEPlantillaCosto plantillaCosto = null;
            try
            {
                if (pFiltro.codPlantillaCosto.Value != 0)
                    plantillaCosto = plantillaCostoData.Find(pFiltro.codPlantillaCosto.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return plantillaCosto;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PlantillaCosto
        /// En la BASE de DATO la Tabla : [Importaciones.PlantillaCosto]
        /// </summary>
        /// <param name="plantillaCosto"></param>
        /// <returns></returns>
        public ReturnValor Insert(BEPlantillaCosto plantillaCosto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = plantillaCostoData.Insert(plantillaCosto);
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpMessages.Evento_NEW;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return returnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PlantillaCosto
        /// En la BASE de DATO la Tabla : [Importaciones.PlantillaCosto]
        /// </summary>
        /// <param name="plantillaCosto"></param>
        /// <returns></returns>
        public ReturnValor Update(BEPlantillaCosto plantillaCosto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = plantillaCostoData.Update(plantillaCosto);
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpMessages.Evento_EDIT;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return returnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Importaciones.PlantillaCosto
        /// En la BASE de DATO la Tabla : [Importaciones.PlantillaCosto]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public ReturnValor Delete(List<BEPlantillaCosto> lstPlantillaCosto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = plantillaCostoData.Delete(lstPlantillaCosto);
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpMessages.Evento_NEW;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return returnValor;
        }

        #endregion

    }
} 

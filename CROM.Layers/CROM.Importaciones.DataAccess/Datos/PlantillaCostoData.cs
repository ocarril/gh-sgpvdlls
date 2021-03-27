namespace CROM.Importaciones.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Importaciones;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 11/09/2014-06:09:07 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Importaciones.PlantillaCostoData.cs]
    /// </summary>
    public class PlantillaCostoData
    {
        private string conexion = string.Empty;

        public PlantillaCostoData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Importaciones.PlantillaCosto
        /// En la BASE de DATO la Tabla : [Importaciones.PlantillaCosto]
        /// <summary>
        /// <returns>List</returns>
        public List<BEPlantillaCosto> List(BaseFiltroImp pFiltro)
        {
            List<BEPlantillaCosto> lstPlantillaCosto = new List<BEPlantillaCosto>();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PlantillaCosto(pFiltro.codPlantillaCosto,
                                                            pFiltro.codRegIncotermo,
                                                            pFiltro.codRegResumenCosto,
                                                            pFiltro.codRegNacionalizacion,
                                                            pFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lstPlantillaCosto.Add(new BEPlantillaCosto()
                        {
                            codPlantillaCosto = item.codPlantillaCosto,
                            codRegIncoterm = item.codRegIncotermo,
                            codRegResumenCosto = item.codRegResumenCosto,
                            codRegNacionalizac = item.codRegNacionalizac,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            auxcodRegIncotermo = item.codRegIncotermoNombre,
                            auxcodRegResumenCosto = item.codRegResumenCostoNombre,
                            auxcodRegNacionalizac = item.codRegNacionalizacNombre
                        });
                    }
                }
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
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PlantillaCosto_Paged(
                                                            pFiltro.grcurrentPage,
                                                            pFiltro.grpageSize,
                                                            pFiltro.grsortColumn,
                                                            pFiltro.grsortOrder,
                                                            pFiltro.codPlantillaCosto,
                                                            pFiltro.codRegIncotermo,
                                                            pFiltro.codRegResumenCosto,
                                                            pFiltro.codRegNacionalizacion,
                                                            pFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        lstPlantillaCosto.Add(new BEPlantillaCosto()
                        {
                            codPlantillaCosto = item.codPlantillaCosto,
                            codRegIncoterm = item.codRegIncotermo,
                            codRegResumenCosto = item.codRegResumenCosto,
                            codRegNacionalizac = item.codRegNacionalizac,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            auxcodRegIncotermo = item.codRegIncotermoNombre,
                            auxcodRegResumenCosto = item.codRegResumenCostoNombre,
                            auxcodRegNacionalizac = item.codRegNacionalizacNombre,

                            ROW = item.ROWNUM == null ? 0 : item.ROWNUM.Value,
                            TOTALROWS = item.TOTALROWS == null ? 0 : item.TOTALROWS.Value
                        });
                    }
                }
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
        public BEPlantillaCosto Find(int codPlantillaCosto)
        {
            BEPlantillaCosto plantillaCosto = new BEPlantillaCosto();
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_PlantillaCosto(codPlantillaCosto, null, null, null, null);
                    foreach (var item in resul)
                    {
                        plantillaCosto = new BEPlantillaCosto()
                        {
                            codPlantillaCosto = item.codPlantillaCosto,
                            codRegNacionalizac = item.codRegNacionalizac,
                            codRegIncoterm = item.codRegIncotermo,
                            codRegResumenCosto = item.codRegResumenCosto,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            auxcodRegIncotermo = item.codRegIncotermoNombre,
                            auxcodRegResumenCosto = item.codRegResumenCostoNombre,
                            auxcodRegNacionalizac = item.codRegNacionalizacNombre,
                            numOrden = item.numOrden
                        };
                    }
                }
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
        public bool Insert(BEPlantillaCosto plantillaCosto)
        {
            int? codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    SQLDC.omgc_I_PlantillaCosto(
                      ref codigoRetorno,
                      plantillaCosto.codRegIncoterm,
                      plantillaCosto.codRegResumenCosto,
                      plantillaCosto.codRegNacionalizac,
                      plantillaCosto.numOrden,
                      plantillaCosto.indActivo,
                      plantillaCosto.segUsuarioCrea);
                    plantillaCosto.codPlantillaCosto = codigoRetorno.Value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno > 0 ? true : false;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PlantillaCosto
        /// En la BASE de DATO la Tabla : [Importaciones.PlantillaCosto]
        /// </summary>
        /// <param name="plantillaCosto"></param>
        /// <returns></returns>
        public bool Update(BEPlantillaCosto plantillaCosto)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    SQLDC.omgc_U_PlantillaCosto(
                        plantillaCosto.codPlantillaCosto,
                        plantillaCosto.codRegIncoterm,
                        plantillaCosto.codRegResumenCosto,
                        plantillaCosto.codRegNacionalizac,
                        plantillaCosto.indActivo,
                        plantillaCosto.segUsuarioEdita,
                        plantillaCosto.numOrden
                        );
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Importaciones.PlantillaCosto
        /// En la BASE de DATO la Tabla : [Importaciones.PlantillaCosto]
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public bool Delete(List<BEPlantillaCosto> lstPlantillaCosto)
        {
            int codigoRetorno = -1;
            try
            {
                using (_ImportacionesDataContext SQLDC = new _ImportacionesDataContext(conexion))
                {
                    foreach (BEPlantillaCosto itemPC in lstPlantillaCosto)
                    {
                        SQLDC.omgc_D_PlantillaCosto(itemPC.codPlantillaCosto,
                                                    itemPC.codRegIncoterm,
                                                    itemPC.codRegResumenCosto,
                                                    itemPC.codRegNacionalizac);
                        codigoRetorno = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

    }
} 

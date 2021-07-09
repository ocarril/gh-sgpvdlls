namespace CROM.GestionAlmacen.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Almacen;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// desNombre : Capa de Datos 
    /// Archivo     : [Almacen.GrupoData.cs]
    /// </summary>
    public class GrupoData
    {
        private string conexion = string.Empty;
        public GrupoData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        ///// <summary>
        ///// Almacena el registro de una ENTIDAD de registro de Tipo Grupo
        ///// En la BASE de DATO la Tabla : [Almacen.Grupo]
        ///// <summary>
        ///// <param name="grupo"></param>
        ///// <returns></returns>
        //public int Insert(GrupoAux grupo)
        //{
        //    int? codRetorno = null;
        //    try
        //    {
        //        using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
        //        {
        //            SQLDC.usp_sgcfe_C_Grupo(
        //                ref codRetorno,
        //                grupo.codEmpresa,
        //                grupo.codGrupoKey,
        //                grupo.codRegLinea,
        //                grupo.codRegMaterial,
        //                grupo.codRegUnidadMedida,
        //                grupo.desNombre,
        //                grupo.indActivo,
        //                grupo.segUsuarioCrea
        //            );
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codRetorno == null ? 0 : codRetorno.Value;
        //}

        #endregion

        #region /* Proceso de UPDATE RECORD */

        ///// <summary>
        ///// Almacena el registro de una ENTIDAD Grupo
        ///// En la BASE de DATO la Tabla : [Almacen.Grupo]
        ///// <summary>
        ///// <param name="grupo"></param>
        ///// <returns></returns>
        //public bool Update(GrupoAux grupo)
        //{
        //    int codRetorno = -1;
        //    try
        //    {
        //        using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
        //        {
        //            codRetorno = SQLDC.usp_sgcfe_U_Grupo(
        //                grupo.codGrupo,
        //                grupo.codEmpresa,
        //                grupo.codGrupoKey,
        //                grupo.codRegLinea,
        //                grupo.codRegMaterial,
        //                grupo.codRegUnidadMedida,
        //                grupo.desNombre,
        //                grupo.indActivo,
        //                grupo.segUsuarioEdita
        //            );
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codRetorno == 0 ? true : false;
        //}

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        ///// <summary>
        ///// ELIMINA un registro de la Entidad Almacen.Grupo
        ///// En la BASE de DATO la Tabla : [Almacen.Grupo]
        ///// <summary>
        ///// <param name="prm_codGrupo">código del Grupo</param>
        ///// <returns></returns>
        //public bool Delete(int prm_codEmpresa,int prm_codGrupo)
        //{
        //    int codRetorno = -1;
        //    try
        //    {
        //        using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
        //        {
        //            codRetorno = SQLDC.usp_sgcfe_D_Grupo(prm_codEmpresa,prm_codGrupo);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codRetorno == 0 ? true : false;
        //}

        #endregion

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Grupo
        /// En la BASE de DATO la Tabla : [Almacen.Grupo]
        /// <summary>
        /// <returns>List</returns>
        public List<GrupoAux> List(BaseFiltroGrupo pFiltro)
        {
            List<GrupoAux> lstGrupo = new List<GrupoAux>();
            try
            { 
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.usp_sgcfe_R_Grupo(pFiltro.codGrupo,
                                                   pFiltro.codEmpresa,
                                                   pFiltro.desNombre, 
                                                   pFiltro.codRegLineaProd, 
                                                   pFiltro.codRegMaterialProd, 
                                                   pFiltro.codRegUnidadMedida, 
                                                   pFiltro.indEstado);
                    foreach (var item in resul)
                    {
                        lstGrupo.Add(new GrupoAux()
                        {
                            codEmpresaRUC = pFiltro.codEmpresaRUC,
                            codEmpresa = pFiltro.codEmpresa,
                            codGrupo = item.codGrupo,
                            codGrupoKey = item.codGrupoKey,
                            codRegLinea = item.codRegLineaProd,
                            codRegMaterial = item.codRegMaterialProd,
                            codRegUnidadMedida = item.codRegUnidadMedida,
                            desNombre = item.desNombre,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.SegMaquina,
                            auxcodRegLineaProdNombre = item.codRegLineaProdNombre,
                            auxcodRegMaterialProdNombre = item.codRegMaterialProdNombre,
                            auxcodRegUnidadMedNombre = item.codRegUnidadMedNombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstGrupo;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.Grupo
        /// En la BASE de DATO la Tabla : [Almacen.Grupo]
        /// <summary>
        /// <param name="pfiltro"></param>
        /// <returns></returns>
        public GrupoAux Find(BaseFiltroGrupo pfiltro)
        {
            GrupoAux grupo = new GrupoAux();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.usp_sgcfe_R_Grupo(pfiltro.codGrupo,
                                                        pfiltro.codEmpresa,
                                                        pfiltro.desNombre,
                                                        pfiltro.codRegLineaProd,
                                                        pfiltro.codRegMaterialProd,
                                                        pfiltro.codRegUnidadMedida,
                                                        pfiltro.indEstado);
                    foreach (var item in resul)
                    {
                        grupo = new GrupoAux()
                        {
                            codEmpresaRUC = pfiltro.codEmpresaRUC,
                            codEmpresa = pfiltro.codEmpresa,
                            codGrupo = item.codGrupo,
                            codGrupoKey = item.codGrupoKey,
                            codRegLinea = item.codRegLineaProd,
                            codRegMaterial = item.codRegMaterialProd,
                            codRegUnidadMedida = item.codRegUnidadMedida,
                            desNombre = item.desNombre,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.SegMaquina,

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return grupo;
        }

        #endregion
    }
} 

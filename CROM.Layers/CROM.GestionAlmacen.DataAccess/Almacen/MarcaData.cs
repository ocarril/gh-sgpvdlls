namespace CROM.GestionAlmacen.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Almacen;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 18/01/2012-04:29:35 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Almacen.DepositoData.cs]
    /// </summary>
    public class MarcaData
    {
        private string conexion = string.Empty;
        public MarcaData()
        {
            conexion = Util.ConexionBD();
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Marca
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEMarca> ListMarca(BaseFiltroMarca pFiltro) 
        {
            List<BEMarca> lstMarca = new List<BEMarca>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Marca(pFiltro.codEmpresa,
                                                      null,
                                                      null,
                                                      string.Empty,
                                                      string.Empty,
                                                      pFiltro.desNombre,
                                                      pFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        BEMarca objMarca = new BEMarca();
                        objMarca.codMarca = item.codMarca;
                        objMarca.codEmpresa = pFiltro.codEmpresa;
                        objMarca.codMarcaKEY = item.codMarcaKEY;
                        objMarca.desNombre = item.desNombre;
                        objMarca.indActivo = item.indActivo;
                        objMarca.segUsuarioCrea = item.segUsuarioCrea;
                        objMarca.segUsuarioEdita = item.segUsuarioEdita;
                        objMarca.segFechaCrea = item.segFechaCrea;
                        objMarca.segFechaEdita = item.segFechaEdita;
                        objMarca.segMaquinaCrea = item.segMaquinaCrea;
                        
                        lstMarca.Add(objMarca);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstMarca;
        }


        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Marca
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEModelo> ListModelo(BaseFiltroModelo pFiltro)
        {
            List<BEModelo> lstMarca = new List<BEModelo>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Modelo(pFiltro.codEmpresa,
                                                    pFiltro.codMarca,
                                                      null,
                                                      null,
                                                      pFiltro.desNombre,
                                                      pFiltro.indActivo);
                    foreach (var item in resul)
                    {
                        BEModelo objMarca = new BEModelo();
                        objMarca.codModelo = item.codModelo;
                        objMarca.codMarca = item.codMarca;
                        objMarca.codEmpresa = pFiltro.codEmpresa;
                        objMarca.codModeloKEY = item.codModeloKEY;
                        objMarca.desNombre = item.desNombre;
                        objMarca.indActivo = item.indActivo;
                        objMarca.segUsuarioCrea = item.segUsuarioCrea;
                        objMarca.segUsuarioEdita = item.segUsuarioEdita;
                        objMarca.segFechaCrea = item.segFechaCrea;
                        objMarca.segFechaEdita = item.segFechaEdita;
                        objMarca.segMaquinaCrea = item.segMaquinaCrea;

                        lstMarca.Add(objMarca);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstMarca;
        }

        #endregion


    }
} 

namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/11/2013-02:07:42 p.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.DocumRegSerieData.cs]
    /// </summary>
    public class DocumRegSerieData
    {
        private string conexion = string.Empty;
        public DocumRegSerieData()
        {
            conexion = Util.ConexionBD();
        }
        #region /* Proceso de SELECT ALL */

        public List<BEDocumRegSerie> ListcodDocumReg(BaseFiltro filtro)
        {
            List<BEDocumRegSerie> listaDocumRegSerie = new List<BEDocumRegSerie>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumRegSerie_codDocumReg(filtro.codDocumReg);
                    foreach (var item in resul)
                    {
                        listaDocumRegSerie.Add(new BEDocumRegSerie()
                        {
                            codProducto = item.codProducto,
                            codDocumRegDetalle = item.codDocumRegDetalle,
                            codProductoSeriado = item.codProductoSeriado,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaEdita,
                            codDocumRegSerie = item.codDocumRegSerie,

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaDocumRegSerie;
        }
        public List<BEDocumRegSerie> ListcodDocumRegDetalle(BaseFiltro filtro)
        {
            List<BEDocumRegSerie> listaDocumRegSerie = new List<BEDocumRegSerie>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_DocumRegSerie_codDocumRegDetalle(filtro.codDocumRegDetalle);
                    foreach (var item in resul)
                    {
                        listaDocumRegSerie.Add(new BEDocumRegSerie()
                        {
                            codProducto = item.codProducto,
                            codDocumRegDetalle = item.codDocumRegDetalle,
                            codProductoSeriado = item.codProductoSeriado,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaEdita,
                            codDocumRegSerie = item.codDocumRegSerie,

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaDocumRegSerie;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo DocumRegSerie
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumRegSerie]
        /// <summary>
        /// <param name = >itemLetraDeCambio</param>
        public int Insert(List<BEDocumRegSerie> plistaDocumRegSerie)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    foreach (BEDocumRegSerie documRegSerie in plistaDocumRegSerie)
                    {
                        int? codDocumRegSerie = null;
                        codigoRetorno = SQLDC.omgc_I_DocumRegSerie(
                           ref codDocumRegSerie,
                           documRegSerie.codProducto,
                           documRegSerie.codDocumRegDetalle,
                           documRegSerie.codProductoSeriado,
                           documRegSerie.segUsuarioEdita);
                        documRegSerie.codDocumRegSerie = codDocumRegSerie.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.DocumRegSerie
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumRegSerie]
        /// <summary>
        /// <returns>bool</returns>
        public bool DeletecodDocumReg(BaseFiltro pFiltro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_D_DocumRegSerie_codDocumReg(pFiltro.codDocumReg, pFiltro.segUsuarioEdita);
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
        public bool DeletecodDocumRegDetalle(BaseFiltro pFiltro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_DocumRegSerie_codDocumRegDetalle(pFiltro.codDocumRegDetalle, pFiltro.segUsuarioEdita);
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

namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/03/2011-05:08:50 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.ListaDePrecioData.cs]
    /// </summary>
    public class ListaDePrecioData
    {
        private string conexion = string.Empty;

        public ListaDePrecioData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ListaDePrecio
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecio]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<BEListaDePrecio> List(BaseFiltro filtro) // string prm_CodigoLista, string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, string prm_Descripcion, bool? prm_EsParaVenta, bool? prm_Estado)
        {
            List<BEListaDePrecio> lstListaDePrecio = new List<BEListaDePrecio>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ListaDePrecio(filtro.codListaPrecio
                                                         , filtro.codEmpresaRUC
                                                         , filtro.codPuntoVenta
                                                         , filtro.desNombre
                                                         , filtro.indParaVenta
                                                         , filtro.indEstado);
                    foreach (var item in resul)
                    {
                        lstListaDePrecio.Add(new BEListaDePrecio()
                        {
                            CodigoLista = item.CodigoLista,
                            Descripcion = item.Descripcion,
                            EsParaVenta = item.EsParaVenta,
                            Observaciones = item.Observaciones,
                            FechaGenerada = item.FechaGenerada,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaCrea = item.SegMaquina,
                            CodigoPersonaEmpre = item.CodigoPersonaEmpre,
                            CodigoPersonaEmpreNombre = item.CodigoPersonaEmpreNombre,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstListaDePrecio;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.ListaDePrecio
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecio]
        /// <summary>
        /// <param name="prm_CodigoLista"></param>
        /// <returns></returns>
        public BEListaDePrecio Find(string prm_CodigoLista)
        {
            BEListaDePrecio listaDePrecio = new BEListaDePrecio();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_ListaDePrecio_codLista(prm_CodigoLista);
                    foreach (var item in resul)
                    {
                        listaDePrecio = new BEListaDePrecio()
                        {
                            CodigoLista = item.CodigoLista,
                            Descripcion = item.Descripcion,
                            EsParaVenta = item.EsParaVenta,
                            Observaciones = item.Observaciones,
                            FechaGenerada = item.FechaGenerada,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaCrea = item.SegMaquina,
                            CodigoPersonaEmpre = item.CodigoPersonaEmpre,
                            CodigoPuntoVenta = item.CodigoPuntoVenta,
                            CodigoPersonaEmpreNombre = item.CodigoPersonaEmpreNombre,
                            CodigoPuntoVentaNombre = item.CodigoPuntoVentaNombre,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaDePrecio;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ListaDePrecio
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecio]
        /// <summary>
        /// <param name="listaDePrecio"></param>
        /// <returns></returns>
        public string Insert(BEListaDePrecio listaDePrecio)
        {
            string codigoRetorno = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_I_ListaDePrecio(
                        ref codigoRetorno,
                        listaDePrecio.CodigoPersonaEmpre,
                        listaDePrecio.CodigoPuntoVenta,
                        listaDePrecio.Descripcion,
                        listaDePrecio.EsParaVenta,
                        listaDePrecio.Observaciones,
                        listaDePrecio.FechaGenerada,
                        listaDePrecio.Estado,
                        listaDePrecio.segUsuarioCrea);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ListaDePrecio
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecio]
        /// <summary>
        /// <param name="listaDePrecio"></param>
        /// <returns></returns>
        public bool Update(BEListaDePrecio listaDePrecio)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_ListaDePrecio(
                        listaDePrecio.CodigoLista,
                        listaDePrecio.CodigoPersonaEmpre,
                        listaDePrecio.CodigoPuntoVenta,
                        listaDePrecio.Descripcion,
                        listaDePrecio.EsParaVenta,
                        listaDePrecio.Observaciones,
                        listaDePrecio.Estado,
                        listaDePrecio.segUsuarioEdita);
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
        /// ELIMINA un registro de la Entidad GestionComercial.ListaDePrecio
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecio]
        /// <summary>
        /// <param name="prm_CodigoLista"></param>
        /// <returns></returns>
        public bool Delete(string prm_CodigoLista)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_ListaDePrecio(prm_CodigoLista);
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

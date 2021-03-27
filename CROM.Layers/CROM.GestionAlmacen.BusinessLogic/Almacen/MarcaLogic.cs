namespace CROM.GestionAlmacen.BusinessLogic
{
    using CROM.BusinessEntities.Almacen;
    using CROM.GestionAlmacen.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;

    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 18/01/2012-04:29:36 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Almacen.DepositoLogic.cs]
    /// </summary>
    public class MarcaLogic
    {
        private MarcaData marcaData = null;
        private ReturnValor returnValor = null;
        public MarcaLogic()
        {
            marcaData = new MarcaData();
            returnValor = new ReturnValor();
        }
       
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Deposito
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <returns>List</returns>
        public List<BEMarca> List(BaseFiltroMarca pFiltro)
        {
            List<BEMarca> lstMarca = new List<BEMarca>();
            try
            {
                lstMarca = marcaData.ListMarca(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstMarca;
        }
        
        public List<BEMarca> List(BaseFiltroMarca pFiltro, Helper.ComboBoxText pTexto)
        {
            List<BEMarca> lstMarca = new List<BEMarca>();
            try
            {
                lstMarca = marcaData.ListMarca(pFiltro);
                if (lstMarca.Count > 0)
                    lstMarca.Insert(0, new BEMarca { codMarca = 0, desNombre = Helper.ObtenerTexto(pTexto) });
                else
                    lstMarca.Add(new BEMarca { codMarca =0, desNombre = Helper.ObtenerTexto(pTexto) });
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstMarca;
        }

        #endregion


        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Deposito
        /// En la BASE de DATO la Tabla : [Almacen.Deposito]
        /// <summary>
        /// <returns>List</returns>
        public List<BEModelo> List(BaseFiltroModelo pFiltro)
        {
            List<BEModelo> lstModelo = new List<BEModelo>();
            try
            {
                lstModelo = marcaData.ListModelo(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstModelo;
        }

        public List<BEModelo> List(BaseFiltroModelo pFiltro, Helper.ComboBoxText pTexto)
        {
            List<BEModelo> lstModelo = new List<BEModelo>();
            try
            {
                lstModelo = marcaData.ListModelo(pFiltro);
                if (lstModelo.Count > 0)
                    lstModelo.Insert(0, new BEModelo { codModelo = 0, desNombre = Helper.ObtenerTexto(pTexto) });
                else
                    lstModelo.Add(new BEModelo { codModelo = 0, desNombre = Helper.ObtenerTexto(pTexto) });
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstModelo;
        }

        #endregion

    }
}

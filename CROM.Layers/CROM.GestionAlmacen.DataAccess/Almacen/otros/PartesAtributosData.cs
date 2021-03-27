namespace CROM.GestionAlmacen.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Almacen;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 26/02/2010-09:55:44 
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Produccion.PartesAtributosData.cs]
    /// </summary>
    public class PartesAtributosData
    {
        private string conexion = string.Empty;

        public PartesAtributosData()
        {
            conexion = Util.ConexionBD();
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
                using (_ProduccionDataContext SQLDC = new _ProduccionDataContext(conexion))
                {
                    //var resul = SQLDC.omgc_mnt_GetAllFromPartesAtributos(prm_CodigoArguParteProdu, prm_CodigoArguAtributoPP, prm_Estado);
                    //foreach (var item in resul)
                    //{
                    //    miLista.Add(new PartesAtributos()
                    //    {
                    //        CodigoArguParteProdu = item.CodigoArguParteProdu,
                    //        CodigoArguAtributoPP = item.CodigoArguAtributoPP,
                    //        CodigoArguParteProduNombre = item.CodigoArguParteProduNombre,
                    //        CodigoArguAtributoPPNombre = item.CodigoArguAtributoPPNombre,
                    //        Estado = item.Estado,
                    //        SegUsuarioCrea = item.SegUsuarioCrea,
                    //        SegUsuarioEdita = item.SegUsuarioEdita,
                    //        SegFechaCrea = item.SegFechaCrea,
                    //        SegFechaEdita = item.SegFechaEdita,
                    //        SegMaquina = item.SegMaquina,

                    //    });
                    //}
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        #endregion

        #region /* Proceso de INSERT UPDATE - RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PartesAtributos
        /// En la BASE de DATO la Tabla : [Produccion.PartesAtributos]
        /// <summary>
        /// <param name = >itemPartesAtributos</param>
        public bool InsertUpdate(BEParteAtributo itemPartesAtributos)
        {
            int codigoRetorno = -1;
            try
            {
                //using (_ProduccionDataContext SQLDC = new _ProduccionDataContext(conexion))
                //{
                //    codigoRetorno = SQLDC.omgc_mnt_InsertUpdatePartesAtributos(
                //        itemPartesAtributos.CodigoArguParteProdu,
                //        itemPartesAtributos.CodigoArguAtributoPP,
                //        itemPartesAtributos.Estado,
                //        itemPartesAtributos.SegUsuarioCrea);
                //}
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
        /// ELIMINA un registro de la Entidad Produccion.PartesAtributos
        /// En la BASE de DATO la Tabla : [Produccion.PartesAtributos]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(string prm_CodigoArguParteProdu, string prm_CodigoArguAtributoPP)
        {
            int codigoRetorno = -1;
            try
            {
                //using (_ProduccionDataContext SQLDC = new _ProduccionDataContext(conexion))
                //{
                //    codigoRetorno = SQLDC.omgc_mnt_DeletePartesAtributos(prm_CodigoArguParteProdu,prm_CodigoArguAtributoPP);
                //}
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

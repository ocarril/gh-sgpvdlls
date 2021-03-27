namespace CROM.TablasMaestras.DataAcces
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Maestros;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 09/07/2010-11:33:49 
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Maestras.TFeriadosData.cs]
    /// </summary>
    public class FeriadoData
    {
        private string conexion = string.Empty;

        public FeriadoData()
        {
            conexion = Util.ConexionBD();
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Maestras.TFeriados
        /// En la BASE de DATO la Tabla : [Maestras.TFeriados]
        /// <summary>
        /// <returns>List</returns>
        public List<BEFeriado> List(string prm_Anio, string prm_Descripcion, bool? prm_Fijo, bool? prm_Estado)
        {
            List<BEFeriado> miLista = new List<BEFeriado>();
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Feriado(prm_Anio, prm_Descripcion, prm_Fijo, prm_Estado);
                    foreach (var item in resul)
                    {
                        miLista.Add(new BEFeriado()
                        {
                            CodigoRegistro = item.CodigoRegistro,
                            Feriado = item.Feriado,
                            Fijo = item.Fijo,
                            Descripcion = item.Descripcion,
                            Estado = item.Estado,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaHoraEdita = item.SegFechaHoraEdita,
                            SegMaquinaOrigen = item.SegMaquinaOrigen,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestras.TFeriados
        /// En la BASE de DATO la Tabla : [Maestras.TFeriados]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEFeriado Find(string prm_CodRegistro)
        {
            BEFeriado miEntidad = new BEFeriado();
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Feriado_Id(prm_CodRegistro);
                    foreach (var item in resul)
                    {
                        miEntidad = new BEFeriado()
                        {
                            CodigoRegistro = item.CodigoRegistro,
                            Feriado = item.Feriado,
                            Fijo = item.Fijo,
                            Descripcion = item.Descripcion,
                            Estado = item.Estado,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaHoraEdita = item.SegFechaHoraEdita,
                            SegMaquinaOrigen = item.SegMaquinaOrigen,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miEntidad;
        }

        public BEFeriado FindByFeriado(string prm_Feriado)
        {
            BEFeriado objFeriado = new BEFeriado();
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Feriado_Fecha(prm_Feriado);
                    foreach (var item in resul)
                    {
                        objFeriado = new BEFeriado()
                        {
                            CodigoRegistro = item.CodigoRegistro,
                            Feriado = item.Feriado,
                            Fijo = item.Fijo,
                            Descripcion = item.Descripcion,
                            Estado = item.Estado,
                            SegUsuarioCrea = item.SegUsuarioCrea,
                            SegFechaHoraCrea = item.SegFechaHoraCrea,
                            SegUsuarioEdita = item.SegUsuarioEdita,
                            SegFechaHoraEdita = item.SegFechaHoraEdita,
                            SegMaquinaOrigen = item.SegMaquinaOrigen,

                        };
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objFeriado;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo TFeriados
        /// En la BASE de DATO la Tabla : [Maestras.TFeriados]
        /// <summary>
        /// <param name = >itemTFeriados</param>
        public string Insert(BEFeriado itemTFeriados)
        {
            string codigoRetorno = null;
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    SQLDC.omgc_I_Feriado(
                         ref codigoRetorno,
                        itemTFeriados.Feriado,
                        itemTFeriados.Fijo,
                        itemTFeriados.Descripcion,
                        itemTFeriados.Estado,
                        itemTFeriados.SegUsuarioCrea,
                        itemTFeriados.SegUsuarioCrea);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo TFeriados
        /// En la BASE de DATO la Tabla : [Maestras.TFeriados]
        /// <summary>
        /// <param name = >itemTFeriados</param>
        public bool Update(BEFeriado itemTFeriados)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_U_Feriado(
                        itemTFeriados.CodigoRegistro,
                        itemTFeriados.Feriado,
                        itemTFeriados.Fijo,
                        itemTFeriados.Descripcion,
                        itemTFeriados.Estado,
                        itemTFeriados.SegUsuarioEdita);
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
        /// ELIMINA un registro de la Entidad Maestras.TFeriados
        /// En la BASE de DATO la Tabla : [Maestras.TFeriados]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(string prm_CodigoRegistro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLTablasDataContext SQLDC = new _DBMLTablasDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_D_Feriado(prm_CodigoRegistro);
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

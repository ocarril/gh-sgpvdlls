namespace CROM.Tools.Config
{
    using CROM.Tools.Comun.settings;
    using System;
    using System.Collections.Generic;
    using System.Configuration;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 06/04/2014-06:27:34 p.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Maestros.ConfiguracionData.cs]
    /// </summary>
    public static class ConfigCROM
    {
        #region /* Proceso de SELECT BY ID CODE */
        public static string cnxNombre { get; set; }

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestros.Configuracion
        /// En la BASE de DATO la Tabla : [Maestros.Configuracion]
        /// <summary>
        /// <returns>Entidad</returns>
        public static string AppConfig(int codEmpresa, ConfigTool pcodKeyConfig)
        {
            ConfigValor configuracion = new ConfigValor();
            try
            {
                string conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystema");
                using (DBML_ConfigDataContext SQLDC = new DBML_ConfigDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Configuracion(codEmpresa, null, pcodKeyConfig.ToString(), null, null);
                    foreach (var item in resul)
                    {
                        configuracion = new ConfigValor()
                        {
                            desValor = item.desValor,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                configuracion.desValor = string.IsNullOrEmpty(configuracion.desValor) ? string.Empty : configuracion.desValor;
            }
            return configuracion.desValor;
        }


        public static string AppConfig(int codEmpresa, string pcodKeyConfig)
        {
            ConfigValor configuracion = new ConfigValor();
            try
            {
                string conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystema");
                using (DBML_ConfigDataContext SQLDC = new DBML_ConfigDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Configuracion(codEmpresa, null, pcodKeyConfig.ToString(), null, null);
                    foreach (var item in resul)
                    {
                        configuracion = new ConfigValor()
                        {
                            desValor = item.desValor,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                configuracion.desValor = string.IsNullOrEmpty(configuracion.desValor) ? string.Empty : configuracion.desValor;
            }
            return configuracion.desValor;
        }


        public static List<ConfigValor> ListAppConfig(int codEmpresa)
        {
            List<ConfigValor> lstConfigValor = new List<ConfigValor>();
            ConfigValor configuracion = new ConfigValor();
            try
            {
                string conexion = GlobalSettings.GetBDCadenaConexion("cnxCROMSystema");
                using (DBML_ConfigDataContext SQLDC = new DBML_ConfigDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Configuracion(codEmpresa, null, string.Empty, null, true);
                    foreach (var item in resul)
                    {

                        lstConfigValor.Add(new ConfigValor()
                        {
                            codConfiguracion = item.codConfiguracion,
                            codKeyConfig = item.codKeyConfig,
                            desValor = item.desValor,
                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lstConfigValor;
        }

        #endregion

    }
}

namespace CROM.RecursosHumanos.DataAcces
{
    using CROM.BusinessEntities.RecursosHumanos;
    using CROM.BusinessEntities.RecursosHumanos.DTO;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// desNombre   : Capa de Datos 
    /// Archivo     : [Almacen.PersonalData.cs]
    /// </summary>
    public class EmpleadoData
    {
        private string conexion = string.Empty;

        public EmpleadoData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro Emplead
        /// En la BASE de DATO la Tabla : [Empleado]
        /// <summary>
        /// <param name="pEmpleado"></param>
        /// <returns></returns>
        public bool Insert(BEEmpleadoRequest pEmpleado)
        {
            bool blnResult = false;
            try
            {
                using (_RecursosHumanosDataContext SQLEmpleadoDC = new _RecursosHumanosDataContext(conexion))
                {
                   var resulSet = SQLEmpleadoDC.omgc_I_Empleado(
                          pEmpleado.codEmpresa
                        , pEmpleado.codPersonaEmpresa
                        , pEmpleado.codPersonaNatural
                        , pEmpleado.codRegAreaEmpleado
                        , pEmpleado.codRegCategoria
                        , pEmpleado.codRegEstadoCivil
                        , pEmpleado.codRegGrupoSanguineo
                        , pEmpleado.fecNacimiento
                        , pEmpleado.fecAltaLaboral
                        , pEmpleado.fecBajaLaboral
                        , pEmpleado.monSueldoBasico
                        , pEmpleado.porComisionXVenta
                        , Convert.ToChar(pEmpleado.indSexo)
                        , pEmpleado.indVendedor
                        , pEmpleado.indActivo
                        , pEmpleado.segUsuarioCrea
                        , pEmpleado.segMaquinaCrea
                        , pEmpleado.codPlanilla
                        , pEmpleado.desCorreoElectronico
                        
                    );
                    foreach (var item in resulSet)
                    {
                        pEmpleado.codEmpleado = item.codError.HasValue ? item.codError.Value : 0;
                        blnResult = item.desMessage == "OK" ? true : false;
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return blnResult;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD Empleado
        /// En la BASE de DATO la Tabla : [Empleado]
        /// <summary>
        /// <param name="pEmpleado"></param>
        /// <returns></returns>
        public bool Update(BEEmpleadoRequest pEmpleado)
        {
            bool blnResult = false;
            try
            {
                using (_RecursosHumanosDataContext SQLEmpleadoDC = new _RecursosHumanosDataContext(conexion))
                {
                    var resulSet = SQLEmpleadoDC.omgc_U_Empleado(
                          pEmpleado.codEmpresa
                        , pEmpleado.codEmpleado
                        , pEmpleado.codPersonaEmpresa
                        , pEmpleado.codPersonaNatural
                        , pEmpleado.codRegAreaEmpleado
                        , pEmpleado.codRegCategoria
                        , pEmpleado.codRegEstadoCivil
                        , pEmpleado.codRegGrupoSanguineo
                        , pEmpleado.fecNacimiento
                        , pEmpleado.fecAltaLaboral
                        , pEmpleado.fecBajaLaboral
                        , pEmpleado.monSueldoBasico
                        , pEmpleado.porComisionXVenta
                        , Convert.ToChar(pEmpleado.indSexo)
                        , pEmpleado.indVendedor
                        , pEmpleado.indActivo
                        , pEmpleado.segUsuarioEdita
                        , pEmpleado.segMaquinaEdita
                        , pEmpleado.codPlanilla
                        , pEmpleado.desCorreoElectronico
                    );
                    foreach (var item in resulSet)
                    {
                        blnResult = item.desMessage == "OK" ? true : false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return blnResult;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.Empleado
        /// En la BASE de DATO la Tabla : [Almacen.Empleado]
        /// <summary>
        /// <param name="pcodEmpleado">código del Empleado</param>
        /// <returns></returns>
        public bool Delete(int pcodEmpresa, int pcodEmpleado, string pUserDelete, string pMaquinaDelete)
        {
            bool blnResult = false;
            try
            {
                using (_RecursosHumanosDataContext SQLEmpleadoDC = new _RecursosHumanosDataContext(conexion))
                {
                    var resulSet = SQLEmpleadoDC.omgc_D_Empleado(pcodEmpresa, 
                                                                 pcodEmpleado,
                                                                 pUserDelete, 
                                                                 pMaquinaDelete );
                    foreach (var item in resulSet)
                    {
                        blnResult = item.desMessage == "OK" ? true : false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return blnResult;
        }

        #endregion

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Personal
        /// En la BASE de DATO la Tabla : [Almacen.Personal]
        /// <summary>
        /// <returns>List</returns>
        public List<BEEmpleado> List(BaseFiltroEmpleado pFiltro)
        {
            List<BEEmpleado> lstEmpleados = new List<BEEmpleado>();
            try
            {
                using (_RecursosHumanosDataContext SQLDC = new _RecursosHumanosDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Empleado(pFiltro.codEmpresa,
                                                      pFiltro.codEmpresaRUC,
                                                      pFiltro.codPersonaNatural,
                                                      pFiltro.codPlanilla,
                                                      pFiltro.codEmpleado, 
                                                      pFiltro.indActivo);

                    foreach (var item in resul)
                    {
                        lstEmpleados.Add(new BEEmpleado()
                        {
                            codEmpleado = item.codEmpleado,

                            ApellidoMaterno = item.ApellidoMaterno,
                            ApellidoPaterno = item.ApellidoPaterno,
                            Nombre1 = item.Nombre1,
                            Nombre2 = item.Nombre2,

                            desApellidos = item.desApellidos,
                            desNombres = item.desNombres,
                            ApellidosNombres = string.Concat(item.desApellidos, ",", item.desNombres),

                            codPersonaEmpresa = item.codPersonaEmpresa,
                            codPersonaNatural = item.codPersonaNatural,
                            codRegAreaEmpleado = item.codRegAreaEmpleado,
                            codRegCategoria = item.codRegCategoria,
                            codRegEstadoCivil = item.codRegEstadoCivil,
                            codRegGrupoSanguineo = item.codRegGrupoSanguineo,
                            fecNacimiento = item.fecNacimiento,
                            fecAltaLaboral = item.fecAltaLaboral,
                            fecBajaLaboral = item.fecBajaLaboral,
                            monSueldoBasico = item.monSueldoBasico,
                            porComisionXVenta = item.porComisionXVenta,
                            indSexo = item.indSexo.ToString(),
                            indVendedor= item.indVendedor,
                            indActivo = item.indActivo,
                            segUsuarioEdita = string.IsNullOrEmpty(item.segUsuarioEdita) ? item.segUsuarioCrea : item.segUsuarioEdita,
                            segFechaEdita = item.segFechaEdita != null ? item.segFechaEdita : item.segFechaCrea,
                            segMaquinaEdita = item.segMaquina,

                            desEmpleado = item.codPersonaNaturalNombre,
                            desArea = item.codRegAreaEmpleadoNombre,
                            desCategoria = item.codRegCategoriaNombre,
                            desEstadoCivil = item.codRegEstadoCivilNombre,
                            desGrupoSanguineo = item.codRegGrupoSanguineoNombre,
                            codEmpresa = item.codEmpresa,
                            codPlanilla = item.codPlanilla,
                            desCorreoElectronico = item.desCorreoElectronico,

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstEmpleados;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Empleado paginados
        /// En la BASE de DATO la Tabla : [Almacen.Personal]
        /// <summary>
        /// <returns>List</returns>
        public List<BEEmpleadoResponse> ListPaged(BEBuscaEmpleadoRequest pFiltro)
        {
            List<BEEmpleadoResponse> lstEmpleados = new List<BEEmpleadoResponse>();
            try
            {
                using (_RecursosHumanosDataContext SQLDC = new _RecursosHumanosDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Empleado_Paged(pFiltro.jqCurrentPage,
                                                            pFiltro.jqPageSize,
                                                            pFiltro.jqSortColumn,
                                                            pFiltro.jqSortOrder,
                                                            pFiltro.codEmpresa,
                                                            pFiltro.codEmpresaRUC,
                                                            pFiltro.codPlanilla,
                                                            pFiltro.codRegEstadoCivil,
                                                            pFiltro.codRegAreaEmpleado,
                                                            pFiltro.codRegCategoria,
                                                            pFiltro.desNombre,
                                                            pFiltro.indSexo,
                                                            pFiltro.indActivo);

                    foreach (var item in resul)
                    {
                        lstEmpleados.Add(new BEEmpleadoResponse()
                        {

                            ROWNUM = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0,

                            codEmpleado = item.codEmpleado,
                            desApellidos = item.desApellidos,
                            desNombres = item.desNombres,
                             
                            fecNacimiento = item.fecNacimiento,
                            fecAltaLaboral = item.fecAltaLaboral,
                            fecBajaLaboral = item.fecBajaLaboral,
                            indSexo = item.indSexo.ToString(),
                            indVendedor = item.indVendedor,
                            indActivo = item.indActivo,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaEdita = item.segFechaHoraEdita ,
                            segMaquinaEdita = item.segMaquinaEdita,
                            desArea = item.codRegAreaEmpleadoNombre,
                            desCategoria = item.codRegCategoriaNombre,
                            desEstadoCivil = item.codRegEstadoCivilNombre,
                            desGrupoSanguineo = item.codRegGrupoSanguineoNombre,
                            codPlanilla = item.codPlanilla,
                            desCorreoElectronico = item.desCorreoElectronico,

                        });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstEmpleados;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.Personal
        /// En la BASE de DATO la Tabla : [Almacen.Personal]
        /// <summary>
        /// <param name="podEmpleado"></param>
        /// <returns></returns>
        public BEEmpleado Find(int pcodEmpresa, int podEmpleado)
        {
            BEEmpleado empleado = null;
            try
            {
                using (_RecursosHumanosDataContext SQLDC = new _RecursosHumanosDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Empleado(pcodEmpresa,
                                                      string.Empty,
                                                      string.Empty,
                                                      string.Empty,
                                                      podEmpleado,
                                                      null);
                    foreach (var item in resul)
                    {
                        empleado = new BEEmpleado()
                        {
                            codEmpleado = item.codEmpleado,
                            codPersonaEmpresa = item.codPersonaEmpresa,
                            codPersonaNatural = item.codPersonaNatural,
                            ApellidoMaterno = item.ApellidoMaterno,
                            ApellidoPaterno = item.ApellidoPaterno,
                            Nombre1 = item.Nombre1,
                            Nombre2 = item.Nombre2,

                            desApellidos = item.desApellidos,
                            desNombres = item.desNombres,
                            ApellidosNombres = string.Concat(item.desApellidos, ",", item.desNombres),

                            codRegAreaEmpleado = item.codRegAreaEmpleado,
                            codRegCategoria = item.codRegCategoria,
                            codRegEstadoCivil = item.codRegEstadoCivil,
                            codRegGrupoSanguineo = item.codRegGrupoSanguineo,
                            fecNacimiento = item.fecNacimiento,
                            fecAltaLaboral = item.fecAltaLaboral,
                            fecBajaLaboral = item.fecBajaLaboral,
                            monSueldoBasico = item.monSueldoBasico,
                            porComisionXVenta = item.porComisionXVenta,
                            indSexo = item.indSexo.ToString(),
                            indVendedor = item.indVendedor,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            desEmpleado = item.codPersonaNaturalNombre,
                            desArea = item.codRegAreaEmpleadoNombre,
                            desCategoria = item.codRegCategoriaNombre,
                            desEstadoCivil = item.codRegEstadoCivilNombre,
                            desGrupoSanguineo = item.codRegGrupoSanguineoNombre,
                            codEmpresa = item.codEmpresa,
                            codPlanilla = item.codPlanilla,
                            desCorreoElectronico = item.desCorreoElectronico,

                            desImagenNombre = item.desImagenNombre

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empleado;
        }

        public BEEmpleado Find(int pcodEmpresa, string pcodPersonaEmpresa, string pcodPersonaNatural)
        {
            BEEmpleado empleado = null;
            try
            {
                using (_RecursosHumanosDataContext SQLDC = new _RecursosHumanosDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Empleado(pcodEmpresa, 
                                                      pcodPersonaEmpresa,
                                                      pcodPersonaNatural,
                                                      string.Empty,
                                                      null,
                                                      null);
                    foreach (var item in resul)
                    {
                        empleado = new BEEmpleado()
                        {
                            codEmpleado = item.codEmpleado,
                            codPersonaEmpresa = item.codPersonaEmpresa,
                            codPersonaNatural = item.codPersonaNatural,

                            ApellidoMaterno = item.ApellidoMaterno,
                            ApellidoPaterno = item.ApellidoPaterno,
                            Nombre1 = item.Nombre1,
                            Nombre2 = item.Nombre2,

                            desApellidos = item.desApellidos,
                            desNombres = item.desNombres,
                            ApellidosNombres = string.Concat(item.desApellidos, ",", item.desNombres),

                            codRegAreaEmpleado = item.codRegAreaEmpleado,
                            codRegCategoria = item.codRegCategoria,
                            codRegEstadoCivil = item.codRegEstadoCivil,
                            codRegGrupoSanguineo = item.codRegGrupoSanguineo,
                            fecNacimiento = item.fecNacimiento,
                            fecAltaLaboral = item.fecAltaLaboral,
                            fecBajaLaboral = item.fecBajaLaboral,
                            monSueldoBasico = item.monSueldoBasico,
                            porComisionXVenta = item.porComisionXVenta,
                            indSexo = item.indSexo.ToString(),
                            indVendedor = item.indVendedor,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            desEmpleado = item.codPersonaNaturalNombre,
                            desArea = item.codRegAreaEmpleadoNombre,
                            desCategoria = item.codRegCategoriaNombre,
                            desEstadoCivil = item.codRegEstadoCivilNombre,
                            desGrupoSanguineo = item.codRegGrupoSanguineoNombre,
                            codEmpresa = item.codEmpresa,
                            codPlanilla = item.codPlanilla,
                            desCorreoElectronico = item.desCorreoElectronico,

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empleado;
        }

        public BEEmpleado FindByPlanilla(int pcodEmpresa, string pcodPlanilla)
        {
            BEEmpleado empleado = null;
            try
            {
                using (_RecursosHumanosDataContext SQLDC = new _RecursosHumanosDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Empleado(pcodEmpresa, 
                                                      string.Empty,
                                                      string.Empty, 
                                                      pcodPlanilla,
                                                      null,
                                                      null);
                    foreach (var item in resul)
                    {
                        empleado = new BEEmpleado()
                        {
                            codEmpleado = item.codEmpleado,
                            codPersonaEmpresa = item.codPersonaEmpresa,
                            codPersonaNatural = item.codPersonaNatural,

                            ApellidoMaterno = item.ApellidoMaterno,
                            ApellidoPaterno = item.ApellidoPaterno,
                            Nombre1 = item.Nombre1,
                            Nombre2 = item.Nombre2,

                            desApellidos = item.desApellidos,
                            desNombres = item.desNombres,
                            ApellidosNombres = string.Concat(item.desApellidos, ",", item.desNombres),

                            codRegAreaEmpleado = item.codRegAreaEmpleado,
                            codRegCategoria = item.codRegCategoria,
                            codRegEstadoCivil = item.codRegEstadoCivil,
                            codRegGrupoSanguineo = item.codRegGrupoSanguineo,
                            fecNacimiento = item.fecNacimiento,
                            fecAltaLaboral = item.fecAltaLaboral,
                            fecBajaLaboral = item.fecBajaLaboral,
                            monSueldoBasico = item.monSueldoBasico,
                            porComisionXVenta = item.porComisionXVenta,
                            indSexo = item.indSexo.ToString(),
                            indVendedor = item.indVendedor,
                            indActivo = item.indActivo,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquina,
                            desEmpleado = item.codPersonaNaturalNombre,
                            desArea = item.codRegAreaEmpleadoNombre,
                            desCategoria = item.codRegCategoriaNombre,
                            desEstadoCivil = item.codRegEstadoCivilNombre,
                            desGrupoSanguineo = item.codRegGrupoSanguineoNombre,
                            codEmpresa = item.codEmpresa,
                            codPlanilla = item.codPlanilla,
                            desCorreoElectronico = item.desCorreoElectronico,

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empleado;
        }

        #endregion

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

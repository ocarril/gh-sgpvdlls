namespace CROM.RecursosHumanos.DataAcces
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.TablasMaestras.BussinesEntities;
    using CROM.RecursosHumanos.BusinessEntities;


    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de EmpleadoData: 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 04/03/2012-11:20:20 p.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [EmpleadoData.cs]
    /// </summary>
    public class EmpleadoDataAsis
    {
        private string conexion = string.Empty;
        public EmpleadoDataAsis()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnxCROM_RRHH"].ConnectionString;
        }

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Personal.Empleado
        /// En la BASE de DATO la Tabla : [Personal.Empleado]
        /// <summary>
        /// <returns>Entidad</returns>
        public EmpleadoAux Find(int prm_codEmpleado)
        {
            EmpleadoAux empleado = new EmpleadoAux();
            try
            {
                using (_RecursosHumanosDataContext SQLDC = new _RecursosHumanosDataContext(conexion))
                {
                    var resul = SQLDC.omgc_mnt_Find_Empleado(prm_codEmpleado);
                    foreach (var item in resul)
                    {
                        empleado = new EmpleadoAux()
                        {
                            codEmpleado = item.codEmpleado,
                            
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraEdita = item.segFechaEdita,
                            segFechaHoraCrea = item.segFechaCrea,
                            segMaquinaOrigen = item.segMaquina,
                            indActivo = item.indActivo,

                            codCalendario = item.codCalendario,
                            codRegArea = item.codRegArea,
                            codRegCategoria = item.codRegCategoria,
                            fecAltaLaboral = item.fecAltaLaboral,
                            fecBajaLaboral = item.fecBajaLaboral,
                            indEmpInterno = item.indEmpInterno,
                            indEsDobleEspecial = item.indEsDobleEspecial,
                            indEsDocente = item.indEsDocente,
                            indEsHrExtra = item.indEsHrExtra,
                            indEsIncEnReporte = item.indEsIncEnReporte,
                            indEsPagoSemanal = item.indEsIncEnReporte,
                            monSueldoBase = item.monSueldoBase,
                            numHijo = item.numHijo,
                            numMinAlmuerzo = item.numMinAlmuerzo,
                            numFlexHoraExtra = item.numFlexHoraExtra,
                            numHorMaxPorDia = item.numHorMaxPorDia,
                            numTarjeta = item.numTarjeta,
                            prcComisionVenta = item.prcComisionVenta,
                            indEsHrExtraAntesEnt = item.indEsHrExtraAntesEnt,
                            auxcodRegAreaEmpleadoNombre = item.auxcodRegAreaNombre,
                            auxcodRegCategoriaNombre = item.auxcodRegCategoriaNombre,
                            auxdesApePaterno = item.auxdesApePaterno,
                            auxdesApeMaterno = item.auxdesApeMaterno,
                            auxdesNombre1 = item.auxdesNombre1,
                            auxdesNombre2 = item.auxdesNombre2,
                            auxApellidos = item.auxdesApePaterno == null ? string.Empty : item.auxdesApePaterno + " " + item.auxdesApeMaterno == null ? string.Empty : item.auxdesApeMaterno,
                            auxNombres = item.auxdesNombre1 == null ? string.Empty : item.auxdesNombre1 + " " + item.auxdesNombre2 == null ? string.Empty : item.auxdesNombre2,
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

        #region /* Proceso de SELECT BY ID CODE FOREIGN KEY*/

        /// <summary>
        /// Retorna una LISTA de registro de la Entidad Maestros.EmpleadoAux POR FOREIGN KEY
        /// En la BASE de DATO la Tabla : [Maestros.EmpleadoAux]
        /// <summary>
        /// <returns>Entidad</returns>
        public List<EmpleadoAux> List(string prm_codPersona, string prm_codPerEmpresa)
        {
            List<EmpleadoAux> miLista = new List<EmpleadoAux>();
            try
            {
                using (_RecursosHumanosDataContext SQLDC = new _RecursosHumanosDataContext(conexion))
                {
                    var resul = SQLDC.omgc_pro_FindcodPerEmpresa_Empleado(prm_codPersona, prm_codPerEmpresa);
                    foreach (var item in resul)
                    {
                        miLista.Add(new EmpleadoAux()
                        {
                            codPersona = item.codPersona,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaHoraEdita = item.segFechaHoraEdita,
                            segFechaHoraCrea = item.segFechaHoraCrea,
                            segMaquinaOrigen = item.segMaquinaOrigen,
                            segEliminado = item.segEliminado,

                            codCalendario = item.codCalendario,
                            codRegArea = item.codRegArea,
                            codRegCategoria = item.codRegCategoria,
                            fecAltaLaboral = item.fecAltaLaboral,
                            fecBajaLaboral = item.fecBajaLaboral,
                            indEmpInterno = item.indEmpInterno,
                            indEsDobleEspecial = item.indEsDobleEspecial,
                            indEsDocente = item.indEsDocente,
                            indEsHrExtra = item.indEsHrExtra,
                            indEsIncEnReporte = item.indEsIncEnReporte,
                            indEsPagoSemanal = item.indEsIncEnReporte,
                            monSueldoBase = item.monSueldoBase,
                            numHijo = item.numHijo,
                            numMinAlmuerzo = item.numMinAlmuerzo,
                            numFlexHoraExtra = item.numFlexHoraExtra,
                            numHorMaxPorDia = item.numHorMaxPorDia,
                            numTarjeta = item.numTarjeta,
                            prcComisionVenta = item.prcComisionVenta,
                            indEsHrExtraAntesEnt = item.indEsHrExtraAntesEnt,

                            indActivo = item.indActivo,
                            auxcodRegAreaEmpleadoNombre = item.auxcodRegAreaNombre,
                            auxcodRegCategoriaNombre = item.auxcodRegCategoriaNombre,
                            auxdesApePaterno = item.auxdesApePaterno,
                            auxdesApeMaterno = item.auxdesApeMaterno,
                            auxdesNombre1 = item.auxdesNombre1,
                            auxdesNombre2 = item.auxdesNombre2,
                            auxApellidos = item.auxdesApePaterno == null ? string.Empty : item.auxdesApePaterno + " " + item.auxdesApeMaterno == null ? string.Empty : item.auxdesApeMaterno,
                            auxNombres = item.auxdesNombre1 == null ? string.Empty : item.auxdesNombre1 + " " + item.auxdesNombre2 == null ? string.Empty : item.auxdesNombre2,
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

        #region /* Proceso de INSERT RECORD - UPDATE RECORD  */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo EmpleadoAux
        /// En la BASE de DATO la Tabla : [Maestros.EmpleadoAux]
        /// <summary>
        /// <param name = >itemEmpleadoAux</param>
        public bool InsertUpdate(EmpleadoAux itemEmpleadoAux)
        {
            int codigoRetorno = -1;
            try
            {
                using (_RecursosHumanosDataContext SQLDC = new _RecursosHumanosDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_InsertUpdated_Empleado(
                        itemEmpleadoAux.codPersona,
                          itemEmpleadoAux.codRegArea,
                           itemEmpleadoAux.codRegCategoria,
                           itemEmpleadoAux.indEmpInterno,
                           itemEmpleadoAux.fecAltaLaboral,
                           itemEmpleadoAux.fecBajaLaboral,
                           itemEmpleadoAux.monSueldoBase,
                           itemEmpleadoAux.codCalendario,
                           itemEmpleadoAux.numTarjeta,
                           Convert.ToByte(itemEmpleadoAux.numHijo),
                           itemEmpleadoAux.prcComisionVenta,
                           Convert.ToByte(itemEmpleadoAux.numMinAlmuerzo),
                           Convert.ToByte(itemEmpleadoAux.numFlexHoraExtra),
                           Convert.ToByte(itemEmpleadoAux.numHorMaxPorDia),
                           itemEmpleadoAux.indEmpInterno,
                           itemEmpleadoAux.indEsDobleEspecial,
                           itemEmpleadoAux.indEsPagoSemanal,
                           itemEmpleadoAux.indEsHrExtra,
                           itemEmpleadoAux.indEsHrExtraAntesEnt,
                           itemEmpleadoAux.indEsIncEnReporte,

                        itemEmpleadoAux.segUsuarioCrea,
                        itemEmpleadoAux.indActivo);
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
        /// ELIMINA un registro de la Entidad Maestros.EmpleadoAux
        /// En la BASE de DATO la Tabla : [Maestros.EmpleadoAux]
        /// <summary>
        /// <returns>bool</returns>
        public bool Delete(string prm_codPersona)
        {
            int codigoRetorno = -1;
            try
            {
                using (_RecursosHumanosDataContext SQLDC = new _RecursosHumanosDataContext(conexion))
                {
                    codigoRetorno = SQLDC.omgc_mnt_Delete_Empleado(prm_codPersona);
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

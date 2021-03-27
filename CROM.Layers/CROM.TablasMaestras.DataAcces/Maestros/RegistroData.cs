namespace CROM.TablasMaestras.DataAcces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;

    using CROM.BusinessEntities.Maestros;
    using CROM.BusinessEntities;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de Tablas Maestras
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 26/03/2012
    /// Descripcion : Clase para capa de datos
    /// Archivo     : TablaRegistroData.cs
    /// </summary>
    public class TablaRegistroData
    {
        private string conexion = String.Empty;

        public TablaRegistroData()
        {
            conexion = Util.ConexionBD();
        }

        #region " /* Otros métodos */ "

        /// <summary>
        /// Obtiene un ultimo codigo correlativo para un item de una entidad TablaRegistro
        /// </summary>
        /// <param name="prm_codTabla">Código de la Tabla</param>
        /// <param name="prm_indTipoDato">Tipo de Dato</param>
        /// <param name="prm_indNivel">Nivel que ocupa en la tabla</param>
        /// <param name="prm_numTamanioCod">Longitud de Código que tiene cada nivel en la tabla</param>
        /// <param name="prm_codPadre">Codigo del Nivel Padre en la tabla</param>
        /// <returns>El ultimo Código generado</returns>
        public string NewcodRegistro(string prm_codTabla, string prm_indTipoDato, int prm_indNivel, int prm_numTamanioCod, string prm_codPadre)
        {
            string prm_codRegistroGenerado = String.Empty;
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    tablaDetalleDC.omgc_P_Registro_GenerarCodigo(prm_codTabla,
                                                                 prm_indNivel,
                                                                 prm_numTamanioCod,
                                                                 prm_codPadre,
                                                                 ref prm_codRegistroGenerado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prm_codRegistroGenerado;
        }


        #endregion


        // VERSION 2.0
        /// <summary>
        /// Obtiene un ultimo codigo correlativo para un item de una entidad TEMaestro
        /// </summary>
        /// <param name="pCodTabla">Código de la Tabla</param>
        /// <param name="pTipoDato">Tipo de Dato</param>
        /// <param name="pNivel">Nivel que ocupa en la tabla</param>
        /// <param name="pLongNivel">Longitud de Código que tiene cada nivel en la tabla</param>
        /// <param name="pCodPadre">Codigo del Nivel Padre en la tabla</param>
        /// <returns>El ultimo Código generado</returns>
        public string ObtenerCodigoCorrelativo(string pCodTabla, string pTipoDato, int pNivel, int pLongNivel, string pCodPadre)
        {
            string codigoGenerado = String.Empty;
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    tablaDetalleDC.omgc_P_Registro_GenerarCodigo(pCodTabla, pNivel, pLongNivel, pCodPadre, ref codigoGenerado);
                    if (pNivel == 1)
                        codigoGenerado = pCodTabla + codigoGenerado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoGenerado;
        }

        /// <summary>
        /// LISTADO de la Entidad TEDetalle
        /// </summary>
        /// <param name="pCaso">Opción para Tipo de Búsqueda</param>
        /// <param name="pCodTabla">Código de la Tabla</param>
        /// <param name="pCodArgu">Código de argumento de Búsqueda</param>
        /// <param name="pDescripcion">Descripción del registro TEDetalle</param>
        /// <param name="pIdioma">Idioma a Seleccionar</param>
        /// <param name="pNivel">Nivel que ocupa en la tabla </param>
        /// <param name="modifyc">Indicador de Retorno</param>
        /// <returns>Retorna una colección de registros de tipo TEDetalle</returns>
        public List<BERegistro> Listar(int pCaso, string pCodTabla, string pCodArgu, string pDescripcion, int pNivel)
        {
            List<BERegistro> lista = new List<BERegistro>();
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    var query = tablaDetalleDC.omgc_S_Registro(pCodTabla, pCodArgu, pDescripcion, pNivel, null);
                    foreach (var item in query)
                    {
                        lista.Add(new BERegistro()
                        {
                            CodigoTabla = item.codTabla,
                            CodigoArgumento = item.codRegistro,
                            NivelDetalle = item.numNivel,
                            DescripcionCorta = item.desNombre,
                            DescripcionLarga = item.gloDescripcion,
                            ValorDecimal = Convert.ToDecimal(item.desValorDecimal),
                            ValorCadena = item.desValorCadena,
                            ValorBoolean = Convert.ToBoolean(item.desValorLogico),
                            ValorEntero = Convert.ToInt32(item.desValorEntero),
                            Estado = Convert.ToBoolean(item.indActivo),
                            ValorFecha = item.desValorFecha,
                            SegUsuarioCrea = item.segUsuCrea,
                            SegUsuarioEdita = item.segUsuEdita,
                            SegFechaHoraCrea = item.segFechaCrea,
                            SegFechaHoraEdita = item.segFechaEdita,
                            SegMaquinaOrigen = item.segMaquinaOrigen
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public List<BERegistro> ListarPaginado(BaseFiltroMaestro pFiltro)
        {
            List<BERegistro> lista = new List<BERegistro>();
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    var query = tablaDetalleDC.omgc_S_Registro_Paged(pFiltro.GNumPagina,
                                                                     pFiltro.GTamPagina,
                                                                     pFiltro.GOrdenPor,
                                                                     pFiltro.GOrdenTipo,
                                                                     pFiltro.codTabla,
                                                                     pFiltro.codReg,
                                                                     pFiltro.desNombre,
                                                                     pFiltro.numNivel,
                                                                     pFiltro.indActivo);
                    foreach (var item in query)
                    {
                        lista.Add(new BERegistro()
                        {
                            CodigoTabla = item.codTabla,
                            CodigoArgumento = item.codRegistro,
                            NivelDetalle = item.numNivel,
                            DescripcionCorta = item.desNombre,
                            DescripcionLarga = item.gloDescripcion,
                            ValorDecimal = Convert.ToDecimal(item.desValorDecimal),
                            ValorCadena = item.desValorCadena,
                            ValorBoolean = Convert.ToBoolean(item.desValorLogico),
                            ValorEntero = Convert.ToInt32(item.desValorEntero),
                            Estado = Convert.ToBoolean(item.indActivo),
                            ValorFecha = item.desValorFecha,
                            SegUsuarioCrea = item.segUsuCrea,
                            SegUsuarioEdita = item.segUsuEdita,
                            SegFechaHoraCrea = item.segFechaCrea,
                            SegFechaHoraEdita = item.segFechaEdita,
                            SegMaquinaOrigen = item.segMaquinaOrigen,

                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        /// <summary>
        /// LISTADO de la Entidad TEDetalle para COMBOS
        /// </summary>
        /// <param name="pCaso">Opción para Tipo de Búsqueda</param>
        /// <param name="pCodTabla">Código de la Tabla</param>
        /// <param name="pCodArgu">Código de argumento de Búsqueda</param>
        /// <param name="pNivel">Nivel que ocupa en la tabla</param>
        /// <param name="pEstado">Estado del TEDetalle</param>
        /// <param name="pIdioma">Idioma a Seleccionar</param>
        /// <returns>Retorna una colección de registros de tipo TEDetalle</returns>
        public List<BERegistro> ListarCombo(string pCaso, string pCodTabla, string pCodArgu, int pNivel, int pEstado)
        {
            List<BERegistro> lista = new List<BERegistro>();
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    var query = tablaDetalleDC.omgc_S_Registro_Combo(pCodTabla, pCodArgu, pNivel, pEstado == 1 ? true : false);
                    foreach (var item in query)
                    {
                        lista.Add(new BERegistro()
                        {
                            CodigoTabla = item.codTabla,
                            CodigoArgumento = item.codRegistro,
                            NivelDetalle = item.numNivel,
                            DescripcionCorta = item.desNombre,
                            DescripcionLarga = item.gloDescripcion,
                            Estado = Convert.ToBoolean(item.indActivo),
                            ValorDecimal = Convert.ToDecimal(item.desValorDecimal),
                            ValorCadena = item.desValorCadena,
                            ValorBoolean = Convert.ToBoolean(item.desValorLogico),
                            ValorEntero = Convert.ToInt32(item.desValorEntero),
                            ValorFecha = item.desValorFecha
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        /// <summary>
        /// Registra un registro de un objeto de tipo TEDetalle
        /// </summary>
        /// <param name="pItem">Entidad TEDetalle</param>
        /// <returns>Verdadero:Registro</returns>
        public bool Registrar(BERegistro pItem)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    codigoRetorno =
                    tablaDetalleDC.omgc_I_Registro(
                        pItem.CodigoTabla,
                        pItem.CodigoArgumento,
                        Convert.ToInt32(pItem.NivelDetalle),
                        pItem.DescripcionCorta,
                        pItem.DescripcionLarga,
                        Convert.ToDecimal(pItem.ValorDecimal),
                        pItem.ValorCadena,
                        Convert.ToBoolean(pItem.ValorBoolean),
                        Convert.ToInt32(pItem.ValorEntero),
                        pItem.ValorFecha,
                        pItem.Estado,
                        pItem.SegUsuarioCrea,
                        pItem.SegMaquinaOrigen
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        /// <summary>
        /// Actualiza el registro de un objeto de tipo TEDetalle
        /// </summary>
        /// <param name="pItem">Entidad TEDetalle</param>
        /// <returns>Verdadero:Actualizo</returns>
        public bool Actualizar(BERegistro pItem)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    codigoRetorno =
                    tablaDetalleDC.omgc_U_Registro(
                        pItem.CodigoArgumento,
                        Convert.ToInt32(pItem.NivelDetalle),
                        pItem.DescripcionCorta,
                        pItem.DescripcionLarga,
                        Convert.ToDecimal(pItem.ValorDecimal),
                        pItem.ValorCadena,
                        Convert.ToBoolean(pItem.ValorBoolean),
                        Convert.ToInt32(pItem.ValorEntero),
                        pItem.ValorFecha,
                        pItem.Estado,
                        pItem.SegUsuarioEdita,
                        pItem.SegMaquinaOrigen
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        /// <summary>
        /// Elimina el registro de un objeto de tipo TEDetalle
        /// </summary>
        /// <param name="pCodTabla">Código de la Tabla</param>
        /// <param name="pCodArgu">Código de Argumento de la Tabla</param>
        /// <returns>Verdadero:Elimino</returns>
        public bool Eliminar(string pCodTabla, string pCodArgu)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    codigoRetorno =
                    tablaDetalleDC.omgc_D_Registro(pCodArgu, "Usu_" + pCodArgu, "Maq_" + pCodArgu);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        /// <summary>
        /// Obtiene todos los nombres de ubigeos por el codigo de argumento ingresado
        /// </summary>
        /// <param name="prm_CodigoArgumento">Código ARGUMENTO de la Tabla</param>
        /// <param name="prm_Idioma">Tipo de Idioma</param>
        public string ObtenerUbigeo(string prm_CodigoUBIGEO)
        {
            string UBIGEOGenerado = String.Empty;
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    tablaDetalleDC.omgc_P_Registro_Ubigeo
                        (
                        prm_CodigoUBIGEO,
                        ref UBIGEOGenerado
                        );//
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UBIGEOGenerado;
        }
    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de Registros de las tablas maestras
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/03/2015
    /// Descripcion : Clase para capa de datos
    /// Archivo     : RegistroData.cs
    /// </summary>
    public class RegistroDataNx
    {
        private string conexion = String.Empty;

        /// <summary>
        /// Metodo                  :Dispose 
        /// Propósito               :Permite Liberar de la memoria al objeto instanciado
        /// Efectos                 :N/A
        /// Retorno                 :N/A
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :21/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public RegistroDataNx()
        {
            conexion = Util.ConexionBD();
        }

        /// <summary>
        /// Buscar un REGISTRO de la entidad Registro de tablas
        /// </summary>
        /// <param name="codRegistro"></param>
        /// <returns></returns>
        public BERegistroNew Buscar(string codRegistro)
        {
            BERegistroNew objRegistro = null;
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    var query = tablaDetalleDC.omgc_S_Registro(string.Empty, codRegistro, string.Empty, null, null);
                    foreach (var item in query)
                    {
                        objRegistro = new BERegistroNew()
                        {
                            codTabla = item.codTabla,
                            codRegistro = item.codRegistro,
                            numNivel = item.numNivel,
                            desNombre = item.desNombre,
                            gloDescripcion = item.gloDescripcion,
                            desValorDecimal = item.desValorDecimal,
                            desValorCadena = item.desValorCadena,
                            desValorLogico = item.desValorLogico,
                            desValorEntero = item.desValorEntero,
                            indActivo = item.indActivo,
                            desValorFecha = item.desValorFecha,
                            segUsuarioCrea = item.segUsuCrea,
                            segUsuarioEdita = item.segUsuEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquinaOrigen,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objRegistro;
        }

        /// <summary>
        /// LISTADO de la entidad Registro de tablas paginado para JQuery
        /// </summary>
        /// <param name="objFiltro"></param>
        /// <returns></returns>
        public List<BERegistroNew> Listar(BaseFiltroMaestro objFiltro)
        {
            List<BERegistroNew> lstRegistro = new List<BERegistroNew>();
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    var query = tablaDetalleDC.omgc_S_Registro(objFiltro.codTabla,
                                                               objFiltro.codReg,
                                                               objFiltro.desNombre,
                                                               objFiltro.numNivel,
                                                               objFiltro.indActivo);
                    foreach (var item in query)
                    {
                        lstRegistro.Add(new BERegistroNew()
                        {
                            codTabla = item.codTabla,
                            codRegistro = item.codRegistro,
                            numNivel = item.numNivel,
                            desNombre = item.desNombre,
                            gloDescripcion = item.gloDescripcion,
                            desValorDecimal = Convert.ToDecimal(item.desValorDecimal),
                            desValorCadena = item.desValorCadena,
                            desValorLogico = Convert.ToBoolean(item.desValorLogico),
                            desValorEntero = Convert.ToInt32(item.desValorEntero),
                            indActivo = Convert.ToBoolean(item.indActivo),
                            desValorFecha = item.desValorFecha,
                            segUsuarioCrea = item.segUsuCrea,
                            segUsuarioEdita = item.segUsuEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaElimina = item.segMaquinaOrigen,

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstRegistro;
        }

        /// <summary>
        /// LISTADO de la entidad Registro de tablas paginado para JQuery
        /// </summary>
        /// <param name="objFiltro"></param>
        /// <returns></returns>
        public List<BERegistroNew> ListarPaginado(BaseFiltroMaestro objFiltro)
        {
            List<BERegistroNew> lstRegistro = new List<BERegistroNew>();
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    var query = tablaDetalleDC.omgc_S_Registro_Paged(objFiltro.GNumPagina,
                                                                     objFiltro.GTamPagina,
                                                                     objFiltro.GOrdenPor,
                                                                     objFiltro.GOrdenTipo,

                                                                     objFiltro.codTabla,
                                                                     objFiltro.codReg,
                                                                     objFiltro.desNombre,
                                                                     objFiltro.numNivel,
                                                                     objFiltro.indActivo);
                    foreach (var item in query)
                    {
                        lstRegistro.Add(new BERegistroNew()
                        {
                            codTabla = item.codTabla,
                            codRegistro = item.codRegistro,
                            numNivel = item.numNivel,
                            desNombre = item.desNombre,
                            gloDescripcion = item.gloDescripcion,
                            desValorDecimal = Convert.ToDecimal(item.desValorDecimal),
                            desValorCadena = item.desValorCadena,
                            desValorLogico = Convert.ToBoolean(item.desValorLogico),
                            desValorEntero = Convert.ToInt32(item.desValorEntero),
                            indActivo = Convert.ToBoolean(item.indActivo),
                            desValorFecha = item.desValorFecha,
                            segUsuarioCrea = item.segUsuCrea,
                            segUsuarioEdita = item.segUsuEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquinaCrea = item.segMaquinaOrigen,

                            ROW = item.ROWNUM.HasValue ? item.ROWNUM.Value : 0,
                            TOTALROWS = item.TOTALROWS.HasValue ? item.TOTALROWS.Value : 0
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstRegistro;
        }

        /// <summary>
        /// LISTADO de la Entidad Registro para COMBOS
        /// </summary>
        /// <param name="objFiltro"></param>
        /// <returns></returns>
        public List<BERegistroNew> ListarCombo(BaseFiltroMaestro objFiltro)
        {
            List<BERegistroNew> lstRegistro = new List<BERegistroNew>();
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    var query = tablaDetalleDC.omgc_S_Registro_Combo(objFiltro.codTabla,
                                                                     objFiltro.codReg,
                                                                     objFiltro.numNivel,
                                                                     objFiltro.indActivo);
                    foreach (var item in query)
                    {
                        lstRegistro.Add(new BERegistroNew()
                        {
                            codTabla = item.codTabla,
                            codRegistro = item.codRegistro,
                            numNivel = item.numNivel,
                            desNombre = item.desNombre,
                            gloDescripcion = item.gloDescripcion,
                            indActivo = item.indActivo,
                            desValorDecimal = item.desValorDecimal,
                            desValorCadena = item.desValorCadena,
                            desValorLogico = item.desValorLogico,
                            desValorEntero = item.desValorEntero,
                            desValorFecha = item.desValorFecha
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstRegistro;
        }

        /// <summary>
        /// Obtiene la descripcion del ubigeo de forma horizontal
        /// </summary>
        /// <param name="codRegistroUbigeo"></param>
        /// <returns></returns>
        public string ObtenerUbigeo(string codRegistroUbigeo)
        {
            string desUbigeoGenerado = String.Empty;
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    tablaDetalleDC.omgc_P_Registro_Ubigeo
                        (
                        codRegistroUbigeo,
                        ref desUbigeoGenerado
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return desUbigeoGenerado;
        }

        /// <summary>
        /// Obtiene un ultimo codigo correlativo para un item de una entidad Registro
        /// </summary>
        /// <param name="objFiltro"></param>
        /// <returns></returns>
        public string GenerarCodRegistro(BaseFiltroMaestro objFiltro)
        {
            string prm_codRegistroGenerado = String.Empty;
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    tablaDetalleDC.omgc_P_Registro_GenerarCodigo(objFiltro.codTabla,
                                                                 objFiltro.numNivel,
                                                                 objFiltro.numLongitudNivel,
                                                                 objFiltro.codRegistroPadre,
                                                                 ref prm_codRegistroGenerado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prm_codRegistroGenerado;
        }
    }

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de Registros de las tablas maestras
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/03/2015
    /// Descripcion : Clase para capa de datos
    /// Archivo     : RegistroData.cs
    /// </summary>
    public class RegistroDataTx
    {
        private string conexion = String.Empty;

        /// <summary>
        /// Metodo                  :Dispose 
        /// Propósito               :Permite Liberar de la memoria al objeto instanciado
        /// Efectos                 :N/A
        /// Retorno                 :N/A
        /// Autor                   :OCR - Orlando Carril R.
        /// Fecha/Hora de Creación  :21/08/2015
        /// Modificado              :N/A
        /// Fecha/Hora Modificación :N/A
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public RegistroDataTx()
        {
            conexion = Util.ConexionBD();
        }

        /// <summary>
        /// Insertar un registro de un objeto Registro
        /// </summary>
        /// <param name="objRegistro"></param>
        /// <returns></returns>
        public bool Registrar(BERegistroNew objRegistro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    tablaDetalleDC.omgc_I_Registro(
                                   objRegistro.codTabla,
                                   objRegistro.codRegistro,
                                   objRegistro.numNivel,
                                   objRegistro.desNombre,
                                   objRegistro.gloDescripcion,
                                   objRegistro.desValorDecimal,
                                   objRegistro.desValorCadena,
                                   objRegistro.desValorLogico,
                                   objRegistro.desValorEntero,
                                   objRegistro.desValorFecha,
                                   objRegistro.indActivo,
                                   objRegistro.segUsuarioCrea,
                                   objRegistro.segMaquinaCrea
                                   );
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        /// <summary>
        /// Actualiza un registro de un objeto Registro
        /// </summary>
        /// <param name="objRegistro"></param>
        /// <returns></returns>
        public bool Actualizar(BERegistroNew objRegistro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    tablaDetalleDC.omgc_U_Registro(
                                   objRegistro.codRegistro,
                                   objRegistro.numNivel,
                                   objRegistro.desNombre,
                                   objRegistro.gloDescripcion,
                                   objRegistro.desValorDecimal,
                                   objRegistro.desValorCadena,
                                   objRegistro.desValorLogico,
                                   objRegistro.desValorEntero,
                                   objRegistro.desValorFecha,
                                   objRegistro.indActivo,
                                   objRegistro.segUsuarioEdita,
                                   objRegistro.segMaquinaCrea
                        );
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        /// <summary>
        /// Elimina el registro de un objeto de tipo Registro
        /// </summary>
        /// <param name="codRegistro"></param>
        /// <returns></returns>
        public bool Eliminar(BaseFiltroMaestro objFiltro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_DBMLMaestrosDataContext tablaDetalleDC = new _DBMLMaestrosDataContext(conexion))
                {
                    tablaDetalleDC.omgc_D_Registro(objFiltro.codRegistro, objFiltro.segUsuarioEdita, objFiltro.segMaquinaOrigen);
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

    }

}

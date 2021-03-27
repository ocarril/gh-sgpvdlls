namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 24/01/2012-03:48:42 p.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.LetraDeCambioData.cs]
    /// </summary>
    public class LetraDeCambioData
    {
        private string conexion = string.Empty;
        public LetraDeCambioData()
        {
            conexion = Util.ConexionBD();
        }
        #region /* Proceso de SELECT ALL */

        public List<LetraDeCambioAux> List(int pcodEmpresa, int prm_codDocumReg)
        {
            List<LetraDeCambioAux> lstLetraDeCambio = new List<LetraDeCambioAux>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_LetraDeCambio_codDocumReg(pcodEmpresa, prm_codDocumReg);
                    foreach (var item in resul)
                    {
                        lstLetraDeCambio.Add(new LetraDeCambioAux()
                        {
                            codDocumReg = item.codDocumReg,
                            codLetraDeCambio  = item.codLetraDeCambio,
                            codEmpresa = item.codEmpresa.Value,
                            codPuntoDeVenta = item.codPuntoDeVenta,
                            codDocumento = item.codDocumento,
                            numDocumento = item.numDocumento,
                            numLetraInterna = item.numLetraInterna,
                            numLetraExterno = item.numLetraExterno,
                            codPersonaEmisor = item.codPersonaEmisor,
                            fecEmision = item.fecEmision,
                            fecRecepcion = item.fecRecepcion,
                            fecVencimiento = item.fecVencimiento,
                            codRegistroMoneda = item.codRegistroMoneda,
                            monValorDeLetra = item.monValorDeLetra,
                            codPersonaAsignado = item.codPersonaAsignado,
                            codPersonaAvalista = item.codPersonaAvalista,
                            codPersonaBanco = item.codPersonaBanco,
                            desClausula = item.desClausula,
                            gloComentario = item.gloComentario,
                            codRegistroEstado = item.codRegistroEstado,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquina = item.segMaquina,
                            auxcodDocumentoNombre = item.auxcodDocumentoNombre,
                            auxcodPersonaAsignadoNombre = item.auxcodPersonaAsignadoNombre,
                            auxcodPersonaAvalistaNombre = item.auxcodPersonaAvalistaNombre,
                            auxcodPersonaBancoNombre = item.auxcodPersonaBancoNombre,
                            auxcodPersonaEmisorNombre = item.auxcodPersonaEmisorNombre,
                            auxcodPersonaEmpreNombre = item.codEmpresaNombre,
                            auxcodPuntoDeVentaNombre = item.auxcodPuntoDeVentaNombre,
                            auxcodRegistroEstadoNombre = item.auxcodRegistroEstadoNombre,
                            auxcodRegistroMonedaNombre = item.auxcodRegistroMonedaNombre,
                            auxindDocumento = item.auxindDocumento,
                            auxmonImportePagadoMonInt = item.auxmonImportePagadoMonInt,
                            auxmonImportePagadoMonNac = item.auxmonImportePagadoMonNac,
                            auxmonImporteSaldo = item.monValorDeLetra - (item.auxmonImportePagadoMonNac == null ? 
                                                 0 : item.auxmonImportePagadoMonNac.Value),
                            auxdesLetraCambio = item.numLetraExterno + " - " + 
                                                item.fecVencimiento.ToShortDateString() + " - " + 
                                                item.monValorDeLetra,
                            auxcodPersonaAsignadoDireccion = item.auxcodPersonaAsignadoDireccion,
                            auxcodPersonaAsignadoLugar = item.auxcodPersonaAsignadoLugar,
                            auxcodRegistroMonedaSimbolo = item.auxcodRegistroMonedaSimbolo,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstLetraDeCambio;
        }

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.LetraDeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.LetraDeCambio]
        /// <summary>
        /// <returns>List</returns>
        public List<LetraDeCambioAux> List(BaseFiltro pFiltro) 
        {
            List<LetraDeCambioAux> lstLetraDeCambio = new List<LetraDeCambioAux>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_LetraDeCambio(pFiltro.codEmpresa,
                                                           pFiltro.fecInicio,
                                                           pFiltro.fecFinal,
                                                           pFiltro.codPuntoVenta,
                                                           pFiltro.codDocumento,
                                                           pFiltro.numDocumento,
                                                           pFiltro.codRegEstado,
                                                           pFiltro.codRegDestinoDocum,
                                                           pFiltro.codPerEntidad,
                                                           pFiltro.codEmpleado);
                    foreach (var item in resul)
                    {
                        lstLetraDeCambio.Add(new LetraDeCambioAux()
                        {
                            codDocumReg=item.codDocumReg,
                            codLetraDeCambio = item.codLetraDeCambio,
                            codEmpresa = item.codEmpresa,
                            codPuntoDeVenta = item.codPuntoDeVenta,
                            codDocumento = item.codDocumento,
                            numDocumento = item.numDocumento,
                            numLetraInterna = item.numLetraInterna,
                            numLetraExterno = item.numLetraExterno,
                            codPersonaEmisor = item.codPersonaEmisor,
                            fecEmision = item.fecEmision,
                            fecRecepcion = item.fecRecepcion,
                            fecVencimiento = item.fecVencimiento,
                            codRegistroMoneda = item.codRegistroMoneda,
                            monValorDeLetra = item.monValorDeLetra,
                            codPersonaAsignado = item.codPersonaAsignado,
                            codPersonaAvalista = item.codPersonaAvalista,
                            codPersonaBanco = item.codPersonaBanco,
                            desClausula = item.desClausula,
                            gloComentario = item.gloComentario,
                            codRegistroEstado = item.codRegistroEstado,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquina = item.segMaquina,
                            auxcodDocumentoNombre = item.auxcodDocumentoNombre,
                            auxcodPersonaAsignadoNombre = item.auxcodPersonaAsignadoNombre,
                            auxcodPersonaAvalistaNombre = item.auxcodPersonaAvalistaNombre,
                            auxcodPersonaBancoNombre = item.auxcodPersonaBancoNombre,
                            auxcodPersonaEmisorNombre = item.auxcodPersonaEmisorNombre,
                            auxcodPersonaEmpreNombre = item.codEmpresaNombre,
                            auxcodPuntoDeVentaNombre = item.auxcodPuntoDeVentaNombre,
                            auxcodRegistroEstadoNombre = item.auxcodRegistroEstadoNombre,
                            auxcodRegistroMonedaNombre = item.auxcodRegistroMonedaNombre,
                            auxindDocumento = item.auxindDocumento,
                            auxmonImportePagadoMonInt = item.auxmonImportePagadoMonInt,
                            auxmonImportePagadoMonNac = item.auxmonImportePagadoMonNac,
                            auxmonImporteSaldo = item.monValorDeLetra - (item.auxmonImportePagadoMonNac),
                            auxdesLetraCambio = item.numLetraExterno + " - " + 
                                                item.fecVencimiento.ToShortDateString() + " - " + 
                                                item.monValorDeLetra,
                            auxdesMovDetaCantidad = item.auxdesMovDetaCantidad, 
                            auxdesMovDetaPrecio = item.auxdesMovDetaPrecio, 
                            auxdesMovDetaProducto = item.auxdesMovDetaProducto,
                            numDocumentoExterno = item.numDocumentoExterno
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstLetraDeCambio;
        }

        #endregion


        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.LetraDeCambio
        /// En la BASE de DATO la Tabla : [GestionComercial.LetraDeCambio]
        /// <summary>
        /// <returns>Entidad</returns>
        public LetraDeCambioAux Find(int pcodEmpresa, int prm_codLetraDeCambio)
        {
            LetraDeCambioAux objLetraDeCambio = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_LetraDeCambio_Id(pcodEmpresa, prm_codLetraDeCambio);
                    foreach (var item in resul)
                    {
                        objLetraDeCambio = new LetraDeCambioAux()
                        {
                            codLetraDeCambio = item.codLetraDeCambio,
                            codEmpresa = item.codEmpresa,
                            codPuntoDeVenta = item.codPuntoDeVenta,
                            codDocumento = item.codDocumento,
                            numDocumento = item.numDocumento,
                            numLetraInterna = item.numLetraInterna,
                            numLetraExterno = item.numLetraExterno,
                            codPersonaEmisor = item.codPersonaEmisor,
                            fecEmision = item.fecEmision,
                            fecRecepcion = item.fecRecepcion,
                            fecVencimiento = item.fecVencimiento,
                            codRegistroMoneda = item.codRegistroMoneda,
                            monValorDeLetra = item.monValorDeLetra,
                            codPersonaAsignado = item.codPersonaAsignado,
                            codPersonaAvalista = item.codPersonaAvalista,
                            codPersonaBanco = item.codPersonaBanco,
                            desClausula = item.desClausula,
                            gloComentario = item.gloComentario,
                            codRegistroEstado = item.codRegistroEstado,
                            segUsuarioCrea = item.segUsuarioCrea,
                            segUsuarioEdita = item.segUsuarioEdita,
                            segFechaCrea = item.segFechaCrea,
                            segFechaEdita = item.segFechaEdita,
                            segMaquina = item.segMaquina,
                            auxcodDocumentoNombre = item.auxcodDocumentoNombre,
                            auxcodPersonaAsignadoNombre = item.auxcodPersonaAsignadoNombre,
                            auxcodPersonaAvalistaNombre = item.auxcodPersonaAvalistaNombre,
                            auxcodPersonaBancoNombre = item.auxcodPersonaBancoNombre,
                            auxcodPersonaEmisorNombre = item.auxcodPersonaEmisorNombre,
                            auxcodPersonaEmpreNombre = item.codEmpresaNombre,
                            auxcodPuntoDeVentaNombre = item.auxcodPuntoDeVentaNombre,
                            auxcodRegistroEstadoNombre = item.auxcodRegistroEstadoNombre,
                            auxcodRegistroMonedaNombre = item.auxcodRegistroMonedaNombre

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objLetraDeCambio;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        ///// <summary>
        ///// Almacena el registro de una ENTIDAD de registro de Tipo LetraDeCambio
        ///// En la BASE de DATO la Tabla : [GestionComercial.LetraDeCambio]
        ///// <summary>
        ///// <param name = >itemLetraDeCambio</param>
        //public void Insert(LetraDeCambioAux itemLetraDeCambio)
        //{
        //    int? codigoRetorno = null;
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            SQLDC.omgc_I_LetraDeCambio(
        //               ref codigoRetorno,
        //               itemLetraDeCambio.codDocumReg,
        //               itemLetraDeCambio.numLetraInterna,
        //               itemLetraDeCambio.numLetraExterno,
        //               itemLetraDeCambio.codPersonaEmisor,
        //               itemLetraDeCambio.fecEmision,
        //               itemLetraDeCambio.fecRecepcion,
        //               itemLetraDeCambio.fecVencimiento,
        //               itemLetraDeCambio.codRegistroMoneda,
        //               itemLetraDeCambio.monValorDeLetra,
        //               itemLetraDeCambio.codPersonaAsignado,
        //               itemLetraDeCambio.codPersonaAvalista,
        //               itemLetraDeCambio.codPersonaBanco,
        //               itemLetraDeCambio.desClausula,
        //               itemLetraDeCambio.gloComentario,
        //               itemLetraDeCambio.codRegistroEstado,
        //               itemLetraDeCambio.segUsuarioCrea);
        //            itemLetraDeCambio.codLetraDeCambio = codigoRetorno.HasValue ? codigoRetorno.Value : 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return;
        //}

        #endregion

        #region /* Proceso de UPDATE RECORD */

        ///// <summary>
        ///// Almacena el registro de una ENTIDAD de registro de Tipo LetraDeCambio
        ///// En la BASE de DATO la Tabla : [GestionComercial.LetraDeCambio]
        ///// <summary>
        ///// <param name = >itemLetraDeCambio</param>
        //public bool Update(LetraDeCambioAux itemLetraDeCambio)
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            codigoRetorno = SQLDC.omgc_U_LetraDeCambio(
        //                itemLetraDeCambio.codLetraDeCambio,
        //                itemLetraDeCambio.codDocumReg,
        //                itemLetraDeCambio.numLetraInterna,
        //                itemLetraDeCambio.numLetraExterno,
        //                itemLetraDeCambio.codPersonaEmisor,
        //                itemLetraDeCambio.fecEmision,
        //                itemLetraDeCambio.fecRecepcion,
        //                itemLetraDeCambio.fecVencimiento,
        //                itemLetraDeCambio.codRegistroMoneda,
        //                itemLetraDeCambio.monValorDeLetra,
        //                itemLetraDeCambio.codPersonaAsignado,
        //                itemLetraDeCambio.codPersonaAvalista,
        //                itemLetraDeCambio.codPersonaBanco,
        //                itemLetraDeCambio.desClausula,
        //                itemLetraDeCambio.gloComentario,
        //                itemLetraDeCambio.codRegistroEstado,
        //                itemLetraDeCambio.segUsuarioEdita,
        //                itemLetraDeCambio.segFechaEdita);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == 0 ? true : false;
        //}

        //public bool UpdatecodRegistroEstado(LetraDeCambioAux itemLetraDeCambio)
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //             SQLDC.omgc_U_LetraDeCambio_codRegistroEstado(
        //                itemLetraDeCambio.codLetraDeCambio,
        //                itemLetraDeCambio.codDocumReg,
        //                itemLetraDeCambio.numLetraInterna,
        //                itemLetraDeCambio.codRegistroEstado,
        //                itemLetraDeCambio.segUsuarioEdita);
        //             codigoRetorno = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == 0 ? true : false;
        //}

        //public bool UpdatefecRecepcion(LetraDeCambioAux itemLetraDeCambio)
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //             SQLDC.omgc_U_LetraDeCambio_fecRecepcion(
        //                itemLetraDeCambio.codLetraDeCambio,
        //                itemLetraDeCambio.codDocumReg,
        //                itemLetraDeCambio.numLetraInterna,
        //                itemLetraDeCambio.fecRecepcion,
        //                itemLetraDeCambio.segUsuarioEdita);
        //             codigoRetorno = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == 0 ? true : false;
        //}
        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        ///// <summary>
        ///// ELIMINA un registro de la Entidad GestionComercial.LetraDeCambio
        ///// En la BASE de DATO la Tabla : [GestionComercial.LetraDeCambio]
        ///// <summary>
        ///// <returns>bool</returns>
        //public bool Delete(int prm_codLetraDeCambioo)
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            SQLDC.omgc_D_LetraDeCambio(prm_codLetraDeCambioo);
        //            codigoRetorno = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == 0 ? true : false;
        //}

        //public bool Delete(int? prm_codDocumReg)
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            SQLDC.omgc_D_LetraDeCambio_codDocumReg(prm_codDocumReg);
        //            codigoRetorno = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == 0 ? true : false;
        //}

        #endregion

    }
}

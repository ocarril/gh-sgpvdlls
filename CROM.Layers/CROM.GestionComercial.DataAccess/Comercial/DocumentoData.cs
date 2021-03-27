namespace CROM.GestionComercial.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [GestionComercial.ComprobantesData.cs]
    /// </summary>
    public class DocumentoData
    {
        private string conexion = string.Empty;

        public DocumentoData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="objComprobantes"></param>
        /// <returns></returns>
        public bool Insert(BEDocumento objComprobantes)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_I_Documento(
                       objComprobantes.CodigoComprobante,
                       objComprobantes.CodigoPersonaEmpre,
                       objComprobantes.CodigoArguComprobante,
                       objComprobantes.Descripcion,
                       objComprobantes.Abreviatura,
                       objComprobantes.CodigoArguCentroCosto,
                       objComprobantes.CodigoComprobanteAsos,
                       objComprobantes.CodigoArguDestinoComp,
                       objComprobantes.LineasComprobante,
                       Convert.ToByte(objComprobantes.CantidadCopias),
                       objComprobantes.IncidenciaEnStocks,
                       objComprobantes.IncidenciaEnCtaCte,
                       objComprobantes.IncidenciaEnCaja,
                       objComprobantes.EsImpRetencion,
                       objComprobantes.EsComprobanteImpreso,
                       objComprobantes.EsFacturadoPorLotes,
                       objComprobantes.EsComprobanteFiscal,
                       objComprobantes.EsComprobanteLocal,
                       objComprobantes.EsNumerAutomatica,
                       objComprobantes.EsPFormaPago,
                       objComprobantes.EsSaleCajaDiaria,
                       objComprobantes.PideComprobanteSecun,
                       objComprobantes.PideNroExternoComp,
                       objComprobantes.PideNroExternoComp2,
                       objComprobantes.PideMoneda,
                       objComprobantes.PideTransportista,
                       objComprobantes.PideMotivo,
                       objComprobantes.PideDepoDestino,
                       objComprobantes.PidePeriodoFiscal,
                       objComprobantes.PideAnioFiscal,
                       objComprobantes.PideCuentaContable,
                       objComprobantes.PideCodigoProducto,
                       objComprobantes.PideDetalle,
                       objComprobantes.PideCantidad,
                       objComprobantes.PideUnidadMedida,
                       objComprobantes.PidePartida,
                       objComprobantes.PidePrecioUnitario,
                       objComprobantes.PideCostoUnitario,
                       objComprobantes.MuestaTotalDetalle,
                       objComprobantes.PideDsctoDetalle,
                       objComprobantes.PideImpuesto,
                       objComprobantes.PideDeposito,
                       objComprobantes.PideFechaVencimiento,
                       objComprobantes.PideVendedor,
                       objComprobantes.PideDespachador,
                       objComprobantes.PideFechaEntrega,
                       objComprobantes.PideCondicion,
                       objComprobantes.PideOrdenDeServicio,
                       objComprobantes.PideObservaciones,
                       objComprobantes.PideReferencia01,
                       objComprobantes.PideReferencia02,
                       objComprobantes.PideGuiaDeSalida,
                       objComprobantes.PidePedidoDeAdquis,
                       objComprobantes.ExigeDocumentoAnexo,
                       objComprobantes.Estado,
                       objComprobantes.segUsuarioCrea,
                       objComprobantes.CodigoArguEstEMIDefault,
                       objComprobantes.CodigoArguEstANUDefault,
                       objComprobantes.CodigoArguEstPRODefault,
                       objComprobantes.EsGravado,
                       objComprobantes.CodigoArguTipoDeOperacionDefault,
                       objComprobantes.PideContactoEntidad,
                       objComprobantes.segMaquinaCrea);
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="objComprobantes"></param>
        /// <returns></returns>
        public bool Update(BEDocumento objComprobantes)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_U_Documento(
                        objComprobantes.CodigoComprobante,
                        objComprobantes.CodigoPersonaEmpre,
                        objComprobantes.CodigoArguComprobante,
                        objComprobantes.Descripcion,
                        objComprobantes.Abreviatura,
                        objComprobantes.CodigoArguCentroCosto,
                        objComprobantes.CodigoComprobanteAsos,
                        objComprobantes.CodigoArguDestinoComp,
                        objComprobantes.LineasComprobante,
                        Convert.ToByte(objComprobantes.CantidadCopias),
                        objComprobantes.IncidenciaEnStocks,
                        objComprobantes.IncidenciaEnCtaCte,
                        objComprobantes.IncidenciaEnCaja,
                        objComprobantes.EsImpRetencion,
                        objComprobantes.EsComprobanteImpreso,
                        objComprobantes.EsFacturadoPorLotes,
                        objComprobantes.EsComprobanteFiscal,
                        objComprobantes.EsComprobanteLocal,
                        objComprobantes.EsNumerAutomatica,
                        objComprobantes.EsPFormaPago,
                        objComprobantes.EsSaleCajaDiaria,
                        objComprobantes.PideComprobanteSecun,
                        objComprobantes.PideNroExternoComp,
                        objComprobantes.PideNroExternoComp2,
                        objComprobantes.PideMoneda,
                        objComprobantes.PideTransportista,
                        objComprobantes.PideMotivo,
                        objComprobantes.PideDepoDestino,
                        objComprobantes.PidePeriodoFiscal,
                        objComprobantes.PideAnioFiscal,
                        objComprobantes.PideCuentaContable,
                        objComprobantes.PideCodigoProducto,
                        objComprobantes.PideDetalle,
                        objComprobantes.PideCantidad,
                        objComprobantes.PideUnidadMedida,
                        objComprobantes.PidePartida,
                        objComprobantes.PidePrecioUnitario,
                        objComprobantes.PideCostoUnitario,
                        objComprobantes.MuestaTotalDetalle,
                        objComprobantes.PideDsctoDetalle,
                        objComprobantes.PideImpuesto,
                        objComprobantes.PideDeposito,
                        objComprobantes.PideFechaVencimiento,
                        objComprobantes.PideVendedor,
                        objComprobantes.PideDespachador,
                        objComprobantes.PideFechaEntrega,
                        objComprobantes.PideCondicion,
                        objComprobantes.PideOrdenDeServicio,
                        objComprobantes.PideObservaciones,
                        objComprobantes.PideReferencia01,
                        objComprobantes.PideReferencia02,
                        objComprobantes.PideGuiaDeSalida,
                        objComprobantes.PidePedidoDeAdquis,
                        objComprobantes.ExigeDocumentoAnexo,
                        objComprobantes.Estado,
                        objComprobantes.segUsuarioEdita,
                        objComprobantes.CodigoArguEstEMIDefault,
                        objComprobantes.CodigoArguEstANUDefault,
                        objComprobantes.CodigoArguEstPRODefault,
                        objComprobantes.EsGravado,
                        objComprobantes.CodigoArguTipoDeOperacionDefault,
                        objComprobantes.PideContactoEntidad,
                        objComprobantes.segMaquinaCrea);
                    codigoRetorno = 0;
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
        /// ELIMINA un registro de la Entidad GestionComercial.Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="prm_CodigoComprobante"></param>
        /// <returns></returns>
        public bool Delete(string prm_CodigoComprobante)
        {
            int codigoRetorno = -1;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    SQLDC.omgc_D_Documento(prm_CodigoComprobante);
                    codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumento> List(BaseFiltroDocumento pFiltro)
        {
            List<BEDocumento> lstDocumentos = new List<BEDocumento>();
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Documento(pFiltro.codEmpresaRUC,
                                                        pFiltro.codDocumento,
                                                        pFiltro.codDocumento,
                                                        pFiltro.codRegDocumento,
                                                        pFiltro.codDocumentoAsos,
                                                        pFiltro.codRegDestinoDocum,
                                                        pFiltro.desNombre,
                                                        pFiltro.indFiscal,
                                                        pFiltro.indLocal,
                                                        pFiltro.Abreviatura,
                                                        pFiltro.indEstado);
                    foreach (var item in resul)
                    {
                        lstDocumentos.Add(new BEDocumento()
                        {
                            CodigoComprobante = item.CodigoComprobante,
                            CodigoArguComprobante = item.CodigoArguComprobante,
                            CodigoArguComprobanteNombre = item.CodigoArguComprobanteNombre,
                            Descripcion = item.Descripcion,
                            Abreviatura = item.Abreviatura,
                            CodigoArguCentroCosto = item.CodigoArguCentroCosto,
                            CodigoArguCentroCostoNombre = item.CodigoArguCentroCostoNombre,
                            CodigoComprobanteAsos = item.CodigoComprobanteAsos,
                            CodigoComprobanteAsosNombre = item.CodigoComprobanteAsosNombre,
                            CodigoArguDestinoComp = item.CodigoArguDestinoComp,
                            CodigoArguDestinoCompNombre = item.CodigoArguDestinoCompNombre,
                            LineasComprobante = item.LineasComprobante,
                            CantidadCopias = item.CantidadCopias,
                            IncidenciaEnStocks = item.IncidenciaEnStocks,
                            IncidenciaEnCtaCte = item.IncidenciaEnCtaCte,
                            IncidenciaEnCaja = item.IncidenciaEnCaja,
                            EsImpRetencion = item.EsImpRetencion,
                            EsComprobanteImpreso = item.EsComprobanteImpreso,
                            EsFacturadoPorLotes = item.EsFacturadoPorLotes,
                            EsComprobanteFiscal = item.EsComprobanteFiscal,
                            EsComprobanteLocal = item.EsComprobanteLocal,
                            EsNumerAutomatica = item.EsNumerAutomatica,
                            EsPFormaPago = item.EsPFormaPago,
                            EsSaleCajaDiaria = item.EsSaleCajaDiaria,
                            PideComprobanteSecun = item.PideComprobanteSecun,
                            PideNroExternoComp = item.PideNroExternoComp,
                            PideNroExternoComp2 = item.PideNroExternoComp2,
                            PideMoneda = item.PideMoneda,
                            PideTransportista = item.PideTransportista,
                            PideMotivo = item.PideMotivo,
                            PideDepoDestino = item.PideDepoDestino,
                            PidePeriodoFiscal = item.PidePeriodoFiscal,
                            PideAnioFiscal = item.PideAnioFiscal,
                            PideCuentaContable = item.PideCuentaContable,
                            PideCodigoProducto = item.PideCodigoProducto,
                            PideDetalle = item.PideDetalle,
                            PideCantidad = item.PideCantidad,
                            PideUnidadMedida = item.PideUnidadMedida,
                            PidePartida = item.PidePartida,
                            PidePrecioUnitario = item.PidePrecioUnitario,
                            PideCostoUnitario = item.PideCostoUnitario,
                            MuestaTotalDetalle = item.MuestaTotalDetalle,
                            PideDsctoDetalle = item.PideDsctoDetalle,
                            PideImpuesto = item.PideImpuesto,
                            PideDeposito = item.PideDeposito,
                            PideFechaVencimiento = item.PideFechaVencimiento,
                            PideVendedor = item.PideVendedor,
                            PideDespachador = item.PideDespachador,
                            PideFechaEntrega = item.PideFechaEntrega,
                            PideCondicion = item.PideCondicion,
                            ExigeDocumentoAnexo = item.ExigeDocumentoAnexo,
                            CodigoPersonaEmpre = item.CodigoPersonaEmpre,
                            CodigoPersonaEmpreNombre = item.CodigoPersonaEmpreNombre,
                            PideGuiaDeSalida = item.PideGuiaDeSalida,
                            PideObservaciones = item.PideObservaciones,
                            PideOrdenDeServicio = item.PideOrdenDeServicio,
                            PidePedidoDeAdquis = item.PidePedidoDeAdquis,
                            PideReferencia01 = item.PideReferencia01,
                            PideReferencia02 = item.PideReferencia02,

                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaCrea = item.SegMaquina,
                            CodigoArguEstEMIDefault = item.CodigoArguEstEMIDefault,
                            CodigoArguEstANUDefault = item.CodigoArguEstANUDefault,
                            CodigoArguEstPRODefault = item.CodigoArguEstPRODefault,
                            EsGravado = item.EsGravado,
                            CodigoArguTipoDeOperacionDefault = item.CodigoArguTipoDeOperacionDefault,
                            CodigoArguTipoDeOperacionDefaultNombre = item.CodigoArguTipoDeOperacionDefaultNombre,
                            PideContactoEntidad = item.PideContactoEntidad,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDocumentos;
        }

        ///// <summary>
        ///// Retorna un LISTA de registros de la Entidad GestionComercial.Comprobantes
        ///// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        ///// </summary>
        ///// <param name="pFiltro"></param>
        ///// <returns></returns>
        //public List<BEDocumento> ListPaged(BaseFiltroDocumento pFiltro)
        //{
        //    List<BEDocumento> lstDocumentos = new List<BEDocumento>();
        //    try
        //    {
        //        using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
        //        {
        //            var resul = SQLDC.omgc_S_Documento_Paged(
        //                pFiltro.jqCurrentPage,
        //                pFiltro.jqPageSize,
        //                pFiltro.jqSortColumn,
        //                pFiltro.jqSortOrder,
        //                pFiltro.codDocumento,
        //                pFiltro.codEmpresaRUC,
        //                pFiltro.codRegDocumento,
        //                pFiltro.codDocumentoAsos,
        //                pFiltro.codRegDestinoDocum,
        //                pFiltro.desNombre,
        //                pFiltro.indFiscal,
        //                pFiltro.indLocal,
        //                pFiltro.indEstado);

        //            foreach (var item in resul)
        //            {
        //                BEDocumento objDocumento = new BEDocumento();
        //                objDocumento.CodigoComprobante = item.CodigoComprobante;
        //                objDocumento.CodigoArguComprobante = item.CodigoArguComprobante;
        //                objDocumento.objDocumento.desNombre = item.CodigoArguComprobanteNombre;
        //                objDocumento.Descripcion = item.Descripcion;
        //                objDocumento.Abreviatura = item.Abreviatura;
        //                objDocumento.CodigoArguCentroCosto = item.CodigoArguCentroCosto;
        //                objDocumento.objCentroCosto.desNombre = item.CodigoArguCentroCostoNombre;
        //                objDocumento.CodigoComprobanteAsos = item.CodigoComprobanteAsos;
        //                objDocumento.CodigoArguDestinoComp = item.CodigoArguDestinoComp;
        //                objDocumento.objDestinoComp.desNombre = item.CodigoArguDestinoCompNombre;
        //                objDocumento.LineasComprobante = item.LineasComprobante;
        //                objDocumento.CantidadCopias = item.CantidadCopias;
        //                objDocumento.IncidenciaEnStocks = item.IncidenciaEnStocks;
        //                objDocumento.IncidenciaEnCtaCte = item.IncidenciaEnCtaCte;
        //                objDocumento.IncidenciaEnCaja = item.IncidenciaEnCaja;
        //                objDocumento.EsImpRetencion = item.EsImpRetencion;
        //                objDocumento.EsComprobanteImpreso = item.EsComprobanteImpreso;
        //                objDocumento.EsFacturadoPorLotes = item.EsFacturadoPorLotes;
        //                objDocumento.EsComprobanteFiscal = item.EsComprobanteFiscal;
        //                objDocumento.EsComprobanteLocal = item.EsComprobanteLocal;
        //                objDocumento.EsNumerAutomatica = item.EsNumerAutomatica;
        //                objDocumento.EsPFormaPago = item.EsPFormaPago;
        //                objDocumento.EsSaleCajaDiaria = item.EsSaleCajaDiaria;
        //                objDocumento.PideComprobanteSecun = item.PideComprobanteSecun;
        //                objDocumento.PideNroExternoComp = item.PideNroExternoComp;
        //                objDocumento.PideNroExternoComp2 = item.PideNroExternoComp2;
        //                objDocumento.PideMoneda = item.PideMoneda;
        //                objDocumento.PideTransportista = item.PideTransportista;
        //                objDocumento.PideMotivo = item.PideMotivo;
        //                objDocumento.PideDepoDestino = item.PideDepoDestino;
        //                objDocumento.PidePeriodoFiscal = item.PidePeriodoFiscal;
        //                objDocumento.PideAnioFiscal = item.PideAnioFiscal;
        //                objDocumento.PideCuentaContable = item.PideCuentaContable;
        //                objDocumento.PideCodigoProducto = item.PideCodigoProducto;
        //                objDocumento.PideDetalle = item.PideDetalle;
        //                objDocumento.PideCantidad = item.PideCantidad;
        //                objDocumento.PideUnidadMedida = item.PideUnidadMedida;
        //                objDocumento.PidePartida = item.PidePartida;
        //                objDocumento.PidePrecioUnitario = item.PidePrecioUnitario;
        //                objDocumento.PideCostoUnitario = item.PideCostoUnitario;
        //                objDocumento.MuestaTotalDetalle = item.MuestaTotalDetalle;
        //                objDocumento.PideDsctoDetalle = item.PideDsctoDetalle;
        //                objDocumento.PideImpuesto = item.PideImpuesto;
        //                objDocumento.PideDeposito = item.PideDeposito;
        //                objDocumento.PideFechaVencimiento = item.PideFechaVencimiento;
        //                objDocumento.PideVendedor = item.PideVendedor;
        //                objDocumento.PideDespachador = item.PideDespachador;
        //                objDocumento.PideFechaEntrega = item.PideFechaEntrega;
        //                objDocumento.PideCondicion = item.PideCondicion;
        //                objDocumento.ExigeDocumentoAnexo = item.ExigeDocumentoAnexo;
        //                objDocumento.CodigoPersonaEmpre = item.CodigoPersonaEmpre;
        //                objDocumento.objPersonaEmpre.RazonSocial = item.CodigoPersonaEmpreNombre;
        //                objDocumento.PideGuiaDeSalida = item.PideGuiaDeSalida;
        //                objDocumento.PideObservaciones = item.PideObservaciones;
        //                objDocumento.PideOrdenDeServicio = item.PideOrdenDeServicio;
        //                objDocumento.PidePedidoDeAdquis = item.PidePedidoDeAdquis;
        //                objDocumento.PideReferencia01 = item.PideReferencia01;
        //                objDocumento.PideReferencia02 = item.PideReferencia02;
        //                objDocumento.Estado = item.Estado;
        //                objDocumento.segUsuarioCrea = item.SegUsuarioCrea;
        //                objDocumento.segUsuarioEdita = item.SegUsuarioEdita;
        //                objDocumento.segFechaCrea = item.SegFechaCrea;
        //                objDocumento.segFechaEdita = item.SegFechaEdita;
        //                objDocumento.segMaquinaCrea = item.SegMaquina;
        //                objDocumento.CodigoArguEstEMIDefault = item.CodigoArguEstEMIDefault;
        //                objDocumento.CodigoArguEstANUDefault = item.CodigoArguEstANUDefault;
        //                objDocumento.CodigoArguEstPRODefault = item.CodigoArguEstPRODefault;
        //                objDocumento.EsGravado = item.EsGravado;
        //                objDocumento.CodigoArguTipoDeOperacionDefault = item.CodigoArguTipoDeOperacionDefault;
        //                objDocumento.objTipoDeOperacionDefault.desNombre = item.CodigoArguTipoDeOperacionDefaultNombre;
        //                objDocumento.PideContactoEntidad = item.PideContactoEntidad;

        //                objDocumento.ROW = item.ROWNUM == null ? 0 : item.ROWNUM.Value;
        //                objDocumento.TOTALROWS = item.TOTALROWS == null ? 0 : item.TOTALROWS.Value;
        //                lstDocumentos.Add(objDocumento);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstDocumentos;
        //}

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.Comprobantes
        /// En la BASE de DATO la Tabla : [GestionComercial.Comprobantes]
        /// <summary>
        /// <param name="prm_CodigoDocumento"></param>
        /// <returns></returns>
        public BEDocumento Find(string prm_CodigoDocumento, string pcodEmpresaRUC)
        {
            BEDocumento objDocumento = null;
            try
            {
                using (_GestionComercialDataContext SQLDC = new _GestionComercialDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Documento(pcodEmpresaRUC, null, prm_CodigoDocumento,
                                                       null, null, null, null, null, null, null, null);
                    foreach (var item in resul)
                    {
                        objDocumento = new BEDocumento()
                        {
                            CodigoComprobante = item.CodigoComprobante,
                            CodigoArguComprobante = item.CodigoArguComprobante,
                            CodigoArguComprobanteNombre = item.CodigoArguComprobanteNombre,
                            Descripcion = item.Descripcion,
                            Abreviatura = item.Abreviatura,
                            CodigoArguCentroCosto = item.CodigoArguCentroCosto,
                            CodigoArguCentroCostoNombre = item.CodigoArguCentroCostoNombre,
                            CodigoComprobanteAsos = item.CodigoComprobanteAsos,
                            CodigoComprobanteAsosNombre = item.CodigoComprobanteAsos,
                            CodigoArguDestinoComp = item.CodigoArguDestinoComp,
                            CodigoArguDestinoCompNombre = item.CodigoArguDestinoCompNombre,
                            LineasComprobante = item.LineasComprobante,
                            CantidadCopias = item.CantidadCopias,
                            IncidenciaEnStocks = item.IncidenciaEnStocks,
                            IncidenciaEnCtaCte = item.IncidenciaEnCtaCte,
                            IncidenciaEnCaja = item.IncidenciaEnCaja,
                            EsImpRetencion = item.EsImpRetencion,
                            EsComprobanteImpreso = item.EsComprobanteImpreso,
                            EsFacturadoPorLotes = item.EsFacturadoPorLotes,
                            EsComprobanteFiscal = item.EsComprobanteFiscal,
                            EsComprobanteLocal = item.EsComprobanteLocal,
                            EsNumerAutomatica = item.EsNumerAutomatica,
                            EsPFormaPago = item.EsPFormaPago,
                            EsSaleCajaDiaria = item.EsSaleCajaDiaria,
                            PideComprobanteSecun = item.PideComprobanteSecun,
                            PideNroExternoComp = item.PideNroExternoComp,
                            PideNroExternoComp2 = item.PideNroExternoComp2,
                            PideMoneda = item.PideMoneda,
                            PideTransportista = item.PideTransportista,
                            PideMotivo = item.PideMotivo,
                            PideDepoDestino = item.PideDepoDestino,
                            PidePeriodoFiscal = item.PidePeriodoFiscal,
                            PideAnioFiscal = item.PideAnioFiscal,
                            PideCuentaContable = item.PideCuentaContable,
                            PideCodigoProducto = item.PideCodigoProducto,
                            PideDetalle = item.PideDetalle,
                            PideCantidad = item.PideCantidad,
                            PideUnidadMedida = item.PideUnidadMedida,
                            PidePartida = item.PidePartida,
                            PidePrecioUnitario = item.PidePrecioUnitario,
                            PideCostoUnitario = item.PideCostoUnitario,
                            MuestaTotalDetalle = item.MuestaTotalDetalle,
                            PideDsctoDetalle = item.PideDsctoDetalle,
                            PideImpuesto = item.PideImpuesto,
                            PideDeposito = item.PideDeposito,
                            PideFechaVencimiento = item.PideFechaVencimiento,
                            PideVendedor = item.PideVendedor,
                            PideDespachador = item.PideDespachador,
                            PideFechaEntrega = item.PideFechaEntrega,
                            PideCondicion = item.PideCondicion,
                            ExigeDocumentoAnexo = item.ExigeDocumentoAnexo,
                            CodigoPersonaEmpre = item.CodigoPersonaEmpre,
                            CodigoPersonaEmpreNombre = item.CodigoPersonaEmpreNombre,
                            PideGuiaDeSalida = item.PideGuiaDeSalida,
                            PideObservaciones = item.PideObservaciones,
                            PideOrdenDeServicio = item.PideOrdenDeServicio,
                            PidePedidoDeAdquis = item.PidePedidoDeAdquis,
                            PideReferencia01 = item.PideReferencia01,
                            PideReferencia02 = item.PideReferencia02,

                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaCrea = item.SegMaquina,
                            CodigoArguEstEMIDefault = item.CodigoArguEstEMIDefault,
                            CodigoArguEstANUDefault = item.CodigoArguEstANUDefault,
                            CodigoArguEstPRODefault = item.CodigoArguEstPRODefault,
                            EsGravado = item.EsGravado,
                            CodigoArguTipoDeOperacionDefault = item.CodigoArguTipoDeOperacionDefault,
                            CodigoArguTipoDeOperacionDefaultNombre = item.CodigoArguTipoDeOperacionDefaultNombre,
                            PideContactoEntidad = item.PideContactoEntidad,

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objDocumento;
        }

        #endregion

    }
} 

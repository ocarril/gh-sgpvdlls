namespace CROM.GestionComercial.BusinessLogic
{
    using CROM.BusinessEntities.Almacen;
    using CROM.BusinessEntities.Cajas;
    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.Comercial.DTO;
    using CROM.BusinessEntities.Maestros;
    using CROM.BusinessEntities.RecursosHumanos;
    using CROM.GestionAlmacen.BusinessLogic;
    using CROM.GestionComercial.DataAccess;
    using CROM.RecursosHumanos.BusinessLogic;
    using CROM.TablasMaestras.BussinesLogic;
    using CROM.Tools.Comun;
    using CROM.Tools.Config;
    using static CROM.Tools.Comun.Web.WebConstants;

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Transactions;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.Web;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [GestionComercial.ComprobanteEmisionLogic.cs]
    /// </summary>
    public class ComprobanteEmisionLogic
    {
        private ComprobanteEmisionData comprobanteEmisionData = null;
        private ComprobanteEmisionDetalleData comprobanteEmisionDetalleData = null;
        private DocumentoSerieData comprobantesSeriesData = null;
        private DocumentoData documentoData = null;
        private CuentasCorrientesData cuentasCorrientesData = null;
        //private LetraDeCambioData letraDeCambioData = null;
        private ComprobanteEmisionImpuestosData comprobanteEmisionImpuestosData = null;
        private DocumRegSerieData documRegSerieData = null;
        //private AuditoriaSistemaLogic auditoriaSistemaLogic = new AuditoriaSistemaLogic();
        private ConfiguracionLogic configuracionLogic = new ConfiguracionLogic();
        private ProductoLogic productoLogic = null;
        private DocumentoLogic documentoLogic = null;
        private ProductoKardexLogic productoKardexLogic = null;
        private ProductoKardexAux productoKardex = null;
        
        private ReturnValor returnValor = null;

        public ComprobanteEmisionLogic()
        {
            comprobanteEmisionData = new ComprobanteEmisionData();
            comprobanteEmisionDetalleData = new ComprobanteEmisionDetalleData();
            comprobantesSeriesData = new DocumentoSerieData();
            documentoData = new DocumentoData();
            cuentasCorrientesData = new CuentasCorrientesData();
            //letraDeCambioData = new LetraDeCambioData();
            comprobanteEmisionImpuestosData = new ComprobanteEmisionImpuestosData();
            documRegSerieData = new DocumRegSerieData();
            //auditoriaSistemaLogic = new AuditoriaSistemaLogic();
            configuracionLogic = new ConfiguracionLogic();
            productoLogic = new ProductoLogic();
            documentoLogic = new DocumentoLogic();
            productoKardexLogic = new ProductoKardexLogic();
            returnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobanteEmision
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmision]
        /// <summary>
        /// <returns>List</returns>
        public List<BEComprobanteEmision> List(BaseFiltro pFiltro)
        {
            List<BEComprobanteEmision> lstComprobanteEmision = new List<BEComprobanteEmision>();
            try
            {
                pFiltro.fecInicio = HelpTime.ConvertYYYYMMDD(pFiltro.fecInicioDate);
                pFiltro.fecFinal = HelpTime.ConvertYYYYMMDD(pFiltro.fecFinalDate);
                lstComprobanteEmision = comprobanteEmisionData.List(pFiltro);
                foreach (BEComprobanteEmision x in lstComprobanteEmision)
                {
                    if (x.DocEsFacturable)
                    {
                        if (x.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_PROVEEDORES)
                        {
                            x.ValorTotalBruto = x.ValorTotalBruto * (-1);
                            x.ValorTotalDescuento = x.ValorTotalDescuento * (-1);
                            x.ValorTotalHistorico = x.ValorTotalHistorico * (-1);
                            x.ValorTotalImpuesto = x.ValorTotalImpuesto * (-1);
                            x.ValorTotalImpuestoGravada = x.ValorTotalImpuestoGravada * (-1);
                            x.ValorTotalPrecioExtran = x.ValorTotalPrecioExtran * (-1);
                            x.ValorTotalPrecioVenta = x.ValorTotalPrecioVenta * (-1);
                            x.ValorTotalVenta = x.ValorTotalVenta * (-1);
                            x.ValorTotalVentaGravada = x.ValorTotalVentaGravada * (-1);
                        }
                    }
                    else
                    {
                        x.ValorTotalBruto = x.ValorTotalBruto * (0);
                        x.ValorTotalDescuento = x.ValorTotalDescuento * (0);
                        x.ValorTotalHistorico = x.ValorTotalHistorico * (0);
                        x.ValorTotalImpuesto = x.ValorTotalImpuesto * (0);
                        x.ValorTotalImpuestoGravada = x.ValorTotalImpuestoGravada * (0);
                        x.ValorTotalPrecioExtran = x.ValorTotalPrecioExtran * (0);
                        x.ValorTotalPrecioVenta = x.ValorTotalPrecioVenta * (0);
                        x.ValorTotalVenta = x.ValorTotalVenta * (0);
                        x.ValorTotalVentaGravada = x.ValorTotalVentaGravada * (0);
                    }
                }
                if (pFiltro.indConDetalle)
                {
                    foreach (BEComprobanteEmision itemComprobanteEmision in lstComprobanteEmision)
                        itemComprobanteEmision.listaComprobanteEmisionDetalle = 
                            comprobanteEmisionDetalleData.List(pFiltro.codEmpresa,itemComprobanteEmision.codDocumReg, string.Empty);
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex, false, string.Concat(this.GetType().Name, ".",
                                                                                  MethodBase.GetCurrentMethod().Name), pFiltro.segUsuarioEdita);
                throw new Exception(returnValor.Message);
            }
            return lstComprobanteEmision;
        }

        public List<BEComprobanteEmision> List(BaseFiltro pFiltro, Helper.ComboBoxText pTexto)
        {
            List<BEComprobanteEmision> lstComprobanteEmision = new List<BEComprobanteEmision>();
            try
            {
                pFiltro.fecInicio = HelpTime.ConvertYYYYMMDD(pFiltro.fecInicioDate);
                pFiltro.fecFinal = HelpTime.ConvertYYYYMMDD(pFiltro.fecFinalDate);
                lstComprobanteEmision = comprobanteEmisionData.List(pFiltro);

                foreach (BEComprobanteEmision x in lstComprobanteEmision)
                {
                    if (x.DocEsFacturable)
                    {
                        if (x.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_PROVEEDORES)
                        {
                            x.ValorTotalBruto = x.ValorTotalBruto * (-1);
                            x.ValorTotalDescuento = x.ValorTotalDescuento * (-1);
                            x.ValorTotalHistorico = x.ValorTotalHistorico * (-1);
                            x.ValorTotalImpuesto = x.ValorTotalImpuesto * (-1);
                            x.ValorTotalImpuestoGravada = x.ValorTotalImpuestoGravada * (-1);
                            x.ValorTotalPrecioExtran = x.ValorTotalPrecioExtran * (-1);
                            x.ValorTotalPrecioVenta = x.ValorTotalPrecioVenta * (-1);
                            x.ValorTotalVenta = x.ValorTotalVenta * (-1);
                            x.ValorTotalVentaGravada = x.ValorTotalVentaGravada * (-1);
                        }
                    }
                    else
                    {
                        x.ValorTotalBruto = x.ValorTotalBruto * (0);
                        x.ValorTotalDescuento = x.ValorTotalDescuento * (0);
                        x.ValorTotalHistorico = x.ValorTotalHistorico * (0);
                        x.ValorTotalImpuesto = x.ValorTotalImpuesto * (0);
                        x.ValorTotalImpuestoGravada = x.ValorTotalImpuestoGravada * (0);
                        x.ValorTotalPrecioExtran = x.ValorTotalPrecioExtran * (0);
                        x.ValorTotalPrecioVenta = x.ValorTotalPrecioVenta * (0);
                        x.ValorTotalVenta = x.ValorTotalVenta * (0);
                        x.ValorTotalVentaGravada = x.ValorTotalVentaGravada * (0);
                    }
                    if (pFiltro.codDocumento == ConfigCROM.AppConfig(pFiltro.codEmpresa, ConfigTool.DEFAULT_Doc_FacturaProvLocal))
                    {
                        string xdat = (string.IsNullOrEmpty(x.NumeroComprobanteExt) == true ? string.Empty : x.NumeroComprobanteExt);
                        string xmon = (string.IsNullOrEmpty(x.CodigoArguMonedaNombre) == true ? string.Empty : x.CodigoArguMonedaNombre);
                        string xtot = x.CodigoArguMoneda == ConfigCROM.AppConfig(pFiltro.codEmpresa, ConfigTool.DEFAULT_MonedaNac) ? 
                                        x.ValorTotalPrecioVenta.ToString("N2") : 
                                        x.ValorTotalPrecioExtran.ToString("N2");
                        x.NumeroMinuta = string.Concat(xdat, " ref. ", x.NumeroComprobante, " - ", xmon, " - ", xtot);
                    }
                }
                if (pFiltro.indConDetalle)
                {
                    foreach (BEComprobanteEmision itemComprobanteEmision in lstComprobanteEmision)
                        itemComprobanteEmision.listaComprobanteEmisionDetalle = 
                            comprobanteEmisionDetalleData.List(pFiltro.codEmpresa,
                                                               itemComprobanteEmision.codDocumReg, 
                                                               string.Empty);
                }
                if (lstComprobanteEmision.Count > 0)
                    lstComprobanteEmision.Insert(0, new BEComprobanteEmision { CodigoComprobante = "", NumeroComprobante = Helper.ObtenerTexto(pTexto) });
                else
                    lstComprobanteEmision.Add(new BEComprobanteEmision { CodigoComprobante = "", NumeroComprobante = Helper.ObtenerTexto(pTexto) });

            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex, false, string.Concat(this.GetType().Name, ".", 
                                                                                   MethodBase.GetCurrentMethod().Name), pFiltro.segUsuarioEdita);
                throw new Exception(returnValor.Message);
            }
            return lstComprobanteEmision;
        }

        //public List<BEComprobanteEmision> ListGeneral(BaseFiltro pFiltro)
        //{
        //    List<BEComprobanteEmision> listaComprobanteEmision = new List<BEComprobanteEmision>();
        //    try
        //    {
        //        pFiltro.fecInicio = HelpTime.ConvertYYYYMMDD(pFiltro.fecInicioDate);
        //        pFiltro.fecFinal = HelpTime.ConvertYYYYMMDD(pFiltro.fecFinalDate);
        //        listaComprobanteEmision = comprobanteEmisionData.ListGeneral(pFiltro);

        //        foreach (BEComprobanteEmision comprobanteEmision in listaComprobanteEmision)

        //            if (comprobanteEmision.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_PROVEEDORES)
        //            {
        //                comprobanteEmision.ValorTotalBruto = comprobanteEmision.ValorTotalBruto * (-1);
        //                comprobanteEmision.ValorTotalDescuento = comprobanteEmision.ValorTotalDescuento * (-1);
        //                comprobanteEmision.ValorTotalHistorico = comprobanteEmision.ValorTotalHistorico * (-1);
        //                comprobanteEmision.ValorTotalImpuesto = comprobanteEmision.ValorTotalImpuesto * (-1);
        //                comprobanteEmision.ValorTotalImpuestoGravada = comprobanteEmision.ValorTotalImpuestoGravada * (-1);
        //                comprobanteEmision.ValorTotalPrecioExtran = comprobanteEmision.ValorTotalPrecioExtran * (-1);
        //                comprobanteEmision.ValorTotalPrecioVenta = comprobanteEmision.ValorTotalPrecioVenta * (-1);
        //                comprobanteEmision.ValorTotalVenta = comprobanteEmision.ValorTotalVenta * (-1);
        //                comprobanteEmision.ValorTotalVentaGravada = comprobanteEmision.ValorTotalVentaGravada * (-1);
        //            }

        //        if (pFiltro.indConDetalle)
        //        {
        //            foreach (BEComprobanteEmision itemComprobanteEmision in listaComprobanteEmision)
        //                itemComprobanteEmision.listaComprobanteEmisionDetalle = 
        //                    comprobanteEmisionDetalleData.List(pFiltro.codEmpresa,
        //                                                       itemComprobanteEmision.codDocumReg, 
        //                                                       string.Empty);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        returnValor = HelpException.mTraerMensaje(ex, false, string.Concat(this.GetType().Name, ".", 
        //                                                                           MethodBase.GetCurrentMethod().Name), pFiltro.segUsuarioEdita);
        //        throw new Exception(returnValor.Message);
        //    }
        //    return listaComprobanteEmision;
        //}

        public List<vwComprobanteEmision> ListEmision(BaseFiltro pFiltro)
        {
            List<vwComprobanteEmision> lstComprobanteEmision = new List<vwComprobanteEmision>();
            try
            {
                pFiltro.fecInicio = HelpTime.ConvertYYYYMMDD(pFiltro.fecInicioDate);
                pFiltro.fecFinal = HelpTime.ConvertYYYYMMDD(pFiltro.fecFinalDate);
                lstComprobanteEmision = comprobanteEmisionData.ListEmision(pFiltro);

                foreach (vwComprobanteEmision comprobanteEmision in lstComprobanteEmision)

                    if (comprobanteEmision.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_PROVEEDORES)
                    {
                        comprobanteEmision.ValorTotalBruto = comprobanteEmision.ValorTotalBruto * (-1);
                        comprobanteEmision.ValorTotalDescuento = comprobanteEmision.ValorTotalDescuento * (-1);
                        comprobanteEmision.ValorTotalHistorico = comprobanteEmision.ValorTotalHistorico * (-1);
                        comprobanteEmision.ValorTotalImpuesto = comprobanteEmision.ValorTotalImpuesto * (-1);
                        comprobanteEmision.ValorTotalImpuestoGravada = comprobanteEmision.ValorTotalImpuestoGravada * (-1);
                        comprobanteEmision.ValorTotalPrecioExtran = comprobanteEmision.ValorTotalPrecioExtran * (-1);
                        comprobanteEmision.ValorTotalPrecioVenta = comprobanteEmision.ValorTotalPrecioVenta * (-1);
                        comprobanteEmision.ValorTotalVenta = comprobanteEmision.ValorTotalVenta * (-1);
                        comprobanteEmision.ValorTotalVentaGravada = comprobanteEmision.ValorTotalVentaGravada * (-1);
                    }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex, false, string.Concat(this.GetType().Name, ".", 
                                                         MethodBase.GetCurrentMethod().Name), pFiltro.segUsuarioEdita);
                throw new Exception(returnValor.Message);

            }
            return lstComprobanteEmision;
        }

        public List<BECuentaCorriente> ListCuentasCorrientes(int prm_codEmpresa, 
                                                             Nullable<DateTime> prm_FechaDeEmisionDeudaINI, 
                                                             Nullable<DateTime> prm_FechaDeEmisionDeudaFIN, 
                                                             string prm_CodigoPuntoVenta, 
                                                             string prm_CodigoPersonaEntidad, 
                                                             string prm_CodigoComprobante, 
                                                             string prm_NumeroComprobante, 
                                                             string prm_CodigoArguDestinoComp, 
                                                             bool prm_Estado)
        {
            List<BECuentaCorriente> lstCuentasCorriente = new List<BECuentaCorriente>();
            try
            {
                CuentasCorrientesData cuentasCorrientesData = new CuentasCorrientesData();
                lstCuentasCorriente = cuentasCorrientesData.ListConCuadre(prm_codEmpresa, 
                                                                          HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionDeudaINI), 
                                                                          HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionDeudaFIN), 
                                                                          prm_CodigoPuntoVenta, 
                                                                          prm_CodigoPersonaEntidad, 
                                                                          prm_CodigoComprobante, 
                                                                          prm_NumeroComprobante, 
                                                                          prm_CodigoArguDestinoComp, 
                                                                          prm_Estado);
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex, false, string.Concat(this.GetType().Name, ".", MethodBase.GetCurrentMethod().Name));
                throw new Exception(returnValor.Message);
            }
            return lstCuentasCorriente;
        }

        //public List<BEComprobanteEmision> ListarDocumentosParaPDT(Nullable<DateTime> prm_FechaDeEmisionInicio, 
        //                                                         Nullable<DateTime> prm_FechaDeEmisionFinal, 
        //                                                         string prm_CodigoPersonaEmpre, 
        //                                                         string prm_CodigoPuntoVenta, 
        //                                                         string prm_CodigoComprobante, 
        //                                                         string prm_NumeroComprobante, 
        //                                                         string prm_CodigoArguEstadoDocu, 
        //                                                         string prm_CodigoArguDestinoComp, 
        //                                                         string prm_CodigoPersonaEntidad, 
        //                                                         string prm_CodigoArguMoneda, 
        //                                                         bool? prm_LogicoDeclarado, 
        //                                                         string prm_perTributario)
        //{
        //    List<BEComprobanteEmision> lstComprobanteEmision = new List<BEComprobanteEmision>();
        //    try
        //    {
        //        lstComprobanteEmision = comprobanteEmisionData.ListDocumentosParaPDT(new BaseFiltro
        //        {
        //            fecInicio = HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionInicio),
        //            fecFinal = HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionFinal),
        //            codEmpresaRUC = prm_CodigoPersonaEmpre,
        //            codPuntoVenta = prm_CodigoPuntoVenta,
        //            codPerEntidad = prm_CodigoPersonaEntidad,
        //            codDocumento = prm_CodigoComprobante,
        //            numDocumento = prm_NumeroComprobante,
        //            codRegEstado = prm_CodigoArguEstadoDocu,
        //            codRegDestinoDocum = prm_CodigoArguDestinoComp,
        //            codRegMoneda = prm_CodigoArguMoneda,
        //            perTributario = prm_perTributario
        //        });
        //        foreach (BEComprobanteEmision comprobanteEmision in lstComprobanteEmision)
        //            if (comprobanteEmision.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_PROVEEDORES)
        //            {
        //                comprobanteEmision.ValorTotalBruto = comprobanteEmision.ValorTotalBruto * (-1);
        //                comprobanteEmision.ValorTotalDescuento = comprobanteEmision.ValorTotalDescuento * (-1);
        //                comprobanteEmision.ValorTotalHistorico = comprobanteEmision.ValorTotalHistorico * (-1);
        //                comprobanteEmision.ValorTotalImpuesto = comprobanteEmision.ValorTotalImpuesto * (-1);
        //                comprobanteEmision.ValorTotalImpuestoGravada = comprobanteEmision.ValorTotalImpuestoGravada * (-1);
        //                comprobanteEmision.ValorTotalPrecioExtran = comprobanteEmision.ValorTotalPrecioExtran * (-1);
        //                comprobanteEmision.ValorTotalPrecioVenta = comprobanteEmision.ValorTotalPrecioVenta * (-1);
        //                comprobanteEmision.ValorTotalVenta = comprobanteEmision.ValorTotalVenta * (-1);
        //                comprobanteEmision.ValorTotalVentaGravada = comprobanteEmision.ValorTotalVentaGravada * (-1);
        //            }
        //    }
        //    catch (Exception ex)
        //    {
        //        returnValor = HelpException.mTraerMensaje(ex,false,string.Concat(this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name));
        //        throw new Exception(returnValor.Message);
        //    }
        //    return lstComprobanteEmision;
        //}

        //public List<BEComprobanteEmision> ListarDocumentosParaPDT(int prm_codEmpresa, 
        //                                                          Nullable<DateTime> prm_FechaDeEmisionInicio, 
        //                                                          Nullable<DateTime> prm_FechaDeEmisionFinal, 
        //                                                          string prm_CodigoPuntoVenta,
        //                                                          string prm_CodigoComprobante, 
        //                                                          string prm_NumeroComprobante, 
        //                                                          string prm_CodigoArguEstadoDocu, 
        //                                                          string prm_CodigoArguDestinoComp, 
        //                                                          string prm_CodigoPersonaEntidad, 
        //                                                          string prm_CodigoArguMoneda, 
        //                                                          bool? prm_LogicoDeclarado, 
        //                                                          string prm_perTributario, 
        //                                                          bool prm_PorPeriodo)
        //{
        //    List<BEComprobanteEmision> lstComprobanteEmision = new List<BEComprobanteEmision>();
        //    try
        //    {
        //        if (prm_PorPeriodo)
        //            lstComprobanteEmision = comprobanteEmisionData.ListDocumentosParaPDTperTributario(prm_codEmpresa, 
        //                                    prm_perTributario, 
        //                                    prm_CodigoPuntoVenta, prm_CodigoPersonaEntidad, prm_CodigoComprobante, 
        //                                    prm_NumeroComprobante, 
        //                                    prm_CodigoArguEstadoDocu, prm_CodigoArguDestinoComp, 
        //                                    prm_CodigoArguMoneda, prm_LogicoDeclarado);
        //        else
        //            lstComprobanteEmision = comprobanteEmisionData.ListDocumentosParaPDTfecDeclaracion(prm_codEmpresa, 
        //                                    HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionInicio), 
        //                                    HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionFinal),  
        //                                    prm_CodigoPuntoVenta, prm_CodigoPersonaEntidad, prm_CodigoComprobante, 
        //                                    prm_NumeroComprobante, prm_CodigoArguEstadoDocu, prm_CodigoArguDestinoComp, 
        //                                    prm_CodigoArguMoneda, prm_LogicoDeclarado);
        //        foreach (BEComprobanteEmision comprobanteEmision in lstComprobanteEmision)
        //            if (comprobanteEmision.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_PROVEEDORES)
        //            {
        //                comprobanteEmision.ValorTotalBruto = comprobanteEmision.ValorTotalBruto * (-1);
        //                comprobanteEmision.ValorTotalDescuento = comprobanteEmision.ValorTotalDescuento * (-1);
        //                comprobanteEmision.ValorTotalHistorico = comprobanteEmision.ValorTotalHistorico * (-1);
        //                comprobanteEmision.ValorTotalImpuesto = comprobanteEmision.ValorTotalImpuesto * (-1);
        //                comprobanteEmision.ValorTotalImpuestoGravada = comprobanteEmision.ValorTotalImpuestoGravada * (-1);
        //                comprobanteEmision.ValorTotalPrecioExtran = comprobanteEmision.ValorTotalPrecioExtran * (-1);
        //                comprobanteEmision.ValorTotalPrecioVenta = comprobanteEmision.ValorTotalPrecioVenta * (-1);
        //                comprobanteEmision.ValorTotalVenta = comprobanteEmision.ValorTotalVenta * (-1);
        //                comprobanteEmision.ValorTotalVentaGravada = comprobanteEmision.ValorTotalVentaGravada * (-1);
        //            }
        //    }
        //    catch (Exception ex)
        //    {
        //        returnValor = HelpException.mTraerMensaje(ex, false, string.Concat(this.GetType().Name, ".", MethodBase.GetCurrentMethod().Name));
        //        throw new Exception(returnValor.Message);
        //    }
        //    return lstComprobanteEmision;
        //}
        public List<BEComprobanteEmisionDetalle> ListProductoComercializado(BaseFiltro filtro)
        {
            List<BEComprobanteEmisionDetalle> lstComprobanteEmisionDetalle = new List<BEComprobanteEmisionDetalle>();
            try
            {
                lstComprobanteEmisionDetalle = comprobanteEmisionDetalleData.ListProductoComercializado(filtro);
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex, false, string.Concat(this.GetType().Name, ".", 
                                                          MethodBase.GetCurrentMethod().Name), filtro.segUsuarioEdita);
                throw new Exception(returnValor.Message);
            }
            return lstComprobanteEmisionDetalle;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.ComprobanteEmision
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmision]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEComprobanteEmision FindcodDocumReg(int pcodDocumReg, int pcodEmpresa, string pUser, string pcodEmpresaRUC)
        {
            BEComprobanteEmision comprobanteEmision = new BEComprobanteEmision();
            BEDocumento comprobantes = new BEDocumento();
            try
            {
                comprobanteEmision = comprobanteEmisionData.Find(pcodEmpresa, pcodDocumReg);
                if (comprobanteEmision.CodigoComprobante != null)
                {
                    comprobantes = documentoData.Find(comprobanteEmision.CodigoComprobante, pcodEmpresaRUC);
                    comprobanteEmision.codEmpresaRUC = pcodEmpresaRUC;
                }

                //CajaRegistroLogic oCajaRegistroData = new CajaRegistroLogic();
                //comprobanteEmision.listaCajaRegistro = oCajaRegistroData.List(pcodEmpresa, null, null, pcodDocumReg, string.Empty, 
                //                                        string.Empty, null, string.Empty, string.Empty, string.Empty, null);

                decimal tipoCambioVenta = comprobanteEmision.ValorTipoCambioVTA;
                if (comprobanteEmision.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_CLIENTES)
                    tipoCambioVenta = comprobanteEmision.ValorTipoCambioVTA;
                else if (comprobanteEmision.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_PROVEEDORES)
                    tipoCambioVenta = comprobanteEmision.ValorTipoCambioVTA;

                comprobanteEmision.listaComprobanteEmisionDetalle = comprobanteEmisionDetalleData.List(
                                                                    pcodEmpresa,
                                                                    pcodDocumReg, 
                                                                    string.Empty);
                foreach (BEComprobanteEmisionDetalle itemDetalle in comprobanteEmision.listaComprobanteEmisionDetalle)
                {
                    itemDetalle.refCodigoArguMoneda = comprobanteEmision.CodigoArguMoneda;

                    if (comprobantes.IncidenciaEnStocks == 0)
                        itemDetalle.listaProductoSeriados = productoLogic.ListProductoSeriado(new BaseFiltroAlmacen
                        {
                            codEmpresaRUC = comprobanteEmision.CodigoPersonaEmpre,
                            codPuntoVenta = comprobanteEmision.CodigoPuntoVenta,
                            codDeposito = string.Empty,
                            codItem = string.Empty,
                            codProducto = itemDetalle.codProducto,
                            numDocumentoCompromiso = comprobanteEmision.NumeroComprobante,
                            numDocumentoVenta = string.Empty,
                            numDocumentoCompra = string.Empty,
                            indComprometido = true,
                            indVendido = null
                        });
                    else if (comprobantes.IncidenciaEnStocks == 1)
                        itemDetalle.listaProductoSeriados = productoLogic.ListProductoSeriado(new BaseFiltroAlmacen
                        {
                            codEmpresaRUC = comprobanteEmision.CodigoPersonaEmpre,
                            codPuntoVenta = comprobanteEmision.CodigoPuntoVenta,
                            codDeposito = string.Empty,
                            codItem = string.Empty,
                            codProducto = itemDetalle.codProducto,
                            numDocumentoCompromiso = string.Empty,
                            numDocumentoVenta = string.Empty,
                            numDocumentoCompra = comprobanteEmision.NumeroComprobante,
                            indComprometido = null,
                            indVendido = null
                        });
                    else if (comprobantes.IncidenciaEnStocks == -1)
                        itemDetalle.listaProductoSeriados = productoLogic.ListProductoSeriado(new BaseFiltroAlmacen
                        {
                            codEmpresaRUC = comprobanteEmision.CodigoPersonaEmpre,
                            codPuntoVenta = comprobanteEmision.CodigoPuntoVenta,
                            codDeposito = string.Empty,
                            codItem = string.Empty,
                            codProducto = itemDetalle.codProducto,
                            numDocumentoCompromiso = string.Empty,
                            numDocumentoVenta = comprobanteEmision.NumeroComprobante,
                            numDocumentoCompra = string.Empty,
                            indComprometido = null,
                            indVendido = true
                        });
                    if (itemDetalle.listaProductoSeriados.Count > 0)
                    {
                        string strNumeroSerie = string.Empty;
                        foreach (BEProductoSeriado pSeries in itemDetalle.listaProductoSeriados)
                            strNumeroSerie = strNumeroSerie + pSeries.NumeroSerie + ",";
                        BEComprobanteEmisionDetalleNrosDeSerie listaSeriesHORI = new BEComprobanteEmisionDetalleNrosDeSerie
                        {
                            CodigoProducto = itemDetalle.CodigoProducto,
                            NrosDeSeriesDelProducto = strNumeroSerie.Substring(0, strNumeroSerie.Trim().Length - 1)
                        };
                        comprobanteEmision.listaComprobanteEmisionDetalleNrosDeSerie.Add(listaSeriesHORI);
                    }

                }
                ComprobanteEmisionImpuestosData comprobanteEmisionImpuestosData = new ComprobanteEmisionImpuestosData();
                comprobanteEmision.listaComprobanteEmisionImpuestos = comprobanteEmisionImpuestosData.List(pcodEmpresa, 
                                                                                                           pcodDocumReg);
                comprobanteEmision = VerificarTiposDeCambioAlSeleccionarDetalle(comprobanteEmision, tipoCambioVenta, 
                                                                                comprobanteEmision.ValorIGV);
                comprobanteEmision.listaComprobanteEmisionImpuestos = VerificarTiposDeImpuestoAlSeleccionar(
                                                                      comprobanteEmision.listaComprobanteEmisionImpuestos,
                                                                      tipoCambioVenta, comprobanteEmision.CodigoArguMoneda,
                                                                      pcodEmpresa);

                string strcodAtribNUM_TELEF = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Telefono1Persona);
                string strcodAtribCTA_EMAIL = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_EmailPersona);

                if (comprobanteEmision.CodigoPersonaEntidadContacto != null)
                {
                    BEPersona personaContacto = new BEPersona();
                    PersonasLogic oPersonasLogic = new PersonasLogic();
                    personaContacto = oPersonasLogic.Find(pcodEmpresa,
                                                          comprobanteEmision.CodigoPersonaEntidadContacto,
                                                          pUser);

                    foreach (BEPersonaAtributo item in personaContacto.listaPersonasAtributos)
                    {
                        if (item.CodigoArguTipoAtributo == strcodAtribNUM_TELEF) // -"PATRB002001" telefono fijo 01
                            comprobanteEmision.REF_CodigoPersonaEntidadContactoTelefono = item.CodigoArguTipoAtributoNombre;
                        if (item.CodigoArguTipoAtributo == strcodAtribCTA_EMAIL) // -"PATRB004001" correo electronico fijo 01
                            comprobanteEmision.REF_CodigoPersonaEntidadContactoEmail = item.CodigoArguTipoAtributoNombre;
                    }
                }
                if (comprobanteEmision.codEmpleadoVendedor != null)
                {
                    BEPersona personaVendedor = new BEPersona();
                    BEEmpleado empleado = new BEEmpleado();

                    PersonasLogic personasLogic = new PersonasLogic();
                    EmpleadoLogic empleadoLogic = new EmpleadoLogic();

                    var resultEmpleado =  empleadoLogic.Find(pcodEmpresa, comprobanteEmision.codEmpleadoVendedor.Value, pUser);
                    if (!resultEmpleado.isValid)
                    {
                        returnValor.Message = string.Format(HelpEventos.MessageEvento(HelpEventos.Process.FIND),
                                                             TipoRegistro.EMPLEADO.ToString());
                        throw new Exception(returnValor.Message);
                    }

                    empleado = JsonConvert.DeserializeObject<BEEmpleado>(resultEmpleado.data);

                    personaVendedor = personasLogic.Find(pcodEmpresa, empleado.codPersonaNatural, pUser);
                    comprobanteEmision.REF_CodigoPersonaVendedorArea = personaVendedor.itemDatoAdicional.CodigoArguAreaEmpleadoNombre;
                    foreach (BEPersonaAtributo item in personaVendedor.listaPersonasAtributos)
                    {
                        if (item.CodigoArguTipoAtributo == "PATRB002001") // - telefono fijo 01
                            comprobanteEmision.REF_CodigoPersonaEntidadContactoTelefono = item.CodigoArguTipoAtributoNombre;
                        if (item.CodigoArguTipoAtributo == "PATRB004001") // - correo electronico fijo 01
                            comprobanteEmision.REF_CodigoPersonaEntidadContactoEmail = item.CodigoArguTipoAtributoNombre;
                    }
                }

                if (comprobanteEmision.CodigoArguMoneda != null)
                {
                    MaestroLogic oMaestroLogic = new MaestroLogic();
                    List<BERegistro> lstMonedas = new List<BERegistro>();
                    lstMonedas = oMaestroLogic.ListDetalle(MaestroLogic.FiltroDetalle.PorCodigoArgumento, 
                                                            comprobanteEmision.CodigoArguMoneda.Substring(0, 5), 
                                                            comprobanteEmision.CodigoArguMoneda, string.Empty, 1,
                                                            pcodEmpresa, pUser);
                    string strSoloEntero = string.Empty;
                    string strSoloDecima = string.Empty;
                    decimal decEnteroD = 0;
                    Int64 intEntero = 0;
                    if (!comprobanteEmision.DocEsGravado)
                    {
                        string strDatoNumero1 = comprobanteEmision.ValorTotalPrecioVenta.ToString("N2");
                        strSoloEntero = strDatoNumero1.Substring(0, strDatoNumero1.IndexOf('.'));
                        strSoloDecima = strDatoNumero1.Substring(strDatoNumero1.IndexOf('.') + 1, 2);
                        decEnteroD = Convert.ToDecimal(strSoloEntero);
                        intEntero = Convert.ToInt64(decEnteroD);

                        comprobanteEmision.REF_ValorTotalPrecioVentaLetras = Helper.Numero_A_Texto(intEntero) + " CON " + 
                            strSoloDecima + "/100 " + (comprobanteEmision.CodigoArguMonedaNombre == null ? 
                            string.Empty : comprobanteEmision.CodigoArguMonedaNombre.Trim().ToUpper());
                    }
                    else
                    {
                        string strDatoNumero1 = comprobanteEmision.ValorTotalVenta.ToString("N2");
                        strSoloEntero = strDatoNumero1.Substring(0, strDatoNumero1.IndexOf('.'));
                        strSoloDecima = strDatoNumero1.Substring(strDatoNumero1.IndexOf('.') + 1, 2);
                        decEnteroD = Convert.ToDecimal(strSoloEntero);
                        intEntero = Convert.ToInt64(decEnteroD);

                        comprobanteEmision.REF_ValorTotalPrecioVentaLetras = Helper.Numero_A_Texto(intEntero) + " CON " + 
                            strSoloDecima + "/100 " + (comprobanteEmision.CodigoArguMonedaNombre == null ? 
                            string.Empty : comprobanteEmision.CodigoArguMonedaNombre.Trim().ToUpper());
                    }
                    comprobanteEmision.REF_CodigoArguMonedaSimbolo = lstMonedas[0].ValorCadena.Trim();
                }
                comprobanteEmision.listaCuentasCorrientes = cuentasCorrientesData.List(pcodEmpresa, 
                                                                                       string.Empty, string.Empty, 
                                                                                       comprobanteEmision.CodigoPuntoVenta, 
                                                                                       comprobanteEmision.CodigoPersonaEntidad, 
                                                                                       comprobanteEmision.CodigoComprobante, 
                                                                                       comprobanteEmision.NumeroComprobante, 
                                                                                       string.Empty, 
                                                                                       true);
                List<LetraDeCambioAux> lstLetraCambio = new List<LetraDeCambioAux>();
                List<LetraDeCambioAux> lstLetraCambioLC = new List<LetraDeCambioAux>();
                //lstLetraCambio = new LetraDeCambioLogic().List(pcodEmpresa, pcodDocumReg);
                //foreach (LetraDeCambioAux letraDeCambio in lstLetraCambio)
                //    lstLetraCambioLC.Add(letraDeCambio);

                comprobanteEmision.listaLetraDeCambio = lstLetraCambioLC;
                //comprobanteEmision.listaGastoDeAduana = gastoDeAduanaData.List(string.Empty, string.Empty, 
                //                                                               comprobanteEmision.CodigoPersonaEmpre, 
                //                                                               comprobanteEmision.CodigoPuntoVenta, 
                //                                                               string.Empty, 
                //                                                               comprobanteEmision.CodigoComprobante, 
                //                                                               comprobanteEmision.NumeroComprobante, 
                //                                                               string.Empty, 
                //                                                               null);

                ///*Rutina para sacar el dato de Abonar en Cuenta de Banco*/
                //List<BECuentaBancaria> lstcuentaBancaria = new List<BECuentaBancaria>();
                //lstcuentaBancaria = new CuentaBancariaLogic().List(new BECuentaBancaria
                //{
                //    codPersonaEmpresa = comprobanteEmision.CodigoPersonaEmpre,
                //    codRegMoneda = comprobanteEmision.CodigoArguMoneda,
                //    indActivo = true
                //});
                //if (lstcuentaBancaria.Count > 0)
                //{
                //    comprobanteEmision.auxCuentaBancariaPago = "Abonar en CTA "
                //        + lstcuentaBancaria[0].auxcodPersonaBanco + " : "
                //        + lstcuentaBancaria[0].desNumeroCuenta + " - "
                //        + lstcuentaBancaria[0].auxcodRegMoneda;
                //}
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex, false, string.Concat(this.GetType().Name, ".", 
                                                          MethodBase.GetCurrentMethod().Name), pUser);
                throw new Exception(returnValor.Message);
            }
            return comprobanteEmision;
        }

        public BEComprobanteEmision FindcodDocumRegPrint(int pcodDocumReg, int pcodEmpresa, string pcodEmpresaRUC, string pUser)
        {
            BEComprobanteEmision comprobanteEmision = new BEComprobanteEmision();
            BEDocumento comprobantes = new BEDocumento();
            try
            {
                comprobanteEmision = comprobanteEmisionData.FindPrint(pcodEmpresa, pcodDocumReg, pcodEmpresaRUC);
                if (comprobanteEmision == null)
                {
                    return comprobanteEmision;
                }
                if (comprobanteEmision.CodigoComprobante != null)
                    comprobantes = documentoData.Find(comprobanteEmision.CodigoComprobante, pcodEmpresaRUC);

                double numeroDias = HelpTime.CantidadDias(comprobanteEmision.FechaDeEmision,
                                                          comprobanteEmision.FechaDeVencimiento.Value,
                                                          HelpTime.TotalTiempo.Dias, true);

                if (numeroDias > 0)
                    if (comprobanteEmision.codCondicionCompra == Convert.ToInt32(ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_CondicionCompra)) ||
                        comprobanteEmision.codCondicionVenta == Convert.ToInt32(ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_CondicionVenta)))
                        if (ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_ConcatenaNumDias).ToLower() ==
                            Helper.ValorSiNo.S.ToString().ToLower())
                            comprobanteEmision.CondicionVentaNombre = comprobanteEmision.CondicionVentaNombre + " : " +
                                                                      numeroDias.ToString() + " DÍAS";

                //CajaRegistroLogic oCajaRegistroData = new CajaRegistroLogic();
                //comprobanteEmision.listaCajaRegistro = oCajaRegistroData.List(pcodEmpresa, null, null, pcodDocumReg, string.Empty, 
                //                                                              string.Empty, null, string.Empty, string.Empty, 
                //                                                              string.Empty, null);

                decimal tipoCambioVenta = comprobanteEmision.ValorTipoCambioVTA;
                if (comprobanteEmision.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_CLIENTES)
                    tipoCambioVenta = comprobanteEmision.ValorTipoCambioVTA;
                else if (comprobanteEmision.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_PROVEEDORES)
                    tipoCambioVenta = comprobanteEmision.ValorTipoCambioVTA;

                comprobanteEmision.listaComprobanteEmisionDetalle = comprobanteEmisionDetalleData.List(
                                                                                        pcodEmpresa,
                                                                                        pcodDocumReg, string.Empty);
                foreach (BEComprobanteEmisionDetalle itemDetalle in comprobanteEmision.listaComprobanteEmisionDetalle)
                {
                    itemDetalle.refCodigoArguMoneda = comprobanteEmision.CodigoArguMoneda;

                    if (comprobantes.IncidenciaEnStocks == 0)
                        itemDetalle.listaProductoSeriados = productoLogic.ListProductoSeriado(new BaseFiltroAlmacen
                        {
                            codEmpresaRUC = comprobanteEmision.CodigoPersonaEmpre,
                            codPuntoVenta = comprobanteEmision.CodigoPuntoVenta,
                            codDeposito = string.Empty,
                            codItem = string.Empty,
                            codProducto = itemDetalle.codProducto,
                            numDocumentoCompromiso = comprobanteEmision.NumeroComprobante,
                            numDocumentoVenta = string.Empty,
                            numDocumentoCompra = string.Empty,
                            indComprometido = true,
                            indVendido = null
                        });
                    else if (comprobantes.IncidenciaEnStocks == 1)
                        itemDetalle.listaProductoSeriados = productoLogic.ListProductoSeriado(new BaseFiltroAlmacen
                        {
                            codEmpresaRUC = comprobanteEmision.CodigoPersonaEmpre,
                            codPuntoVenta = comprobanteEmision.CodigoPuntoVenta,
                            codDeposito = string.Empty,
                            codItem = string.Empty,
                            codProducto = itemDetalle.codProducto,
                            numDocumentoCompromiso = string.Empty,
                            numDocumentoVenta = string.Empty,
                            numDocumentoCompra = comprobanteEmision.NumeroComprobante,
                            indComprometido = null,
                            indVendido = null
                        });
                    else if (comprobantes.IncidenciaEnStocks == -1)
                        itemDetalle.listaProductoSeriados = productoLogic.ListProductoSeriado(new BaseFiltroAlmacen
                        {
                            codEmpresaRUC = comprobanteEmision.CodigoPersonaEmpre,
                            codPuntoVenta = comprobanteEmision.CodigoPuntoVenta,
                            codDeposito = string.Empty,
                            codItem = string.Empty,
                            codProducto = itemDetalle.codProducto,
                            numDocumentoCompromiso = string.Empty,
                            numDocumentoVenta = comprobanteEmision.NumeroComprobante,
                            numDocumentoCompra = string.Empty,
                            indComprometido = null,
                            indVendido = true
                        });
                    if (itemDetalle.listaProductoSeriados.Count > 0)
                    {
                        string strNumeroSerie = string.Empty;
                        foreach (BEProductoSeriado pSeries in itemDetalle.listaProductoSeriados)
                            strNumeroSerie = strNumeroSerie + pSeries.NumeroSerie + ",";
                        BEComprobanteEmisionDetalleNrosDeSerie listaSeriesHORI = new BEComprobanteEmisionDetalleNrosDeSerie
                        {
                            CodigoProducto = itemDetalle.CodigoProducto,
                            NrosDeSeriesDelProducto = strNumeroSerie.Substring(0, strNumeroSerie.Trim().Length - 1)
                        };
                        comprobanteEmision.listaComprobanteEmisionDetalleNrosDeSerie.Add(listaSeriesHORI);
                    }
                }
                ComprobanteEmisionImpuestosData comprobanteEmisionImpuestosData = new ComprobanteEmisionImpuestosData();
                comprobanteEmision.listaComprobanteEmisionImpuestos = comprobanteEmisionImpuestosData.List(pcodEmpresa, 
                                                                                                           pcodDocumReg);

                comprobanteEmision = VerificarTiposDeCambioAlSeleccionarDetalle(comprobanteEmision, tipoCambioVenta, 
                                                                                comprobanteEmision.ValorIGV);

                comprobanteEmision.listaComprobanteEmisionImpuestos = VerificarTiposDeImpuestoAlSeleccionar(
                                                                        comprobanteEmision.listaComprobanteEmisionImpuestos, 
                                                                        tipoCambioVenta, 
                                                                        comprobanteEmision.CodigoArguMoneda,
                                                                        pcodEmpresa);

                string strcodAtribNUM_TELEF = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Telefono1Persona);
                string strcodAtribCTA_EMAIL = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_EmailPersona);

                if (comprobanteEmision.CodigoPersonaEntidadContacto != null)
                {
                    BEPersona personaContacto = new BEPersona();
                    PersonasLogic oPersonasLogic = new PersonasLogic();
                    personaContacto = oPersonasLogic.Find(pcodEmpresa, 
                                                          comprobanteEmision.CodigoPersonaEntidadContacto, 
                                                          pUser);

                    foreach (BEPersonaAtributo item in personaContacto.listaPersonasAtributos)
                    {
                        if (item.CodigoArguTipoAtributo == strcodAtribNUM_TELEF) // -"PATRB002001" telefono fijo 01
                            comprobanteEmision.REF_CodigoPersonaEntidadContactoTelefono = item.DescripcionAtributo;
                        if (item.CodigoArguTipoAtributo == strcodAtribCTA_EMAIL) // -"PATRB004001" correo electronico fijo 01
                            comprobanteEmision.REF_CodigoPersonaEntidadContactoEmail = item.DescripcionAtributo;
                    }
                }
                if (comprobanteEmision.codEmpleadoVendedor != null)
                {
                    BEEmpleado empleado = new BEEmpleado();
                    BEPersona personaVendedor = new BEPersona();

                    PersonasLogic personasLogic = new PersonasLogic();
                    EmpleadoLogic empleadoLogic = new EmpleadoLogic();
                    
                    var resultEmpleado = empleadoLogic.Find(pcodEmpresa, comprobanteEmision.codEmpleadoVendedor.Value, pUser);
                    if (!resultEmpleado.isValid)
                    {
                        returnValor.Message = string.Format(HelpEventos.MessageEvento(HelpEventos.Process.FIND),
                                                             TipoRegistro.EMPLEADO.ToString());
                        throw new Exception(returnValor.Message);
                    }

                    empleado = JsonConvert.DeserializeObject<BEEmpleado>(resultEmpleado.data);

                    personaVendedor = personasLogic.Find(pcodEmpresa, 
                                                         empleado.codPersonaNatural, 
                                                         pUser);
                    if (personaVendedor != null)
                    {
                        comprobanteEmision.REF_CodigoPersonaVendedorArea = personaVendedor.itemDatoAdicional.CodigoArguAreaEmpleadoNombre;
                        foreach (BEPersonaAtributo item in personaVendedor.listaPersonasAtributos)
                        {
                            if (item.CodigoArguTipoAtributo == strcodAtribNUM_TELEF) // -"PATRB002001" telefono fijo 01
                                comprobanteEmision.REF_CodigoPersonaVendedorTelefono = item.DescripcionAtributo;
                            if (item.CodigoArguTipoAtributo == strcodAtribCTA_EMAIL) // -"PATRB004001" correo electronico fijo 01
                                comprobanteEmision.REF_CodigoPersonaVendedorEmail = item.DescripcionAtributo;
                        }
                    }
                }

                if (comprobanteEmision.CodigoArguMoneda != null)
                {
                    MaestroLogic oMaestroLogic = new MaestroLogic();
                    List<BERegistro> lstMonedas = new List<BERegistro>();
                    lstMonedas = oMaestroLogic.ListDetalle(MaestroLogic.FiltroDetalle.PorCodigoArgumento, 
                                                           comprobanteEmision.CodigoArguMoneda.Substring(0, 5), 
                                                           comprobanteEmision.CodigoArguMoneda, string.Empty, 1,
                                                           pcodEmpresa, pUser);
                    string strSoloEntero = string.Empty;
                    string strSoloDecima = string.Empty;
                    decimal decEnteroD = 0;
                    Int64 intEntero = 0;
                    if (!comprobanteEmision.DocEsGravado)
                    {
                        string strDatoNumero1 = comprobanteEmision.ValorTotalPrecioVenta.ToString("N2");
                        strSoloEntero = strDatoNumero1.Substring(0, strDatoNumero1.IndexOf('.'));
                        strSoloDecima = strDatoNumero1.Substring(strDatoNumero1.IndexOf('.') + 1, 2);
                        decEnteroD = Convert.ToDecimal(strSoloEntero);
                        intEntero = Convert.ToInt64(decEnteroD);

                        comprobanteEmision.REF_ValorTotalPrecioVentaLetras = Helper.Numero_A_Texto(intEntero) + " CON " +
                                                                        strSoloDecima + "/100 " + 
                                                                        (comprobanteEmision.CodigoArguMonedaNombre == null ? 
                                                                        string.Empty : 
                                                                        comprobanteEmision.CodigoArguMonedaNombre.Trim().ToUpper());
                    }
                    else
                    {
                        string strDatoNumero1 = comprobanteEmision.ValorTotalVenta.ToString("N2");
                        strSoloEntero = strDatoNumero1.Substring(0, strDatoNumero1.IndexOf('.'));
                        strSoloDecima = strDatoNumero1.Substring(strDatoNumero1.IndexOf('.') + 1, 2);
                        decEnteroD = Convert.ToDecimal(strSoloEntero);
                        intEntero = Convert.ToInt64(decEnteroD);

                        comprobanteEmision.REF_ValorTotalPrecioVentaLetras = Helper.Numero_A_Texto(intEntero) + " CON " + 
                                                                        strSoloDecima + "/100 " + 
                                                                        (comprobanteEmision.CodigoArguMonedaNombre == null ? 
                                                                        string.Empty : 
                                                                        comprobanteEmision.CodigoArguMonedaNombre.Trim().ToUpper());
                    }
                    comprobanteEmision.REF_CodigoArguMonedaSimbolo = lstMonedas[0].ValorCadena.Trim();
                }
                comprobanteEmision.listaCuentasCorrientes = cuentasCorrientesData.List(pcodEmpresa, 
                                                                                       string.Empty, string.Empty, 
                                                                                       comprobanteEmision.CodigoPuntoVenta, 
                                                                                       comprobanteEmision.CodigoPersonaEntidad, 
                                                                                       comprobanteEmision.CodigoComprobante, 
                                                                                       comprobanteEmision.NumeroComprobante, 
                                                                                       string.Empty, true);

                List<LetraDeCambioAux> lstLetraCambio = new List<LetraDeCambioAux>();
                List<LetraDeCambioAux> lstLetraCambioLC = new List<LetraDeCambioAux>();
                //lstLetraCambio = new LetraDeCambioLogic().List(pcodEmpresa, pcodDocumReg);
                //foreach (LetraDeCambioAux letraDeCambio in lstLetraCambio)
                //    //if (letraDeCambio.numMovimiento.Substring(0, 4) != "DOCU")
                //        lstLetraCambioLC.Add(letraDeCambio);
                comprobanteEmision.listaLetraDeCambio = lstLetraCambioLC;
                //comprobanteEmision.listaGastoDeAduana = gastoDeAduanaData.List(string.Empty, string.Empty, 
                //                                                               comprobanteEmision.CodigoPersonaEmpre, 
                //                                                               comprobanteEmision.CodigoPuntoVenta, 
                //                                                               string.Empty, comprobanteEmision.CodigoComprobante, 
                //                                                               comprobanteEmision.NumeroComprobante, 
                //                                                               string.Empty, null);

                ///*Rutina para sacar el dato de Abonar en Cuenta de Banco*/
                //List<BECuentaBancaria> lstcuentaBancaria = new List<BECuentaBancaria>();
                //lstcuentaBancaria = new CuentaBancariaLogic().List(new BECuentaBancaria
                //{
                //    codPersonaEmpresa = comprobanteEmision.CodigoPersonaEmpre,
                //    codRegMoneda = comprobanteEmision.CodigoArguMoneda,
                //    indActivo = true
                //});
                //if (lstcuentaBancaria.Count > 0)
                //{
                //    comprobanteEmision.auxCuentaBancariaPago = "Abonar en CTA "
                //        + lstcuentaBancaria[0].auxcodPersonaBanco + " : "
                //        + lstcuentaBancaria[0].desNumeroCuenta + " - "
                //        + lstcuentaBancaria[0].auxcodRegMoneda;
                //}
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex, false, string.Concat(this.GetType().Name, ".", MethodBase.GetCurrentMethod().Name));
                throw new Exception(returnValor.Message);
            }
            return comprobanteEmision;
        }

        public BEComprobanteEmision FindUnique(FiltroDocumReg pFiltro)
        {
            BEComprobanteEmision comprobanteEmision = new BEComprobanteEmision();
            BEDocumento comprobante = new BEDocumento();
            try
            {
                comprobanteEmision = comprobanteEmisionData.FindUnique(pFiltro);
                int prm_codDocumReg = comprobanteEmision.codDocumReg;
                if (comprobanteEmision.CodigoComprobante != null)
                    comprobante = documentoData.Find(comprobanteEmision.CodigoComprobante, pFiltro.codEmpresaRUC);

                //CajaRegistroLogic cajaRegistroData = new CajaRegistroLogic();
                //comprobanteEmision.listaCajaRegistro = cajaRegistroData.List(pFiltro.codEmpresa, null, null, 
                //                                                             prm_codDocumReg, string.Empty, 
                //                                                             string.Empty, null, string.Empty, 
                //                                                             string.Empty, string.Empty, null);

                decimal decTipoDecambioVenta = comprobanteEmision.ValorTipoCambioVTA;
                if (comprobanteEmision.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_CLIENTES)
                    decTipoDecambioVenta = comprobanteEmision.ValorTipoCambioVTA;
                else if (comprobanteEmision.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_PROVEEDORES)
                    decTipoDecambioVenta = comprobanteEmision.ValorTipoCambioVTA;

                comprobanteEmision.listaComprobanteEmisionDetalle = comprobanteEmisionDetalleData.List(
                                                                                    pFiltro.codEmpresa,
                                                                                    prm_codDocumReg, 
                                                                                    string.Empty);

                foreach (BEComprobanteEmisionDetalle itemDetalle in comprobanteEmision.listaComprobanteEmisionDetalle)
                {
                    itemDetalle.refCodigoArguMoneda = comprobanteEmision.CodigoArguMoneda;

                    if (comprobante.IncidenciaEnStocks == 0)
                        itemDetalle.listaProductoSeriados = productoLogic.ListProductoSeriado(new BaseFiltroAlmacen
                        {
                            codEmpresaRUC = comprobanteEmision.CodigoPersonaEmpre,
                            codPuntoVenta = comprobanteEmision.CodigoPuntoVenta,
                            codDeposito = string.Empty,
                            codItem = string.Empty,
                            codProducto = itemDetalle.codProducto,
                            numDocumentoCompromiso = comprobanteEmision.NumeroComprobante,
                            numDocumentoVenta = string.Empty,
                            numDocumentoCompra = string.Empty,
                            indComprometido = true,
                            indVendido = null
                        });
                    else if (comprobante.IncidenciaEnStocks == 1)
                        itemDetalle.listaProductoSeriados = productoLogic.ListProductoSeriado(new BaseFiltroAlmacen
                        {
                            codEmpresaRUC = comprobanteEmision.CodigoPersonaEmpre,
                            codPuntoVenta = comprobanteEmision.CodigoPuntoVenta,
                            codDeposito = string.Empty,
                            codItem = string.Empty,
                            codProducto = itemDetalle.codProducto,
                            numDocumentoCompromiso = string.Empty,
                            numDocumentoVenta = string.Empty,
                            numDocumentoCompra = comprobanteEmision.NumeroComprobante,
                            indComprometido = null,
                            indVendido = null
                        });
                    else if (comprobante.IncidenciaEnStocks == -1)
                        itemDetalle.listaProductoSeriados = productoLogic.ListProductoSeriado(new BaseFiltroAlmacen
                        {
                            codEmpresaRUC = comprobanteEmision.CodigoPersonaEmpre,
                            codPuntoVenta = comprobanteEmision.CodigoPuntoVenta,
                            codDeposito = string.Empty,
                            codItem = string.Empty,
                            codProducto = itemDetalle.codProducto,
                            numDocumentoCompromiso = string.Empty,
                            numDocumentoVenta = comprobanteEmision.NumeroComprobante,
                            numDocumentoCompra = string.Empty,
                            indComprometido = null,
                            indVendido = true
                        });

                    if (itemDetalle.listaProductoSeriados.Count > 0)
                    {
                        string strNumeroSerie = string.Empty;
                        foreach (BEProductoSeriado productoSeriado in itemDetalle.listaProductoSeriados)
                            strNumeroSerie = strNumeroSerie + productoSeriado.NumeroSerie + ",";
                        BEComprobanteEmisionDetalleNrosDeSerie listaSeriesHORI = new BEComprobanteEmisionDetalleNrosDeSerie
                        {
                            CodigoProducto = itemDetalle.CodigoProducto,
                            NrosDeSeriesDelProducto = strNumeroSerie.Substring(0, strNumeroSerie.Trim().Length - 1)
                        };
                        comprobanteEmision.listaComprobanteEmisionDetalleNrosDeSerie.Add(listaSeriesHORI);
                    }
                }
                ComprobanteEmisionImpuestosData comprobanteEmisionImpuestosData = new ComprobanteEmisionImpuestosData();
                comprobanteEmision.listaComprobanteEmisionImpuestos = comprobanteEmisionImpuestosData.List(pFiltro.codEmpresa, 
                                                                                                           prm_codDocumReg);
                comprobanteEmision = VerificarTiposDeCambioAlSeleccionarDetalle(comprobanteEmision, decTipoDecambioVenta, 
                                                                                comprobanteEmision.ValorIGV);

                comprobanteEmision.listaComprobanteEmisionImpuestos = VerificarTiposDeImpuestoAlSeleccionar
                                                                      (
                                                                        comprobanteEmision.listaComprobanteEmisionImpuestos, 
                                                                        decTipoDecambioVenta, 
                                                                        comprobanteEmision.CodigoArguMoneda,
                                                                        pFiltro.codEmpresa);

                string strcodAtribNUM_TELEF = ConfigCROM.AppConfig(pFiltro.codEmpresa, ConfigTool.DEFAULT_Telefono1Persona);
                string strcodAtribCTA_EMAIL = ConfigCROM.AppConfig(pFiltro.codEmpresa, ConfigTool.DEFAULT_EmailPersona);

                if (!string.IsNullOrEmpty(comprobanteEmision.CodigoPersonaEntidadContacto))
                {
                    BEPersona personaContacto = new BEPersona();
                    PersonasLogic oPersonasLogic = new PersonasLogic();
                    personaContacto = oPersonasLogic.Find(pFiltro.codEmpresa,
                                                          comprobanteEmision.CodigoPersonaEntidadContacto,
                                                          pFiltro.segUsuarioActual);
                    foreach (BEPersonaAtributo item in personaContacto.listaPersonasAtributos)
                    {
                        if (item.CodigoArguTipoAtributo == strcodAtribNUM_TELEF) // -"PATRB002001" telefono fijo 01
                            comprobanteEmision.REF_CodigoPersonaEntidadContactoTelefono = item.CodigoArguTipoAtributoNombre;
                        if (item.CodigoArguTipoAtributo == strcodAtribCTA_EMAIL) // -"PATRB004001" correo electronico fijo 01
                            comprobanteEmision.REF_CodigoPersonaEntidadContactoEmail = item.CodigoArguTipoAtributoNombre;
                    }
                }
                if (comprobanteEmision.codEmpleadoVendedor != null)
                {
                    BEEmpleado empleado = new BEEmpleado();
                    BEPersona personaVendedor = new BEPersona();
                    PersonasLogic oPersonasLogic = new PersonasLogic();
                    EmpleadoLogic empleadoLogic = new EmpleadoLogic();
                    
                    var resultEmpleado = empleadoLogic.Find(pFiltro.codEmpresa, 
                                                            comprobanteEmision.codEmpleadoVendedor.Value, 
                                                            pFiltro.segUsuarioActual);
                    if (!resultEmpleado.isValid)
                    {
                        returnValor.Message = string.Format(HelpEventos.MessageEvento(HelpEventos.Process.FIND),
                                                             TipoRegistro.EMPLEADO.ToString());
                        throw new Exception(returnValor.Message);
                    }

                    empleado = JsonConvert.DeserializeObject<BEEmpleado>(resultEmpleado.data);

                    personaVendedor = oPersonasLogic.Find(pFiltro.codEmpresa, 
                                                          empleado.codPersonaNatural,
                                                          pFiltro.segUsuarioActual);

                    comprobanteEmision.REF_CodigoPersonaVendedorArea = personaVendedor.itemDatoAdicional.CodigoArguAreaEmpleadoNombre;
                    foreach (BEPersonaAtributo item in personaVendedor.listaPersonasAtributos)
                    {
                        if (item.CodigoArguTipoAtributo == strcodAtribNUM_TELEF) // - "PATRB002001"telefono fijo 01
                            comprobanteEmision.REF_CodigoPersonaEntidadContactoTelefono = item.CodigoArguTipoAtributoNombre;
                        if (item.CodigoArguTipoAtributo == strcodAtribCTA_EMAIL) // - "PATRB004001"correo electronico fijo 01
                            comprobanteEmision.REF_CodigoPersonaEntidadContactoEmail = item.CodigoArguTipoAtributoNombre;
                    }
                }

                if (comprobanteEmision.CodigoArguMoneda != null)
                {
                    MaestroLogic maestroLogic = new MaestroLogic();
                    List<BERegistro> idmoneda = new List<BERegistro>();
                    idmoneda = maestroLogic.ListDetalle(MaestroLogic.FiltroDetalle.PorCodigoArgumento, 
                                                        comprobanteEmision.CodigoArguMoneda.Substring(0, 5),
                                                        comprobanteEmision.CodigoArguMoneda, string.Empty, 1,
                                                        pFiltro.codEmpresa, pFiltro.segUsuarioActual);
                    string SoloEntero = string.Empty;
                    string SoloDecima = string.Empty;
                    decimal EnteroD = 0;
                    Int64 Entero = 0;
                    if (!comprobanteEmision.DocEsGravado)
                    {
                        string strDatoNumero1 = comprobanteEmision.ValorTotalPrecioVenta.ToString("N2");
                        SoloEntero = strDatoNumero1.Substring(0, strDatoNumero1.IndexOf('.'));
                        SoloDecima = strDatoNumero1.Substring(strDatoNumero1.IndexOf('.') + 1, 2);
                        EnteroD = Convert.ToDecimal(SoloEntero);
                        Entero = Convert.ToInt64(EnteroD);

                        comprobanteEmision.REF_ValorTotalPrecioVentaLetras = Helper.Numero_A_Texto(Entero) + " CON " + 
                                                                             SoloDecima + "/100 " + 
                                                                             (comprobanteEmision.CodigoArguMonedaNombre == null ? 
                                                                             string.Empty : 
                                                                             comprobanteEmision.CodigoArguMonedaNombre.Trim().ToUpper());
                    }
                    else
                    {
                        string strDatoNumero1 = comprobanteEmision.ValorTotalVenta.ToString("N2");
                        SoloEntero = strDatoNumero1.Substring(0, strDatoNumero1.IndexOf('.'));
                        SoloDecima = strDatoNumero1.Substring(strDatoNumero1.IndexOf('.') + 1, 2);
                        EnteroD = Convert.ToDecimal(SoloEntero);
                        Entero = Convert.ToInt64(EnteroD);

                        comprobanteEmision.REF_ValorTotalPrecioVentaLetras = Helper.Numero_A_Texto(Entero) + " CON " + 
                                                                              SoloDecima + "/100 " + 
                                                                              (comprobanteEmision.CodigoArguMonedaNombre == null ? 
                                                                              string.Empty : 
                                                                              comprobanteEmision.CodigoArguMonedaNombre.Trim().ToUpper());
                    }
                    comprobanteEmision.REF_CodigoArguMonedaSimbolo = idmoneda[0].ValorCadena.Trim();
                }
                comprobanteEmision.listaCuentasCorrientes = cuentasCorrientesData.List(pFiltro.codEmpresa, 
                                                                                       string.Empty, string.Empty, 
                                                                                       comprobanteEmision.CodigoPuntoVenta, 
                                                                                       comprobanteEmision.CodigoPersonaEntidad, 
                                                                                       comprobanteEmision.CodigoComprobante, 
                                                                                       comprobanteEmision.NumeroComprobante, 
                                                                                       string.Empty, true);
                List<LetraDeCambioAux> lstLetraCambio = new List<LetraDeCambioAux>();
                List<LetraDeCambioAux> lstLetraCambioLC = new List<LetraDeCambioAux>();
                //lstLetraCambio = new LetraDeCambioLogic().List(pFiltro.codEmpresa, prm_codDocumReg);
                //foreach (LetraDeCambioAux xLC in lstLetraCambio)
                //    //if (xLC.numMovimiento.Substring(0, 4) != "DOCU")
                //        lstLetraCambioLC.Add(xLC);
                comprobanteEmision.listaLetraDeCambio = lstLetraCambioLC;
                //comprobanteEmision.listaGastoDeAduana = gastoDeAduanaData.List(string.Empty, string.Empty, 
                //                                                               comprobanteEmision.CodigoPersonaEmpre,
                //                                                               comprobanteEmision.CodigoPuntoVenta, 
                //                                                               string.Empty, comprobanteEmision.CodigoComprobante, 
                //                                                               comprobanteEmision.NumeroComprobante, 
                //                                                               string.Empty, null);
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex, false, string.Concat(this.GetType().Name, ".", 
                                                          MethodBase.GetCurrentMethod().Name), pFiltro.segUsuarioActual, 
                                                          pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return comprobanteEmision;
        }

        #endregion

        public ReturnValor SaveComprobanteEmision(BEComprobanteEmision prm_ComprobanteEmision)
        {
            ReturnValor ReturnValor  = new ReturnValor(); 

            if (prm_ComprobanteEmision.FechaDeVencimiento == null)
                prm_ComprobanteEmision.FechaDeVencimiento = prm_ComprobanteEmision.FechaDeEmision;
            if (prm_ComprobanteEmision.EntidadNumeroRUC == null)
                prm_ComprobanteEmision.EntidadNumeroRUC = ".";

            if (prm_ComprobanteEmision.codDocumentoSerie == 0 && string.IsNullOrEmpty(prm_ComprobanteEmision.CodigoComprobante))
            {
                ReturnValor.Exitosa = false;
                ReturnValor.Message = HelpMessages.gc_DOCUM_Selecciona;
                ReturnValor.ErrorCode = TypeError.WARNING.ToString();
                return ReturnValor;
            }

            if (prm_ComprobanteEmision.codDocumentoSerie > 0)
            {
                var documSerie = comprobantesSeriesData.Find(prm_ComprobanteEmision.codEmpresaRUC,
                                                             prm_ComprobanteEmision.codDocumentoSerie, true);
                if (documSerie != null)
                {
                    prm_ComprobanteEmision.CodigoComprobante = documSerie.CodigoComprobante;
                    prm_ComprobanteEmision.CodigoComprobanteFact = documSerie.CodigoComprobante;
                }
            }

            var documentoEmitir = documentoData.Find(prm_ComprobanteEmision.CodigoComprobante,
                                                     prm_ComprobanteEmision.codEmpresaRUC);


            var indTrabajaConDeposito = ConfigCROM.AppConfig(prm_ComprobanteEmision.codEmpresa, ConfigTool.DEFAULT_TrabajaDeposito);

            if (indTrabajaConDeposito.ToLower() == Helper.ValorSiNo.S.ToString().ToLower())
                if (documentoEmitir.IncidenciaEnStocks != 0)
                    if (prm_ComprobanteEmision.CodigoArguDepositoOrigen == null)
                        if (documentoEmitir.PideDeposito)
                            prm_ComprobanteEmision.CodigoArguDepositoOrigen = ConfigCROM.AppConfig(prm_ComprobanteEmision.codEmpresa,
                                                                                                   ConfigTool.DEFAULT_AlmacenPrincipal);
            ComprobanteEmisionLogic oComprobanteEmisionLogic = new ComprobanteEmisionLogic();
            ReturnValor oReturnValor = new ReturnValor();
            
            if (prm_ComprobanteEmision.codDocumReg == 0)
                oReturnValor = Insert(prm_ComprobanteEmision,
                                      documentoEmitir);
            else
                oReturnValor = Update(prm_ComprobanteEmision,
                                      documentoEmitir);

            return oReturnValor;
        }


        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ComprobanteEmision
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmision]
        /// <summary>
        /// <param name="comprobanteEmision"></param>
        /// <param name="comprobante"></param>
        /// <param name="strCodigoTalonario"></param>
        /// <returns></returns>
        public ReturnValor Insert(BEComprobanteEmision comprobanteEmision, BEDocumento comprobante)
        {
            ComprobanteEmisionData objComprobanteEmisionData = null;
            ReturnValor objReturnValor = null;
            try
            {
                string pMessage = string.Empty;
                NumerodeComprobante(comprobanteEmision, comprobante, out pMessage);

                // Validar si generó el Ultimo Numero de Documento
                if (string.IsNullOrEmpty(comprobanteEmision.NumeroComprobante))
                {
                    returnValor.Exitosa = false;
                    returnValor.Message = pMessage;
                    return returnValor;
                }

                objComprobanteEmisionData = new ComprobanteEmisionData();
                objReturnValor = new ReturnValor();
                comprobanteEmision.codEmpleadoVendedor = comprobanteEmision.listaComprobanteEmisionDetalle[0].codEmpleadoVendedor;
                if (comprobanteEmision.CodigoPersonaEntidadContacto != null)
                    if (comprobanteEmision.CodigoPersonaEntidadContacto.Trim() == string.Empty)
                        comprobanteEmision.CodigoPersonaEntidadContacto = null;

                if (!comprobanteEmision.codEmpleado.HasValue)
                {
                    returnValor.Exitosa = false;
                    returnValor.Message = HelpMessages.gc_DOCUMENTOS_Empleado;
                    return returnValor;
                }
                if (string.IsNullOrEmpty(comprobanteEmision.codRegTipoDomicilioTransporte))
                    comprobanteEmision.codRegTipoDomicilioTransporte = null;
                if (string.IsNullOrEmpty(comprobanteEmision.codRegUbigeoTransporte))
                    comprobanteEmision.codRegUbigeoTransporte = null;

                VerificarTotalesComprobanteAlGuardar(comprobanteEmision,
                                                     comprobanteEmision.ValorTipoCambioVTA,
                                                     comprobanteEmision.CodigoArguMoneda);

                BEDocumentoSerie objComprobantesSeriesUpdate = new BEDocumentoSerie
                {
                    codEmpresa = comprobanteEmision.codEmpresa,
                    codEmpresaRUC = comprobanteEmision.codEmpresaRUC,
                    codDocumentoSerie = comprobanteEmision.codDocumentoSerie,
                    segUsuarioEdita = comprobanteEmision.SegUsuarioCrea,
                    segMaquinaEdita = comprobanteEmision.SegMaquina,
                    Estado = true
                };

                using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required))
                {

                    returnValor.Exitosa = objComprobanteEmisionData.Insert(comprobanteEmision);

                    objReturnValor = documentoLogic.UpdateUltimoDocumentoSerie(objComprobantesSeriesUpdate);

                    objReturnValor = AgregarTodaReferenciaComprobanteEmision(comprobanteEmision, comprobante);

                    if (!returnValor.Exitosa || !objReturnValor.Exitosa)
                    {
                        comprobanteEmision.codDocumReg = 0;
                        returnValor.Message = (returnValor.Message == null ? string.Empty : returnValor.Message) + " " +
                                              (objReturnValor.Message == null ? string.Empty : objReturnValor.Message);
                        returnValor.Exitosa = false;

                        HelpLogging.Write(TraceLevel.Warning, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                          returnValor.Message, comprobanteEmision.SegUsuarioEdita, 
                                          comprobanteEmision.codEmpresa.ToString());
                        return returnValor;
                    }
                    returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                    transactionScope.Complete();
                }
            }
            catch (Exception ex)
            {
                string MessageError = string.Format("CodigoPersonaEmpre: {0}, CodigoPuntoVenta: {1}, ProcesoOK: {2}, CodigoPersonaRespon: {3}, SegMaquinaOrigen: {4},  ERROR: {5} ", 
                    comprobanteEmision.CodigoPersonaEmpre,
                    comprobanteEmision.CodigoPuntoVenta, false, 
                    comprobanteEmision.codEmpleado.ToString(), 
                    comprobanteEmision.SegMaquina, ex.Message);

                HelpLogging.Write(TraceLevel.Error, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, MessageError, 
                                  comprobanteEmision.SegUsuarioEdita, comprobanteEmision.codEmpresa.ToString());
                comprobanteEmision.codDocumReg = 0;                
                returnValor = HelpException.mTraerMensaje(ex);
                return returnValor;
            }
            return returnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ComprobanteEmision
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmision]
        /// <summary>
        /// <param name="comprobanteEmision"></param>
        /// <param name="comprobante"></param>
        /// <returns></returns>
        public ReturnValor Update(BEComprobanteEmision comprobanteEmision, BEDocumento comprobante)
        {
            try
            {
                comprobanteEmision.codEmpleadoVendedor = comprobanteEmision.listaComprobanteEmisionDetalle[0].codEmpleadoVendedor;

                if (comprobanteEmision.CodigoPersonaEntidadContacto != null)
                    if (comprobanteEmision.CodigoPersonaEntidadContacto.Trim() == string.Empty)
                        comprobanteEmision.CodigoPersonaEntidadContacto = null;
                if (string.IsNullOrEmpty(comprobanteEmision.codRegTipoDomicilioTransporte))
                    comprobanteEmision.codRegTipoDomicilioTransporte = null;
                if (string.IsNullOrEmpty(comprobanteEmision.codRegUbigeoTransporte))
                    comprobanteEmision.codRegUbigeoTransporte = null;

                if (comprobanteEmision.CodigoArguEstadoDocu == comprobante.CodigoArguEstANUDefault)
                    returnValor.Message = HelpMessages.gc_DOCUM_YA_ANULADO;
                else if (comprobanteEmision.CodigoComprobanteDESTINO != null)
                    returnValor.Message = HelpMessages.gc_DOCUM_NO_ANULADO;
                else
                {
                    BEComprobanteEmision comprobanteEmisionAnterior = new BEComprobanteEmision();

                    comprobanteEmisionAnterior = FindcodDocumReg(comprobanteEmision.codDocumReg,
                                                                 comprobanteEmision.codEmpresa,
                                                                 comprobanteEmision.SegUsuarioEdita,
                                                                 comprobanteEmision.codEmpresaRUC
                                                                 );

                    if (comprobanteEmisionAnterior.NumeroComprobante == null)
                    {
                        returnValor.Message = HelpMessages.gc_DOCUM_NO_EXISTE_DOCUM;
                        return returnValor;
                    }
                    using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                    {
                        VerificarTotalesComprobanteAlGuardar(comprobanteEmision, comprobanteEmision.ValorTipoCambioVTA, comprobanteEmision.CodigoArguMoneda);
                        returnValor.Exitosa = comprobanteEmisionData.Update(comprobanteEmision);

                        //--- Eliminación de los ITEM del detalle del documento
                        ReturnValor ooReturnValor = new ReturnValor();
                        if (comprobanteEmisionAnterior.CodigoArguDepositoOrigen == null)
                            comprobanteEmisionAnterior.CodigoArguDepositoOrigen = comprobanteEmision.CodigoArguDepositoOrigen;

                        /* ELIMINA TODA LA REFERENCIA YA REGISTRADA */
                        ooReturnValor = EliminarTodaReferenciaComprobanteEmision(comprobanteEmisionAnterior, comprobante);
                        if (!ooReturnValor.Exitosa)
                            return ooReturnValor;

                        //--- Inserción de los nuevos ITEM del detalle del documento
                        comprobanteEmision.codEmpleadoVendedor = comprobanteEmision.listaComprobanteEmisionDetalle[0].codEmpleadoVendedor;

                        ReturnValor xIntReturnValor = new ReturnValor();
                        comprobanteEmision.listaLetraDeCambio = comprobanteEmisionAnterior.listaLetraDeCambio;
                        xIntReturnValor = AgregarTodaReferenciaComprobanteEmision(comprobanteEmision, comprobante);

                        if (returnValor.Exitosa && ooReturnValor.Exitosa && xIntReturnValor.Exitosa)
                        {
                            returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                            tx.Complete();
                        }
                        else
                        {
                            returnValor.Exitosa = false;
                            returnValor.Message = "Actualiza: " + returnValor.Message + " ElimREFER: " + ooReturnValor.Message + " AgreREFER: " + xIntReturnValor.Message;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string MessageError = string.Format("CodigoPersonaEmpre: {0}, CodigoPuntoVenta: {1}, ProcesoOK: {2}, CodigoPersonaRespon: {3}, SegMaquinaOrigen: {4},  ERROR: {5} ",
                   comprobanteEmision.CodigoPersonaEmpre,
                   comprobanteEmision.CodigoPuntoVenta, false,
                   comprobanteEmision.codEmpleado.ToString(),
                   comprobanteEmision.SegMaquina, ex.Message);

                HelpLogging.Write(TraceLevel.Error, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, MessageError,
                                  comprobanteEmision.SegUsuarioEdita, comprobanteEmision.codEmpresa.ToString());

                returnValor = HelpException.mTraerMensaje(ex);                
                return returnValor;
            }

            return returnValor;
        }

        public ReturnValor UpdateAnulacion(BEComprobanteEmision comprobanteEmision, BEDocumento comprobante)
        {
            try
            {
                if (string.IsNullOrEmpty(comprobanteEmision.CodigoArguAnulacion))
                    returnValor.Message = HelpMessages.VALIDACIONGeneral;
                else if (comprobanteEmision.CodigoArguEstadoDocu == comprobante.CodigoArguEstANUDefault)
                    returnValor.Message = HelpMessages.gc_DOCUM_YA_ANULADO;
                else if (comprobanteEmision.CodigoComprobanteDESTINO != null)
                    returnValor.Message = HelpMessages.gc_DOCUM_NO_ANULADO;
                else
                {
                    using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required))
                    {
                        returnValor.Exitosa = comprobanteEmisionData.UpdateAnulacion(comprobanteEmision.codDocumReg, 
                                                                                     comprobante.CodigoArguEstANUDefault, 
                                                                                     comprobanteEmision.CodigoArguAnulacion, 
                                                                                     comprobanteEmision.Observaciones, 
                                                                                     comprobanteEmision.FechaDeAnulacion.Value, 
                                                                                     comprobanteEmision.SegUsuarioEdita);
                        if (!returnValor.Exitosa)
                        {
                            returnValor.Message = HelpMessages.gc_DOCUM_NoAnulado;
                            return returnValor;
                        }
                        returnValor= EliminarTodaReferenciaComprobanteEmision(comprobanteEmision, comprobante);
                        if (!returnValor.Exitosa)
                        {
                            returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                            return returnValor;
                        }
                        transactionScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
                HelpLogging.Write(TraceLevel.Error, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, ex, comprobanteEmision.SegUsuarioEdita);
                return returnValor;
            }
            return returnValor;
        }

        public ReturnValor UpdateRevertir(BEComprobanteEmision comprobanteEmision, BEDocumento comprobante)
        {
            try
            {
                returnValor.Exitosa = false;
                if (comprobanteEmision.CodigoArguEstadoDocu == comprobante.CodigoArguEstEMIDefault)
                    returnValor.Message = HelpMessages.gc_DOCUM_NoEditable;
                else if (comprobanteEmision.CodigoArguEstadoDocu == comprobante.CodigoArguEstANUDefault)
                    returnValor.Message = HelpMessages.gc_DOCUM_YA_ANULADO;
                else if (comprobanteEmision.CodigoComprobanteDESTINO != null)
                    returnValor.Message = HelpMessages.gc_DOCUM_NO_ANULADO;
                else
                {
                    CajaRegistroLogic oCajaRegistroLogic = new CajaRegistroLogic();
                    BaseFiltro pDatos = new BaseFiltro
                    {
                        segUsuarioEdita = comprobanteEmision.SegUsuarioEdita,
                        gloObservacion = comprobanteEmision.Observaciones + " -[ESTADO REVERTIDO]",
                        codDocumReg = comprobanteEmision.codDocumReg,
                        codRegEstado = comprobante.CodigoArguEstEMIDefault
                    };
                    ReturnValor objRetornaDeshacer = null;
                    using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                    {

                        objRetornaDeshacer = oCajaRegistroLogic.DeshacerPagoEfectivo(pDatos);

                        if (objRetornaDeshacer.Exitosa)
                        {
                            returnValor.Exitosa = true;
                            returnValor.Message = HelpMessages.gc_DOCUM_YA_REVERTIDO;
                            tx.Complete();
                        }
                        else
                            returnValor.Message = HelpMessages.gc_DOCUM_NoGuardado;
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
                HelpLogging.Write(TraceLevel.Error, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, ex, comprobanteEmision.SegUsuarioEdita);
                return returnValor;
            }
            return returnValor;
        }

        //public ReturnValor UpdateDocumentosParaPDT(List<BEComprobanteEmision> lstComprobanteEmision, BaseFiltro parametro)
        //{
        //    try
        //    {
        //        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
        //        {
        //            foreach (BEComprobanteEmision comprobanteEmision in lstComprobanteEmision)
        //            {
        //                parametro.codDocumReg = comprobanteEmision.codDocumReg;
        //                parametro.codPerEntidad = comprobanteEmision.CodigoPersonaEntidad;
        //                parametro.numDocumento = comprobanteEmision.NumeroComprobante;
        //                parametro.codRegEstado = comprobanteEmision.CodigoArguEstadoDocu;
        //                parametro.fecDeclaracion = comprobanteEmision.FechaDeDeclaracion;
                //                returnValor.Exitosa = comprobanteEmisionData.UpdateDocumentosParaPDT(parametro);
        //            }

        //            if (returnValor.Exitosa)
        //            {
        //                returnValor.Message = HelpMessages.Evento_EDIT;
        //                tx.Complete();
        //            }
        //            else
        //                returnValor.Message = HelpMessages.gc_DOCUM_NoRegistrado;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        returnValor = HelpException.mTraerMensaje(ex);
        //        HelpLogging.Write(TraceLevel.Error, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, ex, parametro.segUsuarioEdita);
        //        return returnValor;
        //    }
        //    return returnValor;
        //}

        public ReturnValor UpdateArchivarDocumento(List<BEComprobanteEmision> lstComprobanteEmision, 
                                                   string codEmpresaRUC, int pcodEmpresa, string pUserActual)
        {
            try
            {

                BEDocumento comprobante = new DocumentoLogic().Find(lstComprobanteEmision[0].CodigoComprobante, 
                                                                    codEmpresaRUC, 
                                                                    pcodEmpresa,
                                                                    pUserActual);

                EsDocumentoValido(lstComprobanteEmision, comprobante);

                using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required))
                {
                    bool sucedeArchivado = true;
                    BEComprobanteEmision comprobanteEmisionArchivar = null;
                    foreach (BEComprobanteEmision comprobanteEmision in lstComprobanteEmision)
                    {
                        if (comprobante.Abreviatura == HelpDocumentos.Tipos.COT.ToString() ||
                            comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString() ||
                            comprobante.Abreviatura == HelpDocumentos.Tipos.FCT.ToString())
                        {
                            if (comprobante.Abreviatura == HelpDocumentos.Tipos.COT.ToString())
                                comprobanteEmision.CodigoArguEstadoDocu = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.EST_COT_Archivado);
                            else if (comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString())
                                comprobanteEmision.CodigoArguEstadoDocu = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.EST_GRE_Archivado);
                            else if (comprobante.Abreviatura == HelpDocumentos.Tipos.FCT.ToString())
                                comprobanteEmision.CodigoArguEstadoDocu = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.EST_FAC_Archivado);
                            else if (comprobante.Abreviatura == HelpDocumentos.Tipos.BVT.ToString())
                                comprobanteEmision.CodigoArguEstadoDocu = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.EST_BVT_Archivado);

                            comprobanteEmisionArchivar = new BEComprobanteEmision
                            {
                                codDocumReg = comprobanteEmision.codDocumReg,
                                CodigoArguEstadoDocu = comprobanteEmision.CodigoArguEstadoDocu,
                                Observaciones = string.Empty,
                                SegUsuarioEdita = comprobanteEmision.SegUsuarioEdita
                            };
                        }

                        if (comprobanteEmisionArchivar != null)
                            sucedeArchivado = comprobanteEmisionData.UpdateEmitido(comprobanteEmisionArchivar.codDocumReg, comprobanteEmisionArchivar.CodigoArguEstadoDocu, comprobanteEmisionArchivar.Observaciones, comprobanteEmisionArchivar.SegUsuarioEdita);
                        else
                            sucedeArchivado = comprobanteEmisionData.UpdateEmitido(comprobanteEmision.codDocumReg, comprobanteEmision.CodigoArguEstadoDocu, comprobanteEmision.Observaciones, comprobanteEmision.SegUsuarioEdita);
                    }
                    if (sucedeArchivado)
                    {
                        returnValor.Exitosa = sucedeArchivado;
                        returnValor.Message = HelpMessages.gc_DOCUM_YA_ARCHIVADO;
                        transactionScope.Complete();
                    }
                    else
                        returnValor.Message = HelpMessages.VALIDACIONGeneral;
                }

            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
                HelpLogging.Write(TraceLevel.Error, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, ex, lstComprobanteEmision[0].SegUsuarioEdita);
                return returnValor;
            }
            return returnValor;
        }
        public ReturnValor UpdateDevolucion(BEComprobanteEmision comprobanteEmision, List<BEProductoSeriado> lstProductoSeriado)
        {
            ReturnValor returnValorDocumento = new ReturnValor();
            ReturnValor returnValorSeriados = new ReturnValor();
            ProductoLogic productoLogic = new ProductoLogic();
            try
            {
                using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required))
                {
                    // Actualiza el documento principal
                    returnValorDocumento.Exitosa = comprobanteEmisionData.UpdateEmitidoDevolucion(comprobanteEmision);

                    List<ProductoKardexAux> lstProductoKardex = new List<ProductoKardexAux>();
                    lstProductoKardex = productoKardexLogic.ListPorDocumento(new BaseFiltroAlmacen { codDocumReg = comprobanteEmision.codDocumReg });
                    List<ProductoKardexAux> lstProductoKardexDevolucion = new List<ProductoKardexAux>();
                    ProductoKardexAux productoKardexDevolucion = null;
                    foreach (ProductoKardexAux productoKardex in lstProductoKardex)
                    {
                        productoKardexDevolucion = LllenarEntidadProductoKardexAux(comprobanteEmision, productoKardexDevolucion, productoKardex);
                        lstProductoKardexDevolucion.Add(productoKardexDevolucion);
                        productoKardexLogic.Insert(productoKardexDevolucion);
                        decimal? SALDO_StockFisico = null;
                        //productoExistenciasData.UpdateStockFisico(new BaseFiltroAlmacen
                        productoLogic.UpdateProductoExistenciaStockFisico(new  BEProductoExistenciaStockUpdate
                        {
                            codProducto = productoKardex.codProducto,
                            codDeposito = comprobanteEmision.CodigoArguDepositoOrigen,
                            cntStockFisico = Math.Round((decimal)productoKardex.cntSalida, 3),
                            indOperador = 1,
                            segUsuarioEdita = productoKardex.segUsuarioCrea,
                        }, ref SALDO_StockFisico);
                        //productoExistenciasData.UpdateStockComprometido(new BaseFiltroAlmacen
                        productoLogic.UpdateProductoExistenciaStockComprometido(new  BEProductoExistenciaStockUpdate
                        {
                            codProducto = productoKardex.codProducto,
                            codDeposito = comprobanteEmision.CodigoArguDepositoOrigen,
                            cntStockFisico = Math.Round((decimal)productoKardex.cntSalida, 3),
                            indOperador = -1,
                            segUsuarioEdita = productoKardex.segUsuarioCrea,
                            cntStockComprometido = Math.Round((decimal)productoKardex.cntSalida, 3)
                        }, ref SALDO_StockFisico);
                    }

                    returnValorSeriados = productoLogic.UpdateProductoSeriadoConsignacion(lstProductoSeriado,
                                                                                          comprobanteEmision.SegUsuarioEdita,
                                                                                          comprobanteEmision.codEmpresa);
                    if (returnValorSeriados.Exitosa && returnValorDocumento.Exitosa)
                    {
                        returnValorDocumento.Message = HelpMessages.gc_DOCUM_Devolucion_Producto;
                        transactionScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
                HelpLogging.Write(TraceLevel.Error, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, ex, comprobanteEmision.SegUsuarioEdita);
                return returnValor;
            }
            return returnValorDocumento;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.ComprobanteEmision
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmision]
        /// <summary>
        /// <param name="comprobanteEmision"></param>
        /// <param name="comprobante"></param>
        /// <param name="indEliminaAnulado"></param>
        /// <returns></returns>
        public ReturnValor Delete(BEComprobanteEmision comprobanteEmision, BEDocumento comprobante, bool indEliminaAnulado)
        {
            ReturnValor objReturnValor = new ReturnValor();
            try
            {
                bool eliminaAnulado = true;
                if (!indEliminaAnulado)
                {
                    if (comprobanteEmision.CodigoArguEstadoDocu == comprobante.CodigoArguEstANUDefault)
                    {
                        returnValor.Message = HelpMessages.gc_DOCUM_YA_ANULADO;
                        eliminaAnulado = false;
                    }
                }
                else if (comprobanteEmision.CodigoComprobanteDESTINO != null)
                {
                    returnValor.Message = HelpMessages.gc_DOCUM_NO_ANULADO;
                    eliminaAnulado = false;
                }
                if (eliminaAnulado)
                {
                    using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                    {
                        objReturnValor = EliminarTodaReferenciaComprobanteEmision(comprobanteEmision, comprobante);
                        if (!objReturnValor.Exitosa)
                            return objReturnValor;

                        objReturnValor.Exitosa = comprobanteEmisionData.Delete(comprobanteEmision.codDocumReg);
                        if (!objReturnValor.Exitosa)
                        {
                            objReturnValor.Message = HelpMessages.gc_DOCUM_SE_ELIMINARA;
                            return objReturnValor;
                        }
                        returnValor.Exitosa = true;
                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
                HelpLogging.Write(TraceLevel.Error, this.GetType().Name + ".Delete", ex);
                return returnValor;
            }
            return returnValor;
        }

        #endregion
      
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.DocumRegSerie
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumRegSerie]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEDocumRegSerie> ListcodDocumReg(BaseFiltro pFiltro)
        {
            List<BEDocumRegSerie> listaDocumRegSerie = new List<BEDocumRegSerie>();
            try
            {
                listaDocumRegSerie = documRegSerieData.ListcodDocumReg(pFiltro);

            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
                HelpLogging.Write(TraceLevel.Error, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, ex, pFiltro.segUsuarioEdita);
                throw new Exception(returnValor.Message);
            }
            return listaDocumRegSerie;
        }
        public List<BEDocumRegSerie> ListcodDocumRegDetalle(BaseFiltro pFiltro)
        {
            List<BEDocumRegSerie> listaDocumRegSerie = new List<BEDocumRegSerie>();
            try
            {
                listaDocumRegSerie = documRegSerieData.ListcodDocumRegDetalle(pFiltro);

            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
                HelpLogging.Write(TraceLevel.Error, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, ex, pFiltro.segUsuarioEdita);
                throw new Exception(returnValor.Message);
            }
            return listaDocumRegSerie;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo DocumRegSerie
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumRegSerie]
        /// <summary>
        /// <param name="lstDocumRegSerie"></param>
        /// <returns></returns>
        public ReturnValor InsertDocumRegSerie(List<BEDocumRegSerie> lstDocumRegSerie)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.codRetorno = documRegSerieData.Insert(lstDocumRegSerie);

                    if (returnValor.codRetorno != -1)
                    {
                        returnValor.Exitosa = true;
                        returnValor.Message = HelpMessages.Evento_NEW;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
                HelpLogging.Write(TraceLevel.Error, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, ex);
                return returnValor;
            }
            return returnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad GestionComercial.DocumRegSerie
        /// En la BASE de DATO la Tabla : [GestionComercial.DocumRegSerie]
        /// <summary>
        /// <param name="objComprobanteEmision"></param>
        /// <returns></returns>
        public ReturnValor DeletecodDocumReg(BEComprobanteEmision objComprobanteEmision)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = documRegSerieData.DeletecodDocumReg(new BaseFiltro
                    {
                        codDocumReg = objComprobanteEmision.codDocumReg,
                        segUsuarioEdita = objComprobanteEmision.SegUsuarioEdita
                    });
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpMessages.Evento_DELETE;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
                HelpLogging.Write(TraceLevel.Error, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, ex);
                return returnValor;
            }
            return returnValor;
        }
        public ReturnValor DeletecodDocumRegDetalle(BaseFiltro pFiltro)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = documRegSerieData.DeletecodDocumRegDetalle(pFiltro);
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpMessages.Evento_DELETE;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
                HelpLogging.Write(TraceLevel.Error, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, ex, 
                                  pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                return returnValor;
            }
            return returnValor;
        }

        #endregion

        #region Métodos Privados

        private BEComprobanteEmision VerificarTotalesComprobanteAlGuardar(BEComprobanteEmision comprobanteEmision, 
                                                                          decimal decTipoDeCambio, string strCodRegMoneda)
        {
            int CANTIDAD_DECIMALES = Convert.ToInt32(ConfigCROM.AppConfig(comprobanteEmision.codEmpresa,
                                                                          ConfigTool.DEFAULT_CantidadDecimals));

            if (strCodRegMoneda == ConfigCROM.AppConfig(comprobanteEmision.codEmpresa,
                                                        ConfigTool.DEFAULT_MonedaInt))
            {
                comprobanteEmision.ValorTotalBruto = Helper.DecimalRound(comprobanteEmision.ValorTotalBruto * decTipoDeCambio, 
                                                                         CANTIDAD_DECIMALES);

                comprobanteEmision.ValorTotalDescuento = Helper.DecimalRound(comprobanteEmision.ValorTotalDescuento * decTipoDeCambio, 
                                                                             CANTIDAD_DECIMALES);

                comprobanteEmision.ValorTotalVenta = Helper.DecimalRound(comprobanteEmision.ValorTotalVenta * decTipoDeCambio,
                                                                                CANTIDAD_DECIMALES);

                comprobanteEmision.ValorTotalPrecioVenta = Helper.DecimalRound(comprobanteEmision.ValorTotalPrecioVenta * decTipoDeCambio, 
                                                                               CANTIDAD_DECIMALES);

                comprobanteEmision.ValorTotalImpuesto = Helper.DecimalRound(comprobanteEmision.ValorTotalImpuesto * decTipoDeCambio, 
                                                                         CANTIDAD_DECIMALES);

                comprobanteEmision.ValorTotalVentaGravada = Helper.DecimalRound(comprobanteEmision.ValorTotalVentaGravada * decTipoDeCambio, 
                                                                                CANTIDAD_DECIMALES);

                comprobanteEmision.mtoDetraccion = Helper.DecimalRound(comprobanteEmision.mtoDetraccion * decTipoDeCambio,
                                                                                CANTIDAD_DECIMALES);

            }
            return comprobanteEmision;
        }

        private BEComprobanteEmision VerificarTotalesComprobanteAlSeleccionar(BEComprobanteEmision comprobanteEmision, decimal decTipoDeCambio, string strCodRegMoneda)
        {
            int z = 0;
            int CANTIDAD_DECIMALES = Convert.ToInt32(ConfigCROM.AppConfig(comprobanteEmision.codEmpresa,
                                                                          ConfigTool.DEFAULT_CantidadDecimals));

            if (strCodRegMoneda == ConfigCROM.AppConfig(comprobanteEmision.codEmpresa,
                                                        ConfigTool.DEFAULT_MonedaInt))
            {
                comprobanteEmision.ValorTotalBruto = Helper.DecimalRound(comprobanteEmision.ValorTotalBruto / decTipoDeCambio, CANTIDAD_DECIMALES);
                comprobanteEmision.ValorTotalDescuento = Helper.DecimalRound(comprobanteEmision.ValorTotalDescuento / decTipoDeCambio, CANTIDAD_DECIMALES);
                comprobanteEmision.ValorTotalPrecioVenta = Helper.DecimalRound(comprobanteEmision.ValorTotalPrecioVenta / decTipoDeCambio, CANTIDAD_DECIMALES);
                comprobanteEmision.ValorTotalImpuesto = Helper.DecimalRound(comprobanteEmision.ValorTotalImpuesto / decTipoDeCambio, CANTIDAD_DECIMALES);
                comprobanteEmision.ValorTotalVenta = Helper.DecimalRound(comprobanteEmision.ValorTotalVenta / decTipoDeCambio, CANTIDAD_DECIMALES);
                comprobanteEmision.ValorTotalVentaGravada = Helper.DecimalRound(comprobanteEmision.ValorTotalVentaGravada / decTipoDeCambio, CANTIDAD_DECIMALES);
                comprobanteEmision.mtoDetraccion = Helper.DecimalRound(comprobanteEmision.mtoDetraccion / decTipoDeCambio, CANTIDAD_DECIMALES);
            }
            ++z;

            return comprobanteEmision;
        }
        private BEComprobanteEmision VerificarTiposDeCambioAlSeleccionarDetalle(BEComprobanteEmision comprobanteEmision, decimal decTipoDeCambio, decimal decIGVSunat)
        {
            int z = 0;

            decimal nTOTAL_ItemValorBruto = 0;
            decimal nTOTAL_ItemValorDscto = 0;
            decimal nTOTAL_ItemValorVenta = 0;
            decimal nTOTAL_ItemValorIGV = 0;

            int CANTIDAD_DECIMALES = 1;
            foreach (BEComprobanteEmisionDetalle comprobanteEmisionDetalle in comprobanteEmision.listaComprobanteEmisionDetalle)
            {
                CANTIDAD_DECIMALES = comprobanteEmisionDetalle.CantiDecimales;
                decimal nUnitPrecioBruto, nUnitPrecioSinIGV, nUnitValorDscto, nUnitValorIGV, nUnitValorVenta = 0;
                decimal nTotItemValorBruto, nTotItemValorDscto, nTotItemValorIGV, nTotItemValorVenta = 0;
                if (comprobanteEmisionDetalle.refCodigoArguMoneda == ConfigCROM.AppConfig(comprobanteEmision.codEmpresa,
                                                                                          ConfigTool.DEFAULT_MonedaInt))
                {
                    nUnitPrecioBruto = comprobanteEmisionDetalle.UnitPrecioBruto / decTipoDeCambio;
                    nUnitPrecioBruto = Helper.DecimalRound(nUnitPrecioBruto, CANTIDAD_DECIMALES);

                    if (comprobanteEmisionDetalle.IncluyeIGV)
                        nUnitPrecioSinIGV = nUnitPrecioBruto - (nUnitPrecioBruto * decIGVSunat);
                    else
                        nUnitPrecioSinIGV = nUnitPrecioBruto;

                    nUnitValorDscto = nUnitPrecioSinIGV * (comprobanteEmisionDetalle.UnitDescuento / 100);
                    nUnitValorIGV = (nUnitPrecioSinIGV - nUnitValorDscto) * decIGVSunat;
                    nUnitValorVenta = nUnitPrecioSinIGV - nUnitValorDscto;

                    nTotItemValorBruto = comprobanteEmisionDetalle.Cantidad * nUnitPrecioSinIGV;
                    nTotItemValorBruto = Helper.DecimalRound(nTotItemValorBruto, 2);

                    nTotItemValorDscto = nUnitValorDscto * comprobanteEmisionDetalle.Cantidad;
                    nTotItemValorDscto = Helper.DecimalRound(nTotItemValorDscto, 2);

                    nTotItemValorIGV = nUnitValorIGV * comprobanteEmisionDetalle.Cantidad;
                    nTotItemValorIGV = Helper.DecimalRound(nTotItemValorIGV, 2);

                    nTotItemValorVenta = nTotItemValorBruto - nTotItemValorDscto;
                    nTotItemValorVenta = Helper.DecimalRound(nTotItemValorVenta, 2);

                    comprobanteEmision.listaComprobanteEmisionDetalle[z].UnitPrecioBruto = nUnitPrecioBruto;
                    comprobanteEmision.listaComprobanteEmisionDetalle[z].UnitPrecioSinIGV = nUnitPrecioSinIGV;
                    comprobanteEmision.listaComprobanteEmisionDetalle[z].UnitValorDscto = nUnitValorDscto;
                    comprobanteEmision.listaComprobanteEmisionDetalle[z].UnitValorIGV = nUnitValorIGV;
                    comprobanteEmision.listaComprobanteEmisionDetalle[z].UnitValorVenta = nUnitValorVenta;

                    comprobanteEmision.listaComprobanteEmisionDetalle[z].TotItemValorBruto = nTotItemValorBruto;
                    comprobanteEmision.listaComprobanteEmisionDetalle[z].TotItemValorDscto = nTotItemValorDscto;
                    comprobanteEmision.listaComprobanteEmisionDetalle[z].TotItemValorIGV = nTotItemValorIGV;
                    comprobanteEmision.listaComprobanteEmisionDetalle[z].TotItemValorVenta = nTotItemValorVenta;

                }
                ++z;
            }
            string strValor = ConfigCROM.AppConfig(comprobanteEmision.codEmpresa, 
                                                   ConfigTool.DEFAULT_Calc_IGV_Horiz);

            foreach (BEComprobanteEmisionDetalle comprobanteEmisionDetalle in comprobanteEmision.listaComprobanteEmisionDetalle)
            {
                nTOTAL_ItemValorBruto += comprobanteEmisionDetalle.TotItemValorBruto;
                nTOTAL_ItemValorDscto += comprobanteEmisionDetalle.TotItemValorDscto;
                nTOTAL_ItemValorVenta += comprobanteEmisionDetalle.TotItemValorVenta;
                if (strValor == Helper.ValorSiNo.S.ToString())
                    nTOTAL_ItemValorIGV += comprobanteEmisionDetalle.TotItemValorIGV;
                else
                    nTOTAL_ItemValorIGV += (comprobanteEmisionDetalle.UnitValorIGV *
                                            comprobanteEmisionDetalle.Cantidad);
            }
            nTOTAL_ItemValorIGV = Helper.DecimalRound(nTOTAL_ItemValorIGV, 2);
            comprobanteEmision.ValorTotalBruto = nTOTAL_ItemValorBruto;
            comprobanteEmision.ValorTotalDescuento = nTOTAL_ItemValorDscto;
            comprobanteEmision.ValorTotalVenta = nTOTAL_ItemValorVenta;
            comprobanteEmision.ValorTotalImpuesto = nTOTAL_ItemValorIGV;
            decimal nTOTAL_PrecioVenta = nTOTAL_ItemValorVenta + nTOTAL_ItemValorIGV;
            comprobanteEmision.ValorTotalPrecioVenta = nTOTAL_PrecioVenta;

            foreach (CajaRegistroAux cajaRegistro in comprobanteEmision.listaCajaRegistro)
            {
                if (cajaRegistro.codRegistroMoneda == ConfigCROM.AppConfig(comprobanteEmision.codEmpresa, 
                                                                           ConfigTool.DEFAULT_MonedaInt))
                {
                    cajaRegistro.auxMontoPagado_MonNac = cajaRegistro.monImportePagado;
                    cajaRegistro.monImportePagado = Helper.DecimalRound(cajaRegistro.monImportePagado / cajaRegistro.monTCambioVTA, 2); ;
                    cajaRegistro.auxMontoPagado_MonInt = cajaRegistro.monImportePagado;
                    cajaRegistro.monImporteVuelto = Helper.DecimalRound(cajaRegistro.monImporteVuelto / cajaRegistro.monTCambioVTA, 2);
                }
                else
                {
                    cajaRegistro.auxMontoPagado_MonNac = cajaRegistro.monImportePagado;
                    cajaRegistro.auxMontoPagado_MonInt = Helper.DecimalRound(cajaRegistro.monImportePagado / cajaRegistro.monTCambioVTA, 2);
                }
            }
            return comprobanteEmision;
        }
        private List<BEComprobanteEmisionDetalle> VerificarTiposDeCambioAlGuardarDetalle(List<BEComprobanteEmisionDetalle> lstComprobanteEmisionDetalle, 
                                                                                         decimal decTipoDeCambio,
                                                                                         decimal decIGVSunat, 
                                                                                         bool prm_EsGravadoImpuesto, 
                                                                                         int pcodEmpresa)
        {
            int z = 0;
            int CANTIDAD_DECIMALES = Convert.ToInt32(ConfigCROM.AppConfig(pcodEmpresa, 
                                                                          ConfigTool.DEFAULT_CantidadDecimals));
            foreach (BEComprobanteEmisionDetalle comprobanteEmisionDetalle in lstComprobanteEmisionDetalle)
            {
                decimal nUnitPrecioBruto, nUnitPrecioSinIGV, nUnitValorDscto, nUnitValorIGV, nUnitValorVenta = 0;
                decimal nTotItemValorBruto, nTotItemValorDscto, nTotItemValorIGV, nTotItemValorVenta = 0;
                if (prm_EsGravadoImpuesto)
                {
                    decIGVSunat = 0;
                    comprobanteEmisionDetalle.UnitValorIGV = 0;
                    comprobanteEmisionDetalle.TotItemValorIGV = 0;
                }
                if (comprobanteEmisionDetalle.refCodigoArguMoneda == ConfigCROM.AppConfig(pcodEmpresa, 
                                                                                          ConfigTool.DEFAULT_MonedaInt))
                {
                    nUnitPrecioBruto = comprobanteEmisionDetalle.UnitPrecioBruto * decTipoDeCambio;
                    nUnitPrecioBruto = Helper.DecimalRound(nUnitPrecioBruto, CANTIDAD_DECIMALES);

                    if (comprobanteEmisionDetalle.IncluyeIGV)
                        nUnitPrecioSinIGV = nUnitPrecioBruto - (nUnitPrecioBruto * decIGVSunat);
                    else
                        nUnitPrecioSinIGV = nUnitPrecioBruto;

                    nUnitValorDscto = nUnitPrecioBruto * (comprobanteEmisionDetalle.UnitDescuento / 100);
                    nUnitValorIGV = (nUnitPrecioSinIGV - nUnitValorDscto) * decIGVSunat;
                    nUnitValorVenta = nUnitPrecioSinIGV - nUnitValorDscto;

                    nTotItemValorBruto = comprobanteEmisionDetalle.Cantidad * nUnitPrecioSinIGV;
                    nTotItemValorBruto = Helper.DecimalRound(nTotItemValorBruto, 2);

                    nTotItemValorDscto = nUnitValorDscto * comprobanteEmisionDetalle.Cantidad;
                    nTotItemValorDscto = Helper.DecimalRound(nTotItemValorDscto, 2);

                    nTotItemValorIGV = nUnitValorIGV * comprobanteEmisionDetalle.Cantidad;
                    nTotItemValorIGV = Helper.DecimalRound(nTotItemValorIGV, 2);

                    nTotItemValorVenta = nUnitValorVenta * comprobanteEmisionDetalle.Cantidad;
                    nTotItemValorVenta = Helper.DecimalRound(nTotItemValorVenta, 2);

                    lstComprobanteEmisionDetalle[z].UnitPrecioBruto = nUnitPrecioBruto;
                    lstComprobanteEmisionDetalle[z].UnitPrecioSinIGV = nUnitPrecioSinIGV;
                    lstComprobanteEmisionDetalle[z].UnitValorDscto = nUnitValorDscto;
                    lstComprobanteEmisionDetalle[z].UnitValorIGV = nUnitValorIGV;
                    lstComprobanteEmisionDetalle[z].UnitValorVenta = nUnitValorVenta;

                    lstComprobanteEmisionDetalle[z].TotItemValorBruto = nTotItemValorBruto;
                    lstComprobanteEmisionDetalle[z].TotItemValorDscto = nTotItemValorDscto;
                    lstComprobanteEmisionDetalle[z].TotItemValorIGV = nTotItemValorIGV;
                    lstComprobanteEmisionDetalle[z].TotItemValorVenta = nTotItemValorVenta;
                }
                ++z;
            }
            return lstComprobanteEmisionDetalle;
        }

        private List<BEComprobanteEmisionImpuesto> VerificarTiposDeImpuestosAlGuardar(List<BEComprobanteEmisionImpuesto> listaImpuestos, 
                                                                                      decimal TIPO_CAMBIO, 
                                                                                      string CODIARGU_MONEDA, 
                                                                                      int pcodDocumReg, 
                                                                                      int pcodEmpresa,
                                                                                      string psegMaquina)
        {
            int CANTIDAD_DECIMALES = Convert.ToInt32(ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_CantidadDecimals));
            foreach (BEComprobanteEmisionImpuesto itemDetalle in listaImpuestos)
            {
                itemDetalle.codDocumReg = pcodDocumReg;
                itemDetalle.SegMaquina = psegMaquina;
                if (CODIARGU_MONEDA == ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_MonedaInt))
                    itemDetalle.ValorTotalImpuesto = Helper.DecimalRound(itemDetalle.ValorTotalImpuesto * 
                                                                         TIPO_CAMBIO, CANTIDAD_DECIMALES);
            }
            return listaImpuestos;
        }

        private List<BEComprobanteEmisionImpuesto> VerificarTiposDeImpuestoAlSeleccionar(List<BEComprobanteEmisionImpuesto> listaImpuestos, 
                                                                                         decimal TIPO_CAMBIO, 
                                                                                         string CODIARGU_MONEDA,
                                                                                         int pcodEmpresa)
        {
            int z = 0;
            int CANTIDAD_DECIMALES = Convert.ToInt32(ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_CantidadDecimals));
            foreach (BEComprobanteEmisionImpuesto itemDetalle in listaImpuestos)
            {
                if (CODIARGU_MONEDA == ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_MonedaInt))
                {
                    itemDetalle.ValorTotalImpuesto = Helper.DecimalRound(itemDetalle.ValorTotalImpuesto / 
                                                                         TIPO_CAMBIO, CANTIDAD_DECIMALES);
                }
                ++z;
            }
            return listaImpuestos;
        }


        private List<BECuentaCorriente> CrearRegistrosDeCuentasCtes(BEComprobanteEmision comprobanteEmision)
        {
            List<BECuentaCorriente> lstCuentaCorriente = new List<BECuentaCorriente>();
            bool indSucedeVenta = comprobanteEmision.CodigoArguDestinoComp ==
                                  WebConstants.DEFAULT_DOCUM_DESTINADO_CLIENTES ? true : false;
            if (indSucedeVenta)
            {
                double numeroDias = HelpTime.CantidadDias(comprobanteEmision.FechaDeEmision,
                                                          comprobanteEmision.FechaDeVencimiento.Value,
                                                          HelpTime.TotalTiempo.Dias, true);
                if (comprobanteEmision.codCondicionVenta.HasValue && comprobanteEmision.codCondicionVenta.Value > 0)
                {
                    BECondicion condicionVenta = new BECondicion();
                    condicionVenta = new CondicionLogic().Find(comprobanteEmision.codCondicionVenta.Value,
                                                               indSucedeVenta, true);
                    if (condicionVenta.indEsGravaCtaCte)
                    {
                        BECuentaCorriente cuentaCorriente;
                        if (condicionVenta.indEsEnCuota)
                        {
                            decimal MontoDeCuota = comprobanteEmision.ValorTotalPrecioVenta / condicionVenta.numCuota;

                            for (int k = 1; k <= condicionVenta.numCuota; ++k)
                            {
                                cuentaCorriente = new BECuentaCorriente
                                {
                                    codEmpresa = comprobanteEmision.codEmpresa,
                                    codDocumReg = comprobanteEmision.codDocumReg,
                                    CodigoArguDestinoComp = comprobanteEmision.CodigoArguDestinoComp,
                                    CodigoArguMoneda = comprobanteEmision.CodigoArguMoneda,
                                    CodigoArguTipoMovimi = comprobanteEmision.CodigoArguTipoDeOperacion,
                                    codEmpleado = comprobanteEmision.codEmpleado,
                                    CodigoPersonaEntidad = comprobanteEmision.CodigoPersonaEntidad,
                                    DEBETipoCambioVTA = comprobanteEmision.ValorTipoCambioVTA,
                                    DEBETipoCambioCMP = comprobanteEmision.ValorTipoCambioCMP,
                                    DEBETotalCuotaNacion = MontoDeCuota,
                                    DEBETotalCuotaExtran = MontoDeCuota / comprobanteEmision.ValorTipoCambioVTA,
                                    Estado = true,
                                    FechaDeEmisionDeuda = comprobanteEmision.FechaDeEmision,
                                    FechaDeVencimiento = comprobanteEmision.FechaDeEmision.AddDays((numeroDias == 0 ?
                                                                                                   Convert.ToDouble(
                                                                                                       ConfigCROM.AppConfig(comprobanteEmision.codEmpresa,
                                                                                                                            ConfigTool.DEFAULT_MaxDiasCredito)) :
                                                                                                   numeroDias) * k),
                                    NumeroDeCuota = k,
                                    Observaciones = comprobanteEmision.Observaciones == null ?
                                    "Registro automático desde Emisión de venta - " :
                                    "Registro automático desde Emisión de venta - " + comprobanteEmision.Observaciones,
                                    SegUsuarioCrea = comprobanteEmision.SegUsuarioCrea,
                                    SegUsuarioEdita = comprobanteEmision.SegUsuarioCrea,
                                    DHDiferenciaMonto = 0,
                                    TipoDeIngreso = "D"

                                };
                                
                                lstCuentaCorriente.Add(cuentaCorriente);
                            }
                        }
                        else
                        {
                            cuentaCorriente = new BECuentaCorriente
                            {
                                codEmpresa = comprobanteEmision.codEmpresa,
                                codDocumReg = comprobanteEmision.codDocumReg,
                                CodigoArguDestinoComp = comprobanteEmision.CodigoArguDestinoComp,
                                CodigoArguMoneda = comprobanteEmision.CodigoArguMoneda,
                                CodigoArguTipoMovimi = comprobanteEmision.CodigoArguTipoDeOperacion,
                                codEmpleado = comprobanteEmision.codEmpleado,
                                DEBETipoCambioVTA = comprobanteEmision.ValorTipoCambioVTA,
                                DEBETipoCambioCMP = comprobanteEmision.ValorTipoCambioCMP,
                                DEBETotalCuotaNacion = comprobanteEmision.ValorTotalPrecioVenta,
                                DEBETotalCuotaExtran = comprobanteEmision.ValorTotalPrecioExtran,
                                Estado = true,
                                FechaDeEmisionDeuda = comprobanteEmision.FechaDeEmision,
                                FechaDeVencimiento = comprobanteEmision.FechaDeEmision.AddDays(
                                                     Convert.ToDouble(
                                                         ConfigCROM.AppConfig(comprobanteEmision.codEmpresa, 
                                                         ConfigTool.DEFAULT_MaxDiasCredito)) * 1),
                                NumeroDeCuota = 1,
                                Observaciones = comprobanteEmision.Observaciones == null ? 
                                "Registro automático desde Emisión de venta - " : 
                                "Registro automático desde Emisión de venta - " + comprobanteEmision.Observaciones,
                                SegUsuarioCrea = comprobanteEmision.SegUsuarioCrea,
                                SegUsuarioEdita = comprobanteEmision.SegUsuarioCrea,
                                CodigoPersonaEntidad = comprobanteEmision.CodigoPersonaEntidad,
                                TipoDeIngreso = "D",
                            };
                            lstCuentaCorriente.Add(cuentaCorriente);
                        }
                    }
                }
            }
            else
            {
                if (comprobanteEmision.codCondicionCompra.HasValue && comprobanteEmision.codCondicionCompra.Value > 0)
                {

                    BECondicion condicionCompra = new BECondicion();
                    condicionCompra = new CondicionLogic().Find(comprobanteEmision.codCondicionCompra.Value,
                                                                indSucedeVenta, true);

                    if (condicionCompra.indEsGravaCtaCte)
                    {
                        BECuentaCorriente cuentaCorriente;

                        cuentaCorriente = new BECuentaCorriente
                        {
                            codEmpresa = comprobanteEmision.codEmpresa,
                            codDocumReg = comprobanteEmision.codDocumReg,
                            CodigoArguDestinoComp = comprobanteEmision.CodigoArguDestinoComp,
                            CodigoArguMoneda = comprobanteEmision.CodigoArguMoneda,
                            CodigoArguTipoMovimi = comprobanteEmision.CodigoArguTipoDeOperacion,
                            CodigoComprobante = comprobanteEmision.CodigoComprobante,
                            codEmpleado = comprobanteEmision.codEmpleado,
                            CodigoPersonaEmpre = comprobanteEmision.CodigoPersonaEmpre,
                            CodigoPuntoVenta = comprobanteEmision.CodigoPuntoVenta,
                            DEBETipoCambioVTA = comprobanteEmision.ValorTipoCambioVTA,
                            DEBETipoCambioCMP = comprobanteEmision.ValorTipoCambioCMP,
                            DEBETotalCuotaNacion = comprobanteEmision.ValorTotalPrecioVenta,
                            DEBETotalCuotaExtran = comprobanteEmision.ValorTotalPrecioExtran,
                            Estado = true,
                            NumeroComprobante = comprobanteEmision.NumeroComprobante,
                            FechaDeEmisionDeuda = comprobanteEmision.FechaDeEmision,
                            FechaDeVencimiento = comprobanteEmision.FechaDeEmision.AddDays(condicionCompra.numDiasCVcto),
                            NumeroDeCuota = 1,
                            Observaciones = comprobanteEmision.Observaciones == null ?
                                           "Registro automático desde registro de compra - " :
                                           "Registro automático desde registro de compra - " + comprobanteEmision.Observaciones,
                            SegUsuarioCrea = comprobanteEmision.SegUsuarioCrea,
                            SegUsuarioEdita = comprobanteEmision.SegUsuarioCrea,
                            CodigoPersonaEntidad = comprobanteEmision.CodigoPersonaEntidad,
                            TipoDeIngreso = "H",
                        };
                        lstCuentaCorriente.Add(cuentaCorriente);

                    }
                }
            }
            return lstCuentaCorriente;
        }

        private ReturnValor AgregarTodaReferenciaComprobanteEmision(BEComprobanteEmision comprobanteEmision, 
                                                                    BEDocumento comprobante)
        {
            ReturnValor returnValor = new ReturnValor();
            bool SUCEDE_KARDEX = true, SUCEDE_DOC_REFER = true;
            int? SUCEDE_DETALLE = null;
            bool SUCEDE_UPDATE_STOCKS = true;
            decimal T_CAMBIO = comprobanteEmision.ValorTipoCambioVTA;
            string rptaCuentaCorriente = string.Empty;
            try
            {
                if (comprobanteEmision.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_CLIENTES ||
                    comprobanteEmision.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_PROVEEDORES)
                    if (comprobanteEmision.DocEsFacturable || comprobante.EsComprobanteLocal)
                    {
                        /*  G U A R D A - En CuentaCorriente  */
                        rptaCuentaCorriente = cuentasCorrientesData.Insert(CrearRegistrosDeCuentasCtes(comprobanteEmision));
                        if (string.IsNullOrEmpty(rptaCuentaCorriente))
                        {
                            returnValor.Exitosa = false;
                            returnValor.Message = HelpMessages.CTA_CORRIENTE_NoRegistrada;
                            return returnValor;
                        }
                    }
                decimal? SALDO_StockFisico = null;
                /*  G U A R D A - En DocumRegImpuesto  */
                int? intResultado = comprobanteEmisionImpuestosData.Insert(
                                            VerificarTiposDeImpuestosAlGuardar(comprobanteEmision.listaComprobanteEmisionImpuestos,
                                                                               T_CAMBIO, 
                                                                               comprobanteEmision.CodigoArguMoneda,
                                                                               comprobanteEmision.codDocumReg,
                                                                               comprobanteEmision.codEmpresa,
                                                                               comprobanteEmision.SegMaquina));
                if (intResultado < 1 || !intResultado.HasValue)
                {
                    returnValor.Exitosa = false;
                    returnValor.Message = HelpMessages.gc_IMPUESTO_NoDefinido;
                    return returnValor;
                }
                ComprobanteEmisionDetalleData oiComprobanteEmisionDetalleData = new ComprobanteEmisionDetalleData();
                ProductoKardexLogic objProductoKardexLogic = new ProductoKardexLogic();
                foreach (BEComprobanteEmisionDetalle comprobanteEmisionDetalle in
                         VerificarTiposDeCambioAlGuardarDetalle(comprobanteEmision.listaComprobanteEmisionDetalle, 
                                                                T_CAMBIO,
                                                                comprobanteEmision.ValorIGV, 
                                                                comprobanteEmision.DocEsGravado,
                                                                comprobanteEmision.codEmpresa))
                {
                    comprobanteEmisionDetalle.codDocumReg = comprobanteEmision.codDocumReg;
                    comprobanteEmisionDetalle.SegUsuarioCrea = comprobanteEmision.SegUsuarioCrea;
                    comprobanteEmisionDetalle.SegMaquina = comprobante.segMaquinaCrea;
                    comprobanteEmisionDetalle.UnitDescuento = comprobanteEmisionDetalle.UnitDescuento / 100;

                    /*  G U A R D A - En DocumRegDetallee  */
                    SUCEDE_DETALLE = oiComprobanteEmisionDetalleData.Insert(comprobanteEmisionDetalle);
                    if (SUCEDE_DETALLE < 1 || !SUCEDE_DETALLE.HasValue)
                    {
                        returnValor.Exitosa = false;
                        returnValor.Message = HelpMessages.gc_DOCUM_DetalleNoRegis;
                        return returnValor;
                    }
                    if (ConfigCROM.AppConfig(comprobanteEmision.codEmpresa,ConfigTool.DEFAULT_TrabajaDeposito) == "S")
                    {
                        if (comprobanteEmisionDetalle.EsVerificarStock && comprobante.IncidenciaEnStocks == 0)
                        {
                            returnValor.Exitosa = false;
                            returnValor.Message = string.Concat(HelpMessages.INVENTARIO_ProcesoValidaDocumento, " - Origen");
                            return returnValor;
                        }

                        if (comprobanteEmisionDetalle.EsVerificarStock)
                        {
                            
                            SUCEDE_UPDATE_STOCKS = true;
                            if (comprobante.IncidenciaEnStocks == -1)
                            {
                                if (string.IsNullOrEmpty(comprobanteEmision.CodigoArguDepositoOrigen))
                                {
                                    returnValor.Exitosa = false;
                                    returnValor.Message = string.Concat( HelpMessages.INVENTARIO_ProcesoValidaAlmacen, " - Origen");
                                    return returnValor;
                                }
                                comprobanteEmisionDetalle.CodigoArguDepositoAlm = comprobanteEmision.CodigoArguDepositoOrigen;
                            }

                            if (comprobante.IncidenciaEnStocks == 1)
                            {
                                if (string.IsNullOrEmpty(comprobanteEmision.CodigoArguDepositoDesti))
                                {
                                    returnValor.Exitosa = false;
                                    returnValor.Message = string.Concat(HelpMessages.INVENTARIO_ProcesoValidaAlmacen, " - Destino");
                                    return returnValor;
                                }
                                comprobanteEmisionDetalle.CodigoArguDepositoAlm = comprobanteEmision.CodigoArguDepositoDesti;
                            }

                            if (comprobanteEmisionDetalle.CodigoArguGarantiaProd == string.Empty)
                                comprobanteEmisionDetalle.CodigoArguGarantiaProd = null;

                            /*  G U A R D A - En DocumRegSerie  */
                            returnValor = RegistrarNroSeries(comprobanteEmision, comprobante, SUCEDE_DETALLE, comprobanteEmisionDetalle);
                            if (!returnValor.Exitosa)
                            {
                                return returnValor;
                            }
                            /* Si el Documento NO es una compra Internacional*/
                            if (!comprobanteEmision.indInternacional)
                                /*Si el documento esta configurado con Incidencidencia en Stocks [-1,+1]
                                 O el motivo de la GUIA es una CONSIGNACION */
                                if (comprobante.IncidenciaEnStocks != 0 ||
                                    comprobanteEmision.CodigoArguMotivoGuia == ConfigCROM.AppConfig(comprobanteEmision.codEmpresa, 
                                                                                                    ConfigTool.DEFAULT_Doc_GuiaRemConsig))
                                {
                                    LlenarEntidadProductoKardexAux(comprobanteEmision, SUCEDE_DETALLE, comprobanteEmisionDetalle);
                                    if (productoKardex.codDeposito == null)
                                        productoKardex.codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm;
                                    /* Si el documento se genera con el tipo de operacion SALDO INICIAL */
                                    if (comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_SALDO_INICIAL)
                                    {
                                        productoKardex.cntEntrada = comprobanteEmisionDetalle.Cantidad;
                                        productoKardex.monCostoUnitEntrada = comprobanteEmisionDetalle.UnitValorCosto;
                                        productoKardex.monTotalEntrada = Math.Round(comprobanteEmisionDetalle.UnitValorCosto * comprobanteEmisionDetalle.Cantidad);
                                        productoKardex.codRegistroTipoMovimi = ConstantesGC.TIPO_MOV_KARDEX_ENTRADA;
                                        //productoExistenciasData.UpdateStockInicial(new BaseFiltroAlmacen
                                        /*  G U A R D A - En Productoexistencia  */
                                        returnValor = productoLogic.UpdateProductoExistenciaStockInicial(new 
                                         BEProductoExistenciaUpdate
                                        {
                                            codEmpresa = comprobanteEmision.codEmpresa,
                                            codProducto = comprobanteEmisionDetalle.codProducto,
                                            codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm,
                                            cntStockInicial = comprobanteEmisionDetalle.Cantidad,
                                            segUsuarioEdita = comprobante.segUsuarioCrea,
                                            segUsuarioCrea = comprobante.segUsuarioCrea,
                                            segMaquinaEdita = comprobanteEmision.SegMaquina,
                                            segMaquinaCrea = comprobanteEmision.SegMaquina,
                                        }, ref SALDO_StockFisico);
                                        if (!returnValor.Exitosa)
                                            return returnValor;
                                    }
                                    /* Si el documento se genera con el tipo de operacion COMPRA, TRANSFER_ALMACEN,DEVOLU_RECIBIDA,DOCUME_CONSIG_RECIBIDA */
                                    else if (comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_COMPRA ||
                                             comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_TRANSFER_ALMACEN ||
                                             comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_DEVOLU_RECIBIDA ||
                                             comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_CONSIG_RECIBIDA)
                                    {
                                        productoKardex.cntEntrada = comprobanteEmisionDetalle.Cantidad;
                                        productoKardex.monCostoUnitEntrada = comprobanteEmisionDetalle.UnitValorCosto;
                                        productoKardex.monTotalEntrada = Math.Round(comprobanteEmisionDetalle.UnitValorCosto * comprobanteEmisionDetalle.Cantidad);
                                        productoKardex.codRegistroTipoMovimi = ConstantesGC.TIPO_MOV_KARDEX_ENTRADA;

                                        List<BEProductoExistencia> lstProductoExistencia = new List<BEProductoExistencia>();
                                        //lstProductoExistencia = productoExistenciasData.Find(new BaseFiltroAlmacen
                                        lstProductoExistencia = productoLogic.FindProductoExistencia(new  BEProductoExistenciaFind
                                        {
                                            codEmpresa = comprobanteEmision.codEmpresa,
                                            codProducto = comprobanteEmisionDetalle.codProducto,
                                            codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm
                                        });
                                        /* El Sistema consulta si el producto tiene ASIENTO de Existencia de Stocks 
                                           de no tener lo inserta y devuelve su Stock Fisico */
                                        if (lstProductoExistencia.Count == 0)
                                        {
                                            //productoExistenciasData.UpdateStockInicial(new BaseFiltroAlmacen
                                            /*  G U A R D A - En Productoexistencia  */
                                            returnValor = productoLogic.UpdateProductoExistenciaStockInicial(new 
                                             BEProductoExistenciaUpdate
                                            {
                                                codEmpresa = comprobanteEmision.codEmpresa,
                                                codProducto = comprobanteEmisionDetalle.codProducto,
                                                codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm,
                                                cntStockInicial = comprobanteEmisionDetalle.Cantidad,
                                                segUsuarioEdita = comprobante.segUsuarioCrea,
                                                segUsuarioCrea = comprobante.segUsuarioCrea,
                                                segMaquinaEdita = comprobanteEmision.SegMaquina,
                                                segMaquinaCrea = comprobanteEmision.SegMaquina,
                                            }, ref SALDO_StockFisico);

                                            SUCEDE_UPDATE_STOCKS = false;
                                            if (!returnValor.Exitosa)
                                            {
                                                return returnValor;
                                            }
                                        }
                                        else
                                        {

                                            ProductoPrecioData productoPrecioData = new ProductoPrecioData();
                                            List<BEProductoPrecio> lstProductoPrecio = new List<BEProductoPrecio>();
                                            lstProductoPrecio = productoPrecioData.List(new BaseFiltroProductoPrecio
                                            {
                                                codEmpresa = comprobanteEmision.codEmpresa,
                                                codProducto = comprobanteEmisionDetalle.codProducto,
                                                codRegMoneda = string.Empty,
                                                codListaPrecio = null,
                                                codEmpresaRUC = comprobanteEmision.CodigoPersonaEmpre,
                                                codPuntoVenta = comprobanteEmision.CodigoPuntoVenta,
                                                indEstado = true
                                            });
                                            if (lstProductoPrecio.Count == 1)
                                            {
                                                lstProductoPrecio[0].ValorCosto = comprobanteEmisionDetalle.refUnitValorCosto;
                                                lstProductoPrecio[0].segMaquinaEdita = comprobanteEmision.SegMaquina;
                                                productoPrecioData.InsertUpdate(lstProductoPrecio[0]);
                                            }
                                            ListaDePrecioDetalleData oListaDePrecioDetalleData = new ListaDePrecioDetalleData();

                                            /*  G U A R D A - En ListaDePrecioDetalle  */
                                            returnValor.Exitosa = oListaDePrecioDetalleData.Update(LlenarEntidadListaDePrecioDetalle(comprobanteEmisionDetalle,
                                                                                                   comprobanteEmision.codEmpresa));
                                            if (!returnValor.Exitosa)
                                            {
                                                returnValor.Message = HelpMessages.gc_PEDD_PRECIO_ITEM;
                                                return returnValor;
                                            }
                                        }
                                    }
                                    /* Si el documento es de tipo operacion VENTA,RETIRO,MERMAS y otros segun la condicion*/
                                    else if (comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_VENTA ||
                                             comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_RETIRO ||
                                             comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_MERMAS ||
                                             comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_DONACION ||
                                             comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_PREMIO ||
                                             comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_DEVOLU_ENTREGADA ||
                                             comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_SALIDA_PRODUCCION ||
                                             comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_DESTRUCCION ||
                                             comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_CONSIG_ENTREGADA)
                                    {
                                        productoKardex.cntSalida = comprobanteEmisionDetalle.Cantidad;
                                        productoKardex.monCostoUnitSalida = comprobanteEmisionDetalle.UnitValorCosto;
                                        productoKardex.monTotalSalida = Math.Round(comprobanteEmisionDetalle.UnitValorCosto * comprobanteEmisionDetalle.Cantidad);
                                        productoKardex.codRegistroTipoMovimi = ConstantesGC.TIPO_MOV_KARDEX_SALIDA; ;
                                    }
                                    /* Si el documento es de tipo operacion DEVOLU_RECIBIDA, NotaCredDevol */
                                    else if (comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_DEVOLU_RECIBIDA ||
                                             comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_NotaCredDevol)
                                    {
                                        productoKardex.cntEntrada = comprobanteEmisionDetalle.Cantidad;
                                        productoKardex.codRegistroTipoMovimi = ConstantesGC.TIPO_MOV_KARDEX_DEVOLUCION; ;
                                    }

                                    // Valida el tipo DE OPERACION
                                    if (productoKardex.cntEntrada.Value == 0 && productoKardex.cntSalida.Value == 0)
                                    {
                                        returnValor.Exitosa = false;
                                        returnValor.Message = HelpMessages.KARDEX_ValidaCantidadES;
                                        return returnValor;
                                    }

                                    productoKardex.monCostoUnitSaldo = comprobanteEmisionDetalle.refUnitValorCosto;
                                    productoKardex.monTotalSaldo = comprobanteEmisionDetalle.refTotItemSaldoStock;
                                    productoKardex.codEmpresa = comprobanteEmision.codEmpresa;

                                    if (comprobanteEmisionDetalle.EsVerificarStock)
                                        if (comprobanteEmision.CodigoArguTipoDeOperacion != ConstantesGC.TIPO_MOV_DOCUME_SALDO_INICIAL &&
                                            SUCEDE_UPDATE_STOCKS)
                                        {
                                            //productoExistenciasData.UpdateStockFisico(new BaseFiltroAlmacen
                                            /*  G U A R D A - En Productoexistencia  */
                                            returnValor = productoLogic.UpdateProductoExistenciaStockFisico(new 
                                             BEProductoExistenciaStockUpdate
                                            {
                                                codEmpresa = comprobanteEmision.codEmpresa,
                                                codProducto = comprobanteEmisionDetalle.codProducto,
                                                codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm,
                                                cntStockFisico = comprobanteEmisionDetalle.Cantidad,
                                                indOperador = comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString() ? -1 : comprobante.IncidenciaEnStocks,
                                                numDocumentoReferencia = comprobanteEmision.NumeroComprobanteORIGEN,
                                                codPerEntidad = comprobanteEmision.CodigoPersonaEntidad,
                                                segUsuarioEdita = comprobante.segUsuarioCrea,
                                                segUsuarioCrea = comprobante.segUsuarioCrea,
                                                segMaquinaEdita = comprobanteEmision.SegMaquina,
                                                segMaquinaCrea = comprobanteEmision.SegMaquina,
                                            }, ref SALDO_StockFisico);
                                            if (!returnValor.Exitosa)
                                            {
                                                return returnValor;
                                            }
                                        }
                                    if (comprobanteEmisionDetalle.EsVerificarStock)
                                    {
                                        productoKardex.cntSaldo = Convert.ToDecimal(SALDO_StockFisico);
                                        if (productoKardex.codRegistroTipoMovimi == null ||
                                            productoKardex.codRegistroTipoMovimi == string.Empty)
                                        {
                                            if (comprobante.IncidenciaEnStocks == -1)
                                                productoKardex.codRegistroTipoMovimi = ConstantesGC.TIPO_MOV_KARDEX_SALIDA;
                                            else if (comprobante.IncidenciaEnStocks == 1)
                                                productoKardex.codRegistroTipoMovimi = ConstantesGC.TIPO_MOV_KARDEX_ENTRADA;
                                        }
                                        /*  G U A R D A - En ProductoKardex  */
                                        returnValor = objProductoKardexLogic.Insert(productoKardex);
                                        if (!returnValor.Exitosa)
                                        {
                                            return returnValor;
                                        }
                                    }
                                }
                            /*Si el documento es una GUIA DE REMISION con destino a CLIENTES y el
                              producto configurado con EsVerificarStock==true 
                             */
                            if (comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString() &&
                                comprobanteEmision.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_CLIENTES)
                            {
                                if (comprobanteEmisionDetalle.EsVerificarStock)
                                {
                                    decimal? prm_SALDO_StockComprometido = null;
                                    //SUCEDE_STOCKCM = productoExistenciasData.UpdateStockComprometido(new BaseFiltroAlmacen
                                    /*  G U A R D A - En ProductoExistencia  */
                                    returnValor = productoLogic.UpdateProductoExistenciaStockComprometido(new 
                                     BEProductoExistenciaStockUpdate
                                    {
                                        codEmpresa = comprobanteEmision.codEmpresa,
                                        codProducto = comprobanteEmisionDetalle.codProducto,
                                        cntStockComprometido = comprobanteEmisionDetalle.Cantidad,
                                        codDeposito = comprobanteEmision.CodigoArguDepositoOrigen,
                                        indOperador = 1,
                                        segUsuarioEdita = comprobanteEmision.SegUsuarioCrea,
                                        segUsuarioCrea = comprobante.segUsuarioCrea,
                                        segMaquinaEdita = comprobanteEmision.SegMaquina,
                                        segMaquinaCrea = comprobanteEmision.SegMaquina,
                                    }, ref prm_SALDO_StockComprometido);

                                    if (!returnValor.Exitosa)
                                    {
                                        return returnValor;
                                    };
                                }
                            }

                            if (comprobanteEmision.NumeroComprobanteORIGEN != null)
                                if (comprobanteEmision.CodigoComprobanteORIGEN != null && comprobanteEmision.NumeroComprobanteORIGEN.Trim().Length > 0)
                                {
                                    BEDocumento xCompAsos = new BEDocumento();
                                    xCompAsos = documentoData.Find(comprobante.CodigoComprobanteAsos, 
                                                                   comprobanteEmision.codEmpresaRUC);

                                    if (xCompAsos.CodigoComprobante != null)
                                    {
                                        if (xCompAsos.Abreviatura == HelpDocumentos.Tipos.GRE.ToString() &&
                                            comprobanteEmision.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_CLIENTES)
                                        {
                                            if (comprobanteEmisionDetalle.EsVerificarStock)
                                            {
                                                decimal? prm_SALDO_StockComprometido = null;
                                                //SUCEDE_STOCKCM = productoExistenciasData.UpdateStockComprometido(new BaseFiltroAlmacen
                                                /*  G U A R D A - En ProductoExistencia  */
                                                returnValor = productoLogic.UpdateProductoExistenciaStockComprometido(new 
                                                 BEProductoExistenciaStockUpdate
                                                {
                                                    codEmpresa = comprobanteEmision.codEmpresa,
                                                    codProducto = comprobanteEmisionDetalle.codProducto,
                                                    cntStockComprometido = comprobanteEmisionDetalle.Cantidad,
                                                    codDeposito = comprobanteEmision.CodigoArguDepositoOrigen,
                                                    indOperador = -1,
                                                    segUsuarioEdita = comprobanteEmision.SegUsuarioCrea,
                                                    segUsuarioCrea = comprobante.segUsuarioCrea,
                                                    segMaquinaEdita = comprobanteEmision.SegMaquina,
                                                    segMaquinaCrea = comprobanteEmision.SegMaquina,
                                                }, ref prm_SALDO_StockComprometido);
                                                if (!returnValor.Exitosa)
                                                {
                                                    return returnValor;
                                                }
                                            }
                                        }
                                    }
                                }
                        }
                    }
                }

                if (comprobanteEmision.NumeroComprobanteORIGEN != null)
                    if (comprobanteEmision.CodigoComprobanteORIGEN != null &&
                        comprobanteEmision.NumeroComprobanteORIGEN.Trim().Length > 0)
                    {
                        BEDocumento itemComprobantesREF = new BEDocumento();
                        itemComprobantesREF = new DocumentoLogic().Find(comprobanteEmision.CodigoComprobanteORIGEN,
                                                                        comprobanteEmision.codEmpresaRUC,
                                                                        comprobanteEmision.codEmpresa,
                                                                        comprobanteEmision.SegUsuarioEdita);

                        // SE ASIGNA EL ID del Documento Emitido a los DOCUMENTOS Referenciados
                        string refEstadoDocum = string.Empty;
                        if (//comprobante.Abreviatura == HelpDocumentos.Tipos.NCR.ToString() ||
                            comprobante.Abreviatura == HelpDocumentos.Tipos.NDB.ToString())
                            refEstadoDocum = itemComprobantesREF.CodigoArguEstEMIDefault;
                        else
                            refEstadoDocum = itemComprobantesREF.CodigoArguEstPRODefault;

                        if (comprobante.Abreviatura != HelpDocumentos.Tipos.NCR.ToString())
                        {
                            String[] documentosORIGEN = comprobanteEmision.NumeroComprobanteORIGEN.Trim().Split(new Char[] { ' ' });
                            foreach (string IdNumeroORIGEN in documentosORIGEN)
                            {
                                /*  G U A R D A - En comprobanteEmision - UpdateRefAsigna  */
                                SUCEDE_DOC_REFER = comprobanteEmisionData.UpdateRefAsigna(comprobanteEmision.codDocumReg,
                                                                                          comprobanteEmision.CodigoComprobanteORIGEN,
                                                                                          IdNumeroORIGEN,
                                                                                          comprobanteEmision.SegUsuarioCrea,
                                                                                          refEstadoDocum,
                                                                                          comprobanteEmision.codMotivoNCR);
                                if (!SUCEDE_DOC_REFER)
                                {
                                    returnValor.Exitosa = SUCEDE_DOC_REFER;
                                    returnValor.Message = HelpMessages.gc_DOCUM_NroDefinido;
                                    return returnValor;
                                }
                            }
                        }
                    }

                //ReturnValor returnLetra = new ReturnValor();
                //if (comprobanteEmision.listaLetraDeCambio.Count > 0)
                //{
                //    foreach (LetraDeCambioAux letraDeCambio in comprobanteEmision.listaLetraDeCambio)
                //        letraDeCambio.codDocumReg = comprobanteEmision.codDocumReg;
                //    ///*  G U A R D A - En LetraDeCambio */
                //    //returnLetra = new LetraDeCambioLogic().Insert(comprobanteEmision.listaLetraDeCambio);
                //    //if (!returnLetra.Exitosa)
                //    //    return returnLetra;
                //}
                if (SUCEDE_DETALLE.HasValue && SUCEDE_KARDEX && SUCEDE_DOC_REFER)
                {
                    returnValor.Exitosa = true;
                    //transactionScope.Complete();
                }
                //}
            }
            catch (Exception ex)
            {
                returnValor.Exitosa = false;
                HelpLogging.Write(System.Diagnostics.TraceLevel.Error, this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name, ex, comprobanteEmision.SegUsuarioEdita);
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return returnValor;
        }
        private ReturnValor RegistrarNroSeries(BEComprobanteEmision comprobanteEmision, BEDocumento comprobante, 
                                               int? SUCEDE_DETALLE, BEComprobanteEmisionDetalle comprobanteEmisionDetalle)
        {
            string cEstadoMercaderia = DetectarEstadoDeMercaderia(comprobanteEmision, comprobante);
            ReturnValor rnsReturnValor = new ReturnValor();
            rnsReturnValor.Exitosa = true;
            List<BEDocumRegSerie> listaDocumRegSerie = new List<BEDocumRegSerie>();
            ProductoLogic oiProductoSeriadoLogic = new ProductoLogic();
            List<BEProductoSeriado> lstProductoSeriadoNuevos = new List<BEProductoSeriado>();
            List<BEProductoSeriado> lstProductoSeriadoEditas = new List<BEProductoSeriado>();
            List<BEProductoSeriado> lstProductoSeriadoDocume = new List<BEProductoSeriado>();
            foreach (BEProductoSeriado productoSeriado in comprobanteEmisionDetalle.listaProductoSeriados)
            {
                LlenarEntidadProductoSeriados(comprobanteEmision, comprobante, cEstadoMercaderia, comprobanteEmisionDetalle, productoSeriado);
                if (productoSeriado.CodigoRegistro == null)
                    lstProductoSeriadoNuevos.Add(productoSeriado);
                else if (productoSeriado.CodigoRegistro != null)
                    lstProductoSeriadoEditas.Add(productoSeriado);
            }
            if (lstProductoSeriadoEditas.Count > 0)
                oiProductoSeriadoLogic.UpdateProductoSeriado(lstProductoSeriadoEditas, 
                                                             comprobanteEmision.SegUsuarioEdita,
                                                             comprobanteEmision.codEmpresa);
            List<BEProductoSeriado> lstProductoSeriadoRegistrado = new List<BEProductoSeriado>();
            if (lstProductoSeriadoNuevos.Count > 0)
            {
                ConfiguracionLogic configuracionLogic = new ConfiguracionLogic();
                string strCodAduana = ConfigCROM.AppConfig(comprobanteEmision.codEmpresa, 
                                                           ConfigTool.DEFAULT_Merca_Aduana);
                foreach (BEProductoSeriado hyui in lstProductoSeriadoNuevos)
                    if (comprobanteEmision.indInternacional)
                        hyui.codRegEstadoMercaderia = strCodAduana;
                lstProductoSeriadoRegistrado = productoLogic.InsertProductoSeriado(lstProductoSeriadoNuevos,
                                                                                   comprobanteEmision.SegUsuarioCrea,
                                                                                   comprobanteEmision.codEmpresa);
            }
            foreach (BEProductoSeriado productoSeriado in lstProductoSeriadoNuevos)
                lstProductoSeriadoDocume.Add(productoSeriado);
            foreach (BEProductoSeriado productoSeriado in lstProductoSeriadoEditas)
                lstProductoSeriadoDocume.Add(productoSeriado);
            listaDocumRegSerie.AddRange(LlenarEntidadDocumRegSerie(comprobanteEmision.SegUsuarioEdita, SUCEDE_DETALLE, lstProductoSeriadoDocume));
            if (listaDocumRegSerie.Count > 0)
            {
                rnsReturnValor = InsertDocumRegSerie(listaDocumRegSerie);
            }
            return rnsReturnValor;
        }

        private static BEListaDePrecioDetalle LlenarEntidadListaDePrecioDetalle(BEComprobanteEmisionDetalle comprobanteEmisionDetalle, int pcodEmpresa)
        {
            BEListaDePrecioDetalle listaDePrecioDetalle = new BEListaDePrecioDetalle
            {
                CodigoArguMoneda = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_MonedaNac),
                CodigoLista = comprobanteEmisionDetalle.CodigoListaPrecio,
                codEmpresa = comprobanteEmisionDetalle.codEmpresa,
                CodigoPuntoVenta = comprobanteEmisionDetalle.CodigoPuntoVenta,
                CodigoProducto = comprobanteEmisionDetalle.CodigoProducto,
                codProducto = comprobanteEmisionDetalle.codProducto,
                Estado = true,
                PrecioUnitario = comprobanteEmisionDetalle.refUnitValorCosto,
                segUsuarioCrea = comprobanteEmisionDetalle.SegUsuarioCrea,
                segUsuarioEdita = comprobanteEmisionDetalle.SegUsuarioCrea,
            };
            return listaDePrecioDetalle;
        }
        private void LlenarEntidadProductoKardexAux(BEComprobanteEmision comprobanteEmision, int? SUCEDE_DETALLE, BEComprobanteEmisionDetalle comprobanteEmisionDetalle)
        {
            productoKardex = new ProductoKardexAux
            {
                codDocumRegDetalle = SUCEDE_DETALLE.Value,
                codDocumReg = comprobanteEmision.codDocumReg,
                codRegistroTipoMotivo = comprobanteEmision.CodigoArguTipoDeOperacion,
                codDeposito = comprobanteEmision.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_CLIENTES ? 
                              comprobanteEmision.CodigoArguDepositoOrigen : comprobanteEmision.CodigoArguDepositoDesti,
                codPersonaMovimi = comprobanteEmision.CodigoPersonaEntidad,
                codProducto = comprobanteEmisionDetalle.codProducto,
                codigoProducto = comprobanteEmisionDetalle.CodigoProducto,
                indActivo = true,
                perKardexAnio = DateTime.Now.Year,
                fecMovimiento = comprobanteEmision.FechaDeEmision,
                segUsuarioCrea = comprobanteEmision.SegUsuarioCrea,
                desRazonSocial = comprobanteEmision.EntidadRazonSocial,
                codItemDetalle = comprobanteEmisionDetalle.CodigoItemDetalle,
            };
            if (comprobanteEmision.indInventarioAutomatico)
                productoKardex.perInventario = comprobanteEmision.strInventarioAutomatico;
        }
        private static void LlenarEntidadProductoSeriados(BEComprobanteEmision comprobanteEmision, BEDocumento comprobante, string cEstadoMercaderia, BEComprobanteEmisionDetalle comprobanteEmisionDetalle, BEProductoSeriado productoSeriado)
        {
            if (!string.IsNullOrEmpty(cEstadoMercaderia))
                productoSeriado.codRegEstadoMercaderia = cEstadoMercaderia;
            productoSeriado.SegUsuarioCrea = comprobanteEmision.SegUsuarioCrea;
            productoSeriado.SegUsuarioEdita = comprobanteEmision.SegUsuarioCrea;
            productoSeriado.CodigoPersonaEmpre = comprobanteEmision.CodigoPersonaEmpre;
            productoSeriado.CodigoPuntoVenta = comprobanteEmision.CodigoPuntoVenta;
            productoSeriado.codDeposito = string.IsNullOrEmpty(comprobanteEmisionDetalle.CodigoArguDepositoAlm) ? productoSeriado.codDeposito : comprobanteEmisionDetalle.CodigoArguDepositoAlm;
            if (comprobante.IncidenciaEnStocks == 1)
            {
                productoSeriado.CodigoPersonaProveedor = comprobanteEmision.CodigoPersonaEntidad;
                productoSeriado.NumeroComprobanteCompra = comprobanteEmision.NumeroComprobante;
                productoSeriado.FechaIngreso = comprobanteEmision.FechaDeEmision;
            }
            else if (comprobante.IncidenciaEnStocks == -1)
            {
                productoSeriado.CodigoPersonaCliente = comprobanteEmision.CodigoPersonaEntidad;
                productoSeriado.NumeroComprobanteVenta = comprobanteEmision.NumeroComprobante;
                productoSeriado.FechaVenta = comprobanteEmision.FechaDeEmision;
            }
            else if (comprobante.IncidenciaEnStocks == 0)
            {
                productoSeriado.CodigoPersonaComprometido = comprobanteEmision.CodigoPersonaEntidad;
                productoSeriado.NumeroComprobanteComprom = comprobanteEmision.NumeroComprobante;
                productoSeriado.FechaComprometido = comprobanteEmision.FechaDeEmision;
            }
        }
        private static List<BEDocumRegSerie> LlenarEntidadDocumRegSerie(string psegUsuarioEdita, int? SUCEDE_DETALLE, List<BEProductoSeriado> lstProductoSeriado)
        {
            List<BEDocumRegSerie> lstDocumRegSerie = new List<BEDocumRegSerie>();
            foreach (BEProductoSeriado productoSeriado in lstProductoSeriado)
            {
                BEDocumRegSerie documRegSerie = new BEDocumRegSerie
                {
                    codDocumRegDetalle = SUCEDE_DETALLE.Value,
                    codProductoSeriado = productoSeriado.codProductoSeriado,
                    codProducto = productoSeriado.codProducto,
                    segUsuarioEdita = psegUsuarioEdita,

                };
                lstDocumRegSerie.Add(documRegSerie);
            }
            return lstDocumRegSerie;
        }

        private static string DetectarEstadoDeMercaderia(BEComprobanteEmision comprobanteEmision, BEDocumento comprobante)
        {
            string pEstadoMercaderia = string.Empty;
            if (comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString())
                if (comprobanteEmision.CodigoArguMotivoGuia == ConfigCROM.AppConfig(comprobanteEmision.codEmpresa, 
                                                                                    ConfigTool.DEFAULT_Doc_GuiaRemConsig))
                    pEstadoMercaderia = ConfigCROM.AppConfig(comprobanteEmision.codEmpresa,
                                                             ConfigTool.DEFAULT_MercaderConsig);
                else
                    pEstadoMercaderia = string.Empty;
            else if (comprobante.IncidenciaEnCaja == 1 && comprobante.IncidenciaEnStocks == -1)
                pEstadoMercaderia = ConfigCROM.AppConfig(comprobanteEmision.codEmpresa,
                                                         ConfigTool.DEFAULT_MercaderVendida);
            return pEstadoMercaderia;
        }

        private ReturnValor EliminarTodaReferenciaComprobanteEmision(BEComprobanteEmision comprobanteEmision, 
                                                                     BEDocumento comprobante)
        {
            string codDeposito = null;
            decimal? SALDO_StockFisico = null;
            try
            {
                using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (comprobante.IncidenciaEnStocks != 0)
                    {

                        if (comprobante.IncidenciaEnStocks == 1)
                            codDeposito = comprobanteEmision.CodigoArguDepositoDesti;
                        else
                            codDeposito = comprobanteEmision.CodigoArguDepositoOrigen;
                        //E L I M I N A = En tabla: [Produccion].[ProductoKardex]
                        returnValor = productoKardexLogic.Delete(new BaseFiltroAlmacen
                        {
                            codDocumReg = comprobanteEmision.codDocumReg,
                            codDeposito = codDeposito
                        });
                        if (!returnValor.Exitosa)
                            return returnValor;
                    }

                    if (comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString())
                    {
                        //E L I M I N A = En tabla: [Produccion].[ProductoKardex]
                        returnValor = productoKardexLogic.Delete(new BaseFiltroAlmacen
                        {
                            codDocumReg = comprobanteEmision.codDocumReg,
                            codDeposito = null
                        });
                        if (!returnValor.Exitosa)
                            return returnValor;
                    }

                    if (comprobante.IncidenciaEnCtaCte != 0)
                    {
                        //E L I M I N A = En tabla: [GestionComercial].[CuentaCorriente]
                        returnValor.Exitosa = cuentasCorrientesData.DeleteCodDocumReg(comprobanteEmision.codEmpresa,
                                                                           comprobanteEmision.codDocumReg, 
                                                                           null,
                                                                           comprobanteEmision.SegUsuarioEdita);
                        if (!returnValor.Exitosa)
                        {
                            returnValor.Message = HelpMessages.CTA_CORRIENTE_NoEliminada;
                            return returnValor;
                        }
                    }

                    if (comprobanteEmision.NumeroComprobanteORIGEN != null)
                        if (comprobanteEmision.CodigoComprobanteORIGEN != null && 
                            comprobanteEmision.NumeroComprobanteORIGEN.Trim().Length > 0)
                        {
                            BEDocumento itemComprobantesREF = new BEDocumento();
                            itemComprobantesREF = new DocumentoLogic().Find(comprobanteEmision.CodigoComprobanteORIGEN,
                                                                            comprobanteEmision.codEmpresaRUC,
                                                                            comprobanteEmision.codEmpresa,
                                                                            comprobanteEmision.SegUsuarioEdita);
                            // SE ASIGNA EL ID del Documento Emitido a los DOCUMENTOS Referenciados
                            String[] documentosORIGEN = comprobanteEmision.NumeroComprobanteORIGEN.Trim().Split(new Char[] { ' ' });
                            foreach (string IdNumeroORIGEN in documentosORIGEN)
                            {
                                //A C T U A L I Z A = En tabla: [GestionComercial].[DocumentoMovCabecera]
                                returnValor.Exitosa = comprobanteEmisionData.UpdateRefDesAsigna(
                                                                    comprobanteEmision.codDocumReg,
                                                                    comprobanteEmision.CodigoComprobanteORIGEN,
                                                                    IdNumeroORIGEN,
                                                                    itemComprobantesREF.CodigoArguEstEMIDefault,
                                                                    comprobanteEmision.SegUsuarioCrea);
                                if (!returnValor.Exitosa)
                                {
                                    returnValor.Message = HelpMessages.gc_DOCUM_NoDesAsigRefer;
                                    return returnValor;
                                }
                            }
                        }

                    List<BEProductoSeriado> lstProductoSeriado = new List<BEProductoSeriado>();
                    foreach (BEComprobanteEmisionDetalle comprobanteEmisionDetalle in comprobanteEmision.listaComprobanteEmisionDetalle)
                    {
                        if (comprobante.IncidenciaEnStocks != 0 ||
                            comprobanteEmision.CodigoArguMotivoGuia == ConfigCROM.AppConfig(comprobanteEmision.codEmpresa,
                                                                                            ConfigTool.DEFAULT_Doc_GuiaRemConsig))
                        {
                            if (!comprobanteEmision.indInternacional)
                            {
                                if (comprobanteEmisionDetalle.EsVerificarStock)
                                {
                                    if (comprobanteEmision.CodigoArguTipoDeOperacion == ConfigCROM.AppConfig(comprobanteEmision.codEmpresa,
                                                                                                             ConfigTool.DEFAULT_Movim_SInicial))
                                    {
                                        //E L I M I N A = En tabla: [Almacen].[ProductoExistencia]
                                        returnValor = productoLogic.DeleteProductoExistencia(new 
                                         BEProductoExistenciaFind 
                                        {
                                            codEmpresa = comprobanteEmision.codEmpresa,
                                            codProducto = comprobanteEmisionDetalle.codProducto,
                                            codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm
                                        });
                                        if (!returnValor.Exitosa)
                                            return returnValor;
                                    }
                                    else if (comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_COMPRA ||
                                                 comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_TRANSFER_ALMACEN ||
                                                 comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_DEVOLU_RECIBIDA ||
                                                 comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_CONSIG_RECIBIDA ||
                                                 comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_VENTA ||
                                                 comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_RETIRO ||
                                                 comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_MERMAS ||
                                                 comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_DONACION ||
                                                 comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_PREMIO ||
                                                 comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_DEVOLU_ENTREGADA ||
                                                 comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_SALIDA_PRODUCCION ||
                                                 comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_DESTRUCCION ||
                                                 comprobanteEmision.CodigoArguTipoDeOperacion == ConstantesGC.TIPO_MOV_DOCUME_CONSIG_ENTREGADA)
                                    {

                                        if (comprobante.Abreviatura != HelpDocumentos.Tipos.GRE.ToString())
                                        {
                                            //A C T U A L I Z A = Stock Fisico En tabla: [Almacen].[ProductoExistencia]
                                            returnValor = productoLogic.UpdateProductoExistenciaStockFisico(new 
                                             BEProductoExistenciaStockUpdate
                                            {
                                                codEmpresa = comprobanteEmision.codEmpresa,
                                                codProducto = comprobanteEmisionDetalle.codProducto,
                                                codDeposito = codDeposito,
                                                cntStockFisico = Math.Round((decimal)comprobanteEmisionDetalle.Cantidad, 3),
                                                indOperador = comprobante.IncidenciaEnStocks * -1,
                                                segUsuarioEdita = comprobante.segUsuarioCrea,
                                            }, ref SALDO_StockFisico);
                                            if (!returnValor.Exitosa)
                                                return returnValor;
                                        }
                                        else
                                        {
                                            if (comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString())
                                            {
                                                //A C T U A L I Z A = Stock Fisico Consig En tabla: [Almacen].[ProductoExistencia]
                                                returnValor = productoLogic.UpdateProductoExistenciaStockFisicoConsig(new 
                                                 BEProductoExistenciaStockUpdate
                                                {
                                                    codEmpresa = comprobanteEmision.codEmpresa,
                                                    codProducto = comprobanteEmisionDetalle.codProducto,
                                                    codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm,
                                                    cntStockFisico = Math.Round((decimal)comprobanteEmisionDetalle.Cantidad, 3),
                                                    indOperador = comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString() ? 1 : (comprobante.IncidenciaEnStocks * -1),
                                                    segUsuarioEdita = comprobante.segUsuarioCrea,
                                                    cntStockComprometido = Math.Round((decimal)comprobanteEmisionDetalle.Cantidad, 3)
                                                }, ref SALDO_StockFisico);
                                                if (!returnValor.Exitosa)
                                                    return returnValor;
                                            }
                                            else
                                            {
                                                //A C T U A L I Z A = Stock Comprometido En tabla: [Almacen].[ProductoExistencia]
                                                returnValor = productoLogic.UpdateProductoExistenciaStockComprometido(new
                                                 BEProductoExistenciaStockUpdate
                                                {
                                                    codEmpresa = comprobanteEmision.codEmpresa,
                                                    codProducto = comprobanteEmisionDetalle.codProducto,
                                                    codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm,
                                                    cntStockFisico = Math.Round((decimal)comprobanteEmisionDetalle.Cantidad, 3),
                                                    indOperador = comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString() ? -1 : (comprobante.IncidenciaEnStocks * 1),
                                                    segUsuarioEdita = comprobante.segUsuarioCrea
                                                }, ref SALDO_StockFisico);
                                                if (!returnValor.Exitosa)
                                                    return returnValor;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString())
                                        {
                                            //A C T U A L I Z A = Stock Fisico Consig En tabla: [Almacen].[ProductoExistencia]
                                            returnValor = productoLogic.UpdateProductoExistenciaStockFisicoConsig(new 
                                             BEProductoExistenciaStockUpdate
                                            {
                                                codEmpresa = comprobanteEmision.codEmpresa,
                                                codProducto = comprobanteEmisionDetalle.codProducto,
                                                codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm,
                                                cntStockFisico = Math.Round((decimal)comprobanteEmisionDetalle.Cantidad, 3),
                                                indOperador = comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString() ? 1 : (comprobante.IncidenciaEnStocks * -1),
                                                segUsuarioEdita = comprobante.segUsuarioCrea,
                                                cntStockComprometido = Math.Round((decimal)comprobanteEmisionDetalle.Cantidad, 3)
                                            }, ref SALDO_StockFisico);
                                            if (!returnValor.Exitosa)
                                                return returnValor;
                                        }
                                        else
                                        {    //A C T U A L I Z A = Stock Comprometido En tabla: [Almacen].[ProductoExistencia]
                                            returnValor = productoLogic.UpdateProductoExistenciaStockComprometido(new 
                                             BEProductoExistenciaStockUpdate
                                            {
                                                codEmpresa = comprobanteEmision.codEmpresa,
                                                codProducto = comprobanteEmisionDetalle.codProducto,
                                                codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm,
                                                cntStockFisico = Math.Round((decimal)comprobanteEmisionDetalle.Cantidad, 3),
                                                indOperador = comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString() ? -1 : (comprobante.IncidenciaEnStocks * 1),
                                                segUsuarioEdita = comprobante.segUsuarioCrea
                                            }, ref SALDO_StockFisico);
                                            if (!returnValor.Exitosa)
                                                return returnValor;
                                        }
                                    }
                                }
                            }
                            if (comprobante.IncidenciaEnStocks == 1)
                            {
                                foreach (BEProductoSeriado productoSeriado in comprobanteEmisionDetalle.listaProductoSeriados)
                                {
                                    //E L I M I N A = En tabla: [Almacen].[ProductoSeriado]
                                    returnValor = productoLogic.DeleteProductoSeriadoPorDetalle(new BaseFiltroAlmacen
                                    {
                                        codId = productoSeriado.codProductoSeriado,
                                        codProducto = comprobanteEmisionDetalle.codProducto,
                                        codDocumRegDetalle = comprobanteEmisionDetalle.codDocumRegDetalle
                                    });
                                    if (!returnValor.Exitosa)
                                        return returnValor;
                                }
                            }
                            else
                            {
                                foreach (BEProductoSeriado productoSeriado in comprobanteEmisionDetalle.listaProductoSeriados)
                                {
                                    productoSeriado.NumeroComprobanteVenta = null;
                                    productoSeriado.SegUsuarioEdita = comprobanteEmision.SegUsuarioEdita;
                                    productoSeriado.FechaVenta = null;
                                    productoSeriado.codRegEstadoMercaderia = ConfigCROM.AppConfig(comprobanteEmision.codEmpresa,
                                                                                                  ConfigTool.DEFAULT_MercaderApto);
                                    productoSeriado.CodigoPersonaCliente = null;
                                    productoSeriado.EstadoVendido = false;
                                    lstProductoSeriado.Add(productoSeriado);
                                }
                                if (lstProductoSeriado.Count > 0)
                                {
                                    //E L I M I N A = En tabla: [Almacen].[ProductoSeriado]
                                    returnValor = productoLogic.UpdateProductoSeriado(lstProductoSeriado,
                                                                                      comprobanteEmision.SegUsuarioEdita,
                                                                                      comprobanteEmision.codEmpresa);
                                    if (!returnValor.Exitosa)
                                        return returnValor;
                                }
                            }
                        }
                        else
                            if (comprobanteEmisionDetalle.EsVerificarStock)
                            {
                                foreach (BEProductoSeriado productoSeriado in comprobanteEmisionDetalle.listaProductoSeriados)
                                {
                                    productoSeriado.NumeroComprobanteComprom = null;
                                    productoSeriado.SegUsuarioEdita = comprobanteEmision.SegUsuarioEdita;
                                    productoSeriado.codRegEstadoMercaderia = ConfigCROM.AppConfig(comprobanteEmision.codEmpresa,
                                                                                                  ConfigTool.DEFAULT_MercaderApto);
                                    productoSeriado.CodigoPersonaComprometido = null;
                                    productoSeriado.EstadoVendido = false;
                                    lstProductoSeriado.Add(productoSeriado);
                                }
                                if (lstProductoSeriado.Count > 0)
                                {
                                    //A C T U A L I Z A = En tabla: [Almacen].[ProductoSeriado]
                                    returnValor = productoLogic.UpdateProductoSeriado(lstProductoSeriado, 
                                                                                      comprobanteEmision.SegUsuarioEdita,
                                                                                      comprobanteEmision.codEmpresa);
                                    if (!returnValor.Exitosa)
                                        return returnValor;
                                }
                                if (comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString() &&
                                    comprobanteEmision.CodigoArguDestinoComp == WebConstants.DEFAULT_DOCUM_DESTINADO_CLIENTES)
                                {
                                    if (comprobanteEmisionDetalle.EsVerificarStock)
                                    {
                                        decimal? prm_SALDO_StockComprometido = null;
                                        //A C T U A L I Z A = Stock Comprometido En tabla: [Almacen].[ProductoExistencia]
                                        returnValor = productoLogic.UpdateProductoExistenciaStockComprometido(new  BEProductoExistenciaStockUpdate
                                        {
                                            codEmpresa = comprobanteEmision.codEmpresa,
                                            codProducto = comprobanteEmisionDetalle.codProducto,
                                            cntStockComprometido = comprobanteEmisionDetalle.Cantidad,
                                            codDeposito = comprobanteEmision.CodigoArguDepositoOrigen,
                                            indOperador = -1,
                                            segUsuarioEdita = comprobanteEmision.SegUsuarioCrea
                                        }, ref prm_SALDO_StockComprometido);
                                        if (!returnValor.Exitosa)
                                            return returnValor;
                                    }
                                }
                            }
                    }
                    InventarioLogic inventarioLogic = new InventarioLogic();
                    //D E L E T E = En tabla: [Almacen].[InventarioDocumReg]
                    returnValor = inventarioLogic.DeleteInventarioDocumReg(new BaseFiltroAlmacen { codDocumReg = comprobanteEmision.codDocumReg });
                    if (!returnValor.Exitosa)
                        return returnValor;

                    //D E L E T E = En tabla: [GestionComercial].[DocumRegSerie]
                    returnValor = DeletecodDocumReg(comprobanteEmision);
                    if (!returnValor.Exitosa)
                        return returnValor;

                    ComprobanteEmisionImpuestosData oComprobanteEmisionImpuestosData = new ComprobanteEmisionImpuestosData();
                    //D E L E T E = En tabla: [GestionComercial].[DocumentoMovImpuesto]
                    returnValor.Exitosa = oComprobanteEmisionImpuestosData.Delete(comprobanteEmision.codDocumReg);
                    if (!returnValor.Exitosa)
                    {
                        returnValor.Message = HelpMessages.gc_IMPUESTO_NoDefinido;
                        return returnValor;
                    }

                    CajaRegistroData oCajaRegistroData = new CajaRegistroData();
                    //D E L E T E = En tabla: [CajaBancos].[CajaRegistro]
                    returnValor.Exitosa = oCajaRegistroData.Delete(comprobanteEmision.codEmpresaRUC, 
                                                                   comprobanteEmision.codDocumReg);

                    if (!returnValor.Exitosa)
                    {
                        returnValor.Message = HelpMessages.CAJA_NoEliminada;
                        return returnValor;
                    }

                    //LetraDeCambioData oLetraDeCambioData = new LetraDeCambioData();
                    ////D E L E T E = En tabla: [GestionComercial].[LetraDeCambio]
                    //returnValor.Exitosa = oLetraDeCambioData.Delete(comprobanteEmision.codDocumReg);
                    //if (!returnValor.Exitosa)
                    //{
                    //    returnValor.Message = HelpMessages.LETRACAMBIO_NoEliminada;
                    //    return returnValor;
                    //}

                    //D E L E T E = En tabla: [GestionComercial].[DocumentoMovDetalle]
                    returnValor.Exitosa = comprobanteEmisionDetalleData.Delete(comprobanteEmision.codDocumReg);
                    if (!returnValor.Exitosa)
                    {
                        returnValor.Message = HelpMessages.gc_DOCUM_DetalleNoElimnado;
                        return returnValor;
                    }

                    transactionScope.Complete();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return returnValor;
        }

        private static ProductoKardexAux LllenarEntidadProductoKardexAux(BEComprobanteEmision comprobanteEmision, ProductoKardexAux productoKardexDevolucion, ProductoKardexAux productoKardex)
        {
            productoKardexDevolucion = new ProductoKardexAux
            {
                codEmpresa = comprobanteEmision.codEmpresa,
                fecMovimiento = DateTime.Now,
                codRegistroTipoMovimi = ConstantesGC.TIPO_MOV_KARDEX_ENTRADA,
                codPersonaMovimi = productoKardex.codPersonaMovimi,
                cntEntrada = productoKardex.cntSalida,
                monCostoUnitEntrada = productoKardex.monCostoUnitSalida,
                cntSaldo = productoKardex.cntSaldo,
                monTotalSaldo = productoKardex.monTotalSaldo,
                desRazonSocial = productoKardex.desRazonSocial,
                perKardexAnio = productoKardex.perKardexAnio,
                codDeposito = productoKardex.codDeposito,
                codRegistroTipoMotivo = ConstantesGC.TIPO_MOV_DOCUME_CONSIG_RECIBIDA,
                indActivo = productoKardex.indActivo,
                segUsuarioCrea = comprobanteEmision.SegUsuarioEdita,
                segFechaCrea = DateTime.Now,
                codProducto = productoKardex.codProducto,
                codDocumRegDetalle = productoKardex.codDocumRegDetalle,
            };
            return productoKardexDevolucion;
        }
        private void EsDocumentoValido(List<BEComprobanteEmision> lstComprobanteEmision, BEDocumento comprobante)
        {
            foreach (BEComprobanteEmision comprobanteEmision in lstComprobanteEmision)
            {
                if (string.IsNullOrEmpty(comprobanteEmision.CodigoArguEstadoDocu))
                    returnValor.Message = HelpMessages.VALIDACIONGeneral;
                else if (comprobanteEmision.CodigoArguEstadoDocu == comprobante.CodigoArguEstANUDefault)
                    returnValor.Message = HelpMessages.gc_DOCUM_YA_ANULADO;
                else if (comprobanteEmision.CodigoComprobanteDESTINO != null)
                    returnValor.Message = HelpMessages.gc_DOCUM_NO_ANULADO;
            }
        }


        private void NumerodeComprobante(BEComprobanteEmision comprobanteEmision,
                                         BEDocumento comprobante,
                                         out string pMessage)
        {
            pMessage = string.Empty;
            ReturnValor objNDReturnValor = new ReturnValor();
            //GREG001000017213 - SI EL NUMERO ES DIGITADO DESDE EL FORMULARIO, SE RESPETARA LO INGRESADO
            if (!string.IsNullOrEmpty(comprobanteEmision.NumeroComprobante))
            {
                if (comprobanteEmision.NumeroComprobante.Length > 15)
                {
                    int numeroExistente = Extensors.ToInteger(comprobanteEmision.NumeroComprobante.Substring(7, 9));
                    if (numeroExistente > 0)
                    {
                        return;
                    }
                }
            }


            List<BEDocumentoSerie> lstDocumentoSerie = new List<BEDocumentoSerie>();
            lstDocumentoSerie = comprobantesSeriesData.ListPorUsuario(new BaseFiltroDocumentoSerie
            {
                codEmpresa = comprobanteEmision.codEmpresa,
                codEmpresaRUC = comprobanteEmision.codEmpresaRUC,
                segUsuarioActual = comprobanteEmision.SegUsuarioCrea,
                codPlanilla = comprobanteEmision.codEmpleadoPlanilla,
                codPuntoVenta = comprobanteEmision.CodigoPuntoVenta,
                codDocumento = comprobanteEmision.CodigoComprobante,
                indEstado = true
            });
            if (lstDocumentoSerie.Count > 0)
            {

                objNDReturnValor = documentoLogic.UltimoNumeroDocumento(comprobanteEmision.codEmpresaRUC,
                                                                     lstDocumentoSerie[0].codDocumentoSerie,
                                                                     comprobanteEmision.SegUsuarioCrea,
                                                                     comprobanteEmision.codEmpresa);
                if (objNDReturnValor.Exitosa)
                {
                    comprobanteEmision.NumeroComprobante = string.Concat(comprobante.Abreviatura, 
                                                                         objNDReturnValor.CodigoRetorno
                                                                         .Replace("-",""));
                }
                else
                {
                    comprobanteEmision.NumeroComprobante = string.Empty; ;
                }

                pMessage = objNDReturnValor.Message;
            }
        }

        #endregion

    }
}

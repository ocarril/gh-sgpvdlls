namespace CROM.ComercialAlmacen.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Transactions;

    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.Comercial.DTO;
    using CROM.BusinessEntities.Almacen;
    using CROM.BusinessEntities.Maestros;
    using CROM.BusinessEntities.Cajas;
    using CROM.BusinessEntities.RecursosHumanos;
    using CROM.GestionComercial.DataAccess;
    using CROM.TablasMaestras.BussinesLogic;
    using CROM.RecursosHumanos.BusinessLogic;
    using CROM.Tools.Config;
    using CROM.Tools;
    using CROM.Tools.Comun;
    using CROM.GestionAlmacen.DataAccess;
    using CROM.GestionComercial.BusinessLogic;

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
        private ProductoExistenciasData productoExistenciasData = null;
        private ProductoExistenciasKardexData productoExistenciasKardexData = null;
        private DocumentoSerieData comprobantesSeriesData = null;
        private ProductoSeriadosData productoSeriadosData = null;
        private DocumentoData comprobantesData = null;
        private CuentasCorrientesData cuentasCorrientesData = null;
        private LetraDeCambioData letraDeCambioData = null;
        private GastoDeAduanaData gastoDeAduanaData = null;
        private ComprobanteEmisionImpuestosData comprobanteEmisionImpuestosData = null;
        private DocumRegSerieData objDocumRegSerieData = null;
        private ProductoKardexAux productoKardex = null;
        private AuditoriaSistemaLogic auditoriaSistemaLogic = new AuditoriaSistemaLogic();
        private ConfiguracionLogic cnf = new ConfiguracionLogic();

        private ReturnValor returnValor = null;

        public ComprobanteEmisionLogic()
        {
            comprobanteEmisionData = new ComprobanteEmisionData();
            comprobanteEmisionDetalleData = new ComprobanteEmisionDetalleData();
            productoExistenciasData = new ProductoExistenciasData();
            productoExistenciasKardexData = new ProductoExistenciasKardexData();
            comprobantesSeriesData = new DocumentoSerieData();
            productoSeriadosData = new ProductoSeriadosData();
            comprobantesData = new DocumentoData();
            cuentasCorrientesData = new CuentasCorrientesData();
            letraDeCambioData = new LetraDeCambioData();
            gastoDeAduanaData = new GastoDeAduanaData();
            comprobanteEmisionImpuestosData = new ComprobanteEmisionImpuestosData();
            objDocumRegSerieData = new DocumRegSerieData();
            returnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ComprobanteEmision
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmision]
        /// <summary>
        /// <returns>List</returns>
        public List<BEComprobanteEmision> List(Nullable<DateTime> prm_FechaDeEmisionInicio, Nullable<DateTime> prm_FechaDeEmisionFinal, string prm_CodigoPersonaEmpre,
                                                string prm_CodigoPuntoVenta, string prm_CodigoComprobante, string prm_CodigoArguEstadoDocu,
                                                string prm_CodigoArguDestinoComp, string prm_CodigoPersonaEntidad, int? prm_codEmpleado,
                                                string prm_CodigoArguMoneda, string prm_CodigoParte, int? prm_CondicionVenta, int? prm_CondicionCompra,
                                                bool prm_Estado, string prm_CodigoArguTipoDeOperacion, bool CON_DETALLES, bool? prm_indInternacional)//
        {
            List<BEComprobanteEmision> lstComprobanteEmision = new List<BEComprobanteEmision>();
            try
            {
                lstComprobanteEmision = comprobanteEmisionData.List(HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionInicio), HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionFinal), prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta,
                                                       prm_CodigoComprobante, prm_CodigoArguEstadoDocu, prm_CodigoArguDestinoComp, prm_CodigoPersonaEntidad,
                                                       prm_codEmpleado, prm_CodigoArguMoneda, prm_CodigoParte, prm_CondicionVenta,
                                                       prm_CondicionCompra, prm_Estado, prm_CodigoArguTipoDeOperacion, prm_indInternacional);

                foreach (BEComprobanteEmision x in lstComprobanteEmision)
                {
                    if (x.DocEsFacturable)
                    {
                        if (x.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_COMPRAS)
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
                if (CON_DETALLES)
                {
                    foreach (BEComprobanteEmision itemComprobanteEmision in lstComprobanteEmision)
                        itemComprobanteEmision.listaComprobanteEmisionDetalle = comprobanteEmisionDetalleData.List(itemComprobanteEmision.codDocumReg, string.Empty);
                }
            }
            catch (Exception ex)
            {
                Helper.CreateEventLog(ex.Message + "- Seguimiento -" + ex.StackTrace, 1, Helper.CategEvento.LIST);
                throw ex;
            }
            return lstComprobanteEmision;
        }

        public List<BEComprobanteEmision> List(Nullable<DateTime> prm_FechaDeEmisionInicio, Nullable<DateTime> prm_FechaDeEmisionFinal, string prm_CodigoPersonaEmpre,
                                                        string prm_CodigoPuntoVenta, string prm_CodigoComprobante, string prm_CodigoArguEstadoDocu,
                                                        string prm_CodigoArguDestinoComp, string prm_CodigoPersonaEntidad, int? prm_codEmpleado,
                                                        string prm_CodigoArguMoneda, string prm_CodigoParte, int? prm_CondicionVenta, int? prm_CondicionCompra,
                                                        bool prm_Estado, string prm_CodigoArguTipoDeOperacion, bool CON_DETALLES, bool? prm_indInternacional, Helper.ComboBoxText pTexto)
        {
            List<BEComprobanteEmision> lstComprobanteEmision = new List<BEComprobanteEmision>();
            try
            {
                lstComprobanteEmision = comprobanteEmisionData.List(HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionInicio), HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionFinal), prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta,
                                                       prm_CodigoComprobante, prm_CodigoArguEstadoDocu, prm_CodigoArguDestinoComp, prm_CodigoPersonaEntidad,
                                                       prm_codEmpleado, prm_CodigoArguMoneda, prm_CodigoParte, prm_CondicionVenta,
                                                       prm_CondicionCompra, prm_Estado, prm_CodigoArguTipoDeOperacion, prm_indInternacional);

                foreach (BEComprobanteEmision x in lstComprobanteEmision)
                {
                    if (x.DocEsFacturable)
                    {
                        if (x.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_COMPRAS)
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
                    if (prm_CodigoComprobante == ConfigCROM.AppConfig(ConfigTool.DEFAULT_Doc_FacturaProvLocal))
                    {
                        string xdat = (string.IsNullOrEmpty(x.NumeroComprobanteExt) == true ? string.Empty : x.NumeroComprobanteExt);
                        string xmon = (string.IsNullOrEmpty(x.CodigoArguMonedaNombre) == true ? string.Empty : x.CodigoArguMonedaNombre);
                        string xtot = x.CodigoArguMoneda == ConfigCROM.AppConfig(ConfigTool.DEFAULT_MonedaNac) ? x.ValorTotalPrecioVenta.ToString("N2") : x.ValorTotalPrecioExtran.ToString("N2");
                        x.NumeroMinuta = xdat + " ref. " + x.NumeroComprobante + " - " + xmon + " - " + xtot;
                    }
                }
                if (CON_DETALLES)
                {
                    foreach (BEComprobanteEmision itemComprobanteEmision in lstComprobanteEmision)
                        itemComprobanteEmision.listaComprobanteEmisionDetalle = comprobanteEmisionDetalleData.List(itemComprobanteEmision.codDocumReg, string.Empty);
                }
                if (lstComprobanteEmision.Count > 0)
                    lstComprobanteEmision.Insert(0, new BEComprobanteEmision { CodigoComprobante = "", NumeroComprobante = Helper.ObtenerTexto(pTexto) });
                else
                    lstComprobanteEmision.Add(new BEComprobanteEmision { CodigoComprobante = "", NumeroComprobante = Helper.ObtenerTexto(pTexto) });

            }
            catch (Exception ex)
            {
                Helper.CreateEventLog(ex.Message + "- Seguimiento -" + ex.StackTrace, 1, Helper.CategEvento.LIST);
                throw ex;
            }
            return lstComprobanteEmision;
        }

        public List<BEComprobanteEmision> ListGeneral(Nullable<DateTime> prm_FechaDeEmisionInicio, Nullable<DateTime> prm_FechaDeEmisionFinal, string prm_CodigoPersonaEmpre,
                                                 string prm_CodigoPuntoVenta, string prm_CodigoComprobante, string prm_CodigoArguEstadoDocu,
                                                 string prm_CodigoArguDestinoComp, string prm_CodigoPersonaEntidad, int? prm_codEmpleado,
                                                 string prm_CodigoArguMoneda, string prm_CodigoParte, int? prm_CondicionVenta, int? prm_CondicionCompra,
                                                 bool prm_Estado, string prm_CodigoArguTipoDeOperacion, bool CON_DETALLES, string prm_RazonSocial,
                                                 string prm_DescripcionDetalle, bool? prm_indInternacional)
        {
            List<BEComprobanteEmision> listaComprobanteEmision = new List<BEComprobanteEmision>();
            try
            {
                listaComprobanteEmision = comprobanteEmisionData.ListGeneral(HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionInicio), HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionFinal), prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta,
                                                       prm_CodigoComprobante, prm_CodigoArguEstadoDocu, prm_CodigoArguDestinoComp, prm_CodigoPersonaEntidad,
                                                       prm_codEmpleado, prm_CodigoArguMoneda, prm_CodigoParte, prm_CondicionVenta,
                                                       prm_CondicionCompra, prm_Estado, prm_CodigoArguTipoDeOperacion, prm_RazonSocial, prm_DescripcionDetalle, prm_indInternacional);

                foreach (BEComprobanteEmision comprobanteEmision in listaComprobanteEmision)

                    if (comprobanteEmision.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_COMPRAS)
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

                if (CON_DETALLES)
                {
                    foreach (BEComprobanteEmision itemComprobanteEmision in listaComprobanteEmision)
                        itemComprobanteEmision.listaComprobanteEmisionDetalle = comprobanteEmisionDetalleData.List(itemComprobanteEmision.codDocumReg, string.Empty);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaComprobanteEmision;
        }
        public List<vwComprobanteEmision> ListEmision(Nullable<DateTime> prm_FechaDeEmisionInicio, Nullable<DateTime> prm_FechaDeEmisionFinal, string prm_CodigoPersonaEmpre,
                                                string prm_CodigoPuntoVenta, string prm_CodigoComprobante, string prm_CodigoArguEstadoDocu,
                                                string prm_CodigoArguDestinoComp, string prm_CodigoPersonaEntidad, int? prm_codEmpleado,
                                                string prm_CodigoArguMoneda, string prm_CodigoParte, int? prm_CondicionVenta, int? prm_CondicionCompra,
                                                bool prm_Estado, string prm_CodigoArguTipoDeOperacion, string prm_RazonSocial,
                                                string prm_DescripcionDetalle, bool? prm_indInternacional)
        {
            List<vwComprobanteEmision> lstComprobanteEmision = new List<vwComprobanteEmision>();
            try
            {
                lstComprobanteEmision = comprobanteEmisionData.ListEmision(HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionInicio), HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionFinal), prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta,
                                                       prm_CodigoComprobante, prm_CodigoArguEstadoDocu, prm_CodigoArguDestinoComp, prm_CodigoPersonaEntidad, prm_codEmpleado
                                                        , prm_CodigoArguMoneda, prm_CodigoParte, prm_CondicionVenta,
                                                       prm_CondicionCompra, prm_Estado, prm_CodigoArguTipoDeOperacion, prm_RazonSocial, prm_DescripcionDetalle, prm_indInternacional);

                foreach (vwComprobanteEmision comprobanteEmision in lstComprobanteEmision)

                    if (comprobanteEmision.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_COMPRAS)
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
                throw ex;
            }
            return lstComprobanteEmision;
        }
        public List<BECuentaCorriente> ListCuentasCorrientes(Nullable<DateTime> prm_FechaDeEmisionDeudaINI, Nullable<DateTime> prm_FechaDeEmisionDeudaFIN, string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, string prm_CodigoPersonaEntidad, string prm_CodigoComprobante, string prm_NumeroComprobante, string prm_CodigoArguDestinoComp, bool prm_Estado)
        {
            List<BECuentaCorriente> lstCuentasCorriente = new List<BECuentaCorriente>();
            try
            {
                CuentasCorrientesData cuentasCorrientesData = new CuentasCorrientesData();
                lstCuentasCorriente = cuentasCorrientesData.ListConCuadre(HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionDeudaINI), HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionDeudaFIN), prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta, prm_CodigoPersonaEntidad, prm_CodigoComprobante, prm_NumeroComprobante, prm_CodigoArguDestinoComp, prm_Estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCuentasCorriente;
        }
        public List<BEComprobanteEmision> ListarDocumentosParaPDT(Nullable<DateTime> prm_FechaDeEmisionInicio, Nullable<DateTime> prm_FechaDeEmisionFinal, string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, string prm_CodigoComprobante, string prm_NumeroComprobante, string prm_CodigoArguEstadoDocu, string prm_CodigoArguDestinoComp, string prm_CodigoPersonaEntidad, string prm_CodigoArguMoneda, bool? prm_LogicoDeclarado, string prm_perTributario)
        {
            List<BEComprobanteEmision> lstComprobanteEmision = new List<BEComprobanteEmision>();
            try
            {

                lstComprobanteEmision = comprobanteEmisionData.ListDocumentosParaPDT(new BaseFiltro { fecInicio = HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionInicio), fecFinal = HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionFinal), codPerEmpresa = prm_CodigoPersonaEmpre, codPuntoVenta = prm_CodigoPuntoVenta, codPerEntidad = prm_CodigoPersonaEntidad, codDocumento = prm_CodigoComprobante, numDocumento = prm_NumeroComprobante, codRegEstado = prm_CodigoArguEstadoDocu, codRegDestinoDocum = prm_CodigoArguDestinoComp, codRegMoneda = prm_CodigoArguMoneda, indLogicoFiltro = prm_LogicoDeclarado, perTributario = prm_perTributario });
                foreach (BEComprobanteEmision comprobanteEmision in lstComprobanteEmision)
                    if (comprobanteEmision.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_COMPRAS)
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
                throw ex;
            }
            return lstComprobanteEmision;
        }
        public List<BEComprobanteEmision> ListarDocumentosParaPDT(Nullable<DateTime> prm_FechaDeEmisionInicio, Nullable<DateTime> prm_FechaDeEmisionFinal, string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, string prm_CodigoComprobante, string prm_NumeroComprobante, string prm_CodigoArguEstadoDocu, string prm_CodigoArguDestinoComp, string prm_CodigoPersonaEntidad, string prm_CodigoArguMoneda, bool? prm_LogicoDeclarado, string prm_perTributario, bool prm_PorPeriodo)
        {
            List<BEComprobanteEmision> lstComprobanteEmision = new List<BEComprobanteEmision>();
            try
            {

                if (prm_PorPeriodo)
                    lstComprobanteEmision = comprobanteEmisionData.ListDocumentosParaPDTperTributario(prm_perTributario, prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta, prm_CodigoPersonaEntidad, prm_CodigoComprobante, prm_NumeroComprobante, prm_CodigoArguEstadoDocu, prm_CodigoArguDestinoComp, prm_CodigoArguMoneda, prm_LogicoDeclarado);
                else
                    lstComprobanteEmision = comprobanteEmisionData.ListDocumentosParaPDTfecDeclaracion(HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionInicio), HelpTime.ConvertYYYYMMDD(prm_FechaDeEmisionFinal), prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta, prm_CodigoPersonaEntidad, prm_CodigoComprobante, prm_NumeroComprobante, prm_CodigoArguEstadoDocu, prm_CodigoArguDestinoComp, prm_CodigoArguMoneda, prm_LogicoDeclarado);
                foreach (BEComprobanteEmision comprobanteEmision in lstComprobanteEmision)
                    if (comprobanteEmision.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_COMPRAS)
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
                throw ex;
            }
            return lstComprobanteEmision;
        }
        public List<BEComprobanteEmisionDetalle> ListProductoComercializado(BaseFiltro filtro)
        {
            List<BEComprobanteEmisionDetalle> lstComprobanteEmisionDetalle = new List<BEComprobanteEmisionDetalle>();
            try
            {
                lstComprobanteEmisionDetalle = comprobanteEmisionDetalleData.ListProductoComercializado(filtro);
            }
            catch (Exception ex)
            {
                throw ex;
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
        public BEComprobanteEmision FindcodDocumReg(int prm_codDocumReg)
        {
            BEComprobanteEmision comprobanteEmision = new BEComprobanteEmision();
            BEDocumento comprobantes = new BEDocumento();
            try
            {
                comprobanteEmision = comprobanteEmisionData.Find(prm_codDocumReg);
                if (comprobanteEmision.CodigoComprobante != null)
                    comprobantes = comprobantesData.Find(comprobanteEmision.CodigoComprobante);

                CajaRegistroLogic oCajaRegistroData = new CajaRegistroLogic();
                comprobanteEmision.listaCajaRegistro = oCajaRegistroData.List(null, null, prm_codDocumReg, string.Empty, 
                                                        string.Empty, null, string.Empty, string.Empty, string.Empty, null);

                decimal tipoCambioVenta = comprobanteEmision.ValorTipoCambioVTA;
                if (comprobanteEmision.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_VENTAS)
                    tipoCambioVenta = comprobanteEmision.ValorTipoCambioVTA;
                else if (comprobanteEmision.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_COMPRAS)
                    tipoCambioVenta = comprobanteEmision.ValorTipoCambioVTA;

                comprobanteEmision.listaComprobanteEmisionDetalle = comprobanteEmisionDetalleData.List(prm_codDocumReg, 
                                                                    string.Empty);
                foreach (BEComprobanteEmisionDetalle itemDetalle in comprobanteEmision.listaComprobanteEmisionDetalle)
                {
                    itemDetalle.refCodigoArguMoneda = comprobanteEmision.CodigoArguMoneda;

                    if (comprobantes.IncidenciaEnStocks == 0)
                        itemDetalle.listaProductoSeriados = productoSeriadosData.List(new BaseFiltroAlmacen
                        {
                            codPerEmpresa = comprobanteEmision.CodigoPersonaEmpre,
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
                        itemDetalle.listaProductoSeriados = productoSeriadosData.List(new BaseFiltroAlmacen
                        {
                            codPerEmpresa = comprobanteEmision.CodigoPersonaEmpre,
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
                        itemDetalle.listaProductoSeriados = productoSeriadosData.List(new BaseFiltroAlmacen
                        {
                            codPerEmpresa = comprobanteEmision.CodigoPersonaEmpre,
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
                comprobanteEmision.listaComprobanteEmisionImpuestos = comprobanteEmisionImpuestosData.List(prm_codDocumReg);
                comprobanteEmision = VerificarTiposDeCambioAlSeleccionarDetalle(comprobanteEmision, tipoCambioVenta, 
                                                                                comprobanteEmision.ValorIGV);
                comprobanteEmision.listaComprobanteEmisionImpuestos = VerificarTiposDeImpuestoAlSeleccionar(
                                                                      comprobanteEmision.listaComprobanteEmisionImpuestos,
                                                                      tipoCambioVenta, comprobanteEmision.CodigoArguMoneda);
                string strcodAtribNUM_TELEF = ConfigCROM.AppConfig(ConfigTool.DEFAULT_Telefono1Persona);
                string strcodAtribCTA_EMAIL = ConfigCROM.AppConfig(ConfigTool.DEFAULT_EmailPersona);

                if (comprobanteEmision.CodigoPersonaEntidadContacto != null)
                {
                    BEPersona personaContacto = new BEPersona();
                    PersonasLogic oPersonasLogic = new PersonasLogic();
                    personaContacto = oPersonasLogic.Find(comprobanteEmision.CodigoPersonaEntidadContacto);
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
                    PersonasLogic personasLogic = new PersonasLogic();
                    EmpleadoLogic empleadoLogic = new EmpleadoLogic();
                    EmpleadoAux empleado = new EmpleadoAux();
                    empleado = empleadoLogic.Find(comprobanteEmision.codEmpleadoVendedor.Value);
                    personaVendedor = personasLogic.Find(empleado.codPersonaNatural);
                    comprobanteEmision.REF_CodigoPersonaVendedorArea = personaVendedor.itemPersonasDatosAdicionales.CodigoArguAreaEmpleadoNombre;
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
                                                            comprobanteEmision.CodigoArguMoneda, string.Empty, 1);
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
                comprobanteEmision.listaCuentasCorrientes = cuentasCorrientesData.List(string.Empty, string.Empty, 
                                                                                       comprobanteEmision.CodigoPersonaEmpre, 
                                                                                       comprobanteEmision.CodigoPuntoVenta, 
                                                                                       comprobanteEmision.CodigoPersonaEntidad, 
                                                                                       comprobanteEmision.CodigoComprobante, 
                                                                                       comprobanteEmision.NumeroComprobante, 
                                                                                       string.Empty, 
                                                                                       true);
                List<LetraDeCambioAux> lstLetraCambio = new List<LetraDeCambioAux>();
                List<LetraDeCambioAux> lstLetraCambioLC = new List<LetraDeCambioAux>();
                lstLetraCambio = new LetraDeCambioLogic().List(prm_codDocumReg);
                foreach (LetraDeCambioAux letraDeCambio in lstLetraCambio)
                    lstLetraCambioLC.Add(letraDeCambio);

                comprobanteEmision.listaLetraDeCambio = lstLetraCambioLC;
                comprobanteEmision.listaGastoDeAduana = gastoDeAduanaData.List(string.Empty, string.Empty, 
                                                                               comprobanteEmision.CodigoPersonaEmpre, 
                                                                               comprobanteEmision.CodigoPuntoVenta, 
                                                                               string.Empty, 
                                                                               comprobanteEmision.CodigoComprobante, 
                                                                               comprobanteEmision.NumeroComprobante, 
                                                                               string.Empty, 
                                                                               null);

                /*Rutina para sacar el dato de Abonar en Cuenta de Banco*/
                List<BECuentaBancaria> lstcuentaBancaria = new List<BECuentaBancaria>();
                lstcuentaBancaria = new CuentaBancariaLogic().List(new BECuentaBancaria
                {
                    codPersonaEmpresa = comprobanteEmision.CodigoPersonaEmpre,
                    codRegMoneda = comprobanteEmision.CodigoArguMoneda,
                    indActivo = true
                });
                if (lstcuentaBancaria.Count > 0)
                {
                    comprobanteEmision.auxCuentaBancariaPago = "Abonar en CTA "
                        + lstcuentaBancaria[0].auxcodPersonaBanco + " : "
                        + lstcuentaBancaria[0].desNumeroCuenta + " - "
                        + lstcuentaBancaria[0].auxcodRegMoneda;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return comprobanteEmision;
        }
        public BEComprobanteEmision FindcodDocumRegPrint(int prm_codDocumReg)
        {
            BEComprobanteEmision comprobanteEmision = new BEComprobanteEmision();
            BEDocumento comprobantes = new BEDocumento();
            try
            {
                comprobanteEmision = comprobanteEmisionData.FindPrint(prm_codDocumReg);
                if (comprobanteEmision.CodigoComprobante != null)
                    comprobantes = comprobantesData.Find(comprobanteEmision.CodigoComprobante);

                double numeroDias = HelpTime.CantidadDias(comprobanteEmision.FechaDeEmision,
                                                          comprobanteEmision.FechaDeVencimiento.Value,
                                                          HelpTime.TotalTiempo.Dias);

                if (numeroDias > 0)
                    if (comprobanteEmision.codCondicionCompra == Convert.ToInt32(ConfigCROM.AppConfig(ConfigTool.DEFAULT_CondicionCompra)) ||
                        comprobanteEmision.codCondicionVenta == Convert.ToInt32(ConfigCROM.AppConfig(ConfigTool.DEFAULT_CondicionVenta)))
                        if (ConfigCROM.AppConfig(ConfigTool.DEFAULT_ConcatenaNumDias).ToLower() ==
                            Helper.ValorSiNo.S.ToString().ToLower())
                            comprobanteEmision.CondicionVentaNombre = comprobanteEmision.CondicionVentaNombre + " : " +
                                                                      numeroDias.ToString() + " DÍAS";

                CajaRegistroLogic oCajaRegistroData = new CajaRegistroLogic();
                comprobanteEmision.listaCajaRegistro = oCajaRegistroData.List(null, null, prm_codDocumReg, string.Empty, 
                                                                              string.Empty, null, string.Empty, string.Empty, 
                                                                              string.Empty, null);

                decimal tipoCambioVenta = comprobanteEmision.ValorTipoCambioVTA;
                if (comprobanteEmision.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_VENTAS)
                    tipoCambioVenta = comprobanteEmision.ValorTipoCambioVTA;
                else if (comprobanteEmision.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_COMPRAS)
                    tipoCambioVenta = comprobanteEmision.ValorTipoCambioVTA;

                comprobanteEmision.listaComprobanteEmisionDetalle = comprobanteEmisionDetalleData.List(prm_codDocumReg, string.Empty);
                foreach (BEComprobanteEmisionDetalle itemDetalle in comprobanteEmision.listaComprobanteEmisionDetalle)
                {
                    itemDetalle.refCodigoArguMoneda = comprobanteEmision.CodigoArguMoneda;

                    if (comprobantes.IncidenciaEnStocks == 0)
                        itemDetalle.listaProductoSeriados = productoSeriadosData.List(new BaseFiltroAlmacen
                        {
                            codPerEmpresa = comprobanteEmision.CodigoPersonaEmpre,
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
                        itemDetalle.listaProductoSeriados = productoSeriadosData.List(new BaseFiltroAlmacen
                        {
                            codPerEmpresa = comprobanteEmision.CodigoPersonaEmpre,
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
                        itemDetalle.listaProductoSeriados = productoSeriadosData.List(new BaseFiltroAlmacen
                        {
                            codPerEmpresa = comprobanteEmision.CodigoPersonaEmpre,
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
                comprobanteEmision.listaComprobanteEmisionImpuestos = comprobanteEmisionImpuestosData.List(prm_codDocumReg);
                comprobanteEmision = VerificarTiposDeCambioAlSeleccionarDetalle(comprobanteEmision, tipoCambioVenta, 
                                                                                comprobanteEmision.ValorIGV);

                comprobanteEmision.listaComprobanteEmisionImpuestos = VerificarTiposDeImpuestoAlSeleccionar(
                                                                        comprobanteEmision.listaComprobanteEmisionImpuestos, 
                                                                        tipoCambioVenta, 
                                                                        comprobanteEmision.CodigoArguMoneda);

                string strcodAtribNUM_TELEF = ConfigCROM.AppConfig(ConfigTool.DEFAULT_Telefono1Persona);
                string strcodAtribCTA_EMAIL = ConfigCROM.AppConfig(ConfigTool.DEFAULT_EmailPersona);

                if (comprobanteEmision.CodigoPersonaEntidadContacto != null)
                {
                    BEPersona personaContacto = new BEPersona();
                    PersonasLogic oPersonasLogic = new PersonasLogic();
                    personaContacto = oPersonasLogic.Find(comprobanteEmision.CodigoPersonaEntidadContacto);
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
                    BEPersona personaVendedor = new BEPersona();
                    PersonasLogic personasLogic = new PersonasLogic();
                    EmpleadoLogic empleadoLogic = new EmpleadoLogic();
                    EmpleadoAux empleado = new EmpleadoAux();
                    empleado = empleadoLogic.Find(comprobanteEmision.codEmpleadoVendedor.Value);
                    personaVendedor = personasLogic.Find(empleado.codPersonaNatural);
                    comprobanteEmision.REF_CodigoPersonaVendedorArea = personaVendedor.itemPersonasDatosAdicionales.CodigoArguAreaEmpleadoNombre;
                    foreach (BEPersonaAtributo item in personaVendedor.listaPersonasAtributos)
                    {
                        if (item.CodigoArguTipoAtributo == strcodAtribNUM_TELEF) // -"PATRB002001" telefono fijo 01
                            comprobanteEmision.REF_CodigoPersonaVendedorTelefono = item.DescripcionAtributo;
                        if (item.CodigoArguTipoAtributo == strcodAtribCTA_EMAIL ) // -"PATRB004001" correo electronico fijo 01
                            comprobanteEmision.REF_CodigoPersonaVendedorEmail = item.DescripcionAtributo;
                    }
                }

                if (comprobanteEmision.CodigoArguMoneda != null)
                {
                    MaestroLogic oMaestroLogic = new MaestroLogic();
                    List<BERegistro> lstMonedas = new List<BERegistro>();
                    lstMonedas = oMaestroLogic.ListDetalle(MaestroLogic.FiltroDetalle.PorCodigoArgumento, 
                                                           comprobanteEmision.CodigoArguMoneda.Substring(0, 5), 
                                                           comprobanteEmision.CodigoArguMoneda, string.Empty, 1);
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
                comprobanteEmision.listaCuentasCorrientes = cuentasCorrientesData.List(string.Empty, string.Empty, 
                                                                                       comprobanteEmision.CodigoPersonaEmpre, 
                                                                                       comprobanteEmision.CodigoPuntoVenta, 
                                                                                       comprobanteEmision.CodigoPersonaEntidad, 
                                                                                       comprobanteEmision.CodigoComprobante, 
                                                                                       comprobanteEmision.NumeroComprobante, 
                                                                                       string.Empty, true);

                List<LetraDeCambioAux> lstLetraCambio = new List<LetraDeCambioAux>();
                List<LetraDeCambioAux> lstLetraCambioLC = new List<LetraDeCambioAux>();
                lstLetraCambio = new LetraDeCambioLogic().List(prm_codDocumReg);
                foreach (LetraDeCambioAux letraDeCambio in lstLetraCambio)
                    //if (letraDeCambio.numMovimiento.Substring(0, 4) != "DOCU")
                        lstLetraCambioLC.Add(letraDeCambio);
                comprobanteEmision.listaLetraDeCambio = lstLetraCambioLC;
                comprobanteEmision.listaGastoDeAduana = gastoDeAduanaData.List(string.Empty, string.Empty, 
                                                                               comprobanteEmision.CodigoPersonaEmpre, 
                                                                               comprobanteEmision.CodigoPuntoVenta, 
                                                                               string.Empty, comprobanteEmision.CodigoComprobante, 
                                                                               comprobanteEmision.NumeroComprobante, 
                                                                               string.Empty, null);

                /*Rutina para sacar el dato de Abonar en Cuenta de Banco*/
                List<BECuentaBancaria> lstcuentaBancaria = new List<BECuentaBancaria>();
                lstcuentaBancaria = new CuentaBancariaLogic().List(new BECuentaBancaria
                {
                    codPersonaEmpresa = comprobanteEmision.CodigoPersonaEmpre,
                    codRegMoneda = comprobanteEmision.CodigoArguMoneda,
                    indActivo = true
                });
                if (lstcuentaBancaria.Count > 0)
                {
                    comprobanteEmision.auxCuentaBancariaPago = "Abonar en CTA "
                        + lstcuentaBancaria[0].auxcodPersonaBanco + " : "
                        + lstcuentaBancaria[0].desNumeroCuenta + " - "
                        + lstcuentaBancaria[0].auxcodRegMoneda;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return comprobanteEmision;
        }
        public BEComprobanteEmision FindUnique(string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, 
                                             string prm_CodigoComprobante, string prm_NumeroComprobante)
        {
            BEComprobanteEmision comprobanteEmision = new BEComprobanteEmision();
            BEDocumento comprobante = new BEDocumento();
            try
            {
                comprobanteEmision = comprobanteEmisionData.FindUnique(prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta, 
                                                                       prm_CodigoComprobante, prm_NumeroComprobante);
                int prm_codDocumReg = comprobanteEmision.codDocumReg;
                if (comprobanteEmision.CodigoComprobante != null)
                    comprobante = comprobantesData.Find(comprobanteEmision.CodigoComprobante);

                CajaRegistroLogic cajaRegistroData = new CajaRegistroLogic();
                comprobanteEmision.listaCajaRegistro = cajaRegistroData.List(null, null, prm_codDocumReg, string.Empty, 
                                                                             string.Empty, null, string.Empty, 
                                                                             string.Empty, string.Empty, null);

                decimal decTipoDecambioVenta = comprobanteEmision.ValorTipoCambioVTA;
                if (comprobanteEmision.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_VENTAS)
                    decTipoDecambioVenta = comprobanteEmision.ValorTipoCambioVTA;
                else if (comprobanteEmision.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_COMPRAS)
                    decTipoDecambioVenta = comprobanteEmision.ValorTipoCambioVTA;

                comprobanteEmision.listaComprobanteEmisionDetalle = comprobanteEmisionDetalleData.List(prm_codDocumReg, string.Empty);
                foreach (BEComprobanteEmisionDetalle itemDetalle in comprobanteEmision.listaComprobanteEmisionDetalle)
                {
                    itemDetalle.refCodigoArguMoneda = comprobanteEmision.CodigoArguMoneda;

                    if (comprobante.IncidenciaEnStocks == 0)
                        itemDetalle.listaProductoSeriados = productoSeriadosData.List(new BaseFiltroAlmacen
                        {
                            codPerEmpresa = comprobanteEmision.CodigoPersonaEmpre,
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
                        itemDetalle.listaProductoSeriados = productoSeriadosData.List(new BaseFiltroAlmacen
                        {
                            codPerEmpresa = comprobanteEmision.CodigoPersonaEmpre,
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
                        itemDetalle.listaProductoSeriados = productoSeriadosData.List(new BaseFiltroAlmacen
                        {
                            codPerEmpresa = comprobanteEmision.CodigoPersonaEmpre,
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
                comprobanteEmision.listaComprobanteEmisionImpuestos = comprobanteEmisionImpuestosData.List(prm_codDocumReg);
                comprobanteEmision = VerificarTiposDeCambioAlSeleccionarDetalle(comprobanteEmision, decTipoDecambioVenta, 
                                                                                comprobanteEmision.ValorIGV);

                comprobanteEmision.listaComprobanteEmisionImpuestos = VerificarTiposDeImpuestoAlSeleccionar(
                                                                        comprobanteEmision.listaComprobanteEmisionImpuestos, 
                                                                        decTipoDecambioVenta, 
                                                                        comprobanteEmision.CodigoArguMoneda);

                string strcodAtribNUM_TELEF = ConfigCROM.AppConfig(ConfigTool.DEFAULT_Telefono1Persona);
                string strcodAtribCTA_EMAIL = ConfigCROM.AppConfig(ConfigTool.DEFAULT_EmailPersona);

                if (comprobanteEmision.CodigoPersonaEntidadContacto != null)
                {
                    BEPersona personaContacto = new BEPersona();
                    PersonasLogic oPersonasLogic = new PersonasLogic();
                    personaContacto = oPersonasLogic.Find(comprobanteEmision.CodigoPersonaEntidadContacto);
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
                    PersonasLogic oPersonasLogic = new PersonasLogic();
                    EmpleadoLogic empleadoLogic = new EmpleadoLogic();
                    EmpleadoAux empleado = new EmpleadoAux();
                    
                    empleado = empleadoLogic.Find(comprobanteEmision.codEmpleadoVendedor.Value);
                    personaVendedor = oPersonasLogic.Find(empleado.codPersonaNatural);
                    comprobanteEmision.REF_CodigoPersonaVendedorArea = personaVendedor.itemPersonasDatosAdicionales.CodigoArguAreaEmpleadoNombre;
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
                                                        comprobanteEmision.CodigoArguMoneda, string.Empty, 1);
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
                comprobanteEmision.listaCuentasCorrientes = cuentasCorrientesData.List(string.Empty, string.Empty, 
                                                                                       comprobanteEmision.CodigoPersonaEmpre, 
                                                                                       comprobanteEmision.CodigoPuntoVenta, 
                                                                                       comprobanteEmision.CodigoPersonaEntidad, 
                                                                                       comprobanteEmision.CodigoComprobante, 
                                                                                       comprobanteEmision.NumeroComprobante, 
                                                                                       string.Empty, true);
                List<LetraDeCambioAux> lstLetraCambio = new List<LetraDeCambioAux>();
                List<LetraDeCambioAux> lstLetraCambioLC = new List<LetraDeCambioAux>();
                lstLetraCambio = new LetraDeCambioLogic().List(prm_codDocumReg);
                foreach (LetraDeCambioAux xLC in lstLetraCambio)
                    //if (xLC.numMovimiento.Substring(0, 4) != "DOCU")
                        lstLetraCambioLC.Add(xLC);
                comprobanteEmision.listaLetraDeCambio = lstLetraCambioLC;
                comprobanteEmision.listaGastoDeAduana = gastoDeAduanaData.List(string.Empty, string.Empty, 
                                                                               comprobanteEmision.CodigoPersonaEmpre,
                                                                               comprobanteEmision.CodigoPuntoVenta, 
                                                                               string.Empty, comprobanteEmision.CodigoComprobante, 
                                                                               comprobanteEmision.NumeroComprobante, 
                                                                               string.Empty, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return comprobanteEmision;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ComprobanteEmision
        /// En la BASE de DATO la Tabla : [GestionComercial.ComprobanteEmision]
        /// <summary>
        /// <param name="comprobanteEmision"></param>
        /// <param name="comprobante"></param>
        /// <param name="strCodigoTalonario"></param>
        /// <returns></returns>
        public ReturnValor Insert(BEComprobanteEmision comprobanteEmision, BEDocumento comprobante, string strCodigoTalonario)
        {
            ReturnValor intReturnValor = new ReturnValor();
            try
            {
                using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required))
                {
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

                    ComprobanteEmisionData oiComprobanteEmisionData = new ComprobanteEmisionData();
                    VerificarTotalesComprobanteAlGuardar(comprobanteEmision, comprobanteEmision.ValorTipoCambioVTA, comprobanteEmision.CodigoArguMoneda);
                    returnValor.codRetorno = oiComprobanteEmisionData.Insert(comprobanteEmision);
                    returnValor.Exitosa = true;
                    comprobanteEmision.codDocumReg = returnValor.codRetorno;
                    intReturnValor = AgregarTodaReferenciaComprobanteEmision(comprobanteEmision, comprobante);
                    bool SUCEDE_REGIS_TALONARIO = true;
                    BEDocumentoSerie objComprobantesSeriesUpdate = new BEDocumentoSerie
                    {
                        CodigoTalonario = strCodigoTalonario,
                        segUsuarioEdita = comprobanteEmision.SegUsuarioCrea,
                        segMaquinaEdita = "UserEmision"
                    };
                    SUCEDE_REGIS_TALONARIO = comprobantesSeriesData.UpdateUltimo(objComprobantesSeriesUpdate);

                    if (returnValor.Exitosa && intReturnValor.Exitosa && SUCEDE_REGIS_TALONARIO)
                    {
                        auditoriaSistemaLogic.Insert(new BEAuditoriaSistema { Clase = this.GetType().FullName, Descripcion = comprobanteEmision.NumeroComprobante, CodigoPersonaEmpre = comprobanteEmision.CodigoPersonaEmpre, CodigoPuntoVenta = comprobanteEmision.CodigoPuntoVenta, SegUsuarioCrea = comprobanteEmision.SegUsuarioCrea, ProcesoOK = true, CodigoPersonaRespon = comprobanteEmision.codEmpleado.ToString(), Metodo = this.GetType().ToString(), OtroDato = "xx" });
                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                        transactionScope.Complete();
                    }
                    else
                    {
                        returnValor.Message = (returnValor.Message == null ? string.Empty : returnValor.Message) + " " + (intReturnValor.Message == null ? string.Empty : intReturnValor.Message);
                        returnValor.Exitosa = false;
                    }
                }
            }
            catch (Exception ex)
            {
                comprobanteEmision.codDocumReg = 0;
                auditoriaSistemaLogic.Insert(new BEAuditoriaSistema { Clase = this.GetType().FullName, Descripcion = ex.Message, CodigoPersonaEmpre = comprobanteEmision.CodigoPersonaEmpre, CodigoPuntoVenta = comprobanteEmision.CodigoPuntoVenta, SegUsuarioCrea = comprobanteEmision.SegUsuarioCrea, ProcesoOK = false, CodigoPersonaRespon = comprobanteEmision.codEmpleado.ToString(), Metodo = this.GetType().Name, OtroDato = "xx" });
                returnValor.Exitosa = false;
                returnValor.Message = ex.Message + " - " + intReturnValor.Message;
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
                    comprobanteEmisionAnterior = FindcodDocumReg(comprobanteEmision.codDocumReg);
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
                        ooReturnValor = EliminarTodaReferenciaComprobanteEmision(comprobanteEmisionAnterior, comprobante);

                        //--- Inserción de los nuevos ITEM del detalle del documento
                        comprobanteEmision.codEmpleadoVendedor = comprobanteEmision.listaComprobanteEmisionDetalle[0].codEmpleadoVendedor;

                        ReturnValor xIntReturnValor = new ReturnValor();
                        comprobanteEmision.listaLetraDeCambio = comprobanteEmisionAnterior.listaLetraDeCambio;
                        xIntReturnValor = AgregarTodaReferenciaComprobanteEmision(comprobanteEmision, comprobante);

                        if (returnValor.Exitosa && ooReturnValor.Exitosa && xIntReturnValor.Exitosa)
                        {
                            auditoriaSistemaLogic.Insert(new BEAuditoriaSistema { Clase = this.GetType().FullName, Descripcion = comprobanteEmision.NumeroComprobante, CodigoPersonaEmpre = comprobanteEmision.CodigoPersonaEmpre, CodigoPuntoVenta = comprobanteEmision.CodigoPuntoVenta, SegUsuarioCrea = comprobanteEmision.SegUsuarioCrea, ProcesoOK = true, CodigoPersonaRespon = comprobanteEmision.codEmpleado.ToString(), Metodo = this.GetType().ToString(), OtroDato = "xx" });
                            returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                            tx.Complete();
                        }
                        else
                        {
                            returnValor.Exitosa = false;
                            returnValor.Message = "Actaliza: " + returnValor.Message + " ElimREFER: " + ooReturnValor.Message + " AgreREFER: " + xIntReturnValor.Message;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                auditoriaSistemaLogic.Insert(new BEAuditoriaSistema { Clase = this.GetType().FullName, Descripcion = ex.Message, CodigoPersonaEmpre = comprobanteEmision.CodigoPersonaEmpre, CodigoPuntoVenta = comprobanteEmision.CodigoPuntoVenta, SegUsuarioCrea = comprobanteEmision.SegUsuarioCrea, ProcesoOK = false, CodigoPersonaRespon = comprobanteEmision.codEmpleado.ToString(), Metodo = this.GetType().Name, OtroDato = "xx" });
                returnValor.Exitosa = false;
                returnValor.Message = ex.Message;
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
                        bool SUCEDE_ANULACION = true;
                        SUCEDE_ANULACION = comprobanteEmisionData.UpdateAnulacion(comprobanteEmision.codDocumReg, comprobante.CodigoArguEstANUDefault, comprobanteEmision.CodigoArguAnulacion, comprobanteEmision.Observaciones, comprobanteEmision.FechaDeAnulacion.Value, comprobanteEmision.SegUsuarioEdita);
                        returnValor = EliminarTodaReferenciaComprobanteEmision(comprobanteEmision, comprobante);

                        if (returnValor.Exitosa && SUCEDE_ANULACION)
                        {
                            returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                            transactionScope.Complete();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor.Exitosa = false;
                returnValor.Message = ex.Message;
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
                returnValor.Exitosa = false;
                returnValor.Message = ex.Message;
            }
            return returnValor;
        }
        public ReturnValor UpdateDocumentosParaPDT(List<BEComprobanteEmision> lstComprobanteEmision, BaseFiltro parametro)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    foreach (BEComprobanteEmision comprobanteEmision in lstComprobanteEmision)
                    {
                        parametro.codDocumReg = comprobanteEmision.codDocumReg;
                        parametro.codPerEntidad = comprobanteEmision.CodigoPersonaEntidad;
                        parametro.numDocumento = comprobanteEmision.NumeroComprobante;
                        parametro.codRegEstado = comprobanteEmision.CodigoArguEstadoDocu;
                        parametro.fecDeclaracion = comprobanteEmision.FechaDeDeclaracion;
                        parametro.indLogicoFiltro = comprobanteEmision.LogicoFiltro;
                        returnValor.Exitosa = comprobanteEmisionData.UpdateDocumentosParaPDT(parametro);
                    }

                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpMessages.Evento_EDIT;
                        tx.Complete();
                    }
                    else
                        returnValor.Message = HelpMessages.gc_DOCUM_NoRegistrado;
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return returnValor;
        }
        public ReturnValor UpdateArchivarDocumento(List<BEComprobanteEmision> lstComprobanteEmision)
        {
            try
            {

                BEDocumento comprobante = new DocumentoLogic().Find(lstComprobanteEmision[0].CodigoComprobante);

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
                                comprobanteEmision.CodigoArguEstadoDocu = ConfigCROM.AppConfig(ConfigTool.EST_COT_Archivado);
                            else if (comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString())
                                comprobanteEmision.CodigoArguEstadoDocu = ConfigCROM.AppConfig(ConfigTool.EST_GRE_Archivado);
                            else if (comprobante.Abreviatura == HelpDocumentos.Tipos.FCT.ToString())
                                comprobanteEmision.CodigoArguEstadoDocu = ConfigCROM.AppConfig(ConfigTool.EST_FAC_Archivado);
                            else if (comprobante.Abreviatura == HelpDocumentos.Tipos.BVT.ToString())
                                comprobanteEmision.CodigoArguEstadoDocu = ConfigCROM.AppConfig(ConfigTool.EST_BVT_Archivado);

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
                returnValor.Exitosa = false;
                returnValor.Message = ex.Message;
            }
            return returnValor;
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
        public ReturnValor UpdateDevolucion(BEComprobanteEmision comprobanteEmision, List<BEProductoSeriado> lstProductoSeriado)
        {
            ReturnValor returnValorDocumento = new ReturnValor();
            ReturnValor returnValorSeriados = new ReturnValor();
            ProductoLogic productoLogic = new ProductoLogic();

            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required))
            {
                // Actualiza el documento principal
                returnValorDocumento.Exitosa = comprobanteEmisionData.UpdateEmitidoDevolucion(comprobanteEmision);

                List<ProductoKardexAux> lstProductoKardex = new List<ProductoKardexAux>();
                lstProductoKardex = productoExistenciasKardexData.ListPorDocumento(new BaseFiltroAlmacen { codDocumReg = comprobanteEmision.codDocumReg });
                List<ProductoKardexAux> lstProductoKardexDevolucion = new List<ProductoKardexAux>();
                ProductoKardexAux productoKardexDevolucion = null;
                foreach (ProductoKardexAux productoKardex in lstProductoKardex)
                {
                    productoKardexDevolucion = LllenarEntidadProductoKardexAux(comprobanteEmision, productoKardexDevolucion, productoKardex);
                    lstProductoKardexDevolucion.Add(productoKardexDevolucion);
                    productoExistenciasKardexData.Insert(productoKardexDevolucion);
                    decimal? SALDO_StockFisico = null;
                    productoExistenciasData.UpdateStockFisico(new BaseFiltroAlmacen
                    {
                        codProducto = productoKardex.codProducto,
                        codDeposito = comprobanteEmision.CodigoArguDepositoOrigen,
                        cntStockFisico = Math.Round((decimal)productoKardex.cntSalida, 3),
                        indOperador = 1,
                        segUsuarioEdita = productoKardex.segUsuarioCrea,
                    }, ref SALDO_StockFisico);
                    productoExistenciasData.UpdateStockComprometido(new BaseFiltroAlmacen
                    {
                        codProducto = productoKardex.codProducto,
                        codDeposito = comprobanteEmision.CodigoArguDepositoOrigen,
                        cntStockFisico = Math.Round((decimal)productoKardex.cntSalida, 3),
                        indOperador = -1,
                        segUsuarioEdita = productoKardex.segUsuarioCrea,
                        cntStockComprometido = Math.Round((decimal)productoKardex.cntSalida, 3)
                    }, ref SALDO_StockFisico);
                }

                returnValorSeriados = productoLogic.UpdateConsignacion(lstProductoSeriado);
                if (returnValorSeriados.Exitosa && returnValorDocumento.Exitosa)
                {
                    returnValorDocumento.Message = HelpMessages.gc_DOCUM_Devolucion_Producto;
                    transactionScope.Complete();
                }
            }

            return returnValorDocumento;
        }

        private static ProductoKardexAux LllenarEntidadProductoKardexAux(BEComprobanteEmision comprobanteEmision, ProductoKardexAux productoKardexDevolucion, ProductoKardexAux productoKardex)
        {
            productoKardexDevolucion = new ProductoKardexAux
            {
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

                        ReturnValor ooReturnValor = new ReturnValor();
                        ooReturnValor = EliminarTodaReferenciaComprobanteEmision(comprobanteEmision, comprobante);

                        bool SUCEDE_DOCUMENTO = true;
                        SUCEDE_DOCUMENTO = comprobanteEmisionData.Delete(comprobanteEmision.codDocumReg);

                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        tx.Complete();

                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            return returnValor;
        }

        #endregion

        #region Métodos Privados

        private BEComprobanteEmision VerificarTotalesComprobanteAlGuardar(BEComprobanteEmision comprobanteEmision, decimal decTipoDeCambio, string strCodRegMoneda)
        {
            int CANTIDAD_DECIMALES = Convert.ToInt32(ConfigCROM.AppConfig(ConfigTool.DEFAULT_CantidadDecimals));

            if (strCodRegMoneda == ConfigCROM.AppConfig(ConfigTool.DEFAULT_MonedaInt))
            {
                comprobanteEmision.ValorTotalBruto = Helper.DecimalRound(comprobanteEmision.ValorTotalBruto * decTipoDeCambio, CANTIDAD_DECIMALES);
                comprobanteEmision.ValorTotalDescuento = Helper.DecimalRound(comprobanteEmision.ValorTotalDescuento * decTipoDeCambio, CANTIDAD_DECIMALES);
                comprobanteEmision.ValorTotalPrecioVenta = Helper.DecimalRound(comprobanteEmision.ValorTotalPrecioVenta * decTipoDeCambio, CANTIDAD_DECIMALES);
                comprobanteEmision.ValorTotalVenta = Helper.DecimalRound(comprobanteEmision.ValorTotalVenta * decTipoDeCambio, CANTIDAD_DECIMALES);
                comprobanteEmision.ValorTotalVentaGravada = Helper.DecimalRound(comprobanteEmision.ValorTotalVentaGravada * decTipoDeCambio, CANTIDAD_DECIMALES);
            }
            return comprobanteEmision;
        }
        private BEComprobanteEmision VerificarTotalesComprobanteAlSeleccionar(BEComprobanteEmision comprobanteEmision, decimal decTipoDeCambio, string strCodRegMoneda)
        {
            int z = 0;
            int CANTIDAD_DECIMALES = Convert.ToInt32(ConfigCROM.AppConfig(ConfigTool.DEFAULT_CantidadDecimals));

            if (strCodRegMoneda == ConfigCROM.AppConfig(ConfigTool.DEFAULT_MonedaInt))
            {
                comprobanteEmision.ValorTotalBruto = Helper.DecimalRound(comprobanteEmision.ValorTotalBruto / decTipoDeCambio, CANTIDAD_DECIMALES);
                comprobanteEmision.ValorTotalDescuento = Helper.DecimalRound(comprobanteEmision.ValorTotalDescuento / decTipoDeCambio, CANTIDAD_DECIMALES);
                comprobanteEmision.ValorTotalPrecioVenta = Helper.DecimalRound(comprobanteEmision.ValorTotalPrecioVenta / decTipoDeCambio, CANTIDAD_DECIMALES);
                comprobanteEmision.ValorTotalImpuesto = Helper.DecimalRound(comprobanteEmision.ValorTotalImpuesto / decTipoDeCambio, CANTIDAD_DECIMALES);
                comprobanteEmision.ValorTotalVenta = Helper.DecimalRound(comprobanteEmision.ValorTotalVenta / decTipoDeCambio, CANTIDAD_DECIMALES);
                comprobanteEmision.ValorTotalVentaGravada = Helper.DecimalRound(comprobanteEmision.ValorTotalVentaGravada / decTipoDeCambio, CANTIDAD_DECIMALES);
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
                if (comprobanteEmisionDetalle.refCodigoArguMoneda == ConfigCROM.AppConfig(ConfigTool.DEFAULT_MonedaInt))
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
            string strValor = ConfigCROM.AppConfig(ConfigTool.DEFAULT_Calc_IGV_Horiz);
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
                if (cajaRegistro.codRegistroMoneda == ConfigCROM.AppConfig(ConfigTool.DEFAULT_MonedaInt))
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
        private List<BEComprobanteEmisionDetalle> VerificarTiposDeCambioAlGuardarDetalle(List<BEComprobanteEmisionDetalle> lstComprobanteEmisionDetalle, decimal decTipoDeCambio, decimal decIGVSunat, bool prm_EsGravadoImpuesto)
        {
            int z = 0;
            int CANTIDAD_DECIMALES = Convert.ToInt32(ConfigCROM.AppConfig(ConfigTool.DEFAULT_CantidadDecimals));
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
                if (comprobanteEmisionDetalle.refCodigoArguMoneda == ConfigCROM.AppConfig(ConfigTool.DEFAULT_MonedaInt))
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
        private List<BEComprobanteEmisionImpuesto> VerificarTiposDeImpuestosAlGuardar(List<BEComprobanteEmisionImpuesto> listaImpuestos, decimal TIPO_CAMBIO, string CODIARGU_MONEDA, int pcodDocumReg)
        {
            int CANTIDAD_DECIMALES = Convert.ToInt32(ConfigCROM.AppConfig(ConfigTool.DEFAULT_CantidadDecimals));
            foreach (BEComprobanteEmisionImpuesto itemDetalle in listaImpuestos)
            {
                itemDetalle.codDocumReg = pcodDocumReg;
                if (CODIARGU_MONEDA == ConfigCROM.AppConfig(ConfigTool.DEFAULT_MonedaInt))
                    itemDetalle.ValorTotalImpuesto = Helper.DecimalRound(itemDetalle.ValorTotalImpuesto * TIPO_CAMBIO, CANTIDAD_DECIMALES);
            }
            return listaImpuestos;
        }
        private List<BEComprobanteEmisionImpuesto> VerificarTiposDeImpuestoAlSeleccionar(List<BEComprobanteEmisionImpuesto> listaImpuestos, decimal TIPO_CAMBIO, string CODIARGU_MONEDA)
        {
            int z = 0;
            int CANTIDAD_DECIMALES = Convert.ToInt32(ConfigCROM.AppConfig(ConfigTool.DEFAULT_CantidadDecimals));
            foreach (BEComprobanteEmisionImpuesto itemDetalle in listaImpuestos)
            {
                if (CODIARGU_MONEDA == ConfigCROM.AppConfig(ConfigTool.DEFAULT_MonedaInt))
                {
                    itemDetalle.ValorTotalImpuesto = Helper.DecimalRound(itemDetalle.ValorTotalImpuesto / TIPO_CAMBIO, CANTIDAD_DECIMALES);
                }
                ++z;
            }
            return listaImpuestos;
        }
        private List<BECuentaCorriente> CrearRegistrosDeCuentasCtes(BEComprobanteEmision comprobanteEmision)
        {
            List<BECuentaCorriente> lstCuentaCorriente = new List<BECuentaCorriente>();
            bool indSucedeVenta = comprobanteEmision.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_VENTAS ? true : false;
            if (indSucedeVenta)
            {
                BECondicion condicionVenta = new BECondicion();
                double numeroDias = HelpTime.CantidadDias(comprobanteEmision.FechaDeEmision,
                                                          comprobanteEmision.FechaDeVencimiento.Value,
                                                          HelpTime.TotalTiempo.Dias);
                condicionVenta = new CondicionLogic().Find(comprobanteEmision.codCondicionVenta.HasValue ?
                                                           comprobanteEmision.codCondicionVenta.Value : 0);
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
                                codDocumReg = comprobanteEmision.codDocumReg,
                                CodigoArguDestinoComp = comprobanteEmision.CodigoArguDestinoComp,
                                CodigoArguMoneda = comprobanteEmision.CodigoArguMoneda,
                                CodigoArguTipoDomicil = comprobanteEmision.CodigoArguTipoDomicil,
                                CodigoArguTipoMovimi = comprobanteEmision.CodigoArguTipoDeOperacion,
                                codEmpleado = comprobanteEmision.codEmpleado,
                                CodigoPersonaEntidad = comprobanteEmision.CodigoPersonaEntidad,
                                DEBETipoCambioVTA = comprobanteEmision.ValorTipoCambioVTA,
                                DEBETipoCambioCMP = comprobanteEmision.ValorTipoCambioCMP,
                                DEBETotalCuotaNacion = MontoDeCuota,
                                DEBETotalCuotaExtran = MontoDeCuota / comprobanteEmision.ValorTipoCambioVTA,
                                Estado = true,
                                FechaDeEmisionDeuda = comprobanteEmision.FechaDeEmision,
                                FechaDeVencimiento = comprobanteEmision.FechaDeEmision.AddDays((numeroDias==0?
                                                                                               Convert.ToDouble(ConfigCROM.AppConfig(ConfigTool.DEFAULT_MaxDiasCredito)):
                                                                                               numeroDias)* k),
                                NumeroDeCuota = k,
                                Observaciones = comprobanteEmision.Observaciones == null ? "Registro automático desde Emisión de venta - " : "Registro automático desde Emisión de venta - " + comprobanteEmision.Observaciones,
                                SegUsuarioCrea = comprobanteEmision.SegUsuarioCrea,
                                SegUsuarioEdita = comprobanteEmision.SegUsuarioCrea,
                                DHDiferenciaMonto = 0,
                                TipoDeIngreso = "D"

                            };
                            cuentaCorriente.CodigoArguTipoDomicil = string.IsNullOrEmpty(cuentaCorriente.CodigoArguTipoDomicil) ? ConfigCROM.AppConfig(ConfigTool.DEFAULT_Atributo_DomicFiscal) : cuentaCorriente.CodigoArguTipoDomicil;
                            lstCuentaCorriente.Add(cuentaCorriente);
                        }
                    }
                    else
                    {
                        cuentaCorriente = new BECuentaCorriente
                        {
                            codDocumReg = comprobanteEmision.codDocumReg,
                            CodigoArguDestinoComp = comprobanteEmision.CodigoArguDestinoComp,
                            CodigoArguMoneda = comprobanteEmision.CodigoArguMoneda,
                            CodigoArguTipoDomicil = comprobanteEmision.CodigoArguTipoDomicil,
                            CodigoArguTipoMovimi = comprobanteEmision.CodigoArguTipoDeOperacion,
                            codEmpleado = comprobanteEmision.codEmpleado,
                            DEBETipoCambioVTA = comprobanteEmision.ValorTipoCambioVTA,
                            DEBETipoCambioCMP = comprobanteEmision.ValorTipoCambioCMP,
                            DEBETotalCuotaNacion = comprobanteEmision.ValorTotalPrecioVenta,
                            DEBETotalCuotaExtran = comprobanteEmision.ValorTotalPrecioExtran,
                            Estado = true,
                            FechaDeEmisionDeuda = comprobanteEmision.FechaDeEmision,
                            FechaDeVencimiento = comprobanteEmision.FechaDeEmision.AddDays(Convert.ToDouble(ConfigCROM.AppConfig(ConfigTool.DEFAULT_MaxDiasCredito)) * 1),
                            NumeroDeCuota = 1,
                            Observaciones = comprobanteEmision.Observaciones == null ? "Registro automático desde Emisión de venta - " : "Registro automático desde Emisión de venta - " + comprobanteEmision.Observaciones,
                            SegUsuarioCrea = comprobanteEmision.SegUsuarioCrea,
                            SegUsuarioEdita = comprobanteEmision.SegUsuarioCrea,
                            CodigoPersonaEntidad = comprobanteEmision.CodigoPersonaEntidad,
                            TipoDeIngreso = "D",
                        };
                        lstCuentaCorriente.Add(cuentaCorriente);
                    }
                }
            }
            else
            {
                BECondicion condicionCompra = new BECondicion();
                condicionCompra = new CondicionLogic().Find(comprobanteEmision.codCondicionCompra.HasValue?
                                                            comprobanteEmision.codCondicionCompra.Value:0);

                if (condicionCompra.indEsGravaCtaCte)
                {
                    BECuentaCorriente cuentaCorriente;

                    cuentaCorriente = new BECuentaCorriente
                    {
                        codDocumReg = comprobanteEmision.codDocumReg,
                        CodigoArguDestinoComp = comprobanteEmision.CodigoArguDestinoComp,
                        CodigoArguMoneda = comprobanteEmision.CodigoArguMoneda,
                        CodigoArguTipoDomicil = comprobanteEmision.CodigoArguTipoDomicil,
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
                        Observaciones = comprobanteEmision.Observaciones == null ? "Registro automático desde registro de compra - " : "Registro automático desde registro de compra - " + comprobanteEmision.Observaciones,
                        SegUsuarioCrea = comprobanteEmision.SegUsuarioCrea,
                        SegUsuarioEdita = comprobanteEmision.SegUsuarioCrea,
                        CodigoPersonaEntidad = comprobanteEmision.CodigoPersonaEntidad,
                        TipoDeIngreso = "H",
                    };
                    lstCuentaCorriente.Add(cuentaCorriente);

                }
            }
            return lstCuentaCorriente;
        }
        private ReturnValor AgregarTodaReferenciaComprobanteEmision(BEComprobanteEmision comprobanteEmision, BEDocumento comprobante)
        {
            ReturnValor intReturnValor = new ReturnValor();
            ReturnValor returnValorDocumRegSerie = new ReturnValor();
            int sucesde_KARDEX = -1;
            bool SUCEDE_KARDEX = true, SUCEDE_DOC_REFER = true, SUCEDE_STOCKCM = true;
            int? SUCEDE_DETALLE = null;
            bool SUCEDE_UPDATE_STOCKS = true;
            decimal T_CAMBIO = comprobanteEmision.ValorTipoCambioVTA;
            try
            {
                using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (comprobanteEmision.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_VENTAS ||
                        comprobanteEmision.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_COMPRAS)
                        if (comprobanteEmision.DocEsFacturable || comprobante.EsComprobanteLocal)
                            cuentasCorrientesData.Insert(CrearRegistrosDeCuentasCtes(comprobanteEmision));

                    decimal? SALDO_StockFisico = null;
                    comprobanteEmisionImpuestosData.Insert(VerificarTiposDeImpuestosAlGuardar(comprobanteEmision.listaComprobanteEmisionImpuestos, T_CAMBIO, comprobanteEmision.CodigoArguMoneda, comprobanteEmision.codDocumReg));
                    ComprobanteEmisionDetalleData oiComprobanteEmisionDetalleData = new ComprobanteEmisionDetalleData();
                    ProductoExistenciasKardexData oiProductoExistenciasKardexData = new ProductoExistenciasKardexData();
                    foreach (BEComprobanteEmisionDetalle comprobanteEmisionDetalle in VerificarTiposDeCambioAlGuardarDetalle(comprobanteEmision.listaComprobanteEmisionDetalle, T_CAMBIO, comprobanteEmision.ValorIGV, comprobanteEmision.DocEsGravado))
                    {
                        comprobanteEmisionDetalle.codDocumReg = comprobanteEmision.codDocumReg;
                        comprobanteEmisionDetalle.SegUsuarioCrea = comprobanteEmision.SegUsuarioCrea;
                        comprobanteEmisionDetalle.UnitDescuento = comprobanteEmisionDetalle.UnitDescuento / 100;
                        SUCEDE_DETALLE = oiComprobanteEmisionDetalleData.Insert(comprobanteEmisionDetalle);
                        if (!SUCEDE_DETALLE.HasValue)
                            break;
                        if (ConfigCROM.AppConfig(ConfigTool.DEFAULT_TrabajaDeposito) == "S")
                        {
                            if (comprobanteEmisionDetalle.EsVerificarStock)
                            {
                                SUCEDE_UPDATE_STOCKS = true;
                                if (comprobante.IncidenciaEnStocks == -1)
                                    comprobanteEmisionDetalle.CodigoArguDepositoAlm = comprobanteEmision.CodigoArguDepositoOrigen;

                                if (comprobante.IncidenciaEnStocks == 1)
                                    comprobanteEmisionDetalle.CodigoArguDepositoAlm = comprobanteEmision.CodigoArguDepositoDesti;

                                if (comprobanteEmisionDetalle.CodigoArguGarantiaProd == string.Empty)
                                    comprobanteEmisionDetalle.CodigoArguGarantiaProd = null;

                                returnValorDocumRegSerie = RegistrarNroSeries(comprobanteEmision, comprobante, SUCEDE_DETALLE, comprobanteEmisionDetalle);
                                /* Si el Documento NO es una compra Internacional*/
                                if (!comprobanteEmision.indInternacional)
                                    /*Si el documento esta configurado con Incidencidencia en Stocks [-1,+1]
                                     O el motivo de la GUIA es una CONSIGNACION */
                                    if (comprobante.IncidenciaEnStocks != 0 ||
                                        comprobanteEmision.CodigoArguMotivoGuia == ConfigCROM.AppConfig(ConfigTool.DEFAULT_Doc_GuiaRemConsig))
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
                                            productoExistenciasData.UpdateStockInicial(new BaseFiltroAlmacen
                                            {
                                                codProducto = comprobanteEmisionDetalle.codProducto,
                                                codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm,
                                                cntStockInicial = comprobanteEmisionDetalle.Cantidad,
                                                segUsuarioEdita = comprobante.segUsuarioCrea
                                            }, ref SALDO_StockFisico);
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
                                            lstProductoExistencia = productoExistenciasData.Find(new BaseFiltroAlmacen
                                            {
                                                codProducto = comprobanteEmisionDetalle.codProducto,
                                                codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm
                                            });
                                            /* El Sistema consulta si el producto tiene ASIENTO de Existencia de Stocks 
                                               de no tener lo inserta y devuelve su Stock Fisico */
                                            if (lstProductoExistencia.Count == 0)
                                            {
                                                productoExistenciasData.UpdateStockInicial(new BaseFiltroAlmacen
                                                {
                                                    codProducto = comprobanteEmisionDetalle.codProducto,
                                                    codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm,
                                                    cntStockInicial = comprobanteEmisionDetalle.Cantidad,
                                                    segUsuarioEdita = comprobante.segUsuarioCrea
                                                }, ref SALDO_StockFisico);
                                                SUCEDE_UPDATE_STOCKS = false;
                                            }
                                            else
                                            {

                                                ProductoPrecioData productoPrecioData = new ProductoPrecioData();
                                                List<BEProductoPrecio> lstProductoPrecio = new List<BEProductoPrecio>();
                                                lstProductoPrecio = productoPrecioData.List(new BaseFiltro
                                                {
                                                    codProducto = comprobanteEmisionDetalle.codProducto,
                                                    codRegMoneda = string.Empty,
                                                    codListaPrecio = null,
                                                    codPerEmpresa = comprobanteEmision.CodigoPersonaEmpre,
                                                    codPuntoVenta = comprobanteEmision.CodigoPuntoVenta,
                                                    indEstado = true
                                                });
                                                if (lstProductoPrecio.Count == 1)
                                                {
                                                    lstProductoPrecio[0].ValorCosto = comprobanteEmisionDetalle.refUnitValorCosto;
                                                    lstProductoPrecio[0].SegMaquina = comprobanteEmision.SegMaquina;
                                                    productoPrecioData.Insert(lstProductoPrecio[0]);
                                                }
                                                ListaDePrecioDetalleData oListaDePrecioDetalleData = new ListaDePrecioDetalleData();
                                                oListaDePrecioDetalleData.Update(LlenarEntidadListaDePrecioDetalle(comprobanteEmisionDetalle));
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

                                        productoKardex.monCostoUnitSaldo = comprobanteEmisionDetalle.refUnitValorCosto;
                                        productoKardex.monTotalSaldo = comprobanteEmisionDetalle.refTotItemSaldoStock;

                                        if (comprobanteEmisionDetalle.EsVerificarStock)
                                            if (comprobanteEmision.CodigoArguTipoDeOperacion != ConstantesGC.TIPO_MOV_DOCUME_SALDO_INICIAL &&
                                                SUCEDE_UPDATE_STOCKS)
                                                productoExistenciasData.UpdateStockFisico(new BaseFiltroAlmacen
                                                {
                                                    codProducto = comprobanteEmisionDetalle.codProducto,
                                                    codDeposito= comprobanteEmisionDetalle.CodigoArguDepositoAlm,
                                                    cntStockFisico = comprobanteEmisionDetalle.Cantidad,
                                                    indOperador = comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString() ? -1 : comprobante.IncidenciaEnStocks,
                                                    numDocumentoReferencia = comprobanteEmision.NumeroComprobanteORIGEN,
                                                    codPerEntidad = comprobanteEmision.CodigoPersonaEntidad,
                                                    segUsuarioEdita = comprobante.segUsuarioCrea
                                                }, ref SALDO_StockFisico);

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
                                            sucesde_KARDEX = oiProductoExistenciasKardexData.Insert(productoKardex);
                                        }
                                    }
                                /*Si el documento es una GUIA DE REMISION con destino a CLIENTES y el
                                  producto configurado con EsVerificarStock==true 
                                 */
                                if (comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString() &&
                                    comprobanteEmision.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_VENTAS)
                                {
                                    if (comprobanteEmisionDetalle.EsVerificarStock)
                                    {
                                        decimal? prm_SALDO_StockComprometido = null;
                                        SUCEDE_STOCKCM = productoExistenciasData.UpdateStockComprometido(new BaseFiltroAlmacen
                                        {
                                            codProducto = comprobanteEmisionDetalle.codProducto,
                                            cntStockComprometido = comprobanteEmisionDetalle.Cantidad,
                                            codDeposito = comprobanteEmision.CodigoArguDepositoOrigen,
                                            indOperador = 1,
                                            segUsuarioEdita = comprobanteEmision.SegUsuarioCrea
                                        }, ref prm_SALDO_StockComprometido);
                                    }
                                }

                                if (comprobanteEmision.NumeroComprobanteORIGEN != null)
                                    if (comprobanteEmision.CodigoComprobanteORIGEN != null && comprobanteEmision.NumeroComprobanteORIGEN.Trim().Length > 0)
                                    {
                                        BEDocumento xCompAsos = new BEDocumento();
                                        xCompAsos = comprobantesData.Find(comprobante.CodigoComprobanteAsos);
                                        if (xCompAsos.CodigoComprobante != null)
                                        {
                                            if (xCompAsos.Abreviatura == HelpDocumentos.Tipos.GRE.ToString() &&
                                                comprobanteEmision.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_VENTAS)
                                            {
                                                if (comprobanteEmisionDetalle.EsVerificarStock)
                                                {
                                                    decimal? prm_SALDO_StockComprometido = null;
                                                    SUCEDE_STOCKCM = productoExistenciasData.UpdateStockComprometido(new BaseFiltroAlmacen
                                                    {
                                                        codProducto = comprobanteEmisionDetalle.codProducto,
                                                        cntStockComprometido = comprobanteEmisionDetalle.Cantidad,
                                                        codDeposito = comprobanteEmision.CodigoArguDepositoOrigen,
                                                        indOperador = -1,
                                                        segUsuarioEdita = comprobanteEmision.SegUsuarioCrea
                                                    }, ref prm_SALDO_StockComprometido);
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
                            itemComprobantesREF = new DocumentoLogic().Find(comprobanteEmision.CodigoComprobanteORIGEN);
                            // SE ASIGNA EL ID del Documento Emitido a los DOCUMENTOS Referenciados
                            string refEstadoDocum = string.Empty;
                            if (comprobante.Abreviatura == HelpDocumentos.Tipos.NCR.ToString() ||
                                comprobante.Abreviatura == HelpDocumentos.Tipos.NDB.ToString())
                                refEstadoDocum = itemComprobantesREF.CodigoArguEstEMIDefault;
                            else
                                refEstadoDocum = itemComprobantesREF.CodigoArguEstPRODefault;

                            String[] documentosORIGEN = comprobanteEmision.NumeroComprobanteORIGEN.Trim().Split(new Char[] { ' ' });
                            foreach (string IdNumeroORIGEN in documentosORIGEN)
                            {
                                SUCEDE_DOC_REFER = comprobanteEmisionData.UpdateRefAsigna(comprobanteEmision.codDocumReg,
                                                                    comprobanteEmision.CodigoComprobanteORIGEN,
                                                                    IdNumeroORIGEN,
                                                                    comprobanteEmision.SegUsuarioCrea,
                                                                    refEstadoDocum);
                            }
                        }

                    ReturnValor returnLetra = new ReturnValor();
                    if (comprobanteEmision.listaLetraDeCambio.Count > 0)
                    {
                        foreach (LetraDeCambioAux letraDeCambio in comprobanteEmision.listaLetraDeCambio)
                            letraDeCambio.codDocumReg = comprobanteEmision.codDocumReg;
                        returnLetra = new LetraDeCambioLogic().Insert(comprobanteEmision.listaLetraDeCambio);
                    }
                    if (SUCEDE_DETALLE.HasValue && SUCEDE_KARDEX && SUCEDE_DOC_REFER)
                    {
                        intReturnValor.Exitosa = true;
                        transactionScope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                intReturnValor.Message = ex.Message.ToString();
            }
            return intReturnValor;
        }
        private ReturnValor RegistrarNroSeries(BEComprobanteEmision comprobanteEmision, BEDocumento comprobante, int? SUCEDE_DETALLE, BEComprobanteEmisionDetalle comprobanteEmisionDetalle)
        {
            string cEstadoMercaderia = DetectarEstadoDeMercaderia(comprobanteEmision, comprobante);
            ReturnValor rnsReturnValor = new ReturnValor();
            List<BEDocumRegSerie> listaDocumRegSerie = new List<BEDocumRegSerie>();
            ProductoSeriadosData oiProductoSeriadosData = new ProductoSeriadosData();
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
                oiProductoSeriadosData.Update(lstProductoSeriadoEditas);
            List<BEProductoSeriado> lstProductoSeriadoRegistrado = new List<BEProductoSeriado>();
            if (lstProductoSeriadoNuevos.Count > 0)
            {
                ConfiguracionLogic configuracionLogic = new ConfiguracionLogic();
                string strCodAduana = ConfigCROM.AppConfig(ConfigTool.DEFAULT_Merca_Aduana);
                foreach (BEProductoSeriado hyui in lstProductoSeriadoNuevos)
                    if (comprobanteEmision.indInternacional)
                        hyui.codRegEstadoMercaderia = strCodAduana;
                lstProductoSeriadoRegistrado = productoSeriadosData.Insert(lstProductoSeriadoNuevos);
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
        private static BEListaDePrecioDetalle LlenarEntidadListaDePrecioDetalle(BEComprobanteEmisionDetalle comprobanteEmisionDetalle)
        {
            BEListaDePrecioDetalle listaDePrecioDetalle = new BEListaDePrecioDetalle
            {
                CodigoArguMoneda = ConfigCROM.AppConfig(ConfigTool.DEFAULT_MonedaNac),
                CodigoLista = comprobanteEmisionDetalle.CodigoListaPrecio,
                CodigoPersonaEmpre = comprobanteEmisionDetalle.CodigoPersonaEmpre,
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
                codDeposito = comprobanteEmision.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_VENTAS ? comprobanteEmision.CodigoArguDepositoOrigen : comprobanteEmision.CodigoArguDepositoDesti,
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
                if (comprobanteEmision.CodigoArguMotivoGuia == ConfigCROM.AppConfig(ConfigTool.DEFAULT_Doc_GuiaRemConsig))
                    pEstadoMercaderia = ConfigCROM.AppConfig(ConfigTool.DEFAULT_MercaderConsig);
                else
                    pEstadoMercaderia = string.Empty;
            else if (comprobante.IncidenciaEnCaja == 1 && comprobante.IncidenciaEnStocks == -1)
                pEstadoMercaderia = ConfigCROM.AppConfig(ConfigTool.DEFAULT_MercaderVendida);
            return pEstadoMercaderia;
        }
        private ReturnValor EliminarTodaReferenciaComprobanteEmision(BEComprobanteEmision comprobanteEmision, BEDocumento comprobante)
        {
            ReturnValor intReturnValor = new ReturnValor();
            bool SUCEDE_DETALLE = true, SUCEDE_IMPUESTOS = true, SUCEDE_KARDEX = true;
            bool SUCEDE_CTACTES = true, SUCEDE_DOC_REFER = true, SUCEDE_REGCAJ = true;
            bool SUCEDE_SERIAD = true, SUCEDE_STOCKCM = true, SUCEDE_LETRA_CAMBIO = true;
            bool SUCEDE_SERIADReg = true;
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
                        SUCEDE_KARDEX = productoExistenciasKardexData.Delete(new BaseFiltroAlmacen
                        {
                            codDocumReg = comprobanteEmision.codDocumReg,
                            codDeposito = codDeposito
                        });
                    }

                    if (comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString())
                        SUCEDE_KARDEX = productoExistenciasKardexData.Delete(new BaseFiltroAlmacen
                        {
                            codDocumReg = comprobanteEmision.codDocumReg,
                            codDeposito = null
                        });


                    if (comprobante.IncidenciaEnCtaCte != 0)
                        SUCEDE_CTACTES = cuentasCorrientesData.Delete(comprobanteEmision.codDocumReg, null);

                    if (comprobanteEmision.NumeroComprobanteORIGEN != null)
                        if (comprobanteEmision.CodigoComprobanteORIGEN != null && comprobanteEmision.NumeroComprobanteORIGEN.Trim().Length > 0)
                        {
                            BEDocumento itemComprobantesREF = new BEDocumento();
                            itemComprobantesREF = new DocumentoLogic().Find(comprobanteEmision.CodigoComprobanteORIGEN);
                            // SE ASIGNA EL ID del Documento Emitido a los DOCUMENTOS Referenciados
                            String[] documentosORIGEN = comprobanteEmision.NumeroComprobanteORIGEN.Trim().Split(new Char[] { ' ' });
                            foreach (string IdNumeroORIGEN in documentosORIGEN)
                            {
                                SUCEDE_DOC_REFER = comprobanteEmisionData.UpdateRefDesAsigna(
                                                                    comprobanteEmision.codDocumReg,
                                                                    comprobanteEmision.CodigoComprobanteORIGEN,
                                                                    IdNumeroORIGEN,
                                                                    itemComprobantesREF.CodigoArguEstEMIDefault,
                                                                    comprobanteEmision.SegUsuarioCrea);
                            }
                        }
                    ProductoSeriadosData productoSeriadoData = new ProductoSeriadosData();
                    List<BEProductoSeriado> lstProductoSeriado = new List<BEProductoSeriado>();
                    foreach (BEComprobanteEmisionDetalle comprobanteEmisionDetalle in comprobanteEmision.listaComprobanteEmisionDetalle)
                    {
                        if (comprobante.IncidenciaEnStocks != 0 || comprobanteEmision.CodigoArguMotivoGuia == ConfigCROM.AppConfig(ConfigTool.DEFAULT_Doc_GuiaRemConsig))
                        {
                            if (!comprobanteEmision.indInternacional)
                            {
                                if (comprobanteEmisionDetalle.EsVerificarStock)
                                {
                                    if (comprobanteEmision.CodigoArguTipoDeOperacion == ConfigCROM.AppConfig(ConfigTool.DEFAULT_Movim_SInicial))
                                    {
                                        productoExistenciasData.Delete(new BaseFiltroAlmacen
                                        {
                                            codProducto = comprobanteEmisionDetalle.codProducto,
                                            codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm
                                        });
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
                                            productoExistenciasData.UpdateStockFisico(new BaseFiltroAlmacen
                                            {
                                                codProducto = comprobanteEmisionDetalle.codProducto,
                                                codDeposito = codDeposito,
                                                cntStockFisico = Math.Round((decimal)comprobanteEmisionDetalle.Cantidad, 3),
                                                indOperador = comprobante.IncidenciaEnStocks * -1,
                                                segUsuarioEdita = comprobante.segUsuarioCrea,
                                            }, ref SALDO_StockFisico);
                                        else
                                        {
                                            if (comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString())
                                                productoExistenciasData.UpdateStockFisicoConsig(new BaseFiltroAlmacen
                                                {
                                                    codProducto = comprobanteEmisionDetalle.codProducto,
                                                    codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm,
                                                    cntStockFisico = Math.Round((decimal)comprobanteEmisionDetalle.Cantidad, 3),
                                                    indOperador = comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString() ? 1 : (comprobante.IncidenciaEnStocks * -1),
                                                    segUsuarioEdita = comprobante.segUsuarioCrea,
                                                    cntStockComprometido = Math.Round((decimal)comprobanteEmisionDetalle.Cantidad, 3)
                                                }, ref SALDO_StockFisico);
                                            else
                                                productoExistenciasData.UpdateStockComprometido(new BaseFiltroAlmacen
                                                {
                                                    codProducto = comprobanteEmisionDetalle.codProducto,
                                                    codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm,
                                                    cntStockFisico = Math.Round((decimal)comprobanteEmisionDetalle.Cantidad, 3),
                                                    indOperador = comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString() ? -1 : (comprobante.IncidenciaEnStocks * 1),
                                                    segUsuarioEdita = comprobante.segUsuarioCrea
                                                }, ref SALDO_StockFisico);
                                        }

                                    }
                                    else
                                    {
                                        if (comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString())

                                            productoExistenciasData.UpdateStockFisicoConsig(new BaseFiltroAlmacen
                                            {
                                                codProducto = comprobanteEmisionDetalle.codProducto,
                                                codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm,
                                                cntStockFisico = Math.Round((decimal)comprobanteEmisionDetalle.Cantidad, 3),
                                                indOperador = comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString() ? 1 : (comprobante.IncidenciaEnStocks * -1),
                                                segUsuarioEdita = comprobante.segUsuarioCrea,
                                                cntStockComprometido = Math.Round((decimal)comprobanteEmisionDetalle.Cantidad, 3)
                                            }, ref SALDO_StockFisico);
                                        else
                                            productoExistenciasData.UpdateStockComprometido(new BaseFiltroAlmacen
                                            {
                                                codProducto = comprobanteEmisionDetalle.codProducto,
                                                codDeposito = comprobanteEmisionDetalle.CodigoArguDepositoAlm,
                                                cntStockFisico = Math.Round((decimal)comprobanteEmisionDetalle.Cantidad, 3),
                                                indOperador = comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString() ? -1 : (comprobante.IncidenciaEnStocks * 1),
                                                segUsuarioEdita = comprobante.segUsuarioCrea
                                            }, ref SALDO_StockFisico);
                                    }

                                }
                            }
                            if (comprobante.IncidenciaEnStocks == 1)
                                foreach (BEProductoSeriado productoSeriado in comprobanteEmisionDetalle.listaProductoSeriados)
                                {
                                    SUCEDE_SERIAD = productoSeriadoData.DeleteDetalleDocum(new BaseFiltroAlmacen
                                    {
                                        codId = productoSeriado.codProductoSeriado,
                                        codProducto = comprobanteEmisionDetalle.codProducto,
                                        codDocumRegDetalle = comprobanteEmisionDetalle.codDocumRegDetalle
                                    });
                                }
                            else
                            {
                                foreach (BEProductoSeriado productoSeriado in comprobanteEmisionDetalle.listaProductoSeriados)
                                {
                                    productoSeriado.NumeroComprobanteVenta = null;
                                    productoSeriado.SegUsuarioEdita = comprobanteEmision.SegUsuarioEdita;
                                    productoSeriado.FechaVenta = null;
                                    productoSeriado.codRegEstadoMercaderia = ConfigCROM.AppConfig(ConfigTool.DEFAULT_MercaderApto);
                                    productoSeriado.CodigoPersonaCliente = null;
                                    productoSeriado.EstadoVendido = false;
                                    lstProductoSeriado.Add(productoSeriado);
                                }
                                if (lstProductoSeriado.Count > 0)
                                    SUCEDE_SERIAD = productoSeriadoData.Update(lstProductoSeriado);
                            }
                        }
                        else
                            if (comprobanteEmisionDetalle.EsVerificarStock)
                            {
                                foreach (BEProductoSeriado productoSeriado in comprobanteEmisionDetalle.listaProductoSeriados)
                                {
                                    productoSeriado.NumeroComprobanteComprom = null;
                                    productoSeriado.SegUsuarioEdita = comprobanteEmision.SegUsuarioEdita;
                                    productoSeriado.codRegEstadoMercaderia = ConfigCROM.AppConfig(ConfigTool.DEFAULT_MercaderApto);
                                    productoSeriado.CodigoPersonaComprometido = null;
                                    productoSeriado.EstadoVendido = false;
                                    lstProductoSeriado.Add(productoSeriado);
                                }
                                if (lstProductoSeriado.Count > 0)
                                    SUCEDE_SERIAD = productoSeriadoData.Update(lstProductoSeriado);
                                if (comprobante.Abreviatura == HelpDocumentos.Tipos.GRE.ToString() && comprobanteEmision.CodigoArguDestinoComp == ConstantesGC.OPERACION_DESTINO_VENTAS)
                                {
                                    if (comprobanteEmisionDetalle.EsVerificarStock)
                                    {
                                        decimal? prm_SALDO_StockComprometido = null;
                                        SUCEDE_STOCKCM = productoExistenciasData.UpdateStockComprometido(new BaseFiltroAlmacen
                                        {
                                            codProducto = comprobanteEmisionDetalle.codProducto,
                                            cntStockComprometido = comprobanteEmisionDetalle.Cantidad,
                                            codDeposito = comprobanteEmision.CodigoArguDepositoOrigen,
                                            indOperador = -1,
                                            segUsuarioEdita = comprobanteEmision.SegUsuarioCrea
                                        }, ref prm_SALDO_StockComprometido);
                                    }
                                }
                            }
                    }
                    InventarioData inventarioData = new InventarioData();
                    inventarioData.DeleteInventarioDocumReg(new BaseFiltroAlmacen { codDocumReg = comprobanteEmision.codDocumReg });

                    returnValor = DeletecodDocumReg(comprobanteEmision);
                    SUCEDE_SERIADReg = returnValor.Exitosa;

                    ComprobanteEmisionImpuestosData oComprobanteEmisionImpuestosData = new ComprobanteEmisionImpuestosData();
                    SUCEDE_IMPUESTOS = oComprobanteEmisionImpuestosData.Delete(comprobanteEmision.codDocumReg);

                    CajaRegistroData oComprobanteEmitidosData = new CajaRegistroData();
                    SUCEDE_REGCAJ = oComprobanteEmitidosData.Delete(comprobanteEmision.codDocumReg);

                    LetraDeCambioData oLetraDeCambioData = new LetraDeCambioData();
                    SUCEDE_LETRA_CAMBIO = oLetraDeCambioData.Delete(comprobanteEmision.codDocumReg);

                    /*SI Documento de Compra esta en estado emitido se elimina NUM SERIES*/
                    SUCEDE_DETALLE = comprobanteEmisionDetalleData.Delete(comprobanteEmision.codDocumReg);

                    if (SUCEDE_DETALLE && SUCEDE_KARDEX && SUCEDE_IMPUESTOS &&
                        SUCEDE_DOC_REFER && SUCEDE_CTACTES && SUCEDE_SERIAD)
                    {
                        intReturnValor.Exitosa = true;
                        transactionScope.Complete();
                    }
                }
            }

            catch (Exception ex)
            {
                intReturnValor.Message = ex.Message.ToString();
            }
            return intReturnValor;
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
                listaDocumRegSerie = objDocumRegSerieData.ListcodDocumReg(pFiltro);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaDocumRegSerie;
        }
        public List<BEDocumRegSerie> ListcodDocumRegDetalle(BaseFiltro pFiltro)
        {
            List<BEDocumRegSerie> listaDocumRegSerie = new List<BEDocumRegSerie>();
            try
            {
                listaDocumRegSerie = objDocumRegSerieData.ListcodDocumRegDetalle(pFiltro);

            }
            catch (Exception ex)
            {
                throw ex;
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
                    returnValor.codRetorno = objDocumRegSerieData.Insert(lstDocumRegSerie);

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
                    returnValor.Exitosa = objDocumRegSerieData.DeletecodDocumReg(new BaseFiltro
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
            }
            return returnValor;
        }
        public ReturnValor DeletecodDocumRegDetalle(BaseFiltro pFiltro)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = objDocumRegSerieData.DeletecodDocumRegDetalle(pFiltro);
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
            }
            return returnValor;
        }

        #endregion


    }
}

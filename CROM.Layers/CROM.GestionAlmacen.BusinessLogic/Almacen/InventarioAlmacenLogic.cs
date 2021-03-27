namespace CROM.GestionAlmacen.BusinessLogic.Almacen
{
    using CROM.BusinessEntities.Almacen;
    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.Maestros;
    using CROM.GestionAlmacen.DataAccess;
    using CROM.TablasMaestras.BussinesLogic;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.Web;
    using CROM.Tools.Config;

    using System;
    using System.Collections.Generic;
    using System.Transactions;
    using static CROM.Tools.Comun.Web.WebConstants;


    public class InventarioAlmacenLogic
    {
 
        ProductoLogic oProductoLogic = null;
        ProductoExistenciaData oProductoExistenciasData = null;
        ProductoKardexData oProductoExistenciasKardexData = null;
        InventarioLogic objInventarioLogic = null;
        PersonasLogic oPersonasLogic = null;
        ConfiguracionLogic cnf = null;

        public InventarioAlmacenLogic()
        {
            oProductoLogic = new ProductoLogic();
            oPersonasLogic = new PersonasLogic();
            objInventarioLogic = new InventarioLogic();
            oProductoExistenciasData = new ProductoExistenciaData();
            oProductoExistenciasKardexData = new ProductoKardexData();
            cnf = new ConfiguracionLogic();
        }

// Obtener el valor del tipo de cambio de la Fecha actual del sistema -->> PARA VALIDAR
// itemTiposDeCambio = new TipoDeCambioLogic().Find(new BaseFiltro { fecInicioDate = DateTime.Now, codRegMoneda = ConfigCROM.AppConfig(ConfigTool.DEFAULT_MonedaInt) });
                
// Obtiene el Valor del impuesto a las ventas IGV
// itemImpuestoVTA = new ImpuestoLogic().Find(ConfigCROM.AppConfig(ConfigTool.DEFAULT_Impuesto_Ventas));

//  Obtiene los numeros de series de los documentos a emitir de forma automática por el proceso
//List<BEDocumentoSerie> listaComprobantesSeries = new List<BEDocumentoSerie>();
//BaseFiltro pFiltro = new BaseFiltro
//{
//    codPerEmpresa = lstInventario[0].CodigoPersonaEmpre,
//    codPuntoVenta = lstInventario[0].CodigoPuntoVenta,
//    codDocumento = string.Empty,
//    indEstado = true
//};
//listaComprobantesSeries = new DocumentoLogic().ListDocumentoSeriePorUsuario(pFiltro);

//  Obtiene Documentos y series de Documento de tipo INVENTARIO
//  Documento Inventario Inicial
//BEDocumento itemComprobanteInventario = new BEDocumento();
//DocumentoLogic oComprobantesLogic = new DocumentoLogic();
//string strCodDocumInventario = ConfigCROM.AppConfig(ConfigTool.DEFAULT_Doc_Inventarios);
//itemComprobanteInventario = oComprobantesLogic.Find(strCodDocumInventario);

//  Obtiene el numero de serie del documento de INVENTARIO
//List<BEDocumentoSerie> listaComprobantesSeriesFiltro = new List<BEDocumentoSerie>();
//listaComprobantesSeriesFiltro = listaComprobantesSeries.FindAll(x => x.CodigoPersonaEmpre == lstInventario[0].CodigoPersonaEmpre &&
//                                                                                 x.CodigoPuntoVenta == lstInventario[0].CodigoPuntoVenta &&
//                                                                                (x.CodigoComprobante == strCodDocumInventario) &&
//                                                                                 x.Estado == true);

//string sNumeroDeDocumento = string.Empty;
//// Obtiene la entidad SERIE del DOCUMENTO 
//itemSerieInventario = listaComprobantesSeriesFiltro[0];
//ReturnValor iReturnValor = new ReturnValor();
//// Obtener el ultimo numero de documento a generar de forma automatica
//iReturnValor = oComprobantesLogic.UltimoNumeroDocumento(itemSerieInventario.CodigoTalonario);
//if (iReturnValor.Exitosa)
//    sNumeroDeDocumento = HelpDocumentos.Tipos.INV.ToString() + iReturnValor.CodigoRetorno.Substring(0, 3) + iReturnValor.CodigoRetorno.Substring(4, 10);
//else
//    return iReturnValor;



        //// Guardar la cabecera del documento de INVENTARIO
        //int? SUCEDE_REGIS_DOCUMENTO = null;
        //SUCEDE_REGIS_DOCUMENTO = new ComprobanteEmisionData().Insert(comprobanteEmisionInventario);

        //int? SUCEDE_REGIS_DOCU_DETA = null;
        //int SUCEDE_REGIS_REG_KARDEX = 0;
        //// Guardar el detalle del documento de INVENTARIO
        //foreach (BEComprobanteEmisionDetalle itemDocDetalle in listaComprobanteEmisionDetalle)
        //{
        //    itemDocDetalle.codDocumReg = SUCEDE_REGIS_DOCUMENTO.Value;
        //    SUCEDE_REGIS_DOCU_DETA = oComprobanteEmisionDetalleData.Insert(itemDocDetalle);
        //    // Guardar el registro de KARDEX
        //    foreach (ProductoKardexAux itemDocKardex in listaProductoKardex)
        //        if (itemDocDetalle.codProducto == itemDocKardex.codProducto)
        //        {
        //            itemDocKardex.codDocumRegDetalle = SUCEDE_REGIS_DOCU_DETA.Value;
        //            SUCEDE_REGIS_REG_KARDEX = oProductoExistenciasKardexData.Insert(itemDocKardex);
        //        }
        //    // Guardar registros de PRODUCTOS SERIADOS por REGULARIZAR
        //    foreach (BEProductoSeriado itemProductoSeriado in itemDocDetalle.listaProductoSeriados)
        //    {
        //        returnValorProcesoCierre = oProductoLogic.Insert(itemProductoSeriado);
        //    }
        //}
        //// Actualizar el registro de serie de DOCUMENTOS
        //BEDocumentoSerie objDocumentoSerieUpdate = new BEDocumentoSerie
        //{
        //    CodigoTalonario = itemSerieInventario.CodigoTalonario,
        //    segUsuarioEdita = itemImpuestoVTA.segUsuarioCrea,
        //    segMaquinaEdita = "UserInventario"
        //};
        //SUCEDE_REGIS_TALONARIO_INV = new DocumentoSerieData().UpdateUltimo(objDocumentoSerieUpdate);
        //// Guardar registros de Kardex por cada item del Detalle
        //if (returnValor.Exitosa &&
        //    ACTUALIZA_KARDEX &&
        //    SUCEDE_REGIS_DOCUMENTO.HasValue &&
        //    SUCEDE_REGIS_DOCU_DETA.HasValue &&
        //    SUCEDE_REGIS_REG_KARDEX != 0 &&
        //    SUCEDE_UPDATE_STOCK_FIS)
        //{
        //    returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
        //    returnValor.Message = returnValor.Message + ", " + HelpEventos.MessageEvento(HelpEventos.Process.NEW);
        //    tx.Complete();
        //}

        //bool SUCEDE_REGIS_TALONARIO_INV = false;

      
        public ReturnValor UpdateInventariosCerrarAsientoEnKardex(List<InventarioAux> lstInventario, 
                                                                  //List<BEDocumentoSerie> listaComprobantesSeries,
                                                                  //List<BEDocumentoSerie> listaComprobantesSeriesFiltro,
                                                                  BETipoDeCambio itemTiposDeCambio,
                                                                  BEImpuesto itemImpuestoVTA,
                                                                  BEDocumento itemComprobanteInventario,
                                                                  string sNumeroDeDocumento,
                                                                  int pcodEmpresa,
                                                                  string psegUsuario,
                                                                  out BEComprobanteEmision comprobanteEmisionInventarioLleno,
                                                                  out List<ProductoKardexAux> listaProductoKardexLleno)
        {
            ReturnValor returnValorProcesoCierre = new ReturnValor();
            //// Documento de Inventario
            BEComprobanteEmision comprobanteEmisionInventario = null;
            List<ProductoKardexAux> listaProductoKardex = new List<ProductoKardexAux>();
            try
            {

                //// Validar el valor del tipo de cambio de la Fecha actual del sistema -->> PARA VALIDAR
                //if (itemTiposDeCambio == null)
                //{
                //    returnValorProcesoCierre.Message = HelpMessages.gc_DOCUM_TipoDeCambio;
                //    comprobanteEmisionInventarioLleno = comprobanteEmisionInventario;
                //    listaProductoKardexLleno = listaProductoKardex; 
                //    return returnValorProcesoCierre;
                //}

                // Validar si todos lo productos tienen Precio de Venta y Precio de Compra antes de Cerrar Inventario
                if (!ValidarPreciosAntesDeCerrarInventario(lstInventario))
                {
                    returnValorProcesoCierre.Message = HelpMessages.INVENTARIOValidacionCIERREPrecios;
                    comprobanteEmisionInventarioLleno = comprobanteEmisionInventario;
                    listaProductoKardexLleno = listaProductoKardex; 
                    return returnValorProcesoCierre;
                }

                //// Si el documento de tipo INVENTARIO tiene una serie definida
                //if (listaComprobantesSeriesFiltro.Count != 1 || itemComprobanteInventario == null || itemImpuestoVTA == null)
                //{
                //    returnValorProcesoCierre.Message = HelpMessages.InventarioValidaDocum;
                //    comprobanteEmisionInventarioLleno = comprobanteEmisionInventario;
                //    listaProductoKardexLleno = listaProductoKardex; 
                //    return returnValorProcesoCierre;
                //}

                List<BEInventarioSerie> lstInventarioSerie = new List<BEInventarioSerie>();
                List<BEInventarioSerie> lstInventarioSerieProdu = null;

                BEDocumentoSerie itemSerieInventario = null;

                string strEstadoPSeriadoMercaderiaRegularizar = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Merca_PorRegular);
                string strEstadoPSeriadoMercaderiaRetirar = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Merca_Retirada);
                string strEstadoPSeriadoMercaderiaConsignacion = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Merca_Consignacion);
                string strCodDocumNotaSalida = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Doc_NotaSalida);
                string strCodDocumNotaIngreso = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Doc_NotaIngreso);
                bool ACTUALIZA_KARDEX = false;
                bool SUCEDE_UPDATE_STOCK_FIS = false;

                // Lista los registros de inventario serie por Periodo de inventario y conteo elegido para el cierre
                lstInventarioSerie = objInventarioLogic.ListInventarioSeriePorPeriodo(new BaseFiltroAlmacen
                {
                    perPeriodo = lstInventario[0].Periodo,
                    cntConteo = (int)lstInventario[0].ConteoSel
                });

                // MODALIDAD (0/1): 
                // Para el caso de CIERRE DE INVENTARIO=0 y 
                // Para generar ASIENTO EN KARDEX=1

                // Valida si el codigo de documento SERIE-INVENTARIO es igual código de documento PROGRAMADO
                if (itemSerieInventario.CodigoComprobante == itemComprobanteInventario.CodigoComprobante)
                {
                    BEProducto itemProducto = new BEProducto();
                    BEPersona itemEmpresa = new BEPersona();
                    // Obtiene Datos de la empresa
                    itemEmpresa = oPersonasLogic.Find(itemComprobanteInventario.codEmpresa,
                                                      lstInventario[0].CodigoPersonaEmpre,
                                                      lstInventario[0].segUsuarioCrea);

                    // Llena la entidad del documento INVENTARIO que contiene todos los productos a cerrar inventario
                    comprobanteEmisionInventario = LlenarDocumentoInventarioInicial(lstInventario
                                                                                   ,itemTiposDeCambio
                                                                                   ,itemImpuestoVTA, oPersonasLogic
                                                                                   ,itemComprobanteInventario
                                                                                   ,sNumeroDeDocumento
                                                                                   ,itemEmpresa
                                                                                   ,pcodEmpresa
                                                                                   ,psegUsuario);

                    // Inicio el proceso TRANSACCION de cierre de inventario ==> Para ASIENTO EN KARDEX
                    using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                    {
                        List<BEComprobanteEmisionDetalle> listaComprobanteEmisionDetalle = new List<BEComprobanteEmisionDetalle>();
                        List<BEProductoSeriado> lstProductoSeries = null;
                        int CONTA_ITEM = 1;
                        // Inicia el recorrido de todo el listado de productos para cerrar su inventario
                        foreach (InventarioAux itemInventario in lstInventario)
                        {
                            // Llena la lista solo cuando el producto es de tipo SERIADO o hay Numeros de series
                            lstInventarioSerieProdu = lstInventarioSerie.FindAll(x => x.codInventario == itemInventario.codInventario);
                            if (lstInventarioSerieProdu.Count > 0)
                                foreach (BEInventarioSerie itemIS in lstInventarioSerieProdu)
                                {
                                    // Si el INDICADOR dice que existe cantidad FISICA
                                    if (itemIS.indExisteFisico)
                                        // Si el estado del Numero de serie esta EN CONSIGNACIÓN, DESAGREGA en el conteo (-1)
                                        if (itemIS.objProductoSerie.codRegEstadoMercaderia == strEstadoPSeriadoMercaderiaConsignacion)
                                            itemInventario.Conteo = itemInventario.Conteo - 1;
                                }

                            decimal? prm_SALDO_StockMerma = 0;
                            decimal? prm_SALDO_StockSobrante = 0;
                            // Actualiza el STOCK del Producto - Se cierra el STOCK para su inventario con: itemInventario.Conteo
                            SUCEDE_UPDATE_STOCK_FIS = oProductoExistenciasData.UpdateStockFisicoInventario(
                                            new BEProductoExistenciaStockUpdate
                                            {
                                                codProducto = itemInventario.codProducto,
                                                codDeposito = itemInventario.codDeposito,
                                                cntStockFisico = itemInventario.Conteo,
                                                segUsuarioEdita = itemInventario.segUsuarioEdita
                                            },
                                            ref prm_SALDO_StockMerma,
                                            ref prm_SALDO_StockSobrante);
                            // Obtiene los stocks de MERMAS y SOBRANTES
                            itemInventario.SALDO_StockMerma = prm_SALDO_StockMerma == null ? 0 : prm_SALDO_StockMerma.Value;
                            itemInventario.SALDO_StockSobrante = prm_SALDO_StockSobrante == null ? 0 : prm_SALDO_StockSobrante.Value;

                            // Actualiza en el INVENTARIO el registro
                            returnValorProcesoCierre = objInventarioLogic.UpdateInventariosCerrar(itemInventario);

                            if (!returnValorProcesoCierre.Exitosa)
                            {
                                comprobanteEmisionInventarioLleno = comprobanteEmisionInventario;
                                listaProductoKardexLleno = listaProductoKardex; 
                                return returnValorProcesoCierre;
                            }

                            // Actualiza en el KARDEX a modo de Procesado - CERRADO asignado PERIODO DE INVENTARIO
                            ACTUALIZA_KARDEX = oProductoExistenciasKardexData.UpdateKardexCierre(new BaseFiltroAlmacen
                            {
                                codEmpresaRUC = itemInventario.CodigoPersonaEmpre,
                                codPuntoVenta = itemInventario.CodigoPuntoVenta,
                                codDeposito = itemInventario.codDeposito,
                                codProducto = itemInventario.codProducto,
                                segUsuarioEdita = itemInventario.segUsuarioEdita,
                                perPeriodo = itemInventario.Periodo,
                                fecCierreInventario = itemInventario.CierreFechaHora.Value,
                                codEmpleadoInventario = itemInventario.CierreEmpleado
                            });

                            // Buscar datos del Producto que se ha cerrado su inventario
                            itemProducto = oProductoLogic.Find(new BaseFiltroAlmacen
                            {
                                codEmpresaRUC = itemInventario.CodigoPersonaEmpre,
                                codPuntoVenta = itemInventario.CodigoPuntoVenta,
                                codDeposito = itemInventario.codDeposito,
                                codProducto = itemInventario.codProducto
                            });
                            decimal PRECIO_VENTAS = itemInventario.ValorVenta.Value;
                            decimal PRECIO_COMPRA = itemInventario.ValorCosto.Value;
                            string CODI_ARGUMONEDA = itemInventario.codRegMoneda;
                            // Llenar la entidad del item-detalle del docuemnto INVENTARIO
                            BEComprobanteEmisionDetalle itemComprobanteEmisionDetalle =
                                                                    LlenarEntidadDocumentoDetalle(itemInventario,
                                                                    itemImpuestoVTA,
                                                                    itemComprobanteInventario,
                                                                    sNumeroDeDocumento,
                                                                    itemProducto,
                                                                    CONTA_ITEM,
                                                                    itemInventario,
                                                                    true);
                            // Si el producto tiene numeros seriados agregarlo como mercaderia por REGULARIZAR
                            if (itemInventario.EsConNumeroSeriado)
                            {
                                lstProductoSeries = new List<BEProductoSeriado>();
                                lstProductoSeries = ProductoSeriadosAgregar(itemInventario
                                                                         , sNumeroDeDocumento
                                                                         , strEstadoPSeriadoMercaderiaRegularizar);
                                itemComprobanteEmisionDetalle.listaProductoSeriados = lstProductoSeries;
                            }
                            listaComprobanteEmisionDetalle.Add(itemComprobanteEmisionDetalle);
                            // Llenar la entidad KARDEX para registrar el asiento 
                            ProductoKardexAux itemProductoKardex = LlenarEntidadKardex(itemComprobanteInventario,
                                                                                        sNumeroDeDocumento,
                                                                                        itemEmpresa,
                                                                                        CONTA_ITEM,
                                                                                        itemInventario,
                                                                                        itemProducto,
                                                                                        itemTiposDeCambio.CambioVentasGOB,
                                                                                        ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Movim_InvCierre),
                                                                                        ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Movim_SInicial));
                            listaProductoKardex.Add(itemProductoKardex);
                            ++CONTA_ITEM;
                        }
                        // Asignar la colección del detalle al documento INVENTARIO
                        comprobanteEmisionInventario.listaComprobanteEmisionDetalle = listaComprobanteEmisionDetalle;

                        // Totalizar el Documento INVENTARIO
                        decimal nTotItemValorBruto = 0;
                        decimal nTotItemValorDscto = 0;
                        decimal nTotItemValorVenta = 0;
                        decimal nTotItemValorIGV = 0;
                        foreach (BEComprobanteEmisionDetalle itemDocDetalle in listaComprobanteEmisionDetalle)
                        {
                            nTotItemValorBruto += itemDocDetalle.TotItemValorBruto;
                            nTotItemValorDscto += itemDocDetalle.TotItemValorDscto;
                            nTotItemValorVenta += itemDocDetalle.TotItemValorVenta;
                            nTotItemValorIGV += itemDocDetalle.TotItemValorIGV;
                        }
                        comprobanteEmisionInventario.ValorTotalBruto = nTotItemValorBruto;
                        comprobanteEmisionInventario.ValorTotalDescuento = nTotItemValorDscto;
                        comprobanteEmisionInventario.ValorTotalVenta = nTotItemValorVenta;
                        comprobanteEmisionInventario.ValorTotalImpuesto = nTotItemValorIGV;
                        decimal nTotPrecioVenta = nTotItemValorVenta + nTotItemValorIGV;
                        comprobanteEmisionInventario.ValorTotalPrecioVenta = nTotPrecioVenta;
                        comprobanteEmisionInventario.ValorTotalPrecioExtran = Helper.DecimalRound(nTotItemValorVenta /
                                                                              comprobanteEmisionInventario.ValorTipoCambioVTA, 2);

                        // Se asigna el documento generado de inventario a la variable OUT
                    }

                }
            }
            catch (Exception ex)
            {
                returnValorProcesoCierre = HelpException.mTraerMensaje(ex);
            }
            comprobanteEmisionInventarioLleno = comprobanteEmisionInventario;
            listaProductoKardexLleno = listaProductoKardex; 
            return returnValorProcesoCierre;
        }



//-----------------------------------------------------
//// Obtiene Documentos y series de Documento
//itemComprobanteNotaIngreso = oComprobantesLogic.Find(strCodDocumNotaIngreso);
//itemComprobanteNotaSalida = oComprobantesLogic.Find(strCodDocumNotaSalida);
//listaComprobantesSeriesFiltro = listaComprobantesSeries.FindAll(x => x.CodigoPersonaEmpre == lstInventario[0].CodigoPersonaEmpre &&
//                                                                        x.CodigoPuntoVenta == lstInventario[0].CodigoPuntoVenta &&
//                                                                        x.CodigoComprobante == strCodDocumNotaSalida &&
//                                                                        x.Estado == true);
//listaComprobantesSeriesFiltro = listaComprobantesSeries.FindAll(x => x.CodigoPersonaEmpre == lstInventario[0].CodigoPersonaEmpre &&
//                                                                          x.CodigoPuntoVenta == lstInventario[0].CodigoPuntoVenta &&
//                                                                          x.CodigoComprobante == strCodDocumNotaIngreso &&
//                                                                          x.Estado == true);

/// OBTENER EL ULTIMO NUMERO DE returnValorNSNI
//ReturnValor returnValorNSNI = null;
//string sNumDocumentoNotaIngres = string.Empty;
//string sNumDocumentoNotaSalida = string.Empty;
//returnValorNSNI = oComprobantesLogic.UltimoNumeroDocumento(itemSerieNotaIngreso.CodigoTalonario);
//if (returnValorNSNI.Exitosa)
//    sNumDocumentoNotaIngres = HelpDocumentos.Tipos.NIN.ToString() + returnValorNSNI.CodigoRetorno.Substring(0, 3) + returnValorNSNI.CodigoRetorno.Substring(4, 10);
//else
//    return returnValorNSNI;
//returnValorNSNI = oComprobantesLogic.UltimoNumeroDocumento(itemSerieNotaSalida.CodigoTalonario);
//if (returnValorNSNI.Exitosa)
//    sNumDocumentoNotaSalida = HelpDocumentos.Tipos.NSL.ToString() + returnValorNSNI.CodigoRetorno.Substring(0, 3) + returnValorNSNI.CodigoRetorno.Substring(4, 10);
//else
//    return returnValorNSNI;


        //// Guardar documento de NOTA DE INGRESO
        //returnValorNI = comprobanteEmisionLogic.Insert(comprobanteEmisionNotaIngreso,
        //                                                itemComprobanteNotaIngreso,
        //                                                itemSerieNotaIngreso.CodigoTalonario);
        //strTieneNI = comprobanteEmisionNotaIngreso.NumeroComprobante;

        //foreach (BEComprobanteEmisionDetalle detalleNI in comprobanteEmisionNotaIngreso.listaComprobanteEmisionDetalle)
        //{
        //    BEInventarioDocumReg inventarioDocumReg = new BEInventarioDocumReg
        //    {
        //        codDocumReg = returnValorNI.codRetorno,
        //        strPeriodo = lstInventario[0].Periodo,
        //        codInventario = detalleNI.auxcodInventario,
        //        segUsuarioCrea = comprobanteEmisionNotaIngreso.SegUsuarioCrea
        //    };
        //    lstInventarioDocumReg.Add(inventarioDocumReg);
        //};

        //// Guardar documento de NOTA DE SALIDA
        //returnValorNS = comprobanteEmisionLogic.Insert(comprobanteEmisionNotaSalida, itemComprobanteNotaSalida, itemSerieNotaSalida.CodigoTalonario);
        //strTieneNS = comprobanteEmisionNotaSalida.NumeroComprobante;
        //foreach (BEComprobanteEmisionDetalle detalleNS in comprobanteEmisionNotaSalida.listaComprobanteEmisionDetalle)
        //{
        //    BEInventarioDocumReg inventarioDocumReg = new BEInventarioDocumReg
        //    {
        //        codDocumReg = returnValorNS.codRetorno,
        //        strPeriodo = lstInventario[0].Periodo,
        //        codInventario = detalleNS.auxcodInventario,
        //        segUsuarioCrea = comprobanteEmisionNotaSalida.SegUsuarioCrea
        //    };
        //    lstInventarioDocumReg.Add(inventarioDocumReg);
        //}

        // AL FINAL GUARDA LA RELACION INVENTARIO-DOCUMREG
        //inventarioData.InsertInventarioDocumReg(lstInventarioDocumReg);
        //returnValorProcesoCierre.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
        //returnValorProcesoCierre.Message = returnValorProcesoCierre.Message + ", Se han creado documento: " +
        //                        (strTieneNI != string.Empty ? "[" + strTieneNI + "]" : string.Empty) +
        //                        (strTieneNS != string.Empty ? "[" + strTieneNS + "]" : string.Empty);

        public ReturnValor UpdateInventariosCerrarDocum_NI_NS(List<InventarioAux> lstInventario,
            //bool prm_AsientoEnKardex,
            //List<BEDocumentoSerie> listaComprobantesSeries,
            //List<BEDocumentoSerie> listaComprobantesSeriesFiltro,
                                                              BETipoDeCambio itemTiposDeCambio,
                                                              BEImpuesto itemImpuestoVTA,
                                                              BEDocumento itemComprobanteInventario,
            // Documento Nota de Ingreso                                    
                                                              BEDocumento itemComprobanteNotaIngreso,
                                                              BEDocumentoSerie itemSerieNotaIngreso,
                                                              string sNumDocumentoNotaIngres,
            // Documento Nota de Salida
                                                              BEDocumento itemComprobanteNotaSalida,
                                                              BEDocumentoSerie itemSerieNotaSalida,
                                                              string sNumDocumentoNotaSalida,
                                                              int pcodEmpresa, string pSegUsuario,
                                                              out BEComprobanteEmision comprobanteEmisionNotaIngresoLleno,
                                                              out BEComprobanteEmision comprobanteEmisionNotaSalidaLleno)
        {
            ReturnValor returnValorProcesoCierre = new ReturnValor();
            //BEDocumentoSerie itemSerieInventario = null;
            //BEComprobanteEmision comprobanteEmisionInventario = null;
            //// Documento Nota de Ingreso
            BEComprobanteEmision comprobanteEmisionNotaIngreso = null;
            // Documento Nota de Salida
            BEComprobanteEmision comprobanteEmisionNotaSalida = null;
            try
            {

                // Validar el valor del tipo de cambio de la Fecha actual del sistema -->> PARA VALIDAR
                if (itemTiposDeCambio == null)
                {
                    // ASIGNAR a la variable de salida de la NOTA DE SALIDA
                    comprobanteEmisionNotaSalidaLleno = comprobanteEmisionNotaSalida;
                    // ASIGNAR a la variable de salida de la NOTA DE INGRESO
                    comprobanteEmisionNotaIngresoLleno = comprobanteEmisionNotaIngreso;

                    returnValorProcesoCierre.Message = HelpMessages.gc_DOCUM_TipoDeCambio;
                    return returnValorProcesoCierre;
                }

                // Validar si todos lo productos tienen Precio de Venta y Precio de Compra antes de Cerrar Inventario
                if (!ValidarPreciosAntesDeCerrarInventario(lstInventario))
                {
                    // ASIGNAR a la variable de salida de la NOTA DE SALIDA
                    comprobanteEmisionNotaSalidaLleno = comprobanteEmisionNotaSalida;
                    // ASIGNAR a la variable de salida de la NOTA DE INGRESO
                    comprobanteEmisionNotaIngresoLleno = comprobanteEmisionNotaIngreso;

                    returnValorProcesoCierre.Message = HelpMessages.INVENTARIOValidacionCIERREPrecios;
                    return returnValorProcesoCierre;
                }

                // Si el documento de tipo INVENTARIO tiene una serie definida -itemComprobanteNotaSalida == null || listaComprobantesSeriesFiltro.Count != 1 || 
                if (itemComprobanteNotaSalida == null || itemImpuestoVTA == null)
                {
                    // ASIGNAR a la variable de salida de la NOTA DE SALIDA
                    comprobanteEmisionNotaSalidaLleno = comprobanteEmisionNotaSalida;

                    // ASIGNAR a la variable de salida de la NOTA DE INGRESO
                    comprobanteEmisionNotaIngresoLleno = comprobanteEmisionNotaIngreso;

                    returnValorProcesoCierre.Message = HelpMessages.InventarioValidaDocum;
                    return returnValorProcesoCierre;
                }

                List<BEInventarioSerie> lstInventarioSerie = new List<BEInventarioSerie>();
                List<BEInventarioSerie> lstInventarioSerieProdu = null;

                //BEDocumentoSerie itemSerieInventario = null;
                //BEComprobanteEmision comprobanteEmisionInventario = null;
                ////// Documento Nota de Ingreso
                //BEComprobanteEmision comprobanteEmisionNotaIngreso = null;
                //// Documento Nota de Salida
                //BEComprobanteEmision comprobanteEmisionNotaSalida = null;
                // Declaración de Variables
                string strEstadoPSeriadoMercaderiaRegularizar = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Merca_PorRegular);
                string strEstadoPSeriadoMercaderiaRetirar = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Merca_Retirada);
                string strEstadoPSeriadoMercaderiaConsignacion = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Merca_Consignacion);
                //string strCodDocumNotaSalida = ConfigCROM.AppConfig(ConfigTool.DEFAULT_Doc_NotaSalida);
                //string strCodDocumNotaIngreso = ConfigCROM.AppConfig(ConfigTool.DEFAULT_Doc_NotaIngreso);
                //bool ACTUALIZA_KARDEX = false;
                //bool SUCEDE_UPDATE_STOCK_FIS = false;
                //bool SUCEDE_REGIS_TALONARIO_INV = false;

                // Lista los registros de inventario serie por Periodo de inventario y conteo elegido para el cierre
                lstInventarioSerie = objInventarioLogic.ListInventarioSeriePorPeriodo(new BaseFiltroAlmacen
                {
                    perPeriodo = lstInventario[0].Periodo,
                    cntConteo = (int)lstInventario[0].ConteoSel
                });

                //MODALIDAD (0)://Para el caso de NOTA DE INGRESO Y NOTA DE SALIDA
                BEProducto itemProducto = null;
                BEPersona empresa = null;

                //if (listaComprobantesSeriesFiltro.Count == 1)
                //    itemSerieNotaSalida = listaComprobantesSeriesFiltro[0];

                //if (listaComprobantesSeriesFiltro.Count == 1)
                //    itemSerieNotaIngreso = listaComprobantesSeriesFiltro[0];

                //if (itemSerieNotaSalida != null && itemSerieNotaIngreso != null &&
                //    itemComprobanteNotaIngreso != null && itemComprobanteNotaSalida != null)
                //{

                if (itemSerieNotaIngreso.CodigoComprobante == itemComprobanteNotaIngreso.CodigoComprobante &&
                    itemSerieNotaSalida.CodigoComprobante == itemComprobanteNotaSalida.CodigoComprobante)
                {
                    string strEstadoNotaIngreso = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_NotaIngrEstado);
                    string strEstadoNotaSalida = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_NotaSalidaEstado);
                    string strMovimENTRADA = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Movim_Entrada);
                    string strMovimSALIDA = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Movim_Salida);
                    string strMovimMERMA = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Movim_Mermas);
                    string strMovimDEVOL = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Movim_Devolucion);

                    empresa = oPersonasLogic.Find(itemComprobanteNotaIngreso.codEmpresa,
                                                  lstInventario[0].CodigoPersonaEmpre,
                                                  lstInventario[0].segUsuarioCrea);

                    comprobanteEmisionNotaIngreso = LlenarDocumentoNotaIngresoSalida(lstInventario, 
                                                                                     itemTiposDeCambio, 
                                                                                     itemImpuestoVTA, 
                                                                                     oPersonasLogic, 
                                                                                     itemComprobanteNotaIngreso, 
                                                                                     sNumDocumentoNotaIngres, 
                                                                                     empresa, 
                                                                                     itemSerieNotaIngreso.CodigoComprobante, 
                                                                                     strEstadoNotaIngreso, 
                                                                                     strMovimDEVOL, 
                                                                                     "Devolucion",
                                                                                     pcodEmpresa,
                                                                                     pSegUsuario);

                    comprobanteEmisionNotaSalida = LlenarDocumentoNotaIngresoSalida(lstInventario, 
                                                                                    itemTiposDeCambio, 
                                                                                    itemImpuestoVTA, 
                                                                                    oPersonasLogic, 
                                                                                    itemComprobanteNotaSalida, 
                                                                                    sNumDocumentoNotaSalida, 
                                                                                    empresa, 
                                                                                    itemSerieNotaSalida.CodigoComprobante, 
                                                                                    strEstadoNotaSalida, 
                                                                                    strMovimMERMA, 
                                                                                    "Merma",
                                                                                    pcodEmpresa,
                                                                                    pSegUsuario);
                    int CONTA_ITEM = 0;
                    List<BEComprobanteEmisionDetalle> lstDetalleNI = new List<BEComprobanteEmisionDetalle>();
                    List<BEComprobanteEmisionDetalle> lstDetalleNS = new List<BEComprobanteEmisionDetalle>();
                    BEComprobanteEmisionDetalle itemDetalleNI_NS = new BEComprobanteEmisionDetalle();
                    ProductoKardexAux itemProductoKardex = new ProductoKardexAux();
                    List<ProductoKardexAux> lstKardexNI = new List<ProductoKardexAux>();
                    List<ProductoKardexAux> lstKardexNS = new List<ProductoKardexAux>();
                    List<BEProductoSeriado> lstProductoSeriesAgregar = new List<BEProductoSeriado>();
                    List<BEProductoSeriado> lstProductoSeriesRetirar = new List<BEProductoSeriado>();
                    List<BEInventarioSerie> lstInventarioSerieGeneral = new List<BEInventarioSerie>();

                    #region RECORRER cada uno de los registros de INVENTARIOS para actualizar el KARDEX y llenar dcumento  itemDetalleNI_NS

                    foreach (InventarioAux itemInventario in lstInventario)
                    {
                        ++CONTA_ITEM;
                        lstInventarioSerieProdu = lstInventarioSerie.FindAll(x => x.codInventario == itemInventario.codInventario);
                        if (lstInventarioSerieProdu.Count > 0)
                            foreach (BEInventarioSerie itemIS in lstInventarioSerieProdu)
                            {
                                if (itemIS.indExisteFisico)
                                    if (itemIS.objProductoSerie.codRegEstadoMercaderia == strEstadoPSeriadoMercaderiaConsignacion)
                                        itemInventario.Conteo = itemInventario.Conteo - 1;
                            }
                        // Buscar datos del Producto
                        itemProducto = oProductoLogic.Find(new BaseFiltroAlmacen
                        {
                            codEmpresaRUC = itemInventario.CodigoPersonaEmpre,
                            codPuntoVenta = itemInventario.CodigoPuntoVenta,
                            codDeposito = itemInventario.codDeposito,
                            codProducto = itemInventario.codProducto
                        });
                        decimal PRECIO_VENTAS = itemInventario.ValorVenta.Value;
                        decimal PRECIO_COMPRA = itemInventario.ValorCosto.Value;
                        string CODI_ARGUMONEDA = itemInventario.codRegMoneda;

                        if (CODI_ARGUMONEDA != comprobanteEmisionNotaSalida.CodigoArguMoneda)
                        {
                            itemProducto.itemProductoPrecio.ValorCosto = PRECIO_COMPRA * itemTiposDeCambio.CambioCompraGOB;
                            itemProducto.itemProductoPrecio.ValorVenta = PRECIO_COMPRA * itemTiposDeCambio.CambioCompraGOB;
                        }
                        else if (CODI_ARGUMONEDA != comprobanteEmisionNotaIngreso.CodigoArguMoneda)
                        {
                            itemProducto.itemProductoPrecio.ValorCosto = PRECIO_COMPRA * itemTiposDeCambio.CambioCompraGOB;
                            itemProducto.itemProductoPrecio.ValorVenta = PRECIO_COMPRA * itemTiposDeCambio.CambioCompraGOB;
                        }
                        if (itemInventario.StockFisico < itemInventario.Conteo)
                        {
                            if (itemInventario.EsConNumeroSeriado)
                            {
                                lstProductoSeriesAgregar = ProductoSeriadosAgregar(itemInventario, sNumDocumentoNotaIngres, strEstadoPSeriadoMercaderiaRegularizar);
                                itemInventario.lstInventarioSerie = objInventarioLogic.ListInventarioSerie(new BaseFiltroAlmacen
                                {
                                    codInventario = itemInventario.codInventario,
                                    cntConteo = (int)itemInventario.ConteoSel.Value
                                });
                            }
                            itemDetalleNI_NS = LlenarEntidadDocumentoDetalle(itemInventario, itemImpuestoVTA, itemComprobanteNotaIngreso, sNumDocumentoNotaIngres, itemProducto, CONTA_ITEM, itemInventario, false);
                            if (lstProductoSeriesAgregar.Count > 0)
                                itemDetalleNI_NS.listaProductoSeriados.AddRange(lstProductoSeriesAgregar);
                            lstDetalleNI.Add(itemDetalleNI_NS);
                            itemProductoKardex = LlenarEntidadKardex(itemComprobanteInventario, sNumDocumentoNotaIngres, empresa, CONTA_ITEM, itemInventario, itemProducto, itemTiposDeCambio.CambioVentasGOB, strMovimENTRADA, strMovimDEVOL);
                            lstKardexNI.Add(itemProductoKardex);
                        }
                        else if (itemInventario.StockFisico > itemInventario.Conteo)
                        {
                            if (itemInventario.EsConNumeroSeriado)
                            {
                                itemInventario.lstInventarioSerie = objInventarioLogic.ListInventarioSerie(new BaseFiltroAlmacen
                                {
                                    codInventario = itemInventario.codInventario,
                                    cntConteo = (int)itemInventario.ConteoSel.Value
                                });
                                lstProductoSeriesRetirar = ProductoSeriadosRetirar(itemInventario,
                                                                                  sNumDocumentoNotaSalida,
                                                                                  strEstadoPSeriadoMercaderiaRetirar);
                            }
                            itemDetalleNI_NS = LlenarEntidadDocumentoDetalle(itemInventario,
                                                                             itemImpuestoVTA,
                                                                             itemComprobanteNotaSalida,
                                                                             sNumDocumentoNotaSalida,
                                                                             itemProducto,
                                                                             CONTA_ITEM,
                                                                             itemInventario,
                                                                             false);
                            if (lstProductoSeriesRetirar.Count > 0)
                                itemDetalleNI_NS.listaProductoSeriados.AddRange(lstProductoSeriesRetirar);
                            lstDetalleNS.Add(itemDetalleNI_NS);
                            itemProductoKardex = LlenarEntidadKardex(itemComprobanteInventario,
                                                                     sNumDocumentoNotaSalida,
                                                                     empresa,
                                                                     CONTA_ITEM,
                                                                     itemInventario,
                                                                     itemProducto,
                                                                     itemTiposDeCambio.CambioVentasGOB,
                                                                     strMovimSALIDA,
                                                                     strMovimMERMA);
                            lstKardexNS.Add(itemProductoKardex);
                        }

                    }
                    #endregion

                    List<BEInventarioDocumReg> lstInventarioDocumReg = new List<BEInventarioDocumReg>();
                    using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                    {
                        string strTieneNI = string.Empty;
                        string strTieneNS = string.Empty;
                        string strDocumento = string.Empty;
                        ReturnValor returnValorNI = null;
                        if (lstDetalleNI.Count > 0)
                        {
                            comprobanteEmisionNotaIngreso.listaComprobanteEmisionDetalle = lstDetalleNI;
                            // Totalizar el Documento NOTA DE INGRESO
                            TotalizarDocumento(comprobanteEmisionNotaIngreso, lstDetalleNI);
                        }
                        if (returnValorNI != null)
                            if (returnValorNI.Exitosa == false)
                                throw new Exception(returnValorNI.Message);

                        ReturnValor returnValorNS = null;
                        if (lstDetalleNS.Count > 0)
                        {
                            comprobanteEmisionNotaSalida.listaComprobanteEmisionDetalle = lstDetalleNS;
                            // Totalizar el Documento NOTA DE SALIDA
                            TotalizarDocumento(comprobanteEmisionNotaSalida, lstDetalleNS);


                        }
                        if (returnValorNS != null)
                            if (returnValorNS.Exitosa == false)
                                throw new Exception(returnValorNS.Message);

                        foreach (InventarioAux itemInventario in lstInventario)
                        {
                            // Actualiza en el INVENTARIO el registro
                            returnValorProcesoCierre = objInventarioLogic.UpdateInventariosCerrar(itemInventario);
                            if (!returnValorProcesoCierre.Exitosa)
                            {
                                // ASIGNAR a la variable de salida de la NOTA DE SALIDA
                                comprobanteEmisionNotaSalidaLleno = comprobanteEmisionNotaSalida;

                                // ASIGNAR a la variable de salida de la NOTA DE INGRESO
                                comprobanteEmisionNotaIngresoLleno = comprobanteEmisionNotaIngreso;

                                return returnValorProcesoCierre;
                            }

                        }

                        //inventarioData.InsertInventarioDocumReg(lstInventarioDocumReg);

                        //returnValorProcesoCierre.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        //returnValorProcesoCierre.Message = returnValorProcesoCierre.Message + ", Se han creado documento: " +
                        //                      (strTieneNI != string.Empty ? "[" + strTieneNI + "]" : string.Empty) +
                        //                      (strTieneNS != string.Empty ? "[" + strTieneNS + "]" : string.Empty);
                        tx.Complete();
                    }
                }
                //}
                //else
                //{
                //    returnValorProcesoCierre.Message = HelpMessages.InventarioValidaDocumentoNI_NS;
                //}

            }
            catch (Exception ex)
            {
                returnValorProcesoCierre = HelpException.mTraerMensaje(ex);
            }

            //  ASIGNAR a la variable de salida de la
            comprobanteEmisionNotaSalidaLleno = comprobanteEmisionNotaSalida;

            // ASIGNAR a la variable de salida de la NOTA DE INGRESO
            comprobanteEmisionNotaIngresoLleno = comprobanteEmisionNotaIngreso;

            return returnValorProcesoCierre;
        }

// Obtener los documentos
//List<BEDocumentoSerie> listaComprobantesSeries = new List<BEDocumentoSerie>();
//List<BEDocumentoSerie> listaComprobantesSeriesFiltro = new List<BEDocumentoSerie>();
// Obtiene los numeros de series de los documentos a emitir de forma automática por el proceso
//listaComprobantesSeries = new DocumentoLogic().ListDocumentoSeriePorUsuario(new BaseFiltro
//{
//    codPerEmpresa = objBaseFiltro.codPerEmpresa,
//    codPuntoVenta = objBaseFiltro.codPuntoVenta,
//    desNombre = string.Empty,
//    indEstado = true
//});

//BETipoDeCambio itemTiposDeCambio = new BETipoDeCambio();
//// Obtener el valor del tipo de cambio de la Fecha actual del sistema -->> PARA VALIDAR
//itemTiposDeCambio = new TipoDeCambioLogic().Find(new BaseFiltro
//{
//    fecInicioDate = DateTime.Now,
//    codRegMoneda = strMonedaExtranjera
//});

////DocumentoLogic oComprobantesLogic = new DocumentoLogic();
//string strCodDocumNotaSalida = ConfigCROM.AppConfig(ConfigTool.DEFAULT_Doc_NotaSalida);
//string strCodDocumNotaIngreso = ConfigCROM.AppConfig(ConfigTool.DEFAULT_Doc_NotaIngreso);

//// Obtener informacion de los documentos a generar de forma automática
// Documento Nota de Ingreso
//BEDocumento itemComprobanteNotaIngreso = new BEDocumento();
//itemComprobanteNotaIngreso = oComprobantesLogic.Find(strCodDocumNotaIngreso);
// Documento Nota de Salida
//BEDocumento itemComprobanteNotaSalida = new BEDocumento();
//itemComprobanteNotaSalida = oComprobantesLogic.Find(strCodDocumNotaSalida);

        //ReturnValor returnValorNS = null;
        //ReturnValor returnValorNI = null;
        // string sNumDocumentoNotaIngres = string.Empty;
        //string sNumDocumentoNotaSalida = string.Empty;
        //returnValorNI = oComprobantesLogic.UltimoNumeroDocumento(itemSerieNotaIngreso.CodigoTalonario);
        //if (returnValorNI.Exitosa)
        //    sNumDocumentoNotaIngres = HelpDocumentos.Tipos.NIN.ToString() + returnValorNI.CodigoRetorno.Substring(0, 3) + returnValorNI.CodigoRetorno.Substring(4, 10);
        //else
        //    return returnValorNI;
        //returnValorNS = oComprobantesLogic.UltimoNumeroDocumento(itemSerieNotaSalida.CodigoTalonario);
        //if (returnValorNS.Exitosa)
        //    sNumDocumentoNotaSalida = HelpDocumentos.Tipos.NSL.ToString() + returnValorNS.CodigoRetorno.Substring(0, 3) + returnValorNS.CodigoRetorno.Substring(4, 10);
        //else
        //    return returnValorNS;

        //itemComprobanteNotaIngreso.NumeroComprobante = sNumDocumentoNotaIngres,
        //itemComprobanteNotaSalida.NumeroComprobante = sNumDocumentoNotaSalida,

        // ComprobanteEmisionDetalleData objComprobanteEmisionDetalleData = new ComprobanteEmisionDetalleData();

        //// Registra la cabecera de la NOTA DE INGRESO
        //int intResultadoNIN = objComprobanteEmisionData.Insert(comprobanteEmisionNotaIngreso);
        //foreach (BEComprobanteEmisionDetalle objComprobanteEmisionDetalle in comprobanteEmisionNotaIngreso.listaComprobanteEmisionDetalle)
        //    objComprobanteEmisionDetalle.codDocumReg = intResultadoNIN;
        //int intResultadoNINDeta = objComprobanteEmisionDetalleData.Insert(comprobanteEmisionNotaIngreso.listaComprobanteEmisionDetalle).Value;
        //// Actualizar el registro de serie de DOCUMENTOS
        //bool SUCEDE_REGIS_TALONARIO_INV = new DocumentoSerieData().UpdateUltimo(new BEDocumentoSerie
        //{
        //    CodigoTalonario = itemSerieNotaIngreso.CodigoTalonario,
        //    segUsuarioEdita = comprobanteEmisionNotaIngreso.SegUsuarioCrea,
        //    segMaquinaEdita = "MaquinaNIN_NSL"
        //});

        // // Registra la cabecera de la NOTA DE SALIDA
        //int intResultadoNSL = objComprobanteEmisionData.Insert(comprobanteEmisionNotaSalida);
        //foreach (BEComprobanteEmisionDetalle objComprobanteEmisionDetalle in comprobanteEmisionNotaSalida.listaComprobanteEmisionDetalle)
        //    objComprobanteEmisionDetalle.codDocumReg = intResultadoNSL;
        //int intResultadoNSLDeta = objComprobanteEmisionDetalleData.Insert(comprobanteEmisionNotaSalida.listaComprobanteEmisionDetalle).Value;

        //// Actualizar el registro de serie de DOCUMENTOS
        //bool SUCEDE_REGIS_TALONARIO_INV = new DocumentoSerieData().UpdateUltimo(new BEDocumentoSerie
        //{
        //    CodigoTalonario = itemSerieNotaSalida.CodigoTalonario,
        //    segUsuarioEdita = comprobanteEmisionNotaSalida.SegUsuarioCrea,
        //    segMaquinaEdita = "Maquina_Inventar."
        //});
        public ReturnValor GenerarNIN_NSLCerrarInventario(BaseFiltroAlmacenCerrarInventario objBaseFiltro,
                                                          //List<BEDocumentoSerie> listaComprobantesSeries,
                                                          //List<BEDocumentoSerie> listaComprobantesSeriesFiltro,
                                                          //BEDocumento itemComprobanteNotaSalida,
                                                          //BEDocumento itemComprobanteNotaIngreso,
                                                          BEDocumentoSerie itemSerieNotaIngreso,
                                                          BEDocumentoSerie itemSerieNotaSalida, 
                                                          BETipoDeCambio itemTiposDeCambio,
                                                          string strCodDocumNotaSalida,
                                                          string strCodDocumNotaIngreso,
                                                          out BEComprobanteEmision comprobanteEmisionNotaIngresoLleno,
                                                          out BEComprobanteEmision comprobanteEmisionNotaSalidaLleno)
        {
            // Documento Nota de Ingreso
            //BEDocumento itemComprobanteNotaIngreso = new BEDocumento();
            //BEDocumentoSerie itemSerieNotaIngreso = null;
            BEComprobanteEmision comprobanteEmisionNotaIngreso = null;
            // Documento Nota de Salida
            //BEDocumento itemComprobanteNotaSalida = new BEDocumento();
            //BEDocumentoSerie itemSerieNotaSalida = null;
            BEComprobanteEmision comprobanteEmisionNotaSalida = null;
            //List<BEDocumentoSerie> listaComprobantesSeries = new List<BEDocumentoSerie>();
            //List<BEDocumentoSerie> listaComprobantesSeriesFiltro = new List<BEDocumentoSerie>();

            ReturnValor objReturnValor = null;
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    // Objetos Capa de Negocio
                    ConfiguracionLogic cnf = new ConfiguracionLogic();
                    List<BEConfiguracion> lstConfiguracion = new List<BEConfiguracion>();
                    lstConfiguracion = cnf.List(new BaseFiltroConfiguracion
                    {
                        codEmpresa = objBaseFiltro.codEmpresa,
                        segUsuarioActual = objBaseFiltro.UserActual,
                        
                        codKeyConfig = string.Empty,
                        desNombre = string.Empty
                    });

                    // Obtener valores de la colección
                    string strNotaSalidaEstado = ConfigCROM.AppConfig(objBaseFiltro.codEmpresa,ConfigTool.DEFAULT_NotaSalidaEstado);
                    string strNotaIngresEstado = ConfigCROM.AppConfig(objBaseFiltro.codEmpresa, ConfigTool.DEFAULT_NotaIngrEstado);
                    string strDestinoInterno = ConfigCROM.AppConfig(objBaseFiltro.codEmpresa, ConfigTool.DEFAULT_DestinoInterno);
                    string strMonedaNacional = ConfigCROM.AppConfig(objBaseFiltro.codEmpresa, ConfigTool.DEFAULT_MonedaNac);
                    string strMonedaExtranjera = ConfigCROM.AppConfig(objBaseFiltro.codEmpresa, ConfigTool.DEFAULT_MonedaInt);
                    int strCodRegDomiFiscal = (int)TipoDomicilio.FISCAL_PRINCIPAL; 
                    string strCodRegDevolucion = ConfigCROM.AppConfig(objBaseFiltro.codEmpresa, ConfigTool.DEFAULT_Movim_Devolucion);
                    string strCodRegMermas = ConfigCROM.AppConfig(objBaseFiltro.codEmpresa, ConfigTool.DEFAULT_Movim_Mermas);

                    //// Obtiene los numeros de series de los documentos a emitir de forma automática por el proceso
                    //listaComprobantesSeries = new DocumentoLogic().ListDocumentoSeriePorUsuario(new BaseFiltro
                    //{
                    //    codPerEmpresa = objBaseFiltro.codPerEmpresa,
                    //    codPuntoVenta = objBaseFiltro.codPuntoVenta,
                    //    desNombre = string.Empty,
                    //    indEstado = true
                    //});

                    //BETipoDeCambio itemTiposDeCambio = new BETipoDeCambio();
                    //// Obtener el valor del tipo de cambio de la Fecha actual del sistema -->> PARA VALIDAR
                    //itemTiposDeCambio = new TipoDeCambioLogic().Find(new BaseFiltro
                    //{
                    //    fecInicioDate = DateTime.Now,
                    //    codRegMoneda = strMonedaExtranjera
                    //});
                    // Obtener datos de la entidad aquien se emitira el documento
                    BEPersona objPersona = new BEPersona();
                    objPersona = new PersonasLogic().Find(objBaseFiltro.codEmpresa, 
                                                          objBaseFiltro.codEmpresaRUC, 
                                                          objBaseFiltro.UserActual);

                    ////DocumentoLogic oComprobantesLogic = new DocumentoLogic();
                    //string strCodDocumNotaSalida = ConfigCROM.AppConfig(ConfigTool.DEFAULT_Doc_NotaSalida);
                    //string strCodDocumNotaIngreso = ConfigCROM.AppConfig(ConfigTool.DEFAULT_Doc_NotaIngreso);

                    // Crear NOTAS DE INGRESO o SALIDA por SOBRANTES o MERMAS
                    //ReturnValor returnValorNS = null;
                    //ReturnValor returnValorNI = null;
                    List<InventarioAux> lstInventarioSobranteMerma = new List<InventarioAux>();

                    BaseFiltroAlmacenMermaSobrante objBaseFiltroMS = new BaseFiltroAlmacenMermaSobrante
                    {
                        codEmpresaRUC = objBaseFiltro.codEmpresaRUC,
                        perPeriodo = objBaseFiltro.perPeriodo,
                        codDeposito = objBaseFiltro.codAlmacen,
                        indEstado = false
                    };
                    objBaseFiltro.indEstado = false;
                    lstInventarioSobranteMerma = objInventarioLogic.ListInventariosMermaSobrante(objBaseFiltroMS);
                    //// Obtener informacion de los documentos a generar de forma automática
                    //itemComprobanteNotaIngreso = oComprobantesLogic.Find(strCodDocumNotaIngreso);
                    //itemComprobanteNotaSalida = oComprobantesLogic.Find(strCodDocumNotaSalida);
                    //listaComprobantesSeriesFiltro = listaComprobantesSeries.FindAll(x => x.CodigoPersonaEmpre == objBaseFiltro.codPerEmpresa &&
                    //                                                                     x.CodigoPuntoVenta == objBaseFiltro.codPuntoVenta &&
                    //                                                                     x.CodigoComprobante == strCodDocumNotaSalida &&
                    //                                                                     x.Estado == true);
                    //if (listaComprobantesSeriesFiltro.Count == 1)
                    //    itemSerieNotaSalida = listaComprobantesSeriesFiltro[0];
                    //listaComprobantesSeriesFiltro = listaComprobantesSeries.FindAll(x => x.CodigoPersonaEmpre == objBaseFiltro.codPerEmpresa &&
                    //                                                                     x.CodigoPuntoVenta == objBaseFiltro.codPuntoVenta &&
                    //                                                                     x.CodigoComprobante == strCodDocumNotaIngreso &&
                    //                                                                     x.Estado == true);
                    //if (listaComprobantesSeriesFiltro.Count == 1)
                    //    itemSerieNotaIngreso = listaComprobantesSeriesFiltro[0];

                    //if (itemSerieNotaSalida != null && itemSerieNotaIngreso != null &&
                    //    itemComprobanteNotaIngreso != null && itemComprobanteNotaSalida != null)
                    //{
                    //string sNumDocumentoNotaIngres = string.Empty;
                    //string sNumDocumentoNotaSalida = string.Empty;
                    //returnValorNI = oComprobantesLogic.UltimoNumeroDocumento(itemSerieNotaIngreso.CodigoTalonario);
                    //if (returnValorNI.Exitosa)
                    //    sNumDocumentoNotaIngres = HelpDocumentos.Tipos.NIN.ToString() + returnValorNI.CodigoRetorno.Substring(0, 3) + returnValorNI.CodigoRetorno.Substring(4, 10);
                    //else
                    //    return returnValorNI;
                    //returnValorNS = oComprobantesLogic.UltimoNumeroDocumento(itemSerieNotaSalida.CodigoTalonario);
                    //if (returnValorNS.Exitosa)
                    //    sNumDocumentoNotaSalida = HelpDocumentos.Tipos.NSL.ToString() + returnValorNS.CodigoRetorno.Substring(0, 3) + returnValorNS.CodigoRetorno.Substring(4, 10);
                    //else
                    //    return returnValorNS;

                    string strcodAtribNUM_RUC = ConfigCROM.AppConfig(objBaseFiltro.codEmpresa,
                                                                     ConfigTool.DEFAULT_Atributo_NumerRUC);
                    //ComprobanteEmisionData objComprobanteEmisionData = new ComprobanteEmisionData();

                    comprobanteEmisionNotaIngreso = new BEComprobanteEmision
                    {
                        CodigoPersonaEmpre = objBaseFiltro.codEmpresaRUC,
                        CodigoPuntoVenta = objBaseFiltro.codPuntoVenta,
                        CodigoComprobante = strCodDocumNotaIngreso,
                        //NumeroComprobante = sNumDocumentoNotaIngres,
                        CodigoArguEstadoDocu = strNotaIngresEstado, //"GCMPB012002",
                        CodigoArguDestinoComp = strDestinoInterno, //"GDSTC003",
                        CodigoPersonaEntidad = objBaseFiltro.codEmpresaRUC,
                        codEmpleado = objBaseFiltro.codEmpleado,
                        FechaDeEmision = DateTime.Now,
                        FechaDeVencimiento = DateTime.Now,
                        CodigoArguMoneda = strMonedaNacional, //"GTMND001",
                        ValorTipoCambioCMP = itemTiposDeCambio.CambioCompraGOB,
                        ValorTipoCambioVTA = itemTiposDeCambio.CambioVentasGOB,
                        EntidadRazonSocial = objPersona.RazonSocial,
                        EntidadDireccion = objPersona.listaPersonasDomicilio.Find(x => x.codRegTipo == strCodRegDomiFiscal).gloDireccionSunat, 
                        EntidadNumeroRUC = objPersona.listaPersonasAtributos.Find(x => x.CodigoArguTipoAtributo == strcodAtribNUM_RUC).DescripcionAtributo, //"PATRB003001"
                        CodigoArguTipoDomicil = strCodRegDomiFiscal.ToString(),
                        CodigoArguUbigeo = objPersona.listaPersonasDomicilio.Find(x => x.codRegTipo == strCodRegDomiFiscal).codUbigeoCode,
                        EntidadDireccionUbigeo = objPersona.listaPersonasDomicilio.Find(x => x.codRegTipo == strCodRegDomiFiscal).codUbigeoNombre, 
                        Observaciones = "¡ [ DEVOLUCION ]¡ Proceso automático de reguralización de inventarios..!" + DateTime.Now.ToLongDateString(),
                        codEmpleadoVendedor = 1,
                        CodigoArguDepositoDesti = objBaseFiltro.codAlmacen,
                        DocEsGravado = false,
                        DocExigeDocAnexo = false,
                        DocEsFacturable = false,
                        CodigoArguTipoDeOperacion = strCodRegDevolucion, // "GTMOV005", 
                        Estado = true,
                        SegUsuarioCrea = objBaseFiltro.UserActual,
                        SegFechaCrea = DateTime.Now,
                        SegUsuarioEdita = objBaseFiltro.UserActual,
                        SegFechaEdita = DateTime.Now,
                        CodigoArguDepositoOrigen = objBaseFiltro.codAlmacen,
                        indInternacional = false,
                    };
                    comprobanteEmisionNotaSalida = new BEComprobanteEmision
                    {
                        CodigoPersonaEmpre = objBaseFiltro.codEmpresaRUC,
                        CodigoPuntoVenta = objBaseFiltro.codPuntoVenta,
                        CodigoComprobante = strCodDocumNotaSalida,
                        //NumeroComprobante = sNumDocumentoNotaSalida,
                        CodigoArguEstadoDocu = strNotaSalidaEstado,// "GCMPB013002",
                        CodigoArguDestinoComp = strDestinoInterno, //"GDSTC003",
                        CodigoPersonaEntidad = objBaseFiltro.codEmpresaRUC,
                        codEmpleado = objBaseFiltro.codEmpleado,
                        FechaDeEmision = DateTime.Now,
                        FechaDeVencimiento = DateTime.Now,
                        CodigoArguMoneda = strMonedaNacional, //"GTMND001",
                        ValorTipoCambioCMP = itemTiposDeCambio.CambioCompraGOB,
                        ValorTipoCambioVTA = itemTiposDeCambio.CambioVentasGOB,
                        EntidadRazonSocial = objPersona.RazonSocial,
                        EntidadDireccion = objPersona.listaPersonasDomicilio.Find(x => x.codRegTipo == strCodRegDomiFiscal).gloDireccionSunat, 
                        EntidadNumeroRUC = objPersona.listaPersonasAtributos.Find(x => x.CodigoArguTipoAtributo == strcodAtribNUM_RUC).DescripcionAtributo, //"PATRB003001"
                        CodigoArguTipoDomicil = strCodRegDomiFiscal.ToString(),
                        CodigoArguUbigeo = objPersona.listaPersonasDomicilio.Find(x => x.codRegTipo == strCodRegDomiFiscal).codUbigeoCode, 
                        EntidadDireccionUbigeo = objPersona.listaPersonasDomicilio.Find(x => x.codRegTipo == strCodRegDomiFiscal).codUbigeoNombre,
                        Observaciones = "¡ [ MERMA-PERDIDA ]¡ Proceso automático de reguralizacion de inventarios..!" + DateTime.Now.ToLongDateString(),
                        codEmpleadoVendedor = 1,
                        CodigoArguDepositoDesti = objBaseFiltro.codAlmacen,
                        DocEsGravado = false,
                        DocExigeDocAnexo = false,
                        DocEsFacturable = false,
                        CodigoArguTipoDeOperacion = strCodRegMermas, // "GTMOV013",
                        Estado = true,
                        SegUsuarioCrea = objBaseFiltro.UserActual,
                        SegFechaCrea = DateTime.Now,
                        SegUsuarioEdita = objBaseFiltro.UserActual,
                        SegFechaEdita = DateTime.Now,
                        CodigoArguDepositoOrigen = objBaseFiltro.codAlmacen,
                        indInternacional = false,
                    };

                    foreach (InventarioAux objInventario in lstInventarioSobranteMerma)
                    {
                        if (objInventario.SALDO_StockMerma > 0)
                        {
                            comprobanteEmisionNotaSalida.listaComprobanteEmisionDetalle.Add(new BEComprobanteEmisionDetalle
                            {
                                CodigoItemDetalle = (comprobanteEmisionNotaSalida.listaComprobanteEmisionDetalle.Count + 1).ToString().PadLeft(3, '0'),
                                CodigoArguUnidadMed = objInventario.codRegUnidadMedida,
                                CodigoArguTipoProducto = objInventario.codRegTipoProducto,
                                CantiDecimales = 3,
                                IncluyeIGV = false,
                                Cantidad = objInventario.SALDO_StockMerma,
                                UnitDescuento = 0,
                                UnitValorCosto = objInventario.ValorCosto.Value,
                                UnitPrecioBruto = objInventario.ValorCosto.Value,
                                UnitPrecioSinIGV = objInventario.ValorCosto.Value,
                                UnitValorDscto = 0,
                                UnitValorVenta = objInventario.ValorCosto.Value,
                                UnitValorIGV = comprobanteEmisionNotaSalida.ValorIGV * objInventario.ValorCosto.Value,
                                TotItemValorBruto = objInventario.ValorCosto.Value * objInventario.SALDO_StockMerma,
                                TotItemValorVenta = objInventario.ValorCosto.Value * objInventario.SALDO_StockMerma,
                                TotItemValorIGV = comprobanteEmisionNotaSalida.ValorIGV * (objInventario.SALDO_StockMerma * objInventario.ValorCosto.Value),
                                Descripcion = objInventario.CodigoProductoNombre,
                                EsVerificarStock = true,
                                codEmpleadoVendedor = comprobanteEmisionNotaSalida.codEmpleado,
                                SegUsuarioCrea = comprobanteEmisionNotaSalida.SegUsuarioCrea,
                                SegUsuarioEdita = comprobanteEmisionNotaSalida.SegUsuarioCrea,
                                SegFechaCrea = DateTime.Now,
                                codProducto = objInventario.codProducto,
                            });
                        }
                        else if (objInventario.SALDO_StockSobrante > 0)
                        {
                            comprobanteEmisionNotaIngreso.listaComprobanteEmisionDetalle.Add(new BEComprobanteEmisionDetalle
                            {
                                CodigoItemDetalle = (comprobanteEmisionNotaIngreso.listaComprobanteEmisionDetalle.Count + 1).ToString().PadLeft(3, '0'),
                                CodigoArguUnidadMed = objInventario.codRegUnidadMedida,
                                CodigoArguTipoProducto = objInventario.codRegTipoProducto,
                                CantiDecimales = 3,
                                IncluyeIGV = false,
                                Cantidad = objInventario.SALDO_StockSobrante,
                                UnitDescuento = 0,
                                UnitValorCosto = objInventario.ValorCosto.Value,
                                UnitPrecioBruto = objInventario.ValorCosto.Value,
                                UnitPrecioSinIGV = objInventario.ValorCosto.Value,
                                UnitValorDscto = 0,
                                UnitValorVenta = objInventario.ValorCosto.Value,
                                UnitValorIGV = comprobanteEmisionNotaIngreso.ValorIGV * objInventario.ValorCosto.Value,
                                TotItemValorBruto = objInventario.ValorCosto.Value * objInventario.SALDO_StockSobrante,
                                TotItemValorVenta = objInventario.ValorCosto.Value * objInventario.SALDO_StockSobrante,
                                TotItemValorIGV = comprobanteEmisionNotaIngreso.ValorIGV * (objInventario.SALDO_StockSobrante * objInventario.ValorCosto.Value),
                                Descripcion = objInventario.CodigoProductoNombre,
                                EsVerificarStock = true,
                                codEmpleadoVendedor = comprobanteEmisionNotaIngreso.codEmpleado,
                                SegUsuarioCrea = comprobanteEmisionNotaIngreso.SegUsuarioCrea,
                                SegUsuarioEdita = comprobanteEmisionNotaIngreso.SegUsuarioCrea,
                                SegFechaCrea = DateTime.Now,
                                codProducto = objInventario.codProducto,
                            });
                        }
                    }

                    //ComprobanteEmisionDetalleData objComprobanteEmisionDetalleData = new ComprobanteEmisionDetalleData();

                    if (comprobanteEmisionNotaIngreso.listaComprobanteEmisionDetalle.Count > 0)
                    {
                        // Totalizar el Documento NOTA DE INGRESO
                        TotalizarDocumento(comprobanteEmisionNotaIngreso, comprobanteEmisionNotaIngreso.listaComprobanteEmisionDetalle);

                        //// Registra la cabecera de la NOTA DE INGRESO
                        //int intResultadoNIN = objComprobanteEmisionData.Insert(comprobanteEmisionNotaIngreso);
                        //foreach (BEComprobanteEmisionDetalle objComprobanteEmisionDetalle in comprobanteEmisionNotaIngreso.listaComprobanteEmisionDetalle)
                        //    objComprobanteEmisionDetalle.codDocumReg = intResultadoNIN;
                        //int intResultadoNINDeta = objComprobanteEmisionDetalleData.Insert(comprobanteEmisionNotaIngreso.listaComprobanteEmisionDetalle).Value;

                        //// Actualizar el registro de serie de DOCUMENTOS

                        //bool SUCEDE_REGIS_TALONARIO_INV = new DocumentoSerieData().UpdateUltimo(new BEDocumentoSerie
                        //{
                        //    CodigoTalonario = itemSerieNotaIngreso.CodigoTalonario,
                        //    segUsuarioEdita = comprobanteEmisionNotaIngreso.SegUsuarioCrea,
                        //    segMaquinaEdita = "MaquinaNIN_NSL"
                        //});
                    }

                    if (comprobanteEmisionNotaSalida.listaComprobanteEmisionDetalle.Count > 0)
                    {
                        // Totalizar el Documento NOTA DE SALIDA
                        TotalizarDocumento(comprobanteEmisionNotaSalida, comprobanteEmisionNotaSalida.listaComprobanteEmisionDetalle);

                        //// Registra la cabecera de la NOTA DE SALIDA
                        //int intResultadoNSL = objComprobanteEmisionData.Insert(comprobanteEmisionNotaSalida);
                        //foreach (BEComprobanteEmisionDetalle objComprobanteEmisionDetalle in comprobanteEmisionNotaSalida.listaComprobanteEmisionDetalle)
                        //    objComprobanteEmisionDetalle.codDocumReg = intResultadoNSL;
                        //int intResultadoNSLDeta = objComprobanteEmisionDetalleData.Insert(comprobanteEmisionNotaSalida.listaComprobanteEmisionDetalle).Value;

                        //// Actualizar el registro de serie de DOCUMENTOS
                        //bool SUCEDE_REGIS_TALONARIO_INV = new DocumentoSerieData().UpdateUltimo(new BEDocumentoSerie
                        //{
                        //    CodigoTalonario = itemSerieNotaSalida.CodigoTalonario,
                        //    segUsuarioEdita = comprobanteEmisionNotaSalida.SegUsuarioCrea,
                        //    segMaquinaEdita = "Maquina_Inventar."
                        //});
                    }


                    objReturnValor = new ReturnValor();
                    objReturnValor.Exitosa = true;
                    objReturnValor.Message = HelpMessages.VALIDACIONProceso;

                    // Se completa el proceso de TRANSACCION
                    tx.Complete();
                }
            }
            catch (Exception ex)
            {
                objReturnValor = new ReturnValor();
                objReturnValor.Message = ex.Message;
            }
            // DEVOLVER el documento NOTA DE INGRESO con informacion completada
            comprobanteEmisionNotaIngresoLleno = comprobanteEmisionNotaIngreso;
            // DEVOLVER el documento NOTA DE SALIDA con informacion completada
            comprobanteEmisionNotaSalidaLleno = comprobanteEmisionNotaSalida;

            return objReturnValor;

        }

        //DocumentoLogic oComprobantesLogic = new DocumentoLogic();
        //itemComprobantes = oComprobantesLogic.Find(ConfigCROM.AppConfig(ConfigTool.DEFAULT_Doc_Inventarios));

        //ComprobanteEmisionLogic oComprobanteEmisionLogic = new ComprobanteEmisionLogic();
        //BEComprobanteEmision itemComprobanteEmisionINV = new BEComprobanteEmision();
        //itemComprobanteEmision = oComprobanteEmisionLogic.FindcodDocumReg(listaProductoKardex[0].codDocumReg);

         //itemComprobanteEmisionINV.CodigoArguAnulacion = itemComprobantesINV.CodigoArguEstANUDefault;
         //itemComprobanteEmisionINV.FechaDeAnulacion = DateTime.Now;
         //returnValor = oComprobanteEmisionLogic.UpdateAnulacion(itemComprobanteEmisionINV, itemComprobantesINV);


        public ReturnValor UpdateInventariosDeshacerCerrar(List<InventarioAux> listaInventario,
                                                           BEDocumento itemComprobantesINV,
                                                           out int codDocumReg)
        {
            ReturnValor returnValor = new ReturnValor();
            ReturnValor returnValorCerrarDeshacer = new ReturnValor();
            int codDocumRegLleno = 0;
            try
            {
                bool SUCEDE_DELET_KAR = false;
                bool SUCEDE_UPDATE_KARDEX = false;
                bool SUCEDE_UPDATE_STOCK_FIS = false;
                using (TransactionScope txDeshaceInv = new TransactionScope(TransactionScopeOption.Required))
                {
                    List<ProductoKardexAux> listaProductoKardex = new List<ProductoKardexAux>();
                    ProductoKardexData oProductoKardexData = new ProductoKardexData();
                    ProductoExistenciaData oProductoExistenciasData = new ProductoExistenciaData();
                    //DocumentoLogic oComprobantesLogic = new DocumentoLogic();
                    //ComprobanteEmisionLogic oComprobanteEmisionLogic = new ComprobanteEmisionLogic();
                    //BEDocumento itemComprobantesINV = new BEDocumento();
                    //BEComprobanteEmision itemComprobanteEmisionINV = new BEComprobanteEmision();
                    BEProducto itemProducto = new BEProducto();
                    ProductoLogic oProductoLogic = new ProductoLogic();

                    //itemComprobantes = oComprobantesLogic.Find(ConfigCROM.AppConfig(ConfigTool.DEFAULT_Doc_Inventarios));
                    string strDocumentoINV = ConfigCROM.AppConfig(itemComprobantesINV.codEmpresa,
                                                                  ConfigTool.DEFAULT_Doc_Inventarios);
                    itemComprobantesINV.IncidenciaEnStocks = 0;
                    listaProductoKardex = oProductoKardexData.ListInventariado(new BaseFiltroAlmacen
                    {
                        codEmpresaRUC = listaInventario[0].CodigoPersonaEmpre,
                        codPuntoVenta = listaInventario[0].CodigoPuntoVenta,
                        codDeposito = listaInventario[0].codDeposito,
                        codDocumento = strDocumentoINV,
                        codRegTipoMovimiUno = string.Empty
                    });
                    if (listaProductoKardex.Count == 0)
                    {
                        returnValor.Message = string.Format(HelpMessages.gc_DOCUM_NoRegistrado, strDocumentoINV);
                        codDocumReg = codDocumRegLleno;
                        return returnValor;
                    }
                    string p_numDocumento = listaProductoKardex[0].numDocumento;

                    codDocumRegLleno = listaProductoKardex[0].codDocumReg;
                    //itemComprobanteEmision = oComprobanteEmisionLogic.FindcodDocumReg(listaProductoKardex[0].codDocumReg);
                    //itemComprobanteEmisionINV.CodigoArguAnulacion = itemComprobantesINV.CodigoArguEstANUDefault;
                    //itemComprobanteEmisionINV.FechaDeAnulacion = DateTime.Now;
                    //returnValor = oComprobanteEmisionLogic.UpdateAnulacion(itemComprobanteEmisionINV, itemComprobantesINV);

                    foreach (ProductoKardexAux produtoKardex in listaProductoKardex)
                    {
                        SUCEDE_DELET_KAR = oProductoKardexData.Delete(new BaseFiltroAlmacen
                        {
                            codDocumRegDetalle = produtoKardex.codDocumRegDetalle,
                            codDeposito = listaInventario[0].codDeposito
                        });
                    }

                    int CONTA_ITEM = 0;
                    foreach (InventarioAux itemInventario in listaInventario)
                    {
                        ++CONTA_ITEM;
                        SUCEDE_UPDATE_KARDEX = oProductoKardexData.UpdateKardexCierreDeshacer(new BaseFiltroAlmacen
                        {
                            codEmpresaRUC = itemInventario.CodigoPersonaEmpre,
                            codPuntoVenta = itemInventario.CodigoPuntoVenta,
                            codDeposito = itemInventario.codDeposito,
                            codProducto = itemInventario.codProducto,
                            segUsuarioEdita = itemInventario.segUsuarioEdita,
                            perPeriodo = itemInventario.Periodo
                        });
                        decimal? prm_SALDO_StockMerma = 0;
                        decimal? prm_SALDO_StockSobrante = 0;
                        if (itemInventario.cntOrigStockFisico > 0)
                            SUCEDE_UPDATE_STOCK_FIS = oProductoExistenciasData
                                                     .UpdateStockFisicoInventarioAnterior(new BEProductoExistenciaStockUpdate
                            {
                                codProducto = itemInventario.codProducto,
                                codDeposito = itemInventario.codDeposito,
                                cntStockFisico = itemInventario.cntOrigStockFisico,
                                cntStockMerma = itemInventario.cntOrigStockMerma,
                                cntStockSobrante = itemInventario.cntOrigStockSobrante,
                                segUsuarioEdita = itemInventario.segUsuarioEdita
                            });

                        itemInventario.SALDO_StockMerma = prm_SALDO_StockMerma == null ? 0 : prm_SALDO_StockMerma.Value;
                        itemInventario.SALDO_StockSobrante = prm_SALDO_StockSobrante == null ? 0 : prm_SALDO_StockSobrante.Value;

                        // Buscar datos del Producto 
                        returnValorCerrarDeshacer  = objInventarioLogic.UpdateInventariosCerrarDeshacer(itemInventario);
                    }

                    // Guardar registros de Kardex por cada item del Detalle
                    if (returnValor.Exitosa && SUCEDE_UPDATE_KARDEX &&
                        SUCEDE_DELET_KAR && returnValorCerrarDeshacer.Exitosa &&
                        SUCEDE_UPDATE_STOCK_FIS)
                    {
                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        returnValor.Message = returnValor.Message + ", " + HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                        txDeshaceInv.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                returnValor = HelpException.mTraerMensaje(ex);
            }
            codDocumReg = codDocumRegLleno;
            return returnValor;
        }


        #region METODOS PRIVADOS del PROCESO CIERRE DE INVENTARIO

        private static List<BEProductoSeriado> ProductoSeriadosAgregar(InventarioAux itemInventario, string strNumeroDocumento, 
                                                                       string pstrEstadoPSeriadoMercaderiaRegularizar)
        {
            List<BEProductoSeriado> lstProductoSeries = new List<BEProductoSeriado>();
            int cntTotalProdSeriados = (int)itemInventario.Conteo - (int)itemInventario.StockFisico;
            for (int cntNumeroSerie = 1; cntNumeroSerie <= cntTotalProdSeriados; ++cntNumeroSerie)
            {
                BEProductoSeriado itemProductoSeriado = new BEProductoSeriado
                {
                    codDeposito = itemInventario.codDeposito,
                    codProducto = itemInventario.codProducto,
                    FechaIngreso = itemInventario.CierreFechaHora == null ? DateTime.Now : itemInventario.CierreFechaHora.Value,
                    NumeroLote = "P.Reg." + itemInventario.codProducto.ToString() + cntNumeroSerie.ToString().PadLeft(3, '0'),
                    NumeroSerie = "P.Reg." + itemInventario.codProducto.ToString() + cntNumeroSerie.ToString().PadLeft(3, '0'),
                    CodigoPersonaProveedor = itemInventario.CodigoPersonaEmpre,
                    Cantidad = 1,
                    EstadoVendido = false,
                    CodigoPersonaCliente = null,
                    EstaComprometido = false,
                    FechaVenta = null,
                    Estado = true,
                    SegUsuarioCrea = itemInventario.segUsuarioCrea,
                    CodigoPersonaEmpre = itemInventario.CodigoPersonaEmpre,
                    CodigoPuntoVenta = itemInventario.CodigoPuntoVenta,
                    NumeroComprobanteVenta = null,
                    FechaComprometido = null,
                    NumeroComprobanteComprom = null,
                    NumeroComprobanteCompra = strNumeroDocumento,
                    codRegEstadoMercaderia = pstrEstadoPSeriadoMercaderiaRegularizar,
                    indRegularizar = true,
                    perInventario = itemInventario.Periodo
                };
                lstProductoSeries.Add(itemProductoSeriado);
            }
            return lstProductoSeries;
        }
        private static List<BEProductoSeriado> ProductoSeriadosRetirar(InventarioAux itemInventario, string strNumeroDocumento, 
                                                                       string pstrEstadoPSeriadoMercaderiaRetirar)
        {
            List<BEProductoSeriado> lstProductoSeries = new List<BEProductoSeriado>();
            int cntTotalProdSeriados = (int)itemInventario.Conteo - (int)itemInventario.StockFisico;

            foreach (BEInventarioSerie inventarioSerie in itemInventario.lstInventarioSerie)
            {
                if (!inventarioSerie.indExisteFisico)
                {
                    BEProductoSeriado itemProductoSeriado = new BEProductoSeriado
                    {
                        codProductoSeriado = inventarioSerie.codProductoSeriado,
                        CodigoRegistro = inventarioSerie.objProductoSerie.CodigoRegistro,
                        codDeposito = itemInventario.codDeposito,
                        codProducto = itemInventario.codProducto,
                        codRegEstadoMercaderia = pstrEstadoPSeriadoMercaderiaRetirar,
                        CodigoPersonaProveedor = itemInventario.CodigoPersonaEmpre,
                        Cantidad = 1,
                        EstadoVendido = false,
                        CodigoPersonaCliente = null,
                        EstaComprometido = false,
                        FechaVenta = null,
                        Estado = false,
                        SegUsuarioEdita = itemInventario.segUsuarioCrea,
                        CodigoPersonaEmpre = itemInventario.CodigoPersonaEmpre,
                        CodigoPuntoVenta = itemInventario.CodigoPuntoVenta,
                        NumeroComprobanteVenta = null,
                        FechaComprometido = DateTime.Now,
                        FechaIngreso = DateTime.Now,
                        FechaVencimiento = DateTime.Now,
                        NumeroComprobanteComprom = strNumeroDocumento,
                        indRegularizar = false,
                        perInventario = itemInventario.Periodo
                    };
                    lstProductoSeries.Add(itemProductoSeriado);
                }
            }
            return lstProductoSeries;
        }
        private static ProductoKardexAux LlenarEntidadKardex(BEDocumento documento, string sNumeroDocumento, BEPersona empresa, 
                                                             int CONTA_ITEM, InventarioAux inventario, BEProducto producto, decimal p_TCVenta, 
                                                             string strcodRegistroTipoMovimi, string strcodRegistroTipoMotivo)
        {
            decimal COSTO_UNIT = producto.itemProductoPrecio.ValorCosto;
            if (producto.itemProductoPrecio.CodigoArguMoneda == ConfigCROM.AppConfig(documento.codEmpresa,
                                                                                     ConfigTool.DEFAULT_MonedaInt))
                COSTO_UNIT = producto.itemProductoPrecio.ValorCosto * p_TCVenta;
            decimal COSTO_TOTAL = inventario.Conteo * COSTO_UNIT;

            ProductoKardexAux itemProductoExistenciasKardex = new ProductoKardexAux
            {
                fecMovimiento = inventario.CierreFechaHora.Value,
                codProducto = inventario.codProducto,
                codigoProducto = inventario.CodigoProducto,
                codPersonaEmpre = inventario.CodigoPersonaEmpre,
                codRegistroTipoMovimi = strcodRegistroTipoMovimi, // ,
                codPuntoDeVenta = inventario.CodigoPuntoVenta,
                codRegistroTipoMotivo = strcodRegistroTipoMotivo, // ,
                codPersonaMovimi = inventario.CodigoPersonaEmpre,
                codDocumento = documento.CodigoComprobante,
                numDocumento = sNumeroDocumento,
                codItemDetalle = CONTA_ITEM.ToString().PadLeft(3, '0'),

                cntEntrada = inventario.Conteo,
                monCostoUnitEntrada = COSTO_UNIT,
                monTotalEntrada = COSTO_TOTAL,

                cntSaldo = inventario.Conteo,
                monCostoUnitSaldo = COSTO_UNIT,
                monTotalSaldo = COSTO_TOTAL,

                desRazonSocial = empresa.RazonSocial,
                perKardexAnio = DateTime.Now.Year,
                codDeposito = ConfigCROM.AppConfig(documento.codEmpresa, ConfigTool.DEFAULT_AlmacenPrincipal),
                indActivo = true,
                segUsuarioCrea = inventario.segUsuarioEdita
            };
            return itemProductoExistenciasKardex;
        }
        private static BEComprobanteEmisionDetalle LlenarEntidadDocumentoDetalle(InventarioAux itemInventario,
                                                                                 BEImpuesto itemImpuestoVTA,
                                                                                 BEDocumento itemComprobante,
                                                                                 string sNumeroDeDocumento,
                                                                                 BEProducto itemProducto,
                                                                                 int CONTA_ITEM,
                                                                                 InventarioAux xInventario,
                                                                                 bool prm_AsientoEnKardex)
        {
            BEComprobanteEmisionDetalle documRegDetalle = new BEComprobanteEmisionDetalle();
            if (!prm_AsientoEnKardex)
            {
                if (itemComprobante.IncidenciaEnStocks == 1)
                    documRegDetalle.Cantidad = itemInventario.Conteo - itemInventario.StockFisico;
                if (itemComprobante.IncidenciaEnStocks == -1)
                    documRegDetalle.Cantidad = itemInventario.StockFisico - itemInventario.Conteo;
            }
            else
                documRegDetalle.Cantidad = itemInventario.Conteo;

            documRegDetalle.CodigoItemDetalle = CONTA_ITEM.ToString().PadLeft(3, '0');
            documRegDetalle.CodigoProducto = itemInventario.CodigoProducto;
            documRegDetalle.codProducto = itemInventario.codProducto;
            documRegDetalle.CodigoArguUnidadMed = itemProducto.CodigoArguUnidadMed;
            documRegDetalle.CantiDecimales = Convert.ToInt16(ConfigCROM.AppConfig(itemComprobante.codEmpresa,
                                                                                  ConfigTool.DEFAULT_CantidadDecimals));
            documRegDetalle.IncluyeIGV = false;
            documRegDetalle.CantidadPendente = 0;
            documRegDetalle.UnitDescuento = 0;
            documRegDetalle.UnitValorCosto = itemProducto.itemProductoPrecio.ValorCosto;
            documRegDetalle.UnitValorVenta = itemProducto.itemProductoPrecio.ValorCosto;
            documRegDetalle.UnitPrecioBruto = itemProducto.itemProductoPrecio.ValorCosto;
            documRegDetalle.UnitPrecioSinIGV = itemProducto.itemProductoPrecio.ValorCosto;
            documRegDetalle.UnitValorDscto = 0;
            documRegDetalle.UnitValorIGV = itemImpuestoVTA.Porcentaje * itemProducto.itemProductoPrecio.ValorCosto;
            documRegDetalle.TotItemValorBruto = itemProducto.itemProductoPrecio.ValorCosto * itemInventario.Conteo;
            documRegDetalle.TotItemValorDscto = 0;
            documRegDetalle.TotItemValorVenta = itemProducto.itemProductoPrecio.ValorCosto * itemInventario.Conteo;
            documRegDetalle.TotItemValorIGV = itemImpuestoVTA.Porcentaje * (itemProducto.itemProductoPrecio.ValorCosto * itemInventario.Conteo);
            documRegDetalle.Descripcion = itemProducto.Descripcion;
            documRegDetalle.CodigoArguTipoProducto = itemProducto.CodigoArguTipoProducto;
            documRegDetalle.CodigoArguDestinoComp = WebConstants.DEFAULT_DOCUM_DESTINADO_INTERNO;
            documRegDetalle.EsVerificarStock = true;
            documRegDetalle.codEmpleadoVendedor = itemInventario.CierreEmpleado;
            documRegDetalle.Valor_ITC = 0;
            documRegDetalle.Escanner = false;
            documRegDetalle.Estado = true;
            documRegDetalle.SegUsuarioCrea = itemInventario.segUsuarioEdita;
            documRegDetalle.auxcodInventario = itemInventario.codInventario;
            return documRegDetalle;
        }

        private static BEComprobanteEmision LlenarDocumentoInventarioInicial(List<InventarioAux> listaInventario,
                                                                             BETipoDeCambio itemTiposDeCambio,
                                                                             BEImpuesto itemImpuestoVTA,
                                                                             PersonasLogic oPersonasLogic,
                                                                             BEDocumento itemComprobantes,
                                                                             string sNumeroDeDocumento,
                                                                             BEPersona itemPersonas,
                                                                             int pcodEmpresa, string pSegUsuario)
        {
            BEComprobanteEmision itemComprobanteEmision = new BEComprobanteEmision()
            {
                NumeroComprobante = sNumeroDeDocumento,
                CodigoPersonaEmpre = listaInventario[0].CodigoPersonaEmpre,
                CodigoPuntoVenta = listaInventario[0].CodigoPuntoVenta,
                CodigoPersonaEntidad = listaInventario[0].CodigoPersonaEmpre,
                CodigoArguDepositoDesti = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_AlmacenPrincipal),
                CodigoArguMoneda = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_MonedaNac),
                CodigoArguTipoDeOperacion = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Movim_SInicial),
                CodigoComprobante = itemComprobantes.CodigoComprobante,
                codEmpleado = listaInventario[0].CierreEmpleado,
                DocEsFacturable = itemComprobantes.EsComprobanteFiscal,
                EntidadRazonSocial = itemPersonas.RazonSocial,
                EntidadDireccion = oPersonasLogic.DomicilioPersona(itemPersonas, false,
                                                                   pcodEmpresa,  pSegUsuario, Tools.Comun.Web.WebConstants.TipoDomicilio.FISCAL_PRINCIPAL), 
                // ConfigCROM.AppConfig(ConfigTool.DEFAULT_Atributo_DomicFiscal), false),
                EntidadNumeroRUC = oPersonasLogic.AtributoPersona(itemPersonas, ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Atributo_NumerRUC)),
                CodigoArguDestinoComp = WebConstants.DEFAULT_DOCUM_DESTINADO_INTERNO,
                CodigoArguEstadoDocu = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Doc_InventEstado),
                FechaDeEmision = listaInventario[0].CierreFechaHora.Value,
                FechaDeVencimiento = listaInventario[0].CierreFechaHora.Value,
                FechaDeProceso = listaInventario[0].CierreFechaHora.Value,
                ValorIGV = itemImpuestoVTA.Porcentaje,
                ValorTipoCambioCMP = itemTiposDeCambio.CambioCompraGOB,
                ValorTipoCambioVTA = itemTiposDeCambio.CambioVentasGOB,
                CodigoArguMotivoGuia = null,
                Observaciones = "¡ Proceso automático de Cierre de inventarios......! " + DateTime.Now.ToLongDateString(),
                CodigoArguUbigeo = oPersonasLogic.ObtenerUbigeoPersona(itemPersonas, DatoUbigeo.UbigeoNombre,  Tools.Comun.Web.WebConstants.TipoDomicilio.FISCAL_PRINCIPAL),
                EntidadDireccionUbigeo = oPersonasLogic.ObtenerUbigeoPersona(itemPersonas,  DatoUbigeo.Domicilio,  Tools.Comun.Web.WebConstants.TipoDomicilio.FISCAL_PRINCIPAL),

                CodigoArguTipoDomicil = ((int)TipoDomicilio.FISCAL_PRINCIPAL).ToString(), 
                SegUsuarioCrea = listaInventario[0].segUsuarioCrea,
                Estado = true
            };
            return itemComprobanteEmision;
        }
        private static BEComprobanteEmision LlenarDocumentoNotaIngresoSalida(List<InventarioAux> listaInventario, BETipoDeCambio
                                                                             itemTiposDeCambio, BEImpuesto itemImpuestoVTA,
                                                                             PersonasLogic oPersonasLogic, BEDocumento documento,
                                                                             string sNumeroDeDocumento, BEPersona itemPersonas,
                                                                             string codDocumento, string codRegEstado,
                                                                             string codRegOperacion, string strTituloDoc,
                                                                             int pcodEmpresa, string pSegUsuario)
        {
            BEComprobanteEmision itemComprobanteEmision = new BEComprobanteEmision()
            {
                NumeroComprobante = sNumeroDeDocumento,

                CodigoPersonaEmpre = listaInventario[0].CodigoPersonaEmpre,
                CodigoPuntoVenta = listaInventario[0].CodigoPuntoVenta,
                CodigoPersonaEntidad = listaInventario[0].CodigoPersonaEmpre,

                CodigoArguDepositoOrigen = listaInventario[0].codDeposito,
                CodigoArguDepositoDesti = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_AlmacenPrincipal),

                CodigoArguMoneda = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_MonedaNac),
                CodigoArguTipoDeOperacion = codRegOperacion,
                CodigoComprobante = documento.CodigoComprobante,
                codEmpleado = listaInventario[0].CierreEmpleado,
                DocEsFacturable = documento.EsComprobanteFiscal,
                EntidadRazonSocial = itemPersonas.RazonSocial,
                EntidadDireccion = oPersonasLogic.DomicilioPersona(itemPersonas, false, pcodEmpresa, pSegUsuario, 
                                                                   Tools.Comun.Web.WebConstants.TipoDomicilio.FISCAL_PRINCIPAL),
                //ConfigCROM.AppConfig(ConfigTool.DEFAULT_Atributo_DomicFiscal), false),
                EntidadNumeroRUC = oPersonasLogic.AtributoPersona(itemPersonas, ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Atributo_NumerRUC)),//, false
                CodigoArguDestinoComp = WebConstants.DEFAULT_DOCUM_DESTINADO_INTERNO,
                CodigoArguEstadoDocu = codRegEstado,
                FechaDeEmision = listaInventario[0].CierreFechaHora.Value,
                FechaDeVencimiento = listaInventario[0].CierreFechaHora.Value,
                FechaDeProceso = listaInventario[0].CierreFechaHora.Value,
                ValorIGV = itemImpuestoVTA.Porcentaje,
                ValorTipoCambioCMP = itemTiposDeCambio.CambioCompraGOB,
                ValorTipoCambioVTA = itemTiposDeCambio.CambioVentasGOB,
                CodigoArguMotivoGuia = null,
                Observaciones = string.Concat( "[ " , strTituloDoc.ToUpper() , 
                                               " ]¡ Proceso automático de Reguralizacion inventarios..!" , 
                                               DateTime.Now.ToLongDateString()),
                CodigoArguUbigeo = oPersonasLogic.ObtenerUbigeoPersona(itemPersonas,  DatoUbigeo.UbigeoNombre,
                                        Tools.Comun.Web.WebConstants.TipoDomicilio.FISCAL_PRINCIPAL),
                //ConfigCROM.AppConfig(ConfigTool.DEFAULT_Atributo_DomicFiscal), true),
                //CodigoArguUbigeo = oPersonasLogic.
                //ObtenerAtributoPersona(itemPersonas, ConfigCROM.AppConfig(ConfigTool.DEFAULT_Atributo_DomicFiscal), true),
                EntidadDireccionUbigeo = oPersonasLogic.NombreDeUbigeo(
                                            oPersonasLogic.ObtenerUbigeoPersona(itemPersonas,  DatoUbigeo.Domicilio,
                                                Tools.Comun.Web.WebConstants.TipoDomicilio.FISCAL_PRINCIPAL)),
                // ConfigCROM.AppConfig(ConfigTool.DEFAULT_Atributo_DomicFiscal), true)))
                //NombreDeUbigeo(oPersonasLogic.ObtenerUbigeo(oPersonasLogic.ObtenerAtributoPersona(itemPersonas, ConfigCROM.AppConfig(ConfigTool.DEFAULT_Atributo_DomicFiscal), true))),
                CodigoArguTipoDomicil =( (int)TipoDomicilio.FISCAL_PRINCIPAL).ToString(), // ConfigCROM.AppConfig(ConfigTool.DEFAULT_Atributo_DomicFiscal),
                SegUsuarioCrea = listaInventario[0].segUsuarioCrea,
                Estado = true,
                strInventarioAutomatico = listaInventario[0].Periodo,
                indInventarioAutomatico = true
            };
            return itemComprobanteEmision;
        }
        private bool ValidarPreciosAntesDeCerrarInventario(List<InventarioAux> lstInventario)
        {
            bool blnTienePrecio = false;
            int intContadorVentaCeros = 0;
            int intContadorCompraCeros = 0;
            foreach (InventarioAux inventario in lstInventario)
            {
                if (inventario.ValorCosto == 0 || inventario.ValorCosto == null)
                    ++intContadorCompraCeros;
                if (inventario.ValorVenta == 0 || inventario.ValorVenta == null)
                    ++intContadorVentaCeros;
            }
            if (lstInventario.Count > 0 && intContadorVentaCeros == 0 && intContadorCompraCeros == 0)
                blnTienePrecio = true;

            return blnTienePrecio;
        }
      
        private static void TotalizarDocumento(BEComprobanteEmision comprobanteEmisionDocumento, 
                                               List<BEComprobanteEmisionDetalle> lstDetalleDocumento)
        {
            decimal nTotItemValorBrutoNI = 0;
            decimal nTotItemValorDsctoNI = 0;
            decimal nTotItemValorVentaNI = 0;
            decimal nTotItemValorIGVNI = 0;
            foreach (BEComprobanteEmisionDetalle itemDocDetalle in lstDetalleDocumento)
            {
                nTotItemValorBrutoNI += itemDocDetalle.TotItemValorBruto;
                nTotItemValorDsctoNI += itemDocDetalle.TotItemValorDscto;
                nTotItemValorVentaNI += itemDocDetalle.TotItemValorVenta;
                nTotItemValorIGVNI += itemDocDetalle.TotItemValorIGV;
            }
            comprobanteEmisionDocumento.ValorTotalBruto = nTotItemValorBrutoNI;
            comprobanteEmisionDocumento.ValorTotalDescuento = nTotItemValorDsctoNI;
            comprobanteEmisionDocumento.ValorTotalVenta = nTotItemValorVentaNI;
            comprobanteEmisionDocumento.ValorTotalImpuesto = nTotItemValorIGVNI;
            decimal nTotPrecioVentaNI = nTotItemValorVentaNI + nTotItemValorIGVNI;
            comprobanteEmisionDocumento.ValorTotalPrecioVenta = nTotPrecioVentaNI;
            comprobanteEmisionDocumento.ValorTotalPrecioExtran = Helper.DecimalRound(nTotItemValorVentaNI / comprobanteEmisionDocumento.ValorTipoCambioVTA, 2);

        }

        #endregion METODOS PRIVADOS
    }
}

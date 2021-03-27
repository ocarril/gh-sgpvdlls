namespace CROM.GestionParqueo.BusinessLogic
{
    using CROM.BusinessEntities.Almacen;
    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.Maestros;
    using CROM.BusinessEntities.Parqueo;
    using CROM.GestionAlmacen.BusinessLogic;
    using CROM.GestionComercial.BusinessLogic;
    using CROM.GestionParqueo.DataAccess;
    using CROM.TablasMaestras.BussinesLogic;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.Web;
    using CROM.Tools.Config;

    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Transactions;
    using static CROM.Tools.Comun.Web.WebConstants;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 28/11/2011-06:25:40 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Parqueo.MovimientoLogic.cs]
    /// </summary>
    public class MovimientoLogic
    {
        private MovimientoData oMovimientoData = null;
        private ReturnValor oReturnValor = null;
        public MovimientoLogic()
        {
            oMovimientoData = new MovimientoData();
            oReturnValor = new ReturnValor();
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Parqueo.Movimiento
        /// En la BASE de DATO la Tabla : [Parqueo.Movimiento]
        /// <summary>
        /// <returns>List</returns>
        public List<MovimientoAux> List(Nullable<DateTime> p_FechaIngreso_desde, Nullable<DateTime> p_FechaIngreso_Hasta, string p_codPersonaEmpresa, string p_codPuntoDeVenta, string p_codVehiculo, string p_codRegTipoVehiculo, string p_codPersonaCliente, string p_codTarifa, bool? p_indAbonado, bool? p_indFacturado, string p_segUsuarioCrea, ref int? p_TotalOcupados)
        {
            List<MovimientoAux> miLista = new List<MovimientoAux>();
            try
            {
                miLista = oMovimientoData.List(HelpTime.ConvertYYYYMMDD(p_FechaIngreso_desde), HelpTime.ConvertYYYYMMDD(p_FechaIngreso_Hasta), p_codPersonaEmpresa, p_codPuntoDeVenta, p_codVehiculo, p_codRegTipoVehiculo, p_codPersonaCliente, p_codTarifa, p_indAbonado, p_indFacturado, p_segUsuarioCrea, ref p_TotalOcupados);
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
        /// Retorna una ENTIDAD de registro de la Entidad Parqueo.Movimiento
        /// En la BASE de DATO la Tabla : [Parqueo.Movimiento]
        /// <summary>
        /// <returns>Entidad</returns>
        public MovimientoAux Find(string prm_codMovimiento)
        {
            MovimientoAux miEntidad = new MovimientoAux();
            try
            {
                miEntidad = oMovimientoData.Find(prm_codMovimiento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miEntidad;
        }

        public MovimientoAux FindFecHoraSalida(string prm_codVehiculo)
        {
            MovimientoAux miEntidad = new MovimientoAux();
            try
            {
                miEntidad = oMovimientoData.FindFecHoraSalida(prm_codVehiculo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miEntidad;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Movimiento
        /// En la BASE de DATO la Tabla : [Parqueo.Movimiento]
        /// <summary>
        /// <param name = >itemMovimiento</param>
        public ReturnValor Insert(MovimientoAux itemMovimiento)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (itemMovimiento.codRegSectorParqueo == string.Empty)
                        itemMovimiento.codRegSectorParqueo = null;
                    if (itemMovimiento.codPersonaCliente == string.Empty)
                        itemMovimiento.codPersonaCliente = null;

                    VehiculoData oVehiculoData = new VehiculoData();
                    VehiculoAux miVehiculo = new VehiculoAux
                    {
                        codVehiculo = itemMovimiento.codVehiculo,
                        codPersonaCliente = itemMovimiento.codPersonaCliente,
                        codRegMarcaModelo = itemMovimiento.codRegMarcaModelo,
                        gloObservacion = itemMovimiento.gloObservacion,
                        codRegTipoVehiculo = itemMovimiento.codRegTipoVehiculo,
                        indActivo = true,
                        segUsuarioCrea = itemMovimiento.segUsuarioCrea,
                    };

                    oReturnValor.Exitosa = oVehiculoData.Insert(miVehiculo);

                    oReturnValor.CodigoRetorno = oMovimientoData.Insert(itemMovimiento);
                    if (oReturnValor.CodigoRetorno != null)
                    {
                        oReturnValor.Exitosa = true;
                        oReturnValor.Message = HelpMessages.Evento_NEW;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Movimiento
        /// En la BASE de DATO la Tabla : [Parqueo.Movimiento]
        /// <summary>
        /// <param name = >itemMovimiento</param>
        public ReturnValor Update(MovimientoAux itemMovimiento)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (itemMovimiento.codRegSectorParqueo == string.Empty)
                        itemMovimiento.codRegSectorParqueo = null;
                    if (itemMovimiento.codPersonaCliente == string.Empty)
                        itemMovimiento.codPersonaCliente = null;

                    oReturnValor.Exitosa = oMovimientoData.Update(itemMovimiento);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_EDIT;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }
        public ReturnValor UpdateFecHoraSalida(MovimientoAux itemMovimiento)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oMovimientoData.UpdateFecHoraSalida(itemMovimiento);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_EDIT;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }
        public ReturnValor UpdateindCancelado(MovimientoAux itemMovimiento)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oMovimientoData.UpdateIndCancelado(itemMovimiento);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.gc_DOCUM_YA_CANCELADO;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        public ReturnValor UpdateIndFacturadoGeneraTCK(int pcodEmpresa, 
                                                       MovimientoAux itemMovimiento, 
                                                       int pcodPersonaEmpleado, 
                                                       string pcodEmpresaRUC,
                                                       string pUser, 
                                                       string pcodPlanilla,
                                                       ref BEComprobanteEmision refmiTicket)
        {
            try
            {
                using (TransactionScope txP = new TransactionScope(TransactionScopeOption.Required))
                {
                    ComprobanteEmisionLogic oComprobanteEmisionLogic = new ComprobanteEmisionLogic();
                    BEComprobanteEmision miTicket = new BEComprobanteEmision();
                    BEDocumento p_miComprobante = new BEDocumento();
                    int codDocumentoSerie = -1;

                    miTicket = GenerarTicketDeVenta(pcodEmpresa,
                                                    itemMovimiento, 
                                                    pcodPersonaEmpleado, 
                                                    pcodEmpresaRUC,
                                                    pUser,
                                                    pcodPlanilla,
                                                    ref p_miComprobante, 
                                                    ref codDocumentoSerie);

                    ReturnValor oReturnTICK = new ReturnValor();

                    miTicket.codDocumentoSerie = codDocumentoSerie;
                    miTicket.codEmpresaRUC = pcodEmpresaRUC;
                    oReturnTICK = oComprobanteEmisionLogic.Insert(miTicket, p_miComprobante);

                    refmiTicket = miTicket;
                    itemMovimiento.codDocumento = refmiTicket.CodigoComprobante;
                    itemMovimiento.numDocumento = refmiTicket.NumeroComprobante;
                    oReturnValor.Exitosa = oMovimientoData.UpdateIndFacturado(itemMovimiento);
                    if (oReturnValor.Exitosa && oReturnTICK.Exitosa)
                    {
                        oReturnValor.CodigoRetorno = miTicket.CodigoComprobante + "*" + miTicket.NumeroComprobante;
                        oReturnValor.Message = HelpMessages.Evento_EDIT;
                        txP.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }
        public ReturnValor UpdateIndFacturadoAnularTCK(MovimientoAux pMovimiento, BEDocumento pDocumento, BEComprobanteEmision miTicket )
        {
            try
            {
                using (TransactionScope txP = new TransactionScope(TransactionScopeOption.Required))
                {
                    ComprobanteEmisionLogic oComprobanteEmisionLogic = new ComprobanteEmisionLogic();
                    ReturnValor oReturnValorJM = new ReturnValor();
                    oReturnValorJM = oComprobanteEmisionLogic.UpdateAnulacion(miTicket, pDocumento);

                    pMovimiento.codDocumento = null;
                    pMovimiento.numDocumento = null;
                    pMovimiento.indFacturado = false;
                    oReturnValor.Exitosa = oMovimientoData.UpdateIndFacturado(pMovimiento);
                    if (oReturnValor.Exitosa && oReturnValorJM.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.gc_DOCUM_YA_ANULADO;
                        txP.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Parqueo.Movimiento
        /// En la BASE de DATO la Tabla : [Parqueo.Movimiento]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Delete(string prm_codMovimiento, string prm_UsuarioEdita)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oMovimientoData.Delete(prm_codMovimiento, prm_UsuarioEdita);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion

        private BEComprobanteEmision GenerarTicketDeVenta(int pcodEmpresa, 
                                                          MovimientoAux pitem, 
                                                          int pcodPersonaEmpleado,
                                                          string pcodEmpresaRUC, 
                                                          string pUserActual, 
                                                          string pcodPlanilla,
                                                          ref BEDocumento pTicketRef, 
                                                          ref int pcodDocumentoSerie)
        {
            DocumentoLogic oDocumentoLogic = new DocumentoLogic();
            PersonasLogic oPersonasLogic = new PersonasLogic();
            ImpuestoLogic oTiposDeImpuestoLogic = new ImpuestoLogic();
            TarifaLogic oTarifaLogic = new TarifaLogic();
            TipoDeCambioLogic oTiposdeCambioLogic = new TipoDeCambioLogic();

            BEImpuesto miImpuestoVTA = new BEImpuesto();
            BEDocumento miTicket = new BEDocumento();
            BEPersona miPersona = new BEPersona();
            TarifaAux miTarifa = new TarifaAux();
            BETipoDeCambio miTiposDeCambio = new BETipoDeCambio();

            miTicket = oDocumentoLogic.Find(ConfigurationManager.AppSettings["DEFAULT_Doc_Ticket"].ToString(), 
                                            pcodEmpresaRUC, 
                                            pcodEmpresa, 
                                            pUserActual);
            pTicketRef = miTicket;

            miPersona = oPersonasLogic.Find(pcodEmpresa,
                                            pitem.codPersonaCliente,
                                            pUserActual);

            miImpuestoVTA = oTiposDeImpuestoLogic.Find(pcodEmpresa, 
                                                       ConfigurationManager.AppSettings["DEFAULT_Impuesto_Ventas"].ToString(),
                                                       pUserActual);
            miTarifa = oTarifaLogic.Find(pitem.codTarifa);
            miTiposDeCambio = oTiposdeCambioLogic.Find(new BaseFiltroTipoCambio
            {
                codEmpresa = pcodEmpresa,
                fecInicioDate = DateTime.Now,
                codRegMoneda = ConfigurationManager.AppSettings["DEFAULT_MonedaInt"].ToString()
            });

            string p_NroComprobante = HelpDocumentos.Tipos.TCK.ToString() + 
                                        NumerodeComprobante(oDocumentoLogic,
                                                            pcodEmpresa,
                                                            pitem.codPersonaEmpresa,
                                                            miTicket.CodigoComprobante,
                                                            pitem.codPuntoDeVenta,
                                                            pcodPlanilla,
                                                            pitem.segUsuarioCrea,
                                                            ref pcodDocumentoSerie);

            BEComprobanteEmision miDocumentoTicket = new BEComprobanteEmision
            {
                CodigoArguEstadoDocu = miTicket.CodigoArguEstEMIDefault,
                CodigoArguMoneda = ConfigurationManager.AppSettings["DEFAULT_MonedaNac"].ToString(),
                CodigoArguTipoDeOperacion = ConfigurationManager.AppSettings["DEFAULT_Movim_Venta"].ToString(),
                CodigoArguTipoDomicil = ((int)TipoDomicilio.FISCAL_PRINCIPAL).ToString(), // ConfigCROM.AppConfig(ConfigTool.DEFAULT_Atributo_DomicFiscal),
                CodigoArguUbigeo = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_Ubigeo),
                //. ConfigurationManager.AppSettings["DEFAULT_Ubigeo"].ToString(),
                CodigoComprobante = ConfigurationManager.AppSettings["DEFAULT_Doc_Ticket"].ToString(),
                CodigoArguDestinoComp = WebConstants.DEFAULT_DOCUM_DESTINADO_CLIENTES,
                CodigoComprobanteFact = miTicket.CodigoComprobante,
                codEmpleado = pcodPersonaEmpleado,
                CodigoPersonaEmpre = pitem.codPersonaEmpresa,
                CodigoPersonaEntidad = pitem.codPersonaCliente,
                codEmpleadoVendedor = pcodPersonaEmpleado,
                CodigoPuntoVenta = pitem.codPuntoDeVenta,
                codCondicionVenta = Convert.ToInt32(ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_CondicionVenta)),
                //.ConfigurationManager.AppSettings["DEFAULT_CondicionVenta"].ToString(),
                DocEsFacturable = miTicket.EsComprobanteFiscal,
                EntidadDireccion = "No exige el tipo de DOC",
                EntidadDireccionUbigeo = "LIMA",
                EntidadNumeroRUC = "9999",
                EntidadRazonSocial = miPersona.RazonSocial,
                Estado = true,
                FechaDeEmision = DateTime.Now,
                FechaDeEntrega = DateTime.Now,
                FechaDeCancelacion = DateTime.Now,
                FechaDeProceso = DateTime.Now,
                FechaDeVencimiento = DateTime.Now,
                
                Nota01 = "Ticket gen. automático",
                NumeroComprobante = p_NroComprobante, // NumerodeComprobante(oComprobantesLogic, miTicket.CodigoComprobante, item.codPersonaEmpresa, item.codPuntoDeVenta, item.segUsuarioCrea),
                Observaciones = pitem.gloObservacion,
                SegUsuarioCrea = pitem.segUsuarioCrea,
                SegUsuarioEdita = pitem.segUsuarioCrea,
                ValorIGV = miImpuestoVTA.Porcentaje,
                ValorTipoCambioCMP = miTiposDeCambio.CodigoArguMoneda == null ? 2 : miTiposDeCambio.CambioCompraPRL,
                ValorTipoCambioVTA = miTiposDeCambio.CodigoArguMoneda == null ? 2 : miTiposDeCambio.CambioVentasPRL,

            };

            ProductoLogic oProductoLogic = new ProductoLogic();
            BEProducto miProducto = new BEProducto();
            miProducto = oProductoLogic.Find(new BaseFiltroAlmacen
            {
                codEmpresaRUC = pitem.codPersonaEmpresa,
                codPuntoVenta = pitem.codPuntoDeVenta,
                codProducto = miTarifa.codProducto
            });

            miDocumentoTicket.listaComprobanteEmisionDetalle.Add(new BEComprobanteEmisionDetalle
            {
                Cantidad = 1,
                CantiDecimales = 4,
                CodigoArguEstadoDocu = miTicket.CodigoArguEstEMIDefault,
                CodigoArguDestinoComp = WebConstants.DEFAULT_DOCUM_DESTINADO_CLIENTES,
                CodigoArguTipoProducto = ConfigurationManager.AppSettings["DEFAULT_ProducTerminado"].ToString(),
                CodigoArguUnidadMed = ConfigurationManager.AppSettings["DEFAULT_UnidadMedida"].ToString(),
                CodigoComprobante = miTicket.CodigoComprobante,
                NumeroComprobante = miDocumentoTicket.NumeroComprobante,
                CodigoItemDetalle = "001",
                //codEmpresa = item.codPersonaEmpresa,
                codEmpleadoVendedor = pcodPersonaEmpleado,
                CodigoProducto = miTarifa.codiProducto,
                codProducto = miTarifa.codProducto,
                Descripcion = miProducto.Descripcion,
                Estado = true,
                CodigoPuntoVenta = pitem.codPuntoDeVenta,
                EsVerificarStock = false,
                FechaDeEmision = miDocumentoTicket.FechaDeEmision,
                IncluyeIGV = miImpuestoVTA.DiscriminaIGV,
                PesoTotal = 0,
                SegUsuarioCrea = pitem.segUsuarioCrea,
                SegUsuarioEdita = pitem.segUsuarioCrea,
                UnitPrecioBruto = pitem.monMontoPagado.Value,
            });
            CalcularDatosDelPrecioDeVenta(miImpuestoVTA, pitem, miDocumentoTicket.listaComprobanteEmisionDetalle[0]);
            CalcularTotalDocumento(ref miDocumentoTicket, miImpuestoVTA);

            return miDocumentoTicket;
        }
        private void CalcularDatosDelPrecioDeVenta(BEImpuesto prm_ImpuestoVTA, MovimientoAux prm_Movimiento, BEComprobanteEmisionDetalle prm_Detalle)
        {
            decimal nUnitPrecioSinIGV;
            decimal nUnitValorDescuento;
            decimal nUnitValorIGVs;
            if (prm_ImpuestoVTA.DiscriminaIGV)
            {
                nUnitValorDescuento = prm_Movimiento.monMontoPagado.Value * (0 / 100);
                nUnitValorIGVs = (prm_Movimiento.monMontoPagado.Value - nUnitValorDescuento) - ((prm_Movimiento.monMontoPagado.Value - nUnitValorDescuento) / (1 + prm_ImpuestoVTA.Porcentaje));
                nUnitPrecioSinIGV = ((prm_Movimiento.monMontoPagado.Value - nUnitValorDescuento) - nUnitValorIGVs);
            }
            else
            {
                nUnitValorDescuento = prm_Movimiento.monMontoPagado.Value * (0 / 100);
                nUnitValorIGVs = (prm_Movimiento.monMontoPagado.Value - nUnitValorDescuento) * prm_ImpuestoVTA.Porcentaje;
                nUnitPrecioSinIGV = prm_Movimiento.monMontoPagado.Value - nUnitValorDescuento;
            }

            prm_Detalle.UnitDescuento = nUnitValorDescuento;
            prm_Detalle.UnitValorIGV = nUnitValorIGVs;
            prm_Detalle.UnitPrecioSinIGV = nUnitPrecioSinIGV;

            decimal nUnitValorDscto = 0;
            if (prm_ImpuestoVTA.DiscriminaIGV)
                nUnitValorDscto = nUnitValorDescuento;
            else
                nUnitValorDscto = nUnitValorDescuento;

            prm_Detalle.UnitValorDscto = nUnitValorDscto;

            decimal nUnitValorVenta = nUnitPrecioSinIGV;
            decimal nUnitValorIGV = nUnitValorIGVs;
            decimal nTotItemValorIGV = Helper.DecimalRound(nUnitValorIGV * 1, 2);
            decimal nTotItemValorBruto = Helper.DecimalRound((nUnitPrecioSinIGV + nUnitValorDscto) * 1, 2);
            decimal nTotItemValorVenta = Helper.DecimalRound(nUnitValorVenta * 1, 2);
            decimal nTotItemValorDscto = Helper.DecimalRound(nUnitValorDscto * 1, 2);
            decimal nTotItemTotalITEM = (nTotItemValorBruto - nTotItemValorDscto) + nTotItemValorIGV;
            decimal nUnitPeso = 0;
            decimal nPesoTotal = Helper.DecimalRound(nUnitPeso * 1, 2);

            prm_Detalle.UnitValorVenta = nUnitValorVenta;
            prm_Detalle.UnitValorIGV = nUnitValorIGV;
            prm_Detalle.TotItemValorIGV = nTotItemValorIGV;
            prm_Detalle.TotItemValorBruto = nTotItemValorBruto;
            prm_Detalle.TotItemValorVenta = nTotItemValorVenta;
            prm_Detalle.TotItemValorDscto = nTotItemValorDscto;
            prm_Detalle.PesoUnitario = nUnitPeso;
            prm_Detalle.PesoTotal = nPesoTotal;

        }
                                            
        private string NumerodeComprobante(DocumentoLogic pDocumentoLogic,
                                           int pcodEmpresa,
                                           string pcodEmpresaRUC, 
                                           string pcodComprobante, 
                                           string pcodPuntoVenta, 
                                           string pcodPlanilla,
                                           string pUserActual, 
                                           ref int pcodDocumentoSerie)
        {
            string numDocumento = null;
            ReturnValor miReturnValor = new ReturnValor();
            BEDocumentoSerie prm_itemComprobantesSeries = new BEDocumentoSerie();

            List<BEDocumentoSerie> lstComprobantesSeries = new List<BEDocumentoSerie>();

            lstComprobantesSeries = pDocumentoLogic.ListDocumentoSeriePorUsuario(new BaseFiltroDocumentoSerie
            {
                codEmpresa = pcodEmpresa,
                codEmpresaRUC = pcodEmpresaRUC,
                codPuntoVenta = pcodPuntoVenta,
                codDocumento = pcodComprobante,
                codPlanilla = pcodPlanilla,
                indEstado = true
            });

            if (lstComprobantesSeries.Count > 0)
            {
                prm_itemComprobantesSeries = lstComprobantesSeries[0];
                pcodDocumentoSerie = prm_itemComprobantesSeries.codDocumentoSerie;
            }

            miReturnValor = pDocumentoLogic.UltimoNumeroDocumento(pcodEmpresaRUC,
                                                                  prm_itemComprobantesSeries.codDocumentoSerie,
                                                                  pUserActual,
                                                                  pcodEmpresa);
            if (miReturnValor.Exitosa)
            {
                string[] NUM = miReturnValor.CodigoRetorno.Split('-');
                numDocumento = NUM[0] + NUM[1];
            }
            else
            {
                numDocumento = null;
            }

            return numDocumento;
        }
        private void CalcularTotalDocumento(ref BEComprobanteEmision miDocumentoTicket, BEImpuesto itemImpuestoVTA)
        {
            decimal nTotItemValorBruto = 0;
            decimal nTotItemValorDscto = 0;
            decimal nTotItemValorVenta = 0;
            decimal nTotItemValorIGV = 0;
            if (string.IsNullOrEmpty(miDocumentoTicket.NumeroComprobante))
                return;

            int xxItems = 0;


            foreach (BEComprobanteEmisionDetalle itemDocDetalle in miDocumentoTicket.listaComprobanteEmisionDetalle)
            {
                nTotItemValorBruto += (itemDocDetalle.TotItemValorBruto);
                nTotItemValorDscto += itemDocDetalle.TotItemValorDscto;
                nTotItemValorVenta += itemDocDetalle.TotItemValorVenta;
                nTotItemValorIGV += itemDocDetalle.TotItemValorIGV;
                ++xxItems;
            }
            miDocumentoTicket.ValorTotalBruto = nTotItemValorBruto;
            miDocumentoTicket.ValorTotalDescuento = nTotItemValorDscto;
            miDocumentoTicket.ValorTotalVenta = nTotItemValorVenta;
            miDocumentoTicket.ValorTotalImpuesto = nTotItemValorIGV;
            decimal nTotPrecioVenta = nTotItemValorVenta + nTotItemValorIGV;
            miDocumentoTicket.ValorTotalPrecioVenta = nTotPrecioVenta;

            foreach (BEComprobanteEmisionImpuesto itemComprobanteEmisionImpuestos in miDocumentoTicket.listaComprobanteEmisionImpuestos)
            {
                if (itemImpuestoVTA.CodigoImpuesto == itemComprobanteEmisionImpuestos.CodigoImpuesto)
                {
                    itemComprobanteEmisionImpuestos.ValorTotalImpuesto = nTotItemValorIGV;
                    itemComprobanteEmisionImpuestos.ValorDeImpuesto100 = Helper.DecimalRound(itemComprobanteEmisionImpuestos.ValorDeImpuesto * 100, 2);
                }
                if (itemComprobanteEmisionImpuestos.CodigoImpuesto == ConfigurationManager.AppSettings["DEFAULT_Impuesto_Desctos"].ToString())
                {
                    itemComprobanteEmisionImpuestos.ValorTotalImpuesto = nTotItemValorDscto;
                    if (nTotItemValorBruto > 0)
                        itemComprobanteEmisionImpuestos.ValorDeImpuesto100 = Helper.DecimalRound((nTotItemValorDscto / nTotItemValorBruto) * 100, 2);
                    else
                        itemComprobanteEmisionImpuestos.ValorDeImpuesto100 = 0;

                }
            }

            //if (miDocumentoTicket.CodigoArguMoneda == ConfigurationManager.AppSettings["DEFAULT_MonedaNac"])
            //{
            //    Decimal PrecExtrj = miDocumentoTicket.ValorTotalPrecioVenta / Convert.ToDecimal(miDocumentoTicket.ValorTipoCambioVTA);
            //    PrecExtrj = Helper.DecimalRound(PrecExtrj, 2);
            //    itemComprobanteEmision.ValorTotalPrecioExtran = PrecExtrj;
            //    itemComprobanteEmision.ValorTotalPrecioVenta = Convert.ToDecimal(DOCUM_ValorTotalPrecioVenta.Text);
            //    itemComprobanteEmision.ValorTotalBruto = Convert.ToDecimal(DOCUM_ValorTotalBruto.Text);

            //    itemComprobanteEmision.ValorTotalVenta = Convert.ToDecimal(DOCUM_ValorTotalVenta.Text);
            //}
            //else if (miDocumentoTicket.CodigoArguMoneda == ConfigurationManager.AppSettings["DEFAULT_MonedaInt"])
            //{
            //    itemComprobanteEmision.ValorTotalPrecioExtran = Convert.ToDecimal(DOCUM_ValorTotalPrecioVenta.Text);
            //    itemComprobanteEmision.ValorTotalPrecioVenta = Convert.ToDecimal(DOCUM_ValorTotalPrecioVenta.Text) * Convert.ToDecimal(DOCUM_ValorTipoCambioVTA.Text);
            //    itemComprobanteEmision.ValorTotalBruto = Convert.ToDecimal(DOCUM_ValorTotalBruto.Text) * Convert.ToDecimal(DOCUM_ValorTipoCambioVTA.Text);
            //    itemComprobanteEmision.ValorTotalVenta = Convert.ToDecimal(DOCUM_ValorTotalVenta.Text) * Convert.ToDecimal(DOCUM_ValorTipoCambioVTA.Text);
            //}

            miDocumentoTicket.ValorTotalPrecioExtran = miDocumentoTicket.ValorTotalPrecioVenta / Convert.ToDecimal(miDocumentoTicket.ValorTipoCambioVTA);

        }
    }
}

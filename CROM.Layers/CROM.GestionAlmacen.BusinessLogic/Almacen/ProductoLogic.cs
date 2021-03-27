namespace CROM.GestionAlmacen.BusinessLogic
{
    using CROM.BusinessEntities.Almacen;
    using CROM.GestionAlmacen.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.settings;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Transactions;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Almacen.ProductoLogic.cs]
    /// </summary>
    public class ProductoLogic
    {
        private ProductoData oProductoData = null;
        private ProductoFotoData oProductoFotosData = null;
        private ProductoProveedorData oProductoProveedoresData = null;
        private ProductoExistenciaData oProductoExistenciaData = null;
        private ProductoSeriadoData oProductoSeriadosData = null;
        private ProductoKardexData oProductoExistenciasKardexData = null;
        private InventarioData oInventariosData = null;
        private ReturnValor oReturnValor = null;

        //private ProductoPartesCompuestaData oProductoPartesCompuestaData = null;
        //private ProductoPartesAtributoData oProductoPartesAtributoData = null;
        
        public ProductoLogic()
        {
            oProductoData = new ProductoData();
            oProductoFotosData = new ProductoFotoData();
            oProductoProveedoresData = new ProductoProveedorData();
            oProductoExistenciaData = new ProductoExistenciaData();
            oProductoSeriadosData = new ProductoSeriadoData();
            oProductoExistenciasKardexData = new ProductoKardexData();
            oInventariosData = new InventarioData();
            oReturnValor = new ReturnValor();
            //oProductoPartesAtributoData = new ProductoPartesAtributoData();
            //oProductoPartesCompuestaData = new ProductoPartesCompuestaData();
        }

        #region /* TABLA:=(Almacen.Producto) PRODUCTO / ARTÍCULO */

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Producto
        /// En la BASE de DATO la Tabla : [Almacen.Producto]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<DTOProductoResponse> List(BaseFiltroProducto filtro)
        {
            List<DTOProductoResponse> lstProducto = new List<DTOProductoResponse>();
            try
            {
                if (string.IsNullOrEmpty(filtro.numSerieProducto))
                    lstProducto = oProductoData.List(filtro);
                else
                    lstProducto = oProductoData.ListNumSerie(filtro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProducto;
        }
        
        public List<DTOProductoResponse> List(BaseFiltroProducto filtro, Helper.ComboBoxText pTexto)
        {
            List<DTOProductoResponse> lstProducto = new List<DTOProductoResponse>();
            try
            {
                if (string.IsNullOrEmpty(filtro.numSerieProducto))
                    lstProducto = oProductoData.List(filtro);
                else
                    lstProducto = oProductoData.ListNumSerie(filtro);

                if (lstProducto.Count > 0)
                    lstProducto.Insert(0, new DTOProductoResponse { codProducto = 0, Descripcion = Helper.ObtenerTexto(pTexto) });
                else
                    lstProducto.Add(new DTOProductoResponse { codProducto = 0, Descripcion = Helper.ObtenerTexto(pTexto) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProducto;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.Producto
        /// En la BASE de DATO la Tabla : [Almacen.Producto]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public BEProducto Find(BaseFiltroAlmacen pFiltro)
        {
            BEProducto producto = new BEProducto();
            try
            {
                if (pFiltro.codProductoRefer != null)
                    producto = oProductoData.Find(pFiltro.codEmpresa, pFiltro.codProductoRefer);
                else
                    producto = oProductoData.Find(pFiltro.codEmpresa, pFiltro.codProducto.Value);

                if (producto != null)
                {
                    if (pFiltro.codProducto == null)
                        pFiltro.codProducto = producto.codProducto;

                    producto.itemProductoFoto = oProductoFotosData.Find(pFiltro.codEmpresa,
                                                                        pFiltro.codProducto.Value, 
                                                                        pFiltro.codId);

                    producto.itemProductoExistencias = oProductoExistenciaData.Find(new BEProductoExistenciaFind
                    {
                        codEmpresa = pFiltro.codEmpresa,
                        codProducto = pFiltro.codProducto.Value,
                        codDeposito = pFiltro.codDeposito
                    });

                    foreach (BEProductoExistencia productoExistencia in producto.itemProductoExistencias)
                    {
                        productoExistencia.listaInventario = oInventariosData.List(pFiltro);
                    }
                    List<ProductoClave> listaProductoClave = new List<ProductoClave>();
                    if (producto.PalabrasClaves != null)
                    {
                        String[] words = producto.PalabrasClaves.Split(',');

                        foreach (string j in words)
                        {
                            listaProductoClave.Add(new ProductoClave
                            {
                                DescripcionClave = j,
                                Estado = true,
                                codProducto = producto.codProducto,
                                CodigoProducto = producto.CodigoProducto,
                                SegUsuarioEdita = producto.segUsuarioEdita,
                                SegFechaEdita = producto.segFechaEdita
                            });
                        }
                        producto.listaProductoClave = listaProductoClave;
                    }

                    producto.listaProductoProductoSeriados = oProductoSeriadosData.List(pFiltro);

                    pFiltro.fecInicio = HelpTime.ConvertYYYYMMDD(DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud())
                        .AddDays(DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).DayOfYear * -1));

                    pFiltro.fecFinal = HelpTime.ConvertYYYYMMDD(DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()));
                    producto.listaProductoKardex = oProductoExistenciasKardexData.List(pFiltro);

                    //BETipoDeCambio tipoDeCambio = new BETipoDeCambio();
                    //tipoDeCambio = new TipoDeCambioLogic().Find(new BaseFiltro
                    //{
                    //    fecInicioDate = DateTime.Now,
                    //    codRegMoneda = ConfigCROM.AppConfig(ConfigTool.DEFAULT_MonedaInt)
                    //});
                    //if (tipoDeCambio != null)
                    //    producto.listaProductoVentas = new ConsultasGCLogic().ListProductoVentasCompras(filtro.codProducto, 
                    //                                                                                    filtro.codPerEmpresa,
                    //                                                                                    filtro.codDeposito, 
                    //                                                                                    filtro.codPuntoVenta, 
                    //                                                                                    DateTime.Now.Year, 
                    //                                                                                    1, 12, 
                    //                                                                                    tipoDeCambio.CambioVentasPRL, 
                    //                                                                                    ConstantesGC.OPERACION_DESTINO_VENTAS);

                    //BaseFiltro filtroComecial = new BaseFiltro
                    //{
                    //    codProducto = filtro.codProducto,
                    //    codRegMoneda = filtro.codRegMoneda,
                    //    codListaPrecio = filtro.codListaPrecio,
                    //    codPerEmpresa = filtro.codPerEmpresa,
                    //    codPuntoVenta = filtro.codPuntoVenta,
                    //    indEstado = filtro.indEstado
                    //};
                    //producto.listaProductoPrecio = oProductoPrecioData.List(filtroComecial);

                    //foreach (BEProductoPrecio itemPrecio in producto.listaProductoPrecio)
                    //{
                    //    producto.itemProductoPrecio = itemPrecio;
                    //    break;
                    //}
                    //producto.listaListaDePrecioDetalle = new ListaDePrecioDetalleData().List(new BaseFiltro
                    //{
                    //    codListaPrecio = producto.itemProductoPrecio.CodigoListaPrecio,
                    //    codProducto = filtro.codProducto,
                    //    codRegMoneda = string.Empty,
                    //    indEstado = null
                    //});
                }
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             pFiltro.segUsuarioEdita, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return producto;
        }
      
        public BEProducto FindCodigoProductoEmpresa(BaseFiltroAlmacen pFiltro)
        {
            BEProducto producto = new BEProducto();
            try
            {
                producto = oProductoData.FindCodigoProductoEmpresa(pFiltro);

                if (producto != null)
                {
                    if (pFiltro.codProducto == null)
                        pFiltro.codProducto = producto.codProducto;

                    //producto.itemProductoFoto = oProductoFotosData.Find(prm_baseFiltro.codProducto.Value,
                    //                                                    prm_baseFiltro.codId);

                    //producto.itemProductoExistencias = oProductoExistenciaData.Find(new BEProductoExistenciaFind
                    //{
                    //    codEmpresa= prm_baseFiltro.codEmpresa,
                    //    codProducto = prm_baseFiltro.codProducto.Value,
                    //    codDeposito = prm_baseFiltro.codDeposito,
                    //});
                    //foreach (BEProductoExistencia productoExistencia in producto.itemProductoExistencias)
                    //{
                    //    productoExistencia.listaInventario = oInventariosData.List(prm_baseFiltro);
                    //}
                    //List<ProductoClave> listaProductoClave = new List<ProductoClave>();
                    //if (producto.PalabrasClaves != null)
                    //{
                    //    String[] words = producto.PalabrasClaves.Split(',');

                    //    foreach (string j in words)
                    //    {
                    //        listaProductoClave.Add(new ProductoClave
                    //        {
                    //            DescripcionClave = j,
                    //            Estado = true,
                    //            codProducto = producto.codProducto,
                    //            CodigoProducto = producto.CodigoProducto,
                    //            SegUsuarioEdita = producto.segUsuarioEdita,
                    //            SegFechaEdita = producto.segFechaEdita
                    //        });
                    //    }
                    //    producto.listaProductoClave = listaProductoClave;
                    //}
                    //producto.listaProductoProveedores = oProductoProveedoresData.List(prm_baseFiltro);
                    //producto.listaProductoProductoSeriados = oProductoSeriadosData.List(prm_baseFiltro);

                    pFiltro.fecInicio = HelpTime.ConvertYYYYMMDD(DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud())
                        .AddDays(DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).DayOfYear * -1));
                    pFiltro.fecFinal = HelpTime.ConvertYYYYMMDD(DateTime.Now);
                    //producto.listaProductoKardex = oProductoExistenciasKardexData.List(prm_baseFiltro);








                    //BETipoDeCambio tipoDeCambio = new BETipoDeCambio();
                    //tipoDeCambio = new TipoDeCambioLogic().Find(new BaseFiltro
                    //{
                    //    fecInicioDate = DateTime.Now,
                    //    codRegMoneda = ConfigCROM.AppConfig(ConfigTool.DEFAULT_MonedaInt)
                    //});
                    //if (tipoDeCambio != null)
                    //    producto.listaProductoVentas = new ConsultasGCLogic().ListProductoVentasCompras(
                    //        prm_baseFiltro.codProducto,
                    //        prm_baseFiltro.codPerEmpresa, 
                    //        prm_baseFiltro.codDeposito, 
                    //        prm_baseFiltro.codPuntoVenta, 
                    //        DateTime.Now.Year, 
                    //        1, 12, 
                    //        tipoDeCambio.CambioVentasPRL, 
                    //        ConstantesGC.OPERACION_DESTINO_VENTAS);

                    //List<BEProductoPrecio> lstProductoPrecio = new List<BEProductoPrecio>();
                    //lstProductoPrecio = oProductoPrecioData.List(new BaseFiltro
                    //{
                    //    codProducto = prm_baseFiltro.codProducto,
                    //    codRegMoneda = prm_baseFiltro.codRegMoneda,
                    //    codListaPrecio = prm_baseFiltro.codListaPrecio,
                    //    codPerEmpresa = prm_baseFiltro.codPerEmpresa,
                    //    codPuntoVenta = prm_baseFiltro.codPuntoVenta,
                    //    indEstado = prm_baseFiltro.indEstado
                    //});
                    //foreach (BEProductoPrecio productoPrecio in lstProductoPrecio)
                    //    if (productoPrecio.Estado && productoPrecio.CodigoPuntoVenta == prm_baseFiltro.codPuntoVenta)
                    //        producto.itemProductoPrecio = productoPrecio;
                    //producto.listaProductoPrecio = lstProductoPrecio;
                    //producto.listaListaDePrecioDetalle = new ListaDePrecioDetalleData().List(new BaseFiltro { codListaPrecio = producto.itemProductoPrecio.CodigoListaPrecio, codProducto = prm_baseFiltro.codProducto, codRegMoneda = string.Empty, indEstado = null });
                }
            }
            catch (Exception ex)
            {

                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                             pFiltro.segUsuarioEdita, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return producto;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Producto
        /// En la BASE de DATO la Tabla : [Almacen.Producto]
        /// <summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public ReturnValor Insert(BEProducto producto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    AsignarValorPorDefecto(producto);
                    producto.PalabrasClaves = IntegrarPalabrasClaves(producto);

                    if (string.IsNullOrEmpty(producto.CodigoProducto))
                    {
                        producto.codProducto = oProductoData.InsertOutput(producto);
                        if (!string.IsNullOrEmpty(producto.CodigoProducto))
                        {
                            oReturnValor.Exitosa = true;
                            oReturnValor.CodigoRetorno = producto.CodigoProducto;
                            oReturnValor.codRetorno = producto.codProducto;
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(producto.CodigoProductoRefer))
                            producto.CodigoProductoRefer = producto.CodigoProducto;
                        oReturnValor.codRetorno = oProductoData.Insert(producto);
                        if (oReturnValor.codRetorno != 0)
                        {
                            oReturnValor.Exitosa = true;
                            producto.codProducto = oReturnValor.codRetorno;
                        }
                    }

                    bool indDeleteProveedor = true;
                    indDeleteProveedor = oProductoProveedoresData.Delete(new BEProductoProveedor
                    {
                        codEmpresa = producto.codEmpresa,
                        codProducto = producto.codProducto,
                        CodigoPersona = string.Empty,
                        segUsuarioElimina = producto.segUsuarioElimina,
                        segMaquinaElimina = producto.segMaquinaElimina
                    });
                    foreach (BEProductoProveedor productoProveedor in producto.listaProductoProveedores)
                    {
                        productoProveedor.codProducto = producto.codProducto;
                        productoProveedor.segUsuarioCrea = producto.segUsuarioCrea;
                        oProductoProveedoresData.Insert(productoProveedor);
                    }

                    if (producto.itemProductoFoto.FotografiaF != null)
                    {
                        producto.itemProductoFoto.codProducto = producto.codProducto;
                        producto.itemProductoFoto.segUsuarioCrea = producto.segUsuarioCrea;
                        oProductoFotosData.InsertUpdate(producto.itemProductoFoto);
                    }
                    //if (!producto.EsListaPrecio)
                    //{
                    //    List<BEPuntoDeVenta> lstPuntoDeVenta = new PuntoDeVentaLogic().List(new BaseFiltro
                    //    {
                    //        codPerEmpresa = producto.codPersonaEmpre,
                    //        indEstado = true
                    //    });
                    //    foreach (BEPuntoDeVenta puntoDeVenta in lstPuntoDeVenta)
                    //    {
                    //        producto.itemProductoPrecio.CodigoPuntoVenta = puntoDeVenta.codPuntoDeVenta;
                    //        producto.itemProductoPrecio.codProducto = producto.codProducto;
                    //        oProductoPrecioData.Insert(producto.itemProductoPrecio);
                    //    }
                    //}
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                        tx.Complete();
                    }
                    else
                        oReturnValor.Message = HelpMessages.gc_PRODUNoRegistrado;
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        private string IntegrarPalabrasClaves(BEProducto producto)
        {
            string palabrasClave = string.Empty;
            int v = 0;
            foreach (ProductoClave itemClave in producto.listaProductoClave)
            {
                if (v == 0)
                    palabrasClave = itemClave.DescripcionClave;
                else
                    palabrasClave = palabrasClave + "," + itemClave.DescripcionClave;
                ++v;
            }
            return palabrasClave;
        }

        private static void AsignarValorPorDefecto(BEProducto producto)
        {
            if (producto.CodigoArguSectorAlm == string.Empty)
                producto.CodigoArguSectorAlm = null;
            //if (producto.codDeposito == string.Empty)
            //    producto.codDeposito = null;
            if (producto.CodigoArguMetodoAlm == string.Empty)
                producto.CodigoArguMetodoAlm = null;
            if (producto.CodigoArguCentroProd == string.Empty)
                producto.CodigoArguCentroProd = null;
            if (producto.CodigoArguColor == string.Empty)
                producto.CodigoArguColor = null;
            if (producto.CodigoCuenta == string.Empty)
                producto.CodigoCuenta = null;
            if (producto.codMarca == 0)
                producto.codMarca = null;

            //if (producto.EsVerificacionStock)
            //    if (producto.codDeposito == null)
            //        producto.codDeposito = ConfigCROM.AppConfig(producto.codEmpresa, 
            //                                                    ConfigTool.DEFAULT_AlmacenPrincipal);

        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Producto
        /// En la BASE de DATO la Tabla : [Almacen.Producto]
        /// <summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public ReturnValor Update(BEProducto producto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    AsignarValorPorDefecto(producto);

                    //bool indEliminaProveedor;
                    //indEliminaProveedor = oProductoProveedoresData.Delete(new BEProductoProveedor
                    //{
                    //    codEmpresa = producto.codEmpresa,
                    //    codProducto = producto.codProducto,
                    //    CodigoPersona = string.Empty,
                    //    segUsuarioElimina = producto.segUsuarioElimina,
                    //    segMaquinaElimina = producto.segMaquinaElimina
                    //});
                    //foreach (BEProductoProveedor productoProveedor in producto.listaProductoProveedores)
                    //{
                        
                    //    productoProveedor.codProducto = producto.codProducto;
                    //    productoProveedor.segUsuarioCrea = producto.segUsuarioCrea;
                    //    productoProveedor.Estado = true;
                    //    oProductoProveedoresData.Insert(productoProveedor);
                    //}
                    producto.PalabrasClaves = IntegrarPalabrasClaves(producto);

                    if (string.IsNullOrEmpty(producto.CodigoProductoRefer))
                        producto.CodigoProductoRefer = producto.CodigoProducto;

                    oReturnValor.Exitosa = oProductoData.Update(producto, out string omessage);

                    //if (producto.itemProductoFoto.FotografiaF != null)
                    //{
                    //    producto.itemProductoFoto.codProducto = producto.codProducto;
                    //    producto.itemProductoFoto.segUsuarioCrea = producto.segUsuarioEdita;
                    //    oProductoFotosData.InsertUpdate(producto.itemProductoFoto);
                    //}
                    //if (!producto.EsListaPrecio)
                    //{
                    //    if (producto.indActualizaPrecioTodos)
                    //    {
                    //        List<BEPuntoDeVenta> lstPuntoDeVenta = new PuntoDeVentaLogic().List(new BaseFiltro
                    //        {
                    //            codPerEmpresa = producto.codPersonaEmpre,
                    //            indEstado = true
                    //        });
                    //        foreach (BEPuntoDeVenta puntoDeVenta in lstPuntoDeVenta)
                    //        {
                    //            producto.itemProductoPrecio.CodigoPuntoVenta = puntoDeVenta.codPuntoDeVenta;
                    //            producto.itemProductoPrecio.codProducto = producto.codProducto;
                    //            oProductoPrecioData.Insert(producto.itemProductoPrecio);
                    //        }
                    //    }
                    //}
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                                producto.segUsuarioEdita, producto.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.Producto
        /// En la BASE de DATO la Tabla : [Almacen.Producto]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public ReturnValor Delete(BEProducto pProducto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oProductoFotosData.Delete(0, pProducto.codEmpresa);

                    oReturnValor.Exitosa = oProductoExistenciaData.Delete(new BEProductoExistenciaFind
                    {
                        codEmpresa = pProducto.codEmpresa,
                        codProducto = pProducto.codProducto
                    });

                    var Proceso2 = oProductoData.Delete(pProducto);

                    if (oReturnValor.Exitosa && Proceso2.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                                pProducto.segUsuarioEdita, pProducto.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #endregion

        #region /* TABLA:=(Almacen.ProductoFoto) TABLA PRODUCTO_FOTOS_LOGO */

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Maestros.PersonasFotoLogo
        /// En la BASE de DATO la Tabla : [Maestros.PersonasFotoLogo]
        /// <summary>
        /// <param name="prm_codProducto"></param>
        /// <returns></returns>
        public BEProductoFoto FindProductoFotoData(int pcodEmpresa, int prm_codProducto, int pcodProductoFoto, string pUser)
        {
            BEProductoFoto productoFotoLogo = null;
            try
            {
                productoFotoLogo = oProductoFotosData.Find(pcodEmpresa, prm_codProducto, pcodProductoFoto);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                  pUser, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return productoFotoLogo;
        }

        public List<BEProductoFoto> ListProductoFotoData(int pcodEmpresa, int prm_codProducto, string pUser)
        {
            List<BEProductoFoto> ListProductoFotoLogo = new List<BEProductoFoto>();
            try
            {
                ListProductoFotoLogo = oProductoFotosData.List(pcodEmpresa, prm_codProducto);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                  pUser, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return ListProductoFotoLogo;
        }


        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo PersonasFotoLogo
        /// En la BASE de DATO la Tabla : [Maestros.PersonasFotoLogo]
        /// <summary>
        /// <param name="productoFoto"></param>
        /// <returns></returns>
        public ReturnValor InsertProductoFotoLogo(BEProductoFoto productoFoto)
        {
            string pMensaje = string.Empty;
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    var codRetorno = oProductoFotosData.InsertUpdate(productoFoto);
                    oReturnValor.Exitosa = codRetorno.ErrorCode > 0 ? true : false;
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_NEW;
                        tx.Complete();
                    }
                    else
                        oReturnValor.Message = codRetorno.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                               this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                               productoFoto.segUsuarioCrea, productoFoto.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.ProductoFotoLogo
        /// En la BASE de DATO la Tabla : [Almacen].[ProductoFoto]
        /// <summary>
        /// <param name="prm_CodigoPersona"></param>
        /// <returns></returns>
        public ReturnValor DeleteProductoFotoLogo(BaseFiltroAlmacen filtro)
        {
            string pMensaje = string.Empty;
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oProductoFotosData.Delete(filtro.codId.Value, filtro.codProducto.Value);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessages.Evento_DELETE;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name, filtro.segUsuarioEdita, 
                                filtro.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #endregion

        #region /* TABLA:=(Produccion.ProductoProveedores) PROVEEDORES DEL PRODUCTO / ARTÍCULO */

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Produccion.ProductoProveedores
        /// En la BASE de DATO la Tabla : [Produccion.ProductoProveedores]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEProductoProveedor> ListProductoProveedores(BaseFiltroProductoProveedor pFiltro)
        {
            List<BEProductoProveedor> lstProductoProveedor = new List<BEProductoProveedor>();
            try
            {
                lstProductoProveedor = oProductoProveedoresData.List(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstProductoProveedor;
        }

        public OperationResult ListProductoProveedoresPaged(BaseFiltroProductoProveedor pFiltro)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                var lstProductoProveedor = oProductoProveedoresData.ListPaged(pFiltro);
                int totalRecords = lstProductoProveedor.Select(x => x.TOTALROWS).FirstOrDefault();
                int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pFiltro.jqPageSize);

                var jsonGrid = new
                {
                    PageCount = totalPages,
                    CurrentPage = pFiltro.jqCurrentPage,
                    RecordCount = totalRecords,
                    Items = (
                        from item in lstProductoProveedor
                        select new
                        {
                            ID = item.codProductoProveedor,
                            Row = new string[]
                            {"", ""
                            , item.codPersonaNombre
                            , item.Estado.ToString()
                            , string.IsNullOrEmpty(item.segUsuarioEdita)?string.Empty:item.segUsuarioEdita
                            , item.segFechaEdita.HasValue?item.segFechaEdita.Value.ToString():string.Empty
                      }
                        }).ToArray()
                };

                operationResult.data = JsonConvert.SerializeObject(jsonGrid);
                operationResult.isValid = true;

               
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }

            return operationResult;
        }

        public BEProductoProveedor FindProductoProveedor(BaseFiltroProductoProveedor pFiltro)
        {
            BEProductoProveedor itemProductoProveedor = new BEProductoProveedor();
            try
            {
                itemProductoProveedor = oProductoProveedoresData.Find(pFiltro);
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioActual, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return itemProductoProveedor;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoProveedores
        /// En la BASE de DATO la Tabla : [Produccion.ProductoProveedores]
        /// <summary>
        /// <param name="itemProductoProveedores"></param>
        /// <returns></returns>
        public ReturnValor InsertUpdateProveedor(BEProductoProveedor productoProveedor)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.codRetorno = oProductoProveedoresData.Insert(productoProveedor);
                    if (oReturnValor.codRetorno != 0)
                    {
                        oReturnValor.Exitosa = true;
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                          productoProveedor.segUsuarioEdita, productoProveedor.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Produccion.Proeedores
        /// En la BASE de DATO la Tabla : [Produccion.Proeedores]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public ReturnValor DeleteProveedor(BEProductoProveedor pFiltro) 
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oProductoProveedoresData.Delete(pFiltro);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                           pFiltro.segUsuarioEdita, pFiltro.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #endregion

        #region /* TABLA:=(Almacen.ProductoSeriados) PRODUCTOS CON NUMEROS DE SERIES PRODUCTO / ARTÍCULO */

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.ProductoSeriados
        /// En la BASE de DATO la Tabla : [Almacen.ProductoSeriados]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<BEProductoSeriado> ListProductoSeriado(BaseFiltroAlmacen pFiltro) 
        {
            List<BEProductoSeriado> lstProductoSeriado = new List<BEProductoSeriado>();
            try
            {
                lstProductoSeriado = oProductoSeriadosData.List(pFiltro); 
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pFiltro.segUsuarioEdita, pFiltro.codEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return lstProductoSeriado;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Almacen.ProductoSeriados
        /// En la BASE de DATO la Tabla : [Almacen.ProductoSeriados]
        /// <summary>
        /// <param name="productoSeriado"></param>
        /// <returns></returns>
        public ReturnValor InsertProductoSeriado(BEProductoSeriado productoSeriado)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.codRetorno = oProductoSeriadosData.Insert(productoSeriado);
                    if (oReturnValor.codRetorno != 0)
                    {
                        oReturnValor.Exitosa = true;
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name), 
                                productoSeriado.SegUsuarioEdita, productoSeriado.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        public List<BEProductoSeriado> InsertProductoSeriado(List<BEProductoSeriado> lstProductoSeriado, 
                                                             string pUsuarioEdita, int pcodEmpresa)
        {
            List<BEProductoSeriado> lstProductoSeriadoRetorno = null;
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    lstProductoSeriadoRetorno = oProductoSeriadosData.Insert(lstProductoSeriado);
                    if (lstProductoSeriadoRetorno.Count == lstProductoSeriado.Count)
                    {
                        oReturnValor.Exitosa = true;
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                                pUsuarioEdita, pcodEmpresa.ToString());
            }
            return lstProductoSeriadoRetorno;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Almacen.ProductoSeriados
        /// En la BASE de DATO la Tabla : [Almacen.ProductoSeriados]
        /// <summary>
        /// <param name="productoSeriado"></param>
        /// <returns></returns>
        public ReturnValor UpdateProductoSeriado(BEProductoSeriado productoSeriado)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    List<BEProductoSeriado> lstProductoSeriado = new List<BEProductoSeriado>();
                    lstProductoSeriado.Add(productoSeriado);
                    oReturnValor.Exitosa = oProductoSeriadosData.Update(lstProductoSeriado);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                                productoSeriado.segUsuarioEdita, productoSeriado.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        public ReturnValor UpdateProductoSeriado(List<BEProductoSeriado> lstProductoSeriado, string pUsuarioEdita,
                                                 int pcodEmpresa)
        {
            try
            {
                //using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                //{
                    oReturnValor.Exitosa = oProductoSeriadosData.Update(lstProductoSeriado);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        //tx.Complete();
                    }
                //}
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                                pUsuarioEdita, pcodEmpresa.ToString());
            }
            return oReturnValor;
        }

        public ReturnValor UpdateProductoSeriadoDatoIngreso(BEProductoSeriado productoSeriado)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    List<BEProductoSeriado> lstProductoSeriado = new List<BEProductoSeriado>();
                    lstProductoSeriado.Add(productoSeriado);
                    oReturnValor.Exitosa = oProductoSeriadosData.UpdateDatoIngreso(lstProductoSeriado);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                                productoSeriado.segUsuarioEdita, productoSeriado.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        public ReturnValor UpdateProductoSeriadoConsignacion(List<BEProductoSeriado> lstProductoSeriado,
                                                             string pUsuarioEdita, int pcodEmpresa)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oProductoSeriadosData.UpdateConsignacion(lstProductoSeriado);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                                pUsuarioEdita, pcodEmpresa.ToString());
            }
            return oReturnValor;
        }
      
        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.ProductoSeriados
        /// En la BASE de DATO la Tabla : [Almacen.ProductoSeriados]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor DeleteProductoSeriado(BaseFiltroAlmacen pFiltro) 
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oProductoSeriadosData.Delete(pFiltro);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                                pFiltro.segUsuarioEdita, pFiltro.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        public ReturnValor DeleteProductoSeriadoPorDetalle(BaseFiltroAlmacen pFiltro)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oProductoSeriadosData.DeleteDetalleDocum(pFiltro);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpException.mTraerMensaje(ex, false,
                                string.Concat(GetType().Name, ".", MethodBase.GetCurrentMethod().Name),
                                pFiltro.segUsuarioEdita, pFiltro.codEmpresa.ToString());
            }
            return oReturnValor;
        }

        #endregion

        #endregion

        #region /* TABLA:=(Produccion.ProductoKardex) PRODUCTOS CON MOVIMIENTOS EN EL KARDEX */

        public List<ProductoKardexAux> ListKardex(BaseFiltroAlmacen filtro) 
        {
            List<ProductoKardexAux> lstProductoKardex = new List<ProductoKardexAux>();
            try
            {
                filtro.fecInicio = HelpTime.ConvertYYYYMMDD(filtro.fecInicioDate);
                filtro.fecFinal = HelpTime.ConvertYYYYMMDD(filtro.fecFinalDate);
                lstProductoKardex = oProductoExistenciasKardexData.List(filtro); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductoKardex;
        }
   
        public List<ProductoKardexAux> ListKardexValorizado(BaseFiltroAlmacen filtro) 
        {
            filtro.fecInicio = HelpTime.ConvertYYYYMMDD(filtro.fecInicioDate);
            filtro.fecFinal = HelpTime.ConvertYYYYMMDD(filtro.fecFinalDate);
            List<ProductoKardexAux> listaProcesada = new List<ProductoKardexAux>();
            List<ProductoKardexAux> listaProductoKardex = new List<ProductoKardexAux>();
            try
            {
                listaProductoKardex = oProductoData.ListParaValorizado(filtro);
                var productos = (from producto in listaProductoKardex
                                 select new
                                 {
                                     producto.codProducto
                                 }).Distinct();


                productos.ToList().ForEach(p =>
                {
                    var producto = from filtroProducto in listaProductoKardex
                                   where filtroProducto.codProducto == p.codProducto
                                   select filtroProducto;

                    listaProcesada.AddRange(RealizarCalculos(producto));
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaProcesada;
        }
  
        private IEnumerable<ProductoKardexAux> RealizarCalculos(IEnumerable<ProductoKardexAux> producto)
        {
            decimal? costoUnitProm = 0;
            decimal? cantidadTotal = 0;
            decimal? subTotalEntrada = 0;
            decimal? montoTotal = 0;
            producto.ToList().ForEach(pr =>
            {
                if (pr.indMovimiento == 1)
                {
                    cantidadTotal = cantidadTotal + pr.cntRegistrado;
                    subTotalEntrada = pr.cntRegistrado * pr.monRegistrado;

                    if (costoUnitProm == 0)
                    {
                        montoTotal = subTotalEntrada;
                        costoUnitProm = pr.monRegistrado;
                    }
                    else if (costoUnitProm != pr.monRegistrado)
                    {
                        decimal hallarCosto = Convert.ToDecimal(montoTotal + (pr.cntRegistrado * pr.monRegistrado));
                        if (cantidadTotal == 0)
                            cantidadTotal = 1;
                        costoUnitProm = (Math.Round(hallarCosto / Convert.ToDecimal(cantidadTotal), 2));
                        montoTotal = montoTotal + (pr.cntRegistrado * pr.monRegistrado);

                    }

                    pr.cntEntrada = pr.cntRegistrado;
                    pr.monCostoUnitEntrada = pr.monRegistrado;
                    pr.monTotalEntrada = subTotalEntrada;

                    pr.monTotalSaldo = montoTotal;
                    pr.monCostoUnitSaldo = costoUnitProm;
                    pr.cntSaldo = cantidadTotal;

                }
                else if (pr.indMovimiento == -1)
                {
                    pr.cntSalida = pr.cntRegistrado;
                    pr.monCostoUnitSalida = costoUnitProm;
                    pr.monTotalSalida = pr.cntRegistrado * costoUnitProm;

                    montoTotal = montoTotal - (pr.cntRegistrado * costoUnitProm);
                    pr.monTotalSaldo = montoTotal;
                    pr.monCostoUnitSaldo = costoUnitProm;

                    cantidadTotal = cantidadTotal - pr.cntRegistrado; ;
                    pr.cntSaldo = cantidadTotal;
                }
            });
            return producto;
        }

        #endregion

        #region /* TABLA:=(Almacen.ProductoExistencia) PRODUCTO / ARTÍCULO */

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoKardexAux
        /// En la BASE de DATO la Tabla : [Produccion.ProductoExistenciasKardex]
        /// <summary>
        /// <param name="productoExistencia"></param>
        /// <returns></returns>
        public ReturnValor InsertUpdateProductoExistencia(BEProductoExistencia productoExistencia)
        {
            ReturnValor objReturnValor = new ReturnValor();
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    objReturnValor.codRetorno = oProductoExistenciaData.InsertUpdate(productoExistencia);
                    if (objReturnValor.codRetorno > 0)
                    {
                        objReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
                        objReturnValor.Exitosa = true;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                objReturnValor = HelpException.mTraerMensaje(ex);
            }
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD - ACTUALIZADOR DE STOCKS*/

        /// <summary>
        /// ACTUALIZA el registro de una ENTIDAD de registro de Tipo ProductoExistencias
        /// En la BASE de DATO la Tabla : [Almacen.ProductoExistencias]
        /// <summary>
        /// <param name="filtro"></param>
        /// <param name="prm_SALDO_StockFisico"></param>
        /// <returns></returns>
        public ReturnValor UpdateProductoExistenciaStockInicial(BEProductoExistenciaUpdate pUpdate, ref decimal? pSALDO_StockFisico)
        {
            ReturnValor objReturnValor = new ReturnValor();
            try
            {
                //using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                //{
                decimal? cantSALDO_StokFisico = 0;
                objReturnValor.codRetorno = oProductoExistenciaData.UpdateStockInicial(pUpdate, ref cantSALDO_StokFisico);
                if (objReturnValor.codRetorno > 0)
                {
                    objReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                    objReturnValor.Exitosa = true;
                    //tx.Complete();
                }

                pSALDO_StockFisico = cantSALDO_StokFisico;
                //}
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat(this.GetType().Name, ".", MethodBase.GetCurrentMethod().Name), ex, pUpdate.segUsuarioEdita);
                objReturnValor = HelpException.mTraerMensaje(ex);
                
            }
            return objReturnValor;
        }

        /// <summary>
        /// ACTUALIZA el registro de una ENTIDAD de registro de Tipo ProductoExistencias
        /// En la BASE de DATO la Tabla : [Almacen.ProductoExistencias]
        /// <summary>
        /// <param name="filtro"></param>
        /// <param name="prm_SALDO_StockFisico"></param>
        /// <returns></returns>
        public ReturnValor UpdateProductoExistenciaStockInicial(BEProductoExistenciaStockUpdate pUpdate)
        {
            ReturnValor objReturnValor = new ReturnValor();
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    objReturnValor.Exitosa = oProductoExistenciaData.UpdateStockInicial(pUpdate);
                    if (objReturnValor.Exitosa)
                    {
                        objReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        objReturnValor.Exitosa = true;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objReturnValor;
        }

        /// <summary>
        /// ACTUALIZA el registro de una ENTIDAD de registro de Tipo ProductoExistencias
        /// En la BASE de DATO la Tabla : [Almacen.ProductoExistencias]
        /// <summary>
        /// <param name="filtro"></param>
        /// <param name="prm_SALDO_StockFisico"></param>
        /// <returns></returns>
        public ReturnValor UpdateProductoExistenciaStockFisico(BEProductoExistenciaStockUpdate pUpdate, ref decimal? pSALDO_StockFisico)
        {
            ReturnValor objReturnValor = new ReturnValor();
            try
            {
                //using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                //{
                    decimal? cantSALDO_StokFisico = 0;
                    objReturnValor.Exitosa = oProductoExistenciaData.UpdateStockFisico(pUpdate, ref cantSALDO_StokFisico);
                    if (objReturnValor.Exitosa)
                    {
                        objReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        objReturnValor.Exitosa = true;
                        //tx.Complete();
                    }
                    pSALDO_StockFisico = cantSALDO_StokFisico;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objReturnValor;
        }

        /// <summary>
        /// ACTUALIZA el registro de una ENTIDAD de registro de Tipo ProductoExistencias
        /// En la BASE de DATO la Tabla : [Almacen.ProductoExistencias]
        /// <summary>
        /// <param name="filtro"></param>
        /// <param name="prm_SALDO_StockFisico"></param>
        /// <returns></returns>
        public ReturnValor UpdateProductoExistenciaStockFisicoConsig(BEProductoExistenciaStockUpdate pUpdate, ref decimal? pSALDO_StockFisico)
        {
            ReturnValor objReturnValor = new ReturnValor();
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    decimal? cantSALDO_StokFisico = 0;
                    objReturnValor.Exitosa = oProductoExistenciaData.UpdateStockFisicoConsig(pUpdate, ref cantSALDO_StokFisico);
                    if (objReturnValor.Exitosa)
                    {
                        objReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        objReturnValor.Exitosa = true;
                        tx.Complete();
                    }
                    pSALDO_StockFisico = cantSALDO_StokFisico;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objReturnValor;
        }

        /// <summary>
        /// ACTUALIZA el registro de una ENTIDAD de registro de Tipo ProductoExistencias
        /// En la BASE de DATO la Tabla : [Almacen.ProductoExistencias]
        /// <summary>
        /// <param name="filtro"></param>
        /// <param name="prm_SALDO_StockFisico"></param>
        /// <returns></returns>
        public ReturnValor UpdateProductoExistenciaStockFisicoInventario(BEProductoExistenciaStockUpdate pUpdate,
                                                                         ref decimal? pSALDO_StockMerma,
                                                                         ref decimal? pSALDO_StockSobrante)
        {
            ReturnValor objReturnValor = new ReturnValor();
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    decimal? cantSALDO_StockMerma = 0;
                    decimal? cantSALDO_StockSobrante = 0;
                    objReturnValor.Exitosa = oProductoExistenciaData.UpdateStockFisicoInventario(pUpdate, 
                                                                                                 ref cantSALDO_StockMerma,
                                                                                                 ref cantSALDO_StockSobrante);
                    if (objReturnValor.Exitosa)
                    {
                        objReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        objReturnValor.Exitosa = true;
                        tx.Complete();
                    }
                    pSALDO_StockMerma = cantSALDO_StockMerma;
                    pSALDO_StockSobrante = cantSALDO_StockSobrante;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objReturnValor;
        }

        /// <summary>
        /// ACTUALIZA el registro de una ENTIDAD de registro de Tipo ProductoExistencias
        /// En la BASE de DATO la Tabla : [Almacen.ProductoExistencias]
        /// <summary>
        /// <param name="filtro"></param>
        /// <param name="prm_SALDO_StockFisico"></param>
        /// <returns></returns>
        public ReturnValor UpdateProductoExistenciaStockFisicoInventarioAnterior(BEProductoExistenciaStockUpdate pFiltro)
        {
            ReturnValor objReturnValor = new ReturnValor();
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    objReturnValor.Exitosa = oProductoExistenciaData.UpdateStockFisicoInventarioAnterior(pFiltro);
                    if (objReturnValor.Exitosa)
                    {
                        objReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        objReturnValor.Exitosa = true;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objReturnValor;
        }

        /// <summary>
        /// ACTUALIZA el registro de una ENTIDAD de registro de Tipo ProductoExistencias
        /// En la BASE de DATO la Tabla : [Almacen.ProductoExistencias]
        /// <summary>
        /// <param name="filtro"></param>
        /// <param name="prm_SALDO_StockFisico"></param>
        /// <returns></returns>
        public ReturnValor UpdateProductoExistenciaStockComprometido(BEProductoExistenciaStockUpdate pUpdate, ref decimal? pSALDO_StockComprometido)
        {
            ReturnValor objReturnValor = new ReturnValor();
            try
            {
                //using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                //{
                    decimal? cantSALDO_StokComprometido = 0;
                    objReturnValor.Exitosa = oProductoExistenciaData.UpdateStockComprometido(pUpdate, ref cantSALDO_StokComprometido);
                    if (objReturnValor.Exitosa)
                    {
                        objReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
                        objReturnValor.Exitosa = true;
                        //tx.Complete();
                    }
                    pSALDO_StockComprometido = cantSALDO_StokComprometido;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// Elimina el registro de una ENTIDAD de registro de Tipo ProductoExistencia
        /// En la BASE de DATO la Tabla : [Produccion.ProductoExistencia]
        /// <summary>
        /// <param name="productoKardex"></param>
        /// <returns></returns>
        public ReturnValor DeleteProductoExistencia(BEProductoExistenciaFind pFiltro)
        {
            ReturnValor objReturnValor = new ReturnValor();
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    objReturnValor.Exitosa = oProductoExistenciaData.Delete(pFiltro);
                    if (objReturnValor.Exitosa)
                    {
                        objReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
                        objReturnValor.Exitosa = true;
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                objReturnValor = HelpException.mTraerMensaje(ex);
            }
            return objReturnValor;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */
        public List<BEProductoExistencia> FindProductoExistencia(BEProductoExistenciaFind filtro)
        {
            List<BEProductoExistencia> lstProductoExistencia = new List<BEProductoExistencia>();
            try
            {
                lstProductoExistencia = oProductoExistenciaData.Find(filtro); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductoExistencia;
        }

        #endregion

        #endregion

        public List<DTOProductoResponse> ListParaInventario(BaseFiltroProducto filtro) 
        {
            List<DTOProductoResponse> lstProducto = new List<DTOProductoResponse>();
            try
            {
                lstProducto = oProductoData.ListParaInventario(filtro); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProducto;
        }
       
        public List<DTOProductoResponse> ListParaStockInicial(BaseFiltroProducto filtro) 
        {
            List<DTOProductoResponse> lstProducto = new List<DTOProductoResponse>();
            try
            {
                lstProducto = oProductoData.ListParaStockInicial(filtro); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProducto;
        }
        
        public List<BEProducto> ListProductoSinListaPrecio(BaseFiltroAlmacen filtro) 
        {
            List<BEProducto> lstProducto = new List<BEProducto>();
            try
            {
                lstProducto = oProductoData.ListProductoSinListaPrecio(filtro); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProducto;
        }

        public List<ProductoCodBarras> ListParaCodBarras(BaseFiltroAlmacen filtro) 
        {
            List<ProductoCodBarras> lstProductoCodBarra = new List<ProductoCodBarras>();
            try
            {
                lstProductoCodBarra = oProductoData.ListParaCodBarras(filtro); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductoCodBarra;
        }


        /*
         
         * (Delete) AL ELIMINAR UN PRODUCTO DEBE DE BORRAR TAMBIEN EN PRODUCTOPRECIO- Deberia de ser Eliminado logico por el historial que pùeda existir ala fecha
         * (Find)   AL BUCAR UN PRODUCTO ESTA OBTENIENTO EL TIPO DE CAMBIO PARA LISTAR LAS VENTAS DEL PRODUCTO, PRODUCTOPRECIO Y OBTIENE ListaDePrecioDetalleData
         * (FindCodigoProductoEmpresa)
         * (Insert) SI EL PRODUCTO NO ESTA EN LA LISTA DE PRECIO GUARDA EN LA TABLA PRODUCTO_PRECIO
         * (Update) SI EL PRODUCTO NO ESTA EN LA LISTA DE PRECIO GUARDA EN LA TABLA PRODUCTO_PRECIO
         */


        //#region /* TABLA:=(GestionComercial.ProductoPrecio) PRODUCTOS COMPUESTOS */

        //public List<BEProductoPrecio> ListProductoPrecio(BaseFiltro filtro)
        //{
        //    List<BEProductoPrecio> lstProductoPrecio = new List<BEProductoPrecio>();
        //    try
        //    {
        //        lstProductoPrecio = oProductoPrecioData.List(filtro);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lstProductoPrecio;
        //}

        //#endregion

        // /// <summary>
        ///// Almacena el registro de una ENTIDAD de registro de Tipo ProductoPrecio
        ///// En la BASE de DATO la Tabla : [GestionComercial.ProductoPrecio]
        ///// <summary>
        ///// <param name="productoPrecio"></param>
        ///// <returns></returns>
        //public ReturnValor InsertProductoPrecio(BEProductoPrecio productoPrecio)
        //{
        //    oProductoPrecioData = new ProductoPrecioData();
        //    try
        //    {
        //        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
        //        {
        //            oReturnValor.codRetorno = oProductoPrecioData.Insert(productoPrecio);
        //            if (oReturnValor.codRetorno != 0)
        //            {
        //                oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
        //                tx.Complete();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oReturnValor = HelpException.mTraerMensaje(ex);
        //    }
        //    return oReturnValor;
        //}
    }
}






#region /* TABLA:=(Almacen.ProductoPartesCompuesta) PRODUCTOS COMPUESTOS */

#region /* Proceso de SELECT ALL [Almacen.ProductoPartesCompuesta]*/
///// <summary>
///// Retorna un LISTA de registros de la Entidad Almacen.ProductoPartesCompuesta
///// En la BASE de DATO la Tabla : [Almacen.ProductoPartesCompuesta]
///// <summary>
///// <returns>List</returns>
//public List<BEProductoParteCompuesta> ListPartesCompuesta(string prm_CodigoProducto, string prm_CodigoProductoParte)
//{
//    List<BEProductoParteCompuesta> miLista = new List<BEProductoParteCompuesta>();
//    try
//    {
//        miLista = oProductoPartesCompuestaData.List(prm_CodigoProducto, prm_CodigoProductoParte);
//    }
//    catch (Exception ex)
//    {
//        throw ex;
//    }
//    return miLista;
//}

#endregion

#region /* Proceso de SELECT BY ID CODE [Almacen.ProductoPartesCompuesta]*/

///// <summary>
///// Retorna una ENTIDAD de registro de la Entidad Almacen.ProductoPartesCompuesta
///// En la BASE de DATO la Tabla : [Almacen.ProductoPartesCompuesta]
///// <summary>
///// <returns>Entidad</returns>
//public BEProductoParteCompuesta FindPartesCompuesta(string prm_CodigoProducto, string prm_CodigoProductoParte)
//{
//    BEProductoParteCompuesta miEntidad = new BEProductoParteCompuesta();
//    try
//    {
//        miEntidad = oProductoPartesCompuestaData.Find(prm_CodigoProducto, prm_CodigoProductoParte);
//    }
//    catch (Exception ex)
//    {
//        throw ex;
//    }
//    return miEntidad;
//}

#endregion

#region /* Proceso de INSERT RECORD [Almacen.ProductoPartesCompuesta]*/

///// <summary>
///// Almacena el registro de una ENTIDAD de registro de Tipo ProductoPartesCompuesta
///// En la BASE de DATO la Tabla : [Almacen.ProductoPartesCompuesta]
///// <summary>
///// <param name = >itemProductoPartesCompuesta</param>
//public ReturnValor InsertPartesCompuesta(BEProductoParteCompuesta itemProductoPartesCompuesta)
//{
//    try
//    {
//        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
//        {
//            oReturnValor.Exitosa = oProductoPartesCompuestaData.Insert(itemProductoPartesCompuesta);
//            if (oReturnValor.Exitosa)
//            {
//                oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
//                tx.Complete();
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        oReturnValor = HelpException.mTraerMensaje(ex);
//    }
//    return oReturnValor;
//}

#endregion

#region /* Proceso de UPDATE RECORD [Almacen.ProductoPartesCompuesta]*/

///// <summary>
///// Almacena el registro de una ENTIDAD de registro de Tipo ProductoPartesCompuesta
///// En la BASE de DATO la Tabla : [Almacen.ProductoPartesCompuesta]
///// <summary>
///// <param name = >itemProductoPartesCompuesta</param>
//public ReturnValor UpdatePartesCompuesta(BEProductoParteCompuesta itemProductoPartesCompuesta)
//{
//    try
//    {
//        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
//        {
//            oReturnValor.Exitosa = oProductoPartesCompuestaData.Update(itemProductoPartesCompuesta);
//            if (oReturnValor.Exitosa)
//            {
//                oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
//                tx.Complete();
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        oReturnValor = HelpException.mTraerMensaje(ex);
//    }
//    return oReturnValor;
//}

#endregion

#region /* Proceso de DELETE BY ID CODE [Almacen.ProductoPartesCompuesta]*/

///// <summary>
///// ELIMINA un registro de la Entidad Almacen.ProductoPartesCompuesta
///// En la BASE de DATO la Tabla : [Almacen.ProductoPartesCompuesta]
///// <summary>
///// <returns>bool</returns>
//public ReturnValor DeletePartesCompuesta(string prm_CodigoProducto, string prm_CodigoProductoParte)
//{
//    try
//    {
//        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
//        {
//            oReturnValor.Exitosa = oProductoPartesCompuestaData.Delete(prm_CodigoProducto, prm_CodigoProductoParte);
//            if (oReturnValor.Exitosa)
//            {
//                oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
//                tx.Complete();
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        oReturnValor = HelpException.mTraerMensaje(ex);
//    }
//    return oReturnValor;
//}

#endregion

#endregion

#region /* TABLA:=(Produccion.ProductoPartes) PARTES DE PRODUCTO / ARTÍCULO */

#region /* Proceso de SELECT ALL [Produccion.ProductoPartes]*/

///// <summary>
///// Retorna un LISTA de registros de la Entidad Produccion.ProductoPartes
///// En la BASE de DATO la Tabla : [Produccion.ProductoPartes]
///// <summary>
///// <returns>List</returns>
//public List<ProductoPartes> List(string prm_codPersonaEmpre, string prm_CodigoProducto, string prm_CodigoArguParteProdu, bool prm_Estado)
//{
//    List<ProductoPartes> miLista = new List<ProductoPartes>();
//    try
//    {
//        miLista = oProductoPartesData.List(prm_codPersonaEmpre, prm_CodigoProducto, prm_CodigoArguParteProdu, prm_Estado);
//    }
//    catch (Exception ex)
//    {
//        throw ex;
//    }
//    return miLista;
//}

#endregion

#region /* Proceso de INSERT RECORD [Produccion.ProductoPartes]*/

///// <summary>
///// Almacena el registro de una ENTIDAD de registro de Tipo ProductoPartes
///// En la BASE de DATO la Tabla : [Produccion.ProductoPartes]
///// <summary>
///// <param name = >itemProductoPartes</param>
//public ReturnValor InsertUpdate(ProductoPartes itemProductoPartes)
//{
//    try
//    {
//        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
//        {
//            oReturnValor.Exitosa = oProductoPartesData.InsertUpdate(itemProductoPartes);
//            if (oReturnValor.Exitosa)
//            {
//                oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
//                tx.Complete();
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        oReturnValor = HelpException.mTraerMensaje(ex);
//    }
//    return oReturnValor;
//}

#endregion

#region /* Proceso de DELETE BY ID CODE [Produccion.ProductoPartes]*/

///// <summary>
///// ELIMINA un registro de la Entidad Produccion.ProductoPartes
///// En la BASE de DATO la Tabla : [Produccion.ProductoPartes]
///// <summary>
///// <returns>bool</returns>
//public ReturnValor Delete(string prm_codPersonaEmpre, string prm_CodigoProducto, string prm_CodigoArguParteProdu)
//{
//    try
//    {
//        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
//        {
//            oReturnValor.Exitosa = oProductoPartesData.Delete(prm_codPersonaEmpre, prm_CodigoProducto, prm_CodigoArguParteProdu);
//            if (oReturnValor.Exitosa)
//            {
//                oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
//                tx.Complete();
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        oReturnValor = HelpException.mTraerMensaje(ex);
//    }
//    return oReturnValor;
//}

#endregion

#endregion

#region /* TABLA:=(Produccion.ProductoPartesAtributo) ATRIBUTOS DE PARTES DE PRODUCTO / ARTÍCULO */

#region /* Proceso de SELECT ALL [Produccion.ProductoPartesAtributo]/

/// <summary>
/// Retorna un LISTA de registros de la Entidad Produccion.ProductoPartesAtributo
/// En la BASE de DATO la Tabla : [Produccion.ProductoPartesAtributo]
/// <summary>
/// <returns>List</returns>
//public List<BEProductoParteAtributo> ListParteAtributo(string prm_CodigoProducto, string prm_CodigoArguParteProdu, string prm_CodigoArguAtributoPP, bool prm_Estado)
//{
//    List<BEProductoParteAtributo> miLista = new List<BEProductoParteAtributo>();
//    try
//    {
//        miLista = oProductoPartesAtributoData.List(prm_CodigoProducto, prm_CodigoArguParteProdu, prm_CodigoArguAtributoPP, prm_Estado);
//    }
//    catch (Exception ex)
//    {
//        throw ex;
//    }
//    return miLista;
//}

#endregion

#region /* Proceso de INSERT RECORD [Produccion.ProductoPartesAtributo]*/

/// <summary>
/// Almacena el registro de una ENTIDAD de registro de Tipo ProductoPartesAtributo
/// En la BASE de DATO la Tabla : [Produccion.ProductoPartesAtributo]
/// <summary>
/// <param name = >itemProductoPartesAtributo</param>
//public ReturnValor InsertUpdate(BEProductoParteAtributo itemProductoPartesAtributo)
//{
//    try
//    {
//        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
//        {
//            oReturnValor.Exitosa = oProductoPartesAtributoData.InsertUpdate(itemProductoPartesAtributo);
//            if (oReturnValor.Exitosa)
//            {
//                oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
//                tx.Complete();
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        oReturnValor = HelpException.mTraerMensaje(ex);
//    }
//    return oReturnValor;
//}

#endregion

#region /* Proceso de DELETE BY ID CODE [Produccion.ProductoPartesAtributo]*/

/// <summary>
/// ELIMINA un registro de la Entidad Produccion.ProductoPartesAtributo
/// En la BASE de DATO la Tabla : [Produccion.ProductoPartesAtributo]
/// <summary>
/// <returns>bool</returns>
//public ReturnValor DeleteParteAtributo(string prm_CodigoProducto, string prm_CodigoArguParteProdu, string prm_CodigoArguAtributoPP)
//{
//    try
//    {
//        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
//        {
//            oReturnValor.Exitosa = oProductoPartesAtributoData.Delete(prm_CodigoProducto, prm_CodigoArguParteProdu, prm_CodigoArguAtributoPP);
//            if (oReturnValor.Exitosa)
//            {
//                oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
//                tx.Complete();
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        oReturnValor = HelpException.mTraerMensaje(ex);
//    }
//    return oReturnValor;
//}

#endregion

#endregion

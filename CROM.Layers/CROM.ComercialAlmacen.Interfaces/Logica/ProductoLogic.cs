namespace CROM.ComercialAlmacen.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Transactions;
    using System.Linq;

    using CROM.BusinessEntities.Almacen;
    using CROM.GestionAlmacen.DataAccess;
    using CROM.GestionComercial.DataAccess;
    using CROM.GestionComercial.BusinessLogic;
    using CROM.Tools.Comun;
    using CROM.Tools.Config;
    using CROM.BusinessEntities.Comercial;
    
    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Almacen.ProductoLogic.cs]
    /// </summary>
    public class ProductoLogic
    {
        private ProductoData oProductoData = null;
        private ProductoFotoData oProductoFotosData = null;
        private ProductoProveedoresData oProductoProveedoresData = null;
        private ProductoExistenciasData oProductoExistenciasData = null;
        private ProductoPartesAtributoData oProductoPartesAtributoData = null;
        private ProductoSeriadosData oProductoSeriadosData = null;
        private ProductoExistenciasKardexData oProductoExistenciasKardexData = null;
        private ComprobanteEmisionData oComprobanteEmisionData = null;
        private ComprobanteEmisionDetalleData oComprobanteEmisionDetalleData = null;
        private InventarioData oInventariosData = null;
        private ProductoPartesCompuestaData oProductoPartesCompuestaData = null;
        private ProductoPrecioData oProductoPrecioData = null;

        private ReturnValor oReturnValor = null;

        public ProductoLogic()
        {
            oProductoData = new ProductoData();
            oProductoFotosData = new ProductoFotoData();
            oProductoProveedoresData = new ProductoProveedoresData();
            oProductoExistenciasData = new ProductoExistenciasData();
            oProductoPartesAtributoData = new ProductoPartesAtributoData();
            oProductoSeriadosData = new ProductoSeriadosData();
            oProductoExistenciasKardexData = new ProductoExistenciasKardexData();
            oComprobanteEmisionData = new ComprobanteEmisionData();
            oComprobanteEmisionDetalleData = new ComprobanteEmisionDetalleData();
            oInventariosData = new InventarioData();
            oProductoPartesCompuestaData = new ProductoPartesCompuestaData();
            oProductoPrecioData = new ProductoPrecioData();
            oReturnValor = new ReturnValor();
        }

        #region /* TABLA:=(Almacen.Producto) PRODUCTO / ARTÍCULO */

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Producto
        /// En la BASE de DATO la Tabla : [Almacen.Producto]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<BEProducto> List(BaseFiltroAlmacen filtro) // string prm_codPersonaEmpre, string prm_codDeposito, string prm_CodigoProductoRefer, string prm_CodigoGrupoArticulo, string prm_Descripcion, string prm_DescripcionComercial, string prm_CodigoArguMarcaProdu, string prm_CodigoArguTipoProducto, bool prm_DestinadoACompra, bool prm_DestinadoAVenta, string prm_CodigoArguCentroProd, string prm_CodigoArguCategoProd, string prm_CodigoArguUnidadMed, bool prm_Estado, string prm_PalabrasClaves, bool prm_Todos)
        {
            List<BEProducto> lstProducto = new List<BEProducto>();
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
        public List<BEProducto> List(BaseFiltroAlmacen filtro, Helper.ComboBoxText pTexto) //string prm_codPersonaEmpre, string prm_codDeposito, string prm_CodigoProductoRefer, string prm_CodigoGrupoArticulo, string prm_Descripcion, string prm_DescripcionComercial, string prm_CodigoArguMarcaProdu, string prm_CodigoArguTipoProducto, bool prm_DestinadoACompra, bool prm_DestinadoAVenta, string prm_CodigoArguCentroProd, string prm_CodigoArguCategoProd, string prm_CodigoArguUnidadMed, bool prm_Estado, string prm_PalabrasClaves, bool prm_Todos
        {
            List<BEProducto> lstProducto = new List<BEProducto>();
            try
            {
                if (string.IsNullOrEmpty(filtro.numSerieProducto))
                    lstProducto = oProductoData.List(filtro);
                else
                    lstProducto = oProductoData.ListNumSerie(filtro);

                if (lstProducto.Count > 0)
                    lstProducto.Insert(0, new BEProducto { codProducto = 0, Descripcion = Helper.ObtenerTexto(pTexto) });
                else
                    lstProducto.Add(new BEProducto { codProducto = 0, Descripcion = Helper.ObtenerTexto(pTexto) });
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
        /// <param name="filtro"></param>
        /// <returns></returns>
        public BEProducto Find(BaseFiltroAlmacen filtro)
        {
            BEProducto producto = new BEProducto();
            try
            {
                if (filtro.codProductoRefer != null)
                    producto = oProductoData.Find(filtro.codProductoRefer);
                else
                    producto = oProductoData.Find(filtro.codProducto.Value);

                if (producto != null)
                {
                    if (filtro.codProducto == null)
                        filtro.codProducto = producto.codProducto;
                    producto.itemProductoFoto = oProductoFotosData.Find(filtro);
                    producto.itemProductoExistencias = oProductoExistenciasData.Find(filtro);
                    foreach (BEProductoExistencia productoExistencia in producto.itemProductoExistencias)
                    {
                        productoExistencia.listaInventario = oInventariosData.List(filtro);
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
                    producto.listaProductoProveedores = oProductoProveedoresData.List(filtro);
                    producto.listaProductoProductoSeriados = oProductoSeriadosData.List(filtro);

                    filtro.fecInicio = HelpTime.ConvertYYYYMMDD(DateTime.Now.AddDays(DateTime.Now.DayOfYear * -1));
                    filtro.fecFinal = HelpTime.ConvertYYYYMMDD(DateTime.Now);
                    producto.listaProductoKardex = oProductoExistenciasKardexData.List(filtro);

                    BETipoDeCambio tipoDeCambio = new BETipoDeCambio();
                    tipoDeCambio = new TipoDeCambioLogic().Find(new BaseFiltro
                    {
                        fecInicioDate = DateTime.Now,
                        codRegMoneda = ConfigCROM.AppConfig(ConfigTool.DEFAULT_MonedaInt)
                    });
                    if (tipoDeCambio != null)
                        producto.listaProductoVentas = new ConsultasGCLogic().ListProductoVentasCompras(filtro.codProducto, 
                                                                                                        filtro.codPerEmpresa,
                                                                                                        filtro.codDeposito, 
                                                                                                        filtro.codPuntoVenta, 
                                                                                                        DateTime.Now.Year, 
                                                                                                        1, 12, 
                                                                                                        tipoDeCambio.CambioVentasPRL, 
                                                                                                        ConstantesGC.OPERACION_DESTINO_VENTAS);

                    BaseFiltro filtroComecial = new BaseFiltro
                    {
                        codProducto = filtro.codProducto,
                        codRegMoneda = filtro.codRegMoneda,
                        codListaPrecio = filtro.codListaPrecio,
                        codPerEmpresa = filtro.codPerEmpresa,
                        codPuntoVenta = filtro.codPuntoVenta,
                        indEstado = filtro.indEstado
                    };
                    producto.listaProductoPrecio = oProductoPrecioData.List(filtroComecial);

                    foreach (BEProductoPrecio itemPrecio in producto.listaProductoPrecio)
                    {
                        producto.itemProductoPrecio = itemPrecio;
                        break;
                    }
                    producto.listaListaDePrecioDetalle = new ListaDePrecioDetalleData().List(new BaseFiltro
                    {
                        codListaPrecio = producto.itemProductoPrecio.CodigoListaPrecio,
                        codProducto = filtro.codProducto,
                        codRegMoneda = string.Empty,
                        indEstado = null
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return producto;
        }
        public BEProducto FindCodigoProductoEmpresa(BaseFiltroAlmacen prm_baseFiltro)
        {
            BEProducto producto = new BEProducto();
            try
            {
                producto = oProductoData.FindCodigoProductoEmpresa(prm_baseFiltro);

                if (producto != null)
                {
                    if (prm_baseFiltro.codProducto == null)
                        prm_baseFiltro.codProducto = producto.codProducto;
                    producto.itemProductoFoto = oProductoFotosData.Find(prm_baseFiltro);
                    producto.itemProductoExistencias = oProductoExistenciasData.Find(prm_baseFiltro);
                    foreach (BEProductoExistencia productoExistencia in producto.itemProductoExistencias)
                    {
                        productoExistencia.listaInventario = oInventariosData.List(prm_baseFiltro);
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
                    producto.listaProductoProveedores = oProductoProveedoresData.List(prm_baseFiltro);
                    producto.listaProductoProductoSeriados = oProductoSeriadosData.List(prm_baseFiltro);

                    prm_baseFiltro.fecInicio = HelpTime.ConvertYYYYMMDD(DateTime.Now.AddDays(DateTime.Now.DayOfYear * -1));
                    prm_baseFiltro.fecFinal = HelpTime.ConvertYYYYMMDD(DateTime.Now);
                    producto.listaProductoKardex = oProductoExistenciasKardexData.List(prm_baseFiltro);

                    BETipoDeCambio tipoDeCambio = new BETipoDeCambio();
                    tipoDeCambio = new TipoDeCambioLogic().Find(new BaseFiltro
                    {
                        fecInicioDate = DateTime.Now,
                        codRegMoneda = ConfigCROM.AppConfig(ConfigTool.DEFAULT_MonedaInt)
                    });
                    if (tipoDeCambio != null)
                        producto.listaProductoVentas = new ConsultasGCLogic().ListProductoVentasCompras(
                            prm_baseFiltro.codProducto,
                            prm_baseFiltro.codPerEmpresa, 
                            prm_baseFiltro.codDeposito, 
                            prm_baseFiltro.codPuntoVenta, 
                            DateTime.Now.Year, 
                            1, 12, 
                            tipoDeCambio.CambioVentasPRL, 
                            ConstantesGC.OPERACION_DESTINO_VENTAS);

                    List<BEProductoPrecio> lstProductoPrecio = new List<BEProductoPrecio>();
                    lstProductoPrecio = oProductoPrecioData.List(new BaseFiltro
                    {
                        codProducto = prm_baseFiltro.codProducto,
                        codRegMoneda = prm_baseFiltro.codRegMoneda,
                        codListaPrecio = prm_baseFiltro.codListaPrecio,
                        codPerEmpresa = prm_baseFiltro.codPerEmpresa,
                        codPuntoVenta = prm_baseFiltro.codPuntoVenta,
                        indEstado = prm_baseFiltro.indEstado
                    });
                    foreach (BEProductoPrecio productoPrecio in lstProductoPrecio)
                        if (productoPrecio.Estado && productoPrecio.CodigoPuntoVenta == prm_baseFiltro.codPuntoVenta)
                            producto.itemProductoPrecio = productoPrecio;
                    producto.listaProductoPrecio = lstProductoPrecio;
                    producto.listaListaDePrecioDetalle = new ListaDePrecioDetalleData().List(new BaseFiltro { codListaPrecio = producto.itemProductoPrecio.CodigoListaPrecio, codProducto = prm_baseFiltro.codProducto, codRegMoneda = string.Empty, indEstado = null });
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                    indDeleteProveedor = oProductoProveedoresData.Delete(new BaseFiltroAlmacen
                    {
                        codProducto = producto.codProducto,
                        codPerProveedor = string.Empty
                    });
                    foreach (BEProductoProveedor productoProveedor in producto.listaProductoProveedores)
                    {
                        productoProveedor.codPersonaEmpre = producto.codPersonaEmpre;
                        productoProveedor.codProducto = producto.codProducto;
                        productoProveedor.SegUsuarioCrea = producto.segUsuarioCrea;
                        oProductoProveedoresData.Insert(productoProveedor);
                    }

                    if (producto.itemProductoFoto.FotografiaF != null)
                    {
                        producto.itemProductoFoto.codProducto = producto.codProducto;
                        producto.itemProductoFoto.segUsuarioCrea = producto.segUsuarioCrea;
                        oProductoFotosData.InsertUpdate(producto.itemProductoFoto);
                    }
                    if (!producto.EsListaPrecio)
                    {
                        List<BEPuntoDeVenta> lstPuntoDeVenta = new PuntoDeVentaLogic().List(new BaseFiltro
                        {
                            codPerEmpresa = producto.codPersonaEmpre,
                            indEstado = true
                        });
                        foreach (BEPuntoDeVenta puntoDeVenta in lstPuntoDeVenta)
                        {
                            producto.itemProductoPrecio.CodigoPuntoVenta = puntoDeVenta.codPuntoDeVenta;
                            producto.itemProductoPrecio.codProducto = producto.codProducto;
                            oProductoPrecioData.Insert(producto.itemProductoPrecio);
                        }
                    }
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
            if (producto.codDeposito == string.Empty)
                producto.codDeposito = null;
            if (producto.CodigoArguMetodoAlm == string.Empty)
                producto.CodigoArguMetodoAlm = null;
            if (producto.CodigoArguCentroProd == string.Empty)
                producto.CodigoArguCentroProd = null;
            if (producto.CodigoArguColor == string.Empty)
                producto.CodigoArguColor = null;
            if (producto.CodigoCuenta == string.Empty)
                producto.CodigoCuenta = null;
            if (producto.CodigoArguMarcaProdu == string.Empty)
                producto.CodigoArguMarcaProdu = null;
            if (producto.EsVerificacionStock)
                if (producto.codDeposito == null)
                    producto.codDeposito = ConfigCROM.AppConfig(ConfigTool.DEFAULT_AlmacenPrincipal);

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

                    bool indEliminaProveedor;
                    indEliminaProveedor = oProductoProveedoresData.Delete(new BaseFiltroAlmacen { codProducto = producto.codProducto }); 
                    foreach (BEProductoProveedor productoProveedor in producto.listaProductoProveedores)
                    {
                        productoProveedor.codPersonaEmpre = producto.codPersonaEmpre;
                        productoProveedor.codProducto = producto.codProducto;
                        productoProveedor.SegUsuarioCrea = producto.segUsuarioCrea;
                        oProductoProveedoresData.Insert(productoProveedor);
                    }
                    producto.PalabrasClaves = IntegrarPalabrasClaves(producto);

                    if (string.IsNullOrEmpty(producto.CodigoProductoRefer))
                        producto.CodigoProductoRefer = producto.CodigoProducto;

                    oReturnValor.Exitosa = oProductoData.Update(producto);
                    if (producto.itemProductoFoto.FotografiaF != null)
                    {
                        producto.itemProductoFoto.codProducto = producto.codProducto;
                        producto.itemProductoFoto.segUsuarioCrea = producto.segUsuarioEdita;
                        oProductoFotosData.InsertUpdate(producto.itemProductoFoto);
                    }
                    if (!producto.EsListaPrecio)
                    {
                        if (producto.indActualizaPrecioTodos)
                        {
                            List<BEPuntoDeVenta> lstPuntoDeVenta = new PuntoDeVentaLogic().List(new BaseFiltro
                            {
                                codPerEmpresa = producto.codPersonaEmpre,
                                indEstado = true
                            });
                            foreach (BEPuntoDeVenta puntoDeVenta in lstPuntoDeVenta)
                            {
                                producto.itemProductoPrecio.CodigoPuntoVenta = puntoDeVenta.codPuntoDeVenta;
                                producto.itemProductoPrecio.codProducto = producto.codProducto;
                                oProductoPrecioData.Insert(producto.itemProductoPrecio);
                            }
                        }
                    }
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
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

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.Producto
        /// En la BASE de DATO la Tabla : [Almacen.Producto]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public ReturnValor Delete(BaseFiltroAlmacen filtro) 
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oProductoFotosData.Delete(filtro);
                    if (filtro.indArticuloExistencia)
                        oReturnValor.Exitosa = oProductoExistenciasData.Delete(filtro);
                    bool Proceso1 = oProductoPrecioData.Delete(new BaseFiltro
                    {
                        codListaPrecio = string.Empty,
                        codProducto = filtro.codProducto,
                        codPuntoVenta = string.Empty,
                        codRegMoneda = string.Empty
                    });
                    bool Proceso2 = oProductoData.Delete(filtro.codProducto.Value);

                    if (oReturnValor.Exitosa && Proceso1 && Proceso2)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
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

        #endregion

        #region /* TABLA:=(Produccion.ProductoPartes) PARTES DE PRODUCTO / ARTÍCULO */

        #region /* Proceso de SELECT ALL */

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

        #region /* Proceso de INSERT RECORD */

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

        #region /* Proceso de DELETE BY ID CODE */

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

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Produccion.ProductoPartesAtributo
        /// En la BASE de DATO la Tabla : [Produccion.ProductoPartesAtributo]
        /// <summary>
        /// <returns>List</returns>
        public List<BEProductoParteAtributo> ListParteAtributo(string prm_CodigoProducto, string prm_CodigoArguParteProdu, string prm_CodigoArguAtributoPP, bool prm_Estado)
        {
            List<BEProductoParteAtributo> miLista = new List<BEProductoParteAtributo>();
            try
            {
                miLista = oProductoPartesAtributoData.List(prm_CodigoProducto, prm_CodigoArguParteProdu, prm_CodigoArguAtributoPP, prm_Estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoPartesAtributo
        /// En la BASE de DATO la Tabla : [Produccion.ProductoPartesAtributo]
        /// <summary>
        /// <param name = >itemProductoPartesAtributo</param>
        public ReturnValor InsertUpdate(BEProductoParteAtributo itemProductoPartesAtributo)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oProductoPartesAtributoData.InsertUpdate(itemProductoPartesAtributo);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
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

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Produccion.ProductoPartesAtributo
        /// En la BASE de DATO la Tabla : [Produccion.ProductoPartesAtributo]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor DeleteParteAtributo(string prm_CodigoProducto, string prm_CodigoArguParteProdu, string prm_CodigoArguAtributoPP)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oProductoPartesAtributoData.Delete(prm_CodigoProducto, prm_CodigoArguParteProdu, prm_CodigoArguAtributoPP);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
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

        #endregion

        #region /* TABLA:=(Produccion.ProductoProveedores) PROVEEDORE DEL PRODUCTO / ARTÍCULO */

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Produccion.ProductoProveedores
        /// En la BASE de DATO la Tabla : [Produccion.ProductoProveedores]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<BEProductoProveedor> ListProducProveedores(BaseFiltroAlmacen filtro)
        {
            List<BEProductoProveedor> lstProductoProveedor = new List<BEProductoProveedor>();
            try
            {
                lstProductoProveedor = oProductoProveedoresData.List(filtro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductoProveedor;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoProveedores
        /// En la BASE de DATO la Tabla : [Produccion.ProductoProveedores]
        /// <summary>
        /// <param name="itemProductoProveedores"></param>
        /// <returns></returns>
        public ReturnValor InsertUpdate(BEProductoProveedor productoProveedor)
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
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Produccion.Proeedores
        /// En la BASE de DATO la Tabla : [Produccion.Proeedores]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public ReturnValor DeleteProveedor(BaseFiltroAlmacen filtro) 
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oProductoProveedoresData.Delete(filtro); 
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
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

        #endregion

        #region /* TABLA:=(Almacen.ProductoSeriados) PRODUCTOS CON NUMEROS DE SERIES PRODUCTO / ARTÍCULO */

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.ProductoSeriados
        /// En la BASE de DATO la Tabla : [Almacen.ProductoSeriados]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<BEProductoSeriado> ListProductoSeriad(BaseFiltroAlmacen filtro) 
        {
            List<BEProductoSeriado> lstProductoSeriado = new List<BEProductoSeriado>();
            try
            {
                lstProductoSeriado = oProductoSeriadosData.List(filtro); 
            }
            catch (Exception ex)
            {
                throw ex;
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
        public ReturnValor Insert(BEProductoSeriado productoSeriado)
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
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Almacen.ProductoSeriados
        /// En la BASE de DATO la Tabla : [Almacen.ProductoSeriados]
        /// <summary>
        /// <param name="productoSeriado"></param>
        /// <returns></returns>
        public ReturnValor Update(BEProductoSeriado productoSeriado)
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
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }
        public ReturnValor UpdateDatoIngreso(BEProductoSeriado productoSeriado)
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
                oReturnValor = HelpException.mTraerMensaje(ex);
            }
            return oReturnValor;
        }
        public ReturnValor UpdateConsignacion(List<BEProductoSeriado> lstProductoSeriado)
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
                oReturnValor = HelpException.mTraerMensaje(ex);
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
        public ReturnValor DeleteProductoSeriados(BaseFiltroAlmacen filtro) 
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oProductoSeriadosData.Delete(filtro);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
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

        public ReturnValor DeleteProductoSeriadosPorDetalle(BaseFiltroAlmacen filtro)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oProductoSeriadosData.DeleteDetalleDocum(filtro);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
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

        #endregion

        #region /* TABLA:=(Produccion.ProductoExistenciasKardex) PRODUCTOS CON MOVIMIENTOS EN EL KARDEX */

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
        public List<ProductoKardexAux> ListKardexValorizado(BaseFiltro filtro) 
        {
            filtro.fecInicio = HelpTime.ConvertYYYYMMDD(filtro.fecInicioDate);
            filtro.fecFinal = HelpTime.ConvertYYYYMMDD(filtro.fecFinalDate);
            List<ProductoKardexAux> listaProcesada = new List<ProductoKardexAux>();
            List<ProductoKardexAux> listaProductoKardex = new List<ProductoKardexAux>();
            try
            {
                listaProductoKardex = oProductoData.ListParaValorizado(new BaseFiltroAlmacen
                {
                    fecInicio = filtro.fecInicio,
                    fecFinal = filtro.fecFinal,
                    codPerEmpresa = filtro.codPerEmpresa,
                    codPuntoVenta = filtro.codPuntoVenta,
                    codProducto = filtro.codProducto
                });
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

        #region /* TABLA:=(Almacen.ProductoPartesCompuesta) PRODUCTOS COMPUESTOS */

        #region /* Proceso de SELECT ALL */
        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.ProductoPartesCompuesta
        /// En la BASE de DATO la Tabla : [Almacen.ProductoPartesCompuesta]
        /// <summary>
        /// <returns>List</returns>
        public List<BEProductoParteCompuesta> ListPartesCompuesta(string prm_CodigoProducto, string prm_CodigoProductoParte)
        {
            List<BEProductoParteCompuesta> miLista = new List<BEProductoParteCompuesta>();
            try
            {
                miLista = oProductoPartesCompuestaData.List(prm_CodigoProducto, prm_CodigoProductoParte);
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
        /// Retorna una ENTIDAD de registro de la Entidad Almacen.ProductoPartesCompuesta
        /// En la BASE de DATO la Tabla : [Almacen.ProductoPartesCompuesta]
        /// <summary>
        /// <returns>Entidad</returns>
        public BEProductoParteCompuesta FindPartesCompuesta(string prm_CodigoProducto, string prm_CodigoProductoParte)
        {
            BEProductoParteCompuesta miEntidad = new BEProductoParteCompuesta();
            try
            {
                miEntidad = oProductoPartesCompuestaData.Find(prm_CodigoProducto, prm_CodigoProductoParte);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoPartesCompuesta
        /// En la BASE de DATO la Tabla : [Almacen.ProductoPartesCompuesta]
        /// <summary>
        /// <param name = >itemProductoPartesCompuesta</param>
        public ReturnValor InsertPartesCompuesta(BEProductoParteCompuesta itemProductoPartesCompuesta)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oProductoPartesCompuestaData.Insert(itemProductoPartesCompuesta);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoPartesCompuesta
        /// En la BASE de DATO la Tabla : [Almacen.ProductoPartesCompuesta]
        /// <summary>
        /// <param name = >itemProductoPartesCompuesta</param>
        public ReturnValor UpdatePartesCompuesta(BEProductoParteCompuesta itemProductoPartesCompuesta)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oProductoPartesCompuestaData.Update(itemProductoPartesCompuesta);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
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

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.ProductoPartesCompuesta
        /// En la BASE de DATO la Tabla : [Almacen.ProductoPartesCompuesta]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor DeletePartesCompuesta(string prm_CodigoProducto, string prm_CodigoProductoParte)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oProductoPartesCompuestaData.Delete(prm_CodigoProducto, prm_CodigoProductoParte);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.DELETE);
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

        #endregion

        #region /* TABLA:=(GestionComercial.ProductoPrecio) PRODUCTOS COMPUESTOS */

        public List<BEProductoPrecio> ListProductoPrecio(BaseFiltro filtro)
        {
            List<BEProductoPrecio> lstProductoPrecio = new List<BEProductoPrecio>();
            try
            {
                lstProductoPrecio = oProductoPrecioData.List(filtro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductoPrecio;
        }

        #endregion

        public List<BEProducto> ListParaInventario(BaseFiltroAlmacen filtro) 
        {
            List<BEProducto> lstProducto = new List<BEProducto>();
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
       
        public List<BEProducto> ListParaStockInicial(BaseFiltroAlmacen filtro) 
        {
            List<BEProducto> lstProducto = new List<BEProducto>();
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
      
        public List<BEProductoExistencia> FindProductoExistencia(BaseFiltroAlmacen filtro)
        {
            List<BEProductoExistencia> lstProductoExistencia = new List<BEProductoExistencia>();
            try
            {
                lstProductoExistencia = oProductoExistenciasData.Find(filtro); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductoExistencia;
        }
  
         /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ProductoPrecio
        /// En la BASE de DATO la Tabla : [GestionComercial.ProductoPrecio]
        /// <summary>
        /// <param name="productoPrecio"></param>
        /// <returns></returns>
        public ReturnValor InsertProductoPrecio(BEProductoPrecio productoPrecio)
        {
            oProductoPrecioData = new ProductoPrecioData();
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.codRetorno = oProductoPrecioData.Insert(productoPrecio);
                    if (oReturnValor.codRetorno != 0)
                    {
                        oReturnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
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
    }
}

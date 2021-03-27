namespace CROM.GestionComercial.BusinessLogic
{
    using CROM.BusinessEntities.Almacen;
    using CROM.BusinessEntities.Comercial;
    using CROM.GestionAlmacen.BusinessLogic;
    using CROM.GestionComercial.DataAccess;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Config;

    using System;
    using System.Collections.Generic;
    using System.Transactions;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 22/03/2011-05:08:51 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [GestionComercial.ListaDePrecioLogic.cs]
    /// </summary>
    public class ListaDePrecioLogic
    {
        private ListaDePrecioData listaDePrecioData = null;
        private ListaDePrecioDetalleData listaDePrecioDetalleData = null;
        private ReturnValor returnValor = null;

        public ListaDePrecioLogic()
        {
            listaDePrecioData = new ListaDePrecioData();
            listaDePrecioDetalleData = new ListaDePrecioDetalleData();
            returnValor = new ReturnValor();
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ListaDePrecio
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecio]
        /// <summary>
        /// <returns>List</returns>
        public List<BEListaDePrecio> List(BaseFiltro filtro) // string prm_CodigoLista, string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, string prm_Descripcion, bool? prm_EsParaVenta, bool? prm_Estado)
        {
            List<BEListaDePrecio> miLista = new List<BEListaDePrecio>();
            try
            {
                miLista = listaDePrecioData.List(filtro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }
        public List<BEListaDePrecio> List(BaseFiltro filtro, bool prm_Vacias) // string prm_CodigoLista, string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, string prm_Descripcion, bool? prm_EsParaVenta, bool? prm_Estado, bool prm_Vacias, string prm_CodigoArguMoneda)
        {
            List<BEListaDePrecio> lstListaDePrecio = new List<BEListaDePrecio>();
            List<BEListaDePrecio> lstListaDePrecioDev = new List<BEListaDePrecio>();
            try
            {
                lstListaDePrecio = listaDePrecioData.List(filtro);// prm_CodigoLista, prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta, prm_Descripcion, prm_EsParaVenta, prm_Estado);
                foreach (BEListaDePrecio listaPrecio in lstListaDePrecio)
                {
                    List<BEListaDePrecioDetalle> listaListaDePrecioDetalle = new List<BEListaDePrecioDetalle>();
                    listaListaDePrecioDetalle = listaDePrecioDetalleData.List(filtro); // listaPrecio.CodigoLista, prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta, string.Empty, prm_CodigoArguMoneda, true);
                    if (prm_Vacias)
                    {
                        if (listaListaDePrecioDetalle.Count == 0)
                        {
                            listaPrecio.listaListaDePrecioDetalle = listaListaDePrecioDetalle;
                            lstListaDePrecioDev.Add(listaPrecio);
                        }
                    }
                    else
                    {
                        if (listaListaDePrecioDetalle.Count > 0)
                        {
                            listaPrecio.listaListaDePrecioDetalle = listaListaDePrecioDetalle;
                            lstListaDePrecioDev.Add(listaPrecio);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstListaDePrecioDev;
        }
        public List<BEListaDePrecioDetalle> ListDesdeStock(BaseFiltro filtro) 
            //, string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, string prm_codDeposito, string prm_CodigoArguMoneda, bool prm_EsParaVentas, string prm_CodigoLista, string prm_UsuarioLogin)
        {
            List<BEListaDePrecioDetalle> lstListaDePrecioDetalle = new List<BEListaDePrecioDetalle>();
            List<DTOProductoResponse> lstProducto = new List<DTOProductoResponse>();
            List<BEProducto> lstProductoDep = new List<BEProducto>();
            List<BEProductoPrecio> lstProductoPrecio = new List<BEProductoPrecio>();
            BETipoDeCambio itemTiposDeCambio = new BETipoDeCambio();
            try
            {
                ProductoLogic productoLogic = new ProductoLogic();
                ProductoPrecioData oProductoPrecioData = new ProductoPrecioData();
                TipoDeCambioLogic oTiposdeCambioLogic = new TipoDeCambioLogic();
                lstProducto = productoLogic.List(new BaseFiltroProducto
                {
                    codEmpresa = filtro.codEmpresa,
                    codEmpresaRUC = filtro.codEmpresaRUC,
                    codDeposito = string.Empty,
                    codProductoRefer = string.Empty,
                    desNombre = string.Empty,
                    desComercial = string.Empty,
                    codMarca = null,
                    codRegTipo = string.Empty,
                    indDestinoCompra = true,
                    indDestinaVenta = true,
                    codRegCentroProducc = string.Empty,
                    codRegCategoria = string.Empty,
                    codRegUnidadMedida = string.Empty,
                    indEstado = true,
                    desPalabraClave = string.Empty,
                    indTodos = true
                });
                itemTiposDeCambio = oTiposdeCambioLogic.Find(new BaseFiltroTipoCambio
                {
                    codEmpresa = filtro.codEmpresa,
                    fecInicioDate = DateTime.Now,
                    codRegMoneda = ConfigCROM.AppConfig(filtro.codEmpresa, ConfigTool.DEFAULT_MonedaInt)
                });
                foreach (DTOProductoResponse xProducto in lstProducto)
                    if (xProducto.EsListaPrecio)
                    {
                        BEProducto productoNew = new BEProducto();
                        filtro.codProducto = xProducto.codProducto;
                        BaseFiltroAlmacen filtroAlmacen = new BaseFiltroAlmacen
                        {
                            codProductoRefer = filtro.codProductoRefer,
                            codProducto = filtro.codProducto.Value
                        };
                        productoNew = productoLogic.Find(filtroAlmacen);
                        productoNew.itemProductoPrecio.codProducto = xProducto.codProducto;
                        productoNew.itemProductoPrecio.CodigoProductoNombre = productoNew.Descripcion;
                        lstProductoPrecio.Add(productoNew.itemProductoPrecio);
                    }
                filtro.codProducto = null;
                foreach (BEProductoPrecio itemproductoPrecio in lstProductoPrecio)
                {
                    BEListaDePrecioDetalle itemlistaDePrecioDetalle = new BEListaDePrecioDetalle
                    {
                        CodigoArguMoneda = filtro.codRegMoneda,
                        codProducto = itemproductoPrecio.codProducto,
                        CodigoProducto = itemproductoPrecio.CodigoProducto,
                        Estado = itemproductoPrecio.Estado,
                        segFechaEdita = DateTime.Now,
                        segUsuarioEdita = filtro.segUsuarioEdita,
                        CodigoProductoNombre = itemproductoPrecio.CodigoProductoNombre,
                        CodigoLista = filtro.codListaPrecio,
                        segUsuarioCrea = filtro.segUsuarioEdita,
                        segFechaCrea = DateTime.Now,
                        CodigoPersonaEmpre = filtro.codEmpresaRUC,
                        CodigoPuntoVenta = filtro.codPuntoVenta,
                    };
                    decimal PRECIO_A_TOMAR = 0;
                    if (filtro.indParaVenta.Value)
                        PRECIO_A_TOMAR = itemproductoPrecio.ValorVenta;
                    else
                        PRECIO_A_TOMAR = itemproductoPrecio.ValorCosto;

                    if (itemproductoPrecio.CodigoArguMoneda == filtro.codRegMoneda)
                        itemlistaDePrecioDetalle.PrecioUnitario = PRECIO_A_TOMAR;
                    else
                    {
                        if (filtro.codRegMoneda == ConfigCROM.AppConfig(filtro.codEmpresa, ConfigTool.DEFAULT_MonedaNac))
                        {
                            if (itemproductoPrecio.CodigoArguMoneda == filtro.codRegMoneda)
                                itemlistaDePrecioDetalle.PrecioUnitario = PRECIO_A_TOMAR;
                            else
                                itemlistaDePrecioDetalle.PrecioUnitario = Helper.DecimalRound(PRECIO_A_TOMAR * itemTiposDeCambio.CambioVentasPRL, 2);
                        }
                        if (filtro.codRegMoneda == ConfigCROM.AppConfig(filtro.codEmpresa, ConfigTool.DEFAULT_MonedaInt))
                        {
                            if (itemproductoPrecio.CodigoArguMoneda == filtro.codRegMoneda)
                                itemlistaDePrecioDetalle.PrecioUnitario = PRECIO_A_TOMAR;
                            else
                                itemlistaDePrecioDetalle.PrecioUnitario = Helper.DecimalRound(PRECIO_A_TOMAR / itemTiposDeCambio.CambioVentasPRL, 2);
                        }
                    }
                    lstListaDePrecioDetalle.Add(itemlistaDePrecioDetalle);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstListaDePrecioDetalle;
        }

        public List<BEListaDePrecioDetalle> ListDesdeStockCompras(BaseFiltro filtro) // string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, string prm_codDeposito, string prm_CodigoArguMoneda, bool prm_ParaCompras, bool prm_ParaVentas, string prm_CodigoLista, string prm_UsuarioLogin)
        {
            List<BEListaDePrecioDetalle> lstListaDePrecioDetalle = new List<BEListaDePrecioDetalle>();
            List<DTOProductoResponse> lstProducto = new List<DTOProductoResponse>();
            List<BEProducto> lstProductoDep = new List<BEProducto>();
            List<BEProductoPrecio> lstProductoPrecio = new List<BEProductoPrecio>();
            BETipoDeCambio tipoDeCambio = new BETipoDeCambio();
            try
            {
                ProductoLogic oProductoLogic = new ProductoLogic();
                ProductoPrecioData oProductoPrecioData = new ProductoPrecioData();
                TipoDeCambioLogic oTiposdeCambioLogic = new TipoDeCambioLogic();
                lstProducto = oProductoLogic.List(new BaseFiltroProducto
                {
                    codEmpresaRUC = filtro.codEmpresaRUC,
                    codDeposito = string.Empty,
                    codProductoRefer = string.Empty,
                    desNombre = string.Empty,
                    desComercial = string.Empty,
                    codMarca = null,
                    codRegTipo = string.Empty,
                    indDestinoCompra = true,
                    indDestinaVenta = true,
                    codRegCentroProducc = string.Empty,
                    codRegCategoria = string.Empty,
                    codRegUnidadMedida = string.Empty,
                    indEstado = true,
                    desPalabraClave = string.Empty,
                    indTodos = true
                });

                tipoDeCambio = oTiposdeCambioLogic.Find(new BaseFiltroTipoCambio
                {
                    codEmpresa = filtro.codEmpresa,
                    fecInicioDate = DateTime.Now,
                    codRegMoneda = ConfigCROM.AppConfig(filtro.codEmpresa, ConfigTool.DEFAULT_MonedaInt)
                });

                foreach (DTOProductoResponse xProducto in lstProducto)
                    if (xProducto.EsListaPrecio)
                    {
                        BEProducto productoNew = new BEProducto();
                        productoNew = oProductoLogic.Find(new BaseFiltroAlmacen
                        {
                            codEmpresa = filtro.codEmpresa,
                            codProducto = xProducto.codProducto
                        });

                        productoNew.itemProductoPrecio.CodigoProductoNombre = productoNew.Descripcion;
                        lstProductoPrecio.Add(productoNew.itemProductoPrecio);
                    }
                filtro.codProducto = null;
                foreach (BEProductoPrecio itemproductoPrecio in lstProductoPrecio)
                {
                    BEListaDePrecioDetalle xlstListaDePrecioDetalle = new BEListaDePrecioDetalle
                    {
                        CodigoArguMoneda = filtro.codRegMoneda,
                        codProducto = itemproductoPrecio.codProducto,
                        CodigoProducto = itemproductoPrecio.CodigoProducto,
                        Estado = itemproductoPrecio.Estado,
                        segFechaEdita = DateTime.Now,
                        segUsuarioEdita = filtro.segUsuarioEdita,
                        CodigoProductoNombre = itemproductoPrecio.CodigoProductoNombre,
                        CodigoLista = filtro.codListaPrecio,
                        segUsuarioCrea = filtro.segUsuarioEdita,
                        segFechaCrea = DateTime.Now,
                        CodigoPersonaEmpre = filtro.codEmpresaRUC,
                        CodigoPuntoVenta = filtro.codPuntoVenta,
                    };
                    if (itemproductoPrecio.CodigoArguMoneda == filtro.codRegMoneda)
                        xlstListaDePrecioDetalle.PrecioUnitario = itemproductoPrecio.ValorVenta;
                    else
                    {
                        if (filtro.codRegMoneda == ConfigCROM.AppConfig(filtro.codEmpresa, ConfigTool.DEFAULT_MonedaNac))
                        {
                            if (itemproductoPrecio.CodigoArguMoneda == filtro.codRegMoneda)
                                xlstListaDePrecioDetalle.PrecioUnitario = itemproductoPrecio.ValorVenta;
                            else
                                xlstListaDePrecioDetalle.PrecioUnitario = Helper.DecimalRound(itemproductoPrecio.ValorVenta * tipoDeCambio.CambioVentasPRL, 2);
                        }
                        if (filtro.codRegMoneda == ConfigCROM.AppConfig(filtro.codEmpresa, ConfigTool.DEFAULT_MonedaInt))
                        {
                            if (itemproductoPrecio.CodigoArguMoneda == filtro.codRegMoneda)
                                xlstListaDePrecioDetalle.PrecioUnitario = itemproductoPrecio.ValorVenta;
                            else
                                xlstListaDePrecioDetalle.PrecioUnitario = Helper.DecimalRound(itemproductoPrecio.ValorVenta / tipoDeCambio.CambioVentasPRL, 2);
                        }
                    }
                    lstListaDePrecioDetalle.Add(xlstListaDePrecioDetalle);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstListaDePrecioDetalle;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */


        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad GestionComercial.ListaDePrecio
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecio]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public BEListaDePrecio Find(BaseFiltro filtro) // string prm_CodigoLista, string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta)
        {
            BEListaDePrecio listaDePrecio = new BEListaDePrecio();
            try
            {
                listaDePrecio = listaDePrecioData.Find(filtro.codListaPrecio);
                listaDePrecio.listaListaDePrecioDetalle = listaDePrecioDetalleData.List(filtro); //prm_CodigoLista, prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta, string.Empty, string.Empty, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaDePrecio;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ListaDePrecio
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecio]
        /// <summary>
        /// <param name="listaDePrecio"></param>
        /// <returns></returns>
        public ReturnValor Insert(BEListaDePrecio listaDePrecio)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.CodigoRetorno = listaDePrecioData.Insert(listaDePrecio);
                    if (returnValor.CodigoRetorno != null)
                    {
                        returnValor.Exitosa = true;
                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
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

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ListaDePrecio
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecio]
        /// <summary>
        /// <param name="listaDePrecio"></param>
        /// <returns></returns>
        public ReturnValor Update(BEListaDePrecio listaDePrecio)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = listaDePrecioData.Update(listaDePrecio);
                    if (returnValor.Exitosa)
                    {
                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
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
        /// ELIMINA un registro de la Entidad GestionComercial.ListaDePrecio
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecio]
        /// <summary>
        /// <param name="prm_CodigoLista"></param>
        /// <returns></returns>
        public ReturnValor Delete(string prm_CodigoLista)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = listaDePrecioData.Delete(prm_CodigoLista);
                    if (returnValor.Exitosa)
                    {
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

        //-------------------------
        // TABLA : ListaDePrecioDetalle
        //-------------------------
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad GestionComercial.ListaDePrecioDetalle
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecioDetalle]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<BEListaDePrecioDetalle> ListDetalle(BaseFiltro filtro) // string prm_CodigoLista, string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, string prm_CodigoProducto, string prm_CodigoArguMoneda, bool? prm_Estado)
        {
            List<BEListaDePrecioDetalle> lstListaDePrecioDetalle = new List<BEListaDePrecioDetalle>();
            try
            {
                lstListaDePrecioDetalle = listaDePrecioDetalleData.List(filtro); //prm_CodigoLista, prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta, prm_CodigoProducto, prm_CodigoArguMoneda, prm_Estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstListaDePrecioDetalle;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ListaDePrecioDetalle
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecioDetalle]
        /// <summary>
        /// <param name="listaListaDePrecioDetalle"></param>
        /// <param name="listaProductoPrecio"></param>
        /// <returns></returns>
        public ReturnValor InsertDetalle(List<BEListaDePrecioDetalle> lstListaDePrecioDetalle, List<BEProductoPrecio> lstProductoPrecio, int pcodEmpresa)
        {
            DTOResponseProcedure objProductoPrecio = null;
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    foreach (BEListaDePrecioDetalle listaPrecioDetalle in lstListaDePrecioDetalle)
                    {
                        returnValor.codRetorno = listaDePrecioDetalleData.Insert(listaPrecioDetalle);
                        if (returnValor.codRetorno != 0)
                            returnValor.Exitosa = true;
                        ProductoPrecioData productoPrecioData = new ProductoPrecioData();
                        lstProductoPrecio = productoPrecioData.List(new BaseFiltroProductoPrecio
                        {
                            codEmpresa = pcodEmpresa,
                            codProducto = listaPrecioDetalle.codProducto,
                            codRegMoneda = string.Empty,
                            codListaPrecio = null,
                            codEmpresaRUC = listaPrecioDetalle.CodigoPersonaEmpre,
                            codPuntoVenta = listaPrecioDetalle.CodigoPuntoVenta,
                            indEstado = true
                        });

                        if (lstProductoPrecio.Count == 1)
                        {
                            if (listaPrecioDetalle.refEsParaVenta)
                                lstProductoPrecio[0].ValorVenta = listaPrecioDetalle.PrecioUnitario;
                            else
                                lstProductoPrecio[0].ValorCosto = listaPrecioDetalle.PrecioUnitario;
                            lstProductoPrecio[0].segUsuarioCrea = listaPrecioDetalle.segUsuarioEdita;
                            lstProductoPrecio[0].segUsuarioEdita = listaPrecioDetalle.segUsuarioEdita;

                            lstProductoPrecio[0].CodigoArguMoneda = listaPrecioDetalle.CodigoArguMoneda;
                            lstProductoPrecio[0].codProducto = listaPrecioDetalle.codProducto;
                            lstProductoPrecio[0].CodigoPuntoVenta = listaPrecioDetalle.CodigoPuntoVenta;
                            lstProductoPrecio[0].CodigoListaPrecio = listaPrecioDetalle.CodigoLista;
                            lstProductoPrecio[0].Estado = true;

                            objProductoPrecio = productoPrecioData.InsertUpdate(lstProductoPrecio[0]);
                        }
                    }
                    if (returnValor.Exitosa && objProductoPrecio.ErrorCode > 0)
                    {
                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.NEW);
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

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo ListaDePrecioDetalle
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecioDetalle]
        /// <summary>
        /// <param name="itemListaDePrecioDetalle"></param>
        /// <param name="listaProductoPrecio"></param>
        /// <returns></returns>
        public ReturnValor UpdateDetalle(BEListaDePrecioDetalle itemListaDePrecioDetalle, List<BEProductoPrecio> listaProductoPrecio)
        {
            DTOResponseProcedure objProductoPrecio = null;
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    int indPrecioUpdate = -1;
                    returnValor.Exitosa = listaDePrecioDetalleData.Update(itemListaDePrecioDetalle);

                    ProductoPrecioData productoPrecioData = new ProductoPrecioData();
                    //listaProductoPrecio = oProductoPrecioData.List(itemListaDePrecioDetalle.CodigoProducto, string.Empty, null, itemListaDePrecioDetalle.CodigoPersonaEmpre, itemListaDePrecioDetalle.CodigoPuntoVenta, true);
                    if (listaProductoPrecio.Count == 1)
                    {
                        if (itemListaDePrecioDetalle.refEsParaVenta)
                            listaProductoPrecio[0].ValorVenta = itemListaDePrecioDetalle.PrecioUnitario;
                        else
                            listaProductoPrecio[0].ValorCosto = itemListaDePrecioDetalle.PrecioUnitario;
                        listaProductoPrecio[0].segUsuarioCrea = itemListaDePrecioDetalle.segUsuarioEdita;
                        listaProductoPrecio[0].segUsuarioEdita = itemListaDePrecioDetalle.segUsuarioEdita;
                        objProductoPrecio = productoPrecioData.InsertUpdate(listaProductoPrecio[0]);
                    }
                    if (returnValor.Exitosa && objProductoPrecio.ErrorCode > 0)
                    {
                        returnValor.Message = HelpEventos.MessageEvento(HelpEventos.Process.EDIT);
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
        /// ELIMINA un registro de la Entidad GestionComercial.ListaDePrecioDetalle
        /// En la BASE de DATO la Tabla : [GestionComercial.ListaDePrecioDetalle]
        /// <summary>
        /// <param name="prm_codListaDePrecioDetalle"></param>
        /// <returns></returns>
        public ReturnValor DeleteDetalle(int prm_codListaDePrecioDetalle) //string prm_CodigoLista, string prm_CodigoPersonaEmpre, string prm_CodigoPuntoVenta, string prm_CodigoProducto,string prm_CodigoArguMoneda)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    returnValor.Exitosa = listaDePrecioDetalleData.Delete(prm_codListaDePrecioDetalle); //prm_CodigoLista, prm_CodigoPersonaEmpre, prm_CodigoPuntoVenta, prm_CodigoProducto, prm_CodigoArguMoneda);
                    if (returnValor.Exitosa)
                    {
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
    }
} 

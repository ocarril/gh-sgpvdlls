namespace CROM.GestionAlmacen.DataAccess
{
    using CROM.BusinessEntities.Almacen;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.settings;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 23/01/2010-01:54:47 a.m.
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Almacen.ProductoData.cs]
    /// </summary>
    public class ProductoData
    {
        private string conexion = string.Empty;
        public ProductoData()
        {
            conexion = Util.ConexionBD();
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Producto
        /// En la BASE de DATO la Tabla : [Almacen.Producto]
        /// <summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public int Insert(BEProducto producto)
        {
            int? codRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    SQLDC.omgc_I_Producto(
                        ref codRetorno,
                        producto.codEmpresa,
                        producto.CodigoProducto,
                        producto.CodigoProductoRefer,
                        producto.codGrupo,
                        producto.Descripcion,
                        producto.DescripcionComercial,
                        producto.DescripcionAbreviada,
                        producto.Observacion,
                        producto.DatoAdicional_01,
                        producto.DatoAdicional_02,
                        producto.codMarca, 
                        producto.codModelo,
                        producto.CodigoArguTipoProducto,
                        producto.DestinadoACompra,
                        producto.DestinadoAVenta,
                        producto.CodigoArguSectorAlm,
                        producto.CodigoArguMetodoAlm,
                        producto.CodigoArguCentroProd,
                        producto.CodigoArguColor,
                        producto.CodigoArguCategoProd,
                        producto.CodigoCuenta,
                        producto.CodigoArguUnidadMed,
                        producto.EditaDescripcion,
                        producto.EditaValorVenta,
                        producto.EditaValorCosto,
                        producto.EsComboDeOferta,
                        producto.EsListaPrecio,
                        producto.EsPerecible,
                        producto.EsVerificacionStock,
                        producto.EsConNumeroSeriado,
                        producto.Estado,
                        producto.segUsuarioCrea,
                        producto.PalabrasClaves,
                        producto.PesoTotal,
                        producto.StockMinimo,
                        producto.StockMaximo,
                        producto.indEsGarantizado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codRetorno == null ? 0 : codRetorno.Value;
        }

        public int InsertOutput(BEProducto producto)
        {
            string codigoRetorno = null;
            int? codRetorno = -1;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    SQLDC.omgc_I_Producto_Output(
                       ref codRetorno,
                       ref codigoRetorno,
                       producto.codEmpresa,
                       producto.CodigoProductoRefer,
                       producto.codGrupo,
                       producto.Descripcion,
                       producto.DescripcionComercial,
                       producto.DescripcionAbreviada,
                       producto.Observacion,
                       producto.DatoAdicional_01,
                       producto.DatoAdicional_02,
                       producto.codMarca,
                       producto.codModelo,
                       producto.CodigoArguTipoProducto,
                       producto.DestinadoACompra,
                       producto.DestinadoAVenta,
                       producto.CodigoArguSectorAlm,
                       producto.CodigoArguMetodoAlm,
                       producto.CodigoArguCentroProd,
                       producto.CodigoArguColor,
                       producto.CodigoArguCategoProd,
                       producto.CodigoCuenta,
                       producto.CodigoArguUnidadMed,
                       producto.EditaDescripcion,
                       producto.EditaValorVenta,
                       producto.EditaValorCosto,
                       producto.EsComboDeOferta,
                       producto.EsListaPrecio,
                       producto.EsPerecible,
                       producto.EsVerificacionStock,
                       producto.EsConNumeroSeriado,
                       producto.Estado,
                       producto.segUsuarioCrea,
                       producto.PalabrasClaves,
                       producto.PesoTotal,
                       producto.StockMinimo,
                       producto.StockMaximo,
                       producto.indEsGarantizado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            producto.CodigoProducto = codigoRetorno;
            return codRetorno == null ? 0 : codRetorno.Value;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Producto
        /// En la BASE de DATO la Tabla : [Almacen.Producto]
        /// <summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public bool Update(BEProducto producto, out string pMensaje)
        {
            int codigoRetorno = -1;
            pMensaje = string.Empty;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                 var resulSet = SQLDC.omgc_U_Producto(
                        producto.codEmpresa,
                        producto.codProducto,
                        producto.CodigoProducto,
                        producto.CodigoProductoRefer,
                        producto.codGrupo,
                        producto.Descripcion,
                        producto.DescripcionComercial,
                        producto.DescripcionAbreviada,
                        producto.Observacion,
                        producto.DatoAdicional_01,
                        producto.DatoAdicional_02,
                        producto.codMarca,
                        producto.codModelo,
                        producto.CodigoArguTipoProducto,
                        producto.DestinadoACompra,
                        producto.DestinadoAVenta,
                        producto.CodigoArguSectorAlm,
                        producto.CodigoArguMetodoAlm,
                        producto.CodigoArguCentroProd,
                        producto.CodigoArguColor,
                        producto.CodigoArguCategoProd,
                        producto.CodigoArguUnidadMed,
                        producto.CodigoCuenta,
                        producto.EditaDescripcion,
                        producto.EditaValorVenta,
                        producto.EditaValorCosto,
                        producto.EsComboDeOferta,
                        producto.EsListaPrecio,
                        producto.EsPerecible,
                        producto.EsVerificacionStock,
                        producto.EsConNumeroSeriado,
                        producto.Estado,
                        producto.segUsuarioEdita,
                        producto.PalabrasClaves,
                        producto.PesoTotal,
                        producto.StockMinimo,
                        producto.StockMaximo,
                        producto.indEsGarantizado);

                    foreach (var item in resulSet)
                    {
                        codigoRetorno = item.codError.Value;
                        pMensaje = item.desMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno > 0 ? true : false;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Almacen.Producto
        /// En la BASE de DATO la Tabla : [Almacen.Producto]
        /// <summary>
        /// <param name="prm_codProducto"></param>
        /// <returns></returns>
        public ReturnValor Delete(BEProducto pProducto)
        {
            ReturnValor codigoRetorno = new ReturnValor();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resulSet = SQLDC.omgc_D_Producto(pProducto.codEmpresa, 
                                                         pProducto.codProducto,
                                                         pProducto.segUsuarioElimina,
                                                         pProducto.segMaquinaElimina);


                    foreach (var item in resulSet)
                    {
                        codigoRetorno.codRetorno = item.codError.Value;
                        codigoRetorno.Message = item.desMessage;
                    }
                    codigoRetorno.Exitosa = codigoRetorno.codRetorno > 0 ? true:false ;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno;
        }

        #endregion

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Producto
        /// En la BASE de DATO la Tabla : [Almacen.Producto]
        /// <summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<DTOProductoResponse> List(BaseFiltroProducto pFiltro)
        {
            List<DTOProductoResponse> lstProducto = new List<DTOProductoResponse>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.usp_sgcfe_R_Producto(pFiltro.codEmpresa, 
                                                           pFiltro.codPuntoVenta, 
                                                           pFiltro.codDeposito, 
                                                           pFiltro.codProductoRefer,
                                                           pFiltro.codGrupo, 
                                                           pFiltro.desNombre, 
                                                           pFiltro.desComercial, 
                                                           pFiltro.codMarca,
                                                           pFiltro.codModelo,
                                                           pFiltro.codRegTipo, 
                                                           pFiltro.indDestinoCompra, 
                                                           pFiltro.indDestinaVenta, 
                                                           pFiltro.codRegCentroProducc, 
                                                           pFiltro.codRegCategoria, 
                                                           pFiltro.codRegUnidadMedida, 
                                                           pFiltro.indEstado, 
                                                           pFiltro.desPalabraClave,
                                                           pFiltro.indTodos);
                    foreach (var item in resul)
                    {
                        lstProducto.Add(new DTOProductoResponse()
                        {
                            codProducto = item.codProducto,

                            CodigoProducto = item.CodigoProducto,
                            CodigoProductoRefer = item.CodigoProductoRefer,
                            codGrupo = item.codGrupo,
                            Descripcion = item.Descripcion,
                            DescripcionComercial = item.DescripcionComercial,
                            DescripcionAbreviada = item.DescripcionAbreviada,
                            Observacion = item.Observacion,
                            DatoAdicional_01 = item.DatoAdicional_01,
                            DatoAdicional_02 = item.DatoAdicional_02,
                            codMarca = item.codMarca,
                            codModelo = item.codModelo,
                            CodigoArguTipoProducto = item.CodigoArguTipoProducto,
                            DestinadoACompra = item.DestinadoACompra,
                            DestinadoAVenta = item.DestinadoAVenta,
                            CodigoArguSectorAlm = item.CodigoArguSectorAlm,
                            CodigoArguMetodoAlm = item.CodigoArguMetodoAlm,
                            CodigoArguCentroProd = item.CodigoArguCentroProd,
                            CodigoArguColor = item.CodigoArguColor,
                            CodigoArguCategoProd = item.CodigoArguCategoProd,
                            CodigoArguUnidadMed = item.CodigoArguUnidadMed,
                            CodigoCuenta = item.CodigoCuenta,
                            EditaDescripcion = item.EditaDescripcion,
                            EditaValorVenta = item.EditaValorVenta,
                            EditaValorCosto = item.EditaValorCosto,
                            EsComboDeOferta = item.EsComboDeOferta,
                            EsListaPrecio = item.EsListaPrecio,
                            EsPerecible = item.EsPerecible,
                            EsVerificacionStock = item.EsVerificacionStock,
                            EsConNumeroSeriado = item.EsConNumeroSeriado,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaCrea = item.SegMaquina,

                            codGrupoNombre = item.codGrupoNombre,
                            codMarcaNombre = item.codMarcaNombre,
                            codModeloNombre = item.codModeloNombre,
                            CodigoArguTipoProductoNombre = item.CodigoArguTipoProductoNombre,
                            CodigoArguSectorAlmNombre = item.CodigoArguSectorAlmNombre,
                            CodigoArguMetodoAlmNombre = item.CodigoArguMetodoAlmNombre,
                            CodigoArguCentroProdNombre = item.CodigoArguCentroProdNombre,
                            CodigoArguColorNombre = item.CodigoArguColorNombre,
                            CodigoArguCategoProdNombre = item.CodigoArguCategoProdNombre,
                            CodigoArguUnidadMedNombre = item.CodigoArguUnidadMedNombre,
                            PalabrasClaves = item.PalabrasClaves,
                            PesoTotal = item.PesoTotal,
                            StockMaximo = item.StockMaximo,
                            StockMinimo = item.StockMinimo,
                            indEsGarantizado = item.indEsGarantizado,
                            StockFisico = item.StockFisico,
                            StockInicial = item.StockInicial,
                            StockSobrante = item.StockSobrante,
                            StoskComprometido = item.StoskComprometido,
                            codDeposito = item.codDeposito,
                            codDepositoNombre = item.codDepositoNombre,
                            codPuntoVenta = item.codPuntoDeVenta,
                            codPuntoVentaNombre = item.codPuntoDeVentaNombre,

                            codRegMoneda = item.codRegMoneda,
                            codRegMonedaNombre = item.codRegMonedaNombre,
                            codRegMonedaSimbolo = item.codRegMonedaSimbolo,
                            ValorCosto = item.ValorCosto.HasValue ? item.ValorCosto.Value : 0,
                            ValorVenta = item.ValorVenta.HasValue ? item.ValorVenta.Value : 0,
                            fecPrecio = item.fecUltimoPrecio.HasValue ? item.fecUltimoPrecio.Value.ToString() : string.Empty,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProducto;
        }
       
        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Almacen.Producto
        /// En la BASE de DATO la Tabla : [Almacen.Producto]
        /// <summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<DTOProductoResponse> ListNumSerie(BaseFiltroProducto pFiltro)
        {
            List<DTOProductoResponse> lstProducto = new List<DTOProductoResponse>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.usp_sgcfe_R_Producto_NumSerie(pFiltro.codEmpresa,
                                                                    pFiltro.codDeposito, 
                                                                    pFiltro.codProductoRefer,
                                                                    pFiltro.codGrupo, 
                                                                    pFiltro.codMarca,
                                                                    pFiltro.codModelo, 
                                                                    pFiltro.desNombre, 
                                                                    pFiltro.desComercial,
                                                                    pFiltro.codRegTipo, 
                                                                    pFiltro.indDestinoCompra,
                                                                    pFiltro.indDestinaVenta, 
                                                                    pFiltro.codRegCentroProducc, 
                                                                    pFiltro.codRegCategoria,
                                                                    pFiltro.codRegUnidadMedida, 
                                                                    pFiltro.indEstado, 
                                                                    pFiltro.desPalabraClave,
                                                                    pFiltro.indTodos, 
                                                                    pFiltro.numSerieProducto);
                    foreach (var item in resul)
                    {
                        lstProducto.Add(new DTOProductoResponse()
                        {
                            codProducto = item.codProducto,

                            CodigoProducto = item.CodigoProducto,
                            CodigoProductoRefer = item.CodigoProductoRefer,
                            codGrupo = item.codGrupo,
                            Descripcion = item.Descripcion,
                            DescripcionComercial = item.DescripcionComercial,
                            DescripcionAbreviada = item.DescripcionAbreviada,
                            Observacion = item.Observacion,
                            DatoAdicional_01 = item.DatoAdicional_01,
                            DatoAdicional_02 = item.DatoAdicional_02,
                            codMarca = item.codMarca,
                            codModelo = item.codModelo,
                            CodigoArguTipoProducto = item.CodigoArguTipoProducto,
                            DestinadoACompra = item.DestinadoACompra,
                            DestinadoAVenta = item.DestinadoAVenta,
                            CodigoArguSectorAlm = item.CodigoArguSectorAlm,
                            CodigoArguMetodoAlm = item.CodigoArguMetodoAlm,
                            CodigoArguCentroProd = item.CodigoArguCentroProd,
                            CodigoArguColor = item.CodigoArguColor,
                            CodigoArguCategoProd = item.CodigoArguCategoProd,
                            CodigoArguUnidadMed = item.CodigoArguUnidadMed,
                            CodigoCuenta = item.CodigoCuenta,
                            EditaDescripcion = item.EditaDescripcion,
                            EditaValorVenta = item.EditaValorVenta,
                            EditaValorCosto = item.EditaValorCosto,
                            EsComboDeOferta = item.EsComboDeOferta,
                            EsListaPrecio = item.EsListaPrecio,
                            EsPerecible = item.EsPerecible,
                            EsVerificacionStock = item.EsVerificacionStock,
                            EsConNumeroSeriado = item.EsConNumeroSeriado,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaCrea = item.SegMaquina,
                            codGrupoNombre = item.codGrupoNombre,
                            codMarcaNombre = item.codMarcaNombre,
                            codModeloNombre = item.codModeloNombre,

                            CodigoArguTipoProductoNombre = item.CodigoArguTipoProductoNombre,
                            CodigoArguSectorAlmNombre = item.CodigoArguSectorAlmNombre,
                            CodigoArguMetodoAlmNombre = item.CodigoArguMetodoAlmNombre,
                            CodigoArguCentroProdNombre = item.CodigoArguCentroProdNombre,
                            CodigoArguColorNombre = item.CodigoArguColorNombre,
                            CodigoArguCategoProdNombre = item.CodigoArguCategoProdNombre,
                            CodigoArguUnidadMedNombre = item.CodigoArguUnidadMedNombre,
                            PalabrasClaves = item.PalabrasClaves,
                            PesoTotal = item.PesoTotal,
                            StockMaximo = item.StockMaximo,
                            StockMinimo = item.StockMinimo,
                            indEsGarantizado = item.indEsGarantizado,
                            StockFisico = item.StockFisico,
                            StockInicial = item.StockInicial,
                            StockSobrante = item.StockSobrante,
                            StoskComprometido = item.StoskComprometido,
                            codDeposito = item.codDeposito,
                            codDepositoNombre = item.desNombre,
                            numeroSerie = item.NumeroSerie
                        });
                    }
                }
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
        /// <param name="prm_codProducto"></param>
        /// <returns></returns>
        public BEProducto Find(int pcodEmpresa, int prm_codProducto)
        {
            BEProducto producto = null;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.usp_sgcfe_R_Producto_ID(pcodEmpresa, prm_codProducto);
                    foreach (var item in resul)
                    {
                        producto = new BEProducto();
                        producto.codEmpresa = pcodEmpresa;
                        producto.codProducto = item.codProducto;
                        producto.CodigoProducto = item.CodigoProducto;
                        producto.CodigoProductoRefer = item.CodigoProductoRefer;
                        producto.codGrupo = item.codGrupo;
                        producto.Descripcion = item.Descripcion;
                        producto.DescripcionComercial = item.DescripcionComercial;
                        producto.DescripcionAbreviada = item.DescripcionAbreviada;
                        producto.Observacion = item.Observacion;
                        producto.DatoAdicional_01 = item.DatoAdicional_01;
                        producto.DatoAdicional_02 = item.DatoAdicional_02;
                        producto.codMarca = item.codMarca;
                        producto.codModelo = item.codModelo;
                        producto.DestinadoACompra = item.DestinadoACompra;
                        producto.DestinadoAVenta = item.DestinadoAVenta;
                        producto.CodigoArguTipoProducto = item.CodigoArguTipoProducto == null ? string.Empty : item.CodigoArguTipoProducto;
                        producto.CodigoArguSectorAlm = item.CodigoArguSectorAlm == null ? string.Empty : item.CodigoArguSectorAlm;
                        producto.CodigoArguMetodoAlm = item.CodigoArguMetodoAlm == null ? string.Empty : item.CodigoArguMetodoAlm;
                        producto.CodigoArguCentroProd = item.CodigoArguCentroProd == null ? string.Empty : item.CodigoArguCentroProd;
                        producto.CodigoArguColor = item.CodigoArguColor == null ? string.Empty : item.CodigoArguColor;
                        producto.CodigoArguCategoProd = item.CodigoArguCategoProd == null ? string.Empty : item.CodigoArguCategoProd;
                        producto.CodigoArguUnidadMed = item.CodigoArguUnidadMed == null ? string.Empty : item.CodigoArguUnidadMed;
                        producto.CodigoCuenta = item.CodigoCuenta == null ? string.Empty : item.CodigoCuenta;
                        producto.EditaDescripcion = item.EditaDescripcion;
                        producto.EditaValorVenta = item.EditaValorVenta;
                        producto.EditaValorCosto = item.EditaValorCosto;
                        producto.EsComboDeOferta = item.EsComboDeOferta;
                        producto.EsListaPrecio = item.EsListaPrecio;
                        producto.EsPerecible = item.EsPerecible;
                        producto.EsVerificacionStock = item.EsVerificacionStock;
                        producto.EsConNumeroSeriado = item.EsConNumeroSeriado;
                        producto.Estado = item.Estado;
                        producto.segUsuarioCrea = item.SegUsuarioCrea;
                        producto.segUsuarioEdita = item.SegUsuarioEdita;
                        producto.segFechaCrea = item.SegFechaCrea;
                        producto.segFechaEdita = item.SegFechaEdita;
                        producto.segMaquinaCrea = item.SegMaquina;
                        
                        producto.PalabrasClaves = item.PalabrasClaves;

                        producto.PesoTotal = item.PesoTotal;
                        producto.StockMaximo = item.StockMaximo;
                        producto.StockMinimo = item.StockMinimo;
                        producto.indEsGarantizado = item.indEsGarantizado;

                        producto.codRegMoneda = item.codRegMoneda;
                        producto.codRegMonedaNombre = item.codRegMonedaNombre;
                        producto.codRegMonedaSimbolo = item.codRegMonedaSimbolo;
                        producto.ValorCosto = item.ValorCosto;
                        producto.ValorVenta = item.ValorVenta;
                        producto.fecPrecio = item.fecUltimoPrecio.HasValue ? item.fecUltimoPrecio.Value.ToString() : string.Empty;
                        producto.prcDescuentoMaximo = item.DescuentoMaximo * 100;

                        producto.itemProductoPrecio.CodigoArguMoneda = item.codRegMoneda;
                        producto.itemProductoPrecio.MargenUtilidad = item.MargenUtilidad.HasValue ? item.MargenUtilidad.Value * 100 : 0;
                        producto.itemProductoPrecio.MediaPorcentaje = item.MediaPorcentaje.HasValue ? item.MediaPorcentaje.Value * 100 : 0;
                        producto.itemProductoPrecio.PorcenComision = item.PorcenComision.HasValue ? item.PorcenComision.Value * 100 : 0;
                        producto.itemProductoPrecio.PorcenComisionMax = item.PorcenComisionMax.HasValue ? item.PorcenComisionMax.Value * 100 : 0;
                        producto.itemProductoPrecio.DescuentoMaximo = item.DescuentoMaximo * 100;
                        producto.itemProductoPrecio.ValorCosto = item.ValorCosto;
                        producto.itemProductoPrecio.ValorVenta = item.ValorVenta;
                        producto.itemProductoPrecio.segFechaCrea = item.fecUltimoPrecio.HasValue ? item.fecUltimoPrecio.Value : DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud());
                        producto.itemProductoPrecio.codProductoPrecio = item.codProductoPrecio.HasValue ? item.codProductoPrecio.Value : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return producto;
        }

        public BEProducto Find(int pcodEmpresa, string prm_codigoProducto)
        {
            BEProducto producto = null;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.usp_sgcfe_R_Producto_Codigo(pcodEmpresa, prm_codigoProducto);
                    foreach (var item in resul)
                    {
                        producto = new BEProducto();
                        producto.codEmpresa = pcodEmpresa;
                        producto.codProducto = item.codProducto;
                        producto.CodigoProducto = item.CodigoProducto;
                        producto.CodigoProductoRefer = item.CodigoProductoRefer;
                        producto.codGrupo = item.codGrupo;
                        producto.Descripcion = item.Descripcion;
                        producto.DescripcionComercial = item.DescripcionComercial;
                        producto.DescripcionAbreviada = item.DescripcionAbreviada;
                        producto.Observacion = item.Observacion;
                        producto.DatoAdicional_01 = item.DatoAdicional_01;
                        producto.DatoAdicional_02 = item.DatoAdicional_02;
                        producto.codMarca = item.codMarca;
                        producto.codModelo = item.codModelo;
                        producto.CodigoArguTipoProducto = item.CodigoArguTipoProducto == null ? string.Empty : item.CodigoArguTipoProducto;
                        producto.DestinadoACompra = item.DestinadoACompra;
                        producto.DestinadoAVenta = item.DestinadoAVenta;
                        producto.CodigoArguSectorAlm = item.CodigoArguSectorAlm == null ? string.Empty : item.CodigoArguSectorAlm;
                        producto.CodigoArguMetodoAlm = item.CodigoArguMetodoAlm == null ? string.Empty : item.CodigoArguMetodoAlm;
                        producto.CodigoArguCentroProd = item.CodigoArguCentroProd == null ? string.Empty : item.CodigoArguCentroProd;
                        producto.CodigoArguColor = item.CodigoArguColor == null ? string.Empty : item.CodigoArguColor;
                        producto.CodigoArguCategoProd = item.CodigoArguCategoProd == null ? string.Empty : item.CodigoArguCategoProd;
                        producto.CodigoArguUnidadMed = item.CodigoArguUnidadMed == null ? string.Empty : item.CodigoArguUnidadMed;
                        producto.CodigoCuenta = item.CodigoCuenta == null ? string.Empty : item.CodigoCuenta;
                        producto.EditaDescripcion = item.EditaDescripcion;
                        producto.EditaValorVenta = item.EditaValorVenta;
                        producto.EditaValorCosto = item.EditaValorCosto;
                        producto.EsComboDeOferta = item.EsComboDeOferta;
                        producto.EsListaPrecio = item.EsListaPrecio;
                        producto.EsPerecible = item.EsPerecible;
                        producto.EsVerificacionStock = item.EsVerificacionStock;
                        producto.EsConNumeroSeriado = item.EsConNumeroSeriado;
                        producto.Estado = item.Estado;
                        producto.segUsuarioCrea = item.SegUsuarioCrea;
                        producto.segUsuarioEdita = item.SegUsuarioEdita;
                        producto.segFechaCrea = item.SegFechaCrea;
                        producto.segFechaEdita = item.SegFechaEdita;
                        producto.segMaquinaCrea = item.SegMaquina;
                       
                        producto.PalabrasClaves = item.PalabrasClaves;

                        producto.PesoTotal = item.PesoTotal;
                        producto.StockMaximo = item.StockMaximo;
                        producto.StockMinimo = item.StockMinimo;
                        producto.indEsGarantizado = item.indEsGarantizado;

                        producto.codRegMoneda = item.codRegMoneda;
                        producto.codRegMonedaNombre = item.codRegMonedaNombre;
                        producto.codRegMonedaSimbolo = item.codRegMonedaSimbolo;
                        producto.ValorCosto = item.ValorCosto;
                        producto.ValorVenta = item.ValorVenta;
                        producto.fecPrecio = item.fecUltimoPrecio.HasValue ? item.fecUltimoPrecio.Value.ToString() : string.Empty;
                        producto.prcDescuentoMaximo = item.DescuentoMaximo * 100;

                        producto.itemProductoPrecio.CodigoArguMoneda = item.codRegMoneda;
                        producto.itemProductoPrecio.MargenUtilidad = item.MargenUtilidad.HasValue ? item.MargenUtilidad.Value * 100 : 0;
                        producto.itemProductoPrecio.MediaPorcentaje = item.MediaPorcentaje.HasValue ? item.MediaPorcentaje.Value * 100 : 0;
                        producto.itemProductoPrecio.PorcenComision = item.PorcenComision.HasValue ? item.PorcenComision.Value * 100 : 0;
                        producto.itemProductoPrecio.PorcenComisionMax = item.PorcenComisionMax.HasValue ? item.PorcenComisionMax.Value * 100 : 0;
                        producto.itemProductoPrecio.DescuentoMaximo = item.DescuentoMaximo * 100;
                        producto.itemProductoPrecio.ValorCosto = item.ValorCosto;
                        producto.itemProductoPrecio.ValorVenta = item.ValorVenta;
                        producto.itemProductoPrecio.segFechaCrea = item.fecUltimoPrecio.HasValue ? item.fecUltimoPrecio.Value : DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud());
                        producto.itemProductoPrecio.codProductoPrecio = item.codProductoPrecio.HasValue ? item.codProductoPrecio.Value : 0;
                    }
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
            BEProducto producto = null;
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Producto_Empresa(prm_baseFiltro.codEmpresa,
                                                              prm_baseFiltro.codProductoRefer, 
                                                              prm_baseFiltro.codProducto,
                                                              prm_baseFiltro.codPuntoVenta,
                                                              prm_baseFiltro.codDeposito);
                    foreach (var item in resul)
                    {
                        producto = new BEProducto();
                        producto.codProducto = item.codProducto;
                        producto.codEmpresa = item.codEmpresa;
                        producto.CodigoProducto = item.CodigoProducto;
                        producto.CodigoProductoRefer = item.CodigoProductoRefer;
                        producto.codGrupo = item.codGrupo;
                        producto.Descripcion = item.Descripcion;
                        producto.DescripcionComercial = item.DescripcionComercial;
                        producto.DescripcionAbreviada = item.DescripcionAbreviada;
                        producto.Observacion = item.Observacion;
                        producto.DatoAdicional_01 = item.DatoAdicional_01;
                        producto.DatoAdicional_02 = item.DatoAdicional_02;
                        producto.codMarca = item.codMarca;
                        producto.codModelo = item.codModelo;
                        producto.CodigoArguTipoProducto = item.CodigoArguTipoProducto == null ? string.Empty : item.CodigoArguTipoProducto;
                        producto.DestinadoACompra = item.DestinadoACompra;
                        producto.DestinadoAVenta = item.DestinadoAVenta;
                        producto.CodigoArguSectorAlm = item.CodigoArguSectorAlm == null ? string.Empty : item.CodigoArguSectorAlm;
                        producto.CodigoArguMetodoAlm = item.CodigoArguMetodoAlm == null ? string.Empty : item.CodigoArguMetodoAlm;
                        producto.CodigoArguCentroProd = item.CodigoArguCentroProd == null ? string.Empty : item.CodigoArguCentroProd;
                        producto.CodigoArguColor = item.CodigoArguColor == null ? string.Empty : item.CodigoArguColor;
                        producto.CodigoArguCategoProd = item.CodigoArguCategoProd == null ? string.Empty : item.CodigoArguCategoProd;
                        producto.CodigoArguUnidadMed = item.CodigoArguUnidadMed == null ? string.Empty : item.CodigoArguUnidadMed;
                        producto.CodigoCuenta = item.CodigoCuenta == null ? string.Empty : item.CodigoCuenta;
                        producto.EditaDescripcion = item.EditaDescripcion;
                        producto.EditaValorVenta = item.EditaValorVenta;
                        producto.EditaValorCosto = item.EditaValorCosto;
                        producto.EsComboDeOferta = item.EsComboDeOferta;
                        producto.EsListaPrecio = item.EsListaPrecio;
                        producto.EsPerecible = item.EsPerecible;
                        producto.EsVerificacionStock = item.EsVerificacionStock;
                        producto.EsConNumeroSeriado = item.EsConNumeroSeriado;
                        producto.Estado = item.Estado;
                        producto.segUsuarioCrea = item.SegUsuarioCrea;
                        producto.segUsuarioEdita = item.SegUsuarioEdita;
                        producto.segFechaCrea = item.SegFechaCrea;
                        producto.segFechaEdita = item.SegFechaEdita;
                        producto.segMaquinaCrea = item.SegMaquina;
                        //producto.codGrupoNombre = item.codGrupoNombre;
                        //producto.codMarcaNombre = item.codMarcaNombre;
                        //producto.codModeloNombre = item.codModeloNombre;
                        //producto.CodigoArguTipoProductoNombre = item.CodigoArguTipoProductoNombre;
                        //producto.CodigoArguSectorAlmNombre = item.CodigoArguSectorAlmNombre;
                        //producto.CodigoArguMetodoAlmNombre = item.CodigoArguMetodoAlmNombre;
                        //producto.CodigoArguCentroProdNombre = item.CodigoArguCentroProdNombre;
                        //producto.CodigoArguColorNombre = item.CodigoArguColorNombre;
                        //producto.CodigoArguCategoProdNombre = item.CodigoArguCategoProdNombre;
                        //producto.CodigoArguUnidadMedNombre = item.CodigoArguUnidadMedNombre;
                        producto.PalabrasClaves = item.PalabrasClaves;

                        producto.PesoTotal = item.PesoTotal;
                        producto.StockMaximo = item.StockMaximo;
                        producto.StockMinimo = item.StockMinimo;
                        producto.indEsGarantizado = item.indEsGarantizado;

                        producto.codRegMoneda = item.codRegMoneda;
                        producto.codRegMonedaNombre = item.codRegMonedaNombre;
                        producto.codRegMonedaSimbolo = item.codRegMonedaSimbolo;
                        producto.ValorCosto = item.ValorCosto;
                        producto.ValorVenta = item.ValorVenta;
                        producto.fecPrecio = item.fecUltimoPrecio.HasValue ? item.fecUltimoPrecio.Value.ToString() : string.Empty;
                        producto.prcDescuentoMaximo = item.DescuentoMaximo * 100;
                        producto.itemProductoPrecio.CodigoArguMoneda = item.codRegMoneda;
                        producto.itemProductoPrecio.MargenUtilidad = item.MargenUtilidad.HasValue ? item.MargenUtilidad.Value * 100 : 0;
                        producto.itemProductoPrecio.MediaPorcentaje = item.MediaPorcentaje.HasValue ? item.MediaPorcentaje.Value * 100 : 0;
                        producto.itemProductoPrecio.PorcenComision = item.PorcenComision.HasValue ? item.PorcenComision.Value * 100 : 0;
                        producto.itemProductoPrecio.PorcenComisionMax = item.PorcenComisionMax.HasValue ? item.PorcenComisionMax.Value * 100 : 0;
                        producto.itemProductoPrecio.DescuentoMaximo = item.DescuentoMaximo * 100;
                        producto.itemProductoPrecio.ValorCosto = item.ValorCosto;
                        producto.itemProductoPrecio.ValorVenta = item.ValorVenta;
                        producto.itemProductoPrecio.segFechaCrea = item.fecUltimoPrecio.HasValue ? item.fecUltimoPrecio.Value : DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud());
                        producto.itemProductoPrecio.codProductoPrecio = item.codProductoPrecio.HasValue ? item.codProductoPrecio.Value : 0;


                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return producto;
        }

        #endregion

        public List<DTOProductoResponse> ListParaInventario(BaseFiltroProducto pFiltro) 
        {
            List<DTOProductoResponse> lstProducto = new List<DTOProductoResponse>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Producto_Inventario(pFiltro.codEmpresa,
                                                                 pFiltro.codDeposito, 
                                                                 pFiltro.codProductoRefer,
                                                                 pFiltro.codGrupo, 
                                                                 pFiltro.desNombre, 
                                                                 pFiltro.desComercial,
                                                                 pFiltro.codMarca, 
                                                                 pFiltro.codRegTipo, 
                                                                 pFiltro.indDestinoCompra,
                                                                 pFiltro.indDestinaVenta, 
                                                                 pFiltro.codRegCentroProducc, 
                                                                 pFiltro.codRegCategoria,
                                                                 pFiltro.codRegUnidadMedida, 
                                                                 pFiltro.indEstado, 
                                                                 pFiltro.desPalabraClave,
                                                                 pFiltro.perPeriodo);
                    foreach (var item in resul)
                    {
                        lstProducto.Add(new DTOProductoResponse()
                        {
                            codProducto = item.codProducto,
                            CodigoProducto = item.CodigoProducto,
                            CodigoProductoRefer = item.CodigoProductoRefer,
                            codGrupo = item.codGrupo,
                            Descripcion = item.Descripcion,
                            DescripcionComercial = item.DescripcionComercial,
                            DescripcionAbreviada = item.DescripcionAbreviada,
                            Observacion = item.Observacion,
                            DatoAdicional_01 = item.DatoAdicional_01,
                            DatoAdicional_02 = item.DatoAdicional_02,
                            codMarca = item.codMarca,
                            CodigoArguTipoProducto = item.CodigoArguTipoProducto,
                            DestinadoACompra = item.DestinadoACompra,
                            DestinadoAVenta = item.DestinadoAVenta,
                            CodigoArguSectorAlm = item.CodigoArguSectorAlm,

                            CodigoArguMetodoAlm = item.CodigoArguMetodoAlm,
                            CodigoArguCentroProd = item.CodigoArguCentroProd,
                            CodigoArguColor = item.CodigoArguColor,
                            CodigoArguCategoProd = item.CodigoArguCategoProd,
                            CodigoArguUnidadMed = item.CodigoArguUnidadMed,
                            CodigoCuenta = item.CodigoCuenta,
                            EditaDescripcion = item.EditaDescripcion,
                            EditaValorVenta = item.EditaValorVenta,
                            EditaValorCosto = item.EditaValorCosto,
                            EsComboDeOferta = item.EsComboDeOferta,
                            EsListaPrecio = item.EsListaPrecio,
                            EsPerecible = item.EsPerecible,
                            EsVerificacionStock = item.EsVerificacionStock,
                            EsConNumeroSeriado = item.EsConNumeroSeriado,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaCrea = item.SegMaquina,
                            codGrupoNombre = item.codGrupoNombre,
                            codMarcaNombre = item.codMarcaNombre,
                            codModelo= item.codModelo,
                            codModeloNombre= item.codModeloNombre,
                            CodigoArguTipoProductoNombre = item.CodigoArguTipoProductoNombre,
                            CodigoArguSectorAlmNombre = item.CodigoArguSectorAlmNombre,

                            CodigoArguMetodoAlmNombre = item.CodigoArguMetodoAlmNombre,
                            CodigoArguCentroProdNombre = item.CodigoArguCentroProdNombre,
                            CodigoArguColorNombre = item.CodigoArguColorNombre,
                            CodigoArguCategoProdNombre = item.CodigoArguCategoProdNombre,
                            CodigoArguUnidadMedNombre = item.CodigoArguUnidadMedNombre,
                            PalabrasClaves = item.PalabrasClaves,
                            PesoTotal = item.PesoTotal,
                            cntInventariar = item.cntInventariar
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProducto;
        }

        public List<DTOProductoResponse> ListParaStockInicial(BaseFiltroProducto pFiltro) 
        {
            List<DTOProductoResponse> lstProducto = new List<DTOProductoResponse>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Producto_StockInicial(pFiltro.codEmpresa,
                                                                   pFiltro.codPuntoVenta, 
                                                                   pFiltro.codDeposito, 
                                                                   pFiltro.codProductoRefer,
                                                                   pFiltro.codGrupo, 
                                                                   pFiltro.desNombre, 
                                                                   pFiltro.desComercial,
                                                                   pFiltro.codMarca, 
                                                                   pFiltro.codRegTipo, 
                                                                   pFiltro.indDestinoCompra,
                                                                   pFiltro.indDestinaVenta, 
                                                                   pFiltro.codRegCentroProducc, 
                                                                   pFiltro.codRegCategoria,
                                                                   pFiltro.codRegUnidadMedida, 
                                                                   pFiltro.indEstado, 
                                                                   pFiltro.desPalabraClave);
                    foreach (var item in resul)
                    {
                        lstProducto.Add(new DTOProductoResponse()
                        {
                            codProducto = item.codProducto,
                            codEmpresa = pFiltro.codEmpresa,
                            CodigoProducto = item.CodigoProducto,
                            CodigoProductoRefer = item.CodigoProductoRefer,
                            codGrupo = item.codGrupo,
                            Descripcion = item.Descripcion,
                            DescripcionComercial = item.DescripcionComercial,
                            DescripcionAbreviada = item.DescripcionAbreviada,
                            Observacion = item.Observacion,
                            DatoAdicional_01 = item.DatoAdicional_01,
                            DatoAdicional_02 = item.DatoAdicional_02,
                            codMarca = item.codMarca,
                            codModelo= item.codModelo,
                            CodigoArguTipoProducto = item.CodigoArguTipoProducto,
                            DestinadoACompra = item.DestinadoACompra,
                            DestinadoAVenta = item.DestinadoAVenta,
                            CodigoArguSectorAlm = item.CodigoArguSectorAlm,

                            CodigoArguMetodoAlm = item.CodigoArguMetodoAlm,
                            CodigoArguCentroProd = item.CodigoArguCentroProd,
                            CodigoArguColor = item.CodigoArguColor,
                            CodigoArguCategoProd = item.CodigoArguCategoProd,
                            CodigoArguUnidadMed = item.CodigoArguUnidadMed,
                            CodigoCuenta = item.CodigoCuenta,
                            EditaDescripcion = item.EditaDescripcion,
                            EditaValorVenta = item.EditaValorVenta,
                            EditaValorCosto = item.EditaValorCosto,
                            EsComboDeOferta = item.EsComboDeOferta,
                            EsListaPrecio = item.EsListaPrecio,
                            EsPerecible = item.EsPerecible,
                            EsVerificacionStock = item.EsVerificacionStock,
                            EsConNumeroSeriado = item.EsConNumeroSeriado,
                            Estado = item.Estado,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segUsuarioEdita = item.SegUsuarioEdita,
                            segFechaCrea = item.SegFechaCrea,
                            segFechaEdita = item.SegFechaEdita,
                            segMaquinaCrea = item.SegMaquina,
                            codGrupoNombre = item.codGrupodesNombre,
                            codMarcaNombre = item.codMarcaNombre,
                            codModeloNombre= item.codModeloNombre,
                            CodigoArguTipoProductoNombre = item.CodigoArguTipoProductoNombre,
                            CodigoArguSectorAlmNombre = item.CodigoArguSectorAlmNombre,

                            CodigoArguMetodoAlmNombre = item.CodigoArguMetodoAlmNombre,
                            CodigoArguCentroProdNombre = item.CodigoArguCentroProdNombre,
                            CodigoArguColorNombre = item.CodigoArguColorNombre,
                            CodigoArguCategoProdNombre = item.CodigoArguCategoProdNombre,
                            CodigoArguUnidadMedNombre = item.CodigoArguUnidadMedNombre,
                            PalabrasClaves = item.PalabrasClaves,
                            PesoTotal = item.PesoTotal,
                             
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProducto;
        }

        public List<BEProducto> ListProductoSinListaPrecio(BaseFiltroAlmacen pFiltro)
        {
            List<BEProducto> lstProductos = new List<BEProducto>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Producto_SinListaPrecio(pFiltro.codEmpresa,
                                                                     pFiltro.indVentaCompra, 
                                                                     pFiltro.codListaPrecio);
                    foreach (var item in resul)
                    {
                        lstProductos.Add(new BEProducto()
                        {
                            CodigoProducto = item.CodigoProducto,
                            CodigoProductoRefer = item.CodigoProductoRefer,
                            Descripcion = item.Descripcion,
                            DescripcionComercial = item.DescripcionComercial,

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductos;
        }

        public List<ProductoCodBarras> ListParaCodBarras(BaseFiltroAlmacen pFiltro)
        {
            List<ProductoCodBarras> lstCodigoBarras = new List<ProductoCodBarras>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Producto_CodBarras(pFiltro.codEmpresa, 
                                                                pFiltro.codProducto);
                    foreach (var item in resul)
                    {
                        lstCodigoBarras.Add(new ProductoCodBarras()
                        {
                            codProducto = item.codProducto,
                            codigoProducto = Convert.ToString(item.codProducto),
                            codProductoRefer = item.codProductoRefer,
                            codRegistroMoneda = item.codRegistroMoneda,
                            codProveedores = item.codProveedores,
                            desNombre = item.codMarcaNombre,
                            monPrecioVenta = item.monPrecioVenta == null ? 0 : item.monPrecioVenta.Value,
                            canStockFisico = item.canStockFisico.HasValue ? item.canStockFisico.Value : 0,
                            canBarraImprime = item.canStockFisico.HasValue ? item.canStockFisico.Value : 0,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCodigoBarras;
        }

        public List<ProductoKardexAux> ListParaValorizado(BaseFiltroAlmacen pFiltro) 
        {
            List<ProductoKardexAux> lstProductoKardex = new List<ProductoKardexAux>();
            try
            {
                using (_AlmacenDataContext SQLDC = new _AlmacenDataContext(conexion))
                {
                    var resul = SQLDC.omgc_S_Producto_Valorizado(pFiltro.codEmpresa, 
                                                                 pFiltro.fecInicio, 
                                                                 pFiltro.fecFinal, 
                                                                 pFiltro.codPuntoVenta, 
                                                                 pFiltro.codProducto);
                    foreach (var item in resul)
                    {
                        lstProductoKardex.Add(new ProductoKardexAux()
                        {
                            codDocumRegDetalle = item.codDocumRegDetalle,
                            codDocumReg = item.codDocumReg,
                            codEmpresa = item.codEmpresa,
                            codPuntoDeVenta = item.CodigoPuntoVenta,
                            fecMovimiento = item.FechaDeEmision,
                            codigoProducto = item.CodigoProducto,
                            codProducto = item.codProducto,
                            codRegistroTipoMovimi = item.CodigoArguTipoDeOperacion,
                            codDocumento = item.CodigoComprobante,
                            numDocumento = item.NumeroComprobante,
                            cntRegistrado = item.Cantidad,
                            monRegistrado = item.UnitValorCosto,

                            desRazonSocial = item.EntidadRazonSocial,
                            codDeposito = item.codDeposito,
                            segUsuarioCrea = item.SegUsuarioCrea,
                            segFechaCrea = item.FechaDeEmision,
                            segMaquina = item.SegMaquina,
                            codRegistroTipoMovimiNombre = item.codRegTipoDeOperacionNombre,
                            codDocumentoNombre = item.codigoComprobanteNombre,
                            codProductoNombre = item.Descripcion,
                            codProductoRefer = item.CodigoProductoRefer,
                            codRegistroCategProducto = item.CodigoArguCategoProd,
                            codRegistroCategProductoNombre = item.codRegCategoProdNombre,
                            codRegistroUnidadMedida = item.CodigoArguUnidadMed,
                            codRegistroUnidadMedidaNombre = item.codRegUnidadMedNombre,
                            codRegistroDepositoNombre = item.codDepositoNombre,
                            codPuntoDeVentaNombre = item.CodigoPuntoVentaNombre,

                            cntStockFisico = item.StockFisico,
                            indMovimiento = item.IncidenciaEnStocks,
                            codPersonaMovimiNombre = item.EntidadRazonSocial,

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProductoKardex;
        }
     
    }
} 

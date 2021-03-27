namespace CROM.ComercialAlmacen.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;

    using CROM.BusinessEntities.Comercial;
    using CROM.BusinessEntities.Almacen;
    using CROM.Tools.Config;

    public class UtilLogic
    {
        public void EncontrarPrecios(BEProducto prm_itemProducto, BaseFiltro filtro, ref decimal prm_PRECIO_VENTAS, ref decimal prm_PRECIO_COMPRA, ref string prm_CODIMONEDA) // string prm_CodigoEmpresa, string prm_CodigoPuntoVenta, string prm_DestinoComp)
        {
            decimal intPRECIO_VENTAS = 0;
            decimal intPRECIO_COMPRA = 0;
            string intprm_CODIMONEDA = ConfigCROM.AppConfig(ConfigTool.DEFAULT_MonedaNac);

            filtro.codProducto = prm_itemProducto.codProducto;
            filtro.codRegMoneda = string.Empty;
            filtro.indEstado = true;

            if (prm_itemProducto.EsListaPrecio)
            {
                ListaDePrecioLogic oListaDePrecioLogic = new ListaDePrecioLogic();
                List<BEListaDePrecioDetalle> listaListaDePrecioDetalle = new List<BEListaDePrecioDetalle>();
                if (filtro.codRegDestinoDocum == ConstantesGC.OPERACION_DESTINO_VENTAS)
                {
                    filtro.codListaPrecio = ConfigCROM.AppConfig(ConfigTool.DEFAULT_ListaPrecioVenta);
                    listaListaDePrecioDetalle = oListaDePrecioLogic.ListDetalle(filtro);
                    if (listaListaDePrecioDetalle.Count == 0)
                        intPRECIO_VENTAS = 0;
                    else
                    {
                        intPRECIO_VENTAS = listaListaDePrecioDetalle[0].PrecioUnitario;
                        intprm_CODIMONEDA = listaListaDePrecioDetalle[0].CodigoArguMoneda;
                    }
                }
                else if (filtro.codRegDestinoDocum == ConstantesGC.OPERACION_DESTINO_COMPRAS)
                {
                    filtro.codListaPrecio = ConfigCROM.AppConfig(ConfigTool.DEFAULT_ListaPrecioCompra);
                    listaListaDePrecioDetalle = oListaDePrecioLogic.ListDetalle(filtro);
                    if (listaListaDePrecioDetalle.Count == 0)
                        intPRECIO_COMPRA = 0;
                    else
                    {
                        intPRECIO_COMPRA = listaListaDePrecioDetalle[0].PrecioUnitario;
                        intprm_CODIMONEDA = listaListaDePrecioDetalle[0].CodigoArguMoneda;
                    }
                }
                else if (filtro.codRegDestinoDocum == ConstantesGC.OPERACION_DESTINO_INTERNO)
                {
                    filtro.codListaPrecio = ConfigCROM.AppConfig(ConfigTool.DEFAULT_ListaPrecioCompra);
                    listaListaDePrecioDetalle = oListaDePrecioLogic.ListDetalle(filtro);
                    if (listaListaDePrecioDetalle.Count == 0)
                        intPRECIO_COMPRA = 0;
                    else
                    {
                        intPRECIO_COMPRA = listaListaDePrecioDetalle[0].PrecioUnitario;
                        intprm_CODIMONEDA = listaListaDePrecioDetalle[0].CodigoArguMoneda;
                    }
                }

            }
            else
            {
                if (filtro.codRegDestinoDocum == ConstantesGC.OPERACION_DESTINO_VENTAS)
                {
                    intPRECIO_VENTAS = prm_itemProducto.itemProductoPrecio.ValorVenta;
                }
                else if (filtro.codRegDestinoDocum == ConstantesGC.OPERACION_DESTINO_COMPRAS)
                {
                    intPRECIO_COMPRA = prm_itemProducto.itemProductoPrecio.ValorCosto;
                }
                else if (filtro.codRegDestinoDocum == ConstantesGC.OPERACION_DESTINO_INTERNO)
                {
                    intPRECIO_COMPRA = prm_itemProducto.itemProductoPrecio.ValorCosto;
                }
                intprm_CODIMONEDA = prm_itemProducto.itemProductoPrecio.CodigoArguMoneda;
            }
            prm_CODIMONEDA = intprm_CODIMONEDA;
            prm_PRECIO_COMPRA = intPRECIO_COMPRA;
            prm_PRECIO_VENTAS = intPRECIO_VENTAS;
        }
    }
}

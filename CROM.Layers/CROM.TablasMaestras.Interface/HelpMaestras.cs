namespace CROM.TablasMaestras.Interface
{
    using CROM.BusinessEntities.Maestros;
    using CROM.TablasMaestras.BussinesLogic;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.settings;
    using CROM.Tools.Comun.Web;

    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    using System.Windows.Forms;

    public static class HelpMaestras
    {
        /// <summary>
        /// Nombre:	CargarListadoGenerico
        /// Carga una lista de tipo TablasMaestrasRegistros en un comboBox.
        /// Modificacion: WF(CROM) 20100109 - 
        /// </summary>
        /// <param name="controlListado"></param>
        /// <param name="pCodTabla"></param>
        /// <param name="pCodArgu"></param>
        /// <param name="pNivel"></param>
        /// <param name="pEstado"></param>
        /// <param name="pIdioma"></param>
        /// <param name="pTipoDescripcion"></param>
        /// <param name="pUbicarCodArgu"></param>
        /// <param name="tipoTexto"></param>
        public static void CargarListadoGenerico(ComboBox controlListado, string pCodTabla, 
                                                 string pCodArgu, int pNivel, MaestroLogic.EstadoDetalle pEstado, 
                                                 MaestroLogic.TipoLongitudDetalle pTipoDescripcion, 
                                                 string pUbicarCodArgu, Helper.ComboBoxText tipoTexto,
                                                 int pcodEmpresa, string pSegUsuario)
        {
            MaestroLogic oMaestroLogic = new MaestroLogic();
            List<BERegistro> listadoTablaMaestraRegistro = oMaestroLogic.ListarComboDetalle(pCodTabla, 
                                                                                            pCodArgu, 
                                                                                            pNivel, 
                                                                                            pEstado, 
                                                                                            pcodEmpresa, 
                                                                                            pSegUsuario);

            List<CROM.Tools.Windows.ListItem> itemListado = new List<CROM.Tools.Windows.ListItem>();
            if (tipoTexto != Helper.ComboBoxText.No_Agregar)
                itemListado.Add(new CROM.Tools.Windows.ListItem { CodigoArgumento = "", Nombre = Helper.ObtenerTexto(tipoTexto) });
            if (pTipoDescripcion == MaestroLogic.TipoLongitudDetalle.Larga)
            {
                listadoTablaMaestraRegistro.Sort(delegate(BERegistro parametro1, BERegistro parametro2)
                { return parametro1.DescripcionLarga.CompareTo(parametro2.DescripcionLarga); });
                controlListado.Items.Clear();
                foreach (BERegistro item in listadoTablaMaestraRegistro)
                {
                    itemListado.Add(new CROM.Tools.Windows.ListItem()
                    {
                        CodigoArgumento = item.CodigoArgumento,
                        Nombre = item.DescripcionCorta,
                        ValorEntero = item.ValorEntero,
                        ValorCadena = item.ValorCadena,
                        CodigoTabla = item.CodigoTabla,
                        Descripcion = item.DescripcionLarga,
                        ValorBoolean = item.ValorBoolean,
                        ValorDecimal = item.ValorDecimal,
                        ValorFecha = item.ValorFecha
                    }
                    );
                }
            }
            else
            {
                listadoTablaMaestraRegistro.Sort(delegate(BERegistro parametro1, BERegistro parametro2)
                { return parametro1.DescripcionCorta.CompareTo(parametro2.DescripcionCorta); });
                foreach (BERegistro item in listadoTablaMaestraRegistro)
                {
                    itemListado.Add(new CROM.Tools.Windows.ListItem()
                    {
                        CodigoArgumento = item.CodigoArgumento,
                        Nombre = item.DescripcionCorta,
                        ValorEntero = item.ValorEntero,
                        ValorCadena = item.ValorCadena,
                        CodigoTabla = item.CodigoTabla,
                        Descripcion = item.DescripcionLarga,
                        ValorBoolean = item.ValorBoolean,
                        ValorDecimal = item.ValorDecimal,
                        ValorFecha = item.ValorFecha
                    }
                    );
                }
            }
            controlListado.DataSource = itemListado;
            controlListado.DisplayMember = "Nombre";
            controlListado.ValueMember = "CodigoArgumento";
            if (pUbicarCodArgu.Trim().Length == 0)
            {
                controlListado.SelectedIndex = 0;
            }
            else
            {
                //SeleccionarItem(controlListado, pUbicarCodArgu);
            }

        }

        public static void CargarListadoGenerico(ref DropDownList pComboBox, string pCodTabla, 
                                                 int pNivel, string pCodArgu, MaestroLogic.EstadoDetalle pEstado, 
                                                 HelpComboBox.Texto pTexto,
                                                 int pcodEmpresa, string pSegUsuario)
        {
            MaestroLogic oMaestroLogic = new MaestroLogic();
            List<BERegistro> Lista = oMaestroLogic.ListarComboDetalle(pCodTabla, pCodArgu, pNivel, 
                                                                      MaestroLogic.EstadoDetalle.Habilitado, 
                                                                      pcodEmpresa,
                                                                      pSegUsuario);
            List<BERegistro> newLista = new List<BERegistro>();

            newLista.Add(new BERegistro { CodigoArgumento = " ", DescripcionCorta = HelpComboBox.ObtenerTexto(pTexto) });
            newLista.AddRange(Lista);
            pComboBox.DataSource = newLista;
            pComboBox.DataTextField = "DescripcionCorta";
            pComboBox.DataValueField = "CodigoArgumento";
            pComboBox.DataBind();
        }


        /// <summary>
        /// Carga una lista de tipo TablasMaestrasRegistros en un CheckedListBox.
        /// Nombre:	CargarListadoGenerico
        /// Creacion: XX(OXINET) 20080920 - REQ:XXX
        /// Modificacion: XX(OXINET) 20080920 - REQ:XXX
        /// </summary>
        /// <param name="controlListado"></param>
        /// <param name="pCodTabla"></param>
        /// <param name="pCodArgu"></param>
        /// <param name="pNivel"></param>
        /// <param name="pEstado"></param>
        /// <param name="pIdioma"></param>
        /// <param name="pTipoDescripcion"></param>
        /// <param name="pUbicarCodArgu"></param>
        public static void CargarListadoGenerico(CheckedListBox controlListado, string pCodTabla, 
                                                 string pCodArgu, int pNivel, 
                                                 MaestroLogic.EstadoDetalle pEstado, 
                                                 MaestroLogic.TipoLongitudDetalle pTipoDescripcion, 
                                                 string pUbicarCodArgu,
                                                 int pcodEmpresa, string pSegUsuario)
        {
            MaestroLogic oMaestroLogic = new MaestroLogic();
            List<BERegistro> listado = oMaestroLogic.ListarComboDetalle(pCodTabla, pCodArgu, pNivel, pEstado, pcodEmpresa, pSegUsuario);
            List<CROM.Tools.Windows.ListItem> itemListado = new List<CROM.Tools.Windows.ListItem>();
            if (pTipoDescripcion == MaestroLogic.TipoLongitudDetalle.Larga)
            {
                listado.Sort(delegate(BERegistro parametro1, BERegistro parametro2)
                { return parametro1.DescripcionLarga.CompareTo(parametro2.DescripcionLarga); });
                controlListado.Items.Clear();
                foreach (BERegistro item in listado)
                {
                    itemListado.Add(new CROM.Tools.Windows.ListItem()
                    {
                        CodigoArgumento = item.CodigoArgumento,
                        Nombre = item.DescripcionCorta,
                        ValorEntero = item.ValorEntero,
                        ValorCadena = item.ValorCadena,
                        CodigoTabla = item.CodigoTabla,
                        Descripcion = item.DescripcionLarga,
                        ValorBoolean = item.ValorBoolean,
                        ValorDecimal = item.ValorDecimal,
                        ValorFecha = item.ValorFecha
                    }
                    );
                }
            }
            else
            {
                listado.Sort(delegate(BERegistro parametro1, BERegistro parametro2)
                { return parametro1.DescripcionCorta.CompareTo(parametro2.DescripcionCorta); });
                foreach (BERegistro item in listado)
                {
                    itemListado.Add(new CROM.Tools.Windows.ListItem()
                    {
                        CodigoArgumento = item.CodigoArgumento,
                        Nombre = item.DescripcionCorta,
                        ValorEntero = item.ValorEntero,
                        ValorCadena = item.ValorCadena,
                        CodigoTabla = item.CodigoTabla,
                        Descripcion = item.DescripcionLarga,
                        ValorBoolean = item.ValorBoolean,
                        ValorDecimal = item.ValorDecimal,
                        ValorFecha = item.ValorFecha
                    }
                    );
                }
            }
            controlListado.DataSource = itemListado;
            controlListado.DisplayMember = "Nombre";
            controlListado.ValueMember = "CodigoArgumento";
        }

        public static int DiasDePrestamo(DateTime prmFechaInicio, int DefaultDiasPrestamo, int DIAS_TOLERANCIA)
        {
            int DIAS_DE_PRESTAMO = 0;
            List<BEFeriado> lstFeriados = new List<BEFeriado>();
            FeriadosLogic oFeriadosLogic = new FeriadosLogic();
            lstFeriados = oFeriadosLogic.List(DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).Year.ToString(), string.Empty, null, true);

            int TOTAL_DIAS_A_CONTAR = (DefaultDiasPrestamo + DIAS_TOLERANCIA);
            DateTime Fecha_Final = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud());
            for (int dia = 1; dia <= TOTAL_DIAS_A_CONTAR; ++dia)
            {
                DateTime FechaABuscar = prmFechaInicio.AddDays(dia);
                string FechaFijaAnual = "0000" + FechaABuscar.Month.ToString().Trim().PadLeft(2, '0') + FechaABuscar.Day.ToString().Trim().PadLeft(2, '0');
                string FechaVariaAnual = DateTime.Now.Year.ToString().Trim() + FechaABuscar.Month.ToString().Trim().PadLeft(2, '0') + FechaABuscar.Day.ToString().Trim().PadLeft(2, '0');

                if (FechaABuscar.DayOfWeek == DayOfWeek.Sunday)
                    ++TOTAL_DIAS_A_CONTAR;
                else
                {
                    if (lstFeriados.Exists(x => x.Feriado == FechaFijaAnual))
                        ++TOTAL_DIAS_A_CONTAR;
                    if (lstFeriados.Exists(x => x.Feriado == FechaVariaAnual))
                        ++TOTAL_DIAS_A_CONTAR;
                }
                Fecha_Final = FechaABuscar;
            }
            double ndiasx = HelpTime.CantidadDias(Convert.ToDateTime(DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).ToShortDateString()), 
                                                  Convert.ToDateTime(Fecha_Final.ToShortDateString()), 
                                                  HelpTime.TotalTiempo.Dias, true);
            return DIAS_DE_PRESTAMO = Convert.ToInt32(ndiasx);
        }


    }
}

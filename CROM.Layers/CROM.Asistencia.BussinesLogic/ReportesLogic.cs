namespace CROM.Asistencia.BussinesLogic
{
    using CROM.BusinessEntities.Asistencia;
    using CROM.BusinessEntities.Maestros;
    using CROM.TablasMaestras.BussinesLogic;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.settings;
    using CROM.Tools.Config;

    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;


    /// <summary>
    /// Proyecto    : Módulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 12/01/2010-05:21:26 a.m.
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Asistencia.ReportesLogic.cs]
    /// </summary>
    public class ReportesLogic
    {
        public List<BEPersona> prm_miListaPersonas;

        private PersonasLogic oPersonasLogic = null;
        private MarcacionesLogic oMarcacionesLogic = null;
        private MaestroLogic oMaestroLogic = null;
        private PersonasAgendaLogic oPersonasAgendaLogic = null;
        private FeriadosLogic oFeriadosLogic = null;

        private ReturnValor oReturnValor = null;
        private List<BEFeriado> listaFeriados = new List<BEFeriado>();
        private List<BEPersonaAgenda> listaPersonasAgenda = new List<BEPersonaAgenda>();
        private string CodArguTipoEntidad;
        private bool SeCalculaTiempoEn60;

        public ReportesLogic(int pcodEmpresa)
        {
            oPersonasLogic = new PersonasLogic();
            oMarcacionesLogic = new MarcacionesLogic();
            oMaestroLogic = new MaestroLogic();
            oPersonasAgendaLogic = new PersonasAgendaLogic();
            oFeriadosLogic = new FeriadosLogic();

            oReturnValor = new ReturnValor();
            CodArguTipoEntidad = ConfigCROM.AppConfig(pcodEmpresa, ConfigTool.DEFAULT_PersonaPorDefecto);

            listaFeriados = oFeriadosLogic.List(DateTime.Now.Year.ToString(), string.Empty, null, true);
            listaPersonasAgenda = oPersonasAgendaLogic.List(string.Empty, string.Empty, true);
            SeCalculaTiempoEn60 = GlobalSettings.GetDEFAULT_Time60();
        }

        #region TABLA PERSONAS_ASISTENCIA

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Maestros.Personas
        /// En la BASE de DATO la Tabla : [Maestros.Personas]
        /// <summary>
        /// <returns>List</returns>
        public List<BETimeEmpleado> ListMarcaciones(int pcodEmpresa, DateTime prm_FechaHoraINI, DateTime prm_FechaHoraFIN, string pUserLogin)
        {

            List<BEPersona> miListaPersonas = new List<BEPersona>();
            List<BETimeEmpleado> listaTimeEmpleado = new List<BETimeEmpleado>();
            CalendariosLogic oCalendariosLogic = new CalendariosLogic();
            try
            {
                // ITERA la Lista de Empleados
                foreach (BEPersona itemPersona in prm_miListaPersonas)
                {
                    List<BEPersonaAtributo> listaPersonasAtributos = new List<BEPersonaAtributo>();
                    listaPersonasAtributos = oPersonasLogic.ListBy_PersonasAtributos(itemPersona.codEmpresa, itemPersona.CodigoPersona);
                    BETimeEmpleado itemTimeEmpleado = new BETimeEmpleado();
                    itemTimeEmpleado.CodigoPersona = itemPersona.CodigoPersona;
                    itemTimeEmpleado.Apellidos = itemPersona.itemDatoAdicional.ApellidoPaterno + " " + itemPersona.itemDatoAdicional.ApellidoMaterno;
                    itemTimeEmpleado.Nombres = itemPersona.itemDatoAdicional.Nombre1 + " " + itemPersona.itemDatoAdicional.Nombre2;
                    // Datos y Valores del Empleado para el Control de Asistencia
                    itemPersona.itemDatoAdicional = oPersonasLogic.FindPersonasDatosAdicionales(itemPersona.codEmpresa, 
                                                                                                           itemTimeEmpleado.CodigoPersona,
                                                                                                           pUserLogin);

                    string CODIGO_CALENDARIO = string.Empty;
                    string TARJETA_MARCACION = string.Empty;

                    //HelpMaestras.

                    // Si Tiene CALENDARIO
                    CODIGO_CALENDARIO = AtributoPersona(listaPersonasAtributos, ConfigurationManager.AppSettings["DEFAULT_CodigoCalendario"].ToString());
                    TARJETA_MARCACION = AtributoPersona(listaPersonasAtributos, ConfigurationManager.AppSettings["DEFAULT_NroDeTarjeta"].ToString());
                    if (!string.IsNullOrEmpty(CODIGO_CALENDARIO))
                    {
                        TARJETA_MARCACION = TARJETA_MARCACION.Trim().PadLeft(Convert.ToInt32(ConfigurationManager.AppSettings["DEFAULT_LongNumCard"]), '0');
                        itemTimeEmpleado.listaMarcaciones = oMarcacionesLogic.List(TARJETA_MARCACION, prm_FechaHoraINI, prm_FechaHoraFIN);
                        // Lista de TimeMarcaciones Datos completos de la Asistencia del Empleado
                        List<BETimeMarcacion> listaTimeMarcaciones = new List<BETimeMarcacion>();
                        // Lista de Marcaciones Datos completos del Registro de Marcaciones del RELOJ
                        List<BEMarcacion> listaMarcacionesFECHA_Actual = new List<BEMarcacion>();
                        // Fecha de INICIO
                        DateTime FECHA_Actual = prm_FechaHoraINI;
                        // CONTAR desde el PRIMER Dia Hasta el ULTIMO Día de UNo en UNO
                        double TOTAL_DE_DIAS = Math.Round(HelpTime.CantidadDias(prm_FechaHoraINI, prm_FechaHoraFIN, HelpTime.TotalTiempo.Dias, true), 0);
                        ++TOTAL_DE_DIAS;
                        for (int i = 1; i <= TOTAL_DE_DIAS; ++i)
                        {
                            // itemTimeMarcaciones para llenar un Registro de Marcación del EMPLEADO
                            BETimeMarcacion itemTimeMarcaciones = new BETimeMarcacion();
                            string DiaSemanaNOMBRE = string.Empty;
                            // Se Encuentra el Día de la Semana en Número y Nombre
                            int DiaSemanaNUMERO = HelpTime.DiaDeLaSemana(FECHA_Actual, out DiaSemanaNOMBRE);

                            itemTimeMarcaciones.CodigoPersona = itemPersona.CodigoPersona;
                            itemTimeMarcaciones.CodigoPersonaNombre = itemPersona.RazonSocial;
                            foreach (BEPersonaAtributo item in listaPersonasAtributos)
                                if (item.CodigoArguTipoAtributo == ConfigCROM.AppConfig(pcodEmpresa,
                                                                                        ConfigTool.DEFAULT_Atributo_NumerRUC))//  - ruc
                                    itemTimeMarcaciones.CodigoPersonaDNI = item.DescripcionAtributo;
                            itemTimeMarcaciones.DiaSemana = DiaSemanaNOMBRE.Substring(0, 3);
                            itemTimeMarcaciones.FechaHora = Convert.ToDateTime(FECHA_Actual.ToShortDateString());

                            string DIA_SEMANA_NOMBRE = string.Empty;
                            int DIA_SEMANA_NUMERO = HelpTime.DiaDeLaSemana(itemTimeMarcaciones.FechaHora, out DIA_SEMANA_NOMBRE);

                            BECalendario itemCalendarios = new BECalendario();
                            itemCalendarios = oCalendariosLogic.Find(CODIGO_CALENDARIO, true);

                            List<BECalendarioDia> itemCalendariosDias = new List<BECalendarioDia>();
                            // Encontrar el Horario de Trabajo de la FECHA_Actual del BUCLE
                            var queryCalendariosDIA = from itemDIA in itemCalendarios.listaCalendariosDias
                                                      //where  itemDIA.FechaInicio == itemTimeMarcaciones.FechaHora
                                                      where itemDIA.CodigoArguDiaSemana == "ADIAS00" + DIA_SEMANA_NUMERO.ToString().Trim()
                                                      select itemDIA;
                            itemCalendariosDias = queryCalendariosDIA.ToList<BECalendarioDia>();

                            // Se Obtiene Todas las Marcaciones del EMPLEADO por la Fecha actual del BUCLE
                            var queryMarcasFECHA_Actual = from ListaMarcasFECHA_Actual in itemTimeEmpleado.listaMarcaciones
                                                          where ListaMarcasFECHA_Actual.FechaTexto.ToShortDateString() == FECHA_Actual.ToShortDateString()
                                                          select ListaMarcasFECHA_Actual;
                            listaMarcacionesFECHA_Actual = queryMarcasFECHA_Actual.ToList<BEMarcacion>();
                            int MARCAS_CANTIDAD = listaMarcacionesFECHA_Actual.Count;
                            int MARCAS_CONTADOR = 0;
                            int MARCAS_VECES = 0;

                            itemTimeMarcaciones.HorarioEntrada = itemCalendariosDias[0].itemHorario.HEntrada == "00:00" ? "__:__" : itemCalendariosDias[0].itemHorario.HEntrada;
                            itemTimeMarcaciones.HorasTeoricasTIME60 = HelpTime.CantidadTiempoEn_HH_MM(Convert.ToDouble(itemCalendariosDias[0].itemHorario.HorasLabor));
                            itemTimeMarcaciones.HorasTeoricasDOUBLE = Convert.ToDouble(itemCalendariosDias[0].itemHorario.HorasLabor);

                            // SI TIENE MAS de una MARCACIÓN
                            if (MARCAS_CANTIDAD > 0)
                            {
                                // Colocar las Marcaciones existentes en el registro Horizontal de itemTimeMarcaciones
                                MarcacionesDeVerticalaHorizontal(listaMarcacionesFECHA_Actual, itemTimeMarcaciones, ref MARCAS_CONTADOR, ref MARCAS_VECES);
                                CalcularTiempoPersona(itemTimeMarcaciones, itemCalendariosDias[0].itemHorario, MARCAS_VECES);
                                itemTimeEmpleado.listaTimeMarcaciones.Add(itemTimeMarcaciones);
                            }
                            else
                            {
                                itemTimeMarcaciones.Entra01 = string.Empty;
                                itemTimeMarcaciones.Entra02 = string.Empty;
                                itemTimeMarcaciones.Salid01 = string.Empty;
                                itemTimeMarcaciones.Salid02 = string.Empty;
                                string decripcion = null;
                                if (DetectaAGENDA(itemTimeEmpleado.CodigoPersona, FECHA_Actual, FECHA_Actual.Year, ref decripcion))
                                {
                                    itemTimeMarcaciones.MarcacionesDescripcion = decripcion;
                                }
                                else if (DetectaFERIADO(itemCalendariosDias[0].itemHorario, FECHA_Actual, ref decripcion))
                                {
                                    itemTimeMarcaciones.MarcacionesDescripcion = decripcion;
                                }
                                else
                                {
                                    itemTimeMarcaciones.CONTADOR_VecesFalta = 1;
                                    itemTimeMarcaciones.MarcacionesDescripcion = decripcion;
                                }
                                itemTimeEmpleado.listaTimeMarcaciones.Add(itemTimeMarcaciones);
                            }
                            // La variable FECHA_Actual es Igual al Acumulado de prm_FechaHoraINI en UNO (Contador=i)
                            FECHA_Actual = prm_FechaHoraINI.AddDays(i);
                        }
                        listaTimeEmpleado.Add(itemTimeEmpleado);
                    }
                }
            }
            catch (Exception ex)
            {
                var returnValor = HelpException.mTraerMensaje(ex, false, this.GetType().Name + '.' + MethodBase.GetCurrentMethod().Name,
                                                              pUserLogin, pcodEmpresa.ToString());
                throw new Exception(returnValor.Message);
            }
            return listaTimeEmpleado;
        }

        private static void MarcacionesDeVerticalaHorizontal(List<BEMarcacion> listaMarcacionesFECHA_Actual, BETimeMarcacion itemTimeMarcaciones, ref int MARCAS_CONTADOR, ref int MARCAS_VECES)
        {
            foreach (BEMarcacion xyzMarca in listaMarcacionesFECHA_Actual)
            {
                if (MARCAS_CONTADOR == 0)
                {
                    itemTimeMarcaciones.Entra01 = string.Empty;
                    itemTimeMarcaciones.Entra02 = string.Empty;
                    itemTimeMarcaciones.Salid01 = string.Empty;
                    itemTimeMarcaciones.Salid02 = string.Empty;
                    itemTimeMarcaciones.Entra01 = xyzMarca.Hora;
                    ++MARCAS_VECES;
                }
                else if (MARCAS_CONTADOR == 1)
                {
                    itemTimeMarcaciones.Salid01 = xyzMarca.Hora;
                    ++MARCAS_VECES;
                }
                else if (MARCAS_CONTADOR == 2)
                {
                    itemTimeMarcaciones.Entra02 = xyzMarca.Hora;
                    ++MARCAS_VECES;
                }
                else if (MARCAS_CONTADOR == 3)
                {
                    itemTimeMarcaciones.Salid02 = xyzMarca.Hora;
                    ++MARCAS_VECES;
                }
                ++MARCAS_CONTADOR;
            }
        }

        private bool DetectaFERIADO(BEHorario itemHorario, DateTime FechaBuscar, ref string prm_DescripcionAusencia)
        {
            bool ESFERIADO = false;
            string prm_descripcionAusencia = string.Empty;


            // Se Obtiene Todas las Marcaciones del EMPLEADO por la Fecha actual del BUCLE
            var queryFERIADO = from ListaMarcasFECHA_Actual in listaFeriados
                               where ListaMarcasFECHA_Actual.Feriado.Substring(4, 4) == HelpTime.ConvertYYYYMMDD(FechaBuscar).Substring(4, 4)
                               select ListaMarcasFECHA_Actual;

            List<BEFeriado> ListaFeriado = new List<BEFeriado>();
            ListaFeriado = queryFERIADO.ToList<BEFeriado>();

            if (itemHorario.CodigoHorario == Convert.ToInt32(ConfigurationManager.AppSettings["DEFAULT_HorarioFeriado"]))
            {
                prm_descripcionAusencia = itemHorario.Descripcion;
                prm_DescripcionAusencia = prm_descripcionAusencia;
                ESFERIADO = true;
                return ESFERIADO;
            }
            else if (ListaFeriado.Count > 0)
            {
                prm_descripcionAusencia = ListaFeriado[0].Descripcion;
                prm_DescripcionAusencia = prm_descripcionAusencia;
                ESFERIADO = true;
            }
            else
            {

                prm_descripcionAusencia = "¡ NO TIENE MARCACIONES !";
                prm_DescripcionAusencia = prm_descripcionAusencia;
                ESFERIADO = false;
            }
            return ESFERIADO;
        }

        private bool DetectaAGENDA(string prm_CodigoEmpleado, DateTime prm_FechaBuscar, int prm_Anio, ref string prm_DescripcionAusencia)
        {
            bool ESAGENDA = false;
            string prm_descripcionAusencia = string.Empty;


            // Se Obtiene Todas las Marcaciones del EMPLEADO por la Fecha actual del BUCLE
            var queryAGENDA = from Lista in listaPersonasAgenda
                              where Lista.CodigoPersona == prm_CodigoEmpleado && Lista.Anio == prm_Anio
                              select Lista;
            List<BEPersonaAgenda> ListaPersonasAgenda = new List<BEPersonaAgenda>();
            ListaPersonasAgenda = queryAGENDA.ToList<BEPersonaAgenda>();

            foreach (BEPersonaAgenda jkl in ListaPersonasAgenda)
            {
                if (prm_FechaBuscar >= jkl.FechaInicio && prm_FechaBuscar <= jkl.FechaFinal)
                {
                    ESAGENDA = true;
                    prm_descripcionAusencia = jkl.CodigoJustificacionNombre;
                    prm_DescripcionAusencia = prm_descripcionAusencia;
                    break;
                }
            }
            return ESAGENDA;
        }

        private void CalcularTiempoPersona(BETimeMarcacion itemTimeMarcaciones, BEHorario itemHorario, int veces_MARCA)
        {
            double HORAS_PERMAN_NUME = 0;
            string HORAS_PERMAN_HORA = string.Empty;
            double HORAS_LABORA_NUME = 0;
            string HORAS_LABORA_HORA = string.Empty;

            string HORA_SALIR_REFRIG = string.Empty;
            string HORA_ENTRA_REFRIG = string.Empty;

            if (HelpTime.CantidadTiempoEn_DECIMAL(itemTimeMarcaciones.Entra01) < HelpTime.CantidadTiempoEn_DECIMAL(itemHorario.HEntrada))
            {
                if (itemTimeMarcaciones.Salid01 == string.Empty)
                    if (itemHorario.RefrigerioSalida != "00:00")
                        itemTimeMarcaciones.Salid01 = itemHorario.RefrigerioSalida.ToString();
            }
            if (itemTimeMarcaciones.Entra01 != string.Empty)
            {
                if (itemHorario.HEntrada != "00:00")
                {
                    string NUEVA_ENTRADA = string.Empty;
                    if (itemHorario.Tolerancia > 0)
                    {
                        double H_ENTRADA = HelpTime.CantidadTiempoEn_DECIMAL(itemHorario.HEntrada);
                        double M_ENTRADA = Convert.ToDouble(Convert.ToDouble(itemHorario.Tolerancia) / 60);
                        H_ENTRADA = H_ENTRADA + M_ENTRADA;
                        NUEVA_ENTRADA = HelpTime.CantidadTiempoEn_HH_MM(H_ENTRADA);
                    }
                    else
                        NUEVA_ENTRADA = itemHorario.HEntrada;
                    double MINUTOS_TARDE = HelpTime.CantidadTiempoEn_100(Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + NUEVA_ENTRADA), Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemTimeMarcaciones.Entra01), HelpTime.TotalTiempo.Minutos);
                    if (MINUTOS_TARDE > 0)
                    {
                        itemTimeMarcaciones.CONTADOR_MinutosTarde = Convert.ToInt32(MINUTOS_TARDE);
                        itemTimeMarcaciones.CONTADOR_VecesTarde = 1;
                    }
                }
            }
            if (itemTimeMarcaciones.Entra01 != string.Empty && itemTimeMarcaciones.Salid01 != string.Empty)
            {
                HORA_SALIR_REFRIG = itemTimeMarcaciones.Salid01;
                if (SeCalculaTiempoEn60)
                {
                    HORAS_PERMAN_NUME = HelpTime.CantidadTiempoEn_100(Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemTimeMarcaciones.Entra01), Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemTimeMarcaciones.Salid01), HelpTime.TotalTiempo.Horas);
                    HORAS_PERMAN_HORA = HelpTime.CantidadTiempoEn_HH_MM(HORAS_PERMAN_NUME);
                    if (itemHorario.HEntrada.ToString() != "00:00")
                    {
                        if (HelpTime.CantidadTiempoEn_DECIMAL(itemTimeMarcaciones.Salid01) < HelpTime.CantidadTiempoEn_DECIMAL(itemHorario.RefrigerioEntrada))
                        {
                            HORAS_LABORA_NUME = HelpTime.CantidadTiempoEn_100(Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemTimeMarcaciones.Entra01.ToString()), Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemTimeMarcaciones.Salid01), HelpTime.TotalTiempo.Horas);
                            HORAS_LABORA_HORA = HelpTime.CantidadTiempoEn_HH_MM(HORAS_LABORA_NUME);
                        }
                        else
                        {
                            double HORA_TRABAJO = HelpTime.CantidadTiempoEn_DECIMAL(itemTimeMarcaciones.Entra01) - HelpTime.CantidadTiempoEn_DECIMAL(itemHorario.HEntrada);
                            if (HelpTime.CantidadTiempoEn_DECIMAL(itemTimeMarcaciones.Salid01) < HelpTime.CantidadTiempoEn_DECIMAL(itemHorario.HSalida))
                                HORAS_LABORA_NUME = HelpTime.CantidadTiempoEn_100(Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemHorario.HEntrada.ToString()), Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemTimeMarcaciones.Salid01), HelpTime.TotalTiempo.Horas) - HORA_TRABAJO;
                            else
                                HORAS_LABORA_NUME = HelpTime.CantidadTiempoEn_100(Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemHorario.HEntrada.ToString()), Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemHorario.HSalida), HelpTime.TotalTiempo.Horas) - HORA_TRABAJO;
                            if (HORAS_LABORA_NUME > 0)
                                HORAS_LABORA_HORA = HelpTime.CantidadTiempoEn_HH_MM(HORAS_LABORA_NUME);
                            else
                                HORAS_LABORA_HORA = "00:00";
                        }
                    }
                    else
                    {
                        HORAS_LABORA_NUME = HORAS_PERMAN_NUME;
                        HORAS_LABORA_HORA = HORAS_PERMAN_HORA;
                    }
                }
                else
                {
                    HORAS_PERMAN_NUME = HelpTime.CantidadTiempoEn_100(Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemTimeMarcaciones.Entra01), Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemTimeMarcaciones.Salid01), HelpTime.TotalTiempo.Horas);
                    HORAS_PERMAN_HORA = Math.Round((decimal)HORAS_PERMAN_NUME, 2).ToString();
                    HORAS_LABORA_NUME = HelpTime.CantidadTiempoEn_100(Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemHorario.HEntrada.ToString()), Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemTimeMarcaciones.Salid01), HelpTime.TotalTiempo.Horas);
                    HORAS_LABORA_HORA = Math.Round((decimal)HORAS_LABORA_NUME, 2).ToString();
                }
            }
            if (itemTimeMarcaciones.Entra02 != string.Empty && itemTimeMarcaciones.Salid02 != string.Empty)
            {
                HORA_ENTRA_REFRIG = itemTimeMarcaciones.Entra02;
                if (SeCalculaTiempoEn60)
                {
                    HORAS_PERMAN_NUME = HORAS_PERMAN_NUME + (HelpTime.CantidadTiempoEn_100(Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemTimeMarcaciones.Entra02), Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemTimeMarcaciones.Salid02), HelpTime.TotalTiempo.Horas));
                    HORAS_PERMAN_HORA = HelpTime.CantidadTiempoEn_HH_MM(HORAS_PERMAN_NUME);
                    if (itemHorario.HEntrada.ToString() != "00:00")
                    {
                        HORAS_LABORA_NUME = HORAS_LABORA_NUME + (HelpTime.CantidadTiempoEn_100(Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemTimeMarcaciones.Entra02.ToString()), Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemHorario.HSalida), HelpTime.TotalTiempo.Horas));
                        HORAS_LABORA_HORA = HelpTime.CantidadTiempoEn_HH_MM(HORAS_LABORA_NUME);
                    }
                    else
                    {
                        HORAS_LABORA_NUME = HORAS_PERMAN_NUME;
                        HORAS_LABORA_HORA = HORAS_PERMAN_HORA;
                    }
                }
                else
                {
                    HORAS_PERMAN_NUME = HORAS_PERMAN_NUME + (HelpTime.CantidadTiempoEn_100(Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemTimeMarcaciones.Entra02), Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemTimeMarcaciones.Salid02), HelpTime.TotalTiempo.Horas));
                    HORAS_PERMAN_HORA = Math.Round((decimal)HORAS_PERMAN_NUME, 2).ToString();
                    HORAS_LABORA_NUME = HORAS_LABORA_NUME + (HelpTime.CantidadTiempoEn_100(Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemHorario.HEntrada.ToString()), Convert.ToDateTime(itemTimeMarcaciones.FechaHora.ToShortDateString() + " " + itemTimeMarcaciones.Salid02), HelpTime.TotalTiempo.Horas));
                    if (HORAS_LABORA_NUME > 0)
                        HORAS_LABORA_HORA = Math.Round((decimal)HORAS_LABORA_NUME, 2).ToString();
                    else
                        HORAS_LABORA_HORA = "00.00";
                }
            }
            else
            {
                HORAS_PERMAN_HORA = "00:00";
                HORAS_LABORA_HORA = "00:00";
            }
            if (itemTimeMarcaciones.Entra01 != string.Empty)
                itemTimeMarcaciones.MarcacionesDescripcion = " E " + itemTimeMarcaciones.Entra01;
            if (itemTimeMarcaciones.Salid01 != string.Empty)
                itemTimeMarcaciones.MarcacionesDescripcion = itemTimeMarcaciones.MarcacionesDescripcion + "  S " + itemTimeMarcaciones.Salid01;
            if (itemTimeMarcaciones.Entra02 != string.Empty)
                itemTimeMarcaciones.MarcacionesDescripcion = itemTimeMarcaciones.MarcacionesDescripcion + " E " + itemTimeMarcaciones.Entra02;
            if (itemTimeMarcaciones.Salid02 != string.Empty)
                itemTimeMarcaciones.MarcacionesDescripcion = itemTimeMarcaciones.MarcacionesDescripcion + "  S " + itemTimeMarcaciones.Salid02;


            itemTimeMarcaciones.HorasPermanenTIME60 = HORAS_PERMAN_HORA;
            itemTimeMarcaciones.HorasLaboradaTIME60 = HORAS_LABORA_HORA;
            double HORAS_DEBE = HelpTime.CantidadTiempoEn_DECIMAL(itemTimeMarcaciones.HorasTeoricasTIME60) - HelpTime.CantidadTiempoEn_DECIMAL(HORAS_LABORA_HORA);
            if (HORAS_DEBE > 0)
            {
                itemTimeMarcaciones.HorasDebeTiemDOUBLE = HORAS_DEBE;
                itemTimeMarcaciones.HorasDebeTiemTIME60 = HelpTime.CantidadTiempoEn_HH_MM(HORAS_DEBE);
            }
            itemTimeMarcaciones.HorasPermanenDOUBLE = HelpTime.CantidadTiempoEn_DECIMAL(HORAS_PERMAN_HORA);
            itemTimeMarcaciones.HorasLaboradaDOUBLE = HelpTime.CantidadTiempoEn_DECIMAL(HORAS_LABORA_HORA);

            itemTimeMarcaciones.RefrigerTeoriTIME60 = HelpTime.CantidadTiempoEn_HH_MM((double)itemHorario.MinAlmuerzo / 60);
            itemTimeMarcaciones.RefrigerTeoriDOUBLE = itemHorario.MinAlmuerzo / 60;

            if (HORA_ENTRA_REFRIG != string.Empty && HORA_SALIR_REFRIG != string.Empty)
            {
                itemTimeMarcaciones.RefrigerRealiDOUBLE = HelpTime.CantidadTiempoEn_DECIMAL(HORA_ENTRA_REFRIG) - HelpTime.CantidadTiempoEn_DECIMAL(HORA_SALIR_REFRIG);
                itemTimeMarcaciones.RefrigerRealiTIME60 = HelpTime.CantidadTiempoEn_HH_MM(itemTimeMarcaciones.RefrigerRealiDOUBLE);
                if (itemTimeMarcaciones.RefrigerRealiDOUBLE > (itemHorario.MinAlmuerzo / 60))
                {
                    itemTimeMarcaciones.RefrigerExcesDOUBLE = (itemTimeMarcaciones.RefrigerRealiDOUBLE - (itemHorario.MinAlmuerzo / 60));
                    itemTimeMarcaciones.RefrigerExcesTIME60 = HelpTime.CantidadTiempoEn_HH_MM((itemTimeMarcaciones.RefrigerRealiDOUBLE - (itemHorario.MinAlmuerzo / 60)));
                }
            }
        }


        private static string AtributoPersona(List<BEPersonaAtributo> prmlistaPersonasAtributos, string CodigoAtributo)//, bool ubigeo
        {
            string UBIGEOS_CAD = string.Empty;
            string DATO_DEVUELTO = string.Empty;

            var query = from item in prmlistaPersonasAtributos
                        where item.CodigoArguTipoAtributo == CodigoAtributo
                        select item;

            List<BEPersonaAtributo> listaPA = new List<BEPersonaAtributo>();
            listaPA = query.ToList<BEPersonaAtributo>();
            if (listaPA.Count > 0)
            {
                BEPersonaAtributo itemPA = new BEPersonaAtributo();
                itemPA = listaPA[0];

                DATO_DEVUELTO = itemPA.DescripcionAtributo;
                //if (ubigeo)
                //{
                //    string d1prm_EmisorUbigeo = itemPA.CodigoArguUbigeoNombre.Trim();
                //    UBIGEOS_CAD = new MaestroLogic().ObtenerUbigeo(itemPA.CodigoArguUbigeo);
                //    ubigeos = UBIGEOS_CAD.Split('@');
                //    for (int h = 0; h < ubigeos.Length; ++h)
                //    {
                //        if (h == 1)
                //        {
                //            if (d1prm_EmisorUbigeo.Trim().ToUpper() != ubigeos[h].Trim().ToUpper())
                //                d1prm_EmisorUbigeo = d1prm_EmisorUbigeo + " - " + ubigeos[h];
                //        }
                //    }
                //    DATO_DEVUELTO = d1prm_EmisorUbigeo;
                //}
            }
            return DATO_DEVUELTO;
        }

        //private static string DomicilioPersona(List<BEPersonasDomicilio> prmlistaPersonasDomicilios, 
        //                                       TipoDomicilio pTipoDomicilio = TipoDomicilio.FISCAL_PRINCIPAL)//, bool ubigeo
        //{
        //    string[] ubigeos;
        //    string UBIGEOS_CAD = string.Empty;
        //    string DATO_DEVUELTO = string.Empty;

        //    var query = from item in prmlistaPersonasDomicilios
        //                where item.codRegTipo == (int)pTipoDomicilio
        //                select item;

        //    List<BEPersonasDomicilio> listaPersonasDomicilio = new List<BEPersonasDomicilio>();
        //    listaPersonasDomicilio = query.ToList<BEPersonasDomicilio>();
        //    if (listaPersonasDomicilio.Count > 0)
        //    {
        //        BEPersonasDomicilio itemPersonasDomicilio = new BEPersonasDomicilio();
        //        itemPersonasDomicilio = listaPersonasDomicilio[0];

        //        DATO_DEVUELTO = itemPersonasDomicilio.gloDireccionSunat;
        //        //if (ubigeo)
        //        //{
        //            string d1prm_EmisorUbigeo = itemPersonasDomicilio.codUbigeoNombre.Trim();
        //            UBIGEOS_CAD = new MaestroLogic().ObtenerUbigeo(itemPersonasDomicilio.codUbigeoCode);
        //            ubigeos = UBIGEOS_CAD.Split('@');
        //            for (int h = 0; h < ubigeos.Length; ++h)
        //            {
        //                if (h == 1)
        //                {
        //                    if (d1prm_EmisorUbigeo.Trim().ToUpper() != ubigeos[h].Trim().ToUpper())
        //                        d1prm_EmisorUbigeo = d1prm_EmisorUbigeo + " - " + ubigeos[h];
        //                }
        //            }
        //            DATO_DEVUELTO = d1prm_EmisorUbigeo;
        //        //}
        //    }
        //    return DATO_DEVUELTO;
        //}

        #endregion
    }
}

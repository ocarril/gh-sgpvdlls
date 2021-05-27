namespace CROM.Tools.Comun
{
    using CROM.Tools.Comun.settings;

    using System;
    using System.Collections;
    using System.Collections.Generic;

    public static class HelpTime
    {
        /// <summary>Enumerador de Contenidos para calcular Totales de Tiempos
        /// <para>Objetivo: Enumerador de Contetenidos</para>
        /// <para>Creacion: Orlando Carril(OXINET) 20100327 - REQ:XXX.</para>
        /// <para>Edición:  Orlando Carril(OXINET) 20100327 - REQ:XXX.</para>
        /// </summary>
        public enum TotalTiempo
        {
            Dias,
            Horas,
            MiliSegundos,
            Minutos,
            Segundos
        }

        public static Dictionary<int, string> LstMesesAnio = new Dictionary<int, string>()
        {
            { 1, "Enero" },
            { 2, "Febrero" },
            { 3, "Marzo" },
            { 4, "Abril" },
            { 5, "Mayo" },
            { 6, "Junio" },
            { 7, "Julio" },
            { 8, "Agosto" },
            { 9, "Septiembre" },
            {10, "Octubre" },
            {11, "Noviembre" },
            {12, "Diciembre" }
        };

        public static int DiaDeLaSemana(DateTime fecha, out string sdia)
        {
            string[] DiasSemEsp = new string[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábados", "Domingos" };
            string[] DiasSemEng = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            ArrayList DiasSemEs = new ArrayList();
            ArrayList DiasSemEn = new ArrayList();
            DiasSemEs.AddRange(DiasSemEsp);
            DiasSemEn.AddRange(DiasSemEng);
            DayOfWeek dia = fecha.Date.DayOfWeek;
            int Posic = DiasSemEn.IndexOf(dia.ToString());
            sdia = DiasSemEs[Posic].ToString();
            return (Posic + 1);
        }

        public static Boolean VerificaIntervaloDeHora(String HoraIni, String HoraFin)
        {
            Boolean Pertenece = false;
            int horaIni = Convert.ToInt16(HoraIni.Substring(0, 2));
            int horaFin = Convert.ToInt16(HoraFin.Substring(0, 2));
            int horaAct = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).Hour;
            if (horaAct >= horaIni && horaAct <= horaFin)
                Pertenece = true;
            return (Pertenece);
        }

        public static String VerificaIntervaloDia(String HoraIni, String HoraFin)
        {
            String Pertenece = "";
            int horaIni = Convert.ToInt16(HoraIni.Substring(0, 2));
            int horaFin = Convert.ToInt16(HoraFin.Substring(0, 2));
            if (horaIni >= 6 && horaIni <= 12)
                Pertenece = "Mañana";
            else if (horaIni > 12 && horaIni <= 18)
                Pertenece = "Tarde";
            else if (horaIni > 18 && horaIni <= 05)
                Pertenece = "Noche";
            else
                Pertenece = "Libre";
            return (Pertenece);
        }

        public static double CantidadDias(DateTime dateTimeInicio, DateTime dateTimeFinal, TotalTiempo prm_Frecuencia, bool RedondeoTruncate)
        {
            TimeSpan ts = dateTimeFinal - dateTimeInicio;
            double differenceInFrecuencia = 0;
            switch (prm_Frecuencia)
            {
                case TotalTiempo.Dias:
                    if (RedondeoTruncate)
                        differenceInFrecuencia = Math.Truncate(ts.TotalDays);
                    else
                        differenceInFrecuencia = ts.TotalDays;
                    break;
                case TotalTiempo.Horas:
                    differenceInFrecuencia = ts.TotalHours;
                    break;
                case TotalTiempo.Minutos:
                    differenceInFrecuencia = ts.TotalMinutes;
                    break;
                case TotalTiempo.Segundos:
                    differenceInFrecuencia = ts.TotalSeconds;
                    break;
                case TotalTiempo.MiliSegundos:
                    differenceInFrecuencia = ts.TotalMilliseconds;
                    break;
            }
            return differenceInFrecuencia;
        }

        public static string ConvertYYYYMMDD(Nullable<DateTime> ValorFecha)
        {
            if (ValorFecha == null)
                return string.Empty;
            return ValorFecha.Value.Year.ToString().Trim() +
                   ValorFecha.Value.Month.ToString().Trim().PadLeft(2, '0') +
                   ValorFecha.Value.Day.ToString().Trim().PadLeft(2, '0');
        }

        public static string ConvertHHMMSSMM(Nullable<DateTime> ValorFecha)
        {
            if (ValorFecha == null)
                return string.Empty;
            return ValorFecha.Value.Hour.ToString().Trim().PadLeft(2, '0') +
                   ValorFecha.Value.Minute.ToString().Trim().PadLeft(2, '0') +
                   ValorFecha.Value.Second.ToString().Trim().PadLeft(2, '0') +
                   ValorFecha.Value.Millisecond.ToString().Trim().PadLeft(2, '0');
        }

        public static double CantidadTiempoEn_100(DateTime FechaActual, DateTime FichaFinal, TotalTiempo prm_Frecuencia)
        {
            TimeSpan ts = FichaFinal - FechaActual;
            double differenceInHours = 0;
            switch (prm_Frecuencia)
            {
                case TotalTiempo.Horas:
                    differenceInHours = ts.TotalHours;
                    break;
                case TotalTiempo.Minutos:
                    differenceInHours = ts.TotalMinutes;
                    break;
                case TotalTiempo.Segundos:
                    differenceInHours = ts.TotalSeconds;
                    break;
                case TotalTiempo.MiliSegundos:
                    differenceInHours = ts.TotalSeconds;
                    break;
                case TotalTiempo.Dias:
                    differenceInHours = ts.TotalSeconds;
                    break;
            }

            return differenceInHours;
        }

        public static string EsFechaValida(string Fecha)
        {
            string Mensaje = string.Empty;
            Fecha = Fecha == null ? string.Empty : Fecha;
            if (Fecha.Trim().Length == 10)
            {
                int nDIA = Convert.ToInt32(Fecha.Substring(0, 2).Trim());
                int nMES = Convert.ToInt32(Fecha.Substring(3, 2).Trim());
                int nANI = Convert.ToInt32(Fecha.Substring(6, 4).Trim());
                if (nDIA > 31 || nDIA == 0)
                    Mensaje = "¡ El día de la fecha es incorrecto !";
                if (nMES > 12 || nMES == 0)
                    Mensaje = "¡ El mes de la fecha es incorrecto !";
                if (nANI < 1900 || nANI == 0)
                    Mensaje = "¡ El año de la fecha es incorrecto !";
            }
            else
                Mensaje = "¡ La fecha ingresada es incorrecto !";
            return Mensaje;
        }

        public static Nullable<DateTime> ConvertYYYYMMDDToDate(string ValorFecha)
        {
            Nullable<DateTime> fecFestivo = null;
            if (string.IsNullOrEmpty(ValorFecha))
                return fecFestivo;
            try
            {
                //string strFecha = ValorFecha.Substring(6, 2) + "/" +
                //                  ValorFecha.Substring(4, 2) + "/" +
                //                  ValorFecha.Substring(0, 4);
                string strFecha = ValorFecha.Substring(0, 4) + "-" +
                                  ValorFecha.Substring(4, 2) + "-" +
                                  ValorFecha.Substring(6, 2)
                                  ;
                fecFestivo = Extensors.ToDateTime(strFecha);
            }
            catch (Exception ex)
            {
                fecFestivo = null;
            }

            return fecFestivo;
        }

        public static string CantidadTiempoEn_HH_MM(double TotalHours)
        {
            double differenceInHoras = TotalHours;
            int POSI_PUNTO = differenceInHoras.ToString("N2").IndexOf('.');
            string DIFER = differenceInHoras.ToString();
            string HORA = DIFER.Substring(0, POSI_PUNTO).PadLeft(2, '0');
            double hOraPri = Convert.ToDouble(DIFER.Substring(0, POSI_PUNTO));
            double diferencia = TotalHours - hOraPri;
            diferencia = diferencia * 60;
            int MINUTOS = Convert.ToInt32(Helper.DecimalRound((decimal)diferencia, 0));
            string MINUTO = MINUTOS.ToString().Trim().PadLeft(2, '0');
            return HORA + ":" + MINUTO;
        }
        public static double CantidadTiempoEn_Minutos(double TotalHours)
        {
            double differenceInHoras = TotalHours;
            int POSI_PUNTO = differenceInHoras.ToString("N2").IndexOf('.');
            string DIFER = differenceInHoras.ToString();
            string HORA = DIFER.Substring(0, POSI_PUNTO).PadLeft(2, '0');
            double hOraPri = Convert.ToDouble(DIFER.Substring(0, POSI_PUNTO));

            double diferencia = TotalHours - hOraPri;
            diferencia = diferencia * 60;

            int MINUTOS = Convert.ToInt32(Helper.DecimalRound((decimal)diferencia, 0));
            string MINUTO = MINUTOS.ToString().Trim().PadLeft(2, '0');

            double ValorDev = Convert.ToDouble(HORA) * 60 + (Convert.ToDouble(MINUTO));
            return ValorDev;
        }
        public static double CantidadTiempoEn_DECIMAL(string Hora)
        {
            int POSI_DOS_PUNTO = Hora.IndexOf(':');
            double HORA = Convert.ToDouble(Hora.Substring(0, POSI_DOS_PUNTO));
            double DECIMAL = Convert.ToDouble(Hora.Substring(POSI_DOS_PUNTO + 1, 2)) / 60;
            double HoraDecimal = HORA + DECIMAL;
            return HoraDecimal;
        }

        public static ulong DateTimeToUnixTimestamp(this DateTime dateTime)
        {
            return Convert.ToUInt64((dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds);
        }

        public static DateTime UnixTimeStampToDateTime(ulong unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(Convert.ToDouble(unixTimeStamp)).ToLocalTime();
            return dtDateTime;
        }


        public static DateTime AddTimeCurrentForDate(Nullable<DateTime> ValorFecha)
        {
            DateTime? DateTimeCurrent = null;
            if (ValorFecha == null)
            {
                DateTimeCurrent = DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud());
            }
            else
            {
                //ToString("dd-MM-yyyy HH:mm:ss")
                DateTimeCurrent = Extensors.ToDateTime(string.Concat(ValorFecha.Value.ToString("dd-MM-yyyy "), " ",
                                                                     DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud())
                                                                    .ToString("HH:mm:ss")));

            }
            return DateTimeCurrent.Value;
        }

    }
}

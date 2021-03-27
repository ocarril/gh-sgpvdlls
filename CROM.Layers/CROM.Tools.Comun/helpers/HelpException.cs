namespace CROM.Tools.Comun
{
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.settings;

    using System;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Runtime.Serialization;
    using System.Text;


    public static class HelpException
    {
        private static string TExcep = GlobalSettings.GetDEFAULT_TipoException();

        public static ReturnValor mTraerMensaje(Exception ex, bool indServicio = false, string pOrigen="", string pUser="USER", string pEmpresa="Empresa")
        {
            HelpLogging.Write(TraceLevel.Error, pOrigen, ex, string.Concat("Empresa: ", pEmpresa, " - User: ", pUser));

            ReturnValor oReturn = new ReturnValor();
            switch (ex.GetType().FullName)
            {
                case "System.Data.SqlClient.SqlException":
                    oReturn = mSqlException(ex);
                    break;
                case "System.IO.DirectoryNotFoundException":
                    oReturn = mDirectoryNotFoundException(ex);
                    break;
                case "System.ApplicationException":
                    oReturn = mApplicationException(ex);
                    break;
                default:
                    oReturn = mException(ex, indServicio);
                    break;
            }
            oReturn.Exitosa = false;
            return oReturn;
        }

        public static ReturnValor mSqlException(Exception ex)
        {

            ReturnValor oReturn = new ReturnValor();
            SqlException sqlex = (SqlException)ex;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(sqlex.GetType().FullName);
            sb.AppendLine("Error Number: " + sqlex.Number.ToString());
            sb.AppendLine("Source SQL: " + sqlex.Source);
            sb.AppendLine("Server: " + sqlex.Server);
            sb.AppendLine("Procedure: " + sqlex.Procedure);
            sb.AppendLine("LineNumber: " + sqlex.LineNumber.ToString());
            sb.AppendLine(sqlex.Message.ToString());
            if (TExcep == "USER")
            {
                //oReturn.Message = HelpMessages.ResourceManager.GetString(sqlex.Number.ToString());
                //if (string.IsNullOrEmpty(oReturn.Message))
                    oReturn.Message = HelpMessages.GeneralAPP_MensajeErrorUser.ToString();
            }
            else if (TExcep == "ADMIN")
                oReturn.Message = sb.ToString();
            return oReturn;
        }

        private static ReturnValor mDirectoryNotFoundException(Exception ex)
        {

            ReturnValor oReturn = new ReturnValor();
            System.IO.DirectoryNotFoundException ioex = (System.IO.DirectoryNotFoundException)ex;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ioex.GetType().FullName);
            sb.AppendLine("Error Number: " + ioex.GetHashCode().ToString());
            sb.AppendLine("Source IO: " + ioex.Source);
            sb.AppendLine("StackTrace: " + ioex.StackTrace.ToString());
            sb.AppendLine(ioex.Message.ToString());

            if (TExcep == "USER")
            {
                //oReturn.Message = HelpMessages.ResourceManager.GetString(ioex.GetHashCode().ToString());
                //if (string.IsNullOrEmpty(oReturn.Message))
                    oReturn.Message = HelpMessages.GeneralAPP_MensajeErrorUser.ToString();
            }
            else if (TExcep == "ADMIN")
                oReturn.Message = sb.ToString();

            return oReturn;
        }

        private static ReturnValor mException(Exception ex, bool indServicio)
        {
            ReturnValor oReturn = new ReturnValor();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ex.GetType().FullName);
            sb.AppendLine("Error Number: " + ex.GetHashCode().ToString());
            sb.AppendLine("Source GEN: " + ex.Source);
            sb.AppendLine("StackTrace: " + ex.StackTrace.ToString());
            sb.AppendLine(ex.Message.ToString());

            if (TExcep == "USER")
            {
                //oReturn.Message = HelpMessages.ResourceManager.GetString(ex.GetHashCode().ToString());
                //if (string.IsNullOrEmpty(oReturn.Message))
                    oReturn.Message = indServicio ? HelpMessages.GeneralWSERVICE_NoComunicacion.ToString() :
                                                    HelpMessages.GeneralAPP_MensajeErrorUser.ToString();
            }
            else if (TExcep == "ADMIN")
                oReturn.Message = sb.ToString();
         
            return oReturn;
        }

        private static ReturnValor mApplicationException(Exception ex)
        {
            ReturnValor oReturn = new ReturnValor();
            oReturn.Message = ex.Message;
            return oReturn;

        }
    }

    public class CROMException : Exception
    {
        public CROMException()
            : base()
        { }

        public CROMException(string message)
            : base(message)
        { }

        public CROMException(string format, params object[] args)
            : base(string.Format(format, args))
        { }

        public CROMException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public CROMException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        { }

        protected CROMException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}

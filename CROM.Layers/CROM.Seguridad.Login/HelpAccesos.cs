namespace CROM.Seguridad.Login
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesLogic;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Comun.security;

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class HelpAccesos 
    {
        public static string Sistema;
        private static string msPathWork = AppDomain.CurrentDomain.BaseDirectory.ToString();
        private static string msFileUser = "User.XML";
        private static ReturnValor oReturnValor = new ReturnValor();

        internal static void SerializarUsuario(BEUsuarioValidoResponse pUsuario)
        {
            try
            {
                // Crear Archivo para Guardar los Datos de La Clase
                FileStream fs = new FileStream(msPathWork + msFileUser, FileMode.Create);
                // Crear un Objeto XmlSerializer to perform the serialization
                XmlSerializer xs = new XmlSerializer(typeof(BEUsuarioValidoResponse));
                // Use the XmlSerializer object to serialize the data to the file
                xs.Serialize(fs, pUsuario);
                // Close the file
                fs.Close();
                return;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<BEUsuarioPermisoResponse> DeserializeRoles()
        {
            List<BEUsuarioPermisoResponse> listaRol = new List<BEUsuarioPermisoResponse>();
            try
            {
                BEUsuarioValidoResponse usuarioValidado = new BEUsuarioValidoResponse();
                usuarioValidado = DeserializeUsuario();
                listaRol = usuarioValidado.lstObjeto.ToList<BEUsuarioPermisoResponse>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listaRol;
        }

        public static List<BEUsuarioPermisoResponse> DeserializeRoles(string p_desEnlaceURL_WIN, bool p_appWindows)
        {
            List<BEUsuarioPermisoResponse> listaRoles = new List<BEUsuarioPermisoResponse>();
            List<BEUsuarioPermisoResponse> miRol = new List<BEUsuarioPermisoResponse>();
            try
            {
                BEUsuarioValidoResponse userValido = new BEUsuarioValidoResponse();
                userValido = DeserializeUsuario();
                listaRoles = userValido.lstObjeto.ToList<BEUsuarioPermisoResponse>();
                if (p_appWindows)
                {
                    var query = from item in listaRoles
                                where item.desEnlaceWIN == p_desEnlaceURL_WIN
                                select item;

                    miRol = query.ToList<BEUsuarioPermisoResponse>();
                }
                else
                {
                    var query = from item in listaRoles
                                where item.desEnlaceURL == p_desEnlaceURL_WIN
                                select item;

                    miRol = query.ToList<BEUsuarioPermisoResponse>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return miRol;
        }

        public static BEUsuarioPermisoResponse DeserializeRolOpcion(string p_desEnlaceURL_WIN, bool p_appWindows)
        {
            BEUsuarioPermisoResponse ItemOpcion = new BEUsuarioPermisoResponse();
            try
            {
                BEUsuarioValidoResponse oUsuarioValido = new BEUsuarioValidoResponse();
                oUsuarioValido = DeserializeUsuario();
                var misRoles = oUsuarioValido.lstObjeto.ToList<BEUsuarioPermisoResponse>();
                if (p_appWindows)
                {
                    var query = from item in misRoles
                                where item.desEnlaceWIN == p_desEnlaceURL_WIN
                                select item;
                    if (query.ToList<BEUsuarioPermisoResponse>().Count() == 1)
                        ItemOpcion = query.ToList<BEUsuarioPermisoResponse>()[0];
                    else ItemOpcion = null;
                }
                else
                {
                    var query = from item in misRoles
                                where item.desEnlaceURL == p_desEnlaceURL_WIN
                                select item;
                    if (query.ToList<BEUsuarioPermisoResponse>().Count() == 1)
                        ItemOpcion = query.ToList<BEUsuarioPermisoResponse>()[0];
                    else ItemOpcion = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ItemOpcion;
        }

        public static BEUsuarioValidoResponse DeserializeUsuario()
        {
            BEUsuarioValidoResponse miUsuario = new BEUsuarioValidoResponse();
            try
            {
                // Crear file to save the data to
                FileStream fs = new FileStream(msPathWork + msFileUser, FileMode.Open);
                // Crear un Objeto XmlSerializer para perform the deserialization
                XmlSerializer xs = new XmlSerializer(typeof(BEUsuarioValidoResponse));
                // Use the XmlSerializer object to deserialize the data to the file
                miUsuario = (BEUsuarioValidoResponse)xs.Deserialize(fs);
                // Close the file
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return miUsuario;
        }

        public static void EliminarExistenciaDeCarpetaFiles()
        {
            try
            {
                if (File.Exists(msPathWork + msFileUser))
                    File.Delete(msPathWork + msFileUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string ObtenerUsuario()
        {

            BEUsuarioValidoResponse oUsuario = new BEUsuarioValidoResponse();
            oUsuario = DeserializeUsuario();
            return oUsuario.desLogin;
        }

        public static List<BERolAux> ListaRol(string pCodSistema)
        {
            List<BERolAux> listaRol = new List<BERolAux>();
            listaRol = new RolLogic().List(string.Empty, pCodSistema, string.Empty, true, Helper.ComboBoxText.Select);
            return listaRol;
        }

    }
}

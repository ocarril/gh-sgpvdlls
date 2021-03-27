namespace CROM.BusinessEntities.Asistencia
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 30/07/2010-04:29:47 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [ConfiguracionSistema.cs]
    /// </summary>
    public class BEConfiguracionSistema
    {
        public string DEFAULT_NameSystem { get; set; }
        public double DEFAULT_OpacidadWindow { get; set; }
        public int DEFAULTDiasAntesConsultas { get; set; }
        public bool DEFAULTAutenticacionWindow { get; set; }
        public bool DEFAULTEliminacionMaestros { get; set; }
        public bool DEFAULTEliminacionMovimien { get; set; }
        public bool DEFAULTVerificaTablasInici { get; set; }
        public string DEFAULT_Idioma { get; set; }
        public string PATH_Empleados { get; set; }
        public string PATH_Sistema { get; set; }
        public string PATH_Importacion { get; set; }
        public string PATH_Exportacion { get; set; }
        public decimal DEFAULT_Size_FotoPersonas { get; set; }
        public decimal DEFAULT_Size_FotoLogotipo { get; set; }
        public string DEFAULT_TipoException { get; set; }


        public string CodigoArgumentoPerDefecto { get; set; }
        public string CodigoArgumentoPerNatural { get; set; }
        public string CodigoArgumentoPerJuridic { get; set; }

        public string DefaultCategEmpleado { get; set; }
        public string DefaultDocumPersNatur { get; set; }
        public string DefaultDocumPersJurid { get; set; }
        public string DefaultUbigeo { get; set; }

        public string DEFAULT_Formato_Archivo { get; set; }

        public decimal DEFAULT_SizeFTransferMB { get; set; }

        public string DEFAULT_SistemaInicio { get; set; }
        public string SistemaSeguridad { get; set; }
        public int WidthPantalla { get; set; }
        public int HeightPantalla { get; set; }
        public int WidthPantallaP { get; set; }
        public int HeightPantallaP { get; set; }

        public string CNX_System_ServerDB { get; set; }
        public string CNX_System_DataBase { get; set; }
        public string CNX_System_UserDBas { get; set; }
        public string CNX_System_Password { get; set; }

        public string CNX_Security_ServerDB { get; set; }
        public string CNX_Security_DataBase { get; set; }
        public string CNX_Security_UserDBas { get; set; }
        public string CNX_Security_Password { get; set; }

        public string EMAIL_Host { get; set; }
        public string EMAIL_CredencialUser { get; set; }
        public string EMAIL_CredencialPass { get; set; }
        public int EMAIL_Puerto { get; set; }
        public bool EMAIL_ActivarSSL { get; set; }
        public string EMAIL_Asunto { get; set; }
        public string EMAIL_CorreoDE { get; set; }



        public bool DEFAULT_DiasAntesFechaDMes { get; set; }
        public string DEFAULT_PATH_Marcaciones { get; set; }
        public string DEFAULT_FileMarcas { get; set; }
        public string DEFAULT_Reloj { get; set; }
        public string DEFAULT_FormatoReloj { get; set; }
        public bool DEFAULT_Time60 { get; set; }
        public int DEFAULT_LongNumCard { get; set; }
        public string DEFAULT_HorarioFeriado { get; set; }

        public string DEFAULT_Encriptacion { get; set; }

    }
}
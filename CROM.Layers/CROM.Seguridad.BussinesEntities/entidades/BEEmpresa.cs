namespace CROM.Seguridad.BussinesEntities
{
    using CROM.Seguridad.BussinesEntities.entidades;
    using CROM.Seguridad.BussinesEntities.entidades.dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 8/10/2019-15:55:24
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Seguridad.Empresa.cs]
    /// </summary>
    public class BEEmpresa : BEBase
    {
        public BEEmpresa()
        {
            nomRazonSocial = string.Empty;
            numRUC = string.Empty;
            nomLogo = string.Empty;
            nomContacto = string.Empty;
            desCorreo = string.Empty;
            desPaginaWeb = string.Empty;
            codEmpresaKey = string.Empty;
            segUsuarioCrea = string.Empty;
            segUsuarioEdita = string.Empty;
            segMaquinaCrea = string.Empty;
            segMaquinaEdita = string.Empty;
        }

        public int codEmpresa { get; set; }
        public string nomRazonSocial { get; set; }
        public string numRUC { get; set; }
        public string nomLogo { get; set; }
        public string nomContacto { get; set; }
        public string desCorreo { get; set; }
        public string desPaginaWeb { get; set; }
        public string codEmpresaKey { get; set; }
        public bool indActivo { get; set; }

        public bool indEliminado { get; set; }
    }


    public class BEEmpresaResponse : BEBasePaged
    {
        public BEEmpresaResponse()
        {
            nomRazonSocial = string.Empty;
            numRUC = string.Empty;
            nomLogo = string.Empty;
            nomContacto = string.Empty;
            desCorreo = string.Empty;
            desPaginaWeb = string.Empty;
            segUsuarioEdita = string.Empty;
            segMaquinaEdita = string.Empty;
        }

        public int codEmpresa { get; set; }
        public string nomRazonSocial { get; set; }
        public string numRUC { get; set; }
        public string nomLogo { get; set; }
        public string nomContacto { get; set; }
        public string desCorreo { get; set; }
        public string desPaginaWeb { get; set; }
        public string codEmpresaKey { get; set; }
        public bool indActivo { get; set; }

    }

    public class BEEmpresaRequest: BEBaseRequest
    {
        public BEEmpresaRequest()
        {
            nomRazonSocial = string.Empty;
            numRUC = string.Empty;
            nomLogo = string.Empty;
            nomContacto = string.Empty;
            desCorreo = string.Empty;
            desPaginaWeb = string.Empty;
            segUsuarioEdita = string.Empty;
            segMaquinaEdita = string.Empty;
        }

        public int codEmpresa { get; set; }
        public string nomRazonSocial { get; set; }
        public string numRUC { get; set; }
        public string nomLogo { get; set; }
        public string nomContacto { get; set; }
        public string desCorreo { get; set; }
        public string desPaginaWeb { get; set; }
        public bool indActivo { get; set; }

    }
}

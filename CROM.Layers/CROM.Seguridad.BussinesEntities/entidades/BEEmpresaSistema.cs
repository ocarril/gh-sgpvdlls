using CROM.Seguridad.BussinesEntities.entidades.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CROM.Seguridad.BussinesEntities
{
    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 8/10/2019-15:55:24
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Seguridad.EmpresaSistema.cs]
    /// </summary>
    public class BEEmpresaSistema : BEBase
    {
        public BEEmpresaSistema()
        {
            codSistema = string.Empty;
            segUsuarioCrea = string.Empty;
            segUsuarioEdita = string.Empty;
            segMaquinaCrea = string.Empty;
            segMaquinaEdita = string.Empty;
        }
        public int codEmpresaSistema { get; set; }
        public int codEmpresa { get; set; }
        public string codSistema { get; set; }
        public bool indActivo { get; set; }
        public DateTime fecInicio { get; set; }
        public DateTime fecFinal { get; set; }
        public int numTiempoToken { get; set; }
        public bool indEliminado { get; set; }
    }

    public class BEEmpresaSistemaRespose : BEBasePaged
    {
        public BEEmpresaSistemaRespose()
        {
            nomEmpresa = string.Empty;
            nomSistema = string.Empty;
            segUsuarioEdita = string.Empty;
            segMaquinaEdita = string.Empty;
        }

        public int codEmpresaSistema { get; set; }
        public string nomEmpresa { get; set; }
        public string nomSistema { get; set; }
        public bool indActivo { get; set; }
        public DateTime fecInicio { get; set; }
        public DateTime fecFinal { get; set; }

        public int numTiempoToken { get; set; }

        public bool indEliminado { get; set; }
    }

    public class BEEmpresaSistemaRequest : BEBaseRequest
    {
        public BEEmpresaSistemaRequest()
        {
            codSistema = string.Empty;
            segUsuarioEdita = string.Empty;
            segMaquinaEdita = string.Empty;
        }
        public int codEmpresaSistema { get; set; }
        public int codEmpresa { get; set; }
        public string codSistema { get; set; }
        public bool indActivo { get; set; }
        public DateTime fecInicio { get; set; }
        public DateTime fecFinal { get; set; }

        public int numTiempoToken { get; set; }
        public bool indEliminado { get; set; }
    }
}

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
    /// Fecha       : 24/09/2019-00:54:24
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Seguridad.EmpresaSistema.cs]
    /// </summary>
   

    public class BEEmpresaSistemaLicenciaRespose : BEBasePaged
    {
        public BEEmpresaSistemaLicenciaRespose()
        {
            nomEmpresa = string.Empty;
            nomSistema = string.Empty;
            segUsuarioEdita = string.Empty;
            segMaquinaEdita = string.Empty;
        }

        public int codEmpresaSistemaLic { get; set; }

        public int codEmpresaSistema { get; set; }

        public string nomEmpresa { get; set; }

        public string nomSistema { get; set; }

        public bool indActivo { get; set; }

        public DateTime fecInicio { get; set; }

        public DateTime fecFinal { get; set; }

        public int numTiempoToken { get; set; }

        public bool indEliminado { get; set; }
    }

}

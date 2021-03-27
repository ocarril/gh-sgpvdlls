using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CROM.BusinessEntities.Comercial.Entidades
{

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 24/02/2020-01:49 p.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.DocumentoSerieEmpleado.cs]
    /// </summary>
    public class BEDocumentoSerieEmpleado : BEBaseEntidad
    {
        public BEDocumentoSerieEmpleado()
        {

        }

        public int codDocumentoSerieEmpleado { get; set; }
        public int codDocumentoSerie { get; set; }
        public int codEmpleado { get; set; }

    }
}

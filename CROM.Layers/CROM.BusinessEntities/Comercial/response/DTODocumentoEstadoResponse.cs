namespace CROM.BusinessEntities.Comercial.response
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;



    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : LOG(OCR)
    /// Fecha       : 12/06/2020-01:07:10 a.m.
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [GestionComercial.DocumentoEstado.cs]
    /// </summary>
    public class DTODocumentoEstadoResponse : BEBaseEntidadItem
    {
        public int codDocumentoEstado { get; set; }
        public string codRegDocumento { get; set; }
        public string codRegEstado { get; set; }
        public int codEstado { get; set; }

        public string codRegDocumentoNombre { get; set; }
        public string codRegEstadoNombre { get; set; }

    }
}

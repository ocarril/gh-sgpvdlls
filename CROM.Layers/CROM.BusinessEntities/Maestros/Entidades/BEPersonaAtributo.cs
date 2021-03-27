namespace CROM.BusinessEntities.Maestros
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    

    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de la Tabla PersonasAtributos
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 30/12/2009
    /// Descripcion : Entidad de negocio
    /// Archivo     : PersonasAtributos.cs
    /// </summary>
    public class BEPersonaAtributo : BEBaseMaestro
    {
        public BEPersonaAtributo()
        {
            CodigoPersona = string.Empty;
            CodigoArguAtributo = string.Empty;
            CodigoArguTipoAtributo = string.Empty;
            CodigoArguTipoAtributoNombre = string.Empty;
            DescripcionAtributo = string.Empty;
            CodigoArguAtributoNombre = string.Empty;
        }
        public string CodigoPersona { get; set; }
        public string CodigoArguAtributo { get; set; }
        public string CodigoArguTipoAtributo { get; set; }
        public string DescripcionAtributo { get; set; }

        public string Proceso { get; set; }

        public string CodigoArguAtributoNombre { get; set; }
        public string CodigoArguTipoAtributoNombre { get; set; }

        public long ROW { get; set; }
        public int TOTALROWS { get; set; }
    }
}
